<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.FeeAfterCheckBox = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.FeeBeforeCheckBox = New System.Windows.Forms.CheckBox()
        Me.SellAllNowProfitFeeTextBox = New System.Windows.Forms.TextBox()
        Me.CurrencyTypeComboBox = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.UpdateLight = New System.Windows.Forms.PictureBox()
        Me.SellAllProfitInfoButton = New System.Windows.Forms.PictureBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.SellAllNowRevenueTextBox = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.BitcoinPictureBox2 = New System.Windows.Forms.PictureBox()
        Me.BitcoinPictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TotalBitcoinsTextBox = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.SellAllNowProfitTextBox = New System.Windows.Forms.TextBox()
        Me.SellAllBTCButton = New System.Windows.Forms.PictureBox()
        Me.IgnoreLossCheckBox = New System.Windows.Forms.CheckBox()
        Me.NewBuyButton = New System.Windows.Forms.Button()
        Me.UpdateIntervalNumericUpDown = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PauseButton = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.NewSellButton = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CurrPriceBTCTextBox = New System.Windows.Forms.TextBox()
        Me.AboutButton = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.UpdateRateTimer = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.UpdateBitcoinValue = New System.ComponentModel.BackgroundWorker()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.BuySellColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateTimeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BTCColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.USDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FeeChargedColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BTCExchangeRateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PercentIncreaseColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SellNowProfitColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BreakEvenPointColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DisabledColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.CommentsColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        CType(Me.UpdateLight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SellAllProfitInfoButton, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BitcoinPictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BitcoinPictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SellAllBTCButton, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UpdateIntervalNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.FeeAfterCheckBox)
        Me.Panel1.Controls.Add(Me.FeeBeforeCheckBox)
        Me.Panel1.Controls.Add(Me.SellAllNowProfitFeeTextBox)
        Me.Panel1.Controls.Add(Me.CurrencyTypeComboBox)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.UpdateLight)
        Me.Panel1.Controls.Add(Me.SellAllProfitInfoButton)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.SellAllNowRevenueTextBox)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.BitcoinPictureBox2)
        Me.Panel1.Controls.Add(Me.BitcoinPictureBox1)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.TotalBitcoinsTextBox)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.SellAllNowProfitTextBox)
        Me.Panel1.Controls.Add(Me.SellAllBTCButton)
        Me.Panel1.Controls.Add(Me.IgnoreLossCheckBox)
        Me.Panel1.Controls.Add(Me.NewBuyButton)
        Me.Panel1.Controls.Add(Me.UpdateIntervalNumericUpDown)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.PauseButton)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.NewSellButton)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.CurrPriceBTCTextBox)
        Me.Panel1.Controls.Add(Me.AboutButton)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.MaximumSize = New System.Drawing.Size(0, 100)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1334, 100)
        Me.Panel1.TabIndex = 9
        '
        'FeeAfterCheckBox
        '
        Me.FeeAfterCheckBox.AutoSize = True
        Me.FeeAfterCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.FeeAfterCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FeeAfterCheckBox.Location = New System.Drawing.Point(362, 65)
        Me.FeeAfterCheckBox.Name = "FeeAfterCheckBox"
        Me.FeeAfterCheckBox.Size = New System.Drawing.Size(112, 14)
        Me.FeeAfterCheckBox.TabIndex = 45
        Me.FeeAfterCheckBox.Text = "Fee Taken After Buy USD"
        Me.FeeAfterCheckBox.UseVisualStyleBackColor = True
        Me.FeeAfterCheckBox.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(355, 21)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(119, 18)
        Me.Label5.TabIndex = 44
        Me.Label5.Text = "Fee Functionality"
        Me.Label5.Visible = False
        '
        'FeeBeforeCheckBox
        '
        Me.FeeBeforeCheckBox.AutoSize = True
        Me.FeeBeforeCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.FeeBeforeCheckBox.Checked = True
        Me.FeeBeforeCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.FeeBeforeCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FeeBeforeCheckBox.Location = New System.Drawing.Point(357, 46)
        Me.FeeBeforeCheckBox.Name = "FeeBeforeCheckBox"
        Me.FeeBeforeCheckBox.Size = New System.Drawing.Size(117, 14)
        Me.FeeBeforeCheckBox.TabIndex = 43
        Me.FeeBeforeCheckBox.Text = "Fee Factored Into Buy USD"
        Me.FeeBeforeCheckBox.UseVisualStyleBackColor = True
        Me.FeeBeforeCheckBox.Visible = False
        '
        'SellAllNowProfitFeeTextBox
        '
        Me.SellAllNowProfitFeeTextBox.Location = New System.Drawing.Point(1064, 19)
        Me.SellAllNowProfitFeeTextBox.Name = "SellAllNowProfitFeeTextBox"
        Me.SellAllNowProfitFeeTextBox.Size = New System.Drawing.Size(29, 20)
        Me.SellAllNowProfitFeeTextBox.TabIndex = 41
        Me.SellAllNowProfitFeeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CurrencyTypeComboBox
        '
        Me.CurrencyTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CurrencyTypeComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CurrencyTypeComboBox.FormattingEnabled = True
        Me.CurrencyTypeComboBox.Location = New System.Drawing.Point(488, 59)
        Me.CurrencyTypeComboBox.Name = "CurrencyTypeComboBox"
        Me.CurrencyTypeComboBox.Size = New System.Drawing.Size(59, 24)
        Me.CurrencyTypeComboBox.TabIndex = 39
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(494, 44)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(49, 13)
        Me.Label11.TabIndex = 40
        Me.Label11.Text = "Currency"
        '
        'UpdateLight
        '
        Me.UpdateLight.Location = New System.Drawing.Point(852, 57)
        Me.UpdateLight.Name = "UpdateLight"
        Me.UpdateLight.Size = New System.Drawing.Size(32, 32)
        Me.UpdateLight.TabIndex = 38
        Me.UpdateLight.TabStop = False
        '
        'SellAllProfitInfoButton
        '
        Me.SellAllProfitInfoButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.SellAllProfitInfoButton.Location = New System.Drawing.Point(1300, 12)
        Me.SellAllProfitInfoButton.Name = "SellAllProfitInfoButton"
        Me.SellAllProfitInfoButton.Size = New System.Drawing.Size(30, 26)
        Me.SellAllProfitInfoButton.TabIndex = 36
        Me.SellAllProfitInfoButton.TabStop = False
        Me.ToolTip1.SetToolTip(Me.SellAllProfitInfoButton, "Click to show how the profit is computed")
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(1099, 10)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(206, 29)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Sell All Now Profit"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(1064, 4)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(31, 12)
        Me.Label10.TabIndex = 35
        Me.Label10.Text = "Fee %"
        '
        'SellAllNowRevenueTextBox
        '
        Me.SellAllNowRevenueTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SellAllNowRevenueTextBox.Location = New System.Drawing.Point(917, 63)
        Me.SellAllNowRevenueTextBox.Name = "SellAllNowRevenueTextBox"
        Me.SellAllNowRevenueTextBox.ReadOnly = True
        Me.SellAllNowRevenueTextBox.Size = New System.Drawing.Size(114, 26)
        Me.SellAllNowRevenueTextBox.TabIndex = 27
        Me.SellAllNowRevenueTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(904, 66)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(16, 18)
        Me.Label9.TabIndex = 33
        Me.Label9.Text = "$"
        '
        'BitcoinPictureBox2
        '
        Me.BitcoinPictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BitcoinPictureBox2.Location = New System.Drawing.Point(187, 37)
        Me.BitcoinPictureBox2.Name = "BitcoinPictureBox2"
        Me.BitcoinPictureBox2.Size = New System.Drawing.Size(26, 26)
        Me.BitcoinPictureBox2.TabIndex = 32
        Me.BitcoinPictureBox2.TabStop = False
        Me.ToolTip1.SetToolTip(Me.BitcoinPictureBox2, "Bitcoins (BTC)")
        '
        'BitcoinPictureBox1
        '
        Me.BitcoinPictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BitcoinPictureBox1.Location = New System.Drawing.Point(311, 37)
        Me.BitcoinPictureBox1.Name = "BitcoinPictureBox1"
        Me.BitcoinPictureBox1.Size = New System.Drawing.Size(26, 26)
        Me.BitcoinPictureBox1.TabIndex = 31
        Me.BitcoinPictureBox1.TabStop = False
        Me.ToolTip1.SetToolTip(Me.BitcoinPictureBox1, "Bitcoins (BTC)")
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(214, 42)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(98, 18)
        Me.Label7.TabIndex = 25
        Me.Label7.Text = "Total Bitcoins"
        '
        'TotalBitcoinsTextBox
        '
        Me.TotalBitcoinsTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotalBitcoinsTextBox.Location = New System.Drawing.Point(187, 63)
        Me.TotalBitcoinsTextBox.Name = "TotalBitcoinsTextBox"
        Me.TotalBitcoinsTextBox.ReadOnly = True
        Me.TotalBitcoinsTextBox.Size = New System.Drawing.Size(151, 26)
        Me.TotalBitcoinsTextBox.TabIndex = 24
        Me.TotalBitcoinsTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(903, 42)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(148, 18)
        Me.Label8.TabIndex = 28
        Me.Label8.Text = "Sell All Now Revenue"
        '
        'SellAllNowProfitTextBox
        '
        Me.SellAllNowProfitTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SellAllNowProfitTextBox.Location = New System.Drawing.Point(1104, 42)
        Me.SellAllNowProfitTextBox.Name = "SellAllNowProfitTextBox"
        Me.SellAllNowProfitTextBox.ReadOnly = True
        Me.SellAllNowProfitTextBox.Size = New System.Drawing.Size(201, 47)
        Me.SellAllNowProfitTextBox.TabIndex = 16
        Me.SellAllNowProfitTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'SellAllBTCButton
        '
        Me.SellAllBTCButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.SellAllBTCButton.Location = New System.Drawing.Point(1031, 63)
        Me.SellAllBTCButton.Name = "SellAllBTCButton"
        Me.SellAllBTCButton.Size = New System.Drawing.Size(30, 26)
        Me.SellAllBTCButton.TabIndex = 30
        Me.SellAllBTCButton.TabStop = False
        Me.ToolTip1.SetToolTip(Me.SellAllBTCButton, "Click to show how the revenue is computed")
        '
        'IgnoreLossCheckBox
        '
        Me.IgnoreLossCheckBox.AutoSize = True
        Me.IgnoreLossCheckBox.CheckAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.IgnoreLossCheckBox.Location = New System.Drawing.Point(986, 3)
        Me.IgnoreLossCheckBox.Name = "IgnoreLossCheckBox"
        Me.IgnoreLossCheckBox.Size = New System.Drawing.Size(76, 31)
        Me.IgnoreLossCheckBox.TabIndex = 26
        Me.IgnoreLossCheckBox.Text = "Ignore ""Loss"""
        Me.ToolTip1.SetToolTip(Me.IgnoreLossCheckBox, "Ignore the money ($) lost from ""LOSS"" transactions for things like ""sell all now " &
        "profit""")
        Me.IgnoreLossCheckBox.UseVisualStyleBackColor = True
        '
        'NewBuyButton
        '
        Me.NewBuyButton.Dock = System.Windows.Forms.DockStyle.Left
        Me.NewBuyButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NewBuyButton.Location = New System.Drawing.Point(90, 0)
        Me.NewBuyButton.Margin = New System.Windows.Forms.Padding(0)
        Me.NewBuyButton.Name = "NewBuyButton"
        Me.NewBuyButton.Size = New System.Drawing.Size(90, 100)
        Me.NewBuyButton.TabIndex = 12
        Me.NewBuyButton.Text = "New Buy"
        Me.ToolTip1.SetToolTip(Me.NewBuyButton, "Add a new transaction")
        Me.NewBuyButton.UseVisualStyleBackColor = True
        '
        'UpdateIntervalNumericUpDown
        '
        Me.UpdateIntervalNumericUpDown.Location = New System.Drawing.Point(803, 69)
        Me.UpdateIntervalNumericUpDown.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
        Me.UpdateIntervalNumericUpDown.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.UpdateIntervalNumericUpDown.Name = "UpdateIntervalNumericUpDown"
        Me.UpdateIntervalNumericUpDown.Size = New System.Drawing.Size(43, 20)
        Me.UpdateIntervalNumericUpDown.TabIndex = 23
        Me.UpdateIntervalNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.UpdateIntervalNumericUpDown, "The current timer update interval in seconds")
        Me.UpdateIntervalNumericUpDown.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(803, 54)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 13)
        Me.Label6.TabIndex = 22
        Me.Label6.Text = "Interval"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(1073, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 39)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "$"
        '
        'PauseButton
        '
        Me.PauseButton.Image = Global.Bitcoin_Transaction_Log.My.Resources.Resources.Pause
        Me.PauseButton.Location = New System.Drawing.Point(764, 59)
        Me.PauseButton.Name = "PauseButton"
        Me.PauseButton.Size = New System.Drawing.Size(30, 30)
        Me.PauseButton.TabIndex = 15
        Me.ToolTip1.SetToolTip(Me.PauseButton, "Pause the update timer, which includes updating the coinbase exchange rate online" &
        " and other TextBoxes")
        Me.PauseButton.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(553, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 39)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "$"
        '
        'NewSellButton
        '
        Me.NewSellButton.Dock = System.Windows.Forms.DockStyle.Left
        Me.NewSellButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NewSellButton.Location = New System.Drawing.Point(0, 0)
        Me.NewSellButton.Margin = New System.Windows.Forms.Padding(0)
        Me.NewSellButton.Name = "NewSellButton"
        Me.NewSellButton.Size = New System.Drawing.Size(90, 100)
        Me.NewSellButton.TabIndex = 13
        Me.NewSellButton.Text = "New Sell"
        Me.ToolTip1.SetToolTip(Me.NewSellButton, "Add a new transaction")
        Me.NewSellButton.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(514, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(318, 29)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Current Coinbase BTC Price"
        '
        'CurrPriceBTCTextBox
        '
        Me.CurrPriceBTCTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CurrPriceBTCTextBox.Location = New System.Drawing.Point(595, 42)
        Me.CurrPriceBTCTextBox.MaxLength = 20
        Me.CurrPriceBTCTextBox.Name = "CurrPriceBTCTextBox"
        Me.CurrPriceBTCTextBox.ReadOnly = True
        Me.CurrPriceBTCTextBox.Size = New System.Drawing.Size(163, 47)
        Me.CurrPriceBTCTextBox.TabIndex = 10
        Me.CurrPriceBTCTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'AboutButton
        '
        Me.AboutButton.Location = New System.Drawing.Point(179, 0)
        Me.AboutButton.Name = "AboutButton"
        Me.AboutButton.Size = New System.Drawing.Size(56, 29)
        Me.AboutButton.TabIndex = 42
        Me.AboutButton.Text = "About"
        Me.AboutButton.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.BuySellColumn, Me.DateTimeColumn, Me.BTCColumn, Me.USDColumn, Me.FeeChargedColumn, Me.BTCExchangeRateColumn, Me.PercentIncreaseColumn, Me.SellNowProfitColumn1, Me.BreakEvenPointColumn, Me.DisabledColumn, Me.CommentsColumn})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 100)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DataGridView1.Size = New System.Drawing.Size(1334, 783)
        Me.DataGridView1.TabIndex = 10
        '
        'UpdateRateTimer
        '
        Me.UpdateRateTimer.Interval = 10000
        '
        'ToolTip1
        '
        Me.ToolTip1.AutoPopDelay = 30000
        Me.ToolTip1.InitialDelay = 500
        Me.ToolTip1.ReshowDelay = 100
        '
        'UpdateBitcoinValue
        '
        Me.UpdateBitcoinValue.WorkerSupportsCancellation = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(241, 5)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(130, 24)
        Me.Label12.TabIndex = 48
        Me.Label12.Text = "(Fees are currently only priced " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "into buys and after sells)"
        '
        'BuySellColumn
        '
        Me.BuySellColumn.HeaderText = "Transaction"
        Me.BuySellColumn.MaxInputLength = 10
        Me.BuySellColumn.Name = "BuySellColumn"
        Me.BuySellColumn.ReadOnly = True
        Me.BuySellColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.BuySellColumn.ToolTipText = "Type of transaction"
        Me.BuySellColumn.Width = 80
        '
        'DateTimeColumn
        '
        Me.DateTimeColumn.HeaderText = "Date"
        Me.DateTimeColumn.Name = "DateTimeColumn"
        Me.DateTimeColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DateTimeColumn.ToolTipText = "Time of transaction (optional)"
        Me.DateTimeColumn.Width = 125
        '
        'BTCColumn
        '
        Me.BTCColumn.HeaderText = "BTC"
        Me.BTCColumn.MaxInputLength = 20
        Me.BTCColumn.Name = "BTCColumn"
        Me.BTCColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.BTCColumn.ToolTipText = "Bitcoins spent or gained"
        '
        'USDColumn
        '
        Me.USDColumn.HeaderText = "USD"
        Me.USDColumn.MaxInputLength = 20
        Me.USDColumn.Name = "USDColumn"
        Me.USDColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.USDColumn.ToolTipText = "Dollars spent or gained"
        '
        'FeeChargedColumn
        '
        Me.FeeChargedColumn.HeaderText = "Fee % (Buy+Sell)"
        Me.FeeChargedColumn.MaxInputLength = 20
        Me.FeeChargedColumn.Name = "FeeChargedColumn"
        Me.FeeChargedColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.FeeChargedColumn.ToolTipText = "The fee incurred (percentage on buys and sells)"
        '
        'BTCExchangeRateColumn
        '
        Me.BTCExchangeRateColumn.HeaderText = "BTC Exchange Rate"
        Me.BTCExchangeRateColumn.MaxInputLength = 20
        Me.BTCExchangeRateColumn.Name = "BTCExchangeRateColumn"
        Me.BTCExchangeRateColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.BTCExchangeRateColumn.ToolTipText = "The BTC exchange rate at the time of buy/sell etc."
        '
        'PercentIncreaseColumn
        '
        Me.PercentIncreaseColumn.HeaderText = "USD % Increase"
        Me.PercentIncreaseColumn.MaxInputLength = 20
        Me.PercentIncreaseColumn.Name = "PercentIncreaseColumn"
        Me.PercentIncreaseColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.PercentIncreaseColumn.ToolTipText = "Includes the percent sell fee if defined."
        '
        'SellNowProfitColumn1
        '
        Me.SellNowProfitColumn1.HeaderText = "Sell This Now Profit ($)"
        Me.SellNowProfitColumn1.MaxInputLength = 25
        Me.SellNowProfitColumn1.Name = "SellNowProfitColumn1"
        Me.SellNowProfitColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.SellNowProfitColumn1.ToolTipText = "Sell this rows bitcoin's at the current exchange rate minus the price it was boug" &
    "ht at."
        Me.SellNowProfitColumn1.Width = 125
        '
        'BreakEvenPointColumn
        '
        Me.BreakEvenPointColumn.HeaderText = "Break Even Point"
        Me.BreakEvenPointColumn.MaxInputLength = 20
        Me.BreakEvenPointColumn.Name = "BreakEvenPointColumn"
        Me.BreakEvenPointColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.BreakEvenPointColumn.ToolTipText = "Price at which you can sell and lose no money, even after any defined fees."
        Me.BreakEvenPointColumn.Width = 75
        '
        'DisabledColumn
        '
        Me.DisabledColumn.HeaderText = "Disabled"
        Me.DisabledColumn.Name = "DisabledColumn"
        Me.DisabledColumn.ToolTipText = "Disable this row from being considered AT ALL."
        Me.DisabledColumn.Width = 75
        '
        'CommentsColumn
        '
        Me.CommentsColumn.HeaderText = "Comments"
        Me.CommentsColumn.Name = "CommentsColumn"
        Me.CommentsColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.CommentsColumn.ToolTipText = "Optional area to describe this transaction."
        Me.CommentsColumn.Width = 300
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1334, 883)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Panel1)
        Me.MinimumSize = New System.Drawing.Size(1330, 215)
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Bitcoin Transaction Logs"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.UpdateLight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SellAllProfitInfoButton, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BitcoinPictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BitcoinPictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SellAllBTCButton, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UpdateIntervalNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents NewSellButton As Button
    Friend WithEvents NewBuyButton As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents CurrPriceBTCTextBox As TextBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Label2 As Label
    Friend WithEvents PauseButton As Button
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents SellAllNowProfitTextBox As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents UpdateIntervalNumericUpDown As NumericUpDown
    Friend WithEvents Label7 As Label
    Friend WithEvents TotalBitcoinsTextBox As TextBox
    Friend WithEvents IgnoreLossCheckBox As CheckBox
    Friend WithEvents Label8 As Label
    Friend WithEvents SellAllNowRevenueTextBox As TextBox
    Friend WithEvents SellAllBTCButton As PictureBox
    Friend WithEvents BitcoinPictureBox1 As PictureBox
    Friend WithEvents BitcoinPictureBox2 As PictureBox
    Friend WithEvents Label9 As Label
    Friend WithEvents SellAllProfitInfoButton As PictureBox
    Friend WithEvents UpdateLight As PictureBox
    Friend WithEvents UpdateRateTimer As Timer
    Friend WithEvents UpdateBitcoinValue As System.ComponentModel.BackgroundWorker
    Friend WithEvents CurrencyTypeComboBox As ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents SellAllNowProfitFeeTextBox As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents AboutButton As Button
    Friend WithEvents FeeAfterCheckBox As CheckBox
    Friend WithEvents Label5 As Label
    Friend WithEvents FeeBeforeCheckBox As CheckBox
    Friend WithEvents Label12 As Label
    Friend WithEvents CommentsColumn As DataGridViewTextBoxColumn
    Friend WithEvents DisabledColumn As DataGridViewCheckBoxColumn
    Friend WithEvents BreakEvenPointColumn As DataGridViewTextBoxColumn
    Friend WithEvents SellNowProfitColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents PercentIncreaseColumn As DataGridViewTextBoxColumn
    Friend WithEvents BTCExchangeRateColumn As DataGridViewTextBoxColumn
    Friend WithEvents FeeChargedColumn As DataGridViewTextBoxColumn
    Friend WithEvents USDColumn As DataGridViewTextBoxColumn
    Friend WithEvents BTCColumn As DataGridViewTextBoxColumn
    Friend WithEvents DateTimeColumn As DataGridViewTextBoxColumn
    Friend WithEvents BuySellColumn As DataGridViewTextBoxColumn
End Class
