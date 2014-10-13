Imports DevComponents.DotNetBar

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormTroncon
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
        Dim LargeurLabel As System.Windows.Forms.Label
        Dim LongueurLabel As System.Windows.Forms.Label
        Dim HauteurLabel As System.Windows.Forms.Label
        Dim ElevationLabel As System.Windows.Forms.Label
        Dim Repere_tronconLabel As System.Windows.Forms.Label
        Dim ReservesLabel As System.Windows.Forms.Label
        Dim Reserves2Label As System.Windows.Forms.Label
        Dim TypeLabel As System.Windows.Forms.Label
        Dim DiametreLabel As System.Windows.Forms.Label
        Dim FormesLabel As System.Windows.Forms.Label
        Dim Reserve_calLabel As System.Windows.Forms.Label
        Dim Reserve2_calLabel As System.Windows.Forms.Label
        Dim RemarqueLabel As System.Windows.Forms.Label
        Dim QuiLabel As System.Windows.Forms.Label
        Dim VersionLabel As System.Windows.Forms.Label
        Dim Label1 As System.Windows.Forms.Label
        Dim ModifLabel As System.Windows.Forms.Label
        Dim DetailmodifLabel As System.Windows.Forms.Label
        Dim Reserve_lotLabel As System.Windows.Forms.Label
        Dim Label3 As System.Windows.Forms.Label
        Dim Label2 As System.Windows.Forms.Label
        Dim Radio_protectionLabel As System.Windows.Forms.Label
        Dim Coupe_feuLabel As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormTroncon))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TableAdapterManager = New progelec.mydbDataSetTableAdapters.TableAdapterManager()
        Me.Types_tronconsTableAdapter = New progelec.mydbDataSetTableAdapters.types_tronconsTableAdapter()
        Me.Salle_2TableAdapter1 = New progelec.mydbDataSetTableAdapters.sallesTableAdapter()
        Me.Cable_details_tronconTableAdapter = New progelec.mydbDataSetTableAdapters.cable_details_tronconTableAdapter()
        Me.SegregationsTableAdapter = New progelec.mydbDataSetTableAdapters.segregationsTableAdapter()
        Me.TronconsTableAdapter = New progelec.mydbDataSetTableAdapters.tronconsTableAdapter()
        Me.SallesTableAdapter = New progelec.mydbDataSetTableAdapters.sallesTableAdapter()
        Me.Cables_troncon_idTableAdapter = New progelec.mydbDataSetTableAdapters.cables_troncon_idTableAdapter()
        Me.BorniersTableAdapter = New progelec.mydbDataSetTableAdapters.sallesTableAdapter()
        Me.Cables_detailsTableAdapter = New progelec.mydbDataSetTableAdapters.cables_detailsTableAdapter()
        Me.CablesTableAdapter = New progelec.mydbDataSetTableAdapters.cablesTableAdapter()
        Me.Troncons_fournituresTableAdapter = New progelec.mydbDataSetTableAdapters.troncons_fournituresTableAdapter()
        Me.FournituresTableAdapter = New progelec.mydbDataSetTableAdapters.fournituresTableAdapter()
        Me.Lst_fournitures_trcTableAdapter = New progelec.mydbDataSetTableAdapters.lst_fournitures_trcTableAdapter()
        Me.MydbDataSet = New progelec.mydbDataSet()
        Me.Reserve2_calTextBox = New System.Windows.Forms.TextBox()
        Me.TronconsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Reserve_calTextBox = New System.Windows.Forms.TextBox()
        Me.GroupBox = New System.Windows.Forms.GroupBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Remplissage3RadioButton = New System.Windows.Forms.RadioButton()
        Me.Remplissage2RadioButton = New System.Windows.Forms.RadioButton()
        Me.RemplissageRadioButton = New System.Windows.Forms.RadioButton()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.Reserve_lotTextBox = New System.Windows.Forms.TextBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Reserves2TextBox = New System.Windows.Forms.TextBox()
        Me.ReservesTextBox = New System.Windows.Forms.TextBox()
        Me.Cable_details_tronconBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ComboBoxEx1 = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.SegregationsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DiametreTextBox = New System.Windows.Forms.TextBox()
        Me.ElevationTextBox = New System.Windows.Forms.TextBox()
        Me.HauteurTextBox = New System.Windows.Forms.TextBox()
        Me.LongueurTextBox = New System.Windows.Forms.TextBox()
        Me.LargeurTextBox = New System.Windows.Forms.TextBox()
        Me.Repere_tronconTextBox = New System.Windows.Forms.TextBox()
        Me.LabelXSegregation = New DevComponents.DotNetBar.LabelX()
        Me.ComboBoxEx2 = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.SallesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.ComboBoxEx3 = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Salle_2bindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Types_tronconsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TypeComboBox = New System.Windows.Forms.ComboBox()
        Me.FormesComboBox = New System.Windows.Forms.ComboBox()
        Me.IdtronconsTextBox = New System.Windows.Forms.TextBox()
        Me.SuperValidator1 = New DevComponents.DotNetBar.Validator.SuperValidator()
        Me.RequiredFieldValidator7 = New DevComponents.DotNetBar.Validator.RequiredFieldValidator("Vous devez choisir une segregation .")
        Me.RequiredFieldValidator5 = New DevComponents.DotNetBar.Validator.RequiredFieldValidator("Vous devez specifier une valeur")
        Me.RequiredFieldValidator9 = New DevComponents.DotNetBar.Validator.RequiredFieldValidator("Your error message here.")
        Me.RequiredFieldValidator4 = New DevComponents.DotNetBar.Validator.RequiredFieldValidator("Vous devez specifier une valeur")
        Me.RequiredFieldValidator3 = New DevComponents.DotNetBar.Validator.RequiredFieldValidator("Vous devez specifier une valeur")
        Me.RequiredFieldValidator2 = New DevComponents.DotNetBar.Validator.RequiredFieldValidator("Vous devez specifier une valeur")
        Me.RequiredFieldValidator6 = New DevComponents.DotNetBar.Validator.RequiredFieldValidator("Vous devez donner un nom au tronçon .")
        Me.RequiredFieldValidator11 = New DevComponents.DotNetBar.Validator.RequiredFieldValidator("Your error message here.")
        Me.RequiredFieldValidator10 = New DevComponents.DotNetBar.Validator.RequiredFieldValidator("Your error message here.")
        Me.RequiredFieldValidator8 = New DevComponents.DotNetBar.Validator.RequiredFieldValidator("Choisir un type .")
        Me.RequiredFieldValidator12 = New DevComponents.DotNetBar.Validator.RequiredFieldValidator("Your error message here.")
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Highlighter1 = New DevComponents.DotNetBar.Validator.Highlighter()
        Me.Date_calculDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.VirtuelCheckBox = New System.Windows.Forms.CheckBox()
        Me.RemarqueTextBox = New System.Windows.Forms.TextBox()
        Me.QuiTextBox = New System.Windows.Forms.TextBox()
        Me.VersionTextBox = New System.Windows.Forms.TextBox()
        Me.TerminalCheckBox = New System.Windows.Forms.CheckBox()
        Me.ModifTextBox = New System.Windows.Forms.TextBox()
        Me.DetailmodifTextBox = New System.Windows.Forms.TextBox()
        Me.DiscriminationCheckBox = New System.Windows.Forms.CheckBox()
        Me.BorniersBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.Cables_troncon_idBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Cables_troncon_idDataGridViewX = New DevComponents.DotNetBar.Controls.DataGridViewX()
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
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewCheckBoxColumn2 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewCheckBoxColumn3 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewCheckBoxColumn4 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Masse_TextBoxX1 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.DateDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.CablesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SuperTabControl1 = New DevComponents.DotNetBar.SuperTabControl()
        Me.SuperTabControlPanel1 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.DataGridViewX1 = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.IdtronconsfournitureDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.quant = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TronconDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CategorieDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FournitureDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdfournitureDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DesignationDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QuantminDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FournisseurDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UniteeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Lst_fournitures_trcBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ButtonX3 = New DevComponents.DotNetBar.ButtonX()
        Me.CheckBoxX1 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.ButtonX2 = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.ComboBoxEx4 = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Dimentions = New DevComponents.DotNetBar.SuperTabItem()
        Me.FournituresBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Troncons_fournituresBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Radio_protectionCheckBox = New System.Windows.Forms.CheckBox()
        Me.Coupe_feuCheckBox = New System.Windows.Forms.CheckBox()
        Me.BatimentsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BatimentsTableAdapter = New progelec.mydbDataSetTableAdapters.batimentsTableAdapter()
        Me.ComboBoxEx5 = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.ComboBoxEx6 = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.batiment2BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.Batiments2TableAdapter = New progelec.mydbDataSetTableAdapters.batimentsTableAdapter()
        Me.RequiredFieldValidator1 = New DevComponents.DotNetBar.Validator.RequiredFieldValidator("Your error message here.")
        Me.RequiredFieldValidator13 = New DevComponents.DotNetBar.Validator.RequiredFieldValidator("Your error message here.")
        LargeurLabel = New System.Windows.Forms.Label()
        LongueurLabel = New System.Windows.Forms.Label()
        HauteurLabel = New System.Windows.Forms.Label()
        ElevationLabel = New System.Windows.Forms.Label()
        Repere_tronconLabel = New System.Windows.Forms.Label()
        ReservesLabel = New System.Windows.Forms.Label()
        Reserves2Label = New System.Windows.Forms.Label()
        TypeLabel = New System.Windows.Forms.Label()
        DiametreLabel = New System.Windows.Forms.Label()
        FormesLabel = New System.Windows.Forms.Label()
        Reserve_calLabel = New System.Windows.Forms.Label()
        Reserve2_calLabel = New System.Windows.Forms.Label()
        RemarqueLabel = New System.Windows.Forms.Label()
        QuiLabel = New System.Windows.Forms.Label()
        VersionLabel = New System.Windows.Forms.Label()
        Label1 = New System.Windows.Forms.Label()
        ModifLabel = New System.Windows.Forms.Label()
        DetailmodifLabel = New System.Windows.Forms.Label()
        Reserve_lotLabel = New System.Windows.Forms.Label()
        Label3 = New System.Windows.Forms.Label()
        Label2 = New System.Windows.Forms.Label()
        Radio_protectionLabel = New System.Windows.Forms.Label()
        Coupe_feuLabel = New System.Windows.Forms.Label()
        CType(Me.MydbDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TronconsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cable_details_tronconBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SegregationsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SallesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Salle_2bindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Types_tronconsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BorniersBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cables_troncon_idBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cables_troncon_idDataGridViewX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CablesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SuperTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControl1.SuspendLayout()
        Me.SuperTabControlPanel1.SuspendLayout()
        CType(Me.DataGridViewX1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Lst_fournitures_trcBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FournituresBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Troncons_fournituresBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BatimentsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.batiment2BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LargeurLabel
        '
        LargeurLabel.AutoSize = True
        LargeurLabel.Location = New System.Drawing.Point(16, 18)
        LargeurLabel.Name = "LargeurLabel"
        LargeurLabel.Size = New System.Drawing.Size(42, 13)
        LargeurLabel.TabIndex = 2
        LargeurLabel.Text = "largeur:"
        '
        'LongueurLabel
        '
        LongueurLabel.AutoSize = True
        LongueurLabel.Location = New System.Drawing.Point(347, 43)
        LongueurLabel.Name = "LongueurLabel"
        LongueurLabel.Size = New System.Drawing.Size(51, 13)
        LongueurLabel.TabIndex = 4
        LongueurLabel.Text = "longueur:"
        '
        'HauteurLabel
        '
        HauteurLabel.AutoSize = True
        HauteurLabel.Location = New System.Drawing.Point(12, 45)
        HauteurLabel.Name = "HauteurLabel"
        HauteurLabel.Size = New System.Drawing.Size(46, 13)
        HauteurLabel.TabIndex = 6
        HauteurLabel.Text = "hauteur:"
        '
        'ElevationLabel
        '
        ElevationLabel.AutoSize = True
        ElevationLabel.Location = New System.Drawing.Point(345, 17)
        ElevationLabel.Name = "ElevationLabel"
        ElevationLabel.Size = New System.Drawing.Size(53, 13)
        ElevationLabel.TabIndex = 0
        ElevationLabel.Text = "elevation:"
        '
        'Repere_tronconLabel
        '
        Repere_tronconLabel.AutoSize = True
        Repere_tronconLabel.Location = New System.Drawing.Point(103, 24)
        Repere_tronconLabel.Name = "Repere_tronconLabel"
        Repere_tronconLabel.Size = New System.Drawing.Size(79, 13)
        Repere_tronconLabel.TabIndex = 2
        Repere_tronconLabel.Text = "repere troncon:"
        '
        'ReservesLabel
        '
        ReservesLabel.Anchor = System.Windows.Forms.AnchorStyles.Top
        ReservesLabel.AutoSize = True
        ReservesLabel.Location = New System.Drawing.Point(29, 118)
        ReservesLabel.Name = "ReservesLabel"
        ReservesLabel.Size = New System.Drawing.Size(70, 13)
        ReservesLabel.TabIndex = 7
        ReservesLabel.Text = "% Part Mono:"
        '
        'Reserves2Label
        '
        Reserves2Label.Anchor = System.Windows.Forms.AnchorStyles.Top
        Reserves2Label.AutoSize = True
        Reserves2Label.Location = New System.Drawing.Point(27, 38)
        Reserves2Label.Name = "Reserves2Label"
        Reserves2Label.Size = New System.Drawing.Size(62, 13)
        Reserves2Label.TabIndex = 5
        Reserves2Label.Text = "% Part Multi"
        '
        'TypeLabel
        '
        TypeLabel.AutoSize = True
        TypeLabel.Location = New System.Drawing.Point(12, 81)
        TypeLabel.Name = "TypeLabel"
        TypeLabel.Size = New System.Drawing.Size(34, 13)
        TypeLabel.TabIndex = 6
        TypeLabel.Text = "Type:"
        '
        'DiametreLabel
        '
        DiametreLabel.AutoSize = True
        DiametreLabel.Location = New System.Drawing.Point(6, 71)
        DiametreLabel.Name = "DiametreLabel"
        DiametreLabel.Size = New System.Drawing.Size(52, 13)
        DiametreLabel.TabIndex = 8
        DiametreLabel.Text = "Diametre:"
        '
        'FormesLabel
        '
        FormesLabel.AutoSize = True
        FormesLabel.Location = New System.Drawing.Point(12, 110)
        FormesLabel.Name = "FormesLabel"
        FormesLabel.Size = New System.Drawing.Size(41, 13)
        FormesLabel.TabIndex = 8
        FormesLabel.Text = "formes:"
        '
        'Reserve_calLabel
        '
        Reserve_calLabel.Anchor = System.Windows.Forms.AnchorStyles.Top
        Reserve_calLabel.AutoSize = True
        Reserve_calLabel.Location = New System.Drawing.Point(407, 84)
        Reserve_calLabel.Name = "Reserve_calLabel"
        Reserve_calLabel.Size = New System.Drawing.Size(139, 13)
        Reserve_calLabel.TabIndex = 1
        Reserve_calLabel.Text = "Remplissage Monocouche :"
        '
        'Reserve2_calLabel
        '
        Reserve2_calLabel.Anchor = System.Windows.Forms.AnchorStyles.Top
        Reserve2_calLabel.AutoSize = True
        Reserve2_calLabel.Location = New System.Drawing.Point(404, 19)
        Reserve2_calLabel.Name = "Reserve2_calLabel"
        Reserve2_calLabel.Size = New System.Drawing.Size(140, 13)
        Reserve2_calLabel.TabIndex = 0
        Reserve2_calLabel.Text = "Remplissage MultiCouches :"
        '
        'RemarqueLabel
        '
        RemarqueLabel.AutoSize = True
        RemarqueLabel.Location = New System.Drawing.Point(289, 75)
        RemarqueLabel.Name = "RemarqueLabel"
        RemarqueLabel.Size = New System.Drawing.Size(54, 13)
        RemarqueLabel.TabIndex = 15
        RemarqueLabel.Text = "remarque:"
        '
        'QuiLabel
        '
        QuiLabel.AutoSize = True
        QuiLabel.Location = New System.Drawing.Point(871, 133)
        QuiLabel.Name = "QuiLabel"
        QuiLabel.Size = New System.Drawing.Size(29, 13)
        QuiLabel.TabIndex = 30
        QuiLabel.Text = "Par :"
        '
        'VersionLabel
        '
        VersionLabel.AutoSize = True
        VersionLabel.Location = New System.Drawing.Point(600, 107)
        VersionLabel.Name = "VersionLabel"
        VersionLabel.Size = New System.Drawing.Size(45, 13)
        VersionLabel.TabIndex = 32
        VersionLabel.Text = "Version:"
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(740, 106)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(23, 13)
        Label1.TabIndex = 34
        Label1.Text = "DU"
        '
        'ModifLabel
        '
        ModifLabel.AutoSize = True
        ModifLabel.Location = New System.Drawing.Point(609, 157)
        ModifLabel.Name = "ModifLabel"
        ModifLabel.Size = New System.Drawing.Size(36, 13)
        ModifLabel.TabIndex = 37
        ModifLabel.Text = "Motif :"
        '
        'DetailmodifLabel
        '
        DetailmodifLabel.AutoSize = True
        DetailmodifLabel.Location = New System.Drawing.Point(585, 183)
        DetailmodifLabel.Name = "DetailmodifLabel"
        DetailmodifLabel.Size = New System.Drawing.Size(60, 13)
        DetailmodifLabel.TabIndex = 39
        DetailmodifLabel.Text = "detailmodif:"
        '
        'Reserve_lotLabel
        '
        Reserve_lotLabel.Anchor = System.Windows.Forms.AnchorStyles.Top
        Reserve_lotLabel.AutoSize = True
        Reserve_lotLabel.Location = New System.Drawing.Point(570, 17)
        Reserve_lotLabel.Name = "Reserve_lotLabel"
        Reserve_lotLabel.Size = New System.Drawing.Size(74, 13)
        Reserve_lotLabel.TabIndex = 45
        Reserve_lotLabel.Text = "(L) reserve lot:"
        '
        'Label3
        '
        Label3.AutoSize = True
        Label3.Location = New System.Drawing.Point(588, 133)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(57, 13)
        Label3.TabIndex = 49
        Label3.Text = "Calcul du :"
        '
        'Label2
        '
        Label2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(246, 19)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(55, 13)
        Label2.TabIndex = 48
        Label2.Text = "Couches :"
        '
        'Radio_protectionLabel
        '
        Radio_protectionLabel.AutoSize = True
        Radio_protectionLabel.Location = New System.Drawing.Point(949, 189)
        Radio_protectionLabel.Name = "Radio_protectionLabel"
        Radio_protectionLabel.Size = New System.Drawing.Size(83, 13)
        Radio_protectionLabel.TabIndex = 52
        Radio_protectionLabel.Text = "radio protection:"
        '
        'Coupe_feuLabel
        '
        Coupe_feuLabel.AutoSize = True
        Coupe_feuLabel.Location = New System.Drawing.Point(974, 219)
        Coupe_feuLabel.Name = "Coupe_feuLabel"
        Coupe_feuLabel.Size = New System.Drawing.Size(58, 13)
        Coupe_feuLabel.TabIndex = 53
        Coupe_feuLabel.Text = "coupe feu:"
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
        Me.TableAdapterManager.Connection = Nothing
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
        'Types_tronconsTableAdapter
        '
        Me.Types_tronconsTableAdapter.ClearBeforeFill = True
        '
        'Salle_2TableAdapter1
        '
        Me.Salle_2TableAdapter1.ClearBeforeFill = True
        '
        'Cable_details_tronconTableAdapter
        '
        Me.Cable_details_tronconTableAdapter.ClearBeforeFill = True
        '
        'SegregationsTableAdapter
        '
        Me.SegregationsTableAdapter.ClearBeforeFill = True
        '
        'TronconsTableAdapter
        '
        Me.TronconsTableAdapter.ClearBeforeFill = True
        '
        'SallesTableAdapter
        '
        Me.SallesTableAdapter.ClearBeforeFill = True
        '
        'Cables_troncon_idTableAdapter
        '
        Me.Cables_troncon_idTableAdapter.ClearBeforeFill = True
        '
        'BorniersTableAdapter
        '
        Me.BorniersTableAdapter.ClearBeforeFill = True
        '
        'Cables_detailsTableAdapter
        '
        Me.Cables_detailsTableAdapter.ClearBeforeFill = True
        '
        'CablesTableAdapter
        '
        Me.CablesTableAdapter.ClearBeforeFill = True
        '
        'Troncons_fournituresTableAdapter
        '
        Me.Troncons_fournituresTableAdapter.ClearBeforeFill = True
        '
        'FournituresTableAdapter
        '
        Me.FournituresTableAdapter.ClearBeforeFill = True
        '
        'Lst_fournitures_trcTableAdapter
        '
        Me.Lst_fournitures_trcTableAdapter.ClearBeforeFill = True
        '
        'MydbDataSet
        '
        Me.MydbDataSet.DataSetName = "mydbDataSet"
        Me.MydbDataSet.EnforceConstraints = False
        Me.MydbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Reserve2_calTextBox
        '
        Me.Reserve2_calTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Reserve2_calTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TronconsBindingSource, "reserve2_cal", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Reserve2_calTextBox.Location = New System.Drawing.Point(416, 35)
        Me.Reserve2_calTextBox.Name = "Reserve2_calTextBox"
        Me.Reserve2_calTextBox.Size = New System.Drawing.Size(119, 20)
        Me.Reserve2_calTextBox.TabIndex = 3
        Me.Reserve2_calTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TronconsBindingSource
        '
        Me.TronconsBindingSource.DataMember = "troncons"
        Me.TronconsBindingSource.DataSource = Me.MydbDataSet
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(887, 479)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(125, 28)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Calcul (Mettre à jour)"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Reserve_calTextBox
        '
        Me.Reserve_calTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Reserve_calTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TronconsBindingSource, "Reserve_cal", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Reserve_calTextBox.Location = New System.Drawing.Point(423, 100)
        Me.Reserve_calTextBox.Name = "Reserve_calTextBox"
        Me.Reserve_calTextBox.Size = New System.Drawing.Size(112, 20)
        Me.Reserve_calTextBox.TabIndex = 4
        Me.Reserve_calTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox
        '
        Me.GroupBox.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox.Controls.Add(Label2)
        Me.GroupBox.Controls.Add(Me.PictureBox5)
        Me.GroupBox.Controls.Add(Me.PictureBox1)
        Me.GroupBox.Controls.Add(Me.Remplissage3RadioButton)
        Me.GroupBox.Controls.Add(Me.Remplissage2RadioButton)
        Me.GroupBox.Controls.Add(Me.RemplissageRadioButton)
        Me.GroupBox.Controls.Add(Me.PictureBox6)
        Me.GroupBox.Controls.Add(Me.PictureBox2)
        Me.GroupBox.Controls.Add(Reserve_lotLabel)
        Me.GroupBox.Controls.Add(Me.PictureBox4)
        Me.GroupBox.Controls.Add(Me.Reserve_lotTextBox)
        Me.GroupBox.Controls.Add(Me.PictureBox3)
        Me.GroupBox.Controls.Add(Me.TextBox1)
        Me.GroupBox.Controls.Add(Me.Reserves2TextBox)
        Me.GroupBox.Controls.Add(Reserves2Label)
        Me.GroupBox.Controls.Add(Me.Reserve_calTextBox)
        Me.GroupBox.Controls.Add(Me.Reserve2_calTextBox)
        Me.GroupBox.Controls.Add(Me.ReservesTextBox)
        Me.GroupBox.Controls.Add(ReservesLabel)
        Me.GroupBox.Controls.Add(Reserve2_calLabel)
        Me.GroupBox.Controls.Add(Reserve_calLabel)
        Me.GroupBox.Location = New System.Drawing.Point(585, 250)
        Me.GroupBox.Name = "GroupBox"
        Me.GroupBox.Size = New System.Drawing.Size(659, 213)
        Me.GroupBox.TabIndex = 9
        Me.GroupBox.TabStop = False
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = Global.progelec.My.Resources.Resources.trefle
        Me.PictureBox5.Location = New System.Drawing.Point(241, 134)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(90, 31)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox5.TabIndex = 47
        Me.PictureBox5.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.progelec.My.Resources.Resources.trefle
        Me.PictureBox1.Location = New System.Drawing.Point(227, 86)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(90, 31)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 13
        Me.PictureBox1.TabStop = False
        '
        'Remplissage3RadioButton
        '
        Me.Remplissage3RadioButton.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.TronconsBindingSource, "remplissage3", True))
        Me.Remplissage3RadioButton.Location = New System.Drawing.Point(10, 169)
        Me.Remplissage3RadioButton.Name = "Remplissage3RadioButton"
        Me.Remplissage3RadioButton.Size = New System.Drawing.Size(104, 24)
        Me.Remplissage3RadioButton.TabIndex = 12
        Me.Remplissage3RadioButton.TabStop = True
        Me.Remplissage3RadioButton.Text = "Dual"
        Me.Remplissage3RadioButton.UseVisualStyleBackColor = True
        '
        'Remplissage2RadioButton
        '
        Me.Remplissage2RadioButton.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.TronconsBindingSource, "remplissage2", True))
        Me.Remplissage2RadioButton.Location = New System.Drawing.Point(10, 93)
        Me.Remplissage2RadioButton.Name = "Remplissage2RadioButton"
        Me.Remplissage2RadioButton.Size = New System.Drawing.Size(104, 24)
        Me.Remplissage2RadioButton.TabIndex = 10
        Me.Remplissage2RadioButton.TabStop = True
        Me.Remplissage2RadioButton.Text = "Mono Couche"
        Me.Remplissage2RadioButton.UseVisualStyleBackColor = True
        '
        'RemplissageRadioButton
        '
        Me.RemplissageRadioButton.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.TronconsBindingSource, "remplissage", True))
        Me.RemplissageRadioButton.Location = New System.Drawing.Point(10, 13)
        Me.RemplissageRadioButton.Name = "RemplissageRadioButton"
        Me.RemplissageRadioButton.Size = New System.Drawing.Size(104, 24)
        Me.RemplissageRadioButton.TabIndex = 9
        Me.RemplissageRadioButton.TabStop = True
        Me.RemplissageRadioButton.Text = "Multi Couches"
        Me.RemplissageRadioButton.UseVisualStyleBackColor = True
        '
        'PictureBox6
        '
        Me.PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), System.Drawing.Image)
        Me.PictureBox6.Location = New System.Drawing.Point(125, 132)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(110, 61)
        Me.PictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox6.TabIndex = 5
        Me.PictureBox6.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(125, 14)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(95, 73)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 1
        Me.PictureBox2.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(241, 167)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(139, 26)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox4.TabIndex = 3
        Me.PictureBox4.TabStop = False
        '
        'Reserve_lotTextBox
        '
        Me.Reserve_lotTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Reserve_lotTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TronconsBindingSource, "reserve_lot", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Reserve_lotTextBox.Location = New System.Drawing.Point(580, 96)
        Me.Reserve_lotTextBox.Name = "Reserve_lotTextBox"
        Me.Reserve_lotTextBox.Size = New System.Drawing.Size(64, 20)
        Me.Reserve_lotTextBox.TabIndex = 46
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(125, 97)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(110, 20)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 2
        Me.PictureBox3.TabStop = False
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.TextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TronconsBindingSource, "nbcouche", True))
        Me.TextBox1.Location = New System.Drawing.Point(252, 41)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(49, 20)
        Me.TextBox1.TabIndex = 44
        '
        'Reserves2TextBox
        '
        Me.Reserves2TextBox.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Reserves2TextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TronconsBindingSource, "reserves2", True))
        Me.Reserves2TextBox.Location = New System.Drawing.Point(30, 54)
        Me.Reserves2TextBox.Name = "Reserves2TextBox"
        Me.Reserves2TextBox.Size = New System.Drawing.Size(65, 20)
        Me.Reserves2TextBox.TabIndex = 6
        Me.Reserves2TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.SuperValidator1.SetValidator1(Me.Reserves2TextBox, Me.RequiredFieldValidator1)
        '
        'ReservesTextBox
        '
        Me.ReservesTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.ReservesTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TronconsBindingSource, "reserves", True))
        Me.ReservesTextBox.Location = New System.Drawing.Point(30, 134)
        Me.ReservesTextBox.Name = "ReservesTextBox"
        Me.ReservesTextBox.Size = New System.Drawing.Size(65, 20)
        Me.ReservesTextBox.TabIndex = 8
        Me.ReservesTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.SuperValidator1.SetValidator1(Me.ReservesTextBox, Me.RequiredFieldValidator13)
        '
        'Cable_details_tronconBindingSource
        '
        Me.Cable_details_tronconBindingSource.DataMember = "cable_details_troncon"
        Me.Cable_details_tronconBindingSource.DataSource = Me.MydbDataSet
        '
        'ComboBoxEx1
        '
        Me.ComboBoxEx1.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.TronconsBindingSource, "segregations_idsegregations", True))
        Me.ComboBoxEx1.DataSource = Me.SegregationsBindingSource
        Me.ComboBoxEx1.DisplayMember = "segregation"
        Me.ComboBoxEx1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBoxEx1.FormattingEnabled = True
        Me.ComboBoxEx1.ItemHeight = 14
        Me.ComboBoxEx1.Location = New System.Drawing.Point(121, 136)
        Me.ComboBoxEx1.Name = "ComboBoxEx1"
        Me.ComboBoxEx1.Size = New System.Drawing.Size(121, 20)
        Me.ComboBoxEx1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ComboBoxEx1.TabIndex = 5
        Me.SuperValidator1.SetValidator1(Me.ComboBoxEx1, Me.RequiredFieldValidator7)
        Me.ComboBoxEx1.ValueMember = "idsegregations"
        '
        'SegregationsBindingSource
        '
        Me.SegregationsBindingSource.DataMember = "segregations"
        Me.SegregationsBindingSource.DataSource = Me.MydbDataSet
        '
        'DiametreTextBox
        '
        Me.DiametreTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TronconsBindingSource, "Diametre", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.DiametreTextBox.Location = New System.Drawing.Point(64, 68)
        Me.DiametreTextBox.Name = "DiametreTextBox"
        Me.DiametreTextBox.Size = New System.Drawing.Size(100, 20)
        Me.DiametreTextBox.TabIndex = 9
        Me.SuperValidator1.SetValidator1(Me.DiametreTextBox, Me.RequiredFieldValidator5)
        '
        'ElevationTextBox
        '
        Me.ElevationTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TronconsBindingSource, "elevation", True))
        Me.ElevationTextBox.Location = New System.Drawing.Point(404, 14)
        Me.ElevationTextBox.Name = "ElevationTextBox"
        Me.ElevationTextBox.Size = New System.Drawing.Size(100, 20)
        Me.ElevationTextBox.TabIndex = 1
        Me.SuperValidator1.SetValidator1(Me.ElevationTextBox, Me.RequiredFieldValidator9)
        '
        'HauteurTextBox
        '
        Me.HauteurTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TronconsBindingSource, "hauteur", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.HauteurTextBox.Location = New System.Drawing.Point(64, 42)
        Me.HauteurTextBox.Name = "HauteurTextBox"
        Me.HauteurTextBox.Size = New System.Drawing.Size(100, 20)
        Me.HauteurTextBox.TabIndex = 7
        Me.SuperValidator1.SetValidator1(Me.HauteurTextBox, Me.RequiredFieldValidator4)
        '
        'LongueurTextBox
        '
        Me.LongueurTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TronconsBindingSource, "longueur", True))
        Me.LongueurTextBox.Location = New System.Drawing.Point(404, 40)
        Me.LongueurTextBox.Name = "LongueurTextBox"
        Me.LongueurTextBox.Size = New System.Drawing.Size(100, 20)
        Me.LongueurTextBox.TabIndex = 5
        Me.SuperValidator1.SetValidator1(Me.LongueurTextBox, Me.RequiredFieldValidator3)
        '
        'LargeurTextBox
        '
        Me.LargeurTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TronconsBindingSource, "largeur", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.LargeurTextBox.Location = New System.Drawing.Point(64, 15)
        Me.LargeurTextBox.Name = "LargeurTextBox"
        Me.LargeurTextBox.Size = New System.Drawing.Size(100, 20)
        Me.LargeurTextBox.TabIndex = 3
        Me.SuperValidator1.SetValidator1(Me.LargeurTextBox, Me.RequiredFieldValidator2)
        '
        'Repere_tronconTextBox
        '
        Me.Repere_tronconTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Repere_tronconTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TronconsBindingSource, "repere troncon", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Repere_tronconTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Repere_tronconTextBox.Location = New System.Drawing.Point(5, 40)
        Me.Repere_tronconTextBox.Name = "Repere_tronconTextBox"
        Me.Repere_tronconTextBox.Size = New System.Drawing.Size(274, 32)
        Me.Repere_tronconTextBox.TabIndex = 3
        Me.SuperValidator1.SetValidator1(Me.Repere_tronconTextBox, Me.RequiredFieldValidator6)
        '
        'LabelXSegregation
        '
        '
        '
        '
        Me.LabelXSegregation.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelXSegregation.Location = New System.Drawing.Point(15, 133)
        Me.LabelXSegregation.Name = "LabelXSegregation"
        Me.LabelXSegregation.Size = New System.Drawing.Size(75, 23)
        Me.LabelXSegregation.TabIndex = 4
        Me.LabelXSegregation.Text = "Ségregation :"
        '
        'ComboBoxEx2
        '
        Me.ComboBoxEx2.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.TronconsBindingSource, "salles", True))
        Me.ComboBoxEx2.DataSource = Me.SallesBindingSource
        Me.ComboBoxEx2.DisplayMember = "repere salle"
        Me.ComboBoxEx2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBoxEx2.FormattingEnabled = True
        Me.ComboBoxEx2.ItemHeight = 14
        Me.ComboBoxEx2.Location = New System.Drawing.Point(121, 192)
        Me.ComboBoxEx2.Name = "ComboBoxEx2"
        Me.ComboBoxEx2.Size = New System.Drawing.Size(121, 20)
        Me.ComboBoxEx2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ComboBoxEx2.TabIndex = 11
        Me.SuperValidator1.SetValidator1(Me.ComboBoxEx2, Me.RequiredFieldValidator11)
        Me.ComboBoxEx2.ValueMember = "idsalle"
        '
        'SallesBindingSource
        '
        Me.SallesBindingSource.DataMember = "salles"
        Me.SallesBindingSource.DataSource = Me.MydbDataSet
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(15, 187)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(43, 23)
        Me.LabelX1.TabIndex = 10
        Me.LabelX1.Text = "Salle :"
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Location = New System.Drawing.Point(14, 214)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(82, 29)
        Me.LabelX2.TabIndex = 12
        Me.LabelX2.Text = "Salle" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Aboutissante :"
        '
        'ComboBoxEx3
        '
        Me.ComboBoxEx3.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.TronconsBindingSource, "salles_idsalle", True))
        Me.ComboBoxEx3.DataSource = Me.Salle_2bindingSource
        Me.ComboBoxEx3.DisplayMember = "repere salle"
        Me.ComboBoxEx3.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBoxEx3.FormattingEnabled = True
        Me.ComboBoxEx3.ItemHeight = 14
        Me.ComboBoxEx3.Location = New System.Drawing.Point(121, 220)
        Me.ComboBoxEx3.Name = "ComboBoxEx3"
        Me.ComboBoxEx3.Size = New System.Drawing.Size(121, 20)
        Me.ComboBoxEx3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ComboBoxEx3.TabIndex = 13
        Me.SuperValidator1.SetValidator1(Me.ComboBoxEx3, Me.RequiredFieldValidator10)
        Me.ComboBoxEx3.ValueMember = "idsalle"
        '
        'Salle_2bindingSource
        '
        Me.Salle_2bindingSource.DataMember = "salles"
        Me.Salle_2bindingSource.DataSource = Me.MydbDataSet
        '
        'Types_tronconsBindingSource
        '
        Me.Types_tronconsBindingSource.DataMember = "types_troncons"
        Me.Types_tronconsBindingSource.DataSource = Me.MydbDataSet
        '
        'TypeComboBox
        '
        Me.TypeComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.TronconsBindingSource, "Types_troncons_idTypes_troncons", True))
        Me.TypeComboBox.DataSource = Me.Types_tronconsBindingSource
        Me.TypeComboBox.DisplayMember = "Type"
        Me.TypeComboBox.FormattingEnabled = True
        Me.TypeComboBox.Location = New System.Drawing.Point(121, 78)
        Me.TypeComboBox.Name = "TypeComboBox"
        Me.TypeComboBox.Size = New System.Drawing.Size(121, 21)
        Me.TypeComboBox.TabIndex = 7
        Me.SuperValidator1.SetValidator1(Me.TypeComboBox, Me.RequiredFieldValidator8)
        Me.TypeComboBox.ValueMember = "idTypes_troncons"
        '
        'FormesComboBox
        '
        Me.FormesComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TronconsBindingSource, "formes", True))
        Me.FormesComboBox.FormattingEnabled = True
        Me.FormesComboBox.Items.AddRange(New Object() {"Rectangle", "Cercle"})
        Me.FormesComboBox.Location = New System.Drawing.Point(121, 107)
        Me.FormesComboBox.Name = "FormesComboBox"
        Me.FormesComboBox.Size = New System.Drawing.Size(121, 21)
        Me.FormesComboBox.TabIndex = 9
        Me.SuperValidator1.SetValidator1(Me.FormesComboBox, Me.RequiredFieldValidator12)
        '
        'IdtronconsTextBox
        '
        Me.IdtronconsTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IdtronconsTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TronconsBindingSource, "idtroncons", True))
        Me.IdtronconsTextBox.Enabled = False
        Me.IdtronconsTextBox.Location = New System.Drawing.Point(0, 1)
        Me.IdtronconsTextBox.Name = "IdtronconsTextBox"
        Me.IdtronconsTextBox.Size = New System.Drawing.Size(562, 20)
        Me.IdtronconsTextBox.TabIndex = 0
        Me.IdtronconsTextBox.Visible = False
        '
        'SuperValidator1
        '
        Me.SuperValidator1.ContainerControl = Me
        Me.SuperValidator1.ErrorProvider = Me.ErrorProvider1
        Me.SuperValidator1.Highlighter = Me.Highlighter1
        Me.SuperValidator1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        '
        'RequiredFieldValidator7
        '
        Me.RequiredFieldValidator7.ErrorMessage = "Vous devez choisir une segregation ."
        Me.RequiredFieldValidator7.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red
        '
        'RequiredFieldValidator5
        '
        Me.RequiredFieldValidator5.ErrorMessage = "Vous devez specifier une valeur"
        Me.RequiredFieldValidator5.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red
        '
        'RequiredFieldValidator9
        '
        Me.RequiredFieldValidator9.ErrorMessage = "Your error message here."
        Me.RequiredFieldValidator9.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red
        '
        'RequiredFieldValidator4
        '
        Me.RequiredFieldValidator4.ErrorMessage = "Vous devez specifier une valeur"
        Me.RequiredFieldValidator4.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red
        '
        'RequiredFieldValidator3
        '
        Me.RequiredFieldValidator3.ErrorMessage = "Vous devez specifier une valeur"
        Me.RequiredFieldValidator3.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red
        '
        'RequiredFieldValidator2
        '
        Me.RequiredFieldValidator2.ErrorMessage = "Vous devez specifier une valeur"
        Me.RequiredFieldValidator2.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red
        '
        'RequiredFieldValidator6
        '
        Me.RequiredFieldValidator6.ErrorMessage = "Vous devez donner un nom au tronçon ."
        Me.RequiredFieldValidator6.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red
        '
        'RequiredFieldValidator11
        '
        Me.RequiredFieldValidator11.ErrorMessage = "Your error message here."
        Me.RequiredFieldValidator11.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red
        '
        'RequiredFieldValidator10
        '
        Me.RequiredFieldValidator10.ErrorMessage = "Your error message here."
        Me.RequiredFieldValidator10.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red
        '
        'RequiredFieldValidator8
        '
        Me.RequiredFieldValidator8.ErrorMessage = "Choisir un type ."
        Me.RequiredFieldValidator8.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red
        '
        'RequiredFieldValidator12
        '
        Me.RequiredFieldValidator12.ErrorMessage = "Your error message here."
        Me.RequiredFieldValidator12.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red
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
        'Date_calculDateTimePicker
        '
        Me.Date_calculDateTimePicker.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.TronconsBindingSource, "date_calcul", True))
        Me.Date_calculDateTimePicker.Enabled = False
        Me.Highlighter1.SetHighlightColor(Me.Date_calculDateTimePicker, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
        Me.Highlighter1.SetHighlightOnFocus(Me.Date_calculDateTimePicker, True)
        Me.Date_calculDateTimePicker.Location = New System.Drawing.Point(654, 128)
        Me.Date_calculDateTimePicker.Name = "Date_calculDateTimePicker"
        Me.Date_calculDateTimePicker.Size = New System.Drawing.Size(200, 20)
        Me.Date_calculDateTimePicker.TabIndex = 36
        '
        'VirtuelCheckBox
        '
        Me.VirtuelCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.TronconsBindingSource, "virtuel", True))
        Me.VirtuelCheckBox.Location = New System.Drawing.Point(299, 28)
        Me.VirtuelCheckBox.Name = "VirtuelCheckBox"
        Me.VirtuelCheckBox.Size = New System.Drawing.Size(72, 22)
        Me.VirtuelCheckBox.TabIndex = 1
        Me.VirtuelCheckBox.Text = "Virtuel"
        Me.VirtuelCheckBox.UseVisualStyleBackColor = True
        '
        'RemarqueTextBox
        '
        Me.RemarqueTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TronconsBindingSource, "remarque", True))
        Me.RemarqueTextBox.Location = New System.Drawing.Point(292, 91)
        Me.RemarqueTextBox.Multiline = True
        Me.RemarqueTextBox.Name = "RemarqueTextBox"
        Me.RemarqueTextBox.Size = New System.Drawing.Size(274, 123)
        Me.RemarqueTextBox.TabIndex = 16
        '
        'QuiTextBox
        '
        Me.QuiTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TronconsBindingSource, "Qui", True))
        Me.QuiTextBox.Enabled = False
        Me.QuiTextBox.Location = New System.Drawing.Point(906, 129)
        Me.QuiTextBox.Name = "QuiTextBox"
        Me.QuiTextBox.Size = New System.Drawing.Size(112, 20)
        Me.QuiTextBox.TabIndex = 31
        '
        'VersionTextBox
        '
        Me.VersionTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TronconsBindingSource, "version", True))
        Me.VersionTextBox.Location = New System.Drawing.Point(654, 103)
        Me.VersionTextBox.Name = "VersionTextBox"
        Me.VersionTextBox.Size = New System.Drawing.Size(82, 20)
        Me.VersionTextBox.TabIndex = 33
        '
        'TerminalCheckBox
        '
        Me.TerminalCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.TronconsBindingSource, "terminal", True))
        Me.TerminalCheckBox.Location = New System.Drawing.Point(377, 27)
        Me.TerminalCheckBox.Name = "TerminalCheckBox"
        Me.TerminalCheckBox.Size = New System.Drawing.Size(79, 24)
        Me.TerminalCheckBox.TabIndex = 35
        Me.TerminalCheckBox.Text = "Terminal"
        Me.TerminalCheckBox.UseVisualStyleBackColor = True
        '
        'ModifTextBox
        '
        Me.ModifTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TronconsBindingSource, "modif", True))
        Me.ModifTextBox.Enabled = False
        Me.ModifTextBox.Location = New System.Drawing.Point(654, 154)
        Me.ModifTextBox.Name = "ModifTextBox"
        Me.ModifTextBox.Size = New System.Drawing.Size(174, 20)
        Me.ModifTextBox.TabIndex = 38
        '
        'DetailmodifTextBox
        '
        Me.DetailmodifTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TronconsBindingSource, "detailmodif", True))
        Me.DetailmodifTextBox.Location = New System.Drawing.Point(654, 180)
        Me.DetailmodifTextBox.Name = "DetailmodifTextBox"
        Me.DetailmodifTextBox.Size = New System.Drawing.Size(174, 20)
        Me.DetailmodifTextBox.TabIndex = 40
        '
        'DiscriminationCheckBox
        '
        Me.DiscriminationCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.TronconsBindingSource, "discrimination", True))
        Me.DiscriminationCheckBox.Location = New System.Drawing.Point(462, 27)
        Me.DiscriminationCheckBox.Name = "DiscriminationCheckBox"
        Me.DiscriminationCheckBox.Size = New System.Drawing.Size(104, 24)
        Me.DiscriminationCheckBox.TabIndex = 45
        Me.DiscriminationCheckBox.Text = "discrimination"
        Me.DiscriminationCheckBox.UseVisualStyleBackColor = True
        '
        'BorniersBindingSource
        '
        Me.BorniersBindingSource.DataMember = "borniers"
        Me.BorniersBindingSource.DataSource = Me.MydbDataSet
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX1.Location = New System.Drawing.Point(652, 24)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Size = New System.Drawing.Size(153, 43)
        Me.ButtonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX1.TabIndex = 18
        Me.ButtonX1.Text = "Nouveau"
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Location = New System.Drawing.Point(0, 529)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(291, 23)
        Me.LabelX3.TabIndex = 37
        Me.LabelX3.Text = "<u><b>Cable Présent dans le troçon</b></u>"
        '
        'Cables_troncon_idBindingSource
        '
        Me.Cables_troncon_idBindingSource.DataMember = "cables_troncon_id"
        Me.Cables_troncon_idBindingSource.DataSource = Me.MydbDataSet
        '
        'Cables_troncon_idDataGridViewX
        '
        Me.Cables_troncon_idDataGridViewX.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cables_troncon_idDataGridViewX.AutoGenerateColumns = False
        Me.Cables_troncon_idDataGridViewX.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Cables_troncon_idDataGridViewX.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn10, Me.DataGridViewTextBoxColumn11, Me.DataGridViewTextBoxColumn12, Me.DataGridViewTextBoxColumn13, Me.DataGridViewTextBoxColumn14, Me.DataGridViewTextBoxColumn15, Me.DataGridViewCheckBoxColumn1, Me.DataGridViewCheckBoxColumn2, Me.DataGridViewCheckBoxColumn3, Me.DataGridViewCheckBoxColumn4})
        Me.Cables_troncon_idDataGridViewX.DataSource = Me.Cables_troncon_idBindingSource
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Cables_troncon_idDataGridViewX.DefaultCellStyle = DataGridViewCellStyle4
        Me.Cables_troncon_idDataGridViewX.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.Cables_troncon_idDataGridViewX.Location = New System.Drawing.Point(5, 558)
        Me.Cables_troncon_idDataGridViewX.Name = "Cables_troncon_idDataGridViewX"
        Me.Cables_troncon_idDataGridViewX.Size = New System.Drawing.Size(1844, 159)
        Me.Cables_troncon_idDataGridViewX.TabIndex = 41
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "repere equipement"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Tenant"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 66
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "designation"
        Me.DataGridViewTextBoxColumn2.HeaderText = "designation"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 86
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "lot"
        Me.DataGridViewTextBoxColumn3.HeaderText = "lot"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 43
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "repere salle"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Salle T"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 65
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "repere cable"
        Me.DataGridViewTextBoxColumn5.HeaderText = "repere cable"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Width = 91
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "Fils"
        Me.DataGridViewTextBoxColumn6.HeaderText = "Fils"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Width = 47
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "section"
        Me.DataGridViewTextBoxColumn7.HeaderText = "section"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.Width = 66
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "types"
        Me.DataGridViewTextBoxColumn8.HeaderText = "types"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.Width = 57
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "repere equipement1"
        Me.DataGridViewTextBoxColumn9.HeaderText = "Aboutissant"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.Width = 87
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "designation1"
        Me.DataGridViewTextBoxColumn10.HeaderText = "designation"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.Width = 86
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "lot1"
        Me.DataGridViewTextBoxColumn11.HeaderText = "lot"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.Width = 43
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "repere salle1"
        Me.DataGridViewTextBoxColumn12.HeaderText = "Salle A"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.Width = 65
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn13.DataPropertyName = "diametre"
        Me.DataGridViewTextBoxColumn13.HeaderText = "diametre"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.Width = 72
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn14.DataPropertyName = "charge_calorifique"
        Me.DataGridViewTextBoxColumn14.HeaderText = "charge_calorifique"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.Visible = False
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn15.DataPropertyName = "masse"
        Me.DataGridViewTextBoxColumn15.HeaderText = "masse"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.Visible = False
        '
        'DataGridViewCheckBoxColumn1
        '
        Me.DataGridViewCheckBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewCheckBoxColumn1.DataPropertyName = "mode_de_pose"
        Me.DataGridViewCheckBoxColumn1.HeaderText = "Monocouche"
        Me.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1"
        Me.DataGridViewCheckBoxColumn1.Width = 76
        '
        'DataGridViewCheckBoxColumn2
        '
        Me.DataGridViewCheckBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewCheckBoxColumn2.DataPropertyName = "mode_de_pose2"
        Me.DataGridViewCheckBoxColumn2.HeaderText = "Trefle"
        Me.DataGridViewCheckBoxColumn2.Name = "DataGridViewCheckBoxColumn2"
        Me.DataGridViewCheckBoxColumn2.Visible = False
        '
        'DataGridViewCheckBoxColumn3
        '
        Me.DataGridViewCheckBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewCheckBoxColumn3.DataPropertyName = "mode_de_pose3"
        Me.DataGridViewCheckBoxColumn3.HeaderText = "Multicouche"
        Me.DataGridViewCheckBoxColumn3.Name = "DataGridViewCheckBoxColumn3"
        Me.DataGridViewCheckBoxColumn3.Width = 71
        '
        'DataGridViewCheckBoxColumn4
        '
        Me.DataGridViewCheckBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewCheckBoxColumn4.DataPropertyName = "trefle"
        Me.DataGridViewCheckBoxColumn4.HeaderText = "trefle"
        Me.DataGridViewCheckBoxColumn4.Name = "DataGridViewCheckBoxColumn4"
        Me.DataGridViewCheckBoxColumn4.Width = 36
        '
        'Masse_TextBoxX1
        '
        '
        '
        '
        Me.Masse_TextBoxX1.Border.Class = "TextBoxBorder"
        Me.Masse_TextBoxX1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Masse_TextBoxX1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TronconsBindingSource, "Masse_calcule", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "0", "### "",""###"))
        Me.Masse_TextBoxX1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Masse_TextBoxX1.ForeColor = System.Drawing.Color.Red
        Me.Masse_TextBoxX1.Location = New System.Drawing.Point(622, 476)
        Me.Masse_TextBoxX1.Name = "Masse_TextBoxX1"
        Me.Masse_TextBoxX1.Size = New System.Drawing.Size(153, 32)
        Me.Masse_TextBoxX1.TabIndex = 47
        Me.Masse_TextBoxX1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'DateDateTimePicker
        '
        Me.DateDateTimePicker.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.TronconsBindingSource, "date", True))
        Me.DateDateTimePicker.Location = New System.Drawing.Point(769, 103)
        Me.DateDateTimePicker.Name = "DateDateTimePicker"
        Me.DateDateTimePicker.Size = New System.Drawing.Size(200, 20)
        Me.DateDateTimePicker.TabIndex = 50
        '
        'LabelX5
        '
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX5.Location = New System.Drawing.Point(781, 476)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(86, 32)
        Me.LabelX5.TabIndex = 51
        Me.LabelX5.Text = "Kg / M."
        '
        'CablesBindingSource
        '
        Me.CablesBindingSource.DataMember = "cables"
        Me.CablesBindingSource.DataSource = Me.MydbDataSet
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
        Me.SuperTabControl1.Location = New System.Drawing.Point(5, 250)
        Me.SuperTabControl1.Name = "SuperTabControl1"
        Me.SuperTabControl1.ReorderTabsEnabled = True
        Me.SuperTabControl1.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.SuperTabControl1.SelectedTabIndex = 0
        Me.SuperTabControl1.Size = New System.Drawing.Size(561, 276)
        Me.SuperTabControl1.TabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SuperTabControl1.TabIndex = 52
        Me.SuperTabControl1.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Dimentions})
        Me.SuperTabControl1.Text = "SuperTabControl1"
        '
        'SuperTabControlPanel1
        '
        Me.SuperTabControlPanel1.Controls.Add(Me.DataGridViewX1)
        Me.SuperTabControlPanel1.Controls.Add(Me.ButtonX3)
        Me.SuperTabControlPanel1.Controls.Add(Me.CheckBoxX1)
        Me.SuperTabControlPanel1.Controls.Add(Me.ButtonX2)
        Me.SuperTabControlPanel1.Controls.Add(Me.LabelX6)
        Me.SuperTabControlPanel1.Controls.Add(DiametreLabel)
        Me.SuperTabControlPanel1.Controls.Add(Me.DiametreTextBox)
        Me.SuperTabControlPanel1.Controls.Add(Me.LargeurTextBox)
        Me.SuperTabControlPanel1.Controls.Add(ElevationLabel)
        Me.SuperTabControlPanel1.Controls.Add(LargeurLabel)
        Me.SuperTabControlPanel1.Controls.Add(Me.ElevationTextBox)
        Me.SuperTabControlPanel1.Controls.Add(Me.LongueurTextBox)
        Me.SuperTabControlPanel1.Controls.Add(HauteurLabel)
        Me.SuperTabControlPanel1.Controls.Add(LongueurLabel)
        Me.SuperTabControlPanel1.Controls.Add(Me.HauteurTextBox)
        Me.SuperTabControlPanel1.Controls.Add(Me.ComboBoxEx4)
        Me.SuperTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel1.Location = New System.Drawing.Point(0, 25)
        Me.SuperTabControlPanel1.Name = "SuperTabControlPanel1"
        Me.SuperTabControlPanel1.Size = New System.Drawing.Size(561, 251)
        Me.SuperTabControlPanel1.TabIndex = 1
        Me.SuperTabControlPanel1.TabItem = Me.Dimentions
        '
        'DataGridViewX1
        '
        Me.DataGridViewX1.AllowUserToAddRows = False
        Me.DataGridViewX1.AllowUserToDeleteRows = False
        Me.DataGridViewX1.AutoGenerateColumns = False
        Me.DataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewX1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdtronconsfournitureDataGridViewTextBoxColumn, Me.quant, Me.TronconDataGridViewTextBoxColumn, Me.CategorieDataGridViewTextBoxColumn, Me.FournitureDataGridViewTextBoxColumn, Me.IdfournitureDataGridViewTextBoxColumn, Me.DesignationDataGridViewTextBoxColumn, Me.QuantminDataGridViewTextBoxColumn, Me.FournisseurDataGridViewTextBoxColumn, Me.UniteeDataGridViewTextBoxColumn})
        Me.DataGridViewX1.DataSource = Me.Lst_fournitures_trcBindingSource
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewX1.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewX1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DataGridViewX1.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.DataGridViewX1.Location = New System.Drawing.Point(0, 153)
        Me.DataGridViewX1.Name = "DataGridViewX1"
        Me.DataGridViewX1.ReadOnly = True
        Me.DataGridViewX1.Size = New System.Drawing.Size(561, 98)
        Me.DataGridViewX1.TabIndex = 1
        '
        'IdtronconsfournitureDataGridViewTextBoxColumn
        '
        Me.IdtronconsfournitureDataGridViewTextBoxColumn.DataPropertyName = "idtroncons_fourniture"
        Me.IdtronconsfournitureDataGridViewTextBoxColumn.HeaderText = "idtroncons_fourniture"
        Me.IdtronconsfournitureDataGridViewTextBoxColumn.Name = "IdtronconsfournitureDataGridViewTextBoxColumn"
        Me.IdtronconsfournitureDataGridViewTextBoxColumn.ReadOnly = True
        Me.IdtronconsfournitureDataGridViewTextBoxColumn.Visible = False
        '
        'quant
        '
        Me.quant.DataPropertyName = "quant"
        Me.quant.HeaderText = "quant"
        Me.quant.Name = "quant"
        Me.quant.ReadOnly = True
        Me.quant.Width = 50
        '
        'TronconDataGridViewTextBoxColumn
        '
        Me.TronconDataGridViewTextBoxColumn.DataPropertyName = "troncon"
        Me.TronconDataGridViewTextBoxColumn.HeaderText = "troncon"
        Me.TronconDataGridViewTextBoxColumn.Name = "TronconDataGridViewTextBoxColumn"
        Me.TronconDataGridViewTextBoxColumn.ReadOnly = True
        Me.TronconDataGridViewTextBoxColumn.Visible = False
        '
        'CategorieDataGridViewTextBoxColumn
        '
        Me.CategorieDataGridViewTextBoxColumn.DataPropertyName = "Categorie"
        Me.CategorieDataGridViewTextBoxColumn.HeaderText = "Categorie"
        Me.CategorieDataGridViewTextBoxColumn.Name = "CategorieDataGridViewTextBoxColumn"
        Me.CategorieDataGridViewTextBoxColumn.ReadOnly = True
        '
        'FournitureDataGridViewTextBoxColumn
        '
        Me.FournitureDataGridViewTextBoxColumn.DataPropertyName = "fourniture"
        Me.FournitureDataGridViewTextBoxColumn.HeaderText = "fourniture"
        Me.FournitureDataGridViewTextBoxColumn.Name = "FournitureDataGridViewTextBoxColumn"
        Me.FournitureDataGridViewTextBoxColumn.ReadOnly = True
        Me.FournitureDataGridViewTextBoxColumn.Visible = False
        '
        'IdfournitureDataGridViewTextBoxColumn
        '
        Me.IdfournitureDataGridViewTextBoxColumn.DataPropertyName = "idfourniture"
        Me.IdfournitureDataGridViewTextBoxColumn.HeaderText = "idfourniture"
        Me.IdfournitureDataGridViewTextBoxColumn.Name = "IdfournitureDataGridViewTextBoxColumn"
        Me.IdfournitureDataGridViewTextBoxColumn.ReadOnly = True
        Me.IdfournitureDataGridViewTextBoxColumn.Visible = False
        '
        'DesignationDataGridViewTextBoxColumn
        '
        Me.DesignationDataGridViewTextBoxColumn.DataPropertyName = "designation"
        Me.DesignationDataGridViewTextBoxColumn.HeaderText = "designation"
        Me.DesignationDataGridViewTextBoxColumn.Name = "DesignationDataGridViewTextBoxColumn"
        Me.DesignationDataGridViewTextBoxColumn.ReadOnly = True
        Me.DesignationDataGridViewTextBoxColumn.Width = 300
        '
        'QuantminDataGridViewTextBoxColumn
        '
        Me.QuantminDataGridViewTextBoxColumn.DataPropertyName = "quant_min"
        Me.QuantminDataGridViewTextBoxColumn.HeaderText = "quant_min"
        Me.QuantminDataGridViewTextBoxColumn.Name = "QuantminDataGridViewTextBoxColumn"
        Me.QuantminDataGridViewTextBoxColumn.ReadOnly = True
        '
        'FournisseurDataGridViewTextBoxColumn
        '
        Me.FournisseurDataGridViewTextBoxColumn.DataPropertyName = "fournisseur"
        Me.FournisseurDataGridViewTextBoxColumn.HeaderText = "fournisseur"
        Me.FournisseurDataGridViewTextBoxColumn.Name = "FournisseurDataGridViewTextBoxColumn"
        Me.FournisseurDataGridViewTextBoxColumn.ReadOnly = True
        Me.FournisseurDataGridViewTextBoxColumn.Visible = False
        '
        'UniteeDataGridViewTextBoxColumn
        '
        Me.UniteeDataGridViewTextBoxColumn.DataPropertyName = "unitee"
        Me.UniteeDataGridViewTextBoxColumn.HeaderText = "unitee"
        Me.UniteeDataGridViewTextBoxColumn.Name = "UniteeDataGridViewTextBoxColumn"
        Me.UniteeDataGridViewTextBoxColumn.ReadOnly = True
        '
        'Lst_fournitures_trcBindingSource
        '
        Me.Lst_fournitures_trcBindingSource.DataMember = "lst_fournitures_trc"
        Me.Lst_fournitures_trcBindingSource.DataSource = Me.MydbDataSet
        '
        'ButtonX3
        '
        Me.ButtonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX3.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX3.Location = New System.Drawing.Point(341, 109)
        Me.ButtonX3.Name = "ButtonX3"
        Me.ButtonX3.Size = New System.Drawing.Size(75, 23)
        Me.ButtonX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX3.TabIndex = 0
        Me.ButtonX3.Text = "Generation"
        '
        'CheckBoxX1
        '
        '
        '
        '
        Me.CheckBoxX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxX1.Location = New System.Drawing.Point(94, 98)
        Me.CheckBoxX1.Name = "CheckBoxX1"
        Me.CheckBoxX1.Size = New System.Drawing.Size(100, 23)
        Me.CheckBoxX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CheckBoxX1.TabIndex = 14
        Me.CheckBoxX1.TextVisible = False
        '
        'ButtonX2
        '
        Me.ButtonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX2.Location = New System.Drawing.Point(422, 109)
        Me.ButtonX2.Name = "ButtonX2"
        Me.ButtonX2.Size = New System.Drawing.Size(75, 23)
        Me.ButtonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX2.TabIndex = 0
        Me.ButtonX2.Text = "Selection"
        '
        'LabelX6
        '
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Location = New System.Drawing.Point(13, 98)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(75, 23)
        Me.LabelX6.TabIndex = 11
        Me.LabelX6.Text = "Pre-selection"
        '
        'ComboBoxEx4
        '
        Me.ComboBoxEx4.DisplayMember = "repere salle"
        Me.ComboBoxEx4.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBoxEx4.FormattingEnabled = True
        Me.ComboBoxEx4.ItemHeight = 14
        Me.ComboBoxEx4.Location = New System.Drawing.Point(10, 127)
        Me.ComboBoxEx4.Name = "ComboBoxEx4"
        Me.ComboBoxEx4.Size = New System.Drawing.Size(207, 20)
        Me.ComboBoxEx4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ComboBoxEx4.TabIndex = 13
        Me.ComboBoxEx4.ValueMember = "idsalle"
        '
        'Dimentions
        '
        Me.Dimentions.AttachedControl = Me.SuperTabControlPanel1
        Me.Dimentions.GlobalItem = False
        Me.Dimentions.Name = "Dimentions"
        Me.Dimentions.Text = "Dimentions"
        '
        'FournituresBindingSource
        '
        Me.FournituresBindingSource.DataMember = "fournitures"
        Me.FournituresBindingSource.DataSource = Me.MydbDataSet
        '
        'Troncons_fournituresBindingSource
        '
        Me.Troncons_fournituresBindingSource.DataMember = "troncons_fournitures"
        Me.Troncons_fournituresBindingSource.DataSource = Me.MydbDataSet
        '
        'Radio_protectionCheckBox
        '
        Me.Radio_protectionCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.TronconsBindingSource, "radio_protection", True))
        Me.Radio_protectionCheckBox.Location = New System.Drawing.Point(1038, 184)
        Me.Radio_protectionCheckBox.Name = "Radio_protectionCheckBox"
        Me.Radio_protectionCheckBox.Size = New System.Drawing.Size(104, 24)
        Me.Radio_protectionCheckBox.TabIndex = 53
        Me.Radio_protectionCheckBox.UseVisualStyleBackColor = True
        '
        'Coupe_feuCheckBox
        '
        Me.Coupe_feuCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.TronconsBindingSource, "coupe_feu", True))
        Me.Coupe_feuCheckBox.Location = New System.Drawing.Point(1038, 214)
        Me.Coupe_feuCheckBox.Name = "Coupe_feuCheckBox"
        Me.Coupe_feuCheckBox.Size = New System.Drawing.Size(104, 24)
        Me.Coupe_feuCheckBox.TabIndex = 54
        Me.Coupe_feuCheckBox.UseVisualStyleBackColor = True
        '
        'BatimentsBindingSource
        '
        Me.BatimentsBindingSource.DataMember = "batiments"
        Me.BatimentsBindingSource.DataSource = Me.MydbDataSet
        '
        'BatimentsTableAdapter
        '
        Me.BatimentsTableAdapter.ClearBeforeFill = True
        '
        'ComboBoxEx5
        '
        Me.ComboBoxEx5.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.SallesBindingSource, "Batiments_idBatiment", True))
        Me.ComboBoxEx5.DataSource = Me.BatimentsBindingSource
        Me.ComboBoxEx5.DisplayMember = "Nom"
        Me.ComboBoxEx5.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBoxEx5.FormattingEnabled = True
        Me.ComboBoxEx5.ItemHeight = 14
        Me.ComboBoxEx5.Location = New System.Drawing.Point(121, 164)
        Me.ComboBoxEx5.Name = "ComboBoxEx5"
        Me.ComboBoxEx5.Size = New System.Drawing.Size(121, 20)
        Me.ComboBoxEx5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ComboBoxEx5.TabIndex = 11
        Me.ComboBoxEx5.ValueMember = "idBatiment"
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Location = New System.Drawing.Point(15, 160)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(75, 23)
        Me.LabelX4.TabIndex = 10
        Me.LabelX4.Text = "Batiment :"
        '
        'CheckBox1
        '
        Me.CheckBox1.Location = New System.Drawing.Point(248, 220)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(95, 24)
        Me.CheckBox1.TabIndex = 45
        Me.CheckBox1.Text = "Inter-Batiment"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'ComboBoxEx6
        '
        Me.ComboBoxEx6.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.Salle_2bindingSource, "Batiments_idBatiment", True))
        Me.ComboBoxEx6.DataSource = Me.batiment2BindingSource
        Me.ComboBoxEx6.DisplayMember = "Nom"
        Me.ComboBoxEx6.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBoxEx6.FormattingEnabled = True
        Me.ComboBoxEx6.ItemHeight = 14
        Me.ComboBoxEx6.Location = New System.Drawing.Point(440, 223)
        Me.ComboBoxEx6.Name = "ComboBoxEx6"
        Me.ComboBoxEx6.Size = New System.Drawing.Size(121, 20)
        Me.ComboBoxEx6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ComboBoxEx6.TabIndex = 11
        Me.ComboBoxEx6.ValueMember = "idBatiment"
        '
        'batiment2BindingSource
        '
        Me.batiment2BindingSource.DataMember = "batiments"
        Me.batiment2BindingSource.DataSource = Me.MydbDataSet
        '
        'LabelX7
        '
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.Location = New System.Drawing.Point(358, 220)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(75, 23)
        Me.LabelX7.TabIndex = 10
        Me.LabelX7.Text = "Batiment :"
        '
        'Batiments2TableAdapter
        '
        Me.Batiments2TableAdapter.ClearBeforeFill = True
        '
        'RequiredFieldValidator1
        '
        Me.RequiredFieldValidator1.ErrorMessage = "Your error message here."
        Me.RequiredFieldValidator1.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red
        '
        'RequiredFieldValidator13
        '
        Me.RequiredFieldValidator13.ErrorMessage = "Your error message here."
        Me.RequiredFieldValidator13.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red
        '
        'FormTroncon
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1849, 738)
        Me.Controls.Add(Coupe_feuLabel)
        Me.Controls.Add(Me.Coupe_feuCheckBox)
        Me.Controls.Add(Radio_protectionLabel)
        Me.Controls.Add(Me.Radio_protectionCheckBox)
        Me.Controls.Add(Me.SuperTabControl1)
        Me.Controls.Add(Me.LabelX5)
        Me.Controls.Add(Me.DateDateTimePicker)
        Me.Controls.Add(Label3)
        Me.Controls.Add(Me.Masse_TextBoxX1)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.DiscriminationCheckBox)
        Me.Controls.Add(Me.Cables_troncon_idDataGridViewX)
        Me.Controls.Add(DetailmodifLabel)
        Me.Controls.Add(Me.DetailmodifTextBox)
        Me.Controls.Add(ModifLabel)
        Me.Controls.Add(Me.ModifTextBox)
        Me.Controls.Add(Me.LabelX3)
        Me.Controls.Add(Me.Date_calculDateTimePicker)
        Me.Controls.Add(Me.TerminalCheckBox)
        Me.Controls.Add(Me.QuiTextBox)
        Me.Controls.Add(Label1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(QuiLabel)
        Me.Controls.Add(Me.VersionTextBox)
        Me.Controls.Add(VersionLabel)
        Me.Controls.Add(Me.GroupBox)
        Me.Controls.Add(Me.RemarqueTextBox)
        Me.Controls.Add(Me.ButtonX1)
        Me.Controls.Add(Me.Repere_tronconTextBox)
        Me.Controls.Add(Me.VirtuelCheckBox)
        Me.Controls.Add(RemarqueLabel)
        Me.Controls.Add(Me.ComboBoxEx3)
        Me.Controls.Add(Me.FormesComboBox)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.LabelX7)
        Me.Controls.Add(Me.LabelX4)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.ComboBoxEx6)
        Me.Controls.Add(FormesLabel)
        Me.Controls.Add(Me.ComboBoxEx5)
        Me.Controls.Add(Me.ComboBoxEx2)
        Me.Controls.Add(Me.ComboBoxEx1)
        Me.Controls.Add(Me.IdtronconsTextBox)
        Me.Controls.Add(Me.LabelXSegregation)
        Me.Controls.Add(Repere_tronconLabel)
        Me.Controls.Add(Me.TypeComboBox)
        Me.Controls.Add(TypeLabel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Highlighter1.SetHighlightColor(Me, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
        Me.MinimumSize = New System.Drawing.Size(1024, 768)
        Me.Name = "FormTroncon"
        Me.Text = "Tronçon"
        CType(Me.MydbDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TronconsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox.ResumeLayout(False)
        Me.GroupBox.PerformLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cable_details_tronconBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SegregationsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SallesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Salle_2bindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Types_tronconsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BorniersBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cables_troncon_idBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cables_troncon_idDataGridViewX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CablesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SuperTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControl1.ResumeLayout(False)
        Me.SuperTabControlPanel1.ResumeLayout(False)
        Me.SuperTabControlPanel1.PerformLayout()
        CType(Me.DataGridViewX1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Lst_fournitures_trcBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FournituresBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Troncons_fournituresBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BatimentsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.batiment2BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ComboBoxEx1 As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox

    Friend WithEvents TronconsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TronconsTableAdapter As progelec.mydbDataSetTableAdapters.tronconsTableAdapter

    Friend WithEvents ElevationTextBox As System.Windows.Forms.TextBox
    Friend WithEvents HauteurTextBox As System.Windows.Forms.TextBox
    Friend WithEvents LongueurTextBox As System.Windows.Forms.TextBox
    Friend WithEvents LargeurTextBox As System.Windows.Forms.TextBox
    Friend WithEvents SegregationsTableAdapter As progelec.mydbDataSetTableAdapters.segregationsTableAdapter
    Friend WithEvents SegregationsBindingSource As System.Windows.Forms.BindingSource

    Friend WithEvents Repere_tronconTextBox As System.Windows.Forms.TextBox
    Private WithEvents LabelXSegregation As DevComponents.DotNetBar.LabelX
    Friend WithEvents ComboBoxEx2 As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents SallesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReservesTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Reserves2TextBox As System.Windows.Forms.TextBox
    Private WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Private WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ComboBoxEx3 As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Types_tronconsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Types_tronconsTableAdapter As progelec.mydbDataSetTableAdapters.types_tronconsTableAdapter
    Friend WithEvents TypeComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Salle_2bindingSource As System.Windows.Forms.BindingSource
    Private WithEvents GroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents DiametreTextBox As System.Windows.Forms.TextBox
    Friend WithEvents FormesComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Cable_details_tronconBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Cable_details_tronconTableAdapter As progelec.mydbDataSetTableAdapters.cable_details_tronconTableAdapter
    Friend WithEvents IdtronconsTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Cables_troncon_idTableAdapter As progelec.mydbDataSetTableAdapters.cables_troncon_idTableAdapter
    Friend WithEvents RepereCableDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FilsDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SectionDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TypesDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DiametreDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ChargecalorifiqueDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MasseDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Reserve_calTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Reserve2_calTextBox As System.Windows.Forms.TextBox
    Friend WithEvents SuperValidator1 As DevComponents.DotNetBar.Validator.SuperValidator
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Highlighter1 As DevComponents.DotNetBar.Validator.Highlighter
    Friend WithEvents RequiredFieldValidator5 As DevComponents.DotNetBar.Validator.RequiredFieldValidator
    Friend WithEvents RequiredFieldValidator4 As DevComponents.DotNetBar.Validator.RequiredFieldValidator
    Friend WithEvents RequiredFieldValidator3 As DevComponents.DotNetBar.Validator.RequiredFieldValidator
    Friend WithEvents RequiredFieldValidator2 As DevComponents.DotNetBar.Validator.RequiredFieldValidator
    Friend WithEvents VirtuelCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents MydbDataSet As progelec.mydbDataSet
    Friend WithEvents BorniersBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TableAdapterManager As progelec.mydbDataSetTableAdapters.TableAdapterManager
    '  Friend WithEvents Types_tronconsTableAdapter As progelec.mydbDataSetTableAdapters.types_tronconsTableAdapter
    Friend WithEvents Salle_2TableAdapter1 As progelec.mydbDataSetTableAdapters.sallesTableAdapter
    ' Friend WithEvents Cable_details_tronconTableAdapter As progelec.mydbDataSetTableAdapters.cable_details_tronconTableAdapter
    ' Friend WithEvents SegregationsTableAdapter As progelec.mydbDataSetTableAdapters.segregationsTableAdapter
    ' Friend WithEvents TronconsTableAdapter As progelec.mydbDataSetTableAdapters.tronconsTableAdapter
    Friend WithEvents SallesTableAdapter As progelec.mydbDataSetTableAdapters.sallesTableAdapter
    'Friend WithEvents Cables_troncon_idTableAdapter As progelec.mydbDataSetTableAdapters.cable_details_tronconTableAdapter
    Friend WithEvents BorniersTableAdapter As progelec.mydbDataSetTableAdapters.sallesTableAdapter
    Friend WithEvents RemarqueTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents RequiredFieldValidator6 As DevComponents.DotNetBar.Validator.RequiredFieldValidator
    Friend WithEvents RequiredFieldValidator7 As DevComponents.DotNetBar.Validator.RequiredFieldValidator
    Friend WithEvents RequiredFieldValidator8 As DevComponents.DotNetBar.Validator.RequiredFieldValidator
    Friend WithEvents VersionTextBox As System.Windows.Forms.TextBox
    Friend WithEvents QuiTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TerminalCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents Date_calculDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ModifTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Cables_detailsTableAdapter As progelec.mydbDataSetTableAdapters.cables_detailsTableAdapter
    Friend WithEvents DetailmodifTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Cables_troncon_idBindingSource As System.Windows.Forms.BindingSource
    '   Friend WithEvents Cables_troncon_idTableAdapter As progelec.mydbDataSetTableAdapters.cables_troncon_idTableAdapter
    Friend WithEvents Cables_troncon_idDataGridViewX As DevComponents.DotNetBar.Controls.DataGridViewX
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
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn2 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn3 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn4 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DiscriminationCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents Remplissage3RadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents Remplissage2RadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents RemplissageRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents RequiredFieldValidator9 As DevComponents.DotNetBar.Validator.RequiredFieldValidator
    Friend WithEvents RequiredFieldValidator10 As DevComponents.DotNetBar.Validator.RequiredFieldValidator
    Friend WithEvents RequiredFieldValidator12 As DevComponents.DotNetBar.Validator.RequiredFieldValidator
    Friend WithEvents RequiredFieldValidator11 As DevComponents.DotNetBar.Validator.RequiredFieldValidator
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Reserve_lotTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Masse_TextBoxX1 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents DateDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents CablesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CablesTableAdapter As progelec.mydbDataSetTableAdapters.cablesTableAdapter
    Friend WithEvents SuperTabControl1 As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents ButtonX3 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX2 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents SuperTabControlPanel1 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents Dimentions As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents Lst_fournitures_trcBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Lst_fournitures_trcTableAdapter As progelec.mydbDataSetTableAdapters.lst_fournitures_trcTableAdapter
    Friend WithEvents DataGridViewX1 As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents FournituresBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents FournituresTableAdapter As progelec.mydbDataSetTableAdapters.fournituresTableAdapter
    Friend WithEvents ComboBoxEx4 As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents CheckBoxX1 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Troncons_fournituresBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Troncons_fournituresTableAdapter As progelec.mydbDataSetTableAdapters.troncons_fournituresTableAdapter
    Friend WithEvents IdtronconsfournitureDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents quant As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TronconDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CategorieDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FournitureDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdfournitureDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DesignationDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantminDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FournisseurDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UniteeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents Coupe_feuCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents Radio_protectionCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents BatimentsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents BatimentsTableAdapter As progelec.mydbDataSetTableAdapters.batimentsTableAdapter
    Private WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ComboBoxEx5 As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Private WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ComboBoxEx6 As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Batiments2TableAdapter As progelec.mydbDataSetTableAdapters.batimentsTableAdapter
    Friend WithEvents batiment2BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents RequiredFieldValidator1 As DevComponents.DotNetBar.Validator.RequiredFieldValidator
    Friend WithEvents RequiredFieldValidator13 As DevComponents.DotNetBar.Validator.RequiredFieldValidator
End Class
