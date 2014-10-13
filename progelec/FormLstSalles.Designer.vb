<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormLstSalles
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
        Me.ButtonXGenerationDCC = New DevComponents.DotNetBar.ButtonX()
        Me.SuperGridControl = New DevComponents.DotNetBar.SuperGrid.SuperGridControl()
        Me.Lst_sallesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MydbDataSet = New progelec.mydbDataSet()
        Me.SallesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Lst_trc_salleBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Cables_troncon_idBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SallesTableAdapter = New progelec.mydbDataSetTableAdapters.sallesTableAdapter()
        Me.Lst_trc_salleTableAdapter = New progelec.mydbDataSetTableAdapters.lst_trc_salleTableAdapter()
        Me.Cables_troncon_idTableAdapter = New progelec.mydbDataSetTableAdapters.cables_troncon_idTableAdapter()
        Me.Lst_sallesTableAdapter = New progelec.mydbDataSetTableAdapters.lst_sallesTableAdapter()
        Me.TableAdapterManager = New progelec.mydbDataSetTableAdapters.TableAdapterManager()
        CType(Me.Lst_sallesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MydbDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SallesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Lst_trc_salleBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cables_troncon_idBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ButtonXGenerationDCC
        '
        Me.ButtonXGenerationDCC.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonXGenerationDCC.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonXGenerationDCC.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonXGenerationDCC.Location = New System.Drawing.Point(12, 31)
        Me.ButtonXGenerationDCC.Name = "ButtonXGenerationDCC"
        Me.ButtonXGenerationDCC.Size = New System.Drawing.Size(1036, 23)
        Me.ButtonXGenerationDCC.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonXGenerationDCC.TabIndex = 0
        Me.ButtonXGenerationDCC.Text = "Generation DCC"
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
        Me.SuperGridControl.Location = New System.Drawing.Point(12, 60)
        Me.SuperGridControl.Name = "SuperGridControl"
        GridColumn1.DataPropertyName = "idsalle"
        GridColumn1.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridIntegerInputEditControl)
        GridColumn1.HeaderText = "idsalle"
        GridColumn1.Name = "idsalle"
        GridColumn1.Visible = False
        GridColumn2.DataPropertyName = "Nom"
        GridColumn2.HeaderText = "Batiment"
        GridColumn2.Name = "Nom"
        GridColumn3.DataPropertyName = "repere salle"
        GridColumn3.HeaderText = "repere salle"
        GridColumn3.Name = "repere salle"
        GridColumn4.DataPropertyName = "Niveau"
        GridColumn4.HeaderText = "Niveau"
        GridColumn4.Name = "Niveau"
        GridColumn5.DataPropertyName = "designation"
        GridColumn5.HeaderText = "designation"
        GridColumn5.Name = "designation"
        GridColumn6.DataPropertyName = "Hauteur"
        GridColumn6.HeaderText = "Hauteur"
        GridColumn6.Name = "Hauteur"
        GridColumn7.DataPropertyName = "Largeur"
        GridColumn7.HeaderText = "Largeur"
        GridColumn7.Name = "Largeur"
        GridColumn8.DataPropertyName = "Longueur"
        GridColumn8.HeaderText = "Longueur"
        GridColumn8.Name = "Longueur"
        GridColumn9.DataPropertyName = "dcc"
        GridColumn9.HeaderText = "dcc"
        GridColumn9.Name = "dcc"
        GridColumn10.DataPropertyName = "qui"
        GridColumn10.HeaderText = "qui"
        GridColumn10.Name = "qui"
        GridColumn11.DataPropertyName = "date"
        GridColumn11.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridDateTimeInputEditControl)
        GridColumn11.HeaderText = "date"
        GridColumn11.Name = "date"
        GridColumn12.DataPropertyName = "version"
        GridColumn12.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridIntegerInputEditControl)
        GridColumn12.HeaderText = "version"
        GridColumn12.Name = "version"
        GridColumn13.DataPropertyName = "Batiments_idBatiment"
        GridColumn13.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridIntegerInputEditControl)
        GridColumn13.HeaderText = "Batiments_idBatiment"
        GridColumn13.Name = "Batiments_idBatiment"
        GridColumn13.Visible = False
        GridColumn14.DataPropertyName = "idBatiment"
        GridColumn14.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridIntegerInputEditControl)
        GridColumn14.HeaderText = "idBatiment"
        GridColumn14.Name = "idBatiment"
        GridColumn14.Visible = False
        GridColumn15.DataPropertyName = "Designation1"
        GridColumn15.HeaderText = "DescBat"
        GridColumn15.Name = "Designation1"
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
        Me.SuperGridControl.PrimaryGrid.DataSource = Me.Lst_sallesBindingSource
        Me.SuperGridControl.PrimaryGrid.EnableFiltering = True
        Me.SuperGridControl.PrimaryGrid.EnableRowFiltering = True
        Me.SuperGridControl.PrimaryGrid.Filter.Visible = True
        Me.SuperGridControl.PrimaryGrid.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions
        Me.SuperGridControl.PrimaryGrid.ShowTreeButtons = True
        Me.SuperGridControl.PrimaryGrid.ShowTreeLines = True
        Me.SuperGridControl.Size = New System.Drawing.Size(1036, 440)
        Me.SuperGridControl.TabIndex = 1
        '
        'Lst_sallesBindingSource
        '
        Me.Lst_sallesBindingSource.DataMember = "lst_salles"
        Me.Lst_sallesBindingSource.DataSource = Me.MydbDataSet
        '
        'MydbDataSet
        '
        Me.MydbDataSet.DataSetName = "mydbDataSet"
        Me.MydbDataSet.EnforceConstraints = False
        Me.MydbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'SallesBindingSource
        '
        Me.SallesBindingSource.DataMember = "salles"
        Me.SallesBindingSource.DataSource = Me.MydbDataSet
        '
        'Lst_trc_salleBindingSource
        '
        Me.Lst_trc_salleBindingSource.DataMember = "lst_trc_salle"
        Me.Lst_trc_salleBindingSource.DataSource = Me.MydbDataSet
        '
        'Cables_troncon_idBindingSource
        '
        Me.Cables_troncon_idBindingSource.DataMember = "cables_troncon_id"
        Me.Cables_troncon_idBindingSource.DataSource = Me.MydbDataSet
        '
        'SallesTableAdapter
        '
        Me.SallesTableAdapter.ClearBeforeFill = True
        '
        'Lst_trc_salleTableAdapter
        '
        Me.Lst_trc_salleTableAdapter.ClearBeforeFill = True
        '
        'Cables_troncon_idTableAdapter
        '
        Me.Cables_troncon_idTableAdapter.ClearBeforeFill = True
        '
        'Lst_sallesTableAdapter
        '
        Me.Lst_sallesTableAdapter.ClearBeforeFill = True
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
        Me.TableAdapterManager.sallesTableAdapter = Me.SallesTableAdapter
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
        'FormLstSalles
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1068, 520)
        Me.Controls.Add(Me.SuperGridControl)
        Me.Controls.Add(Me.ButtonXGenerationDCC)
        Me.Name = "FormLstSalles"
        Me.Text = "Liste Salles"
        CType(Me.Lst_sallesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MydbDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SallesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Lst_trc_salleBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cables_troncon_idBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SallesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SallesTableAdapter As progelec.mydbDataSetTableAdapters.sallesTableAdapter

    Private WithEvents ButtonXGenerationDCC As DevComponents.DotNetBar.ButtonX
    Private WithEvents SuperGridControl As DevComponents.DotNetBar.SuperGrid.SuperGridControl
    Friend WithEvents Lst_trc_salleBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Lst_trc_salleTableAdapter As progelec.mydbDataSetTableAdapters.lst_trc_salleTableAdapter
    Friend WithEvents Cables_troncon_idBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Cables_troncon_idTableAdapter As progelec.mydbDataSetTableAdapters.cables_troncon_idTableAdapter

    Friend WithEvents MydbDataSet As progelec.mydbDataSet
    Friend WithEvents Lst_sallesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Lst_sallesTableAdapter As progelec.mydbDataSetTableAdapters.lst_sallesTableAdapter
    Friend WithEvents TableAdapterManager As progelec.mydbDataSetTableAdapters.TableAdapterManager

End Class
