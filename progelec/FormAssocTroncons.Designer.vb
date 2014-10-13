<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAssocTroncons
    Inherits DevComponents.DotNetBar.RibbonForm

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
        Dim SegregationLabel As System.Windows.Forms.Label
        Dim Repere_salle1Label As System.Windows.Forms.Label
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormAssocTroncons))
        Me.GroupBoxAssociations = New System.Windows.Forms.GroupBox()
        Me.SuperGridControl = New DevComponents.DotNetBar.SuperGrid.SuperGridControl()
        Me.Lst_troncons_sameBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MydbDataSet = New progelec.mydbDataSet()
        Me.GroupBoxDallesInterne = New System.Windows.Forms.GroupBox()
        Me.SuperGridControl1 = New DevComponents.DotNetBar.SuperGrid.SuperGridControl()
        Me.lblSalle = New System.Windows.Forms.Label()
        Me.GroupBoxDallesAProxymitees = New System.Windows.Forms.GroupBox()
        Me.SuperGridControl3 = New DevComponents.DotNetBar.SuperGrid.SuperGridControl()
        Me.lblTronconSelectionne = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuperGridControl2 = New DevComponents.DotNetBar.SuperGrid.SuperGridControl()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ButtonXAssocier = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonXFermer = New DevComponents.DotNetBar.ButtonX()
        Me.Repere_salleComboBox = New System.Windows.Forms.ComboBox()
        Me.SallesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.IdsalleTextBox = New System.Windows.Forms.TextBox()
        Me.SegregationComboBox = New System.Windows.Forms.ComboBox()
        Me.SegregationsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.IdsegregationsTextBox = New System.Windows.Forms.TextBox()
        Me.Repere_salle1TextBox = New System.Windows.Forms.TextBox()
        Me.Lst_troncons_onBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBox = New System.Windows.Forms.TextBox()
        Me.Salles_2 = New System.Windows.Forms.BindingSource(Me.components)
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.SallesTableAdapter = New progelec.mydbDataSetTableAdapters.sallesTableAdapter()
        Me.TronconsTableAdapter = New progelec.mydbDataSetTableAdapters.tronconsTableAdapter()
        Me.SegregationsTableAdapter = New progelec.mydbDataSetTableAdapters.segregationsTableAdapter()
        Me.Troncons_assocTableAdapter = New progelec.mydbDataSetTableAdapters.troncons_assocTableAdapter()
        Me.TableAdapterManager = New progelec.mydbDataSetTableAdapters.TableAdapterManager()
        Me.TronconsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Lst_troncons_segBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Lst_troncons_seg2BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Troncons_assocBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Lst_troncons_onTableAdapter = New progelec.mydbDataSetTableAdapters.lst_troncons_onTableAdapter()
        Me.Lst_troncons_segTableAdapter = New progelec.mydbDataSetTableAdapters.lst_troncons_segTableAdapter()
        Me.Lst_troncons_sameTableAdapter = New progelec.mydbDataSetTableAdapters.lst_troncons_sameTableAdapter()
        Me.Lst_troncons_seg2TableAdapter = New progelec.mydbDataSetTableAdapters.lst_troncons_seg2TableAdapter()
        Me.TextBoxX1 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TextBoxX2 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TextBoxX3 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.NDrawingDocument1 = New Nevron.Diagram.NDrawingDocument()
        Me.NLibraryDocument1 = New Nevron.Diagram.NLibraryDocument()
        Me.NDrawingView1 = New Nevron.Diagram.WinForm.NDrawingView()
        Me.Lst_assoc_seg_salleBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Lst_assoc_seg_salleTableAdapter = New progelec.mydbDataSetTableAdapters.lst_assoc_seg_salleTableAdapter()
        Me.Lst_trc_salle_segBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Lst_trc_salle_segTableAdapter = New progelec.mydbDataSetTableAdapters.lst_trc_salle_segTableAdapter()
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        SegregationLabel = New System.Windows.Forms.Label()
        Repere_salle1Label = New System.Windows.Forms.Label()
        Me.GroupBoxAssociations.SuspendLayout
        CType(Me.Lst_troncons_sameBindingSource,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.MydbDataSet,System.ComponentModel.ISupportInitialize).BeginInit
        Me.GroupBoxDallesInterne.SuspendLayout
        Me.GroupBoxDallesAProxymitees.SuspendLayout
        Me.GroupBox1.SuspendLayout
        CType(Me.SallesBindingSource,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.SegregationsBindingSource,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.Lst_troncons_onBindingSource,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.Salles_2,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TronconsBindingSource,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.Lst_troncons_segBindingSource,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.Lst_troncons_seg2BindingSource,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.Troncons_assocBindingSource,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.Lst_assoc_seg_salleBindingSource,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.Lst_trc_salle_segBindingSource,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'SegregationLabel
        '
        SegregationLabel.AutoSize = true
        SegregationLabel.Location = New System.Drawing.Point(200, 85)
        SegregationLabel.Name = "SegregationLabel"
        SegregationLabel.Size = New System.Drawing.Size(65, 13)
        SegregationLabel.TabIndex = 10
        SegregationLabel.Text = "segregation:"
        '
        'Repere_salle1Label
        '
        Repere_salle1Label.AutoSize = true
        Repere_salle1Label.Location = New System.Drawing.Point(323, 429)
        Repere_salle1Label.Name = "Repere_salle1Label"
        Repere_salle1Label.Size = New System.Drawing.Size(128, 13)
        Repere_salle1Label.TabIndex = 17
        Repere_salle1Label.Text = "repere salle Abouissante :"
        '
        'GroupBoxAssociations
        '
        Me.GroupBoxAssociations.Controls.Add(Me.SuperGridControl)
        Me.GroupBoxAssociations.Location = New System.Drawing.Point(354, 131)
        Me.GroupBoxAssociations.Name = "GroupBoxAssociations"
        Me.GroupBoxAssociations.Size = New System.Drawing.Size(262, 287)
        Me.GroupBoxAssociations.TabIndex = 19
        Me.GroupBoxAssociations.TabStop = false
        Me.GroupBoxAssociations.Text = "Associations"
        '
        'SuperGridControl
        '
        Me.SuperGridControl.BackColor = System.Drawing.Color.White
        Me.SuperGridControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperGridControl.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed
        Me.SuperGridControl.ForeColor = System.Drawing.Color.Black
        Me.SuperGridControl.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.SuperGridControl.Location = New System.Drawing.Point(3, 16)
        Me.SuperGridControl.Name = "SuperGridControl"
        GridColumn1.DataPropertyName = "idtroncons"
        GridColumn1.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridIntegerInputEditControl)
        GridColumn1.HeaderText = "idtroncons"
        GridColumn1.Name = "idtroncons"
        GridColumn1.Visible = false
        GridColumn2.DataPropertyName = "repere troncon"
        GridColumn2.HeaderText = "repere troncon"
        GridColumn2.Name = "repere troncon"
        GridColumn3.DataPropertyName = "segregation"
        GridColumn3.HeaderText = "segregation"
        GridColumn3.Name = "segregation"
        GridColumn4.DataPropertyName = "repere salle"
        GridColumn4.HeaderText = "repere salle"
        GridColumn4.Name = "repere salle"
        GridColumn5.DataPropertyName = "repere salle1"
        GridColumn5.HeaderText = "repere salle1"
        GridColumn5.Name = "repere salle1"
        GridColumn6.DataPropertyName = "largeur"
        GridColumn6.HeaderText = "largeur"
        GridColumn6.Name = "largeur"
        GridColumn7.DataPropertyName = "longueur"
        GridColumn7.HeaderText = "longueur"
        GridColumn7.Name = "longueur"
        GridColumn8.DataPropertyName = "hauteur"
        GridColumn8.HeaderText = "hauteur"
        GridColumn8.Name = "hauteur"
        GridColumn9.DataPropertyName = "elevation"
        GridColumn9.HeaderText = "elevation"
        GridColumn9.Name = "elevation"
        GridColumn10.DataPropertyName = "reserves"
        GridColumn10.HeaderText = "reserves"
        GridColumn10.Name = "reserves"
        GridColumn11.DataPropertyName = "reserves2"
        GridColumn11.HeaderText = "reserves2"
        GridColumn11.Name = "reserves2"
        GridColumn12.DataPropertyName = "formes"
        GridColumn12.HeaderText = "formes"
        GridColumn12.Name = "formes"
        GridColumn13.DataPropertyName = "margesH"
        GridColumn13.HeaderText = "margesH"
        GridColumn13.Name = "margesH"
        GridColumn14.DataPropertyName = "margesL"
        GridColumn14.HeaderText = "margesL"
        GridColumn14.Name = "margesL"
        GridColumn15.DataPropertyName = "Diametre"
        GridColumn15.HeaderText = "Diametre"
        GridColumn15.Name = "Diametre"
        GridColumn16.DataPropertyName = "version"
        GridColumn16.HeaderText = "version"
        GridColumn16.Name = "version"
        GridColumn17.DataPropertyName = "Qui"
        GridColumn17.HeaderText = "Qui"
        GridColumn17.Name = "Qui"
        GridColumn18.DataPropertyName = "Type"
        GridColumn18.HeaderText = "Type"
        GridColumn18.Name = "Type"
        GridColumn19.DataPropertyName = "Reserve_cal"
        GridColumn19.HeaderText = "Reserve_cal"
        GridColumn19.Name = "Reserve_cal"
        GridColumn20.DataPropertyName = "reserve_reel"
        GridColumn20.HeaderText = "reserve_reel"
        GridColumn20.Name = "reserve_reel"
        GridColumn21.DataPropertyName = "date_calcul"
        GridColumn21.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridDateTimeInputEditControl)
        GridColumn21.HeaderText = "date_calcul"
        GridColumn21.Name = "date_calcul"
        GridColumn22.DataPropertyName = "reserve2_cal"
        GridColumn22.HeaderText = "reserve2_cal"
        GridColumn22.Name = "reserve2_cal"
        GridColumn23.DataPropertyName = "reserve2_reel"
        GridColumn23.HeaderText = "reserve2_reel"
        GridColumn23.Name = "reserve2_reel"
        GridColumn24.DataPropertyName = "virtuel"
        GridColumn24.HeaderText = "virtuel"
        GridColumn24.Name = "virtuel"
        GridColumn25.DataPropertyName = "troncons"
        GridColumn25.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridIntegerInputEditControl)
        GridColumn25.HeaderText = "troncons"
        GridColumn25.Name = "troncons"
        GridColumn26.DataPropertyName = "troncons_tenant"
        GridColumn26.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridIntegerInputEditControl)
        GridColumn26.HeaderText = "troncons_tenant"
        GridColumn26.Name = "troncons_tenant"
        Me.SuperGridControl.PrimaryGrid.Columns.Add(GridColumn1)
        Me.SuperGridControl.PrimaryGrid.Columns.Add(GridColumn2)
        Me.SuperGridControl.PrimaryGrid.Columns.Add(GridColumn3)
        Me.SuperGridControl.PrimaryGrid.Columns.Add(GridColumn4)
        Me.SuperGridControl.PrimaryGrid.Columns.Add(GridColumn5)
        Me.SuperGridControl.PrimaryGrid.Columns.Add(GridColumn6)
        Me.SuperGridControl.PrimaryGrid.Columns.Add(GridColumn7)
        Me.SuperGridControl.PrimaryGrid.Columns.Add(GridColumn8)
        Me.SuperGridControl.PrimaryGrid.Columns.Add(GridColumn9)
        Me.SuperGridControl.PrimaryGrid.Columns.Add(GridColumn10)
        Me.SuperGridControl.PrimaryGrid.Columns.Add(GridColumn11)
        Me.SuperGridControl.PrimaryGrid.Columns.Add(GridColumn12)
        Me.SuperGridControl.PrimaryGrid.Columns.Add(GridColumn13)
        Me.SuperGridControl.PrimaryGrid.Columns.Add(GridColumn14)
        Me.SuperGridControl.PrimaryGrid.Columns.Add(GridColumn15)
        Me.SuperGridControl.PrimaryGrid.Columns.Add(GridColumn16)
        Me.SuperGridControl.PrimaryGrid.Columns.Add(GridColumn17)
        Me.SuperGridControl.PrimaryGrid.Columns.Add(GridColumn18)
        Me.SuperGridControl.PrimaryGrid.Columns.Add(GridColumn19)
        Me.SuperGridControl.PrimaryGrid.Columns.Add(GridColumn20)
        Me.SuperGridControl.PrimaryGrid.Columns.Add(GridColumn21)
        Me.SuperGridControl.PrimaryGrid.Columns.Add(GridColumn22)
        Me.SuperGridControl.PrimaryGrid.Columns.Add(GridColumn23)
        Me.SuperGridControl.PrimaryGrid.Columns.Add(GridColumn24)
        Me.SuperGridControl.PrimaryGrid.Columns.Add(GridColumn25)
        Me.SuperGridControl.PrimaryGrid.Columns.Add(GridColumn26)
        Me.SuperGridControl.PrimaryGrid.DataSource = Me.Lst_troncons_sameBindingSource
        Me.SuperGridControl.Size = New System.Drawing.Size(256, 268)
        Me.SuperGridControl.TabIndex = 0
        '
        'Lst_troncons_sameBindingSource
        '
        Me.Lst_troncons_sameBindingSource.DataMember = "lst_troncons_same"
        Me.Lst_troncons_sameBindingSource.DataSource = Me.MydbDataSet
        '
        'MydbDataSet
        '
        Me.MydbDataSet.DataSetName = "mydbDataSet"
        Me.MydbDataSet.EnforceConstraints = false
        Me.MydbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GroupBoxDallesInterne
        '
        Me.GroupBoxDallesInterne.Controls.Add(Me.SuperGridControl1)
        Me.GroupBoxDallesInterne.Location = New System.Drawing.Point(17, 131)
        Me.GroupBoxDallesInterne.Name = "GroupBoxDallesInterne"
        Me.GroupBoxDallesInterne.Size = New System.Drawing.Size(313, 287)
        Me.GroupBoxDallesInterne.TabIndex = 16
        Me.GroupBoxDallesInterne.TabStop = false
        Me.GroupBoxDallesInterne.Text = "Tronçons  Interne"
        '
        'SuperGridControl1
        '
        Me.SuperGridControl1.BackColor = System.Drawing.Color.White
        Me.SuperGridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperGridControl1.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed
        Me.SuperGridControl1.ForeColor = System.Drawing.Color.Black
        Me.SuperGridControl1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.SuperGridControl1.Location = New System.Drawing.Point(3, 16)
        Me.SuperGridControl1.Name = "SuperGridControl1"
        Me.SuperGridControl1.Size = New System.Drawing.Size(307, 268)
        Me.SuperGridControl1.TabIndex = 0
        '
        'lblSalle
        '
        Me.lblSalle.Location = New System.Drawing.Point(59, 85)
        Me.lblSalle.Name = "lblSalle"
        Me.lblSalle.Size = New System.Drawing.Size(45, 16)
        Me.lblSalle.TabIndex = 9
        Me.lblSalle.Text = "Salle :"
        '
        'GroupBoxDallesAProxymitees
        '
        Me.GroupBoxDallesAProxymitees.Controls.Add(Me.SuperGridControl3)
        Me.GroupBoxDallesAProxymitees.Location = New System.Drawing.Point(354, 460)
        Me.GroupBoxDallesAProxymitees.Name = "GroupBoxDallesAProxymitees"
        Me.GroupBoxDallesAProxymitees.Size = New System.Drawing.Size(265, 223)
        Me.GroupBoxDallesAProxymitees.TabIndex = 20
        Me.GroupBoxDallesAProxymitees.TabStop = false
        Me.GroupBoxDallesAProxymitees.Text = "Salle aboutissante"
        '
        'SuperGridControl3
        '
        Me.SuperGridControl3.BackColor = System.Drawing.Color.White
        Me.SuperGridControl3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperGridControl3.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed
        Me.SuperGridControl3.ForeColor = System.Drawing.Color.Black
        Me.SuperGridControl3.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.SuperGridControl3.Location = New System.Drawing.Point(3, 16)
        Me.SuperGridControl3.Name = "SuperGridControl3"
        Me.SuperGridControl3.Size = New System.Drawing.Size(259, 204)
        Me.SuperGridControl3.TabIndex = 0
        '
        'lblTronconSelectionne
        '
        Me.lblTronconSelectionne.Font = New System.Drawing.Font("Arial Black", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblTronconSelectionne.Location = New System.Drawing.Point(28, 700)
        Me.lblTronconSelectionne.Name = "lblTronconSelectionne"
        Me.lblTronconSelectionne.Size = New System.Drawing.Size(154, 32)
        Me.lblTronconSelectionne.TabIndex = 0
        Me.lblTronconSelectionne.Text = "Le tronçon :"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial Black", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(175, 700)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(250, 32)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "?"
        '
        'SuperGridControl2
        '
        Me.SuperGridControl2.BackColor = System.Drawing.Color.White
        Me.SuperGridControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperGridControl2.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed
        Me.SuperGridControl2.ForeColor = System.Drawing.Color.Black
        Me.SuperGridControl2.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.SuperGridControl2.Location = New System.Drawing.Point(3, 16)
        Me.SuperGridControl2.Name = "SuperGridControl2"
        Me.SuperGridControl2.Size = New System.Drawing.Size(300, 204)
        Me.SuperGridControl2.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.SuperGridControl2)
        Me.GroupBox1.Location = New System.Drawing.Point(21, 460)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(306, 223)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = false
        Me.GroupBox1.Text = "Dans la meme salle"
        '
        'ButtonXAssocier
        '
        Me.ButtonXAssocier.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonXAssocier.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonXAssocier.Font = New System.Drawing.Font("Microsoft Sans Serif", 16!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.ButtonXAssocier.Location = New System.Drawing.Point(33, 785)
        Me.ButtonXAssocier.Name = "ButtonXAssocier"
        Me.ButtonXAssocier.Size = New System.Drawing.Size(168, 41)
        Me.ButtonXAssocier.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonXAssocier.TabIndex = 14
        Me.ButtonXAssocier.Text = "Associer"
        '
        'ButtonXFermer
        '
        Me.ButtonXFermer.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonXFermer.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonXFermer.Location = New System.Drawing.Point(1274, 56)
        Me.ButtonXFermer.Name = "ButtonXFermer"
        Me.ButtonXFermer.Size = New System.Drawing.Size(204, 23)
        Me.ButtonXFermer.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonXFermer.TabIndex = 15
        Me.ButtonXFermer.Text = "Fermer"
        '
        'Repere_salleComboBox
        '
        Me.Repere_salleComboBox.DataSource = Me.SallesBindingSource
        Me.Repere_salleComboBox.DisplayMember = "repere salle"
        Me.Repere_salleComboBox.FormattingEnabled = true
        Me.Repere_salleComboBox.Location = New System.Drawing.Point(24, 104)
        Me.Repere_salleComboBox.Name = "Repere_salleComboBox"
        Me.Repere_salleComboBox.Size = New System.Drawing.Size(121, 21)
        Me.Repere_salleComboBox.TabIndex = 11
        Me.Repere_salleComboBox.ValueMember = "idsalle"
        '
        'SallesBindingSource
        '
        Me.SallesBindingSource.DataMember = "salles"
        Me.SallesBindingSource.DataSource = Me.MydbDataSet
        '
        'IdsalleTextBox
        '
        Me.IdsalleTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.SallesBindingSource, "idsalle", true))
        Me.IdsalleTextBox.Enabled = false
        Me.IdsalleTextBox.Location = New System.Drawing.Point(17, 2)
        Me.IdsalleTextBox.Name = "IdsalleTextBox"
        Me.IdsalleTextBox.Size = New System.Drawing.Size(100, 20)
        Me.IdsalleTextBox.TabIndex = 4
        '
        'SegregationComboBox
        '
        Me.SegregationComboBox.DataSource = Me.SegregationsBindingSource
        Me.SegregationComboBox.DisplayMember = "segregation"
        Me.SegregationComboBox.FormattingEnabled = true
        Me.SegregationComboBox.Location = New System.Drawing.Point(165, 104)
        Me.SegregationComboBox.Name = "SegregationComboBox"
        Me.SegregationComboBox.Size = New System.Drawing.Size(121, 21)
        Me.SegregationComboBox.TabIndex = 12
        Me.SegregationComboBox.ValueMember = "idsegregations"
        '
        'SegregationsBindingSource
        '
        Me.SegregationsBindingSource.DataMember = "segregations"
        Me.SegregationsBindingSource.DataSource = Me.MydbDataSet
        '
        'IdsegregationsTextBox
        '
        Me.IdsegregationsTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.SegregationsBindingSource, "idsegregations", true))
        Me.IdsegregationsTextBox.Enabled = false
        Me.IdsegregationsTextBox.Location = New System.Drawing.Point(123, 2)
        Me.IdsegregationsTextBox.Name = "IdsegregationsTextBox"
        Me.IdsegregationsTextBox.Size = New System.Drawing.Size(100, 20)
        Me.IdsegregationsTextBox.TabIndex = 5
        '
        'Repere_salle1TextBox
        '
        Me.Repere_salle1TextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Lst_troncons_onBindingSource, "repere salle1", true))
        Me.Repere_salle1TextBox.Location = New System.Drawing.Point(473, 426)
        Me.Repere_salle1TextBox.Name = "Repere_salle1TextBox"
        Me.Repere_salle1TextBox.Size = New System.Drawing.Size(128, 20)
        Me.Repere_salle1TextBox.TabIndex = 18
        '
        'Lst_troncons_onBindingSource
        '
        Me.Lst_troncons_onBindingSource.DataMember = "lst_troncons_on"
        Me.Lst_troncons_onBindingSource.DataSource = Me.MydbDataSet
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Arial Black", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(352, 739)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(290, 32)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "?"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Arial Black", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label3.Location = New System.Drawing.Point(28, 739)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(328, 32)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Seras associé au tronçon  :"
        '
        'TextBox
        '
        Me.TextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Salles_2, "idsalle", true))
        Me.TextBox.Enabled = false
        Me.TextBox.Location = New System.Drawing.Point(336, 2)
        Me.TextBox.Name = "TextBox"
        Me.TextBox.Size = New System.Drawing.Size(102, 20)
        Me.TextBox.TabIndex = 7
        '
        'Salles_2
        '
        Me.Salles_2.DataMember = "salles"
        Me.Salles_2.DataSource = Me.MydbDataSet
        '
        'TextBox1
        '
        Me.TextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Lst_troncons_onBindingSource, "idtroncons", true))
        Me.TextBox1.Enabled = false
        Me.TextBox1.Location = New System.Drawing.Point(225, 2)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(105, 20)
        Me.TextBox1.TabIndex = 6
        '
        'TextBox2
        '
        Me.TextBox2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Salles_2, "idsalle", true))
        Me.TextBox2.Enabled = false
        Me.TextBox2.Location = New System.Drawing.Point(444, 2)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(102, 20)
        Me.TextBox2.TabIndex = 8
        '
        'SallesTableAdapter
        '
        Me.SallesTableAdapter.ClearBeforeFill = true
        '
        'TronconsTableAdapter
        '
        Me.TronconsTableAdapter.ClearBeforeFill = true
        '
        'SegregationsTableAdapter
        '
        Me.SegregationsTableAdapter.ClearBeforeFill = true
        '
        'Troncons_assocTableAdapter
        '
        Me.Troncons_assocTableAdapter.ClearBeforeFill = true
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
        Me.TableAdapterManager.Connection = Nothing
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
        Me.TableAdapterManager.pieces_marchandiseTableAdapter = Nothing
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
        Me.TableAdapterManager.stockTableAdapter = Nothing
        Me.TableAdapterManager.tourets_has_fournituresTableAdapter = Nothing
        Me.TableAdapterManager.touretsTableAdapter = Nothing
        Me.TableAdapterManager.troncons_assocTableAdapter = Nothing
        Me.TableAdapterManager.troncons_fournituresTableAdapter = Nothing
        Me.TableAdapterManager.troncons_modifTableAdapter = Nothing
        Me.TableAdapterManager.tronconsTableAdapter = Nothing
        Me.TableAdapterManager.type_docTableAdapter = Nothing
        Me.TableAdapterManager.types_cableTableAdapter = Nothing
        Me.TableAdapterManager.types_tronconsTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = progelec.mydbDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'TronconsBindingSource
        '
        Me.TronconsBindingSource.DataMember = "troncons"
        Me.TronconsBindingSource.DataSource = Me.MydbDataSet
        '
        'Lst_troncons_segBindingSource
        '
        Me.Lst_troncons_segBindingSource.DataMember = "lst_troncons_seg"
        Me.Lst_troncons_segBindingSource.DataSource = Me.MydbDataSet
        '
        'Lst_troncons_seg2BindingSource
        '
        Me.Lst_troncons_seg2BindingSource.DataMember = "lst_troncons_seg2"
        Me.Lst_troncons_seg2BindingSource.DataSource = Me.MydbDataSet
        '
        'Troncons_assocBindingSource
        '
        Me.Troncons_assocBindingSource.DataMember = "troncons_assoc"
        Me.Troncons_assocBindingSource.DataSource = Me.MydbDataSet
        '
        'Lst_troncons_onTableAdapter
        '
        Me.Lst_troncons_onTableAdapter.ClearBeforeFill = true
        '
        'Lst_troncons_segTableAdapter
        '
        Me.Lst_troncons_segTableAdapter.ClearBeforeFill = true
        '
        'Lst_troncons_sameTableAdapter
        '
        Me.Lst_troncons_sameTableAdapter.ClearBeforeFill = true
        '
        'Lst_troncons_seg2TableAdapter
        '
        Me.Lst_troncons_seg2TableAdapter.ClearBeforeFill = true
        '
        'TextBoxX1
        '
        '
        '
        '
        Me.TextBoxX1.Border.Class = "TextBoxBorder"
        Me.TextBoxX1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxX1.Location = New System.Drawing.Point(773, 2)
        Me.TextBoxX1.Name = "TextBoxX1"
        Me.TextBoxX1.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxX1.TabIndex = 23
        '
        'TextBoxX2
        '
        '
        '
        '
        Me.TextBoxX2.Border.Class = "TextBoxBorder"
        Me.TextBoxX2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxX2.Location = New System.Drawing.Point(932, 3)
        Me.TextBoxX2.Name = "TextBoxX2"
        Me.TextBoxX2.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxX2.TabIndex = 24
        '
        'TextBoxX3
        '
        '
        '
        '
        Me.TextBoxX3.Border.Class = "TextBoxBorder"
        Me.TextBoxX3.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxX3.Location = New System.Drawing.Point(1029, 3)
        Me.TextBoxX3.Name = "TextBoxX3"
        Me.TextBoxX3.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxX3.TabIndex = 25
        '
        'NDrawingDocument1
        '
        Me.NDrawingDocument1.DesignTimeState = CType(resources.GetObject("NDrawingDocument1.DesignTimeState"),Nevron.Diagram.NBinaryState)
        '
        'NLibraryDocument1
        '
        Me.NLibraryDocument1.DesignTimeState = CType(resources.GetObject("NLibraryDocument1.DesignTimeState"),Nevron.Diagram.NBinaryState)
        '
        'NDrawingView1
        '
        Me.NDrawingView1.AllowDrop = true
        Me.NDrawingView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.NDrawingView1.DesignTimeState = CType(resources.GetObject("NDrawingView1.DesignTimeState"),Nevron.Diagram.NBinaryState)
        Me.NDrawingView1.Document = Me.NDrawingDocument1
        Me.NDrawingView1.Location = New System.Drawing.Point(648, 85)
        Me.NDrawingView1.Name = "NDrawingView1"
        Me.NDrawingView1.Size = New System.Drawing.Size(830, 671)
        Me.NDrawingView1.TabIndex = 26
        Me.NDrawingView1.Text = "NDrawingView1"
        '
        'Lst_assoc_seg_salleBindingSource
        '
        Me.Lst_assoc_seg_salleBindingSource.DataSource = Me.MydbDataSet
        Me.Lst_assoc_seg_salleBindingSource.Position = 0
        '
        'Lst_assoc_seg_salleTableAdapter
        '
        Me.Lst_assoc_seg_salleTableAdapter.ClearBeforeFill = true
        '
        'Lst_trc_salle_segBindingSource
        '
        Me.Lst_trc_salle_segBindingSource.DataSource = Me.MydbDataSet
        Me.Lst_trc_salle_segBindingSource.Position = 0
        '
        'Lst_trc_salle_segTableAdapter
        '
        Me.Lst_trc_salle_segTableAdapter.ClearBeforeFill = true
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.BackColor = System.Drawing.Color.Red
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.ButtonX1.Location = New System.Drawing.Point(674, 56)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Size = New System.Drawing.Size(262, 23)
        Me.ButtonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX1.TabIndex = 28
        Me.ButtonX1.Text = "Generation AUTOCAD"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(512, 700)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(130, 20)
        Me.TextBox3.TabIndex = 29
        '
        'FormAssocTroncons
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = true
        Me.ClientSize = New System.Drawing.Size(1508, 864)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.ButtonX1)
        Me.Controls.Add(Me.NDrawingView1)
        Me.Controls.Add(Me.TextBoxX3)
        Me.Controls.Add(Me.TextBoxX2)
        Me.Controls.Add(Me.TextBoxX1)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.TextBox)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Repere_salle1Label)
        Me.Controls.Add(Me.Repere_salle1TextBox)
        Me.Controls.Add(Me.IdsegregationsTextBox)
        Me.Controls.Add(SegregationLabel)
        Me.Controls.Add(Me.SegregationComboBox)
        Me.Controls.Add(Me.IdsalleTextBox)
        Me.Controls.Add(Me.Repere_salleComboBox)
        Me.Controls.Add(Me.ButtonXFermer)
        Me.Controls.Add(Me.ButtonXAssocier)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBoxAssociations)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblTronconSelectionne)
        Me.Controls.Add(Me.GroupBoxDallesAProxymitees)
        Me.Controls.Add(Me.lblSalle)
        Me.Controls.Add(Me.GroupBoxDallesInterne)
        Me.Name = "FormAssocTroncons"
        Me.Text = "Association Tronçons"
        Me.GroupBoxAssociations.ResumeLayout(false)
        CType(Me.Lst_troncons_sameBindingSource,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.MydbDataSet,System.ComponentModel.ISupportInitialize).EndInit
        Me.GroupBoxDallesInterne.ResumeLayout(false)
        Me.GroupBoxDallesAProxymitees.ResumeLayout(false)
        Me.GroupBox1.ResumeLayout(false)
        CType(Me.SallesBindingSource,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.SegregationsBindingSource,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.Lst_troncons_onBindingSource,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.Salles_2,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TronconsBindingSource,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.Lst_troncons_segBindingSource,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.Lst_troncons_seg2BindingSource,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.Troncons_assocBindingSource,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.Lst_assoc_seg_salleBindingSource,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.Lst_trc_salle_segBindingSource,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Private WithEvents GroupBoxAssociations As System.Windows.Forms.GroupBox
    Private WithEvents SuperGridControl As DevComponents.DotNetBar.SuperGrid.SuperGridControl
    Private WithEvents GroupBoxDallesInterne As System.Windows.Forms.GroupBox
    Private WithEvents SuperGridControl1 As DevComponents.DotNetBar.SuperGrid.SuperGridControl
    Private WithEvents lblSalle As System.Windows.Forms.Label
    Private WithEvents GroupBoxDallesAProxymitees As System.Windows.Forms.GroupBox
    Private WithEvents SuperGridControl3 As DevComponents.DotNetBar.SuperGrid.SuperGridControl
    Private WithEvents lblTronconSelectionne As System.Windows.Forms.Label
    Private WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents SuperGridControl2 As DevComponents.DotNetBar.SuperGrid.SuperGridControl
    Private WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents ButtonXAssocier As DevComponents.DotNetBar.ButtonX
    Private WithEvents ButtonXFermer As DevComponents.DotNetBar.ButtonX
    Friend WithEvents MydbDataSet As progelec.mydbDataSet
    Friend WithEvents SallesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SallesTableAdapter As progelec.mydbDataSetTableAdapters.sallesTableAdapter
    Friend WithEvents TableAdapterManager As progelec.mydbDataSetTableAdapters.TableAdapterManager
    Friend WithEvents Repere_salleComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents IdsalleTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TronconsTableAdapter As progelec.mydbDataSetTableAdapters.tronconsTableAdapter
    Friend WithEvents TronconsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Lst_troncons_onBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Lst_troncons_onTableAdapter As progelec.mydbDataSetTableAdapters.lst_troncons_onTableAdapter
    Friend WithEvents SegregationsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SegregationsTableAdapter As progelec.mydbDataSetTableAdapters.segregationsTableAdapter
    Friend WithEvents SegregationComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents IdsegregationsTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Repere_salle1TextBox As System.Windows.Forms.TextBox
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Lst_troncons_segBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Lst_troncons_segTableAdapter As progelec.mydbDataSetTableAdapters.lst_troncons_segTableAdapter
    Friend WithEvents Lst_troncons_sameBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Lst_troncons_sameTableAdapter As progelec.mydbDataSetTableAdapters.lst_troncons_sameTableAdapter
    Friend WithEvents Salles_2 As System.Windows.Forms.BindingSource
    Private WithEvents TextBox As System.Windows.Forms.TextBox
    Private WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Lst_troncons_seg2BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Lst_troncons_seg2TableAdapter As progelec.mydbDataSetTableAdapters.lst_troncons_seg2TableAdapter
    Private WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Troncons_assocBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Troncons_assocTableAdapter As progelec.mydbDataSetTableAdapters.troncons_assocTableAdapter
    Friend WithEvents TextBoxX1 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TextBoxX2 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TextBoxX3 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents NDrawingDocument1 As Nevron.Diagram.NDrawingDocument
    Friend WithEvents NLibraryDocument1 As Nevron.Diagram.NLibraryDocument
    Friend WithEvents NDrawingView1 As Nevron.Diagram.WinForm.NDrawingView
    Friend WithEvents Lst_assoc_seg_salleBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Lst_assoc_seg_salleTableAdapter As progelec.mydbDataSetTableAdapters.lst_assoc_seg_salleTableAdapter
    Friend WithEvents Lst_trc_salle_segBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Lst_trc_salle_segTableAdapter As progelec.mydbDataSetTableAdapters.Lst_trc_salle_segTableAdapter
    Private WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
End Class
