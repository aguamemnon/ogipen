Module action_module
    Public Sub action_creation(ByVal qui As String, ByVal quoi As String, ByVal table As String, ByVal type As Integer, Optional ByVal identifiant As Integer = 0)
        Dim mydb As MydbDataSet = New MydbDataSet
        Select Case table

            Case "cables"
                Dim action_cable As New BindingSource
                Dim action_cable_adap As New MydbDataSetTableAdapters.actions_cablesTableAdapter
                action_cable_adap.Fill(mydb.actions_cables)
                action_cable.DataSource = mydb
                action_cable.DataMember = "actions_cables"
                action_cable.AddNew()
                Dim rows As MydbDataSet.actions_cablesRow
                rows = CType(CType(action_cable.Current, DataRowView).Row, MydbDataSet.actions_cablesRow)
                rows.cables_idcable = identifiant
                rows.qui = qui
                rows.quoi = quoi
                rows.actions_types_idactions_types = type
                rows._date = Date.Today()
                action_cable.EndEdit()
                action_cable_adap.Update(mydb.actions_cables)
            Case "equipements"
                Dim action_equipement As New BindingSource
                Dim action_equipement_adap As New MydbDataSetTableAdapters.actions_equipementsTableAdapter
                action_equipement_adap.Fill(mydb.actions_equipements)
                action_equipement.DataSource = mydb
                action_equipement.DataMember = "actions_equipements"
                action_equipement.AddNew()
                Dim rows As MydbDataSet.actions_equipementsRow
                rows = CType(CType(action_equipement.Current, DataRowView).Row, MydbDataSet.actions_equipementsRow)
                rows.equipements_idequipement = identifiant
                rows.qui = qui
                rows.quoi = quoi
                rows._date = Date.Today()
                action_equipement.EndEdit()
                action_equipement_adap.Update(mydb.actions_equipements)
            Case "troncons"
                Dim action_troncon As New BindingSource
                Dim action_troncon_adap As New MydbDataSetTableAdapters.actions_tronconsTableAdapter
                action_troncon_adap.Fill(mydb.actions_troncons)
                action_troncon.DataSource = mydb
                action_troncon.DataMember = "actions_troncons"
                action_troncon.AddNew()
                Dim rows As MydbDataSet.actions_tronconsRow
                rows = CType(CType(action_troncon.Current, DataRowView).Row, MydbDataSet.actions_tronconsRow)
                rows.troncons_idtroncons = identifiant
                rows.qui = qui
                rows.quoi = quoi
                rows._date = Date.Today()
                action_troncon.EndEdit()
                action_troncon_adap.Update(mydb.actions_troncons)
            Case "departs"""
                Dim action_depart As New BindingSource
                Dim action_depart_adap As New MydbDataSetTableAdapters.actions_departsTableAdapter
                action_depart_adap.Fill(mydb.actions_departs)
                action_depart.DataSource = mydb
                action_depart.DataMember = "actions_departs"
                action_depart.AddNew()
                Dim rows As MydbDataSet.actions_departsRow
                rows = CType(CType(action_depart.Current, DataRowView).Row, MydbDataSet.actions_departsRow)
                rows.departs_iddepart = identifiant
                rows.qui = qui
                rows.quoi = quoi
                rows._date = Date.Today()
                action_depart.EndEdit()
                action_depart_adap.Update(mydb.actions_departs)
            Case "borniers"
                Dim action_bornier As New BindingSource
                Dim action_bornier_adap As New MydbDataSetTableAdapters.actions_borniersTableAdapter
                action_bornier_adap.Fill(mydb.actions_borniers)
                action_bornier.DataSource = mydb
                action_bornier.DataMember = "actions_borniers"
                action_bornier.AddNew()
                Dim rows As MydbDataSet.actions_borniersRow
                rows = CType(CType(action_bornier.Current, DataRowView).Row, MydbDataSet.actions_borniersRow)
                rows.borniers_idbornier = identifiant
                rows.qui = qui
                rows.quoi = quoi
                rows._date = Date.Today()
                action_bornier.EndEdit()
                action_bornier_adap.Update(mydb.actions_borniers)
            Case "divers"
                Dim action As New BindingSource
                Dim action_adap As New MydbDataSetTableAdapters.actions_diversTableAdapter
                action_adap.Fill(mydb.actions_divers)
                action.DataSource = mydb
                action.DataMember = "actions_divers"
                action.AddNew()
                Dim rows As MydbDataSet.actions_diversRow
                rows = CType(CType(action.Current, DataRowView).Row, MydbDataSet.actions_diversRow)
                rows.qui = qui
                rows.quoi = quoi
                rows._date = Date.Today()
                action.EndEdit()
                action_adap.Update(mydb.actions_divers)
        End Select

    End Sub

End Module