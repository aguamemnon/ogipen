Imports System.DirectoryServices
Imports System.Threading
Public Class LoginForm

    ' TODO: Insert code to perform custom authentication using the provided username and password
    ' (See http://go.microsoft.com/fwlink/?LinkId=35339).
    ' The custom principal can then be attached to the current thread's principal as follows:
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication.
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.
    Private m_ServerName As String
    Private m_LoginName As String

    Private m_Authenicate As String
    Public Sub ctrl_user(id As String)
        Me.UsersBindingSource.Filter = "identifiant ='" & id & "'"
        If Me.UsersBindingSource.Count = 0 Then
            Me.UsersBindingSource.RemoveFilter()
            Me.UsersBindingSource.AddNew()
            Dim ruser As progelecDataSet.usersRow
            ruser = CType(CType(Me.UsersBindingSource.Current, DataRowView).Row, progelecDataSet.usersRow)
            ruser.identifiant = Me.UsernameTextBox.Text
            ruser.password = Me.PasswordTextBox.Text
            ruser.prenom = FormMain.user.Prenom
            ruser.nom = FormMain.user.nom
            Me.UsersBindingSource.EndEdit()
            Me.UsersTableAdapter.Update(Me.ProgelecDataSet.users)

        End If
    End Sub

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FormMain.user.state = False
        Me.Close()

    End Sub

    Public Function IsLogonValid() As Boolean

        Dim m_LoginName As String
        Dim dirEntry As System.DirectoryServices.DirectoryEntry
        Dim dirSearcher As System.DirectoryServices.DirectorySearcher

        '  lblStatus.Text = "Validating User Account"

        Try
            m_LoginName = Me.UsernameTextBox.Text 'The logged in user ID
            dirEntry = New System.DirectoryServices.DirectoryEntry("LDAP://cfb.fr.cegelec.com/OU=USERS,OU=CSE,OU=FR,DC=cfb,DC=fr,DC=cegelec,DC=com", Me.UsernameTextBox.Text, Me.PasswordTextBox.Text)
            dirSearcher = New System.DirectoryServices.DirectorySearcher(dirEntry)
            dirSearcher.Filter = "(samAccountName=" & m_LoginName & ")"

            'Use the .FindOne() Method to stop as soon as a match is found

            Dim sr As SearchResult = dirSearcher.FindOne()

            If sr Is Nothing Then 'return false if user isn't found
                '  lblStatus.Text = "User authentication failed"
                Return False
            End If

            Dim de As System.DirectoryServices.DirectoryEntry = sr.GetDirectoryEntry()
            FormMain.user.Nom_user = de.Properties("sAMAccountName").Value.ToString()
            FormMain.user.nom = de.Properties("sn").Value.ToString()
            FormMain.user.email = de.Properties("mail").Value.ToString()
            FormMain.user.Prenom = de.Properties("GivenName").Value.ToString()

            '  lblStatus.Text = "User authentication success"
            If CheckBoxX1.Checked Then
                My.Settings.login_user = Me.UsernameTextBox.Text
                My.Settings.login_pass = Me.PasswordTextBox.Text
                My.Settings.login_check = True
                My.Settings.Save()
            End If
            ctrl_user(FormMain.user.Nom_user)
            Return True  'Valid user

        Catch ex As Exception ' return false if exception occurs

            ' lblStatus.Text = "User authentication failed"

            Return False

        End Try

    End Function

    Private Delegate Sub Bouleanstate2(ByVal state As Boolean)
    Private Delegate Sub Bouleanstate(ByVal state As Boolean)
    Private _dataload As Thread
    Private Sub Progbarstart2(ByVal state As Boolean)
        If Me.InvokeRequired Then
            Me.Invoke(New Bouleanstate2(AddressOf Progbarstart2), New Object() {state})
        Else
            If state Then
                Me.CircularProgress1.Visible = True
                Me.CircularProgress1.IsRunning = True
                Me.CircularProgress1.ProgressText = "en cours"
            Else
                Me.CircularProgress1.Visible = False
                Me.CircularProgress1.IsRunning = False
            End If
        End If

    End Sub
    Private Sub closeform()
        Me.Dispose()
    End Sub
    Private Sub Progbarstart(ByVal state As Boolean)
        If Me.InvokeRequired Then
            If Me.IsDisposed Then
                Exit Sub
            Else
                If Not Me.IsDisposed Then Me.Invoke(New Bouleanstate(AddressOf Progbarstart), New Object() {state})
            End If
        Else
            If state Then
                closeform()
            Else
                Me.lblStatus.Text = "Identifiant inconu"
            End If
        End If

    End Sub

    Private Sub Button_Click(sender As System.Object, e As System.EventArgs) Handles OK.Click
        Me.Validate()
        If Me.SuperValidator1.Validate() = False Then
            Exit Sub
        End If
        _dataload = New Thread(AddressOf Dataload)
        _dataload.IsBackground = True
        _dataload.Start()

    End Sub

    Private Sub Dataload()
        Dim t As Bouleanstate2
        t = New Bouleanstate2(AddressOf Progbarstart2)

        t(True)
        Dim t2 As Bouleanstate
        t2 = New Bouleanstate(AddressOf Progbarstart)

        If Me.CheckBoxXModeLocal.Checked = True Then
            If Me.UsernameTextBox.Text = "admin" And Me.PasswordTextBox.Text = "admin" Then
                FormMain.user.Nom_user = Me.UsernameTextBox.Text
                FormMain.user.state = True
                FormMain.user.nom = "administrateur"
                If CheckBoxX1.Checked Then
                    My.Settings.login_user = Me.UsernameTextBox.Text
                    My.Settings.login_pass = Me.PasswordTextBox.Text
                    My.Settings.login_check = True
                    My.Settings.Save()
                End If
                ctrl_user(FormMain.user.Nom_user)
                t(False)
                t2(True)
            End If
        Else
            If Me.IsLogonValid Then
                FormMain.user.Nom_user = Me.UsernameTextBox.Text
                FormMain.user.state = True

                t(False)
                t2(True)
            End If
            ' m_ServerName = "cfb.fr.cegelec.com"
            'm_LoginName = Me.UsernameTextBox.Text
            'm_Authenicate = My.User.Name

        End If
        t2(False)
        t(False)
    End Sub

    Private Sub LoginForm_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Me.Focus()

        'TODO: This line of code loads data into the 'ProgelecDataSet.users' table. You can move, or remove it, as needed.
        Me.UsersTableAdapter.Fill(Me.ProgelecDataSet.users)
        If My.Settings.login_check Then
            Me.UsernameTextBox.Text = My.Settings.login_user
            Me.PasswordTextBox.Text = My.Settings.login_pass
        Else

        End If
    End Sub

End Class