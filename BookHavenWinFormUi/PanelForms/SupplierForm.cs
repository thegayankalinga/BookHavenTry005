using BookHavenClassLibrary.Dtos.Supplier;
using BookHavenClassLibrary.Enumz;
using BookHavenClassLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookHavenWinFormUi.PanelForms
{
    public partial class SupplierForm : Form
    {
        private readonly ISupplierRepository _supplierRepository;
        private int? editingSupplierId = null;

        public SupplierForm(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
            InitializeComponent();
        }

        //Setting up the datagrid view configurations
        private void ConfigureDataGridView()
        {
            // Clear existing columns
            supplierDataGridView.Columns.Clear();

            // Add columns
            supplierDataGridView.ColumnCount = 5;
            supplierDataGridView.Columns[0].Name = "ID";
            supplierDataGridView.Columns[1].Name = "Supplier Name";
            supplierDataGridView.Columns[2].Name = "Type";
            supplierDataGridView.Columns[3].Name = "Contact Person";
            supplierDataGridView.Columns[4].Name = "Phone Number";

            // Set auto-sizing for better appearance
            supplierDataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; // ID
            supplierDataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // Supplier Name
            supplierDataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; // Type
            supplierDataGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; // Contact Person
            supplierDataGridView.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; // Phone Number

            // Set row height to make it look better
            supplierDataGridView.RowTemplate.Height = 30;

            // Enable full row selection
            supplierDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            supplierDataGridView.MultiSelect = false;

            // Set better visual appearance
            supplierDataGridView.AllowUserToAddRows = false;
            supplierDataGridView.AllowUserToResizeColumns = true;
            supplierDataGridView.AllowUserToResizeRows = false;
            supplierDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            supplierDataGridView.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            supplierDataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            supplierDataGridView.RowTemplate.Height = 30;
            supplierDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            supplierDataGridView.MultiSelect = false;
            supplierDataGridView.AllowUserToAddRows = false;

        }


        private async Task LoadSuppliersAsync()
        {
            var suppliers = await _supplierRepository.GetAllSuppliersAsync();
            supplierDataGridView.Rows.Clear();

            foreach (var supplier in suppliers)
            {
                supplierDataGridView.Rows.Add(
                    supplier.SupplierId, 
                    supplier.SupplierName, 
                    supplier.SupplierType.ToString(),
                    supplier.ContactPersonName, 
                    supplier.PhoneNumber);
            }
        }

        private async void saveButton_Click(object sender, EventArgs e)
        {
            SupplierTypes selectedSupplierType = GetSelectedSupplierType();
            SupplierRequestDto supplierRequestDto = new SupplierRequestDto
            {
                SupplierName = supplierNameText.Text,
                SupplierType = selectedSupplierType,
                ContactPersonName = supplierContactPerosnText.Text,
                PhoneNumber = supplierPhoneNumberText.Text
            };

            if (editingSupplierId == null)
            {
                await _supplierRepository.AddSupplierAsync(supplierRequestDto);

            }
            else
            {
                await _supplierRepository.UpdateSupplierAsync(editingSupplierId.Value, supplierRequestDto);
                editingSupplierId = null; // Reset edit mode
                saveButton.Text = "Save"; // Change button text back to "Save"
            }

            clearForm();

            await LoadSuppliersAsync();
        }

        private void clearForm()
        {
            supplierNameText.Text = "";
            supplierContactPerosnText.Text = "";
            supplierPhoneNumberText.Text = "";
            ResetRadioButtons();
            editingSupplierId = null; // Reset edit mode
            saveButton.Text = "Save";
        }

        private void ResetRadioButtons()
        {
            foreach (RadioButton rb in supplierTypeGroupBox.Controls.OfType<RadioButton>())
            {
                rb.Checked = false;
            }
        }

        private SupplierTypes GetSelectedSupplierType()
        {
            RadioButton? selectedSupplierType = supplierTypeGroupBox.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            if (selectedSupplierType != null)
            {
                if (Enum.TryParse(selectedSupplierType.Text, out SupplierTypes supplierType))
                {
                    return supplierType;
                }
            }

            return SupplierTypes.Individual;
        }

        private async void SupplierForm_Load(object sender, EventArgs e)
        {
            ConfigureDataGridView();
            await LoadSuppliersAsync();
        }

        private async void deleteButton_Click(object sender, EventArgs e)
        {
            if (supplierDataGridView.SelectedRows.Count > 0)
            {
                int supplierId = Convert.ToInt32(supplierDataGridView.SelectedRows[0].Cells[0].Value);

                var confirmResult = MessageBox.Show("Are you sure you want to delete this supplier?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirmResult == DialogResult.Yes)
                {
                    await _supplierRepository.DeleteSupplierAsync(supplierId);
                    await LoadSuppliersAsync();
                }
            }
            else
            {
                MessageBox.Show("Please select a supplier to delete.", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (supplierDataGridView.SelectedRows.Count > 0)
            {
                // Get selected row values
                editingSupplierId = Convert.ToInt32(supplierDataGridView.SelectedRows[0].Cells[0].Value);
                supplierNameText.Text = supplierDataGridView.SelectedRows[0].Cells[1].Value.ToString();
                string? supplierTypeText = supplierDataGridView.SelectedRows[0].Cells[2].Value.ToString();
                supplierContactPerosnText.Text = supplierDataGridView.SelectedRows[0].Cells[3].Value.ToString();
                supplierPhoneNumberText.Text = supplierDataGridView.SelectedRows[0].Cells[4].Value.ToString();

                // Set the radio button based on the type
                foreach (RadioButton rb in supplierTypeGroupBox.Controls.OfType<RadioButton>())
                {
                    if (rb.Text == supplierTypeText)
                    {
                        rb.Checked = true;
                        break;
                    }
                }

                // Change button text to "Update"
                saveButton.Text = "Update";
            }
            else
            {
                MessageBox.Show("Please select a supplier to edit.", "Edit Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
