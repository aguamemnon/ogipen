Imports Nevron.Diagram.Filters
Imports Nevron.Dom
Imports Nevron.Diagram.Layout
Imports Nevron.Diagram.DataImport
Imports Nevron.GraphicsCore
Imports Nevron.Diagram
Imports Nevron.Diagram.Shapes

Public Class Formserge
    Dim datatroncons As DataView
    Dim datatroncons_old As DataTable
    Dim datatroncons_oldview As DataView
    Dim dataassoc As DataView
    Dim dataassoc_old As DataTable
    Dim dataassoc_oldview As DataView
#Region "Nshape"

    Private Sub Formserge_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet1.segregations'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.SegregationsTableAdapter.Fill(Me.MydbDataSet1.segregations)
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet1.salles'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.SallesTableAdapter.Fill(Me.MydbDataSet1.salles)
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet1.batiments'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.BatimentsTableAdapter.Fill(Me.MydbDataSet1.batiments)
        AttachToEvents()
        'TODO: This line of code loads data into the 'MydbDataSet1.troncons_assoc' table. You can move, or remove it, as needed.
        Me.Troncons_assocTableAdapter.Fill(Me.MydbDataSet1.troncons_assoc)
        'TODO: This line of code loads data into the 'MydbDataSet1.troncons' table. You can move, or remove it, as needed.
        Me.TronconsTableAdapter.Fill(Me.MydbDataSet1.troncons)

    End Sub

#End Region

