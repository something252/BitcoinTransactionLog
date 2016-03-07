Public Class NewBuySell
    Dim Loading As Boolean = True

    Private Sub NewBuySell_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.icon50

        ComboBox1.Items.Add("BUY")
        ComboBox1.Items.Add("SELL")
        ComboBox1.Items.Add("LOSS")
        ComboBox1.Items.Add("GAIN")

        If MainForm.CurrencyTypeComboBox.Text = "USD" Then
            Label2.Text = MainForm.CurrencyTypeComboBox.Text & " ($)"
        ElseIf Not MainForm.CurrencyTypeComboBox.Text = "" Then
            Label2.Location = New Point(Label2.Location.X + 12, Label2.Location.Y)
            Label2.Text = MainForm.CurrencyTypeComboBox.Text
        End If

        If IsNumeric(MainForm.SellAllNowProfitFeeTextBox.Text) Then
            FeeChargedTextBox.Text = MainForm.SellAllNowProfitFeeTextBox.Text
        End If

        Loading = False
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

        If ComboBox1.SelectedItem = "LOSS" OrElse ComboBox1.SelectedItem = "GAIN" Then
            FeeChargedTextBox.Text = ""
            FeeChargedTextBox.Enabled = False

            BTCExchangeRateTextBox.Text = ""
            BTCExchangeRateTextBox.Enabled = False

        Else
            FeeChargedTextBox.Enabled = True
            BTCExchangeRateTextBox.Enabled = True

            If IsNumeric(MainForm.SellAllNowProfitFeeTextBox.Text) Then
                FeeChargedTextBox.Text = MainForm.SellAllNowProfitFeeTextBox.Text
            End If
        End If
    End Sub

    Private Sub ConfirmButton_Click(sender As Object, e As EventArgs) Handles ConfirmButton.Click
        If (ComboBox1.SelectedItem = "BUY" OrElse ComboBox1.SelectedItem = "SELL") Then
            If Not IsNumeric(BTCTextBox.Text) Then
                MsgBox("BTC TextBox is not numeric!", MsgBoxStyle.Critical, "Warning")
            ElseIf Not IsNumeric(USDTextBox.Text) Then
                MsgBox("USD TextBox is not numeric!", MsgBoxStyle.Critical, "Warning")
            ElseIf Not IsNumeric(FeeChargedTextBox.Text) Then
                MsgBox("Fee Charged TextBox is not numeric!", MsgBoxStyle.Critical, "Warning")
            ElseIf Not IsNumeric(BTCExchangeRateTextBox.Text) Then
                MsgBox("BTC Exchange Rate TextBox is not numeric!", MsgBoxStyle.Critical, "Warning")
            Else ' all is well
                CreateRow()
            End If
        ElseIf (ComboBox1.SelectedItem = "LOSS" OrElse ComboBox1.SelectedItem = "GAIN") Then
            If Not IsNumeric(BTCTextBox.Text) Then
                MsgBox("BTC TextBox is not numeric!", MsgBoxStyle.Critical, "Warning")
            ElseIf Not IsNumeric(USDTextBox.Text) Then
                MsgBox("USD TextBox is not numeric!", MsgBoxStyle.Critical, "Warning")
            Else ' all is well
                CreateRow()
            End If
        End If

    End Sub

    Private Sub CreateRow()
        Dim Meridiem As String
        If DateTimePicker2.Value.Hour < 12 Then
            Meridiem = "AM"
        Else
            Meridiem = "PM"
        End If
        Dim BTCTextBoxTemp As String = BTCTextBox.Text
        Dim USDTextBoxTemp As String = USDTextBox.Text
        Dim FeeTextBoxTemp As String = FeeChargedTextBox.Text
        Dim BTCExchangeRateTextBoxTemp As String = BTCExchangeRateTextBox.Text

        MainForm.DataGridView1.Rows.Add(ComboBox1.SelectedItem, DateTimePicker1.Value.Month & "/" & DateTimePicker1.Value.Day & "/" & DateTimePicker1.Value.Year _
                                       & " " & DateTimePicker2.Value.Hour & ":" & DateTimePicker2.Value.Minute & ":" & DateTimePicker2.Value.Second & " " & Meridiem,
                                       BTCTextBoxTemp,
                                       USDTextBoxTemp,
                                       FeeTextBoxTemp,
                                       BTCExchangeRateTextBoxTemp)
        MainForm.PerformUpdates()

        Me.Close()
    End Sub

    Private Sub BTCAndUSD_TextChanged() Handles USDTextBox.TextChanged, BTCTextBox.TextChanged, FeeChargedTextBox.TextChanged
        If BTCExchangerateLockCheckBox.Checked = True Then
            If IsNumeric(USDTextBox.Text) AndAlso IsNumeric(BTCTextBox.Text) AndAlso Not BTCTextBox.Text = 0 Then

                Dim Fee As Decimal = 0D
                If IsNumeric(FeeChargedTextBox.Text) Then
                    Fee = FeeChargedTextBox.Text
                End If

                Try
                    BTCExchangeRateTextBox.Text = Math.Round((1D / CDec(BTCTextBox.Text)) * (CDec(USDTextBox.Text) * (1D - (Fee / 100D))), 5)
                Catch ex As Exception
                    BTCExchangeRateTextBox.Text = "Error"
                End Try

            Else
                BTCExchangeRateTextBox.Text = "0"
            End If
        End If
    End Sub

    Private Sub BTCExchangerateLockCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles BTCExchangerateLockCheckBox.CheckedChanged
        If Not Loading Then
            If BTCExchangerateLockCheckBox.Checked Then
                BTCExchangeRateTextBox.ReadOnly = True
                BTCAndUSD_TextChanged()
            Else
                BTCExchangeRateTextBox.ReadOnly = False
            End If
        End If
    End Sub

End Class