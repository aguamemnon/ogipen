Imports System.Data
Module Mod_users
    Public Function check_user(ByVal username As String, Optional ByVal project_name As String = "") As Boolean
        check_user = False
        'verfi si user existe sur la base
        Dim progelecDataSet As New progelecDataSet
        Dim userbase As New BindingSource
        Dim useradapt As New progelecDataSetTableAdapters.usersTableAdapter
        useradapt.Fill(progelecDataSet.users)

        userbase.DataSource = progelecDataSet
        userbase.DataMember = "users"

        userbase.Filter = "identifiant ='" & username & "'"
        If userbase.Count > 0 Then
            check_profils(username, project_name)
            check_user = True
        Else
            check_user = False
        End If

        'verif si user à des droits
    End Function

    Public Function check_profils(ByVal username As String, Optional ByVal project_name As String = "", Optional ByVal ctrlprofil As String = "NULL") As Boolean
        check_profils = False
        Dim progelecDataSet As New progelecDataSet
        Dim userbase As New BindingSource
        Dim useradapt As New progelecDataSetTableAdapters.usersTableAdapter
        Dim projectbase As BindingSource = New BindingSource
        Dim projectadapt As New progelecDataSetTableAdapters.projetsTableAdapter
        Dim profilbase As BindingSource = New BindingSource
        Dim profiladapt As New progelecDataSetTableAdapters.profilsTableAdapter
        Dim assocprofilbase As BindingSource = New BindingSource
        Dim assocadapt As New progelecDataSetTableAdapters.assoc_profils_users_projetsTableAdapter

        userbase.DataSource = progelecDataSet
        userbase.DataMember = "users"

        projectbase.DataSource = progelecDataSet
        projectbase.DataMember = "projets"

        profilbase.DataSource = progelecDataSet
        profilbase.DataMember = "profils"

        assocprofilbase.DataSource = progelecDataSet
        assocprofilbase.DataMember = "assoc_profils_users_projets"

        useradapt.Fill(progelecDataSet.users)
        projectadapt.Fill(progelecDataSet.projets)
        profiladapt.Fill(progelecDataSet.profils)
        assocadapt.Fill(progelecDataSet.assoc_profils_users_projets)

        userbase.Filter = "identifiant ='" & username & "'"
        Dim row As progelecDataSet.usersRow
        row = CType(CType(userbase.Current, DataRowView).Row, progelecDataSet.usersRow)
        assocprofilbase.Filter = "users_id_user = '" & row.id_user & "'"
        projectbase.Filter = "nom = '" & project_name & "'"
        Dim row3 As progelecDataSet.projetsRow
        row3 = CType(CType(projectbase.Current, DataRowView).Row, progelecDataSet.projetsRow)

        assocprofilbase.Filter = "users_id_user = '" & row.id_user & "' and projets_id_projet = '" & row3.id_projet & "'"
        If assocprofilbase.Count > 0 Then
            Dim row2 As progelecDataSet.assoc_profils_users_projetsRow
            row2 = CType(CType(assocprofilbase.Current, DataRowView).Row, progelecDataSet.assoc_profils_users_projetsRow)
            Dim row4 As progelecDataSet.profilsRow
            profilbase.Position = profilbase.Find("id_profil", row2.profils_id_profil)
            row4 = CType(CType(profilbase.Current, DataRowView).Row, progelecDataSet.profilsRow)
            FormMain.user.profil = row4.nom
        Else
            FormMain.user.profil = "NULL"
        End If
        If ctrlprofil = FormMain.user.profil Then
            check_profils = True
        Else
            check_profils = False
        End If

    End Function

End Module