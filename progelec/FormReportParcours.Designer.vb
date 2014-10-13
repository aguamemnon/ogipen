Imports FastReport.Data
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormReportParcours
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormReportParcours))
        Me.PreviewControl1 = New FastReport.Preview.PreviewControl()
        Me.Report1 = New FastReport.Report()
        Me.Report2 = New FastReport.Report()
        Me.Report3 = New FastReport.Report()
        Me.Report4 = New FastReport.Report()
        Me.Report5 = New FastReport.Report()
        Me.MydbDataSet = New progelec.mydbDataSet()
        Me.Report6 = New FastReport.Report()
        Me.Report7 = New FastReport.Report()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.EquipementsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Type_docBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Type_docTableAdapter = New progelec.mydbDataSetTableAdapters.type_docTableAdapter()
        Me.EquipementsTableAdapter = New progelec.mydbDataSetTableAdapters.equipementsTableAdapter()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.BatimentsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BatimentsTableAdapter = New progelec.mydbDataSetTableAdapters.batimentsTableAdapter()
        Me.Report_ph1_trc = New FastReport.Report()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Report_Phase1_equi = New FastReport.Report()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.Report_phase1_pfm = New FastReport.Report()
        CType(Me.Report1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Report2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Report3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Report4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Report5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MydbDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Report6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Report7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EquipementsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Type_docBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BatimentsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Report_ph1_trc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Report_Phase1_equi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Report_phase1_pfm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PreviewControl1
        '
        Me.PreviewControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PreviewControl1.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.PreviewControl1.Buttons = CType((((((((((FastReport.PreviewButtons.Print Or FastReport.PreviewButtons.Save) _
            Or FastReport.PreviewButtons.Find) _
            Or FastReport.PreviewButtons.Zoom) _
            Or FastReport.PreviewButtons.Outline) _
            Or FastReport.PreviewButtons.PageSetup) _
            Or FastReport.PreviewButtons.Edit) _
            Or FastReport.PreviewButtons.Watermark) _
            Or FastReport.PreviewButtons.Navigator) _
            Or FastReport.PreviewButtons.Close), FastReport.PreviewButtons)
        Me.PreviewControl1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.PreviewControl1.Location = New System.Drawing.Point(223, 2)
        Me.PreviewControl1.Name = "PreviewControl1"
        Me.PreviewControl1.PageOffset = New System.Drawing.Point(10, 10)
        Me.PreviewControl1.Size = New System.Drawing.Size(1081, 741)
        Me.PreviewControl1.TabIndex = 5
        Me.PreviewControl1.UIStyle = FastReport.Utils.UIStyle.Office2007Black
        '
        'Report1
        '
        Me.Report1.ReportResourceString = resources.GetString("Report1.ReportResourceString")
        '
        'Report2
        '
        Me.Report2.ReportResourceString = resources.GetString("Report2.ReportResourceString")
        '
        'Report3
        '
        Me.Report3.ReportResourceString = resources.GetString("Report3.ReportResourceString")
        '
        'Report4
        '
        Me.Report4.ReportResourceString = resources.GetString("Report4.ReportResourceString")
        '
        'Report5
        '
        Me.Report5.ReportResourceString = resources.GetString("Report5.ReportResourceString")
        Me.Report5.RegisterData(Me.MydbDataSet, "MydbDataSet")
        '
        'MydbDataSet
        '
        Me.MydbDataSet.DataSetName = "mydbDataSet"
        Me.MydbDataSet.EnforceConstraints = False
        Me.MydbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Report6
        '
        Me.Report6.ReportResourceString = resources.GetString("Report6.ReportResourceString")
        '
        'Report7
        '
        Me.Report7.ReportResourceString = resources.GetString("Report7.ReportResourceString")
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 57)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(187, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Carnet de déroulage"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(11, 86)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(187, 23)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Annalyse des tronçons"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Enabled = False
        Me.Button3.Location = New System.Drawing.Point(11, 115)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(187, 23)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "Annalyse des tronçons exaustive"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(11, 371)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(187, 23)
        Me.Button4.TabIndex = 3
        Me.Button4.Text = "Carnet Phase 1 equipements"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(11, 144)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(187, 23)
        Me.Button5.TabIndex = 4
        Me.Button5.Text = "Calcul Dcc"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(11, 313)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(187, 23)
        Me.Button6.TabIndex = 4
        Me.Button6.Text = "Carnet de tremies"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(11, 215)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(187, 23)
        Me.Button7.TabIndex = 3
        Me.Button7.Text = "Carnet de contrôle reglementaire"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(11, 244)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(187, 23)
        Me.Button8.TabIndex = 3
        Me.Button8.Text = "Carnet de Raccordement"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 172)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Pour l'equipement"
        '
        'ComboBox1
        '
        Me.ComboBox1.DataSource = Me.EquipementsBindingSource
        Me.ComboBox1.DisplayMember = "repere equipement"
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(16, 188)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(183, 21)
        Me.ComboBox1.TabIndex = 7
        Me.ComboBox1.ValueMember = "idequipement"
        '
        'EquipementsBindingSource
        '
        Me.EquipementsBindingSource.DataMember = "equipements"
        Me.EquipementsBindingSource.DataSource = Me.MydbDataSet
        '
        'Type_docBindingSource
        '
        Me.Type_docBindingSource.DataMember = "type_doc"
        Me.Type_docBindingSource.DataSource = Me.MydbDataSet
        '
        'Type_docTableAdapter
        '
        Me.Type_docTableAdapter.ClearBeforeFill = True
        '
        'EquipementsTableAdapter
        '
        Me.EquipementsTableAdapter.ClearBeforeFill = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 270)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Pour le Batiment"
        '
        'ComboBox2
        '
        Me.ComboBox2.DataSource = Me.BatimentsBindingSource
        Me.ComboBox2.DisplayMember = "Nom"
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(11, 286)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(183, 21)
        Me.ComboBox2.TabIndex = 7
        Me.ComboBox2.ValueMember = "idBatiment"
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
        'Report_ph1_trc
        '
        Me.Report_ph1_trc.ReportResourceString = resources.GetString("Report_ph1_trc.ReportResourceString")
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(11, 342)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(187, 23)
        Me.Button9.TabIndex = 4
        Me.Button9.Text = "PEE Support et chem."
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Report_Phase1_equi
        '
        Me.Report_Phase1_equi.ReportResourceString = resources.GetString("Report_Phase1_equi.ReportResourceString")
        '
        'Button10
        '
        Me.Button10.Location = New System.Drawing.Point(11, 400)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(187, 23)
        Me.Button10.TabIndex = 3
        Me.Button10.Text = "Carnet Phase 1 Eclairage et PFM"
        Me.Button10.UseVisualStyleBackColor = True
        '
        'Report_phase1_pfm
        '
        Me.Report_phase1_pfm.ReportResourceString = resources.GetString("Report_phase1_pfm.ReportResourceString")
        '
        'FormReportParcours
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(1316, 742)
        Me.Controls.Add(Me.ComboBox2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button10)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.PreviewControl1)
        Me.Name = "FormReportParcours"
        Me.Text = "Rapport"
        CType(Me.Report1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Report2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Report3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Report4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Report5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MydbDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Report6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Report7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EquipementsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Type_docBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BatimentsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Report_ph1_trc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Report_Phase1_equi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Report_phase1_pfm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout

End Sub
    Friend WithEvents PreviewControl1 As FastReport.Preview.PreviewControl
    Friend WithEvents Report1 As FastReport.Report
    Friend WithEvents Report2 As FastReport.Report
    Friend WithEvents Report3 As FastReport.Report
    Friend WithEvents Report4 As FastReport.Report
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Report5 As FastReport.Report
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Report6 As FastReport.Report
    Friend WithEvents Report7 As FastReport.Report
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents MydbDataSet As progelec.mydbDataSet
    Friend WithEvents EquipementsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EquipementsTableAdapter As progelec.mydbDataSetTableAdapters.equipementsTableAdapter
    Friend WithEvents Type_docBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Type_docTableAdapter As progelec.mydbDataSetTableAdapters.type_docTableAdapter
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents BatimentsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents BatimentsTableAdapter As progelec.mydbDataSetTableAdapters.batimentsTableAdapter
    Friend WithEvents Report_ph1_trc As FastReport.Report
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Report_Phase1_equi As FastReport.Report
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents Report_phase1_pfm As FastReport.Report




End Class
