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
            this.BTCExchangerateLockCheckBox = new System.Windows.Forms.CheckBox();
            this.FeeChargedTextBox = new System.Windows.Forms.TextBox();
            this.Label9 = new System.Windows.Forms.Label();
            this.Label8 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
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
            this.SuspendLayout();
            // 
            // BTCExchangerateLockCheckBox
            // 
            this.BTCExchangerateLockCheckBox.AutoSize = true;
            this.BTCExchangerateLockCheckBox.Checked = true;
            this.BTCExchangerateLockCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.BTCExchangerateLockCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTCExchangerateLockCheckBox.Location = new System.Drawing.Point(250, 405);
            this.BTCExchangerateLockCheckBox.Name = "BTCExchangerateLockCheckBox";
            this.BTCExchangerateLockCheckBox.Size = new System.Drawing.Size(15, 14);
            this.BTCExchangerateLockCheckBox.TabIndex = 48;
            this.BTCExchangerateLockCheckBox.UseVisualStyleBackColor = true;
            this.BTCExchangerateLockCheckBox.CheckedChanged += new System.EventHandler(this.BTCExchangerateLockCheckBox_CheckedChanged);
            // 
            // FeeChargedTextBox
            // 
            this.FeeChargedTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FeeChargedTextBox.Location = new System.Drawing.Point(0, 359);
            this.FeeChargedTextBox.MaxLength = 8;
            this.FeeChargedTextBox.Name = "FeeChargedTextBox";
            this.FeeChargedTextBox.Size = new System.Drawing.Size(284, 26);
            this.FeeChargedTextBox.TabIndex = 38;
            this.FeeChargedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.FeeChargedTextBox.TextChanged += new System.EventHandler(this.BTCAndUSD_TextChanged);
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label9.Location = new System.Drawing.Point(284, 359);
            this.Label9.Margin = new System.Windows.Forms.Padding(3);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(25, 24);
            this.Label9.TabIndex = 47;
            this.Label9.Text = "%";
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label8.Location = new System.Drawing.Point(17, 74);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(265, 20);
            this.Label8.TabIndex = 46;
            this.Label8.Text = "Loss = spent BTC    Gain = free BTC";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.Location = new System.Drawing.Point(26, 50);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(246, 20);
            this.Label6.TabIndex = 45;
            this.Label6.Text = "Buy = buy BTC        Sell = sell BTC";
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label7.Location = new System.Drawing.Point(196, 107);
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
            this.Label5.Location = new System.Drawing.Point(47, 107);
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
            this.DateTimePicker1.Location = new System.Drawing.Point(0, 138);
            this.DateTimePicker1.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.DateTimePicker1.Name = "DateTimePicker1";
            this.DateTimePicker1.Size = new System.Drawing.Size(155, 29);
            this.DateTimePicker1.TabIndex = 32;
            // 
            // DateTimePicker2
            // 
            this.DateTimePicker2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.DateTimePicker2.Location = new System.Drawing.Point(155, 138);
            this.DateTimePicker2.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.DateTimePicker2.Name = "DateTimePicker2";
            this.DateTimePicker2.Size = new System.Drawing.Size(195, 29);
            this.DateTimePicker2.TabIndex = 34;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(62, 399);
            this.Label4.Margin = new System.Windows.Forms.Padding(3);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(182, 24);
            this.Label4.TabIndex = 42;
            this.Label4.Text = "BTC Exchange Rate";
            // 
            // BTCExchangeRateTextBox
            // 
            this.BTCExchangeRateTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTCExchangeRateTextBox.Location = new System.Drawing.Point(0, 429);
            this.BTCExchangeRateTextBox.MaxLength = 15;
            this.BTCExchangeRateTextBox.Name = "BTCExchangeRateTextBox";
            this.BTCExchangeRateTextBox.ReadOnly = true;
            this.BTCExchangeRateTextBox.Size = new System.Drawing.Size(307, 26);
            this.BTCExchangeRateTextBox.TabIndex = 39;
            this.BTCExchangeRateTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BTCExchangeRateTextBox.TextChanged += new System.EventHandler(this.BTCExchangeRateTextBox_TextChanged);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(133, 329);
            this.Label3.Margin = new System.Windows.Forms.Padding(3);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(44, 24);
            this.Label3.TabIndex = 40;
            this.Label3.Text = "Fee";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(115, 257);
            this.Label2.Margin = new System.Windows.Forms.Padding(3);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(88, 25);
            this.Label2.TabIndex = 36;
            this.Label2.Text = "USD ($)";
            // 
            // USDTextBox
            // 
            this.USDTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.USDTextBox.Location = new System.Drawing.Point(0, 288);
            this.USDTextBox.MaxLength = 15;
            this.USDTextBox.Name = "USDTextBox";
            this.USDTextBox.Size = new System.Drawing.Size(307, 26);
            this.USDTextBox.TabIndex = 37;
            this.USDTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.USDTextBox.TextChanged += new System.EventHandler(this.BTCAndUSD_TextChanged);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(130, 185);
            this.Label1.Margin = new System.Windows.Forms.Padding(3);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(54, 25);
            this.Label1.TabIndex = 33;
            this.Label1.Text = "BTC";
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ConfirmButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfirmButton.Location = new System.Drawing.Point(0, 484);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(305, 51);
            this.ConfirmButton.TabIndex = 31;
            this.ConfirmButton.Text = "Confirm";
            this.ConfirmButton.UseVisualStyleBackColor = true;
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // BTCTextBox
            // 
            this.BTCTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTCTextBox.Location = new System.Drawing.Point(0, 216);
            this.BTCTextBox.MaxLength = 10;
            this.BTCTextBox.Name = "BTCTextBox";
            this.BTCTextBox.Size = new System.Drawing.Size(307, 26);
            this.BTCTextBox.TabIndex = 35;
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
            this.ComboBox1.TabIndex = 50;
            // 
            // NewBuySell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 535);
            this.Controls.Add(this.ComboBox1);
            this.Controls.Add(this.BTCExchangerateLockCheckBox);
            this.Controls.Add(this.FeeChargedTextBox);
            this.Controls.Add(this.Label9);
            this.Controls.Add(this.Label8);
            this.Controls.Add(this.Label6);
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
        internal System.Windows.Forms.TextBox FeeChargedTextBox;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.Label Label6;
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
    }
}