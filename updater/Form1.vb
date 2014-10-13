Imports System.Net
Imports System.IO
Imports System.ComponentModel
Public Class Form1
    Dim MyWebClient As New WebClient
    Dim count As Integer
    Dim count2 As Integer
    Dim bw As BackgroundWorker = New BackgroundWorker

    Private Sub Form1_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        bw.WorkerSupportsCancellation = True
        bw.WorkerReportsProgress = True
        AddHandler bw.DoWork, AddressOf bw_DoWork
        AddHandler bw.ProgressChanged, AddressOf bw_ProgressChanged
        AddHandler bw.RunWorkerCompleted, AddressOf bw_RunWorkerCompleted

    End Sub

    Private Sub bw_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs)
        For Each pr As Process In System.Diagnostics.Process.GetProcesses
            If pr.ProcessName = "progelec.exe" Or pr.ProcessName = "progelec.exe*32" Then
                pr.Kill()
            End If
        Next

        Dim updatelst As updatelist
        Dim objet As updatelist
        Dim listing As New Collection
        Dim Contents As String = MyWebClient.DownloadString(remote)
        ' Process the autoupdate
        ' get rid of the line feeds if exists<>
        Contents = Replace(Contents, Chr(Keys.LineFeed), "")
        Dim FileList() As String = Split(Contents, Chr(Keys.Return))
        Contents = ""
        ' Remove all comments and blank lines
        For Each F As String In FileList
            If InStr(F, "'") <> 0 Then F = Strings.Left(F, InStr(F, "'") - 1)
            If F.Trim <> "" Then
                If Contents <> "" Then Contents += Chr(Keys.Return)
                Contents += F.Trim
            End If
        Next
        ' rebuild the file list
        FileList = Split(Contents, Chr(Keys.Return))
        Dim Info() As String = Split(FileList(0), ";")

        For Each F As String In FileList
            updatelst = New updatelist
            Info = Split(F, ";")
            If Info.Length = 1 Then
                updatelst.filename = Info(0).Trim
                updatelst.oldversion = ""
            Else
                updatelst.filename = Info(0).Trim
                updatelst.oldversion = Info(1).Trim
            End If

            listing.Add(updatelst, Info(0).Trim)
        Next

        count = listing.Count
        count2 = 0

        For Each objet In listing

            Try
                Dim Client As WebClient = New WebClient
                ' AddHandler Client.DownloadProgressChanged, AddressOf client_ProgressChanged

                '  AddHandler Client.DownloadFileCompleted, AddressOf client_DownloadCompleted

                Client.DownloadFile(New Uri(remote2 & objet.filename), objet.filename)
                Me.Label1.Text = String.Format("Téléchargement en cours... {0} / {1}", count2, count)
                count2 += 1
                bw.ReportProgress(CInt(count2 / count * 100))

            Catch exception1 As Exception

                '  MessageBox.Show("Téléchargement Echoué !")

                ' LabelX1.Text = "Téléchargement Terminé !"

            End Try

        Next

        If System.IO.Directory.Exists(Application.StartupPath & "\update") = False Then System.IO.Directory.CreateDirectory(Application.StartupPath & "\update")
        '   For Each objet In listing

        '  File.Delete(Application.StartupPath & "\" & objet.filename)

        ' File.Copy(Application.StartupPath & "\update\" & objet.filename, Application.StartupPath & "\" & objet.filename)
        ' File.Move(Application.StartupPath & "\update\" & objet.filename, Application.StartupPath & "\" & objet.filename)
        '  Next

        ' For Each objet In listing

        ' File.Delete(Application.StartupPath & "\" & objet.filename)

        ' File.Copy(Application.StartupPath & "\update\" & objet.filename, Application.StartupPath & "\" & objet.filename)
        '  File.Move(Application.StartupPath & "\update\" & objet.filename, Application.StartupPath & "\" & objet.filename)
        ' Next

        '  Application.DoEvents()

        If Environment.Is64BitOperatingSystem Then

            Dim launchProc As String
            launchProc = Application.StartupPath & "\progelec.exe"
            Shell(launchProc, AppWinStyle.NormalFocus)
        Else

            Dim proc As New System.Diagnostics.Process()

            proc.StartInfo.FileName = Application.StartupPath & "\progelec.exe"

            proc.Start()

        End If

    End Sub
    Private Sub bw_ProgressChanged(ByVal sender As Object, ByVal e As ProgressChangedEventArgs)
        ' Me.ProgressBarX1.Text = e.ProgressPercentage.ToString() & "%"
        Me.ProgressBar1.Value = e.ProgressPercentage
    End Sub
    Private Sub bw_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs)
        If e.Cancelled = True Then
            MsgBox("Mise à jour annulée")
            Application.Exit()
        ElseIf e.Error IsNot Nothing Then
            MsgBox("Error: " & e.Error.Message)
            Application.Exit()
        Else
            '   MsgBox("Mise à jour compléte")
            Application.Exit()
        End If
    End Sub

    Private Sub ButtonX1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Me.Button1.Enabled = False
        If Not bw.IsBusy = True Then
            bw.RunWorkerAsync()
        End If
    End Sub
End Class