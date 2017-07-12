using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bitcoin_Transaction_Log
{
    public class SettingsClass
    {
        public SettingsClass(MainForm mainForm)
        {
            if (mainForm != null) {
                DataGridRowPrimaryFont = mainForm.DataGridView1.DefaultCellStyle.Font;
                DataGridColumnHeadersFont = mainForm.DataGridView1.ColumnHeadersDefaultCellStyle.Font;
            }
        }

        /// <summary>
        /// Rounding values
        /// </summary>
        public class Rounding
        {
            // Data columns
            public int dc_feeNum = 2;
            public int dc_exchangeRate = 2;
            public int dc_percentInc = 2;
            public int dc_sellNowProfit = 2;
            public int dc_breakEvenPoint = 2;

            // Top bar
            public int tb_profitBreakEven = 2;
            public int tb_breakEven = 2;
            public int tb_sellNowRevenue = 2;
            public int tb_sellNowProfitNum = 2;
            public int tb_sellNowProfitPercent = 2;

            // New buy/sell form
            public int nbs_usd = 5;
            public int nbs_exchangeRate = 2;
            public int nbs_feeAmt = 5;
        }
        /// <summary>
        /// Stores rounding values
        /// </summary>
        public Rounding R = new Rounding();

        public Font DataGridRowPrimaryFont;
        public Font DataGridColumnHeadersFont;

        /// <summary>
        /// Set main form to match settings.
        /// </summary>
        public void LoadMainForm(MainForm mainForm)
        {
            if (mainForm != null) {
                if (DataGridRowPrimaryFont != null) {
                    mainForm.DataGridView1.AlternatingRowsDefaultCellStyle.Font = DataGridRowPrimaryFont;
                    mainForm.DataGridView1.RowsDefaultCellStyle.Font = DataGridRowPrimaryFont;
                }
                if (DataGridColumnHeadersFont != null) {
                    mainForm.DataGridView1.ColumnHeadersDefaultCellStyle.Font = DataGridColumnHeadersFont;
                }
            }
        }

        /// <summary>
        /// Set settings form to match settings.
        /// </summary>
        public void LoadSettingsForm(SettingsForm f)
        {
            if (f != null) {
                f.numericUpDown4.Value = R.dc_feeNum;
                f.numericUpDown6.Value = R.dc_exchangeRate;
                f.numericUpDown3.Value = R.dc_percentInc;
                f.numericUpDown7.Value = R.dc_sellNowProfit;
                f.numericUpDown8.Value = R.dc_breakEvenPoint;

                f.numericUpDown16.Value = R.tb_profitBreakEven;
                f.numericUpDown15.Value = R.tb_breakEven;
                f.numericUpDown13.Value = R.tb_sellNowRevenue;
                f.numericUpDown12.Value = R.tb_sellNowProfitNum;
                f.numericUpDown9.Value = R.tb_sellNowProfitPercent;
                
                f.numericUpDown18.Value = R.nbs_usd;
                f.numericUpDown14.Value = R.nbs_exchangeRate;
                f.numericUpDown11.Value = R.nbs_feeAmt;
            }
        }

        /// <summary>
        /// Settings form NumericUpDown object value has changed.
        /// </summary>
        public void SettingsForm_ValueChanged(object sender)
        {
            if (sender != null) {
                NumericUpDown obj = (NumericUpDown)sender;

                int newValue = Convert.ToInt32(obj.Value);

                switch (obj.Name) {
                    case "numericUpDown4":
                        R.dc_feeNum = newValue;
                        break;
                    case "numericUpDown6":
                        R.dc_exchangeRate = newValue;
                        break;
                    case "numericUpDown3":
                        R.dc_percentInc = newValue;
                        break;
                    case "numericUpDown7":
                        R.dc_sellNowProfit = newValue;
                        break;
                    case "numericUpDown8":
                        R.dc_breakEvenPoint = newValue;
                        break;
                    case "numericUpDown16":
                        R.tb_profitBreakEven = newValue;
                        break;
                    case "numericUpDown15":
                        R.tb_breakEven = newValue;
                        break;
                    case "numericUpDown13":
                        R.tb_sellNowRevenue = newValue;
                        break;
                    case "numericUpDown12":
                        R.tb_sellNowProfitNum = newValue;
                        break;
                    case "numericUpDown9":
                        R.tb_sellNowProfitPercent = newValue;
                        break;
                    case "numericUpDown18":
                        R.nbs_usd = newValue;
                        break;
                    case "numericUpDown14":
                        R.nbs_exchangeRate = newValue;
                        break;
                    case "numericUpDown11":
                        R.nbs_feeAmt = newValue;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}