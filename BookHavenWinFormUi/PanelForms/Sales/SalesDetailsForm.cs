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
using BookHavenClassLibrary.Dtos.Customer;
using BookHavenClassLibrary.Dtos.Sales;
using BookHavenClassLibrary.Enumz;
using BookHavenClassLibrary.Interfaces;
using BookHavenWinFormUi.Utilz;

namespace BookHavenWinFormUi.PanelForms.Customer
{
    public partial class SalesDetailsForm : Form
    {
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SalesRequestDto? Sale { get; private set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SalesRequestDto? SaleUpdate { get; private set; }

        private readonly IUserSessionService _userSessionService;
        private readonly IBookRepository? _bookRepository;
        private readonly ICustomerRepository? _customerRepository;
        private List<BookResponseDto?> availableBooks = [];
        private List<CustomerResponseDto?> customers = [];
        private bool _isEdit = false;

        public event Action<SalesRequestDto>? OnAdded;
        public event Action<SalesRequestDto>? OnUpdated;

        public SalesDetailsForm(IUserSessionService userSessionService, IBookRepository bookRepository, ICustomerRepository customerRepository)
        {
            InitializeComponent();
            _userSessionService = userSessionService;
            _bookRepository = bookRepository;
            _customerRepository = customerRepository;
            _isEdit = false;

            Sale = new SalesRequestDto
            {
                UserId = _userSessionService.CurrentUser?.Id ?? string.Empty,
                DeliveryMethod = DeliveryMethods.Pickup,
                SaleItems = new List<SaleItemRequestDto>()
            };

            InitEvents();
            LoadData();
        }

        public SalesDetailsForm(IUserSessionService userSessionService, SalesResponseDto saleToEdit,
                       IBookRepository bookRepository, ICustomerRepository customerRepository)
        {
            InitializeComponent();
            _userSessionService = userSessionService;
            _bookRepository = bookRepository;
            _customerRepository = customerRepository;
            _isEdit = true;

            SaleUpdate = new SalesRequestDto
            {
                CustomerId = saleToEdit.CustomerId,
                UserId = saleToEdit.UserId,
                DeliveryMethod = saleToEdit.DeliveryMethod,
                SaleItems = saleToEdit.SaleItems?.Select(si => new SaleItemRequestDto
                {
                    BookId = si.BookId,
                    Quantity = si.Quantity,
                    UnitPrice = si.UnitPrice,
                    Discount = si.Discount
                }).ToList() ?? new List<SaleItemRequestDto>()
            };

            InitEvents();
            LoadData();
        }

        private void InitEvents()
        {
            btnSave.Click += btnSave_Click;
            btnCancel.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };

            comboBox1.SelectedIndexChanged += CustomerComboBox_SelectedIndexChanged;
            comboBox2.SelectedIndexChanged += BookComboBox_SelectedIndexChanged;
            txtAuthorName.TextChanged += Quantity_TextChanged;
            txtSellingPrice.TextChanged += SellingPrice_TextChanged;
        }

        private async Task LoadData()
        {
            if (_bookRepository != null)
            {
                availableBooks = await _bookRepository.GetAllBooksAsync();
                comboBox2.DataSource = availableBooks
                    .Where(b => b != null && b.StockQuantity > 0)
                    .Select(b => new ComboBoxItem<int>(b.BookId, b.Title))
                    .ToList();
            }

            if (_customerRepository != null)
            {
                customers = await _customerRepository.GetAllAsync();
                comboBox1.DataSource = customers
                    .Where(c => c != null)
                    .Select(c => new ComboBoxItem<int>(c.Id, c.FullName))
                    //.Prepend(new ComboBoxItem<int>(0, "Walk-in Customer"))
                    .ToList();
            }

            ComboBoxHelper.LoadEnumToComboBox<DeliveryMethods>(new ComboBox());

            if (_isEdit && SaleUpdate != null)
            {
                // Set customer selection
                if (SaleUpdate.CustomerId.HasValue)
                {
                    var customerList = comboBox1.DataSource as List<ComboBoxItem<int>>;
                    if (customerList != null)
                    {
                        comboBox1.SelectedItem = customerList
                            .FirstOrDefault(c => c.Id == SaleUpdate.CustomerId);
                    }
                }

                // Set book selection, quantity and price if there are sale items
                if (SaleUpdate.SaleItems?.Count > 0)
                {
                    var firstItem = SaleUpdate.SaleItems[0];

                    // Set the quantity in the text field
                    txtAuthorName.Text = firstItem.Quantity.ToString();

                    // Set the price
                    txtSellingPrice.Text = firstItem.UnitPrice.ToString("F2");

                    // Select the book in the combobox
                    var bookList = comboBox2.DataSource as List<ComboBoxItem<int>>;
                    if (bookList != null)
                    {
                        comboBox2.SelectedItem = bookList
                            .FirstOrDefault(b => b.Id == firstItem.BookId);
                    }
                }
            }
        }

