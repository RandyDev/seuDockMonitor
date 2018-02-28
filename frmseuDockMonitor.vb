Imports Microsoft.Reporting.WinForms
Imports System
Imports System.Data
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Threading
Imports System.Windows.Forms
Imports System.Xml
Imports Telerik.WinControls.UI

Public Class FrmseuDockMonitor
    Dim utls As New Utilities

#Region "Private Variables '@@@@@@@@@@@@@@@@@@@@@@@@@@@@"
    Private appdirectoryName As String
    Private dscases As New Cases
    Protected Friend locationName As String
    Protected Friend slocaid As String
    Private conStr As String
    Private reportType As String
    Private locaID As Guid
    Private bdOffSet As Integer
    Protected Friend parentCompany As String
    Private parentID As Guid
    Private locatimezoneOffset As Integer
    Protected Friend alldt As DataTable = New DataTable
    Protected Friend actdt As DataTable = New DataTable
    Private bannerArray As List(Of String)
    Private birthdays As List(Of Birthday)
    Private birthdaycounter As Integer
    Private bannerPos As Integer
    Private thisScreenArea As Rectangle
    Private ht As Integer 'screen height
    Private wd As Integer 'screen width
    Private rowheight As Integer
    Private thisScreenRowCount As Integer
    Private thisScreenGridHeight As Integer
    Private thisScreenGridRowCount As Integer
    Private piecesScheduled As Integer
    Private piecesUnloaded As Integer
    Private palletsPieces As New PalletsPieces
    Private cycle As Integer = 1
    Private exitsecs As String
    '    Private exitme As Integer
    Private isConnected As Boolean = False
    Private Const CONNECT_LAN As Long = &H2
    Private Const CONNECT_MODEM As Long = &H1
    Private Const CONNECT_PROXY As Long = &H4
    Private Const CONNECT_OFFLINE As Long = &H20
    Private Const CONNECT_CONFIGURED As Long = &H40
    Private alltabledone As Boolean = True
    Private activetabledone As Boolean = True
    Private gaugeDataDone As Boolean = True
    Private utl As New Utilities
#End Region '"Private Variables" '@@@@@@@@@@@@@@@@@@@@@@@@@@@@


#Region "Start up '@@@@@@@@@@@@@@@@@@@@@@@@"
    Private Sub SeuDockMonitorLoad(sender As Object, e As EventArgs) Handles Me.Load
        GetBirthdays(slocaid)
        Dim iscon As Boolean = IsWebConnected()
        Control.CheckForIllegalCrossThreadCalls = False
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox2.SizeMode = PictureBoxSizeMode.Zoom
        '.Visible = False
        thisScreenArea = Screen.FromControl(Me).Bounds
        ht = thisScreenArea.Height
        wd = thisScreenArea.Width

        Me.thisScreenGridHeight = ht - (lblDateTime.Location.Y + lblDateTime.Height + PictureBox2.Height + lblCopyright.Height + 10)
        rowheight = RadGridView1.TableElement.RowHeight
        Me.thisScreenGridRowCount = Me.thisScreenGridHeight / rowheight
        slocaid = GetXMLdata("Location_Id")
        locaID = New Guid(slocaid)
        locationName = (GetXMLdata("Location_Name"))
        lblLocation.Text = locationName
        GetLogo(GetParentCompany(slocaid))
        Dim utls As New Utilities
        TimerDateTime.Start()
        lblDateTime.Text = utls.GetDateTime()
        '        Me.ControlBox = False
        '       Me.Text = ""
        lblPageTitle.Text = "Active Loads"
        Dim ptlblpt As Point = New Point((wd / 2) - (lblPageTitle.Width / 2), 10) ' PictureBox1.Location.Y + (PictureBox1.Height / 2) - (lblPageTitle.Height / 2))
        lblPageTitle.Location = ptlblpt
        Dim pt As New Point((wd / 2) - (lblLocation.Width / 2), lblPageTitle.Location.Y + lblPageTitle.Height)
        lblLocation.Location = pt
        lblNetwork.Text = "alt"
        BackgroundAllLoads.RunWorkerAsync()
        Try
            Dim a As Integer = 0
            While a < 4 'try 3 times to aquire datatable
                actdt = GetWorkOrders(locationName, False) 'Active Loads
                If actdt Is Nothing Then
                    a += 1
                    Thread.Sleep(5000)
                Else
                    a = 4
                End If
            End While
        Catch exception As System.Exception
            lblLocation.Text = exception.Message
        End Try
        Try
            If Not actdt Is Nothing Then
                RadGridView1.DataSource = actdt
                SetRefreshTimer(actdt.Rows.Count)
                ChangeBanner()
                Me.ReportViewer1.Visible = False
                '                Me.RadRadialGauge1.Visible = False
                ReportPanel.Visible = False

                '                Me.RadRadialGauge1.Visible = False
            Else
                RadGridView1.TableElement.Text = " ... One Moment ..."
                cycle = 2
                ChangeScreen()
                Exit Sub
            End If
        Catch ex As Exception
            Dim msg As String = ex.Message
        End Try
    End Sub
#End Region '"Start up" '@@@@@@@@@@@@@@@@@@@@@@@@

