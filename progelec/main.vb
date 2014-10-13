Imports MySql.Data
Imports FastReport.Data
Imports System.Threading
Imports MySql.Data.MySqlClient
Imports System.IO.File
Module main
    Private _fichier As String
    Public trc As cls_troncons = New cls_troncons
    Public param1 As Integer
    Public user As Class_User = New Class_User
    Dim out As Boolean
    Dim MysqlConn As MySqlConnection
    Dim ConnectionString As String
    Dim maintenance As Boolean = False

    Sub main()
        '    Dim splash As SplashScreen = CType(My.Application.SplashScreen, SplashScreen)
        '    Try
        '        Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException)
        '        Application.EnableVisualStyles()
        '        Application.SetCompatibleTextRenderingDefault(False)
        '        FastReport.Utils.RegisteredObjects.AddConnection(GetType(MySqlDataConnection))
        '    Catch ex As Exception

        '    End Try
        '    Try
        '        splash.UpdateProgress("Initialisation Configuration ..", 5)
        '        _fichier = "debug.zip"
        '        Dim Chemin As String
        '        Chemin = Application.StartupPath & "\"
        '        If Exists(Chemin & _fichier) Then
        '            Dim launchProc As String
        '            launchProc = Application.StartupPath & "\patcher.exe "
        '            Shell(launchProc, AppWinStyle.NormalFocus)
        '            'Process.Start(Chemin & fichier)
        '            Exit Sub

        '        End If
        '        System.Threading.Thread.Sleep(1500)
        '    Catch ex As Exception
        '        MsgBox("Probleme d'initialisation configuration")
        '        Exit Sub
        '    End Try

        '    out = False
        '    ini_serveur()
        '    Try
        '        splash.UpdateProgress("Test connecxion au serveur ..", 5)
        '        MysqlConn = New MySqlConnection()

        '        MysqlConn.ConnectionString = "server=" & FormMain.user.server & ";" _
        ' & "user id=root;" _
        ' & "password=" & FormMain.user.pass_user & ";" _
        ' & "database=progelec"
        '        Const query As String = "SELECT * FROM maintenance"
        '        Dim reader As MySqlDataReader

        '        Dim cmd As New MySqlCommand(query, MysqlConn)

        '        Try
        '            MysqlConn.Open()

        '            reader = cmd.ExecuteReader()
        '            While reader.Read()

        '                For i As Integer = 0 To reader.FieldCount - 1

        '                    maintenance = reader.GetBoolean("statut")
        '                    Debug.WriteLine(reader.GetValue(i).ToString())
        '                Next
        '            End While

        '            MysqlConn.Close()
        '            System.Threading.Thread.Sleep(1500)
        '        Catch myerror As MySqlException
        '            MessageBox.Show("Une erreur est survenu sur la comunication Clent Serveur Contactez votre administrateur: " & myerror.Message)
        '        Finally
        '            MysqlConn.Dispose()
        '        End Try

        '        MysqlConn.Close()
        '        MysqlConn.Dispose()
        '    Catch myerror As MySqlException

        '    End Try

        '    'If maintenance = True Then
        '    '    MsgBox("La base est en maintenance veuillez revenir plus tard")
        '    '    out = True
        '    'End If
        '    'If out = True Then Exit Sub

        '    Dim AssemblyName As String = "progelec"

        '    AutoUpdate.RemotePath = formmain.user.update

        '    AutoUpdate.UpdateFileName = "MyUpdate.dat"

        '    If AutoUpdate.UpdateFiles(AssemblyName & "/") Then

        '        If Environment.Is64BitOperatingSystem Then
        '            MessageBox.Show("2")
        '            Dim launchProc As String
        '            launchProc = Application.StartupPath & "\updater.exe " & AutoUpdate.RemotePath & AssemblyName & "/" & AutoUpdate.UpdateFileName & " " & AutoUpdate.RemotePath & AssemblyName & "/"
        '            Shell(launchProc, AppWinStyle.NormalFocus)
        '            out = True
        '        Else

        '            'Instance de la classe Process
        '            Dim proc As New System.Diagnostics.Process()
        '            proc.StartInfo.Arguments = String.Format(" ""{0}"" ""{1}""", AutoUpdate.RemotePath & AssemblyName & "/" & AutoUpdate.UpdateFileName, AutoUpdate.RemotePath & AssemblyName & "/")
        '            proc.StartInfo.FileName = Application.StartupPath & "\updater.exe"

        '            proc.Start()
        '            out = True
        '        End If

        '    End If

        '    If out = True Then Exit Sub

        '    ' AutoUpdate.ErrorMessage = "Une erreur vien de ce produire lors de la mise à jour veuillez recommencer."

        '    'Dim splash As New SplashScreen
        '    'splash.Show()
        '    'splash.Refresh()

        '    My.Settings("ProgelecConnectionString") = ClassConnectionBuilder.ConnectionStringBuilder( formmain.user.server, "progelec", "root", formmain.user.pass_user)
        '    My.Settings.Save()
        '    ' My.Settings.Reload()

        '    System.Threading.Thread.Sleep(3000)
        '    splash.Close()
        '    ' Application.Run(New Form1)

        '    formmain.user.state = False

        '    Dim login As LoginForm
        '    login = New LoginForm
        '    login.ShowDialog()

        '    login.Dispose()
        '    If FormMain.user.state = True Then

        '        Dim formselectproject As FormSelectProject

        '        formselectproject = New FormSelectProject

        '        formselectproject.ShowDialog()
        '        If FormMain.user.state = False Then Exit Sub

        '        My.Settings.runtimeConnectionstring = ClassConnectionBuilder.ConnectionStringBuilder( formmain.user.server, FormMain.user.Project_user, "root", FormMain.user.pass_user)

        '        My.Settings("MydbConnectionString") = ClassConnectionBuilder.ConnectionStringBuilder( formmain.user.server, FormMain.user.Project_user, "root", FormMain.user.pass_user)
        '        My.Settings("mydb") = ClassConnectionBuilder.ConnectionStringBuilder( formmain.user.server, FormMain.user.Project_user, "root", FormMain.user.pass_user)

        '        My.Settings.Save()

        '        formselectproject.Dispose()
        '        FormMain.user.mode = "Consultation"
        '        FormMain.user.detail_modif = ""
        '        FormMain.user.refmodif = ""
        '        GC.Collect()
        '        Dim FormMain As FormMain = New FormMain
        '        FormMain.ShowDialog()

        '    End If

    End Sub

End Module