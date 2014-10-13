Imports System.Drawing.Drawing2D
Imports DevComponents.DotNetBar.SuperGrid
Imports DevComponents.DotNetBar.SuperGrid.Style
Imports DevComponents.DotNetBar
Public Class FormDispoTirage

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Dim panel As GridPanel = SuperGridControl1.PrimaryGrid
        'Me.Lst_dispo_tirageTableAdapter.Fill(Me.MydbDataSet.lst_dispo_tirage)

        '' panel.VirtualMode = True
        'panel.DataSource = Me.Lst_dispo_tirageBindingSource
        'SuperGridControl1.PrimaryGrid.DetachDataSource(True)
        ' Set both the Slider and SitchButton columns to
        ' our own defined EditControls

        Dim column As GridColumn = panel.Columns("pose")

        column.EditorType = GetType(MyGridSwitchButtonEditControl)

        column = panel.Columns("statut")
        column.EditorType = GetType(MyGridLabelXEditControl)
        column = panel.Columns("status")
        column.EditorType = GetType(MyGridLabelXEditControl)
        column = panel.Columns("statut1")
        column.EditorType = GetType(MyGridLabelXEditControl)
        column = panel.Columns("status1")
        column.EditorType = GetType(MyGridLabelXEditControl)
        column = panel.Columns("parcours_status")
        column.EditorType = GetType(MyGridLabelXEditControl)

        'AddHandler SuperGridControl1.CellValueChanged, AddressOf SuperGridControl1CellValueChanged
    End Sub

    Private Sub FormDispoTirage_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.cables'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.CablesTableAdapter.Fill(Me.MydbDataSet.cables)
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.tourets'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.TouretsTableAdapter.Fill(Me.MydbDataSet.tourets)
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.cables_details_has_tourets'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.Cables_details_has_touretsTableAdapter.Fill(Me.MydbDataSet.cables_details_has_tourets)
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.cables_details_has_tourets_pose'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.Cables_details_has_tourets_poseTableAdapter.Fill(Me.MydbDataSet.cables_details_has_tourets_pose)
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.troncons'. Vous pouvez la déplacer ou la supprimer selon vos besoins.

        'TODO: This line of code loads data into the 'MydbDataSet.cables_details' table. You can move, or remove it, as needed.
        Me.Cables_detailsTableAdapter.Fill(Me.MydbDataSet.cables_details)
        'TODO: This line of code loads data into the 'MydbDataSet.lst_dispo_tirage' table. You can move, or remove it, as needed.
        Me.Lst_dispo_tirageTableAdapter.Fill(Me.MydbDataSet.lst_dispo_tirage)
        Dim panel As GridPanel = SuperGridControl1.PrimaryGrid

        panel.DataSource = Me.Lst_dispo_tirageBindingSource
        ' panel.VirtualMode = True
        'Panel.DataSource = Me.Lst_dispo_tirageBindingSource
        ' SuperGridControl1.PrimaryGrid.DetachDataSource(True)
        '  panel.DataSource = Me.Lst_dispo_tirageBindingSource
        Me.SuperGridControl1.PrimaryGrid.ClearAllFilters(True, True)
        'Me.SuperGridControl1.PrimaryGrid.Columns("parcours_status").FilterDisplayValue = "fait"
        'Me.SuperGridControl1.PrimaryGrid.Columns("parcours_status").FilterExpr = "[statut] like  'fait'"
        'Me.SuperGridControl1.PrimaryGrid.Columns("statut").FilterDisplayValue = "dispo"
        'Me.SuperGridControl1.PrimaryGrid.Columns("statut").FilterExpr = "[statut] LIKE 'dispo'"
        'Me.SuperGridControl1.PrimaryGrid.Columns("statut1").FilterDisplayValue = "dispo"
        'Me.SuperGridControl1.PrimaryGrid.Columns("statut1").FilterExpr = "[statut1] LIKE 'dispo'"
        'Me.SuperGridControl1.PrimaryGrid.Columns("pose").FilterDisplayValue = "false"
        'Me.SuperGridControl1.PrimaryGrid.Columns("pose").FilterExpr = "[pose] like false"
        update_info()
    End Sub
    Public Sub actualisation()
        Me.Lst_dispo_tirageTableAdapter.Fill(Me.MydbDataSet.lst_dispo_tirage)
    End Sub
