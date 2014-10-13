Public Class FormGestUsers

    Private Sub UsersBindingNavigatorSaveItem_Click(sender As System.Object, e As System.EventArgs)
        Me.Validate()
        Me.UsersBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.ProgelecDataSet)

    End Sub

    Private Sub FormGestUsers_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'ProgelecDataSet.profils' table. You can move, or remove it, as needed.
        Me.ProfilsTableAdapter.Fill(Me.ProgelecDataSet.profils)
        'TODO: This line of code loads data into the 'ProgelecDataSet.projets' table. You can move, or remove it, as needed.
        Me.ProjetsTableAdapter.Fill(Me.ProgelecDataSet.projets)
        'TODO: This line of code loads data into the 'ProgelecDataSet.users' table. You can move, or remove it, as needed.
        Me.UsersTableAdapter.Fill(Me.ProgelecDataSet.users)

    End Sub

    Private Sub ButtonX1_Click(sender As System.Object, e As System.EventArgs) Handles ButtonX1.Click
        Me.Close()
    End Sub
End Class