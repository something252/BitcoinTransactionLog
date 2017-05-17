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
            Icon = Properties.Resources.icon50;

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

            if (IsNumeric(mainForm.SellAllNowProfitFeeTextBox.Text)) {
                FeeChargedTextBox.Text = mainForm.SellAllNowProfitFeeTextBox.Text;
            }

            Loading = false;
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (Convert.ToString(ComboBox1.SelectedItem) == "LOSS" || Convert.ToString(ComboBox1.SelectedItem) == "GAIN") {
                FeeChargedTextBox.Text = "";
                FeeChargedTextBox.Enabled = false;

                BTCExchangeRateTextBox.Text = "";
                BTCExchangeRateTextBox.Enabled = false;

                USDTextBox.Text = "";
                USDTextBox.Enabled = false;

                BTCExchangerateLockCheckBox.Enabled = false;
            } else {
                FeeChargedTextBox.Enabled = true;
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
                if (!IsNumeric(BTCTextBox.Text)) {
                    MessageBox.Show("BTC TextBox is not numeric!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } else if (!IsNumeric(USDTextBox.Text)) {
                    MessageBox.Show("USD TextBox is not numeric!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } else if (!IsNumeric(FeeChargedTextBox.Text)) {
                    MessageBox.Show("Fee Charged TextBox is not numeric!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } else if (!IsNumeric(BTCExchangeRateTextBox.Text)) {
                    MessageBox.Show("BTC Exchange Rate TextBox is not numeric!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } else { // all is well
                    CreateRow();
                }
            } else if (Convert.ToString(ComboBox1.SelectedItem) == "LOSS" || Convert.ToString(ComboBox1.SelectedItem) == "GAIN") {
                if (!IsNumeric(BTCTextBox.Text)) {
                    MessageBox.Show("BTC TextBox is not numeric!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //} else if (!IsNumeric(USDTextBox.Text)) {
                    //    MessageBox.Show("USD TextBox is not numeric!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } else { // all is well
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
            string BTCTextBoxTemp = BTCTextBox.Text;
            string USDTextBoxTemp = USDTextBox.Text;
            string FeeTextBoxTemp = FeeChargedTextBox.Text;
            string BTCExchangeRateTextBoxTemp = BTCExchangeRateTextBox.Text;

            mainForm.DataGridView1.Rows.Add(ComboBox1.SelectedItem, DateTimePicker1.Value.Month + "/" + DateTimePicker1.Value.Day + "/" + DateTimePicker1.Value.Year
                                           + " " + DateTimePicker2.Value.Hour + ":" + DateTimePicker2.Value.Minute + ":" + DateTimePicker2.Value.Second + " " + Meridiem,
                                           BTCTextBoxTemp,
                                           USDTextBoxTemp,
                                           FeeTextBoxTemp,
                                           BTCExchangeRateTextBoxTemp);
            mainForm.PerformUpdates();

            this.Close();
        }

        private void BTCAndUSD_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToString(ComboBox1.SelectedItem) != "LOSS" && Convert.ToString(ComboBox1.SelectedItem) != "GAIN") {
                if (BTCExchangerateLockCheckBox.Checked) {
                    decimal btc = 0m;
                    if (IsNumeric(BTCTextBox.Text)) {
                        btc = Convert.ToDecimal(BTCTextBox.Text);
                    }
                    decimal usd = 0m;
                    if (IsNumeric(USDTextBox.Text)) {
                        usd = Convert.ToDecimal(USDTextBox.Text);
                    }
                    decimal feeMultiplier = 1m;
                    if (IsNumeric(FeeChargedTextBox.Text)) {
                        feeMultiplier = 1m - (Convert.ToDecimal(FeeChargedTextBox.Text) / 100m);
                    }

                    try {
                        if (btc == 0m || feeMultiplier == 0m)
                            BTCExchangeRateTextBox.Text = "0.0";
                        else
                            BTCExchangeRateTextBox.Text = Convert.ToString(Math.Round((1m / btc) * (usd / feeMultiplier), 2));
                    } catch {
                        BTCExchangeRateTextBox.Text = "Error";
                    }
                } else {
                    if (sender == FeeChargedTextBox) {
                        BTCExchangeRateTextBox_TextChanged(BTCExchangeRateTextBox, e);
                    }
                }
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
                        decimal fee;
                        if (IsNumeric(FeeChargedTextBox.Text)) {
                            fee = 1m - (Convert.ToDecimal(FeeChargedTextBox.Text) / 100m);
                        } else {
                            fee = 1m;
                        }

                        try {
                            if (btc != 0m) {
                                USDTextBox.Text = Convert.ToString((exRate / (1m / btc)) * fee);
                            } else {
                                USDTextBox.Text = "0.0";
                            }
                        } catch { // System.OverflowException
                            USDTextBox.Text = "Too Large";
                        }
                    }
                }
            }
        }
    }
}
