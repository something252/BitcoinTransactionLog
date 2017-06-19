using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Bitcoin_Transaction_Log.Methods1;

namespace Bitcoin_Transaction_Log
{
    public partial class NewBuySell : Form
    {
        static MainForm mainForm;
        bool Loading = true;

        public NewBuySell(MainForm form)
        {
            InitializeComponent();
            mainForm = form;
        }

        private void NewBuySell_Load(object sender, EventArgs e)
        {
            if (mainForm.CryptoList.CurrentCryptoType == "ETH")
                Icon = Properties.Resources.Ethereum32icon;
            else if (mainForm.CryptoList.CurrentCryptoType == "LTC")
                Icon = Properties.Resources.Litecoin32icon;
            else
                Icon = Properties.Resources.Bitcoin50;

            ComboBox1.Items.Add("BUY");
            ComboBox1.Items.Add("SELL");
            ComboBox1.Items.Add("LOSS");
            ComboBox1.Items.Add("GAIN");

            if (mainForm.CurrencyTypeComboBox.Text == "USD") {
                Label2.Text = mainForm.CurrencyTypeComboBox.Text + " ($)";
            } else if (string.IsNullOrEmpty(mainForm.CurrencyTypeComboBox.Text)) {
                Label2.Location = new Point(Label2.Location.X + 12, Label2.Location.Y);
                Label2.Text = mainForm.CurrencyTypeComboBox.Text;
            }

            Label1.Text = mainForm.CryptoList.CurrentCryptoType;
            Label4.Text = Label4.Text.Replace("BTC", mainForm.CryptoList.CurrentCryptoType);

            if (IsNumeric(mainForm.SellAllNowProfitFeeTextBox.Text)) {
                FeePercentTextBox.Text = mainForm.SellAllNowProfitFeeTextBox.Text;
            }

            Loading = false;
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (Convert.ToString(ComboBox1.SelectedItem) == "LOSS" || Convert.ToString(ComboBox1.SelectedItem) == "GAIN") {
                FeeAmountTextBox.Text = "";
                FeeAmountTextBox.Enabled = false;

                FeePercentTextBox.Text = "";
                FeePercentTextBox.Enabled = false;

                BTCExchangeRateTextBox.Text = "";
                BTCExchangeRateTextBox.Enabled = false;

                USDTextBox.Text = "";
                USDTextBox.Enabled = false;

                BTCExchangerateLockCheckBox.Enabled = false;
            } else {
                FeeAmountTextBox.Enabled = true;
                FeePercentTextBox.Enabled = true;
                BTCExchangeRateTextBox.Enabled = true;
                USDTextBox.Enabled = true;
                BTCExchangerateLockCheckBox.Enabled = true;
            }
            string name = (ComboBox1.SelectedItem.ToString()).ToLower();
            name = name[0].ToString().ToUpper() + name.Substring(1);
            this.Text = "New " + name;
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(ComboBox1.SelectedItem) == "BUY" || Convert.ToString(ComboBox1.SelectedItem) == "SELL") {
                if (string.IsNullOrEmpty(FeePercentTextBox.Text)) {
                    FeePercentTextBox.Text = "0";
                }

                if (!IsNumeric(BTCTextBox.Text)) {
                    Interaction.MsgBox(Label1.Text + " TextBox is not numeric!", MsgBoxStyle.Critical, "Warning");
                } else if (!IsNumeric(USDTextBox.Text)) {
                    Interaction.MsgBox(Label2.Text + " TextBox is not numeric!", MsgBoxStyle.Critical, "Warning");
                } else if (!IsNumeric(FeePercentTextBox.Text)) {
                    Interaction.MsgBox("Fee Charged TextBox is not numeric!", MsgBoxStyle.Critical, "Warning");
                } else if (!IsNumeric(BTCExchangeRateTextBox.Text)) {
                    Interaction.MsgBox(Label1.Text + " Exchange Rate TextBox is not numeric!", MsgBoxStyle.Critical, "Warning");
                } else {
                    CreateRow();
                }
            } else if (Convert.ToString(ComboBox1.SelectedItem) == "LOSS" || Convert.ToString(ComboBox1.SelectedItem) == "GAIN") {
                if (!IsNumeric(BTCTextBox.Text)) {
                    Interaction.MsgBox(Label1.Text + " TextBox is not numeric!", MsgBoxStyle.Critical, "Warning");
                    //} else if (!IsNumeric(USDTextBox.Text)) {
                    //    Interaction.MsgBox(Label2.Text + " TextBox is not numeric!", "Warning", MsgBoxStyle.Critical, "Warning");
                } else {
                    CreateRow();
                }
            }
        }

        private void CreateRow()
        {
            string Meridiem;
            if (DateTimePicker2.Value.Hour < 12) {
                Meridiem = "AM";
            } else {
                Meridiem = "PM";
            }

            mainForm.DataGridView1.Rows.Add(ComboBox1.SelectedItem, DateTimePicker1.Value.Month + "/" + DateTimePicker1.Value.Day + "/" + DateTimePicker1.Value.Year
                                           + " " + DateTimePicker2.Value.Hour + ":" + DateTimePicker2.Value.Minute + ":" + DateTimePicker2.Value.Second + " " + Meridiem,
                                           BTCTextBox.Text,
                                           USDTextBox.Text,
                                           FeeAmountTextBox.Text,
                                           FeePercentTextBox.Text,
                                           BTCExchangeRateTextBox.Text);
            mainForm.PerformUpdates();

            this.Close();
        }

