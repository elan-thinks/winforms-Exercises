namespace ElectronicsInventory
{
    partial class ProductForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblName = new Label();
            txtName = new TextBox();
            lblCategory = new Label();
            cmbCategory = new ComboBox();
            lblPrice = new Label();
            txtPrice = new TextBox();
            lblQuantity = new Label();
            txtQuantity = new TextBox();
            lblManufactureDate = new Label();
            dtpManufactureDate = new DateTimePicker();
            lblExpiryDate = new Label();
            dtpExpiryDate = new DateTimePicker();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.ForeColor = Color.FromArgb(100, 140, 100);
            lblTitle.Location = new Point(110, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(140, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Add Product";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblName.ForeColor = Color.FromArgb(80, 110, 80);
            lblName.Location = new Point(40, 55);
            lblName.Name = "lblName";
            lblName.Size = new Size(97, 19);
            lblName.TabIndex = 1;
            lblName.Text = "Product Name";
            // 
            // txtName
            // 
            txtName.BackColor = Color.FromArgb(250, 255, 250);
            txtName.BorderStyle = BorderStyle.FixedSingle;
            txtName.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            txtName.Location = new Point(40, 78);
            txtName.Name = "txtName";
            txtName.Size = new Size(280, 27);
            txtName.TabIndex = 2;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblCategory.ForeColor = Color.FromArgb(80, 110, 80);
            lblCategory.Location = new Point(40, 115);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(65, 19);
            lblCategory.TabIndex = 3;
            lblCategory.Text = "Category";
            // 
            // cmbCategory
            // 
            cmbCategory.BackColor = Color.FromArgb(250, 255, 250);
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Items.AddRange(new object[] {
                "Computer",
                "Accessories",
                "Audio",
                "Mobile",
                "Display",
                "Storage",
                "Networking",
                "Other"
            });
            cmbCategory.Location = new Point(40, 138);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(280, 28);
            cmbCategory.TabIndex = 4;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblPrice.ForeColor = Color.FromArgb(80, 110, 80);
            lblPrice.Location = new Point(40, 180);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(38, 19);
            lblPrice.TabIndex = 5;
            lblPrice.Text = "Price";
            // 
            // txtPrice
            // 
            txtPrice.BackColor = Color.FromArgb(250, 255, 250);
            txtPrice.BorderStyle = BorderStyle.FixedSingle;
            txtPrice.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            txtPrice.Location = new Point(40, 203);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(280, 27);
            txtPrice.TabIndex = 6;
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblQuantity.ForeColor = Color.FromArgb(80, 110, 80);
            lblQuantity.Location = new Point(40, 245);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(62, 19);
            lblQuantity.TabIndex = 7;
            lblQuantity.Text = "Quantity";
            // 
            // txtQuantity
            // 
            txtQuantity.BackColor = Color.FromArgb(250, 255, 250);
            txtQuantity.BorderStyle = BorderStyle.FixedSingle;
            txtQuantity.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            txtQuantity.Location = new Point(40, 268);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(280, 27);
            txtQuantity.TabIndex = 8;
            // 
            // lblManufactureDate
            // 
            lblManufactureDate.AutoSize = true;
            lblManufactureDate.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblManufactureDate.ForeColor = Color.FromArgb(80, 110, 80);
            lblManufactureDate.Location = new Point(40, 310);
            lblManufactureDate.Name = "lblManufactureDate";
            lblManufactureDate.Size = new Size(120, 19);
            lblManufactureDate.TabIndex = 9;
            lblManufactureDate.Text = "Manufacture Date";
            // 
            // dtpManufactureDate
            // 
            dtpManufactureDate.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            dtpManufactureDate.Format = DateTimePickerFormat.Short;
            dtpManufactureDate.Location = new Point(40, 333);
            dtpManufactureDate.Name = "dtpManufactureDate";
            dtpManufactureDate.Size = new Size(280, 27);
            dtpManufactureDate.TabIndex = 10;
            // 
            // lblExpiryDate
            // 
            lblExpiryDate.AutoSize = true;
            lblExpiryDate.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblExpiryDate.ForeColor = Color.FromArgb(80, 110, 80);
            lblExpiryDate.Location = new Point(40, 375);
            lblExpiryDate.Name = "lblExpiryDate";
            lblExpiryDate.Size = new Size(78, 19);
            lblExpiryDate.TabIndex = 11;
            lblExpiryDate.Text = "Expiry Date";
            // 
            // dtpExpiryDate
            // 
            dtpExpiryDate.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            dtpExpiryDate.Format = DateTimePickerFormat.Short;
            dtpExpiryDate.Location = new Point(40, 398);
            dtpExpiryDate.Name = "dtpExpiryDate";
            dtpExpiryDate.Size = new Size(280, 27);
            dtpExpiryDate.TabIndex = 12;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(140, 200, 160);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(40, 450);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(130, 40);
            btnSave.TabIndex = 13;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(230, 220, 210);
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btnCancel.ForeColor = Color.FromArgb(100, 90, 80);
            btnCancel.Location = new Point(190, 450);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(130, 40);
            btnCancel.TabIndex = 14;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // ProductForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 255, 245);
            ClientSize = new Size(360, 515);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(dtpExpiryDate);
            Controls.Add(lblExpiryDate);
            Controls.Add(dtpManufactureDate);
            Controls.Add(lblManufactureDate);
            Controls.Add(txtQuantity);
            Controls.Add(lblQuantity);
            Controls.Add(txtPrice);
            Controls.Add(lblPrice);
            Controls.Add(cmbCategory);
            Controls.Add(lblCategory);
            Controls.Add(txtName);
            Controls.Add(lblName);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "ProductForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add Product";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblName;
        private TextBox txtName;
        private Label lblCategory;
        private ComboBox cmbCategory;
        private Label lblPrice;
        private TextBox txtPrice;
        private Label lblQuantity;
        private TextBox txtQuantity;
        private Label lblManufactureDate;
        private DateTimePicker dtpManufactureDate;
        private Label lblExpiryDate;
        private DateTimePicker dtpExpiryDate;
        private Button btnSave;
        private Button btnCancel;
    }
}
