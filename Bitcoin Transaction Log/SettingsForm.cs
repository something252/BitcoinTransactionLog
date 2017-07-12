using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bitcoin_Transaction_Log
{
    public partial class SettingsForm : Form
    {
        public SettingsForm(MainForm form)
        {
            InitializeComponent();
            mainForm = form;
        }

        MainForm mainForm;

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            if (mainForm.CryptoList.CurrentCryptoType == "ETH")
                Icon = Properties.Resources.Ethereum32icon;
            else if (mainForm.CryptoList.CurrentCryptoType == "LTC")
                Icon = Properties.Resources.Litecoin32icon;
            else
                Icon = Properties.Resources.Bitcoin50;

            label19.Text = mainForm.CurrentMoneyType;

            if (mainForm.SettingsInfo.DataGridRowPrimaryFont != null) {
                selectSizeTextBox1.Text = mainForm.SettingsInfo.DataGridRowPrimaryFont.Size.ToString();
                selectFontTextBox1.Text = mainForm.SettingsInfo.DataGridRowPrimaryFont.Name;
                selectFontTextBox1.Font = mainForm.SettingsInfo.DataGridRowPrimaryFont;
            } else {
                selectSizeTextBox1.Text = mainForm.DataGridView1.RowsDefaultCellStyle.Font.Size.ToString();
                selectFontTextBox1.Text = mainForm.DataGridView1.RowsDefaultCellStyle.Font.Name;
                selectFontTextBox1.Font = mainForm.DataGridView1.RowsDefaultCellStyle.Font;
            }
            if (mainForm.SettingsInfo.DataGridColumnHeadersFont != null) {
                selectColFontTextBox1.Text = mainForm.SettingsInfo.DataGridColumnHeadersFont.Size.ToString();
                selectColFontTextBox2.Text = mainForm.SettingsInfo.DataGridColumnHeadersFont.Name;
                selectColFontTextBox2.Font = mainForm.SettingsInfo.DataGridColumnHeadersFont;
            } else {
                selectColFontTextBox1.Text = mainForm.DataGridView1.ColumnHeadersDefaultCellStyle.Font.Size.ToString();
                selectColFontTextBox2.Text = mainForm.DataGridView1.ColumnHeadersDefaultCellStyle.Font.Name;
                selectColFontTextBox2.Font = mainForm.DataGridView1.ColumnHeadersDefaultCellStyle.Font;
            }

            mainForm.SettingsInfo.LoadSettingsForm(this);
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            mainForm.SettingsInfo.SettingsForm_ValueChanged(sender);
            mainForm.PerformUpdatesThread();
        }

        private void AboutButton_Click(object sender, EventArgs e)
        {
            mainForm.AboutButton_Click(sender, e);
        }

        private void selectFontButton_Click(object sender, EventArgs e)
        {
            try {
                string name = ((Button)sender).Name;
                if (name == "selectFontButton1")
                    fontDialog1.Font = mainForm.DataGridView1.RowsDefaultCellStyle.Font;
                else if (name == "selectColumnFontButton1")
                    fontDialog1.Font = mainForm.DataGridView1.ColumnHeadersDefaultCellStyle.Font;

                DialogResult result = fontDialog1.ShowDialog();
                if (result == DialogResult.OK) {
                    Font font = fontDialog1.Font;
                    if (name == "selectFontButton1") {
                        selectFontTextBox1.Text = string.Format(font.Name);
                        selectFontTextBox1.Font = font;
                        selectSizeTextBox1.Text = font.Size.ToString();
                        mainForm.DataGridView1.AlternatingRowsDefaultCellStyle.Font = font;
                        mainForm.DataGridView1.RowsDefaultCellStyle.Font = font;
                        mainForm.SettingsInfo.DataGridRowPrimaryFont = font;
                    } else if (name == "selectColumnFontButton1") {
                        selectColFontTextBox2.Text = string.Format(font.Name);
                        selectColFontTextBox2.Font = font;
                        selectColFontTextBox1.Text = font.Size.ToString();
                        mainForm.DataGridView1.ColumnHeadersDefaultCellStyle.Font = font;
                        mainForm.SettingsInfo.DataGridColumnHeadersFont = font;
                    }
                }
            } catch (Exception ex) {
                Interaction.MsgBox(ex.Message, MsgBoxStyle.Exclamation);
            }
        }

        private void font1DefaultButton_Click(object sender, EventArgs e)
        {
            if (mainForm.DefaultRowsDefaultCellStyleFont != null) {
                selectFontTextBox1.Text = string.Format(mainForm.DefaultRowsDefaultCellStyleFont.Name);
                selectFontTextBox1.Font = mainForm.DefaultRowsDefaultCellStyleFont;
                selectSizeTextBox1.Text = mainForm.DefaultRowsDefaultCellStyleFont.Size.ToString();
                mainForm.DataGridView1.AlternatingRowsDefaultCellStyle.Font = mainForm.DefaultRowsDefaultCellStyleFont;
                mainForm.DataGridView1.RowsDefaultCellStyle.Font = mainForm.DefaultRowsDefaultCellStyleFont;
                mainForm.SettingsInfo.DataGridRowPrimaryFont = mainForm.DefaultRowsDefaultCellStyleFont;
            }
        }

        private void font2DefaultButton_Click(object sender, EventArgs e)
        {
            if (mainForm.DefaultColumnHeadersDefaultCellStyleFont != null) {
                selectColFontTextBox2.Text = string.Format(mainForm.DefaultColumnHeadersDefaultCellStyleFont.Name);
                selectColFontTextBox2.Font = mainForm.DefaultColumnHeadersDefaultCellStyleFont;
                selectColFontTextBox1.Text = mainForm.DefaultColumnHeadersDefaultCellStyleFont.Size.ToString();
                mainForm.DataGridView1.ColumnHeadersDefaultCellStyle.Font = mainForm.DefaultColumnHeadersDefaultCellStyleFont;
                mainForm.SettingsInfo.DataGridColumnHeadersFont = mainForm.DefaultColumnHeadersDefaultCellStyleFont;
            }
        }
    }
}
