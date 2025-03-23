using BookHavenClassLibrary.Dtos.Customer;
using BookHavenClassLibrary.Interfaces;
using BookHavenWinFormUi.Utilz;
using System.Data;
using System.Threading.Tasks;

namespace BookHavenWinFormUi.PanelForms.Customer
{
    public partial class CustomerForm : Form
    {
        private readonly ICustomerRepository _customerRepository;
        private List<CustomerResponseDto?> allCustomers = [];
        private int? editingCustomerId = null;
        public CustomerForm(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
            InitializeComponent();
            this.Load += CustomerForm_Load;
        }

        #region "Helpers"
        private void ConfigureGrid()
        {
            //This code has to change.
            var columns = new List<(string Name, DataGridViewAutoSizeColumnMode SizeMode)>
            {
                ("ID", DataGridViewAutoSizeColumnMode.AllCells),
                ("Full Name", DataGridViewAutoSizeColumnMode.Fill),
                ("Phone Number", DataGridViewAutoSizeColumnMode.AllCells),
                ("City", DataGridViewAutoSizeColumnMode.AllCells),
                //TOOD: Add no of Books Purchase
            };

            DataGridViewUtility.ConfigureGrid(gridViewCustomerList, columns);
        }

        private async Task LoadListAsync()
        {
            if (gridViewCustomerList.InvokeRequired)
            {
                gridViewCustomerList.Invoke(new MethodInvoker(async () => await LoadListAsync()));
                return;
            }

            if (gridViewCustomerList.Columns.Count == 0)
            {
                ConfigureGrid();
            }

            gridViewCustomerList.Rows.Clear();
            //This code has to change.
            allCustomers = await _customerRepository.GetAllAsync().ConfigureAwait(false);
            DisplayAll(allCustomers);
        }

        private void DisplayAll(List<CustomerResponseDto?> customersToDisplay)
        {

            if (gridViewCustomerList.InvokeRequired)
            {
                gridViewCustomerList.Invoke(new MethodInvoker(async () => DisplayAll(customersToDisplay)));
                return;
            }
            gridViewCustomerList.Rows.Clear();

            //This code has to change
            foreach (var customer in customersToDisplay)
            {
                if (customer == null) continue; // Skip null customers

                if (!gridViewCustomerList.Rows.Cast<DataGridViewRow>().Any(row => Convert.ToInt32(row.Cells["ID"].Value) == customer.Id))
                {
                    gridViewCustomerList.Rows.Add(
                        customer.Id,
                        customer.FullName,
                        customer.PhoneNumber,
                        customer.City
                    );
                }
            }


        }

        private async void Search()
        {
            var searchKey = txtSearchKey.Text.Trim().ToLower();
            if (string.IsNullOrWhiteSpace(searchKey))
            {
                await LoadListAsync();
                return;
            }
            var searchResults = allCustomers.Where(c => c.FullName.ToLower().Contains(searchKey.ToLower())).ToList();
            DisplayAll(searchResults);
        }

        private async void SaveAsync(CustomerRequestDto customer, int? id)
        {
            try
            {
                if (id == null)
                {
                    //New Book
                    await _customerRepository.AddAsync(customer);
                    MessageBox.Show("Customer Added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //Update book
                    await _customerRepository.UpdateAsync((int)id, customer);
                    MessageBox.Show("Customer Updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                await LoadListAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving customer: {ex.Message}", "Save Customer", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        #endregion

        #region "Events"
        private async void CustomerForm_Load(object sender, EventArgs e)
        {
            ConfigureGrid();
            await LoadListAsync();

        }



        private async void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            if (gridViewCustomerList.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a customer to delete", "Delete Customer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int customerId = Convert.ToInt32(gridViewCustomerList.SelectedRows[0].Cells["ID"].Value);
            string fullName = gridViewCustomerList.SelectedRows[0].Cells["Full Name"].Value.ToString();

            var confirmResult = MessageBox.Show($"Are you sure you want to delete {fullName}?", "Delete Customer", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    await _customerRepository.DeleteAsync(customerId).ConfigureAwait(false);
                    MessageBox.Show("Customer deleted successfully", "Delete Customer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadListAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting customer: {ex.Message}", "Delete Customer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            {

            }
        }

        #endregion

        private void btnEditCustomer_Click(object sender, EventArgs e)
        {
            if (gridViewCustomerList.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a customer to edit", "Edit Customer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int customerId = Convert.ToInt32(gridViewCustomerList.SelectedRows[0].Cells["ID"].Value);
            var customerToEdit = allCustomers.FirstOrDefault(c => c.Id == customerId);

            if (customerToEdit != null)
            {
                using (var customerDialog = new CustomerDetails(customerToEdit))
                {
                    customerDialog.ShowDialog();
                    if (customerDialog.DialogResult == DialogResult.OK)
                    {
                        CustomerRequestDto updateCustomer = customerDialog.Customer;

                        SaveAsync(updateCustomer, customerId);
                    }
                }

            }
        }

        private void btnAddNewCustomer_Click(object sender, EventArgs e)
        {
            using (var customerDialog = new CustomerDetails())
            {
                customerDialog.ShowDialog();
                if (customerDialog.DialogResult == DialogResult.OK)
                {
                    CustomerRequestDto newCustomer = customerDialog.Customer;
                    SaveAsync(newCustomer, null);
                }
            }
        }

        private void txtSearchKey_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                Search();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            
          Search();
           
        }
    }
}
