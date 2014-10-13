<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDsipoCheminements
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormDsipoCheminements))
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
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.SuperGridControl = New DevComponents.DotNetBar.SuperGrid.SuperGridControl()
        Me.Troncons_statusBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MydbDataSet = New progelec.mydbDataSet()
        Me.LabelXPoidsTotal = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.ButtonXPossibiliees = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX2 = New DevComponents.DotNetBar.ButtonX()
        Me.Troncons_statusTableAdapter = New progelec.mydbDataSetTableAdapters.troncons_statusTableAdapter()
        Me.TableAdapterManager = New progelec.mydbDataSetTableAdapters.TableAdapterManager()
        Me.TronconsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TronconsTableAdapter = New progelec.mydbDataSetTableAdapters.tronconsTableAdapter()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        CType(Me.Troncons_statusBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MydbDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TronconsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "dispo")
        Me.ImageList1.Images.SetKeyName(1, "blocage")
        Me.ImageList1.Images.SetKeyName(2, "blocage2")
        '
        'SuperGridControl
        '
        Me.SuperGridControl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SuperGridControl.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed
        Me.SuperGridControl.FilterUseExtendedCustomDialog = True
        Me.SuperGridControl.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.SuperGridControl.Location = New System.Drawing.Point(12, 101)
        Me.SuperGridControl.Name = "SuperGridControl"
        GridColumn1.DataPropertyName = "idtroncons"
        GridColumn1.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridIntegerInputEditControl)
        GridColumn1.HeaderText = "idtroncons"
        GridColumn1.Name = "idtroncons"
        GridColumn1.Visible = False
        GridColumn2.DataPropertyName = "Possible"
        GridColumn2.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl)
        GridColumn2.HeaderText = "Possible"
        GridColumn2.Name = "Possible"
        GridColumn3.DataPropertyName = "pose"
        GridColumn3.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridSwitchButtonEditControl)
        GridColumn3.HeaderText = "pose"
        GridColumn3.Name = "pose"
        GridColumn4.DataPropertyName = "repere troncon"
        GridColumn4.HeaderText = "repere troncon"
        GridColumn4.Name = "repere troncon"
        GridColumn5.DataPropertyName = "salle_tenante"
        GridColumn5.HeaderText = "salle_tenante"
        GridColumn5.Name = "salle_tenante"
        GridColumn6.DataPropertyName = "statut"
        GridColumn6.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl)
        GridColumn6.HeaderText = "statut"
        GridColumn6.Name = "statut"
        GridColumn7.DataPropertyName = "salle_about"
        GridColumn7.HeaderText = "salle_about"
        GridColumn7.Name = "salle_about"
        GridColumn8.DataPropertyName = "statut1"
        GridColumn8.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl)
        GridColumn8.HeaderText = "statut1"
        GridColumn8.Name = "statut1"
        GridColumn9.DataPropertyName = "id_sall_tenant"
        GridColumn9.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridIntegerInputEditControl)
        GridColumn9.HeaderText = "id_sall_tenant"
        GridColumn9.Name = "id_sall_tenant"
        GridColumn9.Visible = False
        GridColumn10.DataPropertyName = "id_sall_about"
        GridColumn10.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridIntegerInputEditControl)
        GridColumn10.HeaderText = "id_sall_about"
        GridColumn10.Name = "id_sall_about"
        GridColumn10.Visible = False
        GridColumn11.DataPropertyName = "date_pose"
        GridColumn11.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridDateTimeInputEditControl)
        GridColumn11.HeaderText = "date_pose"
        GridColumn11.Name = "date_pose"
        GridColumn12.DataPropertyName = "qui"
        GridColumn12.HeaderText = "qui"
        GridColumn12.Name = "qui"
        GridColumn13.DataPropertyName = "temp_de_pose"
        GridColumn13.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridDoubleInputEditControl)
        GridColumn13.HeaderText = "temp_de_pose"
        GridColumn13.Name = "temp_de_pose"
        GridColumn14.DataPropertyName = "longueur"
        GridColumn14.HeaderText = "longueur"
        GridColumn14.Name = "longueur"
        GridColumn15.DataPropertyName = "TempPoseMetre"
        GridColumn15.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridDoubleInputEditControl)
        GridColumn15.HeaderText = "TempPoseMetre"
        GridColumn15.Name = "TempPoseMetre"
        GridColumn16.DataPropertyName = "Quant"
        GridColumn16.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridIntegerInputEditControl)
        GridColumn16.HeaderText = "Quant"
        GridColumn16.Name = "Quant"
        GridColumn17.DataPropertyName = "ifnull(`fournitures`.`TempPoseMetre`,0)"
        GridColumn17.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridDoubleInputEditControl)
        GridColumn17.HeaderText = "ifnull(`fournitures`.`TempPoseMetre`,0)"
        GridColumn17.Name = "ifnull(`fournitures`.`TempPoseMetre`,0)"
        GridColumn18.DataPropertyName = "ifnull(`troncons_fournitures`.`Quant`,0)"
        GridColumn18.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridDoubleIntInputEditControl)
        GridColumn18.HeaderText = "ifnull(`troncons_fournitures`.`Quant`,0)"
        GridColumn18.Name = "ifnull(`troncons_fournitures`.`Quant`,0)"
        Me.SuperGridControl.PrimaryGrid.Columns.Add(GridColumn1)
        Me.SuperGridControl.PrimaryGrid.Columns.Add(GridColumn2)
        Me.SuperGridControl.PrimaryGrid.Columns.Add(GridColumn3)
        Me.SuperGridControl.PrimaryGrid.Columns.Add(GridColumn4)
        Me.SuperGridControl.PrimaryGrid.Columns.Add(GridColumn5)
        Me.SuperGridControl.PrimaryGrid.Columns.Add(GridColumn6)
        Me.SuperGridControl.PrimaryGrid.Columns.Add(GridColumn7)
        Me.SuperGridControl.PrimaryGrid.Columns.Add(GridColumn8)
        Me.SuperGridControl.PrimaryGrid.Columns.Add(GridColumn9)
        Me.SuperGridControl.PrimaryGrid.Columns.Add(GridColumn10)
        Me.SuperGridControl.PrimaryGrid.Columns.Add(GridColumn11)
        Me.SuperGridControl.PrimaryGrid.Columns.Add(GridColumn12)
        Me.SuperGridControl.PrimaryGrid.Columns.Add(GridColumn13)
        Me.SuperGridControl.PrimaryGrid.Columns.Add(GridColumn14)
        Me.SuperGridControl.PrimaryGrid.Columns.Add(GridColumn15)
        Me.SuperGridControl.PrimaryGrid.Columns.Add(GridColumn16)
        Me.SuperGridControl.PrimaryGrid.Columns.Add(GridColumn17)
        Me.SuperGridControl.PrimaryGrid.Columns.Add(GridColumn18)
        Me.SuperGridControl.PrimaryGrid.DataSource = Me.Troncons_statusBindingSource
        Me.SuperGridControl.PrimaryGrid.EnableColumnFiltering = True
        Me.SuperGridControl.PrimaryGrid.EnableFiltering = True
        Me.SuperGridControl.PrimaryGrid.EnableRowFiltering = True
        Me.SuperGridControl.PrimaryGrid.Filter.ShowPanelFilterExpr = True
        Me.SuperGridControl.PrimaryGrid.Filter.Visible = True
        Me.SuperGridControl.PrimaryGrid.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions
        Me.SuperGridControl.PrimaryGrid.UseAlternateColumnStyle = True
        Me.SuperGridControl.Size = New System.Drawing.Size(1240, 415)
        Me.SuperGridControl.TabIndex = 2
        '
        'Troncons_statusBindingSource
        '
        Me.Troncons_statusBindingSource.DataMember = "troncons_status"
        Me.Troncons_statusBindingSource.DataSource = Me.MydbDataSet
        '
        'MydbDataSet
        '
        Me.MydbDataSet.DataSetName = "mydbDataSet"
        Me.MydbDataSet.EnforceConstraints = False
        Me.MydbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'LabelXPoidsTotal
        '
        '
        '
        '
        Me.LabelXPoidsTotal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelXPoidsTotal.Location = New System.Drawing.Point(299, 12)
        Me.LabelXPoidsTotal.Name = "LabelXPoidsTotal"
        Me.LabelXPoidsTotal.Size = New System.Drawing.Size(75, 23)
        Me.LabelXPoidsTotal.TabIndex = 3
        Me.LabelXPoidsTotal.Text = "Poids total"
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(467, 41)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(254, 23)
        Me.LabelX1.TabIndex = 3
        Me.LabelX1.Text = "Poids realisé"
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Location = New System.Drawing.Point(467, 12)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(75, 23)
        Me.LabelX2.TabIndex = 3
        Me.LabelX2.Text = "Poids realisé"
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Location = New System.Drawing.Point(218, 12)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(75, 23)
        Me.LabelX3.TabIndex = 3
        Me.LabelX3.Text = "Poids  total :"
        '
        'ButtonXPossibiliees
        '
        Me.ButtonXPossibiliees.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonXPossibiliees.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonXPossibiliees.Location = New System.Drawing.Point(12, 72)
        Me.ButtonXPossibiliees.Name = "ButtonXPossibiliees"
        Me.ButtonXPossibiliees.Size = New System.Drawing.Size(88, 23)
        Me.ButtonXPossibiliees.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014
        Me.ButtonXPossibiliees.TabIndex = 4
        Me.ButtonXPossibiliees.Text = "Possibiliées"
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX1.Location = New System.Drawing.Point(128, 72)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Size = New System.Drawing.Size(88, 23)
        Me.ButtonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014
        Me.ButtonX1.TabIndex = 4
        Me.ButtonX1.Text = "RAZ"
        '
        'ButtonX2
        '
        Me.ButtonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX2.Location = New System.Drawing.Point(234, 72)
        Me.ButtonX2.Name = "ButtonX2"
        Me.ButtonX2.Size = New System.Drawing.Size(88, 23)
        Me.ButtonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014
        Me.ButtonX2.TabIndex = 4
        Me.ButtonX2.Text = "Vers Excel =>"
        '
        'Troncons_statusTableAdapter
        '
        Me.Troncons_statusTableAdapter.ClearBeforeFill = True
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
        'TronconsBindingSource
        '
        Me.TronconsBindingSource.DataMember = "troncons"
        Me.TronconsBindingSource.DataSource = Me.MydbDataSet
        '
        'TronconsTableAdapter
        '
        Me.TronconsTableAdapter.ClearBeforeFill = True
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Location = New System.Drawing.Point(548, 12)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(75, 23)
        Me.LabelX4.TabIndex = 3
        Me.LabelX4.Text = "Poids realisé"
        '
        'FormDsipoCheminements
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1264, 528)
        Me.Controls.Add(Me.ButtonX2)
        Me.Controls.Add(Me.ButtonX1)
        Me.Controls.Add(Me.ButtonXPossibiliees)
        Me.Controls.Add(Me.LabelX3)
        Me.Controls.Add(Me.LabelX4)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.LabelXPoidsTotal)
        Me.Controls.Add(Me.SuperGridControl)
        Me.Name = "FormDsipoCheminements"
        Me.Text = "Pose Cheminements"
        CType(Me.Troncons_statusBindingSource,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.MydbDataSet,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TronconsBindingSource,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents MydbDataSet As progelec.mydbDataSet
    Friend WithEvents Troncons_statusBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Troncons_statusTableAdapter As progelec.mydbDataSetTableAdapters.troncons_statusTableAdapter
    Friend WithEvents TableAdapterManager As progelec.mydbDataSetTableAdapters.TableAdapterManager
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TronconsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TronconsTableAdapter As progelec.mydbDataSetTableAdapters.tronconsTableAdapter
    Private WithEvents SuperGridControl As DevComponents.DotNetBar.SuperGrid.SuperGridControl
    Private WithEvents LabelXPoidsTotal As DevComponents.DotNetBar.LabelX
    Private WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Private WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Private WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Private WithEvents ButtonXPossibiliees As DevComponents.DotNetBar.ButtonX
    Private WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Private WithEvents ButtonX2 As DevComponents.DotNetBar.ButtonX
    Private WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
End Class