#Region "salle label"
    Dim result As eTaskDialogResult
    Private Sub SuperGridControl1_CellClick(sender As Object, e As DevComponents.DotNetBar.SuperGrid.GridCellClickEventArgs) Handles SuperGridControl1.CellClick
        Dim row As MydbDataSet.lst_dispo_tirageRow
        If e.GridCell.ColumnIndex = SuperGridControl1.PrimaryGrid.Columns("pose").ColumnIndex Then
            Dim row2 As MydbDataSet.cables_detailsRow
            Lst_dispo_tirageBindingSource.RemoveFilter()
            Lst_dispo_tirageBindingSource.Position = Lst_dispo_tirageBindingSource.Find("idcables_details", e.GridCell.GridRow("idcables_details").Value)
            row = CType(CType(Me.Lst_dispo_tirageBindingSource.Current, DataRowView).Row, MydbDataSet.lst_dispo_tirageRow)
            If Not row.pose Then
                Dim info As New TaskDialogInfo("Verification", eTaskDialogIcon.Hand, "Le tirage est il conforme au touret ?", "Les tourets affectes sont il bien ceux utilisé lors du tirage", eTaskDialogButton.Yes Or eTaskDialogButton.No, eTaskDialogBackgroundColor.Red)
                result = TaskDialog.Show(info)

                Select Case result
                    Case eTaskDialogResult.Yes
                        Dim curenttouret As MydbDataSet.cables_details_has_touretsRow

                        Me.Cables_details_has_touretsBindingSource.Filter = "cables_details_idcables_details='" & row.idcables_details & "'"
                        If Me.Cables_details_has_touretsBindingSource.Count = 0 Then
                            MsgBox("ce cables n est pas affecté à un touret , merci de corriger")
                            Me.Cables_details_has_touretsBindingSource.Filter = Nothing
                            Exit Sub
                        End If
                        Me.Cables_details_has_touretsBindingSource.Filter = Nothing
                        Me.Cables_details_has_touretsBindingSource.Position = Me.Cables_details_has_touretsBindingSource.Find("cables_details_idcables_details", row.idcables_details)
                        curenttouret = CType(CType(Me.Cables_details_has_touretsBindingSource.Current, DataRowView).Row, MydbDataSet.cables_details_has_touretsRow)

                        Me.Cables_details_has_tourets_poseBindingSource.AddNew()
                        Dim rooww As MydbDataSet.cables_details_has_tourets_poseRow

                        rooww = CType(CType(Me.Cables_details_has_tourets_poseBindingSource.Current, DataRowView).Row, MydbDataSet.cables_details_has_tourets_poseRow)

                        rooww.cables_details_idcables_details = row.idcables_details
                        rooww.tourets_idtouret = curenttouret.tourets_idtouret
                        rooww._date = Today
                        rooww.qui = user.Nom_user
                        Dim rowcable As MydbDataSet.cablesRow
                        Me.CablesBindingSource.Position = Me.CablesBindingSource.Find("idcables", row.idcable)
                        rowcable = CType(CType(Me.CablesBindingSource.Current, DataRowView).Row, MydbDataSet.cablesRow)
                        rowcable.VerouillageParcours = True
                        Me.CablesBindingSource.EndEdit()
                        Me.CablesTableAdapter.Update(MydbDataSet.cables)
                        Me.CablesTableAdapter.Fill(MydbDataSet.cables)
                        Me.Cables_details_has_tourets_poseBindingSource.EndEdit()

                        Me.Cables_details_has_tourets_poseTableAdapter.Update(MydbDataSet.cables_details_has_tourets_pose)

                        Me.Cables_details_has_tourets_poseTableAdapter.Fill(MydbDataSet.cables_details_has_tourets_pose)

                        Me.Cables_detailsBindingSource.Position = Me.Cables_detailsBindingSource.Find("idcables_details", row.idcables_details)
                        row2 = CType(CType(Me.Cables_detailsBindingSource.Current, DataRowView).Row, MydbDataSet.cables_detailsRow)
                        row2.BeginEdit()
                        row2.pose = True
                        row2.qui = FormMain.user.Nom_user
                        row2.date_pose = Date.Today
                        row2.EndEdit()
                        Me.Cables_detailsBindingSource.EndEdit()
                        Me.Cables_detailsTableAdapter.Update(MydbDataSet.cables_details)
                        Me.Cables_detailsTableAdapter.Fill(MydbDataSet.cables_details)
                        Me.Lst_dispo_tirageTableAdapter.Fill(MydbDataSet.lst_dispo_tirage)

                    Case eTaskDialogResult.No

                        Dim reponse As String
                        Dim postouret As Integer = 0
                        Dim touretselect As MydbDataSet.touretsRow
                        Do Until postouret = 1

                            reponse = InputBox("Merci de donner le numero de touret utilisé : ")
                            If reponse = "" Then
                                Exit Sub
                            End If
                            Me.TouretsBindingSource.Filter = "Repere='" & reponse & "'"
                            If Not Me.TouretsBindingSource.Count = 0 Then
                                postouret = 1
                            End If

                        Loop

                        touretselect = CType(CType(Me.TouretsBindingSource.Current, DataRowView).Row, MydbDataSet.touretsRow)

                        Dim rooww As MydbDataSet.cables_details_has_tourets_poseRow

                        Me.Cables_details_has_tourets_poseBindingSource.AddNew()

                        rooww = CType(CType(Me.Cables_details_has_tourets_poseBindingSource.Current, DataRowView).Row, MydbDataSet.cables_details_has_tourets_poseRow)

                        rooww.cables_details_idcables_details = row.idcables_details
                        rooww.tourets_idtouret = touretselect.idtouret
                        rooww._date = Today
                        rooww.qui = user.Nom_user

                        Me.Cables_details_has_tourets_poseBindingSource.EndEdit()

                        Me.Cables_details_has_tourets_poseTableAdapter.Update(MydbDataSet.cables_details_has_tourets_pose)

                        Me.Cables_details_has_tourets_poseTableAdapter.Fill(MydbDataSet.cables_details_has_tourets_pose)

                        Me.Cables_detailsBindingSource.Position = Me.Cables_detailsBindingSource.Find("idcables_details", row.idcables_details)
                        row2 = CType(CType(Me.Cables_detailsBindingSource.Current, DataRowView).Row, MydbDataSet.cables_detailsRow)
                        row2.BeginEdit()
                        row2.pose = True
                        row2.qui = FormMain.user.Nom_user
                        row2.date_pose = Date.Today
                        row2.EndEdit()
                        Dim rowcable As MydbDataSet.cablesRow
                        Me.CablesBindingSource.Position = Me.CablesBindingSource.Find("idcables", row.idcable)
                        rowcable = CType(CType(Me.CablesBindingSource.Current, DataRowView).Row, MydbDataSet.cablesRow)
                        rowcable.VerouillageParcours = True
                        Me.CablesBindingSource.EndEdit()
                        Me.CablesTableAdapter.Update(MydbDataSet.cables)
                        Me.CablesTableAdapter.Fill(MydbDataSet.cables)
                        Me.Cables_detailsBindingSource.EndEdit()
                        Me.Cables_detailsTableAdapter.Update(MydbDataSet.cables_details)
                        Me.Cables_detailsTableAdapter.Fill(MydbDataSet.cables_details)
                        Me.Lst_dispo_tirageTableAdapter.Fill(MydbDataSet.lst_dispo_tirage)

                End Select

            Else

            End If

        End If
    End Sub

    Private Sub SuperGridControl1_DataFilteringComplete(sender As Object, e As DevComponents.DotNetBar.SuperGrid.GridDataFilteringCompleteEventArgs) Handles SuperGridControl1.DataFilteringComplete
        If Not IsNothing(Me.SuperGridControl1.PrimaryGrid.Columns("parcours_status").FilterDisplayValue) Or Not IsNothing(Me.SuperGridControl1.PrimaryGrid.Columns("statut").FilterDisplayValue) Or Not IsNothing(Me.SuperGridControl1.PrimaryGrid.Columns("statut1").FilterDisplayValue) Or Not IsNothing(Me.SuperGridControl1.PrimaryGrid.Columns("pose").FilterDisplayValue) Then
            '  If CStr(Me.SuperGridControl1.PrimaryGrid.Columns("parcours_status").FilterDisplayValue) = "" Then
            '  Lst_dispo_tirageBindingSource.RemoveFilter()
            '   Me.SuperGridControl1.PrimaryGrid.ClearAllFilters(True, True)
            'Else
            Try
                Dim f1, f2, f3, f4 As String
                Dim filtre As String
                '     Lst_dispo_tirageBindingSource.RemoveFilter()
                '  Me.SuperGridControl1.PrimaryGrid.DetachDataSource(True)
                If Not CStr(Me.SuperGridControl1.PrimaryGrid.Columns("parcours_status").FilterDisplayValue) = "" Then
                    f1 = CStr(DirectCast(SuperGridControl1.PrimaryGrid.Columns("parcours_status").FilterDisplayValue, String))

                    If Not IsNothing(f1) Then
                        filtre = "parcours_status like'" & f1 & "%'"
                        Me.SuperGridControl1.PrimaryGrid.Columns("parcours_status").FilterExpr = "[parcours_status] Like  '" & f1 & "'"
                    End If
                End If
                If Not CStr(Me.SuperGridControl1.PrimaryGrid.Columns("statut").FilterDisplayValue) = "" Then
                    f2 = CStr(DirectCast(SuperGridControl1.PrimaryGrid.Columns("statut").FilterDisplayValue, String))

                    If Not IsNothing(f2) And Not IsNothing(filtre) Then
                        filtre += " and statut like'" & f2 & "%'"
                        Me.SuperGridControl1.PrimaryGrid.Columns("statut").FilterExpr = "[statut] like '" & f2 & "'"
                    End If

                    If Not IsNothing(f2) And IsNothing(filtre) Then
                        filtre = "statut like'" & f2 & "%'"
                        Me.SuperGridControl1.PrimaryGrid.Columns("statut").FilterExpr = "[statut] like '" & f2 & "'"
                    End If
                End If
                If Not CStr(Me.SuperGridControl1.PrimaryGrid.Columns("statut1").FilterDisplayValue) = "" Then
                    f3 = CStr(DirectCast(SuperGridControl1.PrimaryGrid.Columns("statut1").FilterDisplayValue, String))

                    If Not IsNothing(f3) And Not IsNothing(filtre) Then
                        filtre += " and statut1 like'" & f3 & "%'"
                        Me.SuperGridControl1.PrimaryGrid.Columns("statut1").FilterExpr = "[statut1] like '" & f3 & "'"
                    End If

                    If Not IsNothing(f3) And IsNothing(filtre) Then
                        filtre = "statut1 like'" & f3 & "%'"
                        Me.SuperGridControl1.PrimaryGrid.Columns("statut1").FilterExpr = "[statut1] like '" & f3 & "'"
                    End If
                End If
                Dim statefiltre As CheckState
                statefiltre = CType(Me.SuperGridControl1.PrimaryGrid.Columns("pose").FilterDisplayValue, CheckState)
                Select Case statefiltre
                    Case CheckState.Checked
                        filtre += " and pose ='" & statefiltre & "'"
                        Me.SuperGridControl1.PrimaryGrid.Columns("pose").FilterExpr = "[pose] like " & statefiltre & ""
                    Case CheckState.Indeterminate
                        filtre += " and pose ='" & statefiltre & "'"
                        Me.SuperGridControl1.PrimaryGrid.Columns("pose").FilterExpr = "[pose] like " & statefiltre & ""
                    Case CheckState.Unchecked

                End Select

                If Not IsNothing(statefiltre) Then

                    If Not IsNothing(statefiltre) And Not IsNothing(filtre) Then
                        filtre += " and pose ='" & statefiltre & "'"
                        Me.SuperGridControl1.PrimaryGrid.Columns("pose").FilterExpr = "[pose] like " & statefiltre & ""
                    End If

                    If Not IsNothing(statefiltre) And IsNothing(filtre) Then
                        filtre = "pose ='" & statefiltre & "'"
                        Me.SuperGridControl1.PrimaryGrid.Columns("pose").FilterExpr = "[pose] =  " & statefiltre & ""
                    End If
                End If
                If Not IsNothing(filtre) Then
                    Lst_dispo_tirageBindingSource.Filter = filtre
                End If

                '  update_info()
            Catch ex As Exception

            End Try
        End If

        ' Else
        '  Lst_dispo_tirageBindingSource.RemoveFilter()
        ' End If

    End Sub
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

    'Public Sub labeledit_spergrid(ByVal sender As Object, ByVal e As GridPostRenderCellEventArgs) Handles SuperGridControl1.PostRenderCell
    '    If e.GridCell.ColumnIndex = 12 Or e.GridCell.ColumnIndex = 15 Then

    '        RenderSliderBackground(e)

    '    End If
    'End Sub

    'Private Sub RenderSliderBackground(ByVal e As GridPostRenderCellEventArgs)
    '    If (e.RenderParts And RenderParts.Background) = RenderParts.Background Then
    '        If Not IsDBNull(e.GridCell.Value) Then

    '            If CInt(Fix(e.GridCell.Value)) > 70 Then
    '                Using br As Brush = New LinearGradientBrush(e.Bounds, Color.Transparent, Color.Red, 0.0F)
    '                    e.Graphics.FillRectangle(br, e.Bounds)
    '                End Using
    '                Dim pbx As GridProgressBarXEditControl = TryCast(e.GridCell.GridColumn.EditControl, GridProgressBarXEditControl)

    '                If pbx IsNot Nothing Then

    '                    If CInt(Fix(e.GridCell.Value)) > 70 Then

    '                        SuperGridControl1.PrimaryGrid.Columns(12).InvalidateRender()
    '                        SuperGridControl1.PrimaryGrid.Columns(15).InvalidateRender()
    '                    Else
    '                        pbx.ForeColor = Color.Green

    '                    End If
    '                End If
    '            End If
    '        End If
    '    End If

    'End Sub
    'Private Sub X2Progress_BeforeCellPaint(ByVal sender As Object, ByVal e As GridPostRenderCellEventArgs) Handles SuperGridControl1.PostRenderCell

    '    If e.GridCell.GridColumn.ColumnIndex = 2 Or e.GridCell.GridColumn.ColumnIndex = 6 Then
    '        Dim pbc As GridLabelXEditControl = TryCast(e.GridCell.GridColumn.RenderControl, GridLabelXEditControl)

    '        If pbc IsNot Nothing Then
    '            Select Case pbc.Text
    '                Case "BLOCAGE"
    '                    pbc.Text = "BLOCAGE"
    '                    pbc.Image = ImageList1.Images("stop")
    '                    Exit Select

    '                Case "Dispo"
    '                    pbc.Text = "Dispo"
    '                    pbc.Image = ImageList1.Images("ok")
    '                    Exit Select
    '                Case Nothing
    '                    pbc.Text = "Attente"
    '                    pbc.Image = ImageList1.Images("pkoi")
    '                    Exit Select
    '                Case Else

    '                    pbc.Text = "Attente"
    '                    pbc.Image = ImageList1.Images("pkoi")
    '                    Exit Select
    '            End Select

    '        End If
    '    ElseIf e.GridCell.GridColumn.ColumnIndex = 4 Or e.GridCell.GridColumn.ColumnIndex = 8 Then
    '        Dim pbc As GridLabelXEditControl = TryCast(e.GridCell.GridColumn.RenderControl, GridLabelXEditControl)

    '        If pbc IsNot Nothing Then
    '            Select Case pbc.Text
    '                Case "BLOCAGE"
    '                    pbc.Text = "BLOCAGE"
    '                    pbc.Image = ImageList1.Images("stop")
    '                    Exit Select

    '                Case "DISPO"
    '                    pbc.Text = "Dispo"
    '                    pbc.Image = ImageList1.Images("ok")
    '                    Exit Select
    '                Case Nothing
    '                    pbc.Text = "Attente"
    '                    pbc.Image = ImageList1.Images("pkoi")
    '                    Exit Select
    '                Case Else

    '                    pbc.Text = "Attente"
    '                    pbc.Image = ImageList1.Images("pkoi")
    '                    Exit Select
    '            End Select
    '        End If
    '    ElseIf e.GridCell.GridColumn.ColumnIndex = 16 Then
    '        Dim pbc As GridLabelXEditControl = TryCast(e.GridCell.GridColumn.RenderControl, GridLabelXEditControl)

    '        If pbc IsNot Nothing Then
    '            Select Case pbc.Text
    '                Case "BLOCAGE"
    '                    pbc.Text = "BLOCAGE"
    '                    pbc.Image = ImageList1.Images("stop")
    '                    Exit Select

    '                Case "FAIT"
    '                    pbc.Text = "FAIT"
    '                    pbc.Image = ImageList1.Images("ok")
    '                    Exit Select
    '                Case "POSSIBLE"
    '                    pbc.Text = "POSSIBLE"
    '                    pbc.Image = ImageList1.Images("pkoi")
    '                    Exit Select
    '                Case Nothing
    '                    pbc.Text = "Sans parcours"
    '                    pbc.Image = ImageList1.Images("stop")
    '                    Exit Select
    '                Case Else

    '                    pbc.Text = "Sans parcours"
    '                    pbc.Image = ImageList1.Images("stop")
    '                    Exit Select
    '            End Select
    '        End If
    '    End If

    'End Sub

