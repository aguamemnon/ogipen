Imports DevComponents.DotNetBar

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDonnees
    Inherits OfficeForm

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
        Dim Types_cable_idtypes_cableLabel As System.Windows.Forms.Label
        Dim Sections_cables_idsections_cablesLabel As System.Windows.Forms.Label
        Dim DiametreLabel As System.Windows.Forms.Label
        Dim Charge_calorifiqueLabel As System.Windows.Forms.Label
        Dim MasseLabel As System.Windows.Forms.Label
        Dim TempPoseLabel As System.Windows.Forms.Label
        Dim TempRaccTeteLabel As System.Windows.Forms.Label
        Dim NombreBrinsLabel As System.Windows.Forms.Label
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormDonnees))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.MydbDataSet = New progelec.mydbDataSet()
        Me.Donnees_cablesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Donnees_cablesTableAdapter = New progelec.mydbDataSetTableAdapters.donnees_cablesTableAdapter()
        Me.TableAdapterManager = New progelec.mydbDataSetTableAdapters.TableAdapterManager()
        Me.Types_cableTableAdapter = New progelec.mydbDataSetTableAdapters.types_cableTableAdapter()
        Me.DiametreTextBox = New System.Windows.Forms.TextBox()
        Me.Charge_calorifiqueTextBox = New System.Windows.Forms.TextBox()
        Me.MasseTextBox = New System.Windows.Forms.TextBox()
        Me.ComboBox = New System.Windows.Forms.ComboBox()
        Me.TypescableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.SectionscablesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Sections_cablesTableAdapter = New progelec.mydbDataSetTableAdapters.sections_cablesTableAdapter()
        Me.Donnee_phyBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Donnee_phyTableAdapter = New progelec.mydbDataSetTableAdapters.donnee_phyTableAdapter()
        Me.Donnee_phyDataGridViewX = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ButtonX4 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX2 = New DevComponents.DotNetBar.ButtonX()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuperValidator1 = New DevComponents.DotNetBar.Validator.SuperValidator()
        Me.RequiredFieldValidator3 = New DevComponents.DotNetBar.Validator.RequiredFieldValidator("Your error message here.")
        Me.RequiredFieldValidator4 = New DevComponents.DotNetBar.Validator.RequiredFieldValidator("Your error message here.")
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Highlighter1 = New DevComponents.DotNetBar.Validator.Highlighter()
        Me.RequiredFieldValidator1 = New DevComponents.DotNetBar.Validator.RequiredFieldValidator("Your error message here.")
        Me.RequiredFieldValidator2 = New DevComponents.DotNetBar.Validator.RequiredFieldValidator("Your error message here.")
        Me.Ctrl_phyBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Ctrl_phyTableAdapter = New progelec.mydbDataSetTableAdapters.ctrl_phyTableAdapter()
        Me.Ctrl_phyDataGridViewX = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.TempPoseTextBox = New System.Windows.Forms.TextBox()
        Me.TempRaccTeteTextBox = New System.Windows.Forms.TextBox()
        Me.NombreBrinsTextBox = New System.Windows.Forms.TextBox()
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX3 = New DevComponents.DotNetBar.ButtonX()
        Types_cable_idtypes_cableLabel = New System.Windows.Forms.Label()
        Sections_cables_idsections_cablesLabel = New System.Windows.Forms.Label()
        DiametreLabel = New System.Windows.Forms.Label()
        Charge_calorifiqueLabel = New System.Windows.Forms.Label()
        MasseLabel = New System.Windows.Forms.Label()
        TempPoseLabel = New System.Windows.Forms.Label()
        TempRaccTeteLabel = New System.Windows.Forms.Label()
        NombreBrinsLabel = New System.Windows.Forms.Label()
        CType(Me.MydbDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Donnees_cablesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TypescableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SectionscablesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Donnee_phyBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Donnee_phyDataGridViewX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Ctrl_phyBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Ctrl_phyDataGridViewX, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Types_cable_idtypes_cableLabel
        '
        Types_cable_idtypes_cableLabel.AutoSize = True
        Types_cable_idtypes_cableLabel.Location = New System.Drawing.Point(10, 93)
        Types_cable_idtypes_cableLabel.Name = "Types_cable_idtypes_cableLabel"
        Types_cable_idtypes_cableLabel.Size = New System.Drawing.Size(67, 13)
        Types_cable_idtypes_cableLabel.TabIndex = 2
        Types_cable_idtypes_cableLabel.Text = "types cable :"
        '
        'Sections_cables_idsections_cablesLabel
        '
        Sections_cables_idsections_cablesLabel.AutoSize = True
        Sections_cables_idsections_cablesLabel.Location = New System.Drawing.Point(10, 131)
        Sections_cables_idsections_cablesLabel.Name = "Sections_cables_idsections_cablesLabel"
        Sections_cables_idsections_cablesLabel.Size = New System.Drawing.Size(47, 13)
        Sections_cables_idsections_cablesLabel.TabIndex = 4
        Sections_cables_idsections_cablesLabel.Text = "section :"
        '
        'DiametreLabel
        '
        DiametreLabel.AutoSize = True
        DiametreLabel.Location = New System.Drawing.Point(272, 98)
        DiametreLabel.Name = "DiametreLabel"
        DiametreLabel.Size = New System.Drawing.Size(50, 13)
        DiametreLabel.TabIndex = 6
        DiametreLabel.Text = "diametre:"
        '
        'Charge_calorifiqueLabel
        '
        Charge_calorifiqueLabel.AutoSize = True
        Charge_calorifiqueLabel.Location = New System.Drawing.Point(247, 121)
        Charge_calorifiqueLabel.Name = "Charge_calorifiqueLabel"
        Charge_calorifiqueLabel.Size = New System.Drawing.Size(94, 13)
        Charge_calorifiqueLabel.TabIndex = 8
        Charge_calorifiqueLabel.Text = "charge calorifique:"
        '
        'MasseLabel
        '
        MasseLabel.AutoSize = True
        MasseLabel.Location = New System.Drawing.Point(301, 147)
        MasseLabel.Name = "MasseLabel"
        MasseLabel.Size = New System.Drawing.Size(40, 13)
        MasseLabel.TabIndex = 10
        MasseLabel.Text = "masse:"
        '
        'TempPoseLabel
        '
        TempPoseLabel.AutoSize = True
        TempPoseLabel.Location = New System.Drawing.Point(277, 173)
        TempPoseLabel.Name = "TempPoseLabel"
        TempPoseLabel.Size = New System.Drawing.Size(64, 13)
        TempPoseLabel.TabIndex = 31
        TempPoseLabel.Text = "Temp Pose:"
        '
        'TempRaccTeteLabel
        '
        TempRaccTeteLabel.AutoSize = True
        TempRaccTeteLabel.Location = New System.Drawing.Point(250, 199)
        TempRaccTeteLabel.Name = "TempRaccTeteLabel"
        TempRaccTeteLabel.Size = New System.Drawing.Size(91, 13)
        TempRaccTeteLabel.TabIndex = 32
        TempRaccTeteLabel.Text = "Temp Racc Tete:"
        '
        'NombreBrinsLabel
        '
        NombreBrinsLabel.AutoSize = True
        NombreBrinsLabel.Location = New System.Drawing.Point(268, 225)
        NombreBrinsLabel.Name = "NombreBrinsLabel"
        NombreBrinsLabel.Size = New System.Drawing.Size(73, 13)
        NombreBrinsLabel.TabIndex = 33
        NombreBrinsLabel.Text = "Nombre Brins:"
        '
        'MydbDataSet
        '
        Me.MydbDataSet.DataSetName = "mydbDataSet"
        Me.MydbDataSet.EnforceConstraints = False
        Me.MydbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Donnees_cablesBindingSource
        '
        Me.Donnees_cablesBindingSource.DataMember = "donnees_cables"
        Me.Donnees_cablesBindingSource.DataSource = Me.MydbDataSet
        '
        'Donnees_cablesTableAdapter
        '
        Me.Donnees_cablesTableAdapter.ClearBeforeFill = True
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
        Me.TableAdapterManager.donnees_cablesTableAdapter = Me.Donnees_cablesTableAdapter
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
        Me.TableAdapterManager.tronconsTableAdapter = Nothing
        Me.TableAdapterManager.type_docTableAdapter = Nothing
        Me.TableAdapterManager.types_cableTableAdapter = Nothing
        Me.TableAdapterManager.types_tronconsTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = progelec.mydbDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'Types_cableTableAdapter
        '
        Me.Types_cableTableAdapter.ClearBeforeFill = True
        '
        'DiametreTextBox
        '
        Me.DiametreTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Donnees_cablesBindingSource, "diametre", True))
        Me.DiametreTextBox.Location = New System.Drawing.Point(347, 91)
        Me.DiametreTextBox.Name = "DiametreTextBox"
        Me.DiametreTextBox.Size = New System.Drawing.Size(100, 20)
        Me.DiametreTextBox.TabIndex = 7
        '
        'Charge_calorifiqueTextBox
        '
        Me.Charge_calorifiqueTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Donnees_cablesBindingSource, "charge_calorifique", True))
        Me.Charge_calorifiqueTextBox.Location = New System.Drawing.Point(347, 118)
        Me.Charge_calorifiqueTextBox.Name = "Charge_calorifiqueTextBox"
        Me.Charge_calorifiqueTextBox.Size = New System.Drawing.Size(100, 20)
        Me.Charge_calorifiqueTextBox.TabIndex = 9
        '
        'MasseTextBox
        '
        Me.MasseTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Donnees_cablesBindingSource, "masse", True))
        Me.MasseTextBox.Location = New System.Drawing.Point(347, 144)
        Me.MasseTextBox.Name = "MasseTextBox"
        Me.MasseTextBox.Size = New System.Drawing.Size(100, 20)
        Me.MasseTextBox.TabIndex = 11
        '
        'ComboBox
        '
        Me.ComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.Donnees_cablesBindingSource, "types_cable_idtypes_cable", True))
        Me.ComboBox.DataSource = Me.TypescableBindingSource
        Me.ComboBox.DisplayMember = "types"
        Me.ComboBox.FormattingEnabled = True
        Me.ComboBox.Location = New System.Drawing.Point(83, 93)
        Me.ComboBox.Name = "ComboBox"
        Me.ComboBox.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox.TabIndex = 12
        Me.SuperValidator1.SetValidator1(Me.ComboBox, Me.RequiredFieldValidator3)
        Me.ComboBox.ValueMember = "idtypes_cable"
        '
        'TypescableBindingSource
        '
        Me.TypescableBindingSource.DataMember = "types_cable"
        Me.TypescableBindingSource.DataSource = Me.MydbDataSet
        '
        'ComboBox1
        '
        Me.ComboBox1.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.Donnees_cablesBindingSource, "sections_cables_idsections_cables", True))
        Me.ComboBox1.DataSource = Me.SectionscablesBindingSource
        Me.ComboBox1.DisplayMember = "section"
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(83, 131)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox1.TabIndex = 13
        Me.SuperValidator1.SetValidator1(Me.ComboBox1, Me.RequiredFieldValidator4)
        Me.ComboBox1.ValueMember = "idsections_cables"
        '
        'SectionscablesBindingSource
        '
        Me.SectionscablesBindingSource.DataMember = "sections_cables"
        Me.SectionscablesBindingSource.DataSource = Me.MydbDataSet
        '
        'Sections_cablesTableAdapter
        '
        Me.Sections_cablesTableAdapter.ClearBeforeFill = True
        '
        'Donnee_phyBindingSource
        '
        Me.Donnee_phyBindingSource.DataMember = "donnee_phy"
        Me.Donnee_phyBindingSource.DataSource = Me.MydbDataSet
        '
        'Donnee_phyTableAdapter
        '
        Me.Donnee_phyTableAdapter.ClearBeforeFill = True
        '
        'Donnee_phyDataGridViewX
        '
        Me.Donnee_phyDataGridViewX.AutoGenerateColumns = False
        Me.Donnee_phyDataGridViewX.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Donnee_phyDataGridViewX.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8})
        Me.Donnee_phyDataGridViewX.DataSource = Me.Donnee_phyBindingSource
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Donnee_phyDataGridViewX.DefaultCellStyle = DataGridViewCellStyle2
        Me.Donnee_phyDataGridViewX.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Donnee_phyDataGridViewX.Location = New System.Drawing.Point(0, 264)
        Me.Donnee_phyDataGridViewX.Name = "Donnee_phyDataGridViewX"
        Me.Donnee_phyDataGridViewX.Size = New System.Drawing.Size(572, 273)
        Me.Donnee_phyDataGridViewX.TabIndex = 13
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "iddonnee"
        Me.DataGridViewTextBoxColumn1.HeaderText = "iddonnee"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "types"
        Me.DataGridViewTextBoxColumn2.HeaderText = "types"
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
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "diametre"
        Me.DataGridViewTextBoxColumn4.HeaderText = "diametre"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "charge_calorifique"
        Me.DataGridViewTextBoxColumn5.HeaderText = "charge_calorifique"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "masse"
        Me.DataGridViewTextBoxColumn6.HeaderText = "masse"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "types_cable_idtypes_cable"
        Me.DataGridViewTextBoxColumn7.HeaderText = "types_cable_idtypes_cable"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.Visible = False
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "sections_cables_idsections_cables"
        Me.DataGridViewTextBoxColumn8.HeaderText = "sections_cables_idsections_cables"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.Visible = False
        '
        'ButtonX4
        '
        Me.ButtonX4.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX4.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX4.Image = Global.progelec.My.Resources.Resources.down_24_24
        Me.ButtonX4.Location = New System.Drawing.Point(583, 468)
        Me.ButtonX4.Name = "ButtonX4"
        Me.ButtonX4.Size = New System.Drawing.Size(43, 39)
        Me.ButtonX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX4.TabIndex = 30
        '
        'ButtonX2
        '
        Me.ButtonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX2.Image = Global.progelec.My.Resources.Resources.up_1_24_24
        Me.ButtonX2.Location = New System.Drawing.Point(583, 297)
        Me.ButtonX2.Name = "ButtonX2"
        Me.ButtonX2.Size = New System.Drawing.Size(43, 41)
        Me.ButtonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX2.TabIndex = 29
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button3.Image = Global.progelec.My.Resources.Resources.save_24_24
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button3.Location = New System.Drawing.Point(962, 28)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(96, 51)
        Me.Button3.TabIndex = 28
        Me.Button3.Text = "Enregistrement"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.Image = Global.progelec.My.Resources.Resources.remove_24_24
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button2.Location = New System.Drawing.Point(857, 28)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(94, 51)
        Me.Button2.TabIndex = 27
        Me.Button2.Text = "Suppression"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Image = Global.progelec.My.Resources.Resources.add_24_24
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.Location = New System.Drawing.Point(749, 28)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(100, 51)
        Me.Button1.TabIndex = 26
        Me.Button1.Text = "Nouveau"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = True
        '
        'SuperValidator1
        '
        Me.SuperValidator1.ContainerControl = Me
        Me.SuperValidator1.ErrorProvider = Me.ErrorProvider1
        Me.SuperValidator1.Highlighter = Me.Highlighter1
        Me.SuperValidator1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        '
        'RequiredFieldValidator3
        '
        Me.RequiredFieldValidator3.ErrorMessage = "Your error message here."
        Me.RequiredFieldValidator3.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red
        '
        'RequiredFieldValidator4
        '
        Me.RequiredFieldValidator4.ErrorMessage = "Your error message here."
        Me.RequiredFieldValidator4.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red
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
        'RequiredFieldValidator1
        '
        Me.RequiredFieldValidator1.ErrorMessage = "Your error message here."
        Me.RequiredFieldValidator1.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red
        '
        'RequiredFieldValidator2
        '
        Me.RequiredFieldValidator2.ErrorMessage = "Your error message here."
        Me.RequiredFieldValidator2.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red
        '
        'Ctrl_phyBindingSource
        '
        Me.Ctrl_phyBindingSource.DataMember = "ctrl_phy"
        Me.Ctrl_phyBindingSource.DataSource = Me.MydbDataSet
        '
        'Ctrl_phyTableAdapter
        '
        Me.Ctrl_phyTableAdapter.ClearBeforeFill = True
        '
        'Ctrl_phyDataGridViewX
        '
        Me.Ctrl_phyDataGridViewX.AllowUserToAddRows = False
        Me.Ctrl_phyDataGridViewX.AllowUserToDeleteRows = False
        Me.Ctrl_phyDataGridViewX.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Ctrl_phyDataGridViewX.AutoGenerateColumns = False
        Me.Ctrl_phyDataGridViewX.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Ctrl_phyDataGridViewX.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn10, Me.DataGridViewTextBoxColumn11, Me.DataGridViewTextBoxColumn12})
        Me.Ctrl_phyDataGridViewX.DataSource = Me.Ctrl_phyBindingSource
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Ctrl_phyDataGridViewX.DefaultCellStyle = DataGridViewCellStyle1
        Me.Ctrl_phyDataGridViewX.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Ctrl_phyDataGridViewX.Location = New System.Drawing.Point(813, 264)
        Me.Ctrl_phyDataGridViewX.Name = "Ctrl_phyDataGridViewX"
        Me.Ctrl_phyDataGridViewX.ReadOnly = True
        Me.Ctrl_phyDataGridViewX.Size = New System.Drawing.Size(245, 220)
        Me.Ctrl_phyDataGridViewX.TabIndex = 30
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "types_cable_idtypes_cable"
        Me.DataGridViewTextBoxColumn9.HeaderText = "types_cable_idtypes_cable"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        Me.DataGridViewTextBoxColumn9.Visible = False
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "sections_cables_idsections_cables"
        Me.DataGridViewTextBoxColumn10.HeaderText = "sections_cables_idsections_cables"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        Me.DataGridViewTextBoxColumn10.Visible = False
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "types"
        Me.DataGridViewTextBoxColumn11.HeaderText = "types"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "section"
        Me.DataGridViewTextBoxColumn12.HeaderText = "section"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        '
        'LabelX1
        '
        Me.LabelX1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(813, 201)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(245, 23)
        Me.LabelX1.TabIndex = 31
        Me.LabelX1.Text = "<b>A Creer</b>"
        '
        'TempPoseTextBox
        '
        Me.TempPoseTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Donnees_cablesBindingSource, "TempPose", True))
        Me.TempPoseTextBox.Location = New System.Drawing.Point(347, 170)
        Me.TempPoseTextBox.Name = "TempPoseTextBox"
        Me.TempPoseTextBox.Size = New System.Drawing.Size(100, 20)
        Me.TempPoseTextBox.TabIndex = 32
        '
        'TempRaccTeteTextBox
        '
        Me.TempRaccTeteTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Donnees_cablesBindingSource, "TempRaccTete", True))
        Me.TempRaccTeteTextBox.Location = New System.Drawing.Point(347, 196)
        Me.TempRaccTeteTextBox.Name = "TempRaccTeteTextBox"
        Me.TempRaccTeteTextBox.Size = New System.Drawing.Size(100, 20)
        Me.TempRaccTeteTextBox.TabIndex = 33
        '
        'NombreBrinsTextBox
        '
        Me.NombreBrinsTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Donnees_cablesBindingSource, "NombreBrins", True))
        Me.NombreBrinsTextBox.Location = New System.Drawing.Point(347, 222)
        Me.NombreBrinsTextBox.Name = "NombreBrinsTextBox"
        Me.NombreBrinsTextBox.Size = New System.Drawing.Size(100, 20)
        Me.NombreBrinsTextBox.TabIndex = 34
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX1.Image = Global.progelec.My.Resources.Resources.add_24_24
        Me.ButtonX1.Location = New System.Drawing.Point(208, 91)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Size = New System.Drawing.Size(33, 32)
        Me.ButtonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX1.TabIndex = 29
        '
        'ButtonX3
        '
        Me.ButtonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX3.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX3.Image = Global.progelec.My.Resources.Resources.add_24_24
        Me.ButtonX3.Location = New System.Drawing.Point(208, 132)
        Me.ButtonX3.Name = "ButtonX3"
        Me.ButtonX3.Size = New System.Drawing.Size(33, 32)
        Me.ButtonX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX3.TabIndex = 29
        '
        'FormDonnees
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1070, 557)
        Me.Controls.Add(NombreBrinsLabel)
        Me.Controls.Add(Me.NombreBrinsTextBox)
        Me.Controls.Add(TempRaccTeteLabel)
        Me.Controls.Add(Me.TempRaccTeteTextBox)
        Me.Controls.Add(TempPoseLabel)
        Me.Controls.Add(Me.TempPoseTextBox)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Ctrl_phyDataGridViewX)
        Me.Controls.Add(Me.ButtonX4)
        Me.Controls.Add(Me.ButtonX3)
        Me.Controls.Add(Me.ButtonX1)
        Me.Controls.Add(Me.ButtonX2)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Donnee_phyDataGridViewX)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.ComboBox)
        Me.Controls.Add(MasseLabel)
        Me.Controls.Add(Me.MasseTextBox)
        Me.Controls.Add(Charge_calorifiqueLabel)
        Me.Controls.Add(Me.Charge_calorifiqueTextBox)
        Me.Controls.Add(DiametreLabel)
        Me.Controls.Add(Me.DiametreTextBox)
        Me.Controls.Add(Sections_cables_idsections_cablesLabel)
        Me.Controls.Add(Types_cable_idtypes_cableLabel)
        Me.Name = "FormDonnees"
        Me.Text = "Donnees"
        CType(Me.MydbDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Donnees_cablesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TypescableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SectionscablesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Donnee_phyBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Donnee_phyDataGridViewX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Ctrl_phyBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Ctrl_phyDataGridViewX, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MydbDataSet As progelec.mydbDataSet
    Friend WithEvents Donnees_cablesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Donnees_cablesTableAdapter As progelec.mydbDataSetTableAdapters.donnees_cablesTableAdapter
    Friend WithEvents TableAdapterManager As progelec.mydbDataSetTableAdapters.TableAdapterManager
    Friend WithEvents DiametreTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Charge_calorifiqueTextBox As System.Windows.Forms.TextBox
    Friend WithEvents MasseTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Types_cableTableAdapter As progelec.mydbDataSetTableAdapters.types_cableTableAdapter
    Friend WithEvents TypescableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents SectionscablesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Sections_cablesTableAdapter As progelec.mydbDataSetTableAdapters.sections_cablesTableAdapter
    Friend WithEvents Donnee_phyBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Donnee_phyTableAdapter As progelec.mydbDataSetTableAdapters.donnee_phyTableAdapter
    Friend WithEvents Donnee_phyDataGridViewX As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ButtonX4 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX2 As DevComponents.DotNetBar.ButtonX
    Private WithEvents Button3 As System.Windows.Forms.Button
    Private WithEvents Button2 As System.Windows.Forms.Button
    Private WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents SuperValidator1 As DevComponents.DotNetBar.Validator.SuperValidator
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Highlighter1 As DevComponents.DotNetBar.Validator.Highlighter
    Friend WithEvents RequiredFieldValidator1 As DevComponents.DotNetBar.Validator.RequiredFieldValidator
    Friend WithEvents RequiredFieldValidator2 As DevComponents.DotNetBar.Validator.RequiredFieldValidator
    Friend WithEvents Ctrl_phyBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Ctrl_phyTableAdapter As progelec.mydbDataSetTableAdapters.ctrl_phyTableAdapter
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Ctrl_phyDataGridViewX As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NombreBrinsTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TempRaccTeteTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TempPoseTextBox As System.Windows.Forms.TextBox
    Friend WithEvents RequiredFieldValidator4 As DevComponents.DotNetBar.Validator.RequiredFieldValidator
    Friend WithEvents RequiredFieldValidator3 As DevComponents.DotNetBar.Validator.RequiredFieldValidator
    Private WithEvents ButtonX3 As DevComponents.DotNetBar.ButtonX
    Private WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
End Class
