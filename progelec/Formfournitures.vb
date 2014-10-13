Public Class FormFournitures
    Public Idtrc As Integer
    Private Sub FournisseursBindingNavigatorSaveItem_Click(sender As System.Object, e As System.EventArgs)
        Me.Validate()
        Me.FournisseursBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.MydbDataSet)

    End Sub

    Private Sub Form_fournitures_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'MydbDataSet.troncons_fournitures' table. You can move, or remove it, as needed.
        Me.Troncons_fournituresTableAdapter.Fill(Me.MydbDataSet.troncons_fournitures)
        'TODO: This line of code loads data into the 'MydbDataSet.fournitures' table. You can move, or remove it, as needed.
        Me.FournituresTableAdapter.Fill(Me.MydbDataSet.fournitures)
        'TODO: This line of code loads data into the 'MydbDataSet.fournisseurs' table. You can move, or remove it, as needed.
        Me.FournisseursTableAdapter.Fill(Me.MydbDataSet.fournisseurs)

        Try
            Me.Lst_fournitures_trcTableAdapter.Fill(Me.MydbDataSet.lst_fournitures_trc, New System.Nullable(Of Integer)(Idtrc))
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub ButtonX1_Click(sender As System.Object, e As System.EventArgs) Handles ButtonX1.Click

        Dim rows As MydbDataSet.troncons_fournituresRow
        Dim row_four As MydbDataSet.fournituresRow

        row_four = CType(CType(Me.FournituresBindingSource.Current, DataRowView).Row, MydbDataSet.fournituresRow)
        Dim ctrl As Integer = Me.Lst_fournitures_trcBindingSource.Find("fourniture", row_four.idfourniture)
        If ctrl > -1 Then
            For Each rows In MydbDataSet.troncons_fournitures

                If rows.troncon = Idtrc And rows.fourniture = row_four.idfourniture Then
                    rows.Quant += CInt(Me.TextBoxX1.Text)

                    rows.AcceptChanges()
                End If

            Next
            Me.Troncons_fournituresBindingSource.EndEdit()
            Me.Troncons_fournituresTableAdapter.Update(MydbDataSet.troncons_fournitures)
            Me.Lst_fournitures_trcTableAdapter.Fill(Me.MydbDataSet.lst_fournitures_trc, Idtrc)
            Me.Troncons_fournituresTableAdapter.Fill(MydbDataSet.troncons_fournitures)
        Else
            Me.Troncons_fournituresBindingSource.AddNew()
            Dim row_four2 As MydbDataSet.troncons_fournituresRow

            row_four2 = CType(CType(Me.Troncons_fournituresBindingSource.Current, DataRowView).Row, MydbDataSet.troncons_fournituresRow)
            row_four2.troncon = Idtrc
            row_four2.Quant = CInt(Me.TextBoxX1.Text)
            row_four2.fourniture = row_four.idfourniture
            ' row_four2.AcceptChanges()
            Me.Troncons_fournituresBindingSource.EndEdit()
            Me.Troncons_fournituresTableAdapter.Update(MydbDataSet.troncons_fournitures)
            Me.Troncons_fournituresTableAdapter.Fill(MydbDataSet.troncons_fournitures)
            Me.Lst_fournitures_trcTableAdapter.Fill(Me.MydbDataSet.lst_fournitures_trc, Idtrc)
        End If

    End Sub

    Private Sub ButtonX2_Click(sender As System.Object, e As System.EventArgs) Handles ButtonX2.Click
        Dim row_four As MydbDataSet.lst_fournitures_trcRow

        row_four = CType(CType(Me.Lst_fournitures_trcBindingSource.Current, DataRowView).Row, MydbDataSet.lst_fournitures_trcRow)
        Me.Troncons_fournituresBindingSource.RemoveAt(Me.Troncons_fournituresBindingSource.Find("idtroncons_fourniture", row_four.idtroncons_fourniture))
        Me.Troncons_fournituresBindingSource.EndEdit()
        Me.Troncons_fournituresTableAdapter.Update(MydbDataSet.troncons_fournitures)
        Me.Troncons_fournituresTableAdapter.Fill(MydbDataSet.troncons_fournitures)
        Me.Lst_fournitures_trcTableAdapter.Fill(Me.MydbDataSet.lst_fournitures_trc, Idtrc)
    End Sub

    Private Sub ButtonX3_Click(sender As System.Object, e As System.EventArgs) Handles ButtonX3.Click
        Me.Close()

    End Sub
End Class