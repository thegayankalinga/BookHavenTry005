using BookHavenClassLibrary.Dtos.User;
using BookHavenClassLibrary.Enumz;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookHavenWinFormUi.PanelForms.User
{
    public partial class UserDetailForm : Form
    {
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public RegistrationRequestDto User { get; private set; }
        private bool _isEdit = false;
        public UserDetailForm()
        {
            InitializeComponent();
            _isEdit = false;
            User = new RegistrationRequestDto();
            InitEvents();
        }

        public UserDetailForm(UserResponseDto userToEdit)
        {
            InitializeComponent();
            _isEdit = true;
            User = new RegistrationRequestDto
            {
                Email = userToEdit.Email,
                Password = "", // don't prefill for security
                FirstName = userToEdit.FirstName,
                LastName = userToEdit.LastName,
                Role = userToEdit.Role
            };
            InitEvents();
            PreloadFields();
        }

        private void InitEvents()
        {
            btnSave.Click += btnSave_Click;
            btnCancel.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };
        }

        private void PreloadFields()
        {
            txtEmail.Text = User.Email;
            txtFirstName.Text = User.FirstName;
            txtLastName.Text = User.LastName;
            cmbUserTypes.SelectedItem = User.Role;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please fill all required fields");
                return;
            }

            var selectedType = (KeyValuePair<string, UserRoleType>)cmbUserTypes.SelectedItem;
            UserRoleType selectedUserType = selectedType.Value;

            User.Email = txtEmail.Text;
            User.Password = txtPassword.Text;
            User.FirstName = txtFirstName.Text;
            User.LastName = txtLastName.Text;
            User.Role = selectedUserType;

            DialogResult = DialogResult.OK;
            Close();
        }
    
    }
}
