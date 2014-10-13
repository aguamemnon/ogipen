Imports WinSCP
Imports progelec.tourets
Imports DevComponents.DotNetBar

Public Class FormTouretsDetail
    Dim filter As String
    Dim filter2 As String
    Dim filterfull As String
    Public ntouret As Integer = Nothing
    Public mode As Boolean = False
    Dim col1 As New AutoCompleteStringCollection
    Dim listtourets As List(Of cls_touret) = New List(Of cls_touret)
    Private Sub FormTouretsDetail_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        mintouret = 999999
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.lst_cable_mise_touret'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.Lst_cable_mise_touretTableAdapter.Fill(Me.MydbDataSet.lst_cable_mise_touret)
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.documents_has_tourets'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.Documents_has_touretsTableAdapter.Fill(Me.MydbDataSet.documents_has_tourets)
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.lst_cables'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.Lst_cablesTableAdapter.Fill(Me.MydbDataSet.lst_cables)
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.cables'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.CablesTableAdapter.Fill(Me.MydbDataSet.cables)
        '  RemoveHandler ComboBoxEx1.SelectedValueChanged, AddressOf ComboBoxEx1_SelectedValueChanged
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.donnee_phy'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.Donnee_phyTableAdapter.Fill(Me.MydbDataSet.donnee_phy)
        'TODO: This line of code loads data into the 'MydbDataSet.donnees_cables' table. You can move, or remove it, as needed.
        Me.Donnees_cablesTableAdapter.Fill(Me.MydbDataSet.donnees_cables)
        'TODO: This line of code loads data into the 'MydbDataSet.sections_cables' table. You can move, or remove it, as needed.
        Me.Sections_cablesTableAdapter.Fill(Me.MydbDataSet.sections_cables)
        'TODO: This line of code loads data into the 'MydbDataSet.types_cable' table. You can move, or remove it, as needed.
        Me.Types_cableTableAdapter.Fill(Me.MydbDataSet.types_cable)
        'TODO: This line of code loads data into the 'MydbDataSet.documents' table. You can move, or remove it, as needed.
        Me.DocumentsTableAdapter.Fill(Me.MydbDataSet.documents)
        'TODO: This line of code loads data into the 'MydbDataSet.fournitures_has_documents' table. You can move, or remove it, as needed.
        Me.Fournitures_has_documentsTableAdapter.Fill(Me.MydbDataSet.fournitures_has_documents)
        'TODO: This line of code loads data into the 'MydbDataSet.cables_details_has_tourets' table. You can move, or remove it, as needed.
        Me.Cables_details_has_touretsTableAdapter.Fill(Me.MydbDataSet.cables_details_has_tourets)
        'TODO: This line of code loads data into the 'MydbDataSet.tourets_has_fournitures' table. You can move, or remove it, as needed.
        Me.Tourets_has_fournituresTableAdapter.Fill(Me.MydbDataSet.tourets_has_fournitures)
        'TODO: This line of code loads data into the 'MydbDataSet.tourets' table. You can move, or remove it, as needed.
        Me.TouretsTableAdapter.Fill(Me.MydbDataSet.tourets)
        '  maxtouret = Me.TouretsBindingSource.

        Me.Mise_en_touret_TableAdapter.Fill(MydbDataSet.lst_cable_mise_touret)
        For i = 0 To Me.MydbDataSet.tourets.Rows.Count - 1
            col1.Add(Me.MydbDataSet.tourets.Rows(i)("Repere").ToString())
            If maxtouret < CInt(Me.MydbDataSet.tourets.Rows(i)("idtouret")) Then maxtouret = CInt(Me.MydbDataSet.tourets.Rows(i)("idtouret"))
            If mintouret > CInt(Me.MydbDataSet.tourets.Rows(i)("idtouret")) Then mintouret = CInt(Me.MydbDataSet.tourets.Rows(i)("idtouret"))

        Next
        RepereTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource
        RepereTextBox.AutoCompleteCustomSource = col1
        RepereTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend

        If mode Then
            Me.TouretsBindingSource.AddNew()
            Me.Text = "Nouveau touret .."
        Else

            If Not IsNothing(ntouret) Or ntouret > 0 Then
                Me.TouretsBindingSource.Position = Me.TouretsBindingSource.Find("idtouret", ntouret)
                Me.Donnee_phyBindingSource.Position = Me.Donnee_phyBindingSource.Find("iddonnee", CType(CType(Me.TouretsBindingSource.Current, DataRowView).Row, MydbDataSet.touretsRow).donnees_cables_iddonnee)
                Me.ComboBoxEx1.SelectedValue = CType(CType(Me.TouretsBindingSource.Current, DataRowView).Row, MydbDataSet.touretsRow).donnees_cables_iddonnee

                Me.label4.Text = CType(CType(Me.Donnee_phyBindingSource.Current, DataRowView).Row, MydbDataSet.donnee_phyRow).section
                Me.Text = String.Format("Touret : {0} ..", CType(CType(Me.TouretsBindingSource.Current, DataRowView).Row, MydbDataSet.touretsRow).Repere)
                Try
                    Me.Lst_fourniture_touretTableAdapter.Fill(Me.MydbDataSet.lst_fourniture_touret, New System.Nullable(Of Integer)(CType(ntouret, Integer)))
                Catch ex As System.Exception
                    System.Windows.Forms.MessageBox.Show(ex.Message)
                End Try
            End If
        End If
        '   AddHandler ComboBoxEx1.SelectedValueChanged, AddressOf ComboBoxEx1_SelectedValueChanged
        Try
            Me.Lst_doc_touretTableAdapter.Fill(Me.MydbDataSet.lst_doc_touret, New System.Nullable(Of Integer)(CType(ntouret, Integer)))
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try
        Try
            Me.Lst_cable_touret_poseTableAdapter.Fill(Me.MydbDataSet.lst_cable_touret_pose, New System.Nullable(Of Integer)(CType(ntouret, Integer)))
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try
        long_reel()
        update_debit()

    End Sub

    Private Sub ButtonX2_Click(sender As System.Object, e As System.EventArgs) Handles ButtonX2.Click

        Select Case Me.SwitchButtonDocSelect.Value

            Case True
                'fournitures
                If Not Me.Tourets_has_fournituresBindingSource.Count = 0 Then

                    If test_fichier(Me.TextBox1.Text, "fournitures") Then
                        Dim info As New TaskDialogInfo("AVERTISSEMENT", eTaskDialogIcon.Hand, "Fichier deja existant", "Veuillez renomer le fichier avant envoi ou le document present sur le serveur seras ecrasé  ", eTaskDialogButton.Ok Or eTaskDialogButton.Cancel, eTaskDialogBackgroundColor.Red)

                        Dim result As eTaskDialogResult = TaskDialog.Show(info)
                        Select Case result
                            Case eTaskDialogResult.Cancel
                                Exit Sub

                            Case eTaskDialogResult.Ok

                        End Select
                    Else

                    End If

                    If uploadsftp(Me.TextBox1.Text, "fournitures") = 0 Then

                        Dim row As MydbDataSet.fournitures_has_documentsRow
                        Dim row2 As MydbDataSet.documentsRow
                        Me.Fournitures_has_documentsBindingSource.AddNew()
                        row = CType(CType(Me.Fournitures_has_documentsBindingSource.Current, DataRowView).Row, MydbDataSet.fournitures_has_documentsRow)
                        Me.DocumentsBindingSource.AddNew()
                        row2 = CType(CType(Me.DocumentsBindingSource.Current, DataRowView).Row, MydbDataSet.documentsRow)
                        row2.emplacement = "fournitures"
                        row2.qui = FormMain.user.Nom_user
                        row2._date = Date.Today
                        row2.Nom_doc = Me.TextBox2.Text
                        row2.description = Me.DescriptionTextBox.Text
                        row2.EndEdit()
                        Me.DocumentsBindingSource.EndEdit()
                        Me.DocumentsTableAdapter.Update(MydbDataSet.documents)
                        Me.DocumentsTableAdapter.Fill(MydbDataSet.documents)
                        Me.DocumentsBindingSource.Position = Me.DocumentsBindingSource.Find("Nom_doc", Me.TextBox2.Text)
                        row2 = CType(CType(Me.DocumentsBindingSource.Current, DataRowView).Row, MydbDataSet.documentsRow)
                        row.documents_iddocuments = row2.iddocuments
                        row.fournitures_idfourniture = 356
                        row.EndEdit()
                        Me.Fournitures_has_documentsBindingSource.EndEdit()
                        Me.Fournitures_has_documentsTableAdapter.Update(MydbDataSet.fournitures_has_documents)
                        Me.Fournitures_has_documentsTableAdapter.Fill(MydbDataSet.fournitures_has_documents)
                        Me.ButtonX2.Enabled = False
                        MsgBox("Fichier transfere")
                        Try
                            Me.Lst_doc_touretTableAdapter.Fill(Me.MydbDataSet.lst_doc_touret, New System.Nullable(Of Integer)(CType(ntouret, Integer)))
                        Catch ex As System.Exception
                            System.Windows.Forms.MessageBox.Show(ex.Message)
                        End Try
                    Else
                        MsgBox("une erreure vient de ce produire")
                    End If

                Else
                    MsgBox("Pas de fournitures associé avec ce touret, action impossible")
                End If

                Exit Select
            Case False
                'touret
                If test_fichier(Me.TextBox1.Text, "tourets") Then
                    Dim info As New TaskDialogInfo("AVERTISSEMENT", eTaskDialogIcon.Hand, "Fichier deja existant", "Veuillez renomer le fichier avant envoi ou le document present sur le serveur seras ecrasé  ", eTaskDialogButton.Ok Or eTaskDialogButton.Cancel, eTaskDialogBackgroundColor.Red)

                    Dim result As eTaskDialogResult = TaskDialog.Show(info)
                    Select Case result
                        Case eTaskDialogResult.Cancel
                            Exit Sub

                        Case eTaskDialogResult.Ok

                    End Select
                Else

                End If
                If uploadsftp(Me.TextBox1.Text, "tourets") = 0 Then
                    Dim row As MydbDataSet.documents_has_touretsRow
                    Dim row2 As MydbDataSet.documentsRow
                    Me.Documents_has_touretsBindingSource.AddNew()
                    row = CType(CType(Me.Documents_has_touretsBindingSource.Current, DataRowView).Row, MydbDataSet.documents_has_touretsRow)
                    Me.DocumentsBindingSource.AddNew()
                    row2 = CType(CType(Me.DocumentsBindingSource.Current, DataRowView).Row, MydbDataSet.documentsRow)
                    row2.emplacement = "tourets"
                    row2.qui = FormMain.user.Nom_user
                    row2._date = Date.Today
                    row2.Nom_doc = Me.TextBox2.Text
                    row2.description = Me.DescriptionTextBox.Text
                    row2.EndEdit()
                    Me.DocumentsBindingSource.EndEdit()
                    Me.DocumentsTableAdapter.Update(MydbDataSet.documents)
                    Me.DocumentsTableAdapter.Fill(MydbDataSet.documents)
                    Me.DocumentsBindingSource.Position = Me.DocumentsBindingSource.Find("Nom_doc", Me.TextBox2.Text)
                    row2 = CType(CType(Me.DocumentsBindingSource.Current, DataRowView).Row, MydbDataSet.documentsRow)
                    row.documents_iddocuments = row2.iddocuments
                    row.tourets_idtouret = CType(CType(Me.TouretsBindingSource.Current, DataRowView).Row, MydbDataSet.touretsRow).idtouret
                    row.EndEdit()
                    Me.Documents_has_touretsBindingSource.EndEdit()
                    Me.Documents_has_touretsTableAdapter.Update(MydbDataSet.documents_has_tourets)
                    Me.Documents_has_touretsTableAdapter.Fill(MydbDataSet.documents_has_tourets)
                    Me.ButtonX2.Enabled = False

                    MsgBox("Fichier transfere")
                    Try
                        Me.Lst_doc_touretTableAdapter.Fill(Me.MydbDataSet.lst_doc_touret, New System.Nullable(Of Integer)(CType(ntouret, Integer)))
                    Catch ex As System.Exception
                        System.Windows.Forms.MessageBox.Show(ex.Message)
                    End Try
                Else
                    MsgBox("une erreure vient de ce produire")
                End If

                Exit Select

        End Select

        'If uploadsftp(Me.TextBox1.Text) = 0 Then

        '    MsgBox("Fichier transfere")

        '    If Me.Tourets_has_fournituresBindingSource.Count = 0 Then
        '        Dim row As mydbDataSet.documents_has_touretsRow
        '        Dim row2 As mydbDataSet.documentsRow
        '        Me.Documents_has_touretsBindingSource.AddNew()
        '        row = CType(CType(Me.Documents_has_touretsBindingSource.Current, DataRowView).Row, mydbDataSet.documents_has_touretsRow)
        '        Me.DocumentsBindingSource.AddNew()
        '        row2 = CType(CType(Me.DocumentsBindingSource.Current, DataRowView).Row, mydbDataSet.documentsRow)
        '        row2.emplacement = ""
        '        row2.qui = FormMain.user.Nom_user
        '        row2._date = Date.Today
        '        row2.Nom_doc = Me.TextBox2.Text
        '        row2.EndEdit()
        '        Me.DocumentsBindingSource.EndEdit()
        '        Me.DocumentsTableAdapter.Update(MydbDataSet.documents)
        '        Me.DocumentsTableAdapter.Fill(MydbDataSet.documents)
        '        Me.DocumentsBindingSource.Position = Me.DocumentsBindingSource.Find("Nom_doc", Me.TextBox2.Text)
        '        row2 = CType(CType(Me.DocumentsBindingSource.Current, DataRowView).Row, mydbDataSet.documentsRow)
        '        row.documents_iddocuments = row2.iddocuments
        '        row.tourets_idtouret = CType(CType(Me.TouretsBindingSource.Current, DataRowView).Row, mydbDataSet.touretsRow).idtouret
        '        row.EndEdit()
        '        Me.Documents_has_touretsBindingSource.EndEdit()
        '        Me.Documents_has_touretsTableAdapter.Update(MydbDataSet.documents_has_tourets)
        '        Me.Documents_has_touretsTableAdapter.Fill(MydbDataSet.documents_has_tourets)
        '        Me.ButtonX2.Enabled = False

        '    Else
        '        Dim row As mydbDataSet.fournitures_has_documentsRow
        '        Dim row2 As mydbDataSet.documentsRow
        '        Me.Fournitures_has_documentsBindingSource.AddNew()
        '        row = CType(CType(Me.Fournitures_has_documentsBindingSource.Current, DataRowView).Row, mydbDataSet.fournitures_has_documentsRow)
        '        Me.DocumentsBindingSource.AddNew()
        '        row2 = CType(CType(Me.DocumentsBindingSource.Current, DataRowView).Row, mydbDataSet.documentsRow)
        '        row2.emplacement = ""
        '        row2.qui = FormMain.user.Nom_user
        '        row2._date = Date.Today
        '        row2.Nom_doc = Me.TextBox2.Text
        '        row2.EndEdit()
        '        Me.DocumentsBindingSource.EndEdit()
        '        Me.DocumentsTableAdapter.Update(MydbDataSet.documents)
        '        Me.DocumentsTableAdapter.Fill(MydbDataSet.documents)
        '        Me.DocumentsBindingSource.Position = Me.DocumentsBindingSource.Find("Nom_doc", Me.TextBox2.Text)
        '        row2 = CType(CType(Me.DocumentsBindingSource.Current, DataRowView).Row, mydbDataSet.documentsRow)
        '        row.documents_iddocuments = row2.iddocuments
        '        row.fournitures_idfourniture = 356
        '        row.EndEdit()
        '        Me.Fournitures_has_documentsBindingSource.EndEdit()
        '        Me.Fournitures_has_documentsTableAdapter.Update(MydbDataSet.fournitures_has_documents)
        '        Me.Fournitures_has_documentsTableAdapter.Fill(MydbDataSet.fournitures_has_documents)
        '        Me.ButtonX2.Enabled = False
        '    End If

        'Else
        '    MsgBox("une erreure vient de ce produire")
        'End If
    End Sub

    Private Sub ButtonX4_Click(sender As System.Object, e As System.EventArgs) Handles ButtonX4.Click
        Dim fd As OpenFileDialog = New OpenFileDialog()
        Dim strFileName As String

        fd.Title = "Open File Dialog"
        fd.InitialDirectory = "C:\"
        fd.Filter = "All files (*.*)|*.*|All files (*.*)|*.*"
        fd.FilterIndex = 2
        fd.RestoreDirectory = True

        If fd.ShowDialog() = DialogResult.OK Then
            strFileName = fd.FileName
            TextBox1.Text = strFileName
            TextBox2.Text = fd.SafeFileName
            Me.ButtonX2.Enabled = True
        End If
    End Sub
    Public Function uploadsftp(ByVal file As String, ByVal repertoire As String) As Integer
        Try
            ' Setup session options
            Dim sessionOptions As New SessionOptions
            With sessionOptions
                .Protocol = Protocol.Sftp
                .HostName = "10.20.118.201"
                .UserName = "root"
                .Password = "clearos"
                .SshHostKeyFingerprint = "ssh-rsa 2048 d6:20:66:84:bc:da:e1:f2:c1:f9:9e:bc:03:7c:3f:71"

            End With

            Using session As Session = New Session
                ' Connect
                session.Open(sessionOptions)
                'verification du repertoire
                Dim directory As RemoteDirectoryInfo
                Try
                    directory = session.ListDirectory("/var/www/html/progelec/" & FormMain.user.Project_user)
                Catch ex As Exception
                    If IsNothing(directory) Then

                        session.CreateDirectory("/var/www/html/progelec/" & FormMain.user.Project_user)

                    End If

                End Try
                Try
                    directory = session.ListDirectory("/var/www/html/progelec/" & FormMain.user.Project_user & "/" & repertoire)
                Catch ex As Exception
                    If IsNothing(directory) Then

                        session.CreateDirectory("/var/www/html/progelec/" & FormMain.user.Project_user & "/" & repertoire)

                    End If

                End Try

                ' Upload files
                Dim transferOptions As New TransferOptions
                transferOptions.TransferMode = TransferMode.Binary

                Dim transferResult As TransferOperationResult
                transferResult = session.PutFiles(file, "/var/www/html/progelec/" & FormMain.user.Project_user & "/" & repertoire & "/", False, transferOptions)

                ' Throw on any error
                transferResult.Check()

                ' Print results
                Dim transfer As TransferEventArgs
                For Each transfer In transferResult.Transfers
                    Console.WriteLine("Upload of {0} succeeded", transfer.FileName)
                Next
            End Using

            Return 0
        Catch e As Exception
            Console.WriteLine("Error: {0}", e)
            Return 1
        End Try
    End Function
    Public Function test_fichier(ByVal file As String, ByVal repertoire As String) As Boolean
        test_fichier = False
        Try
            ' Setup session options
            Dim sessionOptions As New SessionOptions
            With sessionOptions
                .Protocol = Protocol.Sftp
                .HostName = "10.20.118.201"
                .UserName = "root"
                .Password = "clearos"
                .SshHostKeyFingerprint = "ssh-rsa 2048 d6:20:66:84:bc:da:e1:f2:c1:f9:9e:bc:03:7c:3f:71"

            End With

            Using session As Session = New Session
                ' Connect
                session.Open(sessionOptions)
                Dim directory As RemoteDirectoryInfo
                Try
                    directory = session.ListDirectory("/var/www/html/progelec/" & FormMain.user.Project_user)
                Catch ex As Exception
                    If IsNothing(directory) Then

                        session.CreateDirectory("/var/www/html/progelec/" & FormMain.user.Project_user)

                    End If

                End Try

                Try
                    directory = session.ListDirectory("/var/www/html/progelec/" & FormMain.user.Project_user & "/" & repertoire)
                Catch ex As Exception
                    If IsNothing(directory) Then

                        session.CreateDirectory("/var/www/html/progelec/" & FormMain.user.Project_user & "/" & repertoire)

                    End If

                End Try

                'verification du repertoire
                Dim directory2 As RemoteDirectoryInfo = session.ListDirectory("/var/www/html/progelec/" & FormMain.user.Project_user & "/" & repertoire)
                Return session.FileExists("/var/www/html/progelec/" & FormMain.user.Project_user & "/" & repertoire & "/" & file)
            End Using

        Catch e As Exception
            Console.WriteLine("Error: {0}", e)
            Return True
        End Try
    End Function

    Public Function downloadsftp(ByVal file As String, ByVal repertoire As String) As Integer
        Try
            ' Setup session options
            Dim sessionOptions As New SessionOptions
            With sessionOptions
                .Protocol = Protocol.Sftp
                .HostName = "10.20.118.201"
                .UserName = "root"
                .Password = "clearos"
                .SshHostKeyFingerprint = "ssh-rsa 2048 d6:20:66:84:bc:da:e1:f2:c1:f9:9e:bc:03:7c:3f:71"

            End With

            Using session As Session = New Session
                ' Connect
                session.Open(sessionOptions)
                'verification du repertoire
                Dim directory As RemoteDirectoryInfo = session.ListDirectory("/var/www/html/progelec/" & FormMain.user.Project_user & "/" & repertoire)

                Dim transferOptions As New TransferOptions
                transferOptions.TransferMode = TransferMode.Binary

                Dim transferResult As TransferOperationResult
                '  transferResult = session.PutFiles(file, "/var/www/html/progelec/" &formmain.user.Project_user & "/tourets/", False, transferOptions)
                transferResult = session.GetFiles("/var/www/html/progelec/" & FormMain.user.Project_user & "/" & repertoire & "/" & file, Application.StartupPath & "\" & file, False, transferOptions)
                ' Throw on any error
                transferResult.Check()

                ' Print results
                Dim transfer As TransferEventArgs
                For Each transfer In transferResult.Transfers
                    Console.WriteLine("Upload of {0} succeeded", transfer.FileName)
                    Dim el As New progelec.ErrorLogger
                    el.WriteToErrorLog(transfer.Error.Message, transfer.FileName, "SFTP")

                Next

                '' Upload files

            End Using

            Return 0
        Catch e As Exception
            Console.WriteLine("Error: {0}", e)
            Return 1
        End Try
    End Function
    Private Sub ButtonX3_Click(sender As System.Object, e As System.EventArgs) Handles ButtonX3.Click
        Dim row2 As MydbDataSet.lst_doc_touretRow

        row2 = CType(CType(Me.Lst_doc_touretBindingSource1.Current, DataRowView).Row, MydbDataSet.lst_doc_touretRow)

        downloadsftp(row2.Nom_doc, row2.emplacement)
        Try
            Process.Start(Application.StartupPath & "\" & row2.Nom_doc)
        Catch ex As Exception
            MsgBox("L'application necessaire à la visualisatrion de ce fichier n'est pas presente sur le systeme , merci de contacter l'administrateur")
        End Try

    End Sub

    Private Sub DocumentsDataGridViewX_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs)
        Dim row2 As MydbDataSet.documentsRow
        row2 = CType(CType(Me.DocumentsBindingSource.Current, DataRowView).Row, MydbDataSet.documentsRow)
        Me.TextBox2.Text = row2.Nom_doc
        Me.TextBox1.Text = Nothing
        Me.ButtonX2.Enabled = False
    End Sub

    Private Sub ButtonX1_Click(sender As System.Object, e As System.EventArgs) Handles ButtonX1.Click
        Dim FormFourni_touret As FormFourni_touret = New FormFourni_touret
        FormFourni_touret.Idtrc = CInt(ntouret)
        FormFourni_touret.ShowDialog()
        'Me.Lst_equip_fournitureTableAdapter.Fill(MydbDataSet.lst_equip_fourniture, CType(value2, Integer?))
    End Sub

    Private Sub ButtonX5_Click(sender As Object, e As EventArgs) Handles ButtonX5.Click
        Me.TouretsBindingSource.EndEdit()
        Me.TouretsTableAdapter.Update(Me.MydbDataSet.tourets)
        If ntouret = 0 Or IsNothing(ntouret) Then
            Me.TouretsBindingSource.Position = Me.TouretsBindingSource.Find("Repere", Me.RepereTextBox.Text)

        End If

    End Sub

    Private Sub ComboBoxEx1_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxEx1.SelectionChangeCommitted
        If Me.Donnee_phyBindingSource.Count > 0 Then
            Me.label4.Text = CType(CType(Me.Donnee_phyBindingSource.Current, DataRowView).Row, MydbDataSet.donnee_phyRow).section
            'filter = String.Format("section= '{0}' and types= '{1}'", CType(CType(Me.Donnee_phyBindingSource.Current, DataRowView).Row, mydbDataSet.donnee_phyRow).section, CType(CType(Me.Donnee_phyBindingSource.Current, DataRowView).Row, mydbDataSet.donnee_phyRow).types)
            'If Not filter2 = "" Then
            '    filterfull = String.Format("{0} and {1}", filter, filter2)
            'Else
            '    filterfull = filter
            'End If
            'Me.Lst_cablesBindingSource.Filter = filterfull

            'Me.Label5.Text = CType(CType(Me.Donnee_phyBindingSource.Current, DataRowView).Row, mydbDataSet.donnee_phyRow).types
        End If

    End Sub

    '    Public Sub creation_tourets()

    '        listtourets.Add(New cls_touret("t1", 1, 1, 500))

    '        listtourets.Add(New cls_touret("t2", 1, 12, 300))
    '        listtourets.Add(New cls_touret("t3", 1, 21, 600))
    '        listtourets.Add(New cls_touret("t5", 1, 1, 500))
    '        ListViewEx.Items.Clear()
    '        ListViewEx.Items.Add("For Each Example")
    '        ListViewEx.Items.Add("-----------------------")
    '        listtourets.ForEach(AddressOf displayBottle)

    '    End Sub
    '    Public Sub displayBottle(ByVal b As cls_touret)
    '        ListViewEx.Items.Add(b.numero & " - " & b.type & " - " & b.section & " - " & b.lmax)
    '    End Sub
    '#End Region

    '    Private Sub btnTest_Click(sender As Object, e As EventArgs)
    '        creation_tourets()
    '    End Sub

    '    Private Sub btnAdd_Click(sender As Object, e As EventArgs)
    '        listtourets.Add(New cls_touret("t33", 1, 1, 500))
    '        ListViewEx.Items.Clear()
    '        ListViewEx.Items.Add("For Each Example")
    '        ListViewEx.Items.Add("-----------------------")
    '        listtourets.ForEach(AddressOf displayBottle)
    '    End Sub

    Private Sub DataGridViewX_MouseDown(sender As Object, e As MouseEventArgs) Handles Lst_cable_mise_touretDataGridViewX.MouseDown
        Dim Index As Integer
        Index = Lst_cable_mise_touretDataGridViewX.HitTest(e.X, e.Y).RowIndex
        If Index > -1 Then
            'Pass the Index as "Data" argument of the DoDragDrop Function
            Me.Lst_cable_mise_touretDataGridViewX.Rows(Index).Selected = True
            '  DataGridViewX.DoDragDrop(Index, DragDropEffects.Move)
            Lst_cable_mise_touretDataGridViewX.DoDragDrop(Lst_cable_mise_touretDataGridViewX.SelectedRows(0), DragDropEffects.All)
        End If
        'If DataGridViewX.SelectedRows.Count = 0 Then
        '    Exit Sub
        'End If

    End Sub
    Dim total As Integer

    Private Sub DataGridViewX1_DragDrop(sender As Object, e As DragEventArgs) Handles DataGridViewX1.DragDrop
        Try
            Dim r As DataGridViewRow = CType(e.Data.GetData(GetType(DataGridViewRow)), DataGridViewRow)
            ' MsgBox(r.Cells(20).Value)
            'verif cable deja associé

            'verif capabilité touret
            Dim row As MydbDataSet.touretsRow

            row = CType(CType(Me.TouretsBindingSource.Current, DataRowView).Row, MydbDataSet.touretsRow)

            If Not row.IsLong_estimeNull Then
                total = CInt(CInt(row.Long_estime) + (CInt(r.Cells(7).Value) / 1000))
            Else
                total = CInt(CInt(r.Cells(7).Value) / 1000)
            End If

            If Not Me.Tourets_has_fournituresBindingSource.Count = 0 Then
                'si fourniture
                If total < CInt(Me.TextBox3.Text) Then

                    Dim rooww As MydbDataSet.cables_details_has_touretsRow

                    Me.Cables_details_has_touretsBindingSource.AddNew()
                    rooww = CType(CType(Me.Cables_details_has_touretsBindingSource.Current, DataRowView).Row, MydbDataSet.cables_details_has_touretsRow)
                    rooww.cables_details_idcables_details = CInt(r.Cells(5).Value)
                    rooww.tourets_idtouret = ntouret
                    Me.Cables_details_has_touretsBindingSource.EndEdit()
                    Me.Cables_details_has_touretsTableAdapter.Update(MydbDataSet.cables_details_has_tourets)

                    Me.Cables_details_has_touretsTableAdapter.Fill(MydbDataSet.cables_details_has_tourets)
                    row.BeginEdit()
                    If row.IsLong_estimeNull Then
                        row.Long_estime = CDec(total)
                    Else
                        row.Long_estime = CDec(total)
                    End If

                    Me.TouretsBindingSource.EndEdit()
                    Me.TouretsTableAdapter.Update(MydbDataSet.tourets)

                Else
                    MsgBox("touret Plein")
                End If

            Else
                'pas de fourniture

                If total < CInt(Me.TextBox6.Text) Then
                    Dim rooww As MydbDataSet.cables_details_has_touretsRow

                    Me.Cables_details_has_touretsBindingSource.AddNew()
                    rooww = CType(CType(Me.Cables_details_has_touretsBindingSource.Current, DataRowView).Row, MydbDataSet.cables_details_has_touretsRow)
                    rooww.cables_details_idcables_details = CInt(r.Cells(5).Value)
                    rooww.tourets_idtouret = ntouret
                    Me.Cables_details_has_touretsBindingSource.EndEdit()
                    Me.Cables_details_has_touretsTableAdapter.Update(MydbDataSet.cables_details_has_tourets)

                    Me.Cables_details_has_touretsTableAdapter.Fill(MydbDataSet.cables_details_has_tourets)

                    row.BeginEdit()
                    If row.IsLong_estimeNull Then
                        row.Long_estime = CDec(total)
                    Else
                        row.Long_estime = CDec(total)
                    End If

                    Me.TouretsBindingSource.EndEdit()
                    Me.TouretsTableAdapter.Update(MydbDataSet.tourets)

                Else
                    MsgBox("touret Plein")

                End If

            End If

            'ajout cables si ok

            'maj logueur touret

            ' Me.TouretsTableAdapter.Fill(MydbDataSet.tourets)

            'ajout filtre sur dataggrid
            Me.Lst_cable_mise_touretTableAdapter.Fill(MydbDataSet.lst_cable_mise_touret)
            Me.Lst_cable_mise_touretBindingSource.Filter = "section='" & Me.label4.Text & "' and types='" & Me.ComboBoxEx1.Text & "' and Touret_def is null"
            '
            Me.Mise_en_touret_TableAdapter.Fill(MydbDataSet.lst_cable_mise_touret)
            Me.Mise_en_touret.Filter = "Touret_def ='" & Me.RepereTextBox.Text & "'"
        Catch ex As Exception

        End Try
    End Sub

    Private Sub long_reel()
        Me.Tourets_has_fournituresBindingSource.Filter = "tourets_idtouret='" & ntouret & "'"
        If Not Me.Tourets_has_fournituresBindingSource.Count = 0 Then
            Dim rows As MydbDataSet.lst_fourniture_touretRow
            rows = CType(CType(Me.Lst_fourniture_touretBindingSource.Current, DataRowView).Row, MydbDataSet.lst_fourniture_touretRow)
            Me.TextBox3.Text = rows.Longueur.ToString

        End If
    End Sub

    Private Sub DataGridViewX1_DragEnter(sender As Object, e As DragEventArgs) Handles DataGridViewX1.DragEnter
        e.Effect = DragDropEffects.Copy
    End Sub

    'Private Sub SuperTabItem3_Click(sender As Object, e As EventArgs) Handles SuperTabItem3.Click
    '  update_cable

    'End Sub

    Private Sub ButtonX_Click(sender As Object, e As EventArgs) Handles ButtonX.Click
        Dim rom As MydbDataSet.lst_cable_mise_touretRow
        If Me.Mise_en_touret.Count > 0 Then
            Dim row As MydbDataSet.touretsRow

            row = CType(CType(Me.TouretsBindingSource.Current, DataRowView).Row, MydbDataSet.touretsRow)

            rom = CType(CType(Me.Mise_en_touret.Current, DataRowView).Row, MydbDataSet.lst_cable_mise_touretRow)
            Me.Cables_details_has_touretsBindingSource.Position = Me.Cables_details_has_touretsBindingSource.Find("cables_details_idcables_details", rom.idcables_details)

            If Not row.IsLong_estimeNull Then
                total = CInt(CInt(row.Long_estime) - (CInt(rom.longueur) / 1000))

            End If
            row.BeginEdit()
            If Not Me.Tourets_has_fournituresBindingSource.Count = 0 Then

                'si fourniture
                If total < CInt(Me.TextBox3.Text) Then
                    If row.IsLong_estimeNull Then
                        row.Long_estime = CDec(total)
                    Else
                        row.Long_estime = CDec(total)
                    End If
                End If
            Else

                If total < CInt(Me.TextBox6.Text) Then
                    If row.IsLong_estimeNull Then
                        row.Long_estime = CDec(total)
                    Else
                        row.Long_estime = CDec(total)
                    End If

                End If

            End If

            Me.TouretsBindingSource.EndEdit()
            Me.TouretsTableAdapter.Update(MydbDataSet.tourets)
            Me.Cables_details_has_touretsBindingSource.RemoveCurrent()
            Me.Cables_details_has_touretsTableAdapter.Update(MydbDataSet.cables_details_has_tourets)
            Me.Cables_details_has_touretsTableAdapter.Fill(MydbDataSet.cables_details_has_tourets)
            Me.Mise_en_touret_TableAdapter.Fill(MydbDataSet.lst_cable_mise_touret)
        End If
    End Sub

    Public Sub update_debit()
        Dim totaldeb As Double = 0.0

        For Each row In Me.Lst_cable_touret_poseBindingSource
            Dim rows As MydbDataSet.lst_cable_touret_poseRow
            rows = CType(CType(row, DataRowView).Row, MydbDataSet.lst_cable_touret_poseRow)
            totaldeb += CDbl(rows.longueur)

        Next
        Me.TextBox5.Text = CStr(CDbl(totaldeb) / 1000)
    End Sub

    Private Sub ButtonX6_Click(sender As Object, e As EventArgs) Handles ButtonX6.Click

        Dim row As MydbDataSet.lst_doc_touretRow
        row = CType(CType(Me.Lst_doc_touretBindingSource1.Current, DataRowView).Row, MydbDataSet.lst_doc_touretRow)

        If Me.Fournitures_has_documentsBindingSource.Find("documents_iddocuments", row.iddocuments) <> -1 Then
            Me.Fournitures_has_documentsBindingSource.Position = Me.Fournitures_has_documentsBindingSource.Find("documents_iddocuments", row.iddocuments)
            Me.Fournitures_has_documentsBindingSource.RemoveCurrent()
            Me.Fournitures_has_documentsTableAdapter.Update(MydbDataSet.fournitures_has_documents)
        End If
        If Me.Documents_has_touretsBindingSource.Find("documents_iddocuments", row.iddocuments) <> -1 Then
            Me.Documents_has_touretsBindingSource.Position = Me.Documents_has_touretsBindingSource.Find("documents_iddocuments", row.iddocuments)
            Me.Documents_has_touretsBindingSource.RemoveCurrent()
            Me.Documents_has_touretsBindingSource.EndEdit()
            Me.Documents_has_touretsTableAdapter.Update(MydbDataSet.documents_has_tourets)
        End If
        If Me.DocumentsBindingSource.Find("iddocuments", row.iddocuments) <> -1 Then
            Me.DocumentsBindingSource.Position = Me.DocumentsBindingSource.Find("iddocuments", row.iddocuments)
            Me.DocumentsBindingSource.RemoveCurrent()
            Me.DocumentsTableAdapter.Update(MydbDataSet.documents)
        End If
        Me.Documents_has_touretsTableAdapter.Fill(MydbDataSet.documents_has_tourets)
        Me.Fournitures_has_documentsTableAdapter.Fill(MydbDataSet.fournitures_has_documents)
        Me.DocumentsTableAdapter.Fill(MydbDataSet.documents)
        Me.Lst_doc_touretTableAdapter.Fill(MydbDataSet.lst_doc_touret, ntouret)

    End Sub

    Private Sub SuperTabControl1_SelectedTabChanged(sender As Object, e As SuperTabStripSelectedTabChangedEventArgs) Handles SuperTabControl1.SelectedTabChanged
        update_cable()
    End Sub

    Private Sub ButtonX7_Click(sender As Object, e As EventArgs) Handles ButtonX7.Click
        If ntouret > mintouret Then
            RemoveHandler SuperTabControl1.SelectedTabChanged, AddressOf SuperTabControl1_SelectedTabChanged

            ntouret -= 1
            If Not IsNothing(ntouret) Or ntouret > 0 Then
                Me.TouretsBindingSource.Position = Me.TouretsBindingSource.Find("idtouret", ntouret)
                Me.Donnee_phyBindingSource.Position = Me.Donnee_phyBindingSource.Find("iddonnee", CType(CType(Me.TouretsBindingSource.Current, DataRowView).Row, MydbDataSet.touretsRow).donnees_cables_iddonnee)
                Me.ComboBoxEx1.SelectedValue = CType(CType(Me.TouretsBindingSource.Current, DataRowView).Row, MydbDataSet.touretsRow).donnees_cables_iddonnee

                Me.label4.Text = CType(CType(Me.Donnee_phyBindingSource.Current, DataRowView).Row, MydbDataSet.donnee_phyRow).section
                Me.Text = String.Format("Touret : {0} ..", CType(CType(Me.TouretsBindingSource.Current, DataRowView).Row, MydbDataSet.touretsRow).Repere)
                Try
                    Me.Lst_fourniture_touretTableAdapter.Fill(Me.MydbDataSet.lst_fourniture_touret, New System.Nullable(Of Integer)(CType(ntouret, Integer)))
                Catch ex As System.Exception
                    System.Windows.Forms.MessageBox.Show(ex.Message)
                End Try

            End If
            '   AddHandler ComboBoxEx1.SelectedValueChanged, AddressOf ComboBoxEx1_SelectedValueChanged
            Try
                Me.Lst_doc_touretTableAdapter.Fill(Me.MydbDataSet.lst_doc_touret, New System.Nullable(Of Integer)(CType(ntouret, Integer)))
            Catch ex As System.Exception
                System.Windows.Forms.MessageBox.Show(ex.Message)
            End Try
            Try
                Me.Lst_cable_touret_poseTableAdapter.Fill(Me.MydbDataSet.lst_cable_touret_pose, New System.Nullable(Of Integer)(CType(ntouret, Integer)))
            Catch ex As System.Exception
                System.Windows.Forms.MessageBox.Show(ex.Message)
            End Try
            long_reel()
            update_debit()
            AddHandler SuperTabControl1.SelectedTabChanged, AddressOf SuperTabControl1_SelectedTabChanged
            update_cable()
        End If

    End Sub

    Public Sub update_cable()
        If Me.SuperTabControl1.SelectedTab.Text = "Câbles associés" Then
            Me.CircularProgress.Visible = True
            '  Me.TouretsBindingSource.EndEdit()
            Me.TouretsTableAdapter.Update(Me.MydbDataSet.tourets)
            If ntouret = 0 Or IsNothing(ntouret) Then
                If Not IsNothing(Me.RepereTextBox.Text) Or Not Me.RepereTextBox.Text = "" Then
                    Me.TouretsBindingSource.Position = Me.TouretsBindingSource.Find("Repere", Me.RepereTextBox.Text)
                End If
            Else
                Me.TouretsBindingSource.Position = Me.TouretsBindingSource.Find("idtouret", ntouret)
            End If
            Me.CircularProgress.Visible = False

            Me.Lst_cablesBindingSource.Filter = "section='" & Me.label4.Text & "' and types='" & Me.ComboBoxEx1.Text & "'"
            Me.Lst_cable_mise_touretBindingSource.Filter = "section='" & Me.label4.Text & "' and types='" & Me.ComboBoxEx1.Text & "' and Touret_def is null"
            Me.Mise_en_touret.Filter = "Touret_def ='" & Me.RepereTextBox.Text & "'"
        End If
    End Sub
    Dim maxtouret As Integer
    Dim mintouret As Integer

    Private Sub ButtonX8_Click(sender As Object, e As EventArgs) Handles ButtonX8.Click
        If ntouret < maxtouret Then
            RemoveHandler SuperTabControl1.SelectedTabChanged, AddressOf SuperTabControl1_SelectedTabChanged

            ntouret += 1
            If Not IsNothing(ntouret) Or ntouret > 0 Then
                Me.TouretsBindingSource.Position = Me.TouretsBindingSource.Find("idtouret", ntouret)
                Me.Donnee_phyBindingSource.Position = Me.Donnee_phyBindingSource.Find("iddonnee", CType(CType(Me.TouretsBindingSource.Current, DataRowView).Row, MydbDataSet.touretsRow).donnees_cables_iddonnee)
                Me.ComboBoxEx1.SelectedValue = CType(CType(Me.TouretsBindingSource.Current, DataRowView).Row, MydbDataSet.touretsRow).donnees_cables_iddonnee

                Me.label4.Text = CType(CType(Me.Donnee_phyBindingSource.Current, DataRowView).Row, MydbDataSet.donnee_phyRow).section
                Me.Text = String.Format("Touret : {0} ..", CType(CType(Me.TouretsBindingSource.Current, DataRowView).Row, MydbDataSet.touretsRow).Repere)
                Try
                    Me.Lst_fourniture_touretTableAdapter.Fill(Me.MydbDataSet.lst_fourniture_touret, New System.Nullable(Of Integer)(CType(ntouret, Integer)))
                Catch ex As System.Exception
                    System.Windows.Forms.MessageBox.Show(ex.Message)
                End Try

            End If
            '   AddHandler ComboBoxEx1.SelectedValueChanged, AddressOf ComboBoxEx1_SelectedValueChanged
            Try
                Me.Lst_doc_touretTableAdapter.Fill(Me.MydbDataSet.lst_doc_touret, New System.Nullable(Of Integer)(CType(ntouret, Integer)))
            Catch ex As System.Exception
                System.Windows.Forms.MessageBox.Show(ex.Message)
            End Try
            Try
                Me.Lst_cable_touret_poseTableAdapter.Fill(Me.MydbDataSet.lst_cable_touret_pose, New System.Nullable(Of Integer)(CType(ntouret, Integer)))
            Catch ex As System.Exception
                System.Windows.Forms.MessageBox.Show(ex.Message)
            End Try
            long_reel()
            update_debit()
            update_cable()

            AddHandler SuperTabControl1.SelectedTabChanged, AddressOf SuperTabControl1_SelectedTabChanged
        End If
    End Sub
End Class