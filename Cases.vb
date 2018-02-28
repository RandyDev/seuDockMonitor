Public Class Cases
    Private _cases As List(Of PalletsPieces)
    Public Sub New()
        _cases = New List(Of PalletsPieces)() ' this does the work
        Dim this As New PalletsPieces
        'get the values
        this.LocaID = ""
        this.Location = ""
        this.LogDate = Date.Now.ToShortDateString
        this.PiecesScheduled = 2199
        this.PiecesReceived = 1144
        _cases.Add(this)
    End Sub
    Public Function GetCases() As List(Of PalletsPieces)
        Return _cases
    End Function

    'move methods here
End Class