Public Class FormSelectProject

    Private Sub ButtonX2_Click(sender As System.Object, e As System.EventArgs) Handles ButtonX2.Click
        FormMain.user.state = False
        Me.Close()

    End Sub

    Private Sub FormSelectProject_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

    End Sub

    Private Sub FormSelectProject_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'ProgelecDataSet.projets' table. You can move, or remove it, as needed.
        Me.ProjetsTableAdapter.Connection.Close()
        Me.ProjetsTableAdapter.Connection.ConnectionString = ClassConnectionBuilder.ConnectionStringBuilder(FormMain.user.server, "progelec", "root", FormMain.user.pass_user)
        Me.ProjetsTableAdapter.Connection.Open()
        Me.ProjetsTableAdapter.Fill(Me.ProgelecDataSet.projets)

    End Sub

    Private Sub ButtonX1_Click(sender As System.Object, e As System.EventArgs) Handles ButtonX1.Click
        FormMain.user.Project_user = Me.NomTextBox.Text
        'todo Creation compte actif sur projets
        If check_user(FormMain.user.Nom_user, FormMain.user.Project_user) Then
            Me.ProjetsTableAdapter.Connection.Close()
            Me.Close()
        Else
            MsgBox(" Vous n'avez pas les droits pour ouvrir ce projet")
        End If

    End Sub

    Private Sub ButtonX3_Click(sender As System.Object, e As System.EventArgs) Handles ButtonX3.Click
        Dim FormGestUsers As FormGestUsers
        FormGestUsers = New FormGestUsers
        FormGestUsers.ShowDialog()
    End Sub
End Class