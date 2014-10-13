Public NotInheritable Class SplashScreen

    'TODO: This form can easily be set as the splash screen for the application by going to the "Application" tab
    '  of the Project Designer ("Properties" under the "Project" menu).

    Private Sub SplashScreen_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Set up the dialog text at runtime according to the application's assembly information.
        ApplicationTitle.Parent = PictureBox1
        Label1.Parent = PictureBox1
        Version.Parent = PictureBox1
        Copyright.Parent = PictureBox1
        'TODO: Customize the application's assembly information in the "Application" pane of the project
        '  properties dialog (under the "Project" menu).

        'Application title
        If My.Application.Info.Title <> "" Then
            ApplicationTitle.Text = My.Application.Info.Title
        Else
            'If the application title is missing, use the application name, without the extension
            ApplicationTitle.Text = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If

        'Format the version information using the text set into the Version control at design time as the
        '  formatting string.  This allows for effective localization if desired.
        '  Build and revision information could be included by using the following code and changing the
        '  Version control's designtime text to "Version {0}.{1:00}.{2}.{3}" or something similar.  See
        '  String.Format() in Help for more information.
        '
        Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build, My.Application.Info.Version.Revision)

        'Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build)

        'Copyright info
        Copyright.Text = My.Application.Info.Copyright
    End Sub

    Private Delegate Sub UpdateProgressDelegate(ByVal msg As String, ByVal percentage As Integer)

    Public Sub UpdateProgress(ByVal msg As String, ByVal percentage As Integer)
        If Me.InvokeRequired Then
            Me.Invoke(New UpdateProgressDelegate(AddressOf UpdateProgress), New Object() {msg, percentage})
        Else
            Me.Label1.Text = msg
            If percentage >= Me.ProgressBarX1.Minimum AndAlso percentage <= Me.ProgressBarX1.Maximum Then
                Me.ProgressBarX1.Value = percentage
            End If
        End If
    End Sub

    Private Sub frmSplashScreen_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint

        Dim rc As New Rectangle(0, 0, Me.ClientRectangle.Width - 1, Me.ClientRectangle.Height - 1)
        e.Graphics.DrawRectangle(Pens.Black, rc)
    End Sub
End Class