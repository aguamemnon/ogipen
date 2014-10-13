Namespace Dijkstra

    ''' <summary>
    ''' Represents a collection of Edge objects.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class EdgeCollection
        Inherits BaseCollection(Of Edge)

        '//properties
        ''' <summary>
        ''' Gets the first Edge in the collection that contains both of the specified vertices in either the first or second position. See Remarks..
        ''' </summary>
        ''' <param name="first">The first Vertex to look for.</param>
        ''' <param name="second">The second Vertex to look for.</param>
        ''' <remarks>The order of the parameters are interchangable, as in, the search finds an element if the Edge has both of the specified verticies.</remarks>
        Default Public Overloads ReadOnly Property Item(ByVal first As Vertex, ByVal second As Vertex) As Edge
            Get
                For Each edge As Edge In Me
                    If edge.First.Equals(first) Then
                        If edge.Second.Equals(second) Then
                            Return edge
                        End If
                    ElseIf edge.Second.Equals(first) Then
                        If edge.First.Equals(second) Then
                            Return edge
                        End If
                    End If
                Next
                Return Nothing
            End Get
        End Property

        '//constructors
        Friend Sub New(ByVal graph As Graph)
            MyBase.New(graph)
        End Sub

        '//methods
        Friend Function GetNeighbors(ByVal vertex As Vertex) As Vertex()
            Dim verticies = New List(Of Vertex)()
            For Each edge As Edge In Me
                If edge.First.Equals(vertex) Then
                    If Not verticies.Contains(edge.Second) Then
                        verticies.Add(edge.Second)
                    End If
                ElseIf edge.Second.Equals(vertex) Then
                    If Not verticies.Contains(edge.First) Then
                        verticies.Add(edge.First)
                    End If
                End If
            Next
            Return verticies.ToArray()
        End Function

    End Class

End Namespace