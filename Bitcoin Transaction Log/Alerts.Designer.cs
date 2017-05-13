namespace Bitcoin_Transaction_Log
{
    partial class Alerts
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.addListBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.addListBox2 = new System.Windows.Forms.ListBox();
            this.removeButton1 = new System.Windows.Forms.Button();
            this.addTextBox2 = new System.Windows.Forms.TextBox();
            this.addButton2 = new System.Windows.Forms.Button();
            this.addButton1 = new System.Windows.Forms.Button();
            this.addTextBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.toggleAlertsButton = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // addListBox1
            // 
            this.addListBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.addListBox1.FormattingEnabled = true;
            this.addListBox1.ItemHeight = 18;
            this.addListBox1.Location = new System.Drawing.Point(18, 104);
            this.addListBox1.Margin = new System.Windows.Forms.Padding(4);
            this.addListBox1.Name = "addListBox1";
            this.addListBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.addListBox1.Size = new System.Drawing.Size(160, 184);
            this.addListBox1.TabIndex = 0;
            this.addListBox1.SelectedIndexChanged += new System.EventHandler(this.addListBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 35);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = "Greater than or equal to\r\n                 >=";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(190, 35);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 36);
            this.label2.TabIndex = 3;
            this.label2.Text = "Less than or equal to\r\n               <=";
            // 
            // addListBox2
            // 
            this.addListBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.addListBox2.FormattingEnabled = true;
            this.addListBox2.ItemHeight = 18;
            this.addListBox2.Location = new System.Drawing.Point(185, 104);
            this.addListBox2.Margin = new System.Windows.Forms.Padding(4);
            this.addListBox2.Name = "addListBox2";
            this.addListBox2.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.addListBox2.Size = new System.Drawing.Size(160, 184);
            this.addListBox2.TabIndex = 2;
            this.addListBox2.SelectedIndexChanged += new System.EventHandler(this.addListBox2_SelectedIndexChanged);
            // 
            // removeButton1
            // 
            this.removeButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.removeButton1.Location = new System.Drawing.Point(18, 291);
            this.removeButton1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.removeButton1.Name = "removeButton1";
            this.removeButton1.Size = new System.Drawing.Size(327, 44);
            this.removeButton1.TabIndex = 4;
            this.removeButton1.Text = "Remove Selected";
            this.toolTip1.SetToolTip(this.removeButton1, "Remove selected list items");
            this.removeButton1.UseVisualStyleBackColor = true;
            this.removeButton1.Click += new System.EventHandler(this.removeButton1_Click);
            // 
            // addTextBox2
            // 
            this.addTextBox2.Location = new System.Drawing.Point(185, 73);
            this.addTextBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addTextBox2.MaxLength = 20;
            this.addTextBox2.Name = "addTextBox2";
            this.addTextBox2.Size = new System.Drawing.Size(106, 24);
            this.addTextBox2.TabIndex = 6;
            // 
            // addButton2
            // 
            this.addButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addButton2.Location = new System.Drawing.Point(291, 73);
            this.addButton2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addButton2.Name = "addButton2";
            this.addButton2.Size = new System.Drawing.Size(54, 24);
            this.addButton2.TabIndex = 7;
            this.addButton2.Text = "Add";
            this.toolTip1.SetToolTip(this.addButton2, "Add value to list");
            this.addButton2.UseVisualStyleBackColor = true;
            this.addButton2.Click += new System.EventHandler(this.addButton2_Click);
            // 
            // addButton1
            // 
            this.addButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addButton1.Location = new System.Drawing.Point(124, 73);
            this.addButton1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addButton1.Name = "addButton1";
            this.addButton1.Size = new System.Drawing.Size(54, 24);
            this.addButton1.TabIndex = 9;
            this.addButton1.Text = "Add";
            this.toolTip1.SetToolTip(this.addButton1, "Add value to list");
            this.addButton1.UseVisualStyleBackColor = true;
            this.addButton1.Click += new System.EventHandler(this.addButton1_Click);
            // 
            // addTextBox1
            // 
            this.addTextBox1.Location = new System.Drawing.Point(18, 73);
            this.addTextBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addTextBox1.MaxLength = 20;
            this.addTextBox1.Name = "addTextBox1";
            this.addTextBox1.Size = new System.Drawing.Size(106, 24);
            this.addTextBox1.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(76, 5);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(230, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Price Alerts (Current BTC Price)";
            // 
            // toggleAlertsButton
            // 
            this.toggleAlertsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toggleAlertsButton.Location = new System.Drawing.Point(-2, 1);
            this.toggleAlertsButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.toggleAlertsButton.Name = "toggleAlertsButton";
            this.toggleAlertsButton.Size = new System.Drawing.Size(76, 32);
            this.toggleAlertsButton.TabIndex = 11;
            this.toggleAlertsButton.Text = "Enabled";
            this.toggleAlertsButton.UseVisualStyleBackColor = true;
            this.toggleAlertsButton.Click += new System.EventHandler(this.toggleAlertsButton_Click);
            // 
            // Alerts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 338);
            this.Controls.Add(this.toggleAlertsButton);
            this.Controls.Add(this.removeButton1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.addButton1);
            this.Controls.Add(this.addTextBox1);
            this.Controls.Add(this.addButton2);
            this.Controls.Add(this.addTextBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.addListBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.addListBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(371, 9000);
            this.MinimumSize = new System.Drawing.Size(371, 232);
            this.Name = "Alerts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alerts";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Alerts_FormClosing);
            this.Load += new System.EventHandler(this.Alerts_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox addListBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox addListBox2;
        private System.Windows.Forms.Button removeButton1;
        private System.Windows.Forms.TextBox addTextBox2;
        private System.Windows.Forms.Button addButton2;
        private System.Windows.Forms.Button addButton1;
        private System.Windows.Forms.TextBox addTextBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button toggleAlertsButton;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}