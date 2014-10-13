Public Class FormDefBesoins

    Private Sub FormDefBesoins_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.lst_besoin_cables_global'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.Lst_besoin_cables_globalTableAdapter.Fill(Me.MydbDataSet.lst_besoin_cables_global)
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.lst_besoin_global2'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.Lst_besoin_global2TableAdapter.Fill(Me.MydbDataSet.lst_besoin_global2)
        'TODO: This line of code loads data into the 'MydbDataSet.Lst_besoin_global' table. You can move, or remove it, as needed.
        Me.Lst_besoin_globalTableAdapter.Fill(Me.MydbDataSet.lst_besoin_global)
        'TODO: This line of code loads data into the 'MydbDataSet.lst_besoin_cables' table. You can move, or remove it, as needed.
        Me.Lst_besoin_cablesTableAdapter.Fill(Me.MydbDataSet.lst_besoin_cables)
        'TODO: This line of code loads data into the 'MydbDataSet.lst_besoin_select' table. You can move, or remove it, as needed.
        Me.Lst_besoin_selectTableAdapter.Fill(Me.MydbDataSet.lst_besoin_select)
        'TODO: This line of code loads data into the 'MydbDataSet.Lst_besoin_inconu' table. You can move, or remove it, as needed.
        Me.Lst_besoin_inconuTableAdapter.Fill(Me.MydbDataSet.lst_besoin_inconu)

    End Sub
End Class