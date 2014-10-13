Public Class FormAdministration

    Private Sub FormAdministration_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: cette ligne de code charge les données dans la table 'ProgelecDataSet.assoc_profils_users_projets'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.Assoc_profils_users_projetsTableAdapter.Fill(Me.ProgelecDataSet.assoc_profils_users_projets)
        'TODO: cette ligne de code charge les données dans la table 'ProgelecDataSet.projets'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.ProjetsTableAdapter.Fill(Me.ProgelecDataSet.projets)
        'TODO: cette ligne de code charge les données dans la table 'ProgelecDataSet.users'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.UsersTableAdapter.Fill(Me.ProgelecDataSet.users)
        'TODO: cette ligne de code charge les données dans la table 'ProgelecDataSet.lst_users'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.Lst_usersTableAdapter.Fill(Me.ProgelecDataSet.lst_users)
        'TODO: cette ligne de code charge les données dans la table 'ProgelecDataSet.profils'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.ProfilsTableAdapter.Fill(Me.ProgelecDataSet.profils)
        check_profils_init()

    End Sub
    Private Function check_profils_init() As Boolean
        If Me.ProfilsBindingSource.Count = 0 Then

            Me.ProfilsBindingSource.AddNew()
            Dim row As progelecDataSet.profilsRow
            row = CType(CType(ProfilsBindingSource.Current, DataRowView).Row, progelecDataSet.profilsRow)

            'Profils admin
            row.nom = "Admin"
            row.designation = "administration globale"
            'Me.ProfilsBindingSource.EndEdit()
            'Me.ProfilsTableAdapter.Update(ProgelecDataSet.profils)
            'Me.ProfilsTableAdapter.Fill(ProgelecDataSet.profils)
            Me.ProfilsBindingSource.AddNew()
            'profils etude
            row = CType(CType(ProfilsBindingSource.Current, DataRowView).Row, progelecDataSet.profilsRow)
            row.nom = "Etude"
            row.designation = "Edition est consult"
            'Me.ProfilsBindingSource.EndEdit()
            ' Me.ProfilsTableAdapter.Update(ProgelecDataSet.profils)
            'Me.ProfilsTableAdapter.Fill(ProgelecDataSet.profils)
            Me.ProfilsBindingSource.AddNew()
            row = CType(CType(ProfilsBindingSource.Current, DataRowView).Row, progelecDataSet.profilsRow)
            'profils chantier
            row.nom = "Chantier"
            row.designation = "Edition est consultan"
            'profil consultation
            Me.ProfilsBindingSource.EndEdit()

            Me.ProfilsTableAdapter.Update(ProgelecDataSet.profils)
            Me.ProfilsTableAdapter.Fill(ProgelecDataSet.profils)

        End If

    End Function

    Private Sub ButtonX3_Click(sender As Object, e As EventArgs) Handles ButtonX3.Click
        Assoc_profils_users_projetsBindingSource.AddNew()
        Dim row As progelecDataSet.assoc_profils_users_projetsRow
        row = CType(CType(Assoc_profils_users_projetsBindingSource.Current, DataRowView).Row, progelecDataSet.assoc_profils_users_projetsRow)
        Dim row2 As progelecDataSet.projetsRow
        row2 = CType(CType(ProjetsBindingSource.Current, DataRowView).Row, progelecDataSet.projetsRow)
        Dim row3 As progelecDataSet.profilsRow
        row3 = CType(CType(ProfilsBindingSource.Current, DataRowView).Row, progelecDataSet.profilsRow)
        Dim row4 As progelecDataSet.usersRow

        row4 = CType(CType(UsersBindingSource.Current, DataRowView).Row, progelecDataSet.usersRow)

        row.projets_id_projet = row2.id_projet
        row.profils_id_profil = row3.id_profil
        row.users_id_user = row4.id_user

        Assoc_profils_users_projetsBindingSource.EndEdit()
        Assoc_profils_users_projetsTableAdapter.Update(ProgelecDataSet.assoc_profils_users_projets)
        Assoc_profils_users_projetsTableAdapter.Fill(ProgelecDataSet.assoc_profils_users_projets)
    End Sub
End Class