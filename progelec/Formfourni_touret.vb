Public Class FormFourni_touret
    Public Idtrc As Integer
    Private Sub FournisseursBindingNavigatorSaveItem_Click(sender As System.Object, e As System.EventArgs)
        Me.Validate()
        Me.FournisseursBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.MydbDataSet)

    End Sub

    Private Sub Form_fournitures_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'MydbDataSet.tourets_has_fournitures' table. You can move, or remove it, as needed.
        Me.Tourets_has_fournituresTableAdapter.Fill(Me.MydbDataSet.tourets_has_fournitures)
        'TODO: This line of code loads data into the 'MydbDataSet.equipements_has_fournitures' table. You can move, or remove it, as needed.

        'TODO: This line of code loads data into the 'MydbDataSet.fournitures' table. You can move, or remove it, as needed.
        Me.FournituresTableAdapter.Fill(Me.MydbDataSet.fournitures)
        Me.FournituresBindingSource.Filter = "liste_tourets = true"
        'TODO: This line of code loads data into the 'MydbDataSet.fournisseurs' table. You can move, or remove it, as needed.
        Me.FournisseursTableAdapter.Fill(Me.MydbDataSet.fournisseurs)

        Try
            'Me.Lst_equip_fournitureTableAdapter.Fill(Me.MydbDataSet.lst_equip_fourniture, New System.Nullable(Of Integer)(Idtrc))
            Me.Lst_fourniture_touretTableAdapter.Fill(Me.MydbDataSet.lst_fourniture_touret, New System.Nullable(Of Integer)(CType(Idtrc, Integer)))
            If Me.Lst_fourniture_touretBindingSource.Count > 0 Then
                Me.ButtonX1.Enabled = False
            End If
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub ButtonX1_Click(sender As System.Object, e As System.EventArgs) Handles ButtonX1.Click

        Dim rows As MydbDataSet.tourets_has_fournituresRow
        Dim row_four As MydbDataSet.fournituresRow
        Me.Tourets_has_fournituresBindingSource.Filter = "tourets_idtouret=" & Idtrc
        If Me.Tourets_has_fournituresBindingSource.Count > 0 Then
            MsgBox("touret deja affecté")
        Else
            Me.Tourets_has_fournituresBindingSource.RemoveFilter()
            row_four = CType(CType(Me.FournituresBindingSource.Current, DataRowView).Row, MydbDataSet.fournituresRow)
            'Dim ctrl As Integer = Me.Lst_equip_fournitureBindingSource.Find("fournitures_idfourniture", row_four.idfourniture)
            Dim ctrl As Integer = Me.Lst_fourniture_touretBindingSource.Find("fournitures_idfourniture", row_four.idfourniture)
            Me.Tourets_has_fournituresBindingSource.Filter = "fournitures_idfourniture=" & row_four.idfourniture
            If Me.Tourets_has_fournituresBindingSource.Count > 0 Then
                MsgBox("FournituresBindingSource deja afeté merci de coriger")
            Else
                Me.Tourets_has_fournituresBindingSource.RemoveFilter()
                If ctrl > -1 Then
                    For Each rows In MydbDataSet.tourets_has_fournitures

                        If rows.tourets_idtouret = Idtrc And rows.fournitures_idfourniture = row_four.idfourniture Then

                            rows.EndEdit()
                        End If

                    Next
                    'Me.Equipements_has_fournituresBindingSource.EndEdit()
                    'Me.Equipements_has_fournituresTableAdapter.Update(MydbDataSet.equipements_has_fournitures)
                    'Me.Lst_equip_fournitureTableAdapter.Fill(Me.MydbDataSet.lst_equip_fourniture, Idtrc)
                    'Me.Equipements_has_fournituresTableAdapter.Fill(MydbDataSet.equipements_has_fournitures)
                Else
                    'Me.Equipements_has_fournituresBindingSource.AddNew()
                    Me.Tourets_has_fournituresBindingSource.AddNew()
                    Dim row_four2 As MydbDataSet.tourets_has_fournituresRow

                    row_four2 = CType(CType(Me.Tourets_has_fournituresBindingSource.Current, DataRowView).Row, MydbDataSet.tourets_has_fournituresRow)
                    row_four2.BeginEdit()
                    row_four2.tourets_idtouret = Idtrc

                    row_four2.fournitures_idfourniture = row_four.idfourniture
                    '  row_four2.AcceptChanges()
                    Me.Tourets_has_fournituresBindingSource.EndEdit()
                    Me.Tourets_has_fournituresTableAdapter.Update(MydbDataSet.tourets_has_fournitures)
                    Me.Tourets_has_fournituresTableAdapter.Fill(MydbDataSet.tourets_has_fournitures)
                    Me.Lst_fourniture_touretTableAdapter.Fill(Me.MydbDataSet.lst_fourniture_touret, Idtrc)
                End If
            End If

        End If

    End Sub

    Private Sub ButtonX2_Click(sender As System.Object, e As System.EventArgs) Handles ButtonX2.Click
        Dim row_four As MydbDataSet.lst_fourniture_touretRow
        If Me.Lst_fourniture_touretBindingSource.Count > 0 Then
            row_four = CType(CType(Me.Lst_fourniture_touretBindingSource.Current, DataRowView).Row, MydbDataSet.lst_fourniture_touretRow)
            Me.Tourets_has_fournituresBindingSource.RemoveAt(Me.Tourets_has_fournituresBindingSource.Find("fournitures_idfourniture", row_four.fournitures_idfourniture))
            Me.Tourets_has_fournituresBindingSource.EndEdit()
            Me.Tourets_has_fournituresTableAdapter.Update(MydbDataSet.tourets_has_fournitures)
            Me.Tourets_has_fournituresTableAdapter.Fill(MydbDataSet.tourets_has_fournitures)
            Me.Lst_fourniture_touretTableAdapter.Fill(Me.MydbDataSet.lst_fourniture_touret, Idtrc)
            Me.ButtonX1.Enabled = True
        Else

        End If

    End Sub

    Private Sub ButtonX3_Click(sender As System.Object, e As System.EventArgs) Handles ButtonX3.Click
        Me.Close()

    End Sub

End Class