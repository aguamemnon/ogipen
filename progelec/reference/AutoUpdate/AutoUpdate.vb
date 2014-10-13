Imports System.IO
Imports System.Net
Imports System.Diagnostics
Imports System.Threading

Public Module AutoUpdate
    Private m_RemotePath As String = ""
    Private m_UpdateFileName As String = "Update.txt"
    Private m_ErrorMessage As String = "There was a problem runing the Auto Update."
    Dim MyWebClient As New WebClient

    Public Function UpdateFiles(Optional ByVal AssemblyName As String = "") As Boolean

        Dim updatelst As updatelist
        Dim objet As updatelist
        Dim listing As New Collection
        If RemotePath = "" Then RemotePath = m_RemotePath Else m_RemotePath = RemotePath
        Dim Contents As String = MyWebClient.DownloadString(RemotePath & AssemblyName & "\" & UpdateFileName)
        ' Process the autoupdate
        ' get rid of the line feeds if exists<>
        UpdateFiles = False
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

        Dim myFileVersionInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo("progelec.exe")
        If listing.Contains("progelec.exe") Then
            objet = CType(listing.Item("progelec.exe"), updatelist)

            If GetVersion(myFileVersionInfo.FileVersion) < GetVersion(objet.oldversion) Then
                UpdateFiles = True

            End If
        End If

        Return UpdateFiles
    End Function

    Public Property RemotePath() As String
        Get
            Return m_RemotePath
        End Get
        Set(ByVal value As String)
            m_RemotePath = value
        End Set
    End Property

    Public Property UpdateFileName() As String
        Get
            Return m_UpdateFileName
        End Get
        Set(ByVal value As String)
            m_UpdateFileName = value
        End Set
    End Property

    Public Property ErrorMessage() As String
        Get
            Return m_ErrorMessage
        End Get
        Set(ByVal value As String)
            m_ErrorMessage = value
        End Set
    End Property

    Private Function GetVersion(ByVal Version As String) As String
        Dim x() As String = Split(Version, ".")
        Return String.Format("{0:00000}{1:00000}{2:00000}{3:00000}", Int(x(0)), Int(x(1)), Int(x(2)), Int(x(3)))
    End Function

End Module