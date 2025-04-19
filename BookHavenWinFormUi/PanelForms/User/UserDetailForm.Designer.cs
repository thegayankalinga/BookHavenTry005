namespace BookHavenWinFormUi.PanelForms.User
{
    partial class UserDetailForm
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
            gbBookDetails = new GroupBox();
            cbAddAnother = new CheckBox();
            btnSave = new Button();
            btnCancel = new Button();
            cmbUserTypes = new ComboBox();
            lblUserType = new Label();
            lblLastName = new Label();
            lblFirstName = new Label();
            lblPassword = new Label();
            lblUserID = new Label();
            lblUser_ID = new Label();
            lblEmail = new Label();
            txtLastName = new TextBox();
            txtFirstName = new TextBox();
            txtPassword = new TextBox();
            txtEmail = new TextBox();
            gbBookDetails.SuspendLayout();
            SuspendLayout();
            // 
            // gbBookDetails
            // 
            gbBookDetails.Controls.Add(cbAddAnother);
            gbBookDetails.Controls.Add(btnSave);
            gbBookDetails.Controls.Add(btnCancel);
            gbBookDetails.Controls.Add(cmbUserTypes);
            gbBookDetails.Controls.Add(lblUserType);
            gbBookDetails.Controls.Add(lblLastName);
            gbBookDetails.Controls.Add(lblFirstName);
            gbBookDetails.Controls.Add(lblPassword);
            gbBookDetails.Controls.Add(lblUserID);
            gbBookDetails.Controls.Add(lblUser_ID);
            gbBookDetails.Controls.Add(lblEmail);
            gbBookDetails.Controls.Add(txtLastName);
            gbBookDetails.Controls.Add(txtFirstName);
            gbBookDetails.Controls.Add(txtPassword);
            gbBookDetails.Controls.Add(txtEmail);
            gbBookDetails.ForeColor = SystemColors.ButtonHighlight;
            gbBookDetails.Location = new Point(35, 33);
            gbBookDetails.Name = "gbBookDetails";
            gbBookDetails.Size = new Size(549, 540);
            gbBookDetails.TabIndex = 6;
            gbBookDetails.TabStop = false;
            gbBookDetails.Text = "User Details";
            // 
            // cbAddAnother
            // 
            cbAddAnother.AutoSize = true;
            cbAddAnother.Location = new Point(382, 431);
            cbAddAnother.Name = "cbAddAnother";
            cbAddAnother.Size = new Size(117, 25);
            cbAddAnother.TabIndex = 6;
            cbAddAnother.Text = "Add Another";
            cbAddAnother.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.ForeColor = SystemColors.ActiveCaptionText;
            btnSave.Location = new Point(359, 477);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(140, 47);
            btnSave.TabIndex = 7;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.ForeColor = SystemColors.ActiveCaptionText;
            btnCancel.Location = new Point(190, 477);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(140, 47);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // cmbUserTypes
            // 
            cmbUserTypes.FormattingEnabled = true;
            cmbUserTypes.Location = new Point(176, 279);
            cmbUserTypes.Name = "cmbUserTypes";
            cmbUserTypes.Size = new Size(323, 29);
            cmbUserTypes.TabIndex = 5;
            // 
            // lblUserType
            // 
            lblUserType.AutoSize = true;
            lblUserType.Location = new Point(35, 282);
            lblUserType.Margin = new Padding(4, 0, 4, 0);
            lblUserType.Name = "lblUserType";
            lblUserType.Size = new Size(78, 21);
            lblUserType.TabIndex = 0;
            lblUserType.Text = "User Type";
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Location = new Point(35, 227);
            lblLastName.Margin = new Padding(4, 0, 4, 0);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(84, 21);
            lblLastName.TabIndex = 0;
            lblLastName.Text = "Last Name";
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Location = new Point(35, 174);
            lblFirstName.Margin = new Padding(4, 0, 4, 0);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(86, 21);
            lblFirstName.TabIndex = 0;
            lblFirstName.Text = "First Name";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(35, 116);
            lblPassword.Margin = new Padding(4, 0, 4, 0);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(76, 21);
            lblPassword.TabIndex = 0;
            lblPassword.Text = "Password";
            // 
            // lblUserID
            // 
            lblUserID.AutoSize = true;
            lblUserID.Location = new Point(176, 345);
            lblUserID.Margin = new Padding(4, 0, 4, 0);
            lblUserID.Name = "lblUserID";
            lblUserID.Size = new Size(61, 21);
            lblUserID.TabIndex = 0;
            lblUserID.Text = "User ID";
            // 
            // lblUser_ID
            // 
            lblUser_ID.AutoSize = true;
            lblUser_ID.Location = new Point(35, 345);
            lblUser_ID.Margin = new Padding(4, 0, 4, 0);
            lblUser_ID.Name = "lblUser_ID";
            lblUser_ID.Size = new Size(61, 21);
            lblUser_ID.TabIndex = 0;
            lblUser_ID.Text = "User ID";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(35, 62);
            lblEmail.Margin = new Padding(4, 0, 4, 0);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(44, 21);
            lblEmail.TabIndex = 0;
            lblEmail.Text = "Emai";
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(176, 224);
            txtLastName.Margin = new Padding(4);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(323, 29);
            txtLastName.TabIndex = 4;
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(176, 171);
            txtFirstName.Margin = new Padding(4);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(323, 29);
            txtFirstName.TabIndex = 3;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(176, 113);
            txtPassword.Margin = new Padding(4);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(323, 29);
            txtPassword.TabIndex = 2;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(176, 60);
            txtEmail.Margin = new Padding(4);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(323, 29);
            txtEmail.TabIndex = 1;
            // 
            // UserDetailForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(619, 606);
            Controls.Add(gbBookDetails);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "UserDetailForm";
            Text = "UserDetailForm";
            Load += UserDetailForm_Load;
            gbBookDetails.ResumeLayout(false);
            gbBookDetails.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gbBookDetails;
        private Button btnSave;
        private Button btnCancel;
        private ComboBox cmbUserTypes;
        private Label lblUserType;
        private Label lblLastName;
        private Label lblFirstName;
        private Label lblPassword;
        private Label lblUser_ID;
        private Label lblEmail;
        private TextBox txtLastName;
        private TextBox txtFirstName;
        private TextBox txtPassword;
        private TextBox txtEmail;
        private Label lblUserID;
        private CheckBox cbAddAnother;
    }
}