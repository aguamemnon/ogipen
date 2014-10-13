<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Formserge
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Formserge))
        Dim RoleBasedSecurityManager1 As Dataweb.NShape.RoleBasedSecurityManager = New Dataweb.NShape.RoleBasedSecurityManager()
        Me.DiagramSetController1 = New Dataweb.NShape.Controllers.DiagramSetController()
        Me.Project1 = New Dataweb.NShape.Project(Me.components)
        Me.CachedRepository1 = New Dataweb.NShape.Advanced.CachedRepository()
        Me.XmlStore1 = New Dataweb.NShape.XmlStore()
        Me.ToolSetController1 = New Dataweb.NShape.Controllers.ToolSetController()
        Me.ToolSetListViewPresenter1 = New Dataweb.NShape.WinFormsUI.ToolSetListViewPresenter(Me.components)
        Me.ButtonX3 = New DevComponents.DotNetBar.ButtonX()
        Me.NDrawingView1 = New Nevron.Diagram.WinForm.NDrawingView()
        Me.NDrawingDocument1 = New Nevron.Diagram.NDrawingDocument()
        Me.NLibraryDocument1 = New Nevron.Diagram.NLibraryDocument()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ComboBoxEx1 = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.SallesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MydbDataSet1 = New progelec.mydbDataSet()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.ComboBoxEx2 = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.SallesBindingSource2 = New System.Windows.Forms.BindingSource(Me.components)
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.ComboBoxEx3 = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.BatimentsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.CheckBoxX1 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.CheckBoxX2 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.ComboBoxEx4 = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.SegregationsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.TextBoxX1 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TextBoxX2 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.TronconsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TronconsTableAdapter = New progelec.mydbDataSetTableAdapters.tronconsTableAdapter()
        Me.TableAdapterManager = New progelec.mydbDataSetTableAdapters.TableAdapterManager()
        Me.Troncons_assocTableAdapter = New progelec.mydbDataSetTableAdapters.troncons_assocTableAdapter()
        Me.Troncons_assocBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BatimentsTableAdapter = New progelec.mydbDataSetTableAdapters.batimentsTableAdapter()
        Me.SallesTableAdapter = New progelec.mydbDataSetTableAdapters.sallesTableAdapter()
        Me.SegregationsTableAdapter = New progelec.mydbDataSetTableAdapters.segregationsTableAdapter()
        Me.CheckBoxX3 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.NPanAndZoomControl1 = New Nevron.Diagram.WinForm.NPanAndZoomControl()
        Me.Panel1.SuspendLayout
        CType(Me.SallesBindingSource,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.MydbDataSet1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.SallesBindingSource2,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.BatimentsBindingSource,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.SegregationsBindingSource,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TronconsBindingSource,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.Troncons_assocBindingSource,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'DiagramSetController1
        '
        Me.DiagramSetController1.ActiveTool = Nothing
        Me.DiagramSetController1.Project = Me.Project1
        '
        'Project1
        '
        Me.Project1.Description = Nothing
        Me.Project1.LibrarySearchPaths = CType(resources.GetObject("Project1.LibrarySearchPaths"),System.Collections.Generic.IList(Of String))
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
        Me.XmlStore1.DirectoryName = "C:\ProgramData\"
        Me.XmlStore1.FileExtension = ".xml"
        Me.XmlStore1.ProjectName = ""
        '
        'ToolSetController1
        '
        Me.ToolSetController1.DiagramSetController = Me.DiagramSetController1
        '
        'ToolSetListViewPresenter1
        '
        Me.ToolSetListViewPresenter1.HideDeniedMenuItems = false
        Me.ToolSetListViewPresenter1.ListView = Nothing
        Me.ToolSetListViewPresenter1.ShowDefaultContextMenu = true
        Me.ToolSetListViewPresenter1.ToolSetController = Nothing
        '
        'ButtonX3
        '
        Me.ButtonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX3.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX3.Location = New System.Drawing.Point(1076, 12)
        Me.ButtonX3.Name = "ButtonX3"
        Me.ButtonX3.Size = New System.Drawing.Size(100, 37)
        Me.ButtonX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX3.TabIndex = 6
        Me.ButtonX3.Text = "Generation"
        '
        'NDrawingView1
        '
        Me.NDrawingView1.AllowDrop = true
        Me.NDrawingView1.DesignTimeState = CType(resources.GetObject("NDrawingView1.DesignTimeState"),Nevron.Diagram.NBinaryState)
        Me.NDrawingView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NDrawingView1.Document = Me.NDrawingDocument1
        Me.NDrawingView1.Location = New System.Drawing.Point(0, 0)
        Me.NDrawingView1.Name = "NDrawingView1"
        Me.NDrawingView1.Size = New System.Drawing.Size(1017, 646)
        Me.NDrawingView1.TabIndex = 7
        Me.NDrawingView1.Text = "NDrawingView1"
        '
        'NDrawingDocument1
        '
        Me.NDrawingDocument1.DesignTimeState = CType(resources.GetObject("NDrawingDocument1.DesignTimeState"),Nevron.Diagram.NBinaryState)
        '
        'NLibraryDocument1
        '
        Me.NLibraryDocument1.DesignTimeState = CType(resources.GetObject("NLibraryDocument1.DesignTimeState"),Nevron.Diagram.NBinaryState)
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.NDrawingView1)
        Me.Panel1.Location = New System.Drawing.Point(228, 68)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1017, 646)
        Me.Panel1.TabIndex = 8
        '
        'ComboBoxEx1
        '
        Me.ComboBoxEx1.DataSource = Me.SallesBindingSource
        Me.ComboBoxEx1.DisplayMember = "repere salle"
        Me.ComboBoxEx1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBoxEx1.Enabled = false
        Me.ComboBoxEx1.FormattingEnabled = true
        Me.ComboBoxEx1.ItemHeight = 14
        Me.ComboBoxEx1.Location = New System.Drawing.Point(51, 351)
        Me.ComboBoxEx1.Name = "ComboBoxEx1"
        Me.ComboBoxEx1.Size = New System.Drawing.Size(121, 20)
        Me.ComboBoxEx1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ComboBoxEx1.TabIndex = 9
        Me.ComboBoxEx1.ValueMember = "idsalle"
        '
        'SallesBindingSource
        '
        Me.SallesBindingSource.DataMember = "salles"
        Me.SallesBindingSource.DataSource = Me.MydbDataSet1
        '
        'MydbDataSet1
        '
        Me.MydbDataSet1.DataSetName = "mydbDataSet"
        Me.MydbDataSet1.EnforceConstraints = false
        Me.MydbDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Enabled = false
        Me.LabelX1.Location = New System.Drawing.Point(51, 322)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(75, 23)
        Me.LabelX1.TabIndex = 10
        Me.LabelX1.Text = "Salle depart"
        '
        'ComboBoxEx2
        '
        Me.ComboBoxEx2.DataSource = Me.SallesBindingSource2
        Me.ComboBoxEx2.DisplayMember = "repere salle"
        Me.ComboBoxEx2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBoxEx2.Enabled = false
        Me.ComboBoxEx2.FormattingEnabled = true
        Me.ComboBoxEx2.ItemHeight = 14
        Me.ComboBoxEx2.Location = New System.Drawing.Point(51, 406)
        Me.ComboBoxEx2.Name = "ComboBoxEx2"
        Me.ComboBoxEx2.Size = New System.Drawing.Size(121, 20)
        Me.ComboBoxEx2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ComboBoxEx2.TabIndex = 9
        Me.ComboBoxEx2.ValueMember = "idsalle"
        '
        'SallesBindingSource2
        '
        Me.SallesBindingSource2.DataMember = "salles"
        Me.SallesBindingSource2.DataSource = Me.MydbDataSet1
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Enabled = false
        Me.LabelX2.Location = New System.Drawing.Point(51, 377)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(75, 23)
        Me.LabelX2.TabIndex = 10
        Me.LabelX2.Text = "Salle arrivé"
        '
        'ComboBoxEx3
        '
        Me.ComboBoxEx3.DataSource = Me.BatimentsBindingSource
        Me.ComboBoxEx3.DisplayMember = "Nom"
        Me.ComboBoxEx3.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBoxEx3.FormattingEnabled = true
        Me.ComboBoxEx3.ItemHeight = 14
        Me.ComboBoxEx3.Location = New System.Drawing.Point(51, 128)
        Me.ComboBoxEx3.Name = "ComboBoxEx3"
        Me.ComboBoxEx3.Size = New System.Drawing.Size(121, 20)
        Me.ComboBoxEx3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ComboBoxEx3.TabIndex = 9
        Me.ComboBoxEx3.ValueMember = "idBatiment"
        '
        'BatimentsBindingSource
        '
        Me.BatimentsBindingSource.DataMember = "batiments"
        Me.BatimentsBindingSource.DataSource = Me.MydbDataSet1
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Location = New System.Drawing.Point(51, 99)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(75, 23)
        Me.LabelX3.TabIndex = 10
        Me.LabelX3.Text = "Batiment"
        '
        'CheckBoxX1
        '
        '
        '
        '
        Me.CheckBoxX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxX1.Location = New System.Drawing.Point(12, 68)
        Me.CheckBoxX1.Name = "CheckBoxX1"
        Me.CheckBoxX1.Size = New System.Drawing.Size(124, 23)
        Me.CheckBoxX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CheckBoxX1.TabIndex = 11
        Me.CheckBoxX1.Text = "Reseau Batiment"
        '
        'CheckBoxX2
        '
        '
        '
        '
        Me.CheckBoxX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxX2.Enabled = false
        Me.CheckBoxX2.Location = New System.Drawing.Point(12, 284)
        Me.CheckBoxX2.Name = "CheckBoxX2"
        Me.CheckBoxX2.Size = New System.Drawing.Size(160, 23)
        Me.CheckBoxX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CheckBoxX2.TabIndex = 11
        Me.CheckBoxX2.Text = "Reseau Tenant Aboutissant"
        '
        'ComboBoxEx4
        '
        Me.ComboBoxEx4.DataSource = Me.SegregationsBindingSource
        Me.ComboBoxEx4.DisplayMember = "segregation"
        Me.ComboBoxEx4.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBoxEx4.FormattingEnabled = true
        Me.ComboBoxEx4.ItemHeight = 14
        Me.ComboBoxEx4.Location = New System.Drawing.Point(51, 189)
        Me.ComboBoxEx4.Name = "ComboBoxEx4"
        Me.ComboBoxEx4.Size = New System.Drawing.Size(121, 20)
        Me.ComboBoxEx4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ComboBoxEx4.TabIndex = 9
        Me.ComboBoxEx4.ValueMember = "idsegregations"
        '
        'SegregationsBindingSource
        '
        Me.SegregationsBindingSource.DataMember = "segregations"
        Me.SegregationsBindingSource.DataSource = Me.MydbDataSet1
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Location = New System.Drawing.Point(51, 160)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(121, 23)
        Me.LabelX4.TabIndex = 10
        Me.LabelX4.Text = "Reseau / Segregation"
        '
        'TextBoxX1
        '
        '
        '
        '
        Me.TextBoxX1.Border.Class = "TextBoxBorder"
        Me.TextBoxX1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxX1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.TextBoxX1.Location = New System.Drawing.Point(76, 29)
        Me.TextBoxX1.Name = "TextBoxX1"
        Me.TextBoxX1.PreventEnterBeep = true
        Me.TextBoxX1.Size = New System.Drawing.Size(368, 26)
        Me.TextBoxX1.TabIndex = 13
        '
        'TextBoxX2
        '
        '
        '
        '
        Me.TextBoxX2.Border.Class = "TextBoxBorder"
        Me.TextBoxX2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxX2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.TextBoxX2.Location = New System.Drawing.Point(522, 29)
        Me.TextBoxX2.Name = "TextBoxX2"
        Me.TextBoxX2.PreventEnterBeep = true
        Me.TextBoxX2.Size = New System.Drawing.Size(354, 26)
        Me.TextBoxX2.TabIndex = 13
        '
        'LabelX7
        '
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.Location = New System.Drawing.Point(12, 31)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(58, 23)
        Me.LabelX7.TabIndex = 10
        Me.LabelX7.Text = "Tronçon :"
        '
        'LabelX8
        '
        '
        '
        '
        Me.LabelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX8.Location = New System.Drawing.Point(450, 31)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(66, 23)
        Me.LabelX8.TabIndex = 10
        Me.LabelX8.Text = "Remplis à :"
        '
        'TronconsBindingSource
        '
        Me.TronconsBindingSource.DataMember = "troncons"
        Me.TronconsBindingSource.DataSource = Me.MydbDataSet1
        '
        'TronconsTableAdapter
        '
        Me.TronconsTableAdapter.ClearBeforeFill = true
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
        Me.TableAdapterManager.troncons_assocTableAdapter = Me.Troncons_assocTableAdapter
        Me.TableAdapterManager.troncons_fournituresTableAdapter = Nothing
        Me.TableAdapterManager.troncons_modifTableAdapter = Nothing
        Me.TableAdapterManager.tronconsTableAdapter = Me.TronconsTableAdapter
        Me.TableAdapterManager.type_docTableAdapter = Nothing
        Me.TableAdapterManager.types_cableTableAdapter = Nothing
        Me.TableAdapterManager.types_tronconsTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = progelec.mydbDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'Troncons_assocTableAdapter
        '
        Me.Troncons_assocTableAdapter.ClearBeforeFill = true
        '
        'Troncons_assocBindingSource
        '
        Me.Troncons_assocBindingSource.DataMember = "troncons_assoc"
        Me.Troncons_assocBindingSource.DataSource = Me.MydbDataSet1
        '
        'BatimentsTableAdapter
        '
        Me.BatimentsTableAdapter.ClearBeforeFill = true
        '
        'SallesTableAdapter
        '
        Me.SallesTableAdapter.ClearBeforeFill = true
        '
        'SegregationsTableAdapter
        '
        Me.SegregationsTableAdapter.ClearBeforeFill = true
        '
        'CheckBoxX3
        '
        '
        '
        '
        Me.CheckBoxX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxX3.Location = New System.Drawing.Point(12, 232)
        Me.CheckBoxX3.Name = "CheckBoxX3"
        Me.CheckBoxX3.Size = New System.Drawing.Size(124, 23)
        Me.CheckBoxX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CheckBoxX3.TabIndex = 11
        Me.CheckBoxX3.Text = "Tous réseaux"
        '
        'NPanAndZoomControl1
        '
        Me.NPanAndZoomControl1.LargeZoomChangeFactor = CType(10UI,UInteger)
        Me.NPanAndZoomControl1.Location = New System.Drawing.Point(13, 472)
        Me.NPanAndZoomControl1.MasterView = Me.NDrawingView1
        Me.NPanAndZoomControl1.Name = "NPanAndZoomControl1"
        Me.NPanAndZoomControl1.Size = New System.Drawing.Size(209, 242)
        Me.NPanAndZoomControl1.TabIndex = 14
        Me.NPanAndZoomControl1.Text = "NPanAndZoomControl1"
        '
        'Formserge
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1257, 726)
        Me.Controls.Add(Me.NPanAndZoomControl1)
        Me.Controls.Add(Me.TextBoxX2)
        Me.Controls.Add(Me.TextBoxX1)
        Me.Controls.Add(Me.CheckBoxX2)
        Me.Controls.Add(Me.CheckBoxX3)
        Me.Controls.Add(Me.CheckBoxX1)
        Me.Controls.Add(Me.LabelX4)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.LabelX8)
        Me.Controls.Add(Me.LabelX7)
        Me.Controls.Add(Me.LabelX3)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.ComboBoxEx4)
        Me.Controls.Add(Me.ComboBoxEx2)
        Me.Controls.Add(Me.ComboBoxEx3)
        Me.Controls.Add(Me.ComboBoxEx1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ButtonX3)
        Me.DoubleBuffered = true
        Me.Name = "Formserge"
        Me.Text = "Architecture Tronçons ..."
        Me.Panel1.ResumeLayout(false)
        CType(Me.SallesBindingSource,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.MydbDataSet1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.SallesBindingSource2,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.BatimentsBindingSource,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.SegregationsBindingSource,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TronconsBindingSource,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.Troncons_assocBindingSource,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents Project1 As Dataweb.NShape.Project
    Friend WithEvents DiagramSetController1 As Dataweb.NShape.Controllers.DiagramSetController
    Friend WithEvents ToolSetController1 As Dataweb.NShape.Controllers.ToolSetController
    Friend WithEvents ToolSetListViewPresenter1 As Dataweb.NShape.WinFormsUI.ToolSetListViewPresenter
    Friend WithEvents CachedRepository1 As Dataweb.NShape.Advanced.CachedRepository
    Friend WithEvents XmlStore1 As Dataweb.NShape.XmlStore
    Friend WithEvents MydbDataSet1 As progelec.mydbDataSet
    Friend WithEvents TronconsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TronconsTableAdapter As progelec.mydbDataSetTableAdapters.tronconsTableAdapter
    Friend WithEvents TableAdapterManager As progelec.mydbDataSetTableAdapters.TableAdapterManager

    Friend WithEvents ButtonX3 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents NDrawingView1 As Nevron.Diagram.WinForm.NDrawingView
    Friend WithEvents NDrawingDocument1 As Nevron.Diagram.NDrawingDocument
    Friend WithEvents NLibraryDocument1 As Nevron.Diagram.NLibraryDocument
    Friend WithEvents Troncons_assocTableAdapter As progelec.mydbDataSetTableAdapters.troncons_assocTableAdapter
    Friend WithEvents Troncons_assocBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ComboBoxEx1 As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ComboBoxEx2 As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ComboBoxEx3 As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents CheckBoxX1 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents CheckBoxX2 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents ComboBoxEx4 As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TextBoxX1 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TextBoxX2 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents BatimentsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents BatimentsTableAdapter As progelec.mydbDataSetTableAdapters.batimentsTableAdapter
    Friend WithEvents SallesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SallesTableAdapter As progelec.mydbDataSetTableAdapters.sallesTableAdapter
    Friend WithEvents SegregationsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SegregationsTableAdapter As progelec.mydbDataSetTableAdapters.segregationsTableAdapter
    Friend WithEvents SallesBindingSource2 As System.Windows.Forms.BindingSource
    Friend WithEvents CheckBoxX3 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents NPanAndZoomControl1 As Nevron.Diagram.WinForm.NPanAndZoomControl
End Class
