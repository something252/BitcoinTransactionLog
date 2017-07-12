namespace Bitcoin_Transaction_Log
{
    partial class NewBuySell
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
            if (disposing && (components != null)) {
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
            this.components = new System.ComponentModel.Container();
            this.BTCExchangerateLockCheckBox = new System.Windows.Forms.CheckBox();
            this.FeePercentTextBox = new System.Windows.Forms.TextBox();
            this.Label9 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.DateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.DateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.Label4 = new System.Windows.Forms.Label();
            this.BTCExchangeRateTextBox = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.USDTextBox = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.BTCTextBox = new System.Windows.Forms.TextBox();
            this.ComboBox1 = new System.Windows.Forms.ComboBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.FeeAmountTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BTCExchangerateLockCheckBox
            // 
            this.BTCExchangerateLockCheckBox.AutoSize = true;
            this.BTCExchangerateLockCheckBox.Checked = true;
            this.BTCExchangerateLockCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.BTCExchangerateLockCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTCExchangerateLockCheckBox.Location = new System.Drawing.Point(247, 355);
            this.BTCExchangerateLockCheckBox.Name = "BTCExchangerateLockCheckBox";
            this.BTCExchangerateLockCheckBox.Size = new System.Drawing.Size(15, 14);
            this.BTCExchangerateLockCheckBox.TabIndex = 9;
            this.toolTip1.SetToolTip(this.BTCExchangerateLockCheckBox, "Solve for exchange rate when checked");
            this.BTCExchangerateLockCheckBox.UseVisualStyleBackColor = true;
            this.BTCExchangerateLockCheckBox.CheckedChanged += new System.EventHandler(this.BTCExchangerateLockCheckBox_CheckedChanged);
            // 
            // FeePercentTextBox
            // 
            this.FeePercentTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FeePercentTextBox.Location = new System.Drawing.Point(155, 309);
            this.FeePercentTextBox.MaxLength = 8;
            this.FeePercentTextBox.Name = "FeePercentTextBox";
            this.FeePercentTextBox.Size = new System.Drawing.Size(129, 26);
            this.FeePercentTextBox.TabIndex = 6;
            this.FeePercentTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.FeePercentTextBox.TextChanged += new System.EventHandler(this.BTCAndUSD_TextChanged);
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label9.Location = new System.Drawing.Point(284, 309);
            this.Label9.Margin = new System.Windows.Forms.Padding(3);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(25, 24);
            this.Label9.TabIndex = 47;
            this.Label9.Text = "%";
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label7.Location = new System.Drawing.Point(196, 57);
            this.Label7.Margin = new System.Windows.Forms.Padding(3);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(59, 25);
            this.Label7.TabIndex = 44;
            this.Label7.Text = "Time";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.Location = new System.Drawing.Point(47, 57);
            this.Label5.Margin = new System.Windows.Forms.Padding(3);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(57, 25);
            this.Label5.TabIndex = 43;
            this.Label5.Text = "Date";
            // 
            // DateTimePicker1
            // 
            this.DateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DateTimePicker1.Location = new System.Drawing.Point(0, 88);
            this.DateTimePicker1.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.DateTimePicker1.Name = "DateTimePicker1";
            this.DateTimePicker1.Size = new System.Drawing.Size(155, 29);
            this.DateTimePicker1.TabIndex = 2;
            // 
            // DateTimePicker2
            // 
            this.DateTimePicker2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.DateTimePicker2.Location = new System.Drawing.Point(155, 88);
            this.DateTimePicker2.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.DateTimePicker2.Name = "DateTimePicker2";
            this.DateTimePicker2.Size = new System.Drawing.Size(195, 29);
            this.DateTimePicker2.TabIndex = 3;
            // 
            // Label4
            // 
            this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(0, 349);
            this.Label4.Margin = new System.Windows.Forms.Padding(3);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(305, 24);
            this.Label4.TabIndex = 42;
            this.Label4.Text = "BTC Exchange Rate";
            this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BTCExchangeRateTextBox
            // 
            this.BTCExchangeRateTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTCExchangeRateTextBox.Location = new System.Drawing.Point(0, 379);
            this.BTCExchangeRateTextBox.MaxLength = 15;
            this.BTCExchangeRateTextBox.Name = "BTCExchangeRateTextBox";
            this.BTCExchangeRateTextBox.ReadOnly = true;
            this.BTCExchangeRateTextBox.Size = new System.Drawing.Size(307, 26);
            this.BTCExchangeRateTextBox.TabIndex = 7;
            this.BTCExchangeRateTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BTCExchangeRateTextBox.Click += new System.EventHandler(this.BTCExchangeRateTextBox_Click);
            this.BTCExchangeRateTextBox.TextChanged += new System.EventHandler(this.BTCExchangeRateTextBox_TextChanged);
            // 
            // Label3
            // 
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(0, 279);
            this.Label3.Margin = new System.Windows.Forms.Padding(3);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(305, 24);
            this.Label3.TabIndex = 40;
            this.Label3.Text = "Fee";
            this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label2
            // 
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(0, 207);
            this.Label2.Margin = new System.Windows.Forms.Padding(3);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(305, 25);
            this.Label2.TabIndex = 36;
            this.Label2.Text = "USD ($)";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // USDTextBox
            // 
            this.USDTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.USDTextBox.Location = new System.Drawing.Point(0, 238);
            this.USDTextBox.MaxLength = 15;
            this.USDTextBox.Name = "USDTextBox";
            this.USDTextBox.Size = new System.Drawing.Size(307, 26);
            this.USDTextBox.TabIndex = 5;
            this.USDTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.USDTextBox.TextChanged += new System.EventHandler(this.BTCAndUSD_TextChanged);
            // 
            // Label1
            // 
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(0, 135);
            this.Label1.Margin = new System.Windows.Forms.Padding(3);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(305, 25);
            this.Label1.TabIndex = 33;
            this.Label1.Text = "BTC";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ConfirmButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfirmButton.Location = new System.Drawing.Point(0, 431);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(305, 51);
            this.ConfirmButton.TabIndex = 8;
            this.ConfirmButton.Text = "Confirm";
            this.toolTip1.SetToolTip(this.ConfirmButton, "Add to list");
            this.ConfirmButton.UseVisualStyleBackColor = true;
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // BTCTextBox
            // 
            this.BTCTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTCTextBox.Location = new System.Drawing.Point(0, 166);
            this.BTCTextBox.MaxLength = 10;
            this.BTCTextBox.Name = "BTCTextBox";
            this.BTCTextBox.Size = new System.Drawing.Size(307, 26);
            this.BTCTextBox.TabIndex = 4;
            this.BTCTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BTCTextBox.TextChanged += new System.EventHandler(this.BTCAndUSD_TextChanged);
            // 
            // ComboBox1
            // 
            this.ComboBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboBox1.FormattingEnabled = true;
            this.ComboBox1.Location = new System.Drawing.Point(0, 0);
            this.ComboBox1.Name = "ComboBox1";
            this.ComboBox1.Size = new System.Drawing.Size(305, 39);
            this.ComboBox1.TabIndex = 1;
            this.ComboBox1.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // FeeAmountTextBox
            // 
            this.FeeAmountTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FeeAmountTextBox.Location = new System.Drawing.Point(21, 309);
            this.FeeAmountTextBox.MaxLength = 8;
            this.FeeAmountTextBox.Name = "FeeAmountTextBox";
            this.FeeAmountTextBox.ReadOnly = true;
            this.FeeAmountTextBox.Size = new System.Drawing.Size(128, 26);
            this.FeeAmountTextBox.TabIndex = 48;
            this.FeeAmountTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(1, 309);
            this.label10.Margin = new System.Windows.Forms.Padding(3);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(20, 24);
            this.label10.TabIndex = 49;
            this.label10.Text = "$";
            // 
            // NewBuySell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 482);
            this.Controls.Add(this.FeeAmountTextBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.ComboBox1);
            this.Controls.Add(this.BTCExchangerateLockCheckBox);
            this.Controls.Add(this.FeePercentTextBox);
            this.Controls.Add(this.Label9);
            this.Controls.Add(this.Label7);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.DateTimePicker1);
            this.Controls.Add(this.DateTimePicker2);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.BTCExchangeRateTextBox);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.USDTextBox);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.ConfirmButton);
            this.Controls.Add(this.BTCTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "NewBuySell";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.NewBuySell_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.CheckBox BTCExchangerateLockCheckBox;
        internal System.Windows.Forms.TextBox FeePercentTextBox;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.DateTimePicker DateTimePicker1;
        internal System.Windows.Forms.DateTimePicker DateTimePicker2;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.TextBox BTCExchangeRateTextBox;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox USDTextBox;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Button ConfirmButton;
        internal System.Windows.Forms.TextBox BTCTextBox;
        internal System.Windows.Forms.ComboBox ComboBox1;
        private System.Windows.Forms.ToolTip toolTip1;
        internal System.Windows.Forms.TextBox FeeAmountTextBox;
        internal System.Windows.Forms.Label label10;
    }
}