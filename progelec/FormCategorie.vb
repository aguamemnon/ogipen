Public Class FormCategorie

    Private Sub CategoriesBindingNavigatorSaveItem_Click(sender As System.Object, e As System.EventArgs) Handles CategoriesBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.CategoriesBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.MydbDataSet)

    End Sub

    Private Sub FormCategorie_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.categories'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.CategoriesTableAdapter.Fill(Me.MydbDataSet.categories)

    End Sub
End Class