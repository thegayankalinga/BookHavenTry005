namespace BookHavenWinFormUi.PanelForms
{
    partial class SupplierForm
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
            groupBox1 = new GroupBox();
            saveButton = new Button();
            supplierTypeGroupBox = new GroupBox();
            individualButton = new RadioButton();
            companyButton = new RadioButton();
            supplierPhoneNumberText = new TextBox();
            supplierContactPerosnText = new TextBox();
            supplierNameText = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            deleteButton = new Button();
            editButton = new Button();
            supplierDataGridView = new DataGridView();
            groupBox1.SuspendLayout();
            supplierTypeGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)supplierDataGridView).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(saveButton);
            groupBox1.Controls.Add(supplierTypeGroupBox);
            groupBox1.Controls.Add(supplierPhoneNumberText);
            groupBox1.Controls.Add(supplierContactPerosnText);
            groupBox1.Controls.Add(supplierNameText);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.ForeColor = SystemColors.ButtonFace;
            groupBox1.Location = new Point(20, 28);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(438, 422);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Supplier Record";
            // 
            // saveButton
            // 
            saveButton.ForeColor = SystemColors.ActiveCaptionText;
            saveButton.Location = new Point(281, 351);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(123, 40);
            saveButton.TabIndex = 7;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // supplierTypeGroupBox
            // 
            supplierTypeGroupBox.Controls.Add(individualButton);
            supplierTypeGroupBox.Controls.Add(companyButton);
            supplierTypeGroupBox.ForeColor = SystemColors.ButtonHighlight;
            supplierTypeGroupBox.Location = new Point(152, 215);
            supplierTypeGroupBox.Name = "supplierTypeGroupBox";
            supplierTypeGroupBox.Size = new Size(252, 100);
            supplierTypeGroupBox.TabIndex = 6;
            supplierTypeGroupBox.TabStop = false;
            supplierTypeGroupBox.Text = "Supplier Type";
            // 
            // individualButton
            // 
            individualButton.AutoSize = true;
            individualButton.Location = new Point(19, 36);
            individualButton.Name = "individualButton";
            individualButton.Size = new Size(96, 25);
            individualButton.TabIndex = 4;
            individualButton.TabStop = true;
            individualButton.Text = "Individual";
            individualButton.UseVisualStyleBackColor = true;
            // 
            // companyButton
            // 
            companyButton.AutoSize = true;
            companyButton.Location = new Point(19, 67);
            companyButton.Name = "companyButton";
            companyButton.Size = new Size(95, 25);
            companyButton.TabIndex = 5;
            companyButton.TabStop = true;
            companyButton.Text = "Company";
            companyButton.UseVisualStyleBackColor = true;
            // 
            // supplierPhoneNumberText
            // 
            supplierPhoneNumberText.Location = new Point(151, 150);
            supplierPhoneNumberText.Name = "supplierPhoneNumberText";
            supplierPhoneNumberText.Size = new Size(253, 29);
            supplierPhoneNumberText.TabIndex = 3;
            // 
            // supplierContactPerosnText
            // 
            supplierContactPerosnText.Location = new Point(152, 98);
            supplierContactPerosnText.Name = "supplierContactPerosnText";
            supplierContactPerosnText.Size = new Size(256, 29);
            supplierContactPerosnText.TabIndex = 2;
            // 
            // supplierNameText
            // 
            supplierNameText.Location = new Point(151, 47);
            supplierNameText.Name = "supplierNameText";
            supplierNameText.Size = new Size(257, 29);
            supplierNameText.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(20, 153);
            label3.Name = "label3";
            label3.Size = new Size(116, 21);
            label3.TabIndex = 0;
            label3.Text = "Phone Number";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 101);
            label2.Name = "label2";
            label2.Size = new Size(114, 21);
            label2.TabIndex = 0;
            label2.Text = "Contact Person";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 50);
            label1.Name = "label1";
            label1.Size = new Size(114, 21);
            label1.TabIndex = 0;
            label1.Text = "Supplier Name";
            // 
            // deleteButton
            // 
            deleteButton.ForeColor = SystemColors.ActiveCaptionText;
            deleteButton.Location = new Point(975, 570);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(123, 40);
            deleteButton.TabIndex = 7;
            deleteButton.Text = "Delete";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += deleteButton_Click;
            // 
            // editButton
            // 
            editButton.ForeColor = SystemColors.ActiveCaptionText;
            editButton.Location = new Point(825, 570);
            editButton.Name = "editButton";
            editButton.Size = new Size(123, 40);
            editButton.TabIndex = 7;
            editButton.Text = "Edit";
            editButton.UseVisualStyleBackColor = true;
            editButton.Click += editButton_Click;
            // 
            // supplierDataGridView
            // 
            supplierDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            supplierDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            supplierDataGridView.Location = new Point(509, 28);
            supplierDataGridView.Name = "supplierDataGridView";
            supplierDataGridView.RowHeadersVisible = false;
            supplierDataGridView.Size = new Size(589, 523);
            supplierDataGridView.TabIndex = 8;
            // 
            // SupplierForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(1132, 651);
            Controls.Add(supplierDataGridView);
            Controls.Add(editButton);
            Controls.Add(deleteButton);
            Controls.Add(groupBox1);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "SupplierForm";
            Text = "SupplierForm";
            Load += SupplierForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            supplierTypeGroupBox.ResumeLayout(false);
            supplierTypeGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)supplierDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox supplierTypeGroupBox;
        private RadioButton companyButton;
        private RadioButton individualButton;
        private TextBox supplierPhoneNumberText;
        private TextBox supplierContactPerosnText;
        private TextBox supplierNameText;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button saveButton;
        private Button deleteButton;
        private Button editButton;
        private DataGridView supplierDataGridView;
    }
}