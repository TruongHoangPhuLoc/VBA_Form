Public Class Order
    Dim id As Integer
    Dim customer As Customer
    Dim dayOfOrder As Date
    Dim total As Integer
    Public Sub New()
        customer = New Customer
    End Sub
    Public Property oID() As Integer
        Set(value As Integer)
            Me.id = value
        End Set
        Get
            Return Me.id
        End Get
    End Property
    Public Property oCustomer() As Customer
        Get
            Return Me.customer
        End Get
        Set(value As Customer)
            Me.customer = value
        End Set
    End Property
    Public Property oTotal() As Integer
        Get
            Return Me.total
        End Get
        Set(value As Integer)
            Me.total = value
        End Set
    End Property

    Public Property oDayOfOrder() As Date
        Get
            Return Me.dayOfOrder
        End Get
        Set(value As Date)
            Me.dayOfOrder = value
        End Set
    End Property
    Public Function Output()
        MessageBox.Show(Me.oID)
        MessageBox.Show(Me.oCustomer.CusName)
        MessageBox.Show(Me.oTotal)
        MessageBox.Show(Me.oDayOfOrder)
    End Function
End Class

