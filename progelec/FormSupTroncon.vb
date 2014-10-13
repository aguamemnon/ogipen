Imports DevComponents.DotNetBar.SuperGrid
Public Class FormSupTroncon
    Dim select_trc As Integer

    Private Sub FormSupTroncon_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'MydbDataSet.parcours_detail' table. You can move, or remove it, as needed.
        Me.Parcours_detailTableAdapter.Fill(Me.MydbDataSet.parcours_detail)
        'TODO: This line of code loads data into the 'MydbDataSet.parcours' table. You can move, or remove it, as needed.
        Me.ParcoursTableAdapter.Fill(Me.MydbDataSet.parcours)
        'TODO: This line of code loads data into the 'MydbDataSet.troncons' table. You can move, or remove it, as needed.
        Me.TronconsTableAdapter.Fill(Me.MydbDataSet.troncons)
        'TODO: This line of code loads data into the 'MydbDataSet.troncons_assoc' table. You can move, or remove it, as needed.
        Me.Troncons_assocTableAdapter.Fill(Me.MydbDataSet.troncons_assoc)
        'TODO: This line of code loads data into the 'MydbDataSet.segregations' table. You can move, or remove it, as needed.
        Me.SegregationsTableAdapter.Fill(Me.MydbDataSet.segregations)
        'TODO: This line of code loads data into the 'MydbDataSet.types_troncons' table. You can move, or remove it, as needed.
        Me.Types_tronconsTableAdapter.Fill(Me.MydbDataSet.types_troncons)
        'TODO: This line of code loads data into the 'MydbDataSet.salles' table. You can move, or remove it, as needed.
        Me.SallesTableAdapter.Fill(Me.MydbDataSet.salles)

        'TODO: This line of code loads data into the 'MydbDataSet.types_troncons' table. You can move, or remove it, as needed.
        Me.Types_tronconsTableAdapter.Fill(Me.MydbDataSet.types_troncons)
        'TODO: This line of code loads data into the 'MydbDataSet.segregations' table. You can move, or remove it, as needed.
        Me.SegregationsTableAdapter.Fill(Me.MydbDataSet.segregations)
        'TODO: This line of code loads data into the 'MydbDataSet.salles' table. You can move, or remove it, as needed.
        Me.SallesTableAdapter.Fill(Me.MydbDataSet.salles)

    End Sub

    Private Sub SallesBindingNavigatorSaveItem_Click(sender As System.Object, e As System.EventArgs)
        Me.Validate()
        Me.SallesBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.MydbDataSet)

    End Sub

    'Me.Ctrl_troncons_supTableAdapter.Fill(Me.MydbDataSet.ctrl_troncons_sup, New System.Nullable(Of Integer)(CType(Set_trcToolStripTextBox.Text, Integer)))

    Private Sub ComboBoxEx2_SelectedValueChanged(sender As System.Object, e As System.EventArgs) Handles ComboBoxEx2.SelectedValueChanged, ComboBoxEx3.SelectedValueChanged, ComboBoxEx1.SelectedValueChanged
        If Not IsNothing(Me.ComboBoxEx1.SelectedValue) And Not IsNothing(Me.ComboBoxEx2.SelectedValue) And Not IsNothing(Me.ComboBoxEx2.SelectedValue) Then
            Me.Lst_troncons_supTableAdapter.Fill(Me.MydbDataSet.lst_troncons_sup, New System.Nullable(Of Integer)(CType(Me.ComboBoxEx1.SelectedValue, Integer)), New System.Nullable(Of Integer)(CType(Me.ComboBoxEx2.SelectedValue, Integer)), New System.Nullable(Of Integer)(CType(Me.ComboBoxEx3.SelectedValue, Integer)))
            Me.SuperGridControl1.DataBindings.Clear()
            Me.SuperGridControl1.PrimaryGrid.DataSource = Me.Lst_troncons_supBindingSource

        End If
    End Sub

    Private Sub SuperGridControl1_CellClick(sender As System.Object, e As DevComponents.DotNetBar.SuperGrid.GridCellClickEventArgs) Handles SuperGridControl1.CellClick
        Dim row As GridRow = TryCast(e.GridPanel.Rows(Me.SuperGridControl1.ActiveRow.Index), GridRow)
        LabelX9.Text = row.Cells(1).Value.ToString
        select_trc = CInt(row.Cells(0).Value)
        Me.WizardPage1.NextButtonEnabled = DevComponents.DotNetBar.eWizardButtonState.True
    End Sub

    Private Sub WizardPage1_NextButtonClick(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles WizardPage1.NextButtonClick

        Try
            Me.Ctrl_troncons_supTableAdapter.Fill(Me.MydbDataSet.ctrl_troncons_sup, New System.Nullable(Of Integer)(CType(select_trc, Integer)))
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try

        If Me.Ctrl_troncons_supBindingSource.Count > 0 Then
            Me.ReflectionImage2.Image = progelec.My.Resources.Resources.delete
            Me.ReflectionImage4.Image = progelec.My.Resources.Resources.delete
            Me.ReflectionImage5.Image = progelec.My.Resources.Resources.delete
            Me.LabelX7.Text = "Le tronçopn ne peut etre suprimmer en l'etat Veuillez mener les actions necessaire"
            Me.LabelX6.Text = "Câbles présent dans le tronçon :"
            Me.SuperGridControl2.Visible = True
        Else
            Me.ReflectionImage2.Image = progelec.My.Resources.Resources.accept
            Me.ReflectionImage4.Image = progelec.My.Resources.Resources.accept
            Me.ReflectionImage5.Image = progelec.My.Resources.Resources.accept
            Me.LabelX7.Text = "Le tronçon peut etre suprimmer sans action suplementaire"
            Me.LabelX6.Text = "Aucun câbles dans le tronçon"
            Me.SuperGridControl2.Visible = False
        End If

    End Sub

    Private Sub WizardPage2_AfterPageDisplayed(sender As System.Object, e As DevComponents.DotNetBar.WizardPageChangeEventArgs) Handles WizardPage1.AfterPageDisplayed
        Me.WizardPage1.NextButtonEnabled = DevComponents.DotNetBar.eWizardButtonState.False
    End Sub

    Private Sub WizardPage4_NextButtonClick(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles WizardPage4.NextButtonClick
        Dim idparc As Integer
        Dim row As DataRowView
        If Me.Ctrl_troncons_supBindingSource.Count < 1 Then

            Try

                Me.Troncons_assocBindingSource.Filter = "troncons = " & select_trc
                If Me.Troncons_assocBindingSource.Count > 0 Then

                    Do While Me.Troncons_assocBindingSource.Count > -1
                        Me.Troncons_assocBindingSource.RemoveAt(Me.Troncons_assocBindingSource.Find("troncons", select_trc))
                        Me.Troncons_assocBindingSource.EndEdit()
                        Me.Troncons_assocTableAdapter.Update(Me.MydbDataSet.troncons_assoc)
                        Me.Troncons_assocBindingSource.Filter = "troncons = " & select_trc
                    Loop
                End If

                Me.Troncons_assocBindingSource.Filter = Nothing

                Me.Troncons_assocBindingSource.Filter = "troncons_tenant = " & select_trc
                If Me.Troncons_assocBindingSource.Count > 0 Then
                    Do While Me.Troncons_assocBindingSource.Find("troncons_tenant", select_trc) > -1
                        Me.Troncons_assocBindingSource.RemoveAt(Me.Troncons_assocBindingSource.Find("troncons_tenant", select_trc))
                        Me.Troncons_assocBindingSource.EndEdit()
                        Me.Troncons_assocTableAdapter.Update(Me.MydbDataSet.troncons_assoc)

                    Loop
                End If
                Me.Troncons_assocBindingSource.Filter = Nothing
                Me.ReflectionImage6.Image = progelec.My.Resources.Resources.accept
            Catch ex As Exception
                Me.ReflectionImage6.Image = progelec.My.Resources.Resources.delete
            End Try

            Try
                Me.Parcours_detailBindingSource.Filter = "troncon = " & select_trc
                If Me.Parcours_detailBindingSource.Count > 0 Then

                    Do While Me.Parcours_detailBindingSource.Count > 0 ' (Me.Parcours_detailBindingSource.Find("troncon", select_trc)) > -1
                        Me.Parcours_detailBindingSource.Filter = Nothing
                        Me.Parcours_detailBindingSource.Position = Me.Parcours_detailBindingSource.Find("troncon", select_trc)
                        row = CType(Me.Parcours_detailBindingSource.Item(Me.Parcours_detailBindingSource.Position), DataRowView)
                        idparc = CInt(row.Item("parcours_idparcours"))
                        Do While Me.Parcours_detailBindingSource.Find("parcours_idparcours", idparc) > 0
                            Me.Parcours_detailBindingSource.RemoveAt(Me.Parcours_detailBindingSource.Find("parcours_idparcours", idparc))
                            Me.Parcours_detailBindingSource.EndEdit()
                            Me.Parcours_detailTableAdapter.Update(Me.MydbDataSet.parcours_detail)
                        Loop
                        Me.Parcours_detailTableAdapter.Fill(Me.MydbDataSet.parcours_detail)
                        If Me.Parcours_detailBindingSource.Find("parcours_idparcours", idparc) = 0 Then

                            Do While Me.ParcoursBindingSource.Find("idparcours", idparc) > 0

                                Me.ParcoursBindingSource.RemoveAt(Me.ParcoursBindingSource.Find("idparcours", idparc))
                                Me.ParcoursBindingSource.EndEdit()
                                Me.ParcoursTableAdapter.Update(Me.MydbDataSet.parcours)
                            Loop
                        End If
                        Me.Parcours_detailTableAdapter.Fill(Me.MydbDataSet.parcours_detail)
                        Me.Parcours_detailBindingSource.Filter = "troncon = " & select_trc
                    Loop
                End If
                Me.ReflectionImage7.Image = progelec.My.Resources.Resources.accept
            Catch ex As Exception
                Me.ReflectionImage7.Image = progelec.My.Resources.Resources.delete
            End Try

            Try

                Do While Me.TronconsBindingSource.Find("idtroncons", select_trc) > -1
                    Me.TronconsBindingSource.RemoveAt(Me.TronconsBindingSource.Find("idtroncons", select_trc))
                    Me.TronconsBindingSource.EndEdit()
                    Me.TronconsTableAdapter.Update(Me.MydbDataSet.troncons)

                Loop

                Me.ReflectionImage8.Image = progelec.My.Resources.Resources.accept
            Catch ex As Exception
                Me.ReflectionImage8.Image = progelec.My.Resources.Resources.delete
            End Try
        Else
            Me.ReflectionImage6.Image = progelec.My.Resources.Resources.delete
            Me.ReflectionImage7.Image = progelec.My.Resources.Resources.delete
            Me.ReflectionImage8.Image = progelec.My.Resources.Resources.delete
            Me.LabelX15.Visible = True

        End If
    End Sub

    Private Sub WizardPage3_FinishButtonClick(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles WizardPage3.FinishButtonClick
        Me.Close()
        Me.Dispose()

    End Sub
End Class