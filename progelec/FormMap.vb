Imports System
Imports System.Drawing
Imports System.IO
Imports System.Windows.Forms

Imports Nevron.Diagram
Imports Nevron.Diagram.Maps
Imports Nevron.GraphicsCore
Imports Nevron.Diagram.Extensions
Imports Nevron.Serialization

Public Class FormMap

    'Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    '    NDrawingView1.ViewLayout = ViewLayout.Fit

    '    NDrawingDocument1.Style.FillStyle = New NColorFillStyle(Color.FromArgb(204, 255, 204))
    '    NDrawingDocument1.Style.StrokeStyle = New NStrokeStyle(New NLength(0.75F, NGraphicsUnit.Point), Color.FromArgb(119, 119, 119))
    '    NDrawingDocument1.RoutingManager.Enabled = False
    '    NDrawingDocument1.BridgeManager.Enabled = False
    '    NDrawingDocument1.Bounds = New NRectangleF(0, 0, 500, 500)
    '    NDrawingDocument1.BackgroundStyle.FillStyle = New NColorFillStyle(Color.White)

    '    ' Create the map
    '    Dim m_Map As New NEsriMap()

    '    ' create the COUNTRIES shape file
    '    Dim countries As NEsriShapefile = m_Map.Add(SHAPEFILE_NAME)
    '    countries.NameColumn = "salles"
    '    countries.TextColumn = "salles"

    '    m_Map.Read()
    '    m_Map.Import(NDrawingDocument1, NDrawingDocument1.Bounds)

    '    ' make the Map layer the active layer so that the user can select the map shapes
    '    Dim layerName As String = Path.GetFileNameWithoutExtension(SHAPEFILE_NAME)
    '    Dim mapLayer As NLayer = DirectCast(NDrawingDocument1.Layers.GetChildByName(layerName), NLayer)
    '    NDrawingDocument1.ActiveLayerUniqueId = mapLayer.UniqueId

    '    ' size to visible shapes
    '    NDrawingDocument1.SizeToContent(NDrawingDocument1.AutoBoundsMinSize, NDrawingDocument1.AutoBoundsPadding)
    'End Sub

    '' select the map shape file
    'Private Const SHAPEFILE_NAME As String = "C:\Users\aguamemnon\Desktop\salles.shp"

    Private Sub FormMap_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim Drawing As New NDrawingDocument
        Dim persistencyManager As New NPersistencyManager()
        Drawing = persistencyManager.LoadDrawingFromFile("C:\Users\aguamemnon\Desktop\essais.ndb")

        NDrawingView1.Document = Drawing

    End Sub
End Class