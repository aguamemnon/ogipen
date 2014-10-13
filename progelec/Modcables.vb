Imports Ludiosoft.ConfigurationFile
Module Modcables
    Public Sub ini_serveur()

        Dim ini As New INIFile

        ini.LoadINI("config.ini")

        ' ini_serveur = ini.GetSection("SECTION=serveur").GetKey("address").value()
        FormMain.user.server = ini.GetSection("SECTION=serveur").GetKey("address").value()
        FormMain.user.update = ini.GetSection("SECTION=update").GetKey("serveur").value()
        FormMain.user.pass_user = ini.GetSection("SECTION=serveur").GetKey("password").value()
    End Sub

End Module