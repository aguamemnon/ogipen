Public Class FormOptions

    Private Sub FormOptions_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        'TODO: This line of code loads data into the 'MydbDataSet.type_doc' table. You can move, or remove it, as needed.
        Me.Type_docTableAdapter.Fill(Me.MydbDataSet.type_doc)
        Me.TextBoxX1.Text = My.Settings("savepath").ToString
    End Sub

    Private Sub ButtonX1_Click(sender As System.Object, e As System.EventArgs) Handles ButtonX1.Click
        Me.FolderBrowserDialog1.ShowDialog()
        Me.TextBoxX1.Text = Me.FolderBrowserDialog1.SelectedPath
    End Sub

    Private Sub ButtonX2_Click(sender As System.Object, e As System.EventArgs) Handles ButtonX2.Click
        Me.Close()
    End Sub

    Private Sub ButtonX3_Click(sender As System.Object, e As System.EventArgs) Handles ButtonX3.Click
        If My.Settings("savepath").ToString <> Me.TextBoxX1.Text Then

            My.Settings("savepath") = Me.TextBoxX1.Text
            My.Settings.Save()
        End If

        Me.Validate()
        Me.Type_docBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.MydbDataSet)

        Dim s As DataRowView       '
        s = CType(Me.Type_docBindingSource.Item(Me.Type_docBindingSource.Find("type_doc", "Carnet de deroulage")), DataRowView)
        FormMain.user.option1 = s.Item("reference").ToString

        s = CType(Me.Type_docBindingSource.Item(Me.Type_docBindingSource.Find("type_doc", "Calcul DCC")), DataRowView)

        FormMain.user.option2 = s.Item("reference").ToString
        s = CType(Me.Type_docBindingSource.Item(Me.Type_docBindingSource.Find("type_doc", "Carnet de cables")), DataRowView)

        FormMain.user.option3 = s.Item("reference").ToString
        'progelec.FormMain.config_ini_ok = True

        Me.Close()
    End Sub

    Private Sub ButtonX4_Click(sender As Object, e As EventArgs) Handles ButtonX4.Click
        Me.Type_docBindingSource.AddNew()

    End Sub

   
End Class