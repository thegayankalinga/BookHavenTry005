using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookHavenClassLibrary.Dtos.Sales;
using BookHavenClassLibrary.Interfaces;
using BookHavenClassLibrary.Models;
using BookHavenClassLibrary.Repositories;
using BookHavenWinFormUi.Utilz;
using Microsoft.IdentityModel.Tokens;

namespace BookHavenWinFormUi.PanelForms.Customer
{
    public partial class SalesForm: Form
    {
        private readonly ISalesRepository _salesRepository;
        private readonly IUserSessionService _userSessionService;
        private readonly IBookRepository _bookRepository;
        private readonly ICustomerRepository _customerRepository;

        private List<SalesResponseDto?> allSales = [];
        public SalesForm(ISalesRepository salesRepository, IUserSessionService userSessionService,
                 IBookRepository bookRepository, ICustomerRepository customerRepository)
        {
            _salesRepository = salesRepository;
            _userSessionService = userSessionService;
            _bookRepository = bookRepository;
            _customerRepository = customerRepository;
            InitializeComponent();
            this.Load += SalesForm_Load;
        }

        #region Form Events
        private async void SalesForm_Load(object sender, EventArgs e)
        {
            ConfigureGrid();
            await LoadListAsync();

            // Set up event handlers
            txtSearchKey.KeyPress += txtSearchKey_KeyPress;
            btnSearch.Click += btnSearch_Click;
            btnResetFilter.Click += btnResetFilter_Click;
            btnAddNewBook.Click += btnAddNewSale_Click;
            btnEditBook.Click += btnEditSale_Click;
            btnDeleteBook.Click += btnDeleteSale_Click;
        }
        #endregion

        #region Support Methods
        private void ConfigureGrid()
        {
            var columns = new List<(string, DataGridViewAutoSizeColumnMode)>
            {
                ("ID", DataGridViewAutoSizeColumnMode.AllCells),
                ("Customer", DataGridViewAutoSizeColumnMode.Fill),
                ("Date", DataGridViewAutoSizeColumnMode.AllCells),
                ("Total", DataGridViewAutoSizeColumnMode.AllCells),
                ("Delivery Method", DataGridViewAutoSizeColumnMode.AllCells),
                ("User", DataGridViewAutoSizeColumnMode.AllCells)
            };

            DataGridViewUtility.ConfigureGrid(gridViewBookList, columns);
        }

        private void DisplayAll(List<SalesResponseDto?> sales)
        {
            if (gridViewBookList.InvokeRequired)
            {
                gridViewBookList.BeginInvoke(new MethodInvoker(() => DisplayAll(sales)));
                return;
            }

            gridViewBookList.SuspendLayout();
            gridViewBookList.Rows.Clear();

            foreach (var sale in sales)
            {
                if (sale == null) continue;
                gridViewBookList.Rows.Add(
                    sale.SalesId,
                    sale.Customer?.FullName ?? "Walk-in Customer",
                    sale.SaleDate.ToString("yyyy-MM-dd"),
                    sale.TotalAmount.ToString("C"),
                    sale.DeliveryMethod.ToString(),
                    sale.User?.Email ?? "Unknown"
                );
            }

            gridViewBookList.ResumeLayout();
        }

        private bool isLoading = false;

        private async Task LoadListAsync()
        {
            if (isLoading) return;
            isLoading = true;

            try
            {
                allSales = await _salesRepository.GetAllAsync().ConfigureAwait(false);
                DisplayAll(allSales);
            }
            finally
            {
                isLoading = false;
            }
        }

        private void Search()
        {
            var key = txtSearchKey.Text.Trim().ToLower();
            var filteredSales = allSales.ToList();

            if (!string.IsNullOrWhiteSpace(key))
            {
                filteredSales = filteredSales.Where(s =>
                    (s.Customer?.FullName?.ToLower()?.Contains(key) == true) ||
                    s.SaleDate.ToString("yyyy-MM-dd").Contains(key) ||
                    s.TotalAmount.ToString().Contains(key) ||
                    (s.User?.Email?.ToLower()?.Contains(key) == true)
                ).ToList();
            }

            DisplayAll(filteredSales);
        }

        private int? GetSelectedSaleId()
        {
            if (gridViewBookList.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a sale.");
                return null;
            }

            var saleIdStr = gridViewBookList.SelectedRows[0].Cells["ID"].Value?.ToString();
            if (string.IsNullOrWhiteSpace(saleIdStr) || !int.TryParse(saleIdStr, out var saleId))
            {
                MessageBox.Show("Invalid sale ID.");
                return null;
            }

            return saleId;
        }
        #endregion


        #region CRUD Operations
        private async Task AddSaleAsync(SalesRequestDto sale)
        {
            try
            {
                // Ensure the current user is set for the sale
                sale.UserId = _userSessionService.CurrentUser.Id;
                if (sale.UserId.IsNullOrEmpty())
                {
                    MessageBox.Show($"Empty User ID");
                    return;
                }

                await _salesRepository.AddAsync(sale);
                MessageBox.Show("Sale added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadListAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding sale: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task UpdateSaleAsync(int id, SalesRequestDto sale)
        {
            try
            {
                await _salesRepository.UpdateAsync(id, sale);
                MessageBox.Show("Sale updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadListAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating sale: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task DeleteSaleAsync(int id)
        {
            try
            {
                await _salesRepository.DeleteAsync(id);
                MessageBox.Show("Sale deleted successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadListAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting sale: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Button Events
        private void txtSearchKey_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                Search();
            }
        }

        private async void btnResetFilter_Click(object sender, EventArgs e)
        {
            txtSearchKey.Clear();
            await LoadListAsync();
            DisplayAll(allSales);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void btnAddNewSale_Click(object sender, EventArgs e)
        {
            using (var form = new SalesDetailsForm(_userSessionService, _bookRepository, _customerRepository))
            {
                form.OnAdded += async (sale) =>
                {
                    await AddSaleAsync(sale);
                    //await LoadListAsync();
                };

                form.ShowDialog();
            }
        }

        private async void btnEditSale_Click(object sender, EventArgs e)
        {
            int? saleId = GetSelectedSaleId();
            if (!saleId.HasValue) return;

            var saleToEdit = allSales.FirstOrDefault(s => s?.SalesId == saleId.Value);
            if (saleToEdit == null) return;

            using (var form = new SalesDetailsForm(_userSessionService, saleToEdit, _bookRepository, _customerRepository))
            {
                form.OnUpdated += async (updatedSale) =>
                {
                    await UpdateSaleAsync(saleId.Value, updatedSale);
                };
                form.ShowDialog();
            }
        }

        private async void btnDeleteSale_Click(object sender, EventArgs e)
        {
            int? saleId = GetSelectedSaleId();
            if (!saleId.HasValue) return;

            var confirm = MessageBox.Show("Delete this sale?", "Confirm", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                await DeleteSaleAsync(saleId.Value);
            }
        }
        #endregion
    }
}
