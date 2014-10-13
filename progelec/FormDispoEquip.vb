Imports System.Text
Imports System.ComponentModel
Imports Microsoft.VisualBasic
Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Controls
Imports DevComponents.DotNetBar.Rendering
Imports DevComponents.DotNetBar.SuperGrid
Imports DevComponents.DotNetBar.SuperGrid.Style

Public Class FormDispoEquip

    Dim temps_global As Double
    Dim lot_principal As Integer
    Dim temps_propo As Double
    Dim temps_forc As Double

    Private Sub FormDispoEquip_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'MydbDataSet.equipements_dispo_histo' table. You can move, or remove it, as needed.
        Me.Equipements_dispo_histoTableAdapter.Fill(Me.MydbDataSet.equipements_dispo_histo)
        'TODO: This line of code loads data into the 'MydbDataSet.equipements_dispo' table. You can move, or remove it, as needed.
        Me.Equipements_dispoTableAdapter.Fill(Me.MydbDataSet.equipements_dispo)
        'TODO: This line of code loads data into the 'MydbDataSet.equipements' table. You can move, or remove it, as needed.
        Me.EquipementsTableAdapter.Fill(Me.MydbDataSet.equipements)
        'TODO: This line of code loads data into the 'MydbDataSet.lots' table. You can move, or remove it, as needed.
        Me.LotsTableAdapter.Fill(Me.MydbDataSet.lots)
        Me.LotsBindingSource.Position = Me.LotsBindingSource.Find("principale", True)
        lot_principal = CType(CType(Me.LotsBindingSource.Current, DataRowView).Row, mydbDataSet.lotsRow).idlots
        'TODO: This line of code loads data into the 'MydbDataSet.salles' table. You can move, or remove it, as needed.
        Me.SallesTableAdapter.Fill(Me.MydbDataSet.salles)
        Equipements_statusTableAdapter.Fill(MydbDataSet.equipements_status)
        Equipements_statusBindingSource.RemoveFilter()
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        'X1salle_Initialize()
        'X1pose_Initialize()
        'X2dispo_Initialize()

        ' Add any initialization after the InitializeComponent() call.
        Dim panel As GridPanel = SuperGridControl1.PrimaryGrid

        Dim column As GridColumn = panel.Columns("pose")

        column.EditorType = GetType(MyGridSwitchButtonEditControl)

        column = panel.Columns("salle_dispo")
        column.EditorType = GetType(MyGridLabelXEditControl)

             column  = panel.Columns("avancement")

   column.EditorType = GetType(MyGridProgressBarXEditControl)
       ' InitializeGrid
    End Sub
    '#Region "datagrid"
    '    Private Sub X1salle_Initialize()
    '        Dim bcx As DataGridViewLabelXColumn = TryCast(DataGridViewX1.Columns("salle_status"), DataGridViewLabelXColumn)

    '        If bcx IsNot Nothing Then
    '            ' Hook onto the BeforeCellPaint event so we can
    '            ' demonstrate cell customization

    '            AddHandler bcx.BeforeCellPaint, AddressOf X1salle_BeforeCellPaint
    '        End If
    '    End Sub
    '    Private Sub X1pose_Initialize()
    '        Dim bcx As DataGridViewLabelXColumn = TryCast(DataGridViewX1.Columns("pose"), DataGridViewLabelXColumn)

    '        If bcx IsNot Nothing Then
    '            ' Hook onto the BeforeCellPaint event so we can
    '            ' demonstrate cell customization

    '            AddHandler bcx.BeforeCellPaint, AddressOf X1pose_BeforeCellPaint
    '        End If

    '    End Sub

    '    ''' <summary>
    '    ''' Handles "PostalCode" BeforeCellPaint events
    '    ''' </summary>
    '    ''' <param name="sender">DataGridViewButtonXColumn</param>
    '    ''' <param name="e">BeforeCellPaintEventArgs</param>
    '    Private Sub X1salle_BeforeCellPaint(ByVal sender As Object, ByVal e As BeforeCellPaintEventArgs)
    '        Dim bcx As DataGridViewLabelXColumn = TryCast(sender, DataGridViewLabelXColumn)

    '        If bcx IsNot Nothing Then
    '            ' Set the label image

    '            If String.IsNullOrEmpty(bcx.Text) = True Then
    '                bcx.Image = ImageList1.Images("Close2")
    '                bcx.Text = "<font color=""red"">Salle non dispo</font>"
    '            ElseIf bcx.Text.Contains("BLOCAGE") Then
    '                bcx.Image = ImageList1.Images("blocage")
    '                bcx.Text = "<font color=""red"">BLOCAGE</font>"
    '            Else
    '                bcx.Image = ImageList1.Images("OK")
    '            End If
    '        End If

    '    End Sub
    '    Private Sub X1pose_BeforeCellPaint(ByVal sender As Object, ByVal e As BeforeCellPaintEventArgs)
    '        Dim bcx As DataGridViewLabelXColumn = TryCast(sender, DataGridViewLabelXColumn)

    '        If bcx IsNot Nothing Then

    '            ' Set the label image

    '            If IsDBNull(bcx.Text) Or bcx.Text = "" Then

    '                bcx.Image = ImageList1.Images("attente")
    '                bcx.Text = "<font color=""red"">attente</font>"
    '            ElseIf CBool(bcx.Text) = False Then
    '                bcx.Image = ImageList1.Images("attente")
    '                bcx.Text = "<font color=""red"">attente</font>"
    '            Else
    '                bcx.Image = ImageList1.Images("pose")
    '            End If
    '        End If
    '    End Sub

    '    Private Sub X2dispo_Initialize()
    '        Dim pb As DataGridViewButtonXColumn = TryCast(DataGridViewX1.Columns("status_equip"), DataGridViewButtonXColumn)

    '        '   Hook onto the BeforeCellPaint event so we can
    '        '   demonstrate cell customization

    '        If pb IsNot Nothing Then
    '            AddHandler pb.BeforeCellPaint, AddressOf X2dispo_BeforeCellPaint
    '        End If
    '    End Sub

    '    Private Sub X2dispo_BeforeCellPaint(ByVal sender As Object, ByVal e As BeforeCellPaintEventArgs)
    '        Dim pbc As DataGridViewButtonXCell = TryCast(DataGridViewX1.CurrentCell, DataGridViewButtonXCell)

    '        If pbc IsNot Nothing Then

    '            Dim bc As DataGridViewButtonXColumn = TryCast(DataGridViewX1.Columns(e.ColumnIndex), DataGridViewButtonXColumn)
    '            Dim s As String = Convert.ToString(pbc.Value)

    '            Select Case s
    '                Case "BLOCAGE"
    '                    'pbc.Value = "BLOCAGE"
    '                    bc.ColorTable = eButtonColor.Orange
    '                    Exit Select

    '                Case Else

    '                    'pbc.Value = "DISPO"
    '                    bc.ColorTable = eButtonColor.BlueOrb
    '                    Exit Select

    '            End Select

    '        End If
    '    End Sub

    '    Private Sub DataGridViewX1_CellContentClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs)
    '        Dim cell As DataGridViewButtonXCell = TryCast(DataGridViewX1.CurrentCell, DataGridViewButtonXCell)
    '        Dim cell2 As DataGridViewLabelXCell = TryCast(DataGridViewX1.CurrentCell, DataGridViewLabelXCell)

    '        Dim row As mydbDataSet.equipements_statusRow
    '        row = CType(CType(Equipements_statusBindingSource.Current, DataRowView).Row, mydbDataSet.equipements_statusRow)

    '        If cell IsNot Nothing Then
    '            Dim bc As DataGridViewButtonXColumn = TryCast(DataGridViewX1.Columns(e.ColumnIndex), DataGridViewButtonXColumn)
    '            '  DataGridViewX1.Columns(e.ColumnIndex)
    '            If bc IsNot Nothing Then
    '                If IsDBNull(cell.Value) Then cell.Value = "DISPO"
    '                Dim s As String = Convert.ToString(cell.Value)

    '                Select Case bc.Name
    '                    Case "Status_equip"
    '                        If row.pose = False Then
    '                            Dim info As New TaskDialogInfo("IMPOSSIBLE", eTaskDialogIcon.Exclamation, "Situation IMPOSSIBLE pour l'equipement " & row.repere_equipement, "vous ne pouvez declarer un equipement dispo si celui-ci nest pas posé ! ", eTaskDialogButton.Ok, eTaskDialogBackgroundColor.Red, Nothing, Nothing, Nothing, Nothing, Nothing)
    '                            Dim result As eTaskDialogResult = TaskDialog.Show(info)
    '                            cell.Value = Nothing
    '                            Exit Sub
    '                        End If
    '                        If s = "DISPO" Then
    '                            Dim info As New TaskDialogInfo("Declaration de blocage", eTaskDialogIcon.Hand, "Voullez vous declarer l'equipement " & row.repere_equipement & " en blocage", "vous voullez declarer une situation entrainent le blocage de l'equipement : " & row.repere_equipement & " ", eTaskDialogButton.Ok Or eTaskDialogButton.Cancel, eTaskDialogBackgroundColor.Red, Nothing, Nothing, Nothing, Nothing, Nothing)
    '                            Dim result As eTaskDialogResult = TaskDialog.Show(info)
    '                            Select Case result
    '                                Case eTaskDialogResult.Ok
    '                                    Dim motive As String = InputBox("Quel est le motif ?")

    '                                    Dim row1 As mydbDataSet.equipements_dispoRow
    '                                    Equipements_dispoBindingSource.Filter = "equipements_idequipement=" & "'" & row.idequipement & "'"
    '                                    If Equipements_dispoBindingSource.Count() > 0 Then
    '                                        Equipements_dispoBindingSource.RemoveFilter()
    '                                        Equipements_dispoBindingSource.Position = Equipements_dispoBindingSource.Find("equipements_idequipement", row.idequipement)
    '                                        row1 = CType(CType(Equipements_dispoBindingSource.Current, DataRowView).Row, mydbDataSet.equipements_dispoRow)
    '                                        row1.BeginEdit()
    '                                        row1.status = "BLOCAGE"
    '                                        row1.Motif = motive
    '                                        row1.qui = FormMain.user.Nom_user
    '                                        row1.date_dispo = CStr(Today.Date)
    '                                        row1.EndEdit()
    '                                    Else
    '                                        Equipements_dispoBindingSource.RemoveFilter()
    '                                        Equipements_dispoBindingSource.AddNew()
    '                                        'Equipements_dispoBindingSource.Position = Equipements_dispoBindingSource.Find("equipements_idequipement", row.idequipement)
    '                                        row1 = CType(CType(Equipements_dispoBindingSource.Current, DataRowView).Row, mydbDataSet.equipements_dispoRow)
    '                                        'row1.BeginEdit()
    '                                        row1.equipements_idequipement = row.idequipement
    '                                        row1.status = "BLOCAGE"
    '                                        row1.Motif = motive
    '                                        row1.qui = FormMain.user.Nom_user
    '                                        row1.date_dispo = CStr(Today.Date)
    '                                        row1.EndEdit()
    '                                    End If
    '                                    Equipements_dispoBindingSource.EndEdit()
    '                                    Equipements_dispoTableAdapter.Update(MydbDataSet.equipements_dispo)
    '                                    Equipements_dispoTableAdapter.Fill(MydbDataSet.equipements_dispo)
    '                                    ' cell2.Value = "true"
    '                                    Equipements_statusTableAdapter.Fill(MydbDataSet.equipements_status)
    '                                    motive = Nothing
    '                                Case eTaskDialogResult.Cancel
    '                                    Exit Sub
    '                            End Select

    '                            ' MessageBox.Show("Blocage de l'equipement ", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                            cell.Value = "BLOCAGE"
    '                            bc.ColorTable = eButtonColor.Magenta

    '                        Else

    '                            Dim info As New TaskDialogInfo("Mise à dispo", eTaskDialogIcon.Hand, "Voullez vous declarer l'equipement " & row.repere_equipement & " Mis à dispo ?", "vous voullez declarer l'equipement : " & row.repere_equipement & " Disponible suite à deblocage ", eTaskDialogButton.Ok Or eTaskDialogButton.Cancel, eTaskDialogBackgroundColor.Red, Nothing, Nothing, Nothing, Nothing, Nothing)
    '                            Dim result As eTaskDialogResult = TaskDialog.Show(info)
    '                            Select Case result
    '                                Case eTaskDialogResult.Ok

    '                                    Dim motive As String = InputBox("Quel est le motif ?")
    '                                    Dim row1 As mydbDataSet.equipements_dispoRow
    '                                    Equipements_dispoBindingSource.Filter = "equipements_idequipement=" & "'" & row.idequipement & "'"
    '                                    If Equipements_dispoBindingSource.Count() > 0 Then
    '                                        Equipements_dispoBindingSource.RemoveFilter()
    '                                        Equipements_dispoBindingSource.Position = Equipements_dispoBindingSource.Find("equipements_idequipement", row.idequipement)
    '                                        row1 = CType(CType(Equipements_dispoBindingSource.Current, DataRowView).Row, mydbDataSet.equipements_dispoRow)
    '                                        row1.BeginEdit()
    '                                        row1.status = "DISPO"
    '                                        row1.Motif = motive
    '                                        row1.qui = FormMain.user.Nom_user
    '                                        row1.date_dispo = CStr(Today.Date)
    '                                        row1.EndEdit()
    '                                    Else
    '                                        Equipements_dispoBindingSource.RemoveFilter()
    '                                        Equipements_dispoBindingSource.AddNew()
    '                                        row1 = CType(CType(Equipements_dispoBindingSource.Current, DataRowView).Row, mydbDataSet.equipements_dispoRow)
    '                                        'row1.BeginEdit()
    '                                        row1.equipements_idequipement = row.idequipement
    '                                        row1.status = "DISPO"
    '                                        row1.Motif = motive
    '                                        row1.qui = FormMain.user.Nom_user
    '                                        row1.date_dispo = CStr(Today.Date)
    '                                        row1.EndEdit()
    '                                    End If
    '                                    Equipements_dispoBindingSource.EndEdit()
    '                                    Equipements_dispoTableAdapter.Update(MydbDataSet.equipements_dispo)
    '                                    Equipements_dispoTableAdapter.Fill(MydbDataSet.equipements_dispo)
    '                                    ' cell2.Value = "true"
    '                                    Equipements_statusTableAdapter.Fill(MydbDataSet.equipements_status)
    '                                Case eTaskDialogResult.Cancel
    '                                    Exit Sub
    '                            End Select
    '                            'MessageBox.Show("Mise à dispo de l'equipement ", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                            'cell.Value = "DISPO"
    '                            bc.ColorTable = eButtonColor.BlueWithBackground

    '                        End If

    '                End Select
    '            End If
    '            Exit Sub
    '        End If
    '        If cell2 IsNot Nothing Then
    '            Dim bc As DataGridViewLabelXColumn = TryCast(DataGridViewX1.Columns(e.ColumnIndex), DataGridViewLabelXColumn)
    '            '  DataGridViewX1.Columns(e.ColumnIndex)
    '            If bc IsNot Nothing Then

    '                Select Case bc.Name

    '                    Case "Pose"
    '                        If IsDBNull(cell2.Value) Then cell2.Value = "attente"
    '                        Dim s As String = Convert.ToString(cell2.Value)

    '                        If s = "False" Then
    '                            Dim info As New TaskDialogInfo("Declaration de pose", eTaskDialogIcon.Hand, "Attention declaration de pose d'un equipement", "vous voullez declarer la pose de l'equipement : " & row.repere_equipement & " ", eTaskDialogButton.Ok Or eTaskDialogButton.Cancel, eTaskDialogBackgroundColor.Red, Nothing, Nothing, Nothing, Nothing, Nothing)
    '                            Dim result As eTaskDialogResult = TaskDialog.Show(info)
    '                            Select Case result
    '                                Case eTaskDialogResult.Ok
    '                                    Equipements_statusTableAdapter.ClearBeforeFill = True
    '                                    Dim row1 As mydbDataSet.equipementsRow
    '                                    EquipementsBindingSource.Position = EquipementsBindingSource.Find("idequipement", row.idequipement)
    '                                    row1 = CType(CType(EquipementsBindingSource.Current, DataRowView).Row, mydbDataSet.equipementsRow)
    '                                    row1.BeginEdit()
    '                                    row1.pose = True
    '                                    row1.qui = FormMain.user.Nom_user
    '                                    row1.date_pose = Today
    '                                    row1.EndEdit()
    '                                    EquipementsTableAdapter.Update(MydbDataSet.equipements)

    '                                    Dim row2 As mydbDataSet.equipements_dispoRow
    '                                    Equipements_dispoBindingSource.Filter = "equipements_idequipement=" & "'" & row.idequipement & "'"
    '                                    If Equipements_dispoBindingSource.Count() > 0 Then
    '                                        Equipements_dispoBindingSource.RemoveFilter()
    '                                        Equipements_dispoBindingSource.Position = Equipements_dispoBindingSource.Find("equipements_idequipement", row.idequipement)
    '                                        row2 = CType(CType(Equipements_dispoBindingSource.Current, DataRowView).Row, mydbDataSet.equipements_dispoRow)
    '                                        row2.BeginEdit()
    '                                        row2.status = "DISPO"
    '                                        row2.Motif = "Pose de l'equipement"
    '                                        row2.qui = FormMain.user.Nom_user
    '                                        row2.date_dispo = CStr(Today.Date)
    '                                        row2.EndEdit()
    '                                    Else
    '                                        Equipements_dispoBindingSource.RemoveFilter()
    '                                        Equipements_dispoBindingSource.AddNew()
    '                                        row2 = CType(CType(Equipements_dispoBindingSource.Current, DataRowView).Row, mydbDataSet.equipements_dispoRow)
    '                                        'row1.BeginEdit()
    '                                        row2.equipements_idequipement = row.idequipement
    '                                        row2.status = "DISPO"
    '                                        row2.Motif = "Pose de l'equipement"
    '                                        row2.qui = FormMain.user.Nom_user
    '                                        row2.date_dispo = CStr(Today.Date)
    '                                        row2.EndEdit()
    '                                    End If
    '                                    Equipements_dispoBindingSource.EndEdit()
    '                                    Equipements_dispoTableAdapter.Update(MydbDataSet.equipements_dispo)
    '                                    Equipements_dispoTableAdapter.Fill(MydbDataSet.equipements_dispo)

    '                                    EquipementsTableAdapter.Fill(MydbDataSet.equipements)
    '                                    ' cell2.Value = "true"
    '                                    Equipements_statusTableAdapter.Fill(MydbDataSet.equipements_status)
    '                                Case eTaskDialogResult.Cancel
    '                                    Exit Sub

    '                            End Select

    '                            'Else
    '                            '    cell2.Value = "False"
    '                        End If
    '                    Case "BLOCAGE"

    '                End Select
    '            End If
    '        End If

    '    End Sub

    '    Private Sub ComboBoxEx1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
    '        Equipements_statusBindingSource.RemoveFilter()
    '        If Not IsNothing(ComboBoxEx1.SelectedValue) Then
    '            If CheckBoxX1.Checked Then
    '                Equipements_statusBindingSource.Filter = "idlots=" & "'" & ComboBoxEx1.SelectedValue.ToString & "' and idsalle=" & "'" & ComboBoxEx2.SelectedValue.ToString & "'"
    '            Else
    '                Equipements_statusBindingSource.Filter = "idlots=" & "'" & ComboBoxEx1.SelectedValue.ToString & "'"
    '            End If
    '        End If
    '    End Sub

    '    Private Sub ButtonX1_Click(sender As System.Object, e As System.EventArgs)
    '        Equipements_statusBindingSource.RemoveFilter()

    '    End Sub

    '    Private Sub ButtonX2_Click(sender As System.Object, e As System.EventArgs)
    '        Equipements_statusBindingSource.RemoveFilter()
    '    End Sub

    '    Private Sub ComboBoxEx2_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
    '        Equipements_statusBindingSource.RemoveFilter()
    '        If Not IsNothing(Me.ComboBoxEx2.SelectedValue) Then
    '            If CheckBoxX1.Checked Then
    '                Equipements_statusBindingSource.Filter = "idlots=" & "'" & ComboBoxEx1.SelectedValue.ToString & "' and idsalle=" & "'" & ComboBoxEx2.SelectedValue.ToString & "'"
    '            Else
    '                Equipements_statusBindingSource.Filter = "idsalle=" & "'" & ComboBoxEx2.SelectedValue.ToString & "'"
    '            End If
    '        End If
    '    End Sub

    '#End Region
    Public Sub actualisation()
        'TODO: This line of code loads data into the 'MydbDataSet.equipements_dispo_histo' table. You can move, or remove it, as needed.
        Me.Equipements_dispo_histoTableAdapter.Fill(Me.MydbDataSet.equipements_dispo_histo)
        'TODO: This line of code loads data into the 'MydbDataSet.equipements_dispo' table. You can move, or remove it, as needed.
        Me.Equipements_dispoTableAdapter.Fill(Me.MydbDataSet.equipements_dispo)
        'TODO: This line of code loads data into the 'MydbDataSet.equipements' table. You can move, or remove it, as needed.
        Me.EquipementsTableAdapter.Fill(Me.MydbDataSet.equipements)
        'TODO: This line of code loads data into the 'MydbDataSet.lots' table. You can move, or remove it, as needed.
        Me.LotsTableAdapter.Fill(Me.MydbDataSet.lots)
        'TODO: This line of code loads data into the 'MydbDataSet.salles' table. You can move, or remove it, as needed.
        Me.SallesTableAdapter.Fill(Me.MydbDataSet.salles)
        Equipements_statusTableAdapter.Fill(MydbDataSet.equipements_status)
    End Sub

    'Private Sub ButtonX3_Click(sender As System.Object, e As System.EventArgs)
    '    Equipements_statusBindingSource.RemoveFilter()
    '    If Not IsNothing(ComboBoxEx1.SelectedValue) Then
    '        If CheckBoxX1.Checked Then
    '            Equipements_statusBindingSource.Filter = "idlots=" & "'" & ComboBoxEx1.SelectedValue.ToString & "' and idsalle=" & "'" & ComboBoxEx2.SelectedValue.ToString & "'"
    '        Else
    '            Equipements_statusBindingSource.Filter = "idlots=" & "'" & ComboBoxEx1.SelectedValue.ToString & "'"
    '        End If
    '    End If
    'End Sub

    Private Sub DataGridViewX1_VisibleChanged(sender As Object, e As System.EventArgs) Handles Equipements_statusBindingSource.ListChanged
        temps_global = 0
        temps_propo = 0
        temps_forc = 0
        Dim rea As Double = 0
        Dim raf As Double = 0
        Dim temp1 As Double = 0
        Dim temp2 As Double = 0
        Dim count As Double = 0
        Dim row As mydbDataSet.equipements_statusRow
        For Each c In Equipements_statusBindingSource
            row = CType(CType(c, DataRowView).Row, mydbDataSet.equipements_statusRow)
            Try

                If Not IsDBNull(row.temp_de_pose) And row.idlots = lot_principal Then
                    temps_global += CDbl(row.temp_de_pose)
                    temps_propo += CDbl(row.temps_Propose)
                    temps_forc += CDbl(row.temp_force)
                    If row.idlots = lot_principal Then
                        count += 1
                    End If
                    If row.avancement > 0 And row.pose = False Then
                        temp1 += CDbl(row.temp_de_pose * (row.avancement / 100))

                    End If
                    If row.pose = True Then
                        temp1 += CDbl(row.temp_de_pose)

                    End If

                End If
            Catch ex As Exception
                If ex.Message = "" Then

                End If
            End Try
        Next

        If temps_global > 0.0 Then rea = Math.Round((temp1 * 100) / temps_global)
        raf = temps_global - temp1
        LabelX4.Text = CStr(Math.Round(temps_global, 2))
        LabelX6.Text = CStr(Math.Round(temps_propo, 2))
        LabelX8.Text = CStr(Math.Round(temps_forc, 2))
        LabelX12.Text = CStr(Math.Round(rea, 2)) & " %"
        LabelX14.Text = CStr(Math.Round(raf, 2))
        LabelX10.Text = CStr(Math.Round(count, 2))
    End Sub

    'Private Sub DataGridViewX1_CellContentDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs)

    '    Dim pb As DataGridViewTextBoxColumn = TryCast(DataGridViewX1.Columns(e.ColumnIndex), DataGridViewTextBoxColumn)
    '    If pb IsNot Nothing Then
    '        If pb.Name = "RepereEquipementDataGridViewTextBoxColumn1" Then
    '            Dim FormEquipement As FormEquipement
    '            FormEquipement = New FormEquipement
    '            FormEquipement.MdiParent = Me.ParentForm
    '            FormEquipement.WindowState = FormWindowState.Maximized
    '            FormEquipement.mode = False
    '            Dim row33 As mydbDataSet.equipements_statusRow
    '            row33 = CType(CType(Me.Equipements_statusBindingSource.Current, DataRowView).Row, mydbDataSet.equipements_statusRow)

    '            FormEquipement.value2 = row33.idequipement

    '            FormEquipement.Show()
    '        End If
    '    End If
    'End Sub

    Private Sub SuperGridControl1_CellDoubleClick(sender As System.Object, e As DevComponents.DotNetBar.SuperGrid.GridCellDoubleClickEventArgs) Handles SuperGridControl1.CellDoubleClick

        Dim pb As SuperGridControl = TryCast(sender, SuperGridControl)
        If pb IsNot Nothing Then
            If pb.ActiveCell.ColumnIndex = 4 Then
                Dim FormEquipement As FormEquipement
                FormEquipement = New FormEquipement
                FormEquipement.MdiParent = Me.ParentForm
                FormEquipement.WindowState = FormWindowState.Maximized
                FormEquipement.mode = False
                Dim row33 As mydbDataSet.equipements_statusRow
                row33 = CType(CType(Me.Equipements_statusBindingSource.Current, DataRowView).Row, mydbDataSet.equipements_statusRow)

                FormEquipement.value2 = row33.idequipement

                FormEquipement.Show()
            End If
        End If
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
    'Private Sub X2Progress_BeforeCellPaint(ByVal sender As Object, ByVal e As GridPostRenderCellEventArgs) Handles SuperGridControl1.PostRenderCell
    '    Dim pbc As GridLabelXEditControl
    '    If e.GridCell.GridColumn.ColumnIndex = 3 Then

    '        pbc = TryCast(e.GridCell.GridColumn.RenderControl, GridLabelXEditControl)

    '        If pbc IsNot Nothing Then
    '            Select Case pbc.Text
    '                Case "BLOCAGE"
    '                    pbc.Text = "BLOCAGE"
    '                    pbc.Image = ImageList1.Images("Close2")
    '                    Exit Select

    '                Case "Dispo"
    '                    pbc.Text = "Dispo"
    '                    pbc.Image = ImageList1.Images("OK")
    '                    Exit Select
    '                Case Nothing
    '                    pbc.Text = "Attente"
    '                    pbc.Image = ImageList1.Images("Close2")
    '                    Exit Select
    '                Case Else

    '                    pbc.Text = "Attente"
    '                    pbc.Image = ImageList1.Images("Close2")
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

        ''Private Sub MyGridSwitchButtonEditControlValueChanged(ByVal sender As Object, ByVal e As EventArgs)

        ''    Dim cell As GridCell = EditorCell

        ''    If cell IsNot Nothing Then
        ''         cell.GridRow.Cells(3).InvalidateRender()
        ''        If CBool(cell.GridRow.Cells(17).Value) Then
        ''             MsgBox("depose")

        ''        ElseIf Not CBool(cell.GridRow.Cells(17).Value) Then

        ''              MsgBox("pose")
        ''        End If
        ''    End If
        ''End Sub

#End Region

    End Class

    Private Sub SuperGridControl1_CellClick(sender As Object, e As GridCellClickEventArgs) Handles SuperGridControl1.CellClick

        If e.GridCell.ColumnIndex = SuperGridControl1.PrimaryGrid.Columns("pose").ColumnIndex Then
            Me.EquipementsBindingSource.Position = Me.EquipementsBindingSource.Find("idequipement", e.GridCell.GridRow("idequipement").Value)
            Dim rowa As mydbDataSet.equipementsRow
            rowa = CType(CType(Me.EquipementsBindingSource.Current, DataRowView).Row, mydbDataSet.equipementsRow)
            If rowa.compose Then
               ' MsgBox("Composé " & rowa.repere_equipement.ToString)
                Dim Formposecompose As Formposecompose = New Formposecompose
                Formposecompose.idequip = rowa.idequipement
                Formposecompose.ShowDialog
                ' MsgBox("status " & Formposecompose.valid)
            Else
                If rowa.pose Then
                    rowa.BeginEdit()
                    rowa.pose = False
                    rowa.date_pose = Nothing
                    rowa.qui = FormMain.user.Nom_user
                    If  IsDBNull(rowa.modif) Then
                        rowa.modif = "# depose #" & Now.Date & " #"
                    Else
                        rowa.modif = "# depose #" & Now.Date & " #" & rowa.modif
                    End If

                    rowa.EndEdit()
                    EquipementsTableAdapter.Update(MydbDataSet.equipements)
                    EquipementsTableAdapter.Fill(MydbDataSet.equipements)

                Else
                    rowa.BeginEdit()
                    rowa.pose = True
                    rowa.date_pose = Now.Date
                    rowa.qui = FormMain.user.Nom_user
                    If  IsDBNull(rowa.modif) Then
                        rowa.modif = "# pose #" & Now.Date & " #"
                    Else
                        rowa.modif = "# pose #" & Now.Date & " #" & rowa.modif
                    End If

                    rowa.EndEdit()
                    EquipementsTableAdapter.Update(MydbDataSet.equipements)
                    EquipementsTableAdapter.Fill(MydbDataSet.equipements)
                End If

            End If
            Equipements_statusTableAdapter.Fill(MydbDataSet.equipements_status)
        End If
    End Sub

Private Sub DataGridViewX1_VisibleChanged( sender As Object,  e As ListChangedEventArgs) Handles Equipements_statusBindingSource.ListChanged

End Sub
      Private Sub InitializeGrid()
            Dim panel As GridPanel = superGridControl1.PrimaryGrid

            ' Set both the Slider and SitchButton columns to
            ' our own defined EditControls

            Dim column As GridColumn = panel.Columns("avancement")

   column.EditorType = GetType(MyGridProgressBarXEditControl)

        End Sub
    Private Class MyGridProgressBarXEditControl
            Inherits GridProgressBarXEditControl
            Public Sub New()
                TextVisible = True
            End Sub
         Public Overrides Sub InitializeContext(ByVal cell As GridCell, ByVal style As CellVisualStyle)
                MyBase.InitializeContext(cell, style)
            if     value > 100
                Text = Value.ToString() & " depassement"
                Else
                Text = Value.ToString() & " %"
            End If
            
            End Sub
End Class
End Class