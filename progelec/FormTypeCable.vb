Public Class FormTypeCable

    Private Sub Types_cableBindingNavigatorSaveItem_Click(sender As System.Object, e As System.EventArgs)
        Me.Validate()
        Me.Types_cableBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.MydbDataSet)

    End Sub

    Private Sub FormTypeCable_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.types_cable'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.Types_cableTableAdapter.Fill(Me.MydbDataSet.types_cable)
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.types_cable'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.Types_cableTableAdapter.Fill(Me.MydbDataSet.types_cable)

    End Sub

    Private Sub Types_cableBindingNavigatorSaveItem_Click_1(sender As System.Object, e As System.EventArgs) Handles Types_cableBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.Types_cableBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.MydbDataSet)

    End Sub
End Class