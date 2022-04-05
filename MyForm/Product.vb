Public Class Product
    Dim id As Integer
    Dim name As String
    Dim price As Integer
    Public Property pName() As String
        Set(value As String)
            Me.name = value
        End Set
        Get
            Return Me.name
        End Get
    End Property
    Public Property pPrice() As Integer
        Set(value As Integer)
            Me.price = value
        End Set
        Get
            Return Me.price
        End Get
    End Property
    Public Property pID() As Integer
        Set(value As Integer)
            Me.id = value
        End Set
        Get
            Return Me.id
        End Get
    End Property
End Class

