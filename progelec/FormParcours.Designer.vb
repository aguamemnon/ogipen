<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormParcours
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
        Dim IdparcoursLabel As System.Windows.Forms.Label
        Dim DateLabel As System.Windows.Forms.Label
        Dim QuiLabel As System.Windows.Forms.Label
        Dim RevisionLabel As System.Windows.Forms.Label
        Dim IdsegregationsLabel As System.Windows.Forms.Label
        Dim IdsalleLabel As System.Windows.Forms.Label
        Dim IdsalleLabel1 As System.Windows.Forms.Label
        Dim IdtronconsLabel As System.Windows.Forms.Label
        Dim IdtronconsLabel1 As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormParcours))
        Dim LongueurLabel As System.Windows.Forms.Label
        Me.ButtonXCreer = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonXModifier = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonXSupprimer = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonXFermer = New DevComponents.DotNetBar.ButtonX()
        Me.IdparcoursTextBox = New System.Windows.Forms.TextBox()
        Me.ParcoursBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MydbDataSet = New progelec.mydbDataSet()
        Me.SuperTabControl1 = New DevComponents.DotNetBar.SuperTabControl()
        Me.SuperTabControlPanel1 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.Parcours_detailDataGridView = New System.Windows.Forms.DataGridView()
        Me.RepereSalleDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NiveauDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RepereTronconDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TypeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SegregationDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Parcour_detail_idBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SuperTabItem1 = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel2 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.Cable_details_tronconDataGridView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cable_details_tronconBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SuperTabItem2 = New DevComponents.DotNetBar.SuperTabItem()
        Me.Parcours_detailBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CablesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DateDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.QuiTextBox = New System.Windows.Forms.TextBox()
        Me.RevisionTextBox = New System.Windows.Forms.TextBox()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.ComboBox3 = New System.Windows.Forms.ComboBox()
        Me.Lst_troncons_on2BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ComboBox5 = New System.Windows.Forms.ComboBox()
        Me.SallesBindingSource2 = New System.Windows.Forms.BindingSource(Me.components)
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.Lst_troncons_onBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ComboBox = New System.Windows.Forms.ComboBox()
        Me.SallesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.SegregationsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.IdsegregationsTextBox = New System.Windows.Forms.TextBox()
        Me.IdsalleTextBox = New System.Windows.Forms.TextBox()
        Me.IdsalleTextBox1 = New System.Windows.Forms.TextBox()
        Me.ParcoursTableAdapter = New progelec.mydbDataSetTableAdapters.parcoursTableAdapter()
        Me.TableAdapterManager = New progelec.mydbDataSetTableAdapters.TableAdapterManager()
        Me.Parcours_detailTableAdapter = New progelec.mydbDataSetTableAdapters.parcours_detailTableAdapter()
        Me.SegregationsTableAdapter = New progelec.mydbDataSetTableAdapters.segregationsTableAdapter()
        Me.CablesTableAdapter = New progelec.mydbDataSetTableAdapters.cablesTableAdapter()
        Me.SallesTableAdapter = New progelec.mydbDataSetTableAdapters.sallesTableAdapter()
        Me.SallesTableAdapter2 = New progelec.mydbDataSetTableAdapters.sallesTableAdapter()
        Me.EquipementsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EquipementsTableAdapter = New progelec.mydbDataSetTableAdapters.equipementsTableAdapter()
        Me.EquipementsBindingSource2 = New System.Windows.Forms.BindingSource(Me.components)
        Me.EquipementsTableAdapter2 = New progelec.mydbDataSetTableAdapters.equipementsTableAdapter()
        Me.Lst_troncons_onTableAdapter = New progelec.mydbDataSetTableAdapters.lst_troncons_onTableAdapter()
        Me.Lst_troncons_on2TableAdapter = New progelec.mydbDataSetTableAdapters.lst_troncons_on2TableAdapter()
        Me.Lst_troncons_par_segBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Lst_troncons_par_segTableAdapter = New progelec.mydbDataSetTableAdapters.lst_troncons_par_segTableAdapter()
        Me.IdtronconsTextBox = New System.Windows.Forms.TextBox()
        Me.IdtronconsTextBox1 = New System.Windows.Forms.TextBox()
        Me.Lst_trc_assocBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Lst_trc_assocTableAdapter = New progelec.mydbDataSetTableAdapters.lst_trc_assocTableAdapter()
        Me.Lst_assoc_par_trcBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Lst_assoc_par_trcTableAdapter = New progelec.mydbDataSetTableAdapters.lst_assoc_par_trcTableAdapter()
        Me.Lst_assoc_par_trc2BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Lst_assoc_par_trc2TableAdapter = New progelec.mydbDataSetTableAdapters.lst_assoc_par_trc2TableAdapter()
        Me.Cable_details_tronconTableAdapter = New progelec.mydbDataSetTableAdapters.cable_details_tronconTableAdapter()
        Me.BindingNavigator1 = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.Parcour_detail_idTableAdapter = New progelec.mydbDataSetTableAdapters.parcour_detail_idTableAdapter()
        Me.LongueurTextBox = New System.Windows.Forms.TextBox()
        IdparcoursLabel = New System.Windows.Forms.Label()
        DateLabel = New System.Windows.Forms.Label()
        QuiLabel = New System.Windows.Forms.Label()
        RevisionLabel = New System.Windows.Forms.Label()
        IdsegregationsLabel = New System.Windows.Forms.Label()
        IdsalleLabel = New System.Windows.Forms.Label()
        IdsalleLabel1 = New System.Windows.Forms.Label()
        IdtronconsLabel = New System.Windows.Forms.Label()
        IdtronconsLabel1 = New System.Windows.Forms.Label()
        LongueurLabel = New System.Windows.Forms.Label()
        CType(Me.ParcoursBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MydbDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SuperTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControl1.SuspendLayout()
        Me.SuperTabControlPanel1.SuspendLayout()
        CType(Me.Parcours_detailDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Parcour_detail_idBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControlPanel2.SuspendLayout()
        CType(Me.Cable_details_tronconDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cable_details_tronconBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Parcours_detailBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CablesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.Lst_troncons_on2BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SallesBindingSource2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel2.SuspendLayout()
        CType(Me.Lst_troncons_onBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SallesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SegregationsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EquipementsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EquipementsBindingSource2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Lst_troncons_par_segBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Lst_trc_assocBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Lst_assoc_par_trcBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Lst_assoc_par_trc2BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BindingNavigator1.SuspendLayout()
        Me.SuspendLayout()
        '
        'IdparcoursLabel
        '
        IdparcoursLabel.AutoSize = True
        IdparcoursLabel.Location = New System.Drawing.Point(34, 44)
        IdparcoursLabel.Name = "IdparcoursLabel"
        IdparcoursLabel.Size = New System.Drawing.Size(59, 13)
        IdparcoursLabel.TabIndex = 2
        IdparcoursLabel.Text = "idparcours:"
        '
        'DateLabel
        '
        DateLabel.AutoSize = True
        DateLabel.Location = New System.Drawing.Point(292, 44)
        DateLabel.Name = "DateLabel"
        DateLabel.Size = New System.Drawing.Size(113, 13)
        DateLabel.TabIndex = 4
        DateLabel.Text = "derniere modification ::"
        '
        'QuiLabel
        '
        QuiLabel.AutoSize = True
        QuiLabel.Location = New System.Drawing.Point(470, 63)
        QuiLabel.Name = "QuiLabel"
        QuiLabel.Size = New System.Drawing.Size(28, 13)
        QuiLabel.TabIndex = 8
        QuiLabel.Text = "par :"
        '
        'RevisionLabel
        '
        RevisionLabel.AutoSize = True
        RevisionLabel.Location = New System.Drawing.Point(136, 44)
        RevisionLabel.Name = "RevisionLabel"
        RevisionLabel.Size = New System.Drawing.Size(46, 13)
        RevisionLabel.TabIndex = 3
        RevisionLabel.Text = "revision:"
        '
        'IdsegregationsLabel
        '
        IdsegregationsLabel.AutoSize = True
        IdsegregationsLabel.Location = New System.Drawing.Point(55, 7)
        IdsegregationsLabel.Name = "IdsegregationsLabel"
        IdsegregationsLabel.Size = New System.Drawing.Size(78, 13)
        IdsegregationsLabel.TabIndex = 0
        IdsegregationsLabel.Text = "idsegregations:"
        '
        'IdsalleLabel
        '
        IdsalleLabel.AutoSize = True
        IdsalleLabel.Location = New System.Drawing.Point(350, 170)
        IdsalleLabel.Name = "IdsalleLabel"
        IdsalleLabel.Size = New System.Drawing.Size(39, 13)
        IdsalleLabel.TabIndex = 12
        IdsalleLabel.Text = "idsalle:"
        '
        'IdsalleLabel1
        '
        IdsalleLabel1.AutoSize = True
        IdsalleLabel1.Location = New System.Drawing.Point(593, 170)
        IdsalleLabel1.Name = "IdsalleLabel1"
        IdsalleLabel1.Size = New System.Drawing.Size(39, 13)
        IdsalleLabel1.TabIndex = 14
        IdsalleLabel1.Text = "idsalle:"
        '
        'IdtronconsLabel
        '
        IdtronconsLabel.AutoSize = True
        IdtronconsLabel.Location = New System.Drawing.Point(417, 227)
        IdtronconsLabel.Name = "IdtronconsLabel"
        IdtronconsLabel.Size = New System.Drawing.Size(59, 13)
        IdtronconsLabel.TabIndex = 22
        IdtronconsLabel.Text = "idtroncons:"
        '
        'IdtronconsLabel1
        '
        IdtronconsLabel1.AutoSize = True
        IdtronconsLabel1.Location = New System.Drawing.Point(658, 227)
        IdtronconsLabel1.Name = "IdtronconsLabel1"
        IdtronconsLabel1.Size = New System.Drawing.Size(59, 13)
        IdtronconsLabel1.TabIndex = 24
        IdtronconsLabel1.Text = "idtroncons:"
        '
        'ButtonXCreer
        '
        Me.ButtonXCreer.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonXCreer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonXCreer.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonXCreer.Location = New System.Drawing.Point(1159, 477)
        Me.ButtonXCreer.Name = "ButtonXCreer"
        Me.ButtonXCreer.Size = New System.Drawing.Size(238, 23)
        Me.ButtonXCreer.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonXCreer.TabIndex = 18
        Me.ButtonXCreer.Text = "Creer"
        '
        'ButtonXModifier
        '
        Me.ButtonXModifier.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonXModifier.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonXModifier.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonXModifier.Location = New System.Drawing.Point(1159, 505)
        Me.ButtonXModifier.Name = "ButtonXModifier"
        Me.ButtonXModifier.Size = New System.Drawing.Size(238, 23)
        Me.ButtonXModifier.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonXModifier.TabIndex = 19
        Me.ButtonXModifier.Text = "Modifier"
        '
        'ButtonXSupprimer
        '
        Me.ButtonXSupprimer.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonXSupprimer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonXSupprimer.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonXSupprimer.Location = New System.Drawing.Point(1159, 534)
        Me.ButtonXSupprimer.Name = "ButtonXSupprimer"
        Me.ButtonXSupprimer.Size = New System.Drawing.Size(239, 23)
        Me.ButtonXSupprimer.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonXSupprimer.TabIndex = 20
        Me.ButtonXSupprimer.Text = "Supprimer"
        '
        'ButtonXFermer
        '
        Me.ButtonXFermer.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonXFermer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonXFermer.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonXFermer.Location = New System.Drawing.Point(1159, 562)
        Me.ButtonXFermer.Name = "ButtonXFermer"
        Me.ButtonXFermer.Size = New System.Drawing.Size(239, 23)
        Me.ButtonXFermer.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonXFermer.TabIndex = 21
        Me.ButtonXFermer.Text = "Fermer"
        '
        'IdparcoursTextBox
        '
        Me.IdparcoursTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ParcoursBindingSource, "idparcours", True))
        Me.IdparcoursTextBox.Location = New System.Drawing.Point(17, 60)
        Me.IdparcoursTextBox.Name = "IdparcoursTextBox"
        Me.IdparcoursTextBox.Size = New System.Drawing.Size(100, 20)
        Me.IdparcoursTextBox.TabIndex = 5
        '
        'ParcoursBindingSource
        '
        Me.ParcoursBindingSource.DataMember = "parcours"
        Me.ParcoursBindingSource.DataSource = Me.MydbDataSet
        '
        'MydbDataSet
        '
        Me.MydbDataSet.DataSetName = "mydbDataSet"
        Me.MydbDataSet.EnforceConstraints = False
        Me.MydbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'SuperTabControl1
        '
        Me.SuperTabControl1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.SuperTabControl1.BackColor = System.Drawing.Color.White
        '
        '
        '
        '
        '
        '
        Me.SuperTabControl1.ControlBox.CloseBox.Name = ""
        '
        '
        '
        Me.SuperTabControl1.ControlBox.MenuBox.Name = ""
        Me.SuperTabControl1.ControlBox.Name = ""
        Me.SuperTabControl1.ControlBox.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabControl1.ControlBox.MenuBox, Me.SuperTabControl1.ControlBox.CloseBox})
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel1)
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel2)
        Me.SuperTabControl1.ForeColor = System.Drawing.Color.Black
        Me.SuperTabControl1.Location = New System.Drawing.Point(370, 291)
        Me.SuperTabControl1.Name = "SuperTabControl1"
        Me.SuperTabControl1.ReorderTabsEnabled = True
        Me.SuperTabControl1.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.SuperTabControl1.SelectedTabIndex = 0
        Me.SuperTabControl1.Size = New System.Drawing.Size(622, 295)
        Me.SuperTabControl1.TabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SuperTabControl1.TabIndex = 17
        Me.SuperTabControl1.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabItem1, Me.SuperTabItem2})
        Me.SuperTabControl1.Text = "SuperTabControl1"
        '
        'SuperTabControlPanel1
        '
        Me.SuperTabControlPanel1.Controls.Add(Me.Parcours_detailDataGridView)
        Me.SuperTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel1.Location = New System.Drawing.Point(0, 25)
        Me.SuperTabControlPanel1.Name = "SuperTabControlPanel1"
        Me.SuperTabControlPanel1.Size = New System.Drawing.Size(622, 270)
        Me.SuperTabControlPanel1.TabIndex = 1
        Me.SuperTabControlPanel1.TabItem = Me.SuperTabItem1
        '
        'Parcours_detailDataGridView
        '
        Me.Parcours_detailDataGridView.AutoGenerateColumns = False
        Me.Parcours_detailDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Parcours_detailDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RepereSalleDataGridViewTextBoxColumn, Me.NiveauDataGridViewTextBoxColumn, Me.RepereTronconDataGridViewTextBoxColumn, Me.TypeDataGridViewTextBoxColumn, Me.SegregationDataGridViewTextBoxColumn})
        Me.Parcours_detailDataGridView.DataSource = Me.Parcour_detail_idBindingSource
        Me.Parcours_detailDataGridView.Location = New System.Drawing.Point(28, 18)
        Me.Parcours_detailDataGridView.Name = "Parcours_detailDataGridView"
        Me.Parcours_detailDataGridView.Size = New System.Drawing.Size(563, 240)
        Me.Parcours_detailDataGridView.TabIndex = 0
        '
        'RepereSalleDataGridViewTextBoxColumn
        '
        Me.RepereSalleDataGridViewTextBoxColumn.DataPropertyName = "repere salle"
        Me.RepereSalleDataGridViewTextBoxColumn.HeaderText = "repere salle"
        Me.RepereSalleDataGridViewTextBoxColumn.Name = "RepereSalleDataGridViewTextBoxColumn"
        '
        'NiveauDataGridViewTextBoxColumn
        '
        Me.NiveauDataGridViewTextBoxColumn.DataPropertyName = "Niveau"
        Me.NiveauDataGridViewTextBoxColumn.HeaderText = "Niveau"
        Me.NiveauDataGridViewTextBoxColumn.Name = "NiveauDataGridViewTextBoxColumn"
        '
        'RepereTronconDataGridViewTextBoxColumn
        '
        Me.RepereTronconDataGridViewTextBoxColumn.DataPropertyName = "repere troncon"
        Me.RepereTronconDataGridViewTextBoxColumn.HeaderText = "repere troncon"
        Me.RepereTronconDataGridViewTextBoxColumn.Name = "RepereTronconDataGridViewTextBoxColumn"
        '
        'TypeDataGridViewTextBoxColumn
        '
        Me.TypeDataGridViewTextBoxColumn.DataPropertyName = "Type"
        Me.TypeDataGridViewTextBoxColumn.HeaderText = "Type"
        Me.TypeDataGridViewTextBoxColumn.Name = "TypeDataGridViewTextBoxColumn"
        '
        'SegregationDataGridViewTextBoxColumn
        '
        Me.SegregationDataGridViewTextBoxColumn.DataPropertyName = "segregation"
        Me.SegregationDataGridViewTextBoxColumn.HeaderText = "segregation"
        Me.SegregationDataGridViewTextBoxColumn.Name = "SegregationDataGridViewTextBoxColumn"
        '
        'Parcour_detail_idBindingSource
        '
        Me.Parcour_detail_idBindingSource.DataMember = "parcour_detail_id"
        Me.Parcour_detail_idBindingSource.DataSource = Me.MydbDataSet
        '
        'SuperTabItem1
        '
        Me.SuperTabItem1.AttachedControl = Me.SuperTabControlPanel1
        Me.SuperTabItem1.GlobalItem = False
        Me.SuperTabItem1.Name = "SuperTabItem1"
        Me.SuperTabItem1.Text = "Detail parcour"
        '
        'SuperTabControlPanel2
        '
        Me.SuperTabControlPanel2.AutoScroll = True
        Me.SuperTabControlPanel2.Controls.Add(Me.Cable_details_tronconDataGridView)
        Me.SuperTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel2.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel2.Name = "SuperTabControlPanel2"
        Me.SuperTabControlPanel2.Size = New System.Drawing.Size(622, 295)
        Me.SuperTabControlPanel2.TabIndex = 0
        Me.SuperTabControlPanel2.TabItem = Me.SuperTabItem2
        '
        'Cable_details_tronconDataGridView
        '
        Me.Cable_details_tronconDataGridView.AutoGenerateColumns = False
        Me.Cable_details_tronconDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Cable_details_tronconDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7})
        Me.Cable_details_tronconDataGridView.DataSource = Me.Cable_details_tronconBindingSource
        Me.Cable_details_tronconDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Cable_details_tronconDataGridView.Location = New System.Drawing.Point(0, 0)
        Me.Cable_details_tronconDataGridView.Name = "Cable_details_tronconDataGridView"
        Me.Cable_details_tronconDataGridView.Size = New System.Drawing.Size(622, 295)
        Me.Cable_details_tronconDataGridView.TabIndex = 0
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "repere cable"
        Me.DataGridViewTextBoxColumn1.HeaderText = "repere cable"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Fils"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Fils"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "section"
        Me.DataGridViewTextBoxColumn3.HeaderText = "section"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "types"
        Me.DataGridViewTextBoxColumn4.HeaderText = "types"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "diametre"
        Me.DataGridViewTextBoxColumn5.HeaderText = "diametre"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "charge_calorifique"
        Me.DataGridViewTextBoxColumn6.HeaderText = "charge_calorifique"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "masse"
        Me.DataGridViewTextBoxColumn7.HeaderText = "masse"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        '
        'Cable_details_tronconBindingSource
        '
        Me.Cable_details_tronconBindingSource.DataMember = "cable_details_troncon"
        Me.Cable_details_tronconBindingSource.DataSource = Me.MydbDataSet
        '
        'SuperTabItem2
        '
        Me.SuperTabItem2.AttachedControl = Me.SuperTabControlPanel2
        Me.SuperTabItem2.GlobalItem = False
        Me.SuperTabItem2.Name = "SuperTabItem2"
        Me.SuperTabItem2.Text = "Cables dans le parcour"
        '
        'Parcours_detailBindingSource
        '
        Me.Parcours_detailBindingSource.DataMember = "parcours_detail"
        Me.Parcours_detailBindingSource.DataSource = Me.MydbDataSet
        '
        'CablesBindingSource
        '
        Me.CablesBindingSource.DataMember = "cables"
        Me.CablesBindingSource.DataSource = Me.MydbDataSet
        '
        'DateDateTimePicker
        '
        Me.DateDateTimePicker.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.ParcoursBindingSource, "date", True))
        Me.DateDateTimePicker.Location = New System.Drawing.Point(253, 60)
        Me.DateDateTimePicker.Name = "DateDateTimePicker"
        Me.DateDateTimePicker.Size = New System.Drawing.Size(200, 20)
        Me.DateDateTimePicker.TabIndex = 7
        '
        'QuiTextBox
        '
        Me.QuiTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ParcoursBindingSource, "qui", True))
        Me.QuiTextBox.Location = New System.Drawing.Point(500, 60)
        Me.QuiTextBox.Name = "QuiTextBox"
        Me.QuiTextBox.Size = New System.Drawing.Size(100, 20)
        Me.QuiTextBox.TabIndex = 9
        '
        'RevisionTextBox
        '
        Me.RevisionTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ParcoursBindingSource, "revision", True))
        Me.RevisionTextBox.Location = New System.Drawing.Point(123, 60)
        Me.RevisionTextBox.Name = "RevisionTextBox"
        Me.RevisionTextBox.Size = New System.Drawing.Size(100, 20)
        Me.RevisionTextBox.TabIndex = 6
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.ComboBox3)
        Me.GroupPanel1.Controls.Add(Me.ComboBox5)
        Me.GroupPanel1.Location = New System.Drawing.Point(764, 85)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(317, 200)
        '
        '
        '
        Me.GroupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel1.Style.BackColorGradientAngle = 90
        Me.GroupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderBottomWidth = 1
        Me.GroupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderLeftWidth = 1
        Me.GroupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderRightWidth = 1
        Me.GroupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderTopWidth = 1
        Me.GroupPanel1.Style.CornerDiameter = 4
        Me.GroupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel1.TabIndex = 16
        Me.GroupPanel1.Text = "arrivée :"
        '
        'ComboBox3
        '
        Me.ComboBox3.DataSource = Me.Lst_troncons_on2BindingSource
        Me.ComboBox3.DisplayMember = "repere troncon"
        Me.ComboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox3.FormattingEnabled = True
        Me.ComboBox3.Location = New System.Drawing.Point(5, 138)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(301, 21)
        Me.ComboBox3.TabIndex = 1
        '
        'Lst_troncons_on2BindingSource
        '
        Me.Lst_troncons_on2BindingSource.DataMember = "lst_troncons_on2"
        Me.Lst_troncons_on2BindingSource.DataSource = Me.MydbDataSet
        '
        'ComboBox5
        '
        Me.ComboBox5.DataSource = Me.SallesBindingSource2
        Me.ComboBox5.DisplayMember = "repere salle"
        Me.ComboBox5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox5.FormattingEnabled = True
        Me.ComboBox5.Location = New System.Drawing.Point(5, 20)
        Me.ComboBox5.Name = "ComboBox5"
        Me.ComboBox5.Size = New System.Drawing.Size(301, 21)
        Me.ComboBox5.TabIndex = 0
        '
        'SallesBindingSource2
        '
        Me.SallesBindingSource2.DataMember = "salles"
        Me.SallesBindingSource2.DataSource = Me.MydbDataSet
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.ComboBox2)
        Me.GroupPanel2.Controls.Add(Me.ComboBox)
        Me.GroupPanel2.Location = New System.Drawing.Point(17, 85)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(317, 200)
        '
        '
        '
        Me.GroupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel2.Style.BackColorGradientAngle = 90
        Me.GroupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderBottomWidth = 1
        Me.GroupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderLeftWidth = 1
        Me.GroupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderRightWidth = 1
        Me.GroupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderTopWidth = 1
        Me.GroupPanel2.Style.CornerDiameter = 4
        Me.GroupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel2.TabIndex = 10
        Me.GroupPanel2.Text = "Depart :"
        '
        'ComboBox2
        '
        Me.ComboBox2.DataSource = Me.Lst_troncons_onBindingSource
        Me.ComboBox2.DisplayMember = "repere troncon"
        Me.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(3, 139)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(301, 21)
        Me.ComboBox2.TabIndex = 1
        '
        'Lst_troncons_onBindingSource
        '
        Me.Lst_troncons_onBindingSource.DataMember = "lst_troncons_on"
        Me.Lst_troncons_onBindingSource.DataSource = Me.MydbDataSet
        '
        'ComboBox
        '
        Me.ComboBox.DataSource = Me.SallesBindingSource
        Me.ComboBox.DisplayMember = "repere salle"
        Me.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox.FormattingEnabled = True
        Me.ComboBox.Location = New System.Drawing.Point(3, 21)
        Me.ComboBox.Name = "ComboBox"
        Me.ComboBox.Size = New System.Drawing.Size(301, 21)
        Me.ComboBox.TabIndex = 0
        '
        'SallesBindingSource
        '
        Me.SallesBindingSource.DataMember = "salles"
        Me.SallesBindingSource.DataSource = Me.MydbDataSet
        '
        'ComboBox1
        '
        Me.ComboBox1.DataSource = Me.SegregationsBindingSource
        Me.ComboBox1.DisplayMember = "segregation"
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(395, 124)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(301, 21)
        Me.ComboBox1.TabIndex = 11
        '
        'SegregationsBindingSource
        '
        Me.SegregationsBindingSource.DataMember = "segregations"
        Me.SegregationsBindingSource.DataSource = Me.MydbDataSet
        '
        'IdsegregationsTextBox
        '
        Me.IdsegregationsTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.SegregationsBindingSource, "idsegregations", True))
        Me.IdsegregationsTextBox.Location = New System.Drawing.Point(139, 4)
        Me.IdsegregationsTextBox.Name = "IdsegregationsTextBox"
        Me.IdsegregationsTextBox.Size = New System.Drawing.Size(100, 20)
        Me.IdsegregationsTextBox.TabIndex = 1
        '
        'IdsalleTextBox
        '
        Me.IdsalleTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.SallesBindingSource, "idsalle", True))
        Me.IdsalleTextBox.Location = New System.Drawing.Point(395, 167)
        Me.IdsalleTextBox.Name = "IdsalleTextBox"
        Me.IdsalleTextBox.Size = New System.Drawing.Size(100, 20)
        Me.IdsalleTextBox.TabIndex = 13
        '
        'IdsalleTextBox1
        '
        Me.IdsalleTextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.SallesBindingSource2, "idsalle", True))
        Me.IdsalleTextBox1.Location = New System.Drawing.Point(638, 167)
        Me.IdsalleTextBox1.Name = "IdsalleTextBox1"
        Me.IdsalleTextBox1.Size = New System.Drawing.Size(100, 20)
        Me.IdsalleTextBox1.TabIndex = 15
        '
        'ParcoursTableAdapter
        '
        Me.ParcoursTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.borniersTableAdapter = Nothing
        Me.TableAdapterManager.cables_detailsTableAdapter = Nothing
        Me.TableAdapterManager.cablesTableAdapter = Nothing
        Me.TableAdapterManager.categoriesTableAdapter = Nothing
        Me.TableAdapterManager.departsTableAdapter = Nothing
        Me.TableAdapterManager.donnees_cablesTableAdapter = Nothing
        Me.TableAdapterManager.equipementsTableAdapter = Nothing
        Me.TableAdapterManager.lotsTableAdapter = Nothing
        Me.TableAdapterManager.parcours_detailTableAdapter = Me.Parcours_detailTableAdapter
        Me.TableAdapterManager.parcoursTableAdapter = Me.ParcoursTableAdapter
        Me.TableAdapterManager.sallesTableAdapter = Nothing
        Me.TableAdapterManager.sections_cablesTableAdapter = Nothing
        Me.TableAdapterManager.segregationsTableAdapter = Nothing
        Me.TableAdapterManager.troncons_assocTableAdapter = Nothing
        Me.TableAdapterManager.tronconsTableAdapter = Nothing
        Me.TableAdapterManager.types_cableTableAdapter = Nothing
        Me.TableAdapterManager.types_tronconsTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = progelec.mydbDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'Parcours_detailTableAdapter
        '
        Me.Parcours_detailTableAdapter.ClearBeforeFill = True
        '
        'SegregationsTableAdapter
        '
        Me.SegregationsTableAdapter.ClearBeforeFill = True
        '
        'CablesTableAdapter
        '
        Me.CablesTableAdapter.ClearBeforeFill = True
        '
        'SallesTableAdapter
        '
        Me.SallesTableAdapter.ClearBeforeFill = True
        '
        'SallesTableAdapter2
        '
        Me.SallesTableAdapter2.ClearBeforeFill = True
        '
        'EquipementsBindingSource
        '
        Me.EquipementsBindingSource.DataMember = "equipements"
        Me.EquipementsBindingSource.DataSource = Me.MydbDataSet
        '
        'EquipementsTableAdapter
        '
        Me.EquipementsTableAdapter.ClearBeforeFill = True
        '
        'EquipementsBindingSource2
        '
        Me.EquipementsBindingSource2.DataMember = "equipements"
        Me.EquipementsBindingSource2.DataSource = Me.MydbDataSet
        '
        'EquipementsTableAdapter2
        '
        Me.EquipementsTableAdapter2.ClearBeforeFill = True
        '
        'Lst_troncons_onTableAdapter
        '
        Me.Lst_troncons_onTableAdapter.ClearBeforeFill = True
        '
        'Lst_troncons_on2TableAdapter
        '
        Me.Lst_troncons_on2TableAdapter.ClearBeforeFill = True
        '
        'Lst_troncons_par_segBindingSource
        '
        Me.Lst_troncons_par_segBindingSource.DataMember = "lst_troncons_par_seg"
        Me.Lst_troncons_par_segBindingSource.DataSource = Me.MydbDataSet
        '
        'Lst_troncons_par_segTableAdapter
        '
        Me.Lst_troncons_par_segTableAdapter.ClearBeforeFill = True
        '
        'IdtronconsTextBox
        '
        Me.IdtronconsTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Lst_troncons_onBindingSource, "idtroncons", True))
        Me.IdtronconsTextBox.Location = New System.Drawing.Point(398, 243)
        Me.IdtronconsTextBox.Name = "IdtronconsTextBox"
        Me.IdtronconsTextBox.Size = New System.Drawing.Size(100, 20)
        Me.IdtronconsTextBox.TabIndex = 23
        '
        'IdtronconsTextBox1
        '
        Me.IdtronconsTextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Lst_troncons_on2BindingSource, "idtroncons", True))
        Me.IdtronconsTextBox1.Location = New System.Drawing.Point(638, 243)
        Me.IdtronconsTextBox1.Name = "IdtronconsTextBox1"
        Me.IdtronconsTextBox1.Size = New System.Drawing.Size(100, 20)
        Me.IdtronconsTextBox1.TabIndex = 25
        '
        'Lst_trc_assocBindingSource
        '
        Me.Lst_trc_assocBindingSource.DataMember = "lst_trc_assoc"
        Me.Lst_trc_assocBindingSource.DataSource = Me.MydbDataSet
        '
        'Lst_trc_assocTableAdapter
        '
        Me.Lst_trc_assocTableAdapter.ClearBeforeFill = True
        '
        'Lst_assoc_par_trcBindingSource
        '
        Me.Lst_assoc_par_trcBindingSource.DataMember = "lst_assoc_par_trc"
        Me.Lst_assoc_par_trcBindingSource.DataSource = Me.MydbDataSet
        '
        'Lst_assoc_par_trcTableAdapter
        '
        Me.Lst_assoc_par_trcTableAdapter.ClearBeforeFill = True
        '
        'Lst_assoc_par_trc2BindingSource
        '
        Me.Lst_assoc_par_trc2BindingSource.DataMember = "lst_assoc_par_trc2"
        Me.Lst_assoc_par_trc2BindingSource.DataSource = Me.MydbDataSet
        '
        'Lst_assoc_par_trc2TableAdapter
        '
        Me.Lst_assoc_par_trc2TableAdapter.ClearBeforeFill = True
        '
        'Cable_details_tronconTableAdapter
        '
        Me.Cable_details_tronconTableAdapter.ClearBeforeFill = True
        '
        'BindingNavigator1
        '
        Me.BindingNavigator1.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.BindingNavigator1.BindingSource = Me.ParcoursBindingSource
        Me.BindingNavigator1.CountItem = Me.BindingNavigatorCountItem
        Me.BindingNavigator1.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.BindingNavigator1.Dock = System.Windows.Forms.DockStyle.None
        Me.BindingNavigator1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem})
        Me.BindingNavigator1.Location = New System.Drawing.Point(1117, 243)
        Me.BindingNavigator1.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.BindingNavigator1.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.BindingNavigator1.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.BindingNavigator1.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.BindingNavigator1.Name = "BindingNavigator1"
        Me.BindingNavigator1.PositionItem = Me.BindingNavigatorPositionItem
        Me.BindingNavigator1.Size = New System.Drawing.Size(250, 25)
        Me.BindingNavigator1.TabIndex = 26
        Me.BindingNavigator1.Text = "BindingNavigator1"
        '
        'BindingNavigatorAddNewItem
        '
        Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorAddNewItem.Image = CType(resources.GetObject("BindingNavigatorAddNewItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
        Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorAddNewItem.Text = "Ajouter nouveau"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(30, 22)
        Me.BindingNavigatorCountItem.Text = "de {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Nombre total d'éléments"
        '
        'BindingNavigatorDeleteItem
        '
        Me.BindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
        Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorDeleteItem.Text = "Supprimer"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem.Text = "Placer en premier"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMovePreviousItem.Text = "Déplacer vers le haut"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 21)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Position actuelle"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveNextItem.Text = "Déplacer vers le bas"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveLastItem.Text = "Placer en dernier"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'Parcour_detail_idTableAdapter
        '
        Me.Parcour_detail_idTableAdapter.ClearBeforeFill = True
        '
        'LongueurLabel
        '
        LongueurLabel.AutoSize = True
        LongueurLabel.Location = New System.Drawing.Point(629, 63)
        LongueurLabel.Name = "LongueurLabel"
        LongueurLabel.Size = New System.Drawing.Size(51, 13)
        LongueurLabel.TabIndex = 27
        LongueurLabel.Text = "longueur:"
        '
        'LongueurTextBox
        '
        Me.LongueurTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ParcoursBindingSource, "longueur", True))
        Me.LongueurTextBox.Location = New System.Drawing.Point(686, 60)
        Me.LongueurTextBox.Name = "LongueurTextBox"
        Me.LongueurTextBox.Size = New System.Drawing.Size(100, 20)
        Me.LongueurTextBox.TabIndex = 28
        '
        'FormParcours
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1940, 644)
        Me.Controls.Add(LongueurLabel)
        Me.Controls.Add(Me.LongueurTextBox)
        Me.Controls.Add(Me.BindingNavigator1)
        Me.Controls.Add(IdtronconsLabel1)
        Me.Controls.Add(Me.IdtronconsTextBox1)
        Me.Controls.Add(IdtronconsLabel)
        Me.Controls.Add(Me.IdtronconsTextBox)
        Me.Controls.Add(IdsalleLabel1)
        Me.Controls.Add(Me.IdsalleTextBox1)
        Me.Controls.Add(IdsalleLabel)
        Me.Controls.Add(Me.IdsalleTextBox)
        Me.Controls.Add(IdsegregationsLabel)
        Me.Controls.Add(Me.IdsegregationsTextBox)
        Me.Controls.Add(Me.GroupPanel2)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(RevisionLabel)
        Me.Controls.Add(Me.RevisionTextBox)
        Me.Controls.Add(QuiLabel)
        Me.Controls.Add(Me.QuiTextBox)
        Me.Controls.Add(DateLabel)
        Me.Controls.Add(Me.DateDateTimePicker)
        Me.Controls.Add(Me.SuperTabControl1)
        Me.Controls.Add(IdparcoursLabel)
        Me.Controls.Add(Me.IdparcoursTextBox)
        Me.Controls.Add(Me.ButtonXFermer)
        Me.Controls.Add(Me.ButtonXSupprimer)
        Me.Controls.Add(Me.ButtonXModifier)
        Me.Controls.Add(Me.ButtonXCreer)
        Me.Name = "FormParcours"
        Me.Text = "Form1"
        CType(Me.ParcoursBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MydbDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SuperTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControl1.ResumeLayout(False)
        Me.SuperTabControlPanel1.ResumeLayout(False)
        CType(Me.Parcours_detailDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Parcour_detail_idBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControlPanel2.ResumeLayout(False)
        CType(Me.Cable_details_tronconDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cable_details_tronconBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Parcours_detailBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CablesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.Lst_troncons_on2BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SallesBindingSource2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel2.ResumeLayout(False)
        CType(Me.Lst_troncons_onBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SallesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SegregationsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EquipementsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EquipementsBindingSource2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Lst_troncons_par_segBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Lst_trc_assocBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Lst_assoc_par_trcBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Lst_assoc_par_trc2BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BindingNavigator1.ResumeLayout(False)
        Me.BindingNavigator1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents ButtonXCreer As DevComponents.DotNetBar.ButtonX
    Private WithEvents ButtonXModifier As DevComponents.DotNetBar.ButtonX
    Private WithEvents ButtonXSupprimer As DevComponents.DotNetBar.ButtonX
    Private WithEvents ButtonXFermer As DevComponents.DotNetBar.ButtonX
    Friend WithEvents MydbDataSet As progelec.mydbDataSet
    Friend WithEvents ParcoursBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ParcoursTableAdapter As progelec.mydbDataSetTableAdapters.parcoursTableAdapter
    Friend WithEvents TableAdapterManager As progelec.mydbDataSetTableAdapters.TableAdapterManager
    Friend WithEvents IdparcoursTextBox As System.Windows.Forms.TextBox
    Friend WithEvents SuperTabControl1 As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents SuperTabControlPanel1 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SuperTabItem1 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel2 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SuperTabItem2 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents DateDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents CablesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CablesTableAdapter As progelec.mydbDataSetTableAdapters.cablesTableAdapter
    Friend WithEvents Parcours_detailBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Parcours_detailTableAdapter As progelec.mydbDataSetTableAdapters.parcours_detailTableAdapter
    Friend WithEvents Parcours_detailDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents QuiTextBox As System.Windows.Forms.TextBox
    Friend WithEvents RevisionTextBox As System.Windows.Forms.TextBox
    Friend WithEvents SallesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SallesTableAdapter As progelec.mydbDataSetTableAdapters.sallesTableAdapter
    Friend WithEvents SallesBindingSource2 As System.Windows.Forms.BindingSource
    Friend WithEvents SallesTableAdapter2 As progelec.mydbDataSetTableAdapters.sallesTableAdapter
    Friend WithEvents EquipementsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EquipementsTableAdapter As progelec.mydbDataSetTableAdapters.equipementsTableAdapter
    Friend WithEvents EquipementsBindingSource2 As System.Windows.Forms.BindingSource
    Friend WithEvents EquipementsTableAdapter2 As progelec.mydbDataSetTableAdapters.equipementsTableAdapter
    Private WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Private WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Private WithEvents ComboBox3 As System.Windows.Forms.ComboBox
    Private WithEvents ComboBox5 As System.Windows.Forms.ComboBox
    Private WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Private WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Private WithEvents ComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents SegregationsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SegregationsTableAdapter As progelec.mydbDataSetTableAdapters.segregationsTableAdapter
    Friend WithEvents Lst_troncons_onBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Lst_troncons_onTableAdapter As progelec.mydbDataSetTableAdapters.lst_troncons_onTableAdapter
    Friend WithEvents IdsegregationsTextBox As System.Windows.Forms.TextBox
    Friend WithEvents IdsalleTextBox As System.Windows.Forms.TextBox
    Friend WithEvents IdsalleTextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Lst_troncons_on2BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Lst_troncons_on2TableAdapter As progelec.mydbDataSetTableAdapters.lst_troncons_on2TableAdapter
    Friend WithEvents Lst_troncons_par_segBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Lst_troncons_par_segTableAdapter As progelec.mydbDataSetTableAdapters.lst_troncons_par_segTableAdapter
    Friend WithEvents IdtronconsTextBox As System.Windows.Forms.TextBox
    Friend WithEvents IdtronconsTextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Lst_trc_assocBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Lst_trc_assocTableAdapter As progelec.mydbDataSetTableAdapters.lst_trc_assocTableAdapter
    Friend WithEvents Lst_assoc_par_trcBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Lst_assoc_par_trcTableAdapter As progelec.mydbDataSetTableAdapters.lst_assoc_par_trcTableAdapter
    Friend WithEvents Lst_assoc_par_trc2BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Lst_assoc_par_trc2TableAdapter As progelec.mydbDataSetTableAdapters.lst_assoc_par_trc2TableAdapter
    Friend WithEvents Cable_details_tronconBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Cable_details_tronconTableAdapter As progelec.mydbDataSetTableAdapters.cable_details_tronconTableAdapter
    Friend WithEvents Cable_details_tronconDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BindingNavigator1 As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorAddNewItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorDeleteItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Parcour_detail_idBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Parcour_detail_idTableAdapter As progelec.mydbDataSetTableAdapters.parcour_detail_idTableAdapter
    Friend WithEvents RepereSalleDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NiveauDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RepereTronconDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TypeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SegregationDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LongueurTextBox As System.Windows.Forms.TextBox
End Class
