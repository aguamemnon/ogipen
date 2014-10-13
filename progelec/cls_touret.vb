Namespace tourets
    Public Class cls_touret

        Private _numero As String
        Private _lprev As Double
        Private _type As Integer
        Private _section As Integer
        Private _lmax As Double

        Public Property numero() As String
            Get
                Return _numero
            End Get
            Set(ByVal value As String)
                _numero = value
            End Set
        End Property

        Public Property lprev() As Double
            Get
                Return _lprev
            End Get
            Set(ByVal value As Double)
                _lprev = value
            End Set
        End Property

        Public Property type() As Integer
            Get
                Return _type
            End Get
            Set(ByVal value As Integer)
                _type = value
            End Set
        End Property

        Public Property section() As Integer
            Get
                Return _section
            End Get
            Set(ByVal value As Integer)
                _section = value
            End Set
        End Property

        Public Property lmax() As Double
            Get
                Return _lmax
            End Get
            Set(ByVal value As Double)
                _lmax = value
            End Set
        End Property

        Public Sub New(ByVal m_repere As String, ByVal m_type As Integer, ByVal m_section As Integer, ByVal m_lmax As Double)
            lmax = m_lmax
            numero = m_repere
            type = m_type
            section = m_section

        End Sub

    End Class
End Namespace