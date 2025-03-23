using BookHavenClassLibrary.Dtos.Customer;
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

namespace BookHavenWinFormUi.PanelForms.Customer
{
    public partial class CustomerForm : Form
    {
        private readonly ICustomerRepository _customerRepository;
        private List<CustomerReponseDto> allCustomers = new List<CustomerReponseDto>();
        private int? editingCustomerId = null;
        public CustomerForm(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
            InitializeComponent();
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {

        }
    }
}
