Public Class Customer
    Dim name As String
    Public Sub New()
    End Sub
    Public Sub New(ByVal name As String)
        Me.name = name
    End Sub

    Public Property CusName() As String
        Get
            Return Me.name
        End Get
        Set(value As String)
            Me.name = value
        End Set
    End Property
    Public Function foo()
        MessageBox.Show(Me.name)
    End Function



End Class

