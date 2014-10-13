Public Class FormTouretsliste

    Private Sub FormTouretsliste_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'MydbDataSet.lst_tourets' table. You can move, or remove it, as needed.
        actualisation()
        controle_touret()
    End Sub

    Private Sub Lst_touretsDataGridViewX_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Lst_touretsDataGridViewX.CellDoubleClick

        Dim FormTouretsDetail As FormTouretsDetail
        FormTouretsDetail = New FormTouretsDetail
        FormTouretsDetail.MdiParent = Me.ParentForm
        FormTouretsDetail.WindowState = FormWindowState.Maximized
        Dim row As MydbDataSet.lst_touretsRow
        row = CType(CType(Me.Lst_touretsBindingSource.Current, DataRowView).Row, MydbDataSet.lst_touretsRow)
        FormTouretsDetail.ntouret = row.idtouret
        FormTouretsDetail.Show()

    End Sub
    Public Sub controle_touret()

        If Me.Lst_touretsBindingSource.Count = 0 Then
            Me.Lst_touretsDataGridViewX.Visible = False
            Me.LabelXAvertissement.Visible = True
        End If

    End Sub
    Public Sub actualisation()

        Me.Lst_touretsTableAdapter.Fill(Me.MydbDataSet.lst_tourets)

    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click

        Dim formMiseTourets As FormMiseTourets
        formMiseTourets = New FormMiseTourets
        formMiseTourets.MdiParent = Me.ParentForm
        formMiseTourets.WindowState = FormWindowState.Maximized
        formMiseTourets.Show()

    End Sub
End Class