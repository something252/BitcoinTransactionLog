using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Bitcoin_Transaction_Log.Methods1;

namespace Bitcoin_Transaction_Log
{
    public partial class MainForm : Form
    {
        bool Loading = true;
        //public LockThreadExec As new Object
        private object LockUpdates = new object();

        const string UpdatingInProgressStr = "Bitcoin price updating is in progress.";
        const string UpdatingPausedStr = "Bitcoin price updating is paused.";
        const string UpdatingStoppedStr = "Bitcoin price updating is not in progress.";
        delegate void UpdateLightTooltip_Delegate(Control control, string caption);

        static MainForm mainForm;
        static List<NewBuySell> newBuySell = new List<NewBuySell>();
        static Alerts alerts;

        public MainForm()
        {
            InitializeComponent();
            mainForm = this;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Icon = Properties.Resources.icon50;
            SellAllBTCButton.BackgroundImage = Properties.Resources.Simple_Information;
            SellAllProfitInfoButton.BackgroundImage = Properties.Resources.Simple_Information;
            BitcoinPictureBox1.BackgroundImage = Properties.Resources.bitcoin2;
            BitcoinPictureBox2.BackgroundImage = Properties.Resources.bitcoin2;

            if (Properties.Settings.Default.MainFormSize != null) {
                if (Properties.Settings.Default.MainFormSize.Height != 0 && Properties.Settings.Default.MainFormSize.Width != 0) {
                    this.Size = Properties.Settings.Default.MainFormSize;
                    this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width / 2) - (this.Width / 2), (Screen.PrimaryScreen.WorkingArea.Height / 2) - (this.Height / 2));
                }
            }

            if (IsNumeric(Properties.Settings.Default.SellAllNowProfitFee)) {
                SellAllNowProfitFeeTextBox.Text = Convert.ToString(Properties.Settings.Default.SellAllNowProfitFee);
            } else {
                SellAllNowProfitFeeTextBox.Text = "0";
            }

            if (!string.IsNullOrEmpty(Properties.Settings.Default.MoneyType)) {
                int index = CurrencyTypeComboBox.Items.Add(Properties.Settings.Default.MoneyType);
                CurrencyTypeComboBox.SelectedIndex = index;
                ChangeColumnLabelCurrency(CurrencyTypeComboBox.Text, "USD");
            } else {
                int index = CurrencyTypeComboBox.Items.Add("USD");
                CurrencyTypeComboBox.SelectedIndex = index;
            }

            if (Properties.Settings.Default.DataGridSettings != null) {
                for (int i = 0; i < Properties.Settings.Default.DataGridSettings.Count; i++) {
                    string[] rowValues = Properties.Settings.Default.DataGridSettings[i].Split(new[] { "<**>" }, StringSplitOptions.None);
                    DataGridView1.Rows.Add();
                    try {
                        DataGridView1[0, i].Value = Convert.ToString(rowValues[0]);
                        DataGridView1[1, i].Value = Convert.ToString(rowValues[1]);
                        DataGridView1[2, i].Value = Convert.ToString(rowValues[2]);
                        DataGridView1[3, i].Value = Convert.ToString(rowValues[3]);
                        DataGridView1[4, i].Value = Convert.ToString(rowValues[4]);
                        DataGridView1[5, i].Value = Convert.ToString(rowValues[5]);
                        DataGridView1[6, i].Value = Convert.ToString(rowValues[6]);
                        DataGridView1[7, i].Value = Convert.ToString(rowValues[7]);

                        if (string.IsNullOrEmpty(rowValues[8]))
                            DataGridView1[9, i].Value = false;
                        else
                            DataGridView1[9, i].Value = Convert.ToBoolean(rowValues[8]);

                        DataGridView1[10, i].Value = Convert.ToString(rowValues[9]);
                        DataGridView1[8, i].Value = Convert.ToString(rowValues[10]);
                    } catch (Exception ex) {
                        //MessageBox.Show("A row's column could not be loaded")
                        MessageBox.Show(ex.Message);
                        throw;
                    }
                }
            }

            IgnoreLossCheckBox.Checked = Properties.Settings.Default.IgnoreLoss;

            if (IsNumeric(Properties.Settings.Default.UpdateInterval)) {
                UpdateIntervalNumericUpDown.Value = Properties.Settings.Default.UpdateInterval;
            } else { // default value
                UpdateIntervalNumericUpDown.Value = 1;
            }

