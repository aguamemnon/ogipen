Imports MySql.Data.MySqlClient
Imports FastReport.Data
Imports System.IO.File
Imports FastReport.Utils

Public Class FormReportParcours

    Private Sub FormReportParcours_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.batiments'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.BatimentsTableAdapter.Fill(Me.MydbDataSet.batiments)
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.equipements'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.EquipementsTableAdapter.Fill(Me.MydbDataSet.equipements)

        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.type_doc'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.Type_docTableAdapter.Fill(Me.MydbDataSet.type_doc)
        ' Me.Report1 = New Report()
        ' Me.Report1.Load("report1.frx")
        ' Me.Report1.RegisterData(MydbDataSet1, "cables")
        ' Me.Report1.RegisterData(MydbDataSet1, "cables_details")
        ' Me.Report1.RegisterData(MydbDataSet1, "parcours_detail")
        ' Me.Report1.Preview = Me.PreviewControl1

        'Me.Report1.Show()

        Me.Report1.Dictionary.Connections.Item(0).ConnectionString = ClassConnectionBuilder.ConnectionStringBuilder(FormMain.user.server, FormMain.user.Project_user, "root", FormMain.user.pass_user)
        '   Me.Report3.Dictionary.Connections.Item(0).ConnectionString = ClassConnectionBuilder.ConnectionStringBuilder( formmain.user.server,formmain.user.Project_user, "root",formmain.user.pass_user)
        Me.Report3.Dictionary.Connections.Item(0).ConnectionString = ClassConnectionBuilder.ConnectionStringBuilder(FormMain.user.server, FormMain.user.Project_user, "root", FormMain.user.pass_user)
        Me.Report2.Dictionary.Connections.Item(0).ConnectionString = ClassConnectionBuilder.ConnectionStringBuilder(FormMain.user.server, FormMain.user.Project_user, "root", FormMain.user.pass_user)
        Me.Report4.Dictionary.Connections.Item(0).ConnectionString = ClassConnectionBuilder.ConnectionStringBuilder(FormMain.user.server, FormMain.user.Project_user, "root", FormMain.user.pass_user)
        Me.Report5.Dictionary.Connections.Item(0).ConnectionString = ClassConnectionBuilder.ConnectionStringBuilder(FormMain.user.server, FormMain.user.Project_user, "root", FormMain.user.pass_user)
        Me.Report6.Dictionary.Connections.Item(0).ConnectionString = ClassConnectionBuilder.ConnectionStringBuilder(FormMain.user.server, FormMain.user.Project_user, "root", FormMain.user.pass_user)
        Me.Report7.Dictionary.Connections.Item(0).ConnectionString = ClassConnectionBuilder.ConnectionStringBuilder(FormMain.user.server, FormMain.user.Project_user, "root", FormMain.user.pass_user)
        Me.EquipementsTableAdapter.Fill(Me.MydbDataSet.equipements)
        Config.EmailSettings.UseMAPI = True

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Me.PreviewControl1.Clear()
        Me.Report3.SetParameterValue("RefDoc", FormMain.user.option1)
        Me.Report3.SetParameterValue("Projet", FormMain.user.Project_user)
        Me.Report3.SetParameterValue("ReVDoc", "#")
        Me.Report3.SetParameterValue("version", Application.ProductVersion)

        Me.Report3.Dictionary.Connections.Item(0).ConnectionString = ClassConnectionBuilder.ConnectionStringBuilder(FormMain.user.server, FormMain.user.Project_user, "root", FormMain.user.pass_user)
        Me.Report3.Preview = Me.PreviewControl1
        '    Me.Report3.Prepare()
        Me.Report3.Show()
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Select Case MessageBox.Show("Voulez vous generer un nouveau rapport ? ( Cliquer sur oui )" _
     & Microsoft.VisualBasic.ControlChars.CrLf & "Voulez vous consulter la derniere generation ? ( cliquer sur non )" _
     & Microsoft.VisualBasic.ControlChars.CrLf & "Pour quitter cliquer sur Annuler", "Generation d'un raport", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation)

            Case System.Windows.Forms.DialogResult.Yes
                Config.EmailSettings.UseMAPI = True

                Me.PreviewControl1.Clear()

                Me.Report2.Preview = Me.PreviewControl1
                Me.Report2.Dictionary.Connections.Item(0).ConnectionString = ClassConnectionBuilder.ConnectionStringBuilder(FormMain.user.server, FormMain.user.Project_user, "root", FormMain.user.pass_user)
                Me.Report2.SetParameterValue("RefDoc", FormMain.user.option1)
                Me.Report2.SetParameterValue("Projet", FormMain.user.Project_user)
                Me.Report2.Prepare()
                Dim export As FastReport.Export.Pdf.PDFExport = New FastReport.Export.Pdf.PDFExport()
                If System.IO.Directory.Exists(My.Settings.savepath.ToString & "\" & FormMain.user.Project_user) = False Then System.IO.Directory.CreateDirectory(My.Settings.savepath.ToString & "\" & FormMain.user.Project_user)
                Me.Report2.Export(export, My.Settings.savepath.ToString & "\" & FormMain.user.Project_user & "\" & FormMain.user.option1 & ".pdf")
                Me.Report2.Show()
            Case System.Windows.Forms.DialogResult.No
                Dim fichier As String
                fichier = FormMain.user.option1 & ".pdf"

                Dim Chemin As String
                Chemin = My.Settings.savepath.ToString & "\" & FormMain.user.Project_user & "\"
                If Exists(Chemin & fichier) Then
                    Process.Start(Chemin & fichier)
                Else
                    MsgBox("aucune generation existante")
                End If
            Case System.Windows.Forms.DialogResult.Cancel

        End Select

    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        Select Case MessageBox.Show("Generation du DCC" _
            & Microsoft.VisualBasic.ControlChars.CrLf & "" _
            & Microsoft.VisualBasic.ControlChars.CrLf & "Relancer le calcul pour l'ensemble des salles cliquer sur oui" _
            & Microsoft.VisualBasic.ControlChars.CrLf & "voir la derniere version du rapport cliquer sur non" _
            & Microsoft.VisualBasic.ControlChars.CrLf & "sinon cliquer sur annuler", "Generation du DCC", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation)

            Case System.Windows.Forms.DialogResult.Yes
                Dim rev2 As String
                Dim s As DataRowView       '
                ' Me.Type_docBindingSource.Filter = " Batiment ='" & ComboBox2.Text.ToString & "'"
                s = CType(Me.Type_docBindingSource.Item(Me.Type_docBindingSource.Find("type_doc", "Calcul DCC")), DataRowView)
                rev2 = InputBox("Veuillez indiquer la revision du document")

                ' Config.EmailSettings.UseMAPI = True
                Me.PreviewControl1.Clear()
                Me.Report4.SetParameterValue("RefDoc", s.Item("reference").ToString)
                Me.Report4.SetParameterValue("RevDoc", rev2)
                Me.Report4.Preview = Me.PreviewControl1
                Me.Report4.Dictionary.Connections.Item(0).ConnectionString = ClassConnectionBuilder.ConnectionStringBuilder(FormMain.user.server, FormMain.user.Project_user, "root", FormMain.user.pass_user)
                Me.Report4.SetParameterValue("Projet", FormMain.user.Project_user)
                Me.Report4.Prepare()
                Dim export As FastReport.Export.Pdf.PDFExport = New FastReport.Export.Pdf.PDFExport()
                If System.IO.Directory.Exists(My.Settings.savepath.ToString & "\" & FormMain.user.Project_user) = False Then System.IO.Directory.CreateDirectory(My.Settings.savepath.ToString & "\" & FormMain.user.Project_user)
                Me.Report4.Export(export, My.Settings.savepath.ToString & "\" & FormMain.user.Project_user & "\" & FormMain.user.option2 & ".pdf")
                Me.Report4.Show()

            Case System.Windows.Forms.DialogResult.No
                Dim fichier As String
                fichier = FormMain.user.option2 & ".pdf"

                Dim Chemin As String
                Chemin = My.Settings.savepath.ToString & "\" & FormMain.user.Project_user & "\"
                If Exists(Chemin & fichier) Then
                    Process.Start(Chemin & fichier)
                Else
                    MsgBox("aucune generation existante")
                End If
            Case System.Windows.Forms.DialogResult.Cancel

        End Select

    End Sub

    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click
        Dim rev As Double
        Dim rev2 As String
        Select Case MessageBox.Show("Voulez vous generer un nouveau rapport ? ( Cliquer sur oui )" _
   & Microsoft.VisualBasic.ControlChars.CrLf & "Voulez vous consulter la derniere generation ? ( cliquer sur non )" _
   & Microsoft.VisualBasic.ControlChars.CrLf & "Pour quitter cliquer sur Annuler", "Generation d'un raport", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation)

            Case System.Windows.Forms.DialogResult.Yes
                ' Config.EmailSettings.UseMAPI = True
                Dim ini As String = InputBox("Veuillez completer la reference du document : " & FormMain.user.option4)

                rev2 = InputBox("Veuillez indiquer la revision du document")
                ' rev2 = formmain.user.option4 & rev2

                Me.PreviewControl1.Clear()
                Me.Report5.Preview = Me.PreviewControl1
                Me.Report5.Dictionary.Connections.Item(0).ConnectionString = ClassConnectionBuilder.ConnectionStringBuilder(FormMain.user.server, FormMain.user.Project_user, "root", FormMain.user.pass_user)
                Me.Report5.SetParameterValue("RefDoc", FormMain.user.option4 & ini)
                Me.Report5.SetParameterValue("RevDoc", rev2)
                Me.Report5.SetParameterValue("idbat", CInt(Me.ComboBox2.SelectedValue))
                Me.Report5.SetParameterValue("batiment", ComboBox2.Text)
                Me.Report5.SetParameterValue("redacteur", FormMain.user.nom & " " & FormMain.user.Prenom)
                Me.Report5.SetParameterValue("Projet", FormMain.user.Project_user)
                Me.Report5.Prepare()
                Dim export As FastReport.Export.Pdf.PDFExport = New FastReport.Export.Pdf.PDFExport()
                If System.IO.Directory.Exists(My.Settings.savepath.ToString & "\" & FormMain.user.Project_user) = False Then System.IO.Directory.CreateDirectory(My.Settings.savepath.ToString & "\" & FormMain.user.Project_user)
                Me.Report5.Export(export, My.Settings.savepath.ToString & "\" & FormMain.user.Project_user & "\" & FormMain.user.option4 & ini & "-" & rev2 & ".pdf")
                Me.Report5.Show()
            Case System.Windows.Forms.DialogResult.No
                Dim ini As String = InputBox("Veuillez completer la reference du document : " & FormMain.user.option4)
                rev2 = InputBox("Veuillez indiquer la revision du document")
                Dim fichier As String
                fichier = FormMain.user.option4 & ini & "-" & rev2 & ".pdf"

                Dim Chemin As String
                Chemin = My.Settings.savepath.ToString & "\" & FormMain.user.Project_user & "\"
                If Exists(Chemin & fichier) Then
                    Process.Start(Chemin & fichier)
                Else
                    MsgBox("aucune generation existante")
                End If

            Case System.Windows.Forms.DialogResult.Cancel

        End Select
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim rev As Double
        Dim rev2 As String
        Dim s As DataRowView       '
        s = CType(Me.Type_docBindingSource.Item(Me.Type_docBindingSource.Find("type_doc", "Carnet de raccordement")), DataRowView)

        Select Case MessageBox.Show("Voulez vous generer un nouveau rapport ? ( Cliquer sur oui )" _
   & Microsoft.VisualBasic.ControlChars.CrLf & "Voulez vous consulter la derniere generation ? ( cliquer sur non )" _
   & Microsoft.VisualBasic.ControlChars.CrLf & "Pour quitter cliquer sur Annuler", "Generation d'un raport", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation)

            Case System.Windows.Forms.DialogResult.Yes
                ' Config.EmailSettings.UseMAPI = True
                rev2 = InputBox("Veuillez indiquer la revision du document")
                rev2 = FormMain.user.option4 & rev2
                Me.PreviewControl1.Clear()
                Me.Report6.Preview = Me.PreviewControl1
                Me.Report6.Dictionary.Connections.Item(0).ConnectionString = ClassConnectionBuilder.ConnectionStringBuilder(FormMain.user.server, FormMain.user.Project_user, "root", FormMain.user.pass_user)
                Me.Report6.SetParameterValue("RefDoc", rev2)
                Me.Report6.SetParameterValue("Projet", FormMain.user.Project_user)
                Me.Report6.SetParameterValue("IDequip", CInt(Me.ComboBox1.SelectedValue))
                Me.Report6.Prepare()
                'Dim export As FastReport.Export.Pdf.PDFExport = New FastReport.Export.Pdf.PDFExport()
                'If System.IO.Directory.Exists(My.Settings.savepath.ToString & "\" &formmain.user.Project_user) = False Then System.IO.Directory.CreateDirectory(My.Settings.savepath.ToString & "\" &formmain.user.Project_user)
                'Me.Report6.Export(export, My.Settings.savepath.ToString & "\" &formmain.user.Project_user & "\" &formmain.user.option4 & ".pdf")
                Me.Report6.Show()
            Case System.Windows.Forms.DialogResult.No
                Dim fichier As String
                fichier = FormMain.user.option4 & ".pdf"

                Dim Chemin As String
                Chemin = My.Settings.savepath.ToString & "\" & FormMain.user.Project_user & "\"
                If Exists(Chemin & fichier) Then
                    Process.Start(Chemin & fichier)
                Else
                    MsgBox("aucune generation existante")
                End If

            Case System.Windows.Forms.DialogResult.Cancel

        End Select
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim rev As Double
        Dim rev2 As String
        Dim s As DataRowView       '
        s = CType(Me.Type_docBindingSource.Item(Me.Type_docBindingSource.Find("type_doc", "Carnet de contrôle réglementaire")), DataRowView)

        Select Case MessageBox.Show("Voulez vous generer un nouveau rapport ? ( Cliquer sur oui )" _
   & Microsoft.VisualBasic.ControlChars.CrLf & "Voulez vous consulter la derniere generation ? ( cliquer sur non )" _
   & Microsoft.VisualBasic.ControlChars.CrLf & "Pour quitter cliquer sur Annuler", "Generation d'un raport", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation)

            Case System.Windows.Forms.DialogResult.Yes
                ' Config.EmailSettings.UseMAPI = True
                rev2 = InputBox("Veuillez indiquer la revision du document")
                rev2 = FormMain.user.option4 & rev2
                Me.PreviewControl1.Clear()
                Me.Report7.Preview = Me.PreviewControl1
                Me.Report7.Dictionary.Connections.Item(0).ConnectionString = ClassConnectionBuilder.ConnectionStringBuilder(FormMain.user.server, FormMain.user.Project_user, "root", FormMain.user.pass_user)
                Me.Report7.SetParameterValue("RefDoc", s.Item("reference").ToString)
                Me.Report7.SetParameterValue("ReVDoc", rev2)
                Me.Report7.SetParameterValue("Projet", FormMain.user.Project_user)
                Me.Report7.SetParameterValue("IDequip", CInt(Me.ComboBox1.SelectedValue))
                Me.Report7.Prepare()
                'Dim export As FastReport.Export.Pdf.PDFExport = New FastReport.Export.Pdf.PDFExport()
                'If System.IO.Directory.Exists(My.Settings.savepath.ToString & "\" &formmain.user.Project_user) = False Then System.IO.Directory.CreateDirectory(My.Settings.savepath.ToString & "\" &formmain.user.Project_user)
                'Me.Report6.Export(export, My.Settings.savepath.ToString & "\" &formmain.user.Project_user & "\" &formmain.user.option4 & ".pdf")
                Me.Report7.Show()
            Case System.Windows.Forms.DialogResult.No
                Dim fichier As String
                fichier = FormMain.user.option4 & ".pdf"

                Dim Chemin As String
                Chemin = My.Settings.savepath.ToString & "\" & FormMain.user.Project_user & "\"
                If Exists(Chemin & fichier) Then
                    Process.Start(Chemin & fichier)
                Else
                    MsgBox("aucune generation existante")
                End If

            Case System.Windows.Forms.DialogResult.Cancel

        End Select
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim rev As Double
        Dim rev2 As String
        Dim s As DataRowView       '
        Me.Type_docBindingSource.Filter = " Batiment ='" & ComboBox2.Text.ToString & "'"
        s = CType(Me.Type_docBindingSource.Item(Me.Type_docBindingSource.Find("type_doc", "Programme Particulier d’Essais Support et cheminement phase 1")), DataRowView)

        Select Case MessageBox.Show("Voulez vous generer un nouveau rapport ? ( Cliquer sur oui )" _
   & Microsoft.VisualBasic.ControlChars.CrLf & "Voulez vous consulter la derniere generation ? ( cliquer sur non )" _
   & Microsoft.VisualBasic.ControlChars.CrLf & "Pour quitter cliquer sur Annuler", "Generation d'un raport", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation)

            Case System.Windows.Forms.DialogResult.Yes
                ' Config.EmailSettings.UseMAPI = True
                rev2 = InputBox("Veuillez indiquer la revision du document")

                Me.PreviewControl1.Clear()
                Me.Report_ph1_trc.Preview = Me.PreviewControl1
                Me.Report_ph1_trc.Dictionary.Connections.Item(0).ConnectionString = ClassConnectionBuilder.ConnectionStringBuilder(FormMain.user.server, FormMain.user.Project_user, "root", FormMain.user.pass_user)
                Me.Report_ph1_trc.SetParameterValue("RefDoc", s.Item("reference").ToString)
                Me.Report_ph1_trc.SetParameterValue("Rev", rev2)
                Me.Report_ph1_trc.SetParameterValue("Batiment", ComboBox2.Text)
                Me.Report_ph1_trc.SetParameterValue("Projet", FormMain.user.Project_user)

                Me.Report_ph1_trc.SetParameterValue("idbat", CInt(Me.ComboBox2.SelectedValue))

                Me.Report_ph1_trc.SetParameterValue("redacteur", FormMain.user.nom & " " & FormMain.user.Prenom)
                Me.Report_ph1_trc.Prepare()
                'Dim export As FastReport.Export.Pdf.PDFExport = New FastReport.Export.Pdf.PDFExport()
                'If System.IO.Directory.Exists(My.Settings.savepath.ToString & "\" &formmain.user.Project_user) = False Then System.IO.Directory.CreateDirectory(My.Settings.savepath.ToString & "\" &formmain.user.Project_user)
                'Me.Report6.Export(export, My.Settings.savepath.ToString & "\" &formmain.user.Project_user & "\" &formmain.user.option4 & ".pdf")
                Me.Report_ph1_trc.Show()
            Case System.Windows.Forms.DialogResult.No
                Dim fichier As String
                fichier = FormMain.user.option4 & ".pdf"

                Dim Chemin As String
                Chemin = My.Settings.savepath.ToString & "\" & FormMain.user.Project_user & "\"
                If Exists(Chemin & fichier) Then
                    Process.Start(Chemin & fichier)
                Else
                    MsgBox("aucune generation existante")
                End If

            Case System.Windows.Forms.DialogResult.Cancel

        End Select
    End Sub

   
    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        'Report_Phase1_equi
        Dim rev As Double
        Dim rev2 As String
        Dim s As DataRowView       '
        Me.Type_docBindingSource.Filter = " Batiment ='" & ComboBox2.Text.ToString & "'"
        Try
            s = CType(Me.Type_docBindingSource.Item(Me.Type_docBindingSource.Find("type_doc", "Programme Particulier d’Essais phase 1 Eclairage et PFM")), DataRowView)
        Catch ex As Exception
            MsgBox("Aucune reference documentaire existante merci de corriger ...")
            Exit Sub
        End Try


        Select Case MessageBox.Show("Voulez vous generer un nouveau rapport ? ( Cliquer sur oui )" _
   & Microsoft.VisualBasic.ControlChars.CrLf & "Voulez vous consulter la derniere generation ? ( cliquer sur non )" _
   & Microsoft.VisualBasic.ControlChars.CrLf & "Pour quitter cliquer sur Annuler", "Generation d'un raport", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation)

            Case System.Windows.Forms.DialogResult.Yes
                ' Config.EmailSettings.UseMAPI = True
                rev2 = InputBox("Veuillez indiquer la revision du document")

                Me.PreviewControl1.Clear()
                Me.Report_phase1_pfm.Preview = Me.PreviewControl1
                Me.Report_phase1_pfm.Dictionary.Connections.Item(0).ConnectionString = ClassConnectionBuilder.ConnectionStringBuilder(FormMain.user.server, FormMain.user.Project_user, "root", FormMain.user.pass_user)
                Me.Report_phase1_pfm.SetParameterValue("RefDoc", s.Item("reference").ToString)
                Me.Report_phase1_pfm.SetParameterValue("Rev", rev2)
                Me.Report_phase1_pfm.SetParameterValue("Batiment", ComboBox2.Text)
                Me.Report_phase1_pfm.SetParameterValue("Projet", FormMain.user.Project_user)

                Me.Report_phase1_pfm.SetParameterValue("idbat", CInt(Me.ComboBox2.SelectedValue))

                Me.Report_phase1_pfm.SetParameterValue("redacteur", FormMain.user.nom & " " & FormMain.user.Prenom)
                Me.Report_phase1_pfm.Prepare()
                'Dim export As FastReport.Export.Pdf.PDFExport = New FastReport.Export.Pdf.PDFExport()
                'If System.IO.Directory.Exists(My.Settings.savepath.ToString & "\" &formmain.user.Project_user) = False Then System.IO.Directory.CreateDirectory(My.Settings.savepath.ToString & "\" &formmain.user.Project_user)
                'Me.Report6.Export(export, My.Settings.savepath.ToString & "\" &formmain.user.Project_user & "\" &formmain.user.option4 & ".pdf")
                Me.Report_phase1_pfm.Show()
            Case System.Windows.Forms.DialogResult.No
                Dim fichier As String
                fichier = FormMain.user.option4 & ".pdf"

                Dim Chemin As String
                Chemin = My.Settings.savepath.ToString & "\" & FormMain.user.Project_user & "\"
                If Exists(Chemin & fichier) Then
                    Process.Start(Chemin & fichier)
                Else
                    MsgBox("aucune generation existante")
                End If

            Case System.Windows.Forms.DialogResult.Cancel

        End Select
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        'Report_Phase1_equi
        Dim rev As Double
        Dim rev2 As String
        Dim s As DataRowView       '
        Me.Type_docBindingSource.Filter = " Batiment ='" & ComboBox2.Text.ToString & "'"
        Try
            s = CType(Me.Type_docBindingSource.Item(Me.Type_docBindingSource.Find("type_doc", "Programme Particulier d’Essais phase 1 Equipement")), DataRowView)
        Catch ex As Exception
            MsgBox("Aucune reference documentaire existante merci de corriger ...")
            Exit Sub
        End Try


        Select Case MessageBox.Show("Voulez vous generer un nouveau rapport ? ( Cliquer sur oui )" _
   & Microsoft.VisualBasic.ControlChars.CrLf & "Voulez vous consulter la derniere generation ? ( cliquer sur non )" _
   & Microsoft.VisualBasic.ControlChars.CrLf & "Pour quitter cliquer sur Annuler", "Generation d'un raport", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation)

            Case System.Windows.Forms.DialogResult.Yes
                ' Config.EmailSettings.UseMAPI = True
                rev2 = InputBox("Veuillez indiquer la revision du document")

                Me.PreviewControl1.Clear()
                Me.Report_Phase1_equi.Preview = Me.PreviewControl1
                Me.Report_Phase1_equi.Dictionary.Connections.Item(0).ConnectionString = ClassConnectionBuilder.ConnectionStringBuilder(FormMain.user.server, FormMain.user.Project_user, "root", FormMain.user.pass_user)
                Me.Report_Phase1_equi.SetParameterValue("RefDoc", s.Item("reference").ToString)
                Me.Report_Phase1_equi.SetParameterValue("Rev", rev2)
                Me.Report_Phase1_equi.SetParameterValue("Batiment", ComboBox2.Text)
                Me.Report_Phase1_equi.SetParameterValue("Projet", FormMain.user.Project_user)

                Me.Report_Phase1_equi.SetParameterValue("idbat", CInt(Me.ComboBox2.SelectedValue))

                Me.Report_Phase1_equi.SetParameterValue("redacteur", FormMain.user.nom & " " & FormMain.user.Prenom)
                Me.Report_Phase1_equi.Prepare()
                'Dim export As FastReport.Export.Pdf.PDFExport = New FastReport.Export.Pdf.PDFExport()
                'If System.IO.Directory.Exists(My.Settings.savepath.ToString & "\" &formmain.user.Project_user) = False Then System.IO.Directory.CreateDirectory(My.Settings.savepath.ToString & "\" &formmain.user.Project_user)
                'Me.Report6.Export(export, My.Settings.savepath.ToString & "\" &formmain.user.Project_user & "\" &formmain.user.option4 & ".pdf")
                Me.Report_Phase1_equi.Show()
            Case System.Windows.Forms.DialogResult.No
                Dim fichier As String
                fichier = FormMain.user.option4 & ".pdf"

                Dim Chemin As String
                Chemin = My.Settings.savepath.ToString & "\" & FormMain.user.Project_user & "\"
                If Exists(Chemin & fichier) Then
                    Process.Start(Chemin & fichier)
                Else
                    MsgBox("aucune generation existante")
                End If

            Case System.Windows.Forms.DialogResult.Cancel

        End Select
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

    End Sub
End Class