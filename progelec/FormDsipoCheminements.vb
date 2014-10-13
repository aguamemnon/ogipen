Imports System.Text
Imports System.ComponentModel
Imports Microsoft.VisualBasic
Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Controls
Imports DevComponents.DotNetBar.Rendering
Imports DevComponents.DotNetBar.SuperGrid
Imports DevComponents.DotNetBar.SuperGrid.Style

Imports Microsoft.Office.Interop.Excel
Imports Microsoft.Office.Interop


Public Class FormDsipoCheminements
    Private Sub InitializeGrid()
        Dim panel As GridPanel = SuperGridControl.PrimaryGrid

        ' Set both the Slider and SitchButton columns to
        ' our own defined EditControls

        Dim column As GridColumn = panel.Columns("Possible")

        column.EditorType = GetType(MyGridLabelXEditControl)

        column = panel.Columns("statut")
        column.EditorType = GetType(MyGridLabelXEditControl)

        column = panel.Columns("statut1")
        column.EditorType = GetType(MyGridLabelXEditControl)
    End Sub

    Public Sub update_info()
        Dim compte, compte2, compte3, compte4, compte5, compte6 As Double
        Dim row As mydbDataSet.troncons_statusRow
        For Each c In Troncons_statusBindingSource
            Try

                row = CType(CType(c, DataRowView).Row, mydbDataSet.troncons_statusRow)
                If Not IsDBNull(row.temp_de_pose) Then
                    compte += CDbl(row.temp_de_pose)
                    compte2 += 1
                    If Not row.pose Then
                        compte3 += CDbl(row.temp_de_pose)
                    End If

                End If

            Catch ex As Exception
                If ex.Message.EndsWith("DbNull") Then

                End If
            End Try
        Next
        LabelXPoidsTotal.Text = CStr(Math.Round(compte, 2))
        'LabelX3.Text = compte2 & " Cables selectionnés / parcouru "
        'LabelX5.Text = Math.Round(compte3, 2) & " Poid restant"
        LabelX1.Text = Math.Round((compte - compte3) / compte, 3) * 100 & " % avancement"
        LabelX4.Text = CStr(Math.Round((compte - compte3), 2))
    End Sub
    'Private Sub X1salle_Initialize()
    '    Dim bcx As DataGridViewLabelXColumn = TryCast(Troncons_statusDataGridViewX.Columns("Possible"), DataGridViewLabelXColumn)

    '    If bcx IsNot Nothing Then
    '        ' Hook onto the BeforeCellPaint event so we can
    '        ' demonstrate cell customization

    '        AddHandler bcx.BeforeCellPaint, AddressOf X1salle_BeforeCellPaint
    '    End If
    'End Sub
    'Private Sub X1status_Initialize()
    '    Dim bcx As DataGridViewLabelXColumn = TryCast(Troncons_statusDataGridViewX.Columns("status"), DataGridViewLabelXColumn)

    '    If bcx IsNot Nothing Then
    '        ' Hook onto the BeforeCellPaint event so we can
    '        ' demonstrate cell customization

    '        AddHandler bcx.BeforeCellPaint, AddressOf X1status_BeforeCellPaint
    '    End If

    'End Sub
    'Private Sub X1status1_Initialize()
    '    Dim bcx As DataGridViewLabelXColumn = TryCast(Troncons_statusDataGridViewX.Columns("status1"), DataGridViewLabelXColumn)

    '    If bcx IsNot Nothing Then
    '        ' Hook onto the BeforeCellPaint event so we can
    '        ' demonstrate cell customization

    '        AddHandler bcx.BeforeCellPaint, AddressOf X1status1_BeforeCellPaint
    '    End If

    'End Sub
    'Private Sub X1pose_Initialize()
    '    Dim bcx As DataGridViewButtonXColumn = TryCast(Troncons_statusDataGridViewX.Columns("pose"), DataGridViewButtonXColumn)

    '    If bcx IsNot Nothing Then
    '        ' Hook onto the BeforeCellPaint event so we can
    '        ' demonstrate cell customization

    '        AddHandler bcx.BeforeCellPaint, AddressOf X1pose_BeforeCellPaint
    '    End If

    'End Sub
    Private Sub X1salle_BeforeCellPaint(ByVal sender As Object, ByVal e As BeforeCellPaintEventArgs)
        Dim bcx As DataGridViewLabelXColumn = TryCast(sender, DataGridViewLabelXColumn)

        If bcx IsNot Nothing Then
            ' Set the label image

            If String.IsNullOrEmpty(bcx.Text) = True Then
                bcx.Image = ImageList1.Images("blocage2")
                bcx.Text = "<font color=""red"">Salle non dispo</font>"
            ElseIf bcx.Text.Contains("BLOCAGE") Then
                bcx.Image = ImageList1.Images("blocage2")
                bcx.Text = "<font color=""red"">BLOCAGE</font>"
            ElseIf bcx.Text.Contains("FAIT") Then
                bcx.Image = ImageList1.Images("dispo")
                bcx.Text = "<font color=""green"">FAIT</font>"

            ElseIf bcx.Text.Contains("POSSIBLE") Then
                bcx.Image = ImageList1.Images("blocage")
                bcx.Text = "<font color=""orange"">POSSIBLE</font>"
            Else
                bcx.Image = ImageList1.Images("OK")
            End If
        End If

    End Sub
    Private Sub X1pose_BeforeCellPaint(ByVal sender As Object, ByVal e As BeforeCellPaintEventArgs)
        Dim cell As DataGridViewButtonXColumn = TryCast(sender, DataGridViewButtonXColumn)

        If cell IsNot Nothing Or cell.Text <> "" Then
            ' Set the label image

            If cell.Text = "" Then

            ElseIf CBool(cell.Text) = True Then
                cell.ColorTable = eButtonColor.BlueWithBackground
                'cell.Style = Color.Green
            Else

                cell.ColorTable = eButtonColor.OrangeWithBackground

            End If
        End If

    End Sub
    Private Sub X1status_BeforeCellPaint(ByVal sender As Object, ByVal e As BeforeCellPaintEventArgs)
        Dim bcx As DataGridViewLabelXColumn = TryCast(sender, DataGridViewLabelXColumn)

        If bcx IsNot Nothing Then
            ' Set the label image

            If String.IsNullOrEmpty(bcx.Text) = True Then
                bcx.Image = ImageList1.Images("blocage2")
                bcx.Text = "<font color=""red"">Salle non dispo</font>"
            ElseIf bcx.Text.Contains("BLOCAGE") Then
                bcx.Image = ImageList1.Images("blocage2")
                bcx.Text = "<font color=""red"">BLOCAGE</font>"
            ElseIf bcx.Text.Contains("Dispo") Then
                bcx.Image = ImageList1.Images("dispo")
                bcx.Text = "<font color=""green"">Dispo</font>"

            Else
                bcx.Image = ImageList1.Images("blocage2")
            End If
        End If

    End Sub
    Private Sub X1status1_BeforeCellPaint(ByVal sender As Object, ByVal e As BeforeCellPaintEventArgs)
        Dim bcx As DataGridViewLabelXColumn = TryCast(sender, DataGridViewLabelXColumn)

        If bcx IsNot Nothing Then
            ' Set the label image

            If String.IsNullOrEmpty(bcx.Text) = True Then
                bcx.Image = ImageList1.Images("blocage2")
                bcx.Text = "<font color=""red"">Salle non dispo</font>"
            ElseIf bcx.Text.Contains("BLOCAGE") Then
                bcx.Image = ImageList1.Images("blocage2")
                bcx.Text = "<font color=""red"">BLOCAGE</font>"
            ElseIf bcx.Text.Contains("Dispo") Then
                bcx.Image = ImageList1.Images("dispo")
                bcx.Text = "<font color=""green"">Dispo</font>"

            Else
                bcx.Image = ImageList1.Images("blocage2")
            End If
        End If

    End Sub

    Private Sub FormDsipoCheminements_ImeModeChanged(sender As Object, e As System.EventArgs) Handles Me.Load
        'TODO: This line of code loads data into the 'MydbDataSet.troncons' table. You can move, or remove it, as needed.
        Me.TronconsTableAdapter.Fill(Me.MydbDataSet.troncons)
        Me.Troncons_statusTableAdapter.Fill(Me.MydbDataSet.troncons_status)
        'X1salle_Initialize()
        'X1status1_Initialize()
        'X1status_Initialize()
        'X1pose_Initialize()
    End Sub
    'Public Sub New()

    '  ' This call is required by the designer.
    '  InitializeComponent()

    '  InitializeContext
    '  End Sub

    Private Class MyGridLabelXEditControl
        Inherits GridLabelXEditControl
        Public Sub New()

        End Sub

        Public Overrides Sub InitializeContext(ByVal cell As GridCell, ByVal style As CellVisualStyle)
            MyBase.InitializeContext(cell, style)

            If Text IsNot Nothing Then
                Select Case Text
                    Case "BLOCAGE"

                        Image = My.Resources.remove_24_24
                        Exit Select

                    Case "Dispo"

                        Image = My.Resources.up_24_24

                        Exit Select
                    Case Nothing
                        Text = "Attente"
                        Image = My.Resources.warning_24_24
                        Exit Select
                    Case Else

                        Text = "Attente"
                        Image = My.Resources.warning_24_24
                        Exit Select
                End Select
            End If

        End Sub
    End Class

    'Private Sub DataGridViewX1_CellContentClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs)
    '    Dim cell As DataGridViewButtonXCell = TryCast(Troncons_statusDataGridViewX.CurrentCell, DataGridViewButtonXCell)
    '    If cell IsNot Nothing Then
    '        If CBool(cell.Value) Then

    '        Else
    '            Dim row As mydbDataSet.troncons_statusRow
    '            Dim row2 As mydbDataSet.tronconsRow
    '            row = CType(CType(Troncons_statusBindingSource.Current, DataRowView).Row, mydbDataSet.troncons_statusRow)
    '            Me.TronconsBindingSource.Position = Me.TronconsBindingSource.Find("idtroncons", row.idtroncons)
    '            row2 = CType(CType(TronconsBindingSource.Current, DataRowView).Row, mydbDataSet.tronconsRow)
    '            row2.BeginEdit()
    '            row2.pose = True
    '            row2.date_pose = Today.Date
    '            row2.qui_pose = FormMain.user.Nom_user
    '            row2.EndEdit()
    '            Me.TronconsBindingSource.EndEdit()
    '            Me.TronconsTableAdapter.Update(Me.MydbDataSet.troncons)
    '            Me.TronconsTableAdapter.Fill(Me.MydbDataSet.troncons)
    '            Me.Troncons_statusTableAdapter.Fill(Me.MydbDataSet.troncons_status)
    '        End If

    '    End If
    'End Sub
    Public Sub actualisation()
        Me.TronconsTableAdapter.Fill(Me.MydbDataSet.troncons)
        Me.Troncons_statusTableAdapter.Fill(Me.MydbDataSet.troncons_status)
    End Sub
    'Private Sub X2Progress_BeforeCellPaint(ByVal sender As Object, ByVal e As GridPostRenderCellEventArgs) Handles SuperGridControl.PostRenderCell
    '    Dim pbc As GridLabelXEditControl
    '    If e.GridCell.GridColumn.ColumnIndex = 1 Then

    '        pbc = TryCast(e.GridCell.GridColumn.RenderControl, GridLabelXEditControl)

    '        If pbc IsNot Nothing Then
    '            Select Case pbc.Text
    '                Case "BLOCAGE"
    '                    pbc.Text = "BLOCAGE"
    '                    pbc.Image = ImageList1.Images("blocage2")
    '                    Exit Select

    '                Case "Dispo"
    '                    pbc.Text = "Dispo"
    '                    pbc.Image = ImageList1.Images("Dispo")
    '                    Exit Select
    '                Case Nothing
    '                    pbc.Text = "Attente"
    '                    pbc.Image = ImageList1.Images("blocage2")
    '                    Exit Select
    '                Case Else

    '                    pbc.Text = "Attente"
    '                    pbc.Image = ImageList1.Images("blocage2")
    '                    Exit Select
    '            End Select
    '        End If
    '    ElseIf e.GridCell.GridColumn.ColumnIndex = 5 Or e.GridCell.GridColumn.ColumnIndex = 7 Then

    '        pbc = TryCast(e.GridCell.GridColumn.RenderControl, GridLabelXEditControl)

    '        If pbc IsNot Nothing Then
    '            Select Case pbc.Text
    '                Case "BLOCAGE"
    '                    pbc.Text = "BLOCAGE"
    '                    pbc.Image = ImageList1.Images("blocage2")
    '                    Exit Select

    '                Case "Dispo"
    '                    pbc.Text = "Dispo"
    '                    pbc.Image = ImageList1.Images("Dispo")
    '                    Exit Select
    '                Case Nothing
    '                    pbc.Text = "Attente"
    '                    pbc.Image = ImageList1.Images("blocage2")
    '                    Exit Select
    '                Case Else

    '                    pbc.Text = "Attente"
    '                    pbc.Image = ImageList1.Images("blocage2")
    '                    Exit Select
    '            End Select
    '        End If

    '    End If

    'End Sub
    Private Class MyGridSwitchButtonEditControl
        Inherits GridSwitchButtonEditControl

        Public Sub New()

            StretchBehavior = StretchBehavior.HorizontalOnly
            OffText = "A faire"
            OnText = "Posé"

            'AddHandler ValueChanged, AddressOf MyGridSwitchButtonEditControlValueChanged
        End Sub

