Namespace Dijkstra

    ''' <summary>
    ''' Represents an object that specifies the distance between two vertices.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class Edge

        '//properties
        Private _graph As Graph
        ''' <summary>
        ''' Gets the Graph that contains this Edge.
        ''' </summary>
        Public ReadOnly Property Graph() As Graph
            Get
                Return Me._graph
            End Get
        End Property

        Private _first As Vertex
        ''' <summary>
        ''' Gets the first Vertex of this Edge.
        ''' </summary>
        Public ReadOnly Property First() As Vertex
            Get
                Return Me._first
            End Get
        End Property

        Private _second As Vertex
        ''' <summary>
        ''' Gets the second Vertex of this Edge.
        ''' </summary>
        Public ReadOnly Property Second() As Vertex
            Get
                Return Me._second
            End Get
        End Property

        ''' <summary>
        ''' Gets the zero-based index of the Edge in the Graph.
        ''' </summary>
        Public ReadOnly Property Index() As Integer
            Get
                Return Me.Graph.Edges.IndexOf(Me)
            End Get
        End Property

        Private _distance As Double
        ''' <summary>
        ''' Gets or sets the distance between the two verticies.
        ''' </summary>
        Public Property Distance() As Double
            Get
                Return Me._distance
            End Get
            Set(ByVal value As Double)
                If Not Object.Equals(value, Me._distance) Then
                    Me._distance = value
                    Me.Graph.NotifyRecalculate()
                End If
            End Set
        End Property

        '//constructors
        Friend Sub New(ByVal graph As Graph, ByVal first As Vertex, ByVal second As Vertex)
            Me._graph = graph
            Me._first = first
            Me._second = second
        End Sub

        Friend Sub New(ByVal graph As Graph, ByVal first As Vertex, ByVal second As Vertex, ByVal distance As Double)
            Me.New(graph, first, second)
            Me._distance = distance
        End Sub

    End Class

End Namespace