#Region "Timers '@@@@@@@@@@@@@@@@@@@@@@@@"

    Private Sub TimerGridScroll_Tick(sender As Object, e As EventArgs) Handles TimerGridScroll.Tick
        '        Dim rowcount As Integer = Me.RadGridView1.RowCount
        '        If rowcount + 1 > Me.thisScreenGridRowCount Then
        MoveGrid()
        '        End If
    End Sub

    Private Sub TimerRefresh_Tick(sender As Object, e As EventArgs) Handles TimerRefresh.Tick
        If TimerRefresh.Enabled Then
            Dim artime As String() = Split(lblNextUpdate.Text, ":")
            If CType(artime(0), Integer) + CType(artime(1), Integer) = 0 Then
                '               If exitme = 2 Then Application.Exit()
                cycle = 2
                ChangeScreen()
                Exit Sub
            End If
            'the countdown
            Dim strArrays As String() = Split(Me.lblNextUpdate.Text, ":")
            Dim ttlsecs As Integer = CInt(strArrays(0)) * 60 + CInt(strArrays(1))
            ttlsecs -= 1
            Dim secs As Integer = ttlsecs Mod 60
            Dim mins As Integer = ((ttlsecs - secs) / 60) Mod 60
            Dim str As String = IIf(mins.ToString().Length = 1, "0" & mins.ToString(), mins.ToString()) & ":"
            str &= IIf(secs.ToString().Length = 1, "0" & secs.ToString(), secs.ToString())
            Me.lblNextUpdate.Text = str
            exitsecs = secs.ToString
            '           If exitme = 2 Then
            '           RadGridView1.TableElement.Text = "No Loads Found" & vbCrLf & "Exit in " & exitsecs & " seconds"
            '       End If
        End If
    End Sub

    Private Sub SetRefreshTimer(Optional ByVal rows As Integer = 0, Optional ByVal secs As Integer = 0)
        If Not Me.WindowState = FormWindowState.Maximized Then
            Me.WindowState = FormWindowState.Maximized
        End If
        Setscreen()
        Dim ptlblpt As Point = New Point((wd / 2) - (lblPageTitle.Width / 2), 10) ' PictureBox1.Location.Y + (PictureBox1.Height / 2) - (lblPageTitle.Height / 2))
        lblPageTitle.Location = ptlblpt
        If lblPageTitle.Text = "report" Or rows <= thisScreenGridRowCount Then
            lblNextUpdate.Visible = True
            cycle = 2
            Dim strnextupdate As String = "00:30"
            If secs > 0 Then
                If secs.ToString.Length = 2 Then
                    strnextupdate = secs.ToString
                Else
                    strnextupdate = "00:0" & secs.ToString
                End If
            End If
            TimerGridScroll.Enabled = False
            TimerRefresh.Enabled = True
            TimerRefresh.Start()
            lblGridPosition.Visible = False
            lblNextUpdate.Visible = True
            lblNextUpdate.Text = strnextupdate
        Else
            lblNextUpdate.Visible = False
            lblGridPosition.Visible = True
            TimerRefresh.Enabled = False
            TimerGridScroll.Enabled = True
            lblNextUpdate.Text = String.Empty
            cycle = 1
            Dim rowCount As Integer = RadGridView1.RowCount
            Dim gplbl As String = "Rows: " & rowCount.ToString & vbCrLf & "Cycle: " & cycle.ToString & "  of 2 - " & "0%"
            lblNextUpdate.Text = gplbl
            TimerGridScroll.Start()
            '            me.lblgridposition.text = gplbl
        End If
    End Sub

    Private Sub TimerDateTime_Tick(sender As Object, e As EventArgs) Handles TimerDateTime.Tick
        lblDateTime.Text = utl.GetDateTime()
    End Sub
#End Region '"Timers" '@@@@@@@@@@@@@@@@@@@@@@@@

#Region "Net Connected '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@"


    Public Function IsWebConnected(Optional ByRef connType As String = " ") As Boolean
        Dim dwflags As Long
        Dim webTest As Boolean
        connType = ""
        webTest = InternetGetConnectedState(dwflags, 0&)
        Select Case webTest
            Case dwflags And CONNECT_LAN : connType = "LAN"
            Case dwflags And CONNECT_MODEM : connType = "Modem"
            Case dwflags And CONNECT_PROXY : connType = "Proxy"
            Case dwflags And CONNECT_OFFLINE : connType = "Offline"
            Case dwflags And CONNECT_CONFIGURED : connType = "Configured"
        End Select
        IsWebConnected = webTest
    End Function

    Private Declare Function InternetGetConnectedState Lib "wininet.dll" (ByRef lpdwFlags As Int32, ByVal dwReserved As Int32) As Long
#End Region '"Net Connected" '@@@@@@@@@@@@@@@@@@@@@@@@

