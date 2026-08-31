namespace BMICalculator
{
    partial class BMIForm
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
            lblTitle = new Label();
            lblHeight = new Label();
            txtHeight = new TextBox();
            lblHeightUnit = new Label();
            lblWeight = new Label();
            txtWeight = new TextBox();
            lblWeightUnit = new Label();
            btnCalculate = new Button();
            btnClear = new Button();
            lblSuggestion = new Label();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.Location = new Point(80, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(180, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "BMI Calculator";
            // 
            // lblHeight
            // 
            lblHeight.AutoSize = true;
            lblHeight.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblHeight.Location = new Point(40, 80);
            lblHeight.Name = "lblHeight";
            lblHeight.Size = new Size(52, 19);
            lblHeight.TabIndex = 1;
            lblHeight.Text = "Height";
            // 
            // txtHeight
            // 
            txtHeight.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtHeight.Location = new Point(120, 77);
            txtHeight.Name = "txtHeight";
            txtHeight.Size = new Size(100, 25);
            txtHeight.TabIndex = 2;
            // 
            // lblHeightUnit
            // 
            lblHeightUnit.AutoSize = true;
            lblHeightUnit.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblHeightUnit.Location = new Point(230, 80);
            lblHeightUnit.Name = "lblHeightUnit";
            lblHeightUnit.Size = new Size(30, 19);
            lblHeightUnit.TabIndex = 3;
            lblHeightUnit.Text = "cm";
            // 
            // lblWeight
            // 
            lblWeight.AutoSize = true;
            lblWeight.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblWeight.Location = new Point(40, 130);
            lblWeight.Name = "lblWeight";
            lblWeight.Size = new Size(54, 19);
            lblWeight.TabIndex = 4;
            lblWeight.Text = "Weight";
            // 
            // txtWeight
            // 
            txtWeight.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtWeight.Location = new Point(120, 127);
            txtWeight.Name = "txtWeight";
            txtWeight.Size = new Size(100, 25);
            txtWeight.TabIndex = 5;
            // 
            // lblWeightUnit
            // 
            lblWeightUnit.AutoSize = true;
            lblWeightUnit.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblWeightUnit.Location = new Point(230, 130);
            lblWeightUnit.Name = "lblWeightUnit";
            lblWeightUnit.Size = new Size(24, 19);
            lblWeightUnit.TabIndex = 6;
            lblWeightUnit.Text = "kg";
            // 
            // btnCalculate
            // 
            btnCalculate.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnCalculate.Location = new Point(60, 180);
            btnCalculate.Name = "btnCalculate";
            btnCalculate.Size = new Size(100, 35);
            btnCalculate.TabIndex = 7;
            btnCalculate.Text = "Calculate";
            btnCalculate.UseVisualStyleBackColor = true;
            btnCalculate.Click += btnCalculate_Click;
            // 
            // btnClear
            // 
            btnClear.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnClear.Location = new Point(180, 180);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(100, 35);
            btnClear.TabIndex = 8;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // lblSuggestion
            // 
            lblSuggestion.BorderStyle = BorderStyle.FixedSingle;
            lblSuggestion.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblSuggestion.Location = new Point(20, 235);
            lblSuggestion.Name = "lblSuggestion";
            lblSuggestion.Size = new Size(300, 90);
            lblSuggestion.TabIndex = 9;
            lblSuggestion.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // BMIForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(340, 350);
            Controls.Add(lblSuggestion);
            Controls.Add(btnClear);
            Controls.Add(btnCalculate);
            Controls.Add(lblWeightUnit);
            Controls.Add(txtWeight);
            Controls.Add(lblWeight);
            Controls.Add(lblHeightUnit);
            Controls.Add(txtHeight);
            Controls.Add(lblHeight);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "BMIForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BMI Calculator";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblHeight;
        private TextBox txtHeight;
        private Label lblHeightUnit;
        private Label lblWeight;
        private TextBox txtWeight;
        private Label lblWeightUnit;
        private Button btnCalculate;
        private Button btnClear;
        private Label lblSuggestion;
    }
}
