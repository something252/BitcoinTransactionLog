Imports System.Net
Imports System.IO
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Threading
Imports System.ComponentModel

Public Class MainForm
    Dim Loading As Boolean = True
    'Public LockThreadExec As New Object
    Private LockUpdates As New Object

    Dim UpdatingInProgressStr As String = "Bitcoin price updating is in progress."
    Dim UpdatingPausedStr As String = "Bitcoin price updating is paused."
    Dim UpdatingStoppedStr As String = "Bitcoin price updating is not in progress."
    Delegate Sub UpdateLightTooltip_Delegate(control As Control, caption As String)

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.icon50
        SellAllBTCButton.BackgroundImage = My.Resources.Simple_Information
        SellAllProfitInfoButton.BackgroundImage = My.Resources.Simple_Information
        BitcoinPictureBox1.BackgroundImage = My.Resources.bitcoin2
        BitcoinPictureBox2.BackgroundImage = My.Resources.bitcoin2

        If Not IsNothing(My.Settings.MainFormSize) Then
            If Not My.Settings.MainFormSize.Height = 0 AndAlso Not My.Settings.MainFormSize.Width = 0 Then
                Me.Size = My.Settings.MainFormSize
                Me.Location = New Point((My.Computer.Screen.WorkingArea.Width / 2) - (Me.Width / 2), (My.Computer.Screen.WorkingArea.Height / 2) - (Me.Height / 2))
            End If
        End If

        If IsNumeric(My.Settings.SellAllNowProfitFee) Then
            SellAllNowProfitFeeTextBox.Text = My.Settings.SellAllNowProfitFee
        Else
            SellAllNowProfitFeeTextBox.Text = 0
        End If

        If Not IsNothing(My.Settings.MoneyType) AndAlso Not My.Settings.MoneyType = "" Then
            Dim index = CurrencyTypeComboBox.Items.Add(My.Settings.MoneyType)
            CurrencyTypeComboBox.SelectedIndex = index
            ChangeColumnLabelCurrency(CurrencyTypeComboBox.Text, "USD")
        Else
            Dim index = CurrencyTypeComboBox.Items.Add("USD")
            CurrencyTypeComboBox.SelectedIndex = index
        End If

        If Not IsNothing(My.Settings.DataGridSettings) Then
            For i As Integer = 0 To My.Settings.DataGridSettings.Count - 1
                Dim rowValues() As String = Split(My.Settings.DataGridSettings(i), "<**>")
                DataGridView1.Rows.Add()
                Try
                    DataGridView1.Item(0, i).Value = rowValues(0)
                    DataGridView1.Item(1, i).Value = rowValues(1)
                    DataGridView1.Item(2, i).Value = rowValues(2)
                    DataGridView1.Item(3, i).Value = rowValues(3)
                    DataGridView1.Item(4, i).Value = rowValues(4)
                    DataGridView1.Item(5, i).Value = rowValues(5)
                    DataGridView1.Item(6, i).Value = rowValues(6)
                    DataGridView1.Item(7, i).Value = rowValues(7)
                    DataGridView1.Item(9, i).Value = CBool(rowValues(8))
                    DataGridView1.Item(10, i).Value = CStr(rowValues(9))
                    DataGridView1.Item(8, i).Value = CStr(rowValues(10))
                Catch ex As Exception
                    'MsgBox("A row's column could not be loaded")
                End Try
            Next
        End If

        If Not IsNothing(My.Settings.IgnoreLoss) Then
            IgnoreLossCheckBox.Checked = My.Settings.IgnoreLoss
        Else ' default value
            IgnoreLossCheckBox.Checked = False
        End If
        If IsNumeric(My.Settings.UpdateInterval) Then
            UpdateIntervalNumericUpDown.Value = My.Settings.UpdateInterval
        Else ' default value
            UpdateIntervalNumericUpDown.Value = 10
        End If

        If Not IsNothing(My.Settings.DataGridColumnWidths) Then
            Dim temp() As String = Split(My.Settings.DataGridColumnWidths, "<**>")
            For i As Integer = 0 To temp.Length - 1
                If DataGridView1.Columns.Count >= i Then
                    If IsNumeric(temp(i)) Then
                        DataGridView1.Columns.Item(i).Width = temp(i)
                    End If
                End If
            Next
        End If

        ToolTip1.SetToolTip(PauseButton, pauseTooltip)

        UpdateRateTimer.Interval = UpdateIntervalNumericUpDown.Value * 1000
        UpdateRateTimer.Start()
        UpdateRateTimer_Tick()

        Me.ActiveControl = Label1 ' focus nothing
        Loading = False ' loading is finished flag
    End Sub

    Private Sub MainForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        SyncLock LockUpdates
            ' save all DataGridView rows
            If Not IsNothing(My.Settings.DataGridSettings) Then
                My.Settings.DataGridSettings.Clear()
            End If
            If IsNothing(My.Settings.DataGridSettings) Then
                My.Settings.DataGridSettings = New Specialized.StringCollection
            End If
            For i As Integer = 0 To DataGridView1.Rows.Count - 1
                My.Settings.DataGridSettings.Add(DataGridView1.Item(0, i).Value & "<**>" & DataGridView1.Item(1, i).Value & "<**>" & DataGridView1.Item(2, i).Value & "<**>" & DataGridView1.Item(3, i).Value _
        & "<**>" & DataGridView1.Item(4, i).Value & "<**>" & DataGridView1.Item(5, i).Value & "<**>" & DataGridView1.Item(6, i).Value & "<**>" & DataGridView1.Item(7, i).Value _
        & "<**>" & CStr(DataGridView1.Item(9, i).Value) & "<**>" & CStr(DataGridView1.Item(10, i).Value) & "<**>" & CStr(DataGridView1.Item(8, i).Value))
            Next

            If IsNumeric(SellAllNowProfitFeeTextBox.Text) Then
                My.Settings.SellAllNowProfitFee = SellAllNowProfitFeeTextBox.Text
            ElseIf SellAllNowProfitFeeTextBox.Text = "" Then
                My.Settings.SellAllNowProfitFee = 0
            End If
            My.Settings.MoneyType = CurrencyTypeComboBox.Text
            My.Settings.IgnoreLoss = IgnoreLossCheckBox.Checked
            My.Settings.UpdateInterval = UpdateIntervalNumericUpDown.Value
            My.Settings.MainFormSize = Me.Size

            Dim ConstructWidthStr As String = DataGridView1.Columns.Item(0).Width
            For i As Integer = 1 To DataGridView1.Columns.Count - 1
                ConstructWidthStr &= "<**>"
                ConstructWidthStr &= DataGridView1.Columns.Item(i).Width
            Next
            My.Settings.DataGridColumnWidths = ConstructWidthStr
        End SyncLock
    End Sub

    ''' <summary>
    ''' New buy transaction.
    ''' </summary>
    Private Sub NewBuyButton_Click(sender As Object, e As EventArgs) Handles NewBuyButton.Click
        OpenNewNewBuySell()
        NewBuySell.ComboBox1.SelectedIndex = 0
        NewBuySell.Text = "New Sell"
    End Sub

    ''' <summary>
    ''' New sell transaction.
    ''' </summary>
    Private Sub NewSellButton_Click(sender As Object, e As EventArgs) Handles NewSellButton.Click
        OpenNewNewBuySell()
        NewBuySell.ComboBox1.SelectedIndex = 1
        NewBuySell.Text = "New Buy"
    End Sub

    ''' <summary>
    ''' Open a new NewBuySell form.
    ''' </summary>
    Private Sub OpenNewNewBuySell()
        If NewBuySell.Visible = True Then
            NewBuySell.Close()
            NewBuySell.Show()
        Else
            NewBuySell.Show()
        End If
    End Sub

    Dim PerformOnce1 As Boolean = True
    ''' <summary>
    ''' Main updating thread work.
    ''' </summary>
    Private Sub UpdateBitcoinExchangeValue()
        If Not UpdateBitcoinValue.CancellationPending Then
            Dim d1 As New UpdateLightTooltip_Delegate(AddressOf ToolTip1.SetToolTip)
            Me.Invoke(d1, New Object() {UpdateLight, UpdatingInProgressStr})
            UpdateLight.Image = My.Resources.green_light32

            Try
                If Timer1Paused = False Then
                    Dim wrGETURL As WebRequest
                    wrGETURL = WebRequest.Create("https://api.coinbase.com/v2/exchange-rates?currency=BTC")
                    wrGETURL.Timeout = 750
                    wrGETURL.Method = "GET"

                    Dim objStream As Stream
                    objStream = wrGETURL.GetResponse.GetResponseStream()
                    Dim reader As New StreamReader(objStream)
                    Dim responseFromServer As String = reader.ReadToEnd()
                    objStream.Close()

                    Dim ser As JObject = JObject.Parse(responseFromServer)
                    Dim data As List(Of JToken) = ser.Children().ToList

                    If PerformOnce1 Then
                        For Each item As JProperty In data
                            item.CreateReader()
                            Select Case item.Name
                                Case "data"
                                    For Each data2 As JProperty In item.Values
                                        If data2.Name = "rates" Then
                                            For Each data3 As JProperty In data2.Values
                                                ComboBoxItemsAdd("CurrencyTypeComboBox", data3.Name) 'CurrencyTypeComboBox.Items.Add(data3.Name)
                                            Next
                                            Exit For
                                        End If
                                    Next
                            End Select
                        Next

                        PerformOnce1 = False
                    End If

                    For Each item As JProperty In data
                        item.CreateReader()
                        Select Case item.Name
                            Case "data"
                                For Each data2 As JProperty In item.Values
                                    If data2.Name = "rates" Then
                                        For Each data3 As JProperty In data2.Values
                                            If data3.Name = CurrentMoneyType Then
                                                SetText("CurrPriceBTCTextBox", data3.Value) ' CurrPriceBTCTextBox.Text = data3.Value
                                                Exit For
                                            End If
                                        Next
                                        Exit For
                                    End If
                                Next
                        End Select
                    Next
                End If

                PerformUpdates()

            Catch ex1 As System.Net.WebException
                If ex1.Status = 14 Then ' Timeout
                    'MsgBox("System.Net.WebException" & vbNewLine & ex1.Message.ToString)
                End If
            Catch ex As Exception
            End Try

            If Not UpdateBitcoinValue.CancellationPending Then
                Dim d2 As New UpdateLightTooltip_Delegate(AddressOf ToolTip1.SetToolTip)
                Me.Invoke(d2, New Object() {UpdateLight, UpdatingStoppedStr})
                UpdateLight.Image = My.Resources.red_light32
            End If
        End If
    End Sub

    Delegate Sub SetText_Callback(ByVal TextBoxRef As String, ByVal [text] As String)
    ''' <summary>
    ''' Set a TextBox control's Text property from within a thread.
    ''' </summary>
    Private Sub SetText(ByVal TextBoxRef As String, ByVal [text] As String)
        Dim Control1 As Object = Me.Controls.Find(TextBoxRef, True)
        Dim tb As TextBox = DirectCast(Control1(0), TextBox)
        If tb.InvokeRequired Then
            Dim d As New SetText_Callback(AddressOf SetText)
            Me.Invoke(d, New Object() {TextBoxRef, [text]})
        Else
            tb.Text = [text]
        End If
    End Sub

    Delegate Sub ComboBoxItemsAdd_Callback(ByVal ComboBoxRef As String, ByVal [text] As String)
    ''' <summary>
    ''' Add a ComboBox Item from within a thread.
    ''' </summary>
    Private Sub ComboBoxItemsAdd(ByVal ComboBoxRef As String, ByVal [text] As String)
        Dim Control1 As Object = Me.Controls.Find(ComboBoxRef, True)
        Dim tb As ComboBox = DirectCast(Control1(0), ComboBox)
        If tb.InvokeRequired Then
            Dim d As New ComboBoxItemsAdd_Callback(AddressOf ComboBoxItemsAdd)
            Me.Invoke(d, New Object() {ComboBoxRef, [text]})
        Else
            If Not IsNothing(My.Settings.MoneyType) AndAlso Not My.Settings.MoneyType = "" Then
                If Not [text] = My.Settings.MoneyType AndAlso Not [text] = "BTC" Then ' user money type is added on load
                    tb.Items.Add([text])
                End If
            End If
        End If
    End Sub

    ''' <summary>
    ''' Perform updates on displays
    ''' </summary>
    Public Sub PerformUpdates()
        UpdateTotalBitcoins() ' update total bitcoins display
        UpdateRowSpecificProfit() ' update each row's potential profit if sold at current Bitcoin price
        UpdateRowSpecificBreakEvenPoint() ' update each row's break even Bitcoin price
        UpdateSellNowRevenue() ' update total potential revenue display
        UpdateTotalPossibleProfit() ' update total potential profit display
    End Sub

    ''' <summary>
    ''' Updates each BUY/GAIN transcation's row specific profit if sold at the current Bitcoin price.
    ''' </summary>
    Public Sub UpdateRowSpecificProfit()
        SyncLock LockUpdates
            For i As Integer = 0 To DataGridView1.Rows.Count - 1
                If (IsNumeric(DataGridView1.Item(5, i).Value) AndAlso IsNumeric(DataGridView1.Item(2, i).Value) AndAlso IsNumeric(DataGridView1.Item(3, i).Value)) AndAlso
                    IsNumeric(CurrPriceBTCTextBox.Text) AndAlso
                    (DataGridView1.Item(0, i).Value = "BUY" OrElse DataGridView1.Item(0, i).Value = "GAIN") Then

                    If CDec(CurrPriceBTCTextBox.Text) = 0D Then ' equals 0
                        DataGridView1.Item(6, i).Value = "-100 %" ' percent change
                        DataGridView1.Item(7, i).Value = -CDec(DataGridView1.Item(3, i).Value)  ' profit
                    Else
                        Dim Fee As Decimal = 0D
                        If IsNumeric(DataGridView1.Item(4, i).Value) Then
                            Fee = CDec(DataGridView1.Item(4, i).Value)
                        End If

                        Dim BTC As Decimal = DataGridView1.Item(2, i).Value
                        Dim USD As Decimal = DataGridView1.Item(3, i).Value
                        Dim RowSpecificBTCPrice As Decimal = DataGridView1.Item(5, i).Value

                        Dim Gross As Decimal = ((BTC * CDec(CurrPriceBTCTextBox.Text)) * (1D - (Fee / 100D)))
                        Dim Profit As Decimal = Gross - USD
                        Dim PercentChange As Decimal = Profit / USD

                        Try
                            DataGridView1.Item(6, i).Value = Math.Round(PercentChange * 100D, 4) & " %"
                        Catch
                            DataGridView1.Item(6, i).Value = "--"
                        End Try
                        Try
                            DataGridView1.Item(7, i).Value = Math.Round(Profit, 2)
                        Catch
                            DataGridView1.Item(7, i).Value = "--"
                        End Try
                    End If
                Else
                    DataGridView1.Item(6, i).Value = "--"
                    DataGridView1.Item(7, i).Value = "--"
                End If
            Next
        End SyncLock
    End Sub

    ''' <summary>
    ''' Updates each BUY transcation's row specific break-even point for selling. (Reliant on that row's fee)
    ''' </summary>
    Private Sub UpdateRowSpecificBreakEvenPoint()
        SyncLock LockUpdates
            For i As Integer = 0 To DataGridView1.Rows.Count - 1
                If (DataGridView1.Item(0, i).Value = "BUY") Then

                    Dim FeePercent As Decimal = 0D
                    If IsNumeric(DataGridView1.Item(4, i).Value) Then
                        FeePercent = DataGridView1.Item(4, i).Value
                    End If
                    DataGridView1.Item(8, i).Value = Math.Round((100D * CDec(DataGridView1.Item(3, i).Value)) / ((100D - FeePercent) * CDec(DataGridView1.Item(2, i).Value)), 4)
                Else
                    DataGridView1.Item(8, i).Value = "--"
                End If
            Next
        End SyncLock
    End Sub

    ''' <summary>
    ''' Revenue info (show your work) button.
    ''' </summary>
    Private Sub SellAllBTCButton_Click(sender As Object, e As EventArgs) Handles SellAllBTCButton.MouseDown
        'Dim BuysList As List(Of String) = New List(Of String)
        'Dim SellsList As List(Of String) = New List(Of String)
        Dim TotalBTC As Decimal = 0D
        Dim TotalUSD As Decimal = 0D
        Dim CurrPriceBTC As Decimal = 0D
        Dim Fee As Decimal = 0D
        Dim SellAllNowProfitFee As String = "0"
        Dim temp As Decimal

        SyncLock LockUpdates
            ComputeTotalBTCandUSD(TotalBTC, TotalUSD)

            If TotalBTC > 0 Then
                If IsNumeric(SellAllNowProfitFeeTextBox.Text) Then
                    Fee = CDec(SellAllNowProfitFeeTextBox.Text) / 100D
                    SellAllNowProfitFee = SellAllNowProfitFeeTextBox.Text
                End If
                If IsNumeric(CurrPriceBTCTextBox.Text) Then
                    CurrPriceBTC = CDec(CurrPriceBTCTextBox.Text)
                End If
                temp = TotalBTC * CurrPriceBTC
            End If
        End SyncLock

        If TotalBTC > 0 Then
            MsgBox(TotalBTC & "BTC * $" & CurrPriceBTC & " - $" & (temp * Fee) & " = $" & temp - (temp * Fee) & vbNewLine & vbNewLine &
            "Total BTC * Current BTC Price - " & (temp * Fee) & " (" & SellAllNowProfitFee & "% Fee) = Total Revenue")
        ElseIf TotalBTC < 0 Then
            MsgBox("Total Bitcoins is less than zero: " & TotalBTC)
        ElseIf TotalBTC = 0 Then
            MsgBox("Total bitcoins = 0")
        End If
    End Sub

    ''' <summary>
    ''' Updates "sell all now revenue" TextBox.
    ''' </summary>
    Public Sub UpdateSellNowRevenue()
        SyncLock LockUpdates
            If CDec(TotalBitcoinsTextBox.Text) > 0 Then
                Dim temp As Decimal
                If Not IsNumeric(CurrPriceBTCTextBox.Text) Then
                    temp = CDec(TotalBitcoinsTextBox.Text) * 0D
                Else
                    temp = CDec(TotalBitcoinsTextBox.Text) * CDec(CurrPriceBTCTextBox.Text)
                End If
                Dim Fee As Decimal = 0D
                If IsNumeric(SellAllNowProfitFeeTextBox.Text) Then
                    Fee = CDec(SellAllNowProfitFeeTextBox.Text) / 100D
                End If
                SetText("SellAllNowRevenueTextBox", Math.Round(temp - (temp * Fee), 2))
            Else
                SetText("SellAllNowRevenueTextBox", "0")
            End If
        End SyncLock
    End Sub

    ''' <summary>
    ''' Update total sell now profit TextBox.
    ''' </summary>
    Public Sub UpdateTotalPossibleProfit()
        SyncLock LockUpdates
            Dim TotalBTC As Decimal = 0D
            Dim TotalUSD As Decimal = 0D
            Dim BuyUSD As Decimal = 0D
            Dim SellUSD As Decimal = 0D
            Dim Fee As Decimal = 1D

            If DataGridView1.Rows.Count > 0 Then
                ComputeTotalBTCandUSD(TotalBTC, TotalUSD, BuyUSD, SellUSD)
                If Not IsNumeric(CurrPriceBTCTextBox.Text) Then
                    SetText("SellAllNowProfitTextBox", "0")
                Else
                    ' add total profit columns together
                    If IsNumeric(SellAllNowProfitFeeTextBox.Text) Then
                        Fee = (1 - CDec(SellAllNowProfitFeeTextBox.Text) / 100)
                    End If
                    SetText("SellAllNowProfitTextBox", Math.Round(((TotalBTC * CurrPriceBTCTextBox.Text) * Fee) + (SellUSD - BuyUSD), 2))
                End If
            Else
                SetText("SellAllNowProfitTextBox", "0")
            End If
        End SyncLock
    End Sub

    ''' <summary>
    ''' Profit info (show your work) button.
    ''' </summary>
    Private Sub SellAllProfitInfoButton_Click(sender As Object, e As EventArgs) Handles SellAllProfitInfoButton.Click
        Dim TotalBTC As Decimal = 0D
        Dim TotalUSD As Decimal = 0D
        Dim BuyUSD As Decimal = 0D
        Dim SellUSD As Decimal = 0D
        Dim CurrPriceBTC As Decimal = 0D
        Dim Fee As Decimal = 1D

        If DataGridView1.Rows.Count > 0 Then
            SyncLock LockUpdates
                ComputeTotalBTCandUSD(TotalBTC, TotalUSD, BuyUSD, SellUSD)
                If IsNumeric(CurrPriceBTCTextBox.Text) Then
                    CurrPriceBTC = CDec(CurrPriceBTCTextBox.Text)
                End If
                If IsNumeric(SellAllNowProfitFeeTextBox.Text) Then
                    Fee = 1D - (CDec(SellAllNowProfitFeeTextBox.Text) / 100D)
                End If
            End SyncLock
            MsgBox("[ ( " & TotalBTC & " BTC * $" & CurrPriceBTC & " ) * " & Fee & " ] + ( $" & SellUSD & " - $" & BuyUSD & " ) = $" &
                    Math.Round(((TotalBTC * CurrPriceBTC) * Fee) + (SellUSD - BuyUSD), 2) & vbNewLine & vbNewLine &
                    "[ ( Total BTC * Current BTC price ) * (Fee multiplier) ] + ( Sell USD - Buy USD ) = Total Profit")
        Else
            MsgBox("0")
        End If
    End Sub

    ''' <summary>
    ''' Computes the total bitcoins and total buy and sell money.
    ''' </summary>
    Private Sub ComputeTotalBTCandUSD(ByRef TotalBTC As Decimal, ByRef TotalUSD As Decimal, ByRef Optional BuyUSD As Decimal = 0D, ByRef Optional SellUSD As Decimal = 0D)
        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            If CBool(DataGridView1.Item(9, i).Value) = False Then

                If DataGridView1.Item(0, i).Value = "BUY" Then
                    TotalBTC += (CDec(DataGridView1.Item(2, i).Value))
                    BuyUSD += (CDec(DataGridView1.Item(3, i).Value))
                    'TotalUSD -= (CDec(DataGridView1.Item(3, i).Value))
                    'BuysList.Add(DataGridView1.Item(2, i).Value)
                ElseIf DataGridView1.Item(0, i).Value = "SELL" Then
                    'SellsList.Add(DataGridView1.Item(2, i).Value)
                    TotalBTC -= (CDec(DataGridView1.Item(2, i).Value))
                    SellUSD += (CDec(DataGridView1.Item(3, i).Value))
                    'TotalUSD += (CDec(DataGridView1.Item(3, i).Value))
                ElseIf DataGridView1.Item(0, i).Value = "LOSS" Then

                    ' loss of BTC and/or USD
                    If Not IsNothing(DataGridView1.Item(2, i).Value) Then
                        If DataGridView1.Item(2, i).Value >= 0 Then
                            TotalBTC -= (CDec(DataGridView1.Item(2, i).Value))
                        Else
                            TotalBTC += (CDec(DataGridView1.Item(2, i).Value))
                        End If
                    End If
                    If Not IsNothing(DataGridView1.Item(3, i).Value) Then
                        If DataGridView1.Item(3, i).Value >= 0 Then
                            'TotalUSD -= (CDec(DataGridView1.Item(3, i).Value))
                            If IgnoreLossCheckBox.Checked = True Then
                                BuyUSD -= (CDec(DataGridView1.Item(3, i).Value))
                            End If
                        Else
                            'TotalUSD += (CDec(DataGridView1.Item(3, i).Value))
                            If IgnoreLossCheckBox.Checked = True Then
                                BuyUSD += (CDec(DataGridView1.Item(3, i).Value))
                            End If
                        End If
                    End If

                ElseIf DataGridView1.Item(0, i).Value = "GAIN" Then

                    ' gain of BTC and/or USD
                    If Not IsNothing(DataGridView1.Item(2, i).Value) Then
                        If DataGridView1.Item(2, i).Value >= 0 Then
                            TotalBTC += (CDec(DataGridView1.Item(2, i).Value))
                        Else
                            TotalBTC += (CDec(DataGridView1.Item(2, i).Value))
                        End If
                    End If
                    If Not IsNothing(DataGridView1.Item(3, i).Value) Then
                        If DataGridView1.Item(3, i).Value >= 0 Then
                            'TotalUSD += (CDec(DataGridView1.Item(3, i).Value))
                        Else
                            'TotalUSD += (CDec(DataGridView1.Item(3, i).Value))
                        End If
                    End If
                End If
            End If
        Next
    End Sub

    ''' <summary>
    ''' Update total Bitcoins TextBox
    ''' </summary>
    Public Sub UpdateTotalBitcoins()
        SyncLock LockUpdates
            Dim TotalBTC As Decimal
            For i As Integer = 0 To DataGridView1.Rows.Count - 1
                If CBool(DataGridView1.Item(9, i).Value) = False Then

                    If DataGridView1.Item(0, i).Value = "BUY" Then
                        TotalBTC += (CDec(DataGridView1.Item(2, i).Value))
                    ElseIf DataGridView1.Item(0, i).Value = "SELL" Then
                        TotalBTC -= (CDec(DataGridView1.Item(2, i).Value))
                    ElseIf DataGridView1.Item(0, i).Value = "LOSS" Then
                        ' loss of BTC and/or USD
                        If Not IsNothing(DataGridView1.Item(2, i).Value) Then
                            If DataGridView1.Item(2, i).Value >= 0 Then
                                TotalBTC -= (CDec(DataGridView1.Item(2, i).Value))
                            Else
                                TotalBTC += (CDec(DataGridView1.Item(2, i).Value))
                            End If
                        End If
                    ElseIf DataGridView1.Item(0, i).Value = "GAIN" Then
                        ' gain of BTC and/or USD
                        If Not IsNothing(DataGridView1.Item(2, i).Value) Then
                            If DataGridView1.Item(2, i).Value >= 0 Then
                                TotalBTC += (CDec(DataGridView1.Item(2, i).Value))
                            Else
                                TotalBTC += (CDec(DataGridView1.Item(2, i).Value))
                            End If
                        End If
                    End If
                End If
            Next

            SetText("TotalBitcoinsTextBox", TotalBTC)
        End SyncLock
    End Sub

    ''' <summary>
    ''' Update Bitcoin exchange price timer tick.
    ''' </summary>
    Private Sub UpdateRateTimer_Tick() Handles UpdateRateTimer.Tick
        UpdateRateTimer.Stop() ' timer is restarted when work is complete in thread
        If Not UpdateBitcoinValue.IsBusy = True Then
            UpdateBitcoinValue.RunWorkerAsync()
        End If
    End Sub

    Private Sub UpdateBitcoinValue_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles UpdateBitcoinValue.RunWorkerCompleted
        If Not Timer1Paused Then
            UpdateRateTimer.Start() ' restart the update Bitcoin rate timer now that work is complete
        End If
    End Sub

    Private Sub UpdateBitcoinValue_DoWork(sender As Object, e As DoWorkEventArgs) Handles UpdateBitcoinValue.DoWork
        UpdateBitcoinExchangeValue() ' perform Bitcoin price updating work and other updates
    End Sub

    Dim pauseTooltip As String = "Pause the updating of the exchange rates and other info."
    Dim playTooltip As String = "Resume the updating of the exchange rates and other info."
    Dim Timer1Paused As Boolean = False
    ''' <summary>
    ''' Pause the periodic updating of the Bitcoin price and other data.
    ''' </summary>
    Private Sub PauseButton_Click(sender As Object, e As EventArgs) Handles PauseButton.Click
        If Timer1Paused = True Then
            Timer1Paused = False
            UpdateRateTimer.Interval = UpdateIntervalNumericUpDown.Value * 1000
            UpdateRateTimer_Tick()
            UpdateRateTimer.Start()
            CurrPriceBTCTextBox.ReadOnly = True
            ToolTip1.SetToolTip(PauseButton, pauseTooltip)
            PauseButton.Image = My.Resources.Pause
        Else
            Timer1Paused = True
            UpdateBitcoinValue.CancelAsync()
            UpdateRateTimer.Stop()
            ToolTip1.SetToolTip(UpdateLight, UpdatingPausedStr)
            UpdateLight.Image = My.Resources.yellow_light32
            CurrPriceBTCTextBox.ReadOnly = False
            ToolTip1.SetToolTip(PauseButton, playTooltip)
            PauseButton.Image = My.Resources.Play
        End If
    End Sub

    ''' <summary>
    ''' Change the Currencies used in column labels. (USD is default)
    ''' </summary>
    Private Sub ChangeColumnLabelCurrency(NewMoneyType As String, OldMoneyType As String)
        CurrentMoneyType = NewMoneyType
        DataGridView1.Columns.Item(3).HeaderText = NewMoneyType

        Dim StrBuild = Split(DataGridView1.Columns.Item(6).HeaderText, OldMoneyType)
        Dim NewStr As String = ""
        If StrBuild.Length > 1 Then
            NewStr = NewMoneyType
            For Each element As String In StrBuild
                NewStr &= element
            Next
        End If
        DataGridView1.Columns.Item(6).HeaderText = NewStr

        If NewBuySell.Visible = True Then
            NewBuySell.Label2.Text = NewMoneyType
        End If
    End Sub

    Public CurrentMoneyType As String = "" ' holds current value of CurrencyTypeComboBox.Text
    ''' <summary>
    ''' Change the current currency in use for bitcoin price and display purposes.
    ''' </summary>
    Private Sub CurrencyTypeComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CurrencyTypeComboBox.SelectedIndexChanged
        If Loading = False Then
            ChangeColumnLabelCurrency(CurrencyTypeComboBox.Text, CurrentMoneyType)
        End If
    End Sub

    Private Sub CurrPriceBTCTextBox_TextChanged(sender As Object, e As EventArgs) Handles CurrPriceBTCTextBox.TextChanged
        If Timer1Paused = True Then
            PerformUpdates()
        End If
    End Sub

    Private Sub UpdateIntervalNumericUpDown_ValueChanged(sender As Object, e As EventArgs) Handles UpdateIntervalNumericUpDown.ValueChanged
        If Loading = False Then
            UpdateRateTimer.Stop()
            UpdateRateTimer.Interval = UpdateIntervalNumericUpDown.Value * 1000
            If Timer1Paused = False Then
                UpdateRateTimer.Start()
            End If
        End If
    End Sub

    Private Sub ChangesWereMade() Handles SellAllNowProfitFeeTextBox.TextChanged, IgnoreLossCheckBox.CheckedChanged
        If Loading = False Then
            PerformUpdates()
        End If
    End Sub

    Dim DataGridUserEdit As Boolean = False
    Private Sub DataGridView1_MouseDown(sender As Object, e As MouseEventArgs) Handles DataGridView1.MouseDown
        DataGridUserEdit = True
    End Sub

    Private Sub DataGridView1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        If Loading = False AndAlso DataGridUserEdit = True Then
            DataGridUserEdit = False
            PerformUpdates()
        End If
    End Sub

    Private Sub AboutButton_Click(sender As Object, e As EventArgs) Handles AboutButton.Click
        About.Show()
    End Sub

End Class