#End Region
    Private Class MyGridSwitchButtonEditControl
        Inherits GridSwitchButtonEditControl

        Public Sub New()

            StretchBehavior = StretchBehavior.HorizontalOnly
            OffText = "A faire"
            OnText = "Posé"
            'AddHandler ValueChanged, AddressOf MyGridSwitchButtonEditControlValueChanged
        End Sub

#Region "MyGridSwitchButtonEditControlValueChanged"

        'Private Sub MyGridSwitchButtonEditControlValueChanged(ByVal sender As Object, ByVal e As EventArgs)

        '    Dim cell As GridCell = EditorCell

        '    If cell IsNot Nothing Then
        '        ' cell.GridRow.Cells(3).InvalidateRender()
        '        If CBool(cell.GridRow.Cells(17).Value) Then
        '            ' MsgBox("depose")
        '        ElseIf Not CBool(cell.GridRow.Cells(17).Value) Then
        '            '  MsgBox("pose")
        '        End If
        '    End If
        'End Sub

#End Region

    End Class

    'Private Sub SuperGridControl1CellValueChanged(ByVal sender As Object, ByVal e As GridCellValueChangedEventArgs)
    '    Dim cell As GridCell = e.GridCell

    '    ' If the cell changing value is in the "Power State" column
    '    ' then adjust the row "Start/Stop" cell appropriately

    '    If cell.GridColumn.Name.Equals("pose") = True Then
    '        Dim row As GridRow = cell.GridRow

    '        ' Hide the cell if the switch button is off
    '        ' and reset the cell's value back to the "Start" state

    '        If Not CBool(row.Cells(17).Value) Then
    '            row.Cells("pose").Value = False
    '        End If
    '    End If
    'End Sub

