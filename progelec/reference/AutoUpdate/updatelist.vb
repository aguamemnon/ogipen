<System.SerializableAttribute(), _
 System.Xml.Serialization.XmlRootAttribute("updatelist")> _
Public Class updatelist
    Private m_filename As String
    Private m_version As String
    Private m_oldversion As String
    Private m_state As Boolean
    Public Sub New()
        MyBase.New()
        Me.m_filename = ""
        Me.m_version = ""
        Me.m_oldversion = ""
    End Sub
    Public Property filename() As String
        Get
            Return Me.m_filename
        End Get
        Set(value As String)
            Me.m_filename = value
        End Set
    End Property
    Public Property version() As String
        Get
            Return Me.m_version
        End Get
        Set(value As String)
            Me.m_version = value
        End Set
    End Property
    Public Property oldversion() As String
        Get
            Return Me.m_oldversion
        End Get
        Set(value As String)
            Me.m_oldversion = value
        End Set
    End Property
    Public Property state() As Boolean
        Get
            Return Me.m_state
        End Get
        Set(value As Boolean)
            Me.m_state = value
        End Set
    End Property
    Public Overloads Sub Fill(ByVal dr As System.Data.SqlClient.SqlDataReader)
        Dim props As System.ComponentModel.PropertyDescriptorCollection = System.ComponentModel.TypeDescriptor.GetProperties(Me)
        Dim i As Integer = 0
        Do While (i < props.Count)
            Dim prop As System.ComponentModel.PropertyDescriptor = props(i)
            If (prop.IsReadOnly <> True) Then
                Try
                    If (dr(prop.Name).Equals(System.DBNull.Value) <> True) Then
                        If (prop.PropertyType.Equals(dr(prop.Name).GetType) <> True) Then
                            prop.SetValue(Me, prop.Converter.ConvertFrom(dr(prop.Name)))
                        Else
                            prop.SetValue(Me, dr(prop.Name))
                        End If
                    End If
                Catch __exception As System.Exception
                End Try
            End If
            i = (i + 1)
        Loop
    End Sub
    Public Overloads Sub Fill(ByVal dr As System.Data.DataRow)
        Dim props As System.ComponentModel.PropertyDescriptorCollection = System.ComponentModel.TypeDescriptor.GetProperties(Me)
        Dim i As Integer = 0
        Do While (i < props.Count)
            Dim prop As System.ComponentModel.PropertyDescriptor = props(i)
            If (prop.IsReadOnly <> True) Then
                Try
                    If (dr(prop.Name).Equals(System.DBNull.Value) <> True) Then
                        If (prop.PropertyType.Equals(dr(prop.Name).GetType) <> True) Then
                            prop.SetValue(Me, prop.Converter.ConvertFrom(dr(prop.Name)))
                        Else
                            prop.SetValue(Me, dr(prop.Name))
                        End If
                    End If
                Catch __exception As System.Exception
                End Try
            End If
            i = (i + 1)
        Loop
    End Sub
    Public Function ToXmlString() As String
        Dim oSerialize As System.Xml.Serialization.XmlSerializer = New System.Xml.Serialization.XmlSerializer(Me.GetType)
        Dim oBuffer As System.IO.MemoryStream = New System.IO.MemoryStream()
        oSerialize.Serialize(oBuffer, Me)
        Dim returnVal As String = System.Text.ASCIIEncoding.ASCII.GetString(oBuffer.ToArray)
        Return returnVal
    End Function
    Public Function FromXmlString(ByVal xml As String) As updatelist
        Dim xs As System.Xml.Serialization.XmlSerializer = New System.Xml.Serialization.XmlSerializer(Me.GetType)
        Dim xtr As System.Xml.XmlTextReader = New System.Xml.XmlTextReader(New System.IO.StringReader(xml))
        Return CType(xs.Deserialize(xtr), updatelist)
    End Function
End Class