#Region "BackgroundWorkers '@@@@@@@@@@@@@@@@@@@@"
    Private Sub BackgroundActiveLoads_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundActiveLoads.DoWork
        Dim dt As DataTable
        Try
            Dim a As Integer = 0
            While a < 4 'try 3 times to aquire datatable
                dt = GetWorkOrders(locationName, False) 'Active Loads hides completed Loads
                If dt Is Nothing Then
                    a += 1
                Else
                    '                    exitme = 0
                    actdt = dt 'only overwrite actdt if new data aquired
                    a = 4
                End If
            End While
        Catch exception As System.Exception
            lblLocation.Text = exception.Message
        End Try
    End Sub

    Private Sub BackgroundActiveLoads_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundActiveLoads.RunWorkerCompleted
        activetabledone = True
        Dim gotactivetable As Boolean = Not actdt Is Nothing
        If gotactivetable Then
            lblLocation.Text = locationName
            '            exitme = 0
            lblNetwork.Text = "aco"
        Else
            lblLocation.Text = locationName
            lblNetwork.Text = "acf"
        End If
    End Sub

    Private Sub BackgroundAllLoads_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundAllLoads.DoWork
        Dim dt As DataTable
        Try
            Dim a As Integer = 0
            While a < 4 'try 3 times to aquire datatable
                dt = GetWorkOrders(locationName, True) 'Active Loads defaults to True
                If alldt Is Nothing Then
                    a += 1
                Else
                    alldt = dt 'only overwrite alldt if new data aquired
                    '                    exitme = 0
                    a = 4
                End If
            End While
        Catch ex As System.Exception
            lblLocation.Text = ex.Message
        End Try
    End Sub

    Private Sub BackgroundAllLoads_RunWorkerCompleted1(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundAllLoads.RunWorkerCompleted
        alltabledone = True
        Dim gotalltable As Boolean = Not alldt Is Nothing
        If gotalltable Then
            lblLocation.Text = locationName
            '            exitme = 0
            lblNetwork.Text = "alo"
        Else
            lblLocation.Text = locationName
            lblNetwork.Text = "alf"
        End If
        GetBanners(slocaid)
    End Sub

    Private Sub BackgroundGaugeData_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundGaugeData.DoWork
        'get scheduled
        palletsPieces = New PalletsPieces
        Dim dba As New DBAccess
        Dim schedTry As Integer = 0
        dba.CommandText = "SELECT SUM(WorkOrder.Pieces) AS PiecesScheduled " &
            "FROM Location AS Location INNER JOIN " &
            "WorkOrder AS WorkOrder ON Location.ID = WorkOrder.LocationID " &
            "WHERE (Location.Name = @location) " &
            "GROUP BY CONVERT(VARCHAR(10), WorkOrder.LogDate, 101), Location.Name " &
            "HAVING (CONVERT(VARCHAR(10), WorkOrder.LogDate, 101) = CONVERT(VARCHAR(10), GETDATE(), 101))"
        dba.AddParameter("@location", locationName)
        palletsPieces.Location = locationName
        palletsPieces.LocaID = slocaid
        Try
            While schedTry < 4
                Dim varpiecesScheduled As Integer
                varpiecesScheduled = dba.ExecuteScalar
                If varpiecesScheduled < 1 Then
                    schedTry += 1
                Else
                    palletsPieces.PiecesScheduled = varpiecesScheduled
                    '                    exitme = 0
                    schedTry = 4
                End If
            End While
        Catch ex As Exception
            lblLocation.Text = ex.Message
        End Try

        'get received\
        Dim unlTry As Integer = 0
        dba.CommandText = "SELECT SUM(WorkOrder.Pieces) AS PiecesRecieved " &
            "FROM Location AS Location INNER JOIN " &
            "WorkOrder AS WorkOrder ON Location.ID = WorkOrder.LocationID " &
            "WHERE (Location.Name = @location) AND (CONVERT(VARCHAR(10), WorkOrder.LogDate, 101) = CONVERT(VARCHAR(10), GETDATE(), 101)) AND  " &
            "(CONVERT(VARCHAR(10), WorkOrder.CompTime, 101) = CONVERT(VARCHAR(10), WorkOrder.LogDate, 101)) " &
            "GROUP BY CONVERT(VARCHAR(10), WorkOrder.LogDate, 110)"
        dba.AddParameter("@location", locationName)
        Try
            While unlTry < 4
                Dim varPiecesUnloaded As Integer
                varPiecesUnloaded = dba.ExecuteScalar
                If varPiecesUnloaded < 1 Then
                    unlTry += 1
                Else
                    palletsPieces.PiecesReceived = varPiecesUnloaded
                    '                    exitme = 0
                    unlTry = 4
                End If
            End While
        Catch ex As Exception
            lblLocation.Text = ex.Message
        End Try
        ''appy to report
    End Sub

    Private Sub BackgroundGaugeData_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundGaugeData.RunWorkerCompleted
        gaugeDataDone = True
        Dim sched, unld As Integer
        Dim pcnt As Decimal
        Dim gotGuageData As Boolean = palletsPieces.PiecesScheduled > 0
        If gotGuageData Then
            lblLocation.Text = locationName
            '            exitme = 0
            sched = palletsPieces.PiecesScheduled
            unld = palletsPieces.PiecesReceived
            pcnt = Math.Round(unld / sched * 100, 0)
            lblNetwork.Text = "ro"
        Else
            lblLocation.Text = locationName
            lblNetwork.Text = "rf"
        End If
    End Sub
#End Region '"BackgroundWorkers" '@@@@@@@@@@@@@@@@@@@@

#Region "ChangeScreen '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@"
    Private Sub ChangeScreen()
        ChangeBanner()
        'rotation is active, all, then report
        'if active wasn't found then we come here having setting cycle=2
        Me.TimerRefresh.Stop()
        Me.TimerGridScroll.Stop()
        If cycle = 2 And Me.lblPageTitle.Text = "Active Loads" Then
            RadGridView1.DataSource = Nothing
            SetAllLoads()
        ElseIf cycle = 2 And Me.lblPageTitle.Text = "All Loads" Then
            RadGridView1.DataSource = Nothing
            SetReport()
        ElseIf cycle = 2 And Me.lblPageTitle.Text = "REPORT" Then
            SetActiveLoads()
        End If
    End Sub

    Private Sub SetActiveLoads()
        Me.ReportViewer1.Visible = False
        ReportPanel.Visible = False
        '        Me.RadRadialGauge1.Visible = False
        Me.RadGridView1.Visible = True
        Me.lblPageTitle.Text = "Active Loads"
        'Dim ptlblpt As Point = New Point((wd / 2) - (lblPageTitle.Width / 2), 10) ' PictureBox1.Location.Y + (PictureBox1.Height / 2) - (lblPageTitle.Height / 2))
        'lblPageTitle.Location = ptlblpt
        'Dim pt As New Point((wd / 2) - (lblLocation.Width / 2), lblPageTitle.Location.Y + lblPageTitle.Height)
        'lblLocation.Location = pt
        If Not actdt Is Nothing Then
            If (Me.actdt.Rows.Count <= 0) Then
                Me.RadGridView1.DataSource = Nothing
                Me.RadGridView1.TableElement.Text = "No Loads Working ..."
                SetRefreshTimer(0, 5)
            Else
                Me.RadGridView1.DataSource = Me.actdt
                If RadGridView1.RowCount > 0 Then
                    Me.SetRefreshTimer(Me.actdt.Rows.Count)
                End If
            End If
        Else
            SetRefreshTimer(0, 5)
        End If
        If alltabledone Then
            alltabledone = False
            lblNetwork.Text = "alt"
            BackgroundAllLoads.RunWorkerAsync()
        End If
    End Sub

    Private Sub SetAllLoads()
        Me.ReportViewer1.Visible = False
        ReportPanel.Visible = False
        '        Me.RadRadialGauge1.Visible = False
        Me.RadGridView1.Visible = True
        Me.lblPageTitle.Text = "All Loads"
        If Not alldt Is Nothing Then 'we have data
            If Me.alldt.Rows.Count <= 0 Then 'and row count is not zero
                Me.RadGridView1.DataSource = Nothing
                Me.RadGridView1.TableElement.Text = "No Loads Working ..."
                SetRefreshTimer(0, 5)
                '                exitme += 1
            Else 'assign datasource and reset timer
                Me.RadGridView1.DataSource = Me.alldt
                If RadGridView1.RowCount > 0 Then    'did datasource bind?
                    Me.SetRefreshTimer(Me.RadGridView1.Rows.Count)
                Else
                    '                   exitme += 1
                    SetRefreshTimer(0, 5)
                End If
            End If
        Else 'alldt is nothing
            'did datasource bind?
            '           exitme += 1
            SetRefreshTimer(0, 5)
        End If
        '       If exitme = 2 And alldt Is Nothing And actdt Is Nothing Then
        '       SetRefreshTimer(0, 5)
        '       Else
        If RadGridView1.DataSource Is Nothing Then
            RadGridView1.TableElement.Text = "No Loads Found"
            SetRefreshTimer(0, 5)
        End If
        '       End If
        If gaugeDataDone Then
            gaugeDataDone = False
            lblNetwork.Text = "rt"
            BackgroundGaugeData.RunWorkerAsync()
        End If
    End Sub

    Private Sub SetReport() 'ByVal reportdef)
        Dim curPP As PalletsPieces = palletsPieces
        '        Me.PalletsPiecesBindingSource.DataSource = dscases.GetCases
        Dim cs As List(Of PalletsPieces) = dscases.GetCases
        Me.ReportViewer1.Visible = True
        RadGridView1.Visible = False

        'Set the processing mode for the ReportViewer to Remote  
        ReportViewer1.ProcessingMode = ProcessingMode.Local

        Dim localReport As LocalReport
        localReport = ReportViewer1.LocalReport

        '        Dim dataset As New DataSet("PalletsPieces")
        '        Dim param As ReportParameter() = New ReportParameter(1) {}
        '        param(0) = New ReportParameter("location", locationName)

        '        ReportViewer1.LocalReport.ReportEmbeddedResource = "Report1.rdlc"
        '        ReportViewer1.LocalReport.SetParameters(param)

        ReportViewer1.Visible = True
        'Refresh the report  
        '        ReportViewer1.RefreshReport()

        'Select Case reportdef

        ''End Select
        ReportPanel.Visible = True
        Dim sched As Integer = palletsPieces.PiecesScheduled
        Dim rec As Integer = palletsPieces.PiecesReceived
        lblNumCasesScheduled.Text = sched.ToString
        lblNumCasesReceived.Text = rec.ToString
        lblNumCasesPending.Text = sched - rec.ToString
        lblPctCasesScheduled.Text = Math.Round(sched / sched * 100, 0).ToString & "%"
        lblPctCasesReceived.Text = Math.Round(rec / sched * 100, 0).ToString & "%"
        lblPctCasesPending.Text = Math.Round(Math.Round(sched / sched * 100, 0) - Math.Round(rec / sched * 100, 0)).ToString & "%"
        '        Me.RadRadialGauge1.RangeEnd = piecesScheduled
        '        Me.RadRadialGauge1.Value = piecesUnloaded
        lblPageTitle.Text = "REPORT"
        cycle = 2
        If activetabledone Then
            activetabledone = False
            lblNetwork.Text = "act"
            BackgroundActiveLoads.RunWorkerAsync()
        End If

        If palletsPieces.PiecesScheduled > 0 Then
            SetRefreshTimer()
        Else
            SetRefreshTimer(0, 5)
        End If

    End Sub


