Public Class Form4
    Dim orders As ArrayList
    Public Function InitializeList()
        orders = Form1.getList()
    End Function

    Public Function LoadTotal()
        Dim sum As Integer = getTotal()
        TextBox2.Text = sum
    End Function
    Public Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeList()
        LoadTotal()
    End Sub
    Public Function LoadRevenueOfDate()
        Dim str = TextBox1.Text
        Dim format() = {"dd/MM/yyyy", "d/M/yyyy", "dd-MM-yyyy"}
        Dim value As Date = Date.ParseExact(str, format,
                System.Globalization.DateTimeFormatInfo.InvariantInfo,
                Globalization.DateTimeStyles.None)
        Dim sum As Integer = TotalOnDay(value)
        TextBox3.Text = sum
    End Function
    Public Function FormatMoney(ByVal str As String) As String
        str = str.ToArray()
        For i = str.Length - 3 To 1 Step -3
            str = str.Insert(i, ".")
        Next
        MessageBox.Show(str)
        str.ToString()
        Return str
    End Function
    Public Function TotalOnDay(value As Date) As Integer
        Dim sum As Integer = 0
        For Each order As Order In orders
            If Date.Compare(value, order.oDayOfOrder) = 0 Then
                sum += order.oTotal
            End If
        Next
        Return sum
    End Function
    Public Function getTotal() As Integer
        Dim sum As Integer = 0
        For Each order As Order In orders
            sum += order.oTotal
        Next
        Return sum
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        LoadRevenueOfDate()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class