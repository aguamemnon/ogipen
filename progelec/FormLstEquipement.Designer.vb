<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormLstEquipement
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
        Me.MydbDataSet = New progelec.MydbDataSet()
        Me.Lst_equipementsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Lst_equipementsTableAdapter = New progelec.MydbDataSetTableAdapters.lst_equipementsTableAdapter()
        Me.TableAdapterManager = New progelec.MydbDataSetTableAdapters.TableAdapterManager()
        Me.SuperGridControl = New DevComponents.DotNetBar.SuperGrid.SuperGridControl()
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        CType(Me.MydbDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Lst_equipementsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MydbDataSet
        '
        Me.MydbDataSet.DataSetName = "MydbDataSet"
        Me.MydbDataSet.EnforceConstraints = False
        Me.MydbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
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
        Me.TableAdapterManager.UpdateOrder = progelec.MydbDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'SuperGridControl
        '
        Me.SuperGridControl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SuperGridControl.BackColor = System.Drawing.Color.White
        Me.SuperGridControl.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed
        Me.SuperGridControl.FilterUseExtendedCustomDialog = True
        Me.SuperGridControl.ForeColor = System.Drawing.Color.Black
        Me.SuperGridControl.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.SuperGridControl.Location = New System.Drawing.Point(12, 54)
        Me.SuperGridControl.Name = "SuperGridControl"
        Me.SuperGridControl.PrimaryGrid.AllowEdit = False
        GridColumn1.DataPropertyName = "nom"
        GridColumn1.HeaderText = "Batiment"
        GridColumn1.Name = "nom"
        GridColumn2.DataPropertyName = "repere salle"
        GridColumn2.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        GridColumn2.FilterAutoScan = True
        GridColumn2.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions
        GridColumn2.HeaderText = "repere salle"
        GridColumn2.Name = "repere salle"
        GridColumn2.ShowPanelFilterExpr = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        GridColumn3.DataPropertyName = "Niveau"
        GridColumn3.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        GridColumn3.FilterAutoScan = True
        GridColumn3.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions
        GridColumn3.HeaderText = "Niveau"
        GridColumn3.Name = "Niveau"
        GridColumn3.ShowPanelFilterExpr = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        GridColumn4.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.Multiple
        GridColumn4.DataPropertyName = "repere equipement"
        GridColumn4.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        GridColumn4.EnableGroupHeaderMarkup = True
        GridColumn4.FilterAutoScan = True
        GridColumn4.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions
        GridColumn4.GroupBoxEffects = DevComponents.DotNetBar.SuperGrid.GroupBoxEffects.Move
        GridColumn4.HeaderText = "repere equipement"
        GridColumn4.Name = "repere equipement"
        GridColumn4.ShowPanelFilterExpr = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        GridColumn5.DataPropertyName = "designation"
        GridColumn5.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        GridColumn5.FilterAutoScan = True
        GridColumn5.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions
        GridColumn5.HeaderText = "designation"
        GridColumn5.Name = "designation"
        GridColumn5.ShowPanelFilterExpr = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        GridColumn6.DataPropertyName = "Categorie"
        GridColumn6.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        GridColumn6.FilterAutoScan = True
        GridColumn6.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions
        GridColumn6.HeaderText = "Categorie"
        GridColumn6.Name = "Categorie"
        GridColumn6.ShowPanelFilterExpr = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        GridColumn7.DataPropertyName = "lot"
        GridColumn7.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        GridColumn7.FilterAutoScan = True
        GridColumn7.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions
        GridColumn7.HeaderText = "lot"
        GridColumn7.Name = "lot"
        GridColumn7.ShowPanelFilterExpr = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        GridColumn8.DataPropertyName = "designation1"
        GridColumn8.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        GridColumn8.FilterAutoScan = True
        GridColumn8.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions
        GridColumn8.HeaderText = "Detail"
        GridColumn8.Name = "designation1"
        GridColumn8.ShowPanelFilterExpr = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        GridColumn9.DataPropertyName = "Entreprise"
        GridColumn9.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        GridColumn9.FilterAutoScan = True
        GridColumn9.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions
        GridColumn9.HeaderText = "Entreprise"
        GridColumn9.Name = "Entreprise"
        GridColumn9.ShowPanelFilterExpr = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        GridColumn10.DataPropertyName = "date"
        GridColumn10.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridDateTimeInputEditControl)
        GridColumn10.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        GridColumn10.FilterAutoScan = True
        GridColumn10.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions
        GridColumn10.HeaderText = "date"
        GridColumn10.Name = "date"
        GridColumn10.ShowPanelFilterExpr = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        GridColumn11.DataPropertyName = "revision"
        GridColumn11.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridIntegerInputEditControl)
        GridColumn11.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        GridColumn11.FilterAutoScan = True
        GridColumn11.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions
        GridColumn11.HeaderText = "revision"
        GridColumn11.Name = "revision"
        GridColumn11.ShowPanelFilterExpr = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        GridColumn12.DataPropertyName = "qui"
        GridColumn12.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        GridColumn12.FilterAutoScan = True
        GridColumn12.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions
        GridColumn12.HeaderText = "qui"
        GridColumn12.Name = "qui"
        GridColumn12.ShowPanelFilterExpr = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        GridColumn13.DataPropertyName = "idequipement"
        GridColumn13.HeaderText = "id"
        GridColumn13.Name = "idequipement"
        GridColumn13.Visible = False
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
        Me.SuperGridControl.PrimaryGrid.DataSource = Me.Lst_equipementsBindingSource
        Me.SuperGridControl.PrimaryGrid.EnableColumnFiltering = True
        Me.SuperGridControl.PrimaryGrid.EnableFiltering = True
        Me.SuperGridControl.PrimaryGrid.EnableRowFiltering = True
        Me.SuperGridControl.PrimaryGrid.Filter.ShowPanelFilterExpr = True
        Me.SuperGridControl.PrimaryGrid.Filter.Visible = True
        Me.SuperGridControl.PrimaryGrid.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions
        Me.SuperGridControl.Size = New System.Drawing.Size(1338, 601)
        Me.SuperGridControl.TabIndex = 0
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX1.Location = New System.Drawing.Point(12, 13)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Size = New System.Drawing.Size(143, 35)
        Me.ButtonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX1.Symbol = ""
        Me.ButtonX1.TabIndex = 1
        Me.ButtonX1.Text = "Rafraichissement"
        '
        'FormLstEquipement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1362, 685)
        Me.Controls.Add(Me.ButtonX1)
        Me.Controls.Add(Me.SuperGridControl)
        Me.Name = "FormLstEquipement"
        Me.Text = "Liste Equipements"
        CType(Me.MydbDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Lst_equipementsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MydbDataSet As progelec.MydbDataSet
    Friend WithEvents Lst_equipementsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Lst_equipementsTableAdapter As progelec.MydbDataSetTableAdapters.lst_equipementsTableAdapter
    Friend WithEvents TableAdapterManager As progelec.MydbDataSetTableAdapters.TableAdapterManager
    Private WithEvents SuperGridControl As DevComponents.DotNetBar.SuperGrid.SuperGridControl
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX

End Class
