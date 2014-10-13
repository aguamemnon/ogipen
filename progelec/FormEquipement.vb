Imports DevComponents.DotNetBar
Imports Nevron.Diagram.Extensions
Imports Nevron.Diagram.Filters
Imports Nevron.Dom
Imports Nevron.Diagram.Layout
Imports Nevron.Diagram.DataImport
Imports Nevron.GraphicsCore
Imports Nevron.Diagram
Imports Nevron.Diagram.Shapes
Imports Nevron.Diagram.WinForm
Imports Nevron.Diagram.DataStructures
Imports Nevron.Diagram.Templates

Public Class FormEquipement
    Inherits DevComponents.DotNetBar.OfficeForm
    Dim modif As Boolean = False
    Dim modif2 As Boolean = False
    Public value As String
    Public value2 As Integer
    Public mode As Boolean
    Private ctrl22 As Control
    Dim dataset_temp As DataSet
    Dim table_equip, table_equip2 As DataTable
    Dim table_liaison, table_liaison2 As DataTable
    Private highlightFillStyle As NColorFillStyle = Nothing
    Private highlightStrokeStyle As NStrokeStyle = Nothing

    Private Sub FormEquipement_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        AttachToEvents()
        highlightFillStyle = New NColorFillStyle(Color.FromArgb(80, Color.Red))
        highlightStrokeStyle = New NStrokeStyle(2, Color.Red)

        'TODO: This line of code loads data into the 'MydbDataSet.batiments' table. You can move, or remove it, as needed.
        Me.BatimentsTableAdapter.Fill(Me.MydbDataSet.batiments)
        'TODO: This line of code loads data into the 'MydbDataSet.troncons' table. You can move, or remove it, as needed.
        Me.TronconsTableAdapter.Fill(Me.MydbDataSet.troncons)
        'TODO: This line of code loads data into the 'MydbDataSet.cables_details' table. You can move, or remove it, as needed.

        'TODO: This line of code loads data into the 'MydbDataSet.cables' table. You can move, or remove it, as needed.
        Me.CablesTableAdapter.Fill(Me.MydbDataSet.cables)
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.lots'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.LotsTableAdapter.Fill(Me.MydbDataSet.lots)
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.salles'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.SallesTableAdapter.Fill(Me.MydbDataSet.salles)
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.categories'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.CategoriesTableAdapter.Fill(Me.MydbDataSet.categories)
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.departs'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.DepartsTableAdapter.Fill(Me.MydbDataSet.departs)
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.borniers'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.BorniersTableAdapter.Fill(Me.MydbDataSet.borniers)
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.equipements'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.EquipementsTableAdapter.Fill(Me.MydbDataSet.equipements)
        If mode = True Then
            Me.EquipementsBindingSource.AddNew()
            Me.ButtonX1.Text = "Enregistrer et Fermer"
            Me.Text = "Creation Equipement"
        Else

            Try

                Dim pos As Integer = Me.EquipementsBindingSource.Find("idequipement", value2)
                Me.EquipementsBindingSource.Position = pos
                'Dim match = (From x In Me.MydbDataSet.equipements Where x.Field(Of String)("repere equipement").ToString().EndsWith(value) Select x)
                'If match.Count > 0 Then
                '    Dim p As Integer = EquipementsBindingSource.Find("repere equipement", match.AsDataView.Item(0).Item("repere equipement"))
                '    EquipementsBindingSource.Position = p
                'End If
                Dim row As MydbDataSet.equipementsRow
                row = CType(CType(Me.EquipementsBindingSource.Current, DataRowView).Row, MydbDataSet.equipementsRow)
                Me.Text = row.repere_equipement.ToString
            Catch ex As System.Exception
                System.Windows.Forms.MessageBox.Show(ex.Message)
            End Try
            Try
                Me.Lst_equip_fournitureTableAdapter.Fill(Me.MydbDataSet.lst_equip_fourniture, New System.Nullable(Of Integer)(CType(value2, Integer)))
            Catch ex As System.Exception
                System.Windows.Forms.MessageBox.Show(ex.Message)
            End Try
            Me.ButtonX1.Text = "Modifier"
            For Each Me.ctrl22 In Me.Controls
                Me.ctrl22.Enabled = False
            Next
            Me.SuperTabControl1.Enabled = True
            Me.ButtonX1.Enabled = True
        End If
        autocomplete_champ()

    End Sub

    Private Sub ButtonX1_Click(sender As System.Object, e As System.EventArgs) Handles ButtonX1.Click

        If Me.ButtonX1.Text = "Nouveau" Then
            Me.EquipementsBindingSource.AddNew()
            Me.ButtonX1.Text = "Enregistrer et Fermer"

        ElseIf Me.ButtonX1.Text = "Modifier" Then

            For Each Me.ctrl22 In Me.Controls
                Me.ctrl22.Enabled = True
            Next
            mode = True
            Me.ButtonX1.Text = "Enregistrer et Fermer"
        Else
            Me.Validate()
            If Me.SuperValidator3.Validate() = False Then
                Exit Sub
            End If
            Me.ButtonX1.Text = "Nouveau"
            mode = False
            Me.EquipementsBindingSource.EndEdit()
            Me.EquipementsTableAdapter.Update(Me.MydbDataSet)
            Me.Close()

        End If

    End Sub

    Private Sub ButtonX2_Click_1(sender As System.Object, e As System.EventArgs) Handles ButtonX2.Click
        Me.DepartsBindingSource.Position -= 1

    End Sub

    Private Sub ButtonX4_Click(sender As System.Object, e As System.EventArgs) Handles ButtonX4.Click
        Me.DepartsBindingSource.Position += 1
    End Sub

    Public Sub autocomplete_champ()
        Dim col As New AutoCompleteStringCollection
        Dim i As Integer
        For i = 0 To Me.MydbDataSet.departs.Rows.Count - 1
            col.Add(Me.MydbDataSet.departs.Rows(i)("reference depart").ToString())
        Next
        Reference_departTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource
        Reference_departTextBox.AutoCompleteCustomSource = col
        Reference_departTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Me.DepartsBindingSource.AddNew()
        Me.Button3.Enabled = True
        Me.SerrageCheckBox.Enabled = True
        Me.Reference_departTextBox.Enabled = True
        Me.CoupleTextBox.Enabled = True
        Me.Button1.Enabled = False
        Me.Button7.Enabled = False
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Select Case MessageBox.Show("Vous allez supprimer un depart etes vous sur ?", "Suppression de depart", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            Case System.Windows.Forms.DialogResult.Yes
                Dim cpt As Integer = 0
                Dim cpt2 As Integer = 0
                Dim info As TaskDialogInfo
                Dim row As MydbDataSet.departsRow
                Dim Troncons_assocBindingSource As New BindingSource
                Dim Troncons_assocTableAdapter As New MydbDataSetTableAdapters.troncons_assocTableAdapter
                row = CType(CType(Me.DepartsBindingSource.Current, DataRowView).Row, MydbDataSet.departsRow)
                Try
                    cpt = Me.CablesBindingSource.Find("departs_iddeparts", row.iddepart.ToString())
                Catch ex As Exception

                End Try

                If cpt > 0 Then

                    info = New TaskDialogInfo("Erreur", eTaskDialogIcon.ShieldStop, "Suppression impossible ", FormMain.user.nom & " Vous ne pouvez supprimer le depart : " & row.reference_depart & " ?", eTaskDialogButton.Ok, eTaskDialogBackgroundColor.Red)

                    TaskDialog.Show(info)
                    Exit Sub
                Else
                    Troncons_assocTableAdapter.Fill(Me.MydbDataSet.troncons_assoc)

                    Troncons_assocBindingSource.DataSource = MydbDataSet

                    Troncons_assocBindingSource.DataMember = "troncons_assoc"
                    Troncons_assocBindingSource.Filter = "troncons = " & row.troncons_idtroncons

                    cpt2 = Troncons_assocBindingSource.Count
                    Do While cpt2 > 0

                        Troncons_assocBindingSource.RemoveAt(Troncons_assocBindingSource.Find("troncons", row.troncons_idtroncons))
                        Troncons_assocBindingSource.EndEdit()
                        Troncons_assocTableAdapter.Update(Me.MydbDataSet.troncons_assoc)

                        cpt2 = Troncons_assocBindingSource.Count

                    Loop
                    cpt2 = 0
                    Troncons_assocBindingSource.RemoveFilter()
                    Troncons_assocBindingSource.Filter = "troncons_tenant = " & row.troncons_idtroncons

                    cpt2 = Troncons_assocBindingSource.Count
                    Do While cpt2 > 0

                        Troncons_assocBindingSource.RemoveAt(Troncons_assocBindingSource.Find("troncons_tenant", row.troncons_idtroncons))
                        Troncons_assocBindingSource.EndEdit()
                        Troncons_assocTableAdapter.Update(Me.MydbDataSet.troncons_assoc)

                        cpt2 = Troncons_assocBindingSource.Count

                    Loop
                    Dim repere_trc As Integer = row.troncons_idtroncons
                    Me.DepartsBindingSource.RemoveCurrent()
                    Me.DepartsBindingSource.EndEdit()
                    Me.DepartsTableAdapter.Update(Me.MydbDataSet.departs)
                    Me.DepartsTableAdapter.Fill(Me.MydbDataSet.departs)

                    Me.TronconsBindingSource.Position = Me.TronconsBindingSource.Find("idtroncons", repere_trc)
                    Me.TronconsBindingSource.RemoveCurrent()

                    Me.TronconsTableAdapter.Update(Me.MydbDataSet.troncons)
                    Me.TronconsTableAdapter.Fill(Me.MydbDataSet.troncons)

                End If

            Case System.Windows.Forms.DialogResult.No

        End Select
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click

        Me.Validate()
        If Me.SuperValidator1.Validate() = False Then
            Exit Sub
        End If
        If modif = True Then
            Me.DateDateTimePicker.Value = Today()
            Me.DateDateTimePicker.Enabled = False

            Dim row As MydbDataSet.departsRow
            row = CType(CType(Me.DepartsBindingSource.Current, DataRowView).Row, MydbDataSet.departsRow)

            Me.TronconsBindingSource.Position = Me.TronconsBindingSource.Find("idtroncons", row.troncons_idtroncons)
            row.qui = FormMain.user.Nom_user

            Dim row3 As MydbDataSet.tronconsRow

            row3 = CType(CType(Me.TronconsBindingSource.Current, DataRowView).Row, MydbDataSet.tronconsRow)
            row3.repere_troncon = Me.Reference_departTextBox.Text

            row3.Qui = FormMain.user.Nom_user
            row3.detailmodif = "Modification Depart"

            Me.TronconsBindingSource.EndEdit()
            Me.TronconsTableAdapter.Update(Me.MydbDataSet.troncons)
            Me.TronconsTableAdapter.Fill(Me.MydbDataSet.troncons)
            Me.DepartsBindingSource.EndEdit()
            Me.DepartsTableAdapter.Update(Me.MydbDataSet.departs)
            Me.DepartsTableAdapter.Fill(Me.MydbDataSet.departs)

        Else
            Me.DateDateTimePicker.Value = Today()
            Me.DateDateTimePicker.Enabled = False
            Dim row3 As MydbDataSet.tronconsRow
            Me.TronconsBindingSource.AddNew()
            row3 = CType(CType(Me.TronconsBindingSource.Current, DataRowView).Row, MydbDataSet.tronconsRow)
            row3.repere_troncon = Me.Reference_departTextBox.Text
            row3.Types_troncons_idTypes_troncons = 2
            row3.virtuel = False
            row3.terminal = True
            row3.Qui = FormMain.user.Nom_user
            row3.detailmodif = "creation depart"
            row3.segregations_idsegregations = 0
            row3.discrimination = True
            row3.salles = CInt(Me.ComboBoxEx1.SelectedValue.ToString())
            row3.salles_idsalle = CInt(Me.ComboBoxEx1.SelectedValue.ToString())
            Me.TronconsBindingSource.EndEdit()
            Me.TronconsTableAdapter.Update(Me.MydbDataSet.troncons)
            Me.TronconsTableAdapter.Fill(Me.MydbDataSet.troncons)
            '     Me.TronconsBindingSource.DataSource = Me.TronconsTableAdapter
            '   Me.TronconsBindingSource.ResetBindings(True)
            Me.TronconsBindingSource.Position = Me.TronconsBindingSource.Find("repere troncon", Me.Reference_departTextBox.Text)
            row3 = CType(CType(Me.TronconsBindingSource.Current, DataRowView).Row, MydbDataSet.tronconsRow)

            Dim row2 As MydbDataSet.equipementsRow
            row2 = CType(CType(Me.EquipementsBindingSource.Current, DataRowView).Row, MydbDataSet.equipementsRow)

            Dim row As MydbDataSet.departsRow
            row = CType(CType(Me.DepartsBindingSource.Current, DataRowView).Row, MydbDataSet.departsRow)
            row.equipements_idequipement = row2.idequipement
            row.troncons_idtroncons = row3.idtroncons
            row.qui = FormMain.user.Nom_user

            Me.DepartsBindingSource.EndEdit()
            Me.DepartsTableAdapter.Update(Me.MydbDataSet.departs)
            Me.DepartsTableAdapter.Fill(Me.MydbDataSet.departs)
        End If

        '  Me.DepartsBindingSource.DataSource = Me.DepartsTableAdapter
        '  Me.DepartsBindingSource.ResetBindings(False)
        Me.Button1.Enabled = True
        Me.Button7.Enabled = True
        Me.Button3.Enabled = False
        Me.modif = False
        Me.Reference_departTextBox.Enabled = False
        Me.CoupleTextBox.Enabled = False
        Me.SerrageCheckBox.Enabled = False
    End Sub

    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click
        Me.BorniersBindingSource.AddNew()
        Me.Button4.Enabled = True
        Me.Button6.Enabled = False
        Me.Button8.Enabled = False
        Me.SerrageTextBox.Enabled = True
        Me.Reference_bornierTextBox.Enabled = True
        Me.CoupleCheckBox.Enabled = True

    End Sub

    Private Sub ButtonX5_Click(sender As System.Object, e As System.EventArgs) Handles ButtonX5.Click
        Me.BorniersBindingSource.Position -= 1
    End Sub

    Private Sub ButtonX3_Click(sender As System.Object, e As System.EventArgs) Handles ButtonX3.Click
        Me.BorniersBindingSource.Position += 1
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        Me.Validate()
        If Me.SuperValidator2.Validate() = False Then
            Exit Sub
        End If
        If modif2 = True Then

            Me.DateDateTimePicker1.Value = Today()
            Me.DateDateTimePicker1.Enabled = False
            Dim row As MydbDataSet.borniersRow
            row = CType(CType(Me.BorniersBindingSource.Current, DataRowView).Row, MydbDataSet.borniersRow)
            Me.TronconsBindingSource.Position = Me.TronconsBindingSource.Find("idtroncons", row.troncons_idtroncons)
            row.qui = FormMain.user.Nom_user
            Dim row3 As MydbDataSet.tronconsRow

            row3 = CType(CType(Me.TronconsBindingSource.Current, DataRowView).Row, MydbDataSet.tronconsRow)
            row3.repere_troncon = Me.Reference_bornierTextBox.Text

            row3.Qui = FormMain.user.Nom_user
            row3.detailmodif = "Modification Bornier"

            Me.TronconsBindingSource.EndEdit()
            Me.TronconsTableAdapter.Update(Me.MydbDataSet.troncons)
            Me.TronconsTableAdapter.Fill(Me.MydbDataSet.troncons)
            Me.BorniersBindingSource.EndEdit()
            Me.BorniersTableAdapter.Update(Me.MydbDataSet.borniers)
            Me.BorniersTableAdapter.Fill(Me.MydbDataSet.borniers)

        Else
            Me.DateDateTimePicker1.Value = Today()
            Me.DateDateTimePicker1.Enabled = False
            Dim row3 As MydbDataSet.tronconsRow
            Me.TronconsBindingSource.AddNew()
            row3 = CType(CType(Me.TronconsBindingSource.Current, DataRowView).Row, MydbDataSet.tronconsRow)
            row3.repere_troncon = Me.Reference_bornierTextBox.Text
            row3.Types_troncons_idTypes_troncons = 2
            row3.virtuel = False
            row3.terminal = True
            row3.Qui = FormMain.user.Nom_user
            row3.detailmodif = "creation Bornier"
            row3.segregations_idsegregations = 0
            row3.discrimination = True
            row3.salles = CInt(Me.ComboBoxEx1.SelectedValue.ToString())
            row3.salles_idsalle = CInt(Me.ComboBoxEx1.SelectedValue.ToString())
            Me.TronconsBindingSource.EndEdit()
            Me.TronconsTableAdapter.Update(Me.MydbDataSet.troncons)
            Me.TronconsTableAdapter.Fill(Me.MydbDataSet.troncons)
            '     Me.TronconsBindingSource.DataSource = Me.TronconsTableAdapter
            '   Me.TronconsBindingSource.ResetBindings(True)
            Me.TronconsBindingSource.Position = Me.TronconsBindingSource.Find("repere troncon", Me.Reference_bornierTextBox.Text)
            row3 = CType(CType(Me.TronconsBindingSource.Current, DataRowView).Row, MydbDataSet.tronconsRow)

            Dim row2 As MydbDataSet.equipementsRow
            row2 = CType(CType(Me.EquipementsBindingSource.Current, DataRowView).Row, MydbDataSet.equipementsRow)

            Dim row As MydbDataSet.borniersRow
            row = CType(CType(Me.BorniersBindingSource.Current, DataRowView).Row, MydbDataSet.borniersRow)
            row.equipements_idequipement = row2.idequipement
            row.troncons_idtroncons = row3.idtroncons
            row.qui = FormMain.user.Nom_user

            Me.BorniersBindingSource.EndEdit()
            Me.BorniersTableAdapter.Update(Me.MydbDataSet.borniers)
            Me.BorniersTableAdapter.Fill(Me.MydbDataSet.borniers)
        End If
        Me.Button6.Enabled = True
        Me.Button8.Enabled = True
        Me.Button4.Enabled = False
        Me.modif2 = False
        Me.Reference_bornierTextBox.Enabled = False
        Me.CoupleCheckBox.Enabled = False
        Me.SerrageTextBox.Enabled = False
        '  Me.DepartsBindingSource.DataSource = Me.DepartsTableAdapter
        '  Me.DepartsBindingSource.ResetBindings(False)
    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        Select Case MessageBox.Show("Vous allez supprimer un Bornier etes vous sur ?", "Suppression de bornier", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            Case System.Windows.Forms.DialogResult.Yes
                Dim cpt As Integer
                Dim cpt2 As Integer = 0
                Dim info As TaskDialogInfo
                Dim Troncons_assocBindingSource As New BindingSource
                Dim Troncons_assocTableAdapter As New MydbDataSetTableAdapters.troncons_assocTableAdapter
                Dim parcours_detailBindingSource As New BindingSource
                Dim parcours_detailTableAdapter As New MydbDataSetTableAdapters.parcoursTableAdapter
                Dim parcoursBindingSource As New BindingSource
                Dim parcoursTableAdapter As New MydbDataSetTableAdapters.parcoursTableAdapter
                Dim row As MydbDataSet.borniersRow
                row = CType(CType(Me.BorniersBindingSource.Current, DataRowView).Row, MydbDataSet.borniersRow)
                Try
                    cpt = Me.CablesBindingSource.Find("borniers_idbornier", row.idbornier.ToString())
                Catch ex As Exception

                End Try

                If cpt > 0 Then

                    info = New TaskDialogInfo("Erreur", eTaskDialogIcon.ShieldStop, "Suppression impossible ", FormMain.user.nom & " Vous ne pouvez supprimer le bornier : " & row.reference_bornier & " ?", eTaskDialogButton.Ok, eTaskDialogBackgroundColor.Red)

                    TaskDialog.Show(info)
                    Exit Sub
                Else

                    Troncons_assocTableAdapter.Fill(Me.MydbDataSet.troncons_assoc)
                    Troncons_assocBindingSource.DataSource = MydbDataSet
                    Troncons_assocBindingSource.DataMember = "troncons_assoc"
                    Troncons_assocBindingSource.Filter = "troncons = " & row.troncons_idtroncons

                    cpt2 = Troncons_assocBindingSource.Count
                    Do While cpt2 > 0

                        Troncons_assocBindingSource.RemoveAt(Troncons_assocBindingSource.Find("troncons", row.troncons_idtroncons))
                        Troncons_assocBindingSource.EndEdit()
                        Troncons_assocTableAdapter.Update(Me.MydbDataSet.troncons_assoc)

                        cpt2 = Troncons_assocBindingSource.Count
                    Loop

                    Troncons_assocBindingSource.RemoveFilter()
                    Troncons_assocBindingSource.Filter = "troncons_tenant = " & row.troncons_idtroncons

                    cpt2 = Troncons_assocBindingSource.Count
                    Do While cpt2 > 0

                        Troncons_assocBindingSource.RemoveAt(Troncons_assocBindingSource.Find("troncons_tenant", row.troncons_idtroncons))
                        Troncons_assocBindingSource.EndEdit()
                        Troncons_assocTableAdapter.Update(Me.MydbDataSet.troncons_assoc)

                        cpt2 = Troncons_assocBindingSource.Count

                    Loop
                    cpt2 = 0

                    Dim repere_trc As Integer = row.troncons_idtroncons
                    Me.BorniersBindingSource.RemoveCurrent()
                    'Me.BorniersBindingSource.EndEdit()
                    Me.BorniersTableAdapter.Update(Me.MydbDataSet.borniers)
                    Me.BorniersTableAdapter.Fill(Me.MydbDataSet.borniers)
                    Me.TronconsBindingSource.Position = Me.TronconsBindingSource.Find("idtroncons", repere_trc)
                    Me.TronconsBindingSource.RemoveCurrent()
                    Me.TronconsBindingSource.EndEdit()
                    Me.TronconsTableAdapter.Update(Me.MydbDataSet.troncons)
                    Me.TronconsTableAdapter.Fill(Me.MydbDataSet.troncons)

                End If

            Case System.Windows.Forms.DialogResult.No

        End Select
    End Sub

    Private Sub Button7_Click(sender As System.Object, e As System.EventArgs) Handles Button7.Click
        Me.Button3.Enabled = True
        Me.SerrageCheckBox.Enabled = True
        Me.Reference_departTextBox.Enabled = True
        Me.CoupleTextBox.Enabled = True
        Me.modif = True
        Me.Button1.Enabled = False
        Me.Button7.Enabled = False
    End Sub

    Private Sub Button8_Click(sender As System.Object, e As System.EventArgs) Handles Button8.Click
        Me.Button4.Enabled = True
        Me.SerrageTextBox.Enabled = True
        Me.Reference_bornierTextBox.Enabled = True
        Me.CoupleCheckBox.Enabled = True
        Me.modif2 = True
        Me.Button6.Enabled = False
        Me.Button8.Enabled = False
    End Sub

    Private Sub ButtonX6_Click(sender As System.Object, e As System.EventArgs) Handles ButtonX6.Click
        Dim info As TaskDialogInfo
        Dim cpt As Integer = 0
        Dim cpt2 As Integer = 0
        Dim cpt3 As Integer = 0
        Dim cpt4 As Integer = 0
        Dim motif As String = ""
        Dim cablesb As New BindingSource

        Dim cables_adap As New MydbDataSetTableAdapters.cablesTableAdapter
        Dim row As MydbDataSet.equipementsRow
        row = CType(CType(Me.EquipementsBindingSource.Current, DataRowView).Row, MydbDataSet.equipementsRow)
        info = New TaskDialogInfo("Suppression equipement", eTaskDialogIcon.ShieldStop, "Validation de la demande ", FormMain.user.nom & " Voullez-vous Supprimer l'equipement : " & row.repere_equipement & " ?", eTaskDialogButton.Ok Or eTaskDialogButton.Cancel, eTaskDialogBackgroundColor.Red)

        Dim result As eTaskDialogResult = TaskDialog.Show(info)

        cables_adap.Fill(Me.MydbDataSet.cables)

        cablesb.DataSource = MydbDataSet

        cablesb.DataMember = "cables"

        Select Case result

            Case eTaskDialogResult.Ok

                Try

                    cpt = cablesb.Find("idequipement", row.idequipement.ToString)
                    cpt4 = cablesb.Find("idequipement2", row.idequipement.ToString)
                    cpt2 = Me.DepartsBindingSource.Count
                    cpt3 = Me.BorniersBindingSource.Count

                Catch ex As Exception

                End Try
                If cpt > 0 Then
                    motif += " Au noins 1 Cable part de l'equipement. "
                End If
                If cpt4 > 0 Then
                    motif += " Au noins 1 Cable arrive sur l'equipement. "
                End If
                If cpt2 > 0 Then
                    motif += cpt2.ToString & " depart(s) existe(nt). "
                End If
                If cpt3 > 0 Then
                    motif += cpt3.ToString & " Bornier(s) existe(nt).  "
                End If

                If cpt > 0 Or cpt2 > 0 Or cpt3 > 0 Or cpt4 > 0 Then
                    info = New TaskDialogInfo("Suppression equipement", eTaskDialogIcon.ShieldStop, "Impossible ", FormMain.user.nom & " Vous ne pouvez Supprimer l'equipement : " & row.repere_equipement & " . il y as : " & motif, eTaskDialogButton.Ok, eTaskDialogBackgroundColor.Red)

                    TaskDialog.Show(info)
                    Exit Sub
                Else
                    Me.EquipementsBindingSource.RemoveCurrent()
                    Me.EquipementsBindingSource.EndEdit()
                    Me.EquipementsTableAdapter.Update(Me.MydbDataSet.equipements)
                    Me.EquipementsTableAdapter.Fill(Me.MydbDataSet.equipements)
                    Me.Close()
                End If

            Case eTaskDialogResult.Cancel

                Exit Sub

        End Select
    End Sub

    Private Sub CablesDataGridViewX_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles CablesDataGridViewX.CellDoubleClick
        Dim FormCable As FormCable
        FormCable = New FormCable
        FormCable.MdiParent = Me.ParentForm
        FormCable.WindowState = FormWindowState.Maximized
        FormCable.mode = False
        Dim row As MydbDataSet.cablesRow
        row = CType(CType(Me.CablesBindingSource1.Current, DataRowView).Row, MydbDataSet.cablesRow)
        FormCable.value = CStr(row.idcable) 'CStr(Repere_equipementComboBox.Text)
        FormCable.Show()
    End Sub

    Private Sub CablesDataGridViewX1_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles CablesDataGridViewX1.CellDoubleClick
        Dim FormCable As FormCable
        FormCable = New FormCable
        FormCable.MdiParent = Me.ParentForm
        FormCable.WindowState = FormWindowState.Maximized
        FormCable.mode = False
        Dim row As MydbDataSet.cablesRow
        row = CType(CType(Me.CablesBindingSource.Current, DataRowView).Row, MydbDataSet.cablesRow)
        FormCable.value = CStr(row.idcable) 'CStr(Repere_equipementComboBox.Text)
        FormCable.Show()
    End Sub

    Private Sub ButtonX7_Click(sender As System.Object, e As System.EventArgs) Handles ButtonX7.Click
        Dim lstFormFourni_equip As FormFourni_equip = New FormFourni_equip()
        lstFormFourni_equip.Idtrc = CInt(value2)
        lstFormFourni_equip.ShowDialog()
        Me.Lst_equip_fournitureTableAdapter.Fill(MydbDataSet.lst_equip_fourniture, CType(value2, Integer?))
    End Sub

    Private Sub mysqlimport()
        NDrawingView1.BeginInit()

        ' display the document in the view
        NDrawingView1.Document = NDrawingDocument1
        NDrawingDocument1.Reset()
        NDrawingDocument1.SizeToContent()
        NDrawingDocument1.AutoBoundsMode = AutoBoundsMode.AutoSizeToContent

        ' configure the view
        NDrawingView1.ViewLayout = ViewLayout.Normal
        NDrawingView1.Grid.Visible = False
        NDrawingView1.GlobalVisibility.ShowPorts = False
        NDrawingView1.HorizontalRuler.Visible = True
        NDrawingView1.VerticalRuler.Visible = True

        ' create two stylesheets - one for the vertices and one for the edges
        Dim vertexStyleSheet As New NStyleSheet()

        vertexStyleSheet.Name = "Vertices"

        NDrawingDocument1.StyleSheets.AddChild(vertexStyleSheet)

        Dim edgeStyleSheet As New NStyleSheet()
        edgeStyleSheet.Name = "Edges"
        edgeStyleSheet.Style.StartArrowheadStyle = New NArrowheadStyle(ArrowheadShape.Circle, "", New NSizeL(5, 5), New NColorFillStyle(Color.Gray), New NStrokeStyle(1, Color.Black))
        edgeStyleSheet.Style.EndArrowheadStyle = New NArrowheadStyle(ArrowheadShape.Arrow, "", New NSizeL(5, 5), New NColorFillStyle(Color.Gray), New NStrokeStyle(1, Color.Black))
        NDrawingDocument1.StyleSheets.AddChild(edgeStyleSheet)

        ' configure the graph data source importer
        Dim GraphImporter As New NGraphDataSourceImporter()

        ' set the document in the active layer of which the shapes will be imported
        GraphImporter.Document = NDrawingDocument1
        dataset_temp = New DataSet
        table_equip2 = New DataTable
        table_liaison2 = New DataTable
        table_equip = New DataTable
        table_liaison = New DataTable
        dataset_temp.Tables.Add(table_equip)
        dataset_temp.Tables.Add(table_liaison)
        dataset_temp.Tables.Add(table_equip2)
        dataset_temp.Tables.Add(table_liaison2)
        table_equip = Me.MydbDataSet.equipements.CopyToDataTable
        table_liaison = Me.MydbDataSet.cables.CopyToDataTable

        table_equip2 = table_equip.Clone
        'Me.MydbDataSet.equipements.CopyToDataTable

        table_liaison2 = table_liaison.Clone
        'Me.MydbDataSet.cables.CopyToDataTable

        '  table_equip2.Rows.Clear()
        ' table_liaison2.Rows.Clear()
        For Each dr As DataRow In table_liaison.Rows
            If CInt(dr("idequipement")) = value2 Then
                table_liaison2.ImportRow(dr)
            ElseIf CInt(dr("idequipement2")) = value2 Then
                table_liaison2.ImportRow(dr)
            End If

        Next
        If table_liaison2.Rows.Count > 0 Then
            Dim idtest, idtest2 As Integer

            For Each dr As DataRow In table_liaison2.Rows
                idtest = CInt(dr("idequipement"))
                idtest2 = CInt(dr("idequipement2"))
                For Each dr2 As DataRow In table_equip.Rows
                    If CInt(dr2("idequipement")) = idtest Then
                        If table_equip2.Select("idequipement=" & idtest).Count = 0 Then
                            table_equip2.ImportRow(dr2)
                        End If

                    ElseIf CInt(dr2("idequipement")) = idtest2 Then
                        If table_equip2.Select("idequipement=" & idtest2).Count = 0 Then
                            table_equip2.ImportRow(dr2)
                        End If
                    End If

                Next
            Next
        End If

        GraphImporter.VertexDataSource = table_equip2
        GraphImporter.EdgeDataSource = table_liaison2

        'GraphImporter.VertexDataSource = Me.MydbDataSet.equipements
        'GraphImporter.EdgeDataSource = Me.MydbDataSet.cables

        ' vertex records are uniquely identified by their Id (in the Pages table)
        ' edges link the vertices with the FromPageId and ToPageId (in the Links table)
        GraphImporter.VertexIdColumnName = "idequipement"
        GraphImporter.FromVertexIdColumnName = "idequipement"
        GraphImporter.ToVertexIdColumnName = "idequipement2"

        ' create vertices as rectangles shapes, with default size (60, 30)
        Dim shapesFactory As New NBasicShapesFactory()
        shapesFactory.DefaultSize = New NSizeF(150, 60)

        GraphImporter.VertexShapesFactory = shapesFactory
        GraphImporter.VertexShapesName = BasicShapes.Rectangle.ToString()

        ' set stylesheets to be applied to imported vertices and edges
        GraphImporter.VertexStyleSheetName = "Vertices"

        GraphImporter.EdgeStyleSheetName = "Edges"

        Dim shapes As NNodeList = NDrawingDocument1.ActiveLayer.Children(NFilters.Shape2D)
        ' use layered graph layout
        Dim layout As New NLayeredGraphLayout
        'layout.Direction = LayoutDirection.TopToBottom
        ' layout.LayerAlignment = RelativeAlignment.Center

        'layout.Direction = LayoutDirection.TopToBottom
        'layout.EdgeRouting = LayeredLayoutEdgeRouting.Orthogonal
        'layout.NodeRank = LayeredLayoutNodeRank.Optimal
        'layout.PlugSpacing.Mode = PlugSpacingMode.Proportional
        'layout.PlugSpacing.Offset = 0
        'layout.LayerAlignment = RelativeAlignment.Near
        'layout.NodeAlignment = RelativeAlignment.Center
        'layout.SelfLoopSpacingFactor = 0.25F
        'layout.VertexSpacing = 40
        'layout.LayerSpacing = 40
        'layout.StraightenLines = False
        'layout.UseSingleBus = False
        'layout.Compact = False

        'layout.Layout(shapes, New NDrawingLayoutContext(NDrawingDocument1))
        Dim shapes2 As NNodeList = NDrawingDocument1.ActiveLayer.Children(NFilters.Shape2D)

        ' create a layout context
        Dim layoutContext As NLayoutContext = New NLayoutContext()
        layoutContext.GraphAdapter = New NShapeGraphAdapter()
        layoutContext.BodyAdapter = New NShapeBodyAdapter(NDrawingDocument1)
        layoutContext.BodyContainerAdapter = New NDrawingBodyContainerAdapter(NDrawingDocument1)

        ' layout the shapes
        If Not layout Is Nothing Then
            layout.Layout(shapes, layoutContext)
        End If

        ' resize document to fit all shapes
        NDrawingDocument1.SizeToContent()

        GraphImporter.Layout = layout

        ' subscribe for the vertex imported event,
        ' which is raised when a shape was created for a data source record
        AddHandler GraphImporter.VertexImported, AddressOf OnVertexImported
        AddHandler GraphImporter.EdgeImported, AddressOf OnedgeImported
        ' import
        GraphImporter.Import()

        ' end view init

        NDrawingView1.EndInit()
    End Sub

    Private Sub ButtonX8_Click(sender As System.Object, e As System.EventArgs) Handles ButtonX8.Click
        mysqlimport()
    End Sub
    Private Sub OnedgeImported(ByVal dataSourceImporter As NDataSourceImporter, ByVal shape As NShape, ByVal record As INDataRecord)
        Dim text As String = record.GetColumnValue("segregations_idsegregations").ToString

        shape.Text = record.GetColumnValue("segregations_idsegregations").ToString()
    End Sub
    Private Sub OnVertexImported(ByVal dataSourceImporter As NDataSourceImporter, ByVal shape As NShape, ByVal record As INDataRecord)
        ' display the page title in the shape
        Dim typetrc As String = record.GetColumnValue("repere equipement").ToString()
        Dim segtrc As String = record.GetColumnValue("lots_idlots").ToString()
        Dim tx1trc As String = record.GetColumnValue("designation").ToString()
        Dim tx2trc As String = record.GetColumnValue("designation").ToString()
        If tx2trc = "" Then
            tx2trc = "0"
        End If
        If tx1trc = "" Then
            tx1trc = "0"
        End If
        shape.Text = record.GetColumnValue("repere equipement").ToString()

        shape.Style.FillStyle = New NColorFillStyle(Color.FromArgb(50, &HCC, 0, 0))

        shape.Labels.RemoveAllChildren()

        Dim boundsLabel As NBoundsLabel = New NBoundsLabel("Label 1, Wrapped", shape.UniqueId, New Nevron.Diagram.NMargins(0, 0, 0, 50))
        boundsLabel.Mode = BoxTextMode.Stretch
        shape.Labels.AddChild(boundsLabel)

        shape.Labels.DefaultLabelUniqueId = boundsLabel.UniqueId

        boundsLabel = New NBoundsLabel(typetrc.ToString(), shape.UniqueId, New Nevron.Diagram.NMargins(0, 0, 30, 0))
        boundsLabel.Mode = BoxTextMode.Wrap
        shape.Labels.AddChild(boundsLabel)
        'boundsLabel = New NBoundsLabel("Mono :" & New System.Nullable(Of Integer)(CInt(tx1trc.ToString())) & " % Multi :" & New System.Nullable(Of Integer)(CInt(tx2trc.ToString())) & " %", shape.UniqueId, New Nevron.Diagram.NMargins(0, 0, 80, 0))
        'boundsLabel.Mode = BoxTextMode.Wrap
        'shape.Labels.AddChild(boundsLabel)

        '      shape(1, 1).Text = record.GetColumnValue("Type").ToString()

        If shape.Text Is Nothing Then
            shape.Text = "Title not specified"
        Else
            shape.Text = record.GetColumnValue("repere equipement").ToString()
        End If

        shape.SizeToText(New NMarginsF(10))

        ' Dim cshape As NCompositeShape = TryCast(shape, NCompositeShape)
        Select Case segtrc.ToString()

            Case Is = "0"
                ' shape.Bounds = New NRectanglePath(0, 0, 80, 80)
                shape.Style.FillStyle = New NColorFillStyle(Color.Cyan)

            Case Is = "1"
                '  shape.Primitives.AddChild(New NRectanglePath(0, 0, 80, 80))
                shape.Style.FillStyle = New NColorFillStyle(Color.CornflowerBlue)
            Case Is = "2"
                ' shape.Primitives.AddChild(New NEllipsePath(0, 0, 80, 80))
                shape.Style.FillStyle = New NColorFillStyle(Color.Violet)
            Case Is = "3"
                ' shape.Primitives.AddChild(New NEllipsePath(0, 0, 80, 80))
                shape.Style.FillStyle = New NColorFillStyle(Color.GreenYellow)
            Case Is = "4"
                ' shape.Primitives.AddChild(New NEllipsePath(0, 0, 80, 80))
                shape.Style.FillStyle = New NColorFillStyle(Color.DarkGray)
            Case Is = "5"
                ' shape.Primitives.AddChild(New NEllipsePath(0, 0, 80, 80))
                shape.Style.FillStyle = New NColorFillStyle(Color.Yellow)
            Case Is = "6"
                ' shape.Primitives.AddChild(New NEllipsePath(0, 0, 80, 80))
                shape.Style.FillStyle = New NColorFillStyle(Color.Gold)

        End Select

        Dim url As Object = record.GetColumnValue("designation")
        If url Is Nothing Or url.ToString().Length = 0 Then
            shape.Style.InteractivityStyle = New NInteractivityStyle("Type Non Specifié")
        Else
            shape.Style.InteractivityStyle = New NInteractivityStyle(url.ToString())
        End If

        shape.UpdateModelBounds()
        shape.CreateShapeElements(ShapeElementsMask.Ports)
        shape.Ports.AddChild(New NDynamicPort(New NContentAlignment(), DynamicPortGlueMode.GlueToContour))

        shape.SizeToText(New NMarginsF(10))

    End Sub

    Private Sub UpdateHighlights()
        ClearHighlights()

        ' get the selected shape
        Dim shape As NShape = (TryCast(NDrawingView1.Selection.AnchorNode, NShape))
        If shape Is Nothing Then
            NDrawingDocument1.SmartRefreshAllViews()
            Return
        End If

        ' build the graph in which the shape resides
        Dim graphBuilder As NGraphBuilder = New NGraphBuilder(New NShapeGraphAdapter(), New NGraphPartFactory())

        Dim map As NObjectGraphPartMap
        Dim graph As NGraph = graphBuilder.BuildGraph(shape, map)

        If graph Is Nothing Then
            NDrawingDocument1.SmartRefreshAllViews()
            Return
        End If

        Dim shapesToHighlight As NNodeList = New NNodeList()
        Select Case shape.ShapeType
            Case ShapeType.Shape2D

                ' 2D shapes are treated as graph vertices, so we must find the vertex in the graph, which
                ' represents the shape
                Dim vertex As NGraphVertex = (TryCast(map.GetPartFromObject(shape), NGraphVertex))
                If Not vertex Is Nothing Then
                    ' add edges
                    'If allEdgesCheck.Checked Then
                    '    shapesToHighlight.AddRangeNoDuplicates(GetShapesList(vertex.Edges, map))
                    'Else
                    '    If incommingEdgesCheck.Checked Then
                    '        shapesToHighlight.AddRangeNoDuplicates(GetShapesList(vertex.IncomingEdges, map))
                    '    End If

                    '    If outgoingEdgesCheck.Checked Then
                    shapesToHighlight.AddRangeNoDuplicates(GetShapesList(vertex.OutgoingEdges, map))
                    '    End If
                    'End If

                    ' add neighbour vertices
                    'If neighbourVerticesCheck.Checked Then
                    '    shapesToHighlight.AddRangeNoDuplicates(GetShapesList(vertex.NeighbourVertices, map))
                    'Else
                    '    If sourceVerticesCheck.Checked Then
                    '        shapesToHighlight.AddRangeNoDuplicates(GetShapesList(vertex.SourceVertices, map))
                    '    End If

                    '    If destinationVerticesCheck.Checked Then
                    shapesToHighlight.AddRangeNoDuplicates(GetShapesList(vertex.DestinationVertices, map))
                    'End If
                    '    End If

                    ' add accessible vertices
                    'If accessibleVerticesCheck.Checked Then
                    '    shapesToHighlight.AddRangeNoDuplicates(GetShapesList(vertex.AccessibleVertices, map))
                    'Else
                    '    If predecessorVerticesCheck.Checked Then
                    '        shapesToHighlight.AddRangeNoDuplicates(GetShapesList(vertex.PredecessorVertices, map))
                    '    End If

                    '    If successorVerticesCheck.Checked Then
                    '        shapesToHighlight.AddRangeNoDuplicates(GetShapesList(vertex.SuccessorVertices, map))
                    '    End If
                    'End If
                End If

            Case ShapeType.Shape1D

                ' 1D shapes are treated as graph edges, so we must find the edge in the graph, which
                ' represents the shape
                Dim edge As NGraphEdge = (TryCast(map.GetPartFromObject(shape), NGraphEdge))
                If Not edge Is Nothing Then
                    'If fromVertexCheck.Checked Then
                    '    shapesToHighlight.AddNoDuplicates(CType(map.GetObjectFromPart(edge.FromVertex), NShape))
                    'End If

                    'If toVertexCheck.Checked Then
                    shapesToHighlight.AddNoDuplicates(CType(map.GetObjectFromPart(edge.ToVertex), NShape))
                    'End If
                End If
        End Select

        ' highlight the shapes
        For Each cur As NShape In shapesToHighlight
            cur.Style.FillStyle = (TryCast(highlightFillStyle.Clone(), NFillStyle))
            cur.Style.StrokeStyle = (TryCast(highlightStrokeStyle.Clone(), NStrokeStyle))
        Next cur

        ' smart refresh all views
        NDrawingDocument1.SmartRefreshAllViews()
    End Sub

    Private Sub ClearHighlights()
        Dim en As NNodeEnumerator = NDrawingDocument1.ActiveLayer.GetEnumerator(Nothing)
        Do While en.MoveNext()
            Dim shape As NShape = (TryCast(en.Current, NShape))
            If Not shape Is Nothing Then
                shape.Style.FillStyle = Nothing
                shape.Style.StrokeStyle = Nothing
            End If
        Loop
    End Sub
    Private Function GetShapesList(ByVal edges As NGraphEdgeList, ByVal map As NObjectGraphPartMap) As NNodeList
        Dim list As NNodeList = New NNodeList()
        Dim i As Integer, edgeCount As Integer = edges.Count
        i = 0
        Do While i < edgeCount
            list.Add(CType(map.GetObjectFromPart(edges(i)), NShape))
            i += 1
        Loop

        Return list
    End Function

    Private Function GetShapesList(ByVal vertices As NGraphVertexList, ByVal map As NObjectGraphPartMap) As NNodeList
        Dim list As NNodeList = New NNodeList()
        Dim i As Integer, vertexCount As Integer = vertices.Count
        i = 0
        Do While i < vertexCount
            list.Add(CType(map.GetObjectFromPart(vertices(i)), NShape))
            i += 1
        Loop

        Return list
    End Function
    Private Sub EventSinkService_OnNodeSelected(ByVal args As NNodeEventArgs)
        Dim shape As NShape = (TryCast(args.Node, NShape))
        If Not shape Is Nothing Then

            'graphPartCheck.Enabled = True
            'graphPartCheck.Checked = shape.GraphPart

        End If

        UpdateHighlights()
    End Sub

    Private Sub EventSinkService_OnNodeDeselected(ByVal args As NNodeEventArgs)
        ClearHighlights()
        'graphPartCheck.Enabled = False

        NDrawingDocument1.SmartRefreshAllViews()
    End Sub

    Protected Sub AttachToEvents()
        AddHandler NDrawingView1.EventSinkService.NodeSelected, AddressOf EventSinkService_OnNodeSelected
        AddHandler NDrawingView1.EventSinkService.NodeDeselected, AddressOf EventSinkService_OnNodeDeselected

    End Sub

    Protected Sub DetachFromEvents()
        RemoveHandler NDrawingView1.EventSinkService.NodeSelected, AddressOf EventSinkService_OnNodeSelected
        RemoveHandler NDrawingView1.EventSinkService.NodeDeselected, AddressOf EventSinkService_OnNodeDeselected

    End Sub

    Private Sub ComboBoxEx4_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxEx4.SelectedValueChanged
        If Me.ComboBoxEx4.SelectedIndex > -1 Then
            If CInt(Me.ComboBoxEx4.SelectedValue.ToString) > -1 Then
                update_salle()
            Else

            End If
        End If
    End Sub
    Private Sub update_salle()
        If mode Then

            If Me.SallesBindingSource.Count > 0 Then
                Dim nbat As Integer
                nbat = CInt(ComboBoxEx4.SelectedValue)
                Me.SallesBindingSource.RemoveFilter()
                '    Me.SallesBindingSource.ResumeBinding()
                Me.SallesBindingSource.Filter = "Batiments_idBatiment=" & nbat
                Me.SallesBindingSource.ResetBindings(True)
                'Me.ComboBoxEx1.DataSource = Nothing
                'Me.ComboBoxEx1.DataSource = Me.SallesBindingSource
                'Me.ComboBoxEx1.ValueMember = "idsalles"
                'Me.ComboBoxEx1.DisplayMember = "repere salle"

                Me.ComboBoxEx1.SelectedIndex = -1

            End If
        End If
    End Sub
End Class