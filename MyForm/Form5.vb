Imports System.IO
Public Class Form5
    Private products As New ArrayList
    Private orderdetails As New ArrayList
    'Public Function WriteDataToGridView()
    '    For Each product As Product In products
    '        Dim amount As Integer = 0
    '        Dim total As Integer = 0
    '        For Each orderdetail As OrderDetail In orderdetails
    '            If product.pID = orderdetail.OrdDetailProduct.pID Then
    '                amount += orderdetail.OrderDetailQuantity
    '                total += orderdetail.OrdDetailTotal
    '            End If
    '        Next
    '        DataGridView1.Rows.Add(product.pName, amount, total)
    '    Next
    'End Function
    Public Function WriteDataToListView()
        For Each product As Product In products
            Dim amount As Integer = 0
            Dim total As Integer = 0
            For Each orderdetail As OrderDetail In orderdetails
                If product.pID = orderdetail.OrdDetailProduct.pID Then
                    amount += orderdetail.OrderDetailQuantity
                    total += orderdetail.OrdDetailTotal
                End If
            Next
            Dim item As New ListViewItem
            item.Text = product.pID
            item.SubItems.Add(product.pName)
            item.SubItems.Add(product.pPrice)
            item.SubItems.Add(amount)
            item.SubItems.Add(total)
            ListView1.Items.Add(item)
        Next
    End Function
    Public Function LoadDataFromOrderDetail()
        Dim sr As StreamReader = New StreamReader("D:\MyFormUpdate2\MyForm\MyForm\OrderDetail.txt")
        orderdetails.Clear()
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
    Public Function LoadProductList()
        products.Clear()
        Dim sr As StreamReader = New StreamReader("D:\MyFormUpdate2\MyForm\MyForm\ProductList.txt")
        Try
            Do Until sr.EndOfStream
                Dim line() As String = sr.ReadLine.ToString.Split(vbTab)
                Dim product As New Product
                product.pID = line(0)
                product.pName = line(1)
                product.pPrice = line(2)
                products.Add(product)
            Loop
        Catch ex As Exception
            MessageBox.Show("Fail")
            Return False
        Finally
            sr.Close()
        End Try
        Return True
    End Function
    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadProductList()
        LoadDataFromOrderDetail()
        WriteDataToListView()
    End Sub
End Class