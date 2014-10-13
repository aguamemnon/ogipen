Imports DevComponents.DotNetBar.SuperGrid
Imports Nevron.Diagram.Extensions
Imports Nevron.Diagram.Filters
Imports Nevron.Dom
Imports Nevron.Diagram.Layout
Imports Nevron.Diagram.DataImport
Imports Nevron.GraphicsCore
Imports Nevron.Diagram
Imports Nevron.Diagram.Shapes
Imports Nevron.Diagram.WinForm

Public Class FormAssocTroncons
    Inherits DevComponents.DotNetBar.RibbonForm

    Private Sub ButtonXFermer_Click(sender As System.Object, e As System.EventArgs) Handles ButtonXFermer.Click
        Me.Close()
    End Sub

    Private Sub SallesBindingNavigatorSaveItem_Click(sender As System.Object, e As System.EventArgs)
        Me.Validate()
        Me.SallesBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.MydbDataSet)

    End Sub

    Private Sub FormAssocTroncons_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'MydbDataSet.departs' table. You can move, or remove it, as needed.

        Me.Troncons_assocTableAdapter.Fill(Me.MydbDataSet.troncons_assoc)
        Me.TronconsTableAdapter.Fill(Me.MydbDataSet.troncons)
        Me.SallesTableAdapter.Fill(Me.MydbDataSet.salles)
        Me.SegregationsTableAdapter.Fill(Me.MydbDataSet.segregations)
    End Sub

    Private Sub IdsalleTextBox_TextChanged(sender As System.Object, e As System.EventArgs) Handles IdsalleTextBox.TextChanged, Repere_salleComboBox.SelectedIndexChanged
        If Me.IdsalleTextBox.Text = "" Then
            Exit Sub
        ElseIf Me.IdsegregationsTextBox.Text = "" Then
            Exit Sub
        Else
            Me.Lst_troncons_onTableAdapter.Fill(Me.MydbDataSet.lst_troncons_on, New System.Nullable(Of Integer)(CType(Me.IdsalleTextBox.Text, Integer)), New System.Nullable(Of Integer)(CType(Me.IdsegregationsTextBox.Text, Integer)))
            Me.SuperGridControl1.DataBindings.Clear()

            Me.SuperGridControl1.PrimaryGrid.DataSource = Me.Lst_troncons_onBindingSource

        End If
    End Sub

    Private Sub IdsegregationsTextBox_TextChanged(sender As System.Object, e As System.EventArgs) Handles IdsegregationsTextBox.TextChanged, SegregationComboBox.SelectedIndexChanged
        If Me.IdsalleTextBox.Text = "" Then
            Exit Sub
        ElseIf Me.IdsegregationsTextBox.Text = "" Then
            Exit Sub
        Else
            Me.Lst_troncons_onTableAdapter.Fill(Me.MydbDataSet.lst_troncons_on, New System.Nullable(Of Integer)(CType(Me.IdsalleTextBox.Text, Integer)), New System.Nullable(Of Integer)(CType(Me.IdsegregationsTextBox.Text, Integer)))
            Me.SuperGridControl1.PrimaryGrid.DataSource = Me.Lst_troncons_onBindingSource
        End If
    End Sub

    Private Sub SuperGridControl1_CellClick(sender As System.Object, e As DevComponents.DotNetBar.SuperGrid.GridCellClickEventArgs) Handles SuperGridControl1.CellClick
        Dim row As GridRow = TryCast(e.GridPanel.Rows(Me.SuperGridControl1.ActiveRow.Index), GridRow)

        Me.Label1.Text = row.Cells(1).Value.ToString

        If Me.Repere_salleComboBox.Text <> Me.Repere_salle1TextBox.Text Then
            Me.GroupBoxDallesAProxymitees.Visible = True

            Dim index As Integer = Me.Salles_2.Find("repere salle", Me.Repere_salle1TextBox.Text)
            Me.Salles_2.Position = index
            Me.Lst_troncons_seg2TableAdapter.Fill(Me.MydbDataSet.lst_troncons_seg2, New System.Nullable(Of Integer)(CType(Me.TextBox.Text, Integer)))
            Me.SuperGridControl3.DataBindings.Clear()

            Me.SuperGridControl3.PrimaryGrid.DataSource = Me.Lst_troncons_seg2BindingSource

        Else
            Me.GroupBoxDallesAProxymitees.Visible = False
        End If
        Me.Lst_troncons_segTableAdapter.Fill(Me.MydbDataSet.lst_troncons_seg, New System.Nullable(Of Integer)(CType(Me.IdsalleTextBox.Text, Integer)))
        Me.SuperGridControl2.DataBindings.Clear()

        Me.SuperGridControl2.PrimaryGrid.DataSource = Me.Lst_troncons_segBindingSource
        Me.Lst_troncons_sameTableAdapter.Fill(Me.MydbDataSet.lst_troncons_same, New System.Nullable(Of Integer)(CType(Me.TextBox1.Text, Integer)))
        Me.SuperGridControl.DataBindings.Clear()

        Me.SuperGridControl.PrimaryGrid.DataSource = Me.Lst_troncons_sameBindingSource

    End Sub

    Private Sub SuperGridControl3_CellClick(sender As System.Object, e As DevComponents.DotNetBar.SuperGrid.GridCellClickEventArgs) Handles SuperGridControl3.CellClick
        Dim row As GridRow = TryCast(e.GridPanel.Rows(Me.SuperGridControl3.ActiveRow.Index), GridRow)

        Me.Label2.Text = row.Cells(1).Value.ToString
        Me.TextBox2.Text = row.Cells(0).Value.ToString
    End Sub

    Private Sub SuperGridControl2_CellClick(sender As System.Object, e As DevComponents.DotNetBar.SuperGrid.GridCellClickEventArgs) Handles SuperGridControl2.CellClick
        Dim row As GridRow = TryCast(e.GridPanel.Rows(Me.SuperGridControl2.ActiveRow.Index), GridRow)

        Me.Label2.Text = row.Cells(1).Value.ToString
        Me.TextBox2.Text = row.Cells(0).Value.ToString
    End Sub

    Private Sub ButtonXAssocier_Click(sender As System.Object, e As System.EventArgs) Handles ButtonXAssocier.Click
        Select Case MessageBox.Show("Attention vous allez creer une association entre 2 tronçons etes vous sur ?", "Creation d'une association", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            Case System.Windows.Forms.DialogResult.Yes
                Dim drow As DataRowView = CType(Me.Troncons_assocBindingSource.AddNew(), DataRowView)

                drow("troncons") = Me.TextBox2.Text
                drow("troncons_tenant") = Me.TextBox1.Text
                drow.EndEdit()
                Me.Troncons_assocBindingSource.EndEdit()

                Me.Troncons_assocTableAdapter.Update(Me.MydbDataSet)
                Me.Lst_troncons_sameTableAdapter.Fill(Me.MydbDataSet.lst_troncons_same, New System.Nullable(Of Integer)(CType(Me.TextBox1.Text, Integer)))
                Me.SuperGridControl.DataBindings.Clear()

                Me.SuperGridControl.PrimaryGrid.DataSource = Me.Lst_troncons_sameBindingSource

            Case System.Windows.Forms.DialogResult.No
                Exit Sub
        End Select

    End Sub

#Region "Nevron"

    Private Sub IdsegregationsT(sender As System.Object, e As System.EventArgs) Handles Repere_salleComboBox.SelectedIndexChanged, SegregationComboBox.SelectedIndexChanged
        If Me.Repere_salleComboBox.SelectedValue Is Nothing Then
            Exit Sub
        ElseIf Me.SegregationComboBox.SelectedValue Is Nothing Then
            Exit Sub
        Else
            Me.Lst_assoc_seg_salleTableAdapter.ClearBeforeFill = True
            Me.Lst_assoc_seg_salleTableAdapter.Fill(Me.MydbDataSet.lst_assoc_seg_salle, New System.Nullable(Of Integer)(CType(Me.Repere_salleComboBox.SelectedValue, Integer)), New System.Nullable(Of Integer)(CType(Me.SegregationComboBox.SelectedValue, Integer)))
            Me.Lst_trc_salle_segTableAdapter.ClearBeforeFill = True
            Me.Lst_trc_salle_segTableAdapter.Fill(Me.MydbDataSet.lst_trc_salle_seg, New System.Nullable(Of Integer)(CType(Me.Repere_salleComboBox.SelectedValue, Integer)), New System.Nullable(Of Integer)(CType(Me.SegregationComboBox.SelectedValue, Integer)))

        End If
        mysqlimport()
    End Sub

    Private Sub IdsalleTextBoxt(sender As System.Object, e As System.EventArgs) Handles SegregationComboBox.SelectedIndexChanged, Repere_salleComboBox.SelectedIndexChanged
        If Me.SegregationComboBox.SelectedValue Is Nothing Then
            Exit Sub
        ElseIf Me.Repere_salleComboBox.SelectedValue Is Nothing Then
            Exit Sub
        Else

            Me.Lst_assoc_seg_salleTableAdapter.Fill(Me.MydbDataSet.lst_assoc_seg_salle, New System.Nullable(Of Integer)(CType(Me.Repere_salleComboBox.SelectedValue, Integer)), New System.Nullable(Of Integer)(CType(Me.SegregationComboBox.SelectedValue, Integer)))
            Me.Lst_trc_salle_segTableAdapter.Fill(Me.MydbDataSet.lst_trc_salle_seg, New System.Nullable(Of Integer)(CType(Me.Repere_salleComboBox.SelectedValue, Integer)), New System.Nullable(Of Integer)(CType(Me.SegregationComboBox.SelectedValue, Integer)))

        End If
        mysqlimport()

    End Sub

    Dim i As Integer
    Dim j As Integer
    Dim group As New NGroup()
    Private Sub mysqlimport()
        NDrawingView1.BeginInit()

        ' display the document in the view
        NDrawingView1.Document = NDrawingDocument1
        NDrawingDocument1.Reset()
        NDrawingDocument1.SizeToContent()
        NDrawingDocument1.AutoBoundsMode = AutoBoundsMode.AutoSizeToContent

        ' configure the view
        NDrawingView1.ViewLayout = ViewLayout.Normal
        NDrawingView1.Grid.Visible = False
        NDrawingView1.GlobalVisibility.ShowPorts = False
        NDrawingView1.HorizontalRuler.Visible = True
        NDrawingView1.VerticalRuler.Visible = True

        ' create two stylesheets - one for the vertices and one for the edges
        Dim vertexStyleSheet As New NStyleSheet()

        vertexStyleSheet.Name = "Vertices"

        NDrawingDocument1.StyleSheets.AddChild(vertexStyleSheet)

        Dim edgeStyleSheet As New NStyleSheet()
        edgeStyleSheet.Name = "Edges"
        edgeStyleSheet.Style.StartArrowheadStyle = New NArrowheadStyle(ArrowheadShape.Circle, "", New NSizeL(5, 5), New NColorFillStyle(Color.Gray), New NStrokeStyle(1, Color.Black))
        edgeStyleSheet.Style.EndArrowheadStyle = New NArrowheadStyle(ArrowheadShape.Arrow, "", New NSizeL(5, 5), New NColorFillStyle(Color.Gray), New NStrokeStyle(1, Color.Black))
        NDrawingDocument1.StyleSheets.AddChild(edgeStyleSheet)

        ' configure the graph data source importer
        Dim GraphImporter As New NGraphDataSourceImporter()

        ' set the document in the active layer of which the shapes will be imported
        GraphImporter.Document = NDrawingDocument1

        GraphImporter.VertexDataSource = Me.MydbDataSet.lst_trc_salle_seg
        GraphImporter.EdgeDataSource = Me.MydbDataSet.lst_assoc_seg_salle

        ' vertex records are uniquely identified by their Id (in the Pages table)
        ' edges link the vertices with the FromPageId and ToPageId (in the Links table)
        GraphImporter.VertexIdColumnName = "idtroncons"
        GraphImporter.FromVertexIdColumnName = "troncons"
        GraphImporter.ToVertexIdColumnName = "troncons_tenant"

        ' create vertices as rectangles shapes, with default size (60, 30)
        Dim shapesFactory As New NBasicShapesFactory()
        shapesFactory.DefaultSize = New NSizeF(150, 60)

        GraphImporter.VertexShapesFactory = shapesFactory
        GraphImporter.VertexShapesName = BasicShapes.Rectangle.ToString()

        ' set stylesheets to be applied to imported vertices and edges
        GraphImporter.VertexStyleSheetName = "Vertices"

        GraphImporter.EdgeStyleSheetName = "Edges"

        Dim shapes As NNodeList = NDrawingDocument1.ActiveLayer.Children(NFilters.Shape2D)
        ' use layered graph layout
        Dim layout As New NLayeredGraphLayout()
        'layout.Direction = LayoutDirection.TopToBottom
        ' layout.LayerAlignment = RelativeAlignment.Center

        layout.Direction = LayoutDirection.TopToBottom
        layout.EdgeRouting = LayeredLayoutEdgeRouting.Orthogonal
        layout.NodeRank = LayeredLayoutNodeRank.Gravity
        layout.PlugSpacing.Mode = PlugSpacingMode.Proportional
        layout.PlugSpacing.Offset = 0
        layout.LayerAlignment = RelativeAlignment.Near
        layout.NodeAlignment = RelativeAlignment.Center
        layout.SelfLoopSpacingFactor = 0.25F
        layout.VertexSpacing = 40
        layout.LayerSpacing = 40
        layout.StraightenLines = False
        layout.UseSingleBus = False
        layout.Compact = False

        layout.Layout(shapes, New NDrawingLayoutContext(NDrawingDocument1))
        GraphImporter.Layout = layout

        ' subscribe for the vertex imported event,
        ' which is raised when a shape was created for a data source record
        AddHandler GraphImporter.VertexImported, AddressOf OnVertexImported

        ' import
        GraphImporter.Import()

        ' end view init

        NDrawingView1.EndInit()
    End Sub
    Private Sub OnVertexImported(ByVal dataSourceImporter As NDataSourceImporter, ByVal shape As NShape, ByVal record As INDataRecord)
        ' display the page title in the shape
        Dim typetrc As String = record.GetColumnValue("Type").ToString()
        Dim segtrc As String = record.GetColumnValue("Segregations_idsegregations").ToString()
        Dim tx1trc As String = record.GetColumnValue("Reserve_cal").ToString()
        Dim tx2trc As String = record.GetColumnValue("reserve2_cal").ToString()
        If tx2trc = "" Then
            tx2trc = "0"
        End If
        If tx1trc = "" Then
            tx1trc = "0"
        End If
        shape.Text = record.GetColumnValue("repere troncon").ToString()

        shape.Style.FillStyle = New NColorFillStyle(Color.FromArgb(50, &HCC, 0, 0))

        shape.Labels.RemoveAllChildren()

        Dim boundsLabel As NBoundsLabel = New NBoundsLabel("Label 1, Wrapped", shape.UniqueId, New Nevron.Diagram.NMargins(0, 0, 0, 50))
        boundsLabel.Mode = BoxTextMode.Stretch
        shape.Labels.AddChild(boundsLabel)

        shape.Labels.DefaultLabelUniqueId = boundsLabel.UniqueId

        boundsLabel = New NBoundsLabel(typetrc.ToString(), shape.UniqueId, New Nevron.Diagram.NMargins(0, 0, 30, 0))
        boundsLabel.Mode = BoxTextMode.Wrap
        shape.Labels.AddChild(boundsLabel)
        boundsLabel = New NBoundsLabel("Mono :" & New System.Nullable(Of Integer)(CInt(tx1trc.ToString())) & " % Multi :" & New System.Nullable(Of Integer)(CInt(tx2trc.ToString())) & " %", shape.UniqueId, New Nevron.Diagram.NMargins(0, 0, 80, 0))
        boundsLabel.Mode = BoxTextMode.Wrap
        shape.Labels.AddChild(boundsLabel)

        '      shape(1, 1).Text = record.GetColumnValue("Type").ToString()

        If shape.Text Is Nothing Then
            shape.Text = "Title not specified"
        Else
            shape.Text = record.GetColumnValue("repere troncon").ToString()
        End If

        shape.SizeToText(New NMarginsF(10))

        ' Dim cshape As NCompositeShape = TryCast(shape, NCompositeShape)
        Select Case segtrc.ToString()

            Case Is = "0"
                ' shape.Bounds = New NRectanglePath(0, 0, 80, 80)
                shape.Style.FillStyle = New NColorFillStyle(Color.Cyan)

            Case Is = "1"
                '  shape.Primitives.AddChild(New NRectanglePath(0, 0, 80, 80))
                shape.Style.FillStyle = New NColorFillStyle(Color.CornflowerBlue)
            Case Is = "2"
                ' shape.Primitives.AddChild(New NEllipsePath(0, 0, 80, 80))
                shape.Style.FillStyle = New NColorFillStyle(Color.Violet)
            Case Is = "3"
                ' shape.Primitives.AddChild(New NEllipsePath(0, 0, 80, 80))
                shape.Style.FillStyle = New NColorFillStyle(Color.GreenYellow)
            Case Is = "4"
                ' shape.Primitives.AddChild(New NEllipsePath(0, 0, 80, 80))
                shape.Style.FillStyle = New NColorFillStyle(Color.DarkGray)
            Case Is = "5"
                ' shape.Primitives.AddChild(New NEllipsePath(0, 0, 80, 80))
                shape.Style.FillStyle = New NColorFillStyle(Color.Yellow)
            Case Is = "6"
                ' shape.Primitives.AddChild(New NEllipsePath(0, 0, 80, 80))
                shape.Style.FillStyle = New NColorFillStyle(Color.Gold)

        End Select

        Dim url As Object = record.GetColumnValue("Type")
        If url Is Nothing Or url.ToString().Length = 0 Then
            shape.Style.InteractivityStyle = New NInteractivityStyle("Type Non Specifié")
        Else
            shape.Style.InteractivityStyle = New NInteractivityStyle(url.ToString())
        End If

        '  shape.UpdateModelBounds()
        '  cshape.CreateShapeElements(ShapeElementsMask.Ports)
        '   cshape.Ports.AddChild(New NDynamicPort(New NContentAlignment(), DynamicPortGlueMode.GlueToContour))

        '   shape.SizeToText(New NMarginsF(10))

    End Sub
#End Region

    Private Sub ButtonX1_Click(sender As System.Object, e As System.EventArgs) Handles ButtonX1.Click
        Dim exporter As NAutocadExporter = New NAutocadExporter(NDrawingDocument1)
        exporter.RenderToDxf()
        exporter.ShowDialog()

    End Sub

    Private Sub NDrawingView1_Click(sender As System.Object, e As System.EventArgs) Handles NDrawingView1.Click
        Dim selection As NSelection = Me.NDrawingView1.Selection
        Dim selectedNodes As NNodeList = selection.Nodes
        Dim element As NDiagramElement = (TryCast(Me.NDrawingView1.Selection.AnchorNode, NDiagramElement))
        If element Is Nothing Then
            Return
        End If
        If TypeOf element Is Nevron.Diagram.NRectangleShape Then
            Me.TextBox3.Text = DirectCast(element, Nevron.Diagram.NRectangleShape).Text
        End If

    End Sub
End Class