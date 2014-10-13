<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormModification
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
        Dim IdModifLabel As System.Windows.Forms.Label
        Dim ReferenceLabel As System.Windows.Forms.Label
        Dim ModifcolLabel As System.Windows.Forms.Label
        Dim ModifType_idModifTypeLabel As System.Windows.Forms.Label
        Dim ModifOrigine_idModifOrigineLabel As System.Windows.Forms.Label
        Dim RevModif_idRevModifLabel As System.Windows.Forms.Label
        Dim IdModifDetailLabel As System.Windows.Forms.Label
        Dim DateLabel As System.Windows.Forms.Label
        Dim QuiLabel As System.Windows.Forms.Label
        Dim FaitLabel As System.Windows.Forms.Label
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
        Dim DetailLabel As System.Windows.Forms.Label
        Dim ActionLabel As System.Windows.Forms.Label
        Me.SuperTabControl1 = New DevComponents.DotNetBar.SuperTabControl()
        Me.SuperTabControlPanel1 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.ButtonX6 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX5 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX4 = New DevComponents.DotNetBar.ButtonX()
        Me.IdModifDetailTextBox = New System.Windows.Forms.TextBox()
        Me.ModifdetailBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MydbDataSet = New progelec.mydbDataSet()
        Me.DateDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.QuiTextBox = New System.Windows.Forms.TextBox()
        Me.FaitCheckBox = New System.Windows.Forms.CheckBox()
        Me.SuperGridControl1 = New DevComponents.DotNetBar.SuperGrid.SuperGridControl()
        Me.SuperTabItem1 = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel4 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.SuperTabItem4 = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel3 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.SuperTabItem3 = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel2 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.SuperTabItem2 = New DevComponents.DotNetBar.SuperTabItem()
        Me.IdModifTextBox = New System.Windows.Forms.TextBox()
        Me.ReferenceTextBox = New System.Windows.Forms.TextBox()
        Me.ModifcolTextBox = New System.Windows.Forms.TextBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.ModifBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ModiforigineBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.ModiforigineTableAdapter = New progelec.mydbDataSetTableAdapters.modiforigineTableAdapter()
        Me.ModifTableAdapter = New progelec.mydbDataSetTableAdapters.modifTableAdapter()
        Me.TableAdapterManager = New progelec.mydbDataSetTableAdapters.TableAdapterManager()
        Me.ModifdetailTableAdapter = New progelec.mydbDataSetTableAdapters.modifdetailTableAdapter()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.ModiftypeBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ModiftypeTableAdapter = New progelec.mydbDataSetTableAdapters.modiftypeTableAdapter()
        Me.ComboBox3 = New System.Windows.Forms.ComboBox()
        Me.ModifrevBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ModifrevTableAdapter = New progelec.mydbDataSetTableAdapters.modifrevTableAdapter()
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX2 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX3 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX7 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX8 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX9 = New DevComponents.DotNetBar.ButtonX()
        Me.DetailTextBox = New System.Windows.Forms.TextBox()
        Me.ActionTextBox = New System.Windows.Forms.TextBox()
        IdModifLabel = New System.Windows.Forms.Label()
        ReferenceLabel = New System.Windows.Forms.Label()
        ModifcolLabel = New System.Windows.Forms.Label()
        ModifType_idModifTypeLabel = New System.Windows.Forms.Label()
        ModifOrigine_idModifOrigineLabel = New System.Windows.Forms.Label()
        RevModif_idRevModifLabel = New System.Windows.Forms.Label()
        IdModifDetailLabel = New System.Windows.Forms.Label()
        DateLabel = New System.Windows.Forms.Label()
        QuiLabel = New System.Windows.Forms.Label()
        FaitLabel = New System.Windows.Forms.Label()
        DetailLabel = New System.Windows.Forms.Label()
        ActionLabel = New System.Windows.Forms.Label()
        CType(Me.SuperTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControl1.SuspendLayout()
        Me.SuperTabControlPanel1.SuspendLayout()
        CType(Me.ModifdetailBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MydbDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ModifBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ModiforigineBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ModiftypeBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ModifrevBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'IdModifLabel
        '
        IdModifLabel.AutoSize = True
        IdModifLabel.Location = New System.Drawing.Point(56, 49)
        IdModifLabel.Name = "IdModifLabel"
        IdModifLabel.Size = New System.Drawing.Size(47, 13)
        IdModifLabel.TabIndex = 1
        IdModifLabel.Text = "id Modif:"
        IdModifLabel.Visible = False
        '
        'ReferenceLabel
        '
        ReferenceLabel.AutoSize = True
        ReferenceLabel.Location = New System.Drawing.Point(539, 49)
        ReferenceLabel.Name = "ReferenceLabel"
        ReferenceLabel.Size = New System.Drawing.Size(60, 13)
        ReferenceLabel.TabIndex = 3
        ReferenceLabel.Text = "Reference:"
        '
        'ModifcolLabel
        '
        ModifcolLabel.AutoSize = True
        ModifcolLabel.Location = New System.Drawing.Point(56, 97)
        ModifcolLabel.Name = "ModifcolLabel"
        ModifcolLabel.Size = New System.Drawing.Size(100, 13)
        ModifcolLabel.TabIndex = 5
        ModifcolLabel.Text = "Detail Modification :"
        '
        'ModifType_idModifTypeLabel
        '
        ModifType_idModifTypeLabel.AutoSize = True
        ModifType_idModifTypeLabel.Location = New System.Drawing.Point(362, 49)
        ModifType_idModifTypeLabel.Name = "ModifType_idModifTypeLabel"
        ModifType_idModifTypeLabel.Size = New System.Drawing.Size(34, 13)
        ModifType_idModifTypeLabel.TabIndex = 7
        ModifType_idModifTypeLabel.Text = "Type:"
        '
        'ModifOrigine_idModifOrigineLabel
        '
        ModifOrigine_idModifOrigineLabel.AutoSize = True
        ModifOrigine_idModifOrigineLabel.Location = New System.Drawing.Point(183, 49)
        ModifOrigine_idModifOrigineLabel.Name = "ModifOrigine_idModifOrigineLabel"
        ModifOrigine_idModifOrigineLabel.Size = New System.Drawing.Size(43, 13)
        ModifOrigine_idModifOrigineLabel.TabIndex = 9
        ModifOrigine_idModifOrigineLabel.Text = "Origine:"
        '
        'RevModif_idRevModifLabel
        '
        RevModif_idRevModifLabel.AutoSize = True
        RevModif_idRevModifLabel.Location = New System.Drawing.Point(676, 49)
        RevModif_idRevModifLabel.Name = "RevModif_idRevModifLabel"
        RevModif_idRevModifLabel.Size = New System.Drawing.Size(33, 13)
        RevModif_idRevModifLabel.TabIndex = 11
        RevModif_idRevModifLabel.Text = "Rev :"
        '
        'IdModifDetailLabel
        '
        IdModifDetailLabel.AutoSize = True
        IdModifDetailLabel.Location = New System.Drawing.Point(801, 53)
        IdModifDetailLabel.Name = "IdModifDetailLabel"
        IdModifDetailLabel.Size = New System.Drawing.Size(77, 13)
        IdModifDetailLabel.TabIndex = 1
        IdModifDetailLabel.Text = "id Modif Detail:"
        '
        'DateLabel
        '
        DateLabel.AutoSize = True
        DateLabel.Location = New System.Drawing.Point(801, 210)
        DateLabel.Name = "DateLabel"
        DateLabel.Size = New System.Drawing.Size(33, 13)
        DateLabel.TabIndex = 13
        DateLabel.Text = "Date:"
        '
        'QuiLabel
        '
        QuiLabel.AutoSize = True
        QuiLabel.Location = New System.Drawing.Point(801, 183)
        QuiLabel.Name = "QuiLabel"
        QuiLabel.Size = New System.Drawing.Size(26, 13)
        QuiLabel.TabIndex = 15
        QuiLabel.Text = "Qui:"
        '
        'FaitLabel
        '
        FaitLabel.AutoSize = True
        FaitLabel.Location = New System.Drawing.Point(801, 155)
        FaitLabel.Name = "FaitLabel"
        FaitLabel.Size = New System.Drawing.Size(27, 13)
        FaitLabel.TabIndex = 17
        FaitLabel.Text = "Fait:"
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
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel4)
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel3)
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel2)
        Me.SuperTabControl1.Location = New System.Drawing.Point(12, 267)
        Me.SuperTabControl1.Name = "SuperTabControl1"
        Me.SuperTabControl1.ReorderTabsEnabled = True
        Me.SuperTabControl1.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.SuperTabControl1.SelectedTabIndex = 3
        Me.SuperTabControl1.Size = New System.Drawing.Size(1219, 409)
        Me.SuperTabControl1.TabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SuperTabControl1.TabIndex = 1
        Me.SuperTabControl1.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabItem1, Me.SuperTabItem2, Me.SuperTabItem3, Me.SuperTabItem4})
        Me.SuperTabControl1.Text = "SuperTabControl1"
        '
        'SuperTabControlPanel1
        '
        Me.SuperTabControlPanel1.AutoScroll = True
        Me.SuperTabControlPanel1.Controls.Add(ActionLabel)
        Me.SuperTabControlPanel1.Controls.Add(Me.ActionTextBox)
        Me.SuperTabControlPanel1.Controls.Add(DetailLabel)
        Me.SuperTabControlPanel1.Controls.Add(Me.DetailTextBox)
        Me.SuperTabControlPanel1.Controls.Add(Me.ButtonX6)
        Me.SuperTabControlPanel1.Controls.Add(Me.ButtonX5)
        Me.SuperTabControlPanel1.Controls.Add(IdModifDetailLabel)
        Me.SuperTabControlPanel1.Controls.Add(Me.ButtonX4)
        Me.SuperTabControlPanel1.Controls.Add(Me.IdModifDetailTextBox)
        Me.SuperTabControlPanel1.Controls.Add(DateLabel)
        Me.SuperTabControlPanel1.Controls.Add(Me.DateDateTimePicker)
        Me.SuperTabControlPanel1.Controls.Add(QuiLabel)
        Me.SuperTabControlPanel1.Controls.Add(Me.QuiTextBox)
        Me.SuperTabControlPanel1.Controls.Add(FaitLabel)
        Me.SuperTabControlPanel1.Controls.Add(Me.FaitCheckBox)
        Me.SuperTabControlPanel1.Controls.Add(Me.SuperGridControl1)
        Me.SuperTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel1.Location = New System.Drawing.Point(0, 25)
        Me.SuperTabControlPanel1.Name = "SuperTabControlPanel1"
        Me.SuperTabControlPanel1.Size = New System.Drawing.Size(1219, 384)
        Me.SuperTabControlPanel1.TabIndex = 1
        Me.SuperTabControlPanel1.TabItem = Me.SuperTabItem1
        '
        'ButtonX6
        '
        Me.ButtonX6.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX6.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX6.Location = New System.Drawing.Point(1125, 341)
        Me.ButtonX6.Name = "ButtonX6"
        Me.ButtonX6.Size = New System.Drawing.Size(75, 23)
        Me.ButtonX6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX6.TabIndex = 24
        Me.ButtonX6.Text = "Supression"
        '
        'ButtonX5
        '
        Me.ButtonX5.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX5.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX5.Location = New System.Drawing.Point(1125, 312)
        Me.ButtonX5.Name = "ButtonX5"
        Me.ButtonX5.Size = New System.Drawing.Size(75, 23)
        Me.ButtonX5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX5.TabIndex = 23
        Me.ButtonX5.Text = "Enregistrement"
        '
        'ButtonX4
        '
        Me.ButtonX4.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX4.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX4.Location = New System.Drawing.Point(1125, 283)
        Me.ButtonX4.Name = "ButtonX4"
        Me.ButtonX4.Size = New System.Drawing.Size(75, 23)
        Me.ButtonX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX4.TabIndex = 22
        Me.ButtonX4.Text = "Ajout"
        '
        'IdModifDetailTextBox
        '
        Me.IdModifDetailTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ModifdetailBindingSource, "idModifDetail", True))
        Me.IdModifDetailTextBox.Location = New System.Drawing.Point(903, 48)
        Me.IdModifDetailTextBox.Name = "IdModifDetailTextBox"
        Me.IdModifDetailTextBox.Size = New System.Drawing.Size(200, 20)
        Me.IdModifDetailTextBox.TabIndex = 2
        '
        'ModifdetailBindingSource
        '
        Me.ModifdetailBindingSource.DataMember = "modifdetail"
        Me.ModifdetailBindingSource.DataSource = Me.MydbDataSet
        '
        'MydbDataSet
        '
        Me.MydbDataSet.DataSetName = "mydbDataSet"
        Me.MydbDataSet.EnforceConstraints = False
        Me.MydbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'DateDateTimePicker
        '
        Me.DateDateTimePicker.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.ModifdetailBindingSource, "Date", True))
        Me.DateDateTimePicker.Location = New System.Drawing.Point(903, 204)
        Me.DateDateTimePicker.Name = "DateDateTimePicker"
        Me.DateDateTimePicker.Size = New System.Drawing.Size(200, 20)
        Me.DateDateTimePicker.TabIndex = 14
        '
        'QuiTextBox
        '
        Me.QuiTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ModifdetailBindingSource, "Qui", True))
        Me.QuiTextBox.Location = New System.Drawing.Point(903, 178)
        Me.QuiTextBox.Name = "QuiTextBox"
        Me.QuiTextBox.Size = New System.Drawing.Size(200, 20)
        Me.QuiTextBox.TabIndex = 16
        '
        'FaitCheckBox
        '
        Me.FaitCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.ModifdetailBindingSource, "Fait", True))
        Me.FaitCheckBox.Location = New System.Drawing.Point(903, 148)
        Me.FaitCheckBox.Name = "FaitCheckBox"
        Me.FaitCheckBox.Size = New System.Drawing.Size(200, 24)
        Me.FaitCheckBox.TabIndex = 18
        Me.FaitCheckBox.Text = "CheckBox1"
        Me.FaitCheckBox.UseVisualStyleBackColor = True
        '
        'SuperGridControl1
        '
        Me.SuperGridControl1.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed
        Me.SuperGridControl1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.SuperGridControl1.Location = New System.Drawing.Point(14, 3)
        Me.SuperGridControl1.Name = "SuperGridControl1"
        GridColumn1.DataPropertyName = "idModifDetail"
        GridColumn1.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridIntegerInputEditControl)
        GridColumn1.HeaderText = "idModifDetail"
        GridColumn1.Name = "idModifDetail"
        GridColumn2.DataPropertyName = "Modif_idModif"
        GridColumn2.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridIntegerInputEditControl)
        GridColumn2.HeaderText = "Modif_idModif"
        GridColumn2.Name = "Modif_idModif"
        GridColumn2.Visible = False
        GridColumn3.DataPropertyName = "Modif_ModifType_idModifType"
        GridColumn3.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridIntegerInputEditControl)
        GridColumn3.HeaderText = "Modif_ModifType_idModifType"
        GridColumn3.Name = "Modif_ModifType_idModifType"
        GridColumn3.Visible = False
        GridColumn4.DataPropertyName = "Modif_ModifOrigine_idModifOrigine"
        GridColumn4.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridIntegerInputEditControl)
        GridColumn4.HeaderText = "Modif_ModifOrigine_idModifOrigine"
        GridColumn4.Name = "Modif_ModifOrigine_idModifOrigine"
        GridColumn4.Visible = False
        GridColumn5.DataPropertyName = "Modif_RevModif_idRevModif"
        GridColumn5.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridIntegerInputEditControl)
        GridColumn5.HeaderText = "Modif_RevModif_idRevModif"
        GridColumn5.Name = "Modif_RevModif_idRevModif"
        GridColumn5.Visible = False
        GridColumn6.DataPropertyName = "RevBase_idRevBase"
        GridColumn6.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridIntegerInputEditControl)
        GridColumn6.HeaderText = "RevBase_idRevBase"
        GridColumn6.Name = "RevBase_idRevBase"
        GridColumn6.Visible = False
        GridColumn7.DataPropertyName = "action"
        GridColumn7.HeaderText = "action"
        GridColumn7.Name = "action"
        GridColumn8.DataPropertyName = "detail"
        GridColumn8.HeaderText = "detail"
        GridColumn8.Name = "detail"
        GridColumn9.DataPropertyName = "Fait"
        GridColumn9.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridCheckBoxXEditControl)
        GridColumn9.HeaderText = "Fait"
        GridColumn9.Name = "Fait"
        GridColumn10.DataPropertyName = "Qui"
        GridColumn10.HeaderText = "Qui"
        GridColumn10.Name = "Qui"
        GridColumn11.DataPropertyName = "Date"
        GridColumn11.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridDateTimeInputEditControl)
        GridColumn11.HeaderText = "Date"
        GridColumn11.Name = "Date"
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
        Me.SuperGridControl1.PrimaryGrid.DataSource = Me.ModifdetailBindingSource
        Me.SuperGridControl1.Size = New System.Drawing.Size(649, 378)
        Me.SuperGridControl1.TabIndex = 0
        Me.SuperGridControl1.Text = "SuperGridControl1"
        '
        'SuperTabItem1
        '
        Me.SuperTabItem1.AttachedControl = Me.SuperTabControlPanel1
        Me.SuperTabItem1.GlobalItem = False
        Me.SuperTabItem1.Name = "SuperTabItem1"
        Me.SuperTabItem1.Text = "Actions Etudes necessaires"
        '
        'SuperTabControlPanel4
        '
        Me.SuperTabControlPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel4.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel4.Name = "SuperTabControlPanel4"
        Me.SuperTabControlPanel4.Size = New System.Drawing.Size(1219, 409)
        Me.SuperTabControlPanel4.TabIndex = 0
        Me.SuperTabControlPanel4.TabItem = Me.SuperTabItem4
        '
        'SuperTabItem4
        '
        Me.SuperTabItem4.AttachedControl = Me.SuperTabControlPanel4
        Me.SuperTabItem4.GlobalItem = False
        Me.SuperTabItem4.Name = "SuperTabItem4"
        Me.SuperTabItem4.Text = "Budget"
        '
        'SuperTabControlPanel3
        '
        Me.SuperTabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel3.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel3.Name = "SuperTabControlPanel3"
        Me.SuperTabControlPanel3.Size = New System.Drawing.Size(1219, 409)
        Me.SuperTabControlPanel3.TabIndex = 0
        Me.SuperTabControlPanel3.TabItem = Me.SuperTabItem3
        '
        'SuperTabItem3
        '
        Me.SuperTabItem3.AttachedControl = Me.SuperTabControlPanel3
        Me.SuperTabItem3.GlobalItem = False
        Me.SuperTabItem3.Name = "SuperTabItem3"
        Me.SuperTabItem3.Text = "Actions Chantier"
        '
        'SuperTabControlPanel2
        '
        Me.SuperTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel2.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel2.Name = "SuperTabControlPanel2"
        Me.SuperTabControlPanel2.Size = New System.Drawing.Size(1219, 409)
        Me.SuperTabControlPanel2.TabIndex = 0
        Me.SuperTabControlPanel2.TabItem = Me.SuperTabItem2
        '
        'SuperTabItem2
        '
        Me.SuperTabItem2.AttachedControl = Me.SuperTabControlPanel2
        Me.SuperTabItem2.GlobalItem = False
        Me.SuperTabItem2.Name = "SuperTabItem2"
        Me.SuperTabItem2.Text = "Fournitures suivi"
        '
        'IdModifTextBox
        '
        Me.IdModifTextBox.Location = New System.Drawing.Point(59, 65)
        Me.IdModifTextBox.Name = "IdModifTextBox"
        Me.IdModifTextBox.Size = New System.Drawing.Size(100, 20)
        Me.IdModifTextBox.TabIndex = 2
        Me.IdModifTextBox.Visible = False
        '
        'ReferenceTextBox
        '
        Me.ReferenceTextBox.Location = New System.Drawing.Point(542, 65)
        Me.ReferenceTextBox.Name = "ReferenceTextBox"
        Me.ReferenceTextBox.Size = New System.Drawing.Size(100, 20)
        Me.ReferenceTextBox.TabIndex = 4
        '
        'ModifcolTextBox
        '
        Me.ModifcolTextBox.Location = New System.Drawing.Point(160, 97)
        Me.ModifcolTextBox.Multiline = True
        Me.ModifcolTextBox.Name = "ModifcolTextBox"
        Me.ModifcolTextBox.Size = New System.Drawing.Size(624, 125)
        Me.ModifcolTextBox.TabIndex = 6
        '
        'ComboBox1
        '
        Me.ComboBox1.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.ModifBindingSource, "ModifOrigine_idModifOrigine", True))
        Me.ComboBox1.DataSource = Me.ModiforigineBindingSource1
        Me.ComboBox1.DisplayMember = "ORIGINE"
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(183, 64)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox1.TabIndex = 13
        '
        'ModifBindingSource
        '
        Me.ModifBindingSource.DataMember = "modif"
        Me.ModifBindingSource.DataSource = Me.MydbDataSet
        '
        'ModiforigineBindingSource1
        '
        Me.ModiforigineBindingSource1.DataMember = "modiforigine"
        Me.ModiforigineBindingSource1.DataSource = Me.MydbDataSet
        '
        'ModiforigineTableAdapter
        '
        Me.ModiforigineTableAdapter.ClearBeforeFill = True
        '
        'ModifTableAdapter
        '
        Me.ModifTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.borniersTableAdapter = Nothing
        Me.TableAdapterManager.cables_detailsTableAdapter = Nothing
        Me.TableAdapterManager.cablesTableAdapter = Nothing
        Me.TableAdapterManager.categoriesTableAdapter = Nothing
        Me.TableAdapterManager.departsTableAdapter = Nothing
        Me.TableAdapterManager.doc_referenceTableAdapter = Nothing
        Me.TableAdapterManager.donnees_cablesTableAdapter = Nothing
        Me.TableAdapterManager.editionsTableAdapter = Nothing
        Me.TableAdapterManager.equipementsTableAdapter = Nothing
        Me.TableAdapterManager.lotsTableAdapter = Nothing
        Me.TableAdapterManager.modifdetailTableAdapter = Me.ModifdetailTableAdapter
        Me.TableAdapterManager.modiforigineTableAdapter = Me.ModiforigineTableAdapter
        Me.TableAdapterManager.modifrevTableAdapter = Nothing
        Me.TableAdapterManager.modifTableAdapter = Me.ModifTableAdapter
        Me.TableAdapterManager.modiftypeTableAdapter = Nothing
        Me.TableAdapterManager.parcours_detailTableAdapter = Nothing
        Me.TableAdapterManager.parcoursTableAdapter = Nothing
        Me.TableAdapterManager.revbaseTableAdapter = Nothing
        Me.TableAdapterManager.revisionTableAdapter = Nothing
        Me.TableAdapterManager.sallesTableAdapter = Nothing
        Me.TableAdapterManager.sections_cablesTableAdapter = Nothing
        Me.TableAdapterManager.segregationsTableAdapter = Nothing
        Me.TableAdapterManager.troncons_assocTableAdapter = Nothing
        Me.TableAdapterManager.tronconsTableAdapter = Nothing
        Me.TableAdapterManager.type_docTableAdapter = Nothing
        Me.TableAdapterManager.types_cableTableAdapter = Nothing
        Me.TableAdapterManager.types_tronconsTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = progelec.mydbDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'ModifdetailTableAdapter
        '
        Me.ModifdetailTableAdapter.ClearBeforeFill = True
        '
        'ComboBox2
        '
        Me.ComboBox2.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.ModifBindingSource, "ModifType_idModifType", True))
        Me.ComboBox2.DataSource = Me.ModiftypeBindingSource
        Me.ComboBox2.DisplayMember = "ModifTypecol"
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(362, 65)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox2.TabIndex = 15
        '
        'ModiftypeBindingSource
        '
        Me.ModiftypeBindingSource.DataMember = "modiftype"
        Me.ModiftypeBindingSource.DataSource = Me.MydbDataSet
        '
        'ModiftypeTableAdapter
        '
        Me.ModiftypeTableAdapter.ClearBeforeFill = True
        '
        'ComboBox3
        '
        Me.ComboBox3.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.ModifBindingSource, "RevModif_idRevModif", True))
        Me.ComboBox3.DataSource = Me.ModifrevBindingSource
        Me.ComboBox3.DisplayMember = "Indice"
        Me.ComboBox3.FormattingEnabled = True
        Me.ComboBox3.Location = New System.Drawing.Point(665, 64)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(63, 21)
        Me.ComboBox3.TabIndex = 17
        '
        'ModifrevBindingSource
        '
        Me.ModifrevBindingSource.DataMember = "modifrev"
        Me.ModifrevBindingSource.DataSource = Me.MydbDataSet
        '
        'ModifrevTableAdapter
        '
        Me.ModifrevTableAdapter.ClearBeforeFill = True
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX1.Location = New System.Drawing.Point(310, 63)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Size = New System.Drawing.Size(46, 23)
        Me.ButtonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX1.TabIndex = 19
        Me.ButtonX1.Text = "Add"
        '
        'ButtonX2
        '
        Me.ButtonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX2.Location = New System.Drawing.Point(489, 64)
        Me.ButtonX2.Name = "ButtonX2"
        Me.ButtonX2.Size = New System.Drawing.Size(47, 23)
        Me.ButtonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX2.TabIndex = 20
        Me.ButtonX2.Text = "Add"
        '
        'ButtonX3
        '
        Me.ButtonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX3.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX3.Location = New System.Drawing.Point(735, 63)
        Me.ButtonX3.Name = "ButtonX3"
        Me.ButtonX3.Size = New System.Drawing.Size(49, 23)
        Me.ButtonX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX3.TabIndex = 21
        Me.ButtonX3.Text = "Add"
        '
        'ButtonX7
        '
        Me.ButtonX7.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX7.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX7.Location = New System.Drawing.Point(1018, 102)
        Me.ButtonX7.Name = "ButtonX7"
        Me.ButtonX7.Size = New System.Drawing.Size(71, 23)
        Me.ButtonX7.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX7.TabIndex = 22
        Me.ButtonX7.Text = "Nouvelle"
        '
        'ButtonX8
        '
        Me.ButtonX8.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX8.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX8.Location = New System.Drawing.Point(1018, 143)
        Me.ButtonX8.Name = "ButtonX8"
        Me.ButtonX8.Size = New System.Drawing.Size(71, 23)
        Me.ButtonX8.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX8.TabIndex = 23
        Me.ButtonX8.Text = "Modification"
        '
        'ButtonX9
        '
        Me.ButtonX9.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX9.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX9.Location = New System.Drawing.Point(1018, 185)
        Me.ButtonX9.Name = "ButtonX9"
        Me.ButtonX9.Size = New System.Drawing.Size(71, 23)
        Me.ButtonX9.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX9.TabIndex = 24
        Me.ButtonX9.Text = "Cloture"
        '
        'DetailLabel
        '
        DetailLabel.AutoSize = True
        DetailLabel.Location = New System.Drawing.Point(801, 104)
        DetailLabel.Name = "DetailLabel"
        DetailLabel.Size = New System.Drawing.Size(35, 13)
        DetailLabel.TabIndex = 24
        DetailLabel.Text = "detail:"
        '
        'DetailTextBox
        '
        Me.DetailTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ModifdetailBindingSource, "detail", True))
        Me.DetailTextBox.Location = New System.Drawing.Point(903, 101)
        Me.DetailTextBox.Name = "DetailTextBox"
        Me.DetailTextBox.Size = New System.Drawing.Size(200, 20)
        Me.DetailTextBox.TabIndex = 25
        '
        'ActionLabel
        '
        ActionLabel.AutoSize = True
        ActionLabel.Location = New System.Drawing.Point(797, 78)
        ActionLabel.Name = "ActionLabel"
        ActionLabel.Size = New System.Drawing.Size(39, 13)
        ActionLabel.TabIndex = 25
        ActionLabel.Text = "action:"
        '
        'ActionTextBox
        '
        Me.ActionTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ModifdetailBindingSource, "action", True))
        Me.ActionTextBox.Location = New System.Drawing.Point(903, 75)
        Me.ActionTextBox.Name = "ActionTextBox"
        Me.ActionTextBox.Size = New System.Drawing.Size(200, 20)
        Me.ActionTextBox.TabIndex = 26
        '
        'FormModification
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1261, 696)
        Me.Controls.Add(Me.ButtonX9)
        Me.Controls.Add(Me.ButtonX8)
        Me.Controls.Add(Me.ButtonX7)
        Me.Controls.Add(Me.ButtonX3)
        Me.Controls.Add(Me.ButtonX2)
        Me.Controls.Add(Me.ButtonX1)
        Me.Controls.Add(Me.ComboBox3)
        Me.Controls.Add(Me.ComboBox2)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(IdModifLabel)
        Me.Controls.Add(Me.IdModifTextBox)
        Me.Controls.Add(ReferenceLabel)
        Me.Controls.Add(Me.ReferenceTextBox)
        Me.Controls.Add(ModifcolLabel)
        Me.Controls.Add(Me.ModifcolTextBox)
        Me.Controls.Add(ModifType_idModifTypeLabel)
        Me.Controls.Add(ModifOrigine_idModifOrigineLabel)
        Me.Controls.Add(RevModif_idRevModifLabel)
        Me.Controls.Add(Me.SuperTabControl1)
        Me.DoubleBuffered = True
        Me.Name = "FormModification"
        Me.Text = "FormModification"
        CType(Me.SuperTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControl1.ResumeLayout(False)
        Me.SuperTabControlPanel1.ResumeLayout(False)
        Me.SuperTabControlPanel1.PerformLayout()
        CType(Me.ModifdetailBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MydbDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ModifBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ModiforigineBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ModiftypeBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ModifrevBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SuperTabControl1 As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents SuperTabControlPanel4 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents MydbDataSet As progelec.mydbDataSet
    Friend WithEvents SuperTabItem4 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel3 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SuperTabItem3 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel2 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SuperTabItem2 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel1 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SuperTabItem1 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents IdModifTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ReferenceTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ModifcolTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents ModiforigineTableAdapter As progelec.mydbDataSetTableAdapters.modiforigineTableAdapter
    Friend WithEvents ModifBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ModifTableAdapter As progelec.mydbDataSetTableAdapters.modifTableAdapter
    Friend WithEvents TableAdapterManager As progelec.mydbDataSetTableAdapters.TableAdapterManager
    Friend WithEvents ModifdetailTableAdapter As progelec.mydbDataSetTableAdapters.modifdetailTableAdapter
    Friend WithEvents ModifdetailBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ModiforigineBindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents ModiftypeBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ModiftypeTableAdapter As progelec.mydbDataSetTableAdapters.modiftypeTableAdapter
    Friend WithEvents ComboBox3 As System.Windows.Forms.ComboBox
    Friend WithEvents IdModifDetailTextBox As System.Windows.Forms.TextBox
    Friend WithEvents DateDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents QuiTextBox As System.Windows.Forms.TextBox
    Friend WithEvents FaitCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents SuperGridControl1 As DevComponents.DotNetBar.SuperGrid.SuperGridControl
    Friend WithEvents ModifrevBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ModifrevTableAdapter As progelec.mydbDataSetTableAdapters.modifrevTableAdapter
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX2 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX3 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX4 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX5 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX6 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX7 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX8 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX9 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ActionTextBox As System.Windows.Forms.TextBox
    Friend WithEvents DetailTextBox As System.Windows.Forms.TextBox
End Class
