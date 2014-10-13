<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormArchi
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormArchi))
        Dim RoleBasedSecurityManager1 As Dataweb.NShape.RoleBasedSecurityManager = New Dataweb.NShape.RoleBasedSecurityManager()
        Me.Display1 = New Dataweb.NShape.WinFormsUI.Display()
        Me.DiagramSetController1 = New Dataweb.NShape.Controllers.DiagramSetController()
        Me.Project1 = New Dataweb.NShape.Project(Me.components)
        Me.CachedRepository1 = New Dataweb.NShape.Advanced.CachedRepository()
        Me.XmlStore1 = New Dataweb.NShape.XmlStore()
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.BatimentsDataGridView = New System.Windows.Forms.DataGridView()
        Me.ToolSetListViewPresenter1 = New Dataweb.NShape.WinFormsUI.ToolSetListViewPresenter(Me.components)
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ToolSetController1 = New Dataweb.NShape.Controllers.ToolSetController()
        Me.ButtonX2 = New DevComponents.DotNetBar.ButtonX()
        Me.EquipementsDataGridView = New System.Windows.Forms.DataGridView()
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
        Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.EquipementsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MydbDataSet = New progelec.mydbDataSet()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BatimentsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BatimentsTableAdapter = New progelec.mydbDataSetTableAdapters.batimentsTableAdapter()
        Me.TableAdapterManager = New progelec.mydbDataSetTableAdapters.TableAdapterManager()
        Me.Lst_dispo_tirageBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Lst_dispo_tirageTableAdapter = New progelec.mydbDataSetTableAdapters.lst_dispo_tirageTableAdapter()
        Me.Lst_equipementsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Lst_equipementsTableAdapter = New progelec.mydbDataSetTableAdapters.lst_equipementsTableAdapter()
        Me.BorniersBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BorniersTableAdapter = New progelec.mydbDataSetTableAdapters.borniersTableAdapter()
        Me.DepartsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DepartsTableAdapter = New progelec.mydbDataSetTableAdapters.departsTableAdapter()
        Me.EquipementsTableAdapter = New progelec.mydbDataSetTableAdapters.equipementsTableAdapter()
        CType(Me.BatimentsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EquipementsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EquipementsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MydbDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BatimentsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Lst_dispo_tirageBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Lst_equipementsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BorniersBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DepartsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Display1
        '
        Me.Display1.AllowDrop = True
        Me.Display1.BackColorGradient = System.Drawing.SystemColors.Control
        Me.Display1.DiagramSetController = Me.DiagramSetController1
        Me.Display1.GridColor = System.Drawing.Color.Gainsboro
        Me.Display1.GridSize = 19
        Me.Display1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Display1.Location = New System.Drawing.Point(430, 124)
        Me.Display1.Name = "Display1"
        Me.Display1.PropertyController = Nothing
        Me.Display1.SelectionHilightColor = System.Drawing.Color.Firebrick
        Me.Display1.SelectionInactiveColor = System.Drawing.Color.Gray
        Me.Display1.SelectionInteriorColor = System.Drawing.Color.WhiteSmoke
        Me.Display1.SelectionNormalColor = System.Drawing.Color.DarkGreen
        Me.Display1.Size = New System.Drawing.Size(703, 568)
        Me.Display1.TabIndex = 0
        Me.Display1.ToolPreviewBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(119, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.Display1.ToolPreviewColor = System.Drawing.Color.FromArgb(CType(CType(96, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(180, Byte), Integer))
        '
        'DiagramSetController1
        '
        Me.DiagramSetController1.ActiveTool = Nothing
        Me.DiagramSetController1.Project = Me.Project1
        '
        'Project1
        '
        Me.Project1.LibrarySearchPaths = CType(resources.GetObject("Project1.LibrarySearchPaths"), System.Collections.Generic.IList(Of String))
        Me.Project1.Name = Nothing
        Me.Project1.Repository = Me.CachedRepository1
        RoleBasedSecurityManager1.CurrentRole = Dataweb.NShape.StandardRole.Administrator
        RoleBasedSecurityManager1.CurrentRoleName = "Administrator"
        Me.Project1.SecurityManager = RoleBasedSecurityManager1
        '
        'CachedRepository1
        '
        Me.CachedRepository1.ProjectName = Nothing
        Me.CachedRepository1.Store = Me.XmlStore1
        Me.CachedRepository1.Version = 0
        '
        'XmlStore1
        '
        Me.XmlStore1.DesignFileName = ""
        Me.XmlStore1.DirectoryName = ""
        Me.XmlStore1.FileExtension = ".xml"
        Me.XmlStore1.ProjectName = ""
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX1.Location = New System.Drawing.Point(215, 87)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Size = New System.Drawing.Size(75, 23)
        Me.ButtonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX1.TabIndex = 1
        Me.ButtonX1.Text = "ButtonX1"
        '
        'BatimentsDataGridView
        '
        Me.BatimentsDataGridView.AutoGenerateColumns = False
        Me.BatimentsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.BatimentsDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3})
        Me.BatimentsDataGridView.DataSource = Me.BatimentsBindingSource
        Me.BatimentsDataGridView.Location = New System.Drawing.Point(0, 166)
        Me.BatimentsDataGridView.Name = "BatimentsDataGridView"
        Me.BatimentsDataGridView.Size = New System.Drawing.Size(172, 199)
        Me.BatimentsDataGridView.TabIndex = 3
        '
        'ToolSetListViewPresenter1
        '
        Me.ToolSetListViewPresenter1.HideDeniedMenuItems = False
        Me.ToolSetListViewPresenter1.ListView = Me.ListView1
        Me.ToolSetListViewPresenter1.ShowDefaultContextMenu = True
        Me.ToolSetListViewPresenter1.ToolSetController = Me.ToolSetController1
        '
        'ListView1
        '
        Me.ListView1.FullRowSelect = True
        Me.ListView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.ListView1.HideSelection = False
        Me.ListView1.Location = New System.Drawing.Point(1148, 124)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.ShowItemToolTips = True
        Me.ListView1.Size = New System.Drawing.Size(149, 568)
        Me.ListView1.TabIndex = 5
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'ToolSetController1
        '
        Me.ToolSetController1.DiagramSetController = Me.DiagramSetController1
        '
        'ButtonX2
        '
        Me.ButtonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX2.Location = New System.Drawing.Point(342, 45)
        Me.ButtonX2.Name = "ButtonX2"
        Me.ButtonX2.Size = New System.Drawing.Size(167, 23)
        Me.ButtonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX2.TabIndex = 1
        Me.ButtonX2.Text = "Generation equipement"
        '
        'EquipementsDataGridView
        '
        Me.EquipementsDataGridView.AutoGenerateColumns = False
        Me.EquipementsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.EquipementsDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn10, Me.DataGridViewTextBoxColumn11, Me.DataGridViewTextBoxColumn12, Me.DataGridViewTextBoxColumn13, Me.DataGridViewTextBoxColumn14, Me.DataGridViewTextBoxColumn15, Me.DataGridViewTextBoxColumn16, Me.DataGridViewCheckBoxColumn1})
        Me.EquipementsDataGridView.DataSource = Me.EquipementsBindingSource
        Me.EquipementsDataGridView.Location = New System.Drawing.Point(0, 381)
        Me.EquipementsDataGridView.Name = "EquipementsDataGridView"
        Me.EquipementsDataGridView.Size = New System.Drawing.Size(406, 220)
        Me.EquipementsDataGridView.TabIndex = 5
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "idequipement"
        Me.DataGridViewTextBoxColumn4.HeaderText = "idequipement"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "repere equipement"
        Me.DataGridViewTextBoxColumn5.HeaderText = "repere equipement"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "salles_idsalle"
        Me.DataGridViewTextBoxColumn6.HeaderText = "salles_idsalle"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "lots_idlots"
        Me.DataGridViewTextBoxColumn7.HeaderText = "lots_idlots"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "Categories_idCategories"
        Me.DataGridViewTextBoxColumn8.HeaderText = "Categories_idCategories"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "designation"
        Me.DataGridViewTextBoxColumn9.HeaderText = "designation"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "date"
        Me.DataGridViewTextBoxColumn10.HeaderText = "date"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "revision"
        Me.DataGridViewTextBoxColumn11.HeaderText = "revision"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "qui"
        Me.DataGridViewTextBoxColumn12.HeaderText = "qui"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.DataPropertyName = "modif"
        Me.DataGridViewTextBoxColumn13.HeaderText = "modif"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.DataPropertyName = "revb"
        Me.DataGridViewTextBoxColumn14.HeaderText = "revb"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.DataPropertyName = "TempPose"
        Me.DataGridViewTextBoxColumn15.HeaderText = "TempPose"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.DataPropertyName = "date_pose"
        Me.DataGridViewTextBoxColumn16.HeaderText = "date_pose"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        '
        'DataGridViewCheckBoxColumn1
        '
        Me.DataGridViewCheckBoxColumn1.DataPropertyName = "pose"
        Me.DataGridViewCheckBoxColumn1.HeaderText = "pose"
        Me.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1"
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
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "idBatiment"
        Me.DataGridViewTextBoxColumn1.HeaderText = "idBatiment"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Nom"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Nom"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "Designation"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Designation"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Visible = False
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
        Me.TableAdapterManager.batimentsTableAdapter = Me.BatimentsTableAdapter
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
        'Lst_dispo_tirageBindingSource
        '
        Me.Lst_dispo_tirageBindingSource.DataMember = "lst_dispo_tirage"
        Me.Lst_dispo_tirageBindingSource.DataSource = Me.MydbDataSet
        '
        'Lst_dispo_tirageTableAdapter
        '
        Me.Lst_dispo_tirageTableAdapter.ClearBeforeFill = True
        '
        'Lst_equipementsBindingSource
        '
        Me.Lst_equipementsBindingSource.DataMember = "lst_equipements"
        Me.Lst_equipementsBindingSource.DataSource = Me.MydbDataSet
        '
        'Lst_equipementsTableAdapter
        '
        Me.Lst_equipementsTableAdapter.ClearBeforeFill = True
        '
        'BorniersBindingSource
        '
        Me.BorniersBindingSource.DataMember = "borniers"
        Me.BorniersBindingSource.DataSource = Me.MydbDataSet
        '
        'BorniersTableAdapter
        '
        Me.BorniersTableAdapter.ClearBeforeFill = True
        '
        'DepartsBindingSource
        '
        Me.DepartsBindingSource.DataMember = "departs"
        Me.DepartsBindingSource.DataSource = Me.MydbDataSet
        '
        'DepartsTableAdapter
        '
        Me.DepartsTableAdapter.ClearBeforeFill = True
        '
        'EquipementsTableAdapter
        '
        Me.EquipementsTableAdapter.ClearBeforeFill = True
        '
        'FormArchi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1359, 824)
        Me.Controls.Add(Me.EquipementsDataGridView)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.BatimentsDataGridView)
        Me.Controls.Add(Me.ButtonX2)
        Me.Controls.Add(Me.ButtonX1)
        Me.Controls.Add(Me.Display1)
        Me.DoubleBuffered = True
        Me.Name = "FormArchi"
        Me.Text = "FormArchi"
        CType(Me.BatimentsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EquipementsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EquipementsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MydbDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BatimentsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Lst_dispo_tirageBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Lst_equipementsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BorniersBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DepartsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Display1 As Dataweb.NShape.WinFormsUI.Display
    Friend WithEvents DiagramSetController1 As Dataweb.NShape.Controllers.DiagramSetController
    Friend WithEvents Project1 As Dataweb.NShape.Project
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents MydbDataSet As progelec.mydbDataSet
    Friend WithEvents BatimentsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents BatimentsTableAdapter As progelec.mydbDataSetTableAdapters.batimentsTableAdapter
    Friend WithEvents TableAdapterManager As progelec.mydbDataSetTableAdapters.TableAdapterManager
    Friend WithEvents BatimentsDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolSetListViewPresenter1 As Dataweb.NShape.WinFormsUI.ToolSetListViewPresenter
    Friend WithEvents ToolSetController1 As Dataweb.NShape.Controllers.ToolSetController
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents CachedRepository1 As Dataweb.NShape.Advanced.CachedRepository
    Friend WithEvents XmlStore1 As Dataweb.NShape.XmlStore
    Friend WithEvents Lst_dispo_tirageBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Lst_dispo_tirageTableAdapter As progelec.mydbDataSetTableAdapters.lst_dispo_tirageTableAdapter
    Friend WithEvents Lst_equipementsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Lst_equipementsTableAdapter As progelec.mydbDataSetTableAdapters.lst_equipementsTableAdapter
    Friend WithEvents BorniersBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents BorniersTableAdapter As progelec.mydbDataSetTableAdapters.borniersTableAdapter
    Friend WithEvents DepartsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DepartsTableAdapter As progelec.mydbDataSetTableAdapters.departsTableAdapter
    Friend WithEvents EquipementsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EquipementsTableAdapter As progelec.mydbDataSetTableAdapters.equipementsTableAdapter
    Friend WithEvents ButtonX2 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents EquipementsDataGridView As System.Windows.Forms.DataGridView
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
    Friend WithEvents DataGridViewTextBoxColumn16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn1 As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
