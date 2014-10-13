Imports Ionic.Zip

Imports System.Threading
Imports System.IO

Public Class Form1

    Private Sub MyExtract()
        Dim sPathName As String = Application.StartupPath
        Dim di As New DirectoryInfo(sPathName)
        Dim fi As FileInfo() = di.GetFiles("*.TMP")
        Dim fiTemp As FileInfo
        For Each fiTemp In fi
            File.Delete(sPathName & fiTemp.Name)
        Next fiTemp

        Dim Overwrite As ExtractExistingFileAction = ExtractExistingFileAction.OverwriteSilently
        Dim ZipToUnpack As String = "debug.zip"
        Dim UnpackDirectory As String = Application.StartupPath
        TextBox1.Text = String.Format("Extracting file {0} to {1}", ZipToUnpack, UnpackDirectory)
        Using zip1 As ZipFile = ZipFile.Read(ZipToUnpack)
            AddHandler zip1.ExtractProgress, AddressOf MyExtractProgress
            Dim e As ZipEntry
            For Each e In zip1
                e.Extract(UnpackDirectory, ExtractExistingFileAction.OverwriteSilently)
                addTexte(String.Format("Extracting: {0}", e.FileName.ToString))
            Next

        End Using

        IO.File.Delete(UnpackDirectory & "\" & ZipToUnpack)
        Dim launchProc As String
        launchProc = Application.StartupPath & "\progelec.exe "
        Me.Close()
        Shell(launchProc, AppWinStyle.NormalFocus)

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Me.Button1.Text = " Application en cours "
        Me.Button1.Enabled = False
        MyExtract()
    End Sub
    Private Shared justHadByteUpdate As Boolean = False
    Public Sub addTexte(text As String)
        Me.TextBox1.Text += Environment.NewLine + "  " + text
    End Sub
    Public Sub MyExtractProgress(ByVal sender As Object, ByVal e As ExtractProgressEventArgs)

        If (e.EventType = ZipProgressEventType.Extracting_EntryBytesWritten) Then
            If Form1.justHadByteUpdate Then
                ' Console.SetCursorPosition(0, Console.CursorTop)
            End If
            addTexte(String.Format("Extracting: {0}", e.CurrentEntry.FileName))
            'addTexte(String.Format("   {0}/{1} ({2:N0}%)", e.BytesTransferred, e.TotalBytesToTransfer, (CDbl(e.BytesTransferred) / (0.01 * e.TotalBytesToTransfer))))
            ' Console.Write("   {0}/{1} ({2:N0}%)", e.BytesTransferred, e.TotalBytesToTransfer, (CDbl(e.BytesTransferred) / (0.01 * e.TotalBytesToTransfer)))
            Form1.justHadByteUpdate = True
        ElseIf (e.EventType = ZipProgressEventType.Extracting_BeforeExtractEntry) Then
            If Form1.justHadByteUpdate Then
                'Console.WriteLine()
            End If
            addTexte(String.Format("Extracting: {0}", e.CurrentEntry.FileName))
            'Console.WriteLine("Extracting: {0}", e.CurrentEntry.FileName)
            Form1.justHadByteUpdate = False
        End If
    End Sub
    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        RichTextBox1.SelectionAlignment = HorizontalAlignment.Center
    End Sub

End Class