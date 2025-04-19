namespace BookHavenWinFormUi.PanelForms.User
{
    partial class UserForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            gridViewUserList = new DataGridView();
            btnEditUser = new Button();
            btnDeleteUser = new Button();
            btnAddNewUser = new Button();
            txtSearchKey = new TextBox();
            lblSearchKey = new Label();
            groupBox1 = new GroupBox();
            cmbUserTypes = new ComboBox();
            lblUserTypes = new Label();
            btnResetFilter = new Button();
            btnSearch = new Button();
            groupBox2 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)gridViewUserList).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // gridViewUserList
            // 
            gridViewUserList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridViewUserList.Location = new Point(70, 169);
            gridViewUserList.MultiSelect = false;
            gridViewUserList.Name = "gridViewUserList";
            gridViewUserList.RowHeadersVisible = false;
            gridViewUserList.Size = new Size(922, 420);
            gridViewUserList.TabIndex = 9;
            // 
            // btnEditUser
            // 
            btnEditUser.ForeColor = SystemColors.ActiveCaptionText;
            btnEditUser.Location = new Point(172, 41);
            btnEditUser.Name = "btnEditUser";
            btnEditUser.Size = new Size(123, 40);
            btnEditUser.TabIndex = 6;
            btnEditUser.Text = "Edit";
            btnEditUser.UseVisualStyleBackColor = true;
            btnEditUser.Click += btnEditUser_Click;
            // 
            // btnDeleteUser
            // 
            btnDeleteUser.ForeColor = SystemColors.ActiveCaptionText;
            btnDeleteUser.Location = new Point(328, 41);
            btnDeleteUser.Name = "btnDeleteUser";
            btnDeleteUser.Size = new Size(123, 40);
            btnDeleteUser.TabIndex = 7;
            btnDeleteUser.Text = "Delete";
            btnDeleteUser.UseVisualStyleBackColor = true;
            btnDeleteUser.Click += btnDeleteUser_Click;
            // 
            // btnAddNewUser
            // 
            btnAddNewUser.ForeColor = SystemColors.ActiveCaptionText;
            btnAddNewUser.Location = new Point(21, 41);
            btnAddNewUser.Name = "btnAddNewUser";
            btnAddNewUser.Size = new Size(123, 40);
            btnAddNewUser.TabIndex = 5;
            btnAddNewUser.Text = "Add New";
            btnAddNewUser.UseVisualStyleBackColor = true;
            btnAddNewUser.Click += btnAddNewUser_Click;
            // 
            // txtSearchKey
            // 
            txtSearchKey.Location = new Point(94, 30);
            txtSearchKey.Name = "txtSearchKey";
            txtSearchKey.Size = new Size(211, 29);
            txtSearchKey.TabIndex = 1;
            txtSearchKey.KeyPress += txtSearchKey_KeyPress;
            // 
            // lblSearchKey
            // 
            lblSearchKey.AutoSize = true;
            lblSearchKey.ForeColor = SystemColors.ButtonHighlight;
            lblSearchKey.Location = new Point(14, 33);
            lblSearchKey.Name = "lblSearchKey";
            lblSearchKey.Size = new Size(57, 21);
            lblSearchKey.TabIndex = 3;
            lblSearchKey.Text = "Search";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cmbUserTypes);
            groupBox1.Controls.Add(lblUserTypes);
            groupBox1.Controls.Add(btnResetFilter);
            groupBox1.Controls.Add(btnSearch);
            groupBox1.Controls.Add(txtSearchKey);
            groupBox1.Controls.Add(lblSearchKey);
            groupBox1.ForeColor = SystemColors.ControlDark;
            groupBox1.Location = new Point(70, 21);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(922, 129);
            groupBox1.TabIndex = 10;
            groupBox1.TabStop = false;
            groupBox1.Text = "Filter";
            // 
            // cmbUserTypes
            // 
            cmbUserTypes.ForeColor = SystemColors.ActiveCaptionText;
            cmbUserTypes.FormattingEnabled = true;
            cmbUserTypes.Location = new Point(491, 30);
            cmbUserTypes.Name = "cmbUserTypes";
            cmbUserTypes.Size = new Size(210, 29);
            cmbUserTypes.TabIndex = 2;
            // 
            // lblUserTypes
            // 
            lblUserTypes.AutoSize = true;
            lblUserTypes.ForeColor = SystemColors.ButtonHighlight;
            lblUserTypes.Location = new Point(390, 33);
            lblUserTypes.Name = "lblUserTypes";
            lblUserTypes.Size = new Size(78, 21);
            lblUserTypes.TabIndex = 5;
            lblUserTypes.Text = "User Type";
            // 
            // btnResetFilter
            // 
            btnResetFilter.ForeColor = SystemColors.ActiveCaptionText;
            btnResetFilter.Location = new Point(634, 83);
            btnResetFilter.Name = "btnResetFilter";
            btnResetFilter.Size = new Size(123, 40);
            btnResetFilter.TabIndex = 4;
            btnResetFilter.Text = "Reset";
            btnResetFilter.UseVisualStyleBackColor = true;
            btnResetFilter.Click += btnResetFilter_Click;
            // 
            // btnSearch
            // 
            btnSearch.ForeColor = SystemColors.ActiveCaptionText;
            btnSearch.Location = new Point(773, 83);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(123, 40);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnEditUser);
            groupBox2.Controls.Add(btnDeleteUser);
            groupBox2.Controls.Add(btnAddNewUser);
            groupBox2.ForeColor = SystemColors.ButtonHighlight;
            groupBox2.Location = new Point(75, 595);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(917, 104);
            groupBox2.TabIndex = 11;
            groupBox2.TabStop = false;
            groupBox2.Text = "Actions";
            // 
            // UserForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(1062, 720);
            Controls.Add(gridViewUserList);
            Controls.Add(groupBox1);
            Controls.Add(groupBox2);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "UserForm";
            Text = "UserForm";
            Load += UserForm_Load;
            ((System.ComponentModel.ISupportInitialize)gridViewUserList).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView gridViewUserList;
        private Button btnEditUser;
        private Button btnDeleteUser;
        private Button btnAddNewUser;
        private TextBox txtSearchKey;
        private Label lblSearchKey;
        private GroupBox groupBox1;
        private Button btnResetFilter;
        private Button btnSearch;
        private GroupBox groupBox2;
        private ComboBox cmbUserTypes;
        private Label lblUserTypes;
    }
}