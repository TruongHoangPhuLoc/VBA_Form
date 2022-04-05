Imports System.IO
Public Class Form3
    Private orderdetails As New ArrayList
    Public products As New ArrayList
    Private totals(5) As Integer
    Private OrdID As Integer = Form1.getID + 1
    Public Function getAtMostID() As Integer
        Dim sr As StreamReader = New StreamReader("D:\MyFormUpdate2\MyForm\MyForm\OrderDetail.txt")
        Dim ID As Integer
        Try
            Do Until sr.EndOfStream
                sr.ReadLine()
                ID += 1
            Loop
        Catch ex As Exception
            MessageBox.Show("Fail")
            Return -1
        Finally
            sr.Close()
        End Try
        Return ID
    End Function
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadProductList()
        initializeCombobox()
        setDay()

    End Sub
    Public Function initializeCombobox()
        For Each type In Me.Controls
            If TypeName(type) = "ComboBox" Then
                For Each product In products
                    type.enabled = False
                    type.Items.Add(product.pName)
                Next
            End If
        Next
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

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        For Each product In products
            If ComboBox1.SelectedItem.ToString = product.pName.ToString Then
                TextBox4.Text = product.pPrice
            End If
        Next
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If validCheckBox(1) Then
            ComboBox1.Enabled = True
        Else
            CheckBox1.Checked = False
        End If
        If CheckBox1.Checked = False Then
            ComboBox1.Enabled = False
        End If
    End Sub
    Public Function validCheckBox(index As Integer) As Boolean
        For count = 1 To index - 1
            For Each ctrl In Me.Controls
                If TypeName(ctrl) = "CheckBox" Then
                    Dim str As String() = New String() {"CheckBox"}
                    Dim name() = ctrl.Name.ToString.Split(str, StringSplitOptions.None)
                    If name(1) = count.ToString Then
                        If ctrl.Checked = False Then
                            Return False
                        End If
                    End If
                End If
            Next
        Next
        Return True
    End Function
    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If validCheckBox(2) = False Then
            CheckBox2.Checked = False
        Else
            ComboBox2.Enabled = True
        End If

        If CheckBox2.Checked = False Then
            ComboBox2.Enabled = False
        End If
    End Sub
    Public Function validCreateOrder() As Boolean
        If TextBox1.Text = "" Then
            Return False
        End If
        For Each cb In Me.Controls
            If TypeName(cb) = "ComboBox" Then
                If cb.Enabled = True Then
                    Dim str As String() = New String() {"ComboBox"}
                    Dim temp() = cb.Name.ToString.Split(str, StringSplitOptions.None)
                    For Each numeric In Me.Controls
                        If TypeName(numeric) = "NumericUpDown" Then
                            Dim str2 As String() = New String() {"NumericUpDown"}
                            Dim temp2() = numeric.Name.ToString.Split(str2, StringSplitOptions.None)
                            If temp(1) = temp2(1) Then
                                If cb.text <> "" Or numeric.value <> 0 Then
                                    If cb.text = "" Then
                                        Return False
                                    End If
                                    If numeric.value = 0 Then
                                        Return False
                                    End If
                                End If
                                If cb.text = "" And numeric.value = 0 Then
                                    Return False
                                End If
                            End If
                        End If
                    Next
                End If
            End If
        Next
        Return True
    End Function
    Public Function CalTotal(ByVal n As Integer) As Integer
        Dim sum As Integer = 0
        For i = 0 To n - 1
            sum += totals(i)
        Next
        Return sum
    End Function
    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
        If validCheckBox(3) Then
            ComboBox3.Enabled = True
        Else
            CheckBox3.Checked = False
        End If
        If CheckBox3.Checked = False Then
            ComboBox3.Enabled = False
        End If
    End Sub
    Public Function setDay()
        TextBox2.Text = Date.Today().ToString("dd/MM/yyyy")
    End Function
    Private Sub CheckBox4_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox4.CheckedChanged
        If validCheckBox(4) Then
            ComboBox4.Enabled = True
        Else
            CheckBox4.Checked = False
        End If
        If CheckBox4.Checked = False Then
            ComboBox4.Enabled = False
        End If
    End Sub
    Public Property getProductList() As ArrayList
        Get
            Return Me.products
        End Get
        Set(value As ArrayList)

        End Set
    End Property
    Private Sub CheckBox5_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox5.CheckedChanged
        If validCheckBox(5) Then
            ComboBox5.Enabled = True
        Else
            CheckBox5.Checked = False
        End If
        If CheckBox5.Checked = False Then
            ComboBox5.Enabled = False
        End If
    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged
        Dim sum = CalTotal(0)
        Dim value As Integer = sum + Integer.Parse(TextBox4.Text) * NumericUpDown1.Value
        TextBox3.Text = value
        totals(0) = Integer.Parse(TextBox4.Text) * NumericUpDown1.Value
    End Sub



    Private Sub NumericUpDown2_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown2.ValueChanged
        Dim sum = CalTotal(1)
        Dim value As Integer = sum + Integer.Parse(TextBox5.Text) * NumericUpDown2.Value
        TextBox3.Text = value
        totals(1) = Integer.Parse(TextBox5.Text) * NumericUpDown2.Value
    End Sub

    Private Sub NumericUpDown3_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown3.ValueChanged
        Dim sum = CalTotal(2)
        Dim value As Integer = sum + Integer.Parse(TextBox6.Text) * NumericUpDown3.Value
        TextBox3.Text = value
        totals(2) = Integer.Parse(TextBox6.Text) * NumericUpDown3.Value
    End Sub

    Private Sub NumericUpDown4_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown4.ValueChanged
        Dim sum = CalTotal(3)
        Dim value As Integer = sum + Integer.Parse(TextBox6.Text) * NumericUpDown3.Value
        TextBox3.Text = value
        totals(3) = Integer.Parse(TextBox6.Text) * NumericUpDown3.Value
    End Sub

    Private Sub NumericUpDown5_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown5.ValueChanged
        Dim sum = CalTotal(4)
        Dim value As Integer = sum + Integer.Parse(TextBox7.Text) * NumericUpDown4.Value
        TextBox3.Text = value
        totals(4) = Integer.Parse(TextBox7.Text) * NumericUpDown4.Value
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        For Each product In products
            If ComboBox2.SelectedItem.ToString = product.pName.ToString Then
                TextBox5.Text = product.pPrice
            End If
        Next
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        For Each product In products
            If ComboBox3.SelectedItem.ToString = product.pName.ToString Then
                TextBox6.Text = product.pPrice
            End If
        Next
    End Sub
    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged
        For Each product In products
            If ComboBox4.SelectedItem.ToString = product.pName.ToString Then
                TextBox7.Text = product.pPrice
            End If
        Next
    End Sub

    Private Sub ComboBox5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox5.SelectedIndexChanged
        For Each product In products
            If ComboBox5.SelectedItem.ToString = product.pName.ToString Then
                TextBox8.Text = product.pPrice
            End If
        Next
    End Sub
    Public Function WriteOrderToFile()
        Dim sw As StreamWriter = New StreamWriter("D:\MyFormUpdate2\MyForm\MyForm\Customer.txt", True)
        Try
            sw.WriteLine(Me.OrdID & vbTab & TextBox1.Text & vbTab & TextBox2.Text & vbTab & TextBox3.Text)
        Catch ex As Exception
            Return False
        Finally
            sw.Close()
        End Try
        Return True
    End Function

    Public Function validSubmit() As Boolean
        If validCreateOrder() = False Then
            Return False
        End If
        If TextBox3.Text = "" Then
            Return False
        End If
        Return True
    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If validSubmit() Then
            WriteOrderToFile()
            MessageBox.Show("Tao Don Hang Thanh Cong")
            Form1.LoadData()
            Form1.clearListView()
            Form1.WriteDataToListView()
            addItemToOrderDetails()
            WriteDataToOrderDetail()
            Me.Close()
        Else
            MessageBox.Show("Don Hang Khong Hop Le")
        End If
    End Sub
    Public Function WriteDataToOrderDetail()
        Dim sw As StreamWriter = New StreamWriter("D:\MyFormUpdate2\MyForm\MyForm\OrderDetail.txt", True)
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
    Public Function addItemToOrderDetails()
        orderdetails.Clear()
        Dim ID As Integer = getAtMostID() + 1
        For Each cb In Me.Controls
            If TypeName(cb) = "ComboBox" Then
                If cb.Enabled = True Then
                    Dim str As String() = New String() {"ComboBox"}
                    Dim temp() = cb.Name.ToString.Split(str, StringSplitOptions.None)
                    For Each numeric In Me.Controls
                        If TypeName(numeric) = "NumericUpDown" Then
                            Dim str2 As String() = New String() {"NumericUpDown"}
                            Dim temp2() = numeric.Name.ToString.Split(str2, StringSplitOptions.None)
                            If temp(1) = temp2(1) Then
                                If numeric.value <> 0 Then
                                    Dim orderdetail As New OrderDetail
                                    orderdetail.OrdDetailID = ID
                                    orderdetail.OrdDetailOrdID = Me.OrdID
                                    orderdetail.OrdDetailCustomer.CusName = TextBox1.Text
                                    orderdetail.OrdDetailProduct.pName = cb.SelectedItem
                                    orderdetail.OrdDetailProduct.pPrice = getPrice(orderdetail.OrdDetailProduct.pName)
                                    orderdetail.OrdDetailProduct.pID = getID(orderdetail.OrdDetailProduct.pName)
                                    orderdetail.OrderDetailQuantity = numeric.value
                                    orderdetail.OrdDetailTotal = orderdetail.OrderDetailQuantity * orderdetail.OrdDetailProduct.pPrice
                                    orderdetail.OrdDetailOrdID = Me.OrdID
                                    orderdetails.Add(orderdetail)
                                    ID += 1
                                End If
                            End If
                        End If
                    Next
                End If
            End If
        Next
    End Function
    Public Function getPrice(ByVal str As String) As Integer
        Dim price As Integer = 0
        For Each product As Product In products
            If product.pName = str Then
                price = product.pPrice
                Return price
            End If
        Next
        Return price
    End Function
    Public Function getID(ByVal str As String) As Integer
        Dim ID As Integer = 0
        For Each product As Product In products
            If product.pName = str Then
                ID = product.pID
                Return ID
            End If
        Next
        Return ID
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
    End Sub
End Class