#End Region '"ChangeScreen '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@"

#Region "Banners    '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@"
    Private Sub GetBanners(ByVal slocaid As String)
        If bannerArray Is Nothing Then
            bannerArray = New List(Of String)
        End If

        Dim dba As New DBAccess With {
            .CommandText = "SELECT Banner From DockMonitorBanners WHERE Enabled=1 and LocationID=@locaid ORDER BY SortOrder"
        }
        dba.AddParameter("locaid", slocaid)
        Dim dt As DataTable = New DataTable
        Try
            dt = dba.ExecuteDataSet.Tables(0)
        Catch ex As Exception
            Dim msg As String = ex.Message
        End Try
        If Not dt Is Nothing Then
            If dt.Rows.Count > 0 Then
                bannerArray = New List(Of String)
                For Each row As DataRow In dt.Rows
                    Dim str As String = row.Item("banner")
                    bannerArray.Add(str)
                Next
            End If
        End If
    End Sub

    Private Sub GetBirthdays(ByVal locaid As String)
        Dim dt As New DataTable
        Dim bday As New Birthday
        birthdays = New List(Of Birthday)
        'TO DO wire up HR database
        Dim dba As New DBAccess("hr") With {
            .CommandText = "SELECT EmployeeFirstName, EmployeeLastName FROM Employees " &
            "WHERE DATEPART(d, EmployeeDOB) = DATEPART(d, GETDATE()) " &
            "AND DATEPART(m, EmployeeDOB) = DATEPART(m, GETDATE()) " &
            "AND LocaID = @locaID" ' @@@@@ Stored as string in 0/0/00 format 0/0/00
            }
        dba.AddParameter("@locaID", slocaid)
        '        dt = dba.ExecuteDataSet.Tables(0)
        If Not dt Is Nothing Then
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    bday = New Birthday With {
                        .First = row.Item(0),
                        .Last = row.Item(1)
                    }
                    birthdays.Add(bday)
                Next
            Else
                'bday = New Birthday
                'bday.First = "Randy"
                'bday.Last = "Finster"
                'birthdays.Add(bday)
                'bday = New Birthday
                'bday.First = "Bill"
                'bday.Last = "Walklett"
                'birthdays.Add(bday)
            End If
        End If
    End Sub

    Private Sub ChangeBanner()
        If PictureBox1.Image Is Nothing Then
            GetLogo(GetParentCompany(slocaid))
        End If
        bannerArray = New List(Of String)
        If bannerArray.Count = 0 Then
            GetBanners(slocaid)
        End If
        If bannerArray.Count > 1 Then 'check birthdays
            If birthdays.Count < 1 Then
                'remove happy birthday banner
                Dim remov As String = String.Empty
                For Each bnr As String In bannerArray
                    If bnr.Contains("Happy") And bnr.Contains("Birthday") Then
                        remov = bnr
                    End If
                Next
                bannerArray.Remove(remov)
            End If
        End If
        Dim bannerText As String = String.Empty
        If bannerArray.Count < 2 Then 'add two banners for this location or add these
            Dim bannerText1 As String = "<p style=""text-align: center;font-family: Segoe UI;""><strong><span style=""font-size: 24px;"">Welcome to</span><span style=""font-size: 30px;""> " & parentCompany & "</span></strong></p>"
            Dim bannerText2 As String = "<p style=""text-align: center;""><span style=""font-family: 'Segoe UI';""><strong><span style=""font-size: 24px;"">I thought I made a <span style=""color: #c00000;"">mistake </span>once, but I was <span style=""color: #0070c0;"">mistaken</span></span></strong></span></p>"
            Dim bannerText3 As String = "<p style=""text-align: center;font-family: Segoe UI;""><strong><span style=""font-size: 24px;"">Thank You for using</span><span style=""font-size: 30px;""> Southeast Unloading</span></strong></p>"
            bannerArray.Add(bannerText1)
            bannerArray.Add(bannerText2)
            bannerArray.Add(bannerText3)
        End If
        Dim bannerText4 As String = "<p style=""text-align: center;font-family: Segoe UI;""><strong><span style=""font-size: 30px;"">seuDockMonitor <span style=""font-size: 24px;"">v2</span> by <span style=""font-size: 30px;"">RandyDev</span></strong></p>"
        bannerArray.Add(bannerText4)
        If bannerPos >= bannerArray.Count Then bannerPos = 0
        If bannerArray.Count > 0 Then
            bannerText = bannerArray(bannerPos)
            If InStr(bannerText, "[LocationName]") Then
                bannerText = Replace(bannerText, "[LocationName]", locationName)
            End If
            If InStr(bannerText, "[ParentCompany]") Then
                bannerText = Replace(bannerText, "[ParentCompany]", parentCompany)
            End If

            If birthdays.Count > 0 Then
                If InStr(bannerText, "[First]") Or InStr(bannerText, "[Last]") Then
                    If birthdaycounter = birthdays.Count Then birthdaycounter = 0
                    bannerText = Replace(bannerText, "[First]", birthdays(birthdaycounter).First)
                    bannerText = Replace(bannerText, "[Last]", birthdays(birthdaycounter).Last)
                    birthdaycounter += 1
                End If
            End If
            bannerPos += 1
        End If
        WebBrowser1.Navigate("about:blank")
        WebBrowser1.Document.OpenNew(True)
        WebBrowser1.DocumentText = bannerText
    End Sub
