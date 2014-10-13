Namespace Dijkstra

    ''' <summary>
    ''' Represents a collection of Vertex objects and Edge objects.
    ''' </summary>
    Public Class Graph

        '//fields
        Private needsCalculate As Boolean = True

        '//properties
        Private _verticies As VertexCollection
        ''' <summary>
        ''' Gets the verticies associated with this graph.
        ''' </summary>
        Public ReadOnly Property Verticies() As VertexCollection
            Get
                If Me._verticies Is Nothing Then
                    Me._verticies = New VertexCollection(Me)
                End If
                Return Me._verticies
            End Get
        End Property

        ''' <summary>
        ''' Gets a value that indicates whether all the verticies in the graph are visited.
        ''' </summary>
        Public ReadOnly Property Finished() As Boolean
            Get
                Return Me.Verticies.Finished
            End Get
        End Property

        Private _edges As EdgeCollection
        ''' <summary>
        ''' Gets the edges associated with this graph's verticies.
        ''' </summary>
        Public ReadOnly Property Edges() As EdgeCollection
            Get
                If Me._edges Is Nothing Then
                    Me._edges = New EdgeCollection(Me)
                End If
                Return Me._edges
            End Get
        End Property

        '//methods
        Private Sub Dijkstra(ByVal initialVertex As Vertex)
            If initialVertex Is Nothing Then
                Throw New ArgumentNullException("initialVertex")
            End If
            If Not Me.needsCalculate Then
                Return
            End If
            '//initialize starting values
            For Each vertex As Vertex In Me.Verticies
                vertex.SetDistance(Double.PositiveInfinity)
                vertex.SetVisited(False)
            Next
            initialVertex.SetDistance(0.0R)
            Try
                '//
                Me.Dijkstra(Me, initialVertex)
            Catch ex As Exception
                Throw New AlgorithmException("The graph, vertex, or edges are invalid. Either they are not all connected, or there are edges missing.", ex)
            End Try
        End Sub

        Private Sub Dijkstra(ByVal graph As Graph, ByVal current As Vertex)
            '//loop each neighboring vertex
            For Each neighbor In current.Neighbors
                If Not neighbor.Visited Then
                    '//vertex has not been visited yet
                    Dim edge = graph.Edges(current, neighbor)
                    '//get the distance between the verticies
                    Dim distance = (current.Distance + edge.Distance)
                    '//check if the distance is smaller than it's previous distance
                    If distance < neighbor.Distance Then
                        neighbor.SetDistance(distance)
                        '//sets the vertex that you would follow to get to this neighboring one
                        neighbor.PreviousVertex = current
                    End If
                End If
            Next
            '//mark Vertex visited
            current.SetVisited(True)
            If Not graph.Finished Then
                '//graph has unvisited verticies
                Me.Dijkstra(graph, graph.FindShortestVertex())
            End If
            Me.needsCalculate = False
        End Sub

        Private Function FindShortestVertex() As Vertex
            Dim result As Vertex = Nothing
            Dim min = Double.PositiveInfinity
            '//loop all unvisited verticies to find the vertex that has the smallest distance
            For Each vertex As Vertex In Me.Verticies
                If Not vertex.Visited Then
                    If vertex.Distance < min Then
                        '//set the current smallest vertex
                        min = vertex.Distance
                        result = vertex
                    End If
                End If
            Next
            '//after all distances are evaluated return result
            Return result
        End Function

        ''' <summary>
        ''' Adds a Vertex to the end of the collection.
        ''' </summary>
        ''' <param name="key">The key used as an identifier for the Vertex. Can be null.</param>
        Public Function AddVertex(ByVal key As String) As Vertex
            Dim vertex = New Vertex(Me, key)
            Me.Verticies.Add(vertex)
            Return vertex
        End Function

        ''' <summary>
        ''' Removes the specified Vertex from the collection.
        ''' </summary>
        ''' <param name="vertex">The Vertex to remove.</param>
        Public Sub RemoveVertex(ByVal vertex As Vertex)
            Me.Verticies.Remove(vertex)
        End Sub

        ''' <summary>
        ''' Adds an Edge to the end of the collection.
        ''' </summary>
        ''' <param name="first">The first Vertex for this Edge.</param>
        ''' <param name="second">The second Vertex for this Edge.</param>
        ''' <param name="distance">The distance between the two vertices.</param>
        Public Function AddEdge(ByVal first As Vertex, ByVal second As Vertex, ByVal distance As Double) As Edge
            Dim edge = New Edge(Me, first, second, distance)
            Me.Edges.Add(edge)
            Return edge
        End Function

        ''' <summary>
        ''' Adds an Edge to the end of the collection.
        ''' </summary>
        ''' <param name="firstKey">The key of the first Vertex for this Edge.</param>
        ''' <param name="secondKey">The key of the second Vertex for this Edge.</param>
        ''' <param name="distance">The distance between the two vertices.</param>
        Public Function AddEdge(ByVal firstKey As String, ByVal secondKey As String, ByVal distance As Double) As Edge
            Dim edge = New Edge(Me, Me.Verticies(firstKey), Me.Verticies(secondKey), distance)
            Me.Edges.Add(edge)
            Return edge
        End Function

        ''' <summary>
        ''' Removes the specified Edge from the collection.
        ''' </summary>
        ''' <param name="edge">The Edge to remove.</param>
        Public Sub RemoveEdge(ByVal edge As Edge)
            Me.Edges.Remove(edge)
        End Sub

        ''' <summary>
        ''' Calculates the Graph using the specified Vertex as the starting point.
        ''' </summary>
        ''' <param name="initialVertex">The starting vertex to calculate from.</param>
        Public Sub Calculate(ByVal initialVertex As Vertex)
            Me.Dijkstra(initialVertex)
        End Sub

        ''' <summary>
        ''' Resets the Graph by clearing all verticies and edges.
        ''' </summary>
        Public Sub Reset()
            '//clear all contents
            Me.Verticies.Clear()
            Me.Edges.Clear()
            '//notify graph that it will need to recalculate
            Me.NotifyRecalculate()
        End Sub

        ''' <summary>
        ''' Serializes this Graph to a file.
        ''' </summary>
        ''' <param name="fileName">A string that contains the name of the file.</param>
        Public Sub Save(ByVal fileName As String)

            '//create the document
            Dim doc = <?xml version="1.0" encoding="utf-8"?>
                      <root vertexCount=<%= Me.Verticies.Count %> edgeCount=<%= Me.Edges.Count %>></root>

            '//loop all verticies
            For Each vertex As Vertex In Me.Verticies
                doc.Root.Add(<vertex>
                                 <key><%= vertex.Key %></key>
                             </vertex>)
            Next

            '//loop all edges
            For Each edge As Edge In Me.Edges
                doc.Root.Add(<edge>
                                 <firstKey><%= edge.First.Key %></firstKey>
                                 <secondKey><%= edge.Second.Key %></secondKey>
                                 <distance><%= edge.Distance %></distance>
                             </edge>)
            Next

            '//saves the file
            doc.Save(fileName)
        End Sub

        ''' <summary>
        ''' Creates a new Graph from a file.
        ''' </summary>
        ''' <param name="fileName"></param>
        ''' <remarks></remarks>
        Public Shared Function Load(ByVal fileName As String) As Graph
            '//try to read the Xml file
            Try
                '//load the Xml and create the new graph
                Dim doc = XDocument.Load(fileName)
                Dim graph = New Graph()

                '//get all verticies
                For Each node In doc.<root>.<vertex>
                    graph.AddVertex(node.<key>.Value())
                Next

                '//get all edges
                For Each node In doc.<root>.<edge>
                    graph.AddEdge(node.<firstKey>.Value(), node.<secondKey>.Value(), _
                                  Convert.ToDouble(node.<distance>.Value()))
                Next

                Return graph
            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        ''' <summary>
        ''' Gets the shortest distance between two verticies in the graph.
        ''' </summary>
        ''' <param name="initialVertex">The starting vertex to calculate from.</param>
        ''' <param name="endingVertex">The ending Vertex to calculate to.</param>
        Public Function GetDistance(ByVal initialVertex As Vertex, ByVal endingVertex As Vertex) As Double
            Me.Dijkstra(initialVertex)
            Return endingVertex.Distance
        End Function

        ''' <summary>
        ''' Gets a string representation of the shortest path's order of verticies to follow.
        ''' </summary>
        ''' <param name="initialVertex">The starting vertex to calculate from.</param>
        ''' <param name="endingVertex">The ending Vertex to calculate to.</param>
        Public Function GetPath(ByVal initialVertex As Vertex, ByVal endingVertex As Vertex) As String
            Return Me.GetPath(initialVertex, endingVertex, False)
        End Function

        ''' <summary>
        ''' Gets a string representation of the shortest path's order of verticies to follow.
        ''' </summary>
        ''' <param name="initialVertex">The starting vertex to calculate from.</param>
        ''' <param name="endingVertex">The ending Vertex to calculate to.</param>
        ''' <param name="reverse">Indicates whether the direction of the string should start at the end.</param>
        Public Function GetPath(ByVal initialVertex As Vertex, ByVal endingVertex As Vertex, ByVal reverse As Boolean) As String
            Me.Dijkstra(initialVertex)
            Dim verticies = Me.GetVerticies(initialVertex, endingVertex, reverse)
            Dim builder = New Text.StringBuilder()
            For vertex = 0 To verticies.Count - 2
                builder.AppendFormat("{0} -> ", verticies(vertex).Key)
            Next
            builder.Append(verticies(verticies.Count - 1).Key)
            Return builder.ToString()
        End Function

        ''' <summary>
        ''' Gets a System.TimeSpan object that represents the time it takes to calculate the current instance.
        ''' </summary>
        ''' <param name="initialVertex">The Vertex to start the calculation from.</param>
        Public Function GetElapsed(ByVal initialVertex As Vertex) As TimeSpan
            '//notify graph that it will need to recalculate
            Me.NotifyRecalculate()
            '//create the watch object
            Dim watch = Stopwatch.StartNew()
            '//run the algorithm
            Me.Dijkstra(initialVertex)
            '//return results
            watch.Stop()
            Return watch.Elapsed
        End Function

        ''' <summary>
        ''' Gets an array of the verticies that are used for the shortest path.
        ''' </summary>
        ''' <param name="initialVertex">The starting vertex to calculate from.</param>
        ''' <param name="endingVertex">The ending Vertex to calculate to.</param>
        Public Function GetVerticies(ByVal initialVertex As Vertex, ByVal endingVertex As Vertex) As Vertex()
            Return Me.GetVerticies(initialVertex, endingVertex, False)
        End Function

        ''' <summary>
        ''' Gets an array of the verticies that are used for the shortest path.
        ''' </summary>
        ''' <param name="initialVertex">The starting vertex to calculate from.</param>
        ''' <param name="endingVertex">The ending Vertex to calculate to.</param>
        ''' <param name="reverse">Indicates whether the order of the verticies should be from end to start.</param>
        Public Function GetVerticies(ByVal initialVertex As Vertex, ByVal endingVertex As Vertex, ByVal reverse As Boolean) As Vertex()
            Me.Dijkstra(initialVertex)
            Dim current = endingVertex
            Dim verticies = New List(Of Vertex)()
            Do Until current Is Nothing
                verticies.Add(current)
                current = current.PreviousVertex
            Loop
            If Not reverse Then
                verticies.Reverse()
            End If
            Return verticies.ToArray()
        End Function

        Friend Sub NotifyRecalculate()
            Me.needsCalculate = True
        End Sub

    End Class

End Namespace