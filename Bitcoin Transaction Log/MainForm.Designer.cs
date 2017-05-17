namespace Bitcoin_Transaction_Log
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.ProfitPercentTextBox = new System.Windows.Forms.TextBox();
            this.CurrPriceBTCTextBox = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.FeeAfterCheckBox = new System.Windows.Forms.CheckBox();
            this.FeeBeforeCheckBox = new System.Windows.Forms.CheckBox();
            this.BreakEvenPriceButton = new System.Windows.Forms.PictureBox();
            this.SellAllBreakEvenTextBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.minimizeToTrayButton = new System.Windows.Forms.Button();
            this.alertsButton = new System.Windows.Forms.Button();
            this.Label12 = new System.Windows.Forms.Label();
            this.SellAllNowProfitFeeTextBox = new System.Windows.Forms.TextBox();
            this.CurrencyTypeComboBox = new System.Windows.Forms.ComboBox();
            this.Label11 = new System.Windows.Forms.Label();
            this.UpdateLight = new System.Windows.Forms.PictureBox();
            this.SellAllProfitInfoButton = new System.Windows.Forms.PictureBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label10 = new System.Windows.Forms.Label();
            this.SellAllNowRevenueTextBox = new System.Windows.Forms.TextBox();
            this.Label9 = new System.Windows.Forms.Label();
            this.BitcoinPictureBox2 = new System.Windows.Forms.PictureBox();
            this.BitcoinPictureBox1 = new System.Windows.Forms.PictureBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.TotalBitcoinsTextBox = new System.Windows.Forms.TextBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.SellAllNowProfitTextBox = new System.Windows.Forms.TextBox();
            this.SellAllBTCButton = new System.Windows.Forms.PictureBox();
            this.IgnoreLossCheckBox = new System.Windows.Forms.CheckBox();
            this.NewBuyButton = new System.Windows.Forms.Button();
            this.UpdateIntervalNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.PauseButton = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.NewSellButton = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.AboutButton = new System.Windows.Forms.Button();
            this.DataGridView1 = new System.Windows.Forms.DataGridView();
            this.BuySellColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.DateTimeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BTCColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.USDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FeeChargedColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BTCExchangeRateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PercentIncreaseColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SellNowProfitColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BreakEvenPointColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DisabledColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CommentsColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpdateRateTimer = new System.Windows.Forms.Timer(this.components);
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.UpdateBitcoinValue = new System.ComponentModel.BackgroundWorker();
            this.PriceAlertTimer = new System.Windows.Forms.Timer(this.components);
            this.NotifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BreakEvenPriceButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpdateLight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SellAllProfitInfoButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BitcoinPictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BitcoinPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SellAllBTCButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpdateIntervalNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.ProfitPercentTextBox);
            this.Panel1.Controls.Add(this.CurrPriceBTCTextBox);
            this.Panel1.Controls.Add(this.label14);
            this.Panel1.Controls.Add(this.Label5);
            this.Panel1.Controls.Add(this.FeeAfterCheckBox);
            this.Panel1.Controls.Add(this.FeeBeforeCheckBox);
            this.Panel1.Controls.Add(this.BreakEvenPriceButton);
            this.Panel1.Controls.Add(this.SellAllBreakEvenTextBox);
            this.Panel1.Controls.Add(this.label13);
            this.Panel1.Controls.Add(this.minimizeToTrayButton);
            this.Panel1.Controls.Add(this.alertsButton);
            this.Panel1.Controls.Add(this.Label12);
            this.Panel1.Controls.Add(this.SellAllNowProfitFeeTextBox);
            this.Panel1.Controls.Add(this.CurrencyTypeComboBox);
            this.Panel1.Controls.Add(this.Label11);
            this.Panel1.Controls.Add(this.UpdateLight);
            this.Panel1.Controls.Add(this.SellAllProfitInfoButton);
            this.Panel1.Controls.Add(this.Label4);
            this.Panel1.Controls.Add(this.Label10);
            this.Panel1.Controls.Add(this.SellAllNowRevenueTextBox);
            this.Panel1.Controls.Add(this.Label9);
            this.Panel1.Controls.Add(this.BitcoinPictureBox2);
            this.Panel1.Controls.Add(this.BitcoinPictureBox1);
            this.Panel1.Controls.Add(this.Label7);
            this.Panel1.Controls.Add(this.TotalBitcoinsTextBox);
            this.Panel1.Controls.Add(this.Label8);
            this.Panel1.Controls.Add(this.SellAllNowProfitTextBox);
            this.Panel1.Controls.Add(this.SellAllBTCButton);
            this.Panel1.Controls.Add(this.IgnoreLossCheckBox);
            this.Panel1.Controls.Add(this.NewBuyButton);
            this.Panel1.Controls.Add(this.UpdateIntervalNumericUpDown);
            this.Panel1.Controls.Add(this.Label6);
            this.Panel1.Controls.Add(this.Label3);
            this.Panel1.Controls.Add(this.PauseButton);
            this.Panel1.Controls.Add(this.Label2);
            this.Panel1.Controls.Add(this.NewSellButton);
            this.Panel1.Controls.Add(this.Label1);
            this.Panel1.Controls.Add(this.AboutButton);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.MaximumSize = new System.Drawing.Size(0, 100);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(1361, 100);
            this.Panel1.TabIndex = 10;
            // 
            // ProfitPercentTextBox
            // 
            this.ProfitPercentTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProfitPercentTextBox.Location = new System.Drawing.Point(1131, 76);
            this.ProfitPercentTextBox.Name = "ProfitPercentTextBox";
            this.ProfitPercentTextBox.ReadOnly = true;
            this.ProfitPercentTextBox.Size = new System.Drawing.Size(191, 24);
            this.ProfitPercentTextBox.TabIndex = 61;
            this.ProfitPercentTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CurrPriceBTCTextBox
            // 
            this.CurrPriceBTCTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrPriceBTCTextBox.Location = new System.Drawing.Point(619, 42);
            this.CurrPriceBTCTextBox.MaxLength = 20;
            this.CurrPriceBTCTextBox.Name = "CurrPriceBTCTextBox";
            this.CurrPriceBTCTextBox.ReadOnly = true;
            this.CurrPriceBTCTextBox.Size = new System.Drawing.Size(163, 47);
            this.CurrPriceBTCTextBox.TabIndex = 10;
            this.CurrPriceBTCTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.CurrPriceBTCTextBox.TextChanged += new System.EventHandler(this.CurrPriceBTCTextBox_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(356, 42);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(123, 18);
            this.label14.TabIndex = 52;
            this.label14.Text = "Break-Even Price";
            this.ToolTip1.SetToolTip(this.label14, "Sell all now break-even price");
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.Location = new System.Drawing.Point(383, 0);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(119, 18);
            this.Label5.TabIndex = 59;
            this.Label5.Text = "Fee Functionality";
            this.Label5.Visible = false;
            // 
            // FeeAfterCheckBox
            // 
            this.FeeAfterCheckBox.AutoSize = true;
            this.FeeAfterCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.FeeAfterCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FeeAfterCheckBox.Location = new System.Drawing.Point(390, 44);
            this.FeeAfterCheckBox.Name = "FeeAfterCheckBox";
            this.FeeAfterCheckBox.Size = new System.Drawing.Size(112, 14);
            this.FeeAfterCheckBox.TabIndex = 60;
            this.FeeAfterCheckBox.Text = "Fee Taken After Buy USD";
            this.FeeAfterCheckBox.UseVisualStyleBackColor = true;
            this.FeeAfterCheckBox.Visible = false;
            // 
            // FeeBeforeCheckBox
            // 
            this.FeeBeforeCheckBox.AutoSize = true;
            this.FeeBeforeCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.FeeBeforeCheckBox.Checked = true;
            this.FeeBeforeCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.FeeBeforeCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FeeBeforeCheckBox.Location = new System.Drawing.Point(385, 25);
            this.FeeBeforeCheckBox.Name = "FeeBeforeCheckBox";
            this.FeeBeforeCheckBox.Size = new System.Drawing.Size(117, 14);
            this.FeeBeforeCheckBox.TabIndex = 58;
            this.FeeBeforeCheckBox.Text = "Fee Factored Into Buy USD";
            this.FeeBeforeCheckBox.UseVisualStyleBackColor = true;
            this.FeeBeforeCheckBox.Visible = false;
            // 
            // BreakEvenPriceButton
            // 
            this.BreakEvenPriceButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BreakEvenPriceButton.Location = new System.Drawing.Point(474, 63);
            this.BreakEvenPriceButton.Name = "BreakEvenPriceButton";
            this.BreakEvenPriceButton.Size = new System.Drawing.Size(30, 26);
            this.BreakEvenPriceButton.TabIndex = 57;
            this.BreakEvenPriceButton.TabStop = false;
            this.ToolTip1.SetToolTip(this.BreakEvenPriceButton, "Click to show how the revenue is computed");
            this.BreakEvenPriceButton.Click += new System.EventHandler(this.BreakEvenPriceButton_Click);
            // 
            // SellAllBreakEvenTextBox
            // 
            this.SellAllBreakEvenTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SellAllBreakEvenTextBox.Location = new System.Drawing.Point(360, 63);
            this.SellAllBreakEvenTextBox.Name = "SellAllBreakEvenTextBox";
            this.SellAllBreakEvenTextBox.ReadOnly = true;
            this.SellAllBreakEvenTextBox.Size = new System.Drawing.Size(114, 26);
            this.SellAllBreakEvenTextBox.TabIndex = 51;
            this.SellAllBreakEvenTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(347, 66);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(16, 18);
            this.label13.TabIndex = 53;
            this.label13.Text = "$";
            // 
            // minimizeToTrayButton
            // 
            this.minimizeToTrayButton.Location = new System.Drawing.Point(862, 5);
            this.minimizeToTrayButton.Name = "minimizeToTrayButton";
            this.minimizeToTrayButton.Size = new System.Drawing.Size(62, 34);
            this.minimizeToTrayButton.TabIndex = 50;
            this.minimizeToTrayButton.Text = "Minimize to Tray";
            this.ToolTip1.SetToolTip(this.minimizeToTrayButton, "Minimize program to the system tray");
            this.minimizeToTrayButton.UseVisualStyleBackColor = true;
            this.minimizeToTrayButton.Click += new System.EventHandler(this.minimizeToTrayButton_Click);
            // 
            // alertsButton
            // 
            this.alertsButton.Location = new System.Drawing.Point(930, 5);
            this.alertsButton.Name = "alertsButton";
            this.alertsButton.Size = new System.Drawing.Size(74, 34);
            this.alertsButton.TabIndex = 49;
            this.alertsButton.Text = "Price Alerts";
            this.ToolTip1.SetToolTip(this.alertsButton, "Add or remove price alerts");
            this.alertsButton.UseVisualStyleBackColor = true;
            this.alertsButton.Click += new System.EventHandler(this.alertsButton_Click);
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label12.Location = new System.Drawing.Point(241, 5);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(111, 24);
            this.Label12.TabIndex = 48;
            this.Label12.Text = "(Fees are currently priced \r\ninto buys and sells)";
            // 
            // SellAllNowProfitFeeTextBox
            // 
            this.SellAllNowProfitFeeTextBox.Location = new System.Drawing.Point(1079, 14);
            this.SellAllNowProfitFeeTextBox.MaxLength = 20;
            this.SellAllNowProfitFeeTextBox.Name = "SellAllNowProfitFeeTextBox";
            this.SellAllNowProfitFeeTextBox.Size = new System.Drawing.Size(38, 20);
            this.SellAllNowProfitFeeTextBox.TabIndex = 41;
            this.SellAllNowProfitFeeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SellAllNowProfitFeeTextBox.TextChanged += new System.EventHandler(this.ChangesWereMade);
            // 
            // CurrencyTypeComboBox
            // 
            this.CurrencyTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CurrencyTypeComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrencyTypeComboBox.FormattingEnabled = true;
            this.CurrencyTypeComboBox.Location = new System.Drawing.Point(517, 59);
            this.CurrencyTypeComboBox.Name = "CurrencyTypeComboBox";
            this.CurrencyTypeComboBox.Size = new System.Drawing.Size(59, 24);
            this.CurrencyTypeComboBox.TabIndex = 39;
            this.CurrencyTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.CurrencyTypeComboBox_SelectedIndexChanged);
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.Location = new System.Drawing.Point(523, 44);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(49, 13);
            this.Label11.TabIndex = 40;
            this.Label11.Text = "Currency";
            // 
            // UpdateLight
            // 
            this.UpdateLight.Location = new System.Drawing.Point(876, 57);
            this.UpdateLight.Name = "UpdateLight";
            this.UpdateLight.Size = new System.Drawing.Size(32, 32);
            this.UpdateLight.TabIndex = 38;
            this.UpdateLight.TabStop = false;
            // 
            // SellAllProfitInfoButton
            // 
            this.SellAllProfitInfoButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.SellAllProfitInfoButton.Location = new System.Drawing.Point(1321, 1);
            this.SellAllProfitInfoButton.Name = "SellAllProfitInfoButton";
            this.SellAllProfitInfoButton.Size = new System.Drawing.Size(30, 26);
            this.SellAllProfitInfoButton.TabIndex = 36;
            this.SellAllProfitInfoButton.TabStop = false;
            this.ToolTip1.SetToolTip(this.SellAllProfitInfoButton, "Click to show how the profit is computed");
            this.SellAllProfitInfoButton.Click += new System.EventHandler(this.SellAllProfitInfoButton_Click);
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(1119, -1);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(206, 29);
            this.Label4.TabIndex = 18;
            this.Label4.Text = "Sell All Now Profit";
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label10.Location = new System.Drawing.Point(1084, 1);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(31, 12);
            this.Label10.TabIndex = 35;
            this.Label10.Text = "Fee %";
            // 
            // SellAllNowRevenueTextBox
            // 
            this.SellAllNowRevenueTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SellAllNowRevenueTextBox.Location = new System.Drawing.Point(941, 63);
            this.SellAllNowRevenueTextBox.Name = "SellAllNowRevenueTextBox";
            this.SellAllNowRevenueTextBox.ReadOnly = true;
            this.SellAllNowRevenueTextBox.Size = new System.Drawing.Size(114, 26);
            this.SellAllNowRevenueTextBox.TabIndex = 27;
            this.SellAllNowRevenueTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label9.Location = new System.Drawing.Point(928, 66);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(16, 18);
            this.Label9.TabIndex = 33;
            this.Label9.Text = "$";
            // 
            // BitcoinPictureBox2
            // 
            this.BitcoinPictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BitcoinPictureBox2.Location = new System.Drawing.Point(187, 37);
            this.BitcoinPictureBox2.Name = "BitcoinPictureBox2";
            this.BitcoinPictureBox2.Size = new System.Drawing.Size(26, 26);
            this.BitcoinPictureBox2.TabIndex = 32;
            this.BitcoinPictureBox2.TabStop = false;
            this.ToolTip1.SetToolTip(this.BitcoinPictureBox2, "Bitcoins (BTC)");
            // 
            // BitcoinPictureBox1
            // 
            this.BitcoinPictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BitcoinPictureBox1.Location = new System.Drawing.Point(311, 37);
            this.BitcoinPictureBox1.Name = "BitcoinPictureBox1";
            this.BitcoinPictureBox1.Size = new System.Drawing.Size(26, 26);
            this.BitcoinPictureBox1.TabIndex = 31;
            this.BitcoinPictureBox1.TabStop = false;
            this.ToolTip1.SetToolTip(this.BitcoinPictureBox1, "Bitcoins (BTC)");
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label7.Location = new System.Drawing.Point(214, 42);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(98, 18);
            this.Label7.TabIndex = 25;
            this.Label7.Text = "Total Bitcoins";
            // 
            // TotalBitcoinsTextBox
            // 
            this.TotalBitcoinsTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalBitcoinsTextBox.Location = new System.Drawing.Point(187, 63);
            this.TotalBitcoinsTextBox.Name = "TotalBitcoinsTextBox";
            this.TotalBitcoinsTextBox.ReadOnly = true;
            this.TotalBitcoinsTextBox.Size = new System.Drawing.Size(151, 26);
            this.TotalBitcoinsTextBox.TabIndex = 24;
            this.TotalBitcoinsTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label8.Location = new System.Drawing.Point(927, 42);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(148, 18);
            this.Label8.TabIndex = 28;
            this.Label8.Text = "Sell All Now Revenue";
            // 
            // SellAllNowProfitTextBox
            // 
            this.SellAllNowProfitTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SellAllNowProfitTextBox.Location = new System.Drawing.Point(1131, 31);
            this.SellAllNowProfitTextBox.Name = "SellAllNowProfitTextBox";
            this.SellAllNowProfitTextBox.ReadOnly = true;
            this.SellAllNowProfitTextBox.Size = new System.Drawing.Size(191, 47);
            this.SellAllNowProfitTextBox.TabIndex = 16;
            this.SellAllNowProfitTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SellAllBTCButton
            // 
            this.SellAllBTCButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.SellAllBTCButton.Location = new System.Drawing.Point(1055, 63);
            this.SellAllBTCButton.Name = "SellAllBTCButton";
            this.SellAllBTCButton.Size = new System.Drawing.Size(30, 26);
            this.SellAllBTCButton.TabIndex = 30;
            this.SellAllBTCButton.TabStop = false;
            this.ToolTip1.SetToolTip(this.SellAllBTCButton, "Click to show how the revenue is computed");
            this.SellAllBTCButton.Click += new System.EventHandler(this.SellAllBTCButton_Click);
            // 
            // IgnoreLossCheckBox
            // 
            this.IgnoreLossCheckBox.AutoSize = true;
            this.IgnoreLossCheckBox.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.IgnoreLossCheckBox.Location = new System.Drawing.Point(1006, 0);
            this.IgnoreLossCheckBox.Name = "IgnoreLossCheckBox";
            this.IgnoreLossCheckBox.Size = new System.Drawing.Size(76, 31);
            this.IgnoreLossCheckBox.TabIndex = 26;
            this.IgnoreLossCheckBox.Text = "Ignore \"Loss\"";
            this.ToolTip1.SetToolTip(this.IgnoreLossCheckBox, "Disable \"LOSS\" transactions in calculations");
            this.IgnoreLossCheckBox.UseVisualStyleBackColor = true;
            this.IgnoreLossCheckBox.CheckedChanged += new System.EventHandler(this.ChangesWereMade);
            // 
            // NewBuyButton
            // 
            this.NewBuyButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.NewBuyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewBuyButton.Location = new System.Drawing.Point(90, 0);
            this.NewBuyButton.Margin = new System.Windows.Forms.Padding(0);
            this.NewBuyButton.Name = "NewBuyButton";
            this.NewBuyButton.Size = new System.Drawing.Size(90, 100);
            this.NewBuyButton.TabIndex = 12;
            this.NewBuyButton.Text = "New Buy";
            this.ToolTip1.SetToolTip(this.NewBuyButton, "Add a new transaction");
            this.NewBuyButton.UseVisualStyleBackColor = true;
            this.NewBuyButton.Click += new System.EventHandler(this.NewBuyButton_Click);
            // 
            // UpdateIntervalNumericUpDown
            // 
            this.UpdateIntervalNumericUpDown.Location = new System.Drawing.Point(827, 69);
            this.UpdateIntervalNumericUpDown.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.UpdateIntervalNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.UpdateIntervalNumericUpDown.Name = "UpdateIntervalNumericUpDown";
            this.UpdateIntervalNumericUpDown.Size = new System.Drawing.Size(43, 20);
            this.UpdateIntervalNumericUpDown.TabIndex = 23;
            this.UpdateIntervalNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ToolTip1.SetToolTip(this.UpdateIntervalNumericUpDown, "The current timer update interval in seconds");
            this.UpdateIntervalNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.UpdateIntervalNumericUpDown.ValueChanged += new System.EventHandler(this.UpdateIntervalNumericUpDown_ValueChanged);
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(827, 54);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(42, 13);
            this.Label6.TabIndex = 22;
            this.Label6.Text = "Interval";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(1100, 34);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(36, 39);
            this.Label3.TabIndex = 17;
            this.Label3.Text = "$";
            // 
            // PauseButton
            // 
            this.PauseButton.Image = global::Bitcoin_Transaction_Log.Properties.Resources.Pause;
            this.PauseButton.Location = new System.Drawing.Point(788, 59);
            this.PauseButton.Name = "PauseButton";
            this.PauseButton.Size = new System.Drawing.Size(30, 30);
            this.PauseButton.TabIndex = 15;
            this.ToolTip1.SetToolTip(this.PauseButton, "Pause the update timer, which includes updating the coinbase exchange rate online" +
        " and other TextBoxes");
            this.PauseButton.UseVisualStyleBackColor = true;
            this.PauseButton.Click += new System.EventHandler(this.PauseButton_Click);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(582, 45);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(36, 39);
            this.Label2.TabIndex = 14;
            this.Label2.Text = "$";
            // 
            // NewSellButton
            // 
            this.NewSellButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.NewSellButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewSellButton.Location = new System.Drawing.Point(0, 0);
            this.NewSellButton.Margin = new System.Windows.Forms.Padding(0);
            this.NewSellButton.Name = "NewSellButton";
            this.NewSellButton.Size = new System.Drawing.Size(90, 100);
            this.NewSellButton.TabIndex = 13;
            this.NewSellButton.Text = "New Sell";
            this.ToolTip1.SetToolTip(this.NewSellButton, "Add a new transaction");
            this.NewSellButton.UseVisualStyleBackColor = true;
            this.NewSellButton.Click += new System.EventHandler(this.NewSellButton_Click);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(538, 10);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(318, 29);
            this.Label1.TabIndex = 11;
            this.Label1.Text = "Current Coinbase BTC Price";
            // 
            // AboutButton
            // 
            this.AboutButton.Location = new System.Drawing.Point(179, 0);
            this.AboutButton.Name = "AboutButton";
            this.AboutButton.Size = new System.Drawing.Size(56, 29);
            this.AboutButton.TabIndex = 42;
            this.AboutButton.Text = "About";
            this.AboutButton.UseVisualStyleBackColor = true;
            this.AboutButton.Click += new System.EventHandler(this.AboutButton_Click);
            // 
            // DataGridView1
            // 
            this.DataGridView1.AllowUserToAddRows = false;
            this.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BuySellColumn,
            this.DateTimeColumn,
            this.BTCColumn,
            this.USDColumn,
            this.FeeChargedColumn,
            this.BTCExchangeRateColumn,
            this.PercentIncreaseColumn,
            this.SellNowProfitColumn1,
            this.BreakEvenPointColumn,
            this.DisabledColumn,
            this.CommentsColumn});
            this.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridView1.Location = new System.Drawing.Point(0, 100);
            this.DataGridView1.Name = "DataGridView1";
            this.DataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DataGridView1.Size = new System.Drawing.Size(1361, 783);
            this.DataGridView1.TabIndex = 11;
            this.DataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellValueChanged);
            this.DataGridView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DataGridView1_MouseDown);
            // 
            // BuySellColumn
            // 
            this.BuySellColumn.FillWeight = 80F;
            this.BuySellColumn.HeaderText = "Transaction";
            this.BuySellColumn.Items.AddRange(new object[] {
            "BUY",
            "SELL",
            "GAIN",
            "LOSS"});
            this.BuySellColumn.MaxDropDownItems = 4;
            this.BuySellColumn.Name = "BuySellColumn";
            this.BuySellColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.BuySellColumn.ToolTipText = "Type of transaction";
            // 
            // DateTimeColumn
            // 
            this.DateTimeColumn.FillWeight = 125F;
            this.DateTimeColumn.HeaderText = "Date";
            this.DateTimeColumn.Name = "DateTimeColumn";
            this.DateTimeColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DateTimeColumn.ToolTipText = "Time of transaction (optional)";
            // 
            // BTCColumn
            // 
            this.BTCColumn.HeaderText = "BTC";
            this.BTCColumn.MaxInputLength = 20;
            this.BTCColumn.Name = "BTCColumn";
            this.BTCColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.BTCColumn.ToolTipText = "Bitcoins spent or gained";
            // 
            // USDColumn
            // 
            this.USDColumn.HeaderText = "USD";
            this.USDColumn.MaxInputLength = 20;
            this.USDColumn.Name = "USDColumn";
            this.USDColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.USDColumn.ToolTipText = "Dollars spent or gained";
            // 
            // FeeChargedColumn
            // 
            this.FeeChargedColumn.HeaderText = "Fee % (Buy+Sell)";
            this.FeeChargedColumn.MaxInputLength = 20;
            this.FeeChargedColumn.Name = "FeeChargedColumn";
            this.FeeChargedColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FeeChargedColumn.ToolTipText = "The fee incurred (percentage on buys and sells)";
            // 
            // BTCExchangeRateColumn
            // 
            this.BTCExchangeRateColumn.HeaderText = "BTC Exchange Rate";
            this.BTCExchangeRateColumn.MaxInputLength = 20;
            this.BTCExchangeRateColumn.Name = "BTCExchangeRateColumn";
            this.BTCExchangeRateColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.BTCExchangeRateColumn.ToolTipText = "The BTC exchange rate at the time of buy/sell etc.";
            // 
            // PercentIncreaseColumn
            // 
            this.PercentIncreaseColumn.HeaderText = "USD % Increase";
            this.PercentIncreaseColumn.MaxInputLength = 20;
            this.PercentIncreaseColumn.Name = "PercentIncreaseColumn";
            this.PercentIncreaseColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PercentIncreaseColumn.ToolTipText = "Includes the percent sell fee if defined.";
            // 
            // SellNowProfitColumn1
            // 
            this.SellNowProfitColumn1.FillWeight = 125F;
            this.SellNowProfitColumn1.HeaderText = "Sell This Now Profit ($)";
            this.SellNowProfitColumn1.MaxInputLength = 25;
            this.SellNowProfitColumn1.Name = "SellNowProfitColumn1";
            this.SellNowProfitColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SellNowProfitColumn1.ToolTipText = "Sell this rows bitcoin\'s at the current exchange rate minus the price it was boug" +
    "ht at.";
            // 
            // BreakEvenPointColumn
            // 
            this.BreakEvenPointColumn.FillWeight = 75F;
            this.BreakEvenPointColumn.HeaderText = "Break-Even Point";
            this.BreakEvenPointColumn.MaxInputLength = 20;
            this.BreakEvenPointColumn.Name = "BreakEvenPointColumn";
            this.BreakEvenPointColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.BreakEvenPointColumn.ToolTipText = "Price at which you can sell and lose no money, even after any defined fees.";
            // 
            // DisabledColumn
            // 
            this.DisabledColumn.FillWeight = 75F;
            this.DisabledColumn.HeaderText = "Disabled";
            this.DisabledColumn.Name = "DisabledColumn";
            this.DisabledColumn.ToolTipText = "Disable this row from being considered AT ALL.";
            // 
            // CommentsColumn
            // 
            this.CommentsColumn.FillWeight = 300F;
            this.CommentsColumn.HeaderText = "Comments";
            this.CommentsColumn.Name = "CommentsColumn";
            this.CommentsColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CommentsColumn.ToolTipText = "Optional area to describe this transaction.";
            // 
            // UpdateRateTimer
            // 
            this.UpdateRateTimer.Interval = 10000;
            this.UpdateRateTimer.Tick += new System.EventHandler(this.UpdateRateTimer_Tick);
            // 
            // ToolTip1
            // 
            this.ToolTip1.AutoPopDelay = 30000;
            this.ToolTip1.InitialDelay = 500;
            this.ToolTip1.ReshowDelay = 100;
            // 
            // UpdateBitcoinValue
            // 
            this.UpdateBitcoinValue.WorkerSupportsCancellation = true;
            this.UpdateBitcoinValue.DoWork += new System.ComponentModel.DoWorkEventHandler(this.UpdateBitcoinValue_DoWork);
            this.UpdateBitcoinValue.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.UpdateBitcoinValue_RunWorkerCompleted);
            // 
            // PriceAlertTimer
            // 
            this.PriceAlertTimer.Interval = 1000;
            this.PriceAlertTimer.Tick += new System.EventHandler(this.PriceAlertTimer_Tick);
            // 
            // NotifyIcon1
            // 
            this.NotifyIcon1.Text = "Bitcoin Transaction Logs";
            this.NotifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon1_MouseClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1361, 883);
            this.Controls.Add(this.DataGridView1);
            this.Controls.Add(this.Panel1);
            this.MinimumSize = new System.Drawing.Size(1369, 215);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bitcoin Transaction Log";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BreakEvenPriceButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpdateLight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SellAllProfitInfoButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BitcoinPictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BitcoinPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SellAllBTCButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpdateIntervalNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Label Label12;
        internal System.Windows.Forms.TextBox SellAllNowProfitFeeTextBox;
        internal System.Windows.Forms.Label Label11;
        internal System.Windows.Forms.PictureBox UpdateLight;
        internal System.Windows.Forms.PictureBox SellAllProfitInfoButton;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label10;
        internal System.Windows.Forms.TextBox SellAllNowRevenueTextBox;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.PictureBox BitcoinPictureBox2;
        internal System.Windows.Forms.PictureBox BitcoinPictureBox1;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.TextBox TotalBitcoinsTextBox;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.TextBox SellAllNowProfitTextBox;
        internal System.Windows.Forms.PictureBox SellAllBTCButton;
        internal System.Windows.Forms.CheckBox IgnoreLossCheckBox;
        internal System.Windows.Forms.Button NewBuyButton;
        internal System.Windows.Forms.NumericUpDown UpdateIntervalNumericUpDown;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Button PauseButton;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Button NewSellButton;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox CurrPriceBTCTextBox;
        internal System.Windows.Forms.Button AboutButton;
        internal System.Windows.Forms.DataGridView DataGridView1;
        internal System.Windows.Forms.Timer UpdateRateTimer;
        internal System.Windows.Forms.ToolTip ToolTip1;
        internal System.ComponentModel.BackgroundWorker UpdateBitcoinValue;
        internal System.Windows.Forms.ComboBox CurrencyTypeComboBox;
        public System.Windows.Forms.Timer PriceAlertTimer;
        internal System.Windows.Forms.Button alertsButton;
        internal System.Windows.Forms.Button minimizeToTrayButton;
        internal System.Windows.Forms.NotifyIcon NotifyIcon1;
        internal System.Windows.Forms.TextBox SellAllBreakEvenTextBox;
        internal System.Windows.Forms.Label label13;
        internal System.Windows.Forms.Label label14;
        internal System.Windows.Forms.PictureBox BreakEvenPriceButton;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.CheckBox FeeAfterCheckBox;
        internal System.Windows.Forms.CheckBox FeeBeforeCheckBox;
        private System.Windows.Forms.DataGridViewComboBoxColumn BuySellColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateTimeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn BTCColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn USDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn FeeChargedColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn BTCExchangeRateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PercentIncreaseColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SellNowProfitColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn BreakEvenPointColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DisabledColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CommentsColumn;
        internal System.Windows.Forms.TextBox ProfitPercentTextBox;
    }
}