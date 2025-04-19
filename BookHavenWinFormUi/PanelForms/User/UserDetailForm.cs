using BookHavenClassLibrary.Dtos.Book;
using BookHavenClassLibrary.Dtos.User;
using BookHavenClassLibrary.Enumz;
using BookHavenWinFormUi.Utilz;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace BookHavenWinFormUi.PanelForms.User
{
    public partial class UserDetailForm : Form
    {
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public RegistrationRequestDto? User { get; private set; } //User for Registration

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public UpdateRequestDto? UserUpdate { get; private set; } //User for Update

        public event Action<RegistrationRequestDto>? OnAdded; // Action to Register User Called in the User Form
        public event Action<UpdateRequestDto>? OnUpdated; //Action to Update user (called in the User Form)

        private bool _isEdit = false;

        //Constructor for Add Item
        public UserDetailForm()
        {
            InitializeComponent();
            _isEdit = false;
            lblUserID.Visible = false;
            lblUser_ID.Visible = false;
            User = new RegistrationRequestDto
            {
                Email = "",
                Password = "",
                FirstName = "",
                LastName = "",
                Role = UserRoleType.Clerk // Or Admin/Sales
            };
            InitEvents();
        }

        //Constructor For Edit Item
        public UserDetailForm(UserResponseDto userToEdit)
        {
            InitializeComponent();
            _isEdit = true;
            lblUserID.Visible = true;
            lblUser_ID.Visible = true;
            lblUserID.Text = userToEdit.Id;

            txtPassword.Visible = false;
            lblPassword.Visible = false;
            UserUpdate = new UpdateRequestDto
            {
                Email = userToEdit.Email,
               
                FirstName = userToEdit.FirstName,
                LastName = userToEdit.LastName,
                //SelectGenreInComboBox(BookData.BookGenre);
                
                Role = userToEdit.Role
            };
            InitEvents();
            //PreloadFields();
        }

        private void InitEvents()
        {
            btnSave.Click += btnSave_Click;
            btnCancel.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };
        }

        #region Button Evetns
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!IsValidForm()) return;

            var selectedType = (KeyValuePair<string, UserRoleType>)cmbUserTypes.SelectedItem;
            UserRoleType selectedUserType = selectedType.Value;

            if (!_isEdit)
            {

                User.Email = txtEmail.Text;
                User.Password = txtPassword.Text;
                User.FirstName = txtFirstName.Text;
                User.LastName = txtLastName.Text;
                User.Role = selectedUserType;
            }
            else
            {
                UserUpdate.Email = txtEmail.Text;
       
                UserUpdate.FirstName = txtFirstName.Text;
                UserUpdate.LastName = txtLastName.Text;
                UserUpdate.Role = selectedUserType;
            }

            if (_isEdit && UserUpdate == null)
                return;
            if (!_isEdit && User == null)
                return;

            if (cbAddAnother.Checked && !_isEdit)
            {
                OnAdded?.Invoke(User); // Send to caller
                MessageBox.Show("Book saved. Ready to add another.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetForm();
                return;
            }

            if (!_isEdit)
            {
                OnAdded?.Invoke(User);
            }
            else
            {
                OnUpdated?.Invoke(UserUpdate);
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        #endregion

        #region Supporting Functions
        private void ResetForm()
        {
            txtEmail.Clear();
            txtPassword.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();

            // Reset the ComboBox to the first item (if any)
            if (cmbUserTypes.Items.Count > 0)
                cmbUserTypes.SelectedIndex = 0;

            // Reset DTO as well
            User = new RegistrationRequestDto
            {
                Email = "",
                Password = "",
                FirstName = "",
                LastName = "",
                Role = UserRoleType.Clerk // or any default
            };

            txtEmail.Focus();
        }

        private bool IsValidForm()
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text) ||
                (!_isEdit && string.IsNullOrWhiteSpace(txtPassword.Text)))
            {
                MessageBox.Show("Please fill all required fields");
                return false;
            }
            return true;
        }
        #endregion

        #region Form Events
        private void UserDetailForm_Load(object sender, EventArgs e)
        {
            ComboBoxHelper.LoadEnumToComboBox<UserRoleType>(cmbUserTypes);

            if (_isEdit)
            {

                txtPassword.Visible = false;
                lblUserID.Visible = true;
                lblUser_ID.Visible = true;
                cbAddAnother.Visible = false;

                txtEmail.Text = UserUpdate.Email;
                txtFirstName.Text = UserUpdate.FirstName.ToString();
                txtLastName.Text = UserUpdate.LastName.ToString();
                ComboBoxHelper.SelectEnumInComboBox<UserRoleType>(cmbUserTypes, UserUpdate.Role);

            }
            else
            {
                lblUserID.Visible = false;
                lblUser_ID.Visible = false;
            }

        }

        #endregion

    }


}