            if (Properties.Settings.Default.DataGridColumnWidths != null) {
                string[] temp = Properties.Settings.Default.DataGridColumnWidths.Split(new[] { "<**>" }, StringSplitOptions.None);
                for (int i = 0; i < temp.Length; i++) {
                    if (DataGridView1.Columns.Count >= i) {
                        if (IsNumeric(temp[i])) {
                            DataGridView1.Columns[i].Width = Convert.ToInt32(temp[i]);
                        }
                    }
                }
            }

            ToolTip1.SetToolTip(PauseButton, pauseTooltip);

            UpdateRateTimer.Interval = Convert.ToInt32(UpdateIntervalNumericUpDown.Value) * 1000;
            UpdateRateTimer.Start();
            UpdateRateTimer_Tick(sender, e);

            StartAlertsTimer();

            this.ActiveControl = Label1; // focus nothing
            Loading = false; // loading is finished flag
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            lock (LockUpdates) {
                if (this.WindowState == FormWindowState.Minimized) {
                    if (!this.Visible) {
                        this.Visible = true;
                    }
                    this.Opacity = 0.0;
                    this.WindowState = FormWindowState.Normal;
                }

                // save all DataGridView rows
                if (Properties.Settings.Default.DataGridSettings != null) {
                    Properties.Settings.Default.DataGridSettings.Clear();
                }
                if (Properties.Settings.Default.DataGridSettings == null) {
                    Properties.Settings.Default.DataGridSettings = new System.Collections.Specialized.StringCollection();
                }
                for (int i = 0; i <= DataGridView1.Rows.Count - 1; i++) {
                    string newStr = DataGridView1[0, i].Value + "<**>" + DataGridView1[1, i].Value + "<**>" + DataGridView1[2, i].Value + "<**>" + DataGridView1[3, i].Value
            + "<**>" + DataGridView1[4, i].Value + "<**>" + DataGridView1[5, i].Value + "<**>" + DataGridView1[6, i].Value + "<**>" + DataGridView1[7, i].Value
            + "<**>" + Convert.ToString(DataGridView1[9, i].Value) + "<**>" + Convert.ToString(DataGridView1[10, i].Value) + "<**>" + Convert.ToString(DataGridView1[8, i].Value);
                    Properties.Settings.Default.DataGridSettings.Add(newStr);
                }

                if (IsNumeric(SellAllNowProfitFeeTextBox.Text)) {
                    Properties.Settings.Default.SellAllNowProfitFee = Convert.ToDouble(SellAllNowProfitFeeTextBox.Text);
                } else if (string.IsNullOrEmpty(SellAllNowProfitFeeTextBox.Text)) {
                    Properties.Settings.Default.SellAllNowProfitFee = 0;
                }
                Properties.Settings.Default.MoneyType = CurrencyTypeComboBox.Text;
                Properties.Settings.Default.IgnoreLoss = IgnoreLossCheckBox.Checked;
                Properties.Settings.Default.UpdateInterval = Convert.ToInt32(UpdateIntervalNumericUpDown.Value);
                Properties.Settings.Default.MainFormSize = this.Size;

                string ConstructWidthStr = Convert.ToString(DataGridView1.Columns[0].Width);
                for (int i = 1; i <= DataGridView1.Columns.Count - 1; i++) {
                    ConstructWidthStr += "<**>";
                    ConstructWidthStr += Convert.ToString(DataGridView1.Columns[i].Width);
                }
                Properties.Settings.Default.DataGridColumnWidths = ConstructWidthStr;

                Properties.Settings.Default.Save();
            }
        }

        /// <summary>
        /// new buy transaction.
        /// </summary>
        private void NewBuyButton_Click(object sender, EventArgs e)
        {
            OpenNewNewBuySell(0, "New Sell");
        }

        /// <summary>
        /// Open a new NewBuySell form.
        /// </summary>
        private void NewSellButton_Click(object sender, EventArgs e)
        {
            OpenNewNewBuySell(1, "New Buy");
        }

        /// <summary>
        /// Open a new NewBuySell form.
        /// </summary>
        private void OpenNewNewBuySell(int index, string text)
        {
            NewBuySell newForm = new NewBuySell(mainForm);
            newBuySell.Add(newForm);
            newForm.Show();
            newForm.ComboBox1.SelectedIndex = index;
            newForm.Text = text;
        }

        bool PerformOnce1 = true;
        /// <summary>
        /// Main updating thread work.
        /// </summary>
        private void UpdateBitcoinExchangeValue()
        {
            if (!UpdateBitcoinValue.CancellationPending) {
                UpdateLightTooltip_Delegate d1 = new UpdateLightTooltip_Delegate(ToolTip1.SetToolTip);
                this.Invoke(d1, new object[] { UpdateLight, UpdatingInProgressStr });
                UpdateLight.Image = Properties.Resources.green_light32;

                try {
                    if (!Timer1Paused) {
                        WebRequest wrGETURL;
                        wrGETURL = WebRequest.Create("https://api.coinbase.com/v2/exchange-rates?currency=BTC");
                        wrGETURL.Timeout = 750;
                        wrGETURL.Method = "GET";

                        Stream objStream;
                        objStream = wrGETURL.GetResponse().GetResponseStream();
                        StreamReader reader = new StreamReader(objStream);
                        string responseFromServer = reader.ReadToEnd();
                        objStream.Close();

                        JObject ser = JObject.Parse(responseFromServer);
                        List<JToken> data = ser.Children().ToList();

                        if (PerformOnce1) {
                            foreach (JProperty item in data) {
                                item.CreateReader();
                                switch (item.Name) {
                                    case "data":
                                        foreach (JProperty data2 in item.Value) {
                                            if (data2.Name == "rates") {
                                                foreach (JProperty data3 in data2.Value) {
                                                    ComboBoxItemsAdd("CurrencyTypeComboBox", data3.Name); //CurrencyTypeComboBox.Items.Add(data3.Name)
                                                }
                                                break;
                                            }
                                        }
                                        break;
                                }
                            }
                            PerformOnce1 = false;
                        }

                        foreach (JProperty item in data) {
                            item.CreateReader();
                            switch (item.Name) {
                                case "data":
                                    foreach (JProperty data2 in item.Value) {
                                        if (data2.Name == "rates") {
                                            foreach (JProperty data3 in data2.Value) {
                                                if (data3.Name == CurrentMoneyType) {
                                                    SetText("CurrPriceBTCTextBox", Convert.ToString(data3.Value)); // CurrPriceBTCTextBox.Text = data3.Value
                                                    break;
                                                }
                                            }
                                            break;
                                        }
                                    }
                                    break;
                            }
                        }
                    }

                    PerformUpdates();

                } catch /*(System.Net.WebException ex1)*/ {
                    //if (ex1.Status == 14) { // Timeout
                    //MessageBox.Show("System.Net.WebException" + Environment.NewLine + ex1.Message);
                    //}
                    /*} catch (Exception ex) {
                        //MessageBox.Show("System.Net.WebException" + Environment.NewLine + ex.Message);*/
                } finally {
                    try {
                        if (!UpdateBitcoinValue.CancellationPending) {
                            UpdateLightTooltip_Delegate d2 = new UpdateLightTooltip_Delegate(ToolTip1.SetToolTip);
                            this.Invoke(d2, new object[] { UpdateLight, UpdatingStoppedStr });
                            UpdateLight.Image = Properties.Resources.red_light32;
                        }
                    } catch { }
                }
            }
        }

        delegate void SetText_Callback(string TextBoxRef, string text);
        /// <summary>
        /// Set a TextBox control's Text property from within a thread.
        /// </summary>
        private void SetText(string TextBoxRef, string text)
        {
            object[] Control1 = this.Controls.Find(TextBoxRef, true);
            TextBox tb = (TextBox)Control1[0];
            if (tb.InvokeRequired) {
                SetText_Callback d = new SetText_Callback(SetText);
                this.Invoke(d, new object[] { TextBoxRef, text });
            } else {
                tb.Text = text;
            }
        }

        public delegate void ComboBoxItemsAdd_Callback(string ComboBoxRef, string text);
        /// <summary>
        /// Add a ComboBox Item from within a thread.
        /// </summary>
        private void ComboBoxItemsAdd(string ComboBoxRef, string text)
        {
            object[] Control1 = this.Controls.Find(ComboBoxRef, true);
            ComboBox tb = (ComboBox)Control1[0];
            if (tb.InvokeRequired) {
                ComboBoxItemsAdd_Callback d = new ComboBoxItemsAdd_Callback(ComboBoxItemsAdd);
                this.Invoke(d, new object[] { ComboBoxRef, text });
            } else {
                if (text != tb.Text && text != "BTC") { // user money type is added on load
                    tb.Items.Add(text);
                }
            }
        }

        /// <summary>
        /// Perform updates on displays
        /// </summary>
        public void PerformUpdates()
        {
            UpdateTotalBitcoins(); // update total bitcoins display
            UpdateRowSpecificProfit(); // update each row's potential profit if sold at current Bitcoin price
            UpdateRowSpecificBreakEvenPoint(); // update each row's break-even Bitcoin price
            UpdateSellNowRevenue(); // update total potential revenue display

            decimal TotalBTC = 0m;
            decimal BuyUSD = 0m;
            decimal SellUSD = 0m;
            bool success = false;
            try {
                ComputeTotalBTCandUSD(ref TotalBTC, ref BuyUSD, ref SellUSD);
                success = true;
            } catch {
                SetText("SellAllNowProfitTextBox", "--");
                SetText("SellAllBreakEvenTextBox", "--");
            }
            if (success) {
                UpdateTotalPossibleProfit(ref TotalBTC, ref BuyUSD, ref SellUSD); // update total potential profit display
                UpdateBreakEven(ref TotalBTC, ref BuyUSD, ref SellUSD); // update break-even price display
            }
        }

        /// <summary>
        /// Updates each BUY/GAIN transcation's row specific profit if sold at the current Bitcoin price.
        /// </summary>
        public void UpdateRowSpecificProfit()
        {
            lock (LockUpdates) {
                for (int i = 0; i <= DataGridView1.Rows.Count - 1; i++) {
                    string transactionType = Convert.ToString(DataGridView1[0, i].Value);
                    if (IsNumeric(DataGridView1[5, i].Value) && IsNumeric(DataGridView1[2, i].Value) && IsNumeric(DataGridView1[3, i].Value) && IsNumeric(CurrPriceBTCTextBox.Text) &&
                        (transactionType == "BUY" || transactionType == "GAIN")) {

                        if (Convert.ToDecimal(CurrPriceBTCTextBox.Text) == 0m) { // equals 0
                            DataGridView1[6, i].Value = "-100 %"; // percent change
                            DataGridView1[7, i].Value = -Convert.ToDecimal(DataGridView1[3, i].Value);  // profit
                        } else {
                            decimal Fee = 0m;
                            if (IsNumeric(DataGridView1[4, i].Value)) {
                                Fee = Convert.ToDecimal(DataGridView1[4, i].Value);
                            }

                            decimal BTC = Convert.ToDecimal(DataGridView1[2, i].Value);
                            decimal USD = Convert.ToDecimal(DataGridView1[3, i].Value);

                            try {
                                decimal Gross = ((BTC * Convert.ToDecimal(CurrPriceBTCTextBox.Text)) * (1m - (Fee / 100m)));
                                decimal Profit = Gross - USD;

                                try {
                                    decimal PercentChange = Profit / USD;
                                    DataGridView1[6, i].Value = Math.Round(PercentChange * 100m, 4) + " %";
                                } catch {
                                    DataGridView1[6, i].Value = "--";
                                }
                                try {
                                    DataGridView1[7, i].Value = Math.Round(Profit, 2);
                                } catch {
                                    DataGridView1[7, i].Value = "--";
                                }
                            } catch {
                                DataGridView1[6, i].Value = "--";
                                DataGridView1[7, i].Value = "--";
                            }
                        }
                    } else {
                        DataGridView1[6, i].Value = "--";
                        DataGridView1[7, i].Value = "--";
                    }
                }
            }
        }

        /// <summary>
        /// Updates each BUY transcation's row specific break-even point for selling. (Reliant on that row's fee)
        /// </summary>
        private void UpdateRowSpecificBreakEvenPoint()
        {
            lock (LockUpdates) {
                for (int i = 0; i <= DataGridView1.Rows.Count - 1; i++) {
                    string transactionType = Convert.ToString(DataGridView1[0, i].Value);
                    if (transactionType == "BUY" && IsNumeric(DataGridView1[2, i].Value) && IsNumeric(DataGridView1[3, i].Value)) {
                        decimal FeePercent = 0m;
                        if (IsNumeric(DataGridView1[4, i].Value)) {
                            FeePercent = Convert.ToDecimal(DataGridView1[4, i].Value);
                        }
                        try {
                            DataGridView1[8, i].Value = Math.Round((100m * Convert.ToDecimal(DataGridView1[3, i].Value)) / ((100m - FeePercent) * Convert.ToDecimal(DataGridView1[2, i].Value)), 4);
                        } catch {
                            DataGridView1[8, i].Value = "--";
                        }
                    } else {
                        DataGridView1[8, i].Value = "--";
                    }
                }
            }
        }

        /// <summary>
        /// Revenue info (show your work) button.
        /// </summary>
        private void SellAllBTCButton_Click(object sender, EventArgs e)
        {
            decimal TotalBTC = 0m;
            decimal CurrPriceBTC = 0m;
            decimal Fee = 0m;
            string SellAllNowProfitFee = "0";
            decimal temp = 0m;

            try {
                lock (LockUpdates) {
                    ComputeTotalBTCandUSD(ref TotalBTC);

                    if (TotalBTC > 0) {
                        if (IsNumeric(SellAllNowProfitFeeTextBox.Text)) {
                            Fee = Convert.ToDecimal(SellAllNowProfitFeeTextBox.Text) / 100m;
                            SellAllNowProfitFee = SellAllNowProfitFeeTextBox.Text;
                        }
                        if (IsNumeric(CurrPriceBTCTextBox.Text)) {
                            CurrPriceBTC = Convert.ToDecimal(CurrPriceBTCTextBox.Text);
                        }
                        temp = TotalBTC * CurrPriceBTC;
                    }
                }

                if (TotalBTC > 0) {
                    MessageBox.Show(TotalBTC + "BTC * $" + CurrPriceBTC + " - $" + Convert.ToString(temp * Fee) + " = $" + Convert.ToString(temp - (temp * Fee)) + Environment.NewLine + Environment.NewLine +
                    "Total BTC * Current BTC Price - " + (temp * Fee) + " (" + SellAllNowProfitFee + "% Fee) = Total Revenue");
                } else if (TotalBTC < 0) {
                    MessageBox.Show("Total Bitcoins is less than zero: " + TotalBTC);
                } else if (TotalBTC == 0) {
                    MessageBox.Show("Total bitcoins = 0");
                }
            } catch {
                MessageBox.Show("Unable to calculate.");
            }
        }

        /// <summary>
        /// Updates "sell all now revenue" TextBox.
        /// </summary>
        public void UpdateSellNowRevenue()
        {
            lock (LockUpdates) {
                try {
                    if (Convert.ToDecimal(TotalBitcoinsTextBox.Text) > 0m && IsNumeric(CurrPriceBTCTextBox.Text)) {
                        decimal temp = Convert.ToDecimal(TotalBitcoinsTextBox.Text) * Convert.ToDecimal(CurrPriceBTCTextBox.Text);
                        decimal Fee = 0m;
                        if (IsNumeric(SellAllNowProfitFeeTextBox.Text)) {
                            Fee = Convert.ToDecimal(SellAllNowProfitFeeTextBox.Text) / 100m;
                        }
                        SetText("SellAllNowRevenueTextBox", Convert.ToString(Math.Round(temp - (temp * Fee), 2)));
                    } else {
                        SetText("SellAllNowRevenueTextBox", "0");
                    }
                } catch {
                    SetText("SellAllNowRevenueTextBox", "--");
                }
            }
        }

        /// <summary>
        /// Updates the sell all break-even TextBox.
        /// </summary>
        public void UpdateBreakEven(ref decimal TotalBTC, ref decimal BuyUSD, ref decimal SellUSD)
        {
            lock (LockUpdates) {
                if (TotalBTC > 0m) {
                    try {
                        decimal averageCost = Math.Abs(SellUSD - BuyUSD) / (TotalBTC);
                        decimal fee = 0m;
                        if (IsNumeric(SellAllNowProfitFeeTextBox.Text)) {
                            fee = 1 - (Convert.ToDecimal(SellAllNowProfitFeeTextBox.Text) / 100m);
                        }

                        if (fee != 0m)
                            SetText("SellAllBreakEvenTextBox", Convert.ToString(Math.Round(averageCost / fee, 2)));
                        else
                            SetText("SellAllBreakEvenTextBox", Convert.ToString(Math.Round(averageCost, 2)));
                    } catch {
                        SetText("SellAllBreakEvenTextBox", "--");
                    }
                } else {
                    SetText("SellAllBreakEvenTextBox", "--");
                }
            }
        }

        /// <summary>
        /// Update total sell now profit TextBox.
        /// </summary>
        public void UpdateTotalPossibleProfit(ref decimal TotalBTC, ref decimal BuyUSD, ref decimal SellUSD)
        {
            lock (LockUpdates) {
                if (DataGridView1.Rows.Count > 0) {
                    try {
                        if (!IsNumeric(CurrPriceBTCTextBox.Text)) {
                            SetText("SellAllNowProfitTextBox", "0");
                        } else {
                            // add total profit columns together
                            decimal Fee = 1m;
                            if (IsNumeric(SellAllNowProfitFeeTextBox.Text)) {
                                Fee = (1 - Convert.ToDecimal(SellAllNowProfitFeeTextBox.Text) / 100);
                            }
                            SetText("SellAllNowProfitTextBox", Convert.ToString(Math.Round(((TotalBTC * Convert.ToDecimal(CurrPriceBTCTextBox.Text)) * Fee) + (SellUSD - BuyUSD), 2)));
                        }
                    } catch {
                        SetText("SellAllNowProfitTextBox", "--");
                    }
                } else {
                    SetText("SellAllNowProfitTextBox", "0");
                }
            }
        }

        /// <summary>
        /// Profit info (show your work) button.
        /// </summary>
        private void SellAllProfitInfoButton_Click(object sender, EventArgs e)
        {
            decimal TotalBTC = 0m;
            decimal BuyUSD = 0m;
            decimal SellUSD = 0m;
            decimal CurrPriceBTC = 0m;
            decimal Fee = 1m;

            if (DataGridView1.Rows.Count > 0) {
                try {
                    lock (LockUpdates) {
                        ComputeTotalBTCandUSD(ref TotalBTC, ref BuyUSD, ref SellUSD);
                        if (IsNumeric(CurrPriceBTCTextBox.Text)) {
                            CurrPriceBTC = Convert.ToDecimal(CurrPriceBTCTextBox.Text);
                        }
                        if (IsNumeric(SellAllNowProfitFeeTextBox.Text)) {
                            Fee = 1m - (Convert.ToDecimal(SellAllNowProfitFeeTextBox.Text) / 100m);
                        }
                    }
                    MessageBox.Show("[ ( " + TotalBTC + " BTC * $" + CurrPriceBTC + " ) * " + Fee + " ] + ( $" + SellUSD + " - $" + BuyUSD + " ) = $" +
                            Math.Round(((TotalBTC * CurrPriceBTC) * Fee) + (SellUSD - BuyUSD), 2) + Environment.NewLine + Environment.NewLine +
                            "[ ( Total BTC * Current BTC price ) * (Fee multiplier) ] + ( Sell USD - Buy USD ) = Total Profit");
                } catch {
                    MessageBox.Show("Unable to calculate.");
                }
            } else {
                MessageBox.Show("0");
            }
        }

        private void ComputeTotalBTCandUSD(ref decimal TotalBTC)
        {
            decimal BuyUSD = 0m;
            decimal SellUSD = 0m;
            ComputeTotalBTCandUSD(ref TotalBTC, ref BuyUSD, ref SellUSD);
        }
        /// <summary>
        /// Computes the total bitcoins and total buy and sell money.
        /// </summary>
        private void ComputeTotalBTCandUSD(ref decimal TotalBTC, ref decimal BuyUSD, ref decimal SellUSD)
        {
            for (int i = 0; i <= DataGridView1.Rows.Count - 1; i++) {
                if (!Convert.ToBoolean(DataGridView1[9, i].Value)) {

                    string transactionType = Convert.ToString(DataGridView1[0, i].Value);
                    decimal BTC = Convert.ToDecimal(SanitizeNumber(DataGridView1[2, i].Value));
                    decimal USD = Convert.ToDecimal(SanitizeNumber(DataGridView1[3, i].Value));
                    if (transactionType == "BUY") {
                        TotalBTC += BTC;
                        BuyUSD += USD;
                    } else if (transactionType == "SELL") {
                        TotalBTC -= BTC;
                        SellUSD += USD;
                    } else if (transactionType == "LOSS") {
                        // loss of BTC and/or USD
                        if (!IgnoreLossCheckBox.Checked)
                            if (BTC >= 0m)
                                TotalBTC -= BTC;
                            else
                                TotalBTC += BTC;
                    } else if (transactionType == "GAIN") {
                        // gain of BTC and/or USD
                        TotalBTC += BTC;
                    }
                }
            }
        }

        /// <summary>
        /// Update total Bitcoins TextBox
        /// </summary>
        public void UpdateTotalBitcoins()
        {
            lock (LockUpdates) {
                decimal TotalBTC = 0m;
                for (int i = 0; i <= DataGridView1.Rows.Count - 1; i++) {
                    if (!Convert.ToBoolean(DataGridView1[9, i].Value)) {

                        string transactionType = Convert.ToString(DataGridView1[0, i].Value);
                        decimal value = Convert.ToDecimal(SanitizeNumber(DataGridView1[2, i].Value));
                        if (transactionType == "BUY") {
                            TotalBTC += value;
                        } else if (transactionType == "SELL") {
                            TotalBTC -= value;
                        } else if (transactionType == "LOSS") {
                            // loss of BTC and/or USD
                            if (!IgnoreLossCheckBox.Checked) {
                                bool BTC_IsNullOrEmpty = string.IsNullOrEmpty(Convert.ToString(DataGridView1[2, i].Value));
                                if (!BTC_IsNullOrEmpty) {
                                    if (value >= 0m) {
                                        TotalBTC -= value;
                                    } else {
                                        TotalBTC += value;
                                    }
                                }
                            }
                        } else if (transactionType == "GAIN") {
                            // gain of BTC and/or USD
                            bool BTC_IsNullOrEmpty = string.IsNullOrEmpty(Convert.ToString(DataGridView1[2, i].Value));
                            if (!BTC_IsNullOrEmpty) {
                                TotalBTC += value;
                            }
                        }
                    }
                }

                SetText("TotalBitcoinsTextBox", Convert.ToString(TotalBTC));
            }
        }

        /// <summary>
        /// Update Bitcoin exchange price timer tick.
        /// </summary>
        private void UpdateRateTimer_Tick(object sender, EventArgs e)
        {
            UpdateRateTimer.Stop(); // timer is restarted when work is complete in thread
            if (UpdateBitcoinValue.IsBusy != true) {
                UpdateBitcoinValue.RunWorkerAsync();
            }
        }

        private void UpdateBitcoinValue_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!Timer1Paused) {
                UpdateRateTimer.Start(); // restart the update Bitcoin rate timer now that work is complete
            }
        }

        private void UpdateBitcoinValue_DoWork(object sender, DoWorkEventArgs e)
        {
            UpdateBitcoinExchangeValue(); // perform Bitcoin price updating work and other updates
        }

        string pauseTooltip = "Pause the updating of the exchange rates, price alerts, and other info.";
        string playTooltip = "Resume the updating of the exchange rates, price alerts, and other info.";
        bool Timer1Paused = false;
        /// <summary>
        /// Pause the periodic updating of the Bitcoin price and other data.
        /// </summary>
        private void PauseButton_Click(object sender, EventArgs e)
        {
            if (Timer1Paused) {
                Timer1Paused = false;
                UpdateRateTimer.Interval = Convert.ToInt32(UpdateIntervalNumericUpDown.Value) * 1000;
                UpdateRateTimer_Tick(sender, e);
                UpdateRateTimer.Start();
                StartAlertsTimer();
                CurrPriceBTCTextBox.ReadOnly = true;
                ToolTip1.SetToolTip(PauseButton, pauseTooltip);
                PauseButton.Image = Properties.Resources.Pause;
            } else {
                Timer1Paused = true;
                UpdateBitcoinValue.CancelAsync();
                UpdateRateTimer.Stop();
                ToolTip1.SetToolTip(UpdateLight, UpdatingPausedStr);
                UpdateLight.Image = Properties.Resources.yellow_light32;
                CurrPriceBTCTextBox.ReadOnly = false;
                ToolTip1.SetToolTip(PauseButton, playTooltip);
                PauseButton.Image = Properties.Resources.Play;
            }
        }

        /// <summary>
        /// Change the Currencies used in column labels. (USD is default)
        /// </summary>
        private void ChangeColumnLabelCurrency(string NewMoneyType, string OldMoneyType)
        {
            CurrentMoneyType = NewMoneyType;
            DataGridView1.Columns[3].HeaderText = NewMoneyType;

            string[] StrBuild = DataGridView1.Columns[6].HeaderText.Split(new[] { OldMoneyType }, StringSplitOptions.None);
            string NewStr = "";
            if (StrBuild.Length > 1) {
                NewStr = NewMoneyType;
                foreach (string element in StrBuild) {
                    NewStr += element;
                }
            }
            DataGridView1.Columns[6].HeaderText = NewStr;

            foreach (NewBuySell form in newBuySell) {
                if (form != null && form.Visible) {
                    form.Label2.Text = NewMoneyType;
                }
            }
        }

        public string CurrentMoneyType = ""; // holds current value of CurrencyTypeComboBox.Text
        /// <summary>
        /// Change the current currency in use for bitcoin price and display purposes.
        /// </summary>
        private void CurrencyTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Loading) {
                ChangeColumnLabelCurrency(CurrencyTypeComboBox.Text, CurrentMoneyType);
                UpdateRateTimer_Tick(sender, e);
            }
        }

        private void CurrPriceBTCTextBox_TextChanged(object sender, EventArgs e)
        {
            if (Timer1Paused) {
                PerformUpdates();
            }
        }

        private void UpdateIntervalNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!Loading) {
                UpdateRateTimer.Stop();
                UpdateRateTimer.Interval = Convert.ToInt32(UpdateIntervalNumericUpDown.Value) * 1000;
                if (!Timer1Paused) {
                    UpdateRateTimer.Start();
                }
            }
        }

        private void ChangesWereMade(object sender, EventArgs e)
        {
            if (!Loading) {
                PerformUpdates();
            }
        }

        bool DataGridUserEdit = false;
        private void DataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            DataGridUserEdit = true;
        }

        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!Loading && DataGridUserEdit) {
                DataGridUserEdit = false;
                PerformUpdates();
            }
        }

        static About about;
        private void AboutButton_Click(object sender, EventArgs e)
        {
            if (about == null) {
                about = new About();
            } else {
                about.Close();
                about = new About();
            }
            about.Show();
        }

        public void StartAlertsTimer()
        {
            if (((Properties.Settings.Default.PriceAlertsG != null && Properties.Settings.Default.PriceAlertsG.Count > 0) ||
                (Properties.Settings.Default.PriceAlertsL != null && Properties.Settings.Default.PriceAlertsL.Count > 0)) && (!Timer1Paused && Properties.Settings.Default.PriceAlertsEnabled)) {
                if (!mainForm.PriceAlertTimer.Enabled) {
                    mainForm.PriceAlertTimer.Start();
                }
            } else {
                if (mainForm.PriceAlertTimer.Enabled) {
                    mainForm.PriceAlertTimer.Stop();
                }
            }
        }

        private void PriceAlertTimer_Tick(object sender, EventArgs e)
        {
            if (((Properties.Settings.Default.PriceAlertsG != null && Properties.Settings.Default.PriceAlertsG.Count == 0) &&
                (Properties.Settings.Default.PriceAlertsL != null && Properties.Settings.Default.PriceAlertsL.Count == 0)) || (Timer1Paused || !Properties.Settings.Default.PriceAlertsEnabled)) {
                PriceAlertTimer.Stop();
                return;
            }

            decimal currPrice;
            if (decimal.TryParse(CurrPriceBTCTextBox.Text, out currPrice)) {
                if (Properties.Settings.Default.PriceAlertsG != null)
                    foreach (string str in Properties.Settings.Default.PriceAlertsG) {
                        if (currPrice >= Convert.ToDecimal(str)) {
                            SystemSounds.Asterisk.Play();
                            return;
                        }
                    }
                if (Properties.Settings.Default.PriceAlertsL != null)
                    foreach (string str in Properties.Settings.Default.PriceAlertsL) {
                        if (currPrice <= Convert.ToDecimal(str)) {
                            SystemSounds.Asterisk.Play();
                            return;
                        }
                    }
            }
        }

        private void alertsButton_Click(object sender, EventArgs e)
        {
            if (alerts == null) {
                alerts = new Alerts(mainForm);
                alerts.Show();
            } else {
                if (!alerts.Visible) {
                    alerts = new Alerts(mainForm);
                    alerts.Show();
                } else {
                    alerts.TopMost = true;
                    alerts.TopMost = false;
                }
            }
        }

        bool MinimizeButtonFlag = false;
        private void minimizeToTrayButton_Click(object sender, EventArgs e)
        {
            NotifyIcon1.Icon = Properties.Resources.icon50;
            MinimizeButtonFlag = true;
            WindowState = FormWindowState.Minimized;

            if (alerts != null)
                alerts.Close();
            foreach (NewBuySell form in newBuySell) {
                if (form != null)
                    form.Close();
            }
            if (about != null)
                about.Close();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (MinimizeButtonFlag) { // only when "minimize to tray" button is used and not standard minimizing
                MinimizeButtonFlag = false;
                NotifyIcon1.Visible = true;
                Hide();
            } else if (WindowState == FormWindowState.Normal) {
                NotifyIcon1.Visible = false;
            }
        }

        static TrayMenu trayMenu;
        private void NotifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right) {
                // right click
                if (trayMenu == null) {
                    trayMenu = new TrayMenu(mainForm);
                } else if (!trayMenu.Visible) {
                    trayMenu.Close();
                    trayMenu = new TrayMenu(mainForm);
                }
                trayMenu.Show();
                trayMenu.Activate();
                trayMenu.Width = 1; // it will be set behind the menu, so it's 1x1 pixels
                trayMenu.Height = 1;
            } else if (e.Button == System.Windows.Forms.MouseButtons.Left) {
                // left click
                if (trayMenu != null)
                    trayMenu.Hide();
                this.Show();
                this.WindowState = FormWindowState.Normal;
            }
        }
    }
}

