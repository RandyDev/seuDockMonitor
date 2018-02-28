<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmseuDockMonitor
    Inherits Telerik.WinControls.UI.RadForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim SortDescriptor2 As Telerik.WinControls.Data.SortDescriptor = New Telerik.WinControls.Data.SortDescriptor()
        Dim TableViewDefinition2 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.PalletsPiecesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PalletsPieces2 = New seuDockMonitor.PalletsPieces()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblPageTitle = New Telerik.WinControls.UI.RadLabel()
        Me.lblLocation = New Telerik.WinControls.UI.RadLabel()
        Me.lblDateTime = New Telerik.WinControls.UI.RadLabel()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.lblCopyright = New Telerik.WinControls.UI.RadLabel()
        Me.lblNextUpdate = New Telerik.WinControls.UI.RadLabel()
        Me.lbltxtNextUpdate = New Telerik.WinControls.UI.RadLabel()
        Me.object_9299713e_9074_4c7f_84ea_0607aa03375e = New Telerik.WinControls.RootRadElement()
        Me.BackgroundAllLoads = New System.ComponentModel.BackgroundWorker()
        Me.BackgroundActiveLoads = New System.ComponentModel.BackgroundWorker()
        Me.RadGridView1 = New Telerik.WinControls.UI.RadGridView()
        Me.lblGridPosition = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel1 = New Telerik.WinControls.UI.RadLabel()
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.TimerDateTime = New System.Windows.Forms.Timer(Me.components)
        Me.TimerRefresh = New System.Windows.Forms.Timer(Me.components)
        Me.TimerGridScroll = New System.Windows.Forms.Timer(Me.components)
        Me.RadLabel2 = New Telerik.WinControls.UI.RadLabel()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.BackgroundGaugeData = New System.ComponentModel.BackgroundWorker()
        Me.ReportPanel = New System.Windows.Forms.Panel()
        Me.lblPctCasesPending = New Telerik.WinControls.UI.RadLabel()
        Me.lblPctCasesScheduled = New Telerik.WinControls.UI.RadLabel()
        Me.lblPctCasesReceived = New Telerik.WinControls.UI.RadLabel()
        Me.lblNumCasesPending = New Telerik.WinControls.UI.RadLabel()
        Me.lblNumCasesScheduled = New Telerik.WinControls.UI.RadLabel()
        Me.lblNumCasesReceived = New Telerik.WinControls.UI.RadLabel()
        Me.lblCasesPending = New Telerik.WinControls.UI.RadLabel()
        Me.lblCasesReceived = New Telerik.WinControls.UI.RadLabel()
        Me.lblCasesScheduled = New Telerik.WinControls.UI.RadLabel()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.lblNetwork = New Telerik.WinControls.UI.RadLabel()
        Me.PalletsPiecesTableAdapter = New seuDockMonitor.PalletsPiecesTableAdapters.PalletsPiecesTableAdapter()
        CType(Me.PalletsPiecesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PalletsPieces2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPageTitle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblLocation, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDateTime, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCopyright, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblNextUpdate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lbltxtNextUpdate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGridView1.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblGridPosition, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ReportPanel.SuspendLayout()
        CType(Me.lblPctCasesPending, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPctCasesScheduled, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPctCasesReceived, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblNumCasesPending, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblNumCasesScheduled, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblNumCasesReceived, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCasesPending, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCasesReceived, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCasesScheduled, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblNetwork, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PalletsPiecesBindingSource
        '
        Me.PalletsPiecesBindingSource.DataMember = "PalletsPieces"
        Me.PalletsPiecesBindingSource.DataSource = Me.PalletsPieces2
        '
        'PalletsPieces2
        '
        Me.PalletsPieces2.DataSetName = "PalletsPieces"
        Me.PalletsPieces2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(15, 11)
        Me.PictureBox1.MaximumSize = New System.Drawing.Size(272, 68)
        Me.PictureBox1.MinimumSize = New System.Drawing.Size(68, 68)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(272, 68)
        Me.PictureBox1.TabIndex = 5
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'lblPageTitle
        '
        Me.lblPageTitle.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblPageTitle.AutoSize = False
        Me.lblPageTitle.Font = New System.Drawing.Font("Arial Narrow", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPageTitle.Location = New System.Drawing.Point(620, 11)
        Me.lblPageTitle.Name = "lblPageTitle"
        Me.lblPageTitle.Size = New System.Drawing.Size(200, 33)
        Me.lblPageTitle.TabIndex = 6
        Me.lblPageTitle.Text = "Page Title"
        Me.lblPageTitle.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblLocation
        '
        Me.lblLocation.AutoSize = False
        Me.lblLocation.BackColor = System.Drawing.Color.Transparent
        Me.lblLocation.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLocation.Location = New System.Drawing.Point(620, 50)
        Me.lblLocation.Name = "lblLocation"
        Me.lblLocation.Size = New System.Drawing.Size(200, 21)
        Me.lblLocation.TabIndex = 7
        Me.lblLocation.Text = "Location"
        Me.lblLocation.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDateTime
        '
        Me.lblDateTime.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDateTime.Location = New System.Drawing.Point(967, 66)
        Me.lblDateTime.Name = "lblDateTime"
        Me.lblDateTime.Size = New System.Drawing.Size(309, 33)
        Me.lblDateTime.TabIndex = 9
        Me.lblDateTime.Text = "12:00 AM - Monday - 31 Sept"
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.Location = New System.Drawing.Point(24, 350)
        Me.PictureBox2.MaximumSize = New System.Drawing.Size(230, 68)
        Me.PictureBox2.MinimumSize = New System.Drawing.Size(0, 68)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(230, 68)
        Me.PictureBox2.TabIndex = 10
        Me.PictureBox2.TabStop = False
        '
        'lblCopyright
        '
        Me.lblCopyright.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblCopyright.Location = New System.Drawing.Point(19, 415)
        Me.lblCopyright.Margin = New System.Windows.Forms.Padding(0)
        Me.lblCopyright.Name = "lblCopyright"
        Me.lblCopyright.Size = New System.Drawing.Size(213, 18)
        Me.lblCopyright.TabIndex = 11
        Me.lblCopyright.Text = "Southeast Unloading  All Rights Reserved"
        '
        'lblNextUpdate
        '
        Me.lblNextUpdate.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblNextUpdate.AutoSize = False
        Me.lblNextUpdate.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lblNextUpdate.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNextUpdate.ForeColor = System.Drawing.Color.White
        Me.lblNextUpdate.Location = New System.Drawing.Point(1126, 386)
        Me.lblNextUpdate.Name = "lblNextUpdate"
        Me.lblNextUpdate.Size = New System.Drawing.Size(167, 35)
        Me.lblNextUpdate.TabIndex = 2
        Me.lblNextUpdate.Text = "--:--"
        Me.lblNextUpdate.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbltxtNextUpdate
        '
        Me.lbltxtNextUpdate.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lbltxtNextUpdate.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltxtNextUpdate.Location = New System.Drawing.Point(1136, 311)
        Me.lbltxtNextUpdate.Name = "lbltxtNextUpdate"
        Me.lbltxtNextUpdate.ShowItemToolTips = False
        Me.lbltxtNextUpdate.Size = New System.Drawing.Size(140, 30)
        Me.lbltxtNextUpdate.TabIndex = 2
        Me.lbltxtNextUpdate.Text = "Next Update In"
        Me.lbltxtNextUpdate.TextAlignment = System.Drawing.ContentAlignment.TopLeft
        '
        'object_9299713e_9074_4c7f_84ea_0607aa03375e
        '
        Me.object_9299713e_9074_4c7f_84ea_0607aa03375e.AutoSize = False
        Me.object_9299713e_9074_4c7f_84ea_0607aa03375e.ClickMode = Telerik.WinControls.ClickMode.Release
        Me.object_9299713e_9074_4c7f_84ea_0607aa03375e.Enabled = False
        Me.object_9299713e_9074_4c7f_84ea_0607aa03375e.Name = "object_9299713e_9074_4c7f_84ea_0607aa03375e"
        Me.object_9299713e_9074_4c7f_84ea_0607aa03375e.StretchHorizontally = True
        Me.object_9299713e_9074_4c7f_84ea_0607aa03375e.StretchVertically = True
        Me.object_9299713e_9074_4c7f_84ea_0607aa03375e.Visibility = Telerik.WinControls.ElementVisibility.Hidden
        '
        'BackgroundAllLoads
        '
        '
        'BackgroundActiveLoads
        '
        '
        'RadGridView1
        '
        Me.RadGridView1.BackColor = System.Drawing.Color.White
        Me.RadGridView1.Cursor = System.Windows.Forms.Cursors.Default
        Me.RadGridView1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadGridView1.ForeColor = System.Drawing.Color.Black
        Me.RadGridView1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.RadGridView1.Location = New System.Drawing.Point(5, 86)
        '
        '
        '
        Me.RadGridView1.MasterTemplate.AllowColumnChooser = False
        Me.RadGridView1.MasterTemplate.AllowDragToGroup = False
        Me.RadGridView1.MasterTemplate.EnableGrouping = False
        Me.RadGridView1.MasterTemplate.EnableSorting = False
        SortDescriptor2.Direction = System.ComponentModel.ListSortDirection.Descending
        SortDescriptor2.PropertyName = "Vendor"
        Me.RadGridView1.MasterTemplate.SortDescriptors.AddRange(New Telerik.WinControls.Data.SortDescriptor() {SortDescriptor2})
        Me.RadGridView1.MasterTemplate.ViewDefinition = TableViewDefinition2
        Me.RadGridView1.Name = "RadGridView1"
        Me.RadGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RadGridView1.Size = New System.Drawing.Size(1314, 252)
        Me.RadGridView1.TabIndex = 20
        Me.RadGridView1.Text = "RadGridView1"
        '
        'lblGridPosition
        '
        Me.lblGridPosition.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblGridPosition.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lblGridPosition.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGridPosition.ForeColor = System.Drawing.Color.White
        Me.lblGridPosition.Location = New System.Drawing.Point(1126, 346)
        Me.lblGridPosition.MinimumSize = New System.Drawing.Size(167, 0)
        Me.lblGridPosition.Name = "lblGridPosition"
        '
        '
        '
        Me.lblGridPosition.RootElement.MinSize = New System.Drawing.Size(167, 0)
        Me.lblGridPosition.Size = New System.Drawing.Size(167, 44)
        Me.lblGridPosition.TabIndex = 22
        Me.lblGridPosition.Text = "Rows: ---" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Cycle # of 2 - 0%" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.lblGridPosition.TextAlignment = System.Drawing.ContentAlignment.TopLeft
        '
        'RadLabel1
        '
        Me.RadLabel1.AllowShowFocusCues = True
        Me.RadLabel1.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLabel1.Location = New System.Drawing.Point(325, 15)
        Me.RadLabel1.Name = "RadLabel1"
        Me.RadLabel1.Size = New System.Drawing.Size(143, 25)
        Me.RadLabel1.TabIndex = 22
        Me.RadLabel1.Text = "Loading Site Logo"
        '
        'WebBrowser1
        '
        Me.WebBrowser1.CausesValidation = False
        Me.WebBrowser1.Location = New System.Drawing.Point(337, 350)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.ScrollBarsEnabled = False
        Me.WebBrowser1.Size = New System.Drawing.Size(597, 77)
        Me.WebBrowser1.TabIndex = 24
        '
        'TimerDateTime
        '
        Me.TimerDateTime.Interval = 60000
        '
        'TimerRefresh
        '
        Me.TimerRefresh.Interval = 1000
        '
        'TimerGridScroll
        '
        Me.TimerGridScroll.Interval = 35
        '
        'RadLabel2
        '
        Me.RadLabel2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLabel2.Location = New System.Drawing.Point(329, 51)
        Me.RadLabel2.Name = "RadLabel2"
        '
        '
        '
        Me.RadLabel2.RootElement.CanFocus = True
        Me.RadLabel2.RootElement.MaxSize = New System.Drawing.Size(0, 0)
        Me.RadLabel2.RootElement.UseDefaultDisabledPaint = True
        Me.RadLabel2.Size = New System.Drawing.Size(143, 21)
        Me.RadLabel2.TabIndex = 23
        Me.RadLabel2.Text = "One moment please ..."
        '
        'ReportViewer1
        '
        Me.ReportViewer1.DocumentMapWidth = 394
        ReportDataSource2.Name = "DataSet1"
        ReportDataSource2.Value = Me.PalletsPiecesBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportViewer1.LocalReport.DisplayName = "Report"
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "seuDockMonitor.Report1.rdlc"
        Me.ReportViewer1.LocalReport.ReportPath = "Report1.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(360, 91)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.ShowToolBar = False
        Me.ReportViewer1.Size = New System.Drawing.Size(396, 246)
        Me.ReportViewer1.TabIndex = 25
        '
        'BackgroundGaugeData
        '
        '
        'ReportPanel
        '
        Me.ReportPanel.Controls.Add(Me.lblPctCasesPending)
        Me.ReportPanel.Controls.Add(Me.lblPctCasesScheduled)
        Me.ReportPanel.Controls.Add(Me.lblPctCasesReceived)
        Me.ReportPanel.Controls.Add(Me.lblNumCasesPending)
        Me.ReportPanel.Controls.Add(Me.lblNumCasesScheduled)
        Me.ReportPanel.Controls.Add(Me.lblNumCasesReceived)
        Me.ReportPanel.Controls.Add(Me.lblCasesPending)
        Me.ReportPanel.Controls.Add(Me.lblCasesReceived)
        Me.ReportPanel.Controls.Add(Me.lblCasesScheduled)
        Me.ReportPanel.Controls.Add(Me.ShapeContainer1)
        Me.ReportPanel.Location = New System.Drawing.Point(810, 130)
        Me.ReportPanel.Name = "ReportPanel"
        Me.ReportPanel.Size = New System.Drawing.Size(472, 124)
        Me.ReportPanel.TabIndex = 26
        '
        'lblPctCasesPending
        '
        Me.lblPctCasesPending.AutoSize = False
        Me.lblPctCasesPending.Font = New System.Drawing.Font("Arial Rounded MT Bold", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPctCasesPending.ForeColor = System.Drawing.Color.DarkRed
        Me.lblPctCasesPending.Location = New System.Drawing.Point(363, 78)
        Me.lblPctCasesPending.Name = "lblPctCasesPending"
        Me.lblPctCasesPending.Size = New System.Drawing.Size(67, 29)
        Me.lblPctCasesPending.TabIndex = 7
        Me.lblPctCasesPending.Text = "53%"
        Me.lblPctCasesPending.TextAlignment = System.Drawing.ContentAlignment.BottomRight
        '
        'lblPctCasesScheduled
        '
        Me.lblPctCasesScheduled.AutoSize = False
        Me.lblPctCasesScheduled.Font = New System.Drawing.Font("Arial Rounded MT Bold", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPctCasesScheduled.Location = New System.Drawing.Point(362, 10)
        Me.lblPctCasesScheduled.Name = "lblPctCasesScheduled"
        Me.lblPctCasesScheduled.Size = New System.Drawing.Size(67, 29)
        Me.lblPctCasesScheduled.TabIndex = 5
        Me.lblPctCasesScheduled.Text = "100%"
        Me.lblPctCasesScheduled.TextAlignment = System.Drawing.ContentAlignment.BottomRight
        '
        'lblPctCasesReceived
        '
        Me.lblPctCasesReceived.AutoSize = False
        Me.lblPctCasesReceived.Font = New System.Drawing.Font("Arial Rounded MT Bold", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPctCasesReceived.Location = New System.Drawing.Point(362, 44)
        Me.lblPctCasesReceived.Name = "lblPctCasesReceived"
        Me.lblPctCasesReceived.Size = New System.Drawing.Size(67, 29)
        Me.lblPctCasesReceived.TabIndex = 6
        Me.lblPctCasesReceived.Text = "47%"
        Me.lblPctCasesReceived.TextAlignment = System.Drawing.ContentAlignment.BottomRight
        '
        'lblNumCasesPending
        '
        Me.lblNumCasesPending.AutoSize = False
        Me.lblNumCasesPending.Font = New System.Drawing.Font("Arial Rounded MT Bold", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumCasesPending.ForeColor = System.Drawing.Color.DarkRed
        Me.lblNumCasesPending.Location = New System.Drawing.Point(245, 78)
        Me.lblNumCasesPending.Name = "lblNumCasesPending"
        Me.lblNumCasesPending.Size = New System.Drawing.Size(87, 29)
        Me.lblNumCasesPending.TabIndex = 4
        Me.lblNumCasesPending.Text = "22253"
        Me.lblNumCasesPending.TextAlignment = System.Drawing.ContentAlignment.BottomRight
        '
        'lblNumCasesScheduled
        '
        Me.lblNumCasesScheduled.AutoSize = False
        Me.lblNumCasesScheduled.Font = New System.Drawing.Font("Arial Rounded MT Bold", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumCasesScheduled.Location = New System.Drawing.Point(244, 10)
        Me.lblNumCasesScheduled.Name = "lblNumCasesScheduled"
        Me.lblNumCasesScheduled.Size = New System.Drawing.Size(87, 29)
        Me.lblNumCasesScheduled.TabIndex = 2
        Me.lblNumCasesScheduled.Text = "42257"
        Me.lblNumCasesScheduled.TextAlignment = System.Drawing.ContentAlignment.BottomRight
        '
        'lblNumCasesReceived
        '
        Me.lblNumCasesReceived.AutoSize = False
        Me.lblNumCasesReceived.Font = New System.Drawing.Font("Arial Rounded MT Bold", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumCasesReceived.ForeColor = System.Drawing.Color.Red
        Me.lblNumCasesReceived.Location = New System.Drawing.Point(244, 44)
        Me.lblNumCasesReceived.Name = "lblNumCasesReceived"
        Me.lblNumCasesReceived.Size = New System.Drawing.Size(87, 29)
        Me.lblNumCasesReceived.TabIndex = 3
        Me.lblNumCasesReceived.Text = "19994"
        Me.lblNumCasesReceived.TextAlignment = System.Drawing.ContentAlignment.BottomRight
        '
        'lblCasesPending
        '
        Me.lblCasesPending.Font = New System.Drawing.Font("Arial Rounded MT Bold", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCasesPending.Location = New System.Drawing.Point(11, 78)
        Me.lblCasesPending.Name = "lblCasesPending"
        Me.lblCasesPending.Size = New System.Drawing.Size(166, 29)
        Me.lblCasesPending.TabIndex = 1
        Me.lblCasesPending.Text = "Cases Pending"
        '
        'lblCasesReceived
        '
        Me.lblCasesReceived.Font = New System.Drawing.Font("Arial Rounded MT Bold", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCasesReceived.Location = New System.Drawing.Point(10, 44)
        Me.lblCasesReceived.Name = "lblCasesReceived"
        Me.lblCasesReceived.Size = New System.Drawing.Size(178, 29)
        Me.lblCasesReceived.TabIndex = 1
        Me.lblCasesReceived.Text = "Cases Received"
        '
        'lblCasesScheduled
        '
        Me.lblCasesScheduled.Font = New System.Drawing.Font("Arial Rounded MT Bold", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCasesScheduled.Location = New System.Drawing.Point(10, 10)
        Me.lblCasesScheduled.Name = "lblCasesScheduled"
        Me.lblCasesScheduled.Size = New System.Drawing.Size(192, 29)
        Me.lblCasesScheduled.TabIndex = 0
        Me.lblCasesScheduled.Text = "Cases Scheduled"
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(472, 124)
        Me.ShapeContainer1.TabIndex = 2
        Me.ShapeContainer1.TabStop = False
        '
        'LineShape1
        '
        Me.LineShape1.Name = "LineShape1"
        Me.LineShape1.X1 = 194
        Me.LineShape1.X2 = 453
        Me.LineShape1.Y1 = 75
        Me.LineShape1.Y2 = 75
        '
        'lblNetwork
        '
        Me.lblNetwork.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNetwork.Location = New System.Drawing.Point(905, 16)
        Me.lblNetwork.Name = "lblNetwork"
        Me.lblNetwork.Size = New System.Drawing.Size(29, 18)
        Me.lblNetwork.TabIndex = 27
        Me.lblNetwork.Text = " ---  "
        Me.lblNetwork.TextAlignment = System.Drawing.ContentAlignment.TopLeft
        '
        'PalletsPiecesTableAdapter
        '
        Me.PalletsPiecesTableAdapter.ClearBeforeFill = True
        '
        'FrmseuDockMonitor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1358, 436)
        Me.Controls.Add(Me.lblNetwork)
        Me.Controls.Add(Me.ReportPanel)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Controls.Add(Me.lblNextUpdate)
        Me.Controls.Add(Me.WebBrowser1)
        Me.Controls.Add(Me.RadLabel2)
        Me.Controls.Add(Me.RadLabel1)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.RadGridView1)
        Me.Controls.Add(Me.lblCopyright)
        Me.Controls.Add(Me.lblDateTime)
        Me.Controls.Add(Me.lblPageTitle)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lbltxtNextUpdate)
        Me.Controls.Add(Me.lblGridPosition)
        Me.Controls.Add(Me.lblLocation)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MinimizeBox = False
        Me.Name = "FrmseuDockMonitor"
        Me.RightToLeftLayout = True
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "seuDockMonitor "
        Me.TopMost = True
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
        CType(Me.PalletsPiecesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PalletsPieces2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPageTitle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblLocation, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDateTime, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblCopyright, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblNextUpdate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lbltxtNextUpdate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGridView1.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblGridPosition, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ReportPanel.ResumeLayout(False)
        Me.ReportPanel.PerformLayout()
        CType(Me.lblPctCasesPending, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPctCasesScheduled, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPctCasesReceived, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblNumCasesPending, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblNumCasesScheduled, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblNumCasesReceived, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblCasesPending, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblCasesReceived, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblCasesScheduled, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblNetwork, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblPageTitle As Telerik.WinControls.UI.RadLabel
    Friend WithEvents lblLocation As Telerik.WinControls.UI.RadLabel
    Friend WithEvents lblDateTime As Telerik.WinControls.UI.RadLabel
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents lblCopyright As Telerik.WinControls.UI.RadLabel
    Friend WithEvents lblNextUpdate As Telerik.WinControls.UI.RadLabel
    Friend WithEvents lbltxtNextUpdate As Telerik.WinControls.UI.RadLabel
    'Friend WithEvents BackgroundAllLoads As System.ComponentModel.BackgroundWorker
    'Friend WithEvents BackgroundActiveLoads As System.ComponentModel.BackgroundWorker
    Friend WithEvents object_9299713e_9074_4c7f_84ea_0607aa03375e As Telerik.WinControls.RootRadElement
    Friend WithEvents BackgroundAllLoads As System.ComponentModel.BackgroundWorker
    Friend WithEvents BackgroundActiveLoads As System.ComponentModel.BackgroundWorker
    Friend WithEvents RadGridView1 As Telerik.WinControls.UI.RadGridView
    Friend WithEvents RadLabel1 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser
    Friend WithEvents TimerDateTime As System.Windows.Forms.Timer
    Friend WithEvents TimerRefresh As System.Windows.Forms.Timer
    Friend WithEvents TimerGridScroll As System.Windows.Forms.Timer
    Friend WithEvents lblGridPosition As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel2 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents BackgroundGaugeData As System.ComponentModel.BackgroundWorker
    Friend WithEvents ReportPanel As System.Windows.Forms.Panel
    Friend WithEvents lblCasesPending As Telerik.WinControls.UI.RadLabel
    Friend WithEvents lblCasesReceived As Telerik.WinControls.UI.RadLabel
    Friend WithEvents lblCasesScheduled As Telerik.WinControls.UI.RadLabel
    Friend WithEvents lblNumCasesPending As Telerik.WinControls.UI.RadLabel
    Friend WithEvents lblNumCasesScheduled As Telerik.WinControls.UI.RadLabel
    Friend WithEvents lblNumCasesReceived As Telerik.WinControls.UI.RadLabel
    Friend WithEvents lblPctCasesPending As Telerik.WinControls.UI.RadLabel
    Friend WithEvents lblPctCasesScheduled As Telerik.WinControls.UI.RadLabel
    Friend WithEvents lblPctCasesReceived As Telerik.WinControls.UI.RadLabel
    Friend WithEvents lblNetwork As Telerik.WinControls.UI.RadLabel
    Private WithEvents ShapeContainer1 As PowerPacks.ShapeContainer
    Private WithEvents LineShape1 As PowerPacks.LineShape
    Friend WithEvents PalletsPieces1 As PalletsPieces
    Friend WithEvents PalletsPieces2 As PalletsPieces
    Friend WithEvents PalletsPiecesBindingSource As BindingSource
    Friend WithEvents PalletsPiecesTableAdapter As PalletsPiecesTableAdapters.PalletsPiecesTableAdapter
End Class
