Imports System


Public Class Employee

    Private fullNameField As String

    Public Property FullName As String
        Get
            Return fullNameField
        End Get
        Set(ByVal value As String)
            Me.fullNameField = value
        End Set
    End Property

End Class
