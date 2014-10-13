<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormTouretsDetail
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
        Dim RepereLabel As System.Windows.Forms.Label
        Dim Long_estimeLabel As System.Windows.Forms.Label
        Dim Label1 As System.Windows.Forms.Label
        Dim Label2 As System.Windows.Forms.Label
        Dim Label3 As System.Windows.Forms.Label
        Dim Label6 As System.Windows.Forms.Label
        Dim DescriptionLabel As System.Windows.Forms.Label
        Dim Label5 As System.Windows.Forms.Label
        Dim Label7 As System.Windows.Forms.Label
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormTouretsDetail))
        Me.RepereTextBox = New System.Windows.Forms.TextBox()
        Me.TouretsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MydbDataSet = New progelec.mydbDataSet()
        Me.Long_estimeTextBox = New System.Windows.Forms.TextBox()
        Me.ActifCheckBox = New System.Windows.Forms.CheckBox()
        Me.Cables_details_has_touretsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX2 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX3 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX4 = New DevComponents.DotNetBar.ButtonX()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.SuperTabControl1 = New DevComponents.DotNetBar.SuperTabControl()
        Me.SuperTabControlPanel3 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.ButtonX = New DevComponents.DotNetBar.ButtonX()
        Me.Lst_cable_mise_touretDataGridViewX = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.IdcableDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RepereEquipementDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RepereSalleDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReferenceDepartDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RepereCableDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdcablesdetailsDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FilsDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LongueurDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SectionDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TypesDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SegregationDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RepereEquipement1DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RepereSalle1DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReferenceBornierDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CategorieDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LotcableDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ParcourDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WarningDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContrainteDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.LotteneantDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LotaboutissantDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Idcable1DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TouretdefDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TouretreelDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CaseModedeposeWhenTrueThenMonoCoucheElseMultiCouchesEndDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Lst_cable_mise_touretBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.LabelXGlisserLesCablesDansLeTouret = New DevComponents.DotNetBar.LabelX()
        Me.DataGridViewX1 = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.IdcableDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RepereEquipementDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RepereSalleDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReferenceDepartDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RepereCableDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdcablesdetailsDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FilsDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LongueurDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SectionDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TypesDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SegregationDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RepereEquipement1DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RepereSalle1DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReferenceBornierDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CategorieDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LotcableDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ParcourDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WarningDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContrainteDataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.LotteneantDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LotaboutissantDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Idcable1DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TouretdefDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TouretreelDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CaseModedeposeWhenTrueThenMonoCoucheElseMultiCouchesEndDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Mise_en_touret = New System.Windows.Forms.BindingSource(Me.components)
        Me.SuperTabItem3 = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel4 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.Lst_cable_touret_poseDataGridViewX = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.DataGridViewTextBoxColumn26 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn27 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn28 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn29 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn30 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn31 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn32 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn33 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn34 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn35 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn36 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn37 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn38 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn40 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn41 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn44 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn45 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn46 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewCheckBoxColumn5 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewTextBoxColumn47 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn48 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn49 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn50 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn51 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn52 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn53 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Lst_cable_touret_poseBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SuperTabItem4 = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel1 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.Lst_fourniture_touretDataGridViewX = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewCheckBoxColumn2 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewCheckBoxColumn3 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn19 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewCheckBoxColumn4 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Lst_fourniture_touretBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SuperTabItem1 = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel2 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.DescriptionTextBox = New System.Windows.Forms.TextBox()
        Me.DocumentsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Lst_doc_touretDataGridViewX = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.DataGridViewTextBoxColumn20 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn21 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn22 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn23 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn24 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn25 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Lst_doc_touretBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.LabelXselect = New DevComponents.DotNetBar.LabelX()
        Me.SwitchButtonDocSelect = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.ButtonX6 = New DevComponents.DotNetBar.ButtonX()
        Me.SuperTabItem2 = New DevComponents.DotNetBar.SuperTabItem()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.ButtonX5 = New DevComponents.DotNetBar.ButtonX()
        Me.ComboBoxEx1 = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Donnee_phyBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.label4 = New System.Windows.Forms.Label()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.SuperValidator = New DevComponents.DotNetBar.Validator.SuperValidator()
        Me.RequiredFieldValidator1 = New DevComponents.DotNetBar.Validator.RequiredFieldValidator("Your error message here.")
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Highlighter1 = New DevComponents.DotNetBar.Validator.Highlighter()
        Me.CircularProgress = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.Lst_cablesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Tourets_has_fournituresBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CablesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Fournitures_has_documentsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TouretsTableAdapter = New progelec.mydbDataSetTableAdapters.touretsTableAdapter()
        Me.Tourets_has_fournituresTableAdapter = New progelec.mydbDataSetTableAdapters.tourets_has_fournituresTableAdapter()
        Me.Cables_details_has_touretsTableAdapter = New progelec.mydbDataSetTableAdapters.cables_details_has_touretsTableAdapter()
        Me.Fournitures_has_documentsTableAdapter = New progelec.mydbDataSetTableAdapters.fournitures_has_documentsTableAdapter()
        Me.DocumentsTableAdapter = New progelec.mydbDataSetTableAdapters.documentsTableAdapter()
        Me.Types_cableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Types_cableTableAdapter = New progelec.mydbDataSetTableAdapters.types_cableTableAdapter()
        Me.TableAdapterManager = New progelec.mydbDataSetTableAdapters.TableAdapterManager()
        Me.Donnees_cablesTableAdapter = New progelec.mydbDataSetTableAdapters.donnees_cablesTableAdapter()
        Me.Sections_cablesTableAdapter = New progelec.mydbDataSetTableAdapters.sections_cablesTableAdapter()
        Me.Sections_cablesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Donnees_cablesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Lst_fourniture_touretTableAdapter = New progelec.mydbDataSetTableAdapters.lst_fourniture_touretTableAdapter()
        Me.Donnee_phyTableAdapter = New progelec.mydbDataSetTableAdapters.donnee_phyTableAdapter()
        Me.CablesTableAdapter = New progelec.mydbDataSetTableAdapters.cablesTableAdapter()
        Me.Lst_cablesTableAdapter = New progelec.mydbDataSetTableAdapters.lst_cablesTableAdapter()
        Me.Documents_has_touretsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Documents_has_touretsTableAdapter = New progelec.mydbDataSetTableAdapters.documents_has_touretsTableAdapter()
        Me.Lst_doc_touretTableAdapter = New progelec.mydbDataSetTableAdapters.lst_doc_touretTableAdapter()
        Me.Lst_cable_mise_touretTableAdapter = New progelec.mydbDataSetTableAdapters.lst_cable_mise_touretTableAdapter()
        Me.Mise_en_touret_TableAdapter = New progelec.mydbDataSetTableAdapters.lst_cable_mise_touretTableAdapter()
        Me.Lst_cable_touret_poseTableAdapter = New progelec.mydbDataSetTableAdapters.lst_cable_touret_poseTableAdapter()
        Me.ButtonX7 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX8 = New DevComponents.DotNetBar.ButtonX()
        RepereLabel = New System.Windows.Forms.Label()
        Long_estimeLabel = New System.Windows.Forms.Label()
        Label1 = New System.Windows.Forms.Label()
        Label2 = New System.Windows.Forms.Label()
        Label3 = New System.Windows.Forms.Label()
        Label6 = New System.Windows.Forms.Label()
        DescriptionLabel = New System.Windows.Forms.Label()
        Label5 = New System.Windows.Forms.Label()
        Label7 = New System.Windows.Forms.Label()
        CType(Me.TouretsBindingSource,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.MydbDataSet,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.Cables_details_has_touretsBindingSource,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.SuperTabControl1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuperTabControl1.SuspendLayout
        Me.SuperTabControlPanel3.SuspendLayout
        CType(Me.Lst_cable_mise_touretDataGridViewX,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.Lst_cable_mise_touretBindingSource,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.DataGridViewX1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.Mise_en_touret,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuperTabControlPanel4.SuspendLayout
        CType(Me.Lst_cable_touret_poseDataGridViewX,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.Lst_cable_touret_poseBindingSource,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuperTabControlPanel1.SuspendLayout
        CType(Me.Lst_fourniture_touretDataGridViewX,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.Lst_fourniture_touretBindingSource,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuperTabControlPanel2.SuspendLayout
        CType(Me.DocumentsBindingSource,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.Lst_doc_touretDataGridViewX,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.Lst_doc_touretBindingSource1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.Donnee_phyBindingSource,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.ErrorProvider1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.Lst_cablesBindingSource,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.Tourets_has_fournituresBindingSource,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.CablesBindingSource,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.Fournitures_has_documentsBindingSource,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.Types_cableBindingSource,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.Sections_cablesBindingSource,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.Donnees_cablesBindingSource,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.Documents_has_touretsBindingSource,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'RepereLabel
        '
        RepereLabel.AutoSize = true
        RepereLabel.Location = New System.Drawing.Point(25, 83)
        RepereLabel.Name = "RepereLabel"
        RepereLabel.Size = New System.Drawing.Size(45, 13)
        RepereLabel.TabIndex = 1
        RepereLabel.Text = "Repere:"
        '
        'Long_estimeLabel
        '
        Long_estimeLabel.AutoSize = true
        Long_estimeLabel.Location = New System.Drawing.Point(23, 154)
        Long_estimeLabel.Name = "Long_estimeLabel"
        Long_estimeLabel.Size = New System.Drawing.Size(67, 13)
        Long_estimeLabel.TabIndex = 3
        Long_estimeLabel.Text = "Long estime:"
        '
        'Label1
        '
        Label1.AutoSize = true
        Label1.Location = New System.Drawing.Point(226, 154)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(54, 13)
        Label1.TabIndex = 3
        Label1.Text = "Long réel:"
        '
        'Label2
        '
        Label2.AutoSize = true
        Label2.Location = New System.Drawing.Point(427, 154)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(69, 13)
        Label2.TabIndex = 3
        Label2.Text = "Long restant:"
        '
        'Label3
        '
        Label3.AutoSize = true
        Label3.Location = New System.Drawing.Point(226, 180)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(35, 13)
        Label3.TabIndex = 3
        Label3.Text = "Debit:"
        '
        'Label6
        '
        Label6.AutoSize = true
        Label6.Location = New System.Drawing.Point(23, 184)
        Label6.Name = "Label6"
        Label6.Size = New System.Drawing.Size(60, 13)
        Label6.TabIndex = 3
        Label6.Text = "Long Max :"
        '
        'DescriptionLabel
        '
        DescriptionLabel.AutoSize = true
        DescriptionLabel.Location = New System.Drawing.Point(995, 167)
        DescriptionLabel.Name = "DescriptionLabel"
        DescriptionLabel.Size = New System.Drawing.Size(61, 13)
        DescriptionLabel.TabIndex = 13
        DescriptionLabel.Text = "description:"
        '
        'Label5
        '
        Label5.AutoSize = true
        Label5.Location = New System.Drawing.Point(350, 52)
        Label5.Name = "Label5"
        Label5.Size = New System.Drawing.Size(49, 13)
        Label5.TabIndex = 3
        Label5.Text = "Section :"
        '
        'Label7
        '
        Label7.AutoSize = true
        Label7.Location = New System.Drawing.Point(530, 52)
        Label7.Name = "Label7"
        Label7.Size = New System.Drawing.Size(37, 13)
        Label7.TabIndex = 3
        Label7.Text = "Type :"
        '
        'RepereTextBox
        '
        Me.RepereTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TouretsBindingSource, "Repere", true))
        Me.RepereTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 16!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.RepereTextBox.ForeColor = System.Drawing.Color.Red
        Me.RepereTextBox.Location = New System.Drawing.Point(85, 71)
        Me.RepereTextBox.Name = "RepereTextBox"
        Me.RepereTextBox.Size = New System.Drawing.Size(225, 32)
        Me.RepereTextBox.TabIndex = 2
        Me.RepereTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.SuperValidator.SetValidator1(Me.RepereTextBox, Me.RequiredFieldValidator1)
        '
        'TouretsBindingSource
        '
        Me.TouretsBindingSource.DataMember = "tourets"
        Me.TouretsBindingSource.DataSource = Me.MydbDataSet
        '
        'MydbDataSet
        '
        Me.MydbDataSet.DataSetName = "mydbDataSet"
        Me.MydbDataSet.EnforceConstraints = false
        Me.MydbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Long_estimeTextBox
        '
        Me.Long_estimeTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TouretsBindingSource, "Long_estime", true))
        Me.Long_estimeTextBox.Location = New System.Drawing.Point(96, 151)
        Me.Long_estimeTextBox.Name = "Long_estimeTextBox"
        Me.Long_estimeTextBox.Size = New System.Drawing.Size(100, 20)
        Me.Long_estimeTextBox.TabIndex = 4
        '
        'ActifCheckBox
        '
        Me.ActifCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.TouretsBindingSource, "Actif", true))
        Me.ActifCheckBox.Location = New System.Drawing.Point(28, 118)
        Me.ActifCheckBox.Name = "ActifCheckBox"
        Me.ActifCheckBox.Size = New System.Drawing.Size(104, 24)
        Me.ActifCheckBox.TabIndex = 6
        Me.ActifCheckBox.Text = "Actif"
        Me.ActifCheckBox.UseVisualStyleBackColor = true
        '
        'Cables_details_has_touretsBindingSource
        '
        Me.Cables_details_has_touretsBindingSource.DataMember = "cables_details_has_tourets"
        Me.Cables_details_has_touretsBindingSource.DataSource = Me.MydbDataSet
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX1.Location = New System.Drawing.Point(1265, 5)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Size = New System.Drawing.Size(179, 31)
        Me.ButtonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX1.TabIndex = 10
        Me.ButtonX1.Text = "Fourniture Selection"
        '
        'ButtonX2
        '
        Me.ButtonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX2.Enabled = false
        Me.ButtonX2.Location = New System.Drawing.Point(349, 51)
        Me.ButtonX2.Name = "ButtonX2"
        Me.ButtonX2.Size = New System.Drawing.Size(133, 23)
        Me.ButtonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX2.TabIndex = 11
        Me.ButtonX2.Text = "Enregistrement Doc"
        '
        'ButtonX3
        '
        Me.ButtonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX3.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX3.Location = New System.Drawing.Point(11, 121)
        Me.ButtonX3.Name = "ButtonX3"
        Me.ButtonX3.Size = New System.Drawing.Size(133, 23)
        Me.ButtonX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX3.TabIndex = 11
        Me.ButtonX3.Text = "Visualisation"
        '
        'ButtonX4
        '
        Me.ButtonX4.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX4.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX4.Location = New System.Drawing.Point(349, 22)
        Me.ButtonX4.Name = "ButtonX4"
        Me.ButtonX4.Size = New System.Drawing.Size(133, 23)
        Me.ButtonX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX4.TabIndex = 11
        Me.ButtonX4.Text = "Selection Fichier"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(211, 133)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(271, 20)
        Me.TextBox1.TabIndex = 4
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(211, 102)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(271, 20)
        Me.TextBox2.TabIndex = 4
        '
        'SuperTabControl1
        '
        Me.SuperTabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
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
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel3)
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel4)
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel1)
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel2)
        Me.SuperTabControl1.Location = New System.Drawing.Point(17, 207)
        Me.SuperTabControl1.Name = "SuperTabControl1"
        Me.SuperTabControl1.ReorderTabsEnabled = true
        Me.SuperTabControl1.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.SuperTabControl1.SelectedTabIndex = 1
        Me.SuperTabControl1.Size = New System.Drawing.Size(1551, 372)
        Me.SuperTabControl1.TabAlignment = DevComponents.DotNetBar.eTabStripAlignment.Right
        Me.SuperTabControl1.TabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.SuperTabControl1.TabIndex = 12
        Me.SuperTabControl1.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabItem4, Me.SuperTabItem1, Me.SuperTabItem2, Me.SuperTabItem3})
        Me.SuperTabControl1.Text = "SuperTabControl1"
        '
        'SuperTabControlPanel3
        '
        Me.SuperTabControlPanel3.AutoScroll = true
        Me.SuperTabControlPanel3.Controls.Add(Me.ButtonX)
        Me.SuperTabControlPanel3.Controls.Add(Me.Lst_cable_mise_touretDataGridViewX)
        Me.SuperTabControlPanel3.Controls.Add(Me.LabelX2)
        Me.SuperTabControlPanel3.Controls.Add(Me.LabelX1)
        Me.SuperTabControlPanel3.Controls.Add(Me.LabelXGlisserLesCablesDansLeTouret)
        Me.SuperTabControlPanel3.Controls.Add(Me.DataGridViewX1)
        Me.SuperTabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel3.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel3.Name = "SuperTabControlPanel3"
        Me.SuperTabControlPanel3.Size = New System.Drawing.Size(1447, 372)
        Me.SuperTabControlPanel3.TabIndex = 3
        Me.SuperTabControlPanel3.TabItem = Me.SuperTabItem3
        '
        'ButtonX
        '
        Me.ButtonX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX.Location = New System.Drawing.Point(306, 25)
        Me.ButtonX.Name = "ButtonX"
        Me.ButtonX.Size = New System.Drawing.Size(75, 23)
        Me.ButtonX.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX.TabIndex = 20
        Me.ButtonX.Text = "Supprimer"
        '
        'Lst_cable_mise_touretDataGridViewX
        '
        Me.Lst_cable_mise_touretDataGridViewX.AutoGenerateColumns = false
        Me.Lst_cable_mise_touretDataGridViewX.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Lst_cable_mise_touretDataGridViewX.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdcableDataGridViewTextBoxColumn, Me.RepereEquipementDataGridViewTextBoxColumn, Me.RepereSalleDataGridViewTextBoxColumn, Me.ReferenceDepartDataGridViewTextBoxColumn, Me.RepereCableDataGridViewTextBoxColumn, Me.IdcablesdetailsDataGridViewTextBoxColumn, Me.FilsDataGridViewTextBoxColumn, Me.LongueurDataGridViewTextBoxColumn, Me.SectionDataGridViewTextBoxColumn, Me.TypesDataGridViewTextBoxColumn, Me.SegregationDataGridViewTextBoxColumn, Me.RepereEquipement1DataGridViewTextBoxColumn, Me.RepereSalle1DataGridViewTextBoxColumn, Me.ReferenceBornierDataGridViewTextBoxColumn, Me.CategorieDataGridViewTextBoxColumn, Me.LotcableDataGridViewTextBoxColumn, Me.ParcourDataGridViewTextBoxColumn, Me.WarningDataGridViewTextBoxColumn, Me.ContrainteDataGridViewCheckBoxColumn, Me.LotteneantDataGridViewTextBoxColumn, Me.LotaboutissantDataGridViewTextBoxColumn, Me.DateDataGridViewTextBoxColumn, Me.Idcable1DataGridViewTextBoxColumn, Me.TouretdefDataGridViewTextBoxColumn, Me.TouretreelDataGridViewTextBoxColumn, Me.CaseModedeposeWhenTrueThenMonoCoucheElseMultiCouchesEndDataGridViewTextBoxColumn})
        Me.Lst_cable_mise_touretDataGridViewX.DataSource = Me.Lst_cable_mise_touretBindingSource
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Lst_cable_mise_touretDataGridViewX.DefaultCellStyle = DataGridViewCellStyle1
        Me.Lst_cable_mise_touretDataGridViewX.GridColor = System.Drawing.Color.FromArgb(CType(CType(170,Byte),Integer), CType(CType(170,Byte),Integer), CType(CType(170,Byte),Integer))
        Me.Lst_cable_mise_touretDataGridViewX.Location = New System.Drawing.Point(766, 93)
        Me.Lst_cable_mise_touretDataGridViewX.Name = "Lst_cable_mise_touretDataGridViewX"
        Me.Lst_cable_mise_touretDataGridViewX.Size = New System.Drawing.Size(664, 277)
        Me.Lst_cable_mise_touretDataGridViewX.TabIndex = 19
        '
        'IdcableDataGridViewTextBoxColumn
        '
        Me.IdcableDataGridViewTextBoxColumn.DataPropertyName = "idcable"
        Me.IdcableDataGridViewTextBoxColumn.HeaderText = "idcable"
        Me.IdcableDataGridViewTextBoxColumn.Name = "IdcableDataGridViewTextBoxColumn"
        Me.IdcableDataGridViewTextBoxColumn.Visible = false
        '
        'RepereEquipementDataGridViewTextBoxColumn
        '
        Me.RepereEquipementDataGridViewTextBoxColumn.DataPropertyName = "repere equipement"
        Me.RepereEquipementDataGridViewTextBoxColumn.HeaderText = "repere equipement"
        Me.RepereEquipementDataGridViewTextBoxColumn.Name = "RepereEquipementDataGridViewTextBoxColumn"
        '
        'RepereSalleDataGridViewTextBoxColumn
        '
        Me.RepereSalleDataGridViewTextBoxColumn.DataPropertyName = "repere salle"
        Me.RepereSalleDataGridViewTextBoxColumn.HeaderText = "repere salle"
        Me.RepereSalleDataGridViewTextBoxColumn.Name = "RepereSalleDataGridViewTextBoxColumn"
        '
        'ReferenceDepartDataGridViewTextBoxColumn
        '
        Me.ReferenceDepartDataGridViewTextBoxColumn.DataPropertyName = "reference depart"
        Me.ReferenceDepartDataGridViewTextBoxColumn.HeaderText = "reference depart"
        Me.ReferenceDepartDataGridViewTextBoxColumn.Name = "ReferenceDepartDataGridViewTextBoxColumn"
        '
        'RepereCableDataGridViewTextBoxColumn
        '
        Me.RepereCableDataGridViewTextBoxColumn.DataPropertyName = "repere cable"
        Me.RepereCableDataGridViewTextBoxColumn.HeaderText = "repere cable"
        Me.RepereCableDataGridViewTextBoxColumn.Name = "RepereCableDataGridViewTextBoxColumn"
        '
        'IdcablesdetailsDataGridViewTextBoxColumn
        '
        Me.IdcablesdetailsDataGridViewTextBoxColumn.DataPropertyName = "idcables_details"
        Me.IdcablesdetailsDataGridViewTextBoxColumn.HeaderText = "idcables_details"
        Me.IdcablesdetailsDataGridViewTextBoxColumn.Name = "IdcablesdetailsDataGridViewTextBoxColumn"
        Me.IdcablesdetailsDataGridViewTextBoxColumn.Visible = false
        '
        'FilsDataGridViewTextBoxColumn
        '
        Me.FilsDataGridViewTextBoxColumn.DataPropertyName = "fils"
        Me.FilsDataGridViewTextBoxColumn.HeaderText = "fils"
        Me.FilsDataGridViewTextBoxColumn.Name = "FilsDataGridViewTextBoxColumn"
        '
        'LongueurDataGridViewTextBoxColumn
        '
        Me.LongueurDataGridViewTextBoxColumn.DataPropertyName = "longueur"
        Me.LongueurDataGridViewTextBoxColumn.HeaderText = "longueur"
        Me.LongueurDataGridViewTextBoxColumn.Name = "LongueurDataGridViewTextBoxColumn"
        '
        'SectionDataGridViewTextBoxColumn
        '
        Me.SectionDataGridViewTextBoxColumn.DataPropertyName = "section"
        Me.SectionDataGridViewTextBoxColumn.HeaderText = "section"
        Me.SectionDataGridViewTextBoxColumn.Name = "SectionDataGridViewTextBoxColumn"
        '
        'TypesDataGridViewTextBoxColumn
        '
        Me.TypesDataGridViewTextBoxColumn.DataPropertyName = "types"
        Me.TypesDataGridViewTextBoxColumn.HeaderText = "types"
        Me.TypesDataGridViewTextBoxColumn.Name = "TypesDataGridViewTextBoxColumn"
        '
        'SegregationDataGridViewTextBoxColumn
        '
        Me.SegregationDataGridViewTextBoxColumn.DataPropertyName = "segregation"
        Me.SegregationDataGridViewTextBoxColumn.HeaderText = "segregation"
        Me.SegregationDataGridViewTextBoxColumn.Name = "SegregationDataGridViewTextBoxColumn"
        '
        'RepereEquipement1DataGridViewTextBoxColumn
        '
        Me.RepereEquipement1DataGridViewTextBoxColumn.DataPropertyName = "repere equipement1"
        Me.RepereEquipement1DataGridViewTextBoxColumn.HeaderText = "repere equipement1"
        Me.RepereEquipement1DataGridViewTextBoxColumn.Name = "RepereEquipement1DataGridViewTextBoxColumn"
        '
        'RepereSalle1DataGridViewTextBoxColumn
        '
        Me.RepereSalle1DataGridViewTextBoxColumn.DataPropertyName = "repere salle1"
        Me.RepereSalle1DataGridViewTextBoxColumn.HeaderText = "repere salle1"
        Me.RepereSalle1DataGridViewTextBoxColumn.Name = "RepereSalle1DataGridViewTextBoxColumn"
        '
        'ReferenceBornierDataGridViewTextBoxColumn
        '
        Me.ReferenceBornierDataGridViewTextBoxColumn.DataPropertyName = "reference bornier"
        Me.ReferenceBornierDataGridViewTextBoxColumn.HeaderText = "reference bornier"
        Me.ReferenceBornierDataGridViewTextBoxColumn.Name = "ReferenceBornierDataGridViewTextBoxColumn"
        '
        'CategorieDataGridViewTextBoxColumn
        '
        Me.CategorieDataGridViewTextBoxColumn.DataPropertyName = "categorie"
        Me.CategorieDataGridViewTextBoxColumn.HeaderText = "categorie"
        Me.CategorieDataGridViewTextBoxColumn.Name = "CategorieDataGridViewTextBoxColumn"
        '
        'LotcableDataGridViewTextBoxColumn
        '
        Me.LotcableDataGridViewTextBoxColumn.DataPropertyName = "lot_cable"
        Me.LotcableDataGridViewTextBoxColumn.HeaderText = "lot_cable"
        Me.LotcableDataGridViewTextBoxColumn.Name = "LotcableDataGridViewTextBoxColumn"
        '
        'ParcourDataGridViewTextBoxColumn
        '
        Me.ParcourDataGridViewTextBoxColumn.DataPropertyName = "parcour"
        Me.ParcourDataGridViewTextBoxColumn.HeaderText = "parcour"
        Me.ParcourDataGridViewTextBoxColumn.Name = "ParcourDataGridViewTextBoxColumn"
        '
        'WarningDataGridViewTextBoxColumn
        '
        Me.WarningDataGridViewTextBoxColumn.DataPropertyName = "warning"
        Me.WarningDataGridViewTextBoxColumn.HeaderText = "warning"
        Me.WarningDataGridViewTextBoxColumn.Name = "WarningDataGridViewTextBoxColumn"
        '
        'ContrainteDataGridViewCheckBoxColumn
        '
        Me.ContrainteDataGridViewCheckBoxColumn.DataPropertyName = "Contrainte"
        Me.ContrainteDataGridViewCheckBoxColumn.HeaderText = "Contrainte"
        Me.ContrainteDataGridViewCheckBoxColumn.Name = "ContrainteDataGridViewCheckBoxColumn"
        '
        'LotteneantDataGridViewTextBoxColumn
        '
        Me.LotteneantDataGridViewTextBoxColumn.DataPropertyName = "lot_teneant"
        Me.LotteneantDataGridViewTextBoxColumn.HeaderText = "lot_teneant"
        Me.LotteneantDataGridViewTextBoxColumn.Name = "LotteneantDataGridViewTextBoxColumn"
        '
        'LotaboutissantDataGridViewTextBoxColumn
        '
        Me.LotaboutissantDataGridViewTextBoxColumn.DataPropertyName = "lot_aboutissant"
        Me.LotaboutissantDataGridViewTextBoxColumn.HeaderText = "lot_aboutissant"
        Me.LotaboutissantDataGridViewTextBoxColumn.Name = "LotaboutissantDataGridViewTextBoxColumn"
        '
        'DateDataGridViewTextBoxColumn
        '
        Me.DateDataGridViewTextBoxColumn.DataPropertyName = "date"
        Me.DateDataGridViewTextBoxColumn.HeaderText = "date"
        Me.DateDataGridViewTextBoxColumn.Name = "DateDataGridViewTextBoxColumn"
        '
        'Idcable1DataGridViewTextBoxColumn
        '
        Me.Idcable1DataGridViewTextBoxColumn.DataPropertyName = "idcable1"
        Me.Idcable1DataGridViewTextBoxColumn.HeaderText = "idcable1"
        Me.Idcable1DataGridViewTextBoxColumn.Name = "Idcable1DataGridViewTextBoxColumn"
        Me.Idcable1DataGridViewTextBoxColumn.Visible = false
        '
        'TouretdefDataGridViewTextBoxColumn
        '
        Me.TouretdefDataGridViewTextBoxColumn.DataPropertyName = "Touret_def"
        Me.TouretdefDataGridViewTextBoxColumn.HeaderText = "Touret_def"
        Me.TouretdefDataGridViewTextBoxColumn.Name = "TouretdefDataGridViewTextBoxColumn"
        '
        'TouretreelDataGridViewTextBoxColumn
        '
        Me.TouretreelDataGridViewTextBoxColumn.DataPropertyName = "Touret_reel"
        Me.TouretreelDataGridViewTextBoxColumn.HeaderText = "Touret_reel"
        Me.TouretreelDataGridViewTextBoxColumn.Name = "TouretreelDataGridViewTextBoxColumn"
        '
        'CaseModedeposeWhenTrueThenMonoCoucheElseMultiCouchesEndDataGridViewTextBoxColumn
        '
        Me.CaseModedeposeWhenTrueThenMonoCoucheElseMultiCouchesEndDataGridViewTextBoxColumn.DataPropertyName = "case mode_de_pose"&Global.Microsoft.VisualBasic.ChrW(10)&"        when true then 'MonoCouche'"&Global.Microsoft.VisualBasic.ChrW(10)&"        else 'MultiCouches'"& _ 
    ""&Global.Microsoft.VisualBasic.ChrW(10)&"    end"
        Me.CaseModedeposeWhenTrueThenMonoCoucheElseMultiCouchesEndDataGridViewTextBoxColumn.HeaderText = "case mode_de_pose"&Global.Microsoft.VisualBasic.ChrW(10)&"        when true then 'MonoCouche'"&Global.Microsoft.VisualBasic.ChrW(10)&"        else 'MultiCouches'"& _ 
    ""&Global.Microsoft.VisualBasic.ChrW(10)&"    end"
        Me.CaseModedeposeWhenTrueThenMonoCoucheElseMultiCouchesEndDataGridViewTextBoxColumn.Name = "CaseModedeposeWhenTrueThenMonoCoucheElseMultiCouchesEndDataGridViewTextBoxColumn"
        '
        'Lst_cable_mise_touretBindingSource
        '
        Me.Lst_cable_mise_touretBindingSource.DataMember = "lst_cable_mise_touret"
        Me.Lst_cable_mise_touretBindingSource.DataSource = Me.MydbDataSet
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Location = New System.Drawing.Point(1157, 64)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(221, 23)
        Me.LabelX2.TabIndex = 19
        Me.LabelX2.Text = "Cables en attente de mise en touret"
        Me.LabelX2.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(11, 64)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(221, 23)
        Me.LabelX1.TabIndex = 19
        Me.LabelX1.Text = "Câbles associés"
        Me.LabelX1.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelXGlisserLesCablesDansLeTouret
        '
        '
        '
        '
        Me.LabelXGlisserLesCablesDansLeTouret.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelXGlisserLesCablesDansLeTouret.Location = New System.Drawing.Point(622, 64)
        Me.LabelXGlisserLesCablesDansLeTouret.Name = "LabelXGlisserLesCablesDansLeTouret"
        Me.LabelXGlisserLesCablesDansLeTouret.Size = New System.Drawing.Size(246, 23)
        Me.LabelXGlisserLesCablesDansLeTouret.TabIndex = 19
        Me.LabelXGlisserLesCablesDansLeTouret.Text = "Glisser les cables dans le touret"
        Me.LabelXGlisserLesCablesDansLeTouret.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'DataGridViewX1
        '
        Me.DataGridViewX1.AllowDrop = true
        Me.DataGridViewX1.AutoGenerateColumns = false
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewX1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewX1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdcableDataGridViewTextBoxColumn1, Me.RepereEquipementDataGridViewTextBoxColumn1, Me.RepereSalleDataGridViewTextBoxColumn1, Me.ReferenceDepartDataGridViewTextBoxColumn1, Me.RepereCableDataGridViewTextBoxColumn1, Me.IdcablesdetailsDataGridViewTextBoxColumn1, Me.FilsDataGridViewTextBoxColumn1, Me.LongueurDataGridViewTextBoxColumn1, Me.SectionDataGridViewTextBoxColumn1, Me.TypesDataGridViewTextBoxColumn1, Me.SegregationDataGridViewTextBoxColumn1, Me.RepereEquipement1DataGridViewTextBoxColumn1, Me.RepereSalle1DataGridViewTextBoxColumn1, Me.ReferenceBornierDataGridViewTextBoxColumn1, Me.CategorieDataGridViewTextBoxColumn1, Me.LotcableDataGridViewTextBoxColumn1, Me.ParcourDataGridViewTextBoxColumn1, Me.WarningDataGridViewTextBoxColumn1, Me.ContrainteDataGridViewCheckBoxColumn1, Me.LotteneantDataGridViewTextBoxColumn1, Me.LotaboutissantDataGridViewTextBoxColumn1, Me.DateDataGridViewTextBoxColumn1, Me.Idcable1DataGridViewTextBoxColumn1, Me.TouretdefDataGridViewTextBoxColumn1, Me.TouretreelDataGridViewTextBoxColumn1, Me.CaseModedeposeWhenTrueThenMonoCoucheElseMultiCouchesEndDataGridViewTextBoxColumn1})
        Me.DataGridViewX1.DataSource = Me.Mise_en_touret
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewX1.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewX1.EnableHeadersVisualStyles = false
        Me.DataGridViewX1.GridColor = System.Drawing.Color.FromArgb(CType(CType(170,Byte),Integer), CType(CType(170,Byte),Integer), CType(CType(170,Byte),Integer))
        Me.DataGridViewX1.Location = New System.Drawing.Point(14, 93)
        Me.DataGridViewX1.Name = "DataGridViewX1"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewX1.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewX1.Size = New System.Drawing.Size(688, 277)
        Me.DataGridViewX1.TabIndex = 18
        '
        'IdcableDataGridViewTextBoxColumn1
        '
        Me.IdcableDataGridViewTextBoxColumn1.DataPropertyName = "idcable"
        Me.IdcableDataGridViewTextBoxColumn1.HeaderText = "idcable"
        Me.IdcableDataGridViewTextBoxColumn1.Name = "IdcableDataGridViewTextBoxColumn1"
        Me.IdcableDataGridViewTextBoxColumn1.Visible = false
        '
        'RepereEquipementDataGridViewTextBoxColumn1
        '
        Me.RepereEquipementDataGridViewTextBoxColumn1.DataPropertyName = "repere equipement"
        Me.RepereEquipementDataGridViewTextBoxColumn1.HeaderText = "repere equipement"
        Me.RepereEquipementDataGridViewTextBoxColumn1.Name = "RepereEquipementDataGridViewTextBoxColumn1"
        '
        'RepereSalleDataGridViewTextBoxColumn1
        '
        Me.RepereSalleDataGridViewTextBoxColumn1.DataPropertyName = "repere salle"
        Me.RepereSalleDataGridViewTextBoxColumn1.HeaderText = "repere salle"
        Me.RepereSalleDataGridViewTextBoxColumn1.Name = "RepereSalleDataGridViewTextBoxColumn1"
        '
        'ReferenceDepartDataGridViewTextBoxColumn1
        '
        Me.ReferenceDepartDataGridViewTextBoxColumn1.DataPropertyName = "reference depart"
        Me.ReferenceDepartDataGridViewTextBoxColumn1.HeaderText = "reference depart"
        Me.ReferenceDepartDataGridViewTextBoxColumn1.Name = "ReferenceDepartDataGridViewTextBoxColumn1"
        '
        'RepereCableDataGridViewTextBoxColumn1
        '
        Me.RepereCableDataGridViewTextBoxColumn1.DataPropertyName = "repere cable"
        Me.RepereCableDataGridViewTextBoxColumn1.HeaderText = "repere cable"
        Me.RepereCableDataGridViewTextBoxColumn1.Name = "RepereCableDataGridViewTextBoxColumn1"
        '
        'IdcablesdetailsDataGridViewTextBoxColumn1
        '
        Me.IdcablesdetailsDataGridViewTextBoxColumn1.DataPropertyName = "idcables_details"
        Me.IdcablesdetailsDataGridViewTextBoxColumn1.HeaderText = "idcables_details"
        Me.IdcablesdetailsDataGridViewTextBoxColumn1.Name = "IdcablesdetailsDataGridViewTextBoxColumn1"
        Me.IdcablesdetailsDataGridViewTextBoxColumn1.Visible = false
        '
        'FilsDataGridViewTextBoxColumn1
        '
        Me.FilsDataGridViewTextBoxColumn1.DataPropertyName = "fils"
        Me.FilsDataGridViewTextBoxColumn1.HeaderText = "fils"
        Me.FilsDataGridViewTextBoxColumn1.Name = "FilsDataGridViewTextBoxColumn1"
        '
        'LongueurDataGridViewTextBoxColumn1
        '
        Me.LongueurDataGridViewTextBoxColumn1.DataPropertyName = "longueur"
        Me.LongueurDataGridViewTextBoxColumn1.HeaderText = "longueur"
        Me.LongueurDataGridViewTextBoxColumn1.Name = "LongueurDataGridViewTextBoxColumn1"
        '
        'SectionDataGridViewTextBoxColumn1
        '
        Me.SectionDataGridViewTextBoxColumn1.DataPropertyName = "section"
        Me.SectionDataGridViewTextBoxColumn1.HeaderText = "section"
        Me.SectionDataGridViewTextBoxColumn1.Name = "SectionDataGridViewTextBoxColumn1"
        '
        'TypesDataGridViewTextBoxColumn1
        '
        Me.TypesDataGridViewTextBoxColumn1.DataPropertyName = "types"
        Me.TypesDataGridViewTextBoxColumn1.HeaderText = "types"
        Me.TypesDataGridViewTextBoxColumn1.Name = "TypesDataGridViewTextBoxColumn1"
        '
        'SegregationDataGridViewTextBoxColumn1
        '
        Me.SegregationDataGridViewTextBoxColumn1.DataPropertyName = "segregation"
        Me.SegregationDataGridViewTextBoxColumn1.HeaderText = "segregation"
        Me.SegregationDataGridViewTextBoxColumn1.Name = "SegregationDataGridViewTextBoxColumn1"
        '
        'RepereEquipement1DataGridViewTextBoxColumn1
        '
        Me.RepereEquipement1DataGridViewTextBoxColumn1.DataPropertyName = "repere equipement1"
        Me.RepereEquipement1DataGridViewTextBoxColumn1.HeaderText = "repere equipement1"
        Me.RepereEquipement1DataGridViewTextBoxColumn1.Name = "RepereEquipement1DataGridViewTextBoxColumn1"
        '
        'RepereSalle1DataGridViewTextBoxColumn1
        '
        Me.RepereSalle1DataGridViewTextBoxColumn1.DataPropertyName = "repere salle1"
        Me.RepereSalle1DataGridViewTextBoxColumn1.HeaderText = "repere salle1"
        Me.RepereSalle1DataGridViewTextBoxColumn1.Name = "RepereSalle1DataGridViewTextBoxColumn1"
        '
        'ReferenceBornierDataGridViewTextBoxColumn1
        '
        Me.ReferenceBornierDataGridViewTextBoxColumn1.DataPropertyName = "reference bornier"
        Me.ReferenceBornierDataGridViewTextBoxColumn1.HeaderText = "reference bornier"
        Me.ReferenceBornierDataGridViewTextBoxColumn1.Name = "ReferenceBornierDataGridViewTextBoxColumn1"
        '
        'CategorieDataGridViewTextBoxColumn1
        '
        Me.CategorieDataGridViewTextBoxColumn1.DataPropertyName = "categorie"
        Me.CategorieDataGridViewTextBoxColumn1.HeaderText = "categorie"
        Me.CategorieDataGridViewTextBoxColumn1.Name = "CategorieDataGridViewTextBoxColumn1"
        '
        'LotcableDataGridViewTextBoxColumn1
        '
        Me.LotcableDataGridViewTextBoxColumn1.DataPropertyName = "lot_cable"
        Me.LotcableDataGridViewTextBoxColumn1.HeaderText = "lot_cable"
        Me.LotcableDataGridViewTextBoxColumn1.Name = "LotcableDataGridViewTextBoxColumn1"
        '
        'ParcourDataGridViewTextBoxColumn1
        '
        Me.ParcourDataGridViewTextBoxColumn1.DataPropertyName = "parcour"
        Me.ParcourDataGridViewTextBoxColumn1.HeaderText = "parcour"
        Me.ParcourDataGridViewTextBoxColumn1.Name = "ParcourDataGridViewTextBoxColumn1"
        '
        'WarningDataGridViewTextBoxColumn1
        '
        Me.WarningDataGridViewTextBoxColumn1.DataPropertyName = "warning"
        Me.WarningDataGridViewTextBoxColumn1.HeaderText = "warning"
        Me.WarningDataGridViewTextBoxColumn1.Name = "WarningDataGridViewTextBoxColumn1"
        '
        'ContrainteDataGridViewCheckBoxColumn1
        '
        Me.ContrainteDataGridViewCheckBoxColumn1.DataPropertyName = "Contrainte"
        Me.ContrainteDataGridViewCheckBoxColumn1.HeaderText = "Contrainte"
        Me.ContrainteDataGridViewCheckBoxColumn1.Name = "ContrainteDataGridViewCheckBoxColumn1"
        '
        'LotteneantDataGridViewTextBoxColumn1
        '
        Me.LotteneantDataGridViewTextBoxColumn1.DataPropertyName = "lot_teneant"
        Me.LotteneantDataGridViewTextBoxColumn1.HeaderText = "lot_teneant"
        Me.LotteneantDataGridViewTextBoxColumn1.Name = "LotteneantDataGridViewTextBoxColumn1"
        '
        'LotaboutissantDataGridViewTextBoxColumn1
        '
        Me.LotaboutissantDataGridViewTextBoxColumn1.DataPropertyName = "lot_aboutissant"
        Me.LotaboutissantDataGridViewTextBoxColumn1.HeaderText = "lot_aboutissant"
        Me.LotaboutissantDataGridViewTextBoxColumn1.Name = "LotaboutissantDataGridViewTextBoxColumn1"
        '
        'DateDataGridViewTextBoxColumn1
        '
        Me.DateDataGridViewTextBoxColumn1.DataPropertyName = "date"
        Me.DateDataGridViewTextBoxColumn1.HeaderText = "date"
        Me.DateDataGridViewTextBoxColumn1.Name = "DateDataGridViewTextBoxColumn1"
        '
        'Idcable1DataGridViewTextBoxColumn1
        '
        Me.Idcable1DataGridViewTextBoxColumn1.DataPropertyName = "idcable1"
        Me.Idcable1DataGridViewTextBoxColumn1.HeaderText = "idcable1"
        Me.Idcable1DataGridViewTextBoxColumn1.Name = "Idcable1DataGridViewTextBoxColumn1"
        Me.Idcable1DataGridViewTextBoxColumn1.Visible = false
        '
        'TouretdefDataGridViewTextBoxColumn1
        '
        Me.TouretdefDataGridViewTextBoxColumn1.DataPropertyName = "Touret_def"
        Me.TouretdefDataGridViewTextBoxColumn1.HeaderText = "Touret_def"
        Me.TouretdefDataGridViewTextBoxColumn1.Name = "TouretdefDataGridViewTextBoxColumn1"
        '
        'TouretreelDataGridViewTextBoxColumn1
        '
        Me.TouretreelDataGridViewTextBoxColumn1.DataPropertyName = "Touret_reel"
        Me.TouretreelDataGridViewTextBoxColumn1.HeaderText = "Touret_reel"
        Me.TouretreelDataGridViewTextBoxColumn1.Name = "TouretreelDataGridViewTextBoxColumn1"
        '
        'CaseModedeposeWhenTrueThenMonoCoucheElseMultiCouchesEndDataGridViewTextBoxColumn1
        '
        Me.CaseModedeposeWhenTrueThenMonoCoucheElseMultiCouchesEndDataGridViewTextBoxColumn1.DataPropertyName = "case mode_de_pose"&Global.Microsoft.VisualBasic.ChrW(10)&"        when true then 'MonoCouche'"&Global.Microsoft.VisualBasic.ChrW(10)&"        else 'MultiCouches'"& _ 
    ""&Global.Microsoft.VisualBasic.ChrW(10)&"    end"
        Me.CaseModedeposeWhenTrueThenMonoCoucheElseMultiCouchesEndDataGridViewTextBoxColumn1.HeaderText = "case mode_de_pose"&Global.Microsoft.VisualBasic.ChrW(10)&"        when true then 'MonoCouche'"&Global.Microsoft.VisualBasic.ChrW(10)&"        else 'MultiCouches'"& _ 
    ""&Global.Microsoft.VisualBasic.ChrW(10)&"    end"
        Me.CaseModedeposeWhenTrueThenMonoCoucheElseMultiCouchesEndDataGridViewTextBoxColumn1.Name = "CaseModedeposeWhenTrueThenMonoCoucheElseMultiCouchesEndDataGridViewTextBoxColumn1"& _ 
    ""
        '
        'Mise_en_touret
        '
        Me.Mise_en_touret.DataMember = "lst_cable_mise_touret"
        Me.Mise_en_touret.DataSource = Me.MydbDataSet
        '
        'SuperTabItem3
        '
        Me.SuperTabItem3.AttachedControl = Me.SuperTabControlPanel3
        Me.SuperTabItem3.GlobalItem = false
        Me.SuperTabItem3.Name = "SuperTabItem3"
        Me.SuperTabItem3.Text = "Câbles associés"
        '
        'SuperTabControlPanel4
        '
        Me.SuperTabControlPanel4.AutoScroll = true
        Me.SuperTabControlPanel4.Controls.Add(Me.Lst_cable_touret_poseDataGridViewX)
        Me.SuperTabControlPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel4.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel4.Name = "SuperTabControlPanel4"
        Me.SuperTabControlPanel4.Size = New System.Drawing.Size(1450, 372)
        Me.SuperTabControlPanel4.TabIndex = 4
        Me.SuperTabControlPanel4.TabItem = Me.SuperTabItem4
        '
        'Lst_cable_touret_poseDataGridViewX
        '
        Me.Lst_cable_touret_poseDataGridViewX.AutoGenerateColumns = false
        Me.Lst_cable_touret_poseDataGridViewX.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Lst_cable_touret_poseDataGridViewX.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn26, Me.DataGridViewTextBoxColumn27, Me.DataGridViewTextBoxColumn28, Me.DataGridViewTextBoxColumn29, Me.DataGridViewTextBoxColumn30, Me.DataGridViewTextBoxColumn31, Me.DataGridViewTextBoxColumn32, Me.DataGridViewTextBoxColumn33, Me.DataGridViewTextBoxColumn34, Me.DataGridViewTextBoxColumn35, Me.DataGridViewTextBoxColumn36, Me.DataGridViewTextBoxColumn37, Me.DataGridViewTextBoxColumn38, Me.DataGridViewTextBoxColumn40, Me.DataGridViewTextBoxColumn41, Me.DataGridViewTextBoxColumn44, Me.DataGridViewTextBoxColumn45, Me.DataGridViewTextBoxColumn46, Me.DataGridViewCheckBoxColumn5, Me.DataGridViewTextBoxColumn47, Me.DataGridViewTextBoxColumn48, Me.DataGridViewTextBoxColumn49, Me.DataGridViewTextBoxColumn50, Me.DataGridViewTextBoxColumn51, Me.DataGridViewTextBoxColumn52, Me.DataGridViewTextBoxColumn53})
        Me.Lst_cable_touret_poseDataGridViewX.DataSource = Me.Lst_cable_touret_poseBindingSource
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Lst_cable_touret_poseDataGridViewX.DefaultCellStyle = DataGridViewCellStyle5
        Me.Lst_cable_touret_poseDataGridViewX.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lst_cable_touret_poseDataGridViewX.GridColor = System.Drawing.Color.FromArgb(CType(CType(170,Byte),Integer), CType(CType(170,Byte),Integer), CType(CType(170,Byte),Integer))
        Me.Lst_cable_touret_poseDataGridViewX.Location = New System.Drawing.Point(0, 0)
        Me.Lst_cable_touret_poseDataGridViewX.Name = "Lst_cable_touret_poseDataGridViewX"
        Me.Lst_cable_touret_poseDataGridViewX.Size = New System.Drawing.Size(1450, 372)
        Me.Lst_cable_touret_poseDataGridViewX.TabIndex = 0
        '
        'DataGridViewTextBoxColumn26
        '
        Me.DataGridViewTextBoxColumn26.DataPropertyName = "idcable"
        Me.DataGridViewTextBoxColumn26.HeaderText = "idcable"
        Me.DataGridViewTextBoxColumn26.Name = "DataGridViewTextBoxColumn26"
        Me.DataGridViewTextBoxColumn26.Visible = false
        '
        'DataGridViewTextBoxColumn27
        '
        Me.DataGridViewTextBoxColumn27.DataPropertyName = "repere equipement"
        Me.DataGridViewTextBoxColumn27.HeaderText = "repere equipement"
        Me.DataGridViewTextBoxColumn27.Name = "DataGridViewTextBoxColumn27"
        '
        'DataGridViewTextBoxColumn28
        '
        Me.DataGridViewTextBoxColumn28.DataPropertyName = "repere salle"
        Me.DataGridViewTextBoxColumn28.HeaderText = "repere salle"
        Me.DataGridViewTextBoxColumn28.Name = "DataGridViewTextBoxColumn28"
        '
        'DataGridViewTextBoxColumn29
        '
        Me.DataGridViewTextBoxColumn29.DataPropertyName = "reference depart"
        Me.DataGridViewTextBoxColumn29.HeaderText = "reference depart"
        Me.DataGridViewTextBoxColumn29.Name = "DataGridViewTextBoxColumn29"
        '
        'DataGridViewTextBoxColumn30
        '
        Me.DataGridViewTextBoxColumn30.DataPropertyName = "repere cable"
        Me.DataGridViewTextBoxColumn30.HeaderText = "repere cable"
        Me.DataGridViewTextBoxColumn30.Name = "DataGridViewTextBoxColumn30"
        '
        'DataGridViewTextBoxColumn31
        '
        Me.DataGridViewTextBoxColumn31.DataPropertyName = "idcables_details"
        Me.DataGridViewTextBoxColumn31.HeaderText = "idcables_details"
        Me.DataGridViewTextBoxColumn31.Name = "DataGridViewTextBoxColumn31"
        Me.DataGridViewTextBoxColumn31.Visible = false
        '
        'DataGridViewTextBoxColumn32
        '
        Me.DataGridViewTextBoxColumn32.DataPropertyName = "fils"
        Me.DataGridViewTextBoxColumn32.HeaderText = "fils"
        Me.DataGridViewTextBoxColumn32.Name = "DataGridViewTextBoxColumn32"
        '
        'DataGridViewTextBoxColumn33
        '
        Me.DataGridViewTextBoxColumn33.DataPropertyName = "longueur"
        Me.DataGridViewTextBoxColumn33.HeaderText = "longueur"
        Me.DataGridViewTextBoxColumn33.Name = "DataGridViewTextBoxColumn33"
        '
        'DataGridViewTextBoxColumn34
        '
        Me.DataGridViewTextBoxColumn34.DataPropertyName = "section"
        Me.DataGridViewTextBoxColumn34.HeaderText = "section"
        Me.DataGridViewTextBoxColumn34.Name = "DataGridViewTextBoxColumn34"
        '
        'DataGridViewTextBoxColumn35
        '
        Me.DataGridViewTextBoxColumn35.DataPropertyName = "types"
        Me.DataGridViewTextBoxColumn35.HeaderText = "types"
        Me.DataGridViewTextBoxColumn35.Name = "DataGridViewTextBoxColumn35"
        '
        'DataGridViewTextBoxColumn36
        '
        Me.DataGridViewTextBoxColumn36.DataPropertyName = "segregation"
        Me.DataGridViewTextBoxColumn36.HeaderText = "segregation"
        Me.DataGridViewTextBoxColumn36.Name = "DataGridViewTextBoxColumn36"
        '
        'DataGridViewTextBoxColumn37
        '
        Me.DataGridViewTextBoxColumn37.DataPropertyName = "repere equipement1"
        Me.DataGridViewTextBoxColumn37.HeaderText = "repere equipement1"
        Me.DataGridViewTextBoxColumn37.Name = "DataGridViewTextBoxColumn37"
        '
        'DataGridViewTextBoxColumn38
        '
        Me.DataGridViewTextBoxColumn38.DataPropertyName = "repere salle1"
        Me.DataGridViewTextBoxColumn38.HeaderText = "repere salle1"
        Me.DataGridViewTextBoxColumn38.Name = "DataGridViewTextBoxColumn38"
        '
        'DataGridViewTextBoxColumn40
        '
        Me.DataGridViewTextBoxColumn40.DataPropertyName = "reference bornier"
        Me.DataGridViewTextBoxColumn40.HeaderText = "reference bornier"
        Me.DataGridViewTextBoxColumn40.Name = "DataGridViewTextBoxColumn40"
        '
        'DataGridViewTextBoxColumn41
        '
        Me.DataGridViewTextBoxColumn41.DataPropertyName = "categorie"
        Me.DataGridViewTextBoxColumn41.HeaderText = "categorie"
        Me.DataGridViewTextBoxColumn41.Name = "DataGridViewTextBoxColumn41"
        '
        'DataGridViewTextBoxColumn44
        '
        Me.DataGridViewTextBoxColumn44.DataPropertyName = "lot_cable"
        Me.DataGridViewTextBoxColumn44.HeaderText = "lot_cable"
        Me.DataGridViewTextBoxColumn44.Name = "DataGridViewTextBoxColumn44"
        '
        'DataGridViewTextBoxColumn45
        '
        Me.DataGridViewTextBoxColumn45.DataPropertyName = "parcour"
        Me.DataGridViewTextBoxColumn45.HeaderText = "parcour"
        Me.DataGridViewTextBoxColumn45.Name = "DataGridViewTextBoxColumn45"
        '
        'DataGridViewTextBoxColumn46
        '
        Me.DataGridViewTextBoxColumn46.DataPropertyName = "warning"
        Me.DataGridViewTextBoxColumn46.HeaderText = "warning"
        Me.DataGridViewTextBoxColumn46.Name = "DataGridViewTextBoxColumn46"
        '
        'DataGridViewCheckBoxColumn5
        '
        Me.DataGridViewCheckBoxColumn5.DataPropertyName = "Contrainte"
        Me.DataGridViewCheckBoxColumn5.HeaderText = "Contrainte"
        Me.DataGridViewCheckBoxColumn5.Name = "DataGridViewCheckBoxColumn5"
        '
        'DataGridViewTextBoxColumn47
        '
        Me.DataGridViewTextBoxColumn47.DataPropertyName = "lot_teneant"
        Me.DataGridViewTextBoxColumn47.HeaderText = "lot_teneant"
        Me.DataGridViewTextBoxColumn47.Name = "DataGridViewTextBoxColumn47"
        '
        'DataGridViewTextBoxColumn48
        '
        Me.DataGridViewTextBoxColumn48.DataPropertyName = "lot_aboutissant"
        Me.DataGridViewTextBoxColumn48.HeaderText = "lot_aboutissant"
        Me.DataGridViewTextBoxColumn48.Name = "DataGridViewTextBoxColumn48"
        '
        'DataGridViewTextBoxColumn49
        '
        Me.DataGridViewTextBoxColumn49.DataPropertyName = "date"
        Me.DataGridViewTextBoxColumn49.HeaderText = "date"
        Me.DataGridViewTextBoxColumn49.Name = "DataGridViewTextBoxColumn49"
        '
        'DataGridViewTextBoxColumn50
        '
        Me.DataGridViewTextBoxColumn50.DataPropertyName = "idcable1"
        Me.DataGridViewTextBoxColumn50.HeaderText = "idcable1"
        Me.DataGridViewTextBoxColumn50.Name = "DataGridViewTextBoxColumn50"
        Me.DataGridViewTextBoxColumn50.Visible = false
        '
        'DataGridViewTextBoxColumn51
        '
        Me.DataGridViewTextBoxColumn51.DataPropertyName = "Touret_def"
        Me.DataGridViewTextBoxColumn51.HeaderText = "Touret_def"
        Me.DataGridViewTextBoxColumn51.Name = "DataGridViewTextBoxColumn51"
        '
        'DataGridViewTextBoxColumn52
        '
        Me.DataGridViewTextBoxColumn52.DataPropertyName = "Touret_reel"
        Me.DataGridViewTextBoxColumn52.HeaderText = "Touret_reel"
        Me.DataGridViewTextBoxColumn52.Name = "DataGridViewTextBoxColumn52"
        '
        'DataGridViewTextBoxColumn53
        '
        Me.DataGridViewTextBoxColumn53.DataPropertyName = "case mode_de_pose"&Global.Microsoft.VisualBasic.ChrW(10)&"        when true then 'MonoCouche'"&Global.Microsoft.VisualBasic.ChrW(10)&"        else 'MultiCouches'"& _ 
    ""&Global.Microsoft.VisualBasic.ChrW(10)&"    end"
        Me.DataGridViewTextBoxColumn53.HeaderText = "case mode_de_pose"&Global.Microsoft.VisualBasic.ChrW(10)&"        when true then 'MonoCouche'"&Global.Microsoft.VisualBasic.ChrW(10)&"        else 'MultiCouches'"& _ 
    ""&Global.Microsoft.VisualBasic.ChrW(10)&"    end"
        Me.DataGridViewTextBoxColumn53.Name = "DataGridViewTextBoxColumn53"
        '
        'Lst_cable_touret_poseBindingSource
        '
        Me.Lst_cable_touret_poseBindingSource.DataMember = "lst_cable_touret_pose"
        Me.Lst_cable_touret_poseBindingSource.DataSource = Me.MydbDataSet
        '
        'SuperTabItem4
        '
        Me.SuperTabItem4.AttachedControl = Me.SuperTabControlPanel4
        Me.SuperTabItem4.GlobalItem = false
        Me.SuperTabItem4.Name = "SuperTabItem4"
        Me.SuperTabItem4.Text = "Câbles tirés"
        '
        'SuperTabControlPanel1
        '
        Me.SuperTabControlPanel1.AutoScroll = true
        Me.SuperTabControlPanel1.Controls.Add(Me.Lst_fourniture_touretDataGridViewX)
        Me.SuperTabControlPanel1.Controls.Add(Me.ButtonX1)
        Me.SuperTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel1.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel1.Name = "SuperTabControlPanel1"
        Me.SuperTabControlPanel1.Size = New System.Drawing.Size(1447, 372)
        Me.SuperTabControlPanel1.TabIndex = 1
        Me.SuperTabControlPanel1.TabItem = Me.SuperTabItem1
        '
        'Lst_fourniture_touretDataGridViewX
        '
        Me.Lst_fourniture_touretDataGridViewX.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.Lst_fourniture_touretDataGridViewX.AutoGenerateColumns = false
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Lst_fourniture_touretDataGridViewX.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.Lst_fourniture_touretDataGridViewX.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Lst_fourniture_touretDataGridViewX.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn10, Me.DataGridViewTextBoxColumn11, Me.DataGridViewTextBoxColumn12, Me.DataGridViewTextBoxColumn13, Me.DataGridViewTextBoxColumn14, Me.DataGridViewCheckBoxColumn1, Me.DataGridViewCheckBoxColumn2, Me.DataGridViewCheckBoxColumn3, Me.DataGridViewTextBoxColumn15, Me.DataGridViewTextBoxColumn16, Me.DataGridViewTextBoxColumn17, Me.DataGridViewTextBoxColumn18, Me.DataGridViewTextBoxColumn19, Me.DataGridViewCheckBoxColumn4})
        Me.Lst_fourniture_touretDataGridViewX.DataSource = Me.Lst_fourniture_touretBindingSource
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Lst_fourniture_touretDataGridViewX.DefaultCellStyle = DataGridViewCellStyle7
        Me.Lst_fourniture_touretDataGridViewX.EnableHeadersVisualStyles = false
        Me.Lst_fourniture_touretDataGridViewX.GridColor = System.Drawing.Color.FromArgb(CType(CType(170,Byte),Integer), CType(CType(170,Byte),Integer), CType(CType(170,Byte),Integer))
        Me.Lst_fourniture_touretDataGridViewX.Location = New System.Drawing.Point(3, 40)
        Me.Lst_fourniture_touretDataGridViewX.Name = "Lst_fourniture_touretDataGridViewX"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Lst_fourniture_touretDataGridViewX.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.Lst_fourniture_touretDataGridViewX.Size = New System.Drawing.Size(1444, 332)
        Me.Lst_fourniture_touretDataGridViewX.TabIndex = 10
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "id_tourets_has_fourniturescol"
        Me.DataGridViewTextBoxColumn1.HeaderText = "id_tourets_has_fourniturescol"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Visible = false
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "tourets_idtouret"
        Me.DataGridViewTextBoxColumn2.HeaderText = "tourets_idtouret"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Visible = false
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "fournitures_idfourniture"
        Me.DataGridViewTextBoxColumn3.HeaderText = "fournitures_idfourniture"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Visible = false
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "idfourniture"
        Me.DataGridViewTextBoxColumn4.HeaderText = "idfourniture"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Visible = false
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "designation"
        Me.DataGridViewTextBoxColumn5.HeaderText = "designation"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "Categorie"
        Me.DataGridViewTextBoxColumn6.HeaderText = "Categorie"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "quant_min"
        Me.DataGridViewTextBoxColumn7.HeaderText = "quant_min"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.Visible = false
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "fournisseur"
        Me.DataGridViewTextBoxColumn8.HeaderText = "fournisseur"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "unitee"
        Me.DataGridViewTextBoxColumn9.HeaderText = "unitee"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "Longueur"
        Me.DataGridViewTextBoxColumn10.HeaderText = "Longueur"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "largeur"
        Me.DataGridViewTextBoxColumn11.HeaderText = "largeur"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.Visible = false
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "Hauteur"
        Me.DataGridViewTextBoxColumn12.HeaderText = "Hauteur"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.Visible = false
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.DataPropertyName = "profondeur"
        Me.DataGridViewTextBoxColumn13.HeaderText = "profondeur"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.Visible = false
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.DataPropertyName = "masse"
        Me.DataGridViewTextBoxColumn14.HeaderText = "masse"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.Visible = false
        '
        'DataGridViewCheckBoxColumn1
        '
        Me.DataGridViewCheckBoxColumn1.DataPropertyName = "liste_Troncon"
        Me.DataGridViewCheckBoxColumn1.HeaderText = "liste_Troncon"
        Me.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1"
        Me.DataGridViewCheckBoxColumn1.Visible = false
        '
        'DataGridViewCheckBoxColumn2
        '
        Me.DataGridViewCheckBoxColumn2.DataPropertyName = "liste_cable"
        Me.DataGridViewCheckBoxColumn2.HeaderText = "liste_cable"
        Me.DataGridViewCheckBoxColumn2.Name = "DataGridViewCheckBoxColumn2"
        Me.DataGridViewCheckBoxColumn2.Visible = false
        '
        'DataGridViewCheckBoxColumn3
        '
        Me.DataGridViewCheckBoxColumn3.DataPropertyName = "liste_equipement"
        Me.DataGridViewCheckBoxColumn3.HeaderText = "liste_equipement"
        Me.DataGridViewCheckBoxColumn3.Name = "DataGridViewCheckBoxColumn3"
        Me.DataGridViewCheckBoxColumn3.Visible = false
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.DataPropertyName = "diametre"
        Me.DataGridViewTextBoxColumn15.HeaderText = "diametre"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.Visible = false
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.DataPropertyName = "Matiere"
        Me.DataGridViewTextBoxColumn16.HeaderText = "Matiere"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        '
        'DataGridViewTextBoxColumn17
        '
        Me.DataGridViewTextBoxColumn17.DataPropertyName = "TempPoseMetre"
        Me.DataGridViewTextBoxColumn17.HeaderText = "TempPoseMetre"
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        Me.DataGridViewTextBoxColumn17.Visible = false
        '
        'DataGridViewTextBoxColumn18
        '
        Me.DataGridViewTextBoxColumn18.DataPropertyName = "TempPoseUnitaire"
        Me.DataGridViewTextBoxColumn18.HeaderText = "TempPoseUnitaire"
        Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
        Me.DataGridViewTextBoxColumn18.Visible = false
        '
        'DataGridViewTextBoxColumn19
        '
        Me.DataGridViewTextBoxColumn19.DataPropertyName = "Num_serie"
        Me.DataGridViewTextBoxColumn19.HeaderText = "Num_serie"
        Me.DataGridViewTextBoxColumn19.Name = "DataGridViewTextBoxColumn19"
        '
        'DataGridViewCheckBoxColumn4
        '
        Me.DataGridViewCheckBoxColumn4.DataPropertyName = "liste_tourets"
        Me.DataGridViewCheckBoxColumn4.HeaderText = "liste_tourets"
        Me.DataGridViewCheckBoxColumn4.Name = "DataGridViewCheckBoxColumn4"
        Me.DataGridViewCheckBoxColumn4.Visible = false
        '
        'Lst_fourniture_touretBindingSource
        '
        Me.Lst_fourniture_touretBindingSource.DataMember = "lst_fourniture_touret"
        Me.Lst_fourniture_touretBindingSource.DataSource = Me.MydbDataSet
        '
        'SuperTabItem1
        '
        Me.SuperTabItem1.AttachedControl = Me.SuperTabControlPanel1
        Me.SuperTabItem1.GlobalItem = false
        Me.SuperTabItem1.Name = "SuperTabItem1"
        Me.SuperTabItem1.Text = "Fournitures"
        '
        'SuperTabControlPanel2
        '
        Me.SuperTabControlPanel2.AutoScroll = true
        Me.SuperTabControlPanel2.Controls.Add(DescriptionLabel)
        Me.SuperTabControlPanel2.Controls.Add(Me.DescriptionTextBox)
        Me.SuperTabControlPanel2.Controls.Add(Me.Lst_doc_touretDataGridViewX)
        Me.SuperTabControlPanel2.Controls.Add(Me.LabelXselect)
        Me.SuperTabControlPanel2.Controls.Add(Me.SwitchButtonDocSelect)
        Me.SuperTabControlPanel2.Controls.Add(Me.ButtonX4)
        Me.SuperTabControlPanel2.Controls.Add(Me.ButtonX6)
        Me.SuperTabControlPanel2.Controls.Add(Me.ButtonX2)
        Me.SuperTabControlPanel2.Controls.Add(Me.ButtonX3)
        Me.SuperTabControlPanel2.Controls.Add(Me.TextBox1)
        Me.SuperTabControlPanel2.Controls.Add(Me.TextBox2)
        Me.SuperTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel2.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel2.Name = "SuperTabControlPanel2"
        Me.SuperTabControlPanel2.Size = New System.Drawing.Size(1447, 372)
        Me.SuperTabControlPanel2.TabIndex = 2
        Me.SuperTabControlPanel2.TabItem = Me.SuperTabItem2
        '
        'DescriptionTextBox
        '
        Me.DescriptionTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.DocumentsBindingSource, "description", true))
        Me.DescriptionTextBox.Location = New System.Drawing.Point(1062, 164)
        Me.DescriptionTextBox.Multiline = true
        Me.DescriptionTextBox.Name = "DescriptionTextBox"
        Me.DescriptionTextBox.Size = New System.Drawing.Size(285, 103)
        Me.DescriptionTextBox.TabIndex = 14
        '
        'DocumentsBindingSource
        '
        Me.DocumentsBindingSource.DataMember = "documents"
        Me.DocumentsBindingSource.DataSource = Me.MydbDataSet
        '
        'Lst_doc_touretDataGridViewX
        '
        Me.Lst_doc_touretDataGridViewX.AutoGenerateColumns = false
        Me.Lst_doc_touretDataGridViewX.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Lst_doc_touretDataGridViewX.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn20, Me.DataGridViewTextBoxColumn21, Me.DataGridViewTextBoxColumn22, Me.DataGridViewTextBoxColumn23, Me.DataGridViewTextBoxColumn24, Me.DataGridViewTextBoxColumn25})
        Me.Lst_doc_touretDataGridViewX.DataSource = Me.Lst_doc_touretBindingSource1
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Lst_doc_touretDataGridViewX.DefaultCellStyle = DataGridViewCellStyle9
        Me.Lst_doc_touretDataGridViewX.GridColor = System.Drawing.Color.FromArgb(CType(CType(170,Byte),Integer), CType(CType(170,Byte),Integer), CType(CType(170,Byte),Integer))
        Me.Lst_doc_touretDataGridViewX.Location = New System.Drawing.Point(68, 164)
        Me.Lst_doc_touretDataGridViewX.Name = "Lst_doc_touretDataGridViewX"
        Me.Lst_doc_touretDataGridViewX.Size = New System.Drawing.Size(891, 220)
        Me.Lst_doc_touretDataGridViewX.TabIndex = 13
        '
        'DataGridViewTextBoxColumn20
        '
        Me.DataGridViewTextBoxColumn20.DataPropertyName = "iddocuments"
        Me.DataGridViewTextBoxColumn20.HeaderText = "iddocuments"
        Me.DataGridViewTextBoxColumn20.Name = "DataGridViewTextBoxColumn20"
        Me.DataGridViewTextBoxColumn20.Visible = false
        '
        'DataGridViewTextBoxColumn21
        '
        Me.DataGridViewTextBoxColumn21.DataPropertyName = "Nom_doc"
        Me.DataGridViewTextBoxColumn21.HeaderText = "Nom_doc"
        Me.DataGridViewTextBoxColumn21.Name = "DataGridViewTextBoxColumn21"
        '
        'DataGridViewTextBoxColumn22
        '
        Me.DataGridViewTextBoxColumn22.DataPropertyName = "emplacement"
        Me.DataGridViewTextBoxColumn22.HeaderText = "emplacement"
        Me.DataGridViewTextBoxColumn22.Name = "DataGridViewTextBoxColumn22"
        '
        'DataGridViewTextBoxColumn23
        '
        Me.DataGridViewTextBoxColumn23.DataPropertyName = "qui"
        Me.DataGridViewTextBoxColumn23.HeaderText = "qui"
        Me.DataGridViewTextBoxColumn23.Name = "DataGridViewTextBoxColumn23"
        '
        'DataGridViewTextBoxColumn24
        '
        Me.DataGridViewTextBoxColumn24.DataPropertyName = "date"
        Me.DataGridViewTextBoxColumn24.HeaderText = "date"
        Me.DataGridViewTextBoxColumn24.Name = "DataGridViewTextBoxColumn24"
        '
        'DataGridViewTextBoxColumn25
        '
        Me.DataGridViewTextBoxColumn25.DataPropertyName = "description"
        Me.DataGridViewTextBoxColumn25.HeaderText = "description"
        Me.DataGridViewTextBoxColumn25.Name = "DataGridViewTextBoxColumn25"
        '
        'Lst_doc_touretBindingSource1
        '
        Me.Lst_doc_touretBindingSource1.DataMember = "lst_doc_touret"
        Me.Lst_doc_touretBindingSource1.DataSource = Me.MydbDataSet
        '
        'LabelXselect
        '
        '
        '
        '
        Me.LabelXselect.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelXselect.Location = New System.Drawing.Point(611, 93)
        Me.LabelXselect.Name = "LabelXselect"
        Me.LabelXselect.Size = New System.Drawing.Size(149, 23)
        Me.LabelXselect.TabIndex = 13
        Me.LabelXselect.Text = "Associé le document avec :"
        '
        'SwitchButtonDocSelect
        '
        '
        '
        '
        Me.SwitchButtonDocSelect.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.SwitchButtonDocSelect.Location = New System.Drawing.Point(636, 121)
        Me.SwitchButtonDocSelect.Name = "SwitchButtonDocSelect"
        Me.SwitchButtonDocSelect.OffText = "Touret"
        Me.SwitchButtonDocSelect.OnText = "Fourniture"
        Me.SwitchButtonDocSelect.Size = New System.Drawing.Size(101, 22)
        Me.SwitchButtonDocSelect.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.SwitchButtonDocSelect.TabIndex = 12
        '
        'ButtonX6
        '
        Me.ButtonX6.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX6.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX6.Location = New System.Drawing.Point(817, 121)
        Me.ButtonX6.Name = "ButtonX6"
        Me.ButtonX6.Size = New System.Drawing.Size(133, 23)
        Me.ButtonX6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX6.TabIndex = 11
        Me.ButtonX6.Text = "Suppression"
        '
        'SuperTabItem2
        '
        Me.SuperTabItem2.AttachedControl = Me.SuperTabControlPanel2
        Me.SuperTabItem2.GlobalItem = false
        Me.SuperTabItem2.Name = "SuperTabItem2"
        Me.SuperTabItem2.Text = "Documents"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(299, 151)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(100, 20)
        Me.TextBox3.TabIndex = 4
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(500, 151)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(100, 20)
        Me.TextBox4.TabIndex = 4
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(299, 177)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(100, 20)
        Me.TextBox5.TabIndex = 4
        '
        'ButtonX5
        '
        Me.ButtonX5.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX5.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX5.Image = CType(resources.GetObject("ButtonX5.Image"),System.Drawing.Image)
        Me.ButtonX5.Location = New System.Drawing.Point(1122, 154)
        Me.ButtonX5.Name = "ButtonX5"
        Me.ButtonX5.Size = New System.Drawing.Size(96, 38)
        Me.ButtonX5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX5.TabIndex = 10
        Me.ButtonX5.Text = "[Modifier & enregistrer]"
        '
        'ComboBoxEx1
        '
        Me.ComboBoxEx1.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.TouretsBindingSource, "donnees_cables_iddonnee", true))
        Me.ComboBoxEx1.DataSource = Me.Donnee_phyBindingSource
        Me.ComboBoxEx1.DisplayMember = "types"
        Me.ComboBoxEx1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBoxEx1.DropDownColumns = "types,section"
        Me.ComboBoxEx1.FormattingEnabled = true
        Me.ComboBoxEx1.ItemHeight = 14
        Me.ComboBoxEx1.Location = New System.Drawing.Point(476, 79)
        Me.ComboBoxEx1.Name = "ComboBoxEx1"
        Me.ComboBoxEx1.Size = New System.Drawing.Size(210, 20)
        Me.ComboBoxEx1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ComboBoxEx1.TabIndex = 13
        Me.ComboBoxEx1.ValueMember = "iddonnee"
        '
        'Donnee_phyBindingSource
        '
        Me.Donnee_phyBindingSource.DataMember = "donnee_phy"
        Me.Donnee_phyBindingSource.DataSource = Me.MydbDataSet
        '
        'label4
        '
        Me.label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 16!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.label4.Location = New System.Drawing.Point(316, 76)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(154, 23)
        Me.label4.TabIndex = 18
        Me.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextBox6
        '
        Me.TextBox6.Location = New System.Drawing.Point(96, 181)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(100, 20)
        Me.TextBox6.TabIndex = 4
        Me.TextBox6.Text = "500"
        '
        'SuperValidator
        '
        Me.SuperValidator.ContainerControl = Me
        Me.SuperValidator.ErrorProvider = Me.ErrorProvider1
        Me.SuperValidator.Highlighter = Me.Highlighter1
        Me.SuperValidator.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        '
        'RequiredFieldValidator1
        '
        Me.RequiredFieldValidator1.ErrorMessage = "Your error message here."
        Me.RequiredFieldValidator1.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        Me.ErrorProvider1.Icon = CType(resources.GetObject("ErrorProvider1.Icon"),System.Drawing.Icon)
        '
        'Highlighter1
        '
        Me.Highlighter1.ContainerControl = Me
        Me.Highlighter1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        '
        'CircularProgress
        '
        '
        '
        '
        Me.CircularProgress.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CircularProgress.Location = New System.Drawing.Point(692, 35)
        Me.CircularProgress.Name = "CircularProgress"
        Me.CircularProgress.Size = New System.Drawing.Size(393, 152)
        Me.CircularProgress.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.CircularProgress.TabIndex = 19
        Me.CircularProgress.Visible = false
        '
        'Lst_cablesBindingSource
        '
        Me.Lst_cablesBindingSource.DataMember = "lst_cables"
        Me.Lst_cablesBindingSource.DataSource = Me.MydbDataSet
        '
        'Tourets_has_fournituresBindingSource
        '
        Me.Tourets_has_fournituresBindingSource.DataMember = "tourets_has_fournitures"
        Me.Tourets_has_fournituresBindingSource.DataSource = Me.MydbDataSet
        '
        'CablesBindingSource
        '
        Me.CablesBindingSource.DataMember = "cables"
        Me.CablesBindingSource.DataSource = Me.MydbDataSet
        '
        'Fournitures_has_documentsBindingSource
        '
        Me.Fournitures_has_documentsBindingSource.DataMember = "fournitures_has_documents"
        Me.Fournitures_has_documentsBindingSource.DataSource = Me.MydbDataSet
        '
        'TouretsTableAdapter
        '
        Me.TouretsTableAdapter.ClearBeforeFill = true
        '
        'Tourets_has_fournituresTableAdapter
        '
        Me.Tourets_has_fournituresTableAdapter.ClearBeforeFill = true
        '
        'Cables_details_has_touretsTableAdapter
        '
        Me.Cables_details_has_touretsTableAdapter.ClearBeforeFill = true
        '
        'Fournitures_has_documentsTableAdapter
        '
        Me.Fournitures_has_documentsTableAdapter.ClearBeforeFill = true
        '
        'DocumentsTableAdapter
        '
        Me.DocumentsTableAdapter.ClearBeforeFill = true
        '
        'Types_cableBindingSource
        '
        Me.Types_cableBindingSource.DataMember = "types_cable"
        Me.Types_cableBindingSource.DataSource = Me.MydbDataSet
        '
        'Types_cableTableAdapter
        '
        Me.Types_cableTableAdapter.ClearBeforeFill = true
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
        Me.TableAdapterManager.cables_details_has_touretsTableAdapter = Me.Cables_details_has_touretsTableAdapter
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
        Me.TableAdapterManager.documentsTableAdapter = Me.DocumentsTableAdapter
        Me.TableAdapterManager.donnees_cablesTableAdapter = Me.Donnees_cablesTableAdapter
        Me.TableAdapterManager.editionsTableAdapter = Nothing
        Me.TableAdapterManager.emplacementTableAdapter = Nothing
        Me.TableAdapterManager.equipements_dispo_histoTableAdapter = Nothing
        Me.TableAdapterManager.equipements_dispoTableAdapter = Nothing
        Me.TableAdapterManager.equipements_has_fournituresTableAdapter = Nothing
        Me.TableAdapterManager.equipements_modifTableAdapter = Nothing
        Me.TableAdapterManager.equipementsTableAdapter = Nothing
        Me.TableAdapterManager.fournisseursTableAdapter = Nothing
        Me.TableAdapterManager.fournitures_has_documentsTableAdapter = Me.Fournitures_has_documentsTableAdapter
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
        Me.TableAdapterManager.sections_cablesTableAdapter = Me.Sections_cablesTableAdapter
        Me.TableAdapterManager.segregationsTableAdapter = Nothing
        Me.TableAdapterManager.stockTableAdapter = Nothing
        Me.TableAdapterManager.tourets_has_fournituresTableAdapter = Me.Tourets_has_fournituresTableAdapter
        Me.TableAdapterManager.touretsTableAdapter = Me.TouretsTableAdapter
        Me.TableAdapterManager.troncons_assocTableAdapter = Nothing
        Me.TableAdapterManager.troncons_fournituresTableAdapter = Nothing
        Me.TableAdapterManager.troncons_modifTableAdapter = Nothing
        Me.TableAdapterManager.tronconsTableAdapter = Nothing
        Me.TableAdapterManager.type_docTableAdapter = Nothing
        Me.TableAdapterManager.types_cableTableAdapter = Me.Types_cableTableAdapter
        Me.TableAdapterManager.types_tronconsTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = progelec.mydbDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'Donnees_cablesTableAdapter
        '
        Me.Donnees_cablesTableAdapter.ClearBeforeFill = true
        '
        'Sections_cablesTableAdapter
        '
        Me.Sections_cablesTableAdapter.ClearBeforeFill = true
        '
        'Sections_cablesBindingSource
        '
        Me.Sections_cablesBindingSource.DataMember = "sections_cables"
        Me.Sections_cablesBindingSource.DataSource = Me.MydbDataSet
        '
        'Donnees_cablesBindingSource
        '
        Me.Donnees_cablesBindingSource.DataMember = "donnees_cables"
        Me.Donnees_cablesBindingSource.DataSource = Me.MydbDataSet
        '
        'Lst_fourniture_touretTableAdapter
        '
        Me.Lst_fourniture_touretTableAdapter.ClearBeforeFill = true
        '
        'Donnee_phyTableAdapter
        '
        Me.Donnee_phyTableAdapter.ClearBeforeFill = true
        '
        'CablesTableAdapter
        '
        Me.CablesTableAdapter.ClearBeforeFill = true
        '
        'Lst_cablesTableAdapter
        '
        Me.Lst_cablesTableAdapter.ClearBeforeFill = true
        '
        'Documents_has_touretsBindingSource
        '
        Me.Documents_has_touretsBindingSource.DataMember = "documents_has_tourets"
        Me.Documents_has_touretsBindingSource.DataSource = Me.MydbDataSet
        '
        'Documents_has_touretsTableAdapter
        '
        Me.Documents_has_touretsTableAdapter.ClearBeforeFill = true
        '
        'Lst_doc_touretTableAdapter
        '
        Me.Lst_doc_touretTableAdapter.ClearBeforeFill = true
        '
        'Lst_cable_mise_touretTableAdapter
        '
        Me.Lst_cable_mise_touretTableAdapter.ClearBeforeFill = true
        '
        'Mise_en_touret_TableAdapter
        '
        Me.Mise_en_touret_TableAdapter.ClearBeforeFill = true
        '
        'Lst_cable_touret_poseTableAdapter
        '
        Me.Lst_cable_touret_poseTableAdapter.ClearBeforeFill = true
        '
        'ButtonX7
        '
        Me.ButtonX7.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX7.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX7.Image = Global.progelec.My.Resources.Resources.back_1_24_24
        Me.ButtonX7.Location = New System.Drawing.Point(85, 35)
        Me.ButtonX7.Name = "ButtonX7"
        Me.ButtonX7.Size = New System.Drawing.Size(100, 30)
        Me.ButtonX7.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX7.TabIndex = 20
        Me.ButtonX7.Text = "Precedant"
        '
        'ButtonX8
        '
        Me.ButtonX8.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX8.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX8.Image = Global.progelec.My.Resources.Resources.next_1_24_24
        Me.ButtonX8.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right
        Me.ButtonX8.Location = New System.Drawing.Point(210, 35)
        Me.ButtonX8.Name = "ButtonX8"
        Me.ButtonX8.Size = New System.Drawing.Size(100, 30)
        Me.ButtonX8.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX8.TabIndex = 20
        Me.ButtonX8.Text = "Suivant"
        '
        'FormTouretsDetail
        '
        Me.AutoScroll = true
        Me.ClientSize = New System.Drawing.Size(1585, 593)
        Me.Controls.Add(Me.ButtonX8)
        Me.Controls.Add(Me.ButtonX7)
        Me.Controls.Add(Me.CircularProgress)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.ComboBoxEx1)
        Me.Controls.Add(Me.SuperTabControl1)
        Me.Controls.Add(Me.ButtonX5)
        Me.Controls.Add(Me.ActifCheckBox)
        Me.Controls.Add(Label3)
        Me.Controls.Add(Label6)
        Me.Controls.Add(Label7)
        Me.Controls.Add(Label5)
        Me.Controls.Add(Label2)
        Me.Controls.Add(Label1)
        Me.Controls.Add(Long_estimeLabel)
        Me.Controls.Add(Me.TextBox6)
        Me.Controls.Add(Me.TextBox5)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.Long_estimeTextBox)
        Me.Controls.Add(RepereLabel)
        Me.Controls.Add(Me.RepereTextBox)
        Me.Name = "FormTouretsDetail"
        Me.Text = "Detail Touret"
        CType(Me.TouretsBindingSource,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.MydbDataSet,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.Cables_details_has_touretsBindingSource,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.SuperTabControl1,System.ComponentModel.ISupportInitialize).EndInit
        Me.SuperTabControl1.ResumeLayout(false)
        Me.SuperTabControlPanel3.ResumeLayout(false)
        CType(Me.Lst_cable_mise_touretDataGridViewX,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.Lst_cable_mise_touretBindingSource,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.DataGridViewX1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.Mise_en_touret,System.ComponentModel.ISupportInitialize).EndInit
        Me.SuperTabControlPanel4.ResumeLayout(false)
        CType(Me.Lst_cable_touret_poseDataGridViewX,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.Lst_cable_touret_poseBindingSource,System.ComponentModel.ISupportInitialize).EndInit
        Me.SuperTabControlPanel1.ResumeLayout(false)
        CType(Me.Lst_fourniture_touretDataGridViewX,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.Lst_fourniture_touretBindingSource,System.ComponentModel.ISupportInitialize).EndInit
        Me.SuperTabControlPanel2.ResumeLayout(false)
        Me.SuperTabControlPanel2.PerformLayout
        CType(Me.DocumentsBindingSource,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.Lst_doc_touretDataGridViewX,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.Lst_doc_touretBindingSource1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.Donnee_phyBindingSource,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.ErrorProvider1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.Lst_cablesBindingSource,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.Tourets_has_fournituresBindingSource,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.CablesBindingSource,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.Fournitures_has_documentsBindingSource,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.Types_cableBindingSource,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.Sections_cablesBindingSource,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.Donnees_cablesBindingSource,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.Documents_has_touretsBindingSource,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents MydbDataSet As progelec.mydbDataSet
    Friend WithEvents Tourets_has_fournituresBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TouretsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents RepereTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Long_estimeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ActifCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents Cables_details_has_touretsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Fournitures_has_documentsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DocumentsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TouretsTableAdapter As progelec.mydbDataSetTableAdapters.touretsTableAdapter
    Friend WithEvents Tourets_has_fournituresTableAdapter As progelec.mydbDataSetTableAdapters.tourets_has_fournituresTableAdapter
    Friend WithEvents Cables_details_has_touretsTableAdapter As progelec.mydbDataSetTableAdapters.cables_details_has_touretsTableAdapter
    Friend WithEvents Fournitures_has_documentsTableAdapter As progelec.mydbDataSetTableAdapters.fournitures_has_documentsTableAdapter
    Friend WithEvents DocumentsTableAdapter As progelec.mydbDataSetTableAdapters.documentsTableAdapter
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX2 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX3 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX4 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents SuperTabControl1 As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents SuperTabControlPanel2 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SuperTabItem2 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel1 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SuperTabItem1 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel4 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SuperTabItem4 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel3 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SuperTabItem3 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents Types_cableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Types_cableTableAdapter As progelec.mydbDataSetTableAdapters.types_cableTableAdapter
    Friend WithEvents TableAdapterManager As progelec.mydbDataSetTableAdapters.TableAdapterManager
    Friend WithEvents Sections_cablesTableAdapter As progelec.mydbDataSetTableAdapters.sections_cablesTableAdapter
    Friend WithEvents Sections_cablesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Donnees_cablesTableAdapter As progelec.mydbDataSetTableAdapters.donnees_cablesTableAdapter
    Friend WithEvents Donnees_cablesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents Lst_fourniture_touretBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Lst_fourniture_touretTableAdapter As progelec.mydbDataSetTableAdapters.lst_fourniture_touretTableAdapter
    Friend WithEvents Lst_fourniture_touretDataGridViewX As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn2 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn3 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn19 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn4 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ButtonX5 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ComboBoxEx1 As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Donnee_phyBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Donnee_phyTableAdapter As progelec.mydbDataSetTableAdapters.donnee_phyTableAdapter
    Friend WithEvents CablesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CablesTableAdapter As progelec.mydbDataSetTableAdapters.cablesTableAdapter
    Private WithEvents DataGridViewX1 As DevComponents.DotNetBar.Controls.DataGridViewX
    Private WithEvents LabelXGlisserLesCablesDansLeTouret As DevComponents.DotNetBar.LabelX
    Private WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Private WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Private WithEvents label4 As System.Windows.Forms.Label
    Friend WithEvents Lst_cablesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Lst_cablesTableAdapter As progelec.mydbDataSetTableAdapters.lst_cablesTableAdapter
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Private WithEvents SuperValidator As DevComponents.DotNetBar.Validator.SuperValidator
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Highlighter1 As DevComponents.DotNetBar.Validator.Highlighter
    Friend WithEvents RequiredFieldValidator1 As DevComponents.DotNetBar.Validator.RequiredFieldValidator
    Private WithEvents CircularProgress As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents Documents_has_touretsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Documents_has_touretsTableAdapter As progelec.mydbDataSetTableAdapters.documents_has_touretsTableAdapter
    Private WithEvents SwitchButtonDocSelect As DevComponents.DotNetBar.Controls.SwitchButton
    Private WithEvents LabelXselect As DevComponents.DotNetBar.LabelX
    Friend WithEvents Lst_doc_touretTableAdapter As progelec.mydbDataSetTableAdapters.lst_doc_touretTableAdapter
    Friend WithEvents Lst_doc_touretBindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents Lst_doc_touretDataGridViewX As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Lst_cable_mise_touretTableAdapter As progelec.mydbDataSetTableAdapters.lst_cable_mise_touretTableAdapter
    Friend WithEvents Lst_cable_mise_touretDataGridViewX As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents DataGridViewTextBoxColumn39 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn42 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn43 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Lst_cable_mise_touretBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Mise_en_touret As System.Windows.Forms.BindingSource
    Friend WithEvents Mise_en_touret_TableAdapter As progelec.mydbDataSetTableAdapters.lst_cable_mise_touretTableAdapter
    Friend WithEvents IdcableDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RepereEquipementDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RepereSalleDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReferenceDepartDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RepereCableDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdcablesdetailsDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FilsDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LongueurDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SectionDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TypesDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SegregationDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RepereEquipement1DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RepereSalle1DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReferenceBornierDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CategorieDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LotcableDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ParcourDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WarningDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContrainteDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents LotteneantDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LotaboutissantDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Idcable1DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TouretdefDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TouretreelDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CaseModedeposeWhenTrueThenMonoCoucheElseMultiCouchesEndDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdcableDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RepereEquipementDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RepereSalleDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReferenceDepartDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RepereCableDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdcablesdetailsDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FilsDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LongueurDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SectionDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TypesDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SegregationDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RepereEquipement1DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RepereSalle1DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReferenceBornierDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CategorieDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LotcableDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ParcourDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WarningDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContrainteDataGridViewCheckBoxColumn1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents LotteneantDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LotaboutissantDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Idcable1DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TouretdefDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TouretreelDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CaseModedeposeWhenTrueThenMonoCoucheElseMultiCouchesEndDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents ButtonX As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Lst_cable_touret_poseBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Lst_cable_touret_poseTableAdapter As progelec.mydbDataSetTableAdapters.lst_cable_touret_poseTableAdapter
    Friend WithEvents Lst_cable_touret_poseDataGridViewX As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents DataGridViewTextBoxColumn26 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn27 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn28 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn29 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn30 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn31 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn32 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn33 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn34 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn35 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn36 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn37 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn38 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn40 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn41 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn44 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn45 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn46 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn5 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn47 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn48 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn49 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn50 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn51 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn52 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn53 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ButtonX6 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents DataGridViewTextBoxColumn20 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn21 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn22 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn23 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn24 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn25 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescriptionTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ButtonX8 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX7 As DevComponents.DotNetBar.ButtonX
End Class