#Region "update info"
    Public Sub update_info()
        Dim compte, compte2, compte3, compte4, compte5, compte6 As Double
        Dim row As MydbDataSet.lst_dispo_tirageRow
        For Each c In Lst_dispo_tirageBindingSource
            Try

                row = CType(CType(c, DataRowView).Row, MydbDataSet.lst_dispo_tirageRow)
                If Not IsDBNull(row.temps) Then
                    compte += CDbl(row.temps)
                    compte2 += 1
                    If Not row.pose Then
                        compte3 += CDbl(row.temps)
                    End If

                End If

            Catch ex As Exception
                If ex.Message.EndsWith("DbNull") Then

                End If
            End Try
        Next
        LabelX4.Text = Math.Round(compte, 2) & " Poid Global"
        LabelX3.Text = compte2 & " Cables selectionnés / parcouru "
        LabelX5.Text = Math.Round(compte3, 2) & " Poid restant"
        LabelX7.Text = Math.Round((compte - compte3) / compte, 3) * 100 & " % avancement"

    End Sub

#End Region

    Private Sub Lst_dispo_tirageBindingSource_ListChanged(sender As Object, e As System.ComponentModel.ListChangedEventArgs) Handles Lst_dispo_tirageBindingSource.ListChanged
        update_info()
    End Sub

    Private Sub ButtonX1_Click(sender As System.Object, e As System.EventArgs) Handles ButtonX1.Click
        Lst_dispo_tirageBindingSource.RemoveFilter()
        Me.SuperGridControl1.PrimaryGrid.Columns("parcours_status").FilterExpr = Nothing
        Me.SuperGridControl1.PrimaryGrid.Columns("statut").FilterDisplayValue = Nothing
        Me.SuperGridControl1.PrimaryGrid.Columns("statut").FilterExpr = Nothing
        Me.SuperGridControl1.PrimaryGrid.Columns("statut1").FilterDisplayValue = Nothing
        Me.SuperGridControl1.PrimaryGrid.Columns("statut1").FilterExpr = Nothing
        Me.SuperGridControl1.PrimaryGrid.Columns("pose").FilterDisplayValue = Nothing
        Me.SuperGridControl1.PrimaryGrid.Columns("pose").FilterExpr = Nothing
        Me.SuperGridControl1.PrimaryGrid.ClearAllFilters(True, True)

        update_info()

    End Sub

    Private Sub ButtonX2_Click(sender As System.Object, e As System.EventArgs) Handles ButtonX2.Click
        Me.SuperGridControl1.PrimaryGrid.Columns("parcours_status").FilterDisplayValue = "fait"
        Me.SuperGridControl1.PrimaryGrid.Columns("parcours_status").FilterExpr = "[statut] like  'fait'"
        Me.SuperGridControl1.PrimaryGrid.Columns("statut").FilterDisplayValue = "dispo"
        Me.SuperGridControl1.PrimaryGrid.Columns("statut").FilterExpr = "[statut] LIKE 'dispo'"
        Me.SuperGridControl1.PrimaryGrid.Columns("statut1").FilterDisplayValue = "dispo"
        Me.SuperGridControl1.PrimaryGrid.Columns("statut1").FilterExpr = "[statut1] LIKE 'dispo'"
        Me.SuperGridControl1.PrimaryGrid.Columns("pose").FilterDisplayValue = "false"
        Me.SuperGridControl1.PrimaryGrid.Columns("pose").FilterExpr = "[pose] like false"
        update_info()
    End Sub
End Class