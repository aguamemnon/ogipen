' --------------------------------------------------------------------------------------------------------
' File: clsCables.vb
' Author: verhaeghe loic
' Company:
' Date: 06/12/2012
' Purpose: Classe cables liste , calculs et requetes
' --------------------------------------------------------------------------------------------------------

Public Class clsCable

    Private _id As Integer

    Private _repere As String

    Public Property repere() As String
        Get
            Return _repere
        End Get
        Set(ByVal value As String)
            _repere = value
        End Set
    End Property

    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

End Class