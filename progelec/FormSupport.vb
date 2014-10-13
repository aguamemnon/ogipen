Public Class FormSupport
    Private Sub WebBrowser1_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        'Part 2: Locate the Username TextBox and automatically input your username
        '<INPUT class=yreg_ipt id=username maxLength=96 size=17 name=login>
        Dim theElementCollection As HtmlElementCollection = WebBrowser1.Document.GetElementsByTagName("Input")
        For Each curElement As HtmlElement In theElementCollection
            Dim controlName As String = curElement.GetAttribute("id").ToString
            If controlName = "username" Then
                curElement.SetAttribute("Value", "user")
            End If
        Next

        'Part 3: Locate the Password TextBox and automatically input your password
        '<INPUT class=yreg_ipt id=passwd type=password maxLength=64 size=17 value="" name=passwd>
        theElementCollection = WebBrowser1.Document.GetElementsByTagName("Input")
        For Each curElement As HtmlElement In theElementCollection
            Dim controlName As String = curElement.GetAttribute("id").ToString
            If controlName = "password" Then
                curElement.SetAttribute("Value", "bitnami")
            End If
        Next

        'Part 4: Locate the "Sign In" Button and automatically click it
        '<INPUT type=submit value="Sign In" name=.save>
        theElementCollection = WebBrowser1.Document.GetElementsByTagName("Input")
        For Each curElement As HtmlElement In theElementCollection
            If curElement.GetAttribute("value").Equals("Connexion »") Then
                curElement.InvokeMember("click")
                'Javascript has a click method for we need to invoke on the current submit button element.
            End If
        Next
    End Sub
End Class