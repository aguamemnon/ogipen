Namespace Dijkstra

    ''' <summary>
    ''' Represents an object that specifies a point in a graph.
    ''' </summary>
    Public Class Vertex

        '//properties
        Private _graph As Graph
        ''' <summary>
        ''' Gets the Graph that contains the Vertex.
        ''' </summary>
        Public ReadOnly Property Graph() As Graph
            Get
                Return Me._graph
            End Get
        End Property

        ''' <summary>
        ''' Gets an array of verticies that are neighbored with the Vertex.
        ''' </summary>
        Public ReadOnly Property Neighbors() As Vertex()
            Get
                Return Me.Graph.Edges.GetNeighbors(Me)
            End Get
        End Property

        ''' <summary>
        ''' Gets the zero-based index of the Vertex in the Graph.
        ''' </summary>
        Public ReadOnly Property Index() As Integer
            Get
                Return Me.Graph.Verticies.IndexOf(Me)
            End Get
        End Property

        Private _key As String
        ''' <summary>
        ''' Gets or sets an identifier for the Vertex.
        ''' </summary>
        Public Property Key() As String
            Get
                Return Me._key
            End Get
            Set(ByVal value As String)
                If Not Object.Equals(value, Me._key) Then
                    Me._key = value
                    Me.Graph.NotifyRecalculate()
                End If
            End Set
        End Property

        Private _visited As Boolean
        ''' <summary>
        ''' Gets a value indicating whether this Vertex has been visited.
        ''' </summary>
        Public ReadOnly Property Visited() As Boolean
            Get
                Return Me._visited
            End Get
        End Property

        Private _distance As Double
        ''' <summary>
        ''' Gets the distance that this Vertex is from the initial Vertex.
        ''' </summary>
        Public ReadOnly Property Distance() As Double
            Get
                Return Me._distance
            End Get
        End Property

        Private _tag As Object
        ''' <summary>
        ''' Gets or sets an object that contains data about the current instance.
        ''' </summary>
        Public Property Tag() As Object
            Get
                Return Me._tag
            End Get
            Set(ByVal value As Object)
                Me._tag = value
            End Set
        End Property

        Private _previousVertex As Vertex
        Friend Property PreviousVertex() As Vertex
            Get
                Return Me._previousVertex
            End Get
            Set(ByVal value As Vertex)
                Me._previousVertex = value
            End Set
        End Property

        '//constructors
        Friend Sub New(ByVal graph As Graph, ByVal key As String)
            Me._graph = graph
            Me._key = key
            Me._distance = Double.PositiveInfinity
        End Sub

        '//methods
        Friend Sub SetDistance(ByVal distance As Double)
            Me._distance = distance
        End Sub

        Friend Sub SetVisited(ByVal visited As Boolean)
            Me._visited = visited
        End Sub

    End Class

End Namespace