Imports DevComponents.DotNetBar

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCable
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
        Dim IdcableLabel As System.Windows.Forms.Label
        Dim Repere_cableLabel As System.Windows.Forms.Label
        Dim Departs_iddepartsLabel As System.Windows.Forms.Label
        Dim Borniers_idbornierLabel As System.Windows.Forms.Label
        Dim VoieLabel As System.Windows.Forms.Label
        Dim TensionLabel As System.Windows.Forms.Label
        Dim SectionGlobaleLabel As System.Windows.Forms.Label
        Dim TypesLabel As System.Windows.Forms.Label
        Dim DesignationLabel As System.Windows.Forms.Label
        Dim LotLabel As System.Windows.Forms.Label
        Dim DesignationLabel1 As System.Windows.Forms.Label
        Dim EntrepriseLabel As System.Windows.Forms.Label
        Dim SegregationLabel As System.Windows.Forms.Label
        Dim DesignationLabel2 As System.Windows.Forms.Label
        Dim CategorieLabel As System.Windows.Forms.Label
        Dim Repere_equipementLabel As System.Windows.Forms.Label
        Dim DesignationLabel3 As System.Windows.Forms.Label
        Dim Label1 As System.Windows.Forms.Label
        Dim CoupleLabel As System.Windows.Forms.Label
        Dim SerrageLabel As System.Windows.Forms.Label
        Dim CoupleLabel1 As System.Windows.Forms.Label
        Dim SerrageLabel1 As System.Windows.Forms.Label
        Dim Label2 As System.Windows.Forms.Label
        Dim Label3 As System.Windows.Forms.Label
        Dim Label6 As System.Windows.Forms.Label
        Dim Label9 As System.Windows.Forms.Label
        Dim Label13 As System.Windows.Forms.Label
        Dim Label14 As System.Windows.Forms.Label
        Dim Label15 As System.Windows.Forms.Label
        Dim Label16 As System.Windows.Forms.Label
        Dim Longueur_Note_CalculeLabel As System.Windows.Forms.Label
        Dim LMAXLabel As System.Windows.Forms.Label
        Dim Departs_iddepartsLabel1 As System.Windows.Forms.Label
        Dim Borniers_idbornierLabel1 As System.Windows.Forms.Label
        Dim Cont1ValLabel As System.Windows.Forms.Label
        Dim Cont1ModeLabel As System.Windows.Forms.Label
        Dim Cont2ValLabel As System.Windows.Forms.Label
        Dim Cont2ModeLabel As System.Windows.Forms.Label
        Dim Cont3ValLabel As System.Windows.Forms.Label
        Dim Cont3ModeLabel As System.Windows.Forms.Label
        Dim Cont4ValLabel As System.Windows.Forms.Label
        Dim Cont4ModeLabel As System.Windows.Forms.Label
        Dim Cont5ValLabel As System.Windows.Forms.Label
        Dim Cont5ModeLabel As System.Windows.Forms.Label
        Dim Cont6ValLabel As System.Windows.Forms.Label
        Dim Cont6ModeLabel As System.Windows.Forms.Label
        Dim Cont7ValLabel As System.Windows.Forms.Label
        Dim Cont7ModeLabel As System.Windows.Forms.Label
        Dim Cont8ValLabel As System.Windows.Forms.Label
        Dim Cont8ModeLabel As System.Windows.Forms.Label
        Dim DiversLabel As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormCable))
        Me.Cables_detailsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MydbDataSet = New progelec.mydbDataSet()
        Me.CablesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SuperTabItem3 = New DevComponents.DotNetBar.SuperTabItem()
        Me.SectionGlobaleTextBox = New System.Windows.Forms.TextBox()
        Me.SuperValidator1 = New DevComponents.DotNetBar.Validator.SuperValidator()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Highlighter1 = New DevComponents.DotNetBar.Validator.Highlighter()
        Me.Repere_equipementComboBox = New System.Windows.Forms.ComboBox()
        Me.EquipementsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.RequiredFieldValidator7 = New DevComponents.DotNetBar.Validator.RequiredFieldValidator("Your error message here.")
        Me.ComboBox7 = New System.Windows.Forms.ComboBox()
        Me.EquipementAboutissantBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.RequiredFieldValidator1 = New DevComponents.DotNetBar.Validator.RequiredFieldValidator("Your error message here.")
        Me.Repere_cableTextBox = New System.Windows.Forms.TextBox()
        Me.RequiredFieldValidator9 = New DevComponents.DotNetBar.Validator.RequiredFieldValidator("Your error message here.")
        Me.Types_cable_idtypes_cableComboBox = New System.Windows.Forms.ComboBox()
        Me.Types_cableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.RequiredFieldValidator5 = New DevComponents.DotNetBar.Validator.RequiredFieldValidator("Your error message here.")
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.LotsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.RequiredFieldValidator6 = New DevComponents.DotNetBar.Validator.RequiredFieldValidator("Your error message here.")
        Me.ComboBox = New System.Windows.Forms.ComboBox()
        Me.SegregationsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.RequiredFieldValidator3 = New DevComponents.DotNetBar.Validator.RequiredFieldValidator("Your error message here.")
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.CategoriesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.RequiredFieldValidator4 = New DevComponents.DotNetBar.Validator.RequiredFieldValidator("Your error message here.")
        Me.RequiredFieldValidator8 = New DevComponents.DotNetBar.Validator.RequiredFieldValidator("Your error message here.")
        Me.RequiredFieldValidator2 = New DevComponents.DotNetBar.Validator.RequiredFieldValidator("Your error message here.")
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ButtonX5 = New DevComponents.DotNetBar.ButtonX()
        Me.Departs_iddepartsComboBox = New System.Windows.Forms.ComboBox()
        Me.Lst_departs_onBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SerrageCheckBox = New System.Windows.Forms.CheckBox()
        Me.CoupleTextBox = New System.Windows.Forms.TextBox()
        Me.ComboBox3 = New System.Windows.Forms.ComboBox()
        Me.LotTenantBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DesignationTextBox3 = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ButtonX6 = New DevComponents.DotNetBar.ButtonX()
        Me.Borniers_idbornierComboBox = New System.Windows.Forms.ComboBox()
        Me.Lst_Borniers_onBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ComboBox6 = New System.Windows.Forms.ComboBox()
        Me.LotAboutissantBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CoupleCheckBox = New System.Windows.Forms.CheckBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.SerrageTextBox = New System.Windows.Forms.TextBox()
        Me.IdcableTextBox = New System.Windows.Forms.TextBox()
        Me.VoieTextBox = New System.Windows.Forms.TextBox()
        Me.TensionTextBox = New System.Windows.Forms.TextBox()
        Me.DesignationTextBox = New System.Windows.Forms.TextBox()
        Me.BlindageCheckBox = New System.Windows.Forms.CheckBox()
        Me.DesignationTextBox1 = New System.Windows.Forms.TextBox()
        Me.EntrepriseTextBox = New System.Windows.Forms.TextBox()
        Me.DesignationTextBox2 = New System.Windows.Forms.TextBox()
        Me.ButtonXEnregistrer = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonXNouveau = New DevComponents.DotNetBar.ButtonX()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn19 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn20 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn21 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn22 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.longueur = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Parcour_detail_idBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TextBox8 = New System.Windows.Forms.TextBox()
        Me.ParcoursBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TextBox9 = New System.Windows.Forms.TextBox()
        Me.ButtonX3 = New DevComponents.DotNetBar.ButtonX()
        Me.TextBox10 = New System.Windows.Forms.TextBox()
        Me.TextBox11 = New System.Windows.Forms.TextBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.DataGridView4 = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn28 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn29 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn30 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn31 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.trefle = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewTextBoxColumn32 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn33 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn34 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cable_details_sectionBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ComboBox9 = New System.Windows.Forms.ComboBox()
        Me.Sections_cablesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextBox16 = New System.Windows.Forms.TextBox()
        Me.TextBox17 = New System.Windows.Forms.TextBox()
        Me.TextBox18 = New System.Windows.Forms.TextBox()
        Me.SuperTabControl1 = New DevComponents.DotNetBar.SuperTabControl()
        Me.SuperTabControlPanel2 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.ProgressBarX1 = New DevComponents.DotNetBar.Controls.ProgressBarX()
        Me.ButtonX8 = New DevComponents.DotNetBar.ButtonX()
        Me.ProgressSteps1 = New DevComponents.DotNetBar.ProgressSteps()
        Me.StepItem1 = New DevComponents.DotNetBar.StepItem()
        Me.StepItem6 = New DevComponents.DotNetBar.StepItem()
        Me.StepItem5 = New DevComponents.DotNetBar.StepItem()
        Me.StepItem2 = New DevComponents.DotNetBar.StepItem()
        Me.StepItem3 = New DevComponents.DotNetBar.StepItem()
        Me.StepItem4 = New DevComponents.DotNetBar.StepItem()
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.VerouillageParcoursCheckBox = New System.Windows.Forms.CheckBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ComboBoxEx6 = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.ComboBoxEx5 = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.ComboBoxEx8 = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.ComboBoxEx7 = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.ComboBoxEx4 = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.ComboBoxEx3 = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Cont8ModeTextBox = New System.Windows.Forms.TextBox()
        Me.ComboBoxEx2 = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.ComboBoxEx1 = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Cont7ModeTextBox = New System.Windows.Forms.TextBox()
        Me.Cont6ModeTextBox = New System.Windows.Forms.TextBox()
        Me.Cont5ModeTextBox = New System.Windows.Forms.TextBox()
        Me.Cont4ModeTextBox = New System.Windows.Forms.TextBox()
        Me.Cont3ModeTextBox = New System.Windows.Forms.TextBox()
        Me.Cont2ModeTextBox = New System.Windows.Forms.TextBox()
        Me.Cont1ValTextBox = New System.Windows.Forms.TextBox()
        Me.ContrainteCheckBox = New System.Windows.Forms.CheckBox()
        Me.LMAXTextBox = New System.Windows.Forms.TextBox()
        Me.Longueur_Note_CalculeTextBox = New System.Windows.Forms.TextBox()
        Me.SuperTabItem2 = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel1 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.RadioButton4 = New System.Windows.Forms.RadioButton()
        Me.RadioButton5 = New System.Windows.Forms.RadioButton()
        Me.RadioButton6 = New System.Windows.Forms.RadioButton()
        Me.ButtonX4 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX2 = New DevComponents.DotNetBar.ButtonX()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.SuperTabItem1 = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel3 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.SuperTabItem4 = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel4 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.SuperTabItem5 = New DevComponents.DotNetBar.SuperTabItem()
        Me.Departs_iddepartsTextBox = New System.Windows.Forms.TextBox()
        Me.Borniers_idbornierTextBox = New System.Windows.Forms.TextBox()
        Me.Donnees_cablesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DepartsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CablesTableAdapter = New progelec.mydbDataSetTableAdapters.cablesTableAdapter()
        Me.TableAdapterManager = New progelec.mydbDataSetTableAdapters.TableAdapterManager()
        Me.Cables_detailsTableAdapter = New progelec.mydbDataSetTableAdapters.cables_detailsTableAdapter()
        Me.CategoriesTableAdapter = New progelec.mydbDataSetTableAdapters.categoriesTableAdapter()
        Me.DepartsTableAdapter = New progelec.mydbDataSetTableAdapters.departsTableAdapter()
        Me.EquipementsTableAdapter = New progelec.mydbDataSetTableAdapters.equipementsTableAdapter()
        Me.LotsTableAdapter = New progelec.mydbDataSetTableAdapters.lotsTableAdapter()
        Me.SegregationsTableAdapter = New progelec.mydbDataSetTableAdapters.segregationsTableAdapter()
        Me.Types_cableTableAdapter = New progelec.mydbDataSetTableAdapters.types_cableTableAdapter()
        Me.Lst_departs_onTableAdapter = New progelec.mydbDataSetTableAdapters.lst_departs_onTableAdapter()
        Me.Lst_Borniers_onTableAdapter = New progelec.mydbDataSetTableAdapters.lst_borniers_onTableAdapter()
        Me.Donnees_cablesTableAdapter = New progelec.mydbDataSetTableAdapters.donnees_cablesTableAdapter()
        Me.Sections_cablesTableAdapter = New progelec.mydbDataSetTableAdapters.sections_cablesTableAdapter()
        Me.Cable_details_sectionTableAdapter = New progelec.mydbDataSetTableAdapters.cable_details_sectionTableAdapter()
        Me.Lst_assoc_par_trcBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Lst_assoc_par_trcTableAdapter = New progelec.mydbDataSetTableAdapters.lst_assoc_par_trcTableAdapter()
        Me.Lst_assoc_par_trc2BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Lst_assoc_par_trc2TableAdapter = New progelec.mydbDataSetTableAdapters.lst_assoc_par_trc2TableAdapter()
        Me.ParcoursTableAdapter = New progelec.mydbDataSetTableAdapters.parcoursTableAdapter()
        Me.Parcours_detailBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Parcours_detailTableAdapter = New progelec.mydbDataSetTableAdapters.parcours_detailTableAdapter()
        Me.Parcour_detail_idTableAdapter = New progelec.mydbDataSetTableAdapters.parcour_detail_idTableAdapter()
        Me.TronconsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TronconsTableAdapter = New progelec.mydbDataSetTableAdapters.tronconsTableAdapter()
        Me.VeroulliageCableCheckBox = New System.Windows.Forms.CheckBox()
        Me.DiversTextBox = New System.Windows.Forms.TextBox()
        Me.ButtonX7 = New DevComponents.DotNetBar.ButtonX()
        Me.Actions_borniersTableAdapter = New progelec.mydbDataSetTableAdapters.actions_borniersTableAdapter()
        Me.Lst_cable_mise_touretBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Lst_cable_mise_touretTableAdapter = New progelec.mydbDataSetTableAdapters.lst_cable_mise_touretTableAdapter()
        Me.Cables_details_has_touretsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Cables_details_has_touretsTableAdapter = New progelec.mydbDataSetTableAdapters.cables_details_has_touretsTableAdapter()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        IdcableLabel = New System.Windows.Forms.Label()
        Repere_cableLabel = New System.Windows.Forms.Label()
        Departs_iddepartsLabel = New System.Windows.Forms.Label()
        Borniers_idbornierLabel = New System.Windows.Forms.Label()
        VoieLabel = New System.Windows.Forms.Label()
        TensionLabel = New System.Windows.Forms.Label()
        SectionGlobaleLabel = New System.Windows.Forms.Label()
        TypesLabel = New System.Windows.Forms.Label()
        DesignationLabel = New System.Windows.Forms.Label()
        LotLabel = New System.Windows.Forms.Label()
        DesignationLabel1 = New System.Windows.Forms.Label()
        EntrepriseLabel = New System.Windows.Forms.Label()
        SegregationLabel = New System.Windows.Forms.Label()
        DesignationLabel2 = New System.Windows.Forms.Label()
        CategorieLabel = New System.Windows.Forms.Label()
        Repere_equipementLabel = New System.Windows.Forms.Label()
        DesignationLabel3 = New System.Windows.Forms.Label()
        Label1 = New System.Windows.Forms.Label()
        CoupleLabel = New System.Windows.Forms.Label()
        SerrageLabel = New System.Windows.Forms.Label()
        CoupleLabel1 = New System.Windows.Forms.Label()
        SerrageLabel1 = New System.Windows.Forms.Label()
        Label2 = New System.Windows.Forms.Label()
        Label3 = New System.Windows.Forms.Label()
        Label6 = New System.Windows.Forms.Label()
        Label9 = New System.Windows.Forms.Label()
        Label13 = New System.Windows.Forms.Label()
        Label14 = New System.Windows.Forms.Label()
        Label15 = New System.Windows.Forms.Label()
        Label16 = New System.Windows.Forms.Label()
        Longueur_Note_CalculeLabel = New System.Windows.Forms.Label()
        LMAXLabel = New System.Windows.Forms.Label()
        Departs_iddepartsLabel1 = New System.Windows.Forms.Label()
        Borniers_idbornierLabel1 = New System.Windows.Forms.Label()
        Cont1ValLabel = New System.Windows.Forms.Label()
        Cont1ModeLabel = New System.Windows.Forms.Label()
        Cont2ValLabel = New System.Windows.Forms.Label()
        Cont2ModeLabel = New System.Windows.Forms.Label()
        Cont3ValLabel = New System.Windows.Forms.Label()
        Cont3ModeLabel = New System.Windows.Forms.Label()
        Cont4ValLabel = New System.Windows.Forms.Label()
        Cont4ModeLabel = New System.Windows.Forms.Label()
        Cont5ValLabel = New System.Windows.Forms.Label()
        Cont5ModeLabel = New System.Windows.Forms.Label()
        Cont6ValLabel = New System.Windows.Forms.Label()
        Cont6ModeLabel = New System.Windows.Forms.Label()
        Cont7ValLabel = New System.Windows.Forms.Label()
        Cont7ModeLabel = New System.Windows.Forms.Label()
        Cont8ValLabel = New System.Windows.Forms.Label()
        Cont8ModeLabel = New System.Windows.Forms.Label()
        DiversLabel = New System.Windows.Forms.Label()
        CType(Me.Cables_detailsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MydbDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CablesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EquipementsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EquipementAboutissantBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Types_cableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LotsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SegregationsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CategoriesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.Lst_departs_onBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LotTenantBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.Lst_Borniers_onBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LotAboutissantBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Parcour_detail_idBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ParcoursBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cable_details_sectionBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Sections_cablesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SuperTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControl1.SuspendLayout()
        Me.SuperTabControlPanel2.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuperTabControlPanel1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.Donnees_cablesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DepartsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Lst_assoc_par_trcBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Lst_assoc_par_trc2BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Parcours_detailBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TronconsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Lst_cable_mise_touretBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cables_details_has_touretsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'IdcableLabel
        '
        IdcableLabel.Anchor = System.Windows.Forms.AnchorStyles.Top
        IdcableLabel.AutoSize = True
        IdcableLabel.Location = New System.Drawing.Point(753, 7)
        IdcableLabel.Name = "IdcableLabel"
        IdcableLabel.Size = New System.Drawing.Size(44, 13)
        IdcableLabel.TabIndex = 2
        IdcableLabel.Text = "idcable:"
        IdcableLabel.Visible = False
        '
        'Repere_cableLabel
        '
        Repere_cableLabel.AutoSize = True
        Repere_cableLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Repere_cableLabel.Location = New System.Drawing.Point(416, 30)
        Repere_cableLabel.Name = "Repere_cableLabel"
        Repere_cableLabel.Size = New System.Drawing.Size(151, 25)
        Repere_cableLabel.TabIndex = 6
        Repere_cableLabel.Text = "repere cable:"
        '
        'Departs_iddepartsLabel
        '
        Departs_iddepartsLabel.AutoSize = True
        Departs_iddepartsLabel.Location = New System.Drawing.Point(22, 129)
        Departs_iddepartsLabel.Name = "Departs_iddepartsLabel"
        Departs_iddepartsLabel.Size = New System.Drawing.Size(91, 13)
        Departs_iddepartsLabel.TabIndex = 10
        Departs_iddepartsLabel.Text = "departs iddeparts:"
        '
        'Borniers_idbornierLabel
        '
        Borniers_idbornierLabel.AutoSize = True
        Borniers_idbornierLabel.Location = New System.Drawing.Point(28, 125)
        Borniers_idbornierLabel.Name = "Borniers_idbornierLabel"
        Borniers_idbornierLabel.Size = New System.Drawing.Size(90, 13)
        Borniers_idbornierLabel.TabIndex = 10
        Borniers_idbornierLabel.Text = "borniers idbornier:"
        '
        'VoieLabel
        '
        VoieLabel.AutoSize = True
        VoieLabel.Location = New System.Drawing.Point(622, 94)
        VoieLabel.Name = "VoieLabel"
        VoieLabel.Size = New System.Drawing.Size(31, 13)
        VoieLabel.TabIndex = 10
        VoieLabel.Text = "Voie:"
        '
        'TensionLabel
        '
        TensionLabel.AutoSize = True
        TensionLabel.Location = New System.Drawing.Point(728, 94)
        TensionLabel.Name = "TensionLabel"
        TensionLabel.Size = New System.Drawing.Size(48, 13)
        TensionLabel.TabIndex = 13
        TensionLabel.Text = "Tension:"
        '
        'SectionGlobaleLabel
        '
        SectionGlobaleLabel.AutoSize = True
        SectionGlobaleLabel.Location = New System.Drawing.Point(831, 94)
        SectionGlobaleLabel.Name = "SectionGlobaleLabel"
        SectionGlobaleLabel.Size = New System.Drawing.Size(85, 13)
        SectionGlobaleLabel.TabIndex = 12
        SectionGlobaleLabel.Text = "Section Globale:"
        '
        'TypesLabel
        '
        TypesLabel.AutoSize = True
        TypesLabel.Location = New System.Drawing.Point(419, 94)
        TypesLabel.Name = "TypesLabel"
        TypesLabel.Size = New System.Drawing.Size(35, 13)
        TypesLabel.TabIndex = 24
        TypesLabel.Text = "types:"
        '
        'DesignationLabel
        '
        DesignationLabel.AutoSize = True
        DesignationLabel.Location = New System.Drawing.Point(403, 253)
        DesignationLabel.Name = "DesignationLabel"
        DesignationLabel.Size = New System.Drawing.Size(64, 13)
        DesignationLabel.TabIndex = 26
        DesignationLabel.Text = "désignation:"
        '
        'LotLabel
        '
        LotLabel.AutoSize = True
        LotLabel.Location = New System.Drawing.Point(446, 168)
        LotLabel.Name = "LotLabel"
        LotLabel.Size = New System.Drawing.Size(21, 13)
        LotLabel.TabIndex = 18
        LotLabel.Text = "lot:"
        '
        'DesignationLabel1
        '
        DesignationLabel1.AutoSize = True
        DesignationLabel1.Location = New System.Drawing.Point(403, 197)
        DesignationLabel1.Name = "DesignationLabel1"
        DesignationLabel1.Size = New System.Drawing.Size(64, 13)
        DesignationLabel1.TabIndex = 20
        DesignationLabel1.Text = "designation:"
        '
        'EntrepriseLabel
        '
        EntrepriseLabel.AutoSize = True
        EntrepriseLabel.Location = New System.Drawing.Point(410, 223)
        EntrepriseLabel.Name = "EntrepriseLabel"
        EntrepriseLabel.Size = New System.Drawing.Size(57, 13)
        EntrepriseLabel.TabIndex = 22
        EntrepriseLabel.Text = "Entreprise:"
        '
        'SegregationLabel
        '
        SegregationLabel.AutoSize = True
        SegregationLabel.Location = New System.Drawing.Point(703, 53)
        SegregationLabel.Name = "SegregationLabel"
        SegregationLabel.Size = New System.Drawing.Size(65, 13)
        SegregationLabel.TabIndex = 4
        SegregationLabel.Text = "segregation:"
        '
        'DesignationLabel2
        '
        DesignationLabel2.AutoSize = True
        DesignationLabel2.Location = New System.Drawing.Point(704, 76)
        DesignationLabel2.Name = "DesignationLabel2"
        DesignationLabel2.Size = New System.Drawing.Size(64, 13)
        DesignationLabel2.TabIndex = 8
        DesignationLabel2.Text = "designation:"
        '
        'CategorieLabel
        '
        CategorieLabel.AutoSize = True
        CategorieLabel.Location = New System.Drawing.Point(412, 142)
        CategorieLabel.Name = "CategorieLabel"
        CategorieLabel.Size = New System.Drawing.Size(55, 13)
        CategorieLabel.TabIndex = 16
        CategorieLabel.Text = "Categorie:"
        '
        'Repere_equipementLabel
        '
        Repere_equipementLabel.AutoSize = True
        Repere_equipementLabel.Location = New System.Drawing.Point(22, 19)
        Repere_equipementLabel.Name = "Repere_equipementLabel"
        Repere_equipementLabel.Size = New System.Drawing.Size(98, 13)
        Repere_equipementLabel.TabIndex = 0
        Repere_equipementLabel.Text = "repere equipement:"
        '
        'DesignationLabel3
        '
        DesignationLabel3.AutoSize = True
        DesignationLabel3.Location = New System.Drawing.Point(22, 76)
        DesignationLabel3.Name = "DesignationLabel3"
        DesignationLabel3.Size = New System.Drawing.Size(64, 13)
        DesignationLabel3.TabIndex = 8
        DesignationLabel3.Text = "designation:"
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(22, 47)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(21, 13)
        Label1.TabIndex = 4
        Label1.Text = "lot:"
        '
        'CoupleLabel
        '
        CoupleLabel.AutoSize = True
        CoupleLabel.Location = New System.Drawing.Point(22, 157)
        CoupleLabel.Name = "CoupleLabel"
        CoupleLabel.Size = New System.Drawing.Size(42, 13)
        CoupleLabel.TabIndex = 12
        CoupleLabel.Text = "couple:"
        '
        'SerrageLabel
        '
        SerrageLabel.AutoSize = True
        SerrageLabel.Location = New System.Drawing.Point(22, 186)
        SerrageLabel.Name = "SerrageLabel"
        SerrageLabel.Size = New System.Drawing.Size(45, 13)
        SerrageLabel.TabIndex = 14
        SerrageLabel.Text = "serrage:"
        '
        'CoupleLabel1
        '
        CoupleLabel1.AutoSize = True
        CoupleLabel1.Location = New System.Drawing.Point(28, 153)
        CoupleLabel1.Name = "CoupleLabel1"
        CoupleLabel1.Size = New System.Drawing.Size(43, 13)
        CoupleLabel1.TabIndex = 14
        CoupleLabel1.Text = "Couple:"
        '
        'SerrageLabel1
        '
        SerrageLabel1.AutoSize = True
        SerrageLabel1.Location = New System.Drawing.Point(28, 176)
        SerrageLabel1.Name = "SerrageLabel1"
        SerrageLabel1.Size = New System.Drawing.Size(45, 13)
        SerrageLabel1.TabIndex = 12
        SerrageLabel1.Text = "serrage:"
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(28, 47)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(21, 13)
        Label2.TabIndex = 4
        Label2.Text = "lot:"
        '
        'Label3
        '
        Label3.AutoSize = True
        Label3.Location = New System.Drawing.Point(28, 20)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(98, 13)
        Label3.TabIndex = 0
        Label3.Text = "repere equipement:"
        '
        'Label6
        '
        Label6.AutoSize = True
        Label6.Location = New System.Drawing.Point(28, 74)
        Label6.Name = "Label6"
        Label6.Size = New System.Drawing.Size(64, 13)
        Label6.TabIndex = 8
        Label6.Text = "designation:"
        '
        'Label9
        '
        Label9.AutoSize = True
        Label9.Location = New System.Drawing.Point(105, 23)
        Label9.Name = "Label9"
        Label9.Size = New System.Drawing.Size(51, 13)
        Label9.TabIndex = 1
        Label9.Text = "longueur:"
        '
        'Label13
        '
        Label13.AutoSize = True
        Label13.Location = New System.Drawing.Point(994, 137)
        Label13.Name = "Label13"
        Label13.Size = New System.Drawing.Size(44, 13)
        Label13.TabIndex = 1
        Label13.Text = "section:"
        '
        'Label14
        '
        Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Label14.AutoSize = True
        Label14.Location = New System.Drawing.Point(829, 225)
        Label14.Name = "Label14"
        Label14.Size = New System.Drawing.Size(82, 13)
        Label14.TabIndex = 8
        Label14.Text = "idcables details:"
        Label14.Visible = False
        '
        'Label15
        '
        Label15.AutoSize = True
        Label15.Location = New System.Drawing.Point(889, 137)
        Label15.Name = "Label15"
        Label15.Size = New System.Drawing.Size(25, 13)
        Label15.TabIndex = 0
        Label15.Text = "Fils:"
        '
        'Label16
        '
        Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Label16.AutoSize = True
        Label16.Location = New System.Drawing.Point(829, 264)
        Label16.Name = "Label16"
        Label16.Size = New System.Drawing.Size(78, 13)
        Label16.TabIndex = 10
        Label16.Text = "cables idcable:"
        Label16.Visible = False
        '
        'Longueur_Note_CalculeLabel
        '
        Longueur_Note_CalculeLabel.AutoSize = True
        Longueur_Note_CalculeLabel.Location = New System.Drawing.Point(279, 23)
        Longueur_Note_CalculeLabel.Name = "Longueur_Note_CalculeLabel"
        Longueur_Note_CalculeLabel.Size = New System.Drawing.Size(116, 13)
        Longueur_Note_CalculeLabel.TabIndex = 0
        Longueur_Note_CalculeLabel.Text = "Longueur Note Calcul :"
        '
        'LMAXLabel
        '
        LMAXLabel.AutoSize = True
        LMAXLabel.Location = New System.Drawing.Point(524, 23)
        LMAXLabel.Name = "LMAXLabel"
        LMAXLabel.Size = New System.Drawing.Size(39, 13)
        LMAXLabel.TabIndex = 2
        LMAXLabel.Text = "LMAX:"
        '
        'Departs_iddepartsLabel1
        '
        Departs_iddepartsLabel1.AutoSize = True
        Departs_iddepartsLabel1.Location = New System.Drawing.Point(194, 7)
        Departs_iddepartsLabel1.Name = "Departs_iddepartsLabel1"
        Departs_iddepartsLabel1.Size = New System.Drawing.Size(91, 13)
        Departs_iddepartsLabel1.TabIndex = 0
        Departs_iddepartsLabel1.Text = "departs iddeparts:"
        Departs_iddepartsLabel1.Visible = False
        '
        'Borniers_idbornierLabel1
        '
        Borniers_idbornierLabel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Borniers_idbornierLabel1.AutoSize = True
        Borniers_idbornierLabel1.Location = New System.Drawing.Point(955, 7)
        Borniers_idbornierLabel1.Name = "Borniers_idbornierLabel1"
        Borniers_idbornierLabel1.Size = New System.Drawing.Size(90, 13)
        Borniers_idbornierLabel1.TabIndex = 2
        Borniers_idbornierLabel1.Text = "borniers idbornier:"
        Borniers_idbornierLabel1.Visible = False
        '
        'Cont1ValLabel
        '
        Cont1ValLabel.AutoSize = True
        Cont1ValLabel.Location = New System.Drawing.Point(222, 36)
        Cont1ValLabel.Name = "Cont1ValLabel"
        Cont1ValLabel.Size = New System.Drawing.Size(57, 13)
        Cont1ValLabel.TabIndex = 1
        Cont1ValLabel.Text = "Selection :"
        '
        'Cont1ModeLabel
        '
        Cont1ModeLabel.AutoSize = True
        Cont1ModeLabel.Location = New System.Drawing.Point(17, 36)
        Cont1ModeLabel.Name = "Cont1ModeLabel"
        Cont1ModeLabel.Size = New System.Drawing.Size(41, 13)
        Cont1ModeLabel.TabIndex = 3
        Cont1ModeLabel.Text = "Règle :"
        '
        'Cont2ValLabel
        '
        Cont2ValLabel.AutoSize = True
        Cont2ValLabel.Location = New System.Drawing.Point(222, 64)
        Cont2ValLabel.Name = "Cont2ValLabel"
        Cont2ValLabel.Size = New System.Drawing.Size(57, 13)
        Cont2ValLabel.TabIndex = 5
        Cont2ValLabel.Text = "Selection :"
        '
        'Cont2ModeLabel
        '
        Cont2ModeLabel.AutoSize = True
        Cont2ModeLabel.Location = New System.Drawing.Point(17, 64)
        Cont2ModeLabel.Name = "Cont2ModeLabel"
        Cont2ModeLabel.Size = New System.Drawing.Size(41, 13)
        Cont2ModeLabel.TabIndex = 7
        Cont2ModeLabel.Text = "Regle :"
        '
        'Cont3ValLabel
        '
        Cont3ValLabel.AutoSize = True
        Cont3ValLabel.Location = New System.Drawing.Point(222, 91)
        Cont3ValLabel.Name = "Cont3ValLabel"
        Cont3ValLabel.Size = New System.Drawing.Size(57, 13)
        Cont3ValLabel.TabIndex = 9
        Cont3ValLabel.Text = "Selection :"
        '
        'Cont3ModeLabel
        '
        Cont3ModeLabel.AutoSize = True
        Cont3ModeLabel.Location = New System.Drawing.Point(17, 94)
        Cont3ModeLabel.Name = "Cont3ModeLabel"
        Cont3ModeLabel.Size = New System.Drawing.Size(41, 13)
        Cont3ModeLabel.TabIndex = 11
        Cont3ModeLabel.Text = "Regle :"
        '
        'Cont4ValLabel
        '
        Cont4ValLabel.AutoSize = True
        Cont4ValLabel.Location = New System.Drawing.Point(222, 121)
        Cont4ValLabel.Name = "Cont4ValLabel"
        Cont4ValLabel.Size = New System.Drawing.Size(57, 13)
        Cont4ValLabel.TabIndex = 13
        Cont4ValLabel.Text = "Selection :"
        '
        'Cont4ModeLabel
        '
        Cont4ModeLabel.AutoSize = True
        Cont4ModeLabel.Location = New System.Drawing.Point(17, 121)
        Cont4ModeLabel.Name = "Cont4ModeLabel"
        Cont4ModeLabel.Size = New System.Drawing.Size(41, 13)
        Cont4ModeLabel.TabIndex = 15
        Cont4ModeLabel.Text = "Regle :"
        '
        'Cont5ValLabel
        '
        Cont5ValLabel.AutoSize = True
        Cont5ValLabel.Location = New System.Drawing.Point(224, 147)
        Cont5ValLabel.Name = "Cont5ValLabel"
        Cont5ValLabel.Size = New System.Drawing.Size(57, 13)
        Cont5ValLabel.TabIndex = 17
        Cont5ValLabel.Text = "Selection :"
        '
        'Cont5ModeLabel
        '
        Cont5ModeLabel.AutoSize = True
        Cont5ModeLabel.Location = New System.Drawing.Point(19, 150)
        Cont5ModeLabel.Name = "Cont5ModeLabel"
        Cont5ModeLabel.Size = New System.Drawing.Size(41, 13)
        Cont5ModeLabel.TabIndex = 19
        Cont5ModeLabel.Text = "Regle :"
        '
        'Cont6ValLabel
        '
        Cont6ValLabel.AutoSize = True
        Cont6ValLabel.Location = New System.Drawing.Point(222, 173)
        Cont6ValLabel.Name = "Cont6ValLabel"
        Cont6ValLabel.Size = New System.Drawing.Size(57, 13)
        Cont6ValLabel.TabIndex = 21
        Cont6ValLabel.Text = "Selection :"
        '
        'Cont6ModeLabel
        '
        Cont6ModeLabel.AutoSize = True
        Cont6ModeLabel.Location = New System.Drawing.Point(17, 173)
        Cont6ModeLabel.Name = "Cont6ModeLabel"
        Cont6ModeLabel.Size = New System.Drawing.Size(41, 13)
        Cont6ModeLabel.TabIndex = 23
        Cont6ModeLabel.Text = "Regle :"
        '
        'Cont7ValLabel
        '
        Cont7ValLabel.AutoSize = True
        Cont7ValLabel.Location = New System.Drawing.Point(220, 195)
        Cont7ValLabel.Name = "Cont7ValLabel"
        Cont7ValLabel.Size = New System.Drawing.Size(57, 13)
        Cont7ValLabel.TabIndex = 25
        Cont7ValLabel.Text = "Selection :"
        '
        'Cont7ModeLabel
        '
        Cont7ModeLabel.AutoSize = True
        Cont7ModeLabel.Location = New System.Drawing.Point(15, 195)
        Cont7ModeLabel.Name = "Cont7ModeLabel"
        Cont7ModeLabel.Size = New System.Drawing.Size(41, 13)
        Cont7ModeLabel.TabIndex = 27
        Cont7ModeLabel.Text = "Regle :"
        '
        'Cont8ValLabel
        '
        Cont8ValLabel.AutoSize = True
        Cont8ValLabel.Location = New System.Drawing.Point(220, 221)
        Cont8ValLabel.Name = "Cont8ValLabel"
        Cont8ValLabel.Size = New System.Drawing.Size(57, 13)
        Cont8ValLabel.TabIndex = 29
        Cont8ValLabel.Text = "Selection :"
        '
        'Cont8ModeLabel
        '
        Cont8ModeLabel.AutoSize = True
        Cont8ModeLabel.Location = New System.Drawing.Point(15, 221)
        Cont8ModeLabel.Name = "Cont8ModeLabel"
        Cont8ModeLabel.Size = New System.Drawing.Size(41, 13)
        Cont8ModeLabel.TabIndex = 31
        Cont8ModeLabel.Text = "Regle :"
        '
        'DiversLabel
        '
        DiversLabel.AutoSize = True
        DiversLabel.Location = New System.Drawing.Point(607, 136)
        DiversLabel.Name = "DiversLabel"
        DiversLabel.Size = New System.Drawing.Size(62, 13)
        DiversLabel.TabIndex = 0
        DiversLabel.Text = "remarques :"
        '
        'Cables_detailsBindingSource
        '
        Me.Cables_detailsBindingSource.DataMember = "cables_details"
        Me.Cables_detailsBindingSource.DataSource = Me.MydbDataSet
        '
        'MydbDataSet
        '
        Me.MydbDataSet.DataSetName = "mydbDataSet"
        Me.MydbDataSet.EnforceConstraints = False
        Me.MydbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'CablesBindingSource
        '
        Me.CablesBindingSource.DataMember = "cables"
        Me.CablesBindingSource.DataSource = Me.MydbDataSet
        '
        'SuperTabItem3
        '
        Me.SuperTabItem3.GlobalItem = False
        Me.SuperTabItem3.Name = "SuperTabItem3"
        Me.SuperTabItem3.Text = "Note de Calcul"
        '
        'SectionGlobaleTextBox
        '
        Me.SectionGlobaleTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CablesBindingSource, "SectionGlobale", True))
        Me.SectionGlobaleTextBox.Location = New System.Drawing.Point(834, 110)
        Me.SectionGlobaleTextBox.Name = "SectionGlobaleTextBox"
        Me.SectionGlobaleTextBox.Size = New System.Drawing.Size(100, 20)
        Me.SectionGlobaleTextBox.TabIndex = 15
        '
        'SuperValidator1
        '
        Me.SuperValidator1.ContainerControl = Me
        Me.SuperValidator1.ErrorProvider = Me.ErrorProvider1
        Me.SuperValidator1.Highlighter = Me.Highlighter1
        Me.SuperValidator1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
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
        'Repere_equipementComboBox
        '
        Me.Repere_equipementComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.CablesBindingSource, "idequipement", True))
        Me.Repere_equipementComboBox.DataSource = Me.EquipementsBindingSource
        Me.Repere_equipementComboBox.DisplayMember = "repere equipement"
        Me.Repere_equipementComboBox.FormattingEnabled = True
        Me.Repere_equipementComboBox.Location = New System.Drawing.Point(126, 16)
        Me.Repere_equipementComboBox.Name = "Repere_equipementComboBox"
        Me.Repere_equipementComboBox.Size = New System.Drawing.Size(121, 21)
        Me.Repere_equipementComboBox.TabIndex = 1
        Me.SuperValidator1.SetValidator1(Me.Repere_equipementComboBox, Me.RequiredFieldValidator7)
        Me.Repere_equipementComboBox.ValueMember = "idequipement"
        '
        'EquipementsBindingSource
        '
        Me.EquipementsBindingSource.DataMember = "equipements"
        Me.EquipementsBindingSource.DataSource = Me.MydbDataSet
        '
        'RequiredFieldValidator7
        '
        Me.RequiredFieldValidator7.ErrorMessage = "Your error message here."
        Me.RequiredFieldValidator7.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red
        '
        'ComboBox7
        '
        Me.ComboBox7.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.CablesBindingSource, "idequipement2", True))
        Me.ComboBox7.DataSource = Me.EquipementAboutissantBindingSource
        Me.ComboBox7.DisplayMember = "repere equipement"
        Me.ComboBox7.FormattingEnabled = True
        Me.ComboBox7.Location = New System.Drawing.Point(170, 16)
        Me.ComboBox7.Name = "ComboBox7"
        Me.ComboBox7.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox7.TabIndex = 1
        Me.SuperValidator1.SetValidator1(Me.ComboBox7, Me.RequiredFieldValidator1)
        Me.ComboBox7.ValueMember = "idequipement"
        '
        'EquipementAboutissantBindingSource
        '
        Me.EquipementAboutissantBindingSource.DataMember = "equipements"
        Me.EquipementAboutissantBindingSource.DataSource = Me.MydbDataSet
        '
        'RequiredFieldValidator1
        '
        Me.RequiredFieldValidator1.ErrorMessage = "Your error message here."
        Me.RequiredFieldValidator1.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red
        '
        'Repere_cableTextBox
        '
        Me.Repere_cableTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Repere_cableTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.Repere_cableTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Repere_cableTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CablesBindingSource, "repere cable", True))
        Me.Repere_cableTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Repere_cableTextBox.Location = New System.Drawing.Point(421, 58)
        Me.Repere_cableTextBox.Name = "Repere_cableTextBox"
        Me.Repere_cableTextBox.Size = New System.Drawing.Size(265, 32)
        Me.Repere_cableTextBox.TabIndex = 7
        Me.SuperValidator1.SetValidator1(Me.Repere_cableTextBox, Me.RequiredFieldValidator9)
        '
        'RequiredFieldValidator9
        '
        Me.RequiredFieldValidator9.ErrorMessage = "Your error message here."
        Me.RequiredFieldValidator9.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red
        '
        'Types_cable_idtypes_cableComboBox
        '
        Me.Types_cable_idtypes_cableComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.CablesBindingSource, "types_cable_idtypes_cable", True))
        Me.Types_cable_idtypes_cableComboBox.DataSource = Me.Types_cableBindingSource
        Me.Types_cable_idtypes_cableComboBox.DisplayMember = "types"
        Me.Types_cable_idtypes_cableComboBox.FormattingEnabled = True
        Me.Types_cable_idtypes_cableComboBox.Location = New System.Drawing.Point(421, 109)
        Me.Types_cable_idtypes_cableComboBox.Name = "Types_cable_idtypes_cableComboBox"
        Me.Types_cable_idtypes_cableComboBox.Size = New System.Drawing.Size(121, 21)
        Me.Types_cable_idtypes_cableComboBox.TabIndex = 25
        Me.SuperValidator1.SetValidator1(Me.Types_cable_idtypes_cableComboBox, Me.RequiredFieldValidator5)
        Me.Types_cable_idtypes_cableComboBox.ValueMember = "idtypes_cable"
        '
        'Types_cableBindingSource
        '
        Me.Types_cableBindingSource.DataMember = "types_cable"
        Me.Types_cableBindingSource.DataSource = Me.MydbDataSet
        '
        'RequiredFieldValidator5
        '
        Me.RequiredFieldValidator5.ErrorMessage = "Your error message here."
        Me.RequiredFieldValidator5.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red
        '
        'ComboBox1
        '
        Me.ComboBox1.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.CablesBindingSource, "lots_idlots", True))
        Me.ComboBox1.DataSource = Me.LotsBindingSource
        Me.ComboBox1.DisplayMember = "lot"
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(475, 165)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox1.TabIndex = 19
        Me.SuperValidator1.SetValidator1(Me.ComboBox1, Me.RequiredFieldValidator6)
        Me.ComboBox1.ValueMember = "idlots"
        '
        'LotsBindingSource
        '
        Me.LotsBindingSource.DataMember = "lots"
        Me.LotsBindingSource.DataSource = Me.MydbDataSet
        '
        'RequiredFieldValidator6
        '
        Me.RequiredFieldValidator6.ErrorMessage = "Your error message here."
        Me.RequiredFieldValidator6.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red
        '
        'ComboBox
        '
        Me.ComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.CablesBindingSource, "segregations_idsegregations", True))
        Me.ComboBox.DataSource = Me.SegregationsBindingSource
        Me.ComboBox.DisplayMember = "segregation"
        Me.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox.FormattingEnabled = True
        Me.ComboBox.Location = New System.Drawing.Point(774, 48)
        Me.ComboBox.Name = "ComboBox"
        Me.ComboBox.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox.TabIndex = 5
        Me.SuperValidator1.SetValidator1(Me.ComboBox, Me.RequiredFieldValidator3)
        Me.ComboBox.ValueMember = "idsegregations"
        '
        'SegregationsBindingSource
        '
        Me.SegregationsBindingSource.DataMember = "segregations"
        Me.SegregationsBindingSource.DataSource = Me.MydbDataSet
        '
        'RequiredFieldValidator3
        '
        Me.RequiredFieldValidator3.ErrorMessage = "Your error message here."
        Me.RequiredFieldValidator3.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red
        '
        'ComboBox2
        '
        Me.ComboBox2.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.CablesBindingSource, "Categories_idCategories", True))
        Me.ComboBox2.DataSource = Me.CategoriesBindingSource
        Me.ComboBox2.DisplayMember = "Categorie"
        Me.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(475, 138)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox2.TabIndex = 17
        Me.SuperValidator1.SetValidator1(Me.ComboBox2, Me.RequiredFieldValidator4)
        Me.ComboBox2.ValueMember = "idCategories"
        '
        'CategoriesBindingSource
        '
        Me.CategoriesBindingSource.DataMember = "categories"
        Me.CategoriesBindingSource.DataSource = Me.MydbDataSet
        '
        'RequiredFieldValidator4
        '
        Me.RequiredFieldValidator4.ErrorMessage = "Your error message here."
        Me.RequiredFieldValidator4.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red
        '
        'RequiredFieldValidator8
        '
        Me.RequiredFieldValidator8.ErrorMessage = "Your error message here."
        Me.RequiredFieldValidator8.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red
        '
        'RequiredFieldValidator2
        '
        Me.RequiredFieldValidator2.ErrorMessage = "Your error message here."
        Me.RequiredFieldValidator2.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ButtonX5)
        Me.GroupBox1.Controls.Add(Me.Departs_iddepartsComboBox)
        Me.GroupBox1.Controls.Add(SerrageLabel)
        Me.GroupBox1.Controls.Add(Me.SerrageCheckBox)
        Me.GroupBox1.Controls.Add(CoupleLabel)
        Me.GroupBox1.Controls.Add(Me.CoupleTextBox)
        Me.GroupBox1.Controls.Add(Label1)
        Me.GroupBox1.Controls.Add(Me.ComboBox3)
        Me.GroupBox1.Controls.Add(Repere_equipementLabel)
        Me.GroupBox1.Controls.Add(Me.Repere_equipementComboBox)
        Me.GroupBox1.Controls.Add(DesignationLabel3)
        Me.GroupBox1.Controls.Add(Me.DesignationTextBox3)
        Me.GroupBox1.Controls.Add(Departs_iddepartsLabel)
        Me.GroupBox1.Location = New System.Drawing.Point(17, 32)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(374, 218)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tenant"
        '
        'ButtonX5
        '
        Me.ButtonX5.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX5.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX5.Image = Global.progelec.My.Resources.Resources.info_24_24
        Me.ButtonX5.Location = New System.Drawing.Point(253, 14)
        Me.ButtonX5.Name = "ButtonX5"
        Me.ButtonX5.Size = New System.Drawing.Size(33, 29)
        Me.ButtonX5.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014
        Me.ButtonX5.TabIndex = 17
        '
        'Departs_iddepartsComboBox
        '
        Me.Departs_iddepartsComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.CablesBindingSource, "departs_iddeparts", True))
        Me.Departs_iddepartsComboBox.DataSource = Me.Lst_departs_onBindingSource
        Me.Departs_iddepartsComboBox.DisplayMember = "reference depart"
        Me.Departs_iddepartsComboBox.FormattingEnabled = True
        Me.Departs_iddepartsComboBox.Location = New System.Drawing.Point(126, 126)
        Me.Departs_iddepartsComboBox.Name = "Departs_iddepartsComboBox"
        Me.Departs_iddepartsComboBox.Size = New System.Drawing.Size(235, 21)
        Me.Departs_iddepartsComboBox.TabIndex = 16
        Me.Departs_iddepartsComboBox.ValueMember = "iddepart"
        '
        'Lst_departs_onBindingSource
        '
        Me.Lst_departs_onBindingSource.DataMember = "lst_departs_on"
        Me.Lst_departs_onBindingSource.DataSource = Me.MydbDataSet
        '
        'SerrageCheckBox
        '
        Me.SerrageCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.Lst_departs_onBindingSource, "serrage", True))
        Me.SerrageCheckBox.Location = New System.Drawing.Point(126, 183)
        Me.SerrageCheckBox.Name = "SerrageCheckBox"
        Me.SerrageCheckBox.Size = New System.Drawing.Size(27, 24)
        Me.SerrageCheckBox.TabIndex = 15
        Me.SerrageCheckBox.UseVisualStyleBackColor = True
        '
        'CoupleTextBox
        '
        Me.CoupleTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Lst_departs_onBindingSource, "couple", True))
        Me.CoupleTextBox.Location = New System.Drawing.Point(126, 157)
        Me.CoupleTextBox.Name = "CoupleTextBox"
        Me.CoupleTextBox.Size = New System.Drawing.Size(100, 20)
        Me.CoupleTextBox.TabIndex = 13
        '
        'ComboBox3
        '
        Me.ComboBox3.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.EquipementsBindingSource, "lots_idlots", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.ComboBox3.DataSource = Me.LotTenantBindingSource
        Me.ComboBox3.DisplayMember = "lot"
        Me.ComboBox3.FormattingEnabled = True
        Me.ComboBox3.Location = New System.Drawing.Point(126, 44)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox3.TabIndex = 5
        Me.ComboBox3.ValueMember = "idlots"
        '
        'LotTenantBindingSource
        '
        Me.LotTenantBindingSource.DataMember = "lots"
        Me.LotTenantBindingSource.DataSource = Me.MydbDataSet
        '
        'DesignationTextBox3
        '
        Me.DesignationTextBox3.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EquipementsBindingSource, "designation", True))
        Me.DesignationTextBox3.Location = New System.Drawing.Point(126, 73)
        Me.DesignationTextBox3.Multiline = True
        Me.DesignationTextBox3.Name = "DesignationTextBox3"
        Me.DesignationTextBox3.Size = New System.Drawing.Size(235, 44)
        Me.DesignationTextBox3.TabIndex = 9
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ButtonX6)
        Me.GroupBox2.Controls.Add(Me.Borniers_idbornierComboBox)
        Me.GroupBox2.Controls.Add(Label2)
        Me.GroupBox2.Controls.Add(Me.ComboBox6)
        Me.GroupBox2.Controls.Add(Label3)
        Me.GroupBox2.Controls.Add(Me.ComboBox7)
        Me.GroupBox2.Controls.Add(Label6)
        Me.GroupBox2.Controls.Add(Me.CoupleCheckBox)
        Me.GroupBox2.Controls.Add(CoupleLabel1)
        Me.GroupBox2.Controls.Add(Borniers_idbornierLabel)
        Me.GroupBox2.Controls.Add(Me.TextBox3)
        Me.GroupBox2.Controls.Add(Me.SerrageTextBox)
        Me.GroupBox2.Controls.Add(SerrageLabel1)
        Me.GroupBox2.Location = New System.Drawing.Point(965, 32)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(421, 218)
        Me.GroupBox2.TabIndex = 28
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Aboutissant"
        '
        'ButtonX6
        '
        Me.ButtonX6.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX6.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX6.Image = Global.progelec.My.Resources.Resources.info_24_24
        Me.ButtonX6.Location = New System.Drawing.Point(297, 14)
        Me.ButtonX6.Name = "ButtonX6"
        Me.ButtonX6.Size = New System.Drawing.Size(33, 29)
        Me.ButtonX6.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014
        Me.ButtonX6.TabIndex = 17
        '
        'Borniers_idbornierComboBox
        '
        Me.Borniers_idbornierComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.CablesBindingSource, "borniers_idbornier", True))
        Me.Borniers_idbornierComboBox.DataSource = Me.Lst_Borniers_onBindingSource
        Me.Borniers_idbornierComboBox.DisplayMember = "reference bornier"
        Me.Borniers_idbornierComboBox.FormattingEnabled = True
        Me.Borniers_idbornierComboBox.Location = New System.Drawing.Point(170, 122)
        Me.Borniers_idbornierComboBox.Name = "Borniers_idbornierComboBox"
        Me.Borniers_idbornierComboBox.Size = New System.Drawing.Size(235, 21)
        Me.Borniers_idbornierComboBox.TabIndex = 16
        Me.Borniers_idbornierComboBox.ValueMember = "idbornier"
        '
        'Lst_Borniers_onBindingSource
        '
        Me.Lst_Borniers_onBindingSource.DataMember = "Lst_Borniers_on"
        Me.Lst_Borniers_onBindingSource.DataSource = Me.MydbDataSet
        '
        'ComboBox6
        '
        Me.ComboBox6.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.EquipementAboutissantBindingSource, "lots_idlots", True))
        Me.ComboBox6.DataSource = Me.LotAboutissantBindingSource
        Me.ComboBox6.DisplayMember = "lot"
        Me.ComboBox6.FormattingEnabled = True
        Me.ComboBox6.Location = New System.Drawing.Point(170, 43)
        Me.ComboBox6.Name = "ComboBox6"
        Me.ComboBox6.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox6.TabIndex = 5
        Me.ComboBox6.ValueMember = "idlots"
        '
        'LotAboutissantBindingSource
        '
        Me.LotAboutissantBindingSource.DataMember = "lots"
        Me.LotAboutissantBindingSource.DataSource = Me.MydbDataSet
        '
        'CoupleCheckBox
        '
        Me.CoupleCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.Lst_Borniers_onBindingSource, "Couple", True))
        Me.CoupleCheckBox.Location = New System.Drawing.Point(170, 171)
        Me.CoupleCheckBox.Name = "CoupleCheckBox"
        Me.CoupleCheckBox.Size = New System.Drawing.Size(36, 24)
        Me.CoupleCheckBox.TabIndex = 15
        Me.CoupleCheckBox.UseVisualStyleBackColor = True
        '
        'TextBox3
        '
        Me.TextBox3.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EquipementAboutissantBindingSource, "designation", True))
        Me.TextBox3.Location = New System.Drawing.Point(170, 70)
        Me.TextBox3.Multiline = True
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(235, 44)
        Me.TextBox3.TabIndex = 9
        '
        'SerrageTextBox
        '
        Me.SerrageTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Lst_Borniers_onBindingSource, "serrage", True))
        Me.SerrageTextBox.Location = New System.Drawing.Point(170, 150)
        Me.SerrageTextBox.Name = "SerrageTextBox"
        Me.SerrageTextBox.Size = New System.Drawing.Size(104, 20)
        Me.SerrageTextBox.TabIndex = 13
        '
        'IdcableTextBox
        '
        Me.IdcableTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.IdcableTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CablesBindingSource, "idcable", True))
        Me.IdcableTextBox.Location = New System.Drawing.Point(809, 7)
        Me.IdcableTextBox.Name = "IdcableTextBox"
        Me.IdcableTextBox.Size = New System.Drawing.Size(100, 20)
        Me.IdcableTextBox.TabIndex = 3
        Me.IdcableTextBox.Visible = False
        '
        'VoieTextBox
        '
        Me.VoieTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CablesBindingSource, "Voie", True))
        Me.VoieTextBox.Location = New System.Drawing.Point(622, 110)
        Me.VoieTextBox.Name = "VoieTextBox"
        Me.VoieTextBox.Size = New System.Drawing.Size(100, 20)
        Me.VoieTextBox.TabIndex = 11
        '
        'TensionTextBox
        '
        Me.TensionTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CablesBindingSource, "Tension", True))
        Me.TensionTextBox.Location = New System.Drawing.Point(728, 110)
        Me.TensionTextBox.Name = "TensionTextBox"
        Me.TensionTextBox.Size = New System.Drawing.Size(100, 20)
        Me.TensionTextBox.TabIndex = 14
        '
        'DesignationTextBox
        '
        Me.DesignationTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Types_cableBindingSource, "designation", True))
        Me.DesignationTextBox.Location = New System.Drawing.Point(492, 250)
        Me.DesignationTextBox.Name = "DesignationTextBox"
        Me.DesignationTextBox.Size = New System.Drawing.Size(442, 20)
        Me.DesignationTextBox.TabIndex = 27
        '
        'BlindageCheckBox
        '
        Me.BlindageCheckBox.CheckAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BlindageCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.Types_cableBindingSource, "blindage", True))
        Me.BlindageCheckBox.Location = New System.Drawing.Point(548, 93)
        Me.BlindageCheckBox.Name = "BlindageCheckBox"
        Me.BlindageCheckBox.Size = New System.Drawing.Size(64, 37)
        Me.BlindageCheckBox.TabIndex = 30
        Me.BlindageCheckBox.Text = "Blindage"
        Me.BlindageCheckBox.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BlindageCheckBox.UseVisualStyleBackColor = True
        '
        'DesignationTextBox1
        '
        Me.DesignationTextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.LotsBindingSource, "designation", True))
        Me.DesignationTextBox1.Location = New System.Drawing.Point(475, 193)
        Me.DesignationTextBox1.Name = "DesignationTextBox1"
        Me.DesignationTextBox1.Size = New System.Drawing.Size(121, 20)
        Me.DesignationTextBox1.TabIndex = 21
        '
        'EntrepriseTextBox
        '
        Me.EntrepriseTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.LotsBindingSource, "Entreprise", True))
        Me.EntrepriseTextBox.Location = New System.Drawing.Point(475, 219)
        Me.EntrepriseTextBox.Name = "EntrepriseTextBox"
        Me.EntrepriseTextBox.Size = New System.Drawing.Size(121, 20)
        Me.EntrepriseTextBox.TabIndex = 23
        '
        'DesignationTextBox2
        '
        Me.DesignationTextBox2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.SegregationsBindingSource, "designation", True))
        Me.DesignationTextBox2.Location = New System.Drawing.Point(775, 72)
        Me.DesignationTextBox2.Name = "DesignationTextBox2"
        Me.DesignationTextBox2.Size = New System.Drawing.Size(169, 20)
        Me.DesignationTextBox2.TabIndex = 9
        '
        'ButtonXEnregistrer
        '
        Me.ButtonXEnregistrer.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonXEnregistrer.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonXEnregistrer.Location = New System.Drawing.Point(1392, 66)
        Me.ButtonXEnregistrer.Name = "ButtonXEnregistrer"
        Me.ButtonXEnregistrer.Size = New System.Drawing.Size(103, 24)
        Me.ButtonXEnregistrer.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014
        Me.ButtonXEnregistrer.Symbol = ""
        Me.ButtonXEnregistrer.TabIndex = 33
        Me.ButtonXEnregistrer.Text = "Enregistrer"
        '
        'ButtonXNouveau
        '
        Me.ButtonXNouveau.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonXNouveau.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonXNouveau.Location = New System.Drawing.Point(1392, 32)
        Me.ButtonXNouveau.Name = "ButtonXNouveau"
        Me.ButtonXNouveau.Size = New System.Drawing.Size(103, 23)
        Me.ButtonXNouveau.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014
        Me.ButtonXNouveau.TabIndex = 32
        Me.ButtonXNouveau.Text = "Nouveau"
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AllowUserToDeleteRows = False
        Me.DataGridView2.AllowUserToOrderColumns = True
        Me.DataGridView2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.DataGridView2.AutoGenerateColumns = False
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn18, Me.DataGridViewTextBoxColumn19, Me.DataGridViewTextBoxColumn20, Me.DataGridViewTextBoxColumn21, Me.DataGridViewTextBoxColumn22, Me.longueur})
        Me.DataGridView2.DataSource = Me.Parcour_detail_idBindingSource
        Me.DataGridView2.Location = New System.Drawing.Point(17, 56)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.ReadOnly = True
        Me.DataGridView2.Size = New System.Drawing.Size(775, 317)
        Me.DataGridView2.TabIndex = 4
        '
        'DataGridViewTextBoxColumn18
        '
        Me.DataGridViewTextBoxColumn18.DataPropertyName = "repere salle"
        Me.DataGridViewTextBoxColumn18.HeaderText = "repere salle"
        Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
        Me.DataGridViewTextBoxColumn18.ReadOnly = True
        '
        'DataGridViewTextBoxColumn19
        '
        Me.DataGridViewTextBoxColumn19.DataPropertyName = "Niveau"
        Me.DataGridViewTextBoxColumn19.HeaderText = "Niveau"
        Me.DataGridViewTextBoxColumn19.Name = "DataGridViewTextBoxColumn19"
        Me.DataGridViewTextBoxColumn19.ReadOnly = True
        '
        'DataGridViewTextBoxColumn20
        '
        Me.DataGridViewTextBoxColumn20.DataPropertyName = "repere troncon"
        Me.DataGridViewTextBoxColumn20.HeaderText = "repere troncon"
        Me.DataGridViewTextBoxColumn20.Name = "DataGridViewTextBoxColumn20"
        Me.DataGridViewTextBoxColumn20.ReadOnly = True
        '
        'DataGridViewTextBoxColumn21
        '
        Me.DataGridViewTextBoxColumn21.DataPropertyName = "Type"
        Me.DataGridViewTextBoxColumn21.HeaderText = "Type"
        Me.DataGridViewTextBoxColumn21.Name = "DataGridViewTextBoxColumn21"
        Me.DataGridViewTextBoxColumn21.ReadOnly = True
        '
        'DataGridViewTextBoxColumn22
        '
        Me.DataGridViewTextBoxColumn22.DataPropertyName = "segregation"
        Me.DataGridViewTextBoxColumn22.HeaderText = "segregation"
        Me.DataGridViewTextBoxColumn22.Name = "DataGridViewTextBoxColumn22"
        Me.DataGridViewTextBoxColumn22.ReadOnly = True
        '
        'longueur
        '
        Me.longueur.DataPropertyName = "longueur"
        Me.longueur.HeaderText = "longueur"
        Me.longueur.Name = "longueur"
        Me.longueur.ReadOnly = True
        '
        'Parcour_detail_idBindingSource
        '
        Me.Parcour_detail_idBindingSource.DataMember = "parcour_detail_id"
        Me.Parcour_detail_idBindingSource.DataSource = Me.MydbDataSet
        '
        'TextBox8
        '
        Me.TextBox8.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ParcoursBindingSource, "longueur", True))
        Me.TextBox8.Location = New System.Drawing.Point(162, 20)
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Size = New System.Drawing.Size(100, 20)
        Me.TextBox8.TabIndex = 3
        '
        'ParcoursBindingSource
        '
        Me.ParcoursBindingSource.DataMember = "parcours"
        Me.ParcoursBindingSource.DataSource = Me.MydbDataSet
        '
        'TextBox9
        '
        Me.TextBox9.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Lst_departs_onBindingSource, "troncons_idtroncons", True))
        Me.TextBox9.Location = New System.Drawing.Point(1368, 209)
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Size = New System.Drawing.Size(100, 20)
        Me.TextBox9.TabIndex = 5
        Me.TextBox9.Visible = False
        '
        'ButtonX3
        '
        Me.ButtonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX3.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX3.Location = New System.Drawing.Point(17, 15)
        Me.ButtonX3.Name = "ButtonX3"
        Me.ButtonX3.Size = New System.Drawing.Size(75, 23)
        Me.ButtonX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014
        Me.ButtonX3.TabIndex = 0
        Me.ButtonX3.Text = "Generer"
        '
        'TextBox10
        '
        Me.TextBox10.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Lst_Borniers_onBindingSource, "troncons_idtroncons", True))
        Me.TextBox10.Location = New System.Drawing.Point(1368, 248)
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.Size = New System.Drawing.Size(100, 20)
        Me.TextBox10.TabIndex = 6
        Me.TextBox10.Visible = False
        '
        'TextBox11
        '
        Me.TextBox11.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CablesBindingSource, "parcours_idparcours", True))
        Me.TextBox11.Location = New System.Drawing.Point(1368, 168)
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.Size = New System.Drawing.Size(100, 20)
        Me.TextBox11.TabIndex = 2
        Me.TextBox11.Visible = False
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.Cables_detailsBindingSource, "trefle", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.CheckBox2.Location = New System.Drawing.Point(922, 192)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(97, 17)
        Me.CheckBox2.TabIndex = 6
        Me.CheckBox2.Text = "Posé en trèfle :"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'DataGridView4
        '
        Me.DataGridView4.AutoGenerateColumns = False
        Me.DataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView4.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn28, Me.DataGridViewTextBoxColumn29, Me.DataGridViewTextBoxColumn30, Me.DataGridViewTextBoxColumn31, Me.trefle, Me.DataGridViewTextBoxColumn32, Me.DataGridViewTextBoxColumn33, Me.DataGridViewTextBoxColumn34})
        Me.DataGridView4.DataSource = Me.Cable_details_sectionBindingSource
        Me.DataGridView4.Dock = System.Windows.Forms.DockStyle.Left
        Me.DataGridView4.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView4.Name = "DataGridView4"
        Me.DataGridView4.Size = New System.Drawing.Size(744, 444)
        Me.DataGridView4.TabIndex = 7
        '
        'DataGridViewTextBoxColumn28
        '
        Me.DataGridViewTextBoxColumn28.DataPropertyName = "repere cable"
        Me.DataGridViewTextBoxColumn28.HeaderText = "repere cable"
        Me.DataGridViewTextBoxColumn28.Name = "DataGridViewTextBoxColumn28"
        '
        'DataGridViewTextBoxColumn29
        '
        Me.DataGridViewTextBoxColumn29.DataPropertyName = "Fils"
        Me.DataGridViewTextBoxColumn29.HeaderText = "Fils"
        Me.DataGridViewTextBoxColumn29.Name = "DataGridViewTextBoxColumn29"
        '
        'DataGridViewTextBoxColumn30
        '
        Me.DataGridViewTextBoxColumn30.DataPropertyName = "section"
        Me.DataGridViewTextBoxColumn30.HeaderText = "section"
        Me.DataGridViewTextBoxColumn30.Name = "DataGridViewTextBoxColumn30"
        '
        'DataGridViewTextBoxColumn31
        '
        Me.DataGridViewTextBoxColumn31.DataPropertyName = "types"
        Me.DataGridViewTextBoxColumn31.HeaderText = "types"
        Me.DataGridViewTextBoxColumn31.Name = "DataGridViewTextBoxColumn31"
        '
        'trefle
        '
        Me.trefle.DataPropertyName = "trefle"
        Me.trefle.HeaderText = "trefle"
        Me.trefle.Name = "trefle"
        '
        'DataGridViewTextBoxColumn32
        '
        Me.DataGridViewTextBoxColumn32.DataPropertyName = "diametre"
        Me.DataGridViewTextBoxColumn32.HeaderText = "diametre"
        Me.DataGridViewTextBoxColumn32.Name = "DataGridViewTextBoxColumn32"
        '
        'DataGridViewTextBoxColumn33
        '
        Me.DataGridViewTextBoxColumn33.DataPropertyName = "charge_calorifique"
        Me.DataGridViewTextBoxColumn33.HeaderText = "charge_calorifique"
        Me.DataGridViewTextBoxColumn33.Name = "DataGridViewTextBoxColumn33"
        '
        'DataGridViewTextBoxColumn34
        '
        Me.DataGridViewTextBoxColumn34.DataPropertyName = "masse"
        Me.DataGridViewTextBoxColumn34.HeaderText = "masse"
        Me.DataGridViewTextBoxColumn34.Name = "DataGridViewTextBoxColumn34"
        '
        'Cable_details_sectionBindingSource
        '
        Me.Cable_details_sectionBindingSource.DataMember = "cable_details_section"
        Me.Cable_details_sectionBindingSource.DataSource = Me.MydbDataSet
        '
        'ComboBox9
        '
        Me.ComboBox9.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.Cables_detailsBindingSource, "sections_cables_idsections_cables", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.ComboBox9.DataSource = Me.Sections_cablesBindingSource
        Me.ComboBox9.DisplayMember = "section"
        Me.ComboBox9.FormattingEnabled = True
        Me.ComboBox9.Location = New System.Drawing.Point(957, 152)
        Me.ComboBox9.Name = "ComboBox9"
        Me.ComboBox9.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox9.TabIndex = 5
        Me.ComboBox9.ValueMember = "idsections_cables"
        '
        'Sections_cablesBindingSource
        '
        Me.Sections_cablesBindingSource.DataMember = "sections_cables"
        Me.Sections_cablesBindingSource.DataSource = Me.MydbDataSet
        '
        'Button1
        '
        Me.Button1.Image = Global.progelec.My.Resources.Resources.add_24_24
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.Location = New System.Drawing.Point(815, 11)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(100, 51)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Nouveau"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TextBox16
        '
        Me.TextBox16.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox16.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Cables_detailsBindingSource, "idcables_details", True))
        Me.TextBox16.Location = New System.Drawing.Point(832, 241)
        Me.TextBox16.Name = "TextBox16"
        Me.TextBox16.Size = New System.Drawing.Size(100, 20)
        Me.TextBox16.TabIndex = 9
        Me.TextBox16.Visible = False
        '
        'TextBox17
        '
        Me.TextBox17.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Cables_detailsBindingSource, "Fils", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.TextBox17.Location = New System.Drawing.Point(851, 153)
        Me.TextBox17.Name = "TextBox17"
        Me.TextBox17.Size = New System.Drawing.Size(100, 20)
        Me.TextBox17.TabIndex = 4
        '
        'TextBox18
        '
        Me.TextBox18.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox18.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Cables_detailsBindingSource, "cables_idcable", True))
        Me.TextBox18.Location = New System.Drawing.Point(832, 280)
        Me.TextBox18.Name = "TextBox18"
        Me.TextBox18.Size = New System.Drawing.Size(100, 20)
        Me.TextBox18.TabIndex = 11
        Me.TextBox18.Visible = False
        '
        'SuperTabControl1
        '
        Me.SuperTabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel2)
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel1)
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel3)
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel4)
        Me.SuperTabControl1.ForeColor = System.Drawing.Color.Black
        Me.SuperTabControl1.Location = New System.Drawing.Point(17, 276)
        Me.SuperTabControl1.Name = "SuperTabControl1"
        Me.SuperTabControl1.ReorderTabsEnabled = True
        Me.SuperTabControl1.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.SuperTabControl1.SelectedTabIndex = 1
        Me.SuperTabControl1.Size = New System.Drawing.Size(1494, 469)
        Me.SuperTabControl1.TabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SuperTabControl1.TabIndex = 34
        Me.SuperTabControl1.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabItem1, Me.SuperTabItem2, Me.SuperTabItem4, Me.SuperTabItem5})
        Me.SuperTabControl1.Text = "SuperTabControl1"
        '
        'SuperTabControlPanel2
        '
        Me.SuperTabControlPanel2.AutoScroll = True
        Me.SuperTabControlPanel2.Controls.Add(Me.GroupPanel1)
        Me.SuperTabControlPanel2.Controls.Add(Me.ButtonX1)
        Me.SuperTabControlPanel2.Controls.Add(Me.VerouillageParcoursCheckBox)
        Me.SuperTabControlPanel2.Controls.Add(Me.Panel1)
        Me.SuperTabControlPanel2.Controls.Add(LMAXLabel)
        Me.SuperTabControlPanel2.Controls.Add(Me.DataGridView2)
        Me.SuperTabControlPanel2.Controls.Add(Me.LMAXTextBox)
        Me.SuperTabControlPanel2.Controls.Add(Longueur_Note_CalculeLabel)
        Me.SuperTabControlPanel2.Controls.Add(Label9)
        Me.SuperTabControlPanel2.Controls.Add(Me.Longueur_Note_CalculeTextBox)
        Me.SuperTabControlPanel2.Controls.Add(Me.TextBox11)
        Me.SuperTabControlPanel2.Controls.Add(Me.TextBox8)
        Me.SuperTabControlPanel2.Controls.Add(Me.TextBox9)
        Me.SuperTabControlPanel2.Controls.Add(Me.TextBox10)
        Me.SuperTabControlPanel2.Controls.Add(Me.ButtonX3)
        Me.SuperTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel2.Location = New System.Drawing.Point(0, 25)
        Me.SuperTabControlPanel2.Name = "SuperTabControlPanel2"
        Me.SuperTabControlPanel2.Size = New System.Drawing.Size(1494, 444)
        Me.SuperTabControlPanel2.TabIndex = 0
        Me.SuperTabControlPanel2.TabItem = Me.SuperTabItem2
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.ProgressBarX1)
        Me.GroupPanel1.Controls.Add(Me.ButtonX8)
        Me.GroupPanel1.Controls.Add(Me.ProgressSteps1)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(924, 15)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(629, 87)
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
        Me.GroupPanel1.TabIndex = 15
        Me.GroupPanel1.Text = "Analyse Parcours"
        '
        'ProgressBarX1
        '
        '
        '
        '
        Me.ProgressBarX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ProgressBarX1.Location = New System.Drawing.Point(104, 31)
        Me.ProgressBarX1.Name = "ProgressBarX1"
        Me.ProgressBarX1.ProgressType = DevComponents.DotNetBar.eProgressItemType.Marquee
        Me.ProgressBarX1.Size = New System.Drawing.Size(456, 32)
        Me.ProgressBarX1.TabIndex = 2
        Me.ProgressBarX1.Text = "ProgressBarX1"
        Me.ProgressBarX1.Visible = False
        '
        'ButtonX8
        '
        Me.ButtonX8.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX8.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX8.Image = Global.progelec.My.Resources.Resources.search_1_24_24
        Me.ButtonX8.Location = New System.Drawing.Point(9, 3)
        Me.ButtonX8.Name = "ButtonX8"
        Me.ButtonX8.Size = New System.Drawing.Size(87, 32)
        Me.ButtonX8.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014
        Me.ButtonX8.TabIndex = 1
        Me.ButtonX8.Text = "Lancer"
        '
        'ProgressSteps1
        '
        '
        '
        '
        Me.ProgressSteps1.BackgroundStyle.Class = "ProgressSteps"
        Me.ProgressSteps1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ProgressSteps1.ContainerControlProcessDialogKey = True
        Me.ProgressSteps1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.StepItem1, Me.StepItem6, Me.StepItem5, Me.StepItem2, Me.StepItem3, Me.StepItem4})
        Me.ProgressSteps1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.ProgressSteps1.Location = New System.Drawing.Point(104, 13)
        Me.ProgressSteps1.Name = "ProgressSteps1"
        Me.ProgressSteps1.Size = New System.Drawing.Size(456, 22)
        Me.ProgressSteps1.TabIndex = 0
        '
        'StepItem1
        '
        Me.StepItem1.BackColors = New System.Drawing.Color() {System.Drawing.Color.Red}
        Me.StepItem1.Name = "StepItem1"
        Me.StepItem1.ProgressColors = New System.Drawing.Color() {System.Drawing.Color.Lime}
        Me.StepItem1.SymbolSize = 13.0!
        Me.StepItem1.Text = "Tenant"
        '
        'StepItem6
        '
        Me.StepItem6.BackColors = New System.Drawing.Color() {System.Drawing.Color.Red}
        Me.StepItem6.Name = "StepItem6"
        Me.StepItem6.ProgressColors = New System.Drawing.Color() {System.Drawing.Color.Lime}
        Me.StepItem6.SymbolSize = 13.0!
        Me.StepItem6.Text = "Tenant-assoc"
        '
        'StepItem5
        '
        Me.StepItem5.BackColors = New System.Drawing.Color() {System.Drawing.Color.Red}
        Me.StepItem5.Name = "StepItem5"
        Me.StepItem5.ProgressColors = New System.Drawing.Color() {System.Drawing.Color.Lime}
        Me.StepItem5.SymbolSize = 13.0!
        Me.StepItem5.Text = "Liaison tenant - about"
        '
        'StepItem2
        '
        Me.StepItem2.BackColors = New System.Drawing.Color() {System.Drawing.Color.Red}
        Me.StepItem2.Name = "StepItem2"
        Me.StepItem2.ProgressColors = New System.Drawing.Color() {System.Drawing.Color.Lime}
        Me.StepItem2.SymbolSize = 13.0!
        Me.StepItem2.Text = "Mode de pose"
        '
        'StepItem3
        '
        Me.StepItem3.BackColors = New System.Drawing.Color() {System.Drawing.Color.Red}
        Me.StepItem3.Name = "StepItem3"
        Me.StepItem3.ProgressColors = New System.Drawing.Color() {System.Drawing.Color.Lime}
        Me.StepItem3.SymbolSize = 13.0!
        Me.StepItem3.Text = "Segregation"
        '
        'StepItem4
        '
        Me.StepItem4.BackColors = New System.Drawing.Color() {System.Drawing.Color.Red}
        Me.StepItem4.Name = "StepItem4"
        Me.StepItem4.ProgressColors = New System.Drawing.Color() {System.Drawing.Color.Lime}
        Me.StepItem4.SymbolSize = 13.0!
        Me.StepItem4.Text = "Aboutissant "
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX1.Location = New System.Drawing.Point(689, 15)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Size = New System.Drawing.Size(103, 28)
        Me.ButtonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014
        Me.ButtonX1.Symbol = ""
        Me.ButtonX1.TabIndex = 8
        Me.ButtonX1.Text = "Deparcourir"
        '
        'VerouillageParcoursCheckBox
        '
        Me.VerouillageParcoursCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.CablesBindingSource, "VerouillageParcours", True))
        Me.VerouillageParcoursCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VerouillageParcoursCheckBox.ForeColor = System.Drawing.Color.Red
        Me.VerouillageParcoursCheckBox.Location = New System.Drawing.Point(800, 49)
        Me.VerouillageParcoursCheckBox.Name = "VerouillageParcoursCheckBox"
        Me.VerouillageParcoursCheckBox.Size = New System.Drawing.Size(127, 53)
        Me.VerouillageParcoursCheckBox.TabIndex = 14
        Me.VerouillageParcoursCheckBox.Text = "Verrouillage Parcours"
        Me.VerouillageParcoursCheckBox.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ComboBoxEx6)
        Me.Panel1.Controls.Add(Me.ComboBoxEx5)
        Me.Panel1.Controls.Add(Me.ComboBoxEx8)
        Me.Panel1.Controls.Add(Me.ComboBoxEx7)
        Me.Panel1.Controls.Add(Me.ComboBoxEx4)
        Me.Panel1.Controls.Add(Me.ComboBoxEx3)
        Me.Panel1.Controls.Add(Cont8ModeLabel)
        Me.Panel1.Controls.Add(Me.Cont8ModeTextBox)
        Me.Panel1.Controls.Add(Me.ComboBoxEx2)
        Me.Panel1.Controls.Add(Me.ComboBoxEx1)
        Me.Panel1.Controls.Add(Cont8ValLabel)
        Me.Panel1.Controls.Add(Cont7ModeLabel)
        Me.Panel1.Controls.Add(Me.Cont7ModeTextBox)
        Me.Panel1.Controls.Add(Cont7ValLabel)
        Me.Panel1.Controls.Add(Cont6ModeLabel)
        Me.Panel1.Controls.Add(Me.Cont6ModeTextBox)
        Me.Panel1.Controls.Add(Cont5ModeLabel)
        Me.Panel1.Controls.Add(Cont2ValLabel)
        Me.Panel1.Controls.Add(Me.Cont5ModeTextBox)
        Me.Panel1.Controls.Add(Cont6ValLabel)
        Me.Panel1.Controls.Add(Cont4ModeLabel)
        Me.Panel1.Controls.Add(Cont3ValLabel)
        Me.Panel1.Controls.Add(Me.Cont4ModeTextBox)
        Me.Panel1.Controls.Add(Cont4ValLabel)
        Me.Panel1.Controls.Add(Cont3ModeLabel)
        Me.Panel1.Controls.Add(Cont5ValLabel)
        Me.Panel1.Controls.Add(Me.Cont3ModeTextBox)
        Me.Panel1.Controls.Add(Cont2ModeLabel)
        Me.Panel1.Controls.Add(Me.Cont2ModeTextBox)
        Me.Panel1.Controls.Add(Cont1ModeLabel)
        Me.Panel1.Controls.Add(Cont1ValLabel)
        Me.Panel1.Controls.Add(Me.Cont1ValTextBox)
        Me.Panel1.Controls.Add(Me.ContrainteCheckBox)
        Me.Panel1.Location = New System.Drawing.Point(800, 109)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(437, 265)
        Me.Panel1.TabIndex = 7
        '
        'ComboBoxEx6
        '
        Me.ComboBoxEx6.DisplayMember = "Text"
        Me.ComboBoxEx6.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBoxEx6.FormattingEnabled = True
        Me.ComboBoxEx6.ItemHeight = 14
        Me.ComboBoxEx6.Location = New System.Drawing.Point(290, 215)
        Me.ComboBoxEx6.Name = "ComboBoxEx6"
        Me.ComboBoxEx6.Size = New System.Drawing.Size(104, 20)
        Me.ComboBoxEx6.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014
        Me.ComboBoxEx6.TabIndex = 15
        '
        'ComboBoxEx5
        '
        Me.ComboBoxEx5.DisplayMember = "TEXT"
        Me.ComboBoxEx5.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBoxEx5.FormattingEnabled = True
        Me.ComboBoxEx5.ItemHeight = 14
        Me.ComboBoxEx5.Location = New System.Drawing.Point(290, 189)
        Me.ComboBoxEx5.Name = "ComboBoxEx5"
        Me.ComboBoxEx5.Size = New System.Drawing.Size(104, 20)
        Me.ComboBoxEx5.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014
        Me.ComboBoxEx5.TabIndex = 15
        '
        'ComboBoxEx8
        '
        Me.ComboBoxEx8.DisplayMember = "Text"
        Me.ComboBoxEx8.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBoxEx8.Enabled = False
        Me.ComboBoxEx8.FormattingEnabled = True
        Me.ComboBoxEx8.ItemHeight = 14
        Me.ComboBoxEx8.Location = New System.Drawing.Point(290, 59)
        Me.ComboBoxEx8.Name = "ComboBoxEx8"
        Me.ComboBoxEx8.Size = New System.Drawing.Size(104, 20)
        Me.ComboBoxEx8.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014
        Me.ComboBoxEx8.TabIndex = 15
        '
        'ComboBoxEx7
        '
        Me.ComboBoxEx7.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBoxEx7.Enabled = False
        Me.ComboBoxEx7.FormattingEnabled = True
        Me.ComboBoxEx7.ItemHeight = 14
        Me.ComboBoxEx7.Location = New System.Drawing.Point(290, 33)
        Me.ComboBoxEx7.Name = "ComboBoxEx7"
        Me.ComboBoxEx7.Size = New System.Drawing.Size(104, 20)
        Me.ComboBoxEx7.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014
        Me.ComboBoxEx7.TabIndex = 15
        '
        'ComboBoxEx4
        '
        Me.ComboBoxEx4.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.CablesBindingSource, "Cont6Val", True))
        Me.ComboBoxEx4.DisplayMember = "Text"
        Me.ComboBoxEx4.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBoxEx4.FormattingEnabled = True
        Me.ComboBoxEx4.ItemHeight = 14
        Me.ComboBoxEx4.Location = New System.Drawing.Point(290, 163)
        Me.ComboBoxEx4.Name = "ComboBoxEx4"
        Me.ComboBoxEx4.Size = New System.Drawing.Size(104, 20)
        Me.ComboBoxEx4.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014
        Me.ComboBoxEx4.TabIndex = 15
        '
        'ComboBoxEx3
        '
        Me.ComboBoxEx3.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.CablesBindingSource, "Cont5Val", True))
        Me.ComboBoxEx3.DisplayMember = "TEXT"
        Me.ComboBoxEx3.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBoxEx3.FormattingEnabled = True
        Me.ComboBoxEx3.ItemHeight = 14
        Me.ComboBoxEx3.Location = New System.Drawing.Point(290, 137)
        Me.ComboBoxEx3.Name = "ComboBoxEx3"
        Me.ComboBoxEx3.Size = New System.Drawing.Size(104, 20)
        Me.ComboBoxEx3.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014
        Me.ComboBoxEx3.TabIndex = 15
        '
        'Cont8ModeTextBox
        '
        Me.Cont8ModeTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CablesBindingSource, "Cont8Mode", True))
        Me.Cont8ModeTextBox.Location = New System.Drawing.Point(86, 215)
        Me.Cont8ModeTextBox.Name = "Cont8ModeTextBox"
        Me.Cont8ModeTextBox.Size = New System.Drawing.Size(115, 20)
        Me.Cont8ModeTextBox.TabIndex = 32
        '
        'ComboBoxEx2
        '
        Me.ComboBoxEx2.DisplayMember = "Text"
        Me.ComboBoxEx2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBoxEx2.FormattingEnabled = True
        Me.ComboBoxEx2.ItemHeight = 14
        Me.ComboBoxEx2.Location = New System.Drawing.Point(290, 111)
        Me.ComboBoxEx2.Name = "ComboBoxEx2"
        Me.ComboBoxEx2.Size = New System.Drawing.Size(104, 20)
        Me.ComboBoxEx2.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014
        Me.ComboBoxEx2.TabIndex = 15
        '
        'ComboBoxEx1
        '
        Me.ComboBoxEx1.DisplayMember = "TEXT"
        Me.ComboBoxEx1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBoxEx1.FormattingEnabled = True
        Me.ComboBoxEx1.ItemHeight = 14
        Me.ComboBoxEx1.Location = New System.Drawing.Point(290, 85)
        Me.ComboBoxEx1.Name = "ComboBoxEx1"
        Me.ComboBoxEx1.Size = New System.Drawing.Size(104, 20)
        Me.ComboBoxEx1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014
        Me.ComboBoxEx1.TabIndex = 15
        '
        'Cont7ModeTextBox
        '
        Me.Cont7ModeTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CablesBindingSource, "Cont7Mode", True))
        Me.Cont7ModeTextBox.Location = New System.Drawing.Point(86, 189)
        Me.Cont7ModeTextBox.Name = "Cont7ModeTextBox"
        Me.Cont7ModeTextBox.Size = New System.Drawing.Size(115, 20)
        Me.Cont7ModeTextBox.TabIndex = 28
        '
        'Cont6ModeTextBox
        '
        Me.Cont6ModeTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CablesBindingSource, "Cont6Mode", True))
        Me.Cont6ModeTextBox.Location = New System.Drawing.Point(86, 163)
        Me.Cont6ModeTextBox.Name = "Cont6ModeTextBox"
        Me.Cont6ModeTextBox.Size = New System.Drawing.Size(115, 20)
        Me.Cont6ModeTextBox.TabIndex = 24
        '
        'Cont5ModeTextBox
        '
        Me.Cont5ModeTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CablesBindingSource, "Cont5Mode", True))
        Me.Cont5ModeTextBox.Location = New System.Drawing.Point(86, 137)
        Me.Cont5ModeTextBox.Name = "Cont5ModeTextBox"
        Me.Cont5ModeTextBox.Size = New System.Drawing.Size(115, 20)
        Me.Cont5ModeTextBox.TabIndex = 20
        '
        'Cont4ModeTextBox
        '
        Me.Cont4ModeTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CablesBindingSource, "Cont4Mode", True))
        Me.Cont4ModeTextBox.Location = New System.Drawing.Point(86, 111)
        Me.Cont4ModeTextBox.Name = "Cont4ModeTextBox"
        Me.Cont4ModeTextBox.Size = New System.Drawing.Size(115, 20)
        Me.Cont4ModeTextBox.TabIndex = 16
        '
        'Cont3ModeTextBox
        '
        Me.Cont3ModeTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CablesBindingSource, "Cont3Mode", True))
        Me.Cont3ModeTextBox.Location = New System.Drawing.Point(86, 85)
        Me.Cont3ModeTextBox.Name = "Cont3ModeTextBox"
        Me.Cont3ModeTextBox.Size = New System.Drawing.Size(115, 20)
        Me.Cont3ModeTextBox.TabIndex = 12
        '
        'Cont2ModeTextBox
        '
        Me.Cont2ModeTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CablesBindingSource, "Cont2Mode", True))
        Me.Cont2ModeTextBox.Enabled = False
        Me.Cont2ModeTextBox.Location = New System.Drawing.Point(86, 59)
        Me.Cont2ModeTextBox.Name = "Cont2ModeTextBox"
        Me.Cont2ModeTextBox.Size = New System.Drawing.Size(115, 20)
        Me.Cont2ModeTextBox.TabIndex = 8
        '
        'Cont1ValTextBox
        '
        Me.Cont1ValTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CablesBindingSource, "Cont1Val", True))
        Me.Cont1ValTextBox.Enabled = False
        Me.Cont1ValTextBox.Location = New System.Drawing.Point(86, 33)
        Me.Cont1ValTextBox.Name = "Cont1ValTextBox"
        Me.Cont1ValTextBox.Size = New System.Drawing.Size(115, 20)
        Me.Cont1ValTextBox.TabIndex = 2
        '
        'ContrainteCheckBox
        '
        Me.ContrainteCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.CablesBindingSource, "Contrainte", True))
        Me.ContrainteCheckBox.Location = New System.Drawing.Point(3, 3)
        Me.ContrainteCheckBox.Name = "ContrainteCheckBox"
        Me.ContrainteCheckBox.Size = New System.Drawing.Size(104, 24)
        Me.ContrainteCheckBox.TabIndex = 1
        Me.ContrainteCheckBox.Text = "Contrainte"
        Me.ContrainteCheckBox.UseVisualStyleBackColor = True
        '
        'LMAXTextBox
        '
        Me.LMAXTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CablesBindingSource, "LMAX", True))
        Me.LMAXTextBox.Location = New System.Drawing.Point(569, 20)
        Me.LMAXTextBox.Name = "LMAXTextBox"
        Me.LMAXTextBox.Size = New System.Drawing.Size(100, 20)
        Me.LMAXTextBox.TabIndex = 3
        '
        'Longueur_Note_CalculeTextBox
        '
        Me.Longueur_Note_CalculeTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CablesBindingSource, "Longueur_Note_Calcule", True))
        Me.Longueur_Note_CalculeTextBox.Location = New System.Drawing.Point(404, 20)
        Me.Longueur_Note_CalculeTextBox.Name = "Longueur_Note_CalculeTextBox"
        Me.Longueur_Note_CalculeTextBox.Size = New System.Drawing.Size(100, 20)
        Me.Longueur_Note_CalculeTextBox.TabIndex = 1
        '
        'SuperTabItem2
        '
        Me.SuperTabItem2.AttachedControl = Me.SuperTabControlPanel2
        Me.SuperTabItem2.GlobalItem = False
        Me.SuperTabItem2.Name = "SuperTabItem2"
        Me.SuperTabItem2.Text = "Cheminement"
        '
        'SuperTabControlPanel1
        '
        Me.SuperTabControlPanel1.Controls.Add(Me.GroupBox4)
        Me.SuperTabControlPanel1.Controls.Add(Me.ButtonX4)
        Me.SuperTabControlPanel1.Controls.Add(Me.ButtonX2)
        Me.SuperTabControlPanel1.Controls.Add(Me.Button3)
        Me.SuperTabControlPanel1.Controls.Add(Me.Button2)
        Me.SuperTabControlPanel1.Controls.Add(Me.Button4)
        Me.SuperTabControlPanel1.Controls.Add(Me.Button1)
        Me.SuperTabControlPanel1.Controls.Add(Me.CheckBox2)
        Me.SuperTabControlPanel1.Controls.Add(Me.TextBox18)
        Me.SuperTabControlPanel1.Controls.Add(Me.DataGridView4)
        Me.SuperTabControlPanel1.Controls.Add(Label16)
        Me.SuperTabControlPanel1.Controls.Add(Me.ComboBox9)
        Me.SuperTabControlPanel1.Controls.Add(Me.TextBox17)
        Me.SuperTabControlPanel1.Controls.Add(Label13)
        Me.SuperTabControlPanel1.Controls.Add(Label15)
        Me.SuperTabControlPanel1.Controls.Add(Me.TextBox16)
        Me.SuperTabControlPanel1.Controls.Add(Label14)
        Me.SuperTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel1.Location = New System.Drawing.Point(0, 25)
        Me.SuperTabControlPanel1.Name = "SuperTabControlPanel1"
        Me.SuperTabControlPanel1.Size = New System.Drawing.Size(1494, 444)
        Me.SuperTabControlPanel1.TabIndex = 3
        Me.SuperTabControlPanel1.TabItem = Me.SuperTabItem1
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.RadioButton4)
        Me.GroupBox4.Controls.Add(Me.RadioButton5)
        Me.GroupBox4.Controls.Add(Me.RadioButton6)
        Me.GroupBox4.Location = New System.Drawing.Point(1273, 68)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(138, 281)
        Me.GroupBox4.TabIndex = 36
        Me.GroupBox4.TabStop = False
        '
        'RadioButton4
        '
        Me.RadioButton4.AutoSize = True
        Me.RadioButton4.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.CablesBindingSource, "mode_de_pose3", True))
        Me.RadioButton4.Location = New System.Drawing.Point(9, 216)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(86, 17)
        Me.RadioButton4.TabIndex = 2
        Me.RadioButton4.TabStop = True
        Me.RadioButton4.Text = "Multi couche"
        Me.RadioButton4.UseVisualStyleBackColor = True
        '
        'RadioButton5
        '
        Me.RadioButton5.AutoSize = True
        Me.RadioButton5.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.CablesBindingSource, "mode_de_pose2", True))
        Me.RadioButton5.Location = New System.Drawing.Point(9, 124)
        Me.RadioButton5.Name = "RadioButton5"
        Me.RadioButton5.Size = New System.Drawing.Size(52, 17)
        Me.RadioButton5.TabIndex = 1
        Me.RadioButton5.TabStop = True
        Me.RadioButton5.Text = "Trèfle"
        Me.RadioButton5.UseVisualStyleBackColor = True
        Me.RadioButton5.Visible = False
        '
        'RadioButton6
        '
        Me.RadioButton6.AutoSize = True
        Me.RadioButton6.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.CablesBindingSource, "mode_de_pose", True))
        Me.RadioButton6.Location = New System.Drawing.Point(9, 34)
        Me.RadioButton6.Name = "RadioButton6"
        Me.RadioButton6.Size = New System.Drawing.Size(125, 17)
        Me.RadioButton6.TabIndex = 0
        Me.RadioButton6.TabStop = True
        Me.RadioButton6.Text = "Mono couche / trèfle"
        Me.RadioButton6.UseVisualStyleBackColor = True
        '
        'ButtonX4
        '
        Me.ButtonX4.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX4.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX4.Image = Global.progelec.My.Resources.Resources.down_24_24
        Me.ButtonX4.Location = New System.Drawing.Point(750, 249)
        Me.ButtonX4.Name = "ButtonX4"
        Me.ButtonX4.Size = New System.Drawing.Size(43, 39)
        Me.ButtonX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014
        Me.ButtonX4.TabIndex = 12
        '
        'ButtonX2
        '
        Me.ButtonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX2.Image = Global.progelec.My.Resources.Resources.up_1_24_24
        Me.ButtonX2.Location = New System.Drawing.Point(750, 78)
        Me.ButtonX2.Name = "ButtonX2"
        Me.ButtonX2.Size = New System.Drawing.Size(43, 41)
        Me.ButtonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014
        Me.ButtonX2.TabIndex = 12
        '
        'Button3
        '
        Me.Button3.Image = Global.progelec.My.Resources.Resources.save_24_24
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button3.Location = New System.Drawing.Point(1028, 11)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(96, 51)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "Enregistrement"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Image = Global.progelec.My.Resources.Resources.remove_24_24
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button2.Location = New System.Drawing.Point(923, 11)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(94, 51)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Suppression"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Image = Global.progelec.My.Resources.Resources.folder_edit_1_32_32
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button4.Location = New System.Drawing.Point(815, 68)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(100, 51)
        Me.Button4.TabIndex = 2
        Me.Button4.Text = "Modifier"
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button4.UseVisualStyleBackColor = True
        '
        'SuperTabItem1
        '
        Me.SuperTabItem1.AttachedControl = Me.SuperTabControlPanel1
        Me.SuperTabItem1.GlobalItem = False
        Me.SuperTabItem1.Name = "SuperTabItem1"
        Me.SuperTabItem1.Text = "Details liaison"
        '
        'SuperTabControlPanel3
        '
        Me.SuperTabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel3.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel3.Name = "SuperTabControlPanel3"
        Me.SuperTabControlPanel3.Size = New System.Drawing.Size(1494, 469)
        Me.SuperTabControlPanel3.TabIndex = 2
        Me.SuperTabControlPanel3.TabItem = Me.SuperTabItem4
        '
        'SuperTabItem4
        '
        Me.SuperTabItem4.AttachedControl = Me.SuperTabControlPanel3
        Me.SuperTabItem4.GlobalItem = False
        Me.SuperTabItem4.Name = "SuperTabItem4"
        Me.SuperTabItem4.Text = "Mode de pose"
        Me.SuperTabItem4.Visible = False
        '
        'SuperTabControlPanel4
        '
        Me.SuperTabControlPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel4.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel4.Name = "SuperTabControlPanel4"
        Me.SuperTabControlPanel4.Size = New System.Drawing.Size(1494, 469)
        Me.SuperTabControlPanel4.TabIndex = 1
        Me.SuperTabControlPanel4.TabItem = Me.SuperTabItem5
        '
        'SuperTabItem5
        '
        Me.SuperTabItem5.AttachedControl = Me.SuperTabControlPanel4
        Me.SuperTabItem5.GlobalItem = False
        Me.SuperTabItem5.Name = "SuperTabItem5"
        Me.SuperTabItem5.Text = "Historique"
        '
        'Departs_iddepartsTextBox
        '
        Me.Departs_iddepartsTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CablesBindingSource, "departs_iddeparts", True))
        Me.Departs_iddepartsTextBox.Location = New System.Drawing.Point(291, 4)
        Me.Departs_iddepartsTextBox.Name = "Departs_iddepartsTextBox"
        Me.Departs_iddepartsTextBox.Size = New System.Drawing.Size(100, 20)
        Me.Departs_iddepartsTextBox.TabIndex = 1
        Me.Departs_iddepartsTextBox.Visible = False
        '
        'Borniers_idbornierTextBox
        '
        Me.Borniers_idbornierTextBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Borniers_idbornierTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CablesBindingSource, "borniers_idbornier", True))
        Me.Borniers_idbornierTextBox.Location = New System.Drawing.Point(1048, 4)
        Me.Borniers_idbornierTextBox.Name = "Borniers_idbornierTextBox"
        Me.Borniers_idbornierTextBox.Size = New System.Drawing.Size(100, 20)
        Me.Borniers_idbornierTextBox.TabIndex = 3
        Me.Borniers_idbornierTextBox.Visible = False
        '
        'Donnees_cablesBindingSource
        '
        Me.Donnees_cablesBindingSource.DataMember = "donnees_cables"
        Me.Donnees_cablesBindingSource.DataSource = Me.MydbDataSet
        '
        'DepartsBindingSource
        '
        Me.DepartsBindingSource.DataMember = "departs"
        Me.DepartsBindingSource.DataSource = Me.MydbDataSet
        '
        'CablesTableAdapter
        '
        Me.CablesTableAdapter.ClearBeforeFill = True
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
        Me.TableAdapterManager.equip_pose_articleTableAdapter = Nothing
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
        Me.TableAdapterManager.timestampsTableAdapter = Nothing
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
        'Cables_detailsTableAdapter
        '
        Me.Cables_detailsTableAdapter.ClearBeforeFill = True
        '
        'CategoriesTableAdapter
        '
        Me.CategoriesTableAdapter.ClearBeforeFill = True
        '
        'DepartsTableAdapter
        '
        Me.DepartsTableAdapter.ClearBeforeFill = True
        '
        'EquipementsTableAdapter
        '
        Me.EquipementsTableAdapter.ClearBeforeFill = True
        '
        'LotsTableAdapter
        '
        Me.LotsTableAdapter.ClearBeforeFill = True
        '
        'SegregationsTableAdapter
        '
        Me.SegregationsTableAdapter.ClearBeforeFill = True
        '
        'Types_cableTableAdapter
        '
        Me.Types_cableTableAdapter.ClearBeforeFill = True
        '
        'Lst_departs_onTableAdapter
        '
        Me.Lst_departs_onTableAdapter.ClearBeforeFill = True
        '
        'Lst_Borniers_onTableAdapter
        '
        Me.Lst_Borniers_onTableAdapter.ClearBeforeFill = True
        '
        'Donnees_cablesTableAdapter
        '
        Me.Donnees_cablesTableAdapter.ClearBeforeFill = True
        '
        'Sections_cablesTableAdapter
        '
        Me.Sections_cablesTableAdapter.ClearBeforeFill = True
        '
        'Cable_details_sectionTableAdapter
        '
        Me.Cable_details_sectionTableAdapter.ClearBeforeFill = True
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
        'ParcoursTableAdapter
        '
        Me.ParcoursTableAdapter.ClearBeforeFill = True
        '
        'Parcours_detailBindingSource
        '
        Me.Parcours_detailBindingSource.DataMember = "parcours_detail"
        Me.Parcours_detailBindingSource.DataSource = Me.MydbDataSet
        '
        'Parcours_detailTableAdapter
        '
        Me.Parcours_detailTableAdapter.ClearBeforeFill = True
        '
        'Parcour_detail_idTableAdapter
        '
        Me.Parcour_detail_idTableAdapter.ClearBeforeFill = True
        '
        'TronconsBindingSource
        '
        Me.TronconsBindingSource.DataMember = "troncons"
        Me.TronconsBindingSource.DataSource = Me.MydbDataSet
        '
        'TronconsTableAdapter
        '
        Me.TronconsTableAdapter.ClearBeforeFill = True
        '
        'VeroulliageCableCheckBox
        '
        Me.VeroulliageCableCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.VeroulliageCableCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.CablesBindingSource, "VeroulliageCable", True))
        Me.VeroulliageCableCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VeroulliageCableCheckBox.ForeColor = System.Drawing.Color.Red
        Me.VeroulliageCableCheckBox.Location = New System.Drawing.Point(431, 7)
        Me.VeroulliageCableCheckBox.Name = "VeroulliageCableCheckBox"
        Me.VeroulliageCableCheckBox.Size = New System.Drawing.Size(195, 29)
        Me.VeroulliageCableCheckBox.TabIndex = 1
        Me.VeroulliageCableCheckBox.Text = "Veroulliage Cable"
        Me.VeroulliageCableCheckBox.UseVisualStyleBackColor = True
        '
        'DiversTextBox
        '
        Me.DiversTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CablesBindingSource, "divers", True))
        Me.DiversTextBox.Location = New System.Drawing.Point(610, 152)
        Me.DiversTextBox.Multiline = True
        Me.DiversTextBox.Name = "DiversTextBox"
        Me.DiversTextBox.Size = New System.Drawing.Size(322, 96)
        Me.DiversTextBox.TabIndex = 1
        '
        'ButtonX7
        '
        Me.ButtonX7.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX7.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonX7.Location = New System.Drawing.Point(1392, 112)
        Me.ButtonX7.Name = "ButtonX7"
        Me.ButtonX7.Size = New System.Drawing.Size(103, 34)
        Me.ButtonX7.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014
        Me.ButtonX7.Symbol = ""
        Me.ButtonX7.TabIndex = 35
        Me.ButtonX7.Text = "Supprimer"
        Me.ButtonX7.TextColor = System.Drawing.Color.Red
        '
        'Actions_borniersTableAdapter
        '
        Me.Actions_borniersTableAdapter.ClearBeforeFill = True
        '
        'Lst_cable_mise_touretBindingSource
        '
        Me.Lst_cable_mise_touretBindingSource.DataMember = "lst_cable_mise_touret"
        Me.Lst_cable_mise_touretBindingSource.DataSource = Me.MydbDataSet
        '
        'Lst_cable_mise_touretTableAdapter
        '
        Me.Lst_cable_mise_touretTableAdapter.ClearBeforeFill = True
        '
        'Cables_details_has_touretsBindingSource
        '
        Me.Cables_details_has_touretsBindingSource.DataMember = "cables_details_has_tourets"
        Me.Cables_details_has_touretsBindingSource.DataSource = Me.MydbDataSet
        '
        'Cables_details_has_touretsTableAdapter
        '
        Me.Cables_details_has_touretsTableAdapter.ClearBeforeFill = True
        '
        'BackgroundWorker1
        '
        '
        'FormCable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1523, 757)
        Me.Controls.Add(Me.ButtonX7)
        Me.Controls.Add(DiversLabel)
        Me.Controls.Add(Me.DiversTextBox)
        Me.Controls.Add(Me.VeroulliageCableCheckBox)
        Me.Controls.Add(Borniers_idbornierLabel1)
        Me.Controls.Add(Me.Borniers_idbornierTextBox)
        Me.Controls.Add(Departs_iddepartsLabel1)
        Me.Controls.Add(Me.Departs_iddepartsTextBox)
        Me.Controls.Add(Me.SuperTabControl1)
        Me.Controls.Add(Me.ButtonXNouveau)
        Me.Controls.Add(Me.SectionGlobaleTextBox)
        Me.Controls.Add(SectionGlobaleLabel)
        Me.Controls.Add(Me.ButtonXEnregistrer)
        Me.Controls.Add(Me.ComboBox2)
        Me.Controls.Add(CategorieLabel)
        Me.Controls.Add(Me.ComboBox)
        Me.Controls.Add(SegregationLabel)
        Me.Controls.Add(DesignationLabel2)
        Me.Controls.Add(Me.DesignationTextBox2)
        Me.Controls.Add(DesignationLabel1)
        Me.Controls.Add(Me.EntrepriseTextBox)
        Me.Controls.Add(Me.DesignationTextBox1)
        Me.Controls.Add(EntrepriseLabel)
        Me.Controls.Add(LotLabel)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(TypesLabel)
        Me.Controls.Add(DesignationLabel)
        Me.Controls.Add(Me.DesignationTextBox)
        Me.Controls.Add(Me.BlindageCheckBox)
        Me.Controls.Add(Me.Types_cable_idtypes_cableComboBox)
        Me.Controls.Add(IdcableLabel)
        Me.Controls.Add(Me.IdcableTextBox)
        Me.Controls.Add(Repere_cableLabel)
        Me.Controls.Add(Me.Repere_cableTextBox)
        Me.Controls.Add(VoieLabel)
        Me.Controls.Add(Me.VoieTextBox)
        Me.Controls.Add(TensionLabel)
        Me.Controls.Add(Me.TensionTextBox)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FormCable"
        Me.Text = "Detail Câble :"
        CType(Me.Cables_detailsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MydbDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CablesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EquipementsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EquipementAboutissantBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Types_cableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LotsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SegregationsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CategoriesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.Lst_departs_onBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LotTenantBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.Lst_Borniers_onBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LotAboutissantBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Parcour_detail_idBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ParcoursBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cable_details_sectionBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Sections_cablesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SuperTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControl1.ResumeLayout(False)
        Me.SuperTabControlPanel2.ResumeLayout(False)
        Me.SuperTabControlPanel2.PerformLayout()
        Me.GroupPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.SuperTabControlPanel1.ResumeLayout(False)
        Me.SuperTabControlPanel1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.Donnees_cablesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DepartsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Lst_assoc_par_trcBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Lst_assoc_par_trc2BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Parcours_detailBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TronconsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Lst_cable_mise_touretBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cables_details_has_touretsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SuperValidator1 As DevComponents.DotNetBar.Validator.SuperValidator
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Highlighter1 As DevComponents.DotNetBar.Validator.Highlighter
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    'Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    'Friend WithEvents LineShape4 As Microsoft.VisualBasic.PowerPacks.LineShape
    'Friend WithEvents LineShape3 As Microsoft.VisualBasic.PowerPacks.LineShape
    'Friend WithEvents LineShape2 As Microsoft.VisualBasic.PowerPacks.LineShape
    'Friend WithEvents LineShape1 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents SuperTabItem3 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents CablesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents MydbDataSet As progelec.mydbDataSet
    Friend WithEvents CablesTableAdapter As progelec.mydbDataSetTableAdapters.cablesTableAdapter
    Friend WithEvents TableAdapterManager As progelec.mydbDataSetTableAdapters.TableAdapterManager
    Friend WithEvents IdcableTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Repere_cableTextBox As System.Windows.Forms.TextBox
    Friend WithEvents VoieTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TensionTextBox As System.Windows.Forms.TextBox
    Friend WithEvents SectionGlobaleTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Cables_detailsTableAdapter As progelec.mydbDataSetTableAdapters.cables_detailsTableAdapter
    Friend WithEvents Cables_detailsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Types_cable_idtypes_cableComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Types_cableTableAdapter As progelec.mydbDataSetTableAdapters.types_cableTableAdapter
    Friend WithEvents Types_cableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DesignationTextBox As System.Windows.Forms.TextBox
    Friend WithEvents BlindageCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents LotsTableAdapter As progelec.mydbDataSetTableAdapters.lotsTableAdapter
    Friend WithEvents LotsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents DesignationTextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents EntrepriseTextBox As System.Windows.Forms.TextBox
    Friend WithEvents SegregationsTableAdapter As progelec.mydbDataSetTableAdapters.segregationsTableAdapter
    Friend WithEvents SegregationsBindingSource As System.Windows.Forms.BindingSource
    Private WithEvents ComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents DesignationTextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents CategoriesTableAdapter As progelec.mydbDataSetTableAdapters.categoriesTableAdapter
    Friend WithEvents CategoriesBindingSource As System.Windows.Forms.BindingSource
    Private WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents EquipementsTableAdapter As progelec.mydbDataSetTableAdapters.equipementsTableAdapter
    Friend WithEvents EquipementsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Repere_equipementComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents DesignationTextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents ComboBox3 As System.Windows.Forms.ComboBox
    Friend WithEvents LotTenantBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DepartsTableAdapter As progelec.mydbDataSetTableAdapters.departsTableAdapter
    Friend WithEvents DepartsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Lst_departs_onBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Lst_departs_onTableAdapter As progelec.mydbDataSetTableAdapters.lst_departs_onTableAdapter
    Friend WithEvents SerrageCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents CoupleTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Lst_Borniers_onBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Lst_Borniers_onTableAdapter As progelec.mydbDataSetTableAdapters.Lst_Borniers_onTableAdapter
    Friend WithEvents ComboBox6 As System.Windows.Forms.ComboBox
    Friend WithEvents EquipementAboutissantBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents LotAboutissantBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ComboBox7 As System.Windows.Forms.ComboBox
    Friend WithEvents CoupleCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents SerrageTextBox As System.Windows.Forms.TextBox
    Friend WithEvents RequiredFieldValidator4 As DevComponents.DotNetBar.Validator.RequiredFieldValidator
    Friend WithEvents RequiredFieldValidator3 As DevComponents.DotNetBar.Validator.RequiredFieldValidator
    Friend WithEvents RequiredFieldValidator6 As DevComponents.DotNetBar.Validator.RequiredFieldValidator
    Friend WithEvents RequiredFieldValidator5 As DevComponents.DotNetBar.Validator.RequiredFieldValidator
    Friend WithEvents RequiredFieldValidator9 As DevComponents.DotNetBar.Validator.RequiredFieldValidator
    Friend WithEvents RequiredFieldValidator2 As DevComponents.DotNetBar.Validator.RequiredFieldValidator
    Friend WithEvents RequiredFieldValidator1 As DevComponents.DotNetBar.Validator.RequiredFieldValidator
    Friend WithEvents RequiredFieldValidator7 As DevComponents.DotNetBar.Validator.RequiredFieldValidator
    Friend WithEvents RequiredFieldValidator8 As DevComponents.DotNetBar.Validator.RequiredFieldValidator
    Private WithEvents ButtonXEnregistrer As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Donnees_cablesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Donnees_cablesTableAdapter As progelec.mydbDataSetTableAdapters.donnees_cablesTableAdapter
    Friend WithEvents Sections_cablesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Sections_cablesTableAdapter As progelec.mydbDataSetTableAdapters.sections_cablesTableAdapter
    Private WithEvents ButtonXNouveau As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Cable_details_sectionBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Cable_details_sectionTableAdapter As progelec.mydbDataSetTableAdapters.cable_details_sectionTableAdapter
    Friend WithEvents Lst_assoc_par_trcBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Lst_assoc_par_trcTableAdapter As progelec.mydbDataSetTableAdapters.lst_assoc_par_trcTableAdapter
    Friend WithEvents Lst_assoc_par_trc2BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Lst_assoc_par_trc2TableAdapter As progelec.mydbDataSetTableAdapters.lst_assoc_par_trc2TableAdapter
    Friend WithEvents ParcoursBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ParcoursTableAdapter As progelec.mydbDataSetTableAdapters.parcoursTableAdapter
    Friend WithEvents Parcours_detailBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Parcours_detailTableAdapter As progelec.mydbDataSetTableAdapters.parcours_detailTableAdapter
    Friend WithEvents Parcour_detail_idBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Parcour_detail_idTableAdapter As progelec.mydbDataSetTableAdapters.parcour_detail_idTableAdapter
    Friend WithEvents SuperTabControl1 As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents SuperTabControlPanel1 As DevComponents.DotNetBar.SuperTabControlPanel
    Private WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents TextBox18 As System.Windows.Forms.TextBox
    Friend WithEvents DataGridView4 As System.Windows.Forms.DataGridView
    Friend WithEvents ComboBox9 As System.Windows.Forms.ComboBox
    Friend WithEvents TextBox17 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox16 As System.Windows.Forms.TextBox
    Friend WithEvents SuperTabItem1 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel3 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SuperTabItem4 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel2 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents TextBox11 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox8 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox9 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox10 As System.Windows.Forms.TextBox
    Friend WithEvents ButtonX3 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents SuperTabItem2 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel4 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SuperTabItem5 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents LMAXTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Longueur_Note_CalculeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Borniers_idbornierTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Departs_iddepartsTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Departs_iddepartsComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Borniers_idbornierComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ContrainteCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents ButtonX4 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX2 As DevComponents.DotNetBar.ButtonX
    Private WithEvents Button3 As System.Windows.Forms.Button
    Private WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents DataGridViewTextBoxColumn28 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn29 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn30 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn31 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents trefle As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn32 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn33 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn34 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ButtonX6 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX5 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents TronconsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TronconsTableAdapter As progelec.mydbDataSetTableAdapters.tronconsTableAdapter
    Friend WithEvents Cont1ValTextBox As System.Windows.Forms.TextBox
    Friend WithEvents VeroulliageCableCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents VerouillageParcoursCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents Cont8ModeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Cont7ModeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Cont6ModeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Cont5ModeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Cont4ModeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Cont3ModeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Cont2ModeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents DiversTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ComboBoxEx1 As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents ComboBoxEx2 As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents ComboBoxEx6 As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents ComboBoxEx5 As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents ComboBoxEx8 As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents ComboBoxEx7 As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents ComboBoxEx4 As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents ComboBoxEx3 As DevComponents.DotNetBar.Controls.ComboBoxEx
    Private WithEvents ButtonX7 As DevComponents.DotNetBar.ButtonX
    Private WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Actions_borniersTableAdapter As progelec.mydbDataSetTableAdapters.Actions_borniersTableAdapter
    Friend WithEvents DataGridViewTextBoxColumn18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn19 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn20 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn21 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn22 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents longueur As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton4 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton5 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton6 As System.Windows.Forms.RadioButton
    Friend WithEvents Lst_cable_mise_touretBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Lst_cable_mise_touretTableAdapter As progelec.mydbDataSetTableAdapters.lst_cable_mise_touretTableAdapter
    Friend WithEvents Cables_details_has_touretsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Cables_details_has_touretsTableAdapter As progelec.mydbDataSetTableAdapters.cables_details_has_touretsTableAdapter
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents ButtonX8 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ProgressSteps1 As DevComponents.DotNetBar.ProgressSteps
    Friend WithEvents StepItem1 As DevComponents.DotNetBar.StepItem
    Friend WithEvents StepItem2 As DevComponents.DotNetBar.StepItem
    Friend WithEvents StepItem3 As DevComponents.DotNetBar.StepItem
    Friend WithEvents StepItem4 As DevComponents.DotNetBar.StepItem
    Friend WithEvents StepItem5 As DevComponents.DotNetBar.StepItem
    Friend WithEvents StepItem6 As DevComponents.DotNetBar.StepItem
    Friend WithEvents ProgressBarX1 As DevComponents.DotNetBar.Controls.ProgressBarX
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
End Class
