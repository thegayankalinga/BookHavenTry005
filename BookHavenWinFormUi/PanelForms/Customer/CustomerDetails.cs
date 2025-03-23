using BookHavenClassLibrary.Dtos.Customer;
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
    public partial class CustomerDetails : Form
    {
        public CustomerRequestDto Customer { get; set; }
        private bool _isEditMode = false;

        #region "Constructors"
        public CustomerDetails()
        {
            InitializeComponent();
            _isEditMode = false;

            Customer = new CustomerRequestDto
            {
                FullName = "",
                PhoneNumber = "",
                AddressLineOne = "",
                AddressLineTwo = "",
                City = ""
            };
            this.Load += CustomerDetails_Load;
            btnSave.Click += btnSave_Click;
            btnCancel.Click += btnCancel_Click;

        }

        public CustomerDetails(CustomerResponseDto customerToEdit)
        {
            InitializeComponent();
            Text = "Edit Customer";
            btnSave.Text = "Update Customer";
            _isEditMode = true;
            Customer = new CustomerRequestDto
            {
                FullName = customerToEdit.FullName,
                PhoneNumber = customerToEdit.PhoneNumber,
                AddressLineOne = customerToEdit.AddressLineOne,
                AddressLineTwo = customerToEdit.AddressLineTwo,
                City = customerToEdit.City
            };
            this.Load += CustomerDetails_Load;
            btnSave.Click += btnSave_Click;
            btnCancel.Click += btnCancel_Click;
        }

        #endregion


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text) || string.IsNullOrWhiteSpace(txtPhoneNumber.Text) || string.IsNullOrWhiteSpace(txtAddressLineOne.Text) || string.IsNullOrWhiteSpace(txtCity.Text))
            {
                MessageBox.Show("Please fill all required fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Customer.FullName = txtFullName.Text;
            Customer.PhoneNumber = txtPhoneNumber.Text;
            Customer.AddressLineOne = txtAddressLineOne.Text;
            Customer.AddressLineTwo = txtAddressLineTwo.Text;
            Customer.City = txtCity.Text;
            DialogResult = DialogResult.OK;
            Close();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();

        }

        private void CustomerDetails_Load(object sender, EventArgs e)
        {

            if(_isEditMode)
            {
                txtFullName.Text = Customer.FullName;
                txtPhoneNumber.Text = Customer.PhoneNumber;
                txtAddressLineOne.Text = Customer.AddressLineOne;
                txtAddressLineTwo.Text = Customer.AddressLineTwo;
                txtCity.Text = Customer.City;
            }

        }
    }
}
