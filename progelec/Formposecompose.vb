Public Class Formposecompose
    Public valid As Boolean = False
    Public idequip As Integer

    Private Sub Formposecompose_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.equip_pose_article'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.Equip_pose_articleTableAdapter.Fill(Me.MydbDataSet.equip_pose_article)
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.equipements'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.EquipementsTableAdapter.Fill(Me.MydbDataSet.equipements)

        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.equipements_has_fournitures'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.Equipements_has_fournituresTableAdapter.Fill(Me.MydbDataSet.equipements_has_fournitures)

        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.fournitures'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.FournituresTableAdapter.Fill(Me.MydbDataSet.fournitures)
        Try
            Me.Lst_article_equipTableAdapter.Fill(Me.MydbDataSet.lst_article_equip, New System.Nullable(Of Integer)(CType(idequip, Integer)))
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try

        Me.EquipementsBindingSource.Position = Me.EquipementsBindingSource.Find("idequipement", idequip)
        Dim row As MydbDataSet.equipementsRow
        row = CType(CType(Me.EquipementsBindingSource.Current, DataRowView).Row, MydbDataSet.equipementsRow)
        Me.LabelX1.Text = Me.LabelX1.Text & " " & row.repere_equipement
    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        Dim roaw As MydbDataSet.equip_pose_articleRow
        Me.Equip_pose_articleBindingSource.AddNew()
        roaw = CType(CType(Me.Equip_pose_articleBindingSource.Current, DataRowView).Row, MydbDataSet.equip_pose_articleRow)
        roaw.idequip = idequip
        roaw.id_fourniture = CType(CType(Me.Lst_article_equipBindingSource.Current, DataRowView).Row, MydbDataSet.lst_article_equipRow).idfourniture
        roaw.qte_pose = CDec(Me.Quant_poseTextBox.Text)
        roaw.qui = FormMain.user.Nom_user
        roaw._date = Me.Date_poseDateTimePicker.Value
        roaw.EndEdit()
        Me.Equip_pose_articleBindingSource.EndEdit()
        Me.Equip_pose_articleTableAdapter.Update(Me.MydbDataSet.equip_pose_article)
        Me.Equip_pose_articleTableAdapter.Fill(Me.MydbDataSet.equip_pose_article)
        Me.Lst_article_equipTableAdapter.Fill(Me.MydbDataSet.lst_article_equip, New System.Nullable(Of Integer)(CType(idequip, Integer)))
        Me.Quant_poseTextBox.Text = ""
    End Sub

    Private Sub DataGridViewX1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewX1.CellClick
        Try
            Me.QuantTextBox.Text = CType(CType(Me.Lst_article_equipBindingSource.Current, DataRowView).Row, MydbDataSet.lst_article_equipRow).quant.ToString
            Me.LabelX2.Text = CType(CType(Me.Lst_article_equipBindingSource.Current, DataRowView).Row, MydbDataSet.lst_article_equipRow).designation.ToString
            Me.Quant_poseTextBox.Text = ""
        Catch ex As Exception

        End Try

    End Sub

    Private Sub ButtonX2_Click(sender As Object, e As EventArgs) Handles ButtonX2.Click
        Me.valid = True
        Me.Close()
    End Sub
End Class