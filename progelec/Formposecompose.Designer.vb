<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Formposecompose
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
        Dim QuantLabel As System.Windows.Forms.Label
        Dim Date_poseLabel As System.Windows.Forms.Label
        Dim Quant_poseLabel As System.Windows.Forms.Label
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Formposecompose))
        Me.QuantTextBox = New System.Windows.Forms.TextBox()
        Me.Date_poseDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.Quant_poseTextBox = New System.Windows.Forms.TextBox()
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.DataGridViewX1 = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.SuperValidator1 = New DevComponents.DotNetBar.Validator.SuperValidator()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Highlighter1 = New DevComponents.DotNetBar.Validator.Highlighter()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.ButtonX2 = New DevComponents.DotNetBar.ButtonX()
        Me.Lst_article_equipBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MydbDataSet = New progelec.MydbDataSet()
        Me.Equipements_has_fournituresBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.FournituresBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.FournituresTableAdapter = New progelec.MydbDataSetTableAdapters.fournituresTableAdapter()
        Me.TableAdapterManager = New progelec.MydbDataSetTableAdapters.TableAdapterManager()
        Me.Equipements_has_fournituresTableAdapter = New progelec.MydbDataSetTableAdapters.equipements_has_fournituresTableAdapter()
        Me.Lst_article_equipTableAdapter = New progelec.MydbDataSetTableAdapters.lst_article_equipTableAdapter()
        Me.EquipementsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EquipementsTableAdapter = New progelec.MydbDataSetTableAdapters.equipementsTableAdapter()
        Me.Equip_pose_articleBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Equip_pose_articleTableAdapter = New progelec.MydbDataSetTableAdapters.equip_pose_articleTableAdapter()
        Me.IdequipementDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DesignationDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QuantDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalposeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdfournitureDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Temp1DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Temp2DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AvancementDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        QuantLabel = New System.Windows.Forms.Label()
        Date_poseLabel = New System.Windows.Forms.Label()
        Quant_poseLabel = New System.Windows.Forms.Label()
        CType(Me.DataGridViewX1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.ErrorProvider1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.Lst_article_equipBindingSource,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.MydbDataSet,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.Equipements_has_fournituresBindingSource,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.FournituresBindingSource,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.EquipementsBindingSource,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.Equip_pose_articleBindingSource,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'QuantLabel
        '
        QuantLabel.AutoSize = true
        QuantLabel.Location = New System.Drawing.Point(755, 167)
        QuantLabel.Name = "QuantLabel"
        QuantLabel.Size = New System.Drawing.Size(79, 13)
        QuantLabel.TabIndex = 0
        QuantLabel.Text = "quantité Prevu:"
        '
        'Date_poseLabel
        '
        Date_poseLabel.AutoSize = true
        Date_poseLabel.Location = New System.Drawing.Point(876, 234)
        Date_poseLabel.Name = "Date_poseLabel"
        Date_poseLabel.Size = New System.Drawing.Size(57, 13)
        Date_poseLabel.TabIndex = 2
        Date_poseLabel.Text = "date pose:"
        '
        'Quant_poseLabel
        '
        Quant_poseLabel.AutoSize = true
        Quant_poseLabel.Location = New System.Drawing.Point(969, 167)
        Quant_poseLabel.Name = "Quant_poseLabel"
        Quant_poseLabel.Size = New System.Drawing.Size(66, 13)
        Quant_poseLabel.TabIndex = 4
        Quant_poseLabel.Text = "Total Posés:"
        '
        'QuantTextBox
        '
        Me.QuantTextBox.Enabled = false
        Me.QuantTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.QuantTextBox.Location = New System.Drawing.Point(746, 183)
        Me.QuantTextBox.Name = "QuantTextBox"
        Me.QuantTextBox.Size = New System.Drawing.Size(100, 26)
        Me.QuantTextBox.TabIndex = 1
        '
        'Date_poseDateTimePicker
        '
        Me.Date_poseDateTimePicker.Location = New System.Drawing.Point(809, 250)
        Me.Date_poseDateTimePicker.Name = "Date_poseDateTimePicker"
        Me.Date_poseDateTimePicker.Size = New System.Drawing.Size(200, 20)
        Me.Date_poseDateTimePicker.TabIndex = 3
        '
        'Quant_poseTextBox
        '
        Me.Quant_poseTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Quant_poseTextBox.Location = New System.Drawing.Point(956, 183)
        Me.Quant_poseTextBox.Name = "Quant_poseTextBox"
        Me.Quant_poseTextBox.Size = New System.Drawing.Size(100, 26)
        Me.Quant_poseTextBox.TabIndex = 5
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX1.Image = Global.progelec.My.Resources.Resources.save_24_24
        Me.ButtonX1.Location = New System.Drawing.Point(839, 295)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Size = New System.Drawing.Size(136, 44)
        Me.ButtonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX1.TabIndex = 7
        Me.ButtonX1.Text = "Valider"
        '
        'DataGridViewX1
        '
        Me.DataGridViewX1.AllowUserToOrderColumns = true
        Me.DataGridViewX1.AutoGenerateColumns = false
        Me.DataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewX1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdequipementDataGridViewTextBoxColumn, Me.DesignationDataGridViewTextBoxColumn, Me.QuantDataGridViewTextBoxColumn, Me.TotalposeDataGridViewTextBoxColumn, Me.IdfournitureDataGridViewTextBoxColumn, Me.Temp1DataGridViewTextBoxColumn, Me.Temp2DataGridViewTextBoxColumn, Me.AvancementDataGridViewTextBoxColumn})
        Me.DataGridViewX1.DataSource = Me.Lst_article_equipBindingSource
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewX1.DefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewX1.GridColor = System.Drawing.Color.FromArgb(CType(CType(208,Byte),Integer), CType(CType(215,Byte),Integer), CType(CType(229,Byte),Integer))
        Me.DataGridViewX1.Location = New System.Drawing.Point(12, 102)
        Me.DataGridViewX1.Name = "DataGridViewX1"
        Me.DataGridViewX1.Size = New System.Drawing.Size(687, 420)
        Me.DataGridViewX1.TabIndex = 9
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
        Me.ErrorProvider1.Icon = CType(resources.GetObject("ErrorProvider1.Icon"),System.Drawing.Icon)
        '
        'Highlighter1
        '
        Me.Highlighter1.ContainerControl = Me
        Me.Highlighter1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.LabelX1.Location = New System.Drawing.Point(25, 23)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(1149, 47)
        Me.LabelX1.TabIndex = 10
        Me.LabelX1.Text = "Declaration pose articles composés pour l'equipement :"
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Location = New System.Drawing.Point(746, 102)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(75, 23)
        Me.LabelX2.TabIndex = 11
        Me.LabelX2.Text = "LabelX2"
        '
        'ButtonX2
        '
        Me.ButtonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX2.Image = Global.progelec.My.Resources.Resources._next
        Me.ButtonX2.Location = New System.Drawing.Point(920, 478)
        Me.ButtonX2.Name = "ButtonX2"
        Me.ButtonX2.Size = New System.Drawing.Size(136, 44)
        Me.ButtonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX2.TabIndex = 7
        Me.ButtonX2.Text = "Sortie"
        '
        'Lst_article_equipBindingSource
        '
        Me.Lst_article_equipBindingSource.DataMember = "lst_article_equip"
        Me.Lst_article_equipBindingSource.DataSource = Me.MydbDataSet
        '
        'MydbDataSet
        '
        Me.MydbDataSet.DataSetName = "mydbDataSet"
        Me.MydbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Equipements_has_fournituresBindingSource
        '
        Me.Equipements_has_fournituresBindingSource.DataMember = "equipements_has_fournitures"
        Me.Equipements_has_fournituresBindingSource.DataSource = Me.MydbDataSet
        '
        'FournituresBindingSource
        '
        Me.FournituresBindingSource.DataMember = "fournitures"
        Me.FournituresBindingSource.DataSource = Me.MydbDataSet
        '
        'FournituresTableAdapter
        '
        Me.FournituresTableAdapter.ClearBeforeFill = true
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
        Me.TableAdapterManager.equipements_has_fournituresTableAdapter = Me.Equipements_has_fournituresTableAdapter
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
        Me.TableAdapterManager.UpdateOrder = progelec.MydbDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'Equipements_has_fournituresTableAdapter
        '
        Me.Equipements_has_fournituresTableAdapter.ClearBeforeFill = true
        '
        'Lst_article_equipTableAdapter
        '
        Me.Lst_article_equipTableAdapter.ClearBeforeFill = true
        '
        'EquipementsBindingSource
        '
        Me.EquipementsBindingSource.DataMember = "equipements"
        Me.EquipementsBindingSource.DataSource = Me.MydbDataSet
        '
        'EquipementsTableAdapter
        '
        Me.EquipementsTableAdapter.ClearBeforeFill = true
        '
        'Equip_pose_articleBindingSource
        '
        Me.Equip_pose_articleBindingSource.DataMember = "equip_pose_article"
        Me.Equip_pose_articleBindingSource.DataSource = Me.MydbDataSet
        '
        'Equip_pose_articleTableAdapter
        '
        Me.Equip_pose_articleTableAdapter.ClearBeforeFill = true
        '
        'IdequipementDataGridViewTextBoxColumn
        '
        Me.IdequipementDataGridViewTextBoxColumn.DataPropertyName = "idequipement"
        Me.IdequipementDataGridViewTextBoxColumn.HeaderText = "idequipement"
        Me.IdequipementDataGridViewTextBoxColumn.Name = "IdequipementDataGridViewTextBoxColumn"
        Me.IdequipementDataGridViewTextBoxColumn.Visible = false
        '
        'DesignationDataGridViewTextBoxColumn
        '
        Me.DesignationDataGridViewTextBoxColumn.DataPropertyName = "designation"
        Me.DesignationDataGridViewTextBoxColumn.HeaderText = "designation"
        Me.DesignationDataGridViewTextBoxColumn.Name = "DesignationDataGridViewTextBoxColumn"
        '
        'QuantDataGridViewTextBoxColumn
        '
        Me.QuantDataGridViewTextBoxColumn.DataPropertyName = "quant"
        Me.QuantDataGridViewTextBoxColumn.HeaderText = "quant"
        Me.QuantDataGridViewTextBoxColumn.Name = "QuantDataGridViewTextBoxColumn"
        '
        'TotalposeDataGridViewTextBoxColumn
        '
        Me.TotalposeDataGridViewTextBoxColumn.DataPropertyName = "total_pose"
        Me.TotalposeDataGridViewTextBoxColumn.HeaderText = "total_pose"
        Me.TotalposeDataGridViewTextBoxColumn.Name = "TotalposeDataGridViewTextBoxColumn"
        '
        'IdfournitureDataGridViewTextBoxColumn
        '
        Me.IdfournitureDataGridViewTextBoxColumn.DataPropertyName = "idfourniture"
        Me.IdfournitureDataGridViewTextBoxColumn.HeaderText = "idfourniture"
        Me.IdfournitureDataGridViewTextBoxColumn.Name = "IdfournitureDataGridViewTextBoxColumn"
        Me.IdfournitureDataGridViewTextBoxColumn.Visible = false
        '
        'Temp1DataGridViewTextBoxColumn
        '
        Me.Temp1DataGridViewTextBoxColumn.DataPropertyName = "temp1"
        Me.Temp1DataGridViewTextBoxColumn.HeaderText = "temp1"
        Me.Temp1DataGridViewTextBoxColumn.Name = "Temp1DataGridViewTextBoxColumn"
        Me.Temp1DataGridViewTextBoxColumn.Visible = false
        '
        'Temp2DataGridViewTextBoxColumn
        '
        Me.Temp2DataGridViewTextBoxColumn.DataPropertyName = "temp2"
        Me.Temp2DataGridViewTextBoxColumn.HeaderText = "temp2"
        Me.Temp2DataGridViewTextBoxColumn.Name = "Temp2DataGridViewTextBoxColumn"
        Me.Temp2DataGridViewTextBoxColumn.Visible = false
        '
        'AvancementDataGridViewTextBoxColumn
        '
        Me.AvancementDataGridViewTextBoxColumn.DataPropertyName = "avancement"
        Me.AvancementDataGridViewTextBoxColumn.HeaderText = "avancement"
        Me.AvancementDataGridViewTextBoxColumn.Name = "AvancementDataGridViewTextBoxColumn"
        '
        'Formposecompose
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1195, 533)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.DataGridViewX1)
        Me.Controls.Add(Me.ButtonX2)
        Me.Controls.Add(Me.ButtonX1)
        Me.Controls.Add(Quant_poseLabel)
        Me.Controls.Add(Me.Quant_poseTextBox)
        Me.Controls.Add(Date_poseLabel)
        Me.Controls.Add(Me.Date_poseDateTimePicker)
        Me.Controls.Add(QuantLabel)
        Me.Controls.Add(Me.QuantTextBox)
        Me.DoubleBuffered = true
        Me.Name = "Formposecompose"
        Me.Text = "Formposecompose"
        CType(Me.DataGridViewX1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.ErrorProvider1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.Lst_article_equipBindingSource,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.MydbDataSet,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.Equipements_has_fournituresBindingSource,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.FournituresBindingSource,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.EquipementsBindingSource,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.Equip_pose_articleBindingSource,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents MydbDataSet As progelec.mydbDataSet
    Friend WithEvents FournituresBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents FournituresTableAdapter As progelec.mydbDataSetTableAdapters.fournituresTableAdapter
    Friend WithEvents TableAdapterManager As progelec.mydbDataSetTableAdapters.TableAdapterManager
    Friend WithEvents Equipements_has_fournituresTableAdapter As progelec.mydbDataSetTableAdapters.equipements_has_fournituresTableAdapter
    Friend WithEvents Equipements_has_fournituresBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents QuantTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Date_poseDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents Quant_poseTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Lst_article_equipBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Lst_article_equipTableAdapter As progelec.mydbDataSetTableAdapters.lst_article_equipTableAdapter
    Friend WithEvents DataGridViewX1 As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents SuperValidator1 As DevComponents.DotNetBar.Validator.SuperValidator
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Highlighter1 As DevComponents.DotNetBar.Validator.Highlighter
    Friend WithEvents EquipementsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EquipementsTableAdapter As progelec.MydbDataSetTableAdapters.equipementsTableAdapter
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ButtonX2 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Equip_pose_articleBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Equip_pose_articleTableAdapter As progelec.MydbDataSetTableAdapters.equip_pose_articleTableAdapter
    Friend WithEvents QuantposeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FournituresidfournitureDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdequipementDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DesignationDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalposeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdfournitureDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Temp1DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Temp2DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AvancementDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
