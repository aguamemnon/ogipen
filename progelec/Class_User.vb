Public Class Class_User
    Private _mode As String

    Public Property mode() As String
        Get
            Return _mode
        End Get
        Set(ByVal value As String)
            _mode = value
        End Set
    End Property

    Private _refmodif As String

    Public Property refmodif() As String
        Get
            Return _refmodif
        End Get
        Set(ByVal value As String)
            _refmodif = value
        End Set
    End Property

    Private _detail_modif As String

    Public Property detail_modif() As String
        Get
            Return _detail_modif
        End Get
        Set(ByVal value As String)
            _detail_modif = value
        End Set
    End Property

    Private _statut_modif As String

    Public Property statut_modif() As String
        Get
            Return _statut_modif
        End Get
        Set(ByVal value As String)
            _statut_modif = value
        End Set
    End Property

    Private _update As String

    Public Property update() As String
        Get
            Return _update
        End Get
        Set(ByVal value As String)
            _update = value
        End Set
    End Property

    Private _server As String

    Public Property server() As String
        Get
            Return _server
        End Get
        Set(ByVal value As String)
            _server = value
        End Set
    End Property

    Private _state As Boolean

    Public Property state() As Boolean
        Get
            Return _state
        End Get
        Set(ByVal value As Boolean)
            _state = value
        End Set
    End Property

    Private _project_user As String

    Private _pass_user As String

    Private _nom_user As String

    Public Property Nom_user() As String
        Get
            Return _nom_user
        End Get
        Set(ByVal value As String)
            _nom_user = value
        End Set
    End Property

    Public Property pass_user() As String
        Get
            Return _pass_user
        End Get
        Set(ByVal value As String)
            _pass_user = value
        End Set
    End Property

    Public Property Project_user() As String
        Get
            Return _project_user
        End Get
        Set(ByVal value As String)
            _project_user = value
        End Set
    End Property

    Public Property Prenom As String
        Get
            Return _Prenom
        End Get
        Set(value As String)
            _Prenom = value
        End Set
    End Property

    Public Property email As String
        Get
            Return _email
        End Get
        Set(value As String)
            _email = value
        End Set
    End Property
    Private _Prenom As String
    Private _email As String

    Public Property option2 As String
        Get
            Return m_field1
        End Get
        Set(ByVal value As String)
            m_field1 = value
        End Set
    End Property
    Private m_field1 As String

    Public Property option3 As String
        Get
            Return m_field2
        End Get
        Set(ByVal value As String)
            m_field2 = value
        End Set
    End Property
    Private m_field2 As String

    Public Property option1 As String
        Get
            Return m_field3
        End Get
        Set(ByVal value As String)
            m_field3 = value
        End Set
    End Property
    Private m_field3 As String
    Private _nom As String

    Public Property nom As String
        Get
            Return _nom
        End Get
        Set(value As String)
            _nom = value
        End Set
    End Property
    Public Property option4 As String
        Get
            Return m_field4
        End Get
        Set(ByVal value As String)
            m_field4 = value
        End Set
    End Property
    Private m_field4 As String
    Public Property profil As String
        Get
            Return m_profil
        End Get
        Set(ByVal value As String)
            m_profil = value
        End Set
    End Property
    Private m_profil As String
End Class