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
        public SemaphoreSlim LockUpdates = new SemaphoreSlim(1, 1);
        public SemaphoreSlim LockPriceAlertTimer = new SemaphoreSlim(1, 2);

        public string UpdatingInProgressStr = CryptoMain.CryptoNames.Bitcoin + " price updating is in progress.";
        public string UpdatingPausedStr = CryptoMain.CryptoNames.Bitcoin + " price updating is paused.";
        public string UpdatingStoppedStr = CryptoMain.CryptoNames.Bitcoin + " price updating is not in progress.";
        delegate void UpdateLightTooltip_Delegate(Control control, string caption);

        public static MainForm mainForm;
        public static List<NewBuySell> newBuySell = new List<NewBuySell>();
        public static Alerts alerts;
        public static SettingsForm settingsForm;
        public NotificationIcon notificationIcon1;

        public CryptoMain CryptoList = new CryptoMain();
        public SettingsClass SettingsInfo;
        public Font DefaultRowsDefaultCellStyleFont;
        public Font DefaultColumnHeadersDefaultCellStyleFont;

        public MainForm()
        {
            InitializeComponent();
            mainForm = this;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SettingsInfo = new SettingsClass(this);

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

            DefaultRowsDefaultCellStyleFont = DataGridView1.RowsDefaultCellStyle.Font;
            DefaultColumnHeadersDefaultCellStyleFont = DataGridView1.ColumnHeadersDefaultCellStyle.Font;
            if (!string.IsNullOrEmpty(Properties.Settings.Default.SettingsInfo)) {
                SettingsInfo = JsonConvert.DeserializeObject<SettingsClass>(Properties.Settings.Default.SettingsInfo);
                SettingsInfo.LoadMainForm(this);
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

            CurrencyTypeComboBox.MouseWheel += new MouseEventHandler(CurrencyTypeComboBox_MouseWheel);
            CryptoTypeComboBox.MouseWheel += new MouseEventHandler(CryptoTypeComboBox_MouseWheel);

            this.ActiveControl = Label1; // focus nothing
            Loading = false; // loading is finished flag
        }

        private async void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            PriceAlertTimer.Stop();
            UpdateRateTimer.Stop();

            await LockUpdates.WaitAsync();
            await LockPriceAlertTimer.WaitAsync();
            if (this.WindowState == FormWindowState.Minimized) {
                if (!this.Visible) {
                    this.Visible = true;
                }
                this.Opacity = 0.0;
                this.WindowState = FormWindowState.Normal;
            }

            CryptoList.SaveCurrentCrypto(this);
            Properties.Settings.Default.CryptoMain = JsonConvert.SerializeObject(CryptoList);

            Properties.Settings.Default.SettingsInfo = JsonConvert.SerializeObject(SettingsInfo);

            if (IsNumeric(SellAllNowProfitFeeTextBox.Text)) {
                Properties.Settings.Default.SellAllNowProfitFee = Convert.ToDouble(SellAllNowProfitFeeTextBox.Text);
            } else if (string.IsNullOrEmpty(SellAllNowProfitFeeTextBox.Text)) {
                Properties.Settings.Default.SellAllNowProfitFee = 0;
            }
            Properties.Settings.Default.MoneyType = CurrencyTypeComboBox.Text;
            Properties.Settings.Default.IgnoreLoss = IgnoreLossCheckBox.Checked;
            Properties.Settings.Default.UpdateInterval = Convert.ToInt32(UpdateIntervalNumericUpDown.Value);
            Properties.Settings.Default.MainFormSize = this.Size;

            try {
                string ConstructWidthStr = Convert.ToString(DataGridView1.Columns[0].Width);
                for (int i = 1; i <= DataGridView1.Columns.Count - 1; i++) {
                    ConstructWidthStr += "<**>";
                    ConstructWidthStr += Convert.ToString(DataGridView1.Columns[i].Width);
                }
                Properties.Settings.Default.DataGridColumnWidths = ConstructWidthStr;
            } catch { }

            Properties.Settings.Default.Save();
            LockPriceAlertTimer.Release();
            LockUpdates.Release();
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
        private async void UpdateBitcoinExchangeValue()
        {
            if (!UpdateBitcoinValue.CancellationPending) {
                await LockUpdates.WaitAsync();

                try {
                    UpdateLightTooltip_Delegate d1 = new UpdateLightTooltip_Delegate(ToolTip1.SetToolTip);
                    Invoke(d1, new object[] { UpdateLight, UpdatingInProgressStr });
                    UpdateLight.Image = Properties.Resources.green_light32;

                    try {
                        if (!Timer1Paused) {
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
                                                        ComboBoxItemsAdd("CurrencyTypeComboBox", data3.Name);
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
                                                        SetText("CurrPriceBTCTextBox", Convert.ToString(data3.Value));
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

                    } catch (System.Net.WebException ex) {
                        if (ex.GetType().ToString() == "System.Net.WebException") {
                            if (ex.Status == WebExceptionStatus.Timeout) {
                                LockUpdates.Release();
                                UpdateBitcoinExchangeValue(); // retry
                                return;
                            }
                        }
                    } catch {
                    }

                    LockUpdates.Release();
                    PerformUpdates();

                    try {
                        if (!UpdateBitcoinValue.CancellationPending) {
                            UpdateLightTooltip_Delegate d2 = new UpdateLightTooltip_Delegate(ToolTip1.SetToolTip);
                            Invoke(d2, new object[] { UpdateLight, UpdatingStoppedStr });
                            UpdateLight.Image = Properties.Resources.red_light32;
                        }
                    } catch { }
                } catch {
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
            if (Control1 != null && Control1.Length > 0) {
                TextBox tb = (TextBox)Control1[0];
                if (tb.InvokeRequired) {
                    SetText_Callback d = new SetText_Callback(SetText);
                    this.Invoke(d, new object[] { TextBoxRef, text });
                } else {
                    tb.Text = text;
                    tb.RemoveTrailingZeroes();
                }
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
            if (Control1 != null && Control1.Length > 0) {
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
        }

        /// <summary>
        /// Start threaded version of update method
        /// </summary>
        public void PerformUpdatesThread()
        {
            (new Thread(new ThreadStart(PerformUpdates))).Start();
        }

        /// <summary>
        /// Perform updates on displays
        /// </summary>
        public async void PerformUpdates()
        {
            await LockUpdates.WaitAsync();
            try {
                UpdateRowSpecificFeeAmounts();
                UpdateTotalBitcoins(); // update total crypto display
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
                    notificationIcon1.notifyIcon.Text = CurrPriceBTCTextBox.Text + " (" + CryptoList.CurrentCryptoType + ")";
                }
            } catch (Exception ex) {
                Interaction.MsgBox(ex.Message + Environment.NewLine + "Error 1353632", MsgBoxStyle.Critical);
            }
            LockUpdates.Release();
        }

        /// <summary>
        /// Updates each BUY/GAIN transcation's row specific profit if sold at the current exchange price.
        /// </summary>
        public void UpdateRowSpecificProfit()
        {
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
                                    if (SettingsInfo.R.dc_percentInc != 0)
                                        DataGridView1[7, i].Value = Math.Round(PercentChange * 100m, SettingsInfo.R.dc_percentInc).RemoveTrailingZeroes() + " %";
                                    else
                                        DataGridView1[7, i].Value = (PercentChange * 100m).RemoveTrailingZeroes() + " %";
                                } else {
                                    DataGridView1[7, i].Value = "--";
                                }
                            } catch {
                                DataGridView1[7, i].Value = "--";
                            }
                            try {
                                if (SettingsInfo.R.dc_sellNowProfit != 0)
                                    DataGridView1[8, i].Value = Math.Round(sellNow - cost, SettingsInfo.R.dc_sellNowProfit).RemoveTrailingZeroes();
                                else
                                    DataGridView1[8, i].Value = (sellNow - cost).RemoveTrailingZeroes();
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

        /// <summary>
        /// Updates each BUY transcation's row specific break-even point for selling.
        /// </summary>
        private void UpdateRowSpecificBreakEvenPoint()
        {
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

                        if (FeeRowMult != 0m && SellFee != 0m) {
                            decimal result = (exchangeRate / FeeRowMult) / SellFee;
                            if (SettingsInfo.R.dc_breakEvenPoint != 0)
                                DataGridView1[9, i].Value = Math.Round(result, SettingsInfo.R.dc_breakEvenPoint).RemoveTrailingZeroes();
                            else
                                DataGridView1[9, i].Value = result.RemoveTrailingZeroes();
                        } else {
                            DataGridView1[9, i].Value = (0m).RemoveTrailingZeroes();
                        }
                    } catch {
                        DataGridView1[9, i].Value = "--";
                    }
                } else {
                    DataGridView1[9, i].Value = "--";
                }
            }
        }

        /// <summary>
        /// Revenue info (show your work) button.
        /// </summary>
        private async void SellAllBTCButton_Click(object sender, EventArgs e)
        {
            decimal totalBTC = 0m;
            decimal currPriceBTC = 0m;
            decimal fee = 0m;
            string SellAllNowProfitFee = "0";
            decimal usd = 0m;
            decimal result = 0m;

            await LockUpdates.WaitAsync();
            try {
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
            } catch {
                Interaction.MsgBox("Unable to calculate.");
            }
            LockUpdates.Release();

            if (totalBTC > 0) {
                Interaction.MsgBox("(" + totalBTC + CryptoList.CurrentCryptoType + " * $" + currPriceBTC + ") * " + fee + " = $" + result + Environment.NewLine + Environment.NewLine +
                "(Total " + CryptoList.CurrentCryptoType + " * Current " + CryptoList.CurrentCryptoType + " Price) * Fee Multiplier (" + SellAllNowProfitFee + "%) = Total Revenue");
            } else if (totalBTC < 0) {
                Interaction.MsgBox("Total " + CryptoList.CurrentCryptoName + " is less than zero: " + totalBTC);
            } else {
                Interaction.MsgBox("Total " + CryptoList.CurrentCryptoName + " = 0");
            }

        }

        /// <summary>
        /// Updates "sell all now revenue" TextBox.
        /// </summary>
        public void UpdateSellNowRevenue(decimal totalBTC)
        {
            try {
                if (totalBTC > 0m && IsNumeric(CurrPriceBTCTextBox.Text)) {
                    decimal feeMultiplier;
                    if (IsNumeric(SellAllNowProfitFeeTextBox.Text)) {
                        feeMultiplier = 1m - ((Convert.ToDecimal(SellAllNowProfitFeeTextBox.Text) / 100m));
                    } else feeMultiplier = 1m;

                    decimal result = (totalBTC * Convert.ToDecimal(CurrPriceBTCTextBox.Text)) * feeMultiplier;
                    if (SettingsInfo.R.tb_sellNowRevenue != 0)
                        SetText("SellAllNowRevenueTextBox", Convert.ToString(Math.Round(result, SettingsInfo.R.tb_sellNowRevenue)));
                    else
                        SetText("SellAllNowRevenueTextBox", Convert.ToString(result));
                } else {
                    SetText("SellAllNowRevenueTextBox", "0");
                }
            } catch {
                SetText("SellAllNowRevenueTextBox", "--");
            }
        }

        /// <summary>
        /// Updates row specific fee amount.
        /// </summary>
        public void UpdateRowSpecificFeeAmounts()
        {
            for (int i = 0; i <= DataGridView1.Rows.Count - 1; i++) {
                decimal feePercent;
                if (IsNumeric(DataGridView1[5, i].Value)) {
                    feePercent = (Convert.ToDecimal(DataGridView1[5, i].Value) / 100m);
                } else feePercent = 0m;

                if (IsNumeric(DataGridView1[3, i].Value)) {
                    decimal result = Convert.ToDecimal(DataGridView1[3, i].Value) * feePercent;
                    if (SettingsInfo.R.dc_feeNum != 0)
                        DataGridView1[4, i].Value = Math.Round(result, SettingsInfo.R.dc_feeNum).RemoveTrailingZeroes();
                    else
                        DataGridView1[4, i].Value = (result).RemoveTrailingZeroes();
                } else {
                    DataGridView1[4, i].Value = "--";
                }
            }
        }

        /// <summary>
        /// Updates the profit adjusted break-even point TextBox.
        /// </summary>
        public void UpdateProfitBreakEven(decimal totalBTC, decimal buyUSD, decimal sellUSD, decimal feeAmt)
        {
            try {
                if (totalBTC > 0m) {
                    decimal averageCost = ((buyUSD + feeAmt) - sellUSD) / (totalBTC);
                    decimal feeMultiplier = 0m;
                    if (IsNumeric(SellAllNowProfitFeeTextBox.Text)) {
                        feeMultiplier = 1 - (Convert.ToDecimal(SellAllNowProfitFeeTextBox.Text) / 100m);
                    } else feeMultiplier = 1m;

                    if (feeMultiplier > 0m) {
                        decimal result = averageCost / feeMultiplier;
                        if (SettingsInfo.R.tb_profitBreakEven != 0)
                            SetText("ProfitSellAllBreakEvenTextBox", Convert.ToString(Math.Round(result, SettingsInfo.R.tb_profitBreakEven)));
                        else
                            SetText("ProfitSellAllBreakEvenTextBox", Convert.ToString(result));
                    } else
                        SetText("ProfitSellAllBreakEvenTextBox", "None");
                } else
                    SetText("ProfitSellAllBreakEvenTextBox", "--");
            } catch {
                SetText("ProfitSellAllBreakEvenTextBox", "--");
            }
        }

        /// <summary>
        /// Updates the sell all break-even TextBox.
        /// </summary>
        public void UpdateBreakEven(decimal totalBTC)
        {
            if (totalBTC > 0m) {
                try {
                    bool isNull;
                    List<DataGridSettingsRow> mainList = CryptoMain.GetDataGridViewRows(DataGridView1, out isNull);
                    List<DataGridSettingsRow> buyList = new List<DataGridSettingsRow>();
                    decimal buybtcTotal = 0m; // total buy btc
                    decimal btcTally = 0m;
                    for (int i = 0; i <= mainList.Count - 1; i++) {
                        switch (Convert.ToString(mainList[i].Transaction)) {
                            case "BUY":
                                if (!mainList[i].Disabled) {
                                    buyList.Add(mainList[i]);
                                    decimal value;
                                    if (decimal.TryParse(mainList[i].BTC, out value)) {
                                        buybtcTotal += value; // add to buy btc total
                                        btcTally += value;
                                    }
                                }
                                break;
                            case "SELL":
                                if (!mainList[i].Disabled) {
                                    decimal value;
                                    if (decimal.TryParse(mainList[i].BTC, out value)) {
                                        btcTally -= value; // add to buy btc total
                                        if (btcTally == 0m) {
                                            buyList.Clear();
                                            buybtcTotal = 0m;
                                        }
                                    }
                                }
                                break;
                        }
                    }


                    decimal total = 0m;
                    bool buyFound = false;
                    if (buybtcTotal > 0m) {
                        for (int i = 0; i < buyList.Count; i++) {
                            switch (buyList[i].Transaction) {
                                case "BUY":
                                    decimal btc;
                                    if (decimal.TryParse(buyList[i].BTC, out btc)) {
                                        decimal feeMult;
                                        if (decimal.TryParse(buyList[i].Fee, out feeMult)) {
                                            feeMult = (feeMult / 100m);
                                        }
                                        decimal exchangeRate;
                                        if (decimal.TryParse(buyList[i].ExchangeRate, out exchangeRate)) {
                                            total += (btc / buybtcTotal) * (exchangeRate + (exchangeRate * feeMult));
                                            buyFound = true;
                                        }
                                    }
                                    break;
                            }
                        }
                    }

                    if (buyFound) {
                        decimal feeMult;
                        if (decimal.TryParse(SellAllNowProfitFeeTextBox.Text, out feeMult)) {
                            feeMult = 1m - (feeMult / 100m);
                            if (feeMult > 0m) {
                                decimal result = total / feeMult;
                                if (SettingsInfo.R.tb_breakEven != 0)
                                    SetText("SellAllBreakEvenTextBox", Convert.ToString(Math.Round(result, SettingsInfo.R.tb_breakEven)));
                                else
                                    SetText("SellAllBreakEvenTextBox", Convert.ToString(result));
                            } else
                                SetText("SellAllBreakEvenTextBox", "None");
                        } else {
                            if (SettingsInfo.R.tb_breakEven != 0)
                                SetText("SellAllBreakEvenTextBox", Convert.ToString(Math.Round(total, SettingsInfo.R.tb_breakEven)));
                            else
                                SetText("SellAllBreakEvenTextBox", Convert.ToString(total));
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

        /// <summary>
        /// Break-even show work button.
        /// </summary>
        private async void BreakEvenPriceButton_Click(object sender, EventArgs e)
        {
            decimal buyUSD = 0m;
            decimal sellUSD = 0m;
            decimal totalBTC = 0m;
            decimal feeAmt = 0m;
            string feeText = "";

            await LockUpdates.WaitAsync();
            try {
                ComputetotalBTCandUSD(ref totalBTC, ref buyUSD, ref sellUSD, ref feeAmt);
                feeText = SellAllNowProfitFeeTextBox.Text;
            } catch (Exception ex) {
                Interaction.MsgBox("Error: " + ex.GetType());
            }
            LockUpdates.Release();

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

                        if (SettingsInfo.R.tb_sellNowProfitNum != 0)
                            SetText("SellAllNowProfitTextBox", Convert.ToString(Math.Round(Revenue + (sellUSD - (buyUSD + feeAmt)), SettingsInfo.R.tb_sellNowProfitNum)));
                        else
                            SetText("SellAllNowProfitTextBox", Convert.ToString(Revenue + (sellUSD - (buyUSD + feeAmt))));

                        decimal resultPercent;
                        if (buyUSD + feeAmt != 0m) {
                            if (SettingsInfo.R.tb_sellNowProfitPercent != 0)
                                resultPercent = Math.Round((((Revenue + sellUSD) / (buyUSD + feeAmt)) - 1m) * 100m, SettingsInfo.R.tb_sellNowProfitPercent);
                            else
                                resultPercent = (((Revenue + sellUSD) / (buyUSD + feeAmt)) - 1m) * 100m;
                        } else {
                            resultPercent = 0m;
                        }

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

        /// <summary>
        /// Profit info (show your work) button.
        /// </summary>
        private async void SellAllProfitInfoButton_Click(object sender, EventArgs e)
        {
            decimal totalBTC = 0m;
            decimal buyUSD = 0m;
            decimal sellUSD = 0m;
            decimal feeAmt = 0m;
            decimal CurrPriceBTC;
            decimal FeeMultiplier;
            decimal Revenue;

            if (DataGridView1.Rows.Count > 0) {

                bool semSuccess = false;
                await LockUpdates.WaitAsync();
                try {
                    ComputetotalBTCandUSD(ref totalBTC, ref buyUSD, ref sellUSD, ref feeAmt);

                    if (IsNumeric(CurrPriceBTCTextBox.Text)) {
                        CurrPriceBTC = Convert.ToDecimal(CurrPriceBTCTextBox.Text);
                    } else
                        CurrPriceBTC = 0m;

                    if (IsNumeric(SellAllNowProfitFeeTextBox.Text)) {
                        FeeMultiplier = 1m - (Convert.ToDecimal(SellAllNowProfitFeeTextBox.Text) / 100m);
                    } else
                        FeeMultiplier = 1m;

                    LockUpdates.Release();
                    semSuccess = true;

                    Revenue = ((totalBTC * CurrPriceBTC) * FeeMultiplier);

                    decimal resultPercent;
                    if (buyUSD != 0) {
                        if (SettingsInfo.R.tb_sellNowProfitPercent != 0)
                            resultPercent = Math.Round((((Revenue + sellUSD) / (buyUSD + feeAmt)) - 1m) * 100m, SettingsInfo.R.tb_sellNowProfitPercent);
                        else
                            resultPercent = (((Revenue + sellUSD) / (buyUSD + feeAmt)) - 1m) * 100m;
                    } else {
                        resultPercent = 0m;
                    }

                    decimal result1;
                    if (SettingsInfo.R.tb_sellNowProfitNum != 0)
                        result1 = Math.Round(Revenue + (sellUSD - (buyUSD + feeAmt)), SettingsInfo.R.tb_sellNowProfitNum);
                    else
                        result1 = Revenue + (sellUSD - (buyUSD + feeAmt));

                    string cur = CurrencyTypeComboBox.Text;
                    string type = CryptoList.CurrentCryptoType;
                    Interaction.MsgBox("[ ( " + totalBTC + " " + type + " * $" + CurrPriceBTC + " ) * " + FeeMultiplier + " ] + ( $" + sellUSD + " - ($" + buyUSD + " + " + feeAmt + ") ) = $" +
                            result1 + Environment.NewLine +
                            "[ (Total " + type + " * Current " + type + " Price) * Fee Multiplier ] + ( Sell " + cur + " - (Buy " + cur + " + Fees) ) = Total Profit" + Environment.NewLine + Environment.NewLine +
                            "( [ ( [ ( " + totalBTC + " " + type + " * $" + CurrPriceBTC + " ) * " + FeeMultiplier + " ] + " + sellUSD + " ) / (" + buyUSD + " + " + feeAmt + ") ] - 1 ) * 100 = " + resultPercent + Environment.NewLine +
                            "( [ ( [ ( Total " + type + " * Current " + type + " Price ) * Fee Multiplier ] + Sell " + cur + " ) / (Buy " + cur + " + Fees) ] - 1 ) * 100 = Percentage Change");
                } catch {
                    if (!semSuccess)
                        LockUpdates.Release();
                    Interaction.MsgBox("Unable to calculate.");
                }
            } else {
                Interaction.MsgBox("0");
            }
        }

        /// <summary>
        /// Computes the total bitcoin, total buy, and sell money.
        /// </summary>
        private void ComputetotalBTCandUSD(ref decimal totalBTC)
        {
            decimal buyUSD = 0m;
            decimal sellUSD = 0m;
            decimal feeAmt = 0m;
            ComputetotalBTCandUSD(ref totalBTC, ref buyUSD, ref sellUSD, ref feeAmt);
        }
        /// <summary>
        /// Computes the total bitcoin, total buy, and sell money.
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
        /// Update total Bitcoin TextBox
        /// </summary>
        public void UpdateTotalBitcoins()
        {
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
            if (!string.IsNullOrEmpty(NewMoneyType)) {
                CurrentMoneyType = NewMoneyType;
                try {
                    DataGridView1.Columns[3].HeaderText = DataGridView1.Columns[3].HeaderText.Replace(OldMoneyType, NewMoneyType);
                    DataGridView1.Columns[3].ToolTipText = DataGridView1.Columns[3].ToolTipText.Replace(OldMoneyType, NewMoneyType);
                    DataGridView1.Columns[7].HeaderText = DataGridView1.Columns[7].HeaderText.Replace(OldMoneyType, NewMoneyType);

                    foreach (NewBuySell form in newBuySell) {
                        if (form != null && form.Visible) {
                            form.Label2.Text = NewMoneyType;
                        }
                    }

                    if (settingsForm != null && settingsForm.Visible) {
                        settingsForm.label19.Text = NewMoneyType;
                    }
                } catch { }
            } else if (!string.IsNullOrEmpty(OldMoneyType)) {
                CurrencyTypeComboBox.Text = OldMoneyType;
            }
        }

        /// <summary>
        /// Holds current value of CurrencyTypeComboBox.Text
        /// </summary>
        public string CurrentMoneyType = "";
        /// <summary>
        /// Change the current currency in use for bitcoin price and display purposes.
        /// </summary>
        private async void CurrencyTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Loading) {
                UpdateRateTimer.Stop();

                await LockUpdates.WaitAsync();
                await LockPriceAlertTimer.WaitAsync();

                ChangeColumnLabelCurrency(CurrencyTypeComboBox.Text, CurrentMoneyType);

                LockPriceAlertTimer.Release();
                LockUpdates.Release();

                waitUpdateTimer.Stop();
                waitUpdateTimer.Interval = 150;
                waitUpdateTimer.Start();
            }
        }

        void CurrencyTypeComboBox_MouseWheel(object sender, MouseEventArgs e)
        {
            if (!CurrencyTypeComboBox.DroppedDown) {
                ((HandledMouseEventArgs)e).Handled = true;
            }
        }

        private void CurrPriceBTCTextBox_TextChanged(object sender, EventArgs e)
        {
            if (Timer1Paused) {
                PerformUpdatesThread();
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
                PerformUpdatesThread();
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

                decimal btc;
                decimal usd;
                decimal exchangeRate;
                switch (e.ColumnIndex) {
                    case 3: // usd
                        if (decimal.TryParse(Convert.ToString(DataGridView1[2, e.RowIndex].Value), out btc) &&
                            decimal.TryParse(Convert.ToString(DataGridView1[3, e.RowIndex].Value), out usd)) {
                            DataGridView1[3, e.RowIndex].Value = DataGridView1[3, e.RowIndex].Value.RemoveTrailingZeroes();
                            DataGridView1[6, e.RowIndex].Value = ((1m / btc) * usd).RemoveTrailingZeroes();
                        }
                        break;
                    case 2: // btc
                        DataGridView1[2, e.RowIndex].Value = DataGridView1[2, e.RowIndex].Value.RemoveTrailingZeroes();
                        goto ExRate;
                    case 6: // Exchange Rate
                        DataGridView1[6, e.RowIndex].Value = DataGridView1[6, e.RowIndex].Value.RemoveTrailingZeroes();
                        ExRate:
                        if (decimal.TryParse(Convert.ToString(DataGridView1[2, e.RowIndex].Value), out btc) &&
                            decimal.TryParse(Convert.ToString(DataGridView1[6, e.RowIndex].Value), out exchangeRate)) {
                            DataGridView1[3, e.RowIndex].Value = (btc * exchangeRate).RemoveTrailingZeroes();
                        }
                        break;
                    default:
                        break;
                }

                if (DataGridUserEdit) {
                    DataGridUserEdit = false;

                    PerformUpdatesThread();
                }
            }
        }

        private async void DataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (!Loading) {
                await LockUpdates.WaitAsync();
            }
        }

        private void DataGridView1_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            if (!Loading) {
                LockUpdates.Release();
                if (DataGridView1.SelectedRows.Count == 0) {
                    PerformUpdatesThread();
                }
            }
        }

        static About about;
        public void AboutButton_Click(object sender, EventArgs e)
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

        private async void PriceAlertTimer_Tick(object sender, EventArgs e)
        {
            await LockPriceAlertTimer.WaitAsync();
            var with = CryptoList.CryptoRows[CryptoList.CurrentCryptoType];
            if ((with.PriceAlertsG.Count == 0 && with.PriceAlertsL.Count == 0) || (Timer1Paused || !with.PriceAlertsEnabled)) {
                PriceAlertTimer.Stop();
                LockPriceAlertTimer.Release();
                return;
            }

            decimal currPrice;
            if (decimal.TryParse(CurrPriceBTCTextBox.Text, out currPrice)) {
                if (with.PriceAlertsG.Count > 0)
                    if (currPrice >= Convert.ToDecimal(with.PriceAlertsG[0])) {
                        SystemSounds.Asterisk.Play();
                        LockPriceAlertTimer.Release();
                        return;
                    }
                if (with.PriceAlertsL.Count > 0)
                    if (currPrice <= Convert.ToDecimal(with.PriceAlertsL[0])) {
                        SystemSounds.Asterisk.Play();
                        LockPriceAlertTimer.Release();
                        return;
                    }
            }

            LockPriceAlertTimer.Release();
        }

        public void alertsButton_Click(object sender, EventArgs e)
        {
            if (alerts == null) {
                alerts = new Alerts(this);
                alerts.Show();
            } else {
                if (!alerts.Visible) {
                    alerts = new Alerts(this);
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
            if (notificationIcon1 == null)
                notificationIcon1 = new NotificationIcon(this);
            notificationIcon1.notifyIcon.Text = CurrPriceBTCTextBox.Text + " (" + CryptoList.CurrentCryptoType + ")";
            MinimizeButtonFlag = true;
            WindowState = FormWindowState.Minimized;

            if (settingsForm != null)
                settingsForm.Close();
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
                if (notificationIcon1 != null)
                    notificationIcon1.notifyIcon.Visible = true;
                Hide();
            } else if (WindowState == FormWindowState.Normal) {
                if (notificationIcon1 != null)
                    notificationIcon1.notifyIcon.Visible = false;
                InTrayFlag = false;
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

        private async void CryptoTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Loading) {
                UpdateRateTimer.Stop();

                await LockUpdates.WaitAsync();
                await LockPriceAlertTimer.WaitAsync();

                string newCryptoType = CryptoTypeComboBox.Text;
                CryptoList.SaveCurrentCrypto(this);
                CryptoList.LoadCrypto(this, newCryptoType);

                LockPriceAlertTimer.Release();
                LockUpdates.Release();

                waitUpdateTimer.Stop();
                waitUpdateTimer.Interval = 100;
                waitUpdateTimer.Start();
            }
        }

        void CryptoTypeComboBox_MouseWheel(object sender, MouseEventArgs e)
        {
            if (!CryptoTypeComboBox.DroppedDown) {
                ((HandledMouseEventArgs)e).Handled = true;
            }
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            if (settingsForm == null) {
                settingsForm = new SettingsForm(this);
                settingsForm.Show();
            } else {
                if (!settingsForm.Visible) {
                    settingsForm = new SettingsForm(this);
                    settingsForm.Show();
                } else {
                    settingsForm.TopMost = true;
                    settingsForm.TopMost = false;
                }
            }
        }

        /// <summary>
        /// Wait for a duration before updating exchange price.
        /// </summary>
        private void waitUpdateTimer_Tick(object sender, EventArgs e)
        {
            waitUpdateTimer.Stop();
            UpdateRateTimer_Tick(sender, e);
        }
    }
}

