Imports DevComponents.DotNetBar.SuperGrid
Public Class FormLstSalles

    Public dataSet As DataSet
    Dim column As DataColumn
    Dim row As DataRow
    Dim PrimaryKeyColumns(0) As DataColumn
    Dim lt6 As DataTable = New DataTable("salles")
    Dim lt7 As DataTable = New DataTable("troncons")
    Private Sub SallesBindingNavigatorSaveItem_Click(sender As System.Object, e As System.EventArgs)
        Me.Validate()
        Me.SallesBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.MydbDataSet)

    End Sub

    Private Sub FormLstSalles_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'MydbDataSet.lst_salles' table. You can move, or remove it, as needed.
        Me.Lst_sallesTableAdapter.Fill(Me.MydbDataSet.lst_salles)
        'TODO: This line of code loads data into the 'MydbDataSet.lst_salles' table. You can move, or remove it, as needed.
        Me.Lst_sallesTableAdapter.Fill(Me.MydbDataSet.lst_salles)
        'TODO: This line of code loads data into the 'MydbDataSet.salles' table. You can move, or remove it, as needed.
        Me.SallesTableAdapter.Fill(Me.MydbDataSet.salles)

        column = New DataColumn()
        column.DataType = System.Type.GetType("System.Int32")
        column.ColumnName = "id"
        column.AutoIncrement = False
        column.Caption = "ref_salle"
        column.ReadOnly = False
        column.Unique = False

        ' Add the column to the table.
        lt6.Columns.Add(column)

        column = New DataColumn()
        column.DataType = System.Type.GetType("System.String")
        column.ColumnName = "salle"
        column.AutoIncrement = False
        column.Caption = "salle"
        column.ReadOnly = False
        column.Unique = False

        ' Add the column to the table.
        lt6.Columns.Add(column)

        PrimaryKeyColumns(0) = lt6.Columns("id")
        lt6.PrimaryKey = PrimaryKeyColumns

        ' Instantiate the DataSet variable.
        dataSet = New DataSet()

        ' Add the new DataTable to the DataSet.
        dataSet.Tables.Add(lt6)
    End Sub

    Private Sub ButtonXGenerationDCC_Click(sender As System.Object, e As System.EventArgs) Handles ButtonXGenerationDCC.Click

        Dim grow As GridRow
        Dim dcc_salle As Double
        Dim irow As Integer
        Dim crow As DataRowView
        Dim a As Integer
        Dim drow As DataRow
        Dim coef As Integer

        For Each grow In Me.SuperGridControl.GetSelectedRows
            irow = Me.SallesBindingSource.Find("idsalle", grow.Cells(0).Value.ToString)
            Me.SallesBindingSource.Position = irow
            crow = CType(Me.SallesBindingSource.Item(irow), DataRowView)

            drow = lt6.NewRow
            drow("id") = crow.Item(0).ToString
            drow("salle") = crow.Item(1).ToString
            lt6.Rows.Add(drow)
        Next
        a = lt6.Rows.Count - 1

        Do While a > -1
            dcc_salle = 0
            Me.Lst_trc_salleTableAdapter.Fill(Me.MydbDataSet.lst_trc_salle, New System.Nullable(Of Integer)(CType(Me.lt6(a).Item(0).ToString, Integer)))

            '   Me.Cables_troncon_idTableAdapter.Fill(Me.MydbDataSet.cables_troncon_id, CType(lt4.Rows(a).Item(0), Integer?))

            For Each item In Me.MydbDataSet.lst_trc_salle

                Me.Cables_troncon_idTableAdapter.Fill(Me.MydbDataSet.cables_troncon_id, New System.Nullable(Of Integer)(CType(item.idtroncons, Integer)))
                If item.Types_troncons_idTypes_troncons = 1 Then
                    coef = 2
                Else
                    coef = 1
                End If
                For Each item2 In Me.MydbDataSet.cables_troncon_id
                    dcc_salle = dcc_salle + ((CDbl(item.longueur) / 1000 / coef) * CDbl(item2.charge_calorifique))
                Next

            Next
            Dim erows As DataRowView
            erows = CType(Me.SallesBindingSource.Item(Me.SallesBindingSource.Find("idsalle", lt6.Rows(a).Item(0).ToString)), DataRowView)
            erows.BeginEdit()
            erows("dcc") = Math.Round(dcc_salle)
            erows("qui") = FormMain.user.Nom_user
            erows("date") = DateTime.Today.ToString("g")
            erows.EndEdit()
            Me.SallesBindingSource.EndEdit()
            Me.SallesTableAdapter.Update(Me.MydbDataSet.salles)

            a = a - 1

        Loop

    End Sub

    Private Sub SuperGridControl_CellDoubleClick(sender As System.Object, e As DevComponents.DotNetBar.SuperGrid.GridCellDoubleClickEventArgs) Handles SuperGridControl.CellDoubleClick
        Dim id As Integer
        id = CType(CType(Lst_sallesBindingSource.Current, DataRowView).Row, MydbDataSet.lst_sallesRow).idsalle

        Dim FormSalle As FormSalle
        FormSalle = New FormSalle
        FormSalle.MdiParent = Me.ParentForm
        FormSalle.WindowState = FormWindowState.Maximized
        ' AddHandler Parent.EventFired2, AddressOf FormDsipoCheminements.actualisation
        FormSalle.ID = id
        FormSalle.Show()
    End Sub
    Public Sub actualisation()
        Me.Lst_sallesTableAdapter.Fill(Me.MydbDataSet.lst_salles)
        Me.SallesTableAdapter.Fill(Me.MydbDataSet.salles)
    End Sub
End Class