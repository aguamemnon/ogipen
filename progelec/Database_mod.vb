Imports progelec.My.Resources
Imports MySql.Data
Imports MySql.Data.MySqlClient

Module DatabaseMod
    Public BasePrincipale As DataSet = New DataSet
    Public BaseAdaptateur As MySqlDataAdapter = New MySqlDataAdapter
    Dim connection As MySqlConnection = New MySqlConnection()
    ''' <summary>
    ''' Dbs the open.
    ''' </summary>
    'Public Sub DbOpen()
    '    Dim connectionString As String = My.Settings.DbCon
    '    Try

    '        connection.ConnectionString = connectionString
    '        connection.Open()
    '        Const commande As String = "select * from cables"
    '        BaseAdaptateur.SelectCommand = New MySqlCommand(commande, connection)
    '        BaseAdaptateur.Fill(BasePrincipale, "cables")

    '    Catch ex As Exception
    '        MessageBox.Show(DatabaseMod_DbOpen_Erreur_survenue_lors_de_la_connection_à_la_Db & ex.Message, DatabaseMod_DbOpen_Erreur)
    '    End Try

    'End Sub
    Public Sub Test()
        BasePrincipale.Tables.Item("cables").Rows(5).Item("repere cable") = "test"

        BaseAdaptateur.Update(BasePrincipale.Tables.Item("cables"))

    End Sub
    Public Sub DbClose()
        connection.Close()
    End Sub
End Module