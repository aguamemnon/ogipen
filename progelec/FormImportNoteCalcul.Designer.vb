<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OfficeFormImportNoteDeCalcul
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OfficeFormImportNoteDeCalcul))
        Dim GridColumn3 As DevComponents.DotNetBar.SuperGrid.GridColumn = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Dim GridColumn4 As DevComponents.DotNetBar.SuperGrid.GridColumn = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Dim GridColumn5 As DevComponents.DotNetBar.SuperGrid.GridColumn = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Dim GridColumn6 As DevComponents.DotNetBar.SuperGrid.GridColumn = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Dim GridColumn7 As DevComponents.DotNetBar.SuperGrid.GridColumn = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Dim GridColumn8 As DevComponents.DotNetBar.SuperGrid.GridColumn = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Dim GridColumn9 As DevComponents.DotNetBar.SuperGrid.GridColumn = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Dim GridColumn10 As DevComponents.DotNetBar.SuperGrid.GridColumn = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Dim GridColumn1 As DevComponents.DotNetBar.SuperGrid.GridColumn = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Dim GridColumn2 As DevComponents.DotNetBar.SuperGrid.GridColumn = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.ButtonXSelectionFichier = New DevComponents.DotNetBar.ButtonX()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.CheckBoxXTRCiel = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.CheckBoxXCaneco = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.TextBoxXRevision = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TextBoxXReference = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.SuperValidator = New DevComponents.DotNetBar.Validator.SuperValidator()
        Me.RequiredFieldValidator2 = New DevComponents.DotNetBar.Validator.RequiredFieldValidator("Your error message here.")
        Me.RequiredFieldValidator1 = New DevComponents.DotNetBar.Validator.RequiredFieldValidator("Your error message here.")
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Highlighter1 = New DevComponents.DotNetBar.Validator.Highlighter()
        Me.ComboBoxBatiment = New System.Windows.Forms.ComboBox()
        Me.BatimentsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MydbDataSet = New progelec.mydbDataSet()
        Me.RequiredFieldValidator3 = New DevComponents.DotNetBar.Validator.RequiredFieldValidator("Your error message here.")
        Me.DateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.LabelXinfo = New DevComponents.DotNetBar.LabelX()
        Me.LabelXReference = New DevComponents.DotNetBar.LabelX()
        Me.LabelXIndice = New DevComponents.DotNetBar.LabelX()
        Me.LabelXEnDateDu = New DevComponents.DotNetBar.LabelX()
        Me.ButtonXLancerLannalyse = New DevComponents.DotNetBar.ButtonX()
        Me.TextBoxXFichierSelectionne = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TextBoxXAnnalyse = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.ButtonXLancerLimport = New DevComponents.DotNetBar.ButtonX()
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.SuperGridControlEquipements = New DevComponents.DotNetBar.SuperGrid.SuperGridControl()
        Me.ImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.SuperGridControlcables = New DevComponents.DotNetBar.SuperGrid.SuperGridControl()
        Me.EquipementsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EquipementsTableAdapter = New progelec.mydbDataSetTableAdapters.equipementsTableAdapter()
        Me.TableAdapterManager = New progelec.mydbDataSetTableAdapters.TableAdapterManager()
        Me.CablesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CablesTableAdapter = New progelec.mydbDataSetTableAdapters.cablesTableAdapter()
        Me.Types_cableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Types_cableTableAdapter = New progelec.mydbDataSetTableAdapters.types_cableTableAdapter()
        Me.Sections_cablesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Sections_cablesTableAdapter = New progelec.mydbDataSetTableAdapters.sections_cablesTableAdapter()
        Me.BatimentsTableAdapter = New progelec.mydbDataSetTableAdapters.batimentsTableAdapter()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.SuperTabControl = New DevComponents.DotNetBar.SuperTabControl()
        Me.SuperTabControlPanel3 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.SuperTabItem3 = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel1 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.SuperTabItem1 = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel2 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.SuperTabItem2 = New DevComponents.DotNetBar.SuperTabItem()
        Me.CategoriesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CategoriesTableAdapter = New progelec.mydbDataSetTableAdapters.categoriesTableAdapter()
        Me.LotsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.LotsTableAdapter = New progelec.mydbDataSetTableAdapters.lotsTableAdapter()
        Me.SallesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SallesTableAdapter = New progelec.mydbDataSetTableAdapters.sallesTableAdapter()
        Me.Cables_detailsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Cables_detailsTableAdapter = New progelec.mydbDataSetTableAdapters.cables_detailsTableAdapter()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BatimentsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MydbDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EquipementsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CablesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Types_cableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Sections_cablesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SuperTabControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControl.SuspendLayout()
        Me.SuperTabControlPanel3.SuspendLayout()
        Me.SuperTabControlPanel1.SuspendLayout()
        Me.SuperTabControlPanel2.SuspendLayout()
        CType(Me.CategoriesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LotsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SallesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cables_detailsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ButtonXSelectionFichier
        '
        Me.ButtonXSelectionFichier.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonXSelectionFichier.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonXSelectionFichier.Location = New System.Drawing.Point(12, 77)
        Me.ButtonXSelectionFichier.Name = "ButtonXSelectionFichier"
        Me.ButtonXSelectionFichier.Size = New System.Drawing.Size(155, 23)
        Me.ButtonXSelectionFichier.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonXSelectionFichier.TabIndex = 2
        Me.ButtonXSelectionFichier.Text = "selection fichier"
        '
        'CheckBoxXTRCiel
        '
        '
        '
        '
        Me.CheckBoxXTRCiel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxXTRCiel.Location = New System.Drawing.Point(12, 12)
        Me.CheckBoxXTRCiel.Name = "CheckBoxXTRCiel"
        Me.CheckBoxXTRCiel.Size = New System.Drawing.Size(155, 23)
        Me.CheckBoxXTRCiel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CheckBoxXTRCiel.TabIndex = 0
        Me.CheckBoxXTRCiel.Text = "TR-Ciel"
        '
        'CheckBoxXCaneco
        '
        '
        '
        '
        Me.CheckBoxXCaneco.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxXCaneco.Location = New System.Drawing.Point(12, 41)
        Me.CheckBoxXCaneco.Name = "CheckBoxXCaneco"
        Me.CheckBoxXCaneco.Size = New System.Drawing.Size(155, 23)
        Me.CheckBoxXCaneco.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CheckBoxXCaneco.TabIndex = 1
        Me.CheckBoxXCaneco.Text = "Caneco"
        '
        'TextBoxXRevision
        '
        '
        '
        '
        Me.TextBoxXRevision.Border.Class = "TextBoxBorder"
        Me.TextBoxXRevision.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxXRevision.Location = New System.Drawing.Point(331, 160)
        Me.TextBoxXRevision.Name = "TextBoxXRevision"
        Me.TextBoxXRevision.PreventEnterBeep = True
        Me.TextBoxXRevision.Size = New System.Drawing.Size(81, 20)
        Me.TextBoxXRevision.TabIndex = 8
        Me.SuperValidator.SetValidator1(Me.TextBoxXRevision, Me.RequiredFieldValidator2)
        '
        'TextBoxXReference
        '
        '
        '
        '
        Me.TextBoxXReference.Border.Class = "TextBoxBorder"
        Me.TextBoxXReference.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxXReference.Location = New System.Drawing.Point(91, 160)
        Me.TextBoxXReference.Name = "TextBoxXReference"
        Me.TextBoxXReference.PreventEnterBeep = True
        Me.TextBoxXReference.Size = New System.Drawing.Size(155, 20)
        Me.TextBoxXReference.TabIndex = 6
        Me.SuperValidator.SetValidator1(Me.TextBoxXReference, Me.RequiredFieldValidator1)
        '
        'SuperValidator
        '
        Me.SuperValidator.ContainerControl = Me
        Me.SuperValidator.ErrorProvider = Me.ErrorProvider1
        Me.SuperValidator.Highlighter = Me.Highlighter1
        Me.SuperValidator.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        '
        'RequiredFieldValidator2
        '
        Me.RequiredFieldValidator2.ErrorMessage = "Your error message here."
        Me.RequiredFieldValidator2.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red
        '
        'RequiredFieldValidator1
        '
        Me.RequiredFieldValidator1.ErrorMessage = "Your error message here."
        Me.RequiredFieldValidator1.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red
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
        'ComboBoxBatiment
        '
        Me.ComboBoxBatiment.DataSource = Me.BatimentsBindingSource
        Me.ComboBoxBatiment.DisplayMember = "Nom"
        Me.ComboBoxBatiment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxBatiment.FormattingEnabled = True
        Me.ComboBoxBatiment.Location = New System.Drawing.Point(809, 160)
        Me.ComboBoxBatiment.Name = "ComboBoxBatiment"
        Me.ComboBoxBatiment.Size = New System.Drawing.Size(121, 21)
        Me.ComboBoxBatiment.TabIndex = 16
        Me.SuperValidator.SetValidator1(Me.ComboBoxBatiment, Me.RequiredFieldValidator3)
        Me.ComboBoxBatiment.ValueMember = "idBatiment"
        '
        'BatimentsBindingSource
        '
        Me.BatimentsBindingSource.DataMember = "batiments"
        Me.BatimentsBindingSource.DataSource = Me.MydbDataSet
        '
        'MydbDataSet
        '
        Me.MydbDataSet.DataSetName = "mydbDataSet"
        Me.MydbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'RequiredFieldValidator3
        '
        Me.RequiredFieldValidator3.ErrorMessage = "Your error message here."
        Me.RequiredFieldValidator3.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red
        '
        'DateTimePicker
        '
        Me.DateTimePicker.Location = New System.Drawing.Point(485, 160)
        Me.DateTimePicker.Name = "DateTimePicker"
        Me.DateTimePicker.Size = New System.Drawing.Size(255, 20)
        Me.DateTimePicker.TabIndex = 10
        '
        'LabelXinfo
        '
        '
        '
        '
        Me.LabelXinfo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelXinfo.Location = New System.Drawing.Point(12, 128)
        Me.LabelXinfo.Name = "LabelXinfo"
        Me.LabelXinfo.Size = New System.Drawing.Size(383, 23)
        Me.LabelXinfo.TabIndex = 4
        Me.LabelXinfo.Text = "Vous allez importer une note de calcul dans la base de travail de reference"
        '
        'LabelXReference
        '
        '
        '
        '
        Me.LabelXReference.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelXReference.Location = New System.Drawing.Point(12, 160)
        Me.LabelXReference.Name = "LabelXReference"
        Me.LabelXReference.Size = New System.Drawing.Size(73, 23)
        Me.LabelXReference.TabIndex = 5
        Me.LabelXReference.Text = "reference"
        '
        'LabelXIndice
        '
        '
        '
        '
        Me.LabelXIndice.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelXIndice.Location = New System.Drawing.Point(252, 160)
        Me.LabelXIndice.Name = "LabelXIndice"
        Me.LabelXIndice.Size = New System.Drawing.Size(73, 23)
        Me.LabelXIndice.TabIndex = 7
        Me.LabelXIndice.Text = "indice"
        '
        'LabelXEnDateDu
        '
        '
        '
        '
        Me.LabelXEnDateDu.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelXEnDateDu.Location = New System.Drawing.Point(418, 160)
        Me.LabelXEnDateDu.Name = "LabelXEnDateDu"
        Me.LabelXEnDateDu.Size = New System.Drawing.Size(61, 23)
        Me.LabelXEnDateDu.TabIndex = 9
        Me.LabelXEnDateDu.Text = "en date du :"
        '
        'ButtonXLancerLannalyse
        '
        Me.ButtonXLancerLannalyse.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonXLancerLannalyse.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonXLancerLannalyse.Location = New System.Drawing.Point(12, 200)
        Me.ButtonXLancerLannalyse.Name = "ButtonXLancerLannalyse"
        Me.ButtonXLancerLannalyse.Size = New System.Drawing.Size(155, 23)
        Me.ButtonXLancerLannalyse.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonXLancerLannalyse.TabIndex = 11
        Me.ButtonXLancerLannalyse.Text = "Lancer l'analyse"
        '
        'TextBoxXFichierSelectionne
        '
        '
        '
        '
        Me.TextBoxXFichierSelectionne.Border.Class = "TextBoxBorder"
        Me.TextBoxXFichierSelectionne.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxXFichierSelectionne.Location = New System.Drawing.Point(12, 106)
        Me.TextBoxXFichierSelectionne.Name = "TextBoxXFichierSelectionne"
        Me.TextBoxXFichierSelectionne.PreventEnterBeep = True
        Me.TextBoxXFichierSelectionne.Size = New System.Drawing.Size(728, 20)
        Me.TextBoxXFichierSelectionne.TabIndex = 3
        Me.TextBoxXFichierSelectionne.Text = "Fichier selectionné"
        '
        'TextBoxXAnnalyse
        '
        Me.TextBoxXAnnalyse.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        '
        '
        '
        Me.TextBoxXAnnalyse.Border.Class = "TextBoxBorder"
        Me.TextBoxXAnnalyse.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxXAnnalyse.Location = New System.Drawing.Point(3, 10)
        Me.TextBoxXAnnalyse.Multiline = True
        Me.TextBoxXAnnalyse.Name = "TextBoxXAnnalyse"
        Me.TextBoxXAnnalyse.PreventEnterBeep = True
        Me.TextBoxXAnnalyse.Size = New System.Drawing.Size(1123, 284)
        Me.TextBoxXAnnalyse.TabIndex = 12
        Me.TextBoxXAnnalyse.Text = "annalyse"
        '
        'ButtonXLancerLimport
        '
        Me.ButtonXLancerLimport.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonXLancerLimport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonXLancerLimport.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonXLancerLimport.Enabled = False
        Me.ButtonXLancerLimport.Location = New System.Drawing.Point(831, 60)
        Me.ButtonXLancerLimport.Name = "ButtonXLancerLimport"
        Me.ButtonXLancerLimport.Size = New System.Drawing.Size(155, 23)
        Me.ButtonXLancerLimport.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonXLancerLimport.TabIndex = 13
        Me.ButtonXLancerLimport.Text = "Lancer l'import Equipements"
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.FileName = "OpenFileDialog1"
        '
        'SuperGridControlEquipements
        '
        Me.SuperGridControlEquipements.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SuperGridControlEquipements.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed
        Me.SuperGridControlEquipements.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.SuperGridControlEquipements.Location = New System.Drawing.Point(13, 14)
        Me.SuperGridControlEquipements.Name = "SuperGridControlEquipements"
        GridColumn3.DataPropertyName = "action"
        GridColumn3.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl)
        GridColumn3.HeaderText = "action"
        GridColumn3.Name = "action"
        GridColumn4.DataPropertyName = "repere"
        GridColumn4.HeaderText = "repere"
        GridColumn4.Name = "repere"
        GridColumn5.DataPropertyName = "designation"
        GridColumn5.HeaderText = "designation"
        GridColumn5.Name = "designation"
        GridColumn6.DataPropertyName = "present"
        GridColumn6.HeaderText = "present"
        GridColumn6.Name = "present"
        GridColumn6.Visible = False
        GridColumn7.DataPropertyName = "referent"
        GridColumn7.HeaderText = "referent"
        GridColumn7.Name = "referent"
        GridColumn8.DataPropertyName = "lot"
        GridColumn8.HeaderText = "lot"
        GridColumn8.Name = "lot"
        GridColumn9.DataPropertyName = "salle"
        GridColumn9.HeaderText = "Salle"
        GridColumn9.Name = "salle"
        GridColumn10.DataPropertyName = "categorie"
        GridColumn10.HeaderText = "Categorie"
        GridColumn10.Name = "categorie"
        Me.SuperGridControlEquipements.PrimaryGrid.Columns.Add(GridColumn3)
        Me.SuperGridControlEquipements.PrimaryGrid.Columns.Add(GridColumn4)
        Me.SuperGridControlEquipements.PrimaryGrid.Columns.Add(GridColumn5)
        Me.SuperGridControlEquipements.PrimaryGrid.Columns.Add(GridColumn6)
        Me.SuperGridControlEquipements.PrimaryGrid.Columns.Add(GridColumn7)
        Me.SuperGridControlEquipements.PrimaryGrid.Columns.Add(GridColumn8)
        Me.SuperGridControlEquipements.PrimaryGrid.Columns.Add(GridColumn9)
        Me.SuperGridControlEquipements.PrimaryGrid.Columns.Add(GridColumn10)
        Me.SuperGridControlEquipements.PrimaryGrid.PrimaryColumnIndex = 1
        Me.SuperGridControlEquipements.PrimaryGrid.ShowTreeButtons = True
        Me.SuperGridControlEquipements.PrimaryGrid.ShowTreeLines = True
        Me.SuperGridControlEquipements.Size = New System.Drawing.Size(774, 294)
        Me.SuperGridControlEquipements.TabIndex = 14
        Me.SuperGridControlEquipements.Text = "Equipements"
        '
        'ImageList
        '
        Me.ImageList.ImageStream = CType(resources.GetObject("ImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList.Images.SetKeyName(0, "OK")
        Me.ImageList.Images.SetKeyName(1, "ADD")
        Me.ImageList.Images.SetKeyName(2, "SUP")
        '
        'SuperGridControlcables
        '
        Me.SuperGridControlcables.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SuperGridControlcables.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed
        Me.SuperGridControlcables.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.SuperGridControlcables.Location = New System.Drawing.Point(13, 15)
        Me.SuperGridControlcables.Name = "SuperGridControlcables"
        GridColumn1.DataPropertyName = "referent"
        GridColumn1.HeaderText = "referent"
        GridColumn1.Name = "referent"
        GridColumn2.DataPropertyName = "action"
        GridColumn2.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl)
        GridColumn2.HeaderText = "action"
        GridColumn2.Name = "action"
        Me.SuperGridControlcables.PrimaryGrid.Columns.Add(GridColumn1)
        Me.SuperGridControlcables.PrimaryGrid.Columns.Add(GridColumn2)
        Me.SuperGridControlcables.Size = New System.Drawing.Size(938, 279)
        Me.SuperGridControlcables.TabIndex = 15
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
        'CablesBindingSource
        '
        Me.CablesBindingSource.DataMember = "cables"
        Me.CablesBindingSource.DataSource = Me.MydbDataSet
        '
        'CablesTableAdapter
        '
        Me.CablesTableAdapter.ClearBeforeFill = True
        '
        'Types_cableBindingSource
        '
        Me.Types_cableBindingSource.DataMember = "types_cable"
        Me.Types_cableBindingSource.DataSource = Me.MydbDataSet
        '
        'Types_cableTableAdapter
        '
        Me.Types_cableTableAdapter.ClearBeforeFill = True
        '
        'Sections_cablesBindingSource
        '
        Me.Sections_cablesBindingSource.DataMember = "sections_cables"
        Me.Sections_cablesBindingSource.DataSource = Me.MydbDataSet
        '
        'Sections_cablesTableAdapter
        '
        Me.Sections_cablesTableAdapter.ClearBeforeFill = True
        '
        'BatimentsTableAdapter
        '
        Me.BatimentsTableAdapter.ClearBeforeFill = True
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(809, 131)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(61, 23)
        Me.LabelX1.TabIndex = 9
        Me.LabelX1.Text = "Batiment :"
        '
        'SuperTabControl
        '
        Me.SuperTabControl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        '
        '
        '
        '
        '
        '
        Me.SuperTabControl.ControlBox.CloseBox.Name = ""
        '
        '
        '
        Me.SuperTabControl.ControlBox.MenuBox.Name = ""
        Me.SuperTabControl.ControlBox.Name = ""
        Me.SuperTabControl.ControlBox.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabControl.ControlBox.MenuBox, Me.SuperTabControl.ControlBox.CloseBox})
        Me.SuperTabControl.Controls.Add(Me.SuperTabControlPanel3)
        Me.SuperTabControl.Controls.Add(Me.SuperTabControlPanel1)
        Me.SuperTabControl.Controls.Add(Me.SuperTabControlPanel2)
        Me.SuperTabControl.Location = New System.Drawing.Point(12, 229)
        Me.SuperTabControl.Name = "SuperTabControl"
        Me.SuperTabControl.ReorderTabsEnabled = True
        Me.SuperTabControl.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.SuperTabControl.SelectedTabIndex = 1
        Me.SuperTabControl.Size = New System.Drawing.Size(1142, 325)
        Me.SuperTabControl.TabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SuperTabControl.TabIndex = 17
        Me.SuperTabControl.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabItem1, Me.SuperTabItem2, Me.SuperTabItem3})
        '
        'SuperTabControlPanel3
        '
        Me.SuperTabControlPanel3.Controls.Add(Me.SuperGridControlcables)
        Me.SuperTabControlPanel3.Controls.Add(Me.ButtonX1)
        Me.SuperTabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel3.Location = New System.Drawing.Point(0, 25)
        Me.SuperTabControlPanel3.Name = "SuperTabControlPanel3"
        Me.SuperTabControlPanel3.Size = New System.Drawing.Size(1142, 300)
        Me.SuperTabControlPanel3.TabIndex = 0
        Me.SuperTabControlPanel3.TabItem = Me.SuperTabItem3
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX1.Enabled = False
        Me.ButtonX1.Location = New System.Drawing.Point(973, 29)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Size = New System.Drawing.Size(155, 23)
        Me.ButtonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX1.TabIndex = 13
        Me.ButtonX1.Text = "Lancer l'import"
        '
        'SuperTabItem3
        '
        Me.SuperTabItem3.AttachedControl = Me.SuperTabControlPanel3
        Me.SuperTabItem3.GlobalItem = False
        Me.SuperTabItem3.Name = "SuperTabItem3"
        Me.SuperTabItem3.Text = "Câbles"
        '
        'SuperTabControlPanel1
        '
        Me.SuperTabControlPanel1.Controls.Add(Me.TextBoxXAnnalyse)
        Me.SuperTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel1.Location = New System.Drawing.Point(0, 25)
        Me.SuperTabControlPanel1.Name = "SuperTabControlPanel1"
        Me.SuperTabControlPanel1.Size = New System.Drawing.Size(1142, 300)
        Me.SuperTabControlPanel1.TabIndex = 1
        Me.SuperTabControlPanel1.TabItem = Me.SuperTabItem1
        '
        'SuperTabItem1
        '
        Me.SuperTabItem1.AttachedControl = Me.SuperTabControlPanel1
        Me.SuperTabItem1.GlobalItem = False
        Me.SuperTabItem1.Name = "SuperTabItem1"
        Me.SuperTabItem1.Text = "Analyse"
        '
        'SuperTabControlPanel2
        '
        Me.SuperTabControlPanel2.Controls.Add(Me.SuperGridControlEquipements)
        Me.SuperTabControlPanel2.Controls.Add(Me.ButtonXLancerLimport)
        Me.SuperTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel2.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel2.Name = "SuperTabControlPanel2"
        Me.SuperTabControlPanel2.Size = New System.Drawing.Size(1142, 325)
        Me.SuperTabControlPanel2.TabIndex = 0
        Me.SuperTabControlPanel2.TabItem = Me.SuperTabItem2
        '
        'SuperTabItem2
        '
        Me.SuperTabItem2.AttachedControl = Me.SuperTabControlPanel2
        Me.SuperTabItem2.GlobalItem = False
        Me.SuperTabItem2.Name = "SuperTabItem2"
        Me.SuperTabItem2.Text = "Equipements"
        '
        'CategoriesBindingSource
        '
        Me.CategoriesBindingSource.DataMember = "categories"
        Me.CategoriesBindingSource.DataSource = Me.MydbDataSet
        '
        'CategoriesTableAdapter
        '
        Me.CategoriesTableAdapter.ClearBeforeFill = True
        '
        'LotsBindingSource
        '
        Me.LotsBindingSource.DataMember = "lots"
        Me.LotsBindingSource.DataSource = Me.MydbDataSet
        '
        'LotsTableAdapter
        '
        Me.LotsTableAdapter.ClearBeforeFill = True
        '
        'SallesBindingSource
        '
        Me.SallesBindingSource.DataMember = "salles"
        Me.SallesBindingSource.DataSource = Me.MydbDataSet
        '
        'SallesTableAdapter
        '
        Me.SallesTableAdapter.ClearBeforeFill = True
        '
        'Cables_detailsBindingSource
        '
        Me.Cables_detailsBindingSource.DataMember = "cables_details"
        Me.Cables_detailsBindingSource.DataSource = Me.MydbDataSet
        '
        'Cables_detailsTableAdapter
        '
        Me.Cables_detailsTableAdapter.ClearBeforeFill = True
        '
        'OfficeFormImportNoteDeCalcul
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1418, 606)
        Me.Controls.Add(Me.SuperTabControl)
        Me.Controls.Add(Me.ComboBoxBatiment)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.LabelXEnDateDu)
        Me.Controls.Add(Me.LabelXIndice)
        Me.Controls.Add(Me.LabelXReference)
        Me.Controls.Add(Me.LabelXinfo)
        Me.Controls.Add(Me.DateTimePicker)
        Me.Controls.Add(Me.TextBoxXFichierSelectionne)
        Me.Controls.Add(Me.TextBoxXReference)
        Me.Controls.Add(Me.TextBoxXRevision)
        Me.Controls.Add(Me.CheckBoxXCaneco)
        Me.Controls.Add(Me.CheckBoxXTRCiel)
        Me.Controls.Add(Me.ButtonXLancerLannalyse)
        Me.Controls.Add(Me.ButtonXSelectionFichier)
        Me.Name = "OfficeFormImportNoteDeCalcul"
        Me.Text = "Import Note De Calcul"
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BatimentsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MydbDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EquipementsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CablesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Types_cableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Sections_cablesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SuperTabControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControl.ResumeLayout(False)
        Me.SuperTabControlPanel3.ResumeLayout(False)
        Me.SuperTabControlPanel1.ResumeLayout(False)
        Me.SuperTabControlPanel2.ResumeLayout(False)
        CType(Me.CategoriesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LotsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SallesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cables_detailsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents ButtonXSelectionFichier As DevComponents.DotNetBar.ButtonX
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Private WithEvents CheckBoxXTRCiel As DevComponents.DotNetBar.Controls.CheckBoxX
    Private WithEvents CheckBoxXCaneco As DevComponents.DotNetBar.Controls.CheckBoxX
    Private WithEvents TextBoxXRevision As DevComponents.DotNetBar.Controls.TextBoxX
    Private WithEvents TextBoxXReference As DevComponents.DotNetBar.Controls.TextBoxX
    Private WithEvents SuperValidator As DevComponents.DotNetBar.Validator.SuperValidator
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Highlighter1 As DevComponents.DotNetBar.Validator.Highlighter
    Friend WithEvents RequiredFieldValidator1 As DevComponents.DotNetBar.Validator.RequiredFieldValidator
    Friend WithEvents RequiredFieldValidator2 As DevComponents.DotNetBar.Validator.RequiredFieldValidator
    Private WithEvents LabelXinfo As DevComponents.DotNetBar.LabelX
    Private WithEvents DateTimePicker As System.Windows.Forms.DateTimePicker
    Private WithEvents LabelXIndice As DevComponents.DotNetBar.LabelX
    Private WithEvents LabelXReference As DevComponents.DotNetBar.LabelX
    Private WithEvents LabelXEnDateDu As DevComponents.DotNetBar.LabelX
    Private WithEvents TextBoxXFichierSelectionne As DevComponents.DotNetBar.Controls.TextBoxX
    Private WithEvents ButtonXLancerLannalyse As DevComponents.DotNetBar.ButtonX
    Private WithEvents TextBoxXAnnalyse As DevComponents.DotNetBar.Controls.TextBoxX
    Private WithEvents ButtonXLancerLimport As DevComponents.DotNetBar.ButtonX
    Private WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents EquipementsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents MydbDataSet As progelec.mydbDataSet
    Friend WithEvents EquipementsTableAdapter As progelec.mydbDataSetTableAdapters.equipementsTableAdapter
    Friend WithEvents TableAdapterManager As progelec.mydbDataSetTableAdapters.TableAdapterManager
    Friend WithEvents CablesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CablesTableAdapter As progelec.mydbDataSetTableAdapters.cablesTableAdapter
    Friend WithEvents Types_cableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Types_cableTableAdapter As progelec.mydbDataSetTableAdapters.types_cableTableAdapter
    Friend WithEvents Sections_cablesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Sections_cablesTableAdapter As progelec.mydbDataSetTableAdapters.sections_cablesTableAdapter
    Private WithEvents SuperGridControlEquipements As DevComponents.DotNetBar.SuperGrid.SuperGridControl
    Private WithEvents ImageList As System.Windows.Forms.ImageList
    Private WithEvents SuperGridControlcables As DevComponents.DotNetBar.SuperGrid.SuperGridControl
    Friend WithEvents BatimentsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents BatimentsTableAdapter As progelec.mydbDataSetTableAdapters.batimentsTableAdapter
    Private WithEvents ComboBoxBatiment As System.Windows.Forms.ComboBox
    Friend WithEvents RequiredFieldValidator3 As DevComponents.DotNetBar.Validator.RequiredFieldValidator
    Private WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Private WithEvents SuperTabControl As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents SuperTabControlPanel1 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SuperTabItem1 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel3 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SuperTabItem3 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel2 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SuperTabItem2 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents CategoriesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CategoriesTableAdapter As progelec.mydbDataSetTableAdapters.categoriesTableAdapter
    Friend WithEvents LotsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents LotsTableAdapter As progelec.mydbDataSetTableAdapters.lotsTableAdapter
    Friend WithEvents SallesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SallesTableAdapter As progelec.mydbDataSetTableAdapters.sallesTableAdapter
    Friend WithEvents Cables_detailsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Cables_detailsTableAdapter As progelec.mydbDataSetTableAdapters.cables_detailsTableAdapter
    Private WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
End Class
