Public Class FormRapportProjet

    Dim ds As DataSet
    Dim Table As DataTable
    Private Sub FormRapportProjet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.courbe_avancement'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.Courbe_avancementTableAdapter.Fill(Me.MydbDataSet.courbe_avancement)
        Me.DateTimeInput1.Value = CDate("01/01/2013")
        Me.DateTimeInput2.Value = CDate("31/12/2013")
        Transfig()
        Me.DataGridViewX1.DataSource = ds.Tables("FLIP")

    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        If Me.Courbe_avancementBindingSource.Count > 0 Then

            For Each c In Courbe_avancementBindingSource
                Dim cc As MydbDataSet.courbe_avancementRow = CType(CType(c, DataRowView).Row, MydbDataSet.courbe_avancementRow)
                cc.Delete()

            Next
            Me.Validate()
            Me.Courbe_avancementBindingSource.EndEdit()
            Me.TableAdapterManager.UpdateAll(Me.MydbDataSet)
            Me.Courbe_avancementTableAdapter.Fill(Me.MydbDataSet.courbe_avancement)
        Else
            '            DateTime dateactuelle = DateTime.Now;
            'DateTime dateentrée = new DateTime(2011, 10, 8);
            'TimeSpan ts = dateactuelle - dateentrée;
            '            Console.WriteLine(ts.TotalDays / 7)
            Dim datestart As Date
            datestart = Me.DateTimeInput1.Value
            Dim nbsemaine As TimeSpan = Me.DateTimeInput2.Value - Me.DateTimeInput1.Value
            Dim i As Integer

            Dim nrow As MydbDataSet.courbe_avancementRow

            Do While i < (nbsemaine.TotalDays / 7)
                i += 1
                Me.Courbe_avancementBindingSource.AddNew()
                nrow = CType(CType(Courbe_avancementBindingSource.Current, DataRowView).Row, MydbDataSet.courbe_avancementRow)
                nrow._date = datestart.AddDays(7 * i)
                nrow.Valeur = 0
                Me.Courbe_avancementBindingSource.EndEdit()
                Me.TableAdapterManager.UpdateAll(Me.MydbDataSet)
                Me.Courbe_avancementTableAdapter.Fill(Me.MydbDataSet.courbe_avancement)
            Loop

        End If
        Me.Courbe_avancementTableAdapter.Fill(Me.MydbDataSet.courbe_avancement)
        Transfig()
    End Sub
    Public Sub Transfig()
        ds = New DataSet

        Table = New DataTable()
        Table.TableName = "FLIP"
        Table.Columns.Add("Detail")
        For Each row In Courbe_avancementBindingSource
            Dim drow As MydbDataSet.courbe_avancementRow
            drow = CType(CType(row, DataRowView).Row, MydbDataSet.courbe_avancementRow)
            Table.Columns.Add(drow._date.ToString())
        Next
        Dim i = 1
        Table.Rows.Add()
        Table.Rows.Add()
        For Each row In Courbe_avancementBindingSource
            Dim drow As MydbDataSet.courbe_avancementRow
            drow = CType(CType(row, DataRowView).Row, MydbDataSet.courbe_avancementRow)
            Table.Rows(0).Item(i) = drow.id
            Table.Rows(1).Item(i) = drow.Valeur
            i += 1
        Next
        ds.Tables.Add(Table)
    End Sub
End Class