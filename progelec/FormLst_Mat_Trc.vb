Imports DevComponents.DotNetBar.SuperGrid
Public Class FormLst_Mat_Trc

    Private Sub FormLst_Mat_Trc_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Me.Lst_trc_sans_matTableAdapter.Fill(Me.MydbDataSet.lst_trc_sans_mat)
        '   AddHandler Me.GotFocus, AddressOf FormLst_Mat_Trc_GotFocus
    End Sub

    Private Sub SuperGridControl1_RowDoubleClick(sender As Object, e As DevComponents.DotNetBar.SuperGrid.GridRowDoubleClickEventArgs) Handles SuperGridControl1.RowDoubleClick
        Dim grow As GridRow

        Dim irow As Integer
        Dim crow As DataRowView

        Dim formTroncon As FormTroncon
        formTroncon = New FormTroncon
        formTroncon.MdiParent = Me.ParentForm
        formTroncon.WindowState = FormWindowState.Maximized
        formTroncon.mode = False

        grow = CType(e.GridRow, GridRow)
        irow = Me.Lst_trc_sans_matBindingSource.Find("idtroncons", grow.Cells(0).Value.ToString)
        Me.Lst_trc_sans_matBindingSource.Position = irow
        crow = CType(Me.Lst_trc_sans_matBindingSource.Item(irow), DataRowView)

        formTroncon.value = crow.Item(0).ToString

        formTroncon.Show()

    End Sub

    Private Sub ButtonX2_Click(sender As System.Object, e As System.EventArgs) Handles ButtonX2.Click
        Me.Lst_trc_sans_matTableAdapter.Fill(Me.MydbDataSet.lst_trc_sans_mat)
    End Sub
End Class