using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookHavenClassLibrary.Dtos.Book;
using BookHavenClassLibrary.Dtos.Supplier;
using BookHavenClassLibrary.Enumz;
using BookHavenClassLibrary.Interfaces;
using BookHavenWinFormUi.PanelForms.Order;
using BookHavenWinFormUi.Utilz;

namespace BookHavenWinFormUi.PanelForms.Supplier
{
    public partial class OrderForm : Form
    {
        private readonly ISupplierOrderRepository _orderRepository;
        private readonly ISupplierRepository _supplierRepository;
        private readonly IBookRepository _bookRepository;
        private List<SupplierOrderResponseDto?> allOrders = [];
        private List<SupplierResponseDto?> allSuppliers = [];
        private List<BookResponseDto?> allBooks = [];
        public OrderForm(ISupplierOrderRepository orderRepository, ISupplierRepository supplierRepository, IBookRepository bookRepository)
        {
            InitializeComponent();
            _orderRepository = orderRepository;
            _supplierRepository = supplierRepository;
            _bookRepository = bookRepository;
        }

        #region Form Events
        private async void OrderForm_Load(object sender, EventArgs e)
        {
            ConfigureGrid();
            await LoadSuppliersAsync();
            await LoadBooksAsync();
            await LoadOrdersAsync();
        }
        #endregion

        #region Support Methods
        private void ConfigureGrid()
        {
            var columns = new List<(string, DataGridViewAutoSizeColumnMode)>
            {
                ("Order ID", DataGridViewAutoSizeColumnMode.AllCells),
                ("Supplier", DataGridViewAutoSizeColumnMode.Fill),
                ("Order Date", DataGridViewAutoSizeColumnMode.AllCells),
                ("Status", DataGridViewAutoSizeColumnMode.AllCells),
                ("Total Cost", DataGridViewAutoSizeColumnMode.AllCells)
            };

            DataGridViewUtility.ConfigureGrid(gridViewBookList, columns);
        }

        private async Task LoadSuppliersAsync()
        {
            allSuppliers = await _supplierRepository.GetAllSuppliersAsync();


            // Add "All Suppliers" option
            var supplierList = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("All Suppliers", "ALL")
            };

            // Add each supplier to the list
            foreach (var supplier in allSuppliers)
            {
                if (supplier != null)
                {
                    supplierList.Add(new KeyValuePair<string, object>(
                        supplier.SupplierName,
                        supplier.SupplierId));
                }
            }

            cmbAuthor.DataSource = supplierList;
            cmbAuthor.DisplayMember = "Key";
            cmbAuthor.ValueMember = "Value";
        }

        private async Task LoadBooksAsync()
        {
            allBooks = await _bookRepository.GetAllBooksAsync();

            // Add "All Books" option
            var bookList = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("All Books", "ALL")
            };

            // Add each book to the list
            foreach (var book in allBooks)
            {
                if (book != null)
                {
                    bookList.Add(new KeyValuePair<string, object>(
                        book.Title,
                        book.BookId));
                }
            }

