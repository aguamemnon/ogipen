<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSalle
    Inherits DevComponents.DotNetBar.OfficeForm

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
        Dim Repere_salleLabel As System.Windows.Forms.Label
        Dim NiveauLabel As System.Windows.Forms.Label
        Dim DesignationLabel As System.Windows.Forms.Label
        Dim HauteurLabel As System.Windows.Forms.Label
        Dim LargeurLabel As System.Windows.Forms.Label
        Dim LongueurLabel As System.Windows.Forms.Label
        Dim DCCLabel As System.Windows.Forms.Label
        Dim DateLabel As System.Windows.Forms.Label
        Dim QuiLabel As System.Windows.Forms.Label
        Dim RevLabel As System.Windows.Forms.Label
        Dim Label1 As System.Windows.Forms.Label
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle25 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle26 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle27 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSalle))
        Me.MydbDataSet1 = New progelec.mydbDataSet()
        Me.SuperTabControl1 = New DevComponents.DotNetBar.SuperTabControl()
        Me.SuperTabControlPanel1 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.EquipementsDataGridViewX = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EquipementsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SallesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SuperTabItem1 = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel3 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.DataGridViewX1 = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.SuperTabItem3 = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel4 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.DCCTextBox = New System.Windows.Forms.TextBox()
        Me.SuperTabItem4 = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel2 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.TronconsDataGridViewX = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.IdtronconsDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RepereTronconDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SallesDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SegregationsidsegregationsDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LargeurDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LongueurDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HauteurDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ElevationDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReservesDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Reserves2DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FormesDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MargesHDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MargesLDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DiametreDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VersionDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QuiDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TypestronconsidTypestronconsDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReservecalDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReservereelDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DatecalculDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Reserve2calDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Reserve2reelDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VirtuelDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SallesidsalleDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RemplissageDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Remplissage2DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Remplissage3DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DiscriminationDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RemarqueDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Lst_trc_salleBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SuperTabItem2 = New DevComponents.DotNetBar.SuperTabItem()
        Me.SallesTableAdapter = New progelec.mydbDataSetTableAdapters.sallesTableAdapter()
        Me.TableAdapterManager = New progelec.mydbDataSetTableAdapters.TableAdapterManager()
        Me.EquipementsTableAdapter = New progelec.mydbDataSetTableAdapters.equipementsTableAdapter()
        Me.Repere_salleTextBox = New System.Windows.Forms.TextBox()
        Me.NiveauTextBox = New System.Windows.Forms.TextBox()
        Me.DesignationTextBox = New System.Windows.Forms.TextBox()
        Me.HauteurTextBox = New System.Windows.Forms.TextBox()
        Me.LargeurTextBox = New System.Windows.Forms.TextBox()
        Me.LongueurTextBox = New System.Windows.Forms.TextBox()
        Me.DateDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.QuiTextBox = New System.Windows.Forms.TextBox()
        Me.RevTextBox = New System.Windows.Forms.TextBox()
        Me.Lst_trc_salleTableAdapter = New progelec.mydbDataSetTableAdapters.lst_trc_salleTableAdapter()
        Me.IdsalleTextBox = New System.Windows.Forms.TextBox()
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX2 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX3 = New DevComponents.DotNetBar.ButtonX()
        Me.SuperValidator1 = New DevComponents.DotNetBar.Validator.SuperValidator()
        Me.RequiredFieldValidator1 = New DevComponents.DotNetBar.Validator.RequiredFieldValidator("Your error message here.")
        Me.CustomValidator1 = New DevComponents.DotNetBar.Validator.CustomValidator()
        Me.RequiredFieldValidator2 = New DevComponents.DotNetBar.Validator.RequiredFieldValidator("Champ Obligatoire.")
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Highlighter1 = New DevComponents.DotNetBar.Validator.Highlighter()
        Me.ComboBoxEx1 = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.BatimentsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.RequiredFieldValidator3 = New DevComponents.DotNetBar.Validator.RequiredFieldValidator("Veuillez selectionner un batiment")
        Me.BatimentsTableAdapter = New progelec.mydbDataSetTableAdapters.batimentsTableAdapter()
        Me.ReflectionImage1 = New DevComponents.DotNetBar.Controls.ReflectionImage()
        Me.ButtonX4 = New DevComponents.DotNetBar.ButtonX()
        Me.CablesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CablesTableAdapter = New progelec.mydbDataSetTableAdapters.cablesTableAdapter()
        Me.TronconsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TronconsTableAdapter = New progelec.mydbDataSetTableAdapters.tronconsTableAdapter()
        Repere_salleLabel = New System.Windows.Forms.Label()
        NiveauLabel = New System.Windows.Forms.Label()
        DesignationLabel = New System.Windows.Forms.Label()
        HauteurLabel = New System.Windows.Forms.Label()
        LargeurLabel = New System.Windows.Forms.Label()
        LongueurLabel = New System.Windows.Forms.Label()
        DCCLabel = New System.Windows.Forms.Label()
        DateLabel = New System.Windows.Forms.Label()
        QuiLabel = New System.Windows.Forms.Label()
        RevLabel = New System.Windows.Forms.Label()
        Label1 = New System.Windows.Forms.Label()
        CType(Me.MydbDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SuperTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControl1.SuspendLayout()
        Me.SuperTabControlPanel1.SuspendLayout()
        CType(Me.EquipementsDataGridViewX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EquipementsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SallesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControlPanel3.SuspendLayout()
        CType(Me.DataGridViewX1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControlPanel4.SuspendLayout()
        Me.SuperTabControlPanel2.SuspendLayout()
        CType(Me.TronconsDataGridViewX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Lst_trc_salleBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BatimentsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CablesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TronconsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Repere_salleLabel
        '
        Repere_salleLabel.AutoSize = True
        Repere_salleLabel.Location = New System.Drawing.Point(306, 56)
        Repere_salleLabel.Name = "Repere_salleLabel"
        Repere_salleLabel.Size = New System.Drawing.Size(64, 13)
        Repere_salleLabel.TabIndex = 6
        Repere_salleLabel.Text = "repere salle:"
        '
        'NiveauLabel
        '
        NiveauLabel.AutoSize = True
        NiveauLabel.Location = New System.Drawing.Point(467, 65)
        NiveauLabel.Name = "NiveauLabel"
        NiveauLabel.Size = New System.Drawing.Size(44, 13)
        NiveauLabel.TabIndex = 8
        NiveauLabel.Text = "Niveau:"
        '
        'DesignationLabel
        '
        DesignationLabel.AutoSize = True
        DesignationLabel.Location = New System.Drawing.Point(29, 112)
        DesignationLabel.Name = "DesignationLabel"
        DesignationLabel.Size = New System.Drawing.Size(64, 13)
        DesignationLabel.TabIndex = 10
        DesignationLabel.Text = "designation:"
        '
        'HauteurLabel
        '
        HauteurLabel.AutoSize = True
        HauteurLabel.Location = New System.Drawing.Point(570, 65)
        HauteurLabel.Name = "HauteurLabel"
        HauteurLabel.Size = New System.Drawing.Size(48, 13)
        HauteurLabel.TabIndex = 12
        HauteurLabel.Text = "Hauteur:"
        '
        'LargeurLabel
        '
        LargeurLabel.AutoSize = True
        LargeurLabel.Location = New System.Drawing.Point(685, 65)
        LargeurLabel.Name = "LargeurLabel"
        LargeurLabel.Size = New System.Drawing.Size(46, 13)
        LargeurLabel.TabIndex = 14
        LargeurLabel.Text = "Largeur:"
        '
        'LongueurLabel
        '
        LongueurLabel.AutoSize = True
        LongueurLabel.Location = New System.Drawing.Point(779, 65)
        LongueurLabel.Name = "LongueurLabel"
        LongueurLabel.Size = New System.Drawing.Size(55, 13)
        LongueurLabel.TabIndex = 16
        LongueurLabel.Text = "Longueur:"
        '
        'DCCLabel
        '
        DCCLabel.AutoSize = True
        DCCLabel.Location = New System.Drawing.Point(444, 38)
        DCCLabel.Name = "DCCLabel"
        DCCLabel.Size = New System.Drawing.Size(32, 13)
        DCCLabel.TabIndex = 0
        DCCLabel.Text = "DCC:"
        '
        'DateLabel
        '
        DateLabel.AutoSize = True
        DateLabel.Location = New System.Drawing.Point(318, 15)
        DateLabel.Name = "DateLabel"
        DateLabel.Size = New System.Drawing.Size(33, 13)
        DateLabel.TabIndex = 4
        DateLabel.Text = "Date:"
        '
        'QuiLabel
        '
        QuiLabel.AutoSize = True
        QuiLabel.Location = New System.Drawing.Point(155, 14)
        QuiLabel.Name = "QuiLabel"
        QuiLabel.Size = New System.Drawing.Size(26, 13)
        QuiLabel.TabIndex = 2
        QuiLabel.Text = "Qui:"
        '
        'RevLabel
        '
        RevLabel.AutoSize = True
        RevLabel.Location = New System.Drawing.Point(8, 14)
        RevLabel.Name = "RevLabel"
        RevLabel.Size = New System.Drawing.Size(30, 13)
        RevLabel.TabIndex = 0
        RevLabel.Text = "Rev:"
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(29, 84)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(54, 13)
        Label1.TabIndex = 6
        Label1.Text = "Batiment :"
        '
        'MydbDataSet1
        '
        Me.MydbDataSet1.DataSetName = "mydbDataSet"
        Me.MydbDataSet1.EnforceConstraints = False
        Me.MydbDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'SuperTabControl1
        '
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
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel3)
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel4)
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel2)
        Me.SuperTabControl1.Location = New System.Drawing.Point(11, 234)
        Me.SuperTabControl1.Name = "SuperTabControl1"
        Me.SuperTabControl1.ReorderTabsEnabled = True
        Me.SuperTabControl1.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.SuperTabControl1.SelectedTabIndex = 3
        Me.SuperTabControl1.Size = New System.Drawing.Size(742, 329)
        Me.SuperTabControl1.TabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SuperTabControl1.TabIndex = 19
        Me.SuperTabControl1.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabItem1, Me.SuperTabItem2, Me.SuperTabItem3, Me.SuperTabItem4})
        Me.SuperTabControl1.Text = "SuperTabControl1"
        '
        'SuperTabControlPanel1
        '
        Me.SuperTabControlPanel1.Controls.Add(Me.EquipementsDataGridViewX)
        Me.SuperTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel1.Location = New System.Drawing.Point(0, 25)
        Me.SuperTabControlPanel1.Name = "SuperTabControlPanel1"
        Me.SuperTabControlPanel1.Size = New System.Drawing.Size(742, 304)
        Me.SuperTabControlPanel1.TabIndex = 2
        Me.SuperTabControlPanel1.TabItem = Me.SuperTabItem1
        '
        'EquipementsDataGridViewX
        '
        Me.EquipementsDataGridViewX.AutoGenerateColumns = False
        Me.EquipementsDataGridViewX.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle19.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle19.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.EquipementsDataGridViewX.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle19
        Me.EquipementsDataGridViewX.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.EquipementsDataGridViewX.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9})
        Me.EquipementsDataGridViewX.DataSource = Me.EquipementsBindingSource
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle20.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle20.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle20.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.EquipementsDataGridViewX.DefaultCellStyle = DataGridViewCellStyle20
        Me.EquipementsDataGridViewX.Dock = System.Windows.Forms.DockStyle.Fill
        Me.EquipementsDataGridViewX.EnableHeadersVisualStyles = False
        Me.EquipementsDataGridViewX.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.EquipementsDataGridViewX.Location = New System.Drawing.Point(0, 0)
        Me.EquipementsDataGridViewX.Name = "EquipementsDataGridViewX"
        DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle21.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle21.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.EquipementsDataGridViewX.RowHeadersDefaultCellStyle = DataGridViewCellStyle21
        Me.EquipementsDataGridViewX.Size = New System.Drawing.Size(742, 304)
        Me.EquipementsDataGridViewX.TabIndex = 0
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "idequipement"
        Me.DataGridViewTextBoxColumn1.HeaderText = "idequipement"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "repere equipement"
        Me.DataGridViewTextBoxColumn2.HeaderText = "repere equipement"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 110
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "salles_idsalle"
        Me.DataGridViewTextBoxColumn3.HeaderText = "salles_idsalle"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Visible = False
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "lots_idlots"
        Me.DataGridViewTextBoxColumn4.HeaderText = "lot"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "Categories_idCategories"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Categories_idCategories"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Visible = False
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "designation"
        Me.DataGridViewTextBoxColumn6.HeaderText = "designation"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Width = 86
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "date"
        Me.DataGridViewTextBoxColumn7.HeaderText = "date"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.Visible = False
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "revision"
        Me.DataGridViewTextBoxColumn8.HeaderText = "revision"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.Visible = False
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "qui"
        Me.DataGridViewTextBoxColumn9.HeaderText = "qui"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.Visible = False
        '
        'EquipementsBindingSource
        '
        Me.EquipementsBindingSource.DataMember = "fk_equipements_salles1"
        Me.EquipementsBindingSource.DataSource = Me.SallesBindingSource
        '
        'SallesBindingSource
        '
        Me.SallesBindingSource.DataMember = "salles"
        Me.SallesBindingSource.DataSource = Me.MydbDataSet1
        '
        'SuperTabItem1
        '
        Me.SuperTabItem1.AttachedControl = Me.SuperTabControlPanel1
        Me.SuperTabItem1.GlobalItem = False
        Me.SuperTabItem1.Name = "SuperTabItem1"
        Me.SuperTabItem1.Text = "Equipements"
        '
        'SuperTabControlPanel3
        '
        Me.SuperTabControlPanel3.Controls.Add(Me.DataGridViewX1)
        Me.SuperTabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel3.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel3.Name = "SuperTabControlPanel3"
        Me.SuperTabControlPanel3.Size = New System.Drawing.Size(742, 329)
        Me.SuperTabControlPanel3.TabIndex = 3
        Me.SuperTabControlPanel3.TabItem = Me.SuperTabItem3
        '
        'DataGridViewX1
        '
        Me.DataGridViewX1.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle22.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle22.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewX1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle22
        Me.DataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle23.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle23.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle23.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewX1.DefaultCellStyle = DataGridViewCellStyle23
        Me.DataGridViewX1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridViewX1.EnableHeadersVisualStyles = False
        Me.DataGridViewX1.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.DataGridViewX1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridViewX1.Name = "DataGridViewX1"
        DataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle24.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle24.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewX1.RowHeadersDefaultCellStyle = DataGridViewCellStyle24
        Me.DataGridViewX1.Size = New System.Drawing.Size(742, 329)
        Me.DataGridViewX1.TabIndex = 1
        '
        'SuperTabItem3
        '
        Me.SuperTabItem3.AttachedControl = Me.SuperTabControlPanel3
        Me.SuperTabItem3.GlobalItem = False
        Me.SuperTabItem3.Name = "SuperTabItem3"
        Me.SuperTabItem3.Text = "Cables"
        '
        'SuperTabControlPanel4
        '
        Me.SuperTabControlPanel4.Controls.Add(DCCLabel)
        Me.SuperTabControlPanel4.Controls.Add(Me.DCCTextBox)
        Me.SuperTabControlPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel4.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel4.Name = "SuperTabControlPanel4"
        Me.SuperTabControlPanel4.Size = New System.Drawing.Size(742, 329)
        Me.SuperTabControlPanel4.TabIndex = 0
        Me.SuperTabControlPanel4.TabItem = Me.SuperTabItem4
        '
        'DCCTextBox
        '
        Me.DCCTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.SallesBindingSource, "DCC", True))
        Me.DCCTextBox.Location = New System.Drawing.Point(482, 35)
        Me.DCCTextBox.Name = "DCCTextBox"
        Me.DCCTextBox.Size = New System.Drawing.Size(100, 20)
        Me.DCCTextBox.TabIndex = 1
        '
        'SuperTabItem4
        '
        Me.SuperTabItem4.AttachedControl = Me.SuperTabControlPanel4
        Me.SuperTabItem4.GlobalItem = False
        Me.SuperTabItem4.Name = "SuperTabItem4"
        Me.SuperTabItem4.Text = "DCC"
        '
        'SuperTabControlPanel2
        '
        Me.SuperTabControlPanel2.AutoScroll = True
        Me.SuperTabControlPanel2.Controls.Add(Me.TronconsDataGridViewX)
        Me.SuperTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel2.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel2.Name = "SuperTabControlPanel2"
        Me.SuperTabControlPanel2.Size = New System.Drawing.Size(742, 329)
        Me.SuperTabControlPanel2.TabIndex = 1
        Me.SuperTabControlPanel2.TabItem = Me.SuperTabItem2
        '
        'TronconsDataGridViewX
        '
        Me.TronconsDataGridViewX.AutoGenerateColumns = False
        Me.TronconsDataGridViewX.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle25.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle25.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle25.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle25.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.TronconsDataGridViewX.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle25
        Me.TronconsDataGridViewX.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TronconsDataGridViewX.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdtronconsDataGridViewTextBoxColumn, Me.RepereTronconDataGridViewTextBoxColumn, Me.SallesDataGridViewTextBoxColumn, Me.SegregationsidsegregationsDataGridViewTextBoxColumn, Me.LargeurDataGridViewTextBoxColumn, Me.LongueurDataGridViewTextBoxColumn, Me.HauteurDataGridViewTextBoxColumn, Me.ElevationDataGridViewTextBoxColumn, Me.ReservesDataGridViewTextBoxColumn, Me.Reserves2DataGridViewTextBoxColumn, Me.FormesDataGridViewTextBoxColumn, Me.MargesHDataGridViewTextBoxColumn, Me.MargesLDataGridViewTextBoxColumn, Me.DiametreDataGridViewTextBoxColumn, Me.VersionDataGridViewTextBoxColumn, Me.QuiDataGridViewTextBoxColumn, Me.TypestronconsidTypestronconsDataGridViewTextBoxColumn, Me.ReservecalDataGridViewTextBoxColumn, Me.ReservereelDataGridViewTextBoxColumn, Me.DatecalculDataGridViewTextBoxColumn, Me.Reserve2calDataGridViewTextBoxColumn, Me.Reserve2reelDataGridViewTextBoxColumn, Me.VirtuelDataGridViewTextBoxColumn, Me.SallesidsalleDataGridViewTextBoxColumn, Me.RemplissageDataGridViewTextBoxColumn, Me.Remplissage2DataGridViewTextBoxColumn, Me.Remplissage3DataGridViewTextBoxColumn, Me.DiscriminationDataGridViewTextBoxColumn, Me.RemarqueDataGridViewTextBoxColumn})
        Me.TronconsDataGridViewX.DataSource = Me.Lst_trc_salleBindingSource
        DataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle26.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle26.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle26.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle26.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.TronconsDataGridViewX.DefaultCellStyle = DataGridViewCellStyle26
        Me.TronconsDataGridViewX.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TronconsDataGridViewX.EnableHeadersVisualStyles = False
        Me.TronconsDataGridViewX.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.TronconsDataGridViewX.Location = New System.Drawing.Point(0, 0)
        Me.TronconsDataGridViewX.Name = "TronconsDataGridViewX"
        DataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle27.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle27.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle27.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle27.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.TronconsDataGridViewX.RowHeadersDefaultCellStyle = DataGridViewCellStyle27
        Me.TronconsDataGridViewX.Size = New System.Drawing.Size(742, 329)
        Me.TronconsDataGridViewX.TabIndex = 0
        '
        'IdtronconsDataGridViewTextBoxColumn
        '
        Me.IdtronconsDataGridViewTextBoxColumn.DataPropertyName = "idtroncons"
        Me.IdtronconsDataGridViewTextBoxColumn.HeaderText = "idtroncons"
        Me.IdtronconsDataGridViewTextBoxColumn.Name = "IdtronconsDataGridViewTextBoxColumn"
        Me.IdtronconsDataGridViewTextBoxColumn.Visible = False
        '
        'RepereTronconDataGridViewTextBoxColumn
        '
        Me.RepereTronconDataGridViewTextBoxColumn.DataPropertyName = "repere troncon"
        Me.RepereTronconDataGridViewTextBoxColumn.HeaderText = "repere troncon"
        Me.RepereTronconDataGridViewTextBoxColumn.Name = "RepereTronconDataGridViewTextBoxColumn"
        '
        'SallesDataGridViewTextBoxColumn
        '
        Me.SallesDataGridViewTextBoxColumn.DataPropertyName = "salles"
        Me.SallesDataGridViewTextBoxColumn.HeaderText = "salles"
        Me.SallesDataGridViewTextBoxColumn.Name = "SallesDataGridViewTextBoxColumn"
        Me.SallesDataGridViewTextBoxColumn.Visible = False
        '
        'SegregationsidsegregationsDataGridViewTextBoxColumn
        '
        Me.SegregationsidsegregationsDataGridViewTextBoxColumn.DataPropertyName = "segregations_idsegregations"
        Me.SegregationsidsegregationsDataGridViewTextBoxColumn.HeaderText = "segregations_idsegregations"
        Me.SegregationsidsegregationsDataGridViewTextBoxColumn.Name = "SegregationsidsegregationsDataGridViewTextBoxColumn"
        Me.SegregationsidsegregationsDataGridViewTextBoxColumn.Visible = False
        '
        'LargeurDataGridViewTextBoxColumn
        '
        Me.LargeurDataGridViewTextBoxColumn.DataPropertyName = "largeur"
        Me.LargeurDataGridViewTextBoxColumn.HeaderText = "largeur"
        Me.LargeurDataGridViewTextBoxColumn.Name = "LargeurDataGridViewTextBoxColumn"
        Me.LargeurDataGridViewTextBoxColumn.Visible = False
        '
        'LongueurDataGridViewTextBoxColumn
        '
        Me.LongueurDataGridViewTextBoxColumn.DataPropertyName = "longueur"
        Me.LongueurDataGridViewTextBoxColumn.HeaderText = "longueur"
        Me.LongueurDataGridViewTextBoxColumn.Name = "LongueurDataGridViewTextBoxColumn"
        Me.LongueurDataGridViewTextBoxColumn.Visible = False
        '
        'HauteurDataGridViewTextBoxColumn
        '
        Me.HauteurDataGridViewTextBoxColumn.DataPropertyName = "hauteur"
        Me.HauteurDataGridViewTextBoxColumn.HeaderText = "hauteur"
        Me.HauteurDataGridViewTextBoxColumn.Name = "HauteurDataGridViewTextBoxColumn"
        Me.HauteurDataGridViewTextBoxColumn.Visible = False
        '
        'ElevationDataGridViewTextBoxColumn
        '
        Me.ElevationDataGridViewTextBoxColumn.DataPropertyName = "elevation"
        Me.ElevationDataGridViewTextBoxColumn.HeaderText = "elevation"
        Me.ElevationDataGridViewTextBoxColumn.Name = "ElevationDataGridViewTextBoxColumn"
        Me.ElevationDataGridViewTextBoxColumn.Visible = False
        '
        'ReservesDataGridViewTextBoxColumn
        '
        Me.ReservesDataGridViewTextBoxColumn.DataPropertyName = "reserves"
        Me.ReservesDataGridViewTextBoxColumn.HeaderText = "reserves"
        Me.ReservesDataGridViewTextBoxColumn.Name = "ReservesDataGridViewTextBoxColumn"
        Me.ReservesDataGridViewTextBoxColumn.Visible = False
        '
        'Reserves2DataGridViewTextBoxColumn
        '
        Me.Reserves2DataGridViewTextBoxColumn.DataPropertyName = "reserves2"
        Me.Reserves2DataGridViewTextBoxColumn.HeaderText = "reserves2"
        Me.Reserves2DataGridViewTextBoxColumn.Name = "Reserves2DataGridViewTextBoxColumn"
        Me.Reserves2DataGridViewTextBoxColumn.Visible = False
        '
        'FormesDataGridViewTextBoxColumn
        '
        Me.FormesDataGridViewTextBoxColumn.DataPropertyName = "formes"
        Me.FormesDataGridViewTextBoxColumn.HeaderText = "formes"
        Me.FormesDataGridViewTextBoxColumn.Name = "FormesDataGridViewTextBoxColumn"
        '
        'MargesHDataGridViewTextBoxColumn
        '
        Me.MargesHDataGridViewTextBoxColumn.DataPropertyName = "margesH"
        Me.MargesHDataGridViewTextBoxColumn.HeaderText = "margesH"
        Me.MargesHDataGridViewTextBoxColumn.Name = "MargesHDataGridViewTextBoxColumn"
        Me.MargesHDataGridViewTextBoxColumn.Visible = False
        '
        'MargesLDataGridViewTextBoxColumn
        '
        Me.MargesLDataGridViewTextBoxColumn.DataPropertyName = "margesL"
        Me.MargesLDataGridViewTextBoxColumn.HeaderText = "margesL"
        Me.MargesLDataGridViewTextBoxColumn.Name = "MargesLDataGridViewTextBoxColumn"
        Me.MargesLDataGridViewTextBoxColumn.Visible = False
        '
        'DiametreDataGridViewTextBoxColumn
        '
        Me.DiametreDataGridViewTextBoxColumn.DataPropertyName = "Diametre"
        Me.DiametreDataGridViewTextBoxColumn.HeaderText = "Diametre"
        Me.DiametreDataGridViewTextBoxColumn.Name = "DiametreDataGridViewTextBoxColumn"
        Me.DiametreDataGridViewTextBoxColumn.Visible = False
        '
        'VersionDataGridViewTextBoxColumn
        '
        Me.VersionDataGridViewTextBoxColumn.DataPropertyName = "version"
        Me.VersionDataGridViewTextBoxColumn.HeaderText = "version"
        Me.VersionDataGridViewTextBoxColumn.Name = "VersionDataGridViewTextBoxColumn"
        Me.VersionDataGridViewTextBoxColumn.Visible = False
        '
        'QuiDataGridViewTextBoxColumn
        '
        Me.QuiDataGridViewTextBoxColumn.DataPropertyName = "Qui"
        Me.QuiDataGridViewTextBoxColumn.HeaderText = "Qui"
        Me.QuiDataGridViewTextBoxColumn.Name = "QuiDataGridViewTextBoxColumn"
        Me.QuiDataGridViewTextBoxColumn.Visible = False
        '
        'TypestronconsidTypestronconsDataGridViewTextBoxColumn
        '
        Me.TypestronconsidTypestronconsDataGridViewTextBoxColumn.DataPropertyName = "Types_troncons_idTypes_troncons"
        Me.TypestronconsidTypestronconsDataGridViewTextBoxColumn.HeaderText = "Types_troncons_idTypes_troncons"
        Me.TypestronconsidTypestronconsDataGridViewTextBoxColumn.Name = "TypestronconsidTypestronconsDataGridViewTextBoxColumn"
        Me.TypestronconsidTypestronconsDataGridViewTextBoxColumn.Visible = False
        '
        'ReservecalDataGridViewTextBoxColumn
        '
        Me.ReservecalDataGridViewTextBoxColumn.DataPropertyName = "Reserve_cal"
        Me.ReservecalDataGridViewTextBoxColumn.HeaderText = "Reserve_cal"
        Me.ReservecalDataGridViewTextBoxColumn.Name = "ReservecalDataGridViewTextBoxColumn"
        Me.ReservecalDataGridViewTextBoxColumn.Visible = False
        '
        'ReservereelDataGridViewTextBoxColumn
        '
        Me.ReservereelDataGridViewTextBoxColumn.DataPropertyName = "reserve_reel"
        Me.ReservereelDataGridViewTextBoxColumn.HeaderText = "reserve_reel"
        Me.ReservereelDataGridViewTextBoxColumn.Name = "ReservereelDataGridViewTextBoxColumn"
        Me.ReservereelDataGridViewTextBoxColumn.Visible = False
        '
        'DatecalculDataGridViewTextBoxColumn
        '
        Me.DatecalculDataGridViewTextBoxColumn.DataPropertyName = "date_calcul"
        Me.DatecalculDataGridViewTextBoxColumn.HeaderText = "date_calcul"
        Me.DatecalculDataGridViewTextBoxColumn.Name = "DatecalculDataGridViewTextBoxColumn"
        Me.DatecalculDataGridViewTextBoxColumn.Visible = False
        '
        'Reserve2calDataGridViewTextBoxColumn
        '
        Me.Reserve2calDataGridViewTextBoxColumn.DataPropertyName = "reserve2_cal"
        Me.Reserve2calDataGridViewTextBoxColumn.HeaderText = "reserve2_cal"
        Me.Reserve2calDataGridViewTextBoxColumn.Name = "Reserve2calDataGridViewTextBoxColumn"
        Me.Reserve2calDataGridViewTextBoxColumn.Visible = False
        '
        'Reserve2reelDataGridViewTextBoxColumn
        '
        Me.Reserve2reelDataGridViewTextBoxColumn.DataPropertyName = "reserve2_reel"
        Me.Reserve2reelDataGridViewTextBoxColumn.HeaderText = "reserve2_reel"
        Me.Reserve2reelDataGridViewTextBoxColumn.Name = "Reserve2reelDataGridViewTextBoxColumn"
        Me.Reserve2reelDataGridViewTextBoxColumn.Visible = False
        '
        'VirtuelDataGridViewTextBoxColumn
        '
        Me.VirtuelDataGridViewTextBoxColumn.DataPropertyName = "virtuel"
        Me.VirtuelDataGridViewTextBoxColumn.HeaderText = "virtuel"
        Me.VirtuelDataGridViewTextBoxColumn.Name = "VirtuelDataGridViewTextBoxColumn"
        Me.VirtuelDataGridViewTextBoxColumn.Visible = False
        '
        'SallesidsalleDataGridViewTextBoxColumn
        '
        Me.SallesidsalleDataGridViewTextBoxColumn.DataPropertyName = "salles_idsalle"
        Me.SallesidsalleDataGridViewTextBoxColumn.HeaderText = "salles_idsalle"
        Me.SallesidsalleDataGridViewTextBoxColumn.Name = "SallesidsalleDataGridViewTextBoxColumn"
        Me.SallesidsalleDataGridViewTextBoxColumn.Visible = False
        '
        'RemplissageDataGridViewTextBoxColumn
        '
        Me.RemplissageDataGridViewTextBoxColumn.DataPropertyName = "remplissage"
        Me.RemplissageDataGridViewTextBoxColumn.HeaderText = "remplissage"
        Me.RemplissageDataGridViewTextBoxColumn.Name = "RemplissageDataGridViewTextBoxColumn"
        Me.RemplissageDataGridViewTextBoxColumn.Visible = False
        '
        'Remplissage2DataGridViewTextBoxColumn
        '
        Me.Remplissage2DataGridViewTextBoxColumn.DataPropertyName = "remplissage2"
        Me.Remplissage2DataGridViewTextBoxColumn.HeaderText = "remplissage2"
        Me.Remplissage2DataGridViewTextBoxColumn.Name = "Remplissage2DataGridViewTextBoxColumn"
        Me.Remplissage2DataGridViewTextBoxColumn.Visible = False
        '
        'Remplissage3DataGridViewTextBoxColumn
        '
        Me.Remplissage3DataGridViewTextBoxColumn.DataPropertyName = "remplissage3"
        Me.Remplissage3DataGridViewTextBoxColumn.HeaderText = "remplissage3"
        Me.Remplissage3DataGridViewTextBoxColumn.Name = "Remplissage3DataGridViewTextBoxColumn"
        Me.Remplissage3DataGridViewTextBoxColumn.Visible = False
        '
        'DiscriminationDataGridViewTextBoxColumn
        '
        Me.DiscriminationDataGridViewTextBoxColumn.DataPropertyName = "discrimination"
        Me.DiscriminationDataGridViewTextBoxColumn.HeaderText = "discrimination"
        Me.DiscriminationDataGridViewTextBoxColumn.Name = "DiscriminationDataGridViewTextBoxColumn"
        Me.DiscriminationDataGridViewTextBoxColumn.Visible = False
        '
        'RemarqueDataGridViewTextBoxColumn
        '
        Me.RemarqueDataGridViewTextBoxColumn.DataPropertyName = "remarque"
        Me.RemarqueDataGridViewTextBoxColumn.HeaderText = "remarque"
        Me.RemarqueDataGridViewTextBoxColumn.Name = "RemarqueDataGridViewTextBoxColumn"
        Me.RemarqueDataGridViewTextBoxColumn.Visible = False
        '
        'Lst_trc_salleBindingSource
        '
        Me.Lst_trc_salleBindingSource.DataMember = "lst_trc_salle"
        Me.Lst_trc_salleBindingSource.DataSource = Me.MydbDataSet1
        '
        'SuperTabItem2
        '
        Me.SuperTabItem2.AttachedControl = Me.SuperTabControlPanel2
        Me.SuperTabItem2.GlobalItem = False
        Me.SuperTabItem2.Name = "SuperTabItem2"
        Me.SuperTabItem2.Text = "Tronçons"
        '
        'SallesTableAdapter
        '
        Me.SallesTableAdapter.ClearBeforeFill = True
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
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
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
        Me.TableAdapterManager.equip_pose_articleTableAdapter = Nothing
        Me.TableAdapterManager.equipements_dispo_histoTableAdapter = Nothing
        Me.TableAdapterManager.equipements_dispoTableAdapter = Nothing
        Me.TableAdapterManager.equipements_has_fournituresTableAdapter = Nothing
        Me.TableAdapterManager.equipements_modifTableAdapter = Nothing
        Me.TableAdapterManager.equipementsTableAdapter = Me.EquipementsTableAdapter
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
        Me.TableAdapterManager.sallesTableAdapter = Me.SallesTableAdapter
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
        'EquipementsTableAdapter
        '
        Me.EquipementsTableAdapter.ClearBeforeFill = True
        '
        'Repere_salleTextBox
        '
        Me.Repere_salleTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.SallesBindingSource, "repere salle", True))
        Me.Repere_salleTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Repere_salleTextBox.ForeColor = System.Drawing.Color.Red
        Me.Highlighter1.SetHighlightOnFocus(Me.Repere_salleTextBox, True)
        Me.Repere_salleTextBox.Location = New System.Drawing.Point(244, 72)
        Me.Repere_salleTextBox.Name = "Repere_salleTextBox"
        Me.Repere_salleTextBox.Size = New System.Drawing.Size(197, 32)
        Me.Repere_salleTextBox.TabIndex = 7
        Me.SuperValidator1.SetValidator1(Me.Repere_salleTextBox, Me.RequiredFieldValidator1)
        Me.SuperValidator1.SetValidator2(Me.Repere_salleTextBox, Me.CustomValidator1)
        '
        'NiveauTextBox
        '
        Me.NiveauTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.SallesBindingSource, "Niveau", True))
        Me.Highlighter1.SetHighlightOnFocus(Me.NiveauTextBox, True)
        Me.NiveauTextBox.Location = New System.Drawing.Point(470, 81)
        Me.NiveauTextBox.Name = "NiveauTextBox"
        Me.NiveauTextBox.Size = New System.Drawing.Size(41, 20)
        Me.NiveauTextBox.TabIndex = 9
        Me.SuperValidator1.SetValidator1(Me.NiveauTextBox, Me.RequiredFieldValidator2)
        '
        'DesignationTextBox
        '
        Me.DesignationTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.SallesBindingSource, "designation", True))
        Me.Highlighter1.SetHighlightOnFocus(Me.DesignationTextBox, True)
        Me.DesignationTextBox.Location = New System.Drawing.Point(89, 128)
        Me.DesignationTextBox.Multiline = True
        Me.DesignationTextBox.Name = "DesignationTextBox"
        Me.DesignationTextBox.Size = New System.Drawing.Size(371, 83)
        Me.DesignationTextBox.TabIndex = 11
        '
        'HauteurTextBox
        '
        Me.HauteurTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.SallesBindingSource, "Hauteur", True))
        Me.HauteurTextBox.Location = New System.Drawing.Point(547, 81)
        Me.HauteurTextBox.Name = "HauteurTextBox"
        Me.HauteurTextBox.Size = New System.Drawing.Size(100, 20)
        Me.HauteurTextBox.TabIndex = 13
        '
        'LargeurTextBox
        '
        Me.LargeurTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.SallesBindingSource, "Largeur", True))
        Me.LargeurTextBox.Location = New System.Drawing.Point(653, 81)
        Me.LargeurTextBox.Name = "LargeurTextBox"
        Me.LargeurTextBox.Size = New System.Drawing.Size(100, 20)
        Me.LargeurTextBox.TabIndex = 15
        '
        'LongueurTextBox
        '
        Me.LongueurTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.SallesBindingSource, "Longueur", True))
        Me.LongueurTextBox.Location = New System.Drawing.Point(759, 81)
        Me.LongueurTextBox.Name = "LongueurTextBox"
        Me.LongueurTextBox.Size = New System.Drawing.Size(100, 20)
        Me.LongueurTextBox.TabIndex = 17
        '
        'DateDateTimePicker
        '
        Me.DateDateTimePicker.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.SallesBindingSource, "Date", True))
        Me.DateDateTimePicker.Location = New System.Drawing.Point(357, 11)
        Me.DateDateTimePicker.Name = "DateDateTimePicker"
        Me.DateDateTimePicker.Size = New System.Drawing.Size(200, 20)
        Me.DateDateTimePicker.TabIndex = 5
        '
        'QuiTextBox
        '
        Me.QuiTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.SallesBindingSource, "Qui", True))
        Me.QuiTextBox.Location = New System.Drawing.Point(187, 11)
        Me.QuiTextBox.Name = "QuiTextBox"
        Me.QuiTextBox.Size = New System.Drawing.Size(100, 20)
        Me.QuiTextBox.TabIndex = 3
        '
        'RevTextBox
        '
        Me.RevTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.SallesBindingSource, "version", True))
        Me.RevTextBox.Location = New System.Drawing.Point(44, 11)
        Me.RevTextBox.Name = "RevTextBox"
        Me.RevTextBox.Size = New System.Drawing.Size(100, 20)
        Me.RevTextBox.TabIndex = 1
        '
        'Lst_trc_salleTableAdapter
        '
        Me.Lst_trc_salleTableAdapter.ClearBeforeFill = True
        '
        'IdsalleTextBox
        '
        Me.IdsalleTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.SallesBindingSource, "idsalle", True))
        Me.IdsalleTextBox.Enabled = False
        Me.IdsalleTextBox.Location = New System.Drawing.Point(810, 8)
        Me.IdsalleTextBox.Name = "IdsalleTextBox"
        Me.IdsalleTextBox.Size = New System.Drawing.Size(100, 20)
        Me.IdsalleTextBox.TabIndex = 21
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX1.Location = New System.Drawing.Point(1141, 22)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Size = New System.Drawing.Size(126, 47)
        Me.ButtonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX1.TabIndex = 22
        Me.ButtonX1.Text = "Ajout :"
        '
        'ButtonX2
        '
        Me.ButtonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX2.Location = New System.Drawing.Point(1141, 105)
        Me.ButtonX2.Name = "ButtonX2"
        Me.ButtonX2.Size = New System.Drawing.Size(126, 47)
        Me.ButtonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX2.TabIndex = 23
        Me.ButtonX2.Text = "Modiffications :"
        '
        'ButtonX3
        '
        Me.ButtonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX3.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX3.Location = New System.Drawing.Point(1141, 193)
        Me.ButtonX3.Name = "ButtonX3"
        Me.ButtonX3.Size = New System.Drawing.Size(126, 47)
        Me.ButtonX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX3.TabIndex = 24
        Me.ButtonX3.Text = "Supression"
        '
        'SuperValidator1
        '
        Me.SuperValidator1.ContainerControl = Me
        Me.SuperValidator1.ErrorProvider = Me.ErrorProvider1
        Me.SuperValidator1.Highlighter = Me.Highlighter1
        Me.SuperValidator1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        '
        'RequiredFieldValidator1
        '
        Me.RequiredFieldValidator1.ErrorMessage = "Your error message here."
        Me.RequiredFieldValidator1.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red
        '
        'CustomValidator1
        '
        Me.CustomValidator1.ErrorMessage = "Nom de sale Existant Merci de corriger"
        Me.CustomValidator1.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red
        '
        'RequiredFieldValidator2
        '
        Me.RequiredFieldValidator2.ErrorMessage = "Champ Obligatoire."
        Me.RequiredFieldValidator2.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        Me.ErrorProvider1.Icon = CType(resources.GetObject("ErrorProvider1.Icon"), System.Drawing.Icon)
        '
        'Highlighter1
        '
        Me.Highlighter1.ContainerControl = Me
        Me.Highlighter1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        '
        'ComboBoxEx1
        '
        Me.ComboBoxEx1.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.SallesBindingSource, "Batiments_idBatiment", True))
        Me.ComboBoxEx1.DataSource = Me.BatimentsBindingSource
        Me.ComboBoxEx1.DisplayMember = "Nom"
        Me.ComboBoxEx1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBoxEx1.FormattingEnabled = True
        Me.Highlighter1.SetHighlightOnFocus(Me.ComboBoxEx1, True)
        Me.ComboBoxEx1.ItemHeight = 14
        Me.ComboBoxEx1.Location = New System.Drawing.Point(89, 81)
        Me.ComboBoxEx1.Name = "ComboBoxEx1"
        Me.ComboBoxEx1.Size = New System.Drawing.Size(121, 20)
        Me.ComboBoxEx1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ComboBoxEx1.TabIndex = 25
        Me.SuperValidator1.SetValidator1(Me.ComboBoxEx1, Me.RequiredFieldValidator3)
        Me.ComboBoxEx1.ValueMember = "idBatiment"
        '
        'BatimentsBindingSource
        '
        Me.BatimentsBindingSource.DataMember = "batiments"
        Me.BatimentsBindingSource.DataSource = Me.MydbDataSet1
        '
        'RequiredFieldValidator3
        '
        Me.RequiredFieldValidator3.ErrorMessage = "Veuillez selectionner un batiment"
        Me.RequiredFieldValidator3.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red
        '
        'BatimentsTableAdapter
        '
        Me.BatimentsTableAdapter.ClearBeforeFill = True
        '
        'ReflectionImage1
        '
        '
        '
        '
        Me.ReflectionImage1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionImage1.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.ReflectionImage1.Image = Global.progelec.My.Resources.Resources.home_info
        Me.ReflectionImage1.Location = New System.Drawing.Point(729, 117)
        Me.ReflectionImage1.Name = "ReflectionImage1"
        Me.ReflectionImage1.Size = New System.Drawing.Size(130, 111)
        Me.ReflectionImage1.TabIndex = 26
        '
        'ButtonX4
        '
        Me.ButtonX4.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX4.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX4.Image = Global.progelec.My.Resources.Resources.add_2_24_24
        Me.ButtonX4.Location = New System.Drawing.Point(208, 81)
        Me.ButtonX4.Name = "ButtonX4"
        Me.ButtonX4.Size = New System.Drawing.Size(30, 32)
        Me.ButtonX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX4.TabIndex = 27
        '
        'CablesBindingSource
        '
        Me.CablesBindingSource.DataMember = "cables"
        Me.CablesBindingSource.DataSource = Me.MydbDataSet1
        '
        'CablesTableAdapter
        '
        Me.CablesTableAdapter.ClearBeforeFill = True
        '
        'TronconsBindingSource
        '
        Me.TronconsBindingSource.DataMember = "troncons"
        Me.TronconsBindingSource.DataSource = Me.MydbDataSet1
        '
        'TronconsTableAdapter
        '
        Me.TronconsTableAdapter.ClearBeforeFill = True
        '
        'FormSalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1290, 615)
        Me.Controls.Add(Me.ButtonX4)
        Me.Controls.Add(Me.ReflectionImage1)
        Me.Controls.Add(Me.ComboBoxEx1)
        Me.Controls.Add(Me.ButtonX3)
        Me.Controls.Add(Me.ButtonX2)
        Me.Controls.Add(Me.ButtonX1)
        Me.Controls.Add(Me.IdsalleTextBox)
        Me.Controls.Add(DateLabel)
        Me.Controls.Add(QuiLabel)
        Me.Controls.Add(Me.DateDateTimePicker)
        Me.Controls.Add(RevLabel)
        Me.Controls.Add(Me.QuiTextBox)
        Me.Controls.Add(Me.RevTextBox)
        Me.Controls.Add(LongueurLabel)
        Me.Controls.Add(Me.LongueurTextBox)
        Me.Controls.Add(LargeurLabel)
        Me.Controls.Add(Me.LargeurTextBox)
        Me.Controls.Add(HauteurLabel)
        Me.Controls.Add(Me.HauteurTextBox)
        Me.Controls.Add(DesignationLabel)
        Me.Controls.Add(Me.DesignationTextBox)
        Me.Controls.Add(NiveauLabel)
        Me.Controls.Add(Me.NiveauTextBox)
        Me.Controls.Add(Label1)
        Me.Controls.Add(Repere_salleLabel)
        Me.Controls.Add(Me.Repere_salleTextBox)
        Me.Controls.Add(Me.SuperTabControl1)
        Me.Name = "FormSalle"
        Me.Text = "Salle ."
        CType(Me.MydbDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SuperTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControl1.ResumeLayout(False)
        Me.SuperTabControlPanel1.ResumeLayout(False)
        CType(Me.EquipementsDataGridViewX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EquipementsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SallesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControlPanel3.ResumeLayout(False)
        CType(Me.DataGridViewX1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControlPanel4.ResumeLayout(False)
        Me.SuperTabControlPanel4.PerformLayout()
        Me.SuperTabControlPanel2.ResumeLayout(False)
        CType(Me.TronconsDataGridViewX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Lst_trc_salleBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BatimentsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CablesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TronconsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MydbDataSet1 As progelec.mydbDataSet
    Friend WithEvents SuperTabControl1 As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents SuperTabControlPanel1 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SuperTabItem1 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel4 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SuperTabItem4 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel3 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SuperTabItem3 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel2 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SuperTabItem2 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SallesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SallesTableAdapter As progelec.mydbDataSetTableAdapters.sallesTableAdapter
    Friend WithEvents TableAdapterManager As progelec.mydbDataSetTableAdapters.TableAdapterManager
    Friend WithEvents QuiTextBox As System.Windows.Forms.TextBox
    Friend WithEvents DateDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents DCCTextBox As System.Windows.Forms.TextBox
    Friend WithEvents EquipementsTableAdapter As progelec.mydbDataSetTableAdapters.equipementsTableAdapter
    Friend WithEvents Repere_salleTextBox As System.Windows.Forms.TextBox
    Friend WithEvents NiveauTextBox As System.Windows.Forms.TextBox
    Friend WithEvents DesignationTextBox As System.Windows.Forms.TextBox
    Friend WithEvents HauteurTextBox As System.Windows.Forms.TextBox
    Friend WithEvents LargeurTextBox As System.Windows.Forms.TextBox
    Friend WithEvents LongueurTextBox As System.Windows.Forms.TextBox
    Friend WithEvents RevTextBox As System.Windows.Forms.TextBox
    Friend WithEvents EquipementsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EquipementsDataGridViewX As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents TronconsDataGridViewX As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewX1 As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Lst_trc_salleBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Lst_trc_salleTableAdapter As progelec.mydbDataSetTableAdapters.lst_trc_salleTableAdapter
    Friend WithEvents IdtronconsDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RepereTronconDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SallesDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SegregationsidsegregationsDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LargeurDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LongueurDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HauteurDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ElevationDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReservesDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Reserves2DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FormesDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MargesHDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MargesLDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DiametreDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VersionDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuiDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TypestronconsidTypestronconsDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReservecalDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReservereelDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DatecalculDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Reserve2calDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Reserve2reelDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VirtuelDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SallesidsalleDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RemplissageDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Remplissage2DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Remplissage3DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DiscriminationDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RemarqueDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdsalleTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX2 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX3 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents SuperValidator1 As DevComponents.DotNetBar.Validator.SuperValidator
    Friend WithEvents RequiredFieldValidator2 As DevComponents.DotNetBar.Validator.RequiredFieldValidator
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Highlighter1 As DevComponents.DotNetBar.Validator.Highlighter
    Friend WithEvents BatimentsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents BatimentsTableAdapter As progelec.mydbDataSetTableAdapters.batimentsTableAdapter
    Friend WithEvents ComboBoxEx1 As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents RequiredFieldValidator3 As DevComponents.DotNetBar.Validator.RequiredFieldValidator
    Friend WithEvents CustomValidator1 As DevComponents.DotNetBar.Validator.CustomValidator
    Friend WithEvents RequiredFieldValidator1 As DevComponents.DotNetBar.Validator.RequiredFieldValidator
    Friend WithEvents ReflectionImage1 As DevComponents.DotNetBar.Controls.ReflectionImage
    Friend WithEvents ButtonX4 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents CablesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CablesTableAdapter As progelec.mydbDataSetTableAdapters.cablesTableAdapter
    Friend WithEvents TronconsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TronconsTableAdapter As progelec.mydbDataSetTableAdapters.tronconsTableAdapter
End Class
