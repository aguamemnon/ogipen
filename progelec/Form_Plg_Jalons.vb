Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Rendering
Public Class Form_Plg_Jalons

    Private Sub Form_Plg_Jalons_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'MydbDataSet.plg_jalons_has_equipements' table. You can move, or remove it, as needed.
        Me.Plg_jalons_has_equipementsTableAdapter.Fill(Me.MydbDataSet.plg_jalons_has_equipements)
        'TODO: This line of code loads data into the 'MydbDataSet.plg_jalons_has_salles' table. You can move, or remove it, as needed.
        Me.Plg_jalons_has_sallesTableAdapter.Fill(Me.MydbDataSet.plg_jalons_has_salles)
        'TODO: This line of code loads data into the 'MydbDataSet.plg_jalons' table. You can move, or remove it, as needed.
        Me.Plg_jalonsTableAdapter.Fill(Me.MydbDataSet.plg_jalons)
        'TODO: This line of code loads data into the 'MydbDataSet.equipements' table. You can move, or remove it, as needed.
        Me.EquipementsTableAdapter.Fill(Me.MydbDataSet.equipements)
        'TODO: This line of code loads data into the 'MydbDataSet.salles' table. You can move, or remove it, as needed.
        Me.SallesTableAdapter.Fill(Me.MydbDataSet.salles)
        Try
            Me.Lst_salles_plgTableAdapter.Fill(Me.MydbDataSet.lst_salles_plg, CType(CType(Me.Plg_jalonsBindingSource.Current, DataRowView).Row, MydbDataSet.plg_jalonsRow).idPlg_Jalon)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Me.Plg_jalonsBindingSource.AddNew()
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Me.Plg_jalonsBindingSource.EndEdit()
        Me.Plg_jalonsTableAdapter.Update(Me.MydbDataSet.plg_jalons)
        Me.Plg_jalonsTableAdapter.Fill(Me.MydbDataSet.plg_jalons)
    End Sub

    Private Sub ButtonX3_Click(sender As System.Object, e As System.EventArgs) Handles ButtonX3.Click
        Try
            Me.Plg_jalons_has_sallesBindingSource.AddNew()
            Dim row As MydbDataSet.plg_jalons_has_sallesRow

            row = CType(CType(Me.Plg_jalons_has_sallesBindingSource.Current, DataRowView).Row, MydbDataSet.plg_jalons_has_sallesRow)
            row.Plg_Jalons_idPlg_Jalon = CType(CType(Me.Plg_jalonsBindingSource.Current, DataRowView).Row, MydbDataSet.plg_jalonsRow).idPlg_Jalon
            row.salles_idsalle = CType(CType(Me.SallesBindingSource.Current, DataRowView).Row, MydbDataSet.sallesRow).idsalle

            Me.Plg_jalons_has_sallesBindingSource.EndEdit()
            Me.Plg_jalons_has_sallesTableAdapter.Update(Me.MydbDataSet.plg_jalons_has_salles)

        Catch ex As MySql.Data.MySqlClient.MySqlException

            If ex.Message.Contains("Duplicate") Then
                Dim info As New TaskDialogInfo("Doublon", eTaskDialogIcon.Hand, "Enregistrement deja present", "La salle que vous voullez ajouter est deja presente dans le jalon", eTaskDialogButton.Ok, eTaskDialogBackgroundColor.Red)
                TaskDialog.Show(info)
            End If
        Finally

        End Try
        Me.Plg_jalons_has_sallesTableAdapter.Fill(Me.MydbDataSet.plg_jalons_has_salles)
        Me.Lst_salles_plgTableAdapter.Fill(Me.MydbDataSet.lst_salles_plg, CType(CType(Me.Plg_jalonsBindingSource.Current, DataRowView).Row, MydbDataSet.plg_jalonsRow).idPlg_Jalon)
    End Sub

    Private Sub ButtonX1_Click(sender As System.Object, e As System.EventArgs) Handles ButtonX1.Click
        Try
            Me.Plg_jalons_has_equipementsBindingSource.AddNew()
            Dim row As MydbDataSet.plg_jalons_has_equipementsRow
            row = CType(CType(Me.Plg_jalons_has_equipementsBindingSource.Current, DataRowView).Row, MydbDataSet.plg_jalons_has_equipementsRow)
            row.Plg_Jalons_idPlg_Jalon = CType(CType(Me.Plg_jalonsBindingSource.Current, DataRowView).Row, MydbDataSet.plg_jalonsRow).idPlg_Jalon
            row.equipements_idequipement = CType(CType(Me.EquipementsBindingSource.Current, DataRowView).Row, MydbDataSet.equipementsRow).idequipement

            Me.Plg_jalons_has_equipementsBindingSource.EndEdit()
            Me.Plg_jalons_has_equipementsTableAdapter.Update(Me.MydbDataSet.plg_jalons_has_equipements)
            'Me.Plg_jalons_has_sallesTableAdapter.Fill(Me.MydbDataSet.plg_jalons_has_salles)

        Catch ex As MySql.Data.MySqlClient.MySqlException

            If ex.Message.Contains("Duplicate") Then
                Dim info As New TaskDialogInfo("Doublon", eTaskDialogIcon.Hand, "Enregistrement deja present", "L'equipement que vous voullez ajouter est deja presente dans le jalon", eTaskDialogButton.Ok, eTaskDialogBackgroundColor.Red)
                TaskDialog.Show(info)
            End If
        Finally

        End Try
        Me.Plg_jalons_has_equipementsTableAdapter.Fill(Me.MydbDataSet.plg_jalons_has_equipements)
        Me.Lst_equipement_PlgTableAdapter.Fill(Me.MydbDataSet.lst_equipement_plg, CType(CType(Me.Plg_jalonsBindingSource.Current, DataRowView).Row, MydbDataSet.plg_jalonsRow).idPlg_Jalon)
    End Sub

    Private Sub ButtonX2_Click(sender As System.Object, e As System.EventArgs) Handles ButtonX2.Click

    End Sub

    Private Sub ButtonX4_Click(sender As System.Object, e As System.EventArgs) Handles ButtonX4.Click

    End Sub

    Private Sub Plg_jalonsDataGridViewX_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Plg_jalonsDataGridViewX.CellClick
        Me.Lst_salles_plgTableAdapter.Fill(Me.MydbDataSet.lst_salles_plg, CType(CType(Me.Plg_jalonsBindingSource.Current, DataRowView).Row, MydbDataSet.plg_jalonsRow).idPlg_Jalon)
        Me.Lst_equipement_PlgTableAdapter.Fill(Me.MydbDataSet.lst_equipement_plg, CType(CType(Me.Plg_jalonsBindingSource.Current, DataRowView).Row, MydbDataSet.plg_jalonsRow).idPlg_Jalon)
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Dim info As New TaskDialogInfo("Suppression", eTaskDialogIcon.Hand, "Suppression Jalon", "La suppression du jalon peut impacter les plannings ''Fonction en cours de codage'' ", eTaskDialogButton.Ok Or eTaskDialogButton.Cancel, eTaskDialogBackgroundColor.Red)
        Dim result As eTaskDialogResult = TaskDialog.Show(info)
        Select Case result

            Case eTaskDialogResult.Cancel
                Exit Sub

        End Select

        Me.Plg_jalonsBindingSource.RemoveCurrent()
    End Sub
End Class