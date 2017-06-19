using Microsoft.VisualBasic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Windows.Forms;

namespace Bitcoin_Transaction_Log
{
    public class CryptoMain
    {
        public Dictionary<string, CryptoSettings> CryptoRows = new Dictionary<string, CryptoSettings>();

        private CryptoNames LastCryptoName = CryptoNames.Bitcoin;
        private CryptoNames _currentCryptoName = CryptoNames.Bitcoin;
        public CryptoNames CurrentCryptoName
        {
            get {
                return _currentCryptoName;
            }
            private set {
                if (!MainForm.Loading)
                    LastCryptoName = _currentCryptoName;
                _currentCryptoName = value;
            }
        }
        public enum CryptoNames
        {
            Bitcoin = 0,
            Ethereum = 1,
            Litecoin = 2
        };


        private string LastCryptoType = "BTC";
        private string _currentCryptoType = "BTC";
        public string CurrentCryptoType
        {
            get {
                if (string.IsNullOrEmpty(_currentCryptoType)) {
                    CurrentCryptoName = CryptoNames.Bitcoin;
                    return "BTC";
                } else {
                    return _currentCryptoType;
                }
            }
            private set {
                if (!MainForm.Loading)
                    LastCryptoType = _currentCryptoType;

                _currentCryptoType = value;

                switch (_currentCryptoType) {
                    case "ETH":
                        CurrentCryptoName = CryptoNames.Ethereum;
                        break;
                    case "LTC":
                        CurrentCryptoName = CryptoNames.Litecoin;
                        break;
                    case "BTC":
                    default:
                        CurrentCryptoName = CryptoNames.Bitcoin;
                        break;
                }
            }
        }

        public CryptoMain()
        {

        }

        /// <summary>
        /// Load or create new cryptocurrency.
        /// </summary>
        public void LoadCrypto(MainForm mainForm, string LoadCryptoType)
        {
            if (mainForm != null) {
                mainForm.PriceAlertTimer.Stop();

                if (string.IsNullOrEmpty(LoadCryptoType))
                    CurrentCryptoType = "BTC";
                else
                    CurrentCryptoType = LoadCryptoType;

                bool containsCrypto = false;
                if (CryptoRows.ContainsKey(CurrentCryptoType)) {
                    containsCrypto = true;
                } else {
                    CryptoRows.Add(CurrentCryptoType, new CryptoSettings());
                }
                if (CryptoRows[CurrentCryptoType].PriceAlertsG == null)
                    CryptoRows[CurrentCryptoType].PriceAlertsG = new List<decimal>();
                if (CryptoRows[CurrentCryptoType].PriceAlertsL == null)
                    CryptoRows[CurrentCryptoType].PriceAlertsL = new List<decimal>();

                UpdateDisplayItems(mainForm);

                LoadDataGridViewRows(CurrentCryptoType, containsCrypto, mainForm.DataGridView1);

                mainForm.StartAlertsTimer();
            }
        }

        /// <summary>
        /// Save to current cryptocurrency.
        /// </summary>
        public void SaveCurrentCrypto(MainForm mainForm)
        {
            if (mainForm != null) {
                if (mainForm.CryptoList == null)
                    mainForm.CryptoList = new CryptoMain();

                if (mainForm.CryptoList.CryptoRows.Count > 0 && mainForm.CryptoList.CryptoRows.ContainsKey(CurrentCryptoType)) {
                    mainForm.CryptoList.CryptoRows[CurrentCryptoType].Rows = GetDataGridViewRows(mainForm.DataGridView1);
                } else {
                    CryptoSettings newCrypto = new CryptoSettings();
                    newCrypto.Rows = GetDataGridViewRows(mainForm.DataGridView1);
                    mainForm.CryptoList.CryptoRows.Add(CurrentCryptoType, newCrypto);
                }
            }
        }

        /// <summary>
        /// Load given cryptocurrency DataGridView rows.
        /// </summary>
        private void LoadDataGridViewRows(string CryptoType, bool containsCrypto, DataGridView DataGridView1)
        {
            DataGridView1.Rows.Clear();
            if (containsCrypto) {
                for (int i = 0; i < CryptoRows[CryptoType].Rows.Count; i++) {
                    DataGridView1.Rows.Add();
                    try {
                        DataGridView1[0, i].Value = CryptoRows[CryptoType].Rows[i].Transaction;
                        DataGridView1[1, i].Value = CryptoRows[CryptoType].Rows[i].Date;
                        DataGridView1[2, i].Value = CryptoRows[CryptoType].Rows[i].BTC;
                        DataGridView1[3, i].Value = CryptoRows[CryptoType].Rows[i].USD;
                        DataGridView1[5, i].Value = CryptoRows[CryptoType].Rows[i].Fee;
                        DataGridView1[6, i].Value = CryptoRows[CryptoType].Rows[i].ExchangeRate;
                        DataGridView1[10, i].Value = CryptoRows[CryptoType].Rows[i].Disabled;
                        DataGridView1[11, i].Value = CryptoRows[CryptoType].Rows[i].Comments;
                    } catch { }
                }
            }
        }

