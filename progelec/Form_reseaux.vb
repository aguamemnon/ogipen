Public Class Form_reseaux

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        Me.Validate()
        Me.SegregationsBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.MydbDataSet)
        Me.Close()
    End Sub

    Private Sub Form_reseaux_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.segregations'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.SegregationsTableAdapter.Fill(Me.MydbDataSet.segregations)

    End Sub

    Private Sub ButtonX2_Click(sender As Object, e As EventArgs) Handles ButtonX2.Click
        Me.SegregationsBindingSource.RemoveCurrent()
        Me.SegregationsBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.MydbDataSet)
    End Sub
End Class