Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Runtime.CompilerServices

Public Class DBAccess
    Private ReadOnly cmd As IDbCommand

    Private strConnectionString As String

    Private handleErrors As Boolean

    Private strLastError As String

    Public Property CommandText As String
        Get
            Return Me.cmd.CommandText
        End Get
        Set(ByVal value As String)
            Me.cmd.CommandText = value
            Me.cmd.Parameters.Clear()
        End Set
    End Property

    Public Property ConnectionString As String
        Get
            Return Me.strConnectionString
        End Get
        Set(ByVal value As String)
            Me.strConnectionString = value
        End Set
    End Property

    Public Property HandleExceptions As Boolean
        Get
            Return Me.handleErrors
        End Get
        Set(ByVal value As Boolean)
            Me.handleErrors = value
        End Set
    End Property

    Public ReadOnly Property LastError As String
        Get
            Return Me.strLastError
        End Get
    End Property

    Public ReadOnly Property Parameters As IDataParameterCollection
        Get
            Return Me.cmd.Parameters
        End Get
    End Property

    Public Sub New(Optional ByVal db As String = "rtds")
        MyBase.New()
        Me.cmd = New SqlCommand()
        Me.strConnectionString = ""
        Me.handleErrors = False
        Me.strLastError = ""
        'Dim connectionStringSetting As ConnectionStringSettings = New ConnectionStringSettings()
        'If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(db, "rtds", False) = 0) Then
        '    connectionStringSetting = ConfigurationManager.ConnectionStrings("DockMonitor_DockActivity.RTDSConnectionString")
        'End If
        'Me.strConnectionString = connectionStringSetting.ConnectionString
        Dim sqlConnection As System.Data.SqlClient.SqlConnection = New System.Data.SqlClient.SqlConnection()
        Select Case db
            Case "hr"
                sqlConnection.ConnectionString = "Data Source=reports.div-log.com;Initial Catalog=RTDS;Persist Security Info=True;User ID=rtds;Password=southeast1"
            Case "rtds"
                sqlConnection.ConnectionString = "Data Source=reports.div-log.com;Initial Catalog=RTDS;Persist Security Info=True;User ID=rtds;Password=southeast1"
        End Select
        Me.cmd.Connection = sqlConnection
        Me.cmd.CommandType = CommandType.Text
    End Sub

    Public Sub AddParameter(ByVal paramname As String, ByVal paramvalue As Object)
        Dim sqlParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter(paramname, RuntimeHelpers.GetObjectValue(paramvalue))
        Me.cmd.Parameters.Add(sqlParameter)
    End Sub

    Public Sub AddParameter(ByVal param As IDataParameter)
        Me.cmd.Parameters.Add(param)
    End Sub

    Private Sub Open()
        Me.cmd.Connection.Open()
    End Sub

    Private Sub Close()
        Me.cmd.Connection.Close()
    End Sub

    Public Sub Dispose()
        Me.cmd.Dispose()
    End Sub

    Public Function ExecuteDataSet() As System.Data.DataSet
        Dim sqlDataAdapter As System.Data.SqlClient.SqlDataAdapter = Nothing
        Dim dataSet As System.Data.DataSet = Nothing
        Try
            sqlDataAdapter = New System.Data.SqlClient.SqlDataAdapter() With
            {
                .SelectCommand = DirectCast(Me.cmd, SqlCommand)
            }
            sqlDataAdapter.SelectCommand.CommandTimeout = 120
            dataSet = New System.Data.DataSet()
            sqlDataAdapter.Fill(dataSet)
        Catch exception1 As System.Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As System.Exception = exception1
            If (Not Me.handleErrors) Then
                Throw
            Else
                Me.strLastError = exception.Message
                ProjectData.ClearProjectError()
            End If
        Finally
            Close()
        End Try

        Return dataSet
    End Function

    Public Function ExecuteDataSet(ByVal commandtext As String) As System.Data.DataSet
        Dim dataSet As System.Data.DataSet = Nothing
        Try
            Me.cmd.CommandText = commandtext
            dataSet = Me.ExecuteDataSet()
        Catch exception1 As System.Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As System.Exception = exception1
            If (Not Me.handleErrors) Then
                Throw
            Else
                Me.strLastError = exception.Message
                ProjectData.ClearProjectError()
            End If
        Finally
            Close()
        End Try
        Return dataSet
    End Function

    Public Function ExecuteNonQuery() As Integer
        Dim num As Integer = -1
        Me.Open()
        Try
            Try
                num = Me.cmd.ExecuteNonQuery()
            Catch exception1 As System.Exception
                ProjectData.SetProjectError(exception1)
                Dim exception As System.Exception = exception1
                If (Not Me.handleErrors) Then
                    Throw
                Else
                    Me.strLastError = exception.Message
                    ProjectData.ClearProjectError()
                End If
            End Try
        Finally
            Me.Close()
        End Try
        Return num
    End Function

    Public Function ExecuteNonQuery(ByVal commandtext As String) As Integer
        Dim num As Integer = -1
        Try
            Me.cmd.CommandText = commandtext
            num = Me.ExecuteNonQuery()
        Catch exception1 As System.Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As System.Exception = exception1
            If (Not Me.handleErrors) Then
                Throw
            Else
                Me.strLastError = exception.Message
                ProjectData.ClearProjectError()
            End If
        Finally
            Close()
        End Try
        Return num
    End Function

    Public Function ExecuteReader() As IDataReader
        Dim dataReader As IDataReader = Nothing
        Try
            Me.Open()
            dataReader = Me.cmd.ExecuteReader(CommandBehavior.CloseConnection)
        Catch exception1 As System.Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As System.Exception = exception1
            If (Not Me.handleErrors) Then
                Throw
            Else
                Me.strLastError = exception.Message
                ProjectData.ClearProjectError()
            End If
        End Try
        Return dataReader
    End Function

    Public Function ExecuteReader(ByVal commandtext As String) As IDataReader
        Dim dataReader As IDataReader = Nothing
        Try
            Me.cmd.CommandText = commandtext
            dataReader = Me.ExecuteReader()
        Catch exception1 As System.Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As System.Exception = exception1
            If (Not Me.handleErrors) Then
                Throw
            Else
                Me.strLastError = exception.Message
                ProjectData.ClearProjectError()
            End If
        End Try
        Return dataReader
    End Function

    Public Function ExecuteScalar() As Object
        Dim objectValue As Object = Nothing
        Try
            Me.Open()
            objectValue = RuntimeHelpers.GetObjectValue(Me.cmd.ExecuteScalar())
            Me.Close()
        Catch exception1 As System.Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As System.Exception = exception1
            If (Not Me.handleErrors) Then
                Throw
            Else
                Me.strLastError = exception.Message
                ProjectData.ClearProjectError()
            End If
        Finally
            Close()
        End Try
        Return objectValue
    End Function

    Public Function ExecuteScalar(ByVal commandtext As String) As Object
        Dim objectValue As Object = Nothing
        Try
            Me.cmd.CommandText = commandtext
            objectValue = RuntimeHelpers.GetObjectValue(Me.ExecuteScalar())
        Catch exception1 As System.Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As System.Exception = exception1
            If (Not Me.handleErrors) Then
                Throw
            Else
                Me.strLastError = exception.Message
                ProjectData.ClearProjectError()
            End If
        Finally
            Close()
        End Try
        Return objectValue
    End Function

End Class

