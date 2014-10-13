Imports Nevron.Diagram.Filters
Imports Nevron.Dom
Imports Nevron.Diagram.Layout
Imports Nevron.Diagram.DataImport
Imports Nevron.GraphicsCore
Imports Nevron.Diagram
Imports Nevron.Diagram.Shapes
Imports Nevron.Diagram.Extensions
Imports Nevron.Diagram.WinForm
Imports Nevron.Diagram.DataStructures
Imports Nevron.Diagram.Templates
Public Class FormSynoptique

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

        NDrawingView1.BeginInit()

        ' display the document in the view
        NDrawingView1.Document = NDrawingDocument1
        NDrawingDocument1.Reset()

        'NDrawingDocument1.AutoBoundsMode = AutoBoundsMode.AutoSizeToContent

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
        'ajout des filters
        Dim datacable As DataView
        Dim datacable_old As DataTable

        datacable = New DataView(Me.MydbDataSet.cables)

        If Me.CheckBoxX5.Checked Then
            datacable.RowFilter = "idequipement='" & ComboBox1.SelectedValue.ToString & "'"
        Else
            datacable.RowFilter = Nothing
        End If
        datacable_old = datacable.ToTable
        Dim datacable_oldview As DataView
        datacable_oldview = New DataView(datacable_old)
        'batiment
        Dim dataequipe As DataView

        dataequipe = New DataView(Me.MydbDataSet.lst_equipements)

        dataequipe.RowFilter = "idbatiment='" & Me.ComboBox2.SelectedValue.ToString & "'"
        Dim dataequipe_old As DataTable
        dataequipe_old = dataequipe.ToTable
        Dim dataequipe_oldview As DataView
        dataequipe_oldview = New DataView(dataequipe_old)

        Dim r As MydbDataSet.lst_equipementsRow
        Dim rr As DataRowView
        If CheckBoxX5.Checked Then

            For Each rr In dataequipe_oldview
                '  r = CType(rr.Row , mydbDataSet.lst_equipementsRow)

                datacable_oldview.Sort = "idequipement2"
                If Not CInt(rr("idequipement").ToString) = CInt(ComboBox1.SelectedValue.ToString) Then

                    Dim index As Integer = datacable_oldview.Find(rr("idequipement").ToString)
                    If index = -1 Then
                        rr.Delete()
                    End If
                End If
            Next

            datacable_oldview.Sort = Nothing
        End If
        '  GraphImporter.VertexDataSource = Me.MydbDataSet.equipements
        '  GraphImporter.EdgeDataSource = Me.MydbDataSet.cables
        GraphImporter.VertexDataSource = dataequipe_oldview

        GraphImporter.EdgeDataSource = datacable_oldview

        ' vertex records are uniquely identified by their Id (in the Pages table)
        ' edges link the vertices with the FromPageId and ToPageId (in the Links table)
        GraphImporter.VertexIdColumnName = "idequipement"
        GraphImporter.FromVertexIdColumnName = "idequipement"
        GraphImporter.ToVertexIdColumnName = "idequipement2"

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
        'Dim layout As New NLayeredGraphLayout()

        '''layout.Direction = LayoutDirection.TopToBottom
        ''' layout.LayerAlignment = RelativeAlignment.Center

        'layout.Direction = LayoutDirection.TopToBottom
        'layout.EdgeRouting = LayeredLayoutEdgeRouting.Orthogonal
        'layout.NodeRank = LayeredLayoutNodeRank.Gravity

        'layout.PlugSpacing.Mode = PlugSpacingMode.Proportional
        'layout.PlugSpacing.Offset = 0
        'layout.MultiThreaded = True
        'layout.LayerAlignment = RelativeAlignment.Center
        'layout.NodeAlignment = RelativeAlignment.Center
        'layout.SelfLoopSpacingFactor = 0.25
        'layout.VertexSpacing = 40
        'layout.LayerSpacing = 40

        'layout.StraightenLines = False
        'layout.UseSingleBus = False
        'layout.Compact = False

        Dim layout As New NLayeredGraphLayout()
        'layout.Compact = False
        'layout.MultiThreaded = True
        'layout.CellSpacing = 10
        'layout.GridCellSizeMode = GridCellSizeMode.GridBased

        layout.Layout(shapes, New NDrawingLayoutContext(NDrawingDocument1))
        GraphImporter.Layout = layout

        ' subscribe for the vertex imported event,
        ' which is raised when a shape was created for a data source record
        AddHandler GraphImporter.VertexImported, AddressOf OnVertexImported
        AddHandler GraphImporter.EdgeImported, AddressOf OnEdgeImported
        ' import
        GraphImporter.Import()

        ' end view init,
        Dim shapes2 As NNodeList = NDrawingDocument1.ActiveLayer.Descendants(NFilters.Shape2D, -1)
        Dim count As Integer = shapes2.Count
        count = count - 1
        For i = 0 To count
            Dim shap As NShape = CType(shapes2(i), NShape)

            If shap.GetOutgoingShapes.Count > 0 Then
                shap.CreateShapeElements(ShapeElementsMask.Decorators)
                Dim decorator As NShowHideSubtreeDecorator = New NShowHideSubtreeDecorator
                decorator.Name = "detail equipement"
                shap.Decorators.AddChild(New NShowHideSubtreeDecorator)
            End If

        Next

        NDrawingView1.EndInit()
        NDrawingDocument1.SizeToContent()

    End Sub
    Private Sub OnEdgeImported(ByVal dataSourceImporter As NDataSourceImporter, ByVal shape As NShape, ByVal record As INDataRecord)
        shape.Text = record.GetColumnValue("repere cable").ToString()

    End Sub

    Private Sub OnVertexImported(ByVal dataSourceImporter As NDataSourceImporter, ByVal shape As NShape, ByVal record As INDataRecord)
        ' display the page title in the shape

        ' display the page title in the shape
        Dim typetrc As String = record.GetColumnValue("repere equipement").ToString()
        ' Dim segtrc As String = record.GetColumnValue("salles_idsalle").ToString()

        'shape.Text = record.GetColumnValue("repere equipement").ToString()

        shape.Style.FillStyle = New NColorFillStyle(Color.FromArgb(50, &HCC, 0, 0))

        shape.Labels.RemoveAllChildren()

        Dim boundsLabel As NBoundsLabel = New NBoundsLabel("Label 1, Wrapped", shape.UniqueId, New Nevron.Diagram.NMargins(0, 0, 0, 50))
        boundsLabel.Mode = BoxTextMode.Stretch
        shape.Labels.AddChild(boundsLabel)

        shape.Labels.DefaultLabelUniqueId = boundsLabel.UniqueId

        boundsLabel = New NBoundsLabel(typetrc.ToString(), shape.UniqueId, New Nevron.Diagram.NMargins(0, 0, 30, 0))
        boundsLabel.Mode = BoxTextMode.Wrap
        shape.Labels.AddChild(boundsLabel)

        '      shape(1, 1).Text = record.GetColumnValue("Type").ToString()

        If shape.Text Is Nothing Then
            shape.Text = "Title not specified"
        Else
            shape.Text = record.GetColumnValue("repere equipement").ToString()
        End If

        shape.SizeToText(New NMarginsF(10))

        ' Dim cshape As NCompositeShape = TryCast(shape, NCompositeShape)

    End Sub
    Private highlightFillStyle As NColorFillStyle = Nothing
    Private highlightStrokeStyle As NStrokeStyle = Nothing

    Private Sub FormSynoptique_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.lst_equipements'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.Lst_equipementsTableAdapter.Fill(Me.MydbDataSet.lst_equipements)
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.batiments'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.BatimentsTableAdapter.Fill(Me.MydbDataSet.batiments)
        AttachToEvents()
        highlightFillStyle = New NColorFillStyle(Color.FromArgb(80, Color.Red))
        highlightStrokeStyle = New NStrokeStyle(2, Color.Red)
        Me.EquipementsTableAdapter.Fill(Me.MydbDataSet.equipements)

        Me.CablesTableAdapter.Fill(Me.MydbDataSet.cables)
        Dim col As New AutoCompleteStringCollection
        Dim i As Integer
        For i = 0 To Me.MydbDataSet.equipements.Rows.Count - 1
            col.Add(Me.MydbDataSet.equipements.Rows(i)("repere equipement").ToString())
        Next
        ComboBox1.AutoCompleteSource = AutoCompleteSource.CustomSource
        ComboBox1.AutoCompleteCustomSource = col
        ComboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend

    End Sub

    Private Sub ComboBox1_SelectedValueChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox1.SelectedValueChanged
        If Not IsNothing(Me.ComboBox1.SelectedValue) Then
            If Me.CheckBoxX5.Checked Then

                Me.CablesBindingSource.Filter = "idequipement= " & Me.ComboBox1.SelectedValue.ToString
            End If
        End If
    End Sub

    Private Sub UpdateHighlights()
        ClearHighlights()

        ' get the selected shape
        Dim shape As NShape = (TryCast(NDrawingView1.Selection.AnchorNode, NShape))
        If shape Is Nothing Then
            NDrawingDocument1.SmartRefreshAllViews()
            Return
        End If

        ' build the graph in which the shape resides
        Dim graphBuilder As NGraphBuilder = New NGraphBuilder(New NShapeGraphAdapter(), New NGraphPartFactory())

        Dim map As NObjectGraphPartMap
        Dim graph As NGraph = graphBuilder.BuildGraph(shape, map)

        If graph Is Nothing Then
            NDrawingDocument1.SmartRefreshAllViews()
            Return
        End If

        Dim shapesToHighlight As NNodeList = New NNodeList()
        Select Case shape.ShapeType
            Case ShapeType.Shape2D

                ' 2D shapes are treated as graph vertices, so we must find the vertex in the graph, which
                ' represents the shape
                Dim vertex As NGraphVertex = (TryCast(map.GetPartFromObject(shape), NGraphVertex))
                If Not vertex Is Nothing Then
                    ' add edges
                    'If allEdgesCheck.Checked Then
                    '    shapesToHighlight.AddRangeNoDuplicates(GetShapesList(vertex.Edges, map))
                    'Else
                    If CheckBoxX1.Checked Then
                        shapesToHighlight.AddRangeNoDuplicates(GetShapesList(vertex.IncomingEdges, map))
                    End If

                    If CheckBoxX2.Checked Then
                        shapesToHighlight.AddRangeNoDuplicates(GetShapesList(vertex.OutgoingEdges, map))
                    End If
                    'End If

                    ' add neighbour vertices
                    'If neighbourVerticesCheck.Checked Then
                    '    shapesToHighlight.AddRangeNoDuplicates(GetShapesList(vertex.NeighbourVertices, map))
                    'Else
                    If CheckBoxX1.Checked Then
                        shapesToHighlight.AddRangeNoDuplicates(GetShapesList(vertex.SourceVertices, map))
                    End If

                    If CheckBoxX2.Checked Then
                        shapesToHighlight.AddRangeNoDuplicates(GetShapesList(vertex.DestinationVertices, map))
                    End If
                    '    End If

                    ' add accessible vertices
                    'If accessibleVerticesCheck.Checked Then
                    '    shapesToHighlight.AddRangeNoDuplicates(GetShapesList(vertex.AccessibleVertices, map))
                    'Else
                    If CheckBoxX4.Checked Then
                        shapesToHighlight.AddRangeNoDuplicates(GetShapesList(vertex.PredecessorVertices, map))
                    End If

                    If CheckBoxX3.Checked Then
                        shapesToHighlight.AddRangeNoDuplicates(GetShapesList(vertex.SuccessorVertices, map))
                    End If
                    'End If
                End If

            Case ShapeType.Shape1D

                ' 1D shapes are treated as graph edges, so we must find the edge in the graph, which
                ' represents the shape
                Dim edge As NGraphEdge = (TryCast(map.GetPartFromObject(shape), NGraphEdge))
                If Not edge Is Nothing Then
                    If CheckBoxX2.Checked Then
                        shapesToHighlight.AddNoDuplicates(CType(map.GetObjectFromPart(edge.FromVertex), NShape))
                    End If

                    If CheckBoxX1.Checked Then
                        shapesToHighlight.AddNoDuplicates(CType(map.GetObjectFromPart(edge.ToVertex), NShape))
                    End If
                End If
        End Select

        ' highlight the shapes
        For Each cur As NShape In shapesToHighlight
            cur.Style.FillStyle = (TryCast(highlightFillStyle.Clone(), NFillStyle))
            cur.Style.StrokeStyle = (TryCast(highlightStrokeStyle.Clone(), NStrokeStyle))
        Next cur

        ' smart refresh all views
        NDrawingDocument1.SmartRefreshAllViews()
    End Sub

    Private Sub ClearHighlights()
        Dim en As NNodeEnumerator = NDrawingDocument1.ActiveLayer.GetEnumerator(Nothing)
        Do While en.MoveNext()
            Dim shape As NShape = (TryCast(en.Current, NShape))
            If Not shape Is Nothing Then
                shape.Style.FillStyle = Nothing
                shape.Style.StrokeStyle = Nothing
            End If
        Loop
    End Sub
    Private Function GetShapesList(ByVal edges As NGraphEdgeList, ByVal map As NObjectGraphPartMap) As NNodeList
        Dim list As NNodeList = New NNodeList()
        Dim i As Integer, edgeCount As Integer = edges.Count
        i = 0
        Do While i < edgeCount
            list.Add(CType(map.GetObjectFromPart(edges(i)), NShape))
            i += 1
        Loop

        Return list
    End Function

    Private Function GetShapesList(ByVal vertices As NGraphVertexList, ByVal map As NObjectGraphPartMap) As NNodeList
        Dim list As NNodeList = New NNodeList()
        Dim i As Integer, vertexCount As Integer = vertices.Count
        i = 0
        Do While i < vertexCount
            list.Add(CType(map.GetObjectFromPart(vertices(i)), NShape))
            i += 1
        Loop

        Return list
    End Function
    Private Sub EventSinkService_OnNodeSelected(ByVal args As NNodeEventArgs)
        Dim shape As NShape = (TryCast(args.Node, NShape))
        If Not shape Is Nothing Then

            'graphPartCheck.Enabled = True
            'graphPartCheck.Checked = shape.GraphPart

        End If

        UpdateHighlights()
    End Sub

    Private Sub EventSinkService_OnNodeDeselected(ByVal args As NNodeEventArgs)
        ClearHighlights()
        'graphPartCheck.Enabled = False

        NDrawingDocument1.SmartRefreshAllViews()
    End Sub

    Protected Sub AttachToEvents()
        AddHandler NDrawingView1.EventSinkService.NodeSelected, AddressOf EventSinkService_OnNodeSelected
        AddHandler NDrawingView1.EventSinkService.NodeDeselected, AddressOf EventSinkService_OnNodeDeselected

    End Sub

    Protected Sub DetachFromEvents()
        RemoveHandler NDrawingView1.EventSinkService.NodeSelected, AddressOf EventSinkService_OnNodeSelected
        RemoveHandler NDrawingView1.EventSinkService.NodeDeselected, AddressOf EventSinkService_OnNodeDeselected

    End Sub

    Private Sub CheckBoxX1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxX1.CheckedChanged
        'If Me.CheckBoxX1.Checked Then
        '    Me.CheckBoxX2.Checked = False
        'End If
        UpdateHighlights()

    End Sub

    Private Sub CheckBoxX2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxX2.CheckedChanged
        'If Me.CheckBoxX2.Checked Then
        '    Me.CheckBoxX1.Checked = False
        'End If
        UpdateHighlights()
    End Sub

    Private Sub CheckBoxX3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxX3.CheckedChanged
        UpdateHighlights()
    End Sub

    Private Sub CheckBoxX4_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxX4.CheckedChanged
        UpdateHighlights()
    End Sub

    Private Sub ComboBox2_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedValueChanged
        'todo Mise en place de filtre
        ' Me.EquipementsBindingSource.Filter = "=" & Me.ComboBox2.SelectedValue.ToString
    End Sub

    Private Sub CheckBoxX5_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxX5.CheckedChanged

    End Sub
End Class