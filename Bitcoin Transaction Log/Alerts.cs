using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using static Bitcoin_Transaction_Log.Methods1;

namespace Bitcoin_Transaction_Log
{
    public partial class Alerts : Form
    {
        static MainForm mainForm;
        bool Loading = true;
        const int limit = 1000;
        const string toggleAlertsButtonDisabled = "Price alerts disabled";
        const string toggleAlertsButtonEnabled = "Price alerts enabled";

        public Alerts(MainForm form)
        {
            InitializeComponent();
            mainForm = form;
        }

        public void Alerts_Load(object sender, EventArgs e)
        {
            LoadCryptoInfo(mainForm.CryptoList.CurrentCryptoType);

            Loading = false;
        }

        public void Alerts_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        /// <summary>
        /// Load new crypto by updating this form.
        /// </summary>
        public void LoadCryptoInfo(string crypto)
        {
            if (Loading || !Loading && !string.IsNullOrEmpty(crypto)) {

                if (Loading) {
                    CryptoComboBox.Items.Clear();
                    foreach (string item in mainForm.CryptoTypeComboBox.Items) {
                        CryptoComboBox.Items.Add(item);
                    }
                    CryptoComboBox.Text = mainForm.CryptoList.CurrentCryptoType;
                } else {
                    CryptoComboChangeLock = true;
                    CryptoComboBox.Text = crypto;
                    CryptoComboChangeLock = false;
                }

                var with = mainForm.CryptoList.CryptoRows;
                if (!with.ContainsKey(crypto)) {
                    with.Add(crypto, new CryptoSettings());
                    if (with[crypto].PriceAlertsG == null)
                        with[crypto].PriceAlertsG = new List<decimal>();
                    if (with[crypto].PriceAlertsL == null)
                        with[crypto].PriceAlertsL = new List<decimal>();
                }

                if (crypto == "ETH")
                    Icon = Properties.Resources.Ethereum32icon;
                else if (crypto == "LTC")
                    Icon = Properties.Resources.Litecoin32icon;
                else // BTC
                    Icon = Properties.Resources.Bitcoin50;

                var with2 = mainForm.CryptoList.CryptoRows[crypto];

                addListBox1.Items.Clear();
                for (int i = 0; i <= with2.PriceAlertsG.Count - 1; i++) {
                    addListBox1.Items.Add(with2.PriceAlertsG[i]);
                }
                addListBox2.Items.Clear();
                for (int i = 0; i <= with2.PriceAlertsL.Count - 1; i++) {
                    addListBox2.Items.Add(with2.PriceAlertsL[i]);
                }

                if (!with2.PriceAlertsEnabled) {
                    toggleAlertsButton.Text = "Disabled";
                    toolTip1.SetToolTip(toggleAlertsButton, toggleAlertsButtonDisabled);
                } else {
                    toggleAlertsButton.Text = "Enabled";
                    toolTip1.SetToolTip(toggleAlertsButton, toggleAlertsButtonEnabled);
                }
            }
        }

        private async void addButton1_Click(object sender, EventArgs e)
        {
            decimal output;
            if (!string.IsNullOrEmpty(addTextBox1.Text)) {
                if (decimal.TryParse(addTextBox1.Text, out output)) {
                    if (addListBox2.Items.Count + addListBox1.Items.Count + 1 <= limit) {
                        var with = mainForm.CryptoList.CryptoRows[CryptoComboBox.Text];

                        // check if value already exists in lists
                        foreach (object o in addListBox1.Items) {
                            if (Convert.ToDecimal(o) == output) {
                                Interaction.MsgBox("Entered value already exists.");
                                addTextBox1.Text = "";
                                return;
                            }
                        }
                        foreach (object o in addListBox2.Items) {
                            if (Convert.ToDecimal(o) == output) {
                                Interaction.MsgBox("Entered value already exists.");
                                addTextBox1.Text = "";
                                return;
                            }
                        }

                        // insert/add to listbox
                        bool insertedList = false;
                        for (int i = 0; i <= addListBox1.Items.Count - 1; i++) {

                            if (output < Convert.ToDecimal(addListBox1.Items[i])) {
                                addListBox1.Items.Insert(i, output);
                                insertedList = true;
                                break;
                            }
                        }
                        if (!insertedList) {
                            addListBox1.Items.Add(output);
                        }

                        // insert/add to settings list
                        await mainForm.LockPriceAlertTimer.WaitAsync();
                        bool inserted = false;
                        for (int i = 0; i <= with.PriceAlertsG.Count - 1; i++) {
                            if (output < Convert.ToDecimal(with.PriceAlertsG[i])) {
                                with.PriceAlertsG.Insert(i, output);
                                inserted = true;
                                break;
                            }
                        }
                        if (!inserted) {
                            with.PriceAlertsG.Add(output);
                        }
                        mainForm.LockPriceAlertTimer.Release();

                        addTextBox1.Text = "";
                        mainForm.StartAlertsTimer();
                    } else {
                        Interaction.MsgBox("Alerts are limited to " + limit + ".");
                    }
                } else {
                    Interaction.MsgBox("Entered value is not a number.");
                }
            } else {
                Interaction.MsgBox("Entered value is blank.");
            }
        }