        //private async Task LoadData()
        //{
        //    if (_bookRepository != null)
        //    {
        //        availableBooks = await _bookRepository.GetAllBooksAsync();
        //        comboBox2.DataSource = availableBooks
        //            .Where(b => b != null && b.StockQuantity > 0)
        //            .Select(b => new ComboBoxItem<int>(b.BookId, b.Title))
        //            .ToList();
        //    }

        //    if (_customerRepository != null)
        //    {
        //        customers = await _customerRepository.GetAllAsync();
        //        comboBox1.DataSource = customers
        //            .Where(c => c != null)
        //            .Select(c => new ComboBoxItem<int>(c.Id, c.FullName))
        //            //.Prepend(new ComboBoxItem<int>(0, "Walk-in Customer"))
        //            .ToList();
        //    }

        //    ComboBoxHelper.LoadEnumToComboBox<DeliveryMethods>(new ComboBox());

        //    if (_isEdit && SaleUpdate != null)
        //    {
        //        if (SaleUpdate.CustomerId.HasValue)
        //        {
        //            var customerList = comboBox1.DataSource as List<ComboBoxItem<int>>;
        //            if (customerList != null)
        //            {
        //                comboBox1.SelectedItem = customerList
        //                    .FirstOrDefault(c => c.Id == SaleUpdate.CustomerId);
        //            }
        //        }
        //    }
        //}

        private void CustomerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Handle customer selection if needed
        }

        private void BookComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedBookItem = comboBox2.SelectedItem as ComboBoxItem<int>;
            if (selectedBookItem == null) return;

            var selectedBook = availableBooks.FirstOrDefault(b => b?.BookId == selectedBookItem.Id);
            if (selectedBook != null)
            {
                txtSellingPrice.Text = selectedBook.SellingPrice.ToString("F2");
            }
        }

        private void Quantity_TextChanged(object sender, EventArgs e)
        {
            UpdateTotalValue();
        }

        private void SellingPrice_TextChanged(object sender, EventArgs e)
        {
            UpdateTotalValue();
        }

        private void UpdateTotalValue()
        {
            if (decimal.TryParse(txtSellingPrice.Text, out decimal price) &&
                int.TryParse(txtAuthorName.Text, out int quantity))
            {
                txtCurrentStock.Text = (price * quantity).ToString("F2");
            }
            else
            {
                txtCurrentStock.Text = "0.00";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!IsValidForm()) return;

            var selectedBookItem = comboBox2.SelectedItem as ComboBoxItem<int>;
            if (selectedBookItem == null) return;
            int bookId = selectedBookItem.Id;

            var selectedCustomer = comboBox1.SelectedItem as ComboBoxItem<int>;
            int? customerId = selectedCustomer?.Id == 0 ? 5 : selectedCustomer?.Id;

            var saleItem = new SaleItemRequestDto
            {
                BookId = bookId,
                Quantity = int.Parse(txtAuthorName.Text),
                UnitPrice = decimal.Parse(txtSellingPrice.Text),
                Discount = 0
            };

            if (!_isEdit)
            {
                Sale.CustomerId = customerId;
                Sale.SaleItems = new List<SaleItemRequestDto> { saleItem };
                OnAdded?.Invoke(Sale);
            }
            else
            {
                SaleUpdate.CustomerId = customerId;
                SaleUpdate.SaleItems = new List<SaleItemRequestDto> { saleItem };
                OnUpdated?.Invoke(SaleUpdate);
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private bool IsValidForm()
        {
            if (comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Please select a book");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtAuthorName.Text) ||
                !int.TryParse(txtAuthorName.Text, out int quantity) ||
                quantity <= 0)
            {
                MessageBox.Show("Please enter a valid quantity");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSellingPrice.Text) ||
                !decimal.TryParse(txtSellingPrice.Text, out decimal price) ||
                price <= 0)
            {
                MessageBox.Show("Please enter a valid price");
                return false;
            }

            return true;
        }

        private void SalesDetailsForm_Load(object sender, EventArgs e)
        {
            // Set the quantity in the text field
            
        }
    }

    public class ComboBoxItem<TId>
    {
        public TId Id { get; set; }
        public string Label { get; set; } = string.Empty;

        public ComboBoxItem(TId id, string label)
        {
            Id = id;
            Label = label;
        }

        public override string ToString() => Label;
    }
}
