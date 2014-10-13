Imports DevComponents.DotNetBar.SuperGrid
Public Class FormLstEquipement

    Private Sub FormLstEquipement_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.lst_equipements'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.Lst_equipementsTableAdapter.Fill(Me.MydbDataSet.lst_equipements)
        Me.Lst_equipementsTableAdapter.Connection.Close()
    End Sub

    Private Sub SuperGridControl_RowDoubleClick(sender As System.Object, e As DevComponents.DotNetBar.SuperGrid.GridRowDoubleClickEventArgs) Handles SuperGridControl.RowDoubleClick
        Dim grow As GridRow

        Dim irow As Integer
        Dim crow As DataRowView

        Dim FormEquipement As FormEquipement
        FormEquipement = New FormEquipement
        FormEquipement.MdiParent = Me.ParentForm
        FormEquipement.WindowState = FormWindowState.Maximized
        FormEquipement.mode = False
        Dim row As MydbDataSet.lst_equipementsRow
        row = CType(CType(Me.Lst_equipementsBindingSource.Current, DataRowView).Row, MydbDataSet.lst_equipementsRow)

        'grow = CType(e.GridRow, GridRow)
        'irow = Me.Lst_equipementsBindingSource.Find("repere equipement", grow.Cells(0).Value.ToString)

        'Me.Lst_equipementsBindingSource.Position = irow
        'crow = CType(Me.Lst_equipementsBindingSource.Item(irow), DataRowView)

        FormEquipement.value2 = row.idequipement 'crow.Item(0).ToString

        FormEquipement.Show()
    End Sub

    Private Sub ButtonX1_Click(sender As System.Object, e As System.EventArgs) Handles ButtonX1.Click
        Me.Lst_equipementsTableAdapter.Fill(Me.MydbDataSet.lst_equipements)
        Me.Lst_equipementsTableAdapter.Connection.Close()
    End Sub
End Class