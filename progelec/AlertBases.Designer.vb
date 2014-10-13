Imports DevComponents.DotNetBar

Partial Class AlertBases
    Inherits DevComponents.DotNetBar.Balloon


#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents label2 As System.Windows.Forms.Label
    Friend WithEvents linkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents labelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents labelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents buttonItem3 As DevComponents.DotNetBar.ButtonItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AlertBases))
        Me.label2 = New System.Windows.Forms.Label()
        Me.linkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.labelX2 = New DevComponents.DotNetBar.LabelX()
        Me.labelX1 = New DevComponents.DotNetBar.LabelX()
        Me.bar1 = New DevComponents.DotNetBar.Bar()
        Me.ButtonItem4 = New DevComponents.DotNetBar.ButtonItem()
        Me.buttonItem2 = New DevComponents.DotNetBar.ButtonItem()
        Me.buttonItem3 = New DevComponents.DotNetBar.ButtonItem()
        Me.buttonItem1 = New DevComponents.DotNetBar.ButtonItem()
        Me.reflectionImage1 = New DevComponents.DotNetBar.Controls.ReflectionImage()
        CType(Me.bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'label2
        '
        Me.label2.BackColor = System.Drawing.Color.Transparent
        Me.label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label2.ForeColor = System.Drawing.Color.Firebrick
        Me.label2.Location = New System.Drawing.Point(16, 144)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(168, 16)
        Me.label2.TabIndex = 7
        Me.label2.Text = "Click 'Enable Balloons' now!"
        Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'linkLabel1
        '
        Me.linkLabel1.BackColor = System.Drawing.Color.Transparent
        Me.linkLabel1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.linkLabel1.Location = New System.Drawing.Point(48, 168)
        Me.linkLabel1.Name = "linkLabel1"
        Me.linkLabel1.Size = New System.Drawing.Size(152, 16)
        Me.linkLabel1.TabIndex = 5
        Me.linkLabel1.TabStop = True
        Me.linkLabel1.Text = "Click to visit DevComponents"
        '
        'labelX2
        '
        Me.labelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.labelX2.Location = New System.Drawing.Point(88, 61)
        Me.labelX2.Name = "labelX2"
        Me.labelX2.Size = New System.Drawing.Size(184, 40)
        Me.labelX2.TabIndex = 11
        Me.labelX2.Text = "Veuillez creer les données physique pour garantir les calculs"
        Me.labelX2.TextLineAlignment = System.Drawing.StringAlignment.Near
        Me.labelX2.WordWrap = True
        '
        'labelX1
        '
        Me.labelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.labelX1.Location = New System.Drawing.Point(88, 23)
        Me.labelX1.Name = "labelX1"
        Me.labelX1.Size = New System.Drawing.Size(184, 32)
        Me.labelX1.TabIndex = 10
        Me.labelX1.Text = "<b>Des données physique sont manquantes</b>"
        '
        'bar1
        '
        Me.bar1.BackColor = System.Drawing.Color.Transparent
        Me.bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem4, Me.buttonItem2, Me.buttonItem3})
        Me.bar1.Location = New System.Drawing.Point(0, 111)
        Me.bar1.Name = "bar1"
        Me.bar1.Size = New System.Drawing.Size(280, 25)
        Me.bar1.Stretch = True
        Me.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.bar1.TabIndex = 9
        Me.bar1.TabStop = False
        Me.bar1.Text = "bar1"
        '
        'ButtonItem4
        '
        Me.ButtonItem4.Image = CType(resources.GetObject("ButtonItem4.Image"), System.Drawing.Image)
        Me.ButtonItem4.Name = "ButtonItem4"
        Me.ButtonItem4.Text = "buttonItem1"
        Me.ButtonItem4.Visible = False
        '
        'buttonItem2
        '
        Me.buttonItem2.Image = CType(resources.GetObject("buttonItem2.Image"), System.Drawing.Image)
        Me.buttonItem2.Name = "buttonItem2"
        Me.buttonItem2.Text = "buttonItem2"
        Me.buttonItem2.Visible = False
        '
        'buttonItem3
        '
        Me.buttonItem3.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.buttonItem3.Name = "buttonItem3"
        Me.buttonItem3.Text = "Options.."
        Me.buttonItem3.Visible = False
        '
        'buttonItem1
        '
        Me.buttonItem1.Image = CType(resources.GetObject("buttonItem1.Image"), System.Drawing.Image)
        Me.buttonItem1.Name = "buttonItem1"
        Me.buttonItem1.Text = "buttonItem1"
        '
        'reflectionImage1
        '
        Me.reflectionImage1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.reflectionImage1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.reflectionImage1.Image = Global.progelec.My.Resources.Resources.info
        Me.reflectionImage1.Location = New System.Drawing.Point(12, 12)
        Me.reflectionImage1.Name = "reflectionImage1"
        Me.reflectionImage1.Size = New System.Drawing.Size(64, 100)
        Me.reflectionImage1.TabIndex = 12
        '
        'AlertBases
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(201, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.BorderColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
        Me.CaptionFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ClientSize = New System.Drawing.Size(280, 136)
        Me.Controls.Add(Me.reflectionImage1)
        Me.Controls.Add(Me.labelX2)
        Me.Controls.Add(Me.labelX1)
        Me.Controls.Add(Me.bar1)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.linkLabel1)
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(76, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.Location = New System.Drawing.Point(0, 0)
        Me.Name = "AlertBases"
        Me.Style = DevComponents.DotNetBar.eBallonStyle.Office2007Alert
        CType(Me.bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ButtonItem4 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents buttonItem2 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents buttonItem1 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents reflectionImage1 As DevComponents.DotNetBar.Controls.ReflectionImage

#End Region

End Class
