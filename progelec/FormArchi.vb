Imports System.Collections.Generic
Imports System.Threading
Imports System.Windows.Forms
Imports Dataweb.NShape
Imports Dataweb.NShape.Advanced
Imports Dataweb.NShape.GeneralShapes
Imports Dataweb.NShape.WinFormsUI
Imports Dataweb.NShape.ElectricalShapes
Imports Dataweb.NShape.ElectricalModelObjects
Imports Dataweb.NShape.Layouters

Public Class FormArchi
    Dim stones As New List(Of RoundedBox)()
    Dim shapeType As ShapeType
    Dim positions As New List(Of Point)
    Dim moveCnt As Integer = 0
    Const rectSize = 100
    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click

        XmlStore1.DirectoryName = "C:\Documents and Settings\All Users\Common Files\NShape\Demo Projects"
        XmlStore1.FileExtension = "nspj"

        Project1.Name = "API DEMO"
        Project1.Close()
        Project1.Create()
        Project1.AddLibraryByName("Dataweb.NShape.GeneralShapes", True)
        Project1.AddLibraryByName("Dataweb.NShape.electricalshapes", True)
        Project1.AddLibraryByName("Dataweb.NShape.ElectricalModelObjects", True)
        Dim diagram As New Diagram("Diagram")
        Dim rectangle As DisconnectorSymbol
        Dim t As Shape
        Dim rectangle2 As DisconnectorSymbol
        Dim shape As RoundedBox
        Dim shapeType As ShapeType = Project1.ShapeTypes("Disconnector")

        Dim x As Integer = 10
        Dim y As Integer = 10
        Dim s As ShapeCollection
        s = New ShapeCollection()
        Dim detail_equi As MydbDataSet.lst_equipementsRow
        For Each equi In Me.Lst_equipementsBindingSource
            detail_equi = CType(CType(equi, DataRowView).Row, MydbDataSet.lst_equipementsRow)
            rectangle = CType(shapeType.CreateInstance, DisconnectorSymbol)
            rectangle.Text = detail_equi.repere_equipement
            rectangle.Tag = detail_equi.repere_equipement
            rectangle.Diameter = 100
            rectangle.X = x + 120

            rectangle.Y = y + 50
            x += 120
            diagram.Shapes.Add(rectangle)
            s.Add(rectangle)
            If (x > 1200) Then
                x = 10
                y += 70
            End If
        Next
        Dim arrow As Polyline

        Dim link_equi As MydbDataSet.lst_dispo_tirageRow
        For Each row_equi In Me.Lst_dispo_tirageBindingSource
            arrow = CType(Project1.ShapeTypes("Polyline").CreateInstance(), Polyline)
            link_equi = CType(CType(row_equi, DataRowView).Row, MydbDataSet.lst_dispo_tirageRow)
            For Each t In diagram.Shapes
                If CStr(t.Tag) = link_equi.tenant Then
                    arrow.Connect(ControlPointId.FirstVertex, t, ControlPointId.Reference)

                ElseIf CStr(t.Tag) = link_equi.about Then

                    arrow.Connect(ControlPointId.LastVertex, t, ControlPointId.Reference)

                End If

            Next

            'rectangle = CType(shapeType.CreateInstance, DisconnectorSymbol)
            'rectangle.Text = link_equi.tenant
            'rectangle.Tag = link_equi.tenant

            'rectangle.Diameter = 100
            'rectangle.X = x + 120

            'rectangle.Y = y + 50
            'x += 120
            'diagram.Shapes.Add(rectangle)

            'rectangle2 = CType(shapeType.CreateInstance, DisconnectorSymbol)
            'rectangle2.Text = link_equi.about
            'rectangle2.Tag = link_equi.about

            'rectangle2.Diameter = 100
            'rectangle2.X = x + 120

            'rectangle2.Y = y + 50
            'x += 120
            'diagram.Shapes.Add(rectangle2)

            'link_equi = CType(CType(row_equi, DataRowView).Row, mydbDataSet.lst_dispo_tirageRow)

            diagram.Shapes.Add(arrow)
            s.Add(arrow)
            'If (x > 1200) Then
            '    x = 10
            '    y += 70
            'End If
        Next

        'For Each rectangle In diagram.Shapes
        '    for each xx In

        '    Next
        '    arrow = CType(Project1.ShapeTypes("Polyline").CreateInstance(), Polyline)
        '    diagram.Shapes.Add(arrow)
        '    'arrow.Connect(ControlPointId.FirstVertex, , ControlPointId.Reference)

        CachedRepository1.InsertAll(diagram)
        Display1.Diagram = diagram
        Display1.Invalidate()
        Dim sh As Shape

        For Each sh In diagram.Shapes
            sh.X = 100
            sh.Y = 100

        Next
        'Dim xlayout As FlowLayouter = New FlowLayouter(Project1)
        ''xlayout.AllShapes = Display1.Diagram.Shapes
        'xlayout.Shapes = Display1.Diagram.Shapes
        'xlayout.LayerDistance = 100
        'xlayout.RowDistance = 100

        'xlayout.Direction = FlowLayouter.FlowDirection.TopDown
        'xlayout.Prepare()
        'xlayout.Execute(0)
        'layouter.Fit(50, 50, Display1.Diagram.Width - 100, Display1.Diagram.Height - 100)

        Dim layouter As RepulsionLayouter = New RepulsionLayouter(Project1)
        layouter.SpringRate = 8
        layouter.Repulsion = 3
        layouter.RepulsionRange = 500
        layouter.Friction = 0
        layouter.Mass = 50
        layouter.AllShapes = Display1.Diagram.Shapes
        layouter.Shapes = Display1.Diagram.Shapes

        layouter.Prepare()
        layouter.Execute(10)
        ' layouter.Fit(50, 50, Display1.Diagram.Width - 100, Display1.Diagram.Height - 100)

    End Sub

    Private Sub FormArchi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.equipements'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.EquipementsTableAdapter.Fill(Me.MydbDataSet.equipements)
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.departs'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.DepartsTableAdapter.Fill(Me.MydbDataSet.departs)
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.borniers'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.BorniersTableAdapter.Fill(Me.MydbDataSet.borniers)
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.lst_equipements'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.Lst_equipementsTableAdapter.Fill(Me.MydbDataSet.lst_equipements)
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.lst_dispo_tirage'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.Lst_dispo_tirageTableAdapter.Fill(Me.MydbDataSet.lst_dispo_tirage)
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.batiments'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.BatimentsTableAdapter.Fill(Me.MydbDataSet.batiments)

    End Sub

    Private Sub ButtonX2_Click(sender As Object, e As EventArgs) Handles ButtonX2.Click
        XmlStore1.DirectoryName = "C:\Documents and Settings\All Users\Common Files\NShape\Demo Projects"
        XmlStore1.FileExtension = "nspj"

        Dim equipement As Integer = CType(CType(Me.EquipementsBindingSource.Current, DataRowView).Row, MydbDataSet.equipementsRow).idequipement
        Project1.Close()
        Project1.Name = "API DEMO"
        Project1.Create()
        Project1.AddLibraryByName("Dataweb.NShape.GeneralShapes", True)
        Project1.AddLibraryByName("Dataweb.NShape.electricalshapes", True)
        Project1.AddLibraryByName("Dataweb.NShape.ElectricalModelObjects", True)
        Dim diagram As New Diagram("Diagram")
        Dim busbar As BusBarSymbol
        Dim rectangle As DisconnectorSymbol
        Dim shape As RoundedBox
        Dim xline As Polyline
        Dim shapeType As ShapeType = Project1.ShapeTypes("Disconnector")
        Dim shapeline As ShapeType = Project1.ShapeTypes("polyline")
        Dim x As Integer = 10
        Dim y As Integer = 10
        Dim s As ShapeCollection
        s = New ShapeCollection()

        '// Gaine à barre
        Dim shapeType3 As ShapeType = Project1.ShapeTypes("BusBar")
        busbar = CType(shapeType3.CreateInstance, BusBarSymbol)

        busbar.Fit(x + 120, y + 200, 300, 0)
        '  busbar.X = x + 120

        '  busbar.Y = y + 50

        'x += 120
        diagram.Shapes.Add(busbar)
        s.Add(busbar)

        Me.BorniersBindingSource.Filter = "equipements_idequipement =" & equipement
        Me.DepartsBindingSource.Filter = "equipements_idequipement =" & equipement
        diagram.Width = DepartsBindingSource.Count * 200
        diagram.Height = 500
        Dim detail_equi As MydbDataSet.borniersRow
        For Each equi In Me.BorniersBindingSource
            detail_equi = CType(CType(equi, DataRowView).Row, MydbDataSet.borniersRow)
            rectangle = CType(shapeType.CreateInstance, DisconnectorSymbol)
            xline = CType(shapeline.CreateInstance, Polyline)
            rectangle.Text = detail_equi.reference_bornier
            rectangle.Tag = detail_equi.idbornier
            rectangle.Diameter = 100
            rectangle.X = x + 120

            rectangle.Y = y + 50
            x += 120
            diagram.Shapes.Add(rectangle)
            s.Add(rectangle)
            'If (x > 1200) Then
            '    x = 10
            '    y += 70
            'End If
            xline.Connect(ControlPointId.FirstVertex, rectangle, 7)
            xline.Connect(ControlPointId.LastVertex, busbar, ControlPointId.Reference)
            diagram.Shapes.Add(xline)
        Next

        If DepartsBindingSource.Count > 0 Then
            Dim detail_equi2 As MydbDataSet.departsRow
            For Each equi In Me.DepartsBindingSource
                detail_equi2 = CType(CType(equi, DataRowView).Row, MydbDataSet.departsRow)
                rectangle = CType(shapeType.CreateInstance, DisconnectorSymbol)
                xline = CType(shapeline.CreateInstance, Polyline)
                rectangle.Text = detail_equi2.reference_depart
                rectangle.Diameter = 100
                rectangle.X = x + 120

                rectangle.Y = y + 50
                x += 120
                diagram.Shapes.Add(rectangle)
                s.Add(rectangle)
                xline.Connect(ControlPointId.FirstVertex, busbar, ControlPointId.Reference)
                xline.Connect(ControlPointId.LastVertex, rectangle, 2)
                'If (x > 1200) Then
                '    x = 10
                '    y += 70
                'End If
                diagram.Shapes.Add(xline)
            Next
        End If

        CachedRepository1.InsertAll(diagram)
        Display1.Diagram = diagram
        Display1.Invalidate()

        Dim xlayout As FlowLayouter = New FlowLayouter(Project1)
        ' xlayout.AllShapes = Display1.Diagram.Shapes
        xlayout.Shapes = Display1.Diagram.Shapes
        xlayout.Direction = FlowLayouter.FlowDirection.TopDown
        xlayout.Prepare()
        xlayout.Execute(10)
        'x = 10
        'y += 100

        'Dim shapeType2 As ShapeType = Project1.ShapeTypes("BusBar")

        'For Each equi In Me.BorniersBindingSource

        '    busbar = CType(shapeType2.CreateInstance, BusBarSymbol)

        '    busbar.X = x + 120

        '    busbar.Y = y + 50

        '    x += 120
        '    diagram.Shapes.Add(busbar)
        '    s.Add(busbar)
        '    'If (x > 1200) Then
        '    '    x = 10
        '    '    y += 70
        '    'End If
        '    Dim ss As Shape
        '    For Each ss In s

        '    Next
        'busbar.Connect(ControlPointId.FirstVertex, , ControlPointId.Reference)
        'busbar.Connect(ControlPointId.LastVertex, , ControlPointId.Reference)

        'Next

        'If DepartsBindingSource.Count > 0 Then
        '    Dim detail_equi2 As mydbDataSet.departsRow
        '    For Each equi In Me.DepartsBindingSource
        '        detail_equi2 = CType(CType(equi, DataRowView).Row, mydbDataSet.departsRow)
        '        rectangle = CType(shapeType.CreateInstance, DisconnectorSymbol)
        '        rectangle.Text = detail_equi2.reference_depart
        '        rectangle.Diameter = 100
        '        rectangle.X = x + 120

        '        rectangle.Y = y + 50
        '        x += 120
        '        diagram.Shapes.Add(rectangle)
        '        s.Add(rectangle)
        '        'If (x > 1200) Then
        '        '    x = 10
        '        '    y += 70
        '        'End If
        '    Next
        'End If

    End Sub
End Class