#Region "MyGridSwitchButtonEditControlValueChanged"

        Private Sub MyGridSwitchButtonEditControlValueChanged(ByVal sender As Object, ByVal e As EventArgs)


            'If cell IsNot Nothing Then
            '    ' cell.GridRow.Cells(3).InvalidateRender()
            '    If CBool(cell.GridRow.Cells(17).Value) Then
            '        ' MsgBox("depose")
            '    ElseIf Not CBool(cell.GridRow.Cells(17).Value) Then
            '        '  MsgBox("pose")
            '    End If
            'End If
        End Sub

#End Region

    End Class

    Public Sub New()

        ' Cet appel est requis par le concepteur.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().
        Dim panel As GridPanel = SuperGridControl.PrimaryGrid

        Dim column As GridColumn = panel.Columns("pose")

        column.EditorType = GetType(MyGridSwitchButtonEditControl)
        InitializeGrid()
    End Sub
    Private Sub SuperGridControl1_CellClick(sender As Object, e As GridCellClickEventArgs) Handles SuperGridControl.CellClick

        If e.GridCell.ColumnIndex = SuperGridControl.PrimaryGrid.Columns("pose").ColumnIndex Then
            Me.TronconsBindingSource.Position = Me.TronconsBindingSource.Find("idtroncons", e.GridCell.GridRow("idtroncons").Value)
            Dim rowa As mydbDataSet.tronconsRow
            rowa = CType(CType(Me.TronconsBindingSource.Current, DataRowView).Row, mydbDataSet.tronconsRow)
            If rowa.pose Then
                rowa.pose = False
                rowa.qui_pose = FormMain.user.Nom_user
                rowa.date_pose = Now.Date
                TronconsTableAdapter.Update(MydbDataSet.troncons)
                TronconsTableAdapter.Fill(MydbDataSet.troncons)
            Else
                rowa.pose = True
                rowa.qui_pose = FormMain.user.Nom_user
                rowa.date_pose = Now.Date
                rowa.EndEdit()
                TronconsTableAdapter.Update(MydbDataSet.troncons)
                TronconsTableAdapter.Fill(MydbDataSet.troncons)
            End If
        End If
    End Sub

    Private Sub ButtonXPossibiliees_Click(sender As Object, e As EventArgs) Handles ButtonXPossibiliees.Click
        Me.SuperGridControl.PrimaryGrid.Columns("statut").FilterDisplayValue = "dispo"
        Me.SuperGridControl.PrimaryGrid.Columns("statut").FilterExpr = "[statut] LIKE 'dispo'"
        Me.SuperGridControl.PrimaryGrid.Columns("statut1").FilterDisplayValue = "dispo"
        Me.SuperGridControl.PrimaryGrid.Columns("statut1").FilterExpr = "[statut1] LIKE 'dispo'"
        Me.SuperGridControl.PrimaryGrid.Columns("pose").FilterDisplayValue = "false"
        Me.SuperGridControl.PrimaryGrid.Columns("pose").FilterExpr = "[pose] like false"
    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        Me.SuperGridControl.PrimaryGrid.Columns("statut").FilterDisplayValue = Nothing
        Me.SuperGridControl.PrimaryGrid.Columns("statut").FilterExpr = Nothing
        Me.SuperGridControl.PrimaryGrid.Columns("statut1").FilterDisplayValue = Nothing
        Me.SuperGridControl.PrimaryGrid.Columns("statut1").FilterExpr = Nothing
        Me.SuperGridControl.PrimaryGrid.Columns("pose").FilterDisplayValue = Nothing
        Me.SuperGridControl.PrimaryGrid.Columns("pose").FilterExpr = Nothing
    End Sub

    Private Sub SuperGridControl_RowDoubleClick(sender As Object, e As GridRowDoubleClickEventArgs) Handles SuperGridControl.RowDoubleClick
        Dim grow As GridRow

        Dim irow As Integer
        Dim crow As DataRowView

        Dim formTroncon As FormTroncon
        formTroncon = New FormTroncon
        formTroncon.MdiParent = Me.ParentForm
        formTroncon.WindowState = FormWindowState.Maximized
        formTroncon.mode = False

        grow = CType(e.GridRow, GridRow)
        irow = Me.Troncons_statusBindingSource.Find("idtroncons", grow.Cells(0).Value.ToString)
        Me.Troncons_statusBindingSource.Position = irow
        crow = CType(Me.Troncons_statusBindingSource.Item(irow), DataRowView)

        formTroncon.value = crow.Item(0).ToString

        formTroncon.Show()
    End Sub


    Private Sub ButtonX2_Click(sender As Object, e As EventArgs) Handles ButtonX2.Click
        Me.SuperGridControl.PrimaryGrid.SelectAll()
        Me.SuperGridControl.PrimaryGrid.CopySelectedCellsToClipboard(True, False)



        Dim xlapp As New Excel.Application
        xlapp.Visible = True
        Dim xlbk As Excel.Workbook = xlapp.Workbooks.Add
        Dim xlsheet As Excel.Worksheet = CType(xlbk.Sheets(1), Microsoft.Office.Interop.Excel.Worksheet)

        xlsheet.Range("a1").Select()
        xlsheet.Range("a1").PasteSpecial() ' = Clipboard.GetData(DataFormats.UnicodeText)


        'xlbk.Save()
        'xlbk.Close()
        'xlapp.Quit()
        'System.Runtime.InteropServices.Marshal.ReleaseComObject(xlapp)
    End Sub

    Private Sub Troncons_statusBindingSource_ListChanged(sender As Object, e As ListChangedEventArgs) Handles Troncons_statusBindingSource.ListChanged
        update_info()
    End Sub
End Class