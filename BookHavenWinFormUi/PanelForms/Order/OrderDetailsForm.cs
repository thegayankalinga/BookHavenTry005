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

namespace BookHavenWinFormUi.PanelForms.Order
{
    public partial class OrderDetailsForm : Form
    {
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SupplierOrderRequestDto? OrderRequest { get; private set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SupplierOrderItemRequestDto? OrderItemRequest { get; private set; }

        public event Action<SupplierOrderRequestDto>? OnOrderCreated;
        public event Action<int, SupplierOrderRequestDto>? OnOrderUpdated;
        public event Action<int, SupplierOrderItemRequestDto>? OnOrderItemAdded;

        private readonly IBookRepository? _bookRepository;
        private readonly ISupplierRepository? _supplierRepository;
        private List<BookResponseDto?> _books = [];
        private List<SupplierResponseDto?> _suppliers = [];

        private bool _isEdit = false;
        private int? _existingOrderId = null;

        // Constructor for creating new order
        public OrderDetailsForm(IBookRepository bookRepository, ISupplierRepository supplierRepository)
        {
            InitializeComponent();
            _bookRepository = bookRepository;
            _supplierRepository = supplierRepository;
            _isEdit = false;

            OrderRequest = new SupplierOrderRequestDto
            {
                SupplierId = 0,
                OrderDate = DateOnly.FromDateTime(DateTime.Now),
                OrderStatuses = OrderStatuses.Pending
            };

            OrderItemRequest = new SupplierOrderItemRequestDto
            {
                BookId = 0,
                Quantity = 1,
                UnitPrice = 0.00m
            };

            InitEvents();
        }


        // Constructor for editing an existing order
        public OrderDetailsForm(IBookRepository bookRepository, ISupplierRepository supplierRepository,
                               SupplierOrderResponseDto existingOrder)
        {
            InitializeComponent();
            _bookRepository = bookRepository;
            _supplierRepository = supplierRepository;
            _isEdit = true;
            _existingOrderId = existingOrder.SupplierOrderId;

            OrderRequest = new SupplierOrderRequestDto
            {
                SupplierId = existingOrder.SupplierId,
                OrderDate = existingOrder.OrderDate,
                OrderStatuses = existingOrder.OrderStatuses
            };

            // Default empty order item
            OrderItemRequest = new SupplierOrderItemRequestDto
            {
                BookId = 0,
                Quantity = 1,
                UnitPrice = 0.00m
            };

            InitEvents();
        }

        private void InitEvents()
        {
            btnSave.Click += btnSave_Click;
            btnCancel.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };
            comboBox1.SelectedIndexChanged += BookSelected;
        }

       

        private void BookSelected(object? sender, EventArgs e)
        {
            if (comboBox1.SelectedItem is KeyValuePair<string, object> selectedItem &&
                selectedItem.Value is int bookId && bookId > 0)
            {
                var selectedBook = _books.FirstOrDefault(b => b?.BookId == bookId);
                if (selectedBook != null)
                {
                    // Pre-fill the purchase price with the book's selling price as a starting point
                    txtSellingPrice.Text = selectedBook.SellingPrice.ToString("0.00");
                }
            }
        }

        private async void OrderDetailsForm_Load(object sender, EventArgs e)
        {
            await LoadSuppliersAsync();
            await LoadBooksAsync();

            if (_isEdit)
            {
                // Select the supplier
                SelectSupplierInComboBox(OrderRequest.SupplierId);
            }

            // Calculate total on quantity or price change
            txtCurrentStock.TextChanged += RecalculateTotal;
            txtSellingPrice.TextChanged += RecalculateTotal;
        }

        private void RecalculateTotal(object? sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(txtCurrentStock.Text, out int quantity) &&
                    decimal.TryParse(txtSellingPrice.Text, out decimal price))
                {
                    decimal total = quantity * price;
                    textBox1.Text = total.ToString("0.00");
                }
            }
            catch
            {
                textBox1.Text = "0.00";
            }
        }

        private async Task LoadBooksAsync()
        {
            if (_bookRepository == null) return;

            _books = await _bookRepository.GetAllBooksAsync();

            var bookItems = new List<KeyValuePair<string, object>>();
            foreach (var book in _books)
            {
                if (book != null)
                {
                    bookItems.Add(new KeyValuePair<string, object>(book.Title, book.BookId));
                }
            }

            comboBox1.DataSource = bookItems;
            comboBox1.DisplayMember = "Key";
            comboBox1.ValueMember = "Value";
        }

        private async Task LoadSuppliersAsync()
        {
            if (_supplierRepository == null) return;

            _suppliers = await _supplierRepository.GetAllSuppliersAsync();

            var supplierItems = new List<KeyValuePair<string, object>>();
            foreach (var supplier in _suppliers)
            {
                if (supplier != null)
                {
                    supplierItems.Add(new KeyValuePair<string, object>(supplier.SupplierName, supplier.SupplierId));
                }
            }

            comboBox2.DataSource = supplierItems;
            comboBox2.DisplayMember = "Key";
            comboBox2.ValueMember = "Value";
        }

        private void SelectSupplierInComboBox(int supplierId)
        {
            for (int i = 0; i < comboBox2.Items.Count; i++)
            {
                if (comboBox2.Items[i] is KeyValuePair<string, object> item &&
                    item.Value is int id && id == supplierId)
                {
                    comboBox2.SelectedIndex = i;
                    break;
                }
            }
        }

        private bool IsValidForm()
        {
            // Validate supplier selection
            if (comboBox2.SelectedValue == null || !(comboBox2.SelectedValue is int supplierId) || supplierId <= 0)
            {
                MessageBox.Show("Please select a supplier.");
                return false;
            }

            // Validate book selection
            if (comboBox1.SelectedValue == null || !(comboBox1.SelectedValue is int bookId) || bookId <= 0)
            {
                MessageBox.Show("Please select a book.");
                return false;
            }

            // Validate quantity
            if (string.IsNullOrWhiteSpace(txtCurrentStock.Text) ||
                !int.TryParse(txtCurrentStock.Text, out int quantity) ||
                quantity <= 0)
            {
                MessageBox.Show("Please enter a valid quantity (greater than 0).");
                return false;
            }

            // Validate price
            if (string.IsNullOrWhiteSpace(txtSellingPrice.Text) ||
                !decimal.TryParse(txtSellingPrice.Text, out decimal price) ||
                price <= 0)
            {
                MessageBox.Show("Please enter a valid price (greater than 0).");
                return false;
            }

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!IsValidForm()) return;

            // Get values from form
            int supplierId = (int)comboBox2.SelectedValue;
            int bookId = (int)comboBox1.SelectedValue;
            int quantity = int.Parse(txtCurrentStock.Text);
            decimal unitPrice = decimal.Parse(txtSellingPrice.Text);

            // Update the order request
            OrderRequest.SupplierId = supplierId;

            // Update the order item request
            OrderItemRequest.BookId = bookId;
            OrderItemRequest.Quantity = quantity;
            OrderItemRequest.UnitPrice = unitPrice;

            if (_isEdit && _existingOrderId.HasValue)
            {
                // Update existing order
                OnOrderUpdated?.Invoke(_existingOrderId.Value, OrderRequest);
                // Add order item to existing order
                OnOrderItemAdded?.Invoke(_existingOrderId.Value, OrderItemRequest);
            }
            else
            {
                // Create new order
                OnOrderCreated?.Invoke(OrderRequest);
                // Note: Order items would be added after the order is created and we have the order ID
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
