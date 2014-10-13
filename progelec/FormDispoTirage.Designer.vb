<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDispoTirage
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
        Dim GridColumn12 As DevComponents.DotNetBar.SuperGrid.GridColumn = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Dim GridColumn13 As DevComponents.DotNetBar.SuperGrid.GridColumn = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Dim GridColumn14 As DevComponents.DotNetBar.SuperGrid.GridColumn = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Dim GridColumn15 As DevComponents.DotNetBar.SuperGrid.GridColumn = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Dim GridColumn16 As DevComponents.DotNetBar.SuperGrid.GridColumn = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Dim GridColumn17 As DevComponents.DotNetBar.SuperGrid.GridColumn = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Dim GridColumn18 As DevComponents.DotNetBar.SuperGrid.GridColumn = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Dim GridColumn19 As DevComponents.DotNetBar.SuperGrid.GridColumn = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Dim GridColumn20 As DevComponents.DotNetBar.SuperGrid.GridColumn = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Dim GridColumn21 As DevComponents.DotNetBar.SuperGrid.GridColumn = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormDispoTirage))
        Me.SuperGridControl1 = New DevComponents.DotNetBar.SuperGrid.SuperGridControl()
        Me.Lst_dispo_tirageBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MydbDataSet = New progelec.mydbDataSet()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX2 = New DevComponents.DotNetBar.ButtonX()
        Me.Lst_dispo_tirageTableAdapter = New progelec.mydbDataSetTableAdapters.lst_dispo_tirageTableAdapter()
        Me.TableAdapterManager = New progelec.mydbDataSetTableAdapters.TableAdapterManager()
        Me.Cables_detailsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Cables_detailsTableAdapter = New progelec.mydbDataSetTableAdapters.cables_detailsTableAdapter()
        Me.Cables_details_has_tourets_poseBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Cables_details_has_tourets_poseTableAdapter = New progelec.mydbDataSetTableAdapters.cables_details_has_tourets_poseTableAdapter()
        Me.Cables_details_has_touretsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Cables_details_has_touretsTableAdapter = New progelec.mydbDataSetTableAdapters.cables_details_has_touretsTableAdapter()
        Me.TouretsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TouretsTableAdapter = New progelec.mydbDataSetTableAdapters.touretsTableAdapter()
        Me.CablesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CablesTableAdapter = New progelec.mydbDataSetTableAdapters.cablesTableAdapter()
        CType(Me.Lst_dispo_tirageBindingSource,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.MydbDataSet,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.Cables_detailsBindingSource,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.Cables_details_has_tourets_poseBindingSource,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.Cables_details_has_touretsBindingSource,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TouretsBindingSource,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.CablesBindingSource,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'SuperGridControl1
        '
        Me.SuperGridControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.SuperGridControl1.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed
        Me.SuperGridControl1.FilterUseExtendedCustomDialog = true
        Me.SuperGridControl1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.SuperGridControl1.Location = New System.Drawing.Point(2, 74)
        Me.SuperGridControl1.Name = "SuperGridControl1"
        GridColumn1.DataPropertyName = "idcable"
        GridColumn1.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridIntegerInputEditControl)
        GridColumn1.HeaderText = "idcable"
        GridColumn1.Name = "idcable"
        GridColumn1.Visible = false
        GridColumn2.DataPropertyName = "Salle_tenant"
        GridColumn2.HeaderText = "Salle_tenant"
        GridColumn2.Name = "Salle_tenant"
        GridColumn3.DataPropertyName = "statut"
        GridColumn3.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl)
        GridColumn3.HeaderText = "Statut Salle T"
        GridColumn3.Name = "statut"
        GridColumn4.DataPropertyName = "tenant"
        GridColumn4.HeaderText = "tenant"
        GridColumn4.Name = "tenant"
        GridColumn5.DataPropertyName = "status"
        GridColumn5.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl)
        GridColumn5.HeaderText = "status"
        GridColumn5.Name = "status"
        GridColumn5.Visible = false
        GridColumn6.DataPropertyName = "Salle_about"
        GridColumn6.HeaderText = "Salle_about"
        GridColumn6.Name = "Salle_about"
        GridColumn7.DataPropertyName = "statut1"
        GridColumn7.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl)
        GridColumn7.HeaderText = "statutSalle A"
        GridColumn7.Name = "statut1"
        GridColumn8.DataPropertyName = "about"
        GridColumn8.HeaderText = "about"
        GridColumn8.Name = "about"
        GridColumn9.DataPropertyName = "status1"
        GridColumn9.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl)
        GridColumn9.HeaderText = "status1"
        GridColumn9.Name = "status1"
        GridColumn9.Visible = false
        GridColumn10.DataPropertyName = "repere cable"
        GridColumn10.HeaderText = "repere cable"
        GridColumn10.Name = "repere cable"
        GridColumn11.DataPropertyName = "Fils"
        GridColumn11.HeaderText = "Fils"
        GridColumn11.Name = "Fils"
        GridColumn12.DataPropertyName = "parcours_status"
        GridColumn12.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl)
        GridColumn12.HeaderText = "parcours_status"
        GridColumn12.Name = "parcours_status"
        GridColumn13.DataPropertyName = "types"
        GridColumn13.HeaderText = "types"
        GridColumn13.Name = "types"
        GridColumn14.DataPropertyName = "section"
        GridColumn14.HeaderText = "section"
        GridColumn14.Name = "section"
        GridColumn15.DataPropertyName = "longueur"
        GridColumn15.HeaderText = "longueur"
        GridColumn15.Name = "longueur"
        GridColumn16.DataPropertyName = "TempPose"
        GridColumn16.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridDoubleInputEditControl)
        GridColumn16.HeaderText = "TempPose"
        GridColumn16.Name = "TempPose"
        GridColumn17.DataPropertyName = "temps"
        GridColumn17.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridDoubleInputEditControl)
        GridColumn17.HeaderText = "temps"
        GridColumn17.Name = "temps"
        GridColumn18.DataPropertyName = "pose"
        GridColumn18.HeaderText = "pose"
        GridColumn18.Name = "pose"
        GridColumn19.DataPropertyName = "date_pose"
        GridColumn19.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridDateTimeInputEditControl)
        GridColumn19.HeaderText = "date_pose"
        GridColumn19.Name = "date_pose"
        GridColumn20.DataPropertyName = "qui"
        GridColumn20.HeaderText = "qui"
        GridColumn20.Name = "qui"
        GridColumn21.DataPropertyName = "idcables_details"
        GridColumn21.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridIntegerInputEditControl)
        GridColumn21.HeaderText = "idcables_details"
        GridColumn21.Name = "idcables_details"
        GridColumn21.Visible = false
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
        Me.SuperGridControl1.PrimaryGrid.Columns.Add(GridColumn12)
        Me.SuperGridControl1.PrimaryGrid.Columns.Add(GridColumn13)
        Me.SuperGridControl1.PrimaryGrid.Columns.Add(GridColumn14)
        Me.SuperGridControl1.PrimaryGrid.Columns.Add(GridColumn15)
        Me.SuperGridControl1.PrimaryGrid.Columns.Add(GridColumn16)
        Me.SuperGridControl1.PrimaryGrid.Columns.Add(GridColumn17)
        Me.SuperGridControl1.PrimaryGrid.Columns.Add(GridColumn18)
        Me.SuperGridControl1.PrimaryGrid.Columns.Add(GridColumn19)
        Me.SuperGridControl1.PrimaryGrid.Columns.Add(GridColumn20)
        Me.SuperGridControl1.PrimaryGrid.Columns.Add(GridColumn21)
        Me.SuperGridControl1.PrimaryGrid.DataSource = Me.Lst_dispo_tirageBindingSource
        Me.SuperGridControl1.PrimaryGrid.EnableCellExpressions = true
        Me.SuperGridControl1.PrimaryGrid.EnableColumnFiltering = true
        Me.SuperGridControl1.PrimaryGrid.EnableFiltering = true
        Me.SuperGridControl1.PrimaryGrid.EnableRowFiltering = true
        Me.SuperGridControl1.PrimaryGrid.Filter.Visible = true
        Me.SuperGridControl1.PrimaryGrid.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions
        Me.SuperGridControl1.Size = New System.Drawing.Size(1324, 640)
        Me.SuperGridControl1.TabIndex = 0
        Me.SuperGridControl1.Text = "SuperGridControl1"
        '
        'Lst_dispo_tirageBindingSource
        '
        Me.Lst_dispo_tirageBindingSource.DataMember = "lst_dispo_tirage"
        Me.Lst_dispo_tirageBindingSource.DataSource = Me.MydbDataSet
        '
        'MydbDataSet
        '
        Me.MydbDataSet.DataSetName = "mydbDataSet"
        Me.MydbDataSet.EnforceConstraints = false
        Me.MydbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Location = New System.Drawing.Point(272, 45)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(229, 23)
        Me.LabelX3.TabIndex = 1
        Me.LabelX3.Text = "LabelX1"
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Location = New System.Drawing.Point(12, 45)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(229, 23)
        Me.LabelX4.TabIndex = 1
        Me.LabelX4.Text = "LabelX1"
        '
        'LabelX5
        '
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Location = New System.Drawing.Point(515, 45)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(213, 23)
        Me.LabelX5.TabIndex = 1
        Me.LabelX5.Text = "LabelX1"
        '
        'LabelX7
        '
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.Location = New System.Drawing.Point(795, 45)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(134, 23)
        Me.LabelX7.TabIndex = 1
        Me.LabelX7.Text = "LabelX1"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"),System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "ok")
        Me.ImageList1.Images.SetKeyName(1, "stop")
        Me.ImageList1.Images.SetKeyName(2, "pkoi")
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX1.Location = New System.Drawing.Point(1137, 45)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Size = New System.Drawing.Size(75, 23)
        Me.ButtonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX1.TabIndex = 3
        Me.ButtonX1.Text = "Voir Tout"
        '
        'ButtonX2
        '
        Me.ButtonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.ButtonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX2.Location = New System.Drawing.Point(1230, 45)
        Me.ButtonX2.Name = "ButtonX2"
        Me.ButtonX2.Size = New System.Drawing.Size(75, 23)
        Me.ButtonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX2.TabIndex = 3
        Me.ButtonX2.Text = "Oportunités"
        '
        'Lst_dispo_tirageTableAdapter
        '
        Me.Lst_dispo_tirageTableAdapter.ClearBeforeFill = true
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
        'Cables_detailsBindingSource
        '
        Me.Cables_detailsBindingSource.DataMember = "cables_details"
        Me.Cables_detailsBindingSource.DataSource = Me.MydbDataSet
        '
        'Cables_detailsTableAdapter
        '
        Me.Cables_detailsTableAdapter.ClearBeforeFill = true
        '
        'Cables_details_has_tourets_poseBindingSource
        '
        Me.Cables_details_has_tourets_poseBindingSource.DataMember = "cables_details_has_tourets_pose"
        Me.Cables_details_has_tourets_poseBindingSource.DataSource = Me.MydbDataSet
        '
        'Cables_details_has_tourets_poseTableAdapter
        '
        Me.Cables_details_has_tourets_poseTableAdapter.ClearBeforeFill = true
        '
        'Cables_details_has_touretsBindingSource
        '
        Me.Cables_details_has_touretsBindingSource.DataMember = "cables_details_has_tourets"
        Me.Cables_details_has_touretsBindingSource.DataSource = Me.MydbDataSet
        '
        'Cables_details_has_touretsTableAdapter
        '
        Me.Cables_details_has_touretsTableAdapter.ClearBeforeFill = true
        '
        'TouretsBindingSource
        '
        Me.TouretsBindingSource.DataMember = "tourets"
        Me.TouretsBindingSource.DataSource = Me.MydbDataSet
        '
        'TouretsTableAdapter
        '
        Me.TouretsTableAdapter.ClearBeforeFill = true
        '
        'CablesBindingSource
        '
        Me.CablesBindingSource.DataMember = "cables"
        Me.CablesBindingSource.DataSource = Me.MydbDataSet
        '
        'CablesTableAdapter
        '
        Me.CablesTableAdapter.ClearBeforeFill = true
        '
        'FormDispoTirage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1328, 717)
        Me.Controls.Add(Me.ButtonX2)
        Me.Controls.Add(Me.ButtonX1)
        Me.Controls.Add(Me.LabelX7)
        Me.Controls.Add(Me.LabelX5)
        Me.Controls.Add(Me.LabelX4)
        Me.Controls.Add(Me.LabelX3)
        Me.Controls.Add(Me.SuperGridControl1)
        Me.DoubleBuffered = true
        Me.Name = "FormDispoTirage"
        Me.Text = "FormDispoTirage"
        CType(Me.Lst_dispo_tirageBindingSource,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.MydbDataSet,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.Cables_detailsBindingSource,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.Cables_details_has_tourets_poseBindingSource,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.Cables_details_has_touretsBindingSource,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TouretsBindingSource,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.CablesBindingSource,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents MydbDataSet As progelec.mydbDataSet
    Friend WithEvents Lst_dispo_tirageBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Lst_dispo_tirageTableAdapter As progelec.mydbDataSetTableAdapters.lst_dispo_tirageTableAdapter
    Friend WithEvents TableAdapterManager As progelec.mydbDataSetTableAdapters.TableAdapterManager
    Friend WithEvents SuperGridControl1 As DevComponents.DotNetBar.SuperGrid.SuperGridControl
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Cables_detailsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Cables_detailsTableAdapter As progelec.mydbDataSetTableAdapters.cables_detailsTableAdapter
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX2 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Cables_details_has_tourets_poseBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Cables_details_has_tourets_poseTableAdapter As progelec.mydbDataSetTableAdapters.cables_details_has_tourets_poseTableAdapter
    Friend WithEvents Cables_details_has_touretsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Cables_details_has_touretsTableAdapter As progelec.mydbDataSetTableAdapters.cables_details_has_touretsTableAdapter
    Friend WithEvents TouretsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TouretsTableAdapter As progelec.mydbDataSetTableAdapters.touretsTableAdapter
    Friend WithEvents CablesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CablesTableAdapter As progelec.mydbDataSetTableAdapters.cablesTableAdapter
End Class