        private async void addButton2_Click(object sender, EventArgs e)
        {
            decimal output;
            if (!string.IsNullOrEmpty(addTextBox2.Text)) {
                if (decimal.TryParse(addTextBox2.Text, out output)) {
                    if (addListBox2.Items.Count + addListBox1.Items.Count + 1 <= limit) {
                        var with = mainForm.CryptoList.CryptoRows[CryptoComboBox.Text];

                        // check if value already exists in lists
                        foreach (object o in addListBox1.Items) {
                            if (Convert.ToDecimal(o) == output) {
                                Interaction.MsgBox("Entered value already exists.");
                                addTextBox2.Text = "";
                                return;
                            }
                        }
                        foreach (object o in addListBox2.Items) {
                            if (Convert.ToDecimal(o) == output) {
                                Interaction.MsgBox("Entered value already exists.");
                                addTextBox2.Text = "";
                                return;
                            }
                        }

                        // insert/add to listbox
                        bool insertedList = false;
                        for (int i = 0; i <= addListBox2.Items.Count - 1; i++) {

                            if (output > Convert.ToDecimal(addListBox2.Items[i])) {
                                addListBox2.Items.Insert(i, output);
                                insertedList = true;
                                break;
                            }
                        }
                        if (!insertedList) {
                            addListBox2.Items.Add(output);
                        }

                        // insert/add to settings list
                        await mainForm.LockPriceAlertTimer.WaitAsync();
                        bool inserted = false;
                        for (int i = 0; i <= with.PriceAlertsL.Count - 1; i++) {
                            if (output > Convert.ToDecimal(with.PriceAlertsL[i])) {
                                with.PriceAlertsL.Insert(i, output);
                                inserted = true;
                                break;
                            }
                        }
                        if (!inserted) {
                            with.PriceAlertsL.Add(output);
                        }
                        mainForm.LockPriceAlertTimer.Release();

                        addTextBox2.Text = "";
                        mainForm.StartAlertsTimer();
                    } else {
                        Interaction.MsgBox("Alerts are limited to " + limit + ".");
                    }
                } else {
                    Interaction.MsgBox("Entered value is not a number.");
                }
            } else {
                Interaction.MsgBox("Entered value is blank.");
            }
        }

        private void removeButton1_Click(object sender, EventArgs e)
        {
            if (addListBox1.SelectedItems.Count > 0)
                removeSelectedItems(addListBox1, true);
            else if (addListBox2.SelectedItems.Count > 0)
                removeSelectedItems(addListBox2, false);
            else
                System.Media.SystemSounds.Beep.Play();
        }

        private async void removeSelectedItems(ListBox lstBox, bool type)
        {
            if (lstBox.SelectedItems.Count > 0) {
                await mainForm.LockPriceAlertTimer.WaitAsync();
                var with = mainForm.CryptoList.CryptoRows[CryptoComboBox.Text];

                if (type) { // >= Price Alerts
                    if (with.PriceAlertsG != null) {
                        for (int i = lstBox.SelectedIndices.Count - 1; i >= 0; i--) {
                            with.PriceAlertsG.RemoveAt(lstBox.SelectedIndices[i]);
                        }
                    }
                } else { // <= Price Alerts
                    if (with.PriceAlertsL != null) {
                        for (int i = lstBox.SelectedIndices.Count - 1; i >= 0; i--) {
                            with.PriceAlertsL.RemoveAt(lstBox.SelectedIndices[i]);
                        }
                    }
                }

                ListBox.SelectedIndexCollection selectedIndices = new ListBox.SelectedIndexCollection(lstBox);
                int idx = 0;
                for (int k = selectedIndices.Count - 1; k >= 0; k--) {
                    idx = selectedIndices[k];
                    lstBox.Items.RemoveAt(selectedIndices[k]);
                }
                if (idx + 1 <= lstBox.Items.Count - 1) {
                    lstBox.SetSelected(idx, true);
                } else if (lstBox.Items.Count > 0) {
                    lstBox.SetSelected(lstBox.Items.Count - 1, true);
                }
                mainForm.LockPriceAlertTimer.Release();
            } else {
                Interaction.MsgBox("No item is selected.");
            }
        }

        private void toggleAlertsButton_Click(object sender, EventArgs e)
        {
            var with = mainForm.CryptoList.CryptoRows[CryptoComboBox.Text];
            if (toggleAlertsButton.Text == "Enabled") {
                with.PriceAlertsEnabled = false;
                toggleAlertsButton.Text = "Disabled";
                toolTip1.SetToolTip(toggleAlertsButton, toggleAlertsButtonDisabled);
            } else {
                with.PriceAlertsEnabled = true;
                toggleAlertsButton.Text = "Enabled";
                toolTip1.SetToolTip(toggleAlertsButton, toggleAlertsButtonEnabled);
            }
            mainForm.StartAlertsTimer();
        }

        bool lockSelectedIndexChanged = false;
        private void addListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!lockSelectedIndexChanged) {
                lockSelectedIndexChanged = !lockSelectedIndexChanged;
                addListBox2.ClearSelected();
                lockSelectedIndexChanged = !lockSelectedIndexChanged;
            }

        }

        private void addListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!lockSelectedIndexChanged) {
                lockSelectedIndexChanged = !lockSelectedIndexChanged;
                addListBox1.ClearSelected();
                lockSelectedIndexChanged = !lockSelectedIndexChanged;
            }
        }

        private void addTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                addButton1.PerformClick();
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private void addTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                addButton2.PerformClick();
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private void addListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete) {
                if (addListBox1.SelectedItems.Count > 0)
                    removeSelectedItems(addListBox1, true);
                else if (addListBox2.SelectedItems.Count > 0)
                    removeSelectedItems(addListBox2, false);
                else
                    System.Media.SystemSounds.Beep.Play();
            }
        }

        public bool CryptoComboChangeLock = false;
        private void CryptoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Loading && !CryptoComboChangeLock) {
                LoadCryptoInfo(CryptoComboBox.Text);
            }
        }
    }
}
