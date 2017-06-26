using Newtonsoft.Json;
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
using Microsoft.VisualBasic;
using System.Windows.Forms;
using static Bitcoin_Transaction_Log.Methods1;
using JsonNet.PrivateSettersContractResolvers;
using System.Threading;

namespace Bitcoin_Transaction_Log
{
    public partial class MainForm : Form
    {
        public static bool Loading = true;
        //public LockThreadExec As new Object
        private object LockUpdates = new object();
        private object LockPerformUpdates = new object();

        public string UpdatingInProgressStr = CryptoMain.CryptoNames.Bitcoin + " price updating is in progress.";
        public string UpdatingPausedStr = CryptoMain.CryptoNames.Bitcoin + " price updating is paused.";
        public string UpdatingStoppedStr = CryptoMain.CryptoNames.Bitcoin + " price updating is not in progress.";
        delegate void UpdateLightTooltip_Delegate(Control control, string caption);

        public static MainForm mainForm;
        public static List<NewBuySell> newBuySell = new List<NewBuySell>();
        public static Alerts alerts;

        public CryptoMain CryptoList = new CryptoMain();

        public MainForm()
        {
            InitializeComponent();
            mainForm = this;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SellAllBTCButton.BackgroundImage = Properties.Resources.Simple_Information;
            SellAllProfitInfoButton.BackgroundImage = Properties.Resources.Simple_Information;
            BreakEvenPriceButton.BackgroundImage = Properties.Resources.Simple_Information;
            CryptoPictureBox1.BackgroundImage = Properties.Resources.bitcoin2;
            CryptoPictureBox2.BackgroundImage = Properties.Resources.bitcoin2;

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
                ChangeColumnLabelCurrency(CurrencyTypeComboBox.Text, "usd");
            } else {
                int index = CurrencyTypeComboBox.Items.Add("usd");
                CurrencyTypeComboBox.SelectedIndex = index;
            }

            IgnoreLossCheckBox.Checked = Properties.Settings.Default.IgnoreLoss;

            if (IsNumeric(Properties.Settings.Default.UpdateInterval)) {
                UpdateIntervalNumericUpDown.Value = Properties.Settings.Default.UpdateInterval;
            } else {
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

            if (!string.IsNullOrEmpty(Properties.Settings.Default.CryptoMain)) {
                try {
                    var settings = new JsonSerializerSettings {
                        ContractResolver = new PrivateSetterContractResolver()
                    };
                    CryptoList = JsonConvert.DeserializeObject<CryptoMain>(Properties.Settings.Default.CryptoMain, settings);
                } catch { }
            }
            CryptoList.LoadCrypto(this, CryptoList.CurrentCryptoType);

            ToolTip1.SetToolTip(PauseButton, pauseTooltip);

            UpdateRateTimer.Interval = Convert.ToInt32(UpdateIntervalNumericUpDown.Value) * 1000;
            UpdateRateTimer.Start();
            UpdateRateTimer_Tick(sender, e);

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

                CryptoList.SaveCurrentCrypto(this);
                Properties.Settings.Default.CryptoMain = JsonConvert.SerializeObject(CryptoList);

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
            OpenNewNewBuySell(0, "New Buy");
        }

        /// <summary>
        /// Open a new NewBuySell form.
        /// </summary>
        private void NewSellButton_Click(object sender, EventArgs e)
        {
            OpenNewNewBuySell(1, "New Sell");
        }

        /// <summary>
        /// Open a new NewBuySell form.
        /// </summary>
        private static void OpenNewNewBuySell(int index, string text)
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
                        lock (LockPerformUpdates) {
                            WebRequest wrGETURL;
                            wrGETURL = WebRequest.Create("https://api.coinbase.com/v2/exchange-rates?currency=" + CryptoList.CurrentCryptoType);
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
                    }

