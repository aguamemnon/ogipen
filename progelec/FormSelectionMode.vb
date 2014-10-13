Public Class FormSelectionMode

    Private Sub ButtonX2_Click(sender As System.Object, e As System.EventArgs) Handles ButtonX2.Click
        FormMain.user.mode = "Marché de base"
        FormMain.user.detail_modif = ""
        FormMain.user.refmodif = "Modification Courante"
        Me.Close()
    End Sub

    Private Sub ButtonX3_Click(sender As System.Object, e As System.EventArgs) Handles ButtonX3.Click

    End Sub

    Private Sub ButtonX1_Click(sender As System.Object, e As System.EventArgs) Handles ButtonX1.Click
        FormMain.user.mode = "consultation"
        FormMain.user.detail_modif = ""
        FormMain.user.refmodif = ""
        Me.Close()
    End Sub
End Class