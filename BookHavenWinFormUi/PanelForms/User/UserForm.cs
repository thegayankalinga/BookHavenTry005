using BookHavenClassLibrary.Dtos.User;
using BookHavenClassLibrary.Enumz;
using BookHavenClassLibrary.Interfaces;
using BookHavenClassLibrary.Repositories;
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

            var userTypeList = new List<KeyValuePair<string, UserRoleType>>();
            userTypeList.Add(new KeyValuePair<string, UserRoleType>("All Types", 0));

            foreach(var userType in userTypes)
            {
                Type type = typeof(UserRoleType);
                var fieldInfo = type.GetField(userType.ToString());

                var enumMemberAttribute = fieldInfo.GetCustomAttributes(typeof(EnumMemberAttribute), false).FirstOrDefault() as EnumMemberAttribute;

                string displayName = enumMemberAttribute?.Value ?? userType.ToString();
                userTypeList.Add(new KeyValuePair<string, UserRoleType>(displayName, userType));
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
            string? selectedUserType = (cmbUserTypes.SelectedValue != null && cmbUserTypes !=null) ? cmbUserTypes?.SelectedItem?.ToString() : string.Empty;
            
            var filterUsers = allUsers.ToList();

            if (string.IsNullOrWhiteSpace(key))
            {
                filterUsers = filterUsers.Where(v => 
                v.FirstName.ToLower().Contains(key) || 
                v.Email.ToLower().Contains(key)).ToList();
                
            }

           
            DisplayAll(filterUsers);
        }

        private async void SaveAsync(RegistrationRequestDto user, string? id)
        {
            try
            {
                if (id == null)
                {
                    await _userRepository.RegisterAsync(user);
                    MessageBox.Show("User added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    await _userRepository.UpdateAsync(id, user);
                    MessageBox.Show("User updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                await LoadListAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "User Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



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



        private async void UserForm_Load(object sender, EventArgs e)
        {
            ConfigureGrid();
            await LoadListAsync();
            LoadUserTypesToFilterComboBox();
        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            using var form = new UserDetailForm();
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                SaveAsync(form.User, null);
            }
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            if (gridViewUserList.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to edit.");
                return;
            }

            string? userId = gridViewUserList.SelectedRows[0].Cells["ID"].Value?.ToString();
            
            if (string.IsNullOrWhiteSpace(userId))
            {
                MessageBox.Show("Invalid user ID.");
                return;
            }

            var userToEdit = allUsers.FirstOrDefault(u => u?.Id == userId);
            if (userToEdit == null) return;

            using var form = new UserDetailForm(userToEdit);
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                SaveAsync(form.User, userId);
            }
        }

        private async void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (gridViewUserList.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to delete.");
                return;
            }

            string? userId = gridViewUserList.SelectedRows[0].Cells["ID"].Value?.ToString();

            if (string.IsNullOrWhiteSpace(userId))
            {
                MessageBox.Show("Invalid user ID.");
                return;
            }

            var confirm = MessageBox.Show("Delete this user?", "Confirm", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                await _userRepository.DeleteAsync(userId);
                await LoadListAsync();
            }
        }
    }
}
