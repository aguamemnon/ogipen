Imports DevComponents.DotNetBar.SuperGrid
Public Class FormSupAssocTroncon
    Dim select_trc As Integer
    Dim select_trc2 As Integer
    Dim ctrl As Boolean

    Private Sub FormSupTroncon_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ctrl = False
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
        If Not IsNothing(Me.ComboBoxEx1.SelectedValue) And Not IsNothing(Me.ComboBoxEx2.SelectedValue) And Not IsNothing(Me.ComboBoxEx3.SelectedValue) Then
            Me.Lst_troncons_supTableAdapter.Fill(Me.MydbDataSet.lst_troncons_sup, New System.Nullable(Of Integer)(CType(Me.ComboBoxEx1.SelectedValue, Integer)), New System.Nullable(Of Integer)(CType(Me.ComboBoxEx2.SelectedValue, Integer)), New System.Nullable(Of Integer)(CType(Me.ComboBoxEx3.SelectedValue, Integer)))
            Me.SuperGridControl1.DataBindings.Clear()
            Me.SuperGridControl1.PrimaryGrid.DataSource = Me.Lst_troncons_supBindingSource

        End If
        Me.Ctrl_sup_assoTableAdapter.Fill(Me.MydbDataSet.ctrl_sup_asso, select_trc, select_trc2)
        Me.LabelX5.Text = "Nombre total à supprimer " & Me.Ctrl_sup_assoBindingSource.Count
    End Sub

    Private Sub SuperGridControl1_CellClick(sender As System.Object, e As DevComponents.DotNetBar.SuperGrid.GridCellClickEventArgs) Handles SuperGridControl1.CellClick
        Dim row As GridRow = TryCast(e.GridPanel.Rows(Me.SuperGridControl1.ActiveRow.Index), GridRow)
        LabelX9.Text = row.Cells(1).Value.ToString
        select_trc = CInt(row.Cells(0).Value)
        Me.Lst_troncons_sameTableAdapter.ClearBeforeFill = True
        Me.Lst_troncons_sameTableAdapter.Fill(Me.MydbDataSet.lst_troncons_same, select_trc)
        Me.SuperGridControl4.PrimaryGrid.ClearAll()
        Me.SuperGridControl4.PrimaryGrid.DataSource = Me.Lst_troncons_sameBindingSource
        Me.Ctrl_sup_assoTableAdapter.Fill(Me.MydbDataSet.ctrl_sup_asso, select_trc, select_trc2)
        Me.LabelX5.Text = "Nombre total à supprimer " & Me.Ctrl_sup_assoBindingSource.Count

    End Sub

    Private Sub WizardPage1_NextButtonClick(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles WizardPage1.NextButtonClick
        Dim i As Integer
        Dim ii As Integer
        Dim p As Integer
        Dim pp As Integer

        Dim row As DataRowView
        Try

            If Me.Parcours_detailBindingSource.Find("troncon", select_trc) > -1 Then
                i = Me.Parcours_detailBindingSource.Find("troncon", select_trc)
                row = CType(Me.Parcours_detailBindingSource.Item(Me.Parcours_detailBindingSource.Position), DataRowView)
                p = CInt(row.Item("parcours_idparcours").ToString)
                ii = Me.Parcours_detailBindingSource.Find("troncon", select_trc2)
                row = CType(Me.Parcours_detailBindingSource.Item(Me.Parcours_detailBindingSource.Position), DataRowView)
                pp = CInt(row.Item("parcours_idparcours").ToString)
                If ii = i + 1 Or ii = i - 1 Then
                    If p = pp Then
                        ctrl = True
                    End If
                End If
            End If

        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try

        Me.Ctrl_sup_assoTableAdapter.Fill(Me.MydbDataSet.ctrl_sup_asso, select_trc, select_trc2)
        Me.LabelX5.Text = "Nombre total à supprimer " & Me.Ctrl_sup_assoBindingSource.Count
        If ctrl = False Then
            Me.ReflectionImage2.Image = progelec.My.Resources.Resources.accept
            Me.LabelX7.Text = "Le ou les associations peuvent etre supprimés sans action suplementaire"
        Else
            Me.ReflectionImage2.Image = progelec.My.Resources.Resources.remove
            Me.LabelX7.Text = "La suppression des associations supprimera les parcours"
        End If

        Me.LabelX19.Text = " Demande de suppression des associations entre :" & LabelX9.Text & " et " & LabelX18.Text

    End Sub

    Private Sub WizardPage2_AfterPageDisplayed(sender As System.Object, e As DevComponents.DotNetBar.WizardPageChangeEventArgs) Handles WizardPage1.AfterPageDisplayed
        Me.WizardPage1.NextButtonEnabled = DevComponents.DotNetBar.eWizardButtonState.False
    End Sub

    Private Sub WizardPage4_NextButtonClick(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles WizardPage4.NextButtonClick
        '  Dim idparc As Integer
        Dim row As DataRowView
        Me.Ctrl_sup_assoTableAdapter.ClearBeforeFill = True
        Me.Ctrl_sup_assoTableAdapter.Fill(Me.MydbDataSet.ctrl_sup_asso, select_trc, select_trc2)

        Do While Me.Ctrl_sup_assoBindingSource.Count > 0
            Me.Ctrl_sup_assoBindingSource.Find("troncons", select_trc)
            If Me.Ctrl_sup_assoBindingSource.Find("troncons", select_trc) = -1 Then
                Me.Ctrl_sup_assoBindingSource.Find("troncons_tenant", select_trc)
                row = CType(Me.Ctrl_sup_assoBindingSource.Item(Me.Ctrl_sup_assoBindingSource.Position), DataRowView)
                Me.Troncons_assocBindingSource.RemoveAt(Me.Troncons_assocBindingSource.Find("idtroncon_assoc", row.Item("idtroncon_assoc")))
                Me.Troncons_assocBindingSource.EndEdit()
                Me.Troncons_assocTableAdapter.Update(Me.MydbDataSet.troncons_assoc)
                Me.Ctrl_sup_assoTableAdapter.Fill(Me.MydbDataSet.ctrl_sup_asso, select_trc, select_trc2)
            Else
                row = CType(Me.Ctrl_sup_assoBindingSource.Item(Me.Ctrl_sup_assoBindingSource.Position), DataRowView)
                Me.Troncons_assocBindingSource.RemoveAt(Me.Troncons_assocBindingSource.Find("idtroncon_assoc", row.Item("idtroncon_assoc")))
                Me.Troncons_assocBindingSource.EndEdit()
                Me.Troncons_assocTableAdapter.Update(Me.MydbDataSet.troncons_assoc)
                Me.Ctrl_sup_assoTableAdapter.Fill(Me.MydbDataSet.ctrl_sup_asso, select_trc, select_trc2)
            End If

        Loop

    End Sub

    Private Sub SuperGridControl4_Click(sender As System.Object, e As DevComponents.DotNetBar.SuperGrid.GridCellClickEventArgs) Handles SuperGridControl4.CellClick
        Dim row As GridRow = TryCast(e.GridPanel.Rows(Me.SuperGridControl4.ActiveRow.Index), GridRow)
        LabelX18.Text = row.Cells(1).Value.ToString
        select_trc2 = CInt(row.Cells(0).Value)
        Me.WizardPage1.NextButtonEnabled = DevComponents.DotNetBar.eWizardButtonState.True
        Me.Ctrl_sup_assoTableAdapter.Fill(Me.MydbDataSet.ctrl_sup_asso, select_trc, select_trc2)
        Me.LabelX5.Text = "Nombre total à supprimer " & Me.Ctrl_sup_assoBindingSource.Count
    End Sub

    Private Sub WizardPage3_FinishButtonClick(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles WizardPage3.FinishButtonClick
        Me.Ctrl_sup_assoBindingSource.Dispose()
        Me.Ctrl_troncons_supBindingSource.Dispose()
        Me.Lst_troncons_sameBindingSource.Dispose()
        Me.Lst_troncons_supBindingSource.Dispose()
        Me.Parcours_detailBindingSource.Dispose()
        Me.ParcoursBindingSource.Dispose()
        Me.SallesBindingSource.Dispose()
        Me.SegregationsBindingSource.Dispose()
        Me.Troncons_assocBindingSource.Dispose()
        Me.TronconsBindingSource.Dispose()
        Me.Types_tronconsBindingSource.Dispose()

        Me.Close()
    End Sub
End Class