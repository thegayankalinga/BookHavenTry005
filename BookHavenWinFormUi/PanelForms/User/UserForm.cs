using BookHavenClassLibrary.Dtos.User;
using BookHavenClassLibrary.Enumz;
using BookHavenClassLibrary.Interfaces;
using BookHavenClassLibrary.Repositories;
using BookHavenWinFormUi.PanelForms.Books;
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

namespace BookHavenWinFormUi.PanelForms.User
{
    public partial class UserForm : Form
    {

        private readonly IUserRepository _userRepository;
        private List<UserResponseDto?> allUsers = [];

        public UserForm(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            InitializeComponent();
            this.Load += UserForm_Load;
        }

        #region Form Events
        private async void UserForm_Load(object? sender, EventArgs e)
        {
            ConfigureGrid();
            await LoadListAsync();
            LoadUserTypesToFilterComboBox();
        }

        #endregion

        #region Support Methods

        private void ConfigureGrid()
        {
            var columns = new List<(string, DataGridViewAutoSizeColumnMode)>
            {
                ("ID", DataGridViewAutoSizeColumnMode.AllCells),
                ("Email", DataGridViewAutoSizeColumnMode.Fill),
                ("First Name", DataGridViewAutoSizeColumnMode.AllCells),
                ("Last Name", DataGridViewAutoSizeColumnMode.AllCells),
                ("Role", DataGridViewAutoSizeColumnMode.AllCells)
            };

            DataGridViewUtility.ConfigureGrid(gridViewUserList, columns);
        }

        private void LoadUserTypesToFilterComboBox()
        {
            var userTypes = Enum.GetValues(typeof(UserRoleType)).Cast<UserRoleType>().ToList();

            var userTypeList = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("All Types", "ALL") // this is just a flag, not tied to enum
             };


            foreach (var userType in userTypes)
            {
                var fieldInfo = typeof(UserRoleType).GetField(userType.ToString());
                if (fieldInfo != null)
                {
                    var enumMemberAttribute = fieldInfo.GetCustomAttributes(typeof(EnumMemberAttribute), false)
                                                       .FirstOrDefault() as EnumMemberAttribute;
                    string displayName = enumMemberAttribute?.Value ?? userType.ToString();
                    userTypeList.Add(new KeyValuePair<string, object>(displayName, userType));
                }
            }

            cmbUserTypes.DataSource = userTypeList;
            cmbUserTypes.DisplayMember = "Key";
            cmbUserTypes.ValueMember = "Value";

        }

        private void DisplayAll(List<UserResponseDto?> users)
        {
            if (gridViewUserList.InvokeRequired)
            {
                gridViewUserList.Invoke(new MethodInvoker(() => DisplayAll(users)));
                return;
            }

            gridViewUserList.Rows.Clear();
            foreach (var user in users)
            {
                if (user == null) continue;
                gridViewUserList.Rows.Add(user.Id, user.Email, user.FirstName, user.LastName, user.Role);
            }
        }

        private async Task LoadListAsync()
        {
            if (gridViewUserList.InvokeRequired)
            {
                gridViewUserList.Invoke(new MethodInvoker(async () => await LoadListAsync()));
                return;
            }

            if (gridViewUserList.Columns.Count == 0)
                ConfigureGrid();

            gridViewUserList.Rows.Clear();
            allUsers = await _userRepository.GetAllAsync().ConfigureAwait(false);
            DisplayAll(allUsers);
        }

        private void Search()
        {
            var key = txtSearchKey.Text.Trim().ToLower();
            //string? selectedUserType = (cmbUserTypes.SelectedValue != null && cmbUserTypes !=null) ? cmbUserTypes?.SelectedItem?.ToString() : string.Empty;
            object selectedValue = cmbUserTypes.SelectedValue ?? "ALL";
            var filterUsers = allUsers.ToList();

            if (!string.IsNullOrWhiteSpace(key)) // ✅ This should be negated
            {
                filterUsers = filterUsers.Where(v =>
                    v.FirstName.ToLower().Contains(key) ||
                    v.Email.ToLower().Contains(key)).ToList();
            }

            
            // ✅ Filter by user role if not "ALL"
            if (selectedValue is UserRoleType selectedRole)
            {
                filterUsers = filterUsers.Where(v => v != null && v.Role == selectedRole).ToList();
            }


            DisplayAll(filterUsers);
        }

        private string? GetSelectedUserId()
        {
            if (gridViewUserList.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user.");
                return null;
            }

            var userId = gridViewUserList.SelectedRows[0].Cells["ID"].Value?.ToString();
            if (string.IsNullOrWhiteSpace(userId))
            {
                MessageBox.Show("Invalid user ID.");
                return null;
            }

            return userId;
        }

        #endregion

        #region CRUD Opertations
        private async Task RegisterUserAsync(RegistrationRequestDto user)
        {
            try
            {
                await _userRepository.RegisterAsync(user);
                MessageBox.Show("User added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadListAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error registering user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task UpdateUserAsync(string id, UpdateRequestDto user)
        {
            try
            {
                await _userRepository.UpdateAsync(id, user);
                MessageBox.Show("User updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadListAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            cmbUserTypes.SelectedIndex = 0;
            await LoadListAsync();

            DisplayAll(allUsers);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            using (var form = new UserDetailForm())
            {

                form.OnAdded += async (user) =>
                {
                    await RegisterUserAsync(user);
                    await LoadListAsync();
                };

                form.ShowDialog();
                
            }
                        
        }

        private async void btnEditUser_Click(object sender, EventArgs e)
        {
            string? userId = GetSelectedUserId();
            if (userId == null) return;

            var userToEdit = allUsers.FirstOrDefault(u => u?.Id == userId);
            if (userToEdit == null) return;

            using (var form = new UserDetailForm(userToEdit))
            {
                form.OnUpdated += async (updatedUser) =>
                {
                    await UpdateUserAsync(userId, updatedUser);
                };
                form.ShowDialog();
            }
        }

        private async void btnDeleteUser_Click(object sender, EventArgs e)
        {
            string? userId = GetSelectedUserId();
            if (userId == null) return;

            var confirm = MessageBox.Show("Delete this user?", "Confirm", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                await _userRepository.DeleteAsync(userId);
                await LoadListAsync();
            }
        }
        #endregion

    }
}
