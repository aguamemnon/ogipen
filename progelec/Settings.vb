Imports System

Namespace My

    Partial Public NotInheritable Class MySettings
        Public WriteOnly Property runtimeConnectionstring As String
            Set(value As String)
                My.Settings("MydbConnectionString") = value
                My.Settings("Mydb") = value
            End Set
        End Property

    End Class

End Namespace