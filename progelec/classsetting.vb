Imports MySql.Data.MySqlClient
Public Class ClassConnectionBuilder
    Public Shared Function ConnectionStringBuilder(ByRef Server As String, ByRef database As String, _
    ByRef userid As String, ByRef password As String) As String
        Dim sqlConnString As New MySql.Data.MySqlClient.MySqlConnectionStringBuilder() With {
        .Server = Server,
        .Database = database,
        .UserID = userid,
        .Password = password
        }
        Return sqlConnString.ConnectionString
    End Function
End Class