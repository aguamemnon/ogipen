<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormLstTroncons
    Inherits DevComponents.DotNetBar.OfficeForm
    Private components As System.ComponentModel.IContainer = Nothing
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
    'Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim GridColumn1 As DevComponents.DotNetBar.SuperGrid.GridColumn = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Dim GridColumn2 As DevComponents.DotNetBar.SuperGrid.GridColumn = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Dim GridColumn3 As DevComponents.DotNetBar.SuperGrid.GridColumn = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Dim GridColumn4 As DevComponents.DotNetBar.SuperGrid.GridColumn = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Dim GridColumn5 As DevComponents.DotNetBar.SuperGrid.GridColumn = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Dim GridColumn6 As DevComponents.DotNetBar.SuperGrid.GridColumn = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Dim GridColumn7 As DevComponents.DotNetBar.SuperGrid.GridColumn = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Dim GridColumn8 As DevComponents.DotNetBar.SuperGrid.GridColumn = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Dim GridColumn9 As DevComponents.DotNetBar.SuperGrid.GridColumn = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Dim GridColumn10 As DevComponents.DotNetBar.SuperGrid.GridColumn = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Dim GridColumn11 As DevComponents.DotNetBar.SuperGrid.GridColumn = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Dim GridColumn12 As DevComponents.DotNetBar.SuperGrid.GridColumn = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Dim GridColumn13 As DevComponents.DotNetBar.SuperGrid.GridColumn = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Dim GridColumn14 As DevComponents.DotNetBar.SuperGrid.GridColumn = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Dim GridColumn15 As DevComponents.DotNetBar.SuperGrid.GridColumn = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Dim GridColumn16 As DevComponents.DotNetBar.SuperGrid.GridColumn = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Dim GridColumn17 As DevComponents.DotNetBar.SuperGrid.GridColumn = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Dim GridColumn18 As DevComponents.DotNetBar.SuperGrid.GridColumn = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Dim GridColumn19 As DevComponents.DotNetBar.SuperGrid.GridColumn = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Dim GridColumn20 As DevComponents.DotNetBar.SuperGrid.GridColumn = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Dim GridColumn21 As DevComponents.DotNetBar.SuperGrid.GridColumn = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Dim GridColumn22 As DevComponents.DotNetBar.SuperGrid.GridColumn = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Dim GridColumn23 As DevComponents.DotNetBar.SuperGrid.GridColumn = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Dim GridColumn24 As DevComponents.DotNetBar.SuperGrid.GridColumn = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Dim GridColumn25 As DevComponents.DotNetBar.SuperGrid.GridColumn = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Dim GridColumn26 As DevComponents.DotNetBar.SuperGrid.GridColumn = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Dim GridColumn27 As DevComponents.DotNetBar.SuperGrid.GridColumn = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Dim GridColumn28 As DevComponents.DotNetBar.SuperGrid.GridColumn = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Dim GridColumn29 As DevComponents.DotNetBar.SuperGrid.GridColumn = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Dim GridColumn30 As DevComponents.DotNetBar.SuperGrid.GridColumn = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Dim GridColumn31 As DevComponents.DotNetBar.SuperGrid.GridColumn = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Dim GridColumn32 As DevComponents.DotNetBar.SuperGrid.GridColumn = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.ProgressBarX1 = New DevComponents.DotNetBar.Controls.ProgressBarX()
        Me.Actualisation_Data = New System.ComponentModel.BackgroundWorker()
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX2 = New DevComponents.DotNetBar.ButtonX()
        Me.SuperGridControl1 = New DevComponents.DotNetBar.SuperGrid.SuperGridControl()
        Me.Lst_tronconsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MydbDataSet = New progelec.mydbDataSet()
        Me.SwitchButton1 = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Cables_troncon_idBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Cable_details_tronconBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TronconsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TableAdapterManager = New progelec.mydbDataSetTableAdapters.TableAdapterManager()
        Me.TronconsTableAdapter = New progelec.mydbDataSetTableAdapters.tronconsTableAdapter()
        Me.Cables_troncon_idTableAdapter = New progelec.mydbDataSetTableAdapters.cables_troncon_idTableAdapter()
        Me.Cable_details_tronconTableAdapter = New progelec.mydbDataSetTableAdapters.cable_details_tronconTableAdapter()
        Me.Lst_tronconsTableAdapter = New progelec.mydbDataSetTableAdapters.lst_tronconsTableAdapter()
        CType(Me.Lst_tronconsBindingSource,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.MydbDataSet,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.Cables_troncon_idBindingSource,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.Cable_details_tronconBindingSource,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TronconsBindingSource,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'ProgressBarX1
        '
        Me.ProgressBarX1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        '
        '
        '
        Me.ProgressBarX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Diagonal
        Me.ProgressBarX1.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.ProgressBarX1.Location = New System.Drawing.Point(17, 191)
        Me.ProgressBarX1.Name = "ProgressBarX1"
        Me.ProgressBarX1.Size = New System.Drawing.Size(1247, 95)
        Me.ProgressBarX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ProgressBarX1.TabIndex = 3
        Me.ProgressBarX1.Text = "Chargement en cours ..........."
        Me.ProgressBarX1.TextVisible = true
        Me.ProgressBarX1.Visible = false
        '
        'Actualisation_Data
        '
        Me.Actualisation_Data.WorkerReportsProgress = true
        Me.Actualisation_Data.WorkerSupportsCancellation = true
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX1.Image = Global.progelec.My.Resources.Resources.process_2_24_24
        Me.ButtonX1.Location = New System.Drawing.Point(1141, 38)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Size = New System.Drawing.Size(123, 34)
        Me.ButtonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX1.TabIndex = 7
        Me.ButtonX1.Text = "Calcul Taux de remplissage"
        '
        'ButtonX2
        '
        Me.ButtonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX2.Image = Global.progelec.My.Resources.Resources.repeat_1_32_32
        Me.ButtonX2.Location = New System.Drawing.Point(17, 37)
        Me.ButtonX2.Name = "ButtonX2"
        Me.ButtonX2.Size = New System.Drawing.Size(134, 35)
        Me.ButtonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX2.TabIndex = 9
        Me.ButtonX2.Text = "Rafraichissement Data"
        '
        'SuperGridControl1
        '
        Me.SuperGridControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.SuperGridControl1.BackColor = System.Drawing.Color.FromArgb(CType(CType(239,Byte),Integer), CType(CType(239,Byte),Integer), CType(CType(242,Byte),Integer))
        Me.SuperGridControl1.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed
        Me.SuperGridControl1.FilterUseExtendedCustomDialog = true
        Me.SuperGridControl1.ForeColor = System.Drawing.Color.Black
        Me.SuperGridControl1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.SuperGridControl1.Location = New System.Drawing.Point(17, 86)
        Me.SuperGridControl1.Name = "SuperGridControl1"
        GridColumn1.DataPropertyName = "idtroncons"
        GridColumn1.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridIntegerInputEditControl)
        GridColumn1.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        GridColumn1.FilterAutoScan = true
        GridColumn1.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions
        GridColumn1.HeaderText = "idtroncons"
        GridColumn1.Name = "idtroncons"
        GridColumn1.ShowPanelFilterExpr = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        GridColumn1.Visible = false
        GridColumn2.DataPropertyName = "Type"
        GridColumn2.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        GridColumn2.FilterAutoScan = true
        GridColumn2.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions
        GridColumn2.HeaderText = "Type"
        GridColumn2.Name = "Type"
        GridColumn2.ShowPanelFilterExpr = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        GridColumn3.DataPropertyName = "repere troncon"
        GridColumn3.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        GridColumn3.FilterAutoScan = true
        GridColumn3.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions
        GridColumn3.HeaderText = "repere troncon"
        GridColumn3.Name = "repere troncon"
        GridColumn3.ShowPanelFilterExpr = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        GridColumn4.DataPropertyName = "segregation"
        GridColumn4.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        GridColumn4.FilterAutoScan = true
        GridColumn4.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions
        GridColumn4.HeaderText = "segregation"
        GridColumn4.Name = "segregation"
        GridColumn4.ShowPanelFilterExpr = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        GridColumn5.DataPropertyName = "repere salle"
        GridColumn5.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        GridColumn5.FilterAutoScan = true
        GridColumn5.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions
        GridColumn5.HeaderText = "Salle T"
        GridColumn5.Name = "repere salle"
        GridColumn5.ShowPanelFilterExpr = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        GridColumn6.DataPropertyName = "repere salle1"
        GridColumn6.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        GridColumn6.FilterAutoScan = true
        GridColumn6.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions
        GridColumn6.HeaderText = "Salle A"
        GridColumn6.Name = "repere salle1"
        GridColumn6.ShowPanelFilterExpr = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        GridColumn7.DataPropertyName = "largeur"
        GridColumn7.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        GridColumn7.FilterAutoScan = true
        GridColumn7.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions
        GridColumn7.HeaderText = "largeur"
        GridColumn7.Name = "largeur"
        GridColumn7.ShowPanelFilterExpr = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        GridColumn8.DataPropertyName = "longueur"
        GridColumn8.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        GridColumn8.FilterAutoScan = true
        GridColumn8.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions
        GridColumn8.HeaderText = "longueur"
        GridColumn8.Name = "longueur"
        GridColumn8.ShowPanelFilterExpr = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        GridColumn9.DataPropertyName = "hauteur"
        GridColumn9.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        GridColumn9.FilterAutoScan = true
        GridColumn9.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions
        GridColumn9.HeaderText = "hauteur"
        GridColumn9.Name = "hauteur"
        GridColumn9.ShowPanelFilterExpr = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        GridColumn10.DataPropertyName = "elevation"
        GridColumn10.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        GridColumn10.FilterAutoScan = true
        GridColumn10.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions
        GridColumn10.HeaderText = "elevation"
        GridColumn10.Name = "elevation"
        GridColumn10.ShowPanelFilterExpr = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        GridColumn11.DataPropertyName = "reserves"
        GridColumn11.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        GridColumn11.FilterAutoScan = true
        GridColumn11.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions
        GridColumn11.HeaderText = "% Mono"
        GridColumn11.Name = "reserves"
        GridColumn11.ShowPanelFilterExpr = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        GridColumn12.DataPropertyName = "Reserve_cal"
        GridColumn12.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridIntegerInputEditControl)
        GridColumn12.HeaderText = "Val Mono"
        GridColumn12.Name = "2-Reserve_cal"
        GridColumn13.DataPropertyName = "Reserve_cal"
        GridColumn13.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridProgressBarXEditControl)
        GridColumn13.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        GridColumn13.FilterAutoScan = true
        GridColumn13.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions
        GridColumn13.HeaderText = "Rem. Mono"
        GridColumn13.Name = "Reserve_cal"
        GridColumn13.ShowPanelFilterExpr = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        GridColumn14.DataPropertyName = "reserves2"
        GridColumn14.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        GridColumn14.FilterAutoScan = true
        GridColumn14.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions
        GridColumn14.HeaderText = "% Multi"
        GridColumn14.Name = "reserves2"
        GridColumn14.ShowPanelFilterExpr = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        GridColumn15.DataPropertyName = "reserve2_cal"
        GridColumn15.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridIntegerInputEditControl)
        GridColumn15.HeaderText = "Val Multi"
        GridColumn15.Name = "2-reserve2_cal"
        GridColumn16.DataPropertyName = "reserve2_cal"
        GridColumn16.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridProgressBarXEditControl)
        GridColumn16.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        GridColumn16.FilterAutoScan = true
        GridColumn16.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions
        GridColumn16.HeaderText = "Rempl Multi"
        GridColumn16.Name = "reserve2_cal"
        GridColumn16.ShowPanelFilterExpr = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        GridColumn17.DataPropertyName = "formes"
        GridColumn17.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        GridColumn17.FilterAutoScan = true
        GridColumn17.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions
        GridColumn17.HeaderText = "formes"
        GridColumn17.Name = "formes"
        GridColumn17.ShowPanelFilterExpr = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        GridColumn18.DataPropertyName = "margesH"
        GridColumn18.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        GridColumn18.FilterAutoScan = true
        GridColumn18.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions
        GridColumn18.HeaderText = "margesH"
        GridColumn18.Name = "margesH"
        GridColumn18.ShowPanelFilterExpr = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        GridColumn19.DataPropertyName = "margesL"
        GridColumn19.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        GridColumn19.FilterAutoScan = true
        GridColumn19.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions
        GridColumn19.HeaderText = "margesL"
        GridColumn19.Name = "margesL"
        GridColumn19.ShowPanelFilterExpr = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        GridColumn20.DataPropertyName = "Diametre"
        GridColumn20.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        GridColumn20.FilterAutoScan = true
        GridColumn20.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions
        GridColumn20.HeaderText = "Diametre"
        GridColumn20.Name = "Diametre"
        GridColumn20.ShowPanelFilterExpr = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        GridColumn21.DataPropertyName = "version"
        GridColumn21.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridIntegerInputEditControl)
        GridColumn21.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        GridColumn21.FilterAutoScan = true
        GridColumn21.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions
        GridColumn21.HeaderText = "version"
        GridColumn21.Name = "version"
        GridColumn21.ShowPanelFilterExpr = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        GridColumn22.DataPropertyName = "Qui"
        GridColumn22.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        GridColumn22.FilterAutoScan = true
        GridColumn22.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions
        GridColumn22.HeaderText = "Qui"
        GridColumn22.Name = "Qui"
        GridColumn22.ShowPanelFilterExpr = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        GridColumn23.DataPropertyName = "date_calcul"
        GridColumn23.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridDateTimeInputEditControl)
        GridColumn23.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        GridColumn23.FilterAutoScan = true
        GridColumn23.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions
        GridColumn23.HeaderText = "date_calcul"
        GridColumn23.Name = "date_calcul"
        GridColumn23.ShowPanelFilterExpr = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        GridColumn24.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.AllCellsExceptHeader
        GridColumn24.DataPropertyName = "virtuel"
        GridColumn24.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridCheckBoxXEditControl)
        GridColumn24.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        GridColumn24.FilterAutoScan = true
        GridColumn24.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions
        GridColumn24.HeaderText = "virtuel"
        GridColumn24.Name = "virtuel"
        GridColumn24.ShowPanelFilterExpr = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        GridColumn25.DataPropertyName = "reserve_reel"
        GridColumn25.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        GridColumn25.FilterAutoScan = true
        GridColumn25.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions
        GridColumn25.HeaderText = "reserve_reel"
        GridColumn25.Name = "reserve_reel"
        GridColumn25.ShowPanelFilterExpr = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        GridColumn26.DataPropertyName = "reserve2_reel"
        GridColumn26.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        GridColumn26.FilterAutoScan = true
        GridColumn26.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions
        GridColumn26.HeaderText = "reserve2_reel"
        GridColumn26.Name = "reserve2_reel"
        GridColumn26.ShowPanelFilterExpr = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        GridColumn27.DataPropertyName = "nbcouche"
        GridColumn27.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridIntegerInputEditControl)
        GridColumn27.HeaderText = "nbcouche"
        GridColumn27.Name = "nbcouche"
        GridColumn28.DataPropertyName = "reserve_lot"
        GridColumn28.HeaderText = "reserve_lot"
        GridColumn28.Name = "reserve_lot"
        GridColumn29.DataPropertyName = "Masse_calcule"
        GridColumn29.HeaderText = "Masse/trc"
        GridColumn29.Name = ""
        GridColumn29.NullString = "<<Null>>"
        GridColumn30.DataPropertyName = "interbat"
        GridColumn30.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridCheckBoxXEditControl)
        GridColumn30.HeaderText = "interbat"
        GridColumn30.Name = "interbat"
        GridColumn31.DataPropertyName = "nom"
        GridColumn31.HeaderText = "Batiment T"
        GridColumn31.Name = "nom"
        GridColumn32.DataPropertyName = "nom1"
        GridColumn32.HeaderText = "Batiment B"
        GridColumn32.Name = "nom1"
        Me.SuperGridControl1.PrimaryGrid.Columns.Add(GridColumn1)
        Me.SuperGridControl1.PrimaryGrid.Columns.Add(GridColumn2)
        Me.SuperGridControl1.PrimaryGrid.Columns.Add(GridColumn3)
        Me.SuperGridControl1.PrimaryGrid.Columns.Add(GridColumn4)
        Me.SuperGridControl1.PrimaryGrid.Columns.Add(GridColumn5)
        Me.SuperGridControl1.PrimaryGrid.Columns.Add(GridColumn6)
        Me.SuperGridControl1.PrimaryGrid.Columns.Add(GridColumn7)
        Me.SuperGridControl1.PrimaryGrid.Columns.Add(GridColumn8)
        Me.SuperGridControl1.PrimaryGrid.Columns.Add(GridColumn9)
        Me.SuperGridControl1.PrimaryGrid.Columns.Add(GridColumn10)
        Me.SuperGridControl1.PrimaryGrid.Columns.Add(GridColumn11)
        Me.SuperGridControl1.PrimaryGrid.Columns.Add(GridColumn12)
        Me.SuperGridControl1.PrimaryGrid.Columns.Add(GridColumn13)
        Me.SuperGridControl1.PrimaryGrid.Columns.Add(GridColumn14)
        Me.SuperGridControl1.PrimaryGrid.Columns.Add(GridColumn15)
        Me.SuperGridControl1.PrimaryGrid.Columns.Add(GridColumn16)
        Me.SuperGridControl1.PrimaryGrid.Columns.Add(GridColumn17)
        Me.SuperGridControl1.PrimaryGrid.Columns.Add(GridColumn18)
        Me.SuperGridControl1.PrimaryGrid.Columns.Add(GridColumn19)
        Me.SuperGridControl1.PrimaryGrid.Columns.Add(GridColumn20)
        Me.SuperGridControl1.PrimaryGrid.Columns.Add(GridColumn21)
        Me.SuperGridControl1.PrimaryGrid.Columns.Add(GridColumn22)
        Me.SuperGridControl1.PrimaryGrid.Columns.Add(GridColumn23)
        Me.SuperGridControl1.PrimaryGrid.Columns.Add(GridColumn24)
        Me.SuperGridControl1.PrimaryGrid.Columns.Add(GridColumn25)
        Me.SuperGridControl1.PrimaryGrid.Columns.Add(GridColumn26)
        Me.SuperGridControl1.PrimaryGrid.Columns.Add(GridColumn27)
        Me.SuperGridControl1.PrimaryGrid.Columns.Add(GridColumn28)
        Me.SuperGridControl1.PrimaryGrid.Columns.Add(GridColumn29)
        Me.SuperGridControl1.PrimaryGrid.Columns.Add(GridColumn30)
        Me.SuperGridControl1.PrimaryGrid.Columns.Add(GridColumn31)
        Me.SuperGridControl1.PrimaryGrid.Columns.Add(GridColumn32)
        Me.SuperGridControl1.PrimaryGrid.DataSource = Me.Lst_tronconsBindingSource
        Me.SuperGridControl1.PrimaryGrid.EnableColumnFiltering = true
        Me.SuperGridControl1.PrimaryGrid.EnableFiltering = true
        Me.SuperGridControl1.PrimaryGrid.EnableRowFiltering = true
        Me.SuperGridControl1.PrimaryGrid.Filter.Visible = true
        Me.SuperGridControl1.PrimaryGrid.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions
        Me.SuperGridControl1.PrimaryGrid.NullString = "<<null>>"
        Me.SuperGridControl1.PrimaryGrid.SortLevel = CType((DevComponents.DotNetBar.SuperGrid.SortLevel.Root Or DevComponents.DotNetBar.SuperGrid.SortLevel.Expanded),DevComponents.DotNetBar.SuperGrid.SortLevel)
        Me.SuperGridControl1.Size = New System.Drawing.Size(1247, 295)
        Me.SuperGridControl1.TabIndex = 10
        Me.SuperGridControl1.Text = "SuperGridControl1"
        '
        'Lst_tronconsBindingSource
        '
        Me.Lst_tronconsBindingSource.DataMember = "lst_troncons"
        Me.Lst_tronconsBindingSource.DataSource = Me.MydbDataSet
        '
        'MydbDataSet
        '
        Me.MydbDataSet.CaseSensitive = true
        Me.MydbDataSet.DataSetName = "mydbDataSet"
        Me.MydbDataSet.EnforceConstraints = false
        Me.MydbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'SwitchButton1
        '
        '
        '
        '
        Me.SwitchButton1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.SwitchButton1.Location = New System.Drawing.Point(271, 51)
        Me.SwitchButton1.Name = "SwitchButton1"
        Me.SwitchButton1.OffText = "Non"
        Me.SwitchButton1.OnText = "Oui"
        Me.SwitchButton1.Size = New System.Drawing.Size(66, 22)
        Me.SwitchButton1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.SwitchButton1.TabIndex = 11
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(157, 50)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(108, 23)
        Me.LabelX1.TabIndex = 12
        Me.LabelX1.Text = "Afficher + de details"
        '
        'Cables_troncon_idBindingSource
        '
        Me.Cables_troncon_idBindingSource.DataMember = "cables_troncon_id"
        Me.Cables_troncon_idBindingSource.DataSource = Me.MydbDataSet
        '
        'Cable_details_tronconBindingSource
        '
        Me.Cable_details_tronconBindingSource.DataMember = "cable_details_troncon"
        Me.Cable_details_tronconBindingSource.DataSource = Me.MydbDataSet
        '
        'TronconsBindingSource
        '
        Me.TronconsBindingSource.DataMember = "troncons"
        Me.TronconsBindingSource.DataSource = Me.MydbDataSet
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.actions_borniersTableAdapter = Nothing
        Me.TableAdapterManager.actions_cablesTableAdapter = Nothing
        Me.TableAdapterManager.actions_departsTableAdapter = Nothing
        Me.TableAdapterManager.actions_diversTableAdapter = Nothing
        Me.TableAdapterManager.actions_equipementsTableAdapter = Nothing
        Me.TableAdapterManager.actions_tronconsTableAdapter = Nothing
        Me.TableAdapterManager.actions_typesTableAdapter = Nothing
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = false
        Me.TableAdapterManager.batimentsTableAdapter = Nothing
        Me.TableAdapterManager.borniers_modifTableAdapter = Nothing
        Me.TableAdapterManager.borniersTableAdapter = Nothing
        Me.TableAdapterManager.cables_details_has_fournituresTableAdapter = Nothing
        Me.TableAdapterManager.cables_details_has_tourets_poseTableAdapter = Nothing
        Me.TableAdapterManager.cables_details_has_touretsTableAdapter = Nothing
        Me.TableAdapterManager.cables_detailsTableAdapter = Nothing
        Me.TableAdapterManager.cables_modifTableAdapter = Nothing
        Me.TableAdapterManager.cablesTableAdapter = Nothing
        Me.TableAdapterManager.categoriesTableAdapter = Nothing
        Me.TableAdapterManager.commande_detailsTableAdapter = Nothing
        Me.TableAdapterManager.commandeTableAdapter = Nothing
        Me.TableAdapterManager.courbe_avancement_reelTableAdapter = Nothing
        Me.TableAdapterManager.courbe_avancementTableAdapter = Nothing
        Me.TableAdapterManager.departs_modifTableAdapter = Nothing
        Me.TableAdapterManager.departsTableAdapter = Nothing
        Me.TableAdapterManager.doc_referenceTableAdapter = Nothing
        Me.TableAdapterManager.documents_has_touretsTableAdapter = Nothing
        Me.TableAdapterManager.documentsTableAdapter = Nothing
        Me.TableAdapterManager.donnees_cablesTableAdapter = Nothing
        Me.TableAdapterManager.editionsTableAdapter = Nothing
        Me.TableAdapterManager.emplacementTableAdapter = Nothing
        Me.TableAdapterManager.equipements_dispo_histoTableAdapter = Nothing
        Me.TableAdapterManager.equipements_dispoTableAdapter = Nothing
        Me.TableAdapterManager.equipements_has_fournituresTableAdapter = Nothing
        Me.TableAdapterManager.equipements_modifTableAdapter = Nothing
        Me.TableAdapterManager.equipementsTableAdapter = Nothing
        Me.TableAdapterManager.fournisseursTableAdapter = Nothing
        Me.TableAdapterManager.fournitures_has_documentsTableAdapter = Nothing
        Me.TableAdapterManager.fournituresTableAdapter = Nothing
        Me.TableAdapterManager.livraisons_detailsTableAdapter = Nothing
        Me.TableAdapterManager.livraisonsTableAdapter = Nothing
        Me.TableAdapterManager.lotsTableAdapter = Nothing
        Me.TableAdapterManager.modifdetailTableAdapter = Nothing
        Me.TableAdapterManager.modiforigineTableAdapter = Nothing
        Me.TableAdapterManager.modifrevTableAdapter = Nothing
        Me.TableAdapterManager.modifTableAdapter = Nothing
        Me.TableAdapterManager.modiftypeTableAdapter = Nothing
        Me.TableAdapterManager.parcours_detailTableAdapter = Nothing
        Me.TableAdapterManager.parcoursTableAdapter = Nothing
        Me.TableAdapterManager.plg_blocageTableAdapter = Nothing
        Me.TableAdapterManager.plg_jalons_has_equipementsTableAdapter = Nothing
        Me.TableAdapterManager.plg_jalons_has_sallesTableAdapter = Nothing
        Me.TableAdapterManager.plg_jalonsTableAdapter = Nothing
        Me.TableAdapterManager.plg_madTableAdapter = Nothing
        Me.TableAdapterManager.positionTableAdapter = Nothing
        Me.TableAdapterManager.revbaseTableAdapter = Nothing
        Me.TableAdapterManager.revisionTableAdapter = Nothing
        Me.TableAdapterManager.salles_dispo_histoTableAdapter = Nothing
        Me.TableAdapterManager.salles_dispoTableAdapter = Nothing
        Me.TableAdapterManager.sallesTableAdapter = Nothing
        Me.TableAdapterManager.sections_cablesTableAdapter = Nothing
        Me.TableAdapterManager.segregationsTableAdapter = Nothing
        Me.TableAdapterManager.tourets_has_fournituresTableAdapter = Nothing
        Me.TableAdapterManager.touretsTableAdapter = Nothing
        Me.TableAdapterManager.troncons_assocTableAdapter = Nothing
        Me.TableAdapterManager.troncons_fournituresTableAdapter = Nothing
        Me.TableAdapterManager.troncons_modifTableAdapter = Nothing
        Me.TableAdapterManager.tronconsTableAdapter = Me.TronconsTableAdapter
        Me.TableAdapterManager.type_docTableAdapter = Nothing
        Me.TableAdapterManager.types_cableTableAdapter = Nothing
        Me.TableAdapterManager.types_tronconsTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = progelec.mydbDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'TronconsTableAdapter
        '
        Me.TronconsTableAdapter.ClearBeforeFill = true
        '
        'Cables_troncon_idTableAdapter
        '
        Me.Cables_troncon_idTableAdapter.ClearBeforeFill = true
        '
        'Cable_details_tronconTableAdapter
        '
        Me.Cable_details_tronconTableAdapter.ClearBeforeFill = true
        '
        'Lst_tronconsTableAdapter
        '
        Me.Lst_tronconsTableAdapter.ClearBeforeFill = true
        '
        'FormLstTroncons
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = true
        Me.ClientSize = New System.Drawing.Size(1281, 395)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.SwitchButton1)
        Me.Controls.Add(Me.ProgressBarX1)
        Me.Controls.Add(Me.SuperGridControl1)
        Me.Controls.Add(Me.ButtonX2)
        Me.Controls.Add(Me.ButtonX1)
        Me.DoubleBuffered = true
        Me.Name = "FormLstTroncons"
        Me.Text = "Liste Tronçons "
        CType(Me.Lst_tronconsBindingSource,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.MydbDataSet,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.Cables_troncon_idBindingSource,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.Cable_details_tronconBindingSource,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TronconsBindingSource,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents MydbDataSet As progelec.mydbDataSet


    ' Friend WithEvents TableAdapterManager As progelec.mydbDataSetTableAdapters.TableAdapterManager



    Friend WithEvents TableAdapterManager As progelec.mydbDataSetTableAdapters.TableAdapterManager
    Friend WithEvents Cables_troncon_idBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Cables_troncon_idTableAdapter As progelec.mydbDataSetTableAdapters.cables_troncon_idTableAdapter
    Friend WithEvents Cable_details_tronconBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Cable_details_tronconTableAdapter As progelec.mydbDataSetTableAdapters.cable_details_tronconTableAdapter
    Friend WithEvents TronconsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TronconsTableAdapter As progelec.mydbDataSetTableAdapters.tronconsTableAdapter
    Friend WithEvents Lst_tronconsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Lst_tronconsTableAdapter As progelec.mydbDataSetTableAdapters.lst_tronconsTableAdapter
    Friend WithEvents ProgressBarX1 As DevComponents.DotNetBar.Controls.ProgressBarX
    Friend WithEvents Actualisation_Data As System.ComponentModel.BackgroundWorker
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX2 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents SuperGridControl1 As DevComponents.DotNetBar.SuperGrid.SuperGridControl
    Friend WithEvents SwitchButton1 As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX

End Class
