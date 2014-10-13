<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormFournitures_lst
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
        Dim DesignationLabel As System.Windows.Forms.Label
        Dim CategorieLabel As System.Windows.Forms.Label
        Dim Quant_minLabel As System.Windows.Forms.Label
        Dim FournisseurLabel As System.Windows.Forms.Label
        Dim UniteeLabel As System.Windows.Forms.Label
        Dim LongueurLabel As System.Windows.Forms.Label
        Dim LargeurLabel As System.Windows.Forms.Label
        Dim HauteurLabel As System.Windows.Forms.Label
        Dim ProfondeurLabel As System.Windows.Forms.Label
        Dim MasseLabel As System.Windows.Forms.Label
        Dim Liste_TronconLabel As System.Windows.Forms.Label
        Dim Liste_cableLabel As System.Windows.Forms.Label
        Dim Liste_equipementLabel As System.Windows.Forms.Label
        Dim DiametreLabel As System.Windows.Forms.Label
        Dim MatiereLabel As System.Windows.Forms.Label
        Dim TempPoseMetreLabel As System.Windows.Forms.Label
        Dim TempPoseUnitaireLabel As System.Windows.Forms.Label
        Dim Label1 As System.Windows.Forms.Label
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.FournituresBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MydbDataSet = New progelec.mydbDataSet()
        Me.FournituresDataGridViewX = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.IdfournitureDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CategorieDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DesignationDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QuantminDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FournisseurDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UniteeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LongueurDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LargeurDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HauteurDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProfondeurDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MasseDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ListeTronconDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ListecableDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ListeequipementDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DiametreDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MatiereDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TempPoseMetreDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TempPoseUnitaireDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DesignationTextBox = New System.Windows.Forms.TextBox()
        Me.Quant_minTextBox = New System.Windows.Forms.TextBox()
        Me.LongueurTextBox = New System.Windows.Forms.TextBox()
        Me.LargeurTextBox = New System.Windows.Forms.TextBox()
        Me.HauteurTextBox = New System.Windows.Forms.TextBox()
        Me.ProfondeurTextBox = New System.Windows.Forms.TextBox()
        Me.MasseTextBox = New System.Windows.Forms.TextBox()
        Me.Liste_TronconCheckBox = New System.Windows.Forms.CheckBox()
        Me.Liste_cableCheckBox = New System.Windows.Forms.CheckBox()
        Me.Liste_equipementCheckBox = New System.Windows.Forms.CheckBox()
        Me.DiametreTextBox = New System.Windows.Forms.TextBox()
        Me.ButtonX2 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX3 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.ComboBoxEx1 = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.ComboItem1 = New DevComponents.Editors.ComboItem()
        Me.ComboItem2 = New DevComponents.Editors.ComboItem()
        Me.ComboItem3 = New DevComponents.Editors.ComboItem()
        Me.ComboItem4 = New DevComponents.Editors.ComboItem()
        Me.CABLE = New DevComponents.Editors.ComboItem()
        Me.DALLE = New DevComponents.Editors.ComboItem()
        Me.TUBE = New DevComponents.Editors.ComboItem()
        Me.ECHELLE = New DevComponents.Editors.ComboItem()
        Me.TOURET = New DevComponents.Editors.ComboItem()
        Me.DIVERS = New DevComponents.Editors.ComboItem()
        Me.COSSES = New DevComponents.Editors.ComboItem()
        Me.MESURES = New DevComponents.Editors.ComboItem()
        Me.EQUIPEMENTS = New DevComponents.Editors.ComboItem()
        Me.MATERIELS = New DevComponents.Editors.ComboItem()
        Me.FournituresTableAdapter = New progelec.mydbDataSetTableAdapters.fournituresTableAdapter()
        Me.TableAdapterManager = New progelec.mydbDataSetTableAdapters.TableAdapterManager()
        Me.ComboBoxEx2 = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.ComboItem5 = New DevComponents.Editors.ComboItem()
        Me.ComboItem6 = New DevComponents.Editors.ComboItem()
        Me.ComboItem7 = New DevComponents.Editors.ComboItem()
        Me.ComboItem8 = New DevComponents.Editors.ComboItem()
        Me.ComboBoxEx3 = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.ComboItem9 = New DevComponents.Editors.ComboItem()
        Me.ComboItem10 = New DevComponents.Editors.ComboItem()
        Me.ComboItem11 = New DevComponents.Editors.ComboItem()
        Me.ComboItem12 = New DevComponents.Editors.ComboItem()
        Me.ComboItem13 = New DevComponents.Editors.ComboItem()
        Me.ComboItem14 = New DevComponents.Editors.ComboItem()
        Me.FournisseursBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.FournisseursTableAdapter = New progelec.mydbDataSetTableAdapters.fournisseursTableAdapter()
        Me.ComboBoxEx4 = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.ButtonX4 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX5 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX6 = New DevComponents.DotNetBar.ButtonX()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.ButtonXaddfournisseur = New DevComponents.DotNetBar.ButtonX()
        DesignationLabel = New System.Windows.Forms.Label()
        CategorieLabel = New System.Windows.Forms.Label()
        Quant_minLabel = New System.Windows.Forms.Label()
        FournisseurLabel = New System.Windows.Forms.Label()
        UniteeLabel = New System.Windows.Forms.Label()
        LongueurLabel = New System.Windows.Forms.Label()
        LargeurLabel = New System.Windows.Forms.Label()
        HauteurLabel = New System.Windows.Forms.Label()
        ProfondeurLabel = New System.Windows.Forms.Label()
        MasseLabel = New System.Windows.Forms.Label()
        Liste_TronconLabel = New System.Windows.Forms.Label()
        Liste_cableLabel = New System.Windows.Forms.Label()
        Liste_equipementLabel = New System.Windows.Forms.Label()
        DiametreLabel = New System.Windows.Forms.Label()
        MatiereLabel = New System.Windows.Forms.Label()
        TempPoseMetreLabel = New System.Windows.Forms.Label()
        TempPoseUnitaireLabel = New System.Windows.Forms.Label()
        Label1 = New System.Windows.Forms.Label()
        CType(Me.FournituresBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MydbDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FournituresDataGridViewX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FournisseursBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DesignationLabel
        '
        DesignationLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DesignationLabel.AutoSize = True
        DesignationLabel.Location = New System.Drawing.Point(954, 196)
        DesignationLabel.Name = "DesignationLabel"
        DesignationLabel.Size = New System.Drawing.Size(64, 13)
        DesignationLabel.TabIndex = 4
        DesignationLabel.Text = "designation:"
        '
        'CategorieLabel
        '
        CategorieLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        CategorieLabel.AutoSize = True
        CategorieLabel.Location = New System.Drawing.Point(954, 144)
        CategorieLabel.Name = "CategorieLabel"
        CategorieLabel.Size = New System.Drawing.Size(55, 13)
        CategorieLabel.TabIndex = 6
        CategorieLabel.Text = "Categorie:"
        '
        'Quant_minLabel
        '
        Quant_minLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Quant_minLabel.AutoSize = True
        Quant_minLabel.Location = New System.Drawing.Point(954, 230)
        Quant_minLabel.Name = "Quant_minLabel"
        Quant_minLabel.Size = New System.Drawing.Size(56, 13)
        Quant_minLabel.TabIndex = 8
        Quant_minLabel.Text = "quant min:"
        '
        'FournisseurLabel
        '
        FournisseurLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        FournisseurLabel.AutoSize = True
        FournisseurLabel.Location = New System.Drawing.Point(954, 274)
        FournisseurLabel.Name = "FournisseurLabel"
        FournisseurLabel.Size = New System.Drawing.Size(61, 13)
        FournisseurLabel.TabIndex = 10
        FournisseurLabel.Text = "fournisseur:"
        '
        'UniteeLabel
        '
        UniteeLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        UniteeLabel.AutoSize = True
        UniteeLabel.Location = New System.Drawing.Point(954, 300)
        UniteeLabel.Name = "UniteeLabel"
        UniteeLabel.Size = New System.Drawing.Size(39, 13)
        UniteeLabel.TabIndex = 12
        UniteeLabel.Text = "unitee:"
        '
        'LongueurLabel
        '
        LongueurLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        LongueurLabel.AutoSize = True
        LongueurLabel.Location = New System.Drawing.Point(954, 326)
        LongueurLabel.Name = "LongueurLabel"
        LongueurLabel.Size = New System.Drawing.Size(55, 13)
        LongueurLabel.TabIndex = 14
        LongueurLabel.Text = "Longueur:"
        '
        'LargeurLabel
        '
        LargeurLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        LargeurLabel.AutoSize = True
        LargeurLabel.Location = New System.Drawing.Point(954, 352)
        LargeurLabel.Name = "LargeurLabel"
        LargeurLabel.Size = New System.Drawing.Size(42, 13)
        LargeurLabel.TabIndex = 16
        LargeurLabel.Text = "largeur:"
        '
        'HauteurLabel
        '
        HauteurLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        HauteurLabel.AutoSize = True
        HauteurLabel.Location = New System.Drawing.Point(954, 378)
        HauteurLabel.Name = "HauteurLabel"
        HauteurLabel.Size = New System.Drawing.Size(48, 13)
        HauteurLabel.TabIndex = 18
        HauteurLabel.Text = "Hauteur:"
        '
        'ProfondeurLabel
        '
        ProfondeurLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ProfondeurLabel.AutoSize = True
        ProfondeurLabel.Location = New System.Drawing.Point(954, 404)
        ProfondeurLabel.Name = "ProfondeurLabel"
        ProfondeurLabel.Size = New System.Drawing.Size(61, 13)
        ProfondeurLabel.TabIndex = 20
        ProfondeurLabel.Text = "profondeur:"
        '
        'MasseLabel
        '
        MasseLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        MasseLabel.AutoSize = True
        MasseLabel.Location = New System.Drawing.Point(954, 430)
        MasseLabel.Name = "MasseLabel"
        MasseLabel.Size = New System.Drawing.Size(40, 13)
        MasseLabel.TabIndex = 22
        MasseLabel.Text = "masse:"
        '
        'Liste_TronconLabel
        '
        Liste_TronconLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Liste_TronconLabel.AutoSize = True
        Liste_TronconLabel.Location = New System.Drawing.Point(953, 481)
        Liste_TronconLabel.Name = "Liste_TronconLabel"
        Liste_TronconLabel.Size = New System.Drawing.Size(71, 13)
        Liste_TronconLabel.TabIndex = 24
        Liste_TronconLabel.Text = "liste Troncon:"
        '
        'Liste_cableLabel
        '
        Liste_cableLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Liste_cableLabel.AutoSize = True
        Liste_cableLabel.Location = New System.Drawing.Point(953, 511)
        Liste_cableLabel.Name = "Liste_cableLabel"
        Liste_cableLabel.Size = New System.Drawing.Size(57, 13)
        Liste_cableLabel.TabIndex = 26
        Liste_cableLabel.Text = "liste cable:"
        '
        'Liste_equipementLabel
        '
        Liste_equipementLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Liste_equipementLabel.AutoSize = True
        Liste_equipementLabel.Location = New System.Drawing.Point(953, 541)
        Liste_equipementLabel.Name = "Liste_equipementLabel"
        Liste_equipementLabel.Size = New System.Drawing.Size(86, 13)
        Liste_equipementLabel.TabIndex = 28
        Liste_equipementLabel.Text = "liste equipement:"
        '
        'DiametreLabel
        '
        DiametreLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DiametreLabel.AutoSize = True
        DiametreLabel.Location = New System.Drawing.Point(954, 456)
        DiametreLabel.Name = "DiametreLabel"
        DiametreLabel.Size = New System.Drawing.Size(50, 13)
        DiametreLabel.TabIndex = 30
        DiametreLabel.Text = "diametre:"
        '
        'MatiereLabel
        '
        MatiereLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        MatiereLabel.AutoSize = True
        MatiereLabel.Location = New System.Drawing.Point(954, 572)
        MatiereLabel.Name = "MatiereLabel"
        MatiereLabel.Size = New System.Drawing.Size(45, 13)
        MatiereLabel.TabIndex = 32
        MatiereLabel.Text = "Matiere:"
        '
        'TempPoseMetreLabel
        '
        TempPoseMetreLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        TempPoseMetreLabel.AutoSize = True
        TempPoseMetreLabel.Location = New System.Drawing.Point(946, 608)
        TempPoseMetreLabel.Name = "TempPoseMetreLabel"
        TempPoseMetreLabel.Size = New System.Drawing.Size(94, 13)
        TempPoseMetreLabel.TabIndex = 39
        TempPoseMetreLabel.Text = "Temp Pose Metre:"
        '
        'TempPoseUnitaireLabel
        '
        TempPoseUnitaireLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        TempPoseUnitaireLabel.AutoSize = True
        TempPoseUnitaireLabel.Location = New System.Drawing.Point(937, 634)
        TempPoseUnitaireLabel.Name = "TempPoseUnitaireLabel"
        TempPoseUnitaireLabel.Size = New System.Drawing.Size(103, 13)
        TempPoseUnitaireLabel.TabIndex = 40
        TempPoseUnitaireLabel.Text = "Temp Pose Unitaire:"
        '
        'Label1
        '
        Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(1155, 481)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(66, 13)
        Label1.TabIndex = 28
        Label1.Text = "liste trourets:"
        '
        'FournituresBindingSource
        '
        Me.FournituresBindingSource.DataMember = "fournitures"
        Me.FournituresBindingSource.DataSource = Me.MydbDataSet
        '
        'MydbDataSet
        '
        Me.MydbDataSet.DataSetName = "mydbDataSet"
        Me.MydbDataSet.EnforceConstraints = False
        Me.MydbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'FournituresDataGridViewX
        '
        Me.FournituresDataGridViewX.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FournituresDataGridViewX.AutoGenerateColumns = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.FournituresDataGridViewX.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.FournituresDataGridViewX.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.FournituresDataGridViewX.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdfournitureDataGridViewTextBoxColumn, Me.CategorieDataGridViewTextBoxColumn, Me.DesignationDataGridViewTextBoxColumn, Me.QuantminDataGridViewTextBoxColumn, Me.FournisseurDataGridViewTextBoxColumn, Me.UniteeDataGridViewTextBoxColumn, Me.LongueurDataGridViewTextBoxColumn, Me.LargeurDataGridViewTextBoxColumn, Me.HauteurDataGridViewTextBoxColumn, Me.ProfondeurDataGridViewTextBoxColumn, Me.MasseDataGridViewTextBoxColumn, Me.ListeTronconDataGridViewCheckBoxColumn, Me.ListecableDataGridViewCheckBoxColumn, Me.ListeequipementDataGridViewCheckBoxColumn, Me.DiametreDataGridViewTextBoxColumn, Me.MatiereDataGridViewTextBoxColumn, Me.TempPoseMetreDataGridViewTextBoxColumn, Me.TempPoseUnitaireDataGridViewTextBoxColumn})
        Me.FournituresDataGridViewX.DataSource = Me.FournituresBindingSource
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.FournituresDataGridViewX.DefaultCellStyle = DataGridViewCellStyle2
        Me.FournituresDataGridViewX.EnableHeadersVisualStyles = False
        Me.FournituresDataGridViewX.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.FournituresDataGridViewX.Location = New System.Drawing.Point(12, 106)
        Me.FournituresDataGridViewX.Name = "FournituresDataGridViewX"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.FournituresDataGridViewX.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.FournituresDataGridViewX.Size = New System.Drawing.Size(877, 582)
        Me.FournituresDataGridViewX.TabIndex = 1
        '
        'IdfournitureDataGridViewTextBoxColumn
        '
        Me.IdfournitureDataGridViewTextBoxColumn.DataPropertyName = "idfourniture"
        Me.IdfournitureDataGridViewTextBoxColumn.HeaderText = "idfourniture"
        Me.IdfournitureDataGridViewTextBoxColumn.Name = "IdfournitureDataGridViewTextBoxColumn"
        Me.IdfournitureDataGridViewTextBoxColumn.Visible = False
        '
        'CategorieDataGridViewTextBoxColumn
        '
        Me.CategorieDataGridViewTextBoxColumn.DataPropertyName = "Categorie"
        Me.CategorieDataGridViewTextBoxColumn.HeaderText = "Categorie"
        Me.CategorieDataGridViewTextBoxColumn.Name = "CategorieDataGridViewTextBoxColumn"
        '
        'DesignationDataGridViewTextBoxColumn
        '
        Me.DesignationDataGridViewTextBoxColumn.DataPropertyName = "designation"
        Me.DesignationDataGridViewTextBoxColumn.HeaderText = "designation"
        Me.DesignationDataGridViewTextBoxColumn.MinimumWidth = 100
        Me.DesignationDataGridViewTextBoxColumn.Name = "DesignationDataGridViewTextBoxColumn"
        '
        'QuantminDataGridViewTextBoxColumn
        '
        Me.QuantminDataGridViewTextBoxColumn.DataPropertyName = "quant_min"
        Me.QuantminDataGridViewTextBoxColumn.HeaderText = "quant_min"
        Me.QuantminDataGridViewTextBoxColumn.Name = "QuantminDataGridViewTextBoxColumn"
        '
        'FournisseurDataGridViewTextBoxColumn
        '
        Me.FournisseurDataGridViewTextBoxColumn.DataPropertyName = "fournisseur"
        Me.FournisseurDataGridViewTextBoxColumn.HeaderText = "fournisseur"
        Me.FournisseurDataGridViewTextBoxColumn.Name = "FournisseurDataGridViewTextBoxColumn"
        '
        'UniteeDataGridViewTextBoxColumn
        '
        Me.UniteeDataGridViewTextBoxColumn.DataPropertyName = "unitee"
        Me.UniteeDataGridViewTextBoxColumn.HeaderText = "unitee"
        Me.UniteeDataGridViewTextBoxColumn.Name = "UniteeDataGridViewTextBoxColumn"
        '
        'LongueurDataGridViewTextBoxColumn
        '
        Me.LongueurDataGridViewTextBoxColumn.DataPropertyName = "Longueur"
        Me.LongueurDataGridViewTextBoxColumn.HeaderText = "Longueur"
        Me.LongueurDataGridViewTextBoxColumn.Name = "LongueurDataGridViewTextBoxColumn"
        '
        'LargeurDataGridViewTextBoxColumn
        '
        Me.LargeurDataGridViewTextBoxColumn.DataPropertyName = "largeur"
        Me.LargeurDataGridViewTextBoxColumn.HeaderText = "largeur"
        Me.LargeurDataGridViewTextBoxColumn.Name = "LargeurDataGridViewTextBoxColumn"
        '
        'HauteurDataGridViewTextBoxColumn
        '
        Me.HauteurDataGridViewTextBoxColumn.DataPropertyName = "Hauteur"
        Me.HauteurDataGridViewTextBoxColumn.HeaderText = "Hauteur"
        Me.HauteurDataGridViewTextBoxColumn.Name = "HauteurDataGridViewTextBoxColumn"
        '
        'ProfondeurDataGridViewTextBoxColumn
        '
        Me.ProfondeurDataGridViewTextBoxColumn.DataPropertyName = "profondeur"
        Me.ProfondeurDataGridViewTextBoxColumn.HeaderText = "profondeur"
        Me.ProfondeurDataGridViewTextBoxColumn.Name = "ProfondeurDataGridViewTextBoxColumn"
        '
        'MasseDataGridViewTextBoxColumn
        '
        Me.MasseDataGridViewTextBoxColumn.DataPropertyName = "masse"
        Me.MasseDataGridViewTextBoxColumn.HeaderText = "masse"
        Me.MasseDataGridViewTextBoxColumn.Name = "MasseDataGridViewTextBoxColumn"
        '
        'ListeTronconDataGridViewCheckBoxColumn
        '
        Me.ListeTronconDataGridViewCheckBoxColumn.DataPropertyName = "liste_Troncon"
        Me.ListeTronconDataGridViewCheckBoxColumn.HeaderText = "liste_Troncon"
        Me.ListeTronconDataGridViewCheckBoxColumn.Name = "ListeTronconDataGridViewCheckBoxColumn"
        '
        'ListecableDataGridViewCheckBoxColumn
        '
        Me.ListecableDataGridViewCheckBoxColumn.DataPropertyName = "liste_cable"
        Me.ListecableDataGridViewCheckBoxColumn.HeaderText = "liste_cable"
        Me.ListecableDataGridViewCheckBoxColumn.Name = "ListecableDataGridViewCheckBoxColumn"
        '
        'ListeequipementDataGridViewCheckBoxColumn
        '
        Me.ListeequipementDataGridViewCheckBoxColumn.DataPropertyName = "liste_equipement"
        Me.ListeequipementDataGridViewCheckBoxColumn.HeaderText = "liste_equipement"
        Me.ListeequipementDataGridViewCheckBoxColumn.Name = "ListeequipementDataGridViewCheckBoxColumn"
        '
        'DiametreDataGridViewTextBoxColumn
        '
        Me.DiametreDataGridViewTextBoxColumn.DataPropertyName = "diametre"
        Me.DiametreDataGridViewTextBoxColumn.HeaderText = "diametre"
        Me.DiametreDataGridViewTextBoxColumn.Name = "DiametreDataGridViewTextBoxColumn"
        '
        'MatiereDataGridViewTextBoxColumn
        '
        Me.MatiereDataGridViewTextBoxColumn.DataPropertyName = "Matiere"
        Me.MatiereDataGridViewTextBoxColumn.HeaderText = "Matiere"
        Me.MatiereDataGridViewTextBoxColumn.Name = "MatiereDataGridViewTextBoxColumn"
        '
        'TempPoseMetreDataGridViewTextBoxColumn
        '
        Me.TempPoseMetreDataGridViewTextBoxColumn.DataPropertyName = "TempPoseMetre"
        Me.TempPoseMetreDataGridViewTextBoxColumn.HeaderText = "TempPoseMetre"
        Me.TempPoseMetreDataGridViewTextBoxColumn.Name = "TempPoseMetreDataGridViewTextBoxColumn"
        '
        'TempPoseUnitaireDataGridViewTextBoxColumn
        '
        Me.TempPoseUnitaireDataGridViewTextBoxColumn.DataPropertyName = "TempPoseUnitaire"
        Me.TempPoseUnitaireDataGridViewTextBoxColumn.HeaderText = "TempPoseUnitaire"
        Me.TempPoseUnitaireDataGridViewTextBoxColumn.Name = "TempPoseUnitaireDataGridViewTextBoxColumn"
        '
        'DesignationTextBox
        '
        Me.DesignationTextBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DesignationTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FournituresBindingSource, "designation", True))
        Me.DesignationTextBox.Location = New System.Drawing.Point(1046, 167)
        Me.DesignationTextBox.Multiline = True
        Me.DesignationTextBox.Name = "DesignationTextBox"
        Me.DesignationTextBox.Size = New System.Drawing.Size(352, 46)
        Me.DesignationTextBox.TabIndex = 5
        '
        'Quant_minTextBox
        '
        Me.Quant_minTextBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Quant_minTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FournituresBindingSource, "quant_min", True))
        Me.Quant_minTextBox.Location = New System.Drawing.Point(1046, 227)
        Me.Quant_minTextBox.Name = "Quant_minTextBox"
        Me.Quant_minTextBox.Size = New System.Drawing.Size(64, 20)
        Me.Quant_minTextBox.TabIndex = 9
        Me.Quant_minTextBox.Text = "1"
        '
        'LongueurTextBox
        '
        Me.LongueurTextBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LongueurTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FournituresBindingSource, "Longueur", True))
        Me.LongueurTextBox.Location = New System.Drawing.Point(1046, 323)
        Me.LongueurTextBox.Name = "LongueurTextBox"
        Me.LongueurTextBox.Size = New System.Drawing.Size(104, 20)
        Me.LongueurTextBox.TabIndex = 15
        '
        'LargeurTextBox
        '
        Me.LargeurTextBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LargeurTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FournituresBindingSource, "largeur", True))
        Me.LargeurTextBox.Location = New System.Drawing.Point(1046, 349)
        Me.LargeurTextBox.Name = "LargeurTextBox"
        Me.LargeurTextBox.Size = New System.Drawing.Size(104, 20)
        Me.LargeurTextBox.TabIndex = 17
        '
        'HauteurTextBox
        '
        Me.HauteurTextBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.HauteurTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FournituresBindingSource, "Hauteur", True))
        Me.HauteurTextBox.Location = New System.Drawing.Point(1046, 375)
        Me.HauteurTextBox.Name = "HauteurTextBox"
        Me.HauteurTextBox.Size = New System.Drawing.Size(104, 20)
        Me.HauteurTextBox.TabIndex = 19
        '
        'ProfondeurTextBox
        '
        Me.ProfondeurTextBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProfondeurTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FournituresBindingSource, "profondeur", True))
        Me.ProfondeurTextBox.Location = New System.Drawing.Point(1046, 401)
        Me.ProfondeurTextBox.Name = "ProfondeurTextBox"
        Me.ProfondeurTextBox.Size = New System.Drawing.Size(104, 20)
        Me.ProfondeurTextBox.TabIndex = 21
        '
        'MasseTextBox
        '
        Me.MasseTextBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MasseTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FournituresBindingSource, "masse", True))
        Me.MasseTextBox.Location = New System.Drawing.Point(1046, 427)
        Me.MasseTextBox.Name = "MasseTextBox"
        Me.MasseTextBox.Size = New System.Drawing.Size(104, 20)
        Me.MasseTextBox.TabIndex = 23
        '
        'Liste_TronconCheckBox
        '
        Me.Liste_TronconCheckBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Liste_TronconCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Liste_TronconCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.FournituresBindingSource, "liste_Troncon", True))
        Me.Liste_TronconCheckBox.Location = New System.Drawing.Point(1045, 476)
        Me.Liste_TronconCheckBox.Name = "Liste_TronconCheckBox"
        Me.Liste_TronconCheckBox.Size = New System.Drawing.Size(104, 24)
        Me.Liste_TronconCheckBox.TabIndex = 25
        Me.Liste_TronconCheckBox.UseVisualStyleBackColor = True
        '
        'Liste_cableCheckBox
        '
        Me.Liste_cableCheckBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Liste_cableCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Liste_cableCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.FournituresBindingSource, "liste_cable", True))
        Me.Liste_cableCheckBox.Location = New System.Drawing.Point(1045, 506)
        Me.Liste_cableCheckBox.Name = "Liste_cableCheckBox"
        Me.Liste_cableCheckBox.Size = New System.Drawing.Size(104, 24)
        Me.Liste_cableCheckBox.TabIndex = 27
        Me.Liste_cableCheckBox.UseVisualStyleBackColor = True
        '
        'Liste_equipementCheckBox
        '
        Me.Liste_equipementCheckBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Liste_equipementCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Liste_equipementCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.FournituresBindingSource, "liste_equipement", True))
        Me.Liste_equipementCheckBox.Location = New System.Drawing.Point(1045, 536)
        Me.Liste_equipementCheckBox.Name = "Liste_equipementCheckBox"
        Me.Liste_equipementCheckBox.Size = New System.Drawing.Size(104, 24)
        Me.Liste_equipementCheckBox.TabIndex = 29
        Me.Liste_equipementCheckBox.UseVisualStyleBackColor = True
        '
        'DiametreTextBox
        '
        Me.DiametreTextBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DiametreTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FournituresBindingSource, "diametre", True))
        Me.DiametreTextBox.Location = New System.Drawing.Point(1046, 453)
        Me.DiametreTextBox.Name = "DiametreTextBox"
        Me.DiametreTextBox.Size = New System.Drawing.Size(104, 20)
        Me.DiametreTextBox.TabIndex = 31
        '
        'ButtonX2
        '
        Me.ButtonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX2.Image = Global.progelec.My.Resources.Resources.remove_32_32
        Me.ButtonX2.Location = New System.Drawing.Point(1299, 624)
        Me.ButtonX2.Name = "ButtonX2"
        Me.ButtonX2.Size = New System.Drawing.Size(114, 48)
        Me.ButtonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX2.TabIndex = 36
        Me.ButtonX2.Text = "Suppression"
        '
        'ButtonX3
        '
        Me.ButtonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonX3.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX3.Image = Global.progelec.My.Resources.Resources.next_24_24
        Me.ButtonX3.Location = New System.Drawing.Point(1299, 52)
        Me.ButtonX3.Name = "ButtonX3"
        Me.ButtonX3.Size = New System.Drawing.Size(114, 48)
        Me.ButtonX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX3.TabIndex = 35
        Me.ButtonX3.Text = "Fermer"
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX1.Image = Global.progelec.My.Resources.Resources.add_1_32_32
        Me.ButtonX1.Location = New System.Drawing.Point(932, 52)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Size = New System.Drawing.Size(114, 48)
        Me.ButtonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX1.TabIndex = 34
        Me.ButtonX1.Text = "Ajout"
        '
        'ComboBoxEx1
        '
        Me.ComboBoxEx1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBoxEx1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FournituresBindingSource, "Categorie", True))
        Me.ComboBoxEx1.DisplayMember = "Text"
        Me.ComboBoxEx1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBoxEx1.FormattingEnabled = True
        Me.ComboBoxEx1.ItemHeight = 14
        Me.ComboBoxEx1.Items.AddRange(New Object() {Me.ComboItem1, Me.ComboItem2, Me.ComboItem3, Me.ComboItem4})
        Me.ComboBoxEx1.Location = New System.Drawing.Point(1046, 141)
        Me.ComboBoxEx1.Name = "ComboBoxEx1"
        Me.ComboBoxEx1.Size = New System.Drawing.Size(182, 20)
        Me.ComboBoxEx1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ComboBoxEx1.TabIndex = 37
        Me.ComboBoxEx1.ValueMember = "Categorie"
        '
        'ComboItem1
        '
        Me.ComboItem1.Text = "ECHELLE"
        Me.ComboItem1.Value = ""
        '
        'ComboItem2
        '
        Me.ComboItem2.Text = "DALLE"
        Me.ComboItem2.Value = ""
        '
        'ComboItem3
        '
        Me.ComboItem3.Text = "TUBE"
        '
        'ComboItem4
        '
        Me.ComboItem4.Text = "TOURET"
        '
        'CABLE
        '
        Me.CABLE.Text = "CABLE"
        Me.CABLE.Value = "CABLE"
        '
        'DALLE
        '
        Me.DALLE.Text = "DALLE"
        Me.DALLE.Value = "DALLE"
        '
        'TUBE
        '
        Me.TUBE.Text = "TUBE"
        Me.TUBE.Value = "TUBE"
        '
        'ECHELLE
        '
        Me.ECHELLE.Text = "ECHELLE"
        Me.ECHELLE.Value = "ECHELLE"
        '
        'TOURET
        '
        Me.TOURET.Text = "TOURET"
        Me.TOURET.Value = "TOURET"
        '
        'DIVERS
        '
        Me.DIVERS.Text = "DIVERS"
        Me.DIVERS.Value = "DIVERS"
        '
        'COSSES
        '
        Me.COSSES.Text = "COSSES"
        Me.COSSES.Value = "COSSES"
        '
        'MESURES
        '
        Me.MESURES.Text = "MESURES"
        Me.MESURES.Value = "MESURES"
        '
        'EQUIPEMENTS
        '
        Me.EQUIPEMENTS.Text = "EQUIPEMENTS"
        Me.EQUIPEMENTS.Value = "EQUIPEMENTS"
        '
        'MATERIELS
        '
        Me.MATERIELS.Text = "MATERIELS"
        Me.MATERIELS.Value = "MATERIELS"
        '
        'FournituresTableAdapter
        '
        Me.FournituresTableAdapter.ClearBeforeFill = True
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
        Me.TableAdapterManager.fournituresTableAdapter = Me.FournituresTableAdapter
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
        Me.TableAdapterManager.tronconsTableAdapter = Nothing
        Me.TableAdapterManager.type_docTableAdapter = Nothing
        Me.TableAdapterManager.types_cableTableAdapter = Nothing
        Me.TableAdapterManager.types_tronconsTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = progelec.mydbDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'ComboBoxEx2
        '
        Me.ComboBoxEx2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBoxEx2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FournituresBindingSource, "unitee", True))
        Me.ComboBoxEx2.DisplayMember = "Text"
        Me.ComboBoxEx2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBoxEx2.FormattingEnabled = True
        Me.ComboBoxEx2.ItemHeight = 14
        Me.ComboBoxEx2.Items.AddRange(New Object() {Me.ComboItem5, Me.ComboItem6, Me.ComboItem7, Me.ComboItem8})
        Me.ComboBoxEx2.Location = New System.Drawing.Point(1046, 297)
        Me.ComboBoxEx2.Name = "ComboBoxEx2"
        Me.ComboBoxEx2.Size = New System.Drawing.Size(182, 20)
        Me.ComboBoxEx2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ComboBoxEx2.TabIndex = 37
        Me.ComboBoxEx2.ValueMember = "Unitee"
        '
        'ComboItem5
        '
        Me.ComboItem5.Text = "Ml"
        Me.ComboItem5.Value = ""
        '
        'ComboItem6
        '
        Me.ComboItem6.Text = "PCE"
        Me.ComboItem6.Value = ""
        '
        'ComboItem7
        '
        Me.ComboItem7.Text = "BOITE"
        '
        'ComboItem8
        '
        Me.ComboItem8.Text = "Hrs"
        '
        'ComboBoxEx3
        '
        Me.ComboBoxEx3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBoxEx3.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FournituresBindingSource, "Matiere", True))
        Me.ComboBoxEx3.DisplayMember = "Text"
        Me.ComboBoxEx3.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBoxEx3.FormattingEnabled = True
        Me.ComboBoxEx3.ItemHeight = 14
        Me.ComboBoxEx3.Items.AddRange(New Object() {Me.ComboItem9, Me.ComboItem10, Me.ComboItem11, Me.ComboItem12, Me.ComboItem13, Me.ComboItem14})
        Me.ComboBoxEx3.Location = New System.Drawing.Point(1046, 569)
        Me.ComboBoxEx3.Name = "ComboBoxEx3"
        Me.ComboBoxEx3.Size = New System.Drawing.Size(182, 20)
        Me.ComboBoxEx3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ComboBoxEx3.TabIndex = 37
        Me.ComboBoxEx3.ValueMember = "Matiere"
        '
        'ComboItem9
        '
        Me.ComboItem9.Text = "MRL"
        Me.ComboItem9.Value = ""
        '
        'ComboItem10
        '
        Me.ComboItem10.Text = "IPC"
        Me.ComboItem10.Value = ""
        '
        'ComboItem11
        '
        Me.ComboItem11.Text = "GC"
        '
        'ComboItem12
        '
        Me.ComboItem12.Text = "SZ"
        '
        'ComboItem13
        '
        Me.ComboItem13.Text = "PVC"
        '
        'ComboItem14
        '
        Me.ComboItem14.Text = "INCONUE"
        '
        'FournisseursBindingSource
        '
        Me.FournisseursBindingSource.DataMember = "fournisseurs"
        Me.FournisseursBindingSource.DataSource = Me.MydbDataSet
        '
        'FournisseursTableAdapter
        '
        Me.FournisseursTableAdapter.ClearBeforeFill = True
        '
        'ComboBoxEx4
        '
        Me.ComboBoxEx4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBoxEx4.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.FournituresBindingSource, "fournisseur", True))
        Me.ComboBoxEx4.DataSource = Me.FournisseursBindingSource
        Me.ComboBoxEx4.DisplayMember = "Nom"
        Me.ComboBoxEx4.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBoxEx4.FormattingEnabled = True
        Me.ComboBoxEx4.ItemHeight = 14
        Me.ComboBoxEx4.Location = New System.Drawing.Point(1045, 271)
        Me.ComboBoxEx4.Name = "ComboBoxEx4"
        Me.ComboBoxEx4.Size = New System.Drawing.Size(182, 20)
        Me.ComboBoxEx4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ComboBoxEx4.TabIndex = 37
        Me.ComboBoxEx4.ValueMember = "idFournisseur"
        '
        'ButtonX4
        '
        Me.ButtonX4.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonX4.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX4.Image = Global.progelec.My.Resources.Resources.down_24_24
        Me.ButtonX4.Location = New System.Drawing.Point(895, 417)
        Me.ButtonX4.Name = "ButtonX4"
        Me.ButtonX4.Size = New System.Drawing.Size(43, 39)
        Me.ButtonX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX4.TabIndex = 39
        '
        'ButtonX5
        '
        Me.ButtonX5.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonX5.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX5.Image = Global.progelec.My.Resources.Resources.up_1_24_24
        Me.ButtonX5.Location = New System.Drawing.Point(895, 246)
        Me.ButtonX5.Name = "ButtonX5"
        Me.ButtonX5.Size = New System.Drawing.Size(43, 41)
        Me.ButtonX5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX5.TabIndex = 38
        '
        'ButtonX6
        '
        Me.ButtonX6.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonX6.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX6.Image = Global.progelec.My.Resources.Resources.save_32_32
        Me.ButtonX6.Location = New System.Drawing.Point(1135, 52)
        Me.ButtonX6.Name = "ButtonX6"
        Me.ButtonX6.Size = New System.Drawing.Size(114, 48)
        Me.ButtonX6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX6.TabIndex = 34
        Me.ButtonX6.Text = "Sauvegarde"
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FournituresBindingSource, "TempPoseMetre", True))
        Me.TextBox1.Location = New System.Drawing.Point(1045, 605)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(104, 20)
        Me.TextBox1.TabIndex = 31
        '
        'TextBox2
        '
        Me.TextBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FournituresBindingSource, "TempPoseUnitaire", True))
        Me.TextBox2.Location = New System.Drawing.Point(1045, 631)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(104, 20)
        Me.TextBox2.TabIndex = 31
        '
        'CheckBox1
        '
        Me.CheckBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CheckBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CheckBox1.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.FournituresBindingSource, "liste_tourets", True))
        Me.CheckBox1.Location = New System.Drawing.Point(1247, 476)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(104, 24)
        Me.CheckBox1.TabIndex = 29
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'ButtonXaddfournisseur
        '
        Me.ButtonXaddfournisseur.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonXaddfournisseur.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonXaddfournisseur.Image = Global.progelec.My.Resources.Resources.add_1_24_24
        Me.ButtonXaddfournisseur.Location = New System.Drawing.Point(1233, 271)
        Me.ButtonXaddfournisseur.Name = "ButtonXaddfournisseur"
        Me.ButtonXaddfournisseur.Size = New System.Drawing.Size(28, 23)
        Me.ButtonXaddfournisseur.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonXaddfournisseur.TabIndex = 41
        '
        'FormFournitures_lst
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1434, 700)
        Me.Controls.Add(Me.ButtonXaddfournisseur)
        Me.Controls.Add(TempPoseUnitaireLabel)
        Me.Controls.Add(TempPoseMetreLabel)
        Me.Controls.Add(Me.ButtonX4)
        Me.Controls.Add(Me.ButtonX5)
        Me.Controls.Add(Me.ComboBoxEx3)
        Me.Controls.Add(Me.ComboBoxEx4)
        Me.Controls.Add(Me.ComboBoxEx2)
        Me.Controls.Add(Me.ComboBoxEx1)
        Me.Controls.Add(Me.ButtonX2)
        Me.Controls.Add(Me.ButtonX3)
        Me.Controls.Add(Me.ButtonX6)
        Me.Controls.Add(Me.ButtonX1)
        Me.Controls.Add(DesignationLabel)
        Me.Controls.Add(Me.DesignationTextBox)
        Me.Controls.Add(CategorieLabel)
        Me.Controls.Add(Quant_minLabel)
        Me.Controls.Add(Me.Quant_minTextBox)
        Me.Controls.Add(FournisseurLabel)
        Me.Controls.Add(UniteeLabel)
        Me.Controls.Add(LongueurLabel)
        Me.Controls.Add(Me.LongueurTextBox)
        Me.Controls.Add(LargeurLabel)
        Me.Controls.Add(Me.LargeurTextBox)
        Me.Controls.Add(HauteurLabel)
        Me.Controls.Add(Me.HauteurTextBox)
        Me.Controls.Add(ProfondeurLabel)
        Me.Controls.Add(Me.ProfondeurTextBox)
        Me.Controls.Add(MasseLabel)
        Me.Controls.Add(Me.MasseTextBox)
        Me.Controls.Add(Liste_TronconLabel)
        Me.Controls.Add(Me.Liste_TronconCheckBox)
        Me.Controls.Add(Liste_cableLabel)
        Me.Controls.Add(Me.Liste_cableCheckBox)
        Me.Controls.Add(Label1)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Liste_equipementLabel)
        Me.Controls.Add(Me.Liste_equipementCheckBox)
        Me.Controls.Add(DiametreLabel)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.DiametreTextBox)
        Me.Controls.Add(MatiereLabel)
        Me.Controls.Add(Me.FournituresDataGridViewX)
        Me.Name = "FormFournitures_lst"
        Me.Text = "Liste Fournitures"
        CType(Me.FournituresBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MydbDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FournituresDataGridViewX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FournisseursBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MydbDataSet As progelec.mydbDataSet
    Friend WithEvents FournituresBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents FournituresTableAdapter As progelec.mydbDataSetTableAdapters.fournituresTableAdapter
    Friend WithEvents TableAdapterManager As progelec.mydbDataSetTableAdapters.TableAdapterManager
    Friend WithEvents FournituresDataGridViewX As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents DesignationTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Quant_minTextBox As System.Windows.Forms.TextBox
    Friend WithEvents LongueurTextBox As System.Windows.Forms.TextBox
    Friend WithEvents LargeurTextBox As System.Windows.Forms.TextBox
    Friend WithEvents HauteurTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ProfondeurTextBox As System.Windows.Forms.TextBox
    Friend WithEvents MasseTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Liste_TronconCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents Liste_cableCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents Liste_equipementCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents DiametreTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ButtonX2 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX3 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ComboBoxEx1 As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents CABLE As DevComponents.Editors.ComboItem
    Friend WithEvents DALLE As DevComponents.Editors.ComboItem
    Friend WithEvents TUBE As DevComponents.Editors.ComboItem
    Friend WithEvents ECHELLE As DevComponents.Editors.ComboItem
    Friend WithEvents TOURET As DevComponents.Editors.ComboItem
    Friend WithEvents DIVERS As DevComponents.Editors.ComboItem
    Friend WithEvents COSSES As DevComponents.Editors.ComboItem
    Friend WithEvents MESURES As DevComponents.Editors.ComboItem
    Friend WithEvents EQUIPEMENTS As DevComponents.Editors.ComboItem
    Friend WithEvents MATERIELS As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem1 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem2 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem3 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem4 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboBoxEx2 As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents ComboItem5 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem6 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem7 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem8 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboBoxEx3 As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents ComboItem9 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem10 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem11 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem12 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem13 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem14 As DevComponents.Editors.ComboItem
    Friend WithEvents FournisseursBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents FournisseursTableAdapter As progelec.mydbDataSetTableAdapters.fournisseursTableAdapter
    Friend WithEvents ComboBoxEx4 As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents ButtonX4 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX5 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX6 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents IdfournitureDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CategorieDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DesignationDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantminDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FournisseurDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UniteeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LongueurDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LargeurDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HauteurDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProfondeurDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MasseDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ListeTronconDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ListecableDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ListeequipementDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DiametreDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MatiereDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TempPoseMetreDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TempPoseUnitaireDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Private WithEvents ButtonXaddfournisseur As DevComponents.DotNetBar.ButtonX
End Class