#End Region '"Banner"    '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

#Region "UI '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@"
    Public Sub Setscreen()
        Dim pt As System.Drawing.Point
        '@@@@@@@ Images @@@@@@@@@@
        '@@@@@@@@@@ Top @@@@@@@@@@
        pt = New Point(20, 10)
        PictureBox1.Location = pt
        pt = New Point(PictureBox1.Location.X, PictureBox1.Location.Y + 5)
        RadLabel1.Location = pt
        pt = New Point(RadLabel1.Location.X, RadLabel1.Location.Y + RadLabel1.Height + 7)
        RadLabel2.Location = pt
        pt = New Point(wd - (lblDateTime.Width + 10), lblLocation.Location.Y)
        lblDateTime.Location = pt
        pt = New Point(lblDateTime.Location.X + lblDateTime.Width - lblNetwork.Width, lblPageTitle.Height - 10)
        lblNetwork.Location = pt
        lblNetwork.BringToFront()
        pt = New Point(20, lblDateTime.Location.Y + lblDateTime.Height + 5)
        RadGridView1.Location = pt
        RadGridView1.Height = thisScreenGridHeight
        'ht -(lblDateTime.Location.Y + lblDateTime.Height + pnlUpdate.Height + 40)
        RadGridView1.Width = wd - 20
        RadGridView1.GridViewElement.TableElement.VScrollBar.MinSize =
            New Size(RadGridView1.GridViewElement.TableElement.VScrollBar.Size.Width, RadGridView1.GridViewElement.TableElement.VScrollBar.Size.Height / 5)
        RadGridView1.HorizontalScroll.Enabled = False
        RadGridView1.HorizontalScroll.Visible = False
        Me.ReportViewer1.Location = pt
        'pt = New Point(20, (thisScreenGridHeight / 2) - (RadRadialGauge1.Height / 2))
        '        Me.RadRadialGauge1.Location = pt
        '        RadRadialGauge1.Height = ReportViewer1.Height
        '        RadRadialGauge1.Width = ReportViewer1.Width * 1.5
        Me.ReportViewer1.Height = thisScreenGridHeight
        Me.ReportViewer1.Width = thisScreenGridHeight
        pt = New Point(Me.ReportViewer1.Location.X + Me.ReportViewer1.Width + 20, Me.ReportViewer1.Location.Y + ((Me.ReportViewer1.Height) / 2) - (Me.ReportPanel.Height / 2))
        Me.ReportPanel.Location = pt
        '@@@@@@@@@@ Bottom @@@@@@@@@
        PictureBox2.Image = My.Resources.SEUlogoColor
        pt = New Point(10, ht - PictureBox2.Height - (lblCopyright.Height + 10))
        PictureBox2.Location = pt
        pt = New Point(7, ht - (lblCopyright.Height + 10))
        lblCopyright.Location = pt
        pt = New Point(PictureBox2.Location.X + PictureBox2.Width + 7, PictureBox2.Location.Y)
        Me.FormBorderStyle = FormBorderStyle.None
        pt = New Point(20, ht - PictureBox2.Height - (lblCopyright.Height))
        PictureBox2.Location = pt
        pt = New Point(15, ht - (lblCopyright.Height + 1))
        lblCopyright.Location = pt
        pt = New Point(Width - lblNextUpdate.Width, PictureBox2.Location.Y)
        lbltxtNextUpdate.Location = pt
        pt = New Point(lbltxtNextUpdate.Location.X - 15, lblCopyright.Location.Y - lblNextUpdate.Height)
        lblNextUpdate.Location = pt
        lblGridPosition.Location = pt
        pt = New Point(PictureBox2.Location.X + PictureBox2.Width + 7, PictureBox2.Location.Y)
        WebBrowser1.Location = pt
        WebBrowser1.Width = wd - PictureBox2.Width - lblNextUpdate.Width - 34
        WebBrowser1.Height = PictureBox2.Height + lblCopyright.Height - 5
        '        Dim ptlblpt As Point = New Point((wd / 2) - (lblPageTitle.Width / 2), 10) ' PictureBox1.Location.Y + (PictureBox1.Height / 2) - (lblPageTitle.Height / 2))
        '        lblPageTitle.Location = ptlblpt
    End Sub

    Private Sub LblPageTitleClick(sender As Object, e As EventArgs) Handles lblPageTitle.Click
        Setscreen()
    End Sub