        public static List<DataGridSettingsRow> GetDataGridViewRows(DataGridView DataGridView1)
        {
            List<DataGridSettingsRow> NewList = new List<DataGridSettingsRow>();
            if (DataGridView1 != null)
                for (int i = 0; i <= DataGridView1.Rows.Count - 1; i++) {
                    try {
                        NewList.Add(new DataGridSettingsRow(DataGridView1[0, i].Value, DataGridView1[1, i].Value,
                            DataGridView1[2, i].Value, DataGridView1[3, i].Value, DataGridView1[5, i].Value,
                            DataGridView1[6, i].Value, DataGridView1[10, i].Value, DataGridView1[11, i].Value));
                    } catch {
                    }
                }
            return NewList;
        }

        /// <summary>
        /// Update/change visual elements in interface.
        /// </summary>
        private void UpdateDisplayItems(MainForm mainForm)
        {
            var m = mainForm;
            switch (CurrentCryptoType) {
                case "BTC":
                    m.Label7.Text = "Total Bitcoins";
                    m.Icon = Properties.Resources.Bitcoin50;
                    m.CryptoPictureBox1.BackgroundImage = Properties.Resources.bitcoin2;
                    m.CryptoPictureBox2.BackgroundImage = Properties.Resources.bitcoin2;
                    m.ToolTip1.SetToolTip(m.CryptoPictureBox1, "Bitcoins (BTC)");
                    m.ToolTip1.SetToolTip(m.CryptoPictureBox2, "Bitcoins (BTC)");
                    if (MainForm.alerts != null)
                        MainForm.alerts.Icon = Properties.Resources.Bitcoin50;
                    break;
                case "ETH":
                    m.Label7.Text = "Total Ethereum";
                    m.Icon = Properties.Resources.Ethereum32icon;
                    m.CryptoPictureBox1.BackgroundImage = Properties.Resources.Ethereum32;
                    m.CryptoPictureBox2.BackgroundImage = Properties.Resources.Ethereum32;
                    m.ToolTip1.SetToolTip(m.CryptoPictureBox1, "Ethereum (ETH)");
                    m.ToolTip1.SetToolTip(m.CryptoPictureBox2, "Ethereum (ETH)");
                    if (MainForm.alerts != null)
                        MainForm.alerts.Icon = Properties.Resources.Ethereum32icon;
                    break;
                case "LTC":
                    m.Label7.Text = "Total Litecoins";
                    m.Icon = Properties.Resources.Litecoin32icon;
                    m.CryptoPictureBox1.BackgroundImage = Properties.Resources.Litecoin32;
                    m.CryptoPictureBox2.BackgroundImage = Properties.Resources.Litecoin32;
                    m.ToolTip1.SetToolTip(m.CryptoPictureBox1, "Litecoins (LTC)");
                    m.ToolTip1.SetToolTip(m.CryptoPictureBox2, "Litecoins (LTC)");
                    if (MainForm.alerts != null)
                        MainForm.alerts.Icon = Properties.Resources.Litecoin32icon;
                    break;
                default:
                    break;
            }
            m.Text = m.Text.Replace(LastCryptoName.ToString(), CurrentCryptoName.ToString());
            m.DataGridView1.Columns[2].HeaderText = m.DataGridView1.Columns[2].HeaderText.Replace(LastCryptoType, CurrentCryptoType);
            m.DataGridView1.Columns[6].HeaderText = m.DataGridView1.Columns[6].HeaderText.Replace(LastCryptoType, CurrentCryptoType);
            if (MainForm.alerts != null)
                MainForm.alerts.label3.Text = MainForm.alerts.label3.Text.Replace(LastCryptoType, CurrentCryptoType);
            if (MainForm.newBuySell.Count > 0) {
                for (int i = 0; i < MainForm.newBuySell.Count; i++) {
                    MainForm.newBuySell[i].Label1.Text = CurrentCryptoType;
                    MainForm.newBuySell[i].Label4.Text = MainForm.newBuySell[i].Label4.Text.Replace(LastCryptoType, CurrentCryptoType);
                    if (CurrentCryptoType == "ETH")
                        MainForm.newBuySell[i].Icon = Properties.Resources.Ethereum32icon;
                    else if (CurrentCryptoType == "LTC")
                        MainForm.newBuySell[i].Icon = Properties.Resources.Litecoin32icon;
                    else // BTC
                        MainForm.newBuySell[i].Icon = Properties.Resources.Bitcoin50;
                }
            }
            m.UpdatingInProgressStr = m.UpdatingInProgressStr.Replace(LastCryptoName.ToString(), CurrentCryptoName.ToString());
            m.UpdatingPausedStr = m.UpdatingInProgressStr.Replace(LastCryptoName.ToString(), CurrentCryptoName.ToString());
            m.UpdatingStoppedStr = m.UpdatingInProgressStr.Replace(LastCryptoName.ToString(), CurrentCryptoName.ToString());

            if (MainForm.Loading)
                m.CryptoTypeComboBox.Text = CurrentCryptoType;
        }
    }
}
