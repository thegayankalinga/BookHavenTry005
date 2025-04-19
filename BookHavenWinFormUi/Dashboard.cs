// Fully implemented Dashboard.cs with data + chart logic
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using BookHavenClassLibrary.Connections;
using BookHavenClassLibrary.Interfaces;
using Microsoft.EntityFrameworkCore;
using ScottPlot;
using ScottPlot.WinForms;
using ScottPlot.Plottables;

namespace BookHavenWinFormUi.PanelForms
{
    public partial class Dashboard : Form
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly ISupplierOrderRepository _supplierOrderRepository;
        private readonly ISalesRepository _salesRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        public Dashboard(
            ISupplierRepository supplierRepository,
            ISupplierOrderRepository supplierOrderRepository,
            ISalesRepository salesRepository,
            ICustomerRepository customerRepository,
            IDbContextFactory<AppDbContext> contextFactory)
        {
            InitializeComponent();
            _supplierRepository = supplierRepository;
            _supplierOrderRepository = supplierOrderRepository;
            _salesRepository = salesRepository;
            _customerRepository = customerRepository;
            _contextFactory = contextFactory;
        }

        private async void Dashboard_Load_1(object sender, EventArgs e)
        {
            await LoadSupplierSummaryAsync();
            await LoadSalesSummaryAsync();
            await LoadTopBooksChartAsync();

          
        }

        private async Task LoadSupplierSummaryAsync()
        {
            var suppliers = await _supplierRepository.GetAllSuppliersAsync();
            var orders = await _supplierOrderRepository.GetAllSupplierOrdersAsync();

            int totalSuppliers = suppliers.Count;
            int totalOrders = orders.Count;
            //decimal totalOrderValue = orders.Sum(o => o.OrderItems.Sum(i => i.Quantity * i.UnitPrice));
            //decimal totalOrderValue = orders.Sum(o => o.SupplierOrderItems.Sum(i => i.Quantity * i.UnitPrice));
            decimal totalOrderValue = orders.Sum(o => o.TotalPrice);



            label9.Text = totalSuppliers.ToString();       // No of Suppliers
            label11.Text = totalOrders.ToString();          // No of Orders
            label13.Text = totalOrderValue.ToString("0.00"); // Total Order Value

           
        }

        private async Task LoadSalesSummaryAsync()
        {
            using var db = _contextFactory.CreateDbContext();
            DateTime now = DateTime.Now;
            DateTime weekStart = now.AddDays(-7);

            var sales = await db.Sales
                .Include(s => s.SaleItems)
                .Include(s => s.Customer)
                .Where(s => s.SaleDate >= weekStart && s.SaleDate <= now)
                .ToListAsync();

            int saleCount = sales.Count;
            decimal totalSalesValue = sales.Sum(s => s.SaleItems.Sum(i => i.Subtotal));
            int customerCount = await db.Customers.CountAsync();

            label20.Text = saleCount.ToString();            // No of Sales
            label16.Text = totalSalesValue.ToString("0.00"); // Weekly sales value
            label14.Text = customerCount.ToString();        // No of Customers
        }



        private async Task LoadTopBooksChartAsync()
        {
            using var db = _contextFactory.CreateDbContext();

            var topBooks = await db.SaleItems
                .Include(si => si.Book)
                .GroupBy(si => si.Book.Title)
                .Select(g => new
                {
                    Title = g.Key,
                    Revenue = g.Sum(x => x.Subtotal)
                })
                .OrderByDescending(x => x.Revenue)
                .Take(5)
                .ToListAsync();

            var plt = formsPlot1.Plot;
            plt.Clear();

            double[] values = topBooks.Select(x => (double)x.Revenue).ToArray();
            string[] labels = topBooks.Select(x => x.Title).ToArray();
            double[] positions = Enumerable.Range(0, values.Length).Select(x => (double)x).ToArray();

            var bar = plt.Add.Bars(values, positions);
            //bar.FillColor = Colors.Blue.WithAlpha(0.75);

            plt.Title("Top 5 Selling Books (Revenue)");
            plt.YLabel("Revenue (Rs)");
            plt.XLabel("Book Titles");

            plt.Axes.Bottom.TickGenerator = new ScottPlot.TickGenerators.NumericManual(positions, labels);
            plt.Axes.Bottom.TickLabelStyle.Rotation = 45;
            plt.Axes.Bottom.TickLabelStyle.Alignment = Alignment.MiddleRight;

            plt.Axes.SetLimits(0);

            formsPlot1.Refresh();
        }

    }
}
