using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static Bitcoin_Transaction_Log.Methods1;

namespace Bitcoin_Transaction_Log
{
    public partial class Alerts : Form
    {
        static MainForm mainForm;
        const int limit = 100;

        public Alerts(MainForm form)
        {
            InitializeComponent();
            mainForm = form;
        }

        private void Alerts_Load(object sender, EventArgs e)
        {
            Icon = Properties.Resources.icon50;

            if (Properties.Settings.Default.PriceAlertsG != null) {
                foreach (string str in Properties.Settings.Default.PriceAlertsG) {
                    addListBox1.Items.Add(str);
                }
            }
            if (Properties.Settings.Default.PriceAlertsL != null) {
                foreach (string str in Properties.Settings.Default.PriceAlertsL) {
                    addListBox2.Items.Add(str);
                }
            }
            if (!Properties.Settings.Default.PriceAlertsEnabled) {
                toggleAlertsButton.Text = "Disabled";
            } else {
                toggleAlertsButton.Text = "Enabled";
            }
        }

        private void Alerts_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void addButton1_Click(object sender, EventArgs e)
        {
            decimal output;
            if (!string.IsNullOrEmpty(addTextBox1.Text)) {
                if (decimal.TryParse(addTextBox1.Text, out output)) {
                    if (addListBox2.Items.Count + addListBox1.Items.Count + 1 <= limit) {
                        foreach (object o in addListBox1.Items) {
                            if (Convert.ToDecimal(o) == output) {
                                MessageBox.Show("Entered value already exists.");
                                addTextBox1.Text = "";
                                return;
                            }
                        }
                        foreach (object o in addListBox2.Items) {
                            if (Convert.ToDecimal(o) == output) {
                                MessageBox.Show("Entered value already exists.");
                                addTextBox1.Text = "";
                                return;
                            }
                        }

                        addListBox1.Items.Add(output);
                        if (Properties.Settings.Default.PriceAlertsG == null) {
                            Properties.Settings.Default.PriceAlertsG = new System.Collections.Specialized.StringCollection();
                        }
                        Properties.Settings.Default.PriceAlertsG.Add(Convert.ToString(output));
                        addTextBox1.Text = "";
                        mainForm.StartAlertsTimer();
                    } else {
                        MessageBox.Show("Alerts are limited to " + limit + ".");
                    }
                } else {
                    MessageBox.Show("Entered value is not a number.");
                }
            } else {
                MessageBox.Show("Entered value is blank.");
            }
        }

        private void addButton2_Click(object sender, EventArgs e)
        {
            decimal output;
            if (!string.IsNullOrEmpty(addTextBox2.Text)) {
                if (decimal.TryParse(addTextBox2.Text, out output)) {
                    if (addListBox2.Items.Count + addListBox1.Items.Count + 1 <= limit) {
                        foreach (object o in addListBox1.Items) {
                            if (Convert.ToDecimal(o) == output) {
                                MessageBox.Show("Entered value already exists.");
                                addTextBox2.Text = "";
                                return;
                            }
                        }
                        foreach (object o in addListBox2.Items) {
                            if (Convert.ToDecimal(o) == output) {
                                MessageBox.Show("Entered value already exists.");
                                addTextBox2.Text = "";
                                return;
                            }
                        }

                        addListBox2.Items.Add(output);
                        if (Properties.Settings.Default.PriceAlertsL == null) {
                            Properties.Settings.Default.PriceAlertsL = new System.Collections.Specialized.StringCollection();
                        }
                        Properties.Settings.Default.PriceAlertsL.Add(Convert.ToString(output));
                        addTextBox2.Text = "";
                        mainForm.StartAlertsTimer();
                    } else {
                        MessageBox.Show("Alerts are limited to " + limit + ".");
                    }
                } else {
                    MessageBox.Show("Entered value is not a number.");
                }
            } else {
                MessageBox.Show("Entered value is blank.");
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

        private void removeSelectedItems(ListBox lstBox, bool type)
        {
            if (lstBox.SelectedItems.Count > 0) {
                if (type) {
                    if (Properties.Settings.Default.PriceAlertsG != null) {
                        foreach (int i in lstBox.SelectedIndices) {
                            Properties.Settings.Default.PriceAlertsG.Remove(Convert.ToString(lstBox.Items[i]));
                        }
                    }
                } else {
                    if (Properties.Settings.Default.PriceAlertsL != null) {
                        foreach (int i in lstBox.SelectedIndices) {
                            Properties.Settings.Default.PriceAlertsL.Remove(Convert.ToString(lstBox.Items[i]));
                        }
                    }
                }

                ListBox.SelectedObjectCollection selectedItems = new ListBox.SelectedObjectCollection(lstBox);
                for (int i = selectedItems.Count - 1; i >= 0; i--) {
                    lstBox.Items.Remove(selectedItems[i]);
                }
            } else {
                MessageBox.Show("No item is selected.");
            }
        }

        private void toggleAlertsButton_Click(object sender, EventArgs e)
        {
            if (toggleAlertsButton.Text == "Enabled") {
                Properties.Settings.Default.PriceAlertsEnabled = false;
                toggleAlertsButton.Text = "Disabled";
            } else {
                Properties.Settings.Default.PriceAlertsEnabled = true;
                toggleAlertsButton.Text = "Enabled";
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
    }
}
