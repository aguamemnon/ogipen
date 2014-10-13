Namespace Dijkstra

    ''' <summary>
    ''' Represents the base collection.
    ''' </summary>
    ''' <typeparam name="T">The type of element.</typeparam>
    Public MustInherit Class BaseCollection(Of T)
        Inherits ReadOnlyCollectionBase

        '//properties
        ''' <summary>
        ''' Gets the element at the specified index.
        ''' </summary>
        ''' <param name="index">The index of the element to retrieve.</param>
        Default Public Overridable Overloads ReadOnly Property Item(ByVal index As Integer) As T
            Get
                Return CType(MyBase.InnerList.Item(index), T)
            End Get
        End Property

        Private _graph As Graph
        ''' <summary>
        ''' Gets the Graph that contains the current instance.
        ''' </summary>
        Public ReadOnly Property Graph() As Graph
            Get
                Return Me._graph
            End Get
        End Property

        '//constructors
        Friend Sub New(ByVal graph As Graph)
            If graph Is Nothing Then
                Throw New ArgumentNullException("graph")
            End If
            Me._graph = graph
        End Sub

        '//methods
        Friend Overridable Sub Add(ByVal element As T)
            MyBase.InnerList.Add(element)
            Me.Graph.NotifyRecalculate()
        End Sub

        Friend Overridable Sub Remove(ByVal element As T)
            MyBase.InnerList.Remove(element)
            Me.Graph.NotifyRecalculate()
        End Sub

        Friend Overridable Sub Clear()
            MyBase.InnerList.Clear()
        End Sub

        ''' <summary>
        ''' Gets a value that indicates whether the specified element exists in the collection.
        ''' </summary>
        ''' <param name="element">The element to look for.</param>
        Public Overridable Function Contains(ByVal element As T) As Boolean
            Return MyBase.InnerList.Contains(element)
        End Function

        ''' <summary>
        ''' Retrieves the zero-based index of the specified element.
        ''' </summary>
        ''' <param name="element">The element to get the index for.</param>
        Public Overridable Function IndexOf(ByVal element As T) As Integer
            Return MyBase.InnerList.IndexOf(element)
        End Function

    End Class

End Namespace