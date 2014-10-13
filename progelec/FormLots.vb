Public Class FormLots

    Private Sub LotsBindingNavigatorSaveItem_Click(sender As System.Object, e As System.EventArgs) Handles LotsBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.LotsBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.MydbDataSet)

    End Sub

    Private Sub Lots_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.lots'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.LotsTableAdapter.Fill(Me.MydbDataSet.lots)

    End Sub
End Class