                    PerformUpdates();

                } catch /*(System.Net.WebException ex1)*/ {
                    //if (ex1.Status == 14) { // Timeout
                    //Interaction.MsgBox("System.Net.WebException" + Environment.NewLine + ex1.Message);
                    //}
                    /*} catch (Exception ex) {
                        //Interaction.MsgBox("System.Net.WebException" + Environment.NewLine + ex.Message);*/
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

        delegate void SetTitle_Callback(string text);
        /// <summary>
        /// Change form's title.
        /// </summary>
        private void SetTitle(string text)
        {
            if (mainForm.InvokeRequired) {
                SetTitle_Callback d = new SetTitle_Callback(SetTitle);
                this.Invoke(d, new object[] { text });
            } else {
                this.Text = text;
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
                if (text != tb.Text) { // user money type is added on load
                    tb.Items.Add(text);
                }
            }
        }

        /// <summary>
        /// Perform updates on displays
        /// </summary>
        public void PerformUpdates()
        {
            UpdateRowSpecificFeeAmounts();
            UpdateTotalBitcoins(); // update total crytpo display
            UpdateRowSpecificProfit(); // update each row's potential profit if sold at current exchange price
            UpdateRowSpecificBreakEvenPoint(); // update each row's break-even Bitcoin price

            decimal totalBTC = 0m;
            decimal buyUSD = 0m;
            decimal sellUSD = 0m;
            decimal feeAmt = 0m;
            ComputetotalBTCandUSD(ref totalBTC, ref buyUSD, ref sellUSD, ref feeAmt);

            UpdateSellNowRevenue(totalBTC); // update total potential revenue display
            UpdateTotalPossibleProfit(totalBTC, buyUSD, sellUSD, feeAmt); // update total potential profit display
            UpdateBreakEven(totalBTC); // update break-even display
            UpdateProfitBreakEven(totalBTC, buyUSD, sellUSD, feeAmt); // update profit adjusted break-even display

            if (InTrayFlag) {
                NotifyIcon1.Text = CurrPriceBTCTextBox.Text + " (" + CryptoList.CurrentCryptoType + ")";
            }
        }

        /// <summary>
        /// Updates each BUY/GAIN transcation's row specific profit if sold at the current exchange price.
        /// </summary>
        public void UpdateRowSpecificProfit()
        {
            lock (LockUpdates) {
                decimal SellFeeMult;
                if (IsNumeric(SellAllNowProfitFeeTextBox.Text)) {
                    SellFeeMult = (1m - (Convert.ToDecimal(SellAllNowProfitFeeTextBox.Text) / 100m));
                } else SellFeeMult = 1m;

                for (int i = 0; i <= DataGridView1.Rows.Count - 1; i++) {
                    string transactionType = Convert.ToString(DataGridView1[0, i].Value);
                    decimal btc;
                    decimal usd;
                    decimal currentExchangeRate;
                    if (decimal.TryParse(Convert.ToString(DataGridView1[2, i].Value), out btc) &&
                        decimal.TryParse(Convert.ToString(DataGridView1[3, i].Value), out usd) &&
                        decimal.TryParse(CurrPriceBTCTextBox.Text, out currentExchangeRate) &&
                        (transactionType == "BUY" || transactionType == "GAIN")) {

                        if (currentExchangeRate == 0m) { // equals 0
                            DataGridView1[7, i].Value = "-100 %"; // percent change
                            DataGridView1[8, i].Value = -Convert.ToDecimal(DataGridView1[3, i].Value); // profit
                        } else {
                            decimal FeeAmount;
                            if (!decimal.TryParse(Convert.ToString(DataGridView1[4, i].Value), out FeeAmount))
                                FeeAmount = 0m;

                            try {
                                decimal cost = usd + FeeAmount;
                                decimal sellNow;
                                if (SellFeeMult != 0m)
                                    sellNow = btc * (currentExchangeRate / SellFeeMult);
                                else
                                    sellNow = 0m;

                                try {
                                    if (cost != 0m) {
                                        decimal PercentChange = (sellNow / cost) - 1m;
                                        DataGridView1[7, i].Value = Math.Round(PercentChange * 100m, 2) + " %";
                                    } else {
                                        DataGridView1[7, i].Value = "--";
                                    }
                                } catch {
                                    DataGridView1[7, i].Value = "--";
                                }
                                try {
                                    DataGridView1[8, i].Value = Math.Round(sellNow - cost, 2);
                                } catch {
                                    DataGridView1[8, i].Value = "--";
                                }
                            } catch {
                                DataGridView1[7, i].Value = "--";
                                DataGridView1[8, i].Value = "--";
                            }
                        }
                    } else {
                        DataGridView1[7, i].Value = "--";
                        DataGridView1[8, i].Value = "--";
                    }
                }
            }
        }

        /// <summary>
        /// Updates each BUY transcation's row specific break-even point for selling.
        /// </summary>
        private void UpdateRowSpecificBreakEvenPoint()
        {
            lock (LockUpdates) {
                for (int i = 0; i <= DataGridView1.Rows.Count - 1; i++) {
                    string transactionType = Convert.ToString(DataGridView1[0, i].Value);
                    if (transactionType == "BUY" && IsNumeric(DataGridView1[6, i].Value)) {
                        try {
                            decimal SellFee;
                            if (IsNumeric(SellAllNowProfitFeeTextBox.Text)) {
                                SellFee = 1m - (Convert.ToDecimal(SellAllNowProfitFeeTextBox.Text) / 100m);
                            } else SellFee = 1m;
                            decimal FeeRowMult;
                            if (IsNumeric(DataGridView1[5, i].Value)) {
                                FeeRowMult = 1m - (Convert.ToDecimal(DataGridView1[5, i].Value) / 100m);
                            } else FeeRowMult = 1m;
                            decimal exchangeRate = Convert.ToDecimal(DataGridView1[6, i].Value);

                            if (FeeRowMult != 0m && SellFee != 0m)
                                DataGridView1[9, i].Value = Math.Round((exchangeRate / FeeRowMult) / SellFee, 2);
                            else
                                DataGridView1[9, i].Value = 0m;
                        } catch {
                            DataGridView1[9, i].Value = "--";
                        }
                    } else {
                        DataGridView1[9, i].Value = "--";
                    }
                }
            }
        }

        /// <summary>
        /// Revenue info (show your work) button.
        /// </summary>
        private void SellAllBTCButton_Click(object sender, EventArgs e)
        {
            decimal totalBTC = 0m;
            decimal currPriceBTC = 0m;
            decimal fee = 0m;
            string SellAllNowProfitFee = "0";
            decimal usd = 0m;
            decimal result = 0m;

            try {
                lock (LockUpdates) {
                    ComputetotalBTCandUSD(ref totalBTC);

                    if (totalBTC > 0) {
                        if (IsNumeric(SellAllNowProfitFeeTextBox.Text)) {
                            fee = 1m - ((Convert.ToDecimal(SellAllNowProfitFeeTextBox.Text) / 100m));
                            SellAllNowProfitFee = SellAllNowProfitFeeTextBox.Text;
                        }
                        if (IsNumeric(CurrPriceBTCTextBox.Text)) {
                            currPriceBTC = Convert.ToDecimal(CurrPriceBTCTextBox.Text);
                        }
                        usd = totalBTC * currPriceBTC;
                        result = usd * fee;
                    }
                }

                if (totalBTC > 0) {
                    Interaction.MsgBox("(" + totalBTC + CryptoList.CurrentCryptoType + " * $" + currPriceBTC + ") * " + fee + " = $" + result + Environment.NewLine + Environment.NewLine +
                    "(Total " + CryptoList.CurrentCryptoType + " * Current " + CryptoList.CurrentCryptoType + " Price) * Fee Multiplier (" + SellAllNowProfitFee + "%) = Total Revenue");
                } else if (totalBTC < 0) {
                    Interaction.MsgBox("Total " + CryptoList.CurrentCryptoName + " is less than zero: " + totalBTC);
                } else {
                    Interaction.MsgBox("Total " + CryptoList.CurrentCryptoName + " = 0");
                }
            } catch {
                Interaction.MsgBox("Unable to calculate.");
            }
        }

        /// <summary>
        /// Updates "sell all now revenue" TextBox.
        /// </summary>
        public void UpdateSellNowRevenue(decimal totalBTC)
        {
            lock (LockUpdates) {
                try {
                    if (totalBTC > 0m && IsNumeric(CurrPriceBTCTextBox.Text)) {
                        decimal feeMultiplier;
                        if (IsNumeric(SellAllNowProfitFeeTextBox.Text)) {
                            feeMultiplier = 1m - ((Convert.ToDecimal(SellAllNowProfitFeeTextBox.Text) / 100m));
                        } else feeMultiplier = 1m;

                        SetText("SellAllNowRevenueTextBox", Convert.ToString(Math.Round((totalBTC * Convert.ToDecimal(CurrPriceBTCTextBox.Text)) * feeMultiplier, 2)));
                    } else {
                        SetText("SellAllNowRevenueTextBox", "0");
                    }
                } catch {
                    SetText("SellAllNowRevenueTextBox", "--");
                }
            }
        }

        /// <summary>
        /// Updates row specific fee amount.
        /// </summary>
        public void UpdateRowSpecificFeeAmounts()
        {
            lock (LockUpdates) {
                for (int i = 0; i <= DataGridView1.Rows.Count - 1; i++) {
                    decimal feePercent;
                    if (IsNumeric(DataGridView1[5, i].Value)) {
                        feePercent = (Convert.ToDecimal(DataGridView1[5, i].Value) / 100m);
                    } else feePercent = 0m;

                    if (IsNumeric(DataGridView1[3, i].Value)) {
                        DataGridView1[4, i].Value = Convert.ToString(Convert.ToDecimal(DataGridView1[3, i].Value) * feePercent);
                    } else {
                        DataGridView1[4, i].Value = "--";
                    }
                }
            }
        }

        /// <summary>
        /// Updates the profit adjusted break-even point TextBox.
        /// </summary>
        public void UpdateProfitBreakEven(decimal totalBTC, decimal buyUSD, decimal sellUSD, decimal feeAmt)
        {
            lock (LockUpdates) {
                try {
                    if (totalBTC > 0m) {
                        decimal averageCost = ((buyUSD + feeAmt) - sellUSD) / (totalBTC);
                        decimal feeMultiplier;
                        if (IsNumeric(SellAllNowProfitFeeTextBox.Text)) {
                            feeMultiplier = 1 - (Convert.ToDecimal(SellAllNowProfitFeeTextBox.Text) / 100m);
                        } else feeMultiplier = 0m;

                        if (feeMultiplier > 0m) {
                            decimal result = averageCost / feeMultiplier;
                            SetText("ProfitSellAllBreakEvenTextBox", Convert.ToString(Math.Round(result, 2)));
                        } else
                            SetText("ProfitSellAllBreakEvenTextBox", "None");
                    } else
                        SetText("ProfitSellAllBreakEvenTextBox", "--");
                } catch {
                    SetText("ProfitSellAllBreakEvenTextBox", "--");
                }
            }
        }

        /// <summary>
        /// Updates the sell all break-even TextBox.
        /// </summary>
        public void UpdateBreakEven(decimal totalBTC)
        {
            lock (LockUpdates) {
                if (totalBTC > 0m) {
                    try {
                        List<DataGridSettingsRow> mainList = CryptoMain.GetDataGridViewRows(DataGridView1);
                        List<DataGridSettingsRow> buyList = new List<DataGridSettingsRow>();
                        decimal buybtcTotal = 0m; // total buy btc
                        for (int i = 0; i <= mainList.Count - 1; i++) {
                            switch (Convert.ToString(mainList[i].Transaction)) {
                                case "BUY":
                                    if (!mainList[i].Disabled) {
                                        buyList.Add(mainList[i]);
                                        decimal value;
                                        if (decimal.TryParse(mainList[i].BTC, out value)) {
                                            buybtcTotal += value; // add to buy btc total
                                        }
                                    }
                                    break;
                            }
                        }

                        decimal total = 0m;
                        bool buyFound = false;
                        for (int i = 0; i < buyList.Count; i++) {
                            switch (buyList[i].Transaction) {
                                case "BUY":
                                    decimal btc;
                                    if (decimal.TryParse(buyList[i].BTC, out btc)) {
                                        decimal feeMult;
                                        if (decimal.TryParse(buyList[i].Fee, out feeMult)) {
                                            feeMult = (1m - (feeMult / 100m));
                                        }
                                        decimal exchangeRate;
                                        if (decimal.TryParse(buyList[i].ExchangeRate, out exchangeRate)) {
                                            if (feeMult != 0m) {
                                                total += (btc / buybtcTotal) * (exchangeRate / feeMult);
                                                buyFound = true;
                                            }
                                        }
                                    }
                                    break;
                            }
                        }

                        if (buyFound) {
                            decimal feeMult;
                            if (decimal.TryParse(SellAllNowProfitFeeTextBox.Text, out feeMult)) {
                                feeMult = 1m - (feeMult / 100m);
                                if (feeMult > 0m) {
                                    decimal result = total / feeMult;
                                    SetText("SellAllBreakEvenTextBox", Convert.ToString(Math.Round(result, 2)));
                                } else
                                    SetText("SellAllBreakEvenTextBox", "None");
                            } else {
                                SetText("SellAllBreakEvenTextBox", Convert.ToString(Math.Round(total, 2)));
                            }
                        } else {
                            SetText("SellAllBreakEvenTextBox", "--");
                        }
                    } catch {
                        SetText("SellAllBreakEvenTextBox", "--");
                    }
                } else {
                    SetText("SellAllBreakEvenTextBox", "--");
                }
            }
        }

        /// <summary>
        /// Break-even show work button.
        /// </summary>
        private void BreakEvenPriceButton_Click(object sender, EventArgs e)
        {
            decimal buyUSD = 0m;
            decimal sellUSD = 0m;
            decimal totalBTC = 0m;
            decimal feeAmt = 0m;
            string feeText = "";

            try {
                lock (LockUpdates) {
                    ComputetotalBTCandUSD(ref totalBTC, ref buyUSD, ref sellUSD, ref feeAmt);
                    feeText = SellAllNowProfitFeeTextBox.Text;
                }
            } catch (Exception ex) {
                Interaction.MsgBox("Error: " + ex.GetType());
            }

            if (totalBTC > 0m) {
                try {
                    decimal averageCost = ((buyUSD + feeAmt) - sellUSD) / (totalBTC);
                    decimal feeMultiplier;
                    if (IsNumeric(feeText)) {
                        feeMultiplier = 1 - (Convert.ToDecimal(feeText) / 100m);
                    } else feeMultiplier = 0m;

                    if (feeMultiplier > 0m) {
                        decimal result = averageCost / feeMultiplier;
                        Interaction.MsgBox("[( (" + buyUSD + " + " + feeAmt + ") - " + sellUSD + ") / " + totalBTC + "] " + " / " + feeMultiplier + " = " + result + Environment.NewLine + Environment.NewLine +
                                        "[( (Buy " + CurrencyTypeComboBox.Text + " + Fees) - Sell " + CurrencyTypeComboBox.Text + ") / Total " + CryptoList.CurrentCryptoType + "] / Fee Multiplier = " + result);
                    } else {
                        Interaction.MsgBox("None");
                    }
                } catch (Exception ex) {
                    Interaction.MsgBox("Error: " + ex.GetType());
                }
            } else {
                Interaction.MsgBox("Unable to calculate. Total " + CryptoList.CurrentCryptoName + " <= 0");
            }
        }

        /// <summary>
        /// Update total sell now profit TextBox.
        /// </summary>
        public void UpdateTotalPossibleProfit(decimal totalBTC, decimal buyUSD, decimal sellUSD, decimal feeAmt)
        {
            lock (LockUpdates) {
                if (DataGridView1.Rows.Count > 0) {
                    try {
                        if (!IsNumeric(CurrPriceBTCTextBox.Text)) {
                            SetText("SellAllNowProfitTextBox", "0");
                            SetText("ProfitPercentTextBox", "0");
                        } else {
                            // add total profit columns together
                            decimal feeMultiplier;
                            if (IsNumeric(SellAllNowProfitFeeTextBox.Text)) {
                                feeMultiplier = 1m - (Convert.ToDecimal(SellAllNowProfitFeeTextBox.Text) / 100m);
                            } else
                                feeMultiplier = 1m;

                            //if (totalBTC <= 0m)
                            //    totalBTC = 0m;
                            decimal Revenue = ((totalBTC * Convert.ToDecimal(CurrPriceBTCTextBox.Text)) * feeMultiplier);

                            SetText("SellAllNowProfitTextBox", Convert.ToString(Math.Round(Revenue + (sellUSD - (buyUSD + feeAmt)), 2)));

                            decimal resultPercent;
                            if (buyUSD + feeAmt != 0m)
                                resultPercent = Math.Round((((Revenue + sellUSD) / (buyUSD + feeAmt)) - 1m) * 100m, 2);
                            else
                                resultPercent = 0m;

                            if (resultPercent > 0m)
                                SetText("ProfitPercentTextBox", "+" + Convert.ToString(resultPercent) + "%");
                            else
                                SetText("ProfitPercentTextBox", Convert.ToString(resultPercent) + "%");
                        }
                    } catch {
                        SetText("SellAllNowProfitTextBox", "--");
                        SetText("ProfitPercentTextBox", "--");
                    }
                } else {
                    SetText("SellAllNowProfitTextBox", "0");
                    SetText("ProfitPercentTextBox", "0");
                }
            }
        }

        /// <summary>
        /// Profit info (show your work) button.
        /// </summary>
        private void SellAllProfitInfoButton_Click(object sender, EventArgs e)
        {
            decimal totalBTC = 0m;
            decimal buyUSD = 0m;
            decimal sellUSD = 0m;
            decimal feeAmt = 0m;
            decimal CurrPriceBTC;
            decimal FeeMultiplier;
            decimal Revenue;

            if (DataGridView1.Rows.Count > 0) {
                try {
                    lock (LockUpdates) {
                        ComputetotalBTCandUSD(ref totalBTC, ref buyUSD, ref sellUSD, ref feeAmt);

                        if (IsNumeric(CurrPriceBTCTextBox.Text)) {
                            CurrPriceBTC = Convert.ToDecimal(CurrPriceBTCTextBox.Text);
                        } else
                            CurrPriceBTC = 0m;

                        if (IsNumeric(SellAllNowProfitFeeTextBox.Text)) {
                            FeeMultiplier = 1m - (Convert.ToDecimal(SellAllNowProfitFeeTextBox.Text) / 100m);
                        } else
                            FeeMultiplier = 1m;

                        Revenue = ((totalBTC * Convert.ToDecimal(CurrPriceBTCTextBox.Text)) * FeeMultiplier);
                    }

                    decimal resultPercent;
                    if (buyUSD != 0)
                        resultPercent = Math.Round((((Revenue + sellUSD) / (buyUSD + feeAmt)) - 1m) * 100m, 2);
                    else
                        resultPercent = 0m;

                    string cur = CurrencyTypeComboBox.Text;
                    string type = CryptoList.CurrentCryptoType;
                    Interaction.MsgBox("[ ( " + totalBTC + " " + type + " * $" + CurrPriceBTC + " ) * " + FeeMultiplier + " ] + ( $" + sellUSD + " - ($" + buyUSD + " + " + feeAmt + ") ) = $" +
                            Math.Round(Revenue + (sellUSD - (buyUSD + feeAmt)), 2) + Environment.NewLine +
                            "[ (Total " + type + " * Current " + type + " Price) * Fee Multiplier ] + ( Sell " + cur + " - (Buy " + cur + " + Fees) ) = Total Profit" + Environment.NewLine + Environment.NewLine +
                            "( [ ( [ ( " + totalBTC + " " + type + " * $" + CurrPriceBTC + " ) * " + FeeMultiplier + " ] + " + sellUSD + " ) / (" + buyUSD + " + " + feeAmt + ") ] - 1 ) * 100 = " + resultPercent + Environment.NewLine +
                            "( [ ( [ ( Total " + type + " * Current " + type + " Price ) * Fee Multiplier ] + Sell " + cur + " ) / (Buy " + cur + " + Fees) ] - 1 ) * 100 = Percentage Change");
                } catch {
                    Interaction.MsgBox("Unable to calculate.");
                }
            } else {
                Interaction.MsgBox("0");
            }
        }

        /// <summary>
        /// Computes the total bitcoins and total buy and sell money.
        /// </summary>
        private void ComputetotalBTCandUSD(ref decimal totalBTC)
        {
            decimal buyUSD = 0m;
            decimal sellUSD = 0m;
            decimal feeAmt = 0m;
            ComputetotalBTCandUSD(ref totalBTC, ref buyUSD, ref sellUSD, ref feeAmt);
        }
        /// <summary>
        /// Computes the total bitcoins and total buy and sell money.
        /// </summary>
        private void ComputetotalBTCandUSD(ref decimal totalBTC, ref decimal buyUSD, ref decimal sellUSD, ref decimal feeAmt)
        {
            for (int i = 0; i <= DataGridView1.Rows.Count - 1; i++) {
                if (!Convert.ToBoolean(DataGridView1[10, i].Value)) {

                    string transactionType = Convert.ToString(DataGridView1[0, i].Value);
                    decimal btc = Convert.ToDecimal(SanitizeNumber(DataGridView1[2, i].Value));
                    decimal usd = Convert.ToDecimal(SanitizeNumber(DataGridView1[3, i].Value));
                    decimal feeVal = Convert.ToDecimal(SanitizeNumber(DataGridView1[4, i].Value));
                    if (transactionType == "BUY") {
                        totalBTC += btc;
                        buyUSD += usd;
                        feeAmt += feeVal;
                    } else if (transactionType == "SELL") {
                        totalBTC -= btc;
                        sellUSD += usd;
                        feeAmt += feeVal;
                    } else if (transactionType == "LOSS") {
                        // loss of btc and/or usd
                        if (!IgnoreLossCheckBox.Checked)
                            if (btc >= 0m)
                                totalBTC -= btc;
                            else
                                totalBTC += btc;
                    } else if (transactionType == "GAIN") {
                        // gain of btc and/or usd
                        totalBTC += btc;
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
                decimal totalBTC = 0m;
                for (int i = 0; i <= DataGridView1.Rows.Count - 1; i++) {
                    if (!Convert.ToBoolean(DataGridView1[10, i].Value)) {

                        string transactionType = Convert.ToString(DataGridView1[0, i].Value);
                        decimal value = Convert.ToDecimal(SanitizeNumber(DataGridView1[2, i].Value));
                        if (transactionType == "BUY") {
                            totalBTC += value;
                        } else if (transactionType == "SELL") {
                            totalBTC -= value;
                        } else if (transactionType == "LOSS") {
                            // loss of btc and/or usd
                            if (!IgnoreLossCheckBox.Checked) {
                                bool btc_IsNullOrEmpty = string.IsNullOrEmpty(Convert.ToString(DataGridView1[2, i].Value));
                                if (!btc_IsNullOrEmpty) {
                                    if (value >= 0m) {
                                        totalBTC -= value;
                                    } else {
                                        totalBTC += value;
                                    }
                                }
                            }
                        } else if (transactionType == "GAIN") {
                            // gain of btc and/or usd
                            bool btc_IsNullOrEmpty = string.IsNullOrEmpty(Convert.ToString(DataGridView1[2, i].Value));
                            if (!btc_IsNullOrEmpty) {
                                totalBTC += value;
                            }
                        }
                    }
                }

                //if (totalBTC <= 0m)
                //    totalBTC = 0m;

                SetText("TotalBitcoinsTextBox", Convert.ToString(totalBTC));
            }
        }

        /// <summary>
        /// Update Bitcoin exchange price timer tick.
        /// </summary>
        private void UpdateRateTimer_Tick(object sender, EventArgs e)
        {
            UpdateRateTimer.Stop(); // timer is restarted when work is complete in thread
            if (!UpdateBitcoinValue.IsBusy) {
                UpdateBitcoinValue.RunWorkerAsync();
            }
        }

        private void UpdateBitcoinValue_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!Timer1Paused) {
                UpdateRateTimer.Start(); // restart the update Bitcoin rate timer now that work is complete
            }
        }

        /// <summary>
        /// Perform Cryptocurrency price updating work and other updates.
        /// </summary>
        private void UpdateBitcoinValue_DoWork(object sender, DoWorkEventArgs e)
        {
            UpdateBitcoinExchangeValue();
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
        /// Change the Currencies used in column labels. (usd is default)
        /// </summary>
        private void ChangeColumnLabelCurrency(string NewMoneyType, string OldMoneyType)
        {
            CurrentMoneyType = NewMoneyType;
            DataGridView1.Columns[3].HeaderText = DataGridView1.Columns[3].HeaderText.Replace(OldMoneyType, NewMoneyType);
            DataGridView1.Columns[7].HeaderText = DataGridView1.Columns[7].HeaderText.Replace(OldMoneyType, NewMoneyType);

            foreach (NewBuySell form in newBuySell) {
                if (form != null && form.Visible) {
                    form.Label2.Text = NewMoneyType;
                }
            }
        }

        /// <summary>
        /// Holds current value of CurrencyTypeComboBox.Text
        /// </summary>
        public string CurrentMoneyType = "";
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

        /// <summary>
        /// User is editting a DataGridView cell.
        /// </summary>
        bool DataGridUserEdit = false;
        private void DataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            DataGridUserEdit = true;

            if (e.Button == MouseButtons.Right) {
                int col = DataGridView1.HitTest(e.Location.X, e.Location.Y).ColumnIndex;
                int row = DataGridView1.HitTest(e.Location.X, e.Location.Y).RowIndex;
                if (col >= 0 && row >= 0 && DataGridView1.Columns.Count - 1 >= col && DataGridView1.Rows.Count - 1 >= row) {
                    DataGridView1.ClearSelection();
                    DataGridView1[col, row].Selected = true;
                }
            }
        }

        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (DataGridUserEdit && !Loading && e.RowIndex >= 0 && e.ColumnIndex >= 0) {
                DataGridUserEdit = false;

                lock (LockUpdates) {
                    decimal btc;
                    decimal usd;
                    decimal exchangeRate;
                    switch (e.ColumnIndex) {
                        case 3: // usd
                            if (decimal.TryParse(Convert.ToString(DataGridView1[2, e.RowIndex].Value), out btc) &&
                                decimal.TryParse(Convert.ToString(DataGridView1[3, e.RowIndex].Value), out usd)) {
                                DataGridView1[6, e.RowIndex].Value = (1m / btc) * usd;
                            }
                            break;
                        case 2: // btc
                        case 6: // Exchange Rate
                            if (decimal.TryParse(Convert.ToString(DataGridView1[2, e.RowIndex].Value), out btc) &&
                                decimal.TryParse(Convert.ToString(DataGridView1[6, e.RowIndex].Value), out exchangeRate)) {
                                DataGridView1[3, e.RowIndex].Value = btc * exchangeRate;
                            }
                            break;
                        default:
                            break;
                    }
                }

                PerformUpdates();
            }
        }

