Imports System.Algorithms.Dijkstra
Public Class FormParcours
    Inherits DevComponents.DotNetBar.RibbonForm
    Public dataSet As DataSet
    Public dataSet2 As DataSet
    Public dataset3 As DataSet
    Public dataset4 As DataSet
    Public troncon_associations As DataView
    Public troncons_seg As DataView

    Public graph As Graph
    Dim lt As DataTable = New DataTable("troncons_seg2")
    Dim lt2 As DataTable = New DataTable("troncons_tri")

    Dim column As DataColumn
    Dim row As DataRow
    Dim i As Integer
    Dim a As Integer
    '

    Dim st As Integer
    Dim fn As Integer
    Dim item As Object

    Private Sub FormParcours_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Me.SallesTableAdapter.Fill(Me.MydbDataSet.salles)
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.segregations'. Vous pouvez la déplacer ou la supprimer selon vos besoins.

        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.equipements'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.EquipementsTableAdapter.Fill(Me.MydbDataSet.equipements)
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.salles'. Vous pouvez la déplacer ou la supprimer selon vos besoins.

        Me.ParcoursTableAdapter.Fill(Me.MydbDataSet.parcours)
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.parcours_detail'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.Parcours_detailTableAdapter.Fill(Me.MydbDataSet.parcours_detail)
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.cables'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.CablesTableAdapter.Fill(Me.MydbDataSet.cables)
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.parcours'. Vous pouvez la déplacer ou la supprimer selon vos besoins.

        ' Declare variables

        Me.SegregationsTableAdapter.Fill(Me.MydbDataSet.segregations)
        ' Create new DataColumn, set DataType, ColumnName
        ' and add to DataTable.
        column = New DataColumn()
        column.DataType = System.Type.GetType("System.Int32")
        column.ColumnName = "id"
        column.ReadOnly = True
        column.Unique = True

        ' Add the Column to the DataColumnCollection.
        lt.Columns.Add(column)

        ' Create second column.
        column = New DataColumn()
        column.DataType = System.Type.GetType("System.String")
        column.ColumnName = "troncon"
        column.AutoIncrement = False
        column.Caption = "troncon"
        column.ReadOnly = False
        column.Unique = False

        ' Add the column to the table.
        lt.Columns.Add(column)

        ' Make the ID column the primary key column.
        Dim PrimaryKeyColumns(0) As DataColumn
        PrimaryKeyColumns(0) = lt.Columns("id")
        lt.PrimaryKey = PrimaryKeyColumns

        ' Instantiate the DataSet variable.
        dataSet = New DataSet()

        ' Add the new DataTable to the DataSet.
        dataSet.Tables.Add(lt)

        ' Create new DataColumn, set DataType, ColumnName
        ' and add to DataTable.
        column = New DataColumn()
        column.DataType = System.Type.GetType("System.Int32")
        column.ColumnName = "id"
        column.ReadOnly = True
        column.Unique = True

        ' Add the Column to the DataColumnCollection.
        lt2.Columns.Add(column)

        ' Create second column.
        column = New DataColumn()
        column.DataType = System.Type.GetType("System.Int32")
        column.ColumnName = "id_troncon"
        column.AutoIncrement = False
        column.Caption = "troncon"
        column.ReadOnly = False
        column.Unique = False

        ' Add the column to the table.
        lt2.Columns.Add(column)

        ' Create second column.
        column = New DataColumn()
        column.DataType = System.Type.GetType("System.Int32")
        column.ColumnName = "id_troncon2"
        column.AutoIncrement = False
        column.Caption = "troncon tenant"
        column.ReadOnly = False
        column.Unique = False

        ' Add the column to the table.
        lt2.Columns.Add(column)

        ' Create second column.
        column = New DataColumn()
        column.DataType = System.Type.GetType("System.Int32")
        column.ColumnName = "longueur"
        column.AutoIncrement = False
        column.Caption = "longueur"
        column.ReadOnly = False
        column.Unique = False

        ' Add the column to the table.
        lt2.Columns.Add(column)

        ' Make the ID column the primary key column.

        PrimaryKeyColumns(0) = lt2.Columns("id")
        lt2.PrimaryKey = PrimaryKeyColumns
        dataSet.Tables.Add(lt2)

        Me.ComboBox.Enabled = False
        Me.ComboBox2.Enabled = False
        Me.ComboBox3.Enabled = False
        Me.ComboBox5.Enabled = False
        Me.ComboBox3.Text = ""
        param1 = CInt("0")

    End Sub

    Private Sub ButtonXFermer_Click(sender As System.Object, e As System.EventArgs) Handles ButtonXFermer.Click
        Me.Close()
    End Sub

    Private Sub IdsalleTextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles IdsalleTextBox1.TextChanged
        If Me.IdsalleTextBox1.Text <> "" And Me.IdsegregationsTextBox.Text <> "" Then
            Me.ComboBox3.Enabled = True

            Me.Lst_troncons_on2TableAdapter.Fill(Me.MydbDataSet.lst_troncons_on2, New System.Nullable(Of Integer)(CType(Me.IdsalleTextBox1.Text, Integer)), New System.Nullable(Of Integer)(CType(Me.IdsegregationsTextBox.Text, Integer)))
            Me.ComboBox3.DataSource = Me.Lst_troncons_on2BindingSource
        End If
    End Sub

    Private Sub IdsalleTextBox_TextChanged(sender As System.Object, e As System.EventArgs) Handles IdsalleTextBox.TextChanged
        If Me.IdsalleTextBox.Text <> "" And Me.IdsegregationsTextBox.Text <> "" Then

            Me.ComboBox2.Enabled = True

            Me.Lst_troncons_onTableAdapter.Fill(Me.MydbDataSet.lst_troncons_on, New System.Nullable(Of Integer)(CType(Me.IdsalleTextBox.Text, Integer)), New System.Nullable(Of Integer)(CType(Me.IdsegregationsTextBox.Text, Integer)))
            Me.ComboBox2.DataSource = Me.Lst_troncons_onBindingSource
        End If
    End Sub

    Private Sub ComboBox1_SelectedValueChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox1.SelectedValueChanged
        Me.ComboBox5.Enabled = True
        Me.ComboBox.Enabled = True

    End Sub

    Private Sub IdsegregationsTextBox_TextChanged(sender As System.Object, e As System.EventArgs) Handles IdsegregationsTextBox.TextChanged
        If Me.IdsalleTextBox.Text <> "" And Me.IdsalleTextBox1.Text <> "" And Me.IdsegregationsTextBox.Text <> "" Then
            Me.Lst_troncons_onTableAdapter.Fill(Me.MydbDataSet.lst_troncons_on, New System.Nullable(Of Integer)(CType(Me.IdsalleTextBox.Text, Integer)), New System.Nullable(Of Integer)(CType(Me.IdsegregationsTextBox.Text, Integer)))
            Me.ComboBox2.DataSource = Me.Lst_troncons_onBindingSource
            Me.Lst_troncons_on2TableAdapter.Fill(Me.MydbDataSet.lst_troncons_on2, New System.Nullable(Of Integer)(CType(Me.IdsalleTextBox1.Text, Integer)), New System.Nullable(Of Integer)(CType(Me.IdsegregationsTextBox.Text, Integer)))
            Me.ComboBox3.DataSource = Me.Lst_troncons_on2BindingSource
        End If
    End Sub

    Private Sub ButtonXCreer_Click(sender As System.Object, e As System.EventArgs) Handles ButtonXCreer.Click
        Select Case MessageBox.Show("Vous allez creer un parcour entre et .Etes vous sur ?", "Creation d'un parcour", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            Case System.Windows.Forms.DialogResult.Yes
                'verification de la selection
                st = CInt(Me.IdtronconsTextBox.Text)
                fn = CInt(Me.IdtronconsTextBox1.Text)

                If st = 0 Then

                    MessageBox.Show("Aucun parcours possible" _
            & Microsoft.VisualBasic.ControlChars.CrLf & "" _
            & Microsoft.VisualBasic.ControlChars.CrLf & "Veuillez selectionner Le tronçon tenant .", "Impossible", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    Exit Sub
                End If

                If fn = 0 Then

                    MessageBox.Show("Aucun parcours possible" _
            & Microsoft.VisualBasic.ControlChars.CrLf & "" _
            & Microsoft.VisualBasic.ControlChars.CrLf & "Veuillez selectionner le tronçon aboutissant .", "Impossible", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    Exit Sub
                End If

                'creation de la liste des troncons et de l'arbre unique

                'selection des associations unique pour l'arbre

                lt.Clear()
                lt2.Clear()
                Dim item As DataRow

                i = 0
                a = 1
                row = lt.NewRow()
                row("id") = st
                row("troncon") = Me.ComboBox2.Text
                lt.Rows.Add(row)

                Do While a > 0
                    'pour chaque trc dans troncons_assoc = st
                    Me.Lst_assoc_par_trcTableAdapter.Fill(Me.MydbDataSet.lst_assoc_par_trc, CType(lt.Rows(i).Item(0), Integer?), st, fn)

                    For Each item In Me.MydbDataSet.lst_assoc_par_trc
                        If item(6).ToString = Me.IdsegregationsTextBox.Text Or item(6).ToString = "0" Then

                            If 0 = dataSet.Tables("troncons_tri").Select("ID = '" & item(0).ToString & "'").Count() Then
                                row = lt2.NewRow()
                                row("id") = item(0).ToString
                                row("id_troncon") = item(1).ToString
                                row("id_troncon2") = item(2).ToString
                                row("longueur") = CType(item(8).ToString, Double?)
                                lt2.Rows.Add(row)
                                If 0 = dataSet.Tables("troncons_seg2").Select("ID = '" & item(2).ToString & "'").Count() Then
                                    row = lt.NewRow()
                                    row("id") = item(2).ToString
                                    row("troncon") = item(4).ToString
                                    lt.Rows.Add(row)
                                    a = a + 1
                                End If

                            End If

                        End If

                    Next

                    Me.Lst_assoc_par_trc2TableAdapter.Fill(Me.MydbDataSet.lst_assoc_par_trc2, CType(lt.Rows(i).Item(0), Integer?), st, fn)

                    For Each item In Me.MydbDataSet.lst_assoc_par_trc2
                        If item(6).ToString = Me.IdsegregationsTextBox.Text Or item(6).ToString = "0" Then

                            If dataSet.Tables("troncons_tri").Select("ID = '" & item(0).ToString & "'").Count() = 0 Then
                                row = lt2.NewRow()
                                row("id") = item(0).ToString
                                row("id_troncon") = item(1).ToString
                                row("id_troncon2") = item(2).ToString
                                row("longueur") = CInt(item(8).ToString)
                                lt2.Rows.Add(row)
                                If 0 = dataSet.Tables("troncons_seg2").Select("ID = '" & item(1).ToString & "'").Count() Then
                                    row = lt.NewRow()
                                    row("id") = item(1).ToString
                                    row("troncon") = item(4).ToString
                                    lt.Rows.Add(row)
                                    a = a + 1
                                End If

                            End If
                        End If
                    Next

                    i = i + 1
                    a = a - 1
                Loop

                If 0 = dataSet.Tables("troncons_seg2").Select("ID = '" & fn & "'").Count() Then

                    MessageBox.Show("Aucun parcours ne mene au tronçon demandé" _
                        & Microsoft.VisualBasic.ControlChars.CrLf & "" _
                        & Microsoft.VisualBasic.ControlChars.CrLf & "Veuillez choisir un autre tronçon ou creer un pont .", "Impossible", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    Exit Sub
                End If

                Me.graph = New Graph

                '//reset graph
                Me.graph.Reset()

                For Each item In lt.Rows

                    Dim te As Integer = CInt(item(0).ToString)
                    Me.graph.AddVertex(te.ToString)
                Next

                For Each item In lt2.Rows

                    Me.graph.AddEdge(item(2).ToString, item(1).ToString, CDbl(item(3).ToString))

                Next

                'Me.graph.Save("graph2")

                Dim starting = Me.graph.Verticies(st.ToString)
                Dim ending = Me.graph.Verticies(fn.ToString)

                Me.ShowResults(starting, ending)

            Case System.Windows.Forms.DialogResult.No

        End Select

    End Sub

    Private Sub ShowResults(ByVal start As Vertex, _
                    ByVal [end] As Vertex)

        Dim distance = graph.GetDistance(start, [end])
        Dim path = graph.GetPath(start, [end], False)

        '//show basic results
        MessageBox.Show(String.Format("De {0} à {1}{3}{3}Parcour : {2}{3}{3}Distance: {4}", _
                                      start.Key, [end].Key, path, Environment.NewLine, distance), _
                        "Dijkstra's", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Select Case MessageBox.Show("Voullez vous enregistrer le parcour.Etes vous sur ?", "enregistrement d'un parcour", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            Case System.Windows.Forms.DialogResult.Yes
                ' Me.ParcoursBindingSource.AddNew()
                Dim ref_parcours As String
                Dim prow As DataRow
                Dim drow As DataRow
                Dim dow As Date

                prow = Me.MydbDataSet.parcours.NewRow
                dow = Today
                'ref_parcours = CStr(Year(Today))
                ref_parcours = CStr(Month(Today))
                ref_parcours = ref_parcours & dow.Day()
                ref_parcours = ref_parcours & Hour(Now)
                ref_parcours = ref_parcours & Minute(Now)

                prow.Item(1) = st
                prow.Item(2) = fn
                prow.Item(3) = Today
                prow.Item(4) = "test"
                prow.Item(6) = ref_parcours

                Me.MydbDataSet.parcours.Rows.Add(prow)
                Me.ParcoursBindingSource.EndEdit()
                Me.ParcoursTableAdapter.Update(MydbDataSet)
                Me.ParcoursTableAdapter.Fill(Me.MydbDataSet.parcours)
                Me.ParcoursBindingSource.ResetBindings(False)
                Me.ParcoursBindingSource.Sort = "ref_parcour"
                Dim place As Integer = Me.ParcoursBindingSource.Find("ref_parcour", ref_parcours)
                Me.ParcoursBindingSource.Position = place

                ' Me.Parcours_detailBindingSource.AddNew()
                Dim strArr() As String
                Dim count As Integer
                path = path.Replace(">", "")
                path = path.Replace(" ", "")
                strArr = path.Split(CChar("-"))

                Dim rows As DataRowView
                rows = CType(Me.ParcoursBindingSource.Item(place), DataRowView)
                For count = 0 To strArr.Length - 1
                    '  MsgBox(strArr(count))
                    drow = MydbDataSet.parcours_detail.NewRow
                    drow.Item("parcours_idparcours") = rows(0).ToString
                    drow.Item("ordre") = count + 1
                    drow.Item("troncon") = strArr(count)
                    MydbDataSet.parcours_detail.Rows.Add(drow)
                Next

                Me.Parcours_detailBindingSource.EndEdit()
                Me.Parcours_detailTableAdapter.Update(MydbDataSet)
                Me.Parcours_detailTableAdapter.Fill(Me.MydbDataSet.parcours_detail)

            Case (System.Windows.Forms.DialogResult.No)

        End Select

    End Sub

    Private Sub IdparcoursTextBox_TextChanged(sender As System.Object, e As System.EventArgs) Handles IdparcoursTextBox.TextChanged
        Try
            Me.Cable_details_tronconTableAdapter.Fill(Me.MydbDataSet.cable_details_troncon, New System.Nullable(Of Integer)(CType(Me.IdparcoursTextBox.Text, Integer)))
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try
        Try
            Me.Parcour_detail_idTableAdapter.Fill(Me.MydbDataSet.parcour_detail_id, New System.Nullable(Of Integer)(CType(Me.IdparcoursTextBox.Text, Integer)))
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try
    End Sub

End Class