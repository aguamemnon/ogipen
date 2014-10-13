Imports DevComponents.DotNetBar

Public Class FormCtrlEtudes
    Dim result As eTaskDialogResult
    Sub Actualisation()
        'Throw New NotImplementedException
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.equipements'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.EquipementsTableAdapter.Fill(Me.MydbDataSet.equipements)
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.lst_equip_sans_alim'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.Lst_equip_sans_alimTableAdapter.Fill(Me.MydbDataSet.lst_equip_sans_alim)
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.cables'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.CablesTableAdapter.Fill(Me.MydbDataSet.cables)
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.cable_non_real'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.Cable_non_realTableAdapter.Fill(Me.MydbDataSet.cable_non_real)

    End Sub

    Private Sub FormCtrlEtudes_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Actualisation()
        Affichage()
    End Sub

    Public Sub Affichage()

        TextBoxItem1.Text = EquipementsBindingSource.Count.ToString()

        TextBoxItem2.Text = Lst_equip_sans_alimBindingSource.Count.ToString()
        TextBoxItem3.Text = CablesBindingSource.Count.ToString
        TextBoxItem4.Text = Cable_non_realBindingSource.Count.ToString

    End Sub

    Private Sub ButtonX2_Click(sender As Object, e As EventArgs) Handles ButtonX2.Click
        Dim row As MydbDataSet.lst_equip_sans_alimRow
        row = CType(CType(Me.Lst_equip_sans_alimBindingSource.Current, DataRowView).Row, MydbDataSet.lst_equip_sans_alimRow)
        Dim info As New TaskDialogInfo("Suppression", eTaskDialogIcon.Delete, "Suppression de l'equipement :" & row.repere_equipement, "Vous allez supprimer un equipement definitivement étes vous sur ?", eTaskDialogButton.Ok Or eTaskDialogButton.Cancel, eTaskDialogBackgroundColor.Red)

        result = TaskDialog.Show(info)

        Select Case result
            Case eTaskDialogResult.Ok
                Me.EquipementsBindingSource.Position = Me.EquipementsBindingSource.Find("idequipement", row.idequipement)
                Me.EquipementsBindingSource.RemoveCurrent()
                Me.EquipementsTableAdapter.Update(MydbDataSet.equipements)
                Me.EquipementsTableAdapter.Fill(MydbDataSet.equipements)
                Me.Lst_equip_sans_alimTableAdapter.Fill(MydbDataSet.lst_equip_sans_alim)

            Case eTaskDialogResult.Cancel

        End Select

    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click

        Dim FormEquipement As FormEquipement
        FormEquipement = New FormEquipement
        FormEquipement.MdiParent = Me.ParentForm
        FormEquipement.WindowState = FormWindowState.Maximized
        FormEquipement.mode = False
        Dim row As MydbDataSet.lst_equip_sans_alimRow
        row = CType(CType(Me.Lst_equip_sans_alimBindingSource.Current, DataRowView).Row, MydbDataSet.lst_equip_sans_alimRow)

        FormEquipement.value2 = row.idequipement

        FormEquipement.Show()

    End Sub

    Private Sub ButtonX4_Click(sender As Object, e As EventArgs) Handles ButtonX4.Click
        Dim FormCable As New FormCable
        FormCable.value = CStr(CType(CType(Cable_non_realBindingSource.Current, DataRowView).Row, MydbDataSet.cable_non_realRow).idcable)
        FormCable.MdiParent = Me.ParentForm
        FormCable.WindowState = FormWindowState.Maximized
        FormCable.mode = False
        FormCable.Show()
    End Sub
End Class