namespace BookHavenWinFormUi
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            label1 = new Label();
            label2 = new Label();
            userEmail = new TextBox();
            label3 = new Label();
            userPassword = new TextBox();
            label4 = new Label();
            pictureBox1 = new PictureBox();
            loginButton = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(95, 90);
            label1.Name = "label1";
            label1.Size = new Size(104, 45);
            label1.TabIndex = 0;
            label1.Text = "Login";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.ButtonShadow;
            label2.Location = new Point(95, 165);
            label2.Name = "label2";
            label2.Size = new Size(183, 21);
            label2.TabIndex = 1;
            label2.Text = "Welcome to Book Haven ";
            // 
            // userEmail
            // 
            userEmail.Location = new Point(95, 238);
            userEmail.MinimumSize = new Size(0, 30);
            userEmail.Name = "userEmail";
            userEmail.Size = new Size(311, 30);
            userEmail.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.ButtonHighlight;
            label3.Location = new Point(95, 203);
            label3.Name = "label3";
            label3.Size = new Size(108, 21);
            label3.TabIndex = 3;
            label3.Text = "Email Address";
            // 
            // userPassword
            // 
            userPassword.Location = new Point(95, 330);
            userPassword.Name = "userPassword";
            userPassword.Size = new Size(314, 29);
            userPassword.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = SystemColors.ButtonHighlight;
            label4.Location = new Point(95, 294);
            label4.Name = "label4";
            label4.Size = new Size(76, 21);
            label4.TabIndex = 5;
            label4.Text = "Password";
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImageLayout = ImageLayout.Center;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(505, -3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(524, 600);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // loginButton
            // 
            loginButton.Location = new Point(96, 406);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(314, 54);
            loginButton.TabIndex = 7;
            loginButton.Text = "Login";
            loginButton.UseVisualStyleBackColor = true;
            loginButton.Click += loginButton_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(1027, 593);
            Controls.Add(loginButton);
            Controls.Add(pictureBox1);
            Controls.Add(label4);
            Controls.Add(userPassword);
            Controls.Add(label3);
            Controls.Add(userEmail);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 12F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 4, 4, 4);
            Name = "LoginForm";
            Text = "LoginForm";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox userEmail;
        private Label label3;
        private TextBox userPassword;
        private Label label4;
        private PictureBox pictureBox1;
        private Button loginButton;
    }
}
