<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMap
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMap))
        Me.NDrawingView1 = New Nevron.Diagram.WinForm.NDrawingView()
        Me.NDrawingDocument1 = New Nevron.Diagram.NDrawingDocument()
        Me.NPanAndZoomControl1 = New Nevron.Diagram.WinForm.NPanAndZoomControl()
        Me.NPropertyBrowser1 = New Nevron.Diagram.WinForm.NPropertyBrowser()
        Me.SuspendLayout()
        '
        'NDrawingView1
        '
        Me.NDrawingView1.AllowDrop = True
        Me.NDrawingView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NDrawingView1.DesignTimeState = CType(resources.GetObject("NDrawingView1.DesignTimeState"), Nevron.Diagram.NBinaryState)
        Me.NDrawingView1.Document = Me.NDrawingDocument1
        Me.NDrawingView1.Location = New System.Drawing.Point(333, 42)
        Me.NDrawingView1.Name = "NDrawingView1"
        Me.NDrawingView1.Size = New System.Drawing.Size(973, 682)
        Me.NDrawingView1.TabIndex = 0
        Me.NDrawingView1.Text = "NDrawingView1"
        '
        'NDrawingDocument1
        '
        Me.NDrawingDocument1.DesignTimeState = CType(resources.GetObject("NDrawingDocument1.DesignTimeState"), Nevron.Diagram.NBinaryState)
        '
        'NPanAndZoomControl1
        '
        Me.NPanAndZoomControl1.LargeZoomChangeFactor = CType(10UI, UInteger)
        Me.NPanAndZoomControl1.Location = New System.Drawing.Point(22, 54)
        Me.NPanAndZoomControl1.MasterView = Nothing
        Me.NPanAndZoomControl1.Name = "NPanAndZoomControl1"
        Me.NPanAndZoomControl1.Size = New System.Drawing.Size(274, 249)
        Me.NPanAndZoomControl1.TabIndex = 1
        Me.NPanAndZoomControl1.Text = "NPanAndZoomControl1"
        '
        'NPropertyBrowser1
        '
        Me.NPropertyBrowser1.Location = New System.Drawing.Point(12, 325)
        Me.NPropertyBrowser1.Name = "NPropertyBrowser1"
        Me.NPropertyBrowser1.Size = New System.Drawing.Size(284, 387)
        Me.NPropertyBrowser1.TabIndex = 2
        Me.NPropertyBrowser1.View = Nothing
        '
        'FormMap
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1310, 724)
        Me.Controls.Add(Me.NPropertyBrowser1)
        Me.Controls.Add(Me.NPanAndZoomControl1)
        Me.Controls.Add(Me.NDrawingView1)
        Me.DoubleBuffered = True
        Me.Name = "FormMap"
        Me.Text = "FormMap"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents NDrawingView1 As Nevron.Diagram.WinForm.NDrawingView
    Friend WithEvents NDrawingDocument1 As Nevron.Diagram.NDrawingDocument
    Friend WithEvents NPanAndZoomControl1 As Nevron.Diagram.WinForm.NPanAndZoomControl
    Friend WithEvents NPropertyBrowser1 As Nevron.Diagram.WinForm.NPropertyBrowser
End Class
