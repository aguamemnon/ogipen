Public Class FormFourni_equip
    Public Idtrc As Integer
    Private Sub FournisseursBindingNavigatorSaveItem_Click(sender As System.Object, e As System.EventArgs)
        Me.Validate()
        Me.FournisseursBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.MydbDataSet)

    End Sub

    Private Sub Form_fournitures_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'MydbDataSet.equipements_has_fournitures' table. You can move, or remove it, as needed.
        Me.Equipements_has_fournituresTableAdapter.Fill(Me.MydbDataSet.equipements_has_fournitures)

        'TODO: This line of code loads data into the 'MydbDataSet.fournitures' table. You can move, or remove it, as needed.
        Me.FournituresTableAdapter.Fill(Me.MydbDataSet.fournitures)
        Me.FournituresBindingSource.Filter = "liste_equipement = true"
        'TODO: This line of code loads data into the 'MydbDataSet.fournisseurs' table. You can move, or remove it, as needed.
        Me.FournisseursTableAdapter.Fill(Me.MydbDataSet.fournisseurs)

        Try
            Me.Lst_equip_fournitureTableAdapter.Fill(Me.MydbDataSet.lst_equip_fourniture, New System.Nullable(Of Integer)(Idtrc))
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub ButtonX1_Click(sender As System.Object, e As System.EventArgs) Handles ButtonX1.Click

        Dim rows As MydbDataSet.equipements_has_fournituresRow
        Dim row_four As MydbDataSet.fournituresRow

        row_four = CType(CType(Me.FournituresBindingSource.Current, DataRowView).Row, MydbDataSet.fournituresRow)
        Dim ctrl As Integer = Me.Lst_equip_fournitureBindingSource.Find("fournitures_idfourniture", row_four.idfourniture)
        If ctrl > -1 Then
            For Each rows In MydbDataSet.equipements_has_fournitures

                If rows.equipements_idequipement = Idtrc And rows.fournitures_idfourniture = row_four.idfourniture Then
                    rows.quant = CDec(Me.TextBoxX1.Text) + rows.quant

                    rows.EndEdit()
                End If

            Next
            Me.Equipements_has_fournituresBindingSource.EndEdit()
            Me.Equipements_has_fournituresTableAdapter.Update(MydbDataSet.equipements_has_fournitures)
            Me.Lst_equip_fournitureTableAdapter.Fill(Me.MydbDataSet.lst_equip_fourniture, Idtrc)
            Me.Equipements_has_fournituresTableAdapter.Fill(MydbDataSet.equipements_has_fournitures)
        Else
            Me.Equipements_has_fournituresBindingSource.AddNew()
            Dim row_four2 As MydbDataSet.equipements_has_fournituresRow

            row_four2 = CType(CType(Me.Equipements_has_fournituresBindingSource.Current, DataRowView).Row, MydbDataSet.equipements_has_fournituresRow)
            row_four2.equipements_idequipement = Idtrc
            row_four2.quant = CInt(Me.TextBoxX1.Text)
            row_four2.fournitures_idfourniture = row_four.idfourniture
            ' row_four2.AcceptChanges()
            Me.Equipements_has_fournituresBindingSource.EndEdit()
            Me.Equipements_has_fournituresTableAdapter.Update(MydbDataSet.equipements_has_fournitures)
            Me.Equipements_has_fournituresTableAdapter.Fill(MydbDataSet.equipements_has_fournitures)
            Me.Lst_equip_fournitureTableAdapter.Fill(Me.MydbDataSet.lst_equip_fourniture, Idtrc)
        End If

    End Sub

    Private Sub ButtonX2_Click(sender As System.Object, e As System.EventArgs) Handles ButtonX2.Click
        Dim row_four As MydbDataSet.lst_equip_fournitureRow

        row_four = CType(CType(Me.Lst_equip_fournitureBindingSource.Current, DataRowView).Row, MydbDataSet.lst_equip_fournitureRow)
        Me.Equipements_has_fournituresBindingSource.RemoveAt(Me.Equipements_has_fournituresBindingSource.Find("fournitures_idfourniture", row_four.fournitures_idfourniture))
        Me.Equipements_has_fournituresBindingSource.EndEdit()
        Me.Equipements_has_fournituresTableAdapter.Update(MydbDataSet.equipements_has_fournitures)
        Me.Equipements_has_fournituresTableAdapter.Fill(MydbDataSet.equipements_has_fournitures)
        Me.Lst_equip_fournitureTableAdapter.Fill(Me.MydbDataSet.lst_equip_fourniture, Idtrc)
    End Sub

    Private Sub ButtonX3_Click(sender As System.Object, e As System.EventArgs) Handles ButtonX3.Click
        Me.Close()

    End Sub

End Class