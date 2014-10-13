<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSynoptique
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSynoptique))
        Me.NDrawingDocument1 = New Nevron.Diagram.NDrawingDocument()
        Me.NDrawingView1 = New Nevron.Diagram.WinForm.NDrawingView()
        Me.NLibraryDocument1 = New Nevron.Diagram.NLibraryDocument()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.MydbDataSet = New progelec.mydbDataSet()
        Me.Lst_cablesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Lst_cablesTableAdapter = New progelec.mydbDataSetTableAdapters.lst_cablesTableAdapter()
        Me.TableAdapterManager = New progelec.mydbDataSetTableAdapters.TableAdapterManager()
        Me.CablesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CablesTableAdapter = New progelec.mydbDataSetTableAdapters.cablesTableAdapter()
        Me.EquipementsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EquipementsTableAdapter = New progelec.mydbDataSetTableAdapters.equipementsTableAdapter()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.CheckBoxX1 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.CheckBoxX2 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.CheckBoxX3 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.CheckBoxX4 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.BatimentsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.BatimentsTableAdapter = New progelec.mydbDataSetTableAdapters.batimentsTableAdapter()
        Me.CheckBoxX5 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Lst_equipementsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Lst_equipementsTableAdapter = New progelec.mydbDataSetTableAdapters.lst_equipementsTableAdapter()
        CType(Me.MydbDataSet,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.Lst_cablesBindingSource,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.CablesBindingSource,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.EquipementsBindingSource,System.ComponentModel.ISupportInitialize).BeginInit
        Me.Panel1.SuspendLayout
        CType(Me.BatimentsBindingSource,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.Lst_equipementsBindingSource,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'NDrawingDocument1
        '
        Me.NDrawingDocument1.DesignTimeState = CType(resources.GetObject("NDrawingDocument1.DesignTimeState"),Nevron.Diagram.NBinaryState)
        '
        'NDrawingView1
        '
        Me.NDrawingView1.AllowDrop = true
        Me.NDrawingView1.DesignTimeState = CType(resources.GetObject("NDrawingView1.DesignTimeState"),Nevron.Diagram.NBinaryState)
        Me.NDrawingView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NDrawingView1.Document = Me.NDrawingDocument1
        Me.NDrawingView1.Location = New System.Drawing.Point(0, 0)
        Me.NDrawingView1.Name = "NDrawingView1"
        Me.NDrawingView1.Size = New System.Drawing.Size(1391, 671)
        Me.NDrawingView1.TabIndex = 0
        Me.NDrawingView1.Text = "NDrawingView1"
        '
        'NLibraryDocument1
        '
        Me.NLibraryDocument1.DesignTimeState = CType(resources.GetObject("NLibraryDocument1.DesignTimeState"),Nevron.Diagram.NBinaryState)
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(1218, 21)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Generation"
        Me.Button1.UseVisualStyleBackColor = true
        '
        'MydbDataSet
        '
        Me.MydbDataSet.DataSetName = "mydbDataSet"
        Me.MydbDataSet.EnforceConstraints = false
        Me.MydbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Lst_cablesBindingSource
        '
        Me.Lst_cablesBindingSource.DataMember = "lst_cables"
        Me.Lst_cablesBindingSource.DataSource = Me.MydbDataSet
        '
        'Lst_cablesTableAdapter
        '
        Me.Lst_cablesTableAdapter.ClearBeforeFill = true
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
        'CablesBindingSource
        '
        Me.CablesBindingSource.DataMember = "cables"
        Me.CablesBindingSource.DataSource = Me.MydbDataSet
        '
        'CablesTableAdapter
        '
        Me.CablesTableAdapter.ClearBeforeFill = true
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
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.NDrawingView1)
        Me.Panel1.Location = New System.Drawing.Point(12, 61)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1391, 671)
        Me.Panel1.TabIndex = 2
        '
        'ComboBox1
        '
        Me.ComboBox1.DataSource = Me.EquipementsBindingSource
        Me.ComboBox1.DisplayMember = "repere equipement"
        Me.ComboBox1.FormattingEnabled = true
        Me.ComboBox1.Location = New System.Drawing.Point(860, 34)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox1.TabIndex = 3
        Me.ComboBox1.ValueMember = "idequipement"
        '
        'CheckBoxX1
        '
        Me.CheckBoxX1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        '
        '
        '
        Me.CheckBoxX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxX1.Location = New System.Drawing.Point(1429, 138)
        Me.CheckBoxX1.Name = "CheckBoxX1"
        Me.CheckBoxX1.Size = New System.Drawing.Size(100, 23)
        Me.CheckBoxX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CheckBoxX1.TabIndex = 4
        Me.CheckBoxX1.Text = "Qui m'alimente ?"
        '
        'CheckBoxX2
        '
        Me.CheckBoxX2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        '
        '
        '
        Me.CheckBoxX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxX2.Location = New System.Drawing.Point(1429, 182)
        Me.CheckBoxX2.Name = "CheckBoxX2"
        Me.CheckBoxX2.Size = New System.Drawing.Size(100, 23)
        Me.CheckBoxX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CheckBoxX2.TabIndex = 4
        Me.CheckBoxX2.Text = "J'alimente Qui ?"
        '
        'LabelX1
        '
        Me.LabelX1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(1429, 99)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(75, 23)
        Me.LabelX1.TabIndex = 5
        Me.LabelX1.Text = "Annalyse"
        '
        'CheckBoxX3
        '
        Me.CheckBoxX3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        '
        '
        '
        Me.CheckBoxX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxX3.Location = New System.Drawing.Point(1413, 275)
        Me.CheckBoxX3.Name = "CheckBoxX3"
        Me.CheckBoxX3.Size = New System.Drawing.Size(134, 23)
        Me.CheckBoxX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CheckBoxX3.TabIndex = 4
        Me.CheckBoxX3.Text = "Tous les successeurs"
        '
        'CheckBoxX4
        '
        Me.CheckBoxX4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        '
        '
        '
        Me.CheckBoxX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxX4.Location = New System.Drawing.Point(1413, 314)
        Me.CheckBoxX4.Name = "CheckBoxX4"
        Me.CheckBoxX4.Size = New System.Drawing.Size(134, 23)
        Me.CheckBoxX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CheckBoxX4.TabIndex = 4
        Me.CheckBoxX4.Text = "Tous les predecesseurs"
        '
        'ComboBox2
        '
        Me.ComboBox2.DataSource = Me.BatimentsBindingSource
        Me.ComboBox2.DisplayMember = "Nom"
        Me.ComboBox2.FormattingEnabled = true
        Me.ComboBox2.Location = New System.Drawing.Point(216, 34)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox2.TabIndex = 3
        Me.ComboBox2.ValueMember = "idBatiment"
        '
        'BatimentsBindingSource
        '
        Me.BatimentsBindingSource.DataMember = "batiments"
        Me.BatimentsBindingSource.DataSource = Me.MydbDataSet
        '
        'LabelX2
        '
        Me.LabelX2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Location = New System.Drawing.Point(411, 5)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(75, 23)
        Me.LabelX2.TabIndex = 5
        Me.LabelX2.Text = "Batiment"
        '
        'BatimentsTableAdapter
        '
        Me.BatimentsTableAdapter.ClearBeforeFill = true
        '
        'CheckBoxX5
        '
        '
        '
        '
        Me.CheckBoxX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxX5.Location = New System.Drawing.Point(660, 32)
        Me.CheckBoxX5.Name = "CheckBoxX5"
        Me.CheckBoxX5.Size = New System.Drawing.Size(178, 23)
        Me.CheckBoxX5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CheckBoxX5.TabIndex = 6
        Me.CheckBoxX5.Text = "Filtre equipements tenant"
        '
        'Lst_equipementsBindingSource
        '
        Me.Lst_equipementsBindingSource.DataMember = "lst_equipements"
        Me.Lst_equipementsBindingSource.DataSource = Me.MydbDataSet
        '
        'Lst_equipementsTableAdapter
        '
        Me.Lst_equipementsTableAdapter.ClearBeforeFill = true
        '
        'FormSynoptique
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1559, 734)
        Me.Controls.Add(Me.CheckBoxX5)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.CheckBoxX4)
        Me.Controls.Add(Me.CheckBoxX3)
        Me.Controls.Add(Me.CheckBoxX2)
        Me.Controls.Add(Me.CheckBoxX1)
        Me.Controls.Add(Me.ComboBox2)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Button1)
        Me.DoubleBuffered = true
        Me.Name = "FormSynoptique"
        Me.Text = "Synoptique.."
        CType(Me.MydbDataSet,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.Lst_cablesBindingSource,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.CablesBindingSource,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.EquipementsBindingSource,System.ComponentModel.ISupportInitialize).EndInit
        Me.Panel1.ResumeLayout(false)
        CType(Me.BatimentsBindingSource,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.Lst_equipementsBindingSource,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents NDrawingDocument1 As Nevron.Diagram.NDrawingDocument
    Friend WithEvents NDrawingView1 As Nevron.Diagram.WinForm.NDrawingView
    Friend WithEvents NLibraryDocument1 As Nevron.Diagram.NLibraryDocument
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents MydbDataSet As progelec.mydbDataSet
    Friend WithEvents Lst_cablesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Lst_cablesTableAdapter As progelec.mydbDataSetTableAdapters.lst_cablesTableAdapter
    Friend WithEvents TableAdapterManager As progelec.mydbDataSetTableAdapters.TableAdapterManager
    Friend WithEvents CablesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CablesTableAdapter As progelec.mydbDataSetTableAdapters.cablesTableAdapter
    Friend WithEvents EquipementsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EquipementsTableAdapter As progelec.mydbDataSetTableAdapters.equipementsTableAdapter
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents CheckBoxX1 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents CheckBoxX2 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents CheckBoxX3 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents CheckBoxX4 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents BatimentsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents BatimentsTableAdapter As progelec.mydbDataSetTableAdapters.batimentsTableAdapter
    Friend WithEvents CheckBoxX5 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Lst_equipementsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Lst_equipementsTableAdapter As progelec.mydbDataSetTableAdapters.lst_equipementsTableAdapter
End Class
