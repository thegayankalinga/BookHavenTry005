// Refactored Report.cs for BookHaven with full implementation
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookHavenClassLibrary.Connections;
using BookHavenClassLibrary.Interfaces;
using Microsoft.EntityFrameworkCore;
using BookHavenClassLibrary.Dtos.User;
using BookHavenClassLibrary.Enumz;

namespace BookHavenWinFormUi.PanelForms.Reports
{
    public partial class Report : Form
    {
        private readonly IBookRepository _bookRepository;
        private readonly ISalesRepository _salesRepository;
        private readonly IUserRepository _userRepository;
        private readonly ISupplierRepository _supplierRepository;
        private readonly ISupplierOrderRepository _supplierOrderRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        private List<UserResponseDto> _allUsers = new();

        public Report(
            IBookRepository bookRepository,
            ISalesRepository salesRepository,
            IUserRepository userRepository,
            ISupplierRepository supplierRepository,
            ISupplierOrderRepository supplierOrderRepository,
            ICustomerRepository customerRepository,
            IDbContextFactory<AppDbContext> contextFactory)
        {
            InitializeComponent();
            _bookRepository = bookRepository;
            _salesRepository = salesRepository;
            _userRepository = userRepository;
            _supplierRepository = supplierRepository;
            _supplierOrderRepository = supplierOrderRepository;
            _customerRepository = customerRepository;
            _contextFactory = contextFactory;
        }

        private async void Report_Load(object sender, EventArgs e)
        {
            cboReportType.Items.AddRange(new string[]
            {
                "Sales Summary",
                "Inventory Status",
                "Top Selling Books",
                "Customer Purchase History",
                "Supplier Orders",
                "Low Stock Alert",
                "Sales by User"
            });
            cboReportType.SelectedIndex = 0;
            dtFromDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtToDate.Value = DateTime.Now;
            await LoadUsersAsync();
        }