        bool TextChanged_Locked = false;
        private void BTCAndUSD_TextChanged(object sender, EventArgs e)
        {
            if (!TextChanged_Locked) {
                TextChanged_Locked = true;

                try {
                    if (Convert.ToString(ComboBox1.SelectedItem) != "LOSS" && Convert.ToString(ComboBox1.SelectedItem) != "GAIN") {
                        decimal btc = 0m;
                        if (IsNumeric(BTCTextBox.Text)) {
                            btc = Convert.ToDecimal(BTCTextBox.Text);
                        }
                        decimal usd = 0m;
                        if (IsNumeric(USDTextBox.Text)) {
                            usd = Convert.ToDecimal(USDTextBox.Text);
                        }
                        decimal exchangeRate = 0m;
                        if (IsNumeric(BTCExchangeRateTextBox.Text)) {
                            exchangeRate = Convert.ToDecimal(BTCExchangeRateTextBox.Text);
                        }

                        if (!BTCExchangerateLockCheckBox.Checked) {

                            if (sender.Equals(BTCTextBox)) {
                                if (!string.IsNullOrEmpty(BTCExchangeRateTextBox.Text)) {
                                    try {
                                        USDTextBox.Text = Convert.ToString(Math.Round((btc * exchangeRate), 5));
                                    } catch {
                                        USDTextBox.Text = "Error";
                                    }
                                }
                            } else if (sender.Equals(USDTextBox)) {
                                try {
                                    if (btc == 0m)
                                        BTCExchangeRateTextBox.Text = "0.0";
                                    else
                                        BTCExchangeRateTextBox.Text = Convert.ToString(Math.Round((1m / btc) * (usd), 2));
                                } catch {
                                    BTCExchangeRateTextBox.Text = "Error";
                                }
                            }

                            try {
                                if (IsNumeric(USDTextBox.Text)) {
                                    FeeAmountTextBox.Text = Convert.ToString(Math.Round(usd * (Convert.ToDecimal(FeePercentTextBox.Text) / 100m), 2));
                                } else {
                                    FeeAmountTextBox.Text = "";
                                }
                            } catch {
                                FeeAmountTextBox.Text = "Error";
                            }

                        } else {

                            try {
                                if (btc == 0m)
                                    BTCExchangeRateTextBox.Text = "0.0";
                                else
                                    BTCExchangeRateTextBox.Text = Convert.ToString(Math.Round((1m / btc) * (usd), 2));
                            } catch {
                                BTCExchangeRateTextBox.Text = "Error";
                            }

                        }

                        UpdateFeeAmountTextBox();
                    }
                } catch {
                }

                TextChanged_Locked = false;
            }
        }

        private void BTCExchangerateLockCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!Loading) {
                if (BTCExchangerateLockCheckBox.Checked) {
                    BTCExchangeRateTextBox.ReadOnly = true;
                    BTCAndUSD_TextChanged(sender, e);
                } else {
                    BTCExchangeRateTextBox.ReadOnly = false;
                }
            }
        }

        private void BTCExchangeRateTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!TextChanged_Locked) {
                TextChanged_Locked = true;

                try {
                    if (Convert.ToString(ComboBox1.SelectedItem) != "LOSS" && Convert.ToString(ComboBox1.SelectedItem) != "GAIN") {
                        if (!BTCExchangerateLockCheckBox.Checked) {
                            if (!string.IsNullOrEmpty(BTCTextBox.Text)) {
                                decimal btc;
                                if (IsNumeric(BTCTextBox.Text)) {
                                    btc = Convert.ToDecimal(BTCTextBox.Text);
                                } else {
                                    btc = 0m;
                                }
                                decimal exRate;
                                if (IsNumeric(BTCExchangeRateTextBox.Text)) {
                                    exRate = Convert.ToDecimal(BTCExchangeRateTextBox.Text);
                                } else {
                                    exRate = 0m;
                                }
                                try {
                                    if (btc != 0m) {
                                        USDTextBox.Text = Convert.ToString(Math.Round((exRate / (1m / btc)), 5));
                                    } else {
                                        USDTextBox.Text = "0.0";
                                    }
                                } catch { // System.OverflowException
                                    USDTextBox.Text = "Too Large";
                                }
                                UpdateFeeAmountTextBox();
                            }
                        }
                    }
                } catch (Exception ex) {
                    Interaction.MsgBox(ex.Message);
                }

                TextChanged_Locked = false;
            }
        }

        private void UpdateFeeAmountTextBox()
        {
            try {
                FeeAmountTextBox.Text = Convert.ToString(Math.Round(Convert.ToDecimal(USDTextBox.Text) * (Convert.ToDecimal(FeePercentTextBox.Text) / 100m), 4));
            } catch {
                FeeAmountTextBox.Text = "";
            }
        }
    }
}
