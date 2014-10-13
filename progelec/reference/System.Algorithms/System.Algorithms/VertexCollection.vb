Namespace Dijkstra

    ''' <summary>
    ''' Represents a colleciton of Vertex objects.
    ''' </summary>
    Public Class VertexCollection
        Inherits BaseCollection(Of Vertex)

        '//properties
        ''' <summary>
        ''' Gets the first Vertex in the collection with the specified key.
        ''' </summary>
        ''' <param name="key">The key of the vertex to retrieve.</param>
        Default Public Overloads ReadOnly Property Item(ByVal key As String) As Vertex
            Get
                For Each vertex As Vertex In Me
                    If vertex.Key.Equals(key) Then
                        Return vertex
                    End If
                Next
                Return Nothing
            End Get
        End Property

        ''' <summary>
        ''' Gets a value indicating whether this collection's verticies are all visited.
        ''' </summary>
        Public ReadOnly Property Finished() As Boolean
            Get
                For Each vertex As Vertex In Me
                    If Not vertex.Visited Then
                        Return False
                    End If
                Next
                Return True
            End Get
        End Property

        '//constructors
        Friend Sub New(ByVal graph As Graph)
            MyBase.New(graph)
        End Sub

        '//methods
        ''' <summary>
        ''' Gets a value that indicates whether an element with the specified key exists in the collection.
        ''' </summary>
        ''' <param name="key">The key to search for.</param>
        Public Function ContainsKey(ByVal key As String) As Boolean
            Return Me(key) IsNot Nothing
        End Function

        ''' <summary>
        ''' Gets thezero-based index of the first element with the specified key.
        ''' </summary>
        ''' <param name="key">The key to search for.</param>
        Public Overloads Function IndexOfKey(ByVal key As String) As Integer
            Dim vertex = Me.Item(key)
            If vertex IsNot Nothing Then
                Return MyBase.IndexOf(vertex)
            End If
            Return -1
        End Function

    End Class

End Namespace