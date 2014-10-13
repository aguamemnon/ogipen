<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormShedule
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Chart1 = New Braincase.GanttChart.Chart()
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.SuperTabControl1 = New DevComponents.DotNetBar.SuperTabControl()
        Me.SuperTabControlPanel1 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.CircularProgress1 = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.label1 = New System.Windows.Forms.Label()
        Me.DataGridViewX1 = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.SuperTabItem1 = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel4 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.DataGridViewX2 = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.SuperTabItem3 = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel3 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.ListViewEx1 = New DevComponents.DotNetBar.Controls.ListViewEx()
        Me.Ressources = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel2 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.AdvPropertyGrid2 = New DevComponents.DotNetBar.AdvPropertyGrid()
        Me.SuperTabItem2 = New DevComponents.DotNetBar.SuperTabItem()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.TextBoxX1 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.MydbDataSet = New progelec.mydbDataSet()
        Me.Salles_statusBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Salles_statusTableAdapter = New progelec.mydbDataSetTableAdapters.salles_statusTableAdapter()
        Me.TableAdapterManager = New progelec.mydbDataSetTableAdapters.TableAdapterManager()
        Me.LotsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.LotsTableAdapter = New progelec.mydbDataSetTableAdapters.lotsTableAdapter()
        Me.Equipements_statusBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Equipements_statusTableAdapter = New progelec.mydbDataSetTableAdapters.equipements_statusTableAdapter()
        Me.Troncons_statusBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Troncons_statusTableAdapter = New progelec.mydbDataSetTableAdapters.troncons_statusTableAdapter()
        Me.Panel1.SuspendLayout()
        CType(Me.SuperTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControl1.SuspendLayout()
        Me.SuperTabControlPanel1.SuspendLayout()
        CType(Me.DataGridViewX1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControlPanel4.SuspendLayout()
        CType(Me.DataGridViewX2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControlPanel3.SuspendLayout()
        Me.SuperTabControlPanel2.SuspendLayout()
        CType(Me.AdvPropertyGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MydbDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Salles_statusBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LotsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Equipements_statusBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Troncons_statusBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.Chart1)
        Me.Panel1.Location = New System.Drawing.Point(542, 57)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(744, 695)
        Me.Panel1.TabIndex = 0
        '
        'Chart1
        '
        Me.Chart1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Chart1.Location = New System.Drawing.Point(0, 0)
        Me.Chart1.Margin = New System.Windows.Forms.Padding(0)
        Me.Chart1.Name = "Chart1"
        Me.Chart1.Size = New System.Drawing.Size(744, 695)
        Me.Chart1.TabIndex = 0
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX1.Location = New System.Drawing.Point(15, 12)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Size = New System.Drawing.Size(166, 39)
        Me.ButtonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014
        Me.ButtonX1.TabIndex = 1
        Me.ButtonX1.Text = "Planning Mise à dispo salles"
        '
        'SuperTabControl1
        '
        Me.SuperTabControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
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
        Me.SuperTabControl1.Location = New System.Drawing.Point(12, 57)
        Me.SuperTabControl1.Name = "SuperTabControl1"
        Me.SuperTabControl1.ReorderTabsEnabled = True
        Me.SuperTabControl1.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.SuperTabControl1.SelectedTabIndex = 0
        Me.SuperTabControl1.Size = New System.Drawing.Size(524, 681)
        Me.SuperTabControl1.TabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SuperTabControl1.TabIndex = 6
        Me.SuperTabControl1.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabItem1, Me.SuperTabItem2, Me.Ressources, Me.SuperTabItem3})
        Me.SuperTabControl1.Text = "SuperTabControl1"
        '
        'SuperTabControlPanel1
        '
        Me.SuperTabControlPanel1.Controls.Add(Me.CircularProgress1)
        Me.SuperTabControlPanel1.Controls.Add(Me.label1)
        Me.SuperTabControlPanel1.Controls.Add(Me.DataGridViewX1)
        Me.SuperTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel1.Location = New System.Drawing.Point(0, 25)
        Me.SuperTabControlPanel1.Name = "SuperTabControlPanel1"
        Me.SuperTabControlPanel1.Size = New System.Drawing.Size(524, 656)
        Me.SuperTabControlPanel1.TabIndex = 1
        Me.SuperTabControlPanel1.TabItem = Me.SuperTabItem1
        '
        'CircularProgress1
        '
        Me.CircularProgress1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        '
        '
        '
        Me.CircularProgress1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CircularProgress1.Location = New System.Drawing.Point(-3, -25)
        Me.CircularProgress1.Name = "CircularProgress1"
        Me.CircularProgress1.ProgressTextVisible = True
        Me.CircularProgress1.Size = New System.Drawing.Size(527, 681)
        Me.CircularProgress1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.CircularProgress1.TabIndex = 3
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(161, 11)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(191, 13)
        Me.label1.TabIndex = 2
        Me.label1.Text = "Selecionné une ligne pour voir la tâhce"
        '
        'DataGridViewX1
        '
        Me.DataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewX1.DefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewX1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DataGridViewX1.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.DataGridViewX1.Location = New System.Drawing.Point(0, 44)
        Me.DataGridViewX1.Name = "DataGridViewX1"
        Me.DataGridViewX1.Size = New System.Drawing.Size(524, 612)
        Me.DataGridViewX1.TabIndex = 0
        '
        'SuperTabItem1
        '
        Me.SuperTabItem1.AttachedControl = Me.SuperTabControlPanel1
        Me.SuperTabItem1.GlobalItem = False
        Me.SuperTabItem1.Name = "SuperTabItem1"
        Me.SuperTabItem1.Text = "Liste Tâches"
        '
        'SuperTabControlPanel4
        '
        Me.SuperTabControlPanel4.Controls.Add(Me.DataGridViewX2)
        Me.SuperTabControlPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel4.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel4.Name = "SuperTabControlPanel4"
        Me.SuperTabControlPanel4.Size = New System.Drawing.Size(524, 681)
        Me.SuperTabControlPanel4.TabIndex = 0
        Me.SuperTabControlPanel4.TabItem = Me.SuperTabItem3
        '
        'DataGridViewX2
        '
        Me.DataGridViewX2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewX2.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewX2.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.DataGridViewX2.Location = New System.Drawing.Point(4, 34)
        Me.DataGridViewX2.Name = "DataGridViewX2"
        Me.DataGridViewX2.Size = New System.Drawing.Size(517, 618)
        Me.DataGridViewX2.TabIndex = 0
        '
        'SuperTabItem3
        '
        Me.SuperTabItem3.AttachedControl = Me.SuperTabControlPanel4
        Me.SuperTabItem3.GlobalItem = False
        Me.SuperTabItem3.Name = "SuperTabItem3"
        Me.SuperTabItem3.Text = "Charges"
        '
        'SuperTabControlPanel3
        '
        Me.SuperTabControlPanel3.Controls.Add(Me.ListViewEx1)
        Me.SuperTabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel3.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel3.Name = "SuperTabControlPanel3"
        Me.SuperTabControlPanel3.Size = New System.Drawing.Size(524, 681)
        Me.SuperTabControlPanel3.TabIndex = 0
        Me.SuperTabControlPanel3.TabItem = Me.Ressources
        '
        'ListViewEx1
        '
        '
        '
        '
        Me.ListViewEx1.Border.Class = "ListViewBorder"
        Me.ListViewEx1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ListViewEx1.DisabledBackColor = System.Drawing.Color.Empty
        Me.ListViewEx1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListViewEx1.Location = New System.Drawing.Point(0, 0)
        Me.ListViewEx1.Name = "ListViewEx1"
        Me.ListViewEx1.Size = New System.Drawing.Size(524, 681)
        Me.ListViewEx1.TabIndex = 0
        Me.ListViewEx1.UseCompatibleStateImageBehavior = False
        '
        'Ressources
        '
        Me.Ressources.AttachedControl = Me.SuperTabControlPanel3
        Me.Ressources.GlobalItem = False
        Me.Ressources.Name = "Ressources"
        Me.Ressources.Text = "Ressources"
        '
        'SuperTabControlPanel2
        '
        Me.SuperTabControlPanel2.Controls.Add(Me.AdvPropertyGrid2)
        Me.SuperTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel2.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel2.Name = "SuperTabControlPanel2"
        Me.SuperTabControlPanel2.Size = New System.Drawing.Size(524, 681)
        Me.SuperTabControlPanel2.TabIndex = 0
        Me.SuperTabControlPanel2.TabItem = Me.SuperTabItem2
        '
        'AdvPropertyGrid2
        '
        Me.AdvPropertyGrid2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AdvPropertyGrid2.GridLinesColor = System.Drawing.Color.WhiteSmoke
        Me.AdvPropertyGrid2.Location = New System.Drawing.Point(0, 0)
        Me.AdvPropertyGrid2.Name = "AdvPropertyGrid2"
        Me.AdvPropertyGrid2.Size = New System.Drawing.Size(524, 681)
        Me.AdvPropertyGrid2.TabIndex = 1
        Me.AdvPropertyGrid2.Text = "AdvPropertyGrid2"
        '
        'SuperTabItem2
        '
        Me.SuperTabItem2.AttachedControl = Me.SuperTabControlPanel2
        Me.SuperTabItem2.GlobalItem = False
        Me.SuperTabItem2.Name = "SuperTabItem2"
        Me.SuperTabItem2.Text = "Détail tâche"
        '
        'BackgroundWorker1
        '
        '
        'TextBoxX1
        '
        '
        '
        '
        Me.TextBoxX1.Border.Class = "TextBoxBorder"
        Me.TextBoxX1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxX1.Location = New System.Drawing.Point(367, 21)
        Me.TextBoxX1.Name = "TextBoxX1"
        Me.TextBoxX1.PreventEnterBeep = True
        Me.TextBoxX1.Size = New System.Drawing.Size(41, 20)
        Me.TextBoxX1.TabIndex = 7
        Me.TextBoxX1.Text = "7"
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(213, 18)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(151, 23)
        Me.LabelX1.TabIndex = 8
        Me.LabelX1.Text = "Heures Travaillés par jour"
        '
        'MydbDataSet
        '
        Me.MydbDataSet.DataSetName = "mydbDataSet"
        Me.MydbDataSet.EnforceConstraints = False
        Me.MydbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Salles_statusBindingSource
        '
        Me.Salles_statusBindingSource.DataMember = "salles_status"
        Me.Salles_statusBindingSource.DataSource = Me.MydbDataSet
        '
        'Salles_statusTableAdapter
        '
        Me.Salles_statusTableAdapter.ClearBeforeFill = True
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
        'LotsBindingSource
        '
        Me.LotsBindingSource.DataMember = "lots"
        Me.LotsBindingSource.DataSource = Me.MydbDataSet
        '
        'LotsTableAdapter
        '
        Me.LotsTableAdapter.ClearBeforeFill = True
        '
        'Equipements_statusBindingSource
        '
        Me.Equipements_statusBindingSource.DataMember = "equipements_status"
        Me.Equipements_statusBindingSource.DataSource = Me.MydbDataSet
        '
        'Equipements_statusTableAdapter
        '
        Me.Equipements_statusTableAdapter.ClearBeforeFill = True
        '
        'Troncons_statusBindingSource
        '
        Me.Troncons_statusBindingSource.DataMember = "troncons_status"
        Me.Troncons_statusBindingSource.DataSource = Me.MydbDataSet
        '
        'Troncons_statusTableAdapter
        '
        Me.Troncons_statusTableAdapter.ClearBeforeFill = True
        '
        'FormShedule
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1289, 750)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.TextBoxX1)
        Me.Controls.Add(Me.SuperTabControl1)
        Me.Controls.Add(Me.ButtonX1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FormShedule"
        Me.Text = "Planification"
        Me.Panel1.ResumeLayout(False)
        CType(Me.SuperTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControl1.ResumeLayout(False)
        Me.SuperTabControlPanel1.ResumeLayout(False)
        Me.SuperTabControlPanel1.PerformLayout()
        CType(Me.DataGridViewX1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControlPanel4.ResumeLayout(False)
        CType(Me.DataGridViewX2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControlPanel3.ResumeLayout(False)
        Me.SuperTabControlPanel2.ResumeLayout(False)
        CType(Me.AdvPropertyGrid2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MydbDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Salles_statusBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LotsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Equipements_statusBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Troncons_statusBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Chart1 As Braincase.GanttChart.Chart
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents MydbDataSet As progelec.mydbDataSet
    Friend WithEvents Salles_statusBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Salles_statusTableAdapter As progelec.mydbDataSetTableAdapters.salles_statusTableAdapter
    Friend WithEvents TableAdapterManager As progelec.mydbDataSetTableAdapters.TableAdapterManager
    Friend WithEvents SuperTabControl1 As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents SuperTabControlPanel1 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SuperTabItem1 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel2 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents AdvPropertyGrid2 As DevComponents.DotNetBar.AdvPropertyGrid
    Friend WithEvents SuperTabItem2 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents ListViewEx1 As DevComponents.DotNetBar.Controls.ListViewEx
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewX1 As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents SuperTabControlPanel3 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents Ressources As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents CircularProgress1 As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents LotsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents LotsTableAdapter As progelec.mydbDataSetTableAdapters.lotsTableAdapter
    Friend WithEvents Equipements_statusBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Equipements_statusTableAdapter As progelec.mydbDataSetTableAdapters.equipements_statusTableAdapter
    Friend WithEvents Troncons_statusBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Troncons_statusTableAdapter As progelec.mydbDataSetTableAdapters.troncons_statusTableAdapter
    Friend WithEvents TextBoxX1 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents SuperTabControlPanel4 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents DataGridViewX2 As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents SuperTabItem3 As DevComponents.DotNetBar.SuperTabItem
End Class