        private async Task LoadUsersAsync()
        {
            try
            {
                _allUsers = await _userRepository.GetAllAsync();
                var bindingList = new List<UserResponseDto>(_allUsers);
                bindingList.Insert(0, new UserResponseDto
                {
                    Id = "",
                    FirstName = "All",
                    LastName = "Users",
                    Email = "all@bookhaven.fake", // Required field workaround
                    Role = UserRoleType.Admin,    // Optional: set a default role too
                    CreatedAt = DateTime.MinValue,
                    LastLoginAt = DateTime.MinValue
                });
                cboUser.DataSource = bindingList;
                cboUser.DisplayMember = "FullName";
                cboUser.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading users: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                dgvReportData.DataSource = null;
                lblNoOfItems.Text = "0";
                lblTotalValue.Text = "0.00";

                string reportType = cboReportType.SelectedItem.ToString();
                DateTime fromDate = dtFromDate.Value.Date;
                DateTime toDate = dtToDate.Value.Date.AddDays(1).AddTicks(-1);
                string userId = cboUser.SelectedValue?.ToString();

                switch (reportType)
                {
                    case "Sales Summary":
                        await LoadSalesSummaryReport(fromDate, toDate, userId);
                        break;
                    case "Inventory Status":
                        await LoadInventoryStatusReport();
                        break;
                    case "Top Selling Books":
                        await LoadTopSellingBooksReport(fromDate, toDate);
                        break;
                    case "Customer Purchase History":
                        await LoadCustomerPurchaseReport(fromDate, toDate);
                        break;
                    case "Supplier Orders":
                        await LoadSupplierOrdersReport(fromDate, toDate);
                        break;
                    case "Low Stock Alert":
                        await LoadLowStockReport();
                        break;
                    case "Sales by User":
                        await LoadSalesByUserReport(fromDate, toDate);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Report error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cboReportType.SelectedIndex = 0;
            dtFromDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtToDate.Value = DateTime.Now;
            cboUser.SelectedIndex = 0;
            dgvReportData.DataSource = null;
            lblNoOfItems.Text = "0";
            lblTotalValue.Text = "0.00";
        }

        private void cboReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string report = cboReportType.SelectedItem?.ToString() ?? "";
            dtFromDate.Enabled = dtToDate.Enabled = report != "Inventory Status" && report != "Low Stock Alert";
            cboUser.Enabled = report == "Sales Summary" || report == "Sales by User";
        }

        private async Task LoadSalesSummaryReport(DateTime fromDate, DateTime toDate, string userId)
        {
            using var db = _contextFactory.CreateDbContext();
            var query = db.Sales
                .Include(s => s.SaleItems)
                .ThenInclude(si => si.Book)
                .Include(s => s.Customer)
                .Include(s => s.User)
                .Where(s => s.SaleDate >= fromDate && s.SaleDate <= toDate);

            if (!string.IsNullOrWhiteSpace(userId))
                query = query.Where(s => s.UserId == userId);

            var data = await query.ToListAsync();
            var reportData = data.Select(s => new
            {
                s.SalesId,
                s.SaleDate,
                Customer = s.Customer?.FullName ?? "Guest",
                Cashier = s.User?.FirstName + " " + s.User?.LastName,
                TotalItems = s.SaleItems.Sum(i => i.Quantity),
                TotalAmount = s.SaleItems.Sum(i => i.Subtotal),
                s.DeliveryMethod
            }).ToList();

            dgvReportData.DataSource = reportData;
            lblNoOfItems.Text = reportData.Count.ToString();
            lblTotalValue.Text = reportData.Sum(x => x.TotalAmount).ToString("0.00");
        }

        private async Task LoadInventoryStatusReport()
        {
            var books = await _bookRepository.GetAllBooksAsync();
            var reportData = books.Select(b => new
            {
                b.BookId,
                b.Title,
                b.Author,
                Genre = b.BookGenre.ToString(),
                b.Isbn,
                b.StockQuantity,
                QuantitySold = b.QuanitySold,
                b.SellingPrice,
                Value = b.StockQuantity * b.SellingPrice
            }).ToList();

            dgvReportData.DataSource = reportData;
            lblNoOfItems.Text = reportData.Count.ToString();
            lblTotalValue.Text = reportData.Sum(x => x.Value).ToString("0.00");
        }

        private async Task LoadTopSellingBooksReport(DateTime fromDate, DateTime toDate)
        {
            using var db = _contextFactory.CreateDbContext();
            var sales = await db.SaleItems
                .Include(si => si.Book)
                .Include(si => si.Sales)
                .Where(si => si.Sales.SaleDate >= fromDate && si.Sales.SaleDate <= toDate)
                .ToListAsync();

            var reportData = sales
                .GroupBy(si => si.BookId)
                .Select(g => new
                {
                    g.First().Book.BookId,
                    g.First().Book.Title,
                    g.First().Book.Author,
                    Genre = g.First().Book.BookGenre.ToString(),
                    QuantitySold = g.Sum(si => si.Quantity),
                    TotalRevenue = g.Sum(si => si.Subtotal),
                    AvgPrice = g.Sum(si => si.Subtotal) / g.Sum(si => si.Quantity)
                })
                .OrderByDescending(x => x.QuantitySold)
                .ToList();

            dgvReportData.DataSource = reportData;
            lblNoOfItems.Text = reportData.Count.ToString();
            lblTotalValue.Text = reportData.Sum(x => x.TotalRevenue).ToString("0.00");
        }

        private async Task LoadCustomerPurchaseReport(DateTime fromDate, DateTime toDate)
        {
            using var db = _contextFactory.CreateDbContext();
            var sales = await db.Sales
                .Include(s => s.Customer)
                .Include(s => s.SaleItems)
                .Where(s => s.CustomerId != null && s.SaleDate >= fromDate && s.SaleDate <= toDate)
                .ToListAsync();

            var reportData = sales
                .GroupBy(s => s.CustomerId)
                .Select(g => new
                {
                    Customer = g.First().Customer?.FullName ?? "Unknown",
                    Phone = g.First().Customer?.PhoneNumber ?? "",
                    PurchaseCount = g.Count(),
                    TotalItems = g.Sum(s => s.SaleItems.Sum(si => si.Quantity)),
                    TotalSpent = g.Sum(s => s.SaleItems.Sum(si => si.Subtotal)),
                    LastPurchase = g.Max(s => s.SaleDate)
                })
                .ToList();

            dgvReportData.DataSource = reportData;
            lblNoOfItems.Text = reportData.Count.ToString();
            lblTotalValue.Text = reportData.Sum(x => x.TotalSpent).ToString("0.00");
        }

        private async Task LoadSupplierOrdersReport(DateTime fromDate, DateTime toDate)
        {
            using var db = _contextFactory.CreateDbContext();
            var orders = await db.SupplierOrders
                .Include(o => o.Supplier)
                .Include(o => o.SupplierOrderItems)
                .Where(o =>
                    o.OrderDate >= DateOnly.FromDateTime(fromDate) &&
                    o.OrderDate <= DateOnly.FromDateTime(toDate))
                .ToListAsync();

            var reportData = orders.Select(o => new
            {
                o.SupplierOrderId,
                Supplier = o.Supplier?.SupplierName ?? "",
                o.OrderDate,
                Status = o.OrderStatuses.ToString(),
                TotalItems = o.SupplierOrderItems.Sum(i => i.Quantity),
                TotalCost = o.SupplierOrderItems.Sum(i => i.Quantity * i.UnitPrice)
            }).ToList();

            dgvReportData.DataSource = reportData;
            lblNoOfItems.Text = reportData.Count().ToString();
            lblTotalValue.Text = reportData.Sum(x => x.TotalCost).ToString("0.00");
        }

        private async Task LoadLowStockReport()
        {
            const int lowStockThreshold = 10;
            var books = await _bookRepository.GetAllBooksAsync();
            var reportData = books
                .Where(b => b.StockQuantity < lowStockThreshold)
                .Select(b => new
                {
                    b.BookId,
                    b.Title,
                    b.Author,
                    b.StockQuantity,
                    ReorderLevel = lowStockThreshold,
                    ReorderQty = (lowStockThreshold * 2) - b.StockQuantity,
                    b.SellingPrice,
                    Status = b.StockQuantity == 0 ? "Out of Stock" : "Low Stock"
                })
                .ToList();

            dgvReportData.DataSource = reportData;
            lblNoOfItems.Text = reportData.Count.ToString();
            lblTotalValue.Text = reportData.Sum(x => x.ReorderQty).ToString();
        }

        private async Task LoadSalesByUserReport(DateTime fromDate, DateTime toDate)
        {
            using var db = _contextFactory.CreateDbContext();
            var sales = await db.Sales
                .Include(s => s.User)
                .Include(s => s.SaleItems)
                .Where(s => s.SaleDate >= fromDate && s.SaleDate <= toDate)
                .ToListAsync();

            var reportData = sales
                .GroupBy(s => s.UserId)
                .Select(g => new
                {
                    User = g.First().User?.FirstName + " " + g.First().User?.LastName,
                    TotalSales = g.Count(),
                    TotalItems = g.Sum(s => s.SaleItems.Sum(si => si.Quantity)),
                    TotalRevenue = g.Sum(s => s.SaleItems.Sum(si => si.Subtotal)),
                    FirstSale = g.Min(s => s.SaleDate),
                    LastSale = g.Max(s => s.SaleDate)
                })
                .ToList();

            dgvReportData.DataSource = reportData;
            lblNoOfItems.Text = reportData.Count.ToString();
            lblTotalValue.Text = reportData.Sum(x => x.TotalRevenue).ToString("0.00");
        }
    }
}
