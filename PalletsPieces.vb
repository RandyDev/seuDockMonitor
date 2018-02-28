Public Class PalletsPieces
    Private _locaID As String
    Private _location As String
    Private _logDate As DateTime
    Private _piecesReceived As Integer
    Private _piecesScheduled As Integer
    'Public Sub New()
    '    _logDate = Date.Now.ToShortDateString

    '    'to do ... return complete palletspieces
    'End Sub
    Public Property LocaID() As String
        Get
            Return _locaID
        End Get
        Set(value As String)
            _locaID = value
        End Set
    End Property
    Public Property Location() As String
        Get
            Return _location
        End Get
        Set(value As String)
            _location = value
        End Set
    End Property
    Public Property LogDate() As DateTime
        Get
            Return _logDate
        End Get
        Set(value As DateTime)
            _logDate = value
        End Set
    End Property
    Public Property PiecesReceived() As Integer
        Get
            Return _piecesReceived
        End Get
        Set(value As Integer)
            _piecesReceived = value
        End Set
    End Property
    Public Property PiecesScheduled() As Integer
        Get
            Return _piecesScheduled
        End Get
        Set(value As Integer)
            _piecesScheduled = value
        End Set
    End Property
End Class
