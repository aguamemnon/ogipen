Module main
    Dim CommandLineArgs As System.Collections.ObjectModel.ReadOnlyCollection(Of String) = My.Application.CommandLineArgs
    Public remote As String
    Public remote2 As String
    Sub main()
        Dim state As Boolean
        For i As Integer = 0 To CommandLineArgs.Count - 1
            'MessageBox.Show(CommandLineArgs(i))

        Next
        ' remote = "http://127.0.0.1/progelec/progelec/MyUpdate.dat"
        ' remote2 = "http://127.0.0.1/progelec/progelec/"

        remote = CommandLineArgs(0)
        remote2 = CommandLineArgs(1)
        Do While state = False
            For Each pr As Process In System.Diagnostics.Process.GetProcesses
                If pr.ProcessName = "progelec.exe" Or pr.ProcessName = "progelec.exe*32" Then
                    pr.Kill()
                End If
            Next

            For Each pr As Process In System.Diagnostics.Process.GetProcesses
                If pr.ProcessName = "progelec.exe" Or pr.ProcessName = "progelec.exe*32" Then
                    state = False
                Else
                    state = True
                End If
            Next
        Loop
        ' MsgBox("processs kill", MsgBoxStyle.Information)
        Dim frm As Form1
        frm = New Form1
        frm.ShowDialog()

    End Sub
End Module