#End Region ' "UI" '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

#Region "RadGridView1    '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@"
    Public Function GetWorkOrders(ByVal locationName As String, Optional ByVal hideActive As Boolean = True) As DataTable
        Dim dba As New DBAccess
        'default True = all loads False hides completed (active loads only)
        '        Dim constr As String = "Data Source=reports.div-log.com;Initial Catalog=RTDS;Persist Security Info=True;User ID=rtds;Password=southeast1"
        If hideActive Then
            dba.CommandText = "SELECT DoorNumber, Vendor, PurchaseOrder, Carrier, TrailerNumber, AppointmentTime, DockTime, StartTime, CompTime, Department, ID, Unloaders " &
                "FROM dbo.tblfunc_DockMonAllLoads('" & locationName & "') AS DockMonAllLoads" 'all loads
        Else
            dba.CommandText = "SELECT DoorNumber, Vendor, PurchaseOrder, Carrier, TrailerNumber, AppointmentTime, DockTime, StartTime, CompTime, Department, ID, Unloaders " &
                "FROM dbo.tblfunc_DockMonOpenLoads('" & locationName & "') AS DockMonOpenLoads" 'hides completed
        End If
        'Dim sqldataadapter As SqlDataAdapter = New SqlDataAdapter(strSql, constr)
        'sqldataadapter.SelectCommand.CommandTimeout = 120
        'sqldataadapter.SelectCommand.CommandType = CommandType.Text
        Dim dt As DataTable = New DataTable
        Dim ds As DataSet = New DataSet
        Try
            ds = dba.ExecuteDataSet()
            dt = ds.Tables(0)
        Catch ex As Exception
            Dim err As String = ex.Message()
        End Try
        If dt.Rows.Count = 0 Then
            dt = Nothing
        End If
        Return dt
    End Function
    Private Sub RadGridView1_Paint1(sender As Object, e As PaintEventArgs) Handles RadGridView1.Paint
        If RadGridView1.Columns.Count > 0 Then
            RadGridView1.AutoScroll = True
            Dim size As Size = New Size(1, 1)
            RadGridView1.AutoScrollMinSize = size
            RadGridView1.ReadOnly = True
            Dim sz As Size = New Size(15, 15)
            RadGridView1.Columns("ID").IsVisible = False
            RadGridView1.Columns("DoorNumber").HeaderText = "Dr #"
            RadGridView1.Columns("DoorNumber").Width = 45
            RadGridView1.Columns("Vendor").Width = 200
            RadGridView1.Columns("PurchaseOrder").HeaderText = "PO #"
            RadGridView1.Columns("PurchaseOrder").Width = 100
            RadGridView1.Columns("Carrier").Width = 175
            RadGridView1.Columns("TrailerNumber").HeaderText = "Trailer"
            RadGridView1.Columns("TrailerNumber").Width = 75
            RadGridView1.Columns("AppointmentTime").HeaderText = "Appt"
            RadGridView1.Columns("AppointmentTime").Width = 85
            RadGridView1.Columns("DockTime").HeaderText = "Dock"
            RadGridView1.Columns("DockTime").Width = 85
            RadGridView1.Columns("StartTime").HeaderText = "Start"
            RadGridView1.Columns("StartTime").Width = 85
            RadGridView1.Columns("CompTime").HeaderText = "Fini"
            RadGridView1.Columns("CompTime").Width = 85
            RadGridView1.Columns("Department").Width = 110
            RadGridView1.Columns("Unloaders").WrapText = True
            Dim num As Integer = RadGridView1.Columns("DoorNumber").Width + RadGridView1.Columns("Vendor").Width +
                RadGridView1.Columns("PurchaseOrder").Width + RadGridView1.Columns("Carrier").Width +
                RadGridView1.Columns("TrailerNumber").Width + RadGridView1.Columns("AppointmentTime").Width +
                RadGridView1.Columns("DockTime").Width + RadGridView1.Columns("StartTime").Width +
                RadGridView1.Columns("CompTime").Width + RadGridView1.Columns("Department").Width + 18 + 10
            RadGridView1.Columns("Unloaders").Width = RadGridView1.Width - num '1327
            If RadGridView1.Rows.Count <= thisScreenGridRowCount Then
                If RadGridView1.TableElement.VScrollBar.Size.Width = 0 Then
                    RadGridView1.Columns("Unloaders").Width += 18
                Else
                    RadGridView1.Columns("Unloaders").Width += RadGridView1.TableElement.VScrollBar.Size.Width
                End If
            End If
        End If
    End Sub

    Private Sub RadGridView1_RowFormatting_1(sender As Object, e As RowFormattingEventArgs) Handles RadGridView1.RowFormatting
        Dim apptTime As DateTime = Nothing    'ew System.DateTime()
        Dim dockTime As System.DateTime = Nothing    'New System.DateTime()
        Dim startTime As System.DateTime = Nothing    'New System.DateTime()
        Dim compTime As System.DateTime = Nothing    'New System.DateTime()
        If (e.RowElement.RowInfo.Cells("AppointmentTime") IsNot Nothing) Then
            If e.RowElement.RowInfo.Cells("AppointmentTime").Value IsNot Nothing And Not e.RowElement.RowInfo.Cells("AppointmentTime").Value = "- - -" Then
                apptTime = CType(Date.Now.ToShortDateString & " " & e.RowElement.RowInfo.Cells("AppointmentTime").Value, DateTime)
                e.RowElement.RowInfo.Cells("AppointmentTime").Value = Strings.Format(apptTime, "h:mm tt").ToString()
            End If
            If e.RowElement.RowInfo.Cells("DockTime").Value IsNot Nothing And Not e.RowElement.RowInfo.Cells("DockTime").Value = "- - -" Then
                dockTime = CType(DateTime.Now.ToShortDateString & " " & e.RowElement.RowInfo.Cells("DockTime").Value, DateTime)
                e.RowElement.RowInfo.Cells("DockTime").Value = Strings.Format(dockTime, "h:mm tt").ToString()
            End If
            If e.RowElement.RowInfo.Cells("StartTime").Value IsNot Nothing And Not e.RowElement.RowInfo.Cells("StartTime").Value = "- - -" Then
                startTime = CType(Date.Now.ToShortDateString & " " & e.RowElement.RowInfo.Cells("StartTime").Value, DateTime)
                e.RowElement.RowInfo.Cells("StartTime").Value = Strings.Format(startTime, "h:mm tt").ToString()
            End If
            If e.RowElement.RowInfo.Cells("CompTime").Value IsNot Nothing And Not e.RowElement.RowInfo.Cells("CompTime").Value = "- - -" Then
                compTime = CType(Date.Now.ToShortDateString & " " & e.RowElement.RowInfo.Cells("CompTime").Value, DateTime)
                e.RowElement.RowInfo.Cells("CompTime").Value = Strings.Format(compTime, "h:mm tt").ToString()
            End If
            Dim surnull As DateTime = CType("1/1/1900", DateTime)
            Dim flag As Boolean = System.DateTime.Compare(dockTime, System.DateTime.MinValue) > 0 And System.DateTime.Compare(compTime, System.DateTime.MinValue) = 0
            Dim index As Integer = e.RowElement.RowInfo.Index
            e.RowElement.GradientStyle = Telerik.WinControls.GradientStyles.Solid
            If (System.DateTime.Compare(dockTime, System.DateTime.MinValue) = 0) Then
                e.RowElement.BackColor = DefaultBackColor
                e.RowElement.DrawFill = True
                e.RowElement.ForeColor = Control.DefaultForeColor
            ElseIf (Not flag) Then
                e.RowElement.ForeColor = DefaultForeColor
                e.RowElement.BackColor = Color.FromArgb(188, 204, 180)
                e.RowElement.GradientStyle = Telerik.WinControls.GradientStyles.Solid
                e.RowElement.DrawFill = True
                If DateAndTime.DateDiff(DateInterval.Hour, startTime, compTime) > 2 Then
                    e.RowElement.ForeColor = Color.Red
                End If
            Else
                e.RowElement.ForeColor = DefaultForeColor
                e.RowElement.BackColor = DefaultBackColor
                e.RowElement.DrawFill = True
                If (System.DateTime.Compare(startTime, System.DateTime.MinValue) <= 0) Then
                    e.RowElement.ForeColor = DefaultForeColor
                    If Not e.RowElement.RowInfo.Cells("Unloaders").Value = "- - -" Then
                        e.RowElement.BackColor = Color.FromArgb(173, 214, 255)
                    End If
                Else
                    Dim num As Integer = DateAndTime.DateDiff(DateInterval.Minute, dockTime, System.DateTime.Now)
                    If (num > 120) Then
                        e.RowElement.BackColor = Color.Red
                    ElseIf (num <= 90) Then
                        e.RowElement.BackColor = Control.DefaultBackColor
                    Else
                        e.RowElement.BackColor = Color.Orange
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub MoveGrid()
        '    TO DO
        Dim maxScrollBar As Integer = (Me.RadGridView1.TableElement.VScrollBar.Maximum + 53) - Me.thisScreenGridHeight
        Dim value As Integer = Me.RadGridView1.TableElement.VScrollBar.Value
        Dim pcnt As Integer = (value / maxScrollBar) * 100
        Dim rowcount As Integer = RadGridView1.Rows.Count ' Me.RadGridView1.CurrentRow.ViewInfo.Rows.Count
        If rowcount > 0 Then
            If rowcount > Me.thisScreenGridRowCount Then
                Dim gplbl As String = "Rows: " & rowcount.ToString & vbCrLf & "Cycle: " & cycle.ToString & "  of 2 - " & "0%"
                lblGridPosition.Text = gplbl
                If Me.RadGridView1.TableElement.VScrollBar.Value = 0 Then
                    Thread.Sleep(10000)
                End If
                If Me.RadGridView1.TableElement.VScrollBar.Value >= maxScrollBar Then
                    Thread.Sleep(5000)
                    If cycle = 2 Then
                        ChangeScreen()
                        Exit Sub
                    Else
                        ChangeBanner()
                        cycle += 1
                        RadGridView1.TableElement.VScrollBar.Value = 0
                        gplbl = "Rows: " & rowcount.ToString & vbCrLf & "Cycle: " & cycle.ToString & "  of 2 - 0%"
                        lblGridPosition.Text = gplbl
                    End If
                Else
                    Me.RadGridView1.TableElement.VScrollBar.Value += 1
                    gplbl = "Rows: " & rowcount.ToString & vbCrLf & "Cycle: " & cycle.ToString & " of 2 - " & pcnt.ToString & "%"
                    lblGridPosition.Text = gplbl
                End If
            End If
        End If
    End Sub
    Private Sub RadGridView1_CurrentRowChanging(sender As Object, e As CurrentRowChangingEventArgs)
        e.Cancel = True
    End Sub

    Private Sub RadGridView1_SelectionChanged(sender As Object, e As EventArgs)
        Dim asd As String = String.Empty
    End Sub
