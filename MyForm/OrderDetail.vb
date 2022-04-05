Public Class OrderDetail
    Dim ID As Integer = 0
    Dim customer As Customer
    Dim product As Product
    Dim quantity As Integer
    Dim ordID As Integer
    Dim total As Integer
    Public Sub New()
        Me.customer = New Customer()
        Me.product = New Product()
    End Sub
    Public Property OrdDetailID() As Integer
        Get
            Return Me.ID
        End Get
        Set(value As Integer)
            Me.ID = value
        End Set
    End Property
    Public Property OrdDetailCustomer() As Customer
        Set(value As Customer)
            Me.customer = value
        End Set
        Get
            Return Me.customer
        End Get
    End Property
    Public Property OrdDetailProduct() As Product
        Set(value As Product)
            Me.product = value
        End Set
        Get
            Return Me.product
        End Get
    End Property
    Public Property OrdDetailTotal() As Integer
        Set(value As Integer)
            Me.total = value
        End Set
        Get
            Return Me.total
        End Get
    End Property
    Public Property OrderDetailQuantity() As Integer
        Set(value As Integer)
            Me.quantity = value
        End Set
        Get
            Return Me.quantity
        End Get
    End Property
    Public Property OrdDetailOrdID() As Integer
        Get
            Return Me.ordID
        End Get
        Set(value As Integer)
            Me.ordID = value
        End Set
    End Property
End Class