            cmbGenre.DataSource = bookList;
            cmbGenre.DisplayMember = "Key";
            cmbGenre.ValueMember = "Value";
        }

        private async Task LoadOrdersAsync()
        {
            if (gridViewBookList.InvokeRequired)
            {
                gridViewBookList.Invoke(new MethodInvoker(async () => await LoadOrdersAsync()));
                return;
            }

            if (gridViewBookList.Columns.Count == 0)
                ConfigureGrid();

            gridViewBookList.Rows.Clear();
            allOrders = await _orderRepository.GetAllSupplierOrdersAsync();
            DisplayOrders(allOrders);
        }

        private void DisplayOrders(List<SupplierOrderResponseDto?> orders)
        {
            if (gridViewBookList.InvokeRequired)
            {
                gridViewBookList.Invoke(new MethodInvoker(() => DisplayOrders(orders)));
                return;
            }

            gridViewBookList.Rows.Clear();
            foreach (var order in orders)
            {
                if (order == null) continue;

                // Find supplier name
                string supplierName = "Unknown";
                var supplier = allSuppliers.FirstOrDefault(s => s?.SupplierId == order.SupplierId);
                if (supplier != null)
                {
                    supplierName = supplier.SupplierName;
                }

                gridViewBookList.Rows.Add(
                    order.SupplierOrderId,
                    supplierName,
                    order.OrderDate.ToString("yyyy-MM-dd"),
                    order.OrderStatuses.ToString(),
                    order.TotalPrice.ToString("C")
                );
            }
        }

        private void Search()
        {
            var searchKey = txtSearchKey.Text.Trim().ToLower();
            object selectedSupplierValue = cmbAuthor.SelectedValue ?? "ALL";
            object selectedBookValue = cmbGenre.SelectedValue ?? "ALL";

            var filteredOrders = allOrders.ToList();

            // Filter by search key
            if (!string.IsNullOrWhiteSpace(searchKey))
            {
                filteredOrders = filteredOrders.Where(o => {
                    if (o == null) return false;

                    // Find supplier name
                    var supplier = allSuppliers.FirstOrDefault(s => s?.SupplierId == o.SupplierId);
                    string supplierName = supplier?.SupplierName ?? "";

                    return supplierName.ToLower().Contains(searchKey) ||
                           o.SupplierOrderId.ToString().Contains(searchKey) ||
                           o.OrderDate.ToString().ToLower().Contains(searchKey) ||
                           o.OrderStatuses.ToString().ToLower().Contains(searchKey);
                }).ToList();
            }

            // Filter by supplier
            if (selectedSupplierValue is int supplierId)
            {
                filteredOrders = filteredOrders.Where(o => o?.SupplierId == supplierId).ToList();
            }

            // Filter by book (if selected)
            if (selectedBookValue is int bookId)
            {
                filteredOrders = filteredOrders.Where(o =>
                    o?.OrderItems.Any(item => item.BookId == bookId) ?? false
                ).ToList();
            }

            DisplayOrders(filteredOrders);
        }

        private int? GetSelectedOrderId()
        {
            if (gridViewBookList.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an order.");
                return null;
            }

            if (int.TryParse(gridViewBookList.SelectedRows[0].Cells["Order ID"].Value?.ToString(), out int orderId))
            {
                return orderId;
            }

            MessageBox.Show("Invalid order ID.");
            return null;
        }
        #endregion

        #region CRUD Operations
        private async Task CreateOrderAsync(SupplierOrderRequestDto orderDto)
        {
            try
            {
                await _orderRepository.AddSupplierOrderAsync(orderDto);
                MessageBox.Show("Order created successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadOrdersAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating order: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task UpdateOrderAsync(int orderId, SupplierOrderRequestDto orderDto)
        {
            try
            {
                await _orderRepository.UpdateSupplierOrderAsync(orderId, orderDto);
                MessageBox.Show("Order updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadOrdersAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating order: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task DeleteOrderAsync(int orderId)
        {
            try
            {
                await _orderRepository.DeleteSupplierOrderAsync(orderId);
                MessageBox.Show("Order deleted successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadOrdersAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting order: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            cmbAuthor.SelectedIndex = 0; // First item ("All Suppliers")
            cmbGenre.SelectedIndex = 0;  // First item ("All Books")
            await LoadOrdersAsync();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void btnAddNewBook_Click(object sender, EventArgs e)
        {
            // Create a new order with default values
            var newOrder = new SupplierOrderRequestDto
            {
                SupplierId = 0,
                OrderDate = DateOnly.FromDateTime(DateTime.Now),
                OrderStatuses = OrderStatuses.Pending
            };

            // Show order details form
            using (var form = new OrderDetailsForm(_bookRepository, _supplierRepository))
            {
                // TODO: Add implementation for creating a new order
                form.OnOrderCreated += async (neworder) =>
                {
                    await CreateOrderAsync(neworder);
                };
                form.ShowDialog();
            }
        }

        private async void btnEditBook_Click(object sender, EventArgs e)
        {
            int? orderId = GetSelectedOrderId();
            if (!orderId.HasValue) return;

            var orderToEdit = allOrders.FirstOrDefault(o => o?.SupplierOrderId == orderId.Value);
            if (orderToEdit == null) return;

            // Show order details form for editing
            using (var form = new OrderDetailsForm(_bookRepository, _supplierRepository, orderToEdit))
            {
                // TODO: Add implementation for editing an existing order
                form.OnOrderUpdated += async (id, item) =>
                {
                    await _orderRepository.UpdateSupplierOrderAsync(id, item);
                    await LoadOrdersAsync();
                };
                form.ShowDialog();
            }
        }

        private async void btnDeleteBook_Click(object sender, EventArgs e)
        {
            int? orderId = GetSelectedOrderId();
            if (!orderId.HasValue) return;

            var confirm = MessageBox.Show("Delete this order?", "Confirm", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                await DeleteOrderAsync(orderId.Value);
            }
        }
        #endregion

    }
}