#End Region '"RadGridView1"    '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

#Region "Utilities    '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@"
    Private Function GetParentCompany(ByVal locaid As String) As String
        Dim retstr As String = String.Empty
        Dim dba As New DBAccess With {
            .CommandText = "SELECT ParentCompany.Name " &
            "FROM Location INNER JOIN " &
            "ParentCompany ON Location.ParentCompanyID = ParentCompany.ID " &
            "WHERE (Location.ID = @locaid)"
        }
        dba.AddParameter("@locaid", locaid)
        Dim i As Integer = 0
        Do While i < 4
            Try
                retstr = dba.ExecuteScalar
                If retstr.Length > 0 Then i = 4
            Catch ex As Exception
                Dim err As String = ex.Message
            End Try
            i += 1
        Loop
        parentCompany = retstr
        Return retstr
    End Function

    Private Sub GetLogo(ByVal parentName As String)
        'image location
        Dim imgdirectory As String = My.Application.Info.DirectoryPath & "\"
        parentName = parentName.Replace(" ", String.Empty)        'strip spaces for image name
        Dim logoName As String = parentName & ".jpg"        'create name
        Dim locaLogo As String = imgdirectory & logoName        'full path to logoName
        Dim curLogo As System.Drawing.Image
        Try
            curLogo = Image.FromFile(locaLogo)        'init curLogo with client logo
            PictureBox1.Image = curLogo
        Catch ex As Exception
            RadLabel1.Text = RadLabel1.Text
            RadLabel1.Visible = True
            RadLabel2.Visible = True
        End Try
        If PictureBox1.ImageLocation Is Nothing Then
            Dim i As Integer
            Dim strwebfolder As String = "http://seu.div-log.com/images/" & logoName
            Dim wc As Net.WebClient = New Net.WebClient
            While i < 4
                If Not FileIO.FileSystem.FileExists(logoName) Then
                    Try
                        wc = New Net.WebClient
                        wc.DownloadFile(strwebfolder, logoName)
                    Catch ex As Exception
                        Dim msg As String = ex.Message
                    Finally
                        wc.Dispose()
                    End Try
                Else
                    Try
                        curLogo = Image.FromFile(logoName)
                        PictureBox1.Image = curLogo  'ScaleImage(curlogo, PictureBox1.Height, PictureBox1.Width)
                    Catch ex As Exception
                        RadLabel1.Visible = True
                        RadLabel2.Visible = True
                    End Try
                End If
                If PictureBox1.Image Is Nothing Then
                    i += 1
                    RadLabel1.Visible = True
                    RadLabel2.Visible = True
                Else
                    i = 4
                    PictureBox1.Visible = True
                    RadLabel1.Visible = False
                    RadLabel2.Visible = False
                End If

            End While
        End If
        'Loading Site Logo one moment please ...
    End Sub

    Public Function GetXMLdata(ByVal itm As String) As String
        Dim strRet As String = String.Empty
        Dim locaconfig As String = "seuDMconfig.xml"
        Dim xmldoc As New XmlDocument
        Try
            xmldoc.Load(locaconfig)
            Dim txt As XmlNode = xmldoc.SelectSingleNode("/appConfig")
            With txt
                Select Case itm
                    Case "Location_Name"
                        strRet = .SelectSingleNode("Location_Name").InnerText
                    Case "Location_Id"
                        strRet = .SelectSingleNode("Location_Id").InnerText
                End Select
            End With
        Catch ex As Exception
            MessageBox.Show("Configuration File: seuDMconfig.XML can not be found")
            Application.Exit()
        End Try
        If strRet = "00000000-0000-0000-0000-000000000000" Then
            MessageBox.Show("Configuration File: seuDMconfig.XML is not well formed")
            Application.Exit()
        End If
        Return strRet
    End Function

    Public Function ScaleImage(ByVal oldImage As Image, ByVal targetHeight As Integer, ByVal targetWidth As Integer) As System.Drawing.Image
        Dim newHeight As Integer = targetHeight
        Dim newWidth As Integer = newHeight / oldImage.Height * oldImage.Width
        If newWidth > targetWidth Then
            newWidth = targetWidth
            newHeight = newWidth / oldImage.Width * oldImage.Height
        End If
        Return New Bitmap(oldImage, newWidth, newHeight)
    End Function
#End Region '"Utilities    '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@"


    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub


End Class
' object_9299713e_9074_4c7f_84ea_0607aa03375e