#Region "Nevron"
    Protected Sub AttachToEvents()
        AddHandler NDrawingView1.EventSinkService.NodeSelected, AddressOf EventSinkService_OnNodeSelected
        ' AddHandler NDrawingView1.EventSinkService.NodeDeselected, AddressOf EventSinkService_OnNodeDeselected

    End Sub

    Protected Sub DetachFromEvents()
        RemoveHandler NDrawingView1.EventSinkService.NodeSelected, AddressOf EventSinkService_OnNodeSelected
        'RemoveHandler NDrawingView1.EventSinkService.NodeDeselected, AddressOf EventSinkService_OnNodeDeselected

    End Sub
    Private Sub EventSinkService_OnNodeSelected(ByVal args As NNodeEventArgs)
        Dim shape As NShape = (TryCast(args.Node, NShape))
        If Not shape Is Nothing Then

            Me.TextBoxX1.Text = shape.Text
            '  Dim label As NLabel
            ' label= shape.Labels.Id(2)
            For Each label As NLabel In shape.Labels.Children(Nothing)

                If label.ZOrder = 2 Then
                    Me.TextBoxX2.Text = label.Text
                End If
            Next

            '  me.TextBoxX2.Text = shape.Labels.GetChildFromId(2).Tag
            'graphPartCheck.Enabled = True
            'graphPartCheck.Checked = shape.GraphPart

        Else
            Me.TextBoxX1.Text = ""
            Me.TextBoxX2.Text = """"

        End If

    End Sub
    Private Sub ButtonX3_Click(sender As System.Object, e As System.EventArgs)
        NDrawingView1.BeginInit()

        ' display the document in the view
        NDrawingView1.Document = NDrawingDocument1
        NDrawingDocument1.Reset()
        NDrawingDocument1.SizeToContent()
        '     NDrawingDocument1.AutoBoundsMode = AutoBoundsMode.AutoSizeToContent

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

        'generation avec filtres

        'reseaux

        GraphImporter.VertexDataSource = datatroncons_oldview
        GraphImporter.EdgeDataSource = dataassoc_oldview

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
        layout.NodeRank = LayeredLayoutNodeRank.Optimal
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

    Private Sub mysqlimport(sender As System.Object, e As System.EventArgs) Handles ButtonX3.Click

        NDrawingView1.BeginInit()
        'NDrawingView1.Reset
        ' display the document in the view
        NDrawingDocument1.Reset()
        NDrawingView1.Document = NDrawingDocument1
        NDrawingDocument1.SizeToContent()
        ' configure the view
        '   NDrawingView1.ViewLayout = ViewLayout.StretchToHeight
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

        ' set the connection string, data sources and DataAdapters
        ' in this example we have created two OleDbDataAdapters:
        ' the PagesDataAdapter selects all records and columns from the Pages table of the SiteMap.mdb
        ' the LinksDataAdapter selects all records and columns from the Links table of the SiteMap.mdb
        'Dim connString As String = "server=127.0.0.1;User Id=root;database=progelec"";"
        'Dim PagesDataAdapter As New OleDbDataAdapter("SELECT * FROM Pages", connString)
        'Dim LinksDataAdapter As New OleDbDataAdapter("SELECT * FROM Links", connString)

        'Filtre batiment

        If CheckBoxX1.Checked Then
            'filtre segregation

            Dim rr As DataRowView

            datatroncons = New DataView(Me.MydbDataSet1.troncons)
            datatroncons_old = datatroncons.ToTable

            datatroncons_oldview = New DataView(datatroncons_old)

            If CheckBoxX2.Checked Then

            Else
                For Each rr In datatroncons_oldview

                    Me.SallesBindingSource.Sort = "idsalle"

                    Dim index As Integer = Me.SallesBindingSource.Find("idsalle", rr("salles").ToString)
                    If index = -1 Then
                        rr.Delete()
                    End If

                Next

            End If

            If Not Me.CheckBoxX3.Checked Then
                datatroncons_oldview.RowFilter = "segregations_idsegregations='" & Me.ComboBoxEx4.SelectedValue.ToString & "' or segregations_idsegregations='0'"
            End If

            dataassoc = New DataView(Me.MydbDataSet1.troncons_assoc)

            dataassoc_old = dataassoc.ToTable

            dataassoc_oldview = New DataView(dataassoc_old)

            For Each rr In dataassoc_oldview

                datatroncons_oldview.Sort = "idtroncons"

                Dim index As Integer = datatroncons_oldview.Find(rr("troncons").ToString)
                If index = -1 Then
                    rr.Delete()
                End If

            Next

            For Each rr In dataassoc_oldview

                datatroncons_oldview.Sort = "idtroncons"

                Dim index As Integer = datatroncons_oldview.Find(rr("troncons_tenant").ToString)
                If index = -1 Then
                    rr.Delete()
                End If

            Next

        Else
            ' sans filtre
            datatroncons = New DataView(Me.MydbDataSet1.troncons)
            datatroncons_old = datatroncons.ToTable

            datatroncons_oldview = New DataView(datatroncons_old)
            dataassoc = New DataView(Me.MydbDataSet1.troncons_assoc)

            dataassoc_old = dataassoc.ToTable

            dataassoc_oldview = New DataView(dataassoc_old)

        End If

        GraphImporter.VertexDataSource = datatroncons_oldview ' Me.MydbDataSet1.troncons
        GraphImporter.EdgeDataSource = dataassoc_oldview ' Me.MydbDataSet1.troncons_assoc

        ' vertex records are uniquely identified by their Id (in the Pages table)
        ' edges link the vertices with the FromPageId and ToPageId (in the Links table)
        GraphImporter.VertexIdColumnName = "idtroncons"
        GraphImporter.FromVertexIdColumnName = "troncons"
        GraphImporter.ToVertexIdColumnName = "troncons_tenant"

        ' create vertices as rectangles shapes, with default size (60, 30)
        Dim shapesFactory As New NBasicShapesFactory()
        shapesFactory.DefaultSize = New NSizeF(60, 30)
        GraphImporter.VertexShapesFactory = shapesFactory
        GraphImporter.VertexShapesName = BasicShapes.Rectangle.ToString()

        ' set stylesheets to be applied to imported vertices and edges
        GraphImporter.VertexStyleSheetName = "Vertices"
        GraphImporter.EdgeStyleSheetName = "Edges"

        ' use layered graph layout
        Dim layout As New NLayeredGraphLayout()
        layout.Direction = LayoutDirection.TopToBottom
        layout.LayerAlignment = RelativeAlignment.Near
        GraphImporter.Layout = layout

        ' subscribe for the vertex imported event,
        ' which is raised when a shape was created for a data source record
        AddHandler GraphImporter.VertexImported, AddressOf OnVertexImported

        ' import
        GraphImporter.Import()

        ' end view init

        NDrawingView1.EndInit()
        Dim shapes As NNodeList = NDrawingDocument1.ActiveLayer.Children(NFilters.Shape2D)

        ' layout the shapes
        If Not layout Is Nothing Then
            layout.Layout(shapes, New NDrawingLayoutContext(NDrawingDocument1))
        End If

        ' resize document to fit all shapes
        NDrawingDocument1.SizeToContent()

    End Sub
    Private Sub OnVertexImported(ByVal dataSourceImporter As NDataSourceImporter, ByVal shape As NShape, ByVal record As INDataRecord)
        ' display the page title in the shape

        ' display the page title in the shape
        Dim typetrc As String = record.GetColumnValue("Types_troncons_idTypes_troncons").ToString()
        Dim segtrc As String = record.GetColumnValue("Segregations_idsegregations").ToString()
        Dim tx1trc As String = record.GetColumnValue("Reserve_cal").ToString()
        Dim tx2trc As String = record.GetColumnValue("reserve2_cal").ToString()
        If tx2trc = "" Then
            tx2trc = "0"
        End If
        If tx1trc = "" Then
            tx1trc = "0"
        End If
        'If Not Integer.TryParse(tx1trc, Nothing) Then tx1trc = "0"
        'If Not Integer.TryParse(tx2trc, Nothing) Then tx2trc = "0"
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
        boundsLabel = New NBoundsLabel("Mono :" & (CDbl(tx1trc)) & " % Multi :" & (CDbl(tx2trc)) & " %", shape.UniqueId, New Nevron.Diagram.NMargins(0, 0, 80, 0))
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

            Case Is = "7"
                ' shape.Primitives.AddChild(New NEllipsePath(0, 0, 80, 80))
                shape.Style.FillStyle = New NColorFillStyle(Color.Beige)

            Case Is = "8"
                ' shape.Primitives.AddChild(New NEllipsePath(0, 0, 80, 80))
                shape.Style.FillStyle = New NColorFillStyle(Color.Coral)

            Case Is = "9"
                ' shape.Primitives.AddChild(New NEllipsePath(0, 0, 80, 80))
                shape.Style.FillStyle = New NColorFillStyle(Color.Green)
            Case Is = "10"
                ' shape.Primitives.AddChild(New NEllipsePath(0, 0, 80, 80))
                shape.Style.FillStyle = New NColorFillStyle(Color.Linen)

        End Select

        Dim url As Object = record.GetColumnValue("Types_troncons_idTypes_troncons")
        If url Is Nothing Or url.ToString().Length = 0 Then
            shape.Style.InteractivityStyle = New NInteractivityStyle("Type Non Specifié")
        Else
            shape.Style.InteractivityStyle = New NInteractivityStyle(url.ToString())
        End If

    End Sub
#End Region

    Private Sub ComboBoxEx3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxEx3.SelectedIndexChanged

        '       datatroncons_oldview

        'dataassoc_oldview
        If Not IsNothing(Me.ComboBoxEx3.SelectedValue) Then
            Me.SallesBindingSource.Filter = "Batiments_idBatiment= " & Me.ComboBoxEx3.SelectedValue.ToString
            Me.SallesBindingSource2.Filter = "Batiments_idBatiment= " & Me.ComboBoxEx3.SelectedValue.ToString
        End If

    End Sub
End Class