        private void DataGridView1_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            if (!Loading) {
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
            var with = CryptoList.CryptoRows[CryptoList.CurrentCryptoType];
            if ((with.PriceAlertsG.Count > 0 || with.PriceAlertsL.Count > 0) && (!Timer1Paused && with.PriceAlertsEnabled)) {
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
            var with = CryptoList.CryptoRows[CryptoList.CurrentCryptoType];
            if ((with.PriceAlertsG.Count == 0 && with.PriceAlertsL.Count == 0) || (Timer1Paused || !with.PriceAlertsEnabled)) {
                PriceAlertTimer.Stop();
                return;
            }

            decimal currPrice;
            if (decimal.TryParse(CurrPriceBTCTextBox.Text, out currPrice)) {
                if (with.PriceAlertsG.Count > 0)
                    if (currPrice >= Convert.ToDecimal(with.PriceAlertsG[0])) {
                        SystemSounds.Asterisk.Play();
                        return;
                    }
                if (with.PriceAlertsL.Count > 0)
                    if (currPrice <= Convert.ToDecimal(with.PriceAlertsL[0])) {
                        SystemSounds.Asterisk.Play();
                        return;
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
        bool InTrayFlag = false;
        private void minimizeToTrayButton_Click(object sender, EventArgs e)
        {
            if (mainForm.CryptoList.CurrentCryptoType == "ETH")
                NotifyIcon1.Icon = Properties.Resources.Ethereum32icon;
            else if (mainForm.CryptoList.CurrentCryptoType == "LTC")
                NotifyIcon1.Icon = Properties.Resources.Litecoin32icon;
            else
                NotifyIcon1.Icon = Properties.Resources.Bitcoin50;
            NotifyIcon1.Text = CurrPriceBTCTextBox.Text + " (" + CryptoList.CurrentCryptoType + ")";
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
                InTrayFlag = true;
                NotifyIcon1.Visible = true;
                Hide();
            } else if (WindowState == FormWindowState.Normal) {
                NotifyIcon1.Visible = false;
                InTrayFlag = false;
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

        private void copyCellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DataGridView1.SelectedCells.Count > 0) {
                try {
                    if (DataGridView1.SelectedCells[0].Value != null) {
                        Clipboard.SetText(Convert.ToString(DataGridView1.SelectedCells[0].Value));
                    } else {
                        Clipboard.Clear();
                    }
                } catch {
                }
            }
        }

        private void CryptoTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Loading) {
                UpdateRateTimer.Stop();
                CryptoTypeWaitTimer_Tick(sender, e);
            }
        }

        private void CryptoTypeWaitTimer_Tick(object sender, EventArgs e)
        {
            cryptoTypeWaitTimer.Start();
            if (!UpdateBitcoinValue.IsBusy) {
                cryptoTypeWaitTimer.Stop();

                lock (LockPerformUpdates) {
                    string newCryptoType = CryptoTypeComboBox.Text;
                    CryptoList.SaveCurrentCrypto(this);
                    CryptoList.LoadCrypto(this, newCryptoType);
                }

                UpdateRateTimer_Tick(sender, e);
                PerformUpdates();
            }
        }
    }
}

