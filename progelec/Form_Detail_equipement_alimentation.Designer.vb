<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Detail_equipement_alimentation
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.SuperGridControl1 = New DevComponents.DotNetBar.SuperGrid.SuperGridControl()
        Me.EquipementsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MydbDataSet = New progelec.mydbDataSet()
        Me.EquipementsTableAdapter = New progelec.mydbDataSetTableAdapters.equipementsTableAdapter()
        Me.TableAdapterManager = New progelec.mydbDataSetTableAdapters.TableAdapterManager()
        Me.BorniersTableAdapter = New progelec.mydbDataSetTableAdapters.borniersTableAdapter()
        Me.CablesTableAdapter = New progelec.mydbDataSetTableAdapters.cablesTableAdapter()
        Me.Fkborniersequipements1BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CablesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SegregationsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SegregationsTableAdapter = New progelec.mydbDataSetTableAdapters.segregationsTableAdapter()
        Me.Lst_alim_equipBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Lst_alim_equipTableAdapter = New progelec.mydbDataSetTableAdapters.lst_alim_equipTableAdapter()
        Me.Lst_alim_equipDataGridViewX = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DepartsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DepartsTableAdapter = New progelec.mydbDataSetTableAdapters.departsTableAdapter()
        Me.CablesBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.EquipementsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MydbDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Fkborniersequipements1BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CablesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SegregationsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Lst_alim_equipBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Lst_alim_equipDataGridViewX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DepartsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CablesBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SuperGridControl1
        '
        Me.SuperGridControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.SuperGridControl1.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed
        Me.SuperGridControl1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.SuperGridControl1.Location = New System.Drawing.Point(3, 53)
        Me.SuperGridControl1.Name = "SuperGridControl1"
        Me.SuperGridControl1.PrimaryGrid.DataMember = "equipement"
        Me.SuperGridControl1.PrimaryGrid.ShowTreeButtons = True
        Me.SuperGridControl1.PrimaryGrid.ShowTreeLines = True
        Me.SuperGridControl1.Size = New System.Drawing.Size(660, 707)
        Me.SuperGridControl1.TabIndex = 0
        Me.SuperGridControl1.Text = "SuperGridControl1"
        '
        'EquipementsBindingSource
        '
        Me.EquipementsBindingSource.DataMember = "equipements"
        Me.EquipementsBindingSource.DataSource = Me.MydbDataSet
        '
        'MydbDataSet
        '
        Me.MydbDataSet.DataSetName = "mydbDataSet"
        Me.MydbDataSet.EnforceConstraints = False
        Me.MydbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'EquipementsTableAdapter
        '
        Me.EquipementsTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.Actions_borniersTableAdapter = Nothing
        Me.TableAdapterManager.Actions_cablesTableAdapter = Nothing
        Me.TableAdapterManager.Actions_departsTableAdapter = Nothing
        Me.TableAdapterManager.Actions_diversTableAdapter = Nothing
        Me.TableAdapterManager.Actions_equipementsTableAdapter = Nothing
        Me.TableAdapterManager.Actions_tronconsTableAdapter = Nothing
        Me.TableAdapterManager.Actions_typesTableAdapter = Nothing
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.Borniers_modifTableAdapter = Nothing
        Me.TableAdapterManager.borniersTableAdapter = Me.BorniersTableAdapter
        Me.TableAdapterManager.cables_detailsTableAdapter = Nothing
        Me.TableAdapterManager.Cables_modifTableAdapter = Nothing
        Me.TableAdapterManager.cablesTableAdapter = Me.CablesTableAdapter
        Me.TableAdapterManager.categoriesTableAdapter = Nothing
        Me.TableAdapterManager.Commande_detailsTableAdapter = Nothing
        Me.TableAdapterManager.CommandeTableAdapter = Nothing
        Me.TableAdapterManager.departs_modifTableAdapter = Nothing
        Me.TableAdapterManager.departsTableAdapter = Nothing
        Me.TableAdapterManager.doc_referenceTableAdapter = Nothing
        Me.TableAdapterManager.donnees_cablesTableAdapter = Nothing
        Me.TableAdapterManager.editionsTableAdapter = Nothing
        Me.TableAdapterManager.EmplacementTableAdapter = Nothing
        Me.TableAdapterManager.equipements_modifTableAdapter = Nothing
        Me.TableAdapterManager.equipementsTableAdapter = Me.EquipementsTableAdapter
        Me.TableAdapterManager.fournisseursTableAdapter = Nothing
        Me.TableAdapterManager.fournituresTableAdapter = Nothing
        Me.TableAdapterManager.Livraisons_detailsTableAdapter = Nothing
        Me.TableAdapterManager.LivraisonsTableAdapter = Nothing
        Me.TableAdapterManager.lotsTableAdapter = Nothing
        Me.TableAdapterManager.ModifDetailTableAdapter = Nothing
        Me.TableAdapterManager.ModifOrigineTableAdapter = Nothing
        Me.TableAdapterManager.ModifRevTableAdapter = Nothing
        Me.TableAdapterManager.ModifTableAdapter = Nothing
        Me.TableAdapterManager.ModifTypeTableAdapter = Nothing
        Me.TableAdapterManager.parcours_detailTableAdapter = Nothing
        Me.TableAdapterManager.parcoursTableAdapter = Nothing
        Me.TableAdapterManager.Plg_blocageTableAdapter = Nothing
        Me.TableAdapterManager.Plg_Jalons_has_equipementsTableAdapter = Nothing
        Me.TableAdapterManager.Plg_Jalons_has_sallesTableAdapter = Nothing
        Me.TableAdapterManager.Plg_JalonsTableAdapter = Nothing
        Me.TableAdapterManager.Plg_MADTableAdapter = Nothing
        Me.TableAdapterManager.PositionTableAdapter = Nothing
        Me.TableAdapterManager.RevBaseTableAdapter = Nothing
        Me.TableAdapterManager.revisionTableAdapter = Nothing
        Me.TableAdapterManager.sallesTableAdapter = Nothing
        Me.TableAdapterManager.sections_cablesTableAdapter = Nothing
        Me.TableAdapterManager.segregationsTableAdapter = Nothing
        Me.TableAdapterManager.troncons_assocTableAdapter = Nothing
        Me.TableAdapterManager.troncons_fournituresTableAdapter = Nothing
        Me.TableAdapterManager.troncons_modifTableAdapter = Nothing
        Me.TableAdapterManager.tronconsTableAdapter = Nothing
        Me.TableAdapterManager.type_docTableAdapter = Nothing
        Me.TableAdapterManager.types_cableTableAdapter = Nothing
        Me.TableAdapterManager.types_tronconsTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = progelec.mydbDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'BorniersTableAdapter
        '
        Me.BorniersTableAdapter.ClearBeforeFill = True
        '
        'CablesTableAdapter
        '
        Me.CablesTableAdapter.ClearBeforeFill = True
        '
        'Fkborniersequipements1BindingSource
        '
        Me.Fkborniersequipements1BindingSource.DataMember = "fk_borniers_equipements1"
        Me.Fkborniersequipements1BindingSource.DataSource = Me.EquipementsBindingSource
        '
        'CablesBindingSource
        '
        Me.CablesBindingSource.DataMember = "fk_cables_borniers1"
        Me.CablesBindingSource.DataSource = Me.Fkborniersequipements1BindingSource
        '
        'SegregationsBindingSource
        '
        Me.SegregationsBindingSource.DataMember = "segregations"
        Me.SegregationsBindingSource.DataSource = Me.MydbDataSet
        '
        'SegregationsTableAdapter
        '
        Me.SegregationsTableAdapter.ClearBeforeFill = True
        '
        'Lst_alim_equipBindingSource
        '
        Me.Lst_alim_equipBindingSource.DataMember = "lst_alim_equip"
        Me.Lst_alim_equipBindingSource.DataSource = Me.MydbDataSet
        '
        'Lst_alim_equipTableAdapter
        '
        Me.Lst_alim_equipTableAdapter.ClearBeforeFill = True
        '
        'Lst_alim_equipDataGridViewX
        '
        Me.Lst_alim_equipDataGridViewX.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lst_alim_equipDataGridViewX.AutoGenerateColumns = False
        Me.Lst_alim_equipDataGridViewX.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Lst_alim_equipDataGridViewX.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6})
        Me.Lst_alim_equipDataGridViewX.DataSource = Me.Lst_alim_equipBindingSource
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Lst_alim_equipDataGridViewX.DefaultCellStyle = DataGridViewCellStyle1
        Me.Lst_alim_equipDataGridViewX.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Lst_alim_equipDataGridViewX.Location = New System.Drawing.Point(702, 53)
        Me.Lst_alim_equipDataGridViewX.Name = "Lst_alim_equipDataGridViewX"
        Me.Lst_alim_equipDataGridViewX.Size = New System.Drawing.Size(688, 707)
        Me.Lst_alim_equipDataGridViewX.TabIndex = 1
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
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "repere equipement"
        Me.DataGridViewTextBoxColumn2.HeaderText = "repere equipement"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "designation"
        Me.DataGridViewTextBoxColumn3.HeaderText = "designation"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 400
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "repere salle"
        Me.DataGridViewTextBoxColumn4.HeaderText = "repere salle"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "Niveau"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Niveau"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "count(`segregations`.`segregation`)"
        Me.DataGridViewTextBoxColumn6.HeaderText = "Nombre d'alimentation"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'DepartsBindingSource
        '
        Me.DepartsBindingSource.DataMember = "fk_departs_equipements"
        Me.DepartsBindingSource.DataSource = Me.EquipementsBindingSource
        '
        'DepartsTableAdapter
        '
        Me.DepartsTableAdapter.ClearBeforeFill = True
        '
        'CablesBindingSource1
        '
        Me.CablesBindingSource1.DataMember = "fk_cables_departs1"
        Me.CablesBindingSource1.DataSource = Me.DepartsBindingSource
        '
        'Form_Detail_equipement_alimentation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1393, 772)
        Me.Controls.Add(Me.Lst_alim_equipDataGridViewX)
        Me.Controls.Add(Me.SuperGridControl1)
        Me.DoubleBuffered = True
        Me.Name = "Form_Detail_equipement_alimentation"
        Me.Text = "alimentations Equipements"
        CType(Me.EquipementsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MydbDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Fkborniersequipements1BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CablesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SegregationsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Lst_alim_equipBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Lst_alim_equipDataGridViewX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DepartsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CablesBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SuperGridControl1 As DevComponents.DotNetBar.SuperGrid.SuperGridControl
    Friend WithEvents MydbDataSet As progelec.mydbDataSet
    Friend WithEvents EquipementsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EquipementsTableAdapter As progelec.mydbDataSetTableAdapters.equipementsTableAdapter
    Friend WithEvents TableAdapterManager As progelec.mydbDataSetTableAdapters.TableAdapterManager
    Friend WithEvents BorniersTableAdapter As progelec.mydbDataSetTableAdapters.borniersTableAdapter
    Friend WithEvents CablesTableAdapter As progelec.mydbDataSetTableAdapters.cablesTableAdapter
    Friend WithEvents Fkborniersequipements1BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CablesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SegregationsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SegregationsTableAdapter As progelec.mydbDataSetTableAdapters.segregationsTableAdapter
    Friend WithEvents Lst_alim_equipBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Lst_alim_equipTableAdapter As progelec.mydbDataSetTableAdapters.lst_alim_equipTableAdapter
    Friend WithEvents Lst_alim_equipDataGridViewX As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DepartsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DepartsTableAdapter As progelec.mydbDataSetTableAdapters.departsTableAdapter
    Friend WithEvents CablesBindingSource1 As System.Windows.Forms.BindingSource
End Class
