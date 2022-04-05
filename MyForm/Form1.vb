Imports System.IO
Public Class Form1
    Private orders As New ArrayList
    Private ID As Integer
    Private orderdetails As New ArrayList
    Private IDTobeDel As Integer = -1
    Public Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData()
        WriteDataToListView()
    End Sub
    'Public Function WriteDataToGridView()
    '    For Each order In orders
    '        DataGridView1.Rows.Add(order.oID, order.oCustomer.CusName, Date.Parse(order.oDayOfOrder).ToString("dd-MM-yyyy"), order.oTotal)
    '    Next
    'End Function
    Public Function WriteDataToListView()


        For Each order As Order In orders
            Dim itm As New ListViewItem()
            itm.Text = order.oID
            itm.SubItems.Add(order.oCustomer.CusName)
            itm.SubItems.Add(Date.Parse(order.oDayOfOrder).ToString("dd/MM/yyyy"))
            itm.SubItems.Add(order.oTotal)
            ListView1.Items.Add(itm)


        Next





    End Function
    Public Property getID() As Integer
        Get
            Return Me.ID
        End Get
        Set(value As Integer)
        End Set
    End Property
    Public Property getList() As ArrayList
        Get
            Return Me.orders
        End Get
        Set(value As ArrayList)

        End Set
    End Property
    Public Function LoadData() As Boolean
        Dim sr As StreamReader = New StreamReader("D:\MyFormUpdate2\MyForm\MyForm\Customer.txt")
        orders.Clear()
        Me.ID = 0
        Try
            Do Until sr.EndOfStream
                Dim line() As String = sr.ReadLine.ToString.Split(vbTab)
                Dim temp As New Order
                temp.oID = Integer.Parse(line(0))
                temp.oCustomer.CusName = line(1)
                Dim format() = {"dd/MM/yyyy", "d/M/yyyy", "dd-MM-yyyy"}
                temp.oDayOfOrder = Date.ParseExact(line(2), format,
                System.Globalization.DateTimeFormatInfo.InvariantInfo,
                Globalization.DateTimeStyles.None)
                temp.oTotal = Integer.Parse(line(3))
                orders.Add(temp)
                Me.ID += 1
            Loop
        Catch ex As Exception
            MessageBox.Show("Fail")
            Return False
        Finally
            sr.Close()
        End Try
        Return True
    End Function

    Public Function clearListView()
        Dim count As Integer = ListView1.Items.Count
        For i As Integer = count - 1 To 0 Step -1
            ListView1.Items(i).Remove()
        Next

    End Function
    'Public Function clearDataGridView()
    '    DataGridView1.DataSource = Nothing
    '    DataGridView1.Rows.Clear()

    'End Function
    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Form2.Show()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Form3.Show()
    End Sub

    Public Function WriteFile()
        Dim sw As StreamWriter = New StreamWriter("D:\MyFormUpdate2\MyForm\MyForm\Customer.txt", False)
        Try
            For Each order As Order In orders
                sw.WriteLine(order.oID & vbTab & order.oCustomer.CusName & vbTab & order.oDayOfOrder.ToString("dd-MM-yyyy") & vbTab & order.oTotal)
            Next
        Catch ex As Exception
            Return False
        Finally
            sw.Close()
        End Try
        Return True
    End Function
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form5.Show()
    End Sub
    Public Function FindID() As Integer
        Dim id As String
        If IsNothing(ListView1.FocusedItem) = False Then
            id = ListView1.FocusedItem.Text
        Else
            id = InputBox("Nhập ID cần xóa")
        End If
        If id <> "" Then
            Return Integer.Parse(id)
        Else
            Return -1
        End If



    End Function





    Public Function changeIndex(ByVal value As Integer)
        For i = orders.Count - 1 To value - 1 Step -1
            orders(i).oID -= 1
        Next
    End Function
    Public Function DelOrderByListView(id As Integer)
        orders.RemoveAt(id - 1)
        changeIndex(id)
        LoadDataFromOrderDetail()
        DelDataFromOrderDetail2(id)
        WriteDataToOrderDetail()
        WriteFile()
        clearListView()
        LoadData()
        WriteDataToListView()


    End Function
    'Public Function DelOrder()
    '    Dim row = DataGridView1.CurrentCell.RowIndex
    '    Dim value = DataGridView1.Rows(row).Cells(0).Value
    '    orders.RemoveAt(value - 1)
    '    changeIndex(value)
    '    LoadDataFromOrderDetail()
    '    DelDataFromOrderDetail2(value)
    '    WriteDataToOrderDetail()
    '    WriteFile()
    '    clearDataGridView()
    '    LoadData()
    '    WriteDataToGridView()
    'End Function
    Public Function WriteDataToOrderDetail()
        Dim sw As StreamWriter = New StreamWriter("D:\MyFormUpdate2\MyForm\MyForm\Customer.txt", False)
        Try
            For Each orderdetail As OrderDetail In orderdetails
                sw.WriteLine(orderdetail.OrdDetailID & vbTab & orderdetail.OrdDetailCustomer.CusName & vbTab & orderdetail.OrdDetailProduct.pID & vbTab & orderdetail.OrdDetailProduct.pName & vbTab & orderdetail.OrdDetailProduct.pPrice & vbTab & orderdetail.OrderDetailQuantity & vbTab & orderdetail.OrdDetailTotal & vbTab & orderdetail.OrdDetailOrdID)
            Next
        Catch ex As Exception
            Return False
        Finally
            sw.Close()
        End Try
        Return True
    End Function
    Public Function DelDataFromOrderDetail2(ByVal value As Integer)
        Dim count As Integer = orderdetails.Count - 1
        For i = 0 To count
            If orderdetails(i).OrdDetailOrdID = value Then
                orderdetails.RemoveAt(i)
                For j = orderdetails.Count - 1 To i Step -1
                    orderdetails(j).OrdDetailID -= 1
                Next
                count -= 1
                i -= 1
            End If
            If i >= count Then
                Exit For
            End If
        Next
        For Each orderdetail As OrderDetail In orderdetails
            If orderdetail.OrdDetailOrdID > value Then
                orderdetail.OrdDetailOrdID -= 1
            End If
        Next
    End Function
    Public Function DelDataFromOrderDetail(ByVal value As Integer)
        Dim count As Integer = orderdetails.Count - 1
        Dim flag As Integer = 0
        For i = 0 To count
            If orderdetails(i).OrdDetailOrdID = value Then
                flag = i
                orderdetails.RemoveAt(i)
                For j = orderdetails.Count - 1 To i Step -1
                    orderdetails(j).OrdDetailID -= 1
                Next
                count -= 1
                i -= 1
            End If
            If i >= count Then
                Exit For
            End If
        Next
        For i = orderdetails.Count - 1 To flag Step -1
            orderdetails(i).OrdDetailOrdID -= 1
        Next
    End Function
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form4.Show()
    End Sub
    Public Function checked()
        MessageBox.Show(orderdetails.Count)
        For Each orderdetail As OrderDetail In orderdetails
            MessageBox.Show(orderdetail.OrdDetailID & orderdetail.OrdDetailCustomer.CusName & orderdetail.OrdDetailOrdID)
        Next

    End Function


    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        End
    End Sub
    Public Function LoadDataFromOrderDetail()
        orderdetails.Clear()
        Dim sr As StreamReader = New StreamReader("D:\MyFormUpdate2\MyForm\MyForm\Orderdetail")
        Try
            Do Until sr.EndOfStream
                Dim line() As String = sr.ReadLine.ToString.Split(vbTab)
                Dim orderdetail As New OrderDetail
                orderdetail.OrdDetailID = Integer.Parse(line(0))
                orderdetail.OrdDetailCustomer.CusName = line(1)
                orderdetail.OrdDetailProduct.pID = Integer.Parse(line(2))
                orderdetail.OrdDetailProduct.pName = line(3)
                orderdetail.OrdDetailProduct.pPrice = line(4)
                orderdetail.OrderDetailQuantity = line(5)
                orderdetail.OrdDetailTotal = Integer.Parse(line(6))
                orderdetail.OrdDetailOrdID = Integer.Parse(line(7))
                orderdetails.Add(orderdetail)
            Loop
        Catch ex As Exception
            MessageBox.Show("Fail")
            Return -1
        Finally
            sr.Close()
        End Try
        Return True
    End Function
    Public Function FindCustomer(ByVal str As String) As Boolean
        For Each order As Order In orders
            If order.oCustomer.CusName = str Then
                Return True
            End If
        Next
        Return False
    End Function
    Public Function CalSum(ByVal str As String) As Integer
        Dim sum As Integer = 0
        For Each order As Order In orders
            If order.oCustomer.CusName = str Then
                sum += order.oTotal
            End If
        Next
        Return sum

    End Function
    Public Function TotalOfCustomer()
        Dim customerName = TextBox1.Text
        If FindCustomer(customerName) Then
            Dim sum = CalSum(customerName)
            MessageBox.Show("Tổng hóa đơn của " + customerName + " là " + sum.ToString())
        ElseIf TextBox1.Text = "" Then
            MessageBox.Show("Không được để trống")
        Else
            MessageBox.Show("Không tìm thấy khách hàng cần tìm")
        End If
    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TotalOfCustomer()
    End Sub

    Public Function ToDelOrder()
        Dim id As Integer = FindID()
        GroupBox1.Enabled = True
        GroupBox1.Visible = True
        Dim value As String
        If RadioButton1.Checked Then
            value = RadioButton1.Text
            MessageBox.Show(value)
        ElseIf RadioButton2.Checked Then
            value = RadioButton2.Text
        End If
        If value = "Có" Then
            DelOrderByListView(id)
            MessageBox.Show(value)
        End If

    End Function
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.IDTobeDel = FindID()
        If Me.IDTobeDel <> -1 Then
            GroupBox1.Enabled = True
            GroupBox1.Visible = True
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim value As String
        If RadioButton1.Checked Then
            value = RadioButton1.Text

        ElseIf RadioButton2.Checked Then
            value = RadioButton2.Text
        End If
        If value = "Có" Then
            DelOrderByListView(ID)
        End If
        GroupBox1.Visible = False
        GroupBox1.Enabled = False
    End Sub
End Class
