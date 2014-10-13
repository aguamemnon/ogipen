Imports System.Text
Imports System.ComponentModel
Imports Microsoft.VisualBasic
Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Controls
Imports DevComponents.DotNetBar.Rendering
Imports DevComponents.DotNetBar.SuperGrid
Imports DevComponents.DotNetBar.SuperGrid.Style
Public Class OfficeFormImportNoteDeCalcul

    Private Sub ButtonXSelectionFichier_Click(sender As Object, e As EventArgs) Handles ButtonXSelectionFichier.Click
        OpenFileDialog.ShowDialog()
        TextBoxXFichierSelectionne.Text = OpenFileDialog.FileName

    End Sub
    Dim dt1 As New DataTable
    Dim dbequipemets As New DataTable
    Dim dbcables As New DataTable
    Dim dbdetailcables As New DataTable
    Private Sub ButtonXLancerLannalyse_Click(sender As Object, e As EventArgs) Handles ButtonXLancerLannalyse.Click

        If Me.SuperValidator.Validate Then

            Using conn As OleDb.OleDbConnection = New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + OpenFileDialog.FileName + "; Extended Properties=""Excel 12.0 Xml;HDR=Yes""")

                Using adapter As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter("SELECT * FROM [Export$]", conn)

                    adapter.Fill(dt1)

                End Using

            End Using
        Else
            Exit Sub
        End If

        ' generation liste equipement

        '  dbequipemets.Columns.Add("id", GetType(Integer))
        dbequipemets.Columns.Add("repere", GetType(String))
        dbequipemets.Columns.Add("designation", GetType(String))
        dbequipemets.Columns.Add("present", GetType(Boolean))
        dbequipemets.Columns.Add("action", GetType(String))
        dbequipemets.Columns.Add("referent", GetType(String))
        dbequipemets.Columns.Add("lot", GetType(String))
        dbequipemets.Columns.Add("salle", GetType(String))
        dbequipemets.Columns.Add("categorie", GetType(String))
        Dim data_columns(0) As DataColumn
        Dim unique_constraint As UniqueConstraint

        data_columns(0) = dbequipemets.Columns("repere")

        unique_constraint = New UniqueConstraint(data_columns)
        dbequipemets.Constraints.Add(unique_constraint)

        ' generation liste câble

        dbcables.Columns.Add("repere", GetType(String))
        dbcables.Columns.Add("Type", GetType(String))
        dbcables.Columns.Add("Polarité", GetType(String))
        dbcables.Columns.Add("Phase", GetType(String))
        dbcables.Columns.Add("Neutre", GetType(String))
        dbcables.Columns.Add("PE", GetType(String))
        dbcables.Columns.Add("LMAX", GetType(String))
        dbcables.Columns.Add("tenant", GetType(String))
        dbcables.Columns.Add("aboutissant", GetType(String))
        dbcables.Columns.Add("present", GetType(Boolean))
        dbcables.Columns.Add("id", GetType(Integer))
        dbcables.Columns.Add("Typecable", GetType(Integer))
        dbcables.Columns.Add("referent", GetType(String))
        dbcables.Columns.Add("lnote", GetType(String))
        dbcables.Columns.Add("action", GetType(String))
        dbcables.Columns.Add("idtenant", GetType(String))
        dbcables.Columns.Add("idaboutissant", GetType(String))
        dbcables.Columns.Add("changement", GetType(Boolean))
        dbcables.Columns.Add("changement2", GetType(Boolean))
        data_columns(0) = dbcables.Columns("repere")

        unique_constraint = New UniqueConstraint(data_columns)
        dbcables.Constraints.Add(unique_constraint)

        'generation liste detail cables

        dbdetailcables.Columns.Add("id", GetType(Integer))
        dbdetailcables.Columns.Add("id_detail", GetType(Integer))
        dbdetailcables.Columns.Add("repere", GetType(String))
        dbdetailcables.Columns.Add("section", GetType(String))
        dbdetailcables.Columns.Add("fil", GetType(String))
        dbdetailcables.Columns.Add("trefle)", GetType(Boolean))
        dbdetailcables.Columns.Add("idreal", GetType(Integer))

        'data_columns(0) = dbcables.Columns("repere")

        'unique_constraint = New UniqueConstraint(data_columns)
        'dbcables.Constraints.Add(unique_constraint)

        Dim cpt As Integer = 0
        Dim rowequipement(3) As Object
        Dim rowcable(17) As Object
        Dim rowcabledetail(6) As Object
        Dim row As DataRow
        Dim section As String
        For Each row In dt1.Rows
            If row("Repère Câble").ToString() <> "" Then
                cpt += 1
                rowequipement(0) = row("Repère Equipement").ToString()
                rowequipement(1) = row("Désignation Equipement").ToString()
                rowequipement(2) = False
                rowequipement(3) = "ras"
                rowcable(0) = row("Repère Câble").ToString
                rowcable(1) = row("Type Câble").ToString

                rowcable(2) = row("Polarité").ToString

                Select Case row("Polarité").ToString
                    Case "Triphasé"
                        If row("Type Câble").ToString.Contains("Multiconducteur") Then
                            If Not row("Phase (mm2)").ToString = "" Then
                                section = row("Phase (mm2)").ToString
                                section.Replace("1x", "4G")
                                rowcable(3) = section
                            End If
                            If Not row("Phase (mm2)").ToString = "" Then
                                section = row("Neutre (mm2)").ToString
                                section.Replace("1x", "4G")
                                rowcable(4) = section
                            End If
                            If Not row("Phase (mm2)").ToString = "" Then
                                section = row("PE (mm2)").ToString
                                section.Replace("1x", "4G")
                                rowcable(5) = section
                            End If

                        ElseIf row("Type Câble").ToString.Contains("Monoconducteur") Then
                            If Not row("Phase (mm2)").ToString = "" Then
                                section = row("Phase (mm2)").ToString

                                rowcable(3) = section
                            End If
                            If Not row("Phase (mm2)").ToString = "" Then
                                section = row("Neutre (mm2)").ToString

                                rowcable(4) = section
                            End If
                            If Not row("Phase (mm2)").ToString = "" Then
                                section = row("PE (mm2)").ToString

                                rowcable(5) = section
                            End If

                        End If
                        '4g = Multiconducteur avec PE

                        'mode de pose multicouches (2)

                        '1x = Monoconducteur
                        'mode de pose
                        'jointif 1 couche
                        'trefle trefle = true

                    Case "Monophasé"
                        If row("Type Câble").ToString.Contains("Multiconducteur") Then
                            If Not row("Phase (mm2)").ToString = "" Then
                                section = row("Phase (mm2)").ToString
                                section.Replace("1x", "3G")
                                rowcable(3) = section
                            End If
                            If Not row("Phase (mm2)").ToString = "" Then
                                section = row("Neutre (mm2)").ToString
                                section.Replace("1x", "3G")
                                rowcable(4) = section
                            End If
                            If Not row("Phase (mm2)").ToString = "" Then
                                section = row("PE (mm2)").ToString
                                section.Replace("1x", "3G")
                                rowcable(5) = section
                            End If
                        End If
                        '3g = Multiconducteur avec PE
                        'mode de pose multicouches (2)
                    Case "Tétraphasé"
                        '5g=Multiconducteur avec PE
                        If row("Type Câble").ToString.Contains("Multiconducteur") Then
                            If Not row("Phase (mm2)").ToString = "" Then
                                section = row("Phase (mm2)").ToString
                                section.Replace("1x", "3G")
                                rowcable(3) = section
                            End If
                            If Not row("Phase (mm2)").ToString = "" Then
                                section = row("Neutre (mm2)").ToString
                                section.Replace("1x", "3G")
                                rowcable(4) = section
                            End If
                            If Not row("Phase (mm2)").ToString = "" Then
                                section = row("PE (mm2)").ToString
                                section.Replace("1x", "3G")
                                rowcable(5) = section
                            End If
                        ElseIf row("Type Câble").ToString.Contains("Monoconducteur") Then
                            If Not row("Phase (mm2)").ToString = "" Then
                                section = row("Phase (mm2)").ToString

                                rowcable(3) = section
                            End If
                            If Not row("Phase (mm2)").ToString = "" Then
                                section = row("Neutre (mm2)").ToString

                                rowcable(4) = section
                            End If
                            If Not row("Phase (mm2)").ToString = "" Then
                                section = row("PE (mm2)").ToString

                                rowcable(5) = section
                            End If

                        End If
                        'mode de pose multicouches (2)
                        '4x

                        '1x = Monoconducteur
                        'jointif 1 couche
                        'trefle trefle
                End Select

                ' rowcable(3) = row("Phase (mm2)").ToString
                ' rowcable(4) = row("Neutre (mm2)").ToString
                ' rowcable(5) = row("PE (mm2)").ToString
                rowcable(6) = row("Longueur max (m)").ToString
                rowcable(7) = row("Repère Equipement").ToString
                rowcable(8) = row("Repère Aboutissant").ToString
                rowcable(9) = False

                'Try
                rowcable(13) = row("Longueur estimée (m)").ToString
                'Catch ex As Exception

                'End Try

                '    rowcable(13) = row("Longueur estimée (m)").ToString

                Me.Types_cableBindingSource.Position = Me.Types_cableBindingSource.Find("types", row("Phase - Isolant").ToString)
                rowcable(11) = CType(CType(Me.Types_cableBindingSource.Current, DataRowView).Row, MydbDataSet.types_cableRow).idtypes_cable

                dbcables.Rows.Add(rowcable)
                Try
                    dbequipemets.Rows.Add(rowequipement)

                Catch ex As Exception

                End Try

            End If

        Next

        For Each row In dt1.Rows
            If row("Repère Câble").ToString() <> "" Then

                rowequipement(0) = row("Repère Aboutissant").ToString()
                rowequipement(1) = row("Désignation2").ToString()
                rowequipement(2) = False
                rowequipement(3) = "ras"
                Try
                    dbequipemets.Rows.Add(rowequipement)
                Catch ex As Exception

                End Try

            End If

        Next
        TextBoxXAnnalyse.AppendText(Environment.NewLine & "##########################################################################################" & Environment.NewLine)
        TextBoxXAnnalyse.AppendText("##                              Controle des equipements                                ##" & Environment.NewLine)
        TextBoxXAnnalyse.AppendText(String.Format("##                             {0}                                 ##{1}", Today, Environment.NewLine))
        TextBoxXAnnalyse.AppendText("##########################################################################################" & Environment.NewLine)
        TextBoxXAnnalyse.AppendText("Total equipements dans la note de calcul :" & dbequipemets.Rows.Count & Environment.NewLine)
        TextBoxXAnnalyse.AppendText("Total equipements dans la Base :" & Me.EquipementsBindingSource.Count & Environment.NewLine)
        'comparaison equipement et base

        'affichage ecarts :
        For Each row In dbequipemets.Rows
            If Me.EquipementsBindingSource.Find("repere equipement", row("repere").ToString) > 0 Then
                row.BeginEdit()
                row("present") = True
                row("action") = ""
                row.EndEdit()
            Else
                row.BeginEdit()
                row("present") = False
                row("action") = "ajout"
                row.EndEdit()
            End If

        Next
        dbequipemets.AcceptChanges()

        dbequipemets.DefaultView.RowFilter = "present = True"
        TextBoxXAnnalyse.AppendText("#--------------------------------------------------------------------------------------#" & Environment.NewLine)
        TextBoxXAnnalyse.AppendText("Total equipements corespondant :" & dbequipemets.DefaultView.Count & " / " & Me.EquipementsBindingSource.Count & Environment.NewLine)
        TextBoxXAnnalyse.AppendText("#--------------------------------------------------------------------------------------#" & Environment.NewLine)
        dbequipemets.DefaultView.RowFilter = "present = False"
        TextBoxXAnnalyse.AppendText(dbequipemets.DefaultView.Count & " Equipements sont soit Nouveau ou on changé de repere" & Environment.NewLine)
        Dim erows As DataRowView
        For Each erows In dbequipemets.DefaultView
            TextBoxXAnnalyse.AppendText("Equipement : " & erows("repere").ToString & Environment.NewLine)
        Next

        TextBoxXAnnalyse.AppendText("#--------------------------------------------------------------------------------------#" & Environment.NewLine)
        TextBoxXAnnalyse.AppendText("#                                Comparaison câbles                                      #" & Environment.NewLine)
        TextBoxXAnnalyse.AppendText("#--------------------------------------------------------------------------------------#" & Environment.NewLine)

        For Each row In dbcables.Rows
            If Me.CablesBindingSource.Find("repere cable", row("repere").ToString) > 0 Then
                Me.CablesBindingSource.Position = Me.CablesBindingSource.Find("repere cable", row("repere").ToString)
                row.BeginEdit()
                row("present") = True
                row("action") = "Mise à jour"
                row("id") = CType(CType(Me.CablesBindingSource.Current, DataRowView).Row, MydbDataSet.cablesRow).idcable

                'analyse section

                'If Not CType(CType(Me.CablesBindingSource.Current, DataRowView).Row, mydbDataSet.cablesRow).types_cable_idtypes_cable = CInt(row("Typecable").ToString) Then

                'End If

                row.EndEdit()
            Else
                row.BeginEdit()
                row("present") = False
                row("action") = "ajout"
                row.EndEdit()
            End If
        Next
        dbcables.AcceptChanges()
        'generation detail cables
        Dim ii As Integer = 1
        Dim aa As Integer

        Dim tempfil As String = ""

        For Each row In dbcables.Rows

            'monophasé
            Select Case row("Type").ToString

                Case "Monoconducteur en trèfle"
                    'generation phase
                    If Not row("Phase").ToString = "" Then
                        Dim sectionfils As String = ""

                        sectionfils = Microsoft.VisualBasic.Left(row("Phase").ToString, 2)
                        sectionfils.ToLower()
                        sectionfils = String.Join(Nothing, System.Text.RegularExpressions.Regex.Split(sectionfils, "[^\d]"))

                        Dim af As Integer = 1
                        For i = 1 To CInt(sectionfils)
                            rowcabledetail(5) = New Object
                            aa = 1
                            For aa = 1 To 3

                                If CInt(sectionfils) > 1 Then
                                    tempfil = Math.Ceiling(af) & "L" & aa
                                Else
                                    tempfil = "L" & aa
                                End If

                                rowcabledetail(0) = ii
                                If Not row("id").ToString = "" Then rowcabledetail(1) = row("id").ToString Else rowcabledetail(1) = 0
                                rowcabledetail(2) = row("repere").ToString
                                Dim section_tempP As String
                                section_tempP = row("Phase").ToString
                                section_tempP = section_tempP.Replace(Microsoft.VisualBasic.Left(row("Phase").ToString, 2), "1x")
                                Me.Sections_cablesBindingSource.Position = Me.Sections_cablesBindingSource.Find("section", section_tempP)
                                rowcabledetail(3) = CType(CType(Me.Sections_cablesBindingSource.Current, DataRowView).Row, MydbDataSet.sections_cablesRow).idsections_cables
                                rowcabledetail(4) = tempfil

                                rowcabledetail(5) = True
                                dbdetailcables.Rows.Add(rowcabledetail)
                                ii += 1
                            Next
                            af += 1
                        Next

                    End If
                    'generation neutre
                    If Not row("Neutre").ToString = "" Then
                        Dim sectionfils As String = ""

                        sectionfils = Microsoft.VisualBasic.Left(row("Neutre").ToString, 2)
                        sectionfils.ToLower()
                        sectionfils = String.Join(Nothing, System.Text.RegularExpressions.Regex.Split(sectionfils, "[^\d]"))

                        Dim af As Integer = 1
                        For i = 1 To CInt(sectionfils)

                            rowcabledetail(5) = New Object

                            If CInt(sectionfils) > 1 Then
                                tempfil = Math.Ceiling(af) & "N"
                            Else
                                tempfil = "N"
                            End If

                            rowcabledetail(0) = ii
                            If Not row("id").ToString = "" Then rowcabledetail(1) = row("id").ToString Else rowcabledetail(1) = 0
                            rowcabledetail(2) = row("repere").ToString
                            Dim section_tempN As String
                            section_tempN = row("Neutre").ToString
                            section_tempN = section_tempN.Replace(Microsoft.VisualBasic.Left(row("Neutre").ToString, 2), "1x")
                            Me.Sections_cablesBindingSource.Position = Me.Sections_cablesBindingSource.Find("section", section_tempN)
                            rowcabledetail(3) = CType(CType(Me.Sections_cablesBindingSource.Current, DataRowView).Row, MydbDataSet.sections_cablesRow).idsections_cables
                            rowcabledetail(4) = tempfil

                            rowcabledetail(5) = False
                            dbdetailcables.Rows.Add(rowcabledetail)
                            ii += 1

                            af += 1
                        Next

                    End If
                    'generation PE

                    If Not row("PE").ToString = "" Then
                        Dim sectionfils As String = ""

                        sectionfils = Microsoft.VisualBasic.Left(row("PE").ToString, 2)
                        sectionfils.ToLower()
                        sectionfils = String.Join(Nothing, System.Text.RegularExpressions.Regex.Split(sectionfils, "[^\d]"))

                        Dim af As Integer = 1
                        For i = 1 To CInt(sectionfils)
                            rowcabledetail(5) = New Object

                            If CInt(sectionfils) > 1 Then
                                tempfil = Math.Ceiling(af) & "PE"
                            Else
                                tempfil = "PE"
                            End If

                            rowcabledetail(0) = ii
                            If Not row("id").ToString = "" Then rowcabledetail(1) = row("id").ToString Else rowcabledetail(1) = 0
                            rowcabledetail(2) = row("repere").ToString
                            Dim section_temp As String
                            section_temp = row("PE").ToString
                            section_temp = section_temp.Replace(Microsoft.VisualBasic.Left(row("PE").ToString, 2), "1x")
                            Me.Sections_cablesBindingSource.Position = Me.Sections_cablesBindingSource.Find("section", section_temp)
                            rowcabledetail(3) = CType(CType(Me.Sections_cablesBindingSource.Current, DataRowView).Row, MydbDataSet.sections_cablesRow).idsections_cables
                            rowcabledetail(4) = tempfil

                            rowcabledetail(5) = False
                            dbdetailcables.Rows.Add(rowcabledetail)
                            ii += 1

                            af += 1
                        Next

                    End If

                Case "Multiconducteur avec PE"

                    'polarité
                    Select Case row("Polarité").ToString
                        Case "Monophasé"
                            If Not row("Phase").ToString = "" Then
                                Dim sectionfils As String = ""
                                rowcabledetail(5) = New Object
                                sectionfils = row("Phase").ToString
                                sectionfils.ToLower()
                                sectionfils = sectionfils.Replace("1x", "3G")
                                sectionfils.ToUpper()

                                rowcabledetail(0) = ii
                                If Not row("id").ToString = "" Then rowcabledetail(1) = row("id").ToString Else rowcabledetail(1) = 0

                                rowcabledetail(2) = row("repere").ToString
                                Me.Sections_cablesBindingSource.Position = Me.Sections_cablesBindingSource.Find("section", sectionfils)
                                rowcabledetail(3) = CInt(CType(CType(Me.Sections_cablesBindingSource.Current, DataRowView).Row, MydbDataSet.sections_cablesRow).idsections_cables.ToString)
                                rowcabledetail(4) = ""

                                rowcabledetail(5) = False
                                dbdetailcables.Rows.Add(rowcabledetail)

                            End If
                        Case "Triphasé"
                            If Not row("Phase").ToString = "" Then
                                Dim sectionfils As String = ""
                                rowcabledetail(5) = New Object
                                sectionfils = row("Phase").ToString
                                sectionfils.ToLower()
                                sectionfils = sectionfils.Replace("1x", "4G")
                                sectionfils.ToUpper()

                                rowcabledetail(0) = ii
                                If Not row("id").ToString = "" Then rowcabledetail(1) = row("id").ToString Else rowcabledetail(1) = 0
                                rowcabledetail(2) = row("repere").ToString
                                Me.Sections_cablesBindingSource.Position = Me.Sections_cablesBindingSource.Find("section", sectionfils)
                                rowcabledetail(3) = CInt(CType(CType(Me.Sections_cablesBindingSource.Current, DataRowView).Row, MydbDataSet.sections_cablesRow).idsections_cables.ToString)
                                rowcabledetail(4) = ""

                                rowcabledetail(5) = False
                                dbdetailcables.Rows.Add(rowcabledetail)
                            End If
                        Case "Tétraphasé"
                            If Not row("Phase").ToString = "" Then
                                Dim sectionfils As String = ""
                                rowcabledetail(5) = New Object
                                sectionfils = row("Phase").ToString
                                sectionfils.ToLower()
                                sectionfils = sectionfils.Replace("1x", "5G")
                                sectionfils.ToUpper()

                                rowcabledetail(0) = ii
                                If Not row("id").ToString = "" Then rowcabledetail(1) = row("id").ToString Else rowcabledetail(1) = 0
                                rowcabledetail(2) = row("repere").ToString
                                Me.Sections_cablesBindingSource.Position = Me.Sections_cablesBindingSource.Find("section", sectionfils)
                                rowcabledetail(3) = CInt(CType(CType(Me.Sections_cablesBindingSource.Current, DataRowView).Row, MydbDataSet.sections_cablesRow).idsections_cables.ToString)
                                rowcabledetail(4) = ""

                                rowcabledetail(5) = False
                                dbdetailcables.Rows.Add(rowcabledetail)
                            End If
                    End Select

                Case "Monoconducteurs séparés"
                    If Not row("Phase").ToString = "" Then
                        Dim sectionfils As String = ""

                        sectionfils = Microsoft.VisualBasic.Left(row("Phase").ToString, 2)
                        sectionfils.ToLower()
                        sectionfils = String.Join(Nothing, System.Text.RegularExpressions.Regex.Split(sectionfils, "[^\d]"))

                        Dim af As Integer = 1
                        For i = 1 To CInt(sectionfils)
                            rowcabledetail(5) = New Object
                            aa = 1
                            For aa = 1 To 3

                                If CInt(sectionfils) > 1 Then
                                    tempfil = Math.Ceiling(af) & "L" & aa
                                Else
                                    tempfil = "L" & aa
                                End If

                                rowcabledetail(0) = ii
                                If Not row("id").ToString = "" Then rowcabledetail(1) = row("id").ToString Else rowcabledetail(1) = 0
                                rowcabledetail(2) = row("repere").ToString
                                Dim section_tempP As String
                                section_tempP = row("Phase").ToString
                                section_tempP = section_tempP.Replace(Microsoft.VisualBasic.Left(row("Phase").ToString, 2), "1x")
                                Me.Sections_cablesBindingSource.Position = Me.Sections_cablesBindingSource.Find("section", section_tempP)
                                rowcabledetail(3) = CType(CType(Me.Sections_cablesBindingSource.Current, DataRowView).Row, MydbDataSet.sections_cablesRow).idsections_cables
                                rowcabledetail(4) = tempfil

                                rowcabledetail(5) = False
                                dbdetailcables.Rows.Add(rowcabledetail)
                                ii += 1
                            Next
                            af += 1
                        Next

                    End If
                    'generation neutre
                    If Not row("Neutre").ToString = "" Then
                        Dim sectionfils As String = ""

                        sectionfils = Microsoft.VisualBasic.Left(row("Neutre").ToString, 2)
                        sectionfils.ToLower()
                        sectionfils = String.Join(Nothing, System.Text.RegularExpressions.Regex.Split(sectionfils, "[^\d]"))

                        Dim af As Integer = 1
                        For i = 1 To CInt(sectionfils)

                            rowcabledetail(5) = New Object

                            If CInt(sectionfils) > 1 Then
                                tempfil = Math.Ceiling(af) & "N"
                            Else
                                tempfil = "N"
                            End If

                            rowcabledetail(0) = ii
                            If Not row("id").ToString = "" Then rowcabledetail(1) = row("id").ToString Else rowcabledetail(1) = 0
                            rowcabledetail(2) = row("repere").ToString
                            Dim section_tempN As String
                            section_tempN = row("Neutre").ToString
                            section_tempN = section_tempN.Replace(Microsoft.VisualBasic.Left(row("Neutre").ToString, 2), "1x")
                            Me.Sections_cablesBindingSource.Position = Me.Sections_cablesBindingSource.Find("section", section_tempN)
                            rowcabledetail(3) = CType(CType(Me.Sections_cablesBindingSource.Current, DataRowView).Row, MydbDataSet.sections_cablesRow).idsections_cables
                            rowcabledetail(4) = tempfil

                            rowcabledetail(5) = False
                            dbdetailcables.Rows.Add(rowcabledetail)
                            ii += 1

                            af += 1
                        Next

                    End If
                    'generation PE

                    If Not row("PE").ToString = "" Then
                        Dim sectionfils As String = ""

                        sectionfils = Microsoft.VisualBasic.Left(row("PE").ToString, 2)
                        sectionfils.ToLower()
                        sectionfils = String.Join(Nothing, System.Text.RegularExpressions.Regex.Split(sectionfils, "[^\d]"))

                        Dim af As Integer = 1
                        For i = 1 To CInt(sectionfils)
                            rowcabledetail(5) = New Object

                            If CInt(sectionfils) > 1 Then
                                tempfil = Math.Ceiling(af) & "PE"
                            Else
                                tempfil = "PE"
                            End If

                            rowcabledetail(0) = ii
                            If Not row("id").ToString = "" Then rowcabledetail(1) = row("id").ToString Else rowcabledetail(1) = 0
                            rowcabledetail(2) = row("repere").ToString
                            Dim section_temp As String
                            section_temp = row("PE").ToString
                            section_temp = section_temp.Replace(Microsoft.VisualBasic.Left(row("PE").ToString, 2), "1x")
                            Me.Sections_cablesBindingSource.Position = Me.Sections_cablesBindingSource.Find("section", section_temp)
                            rowcabledetail(3) = CType(CType(Me.Sections_cablesBindingSource.Current, DataRowView).Row, MydbDataSet.sections_cablesRow).idsections_cables
                            rowcabledetail(4) = tempfil

                            rowcabledetail(5) = False
                            dbdetailcables.Rows.Add(rowcabledetail)
                            ii += 1

                            af += 1
                        Next

                    End If

                Case "Monoconducteurs jointifs"

                    If Not row("Phase").ToString = "" Then
                        Dim sectionfils As String = ""

                        sectionfils = Microsoft.VisualBasic.Left(row("Phase").ToString, 2)
                        sectionfils.ToLower()
                        sectionfils = String.Join(Nothing, System.Text.RegularExpressions.Regex.Split(sectionfils, "[^\d]"))

                        Dim af As Integer = 1
                        For i = 1 To CInt(sectionfils)
                            rowcabledetail(5) = New Object
                            aa = 1
                            For aa = 1 To 3

                                If CInt(sectionfils) > 1 Then
                                    tempfil = Math.Ceiling(af) & "L" & aa
                                Else
                                    tempfil = "L" & aa
                                End If

                                rowcabledetail(0) = ii
                                If Not row("id").ToString = "" Then rowcabledetail(1) = row("id").ToString Else rowcabledetail(1) = 0
                                rowcabledetail(2) = row("repere").ToString
                                Dim section_tempP As String
                                section_tempP = row("Phase").ToString
                                section_tempP = section_tempP.Replace(Microsoft.VisualBasic.Left(row("Phase").ToString, 2), "1x")
                                Me.Sections_cablesBindingSource.Position = Me.Sections_cablesBindingSource.Find("section", section_tempP)
                                rowcabledetail(3) = CType(CType(Me.Sections_cablesBindingSource.Current, DataRowView).Row, MydbDataSet.sections_cablesRow).idsections_cables
                                rowcabledetail(4) = tempfil

                                rowcabledetail(5) = False
                                dbdetailcables.Rows.Add(rowcabledetail)
                                ii += 1
                            Next
                            af += 1
                        Next

                    End If
                    'generation neutre
                    If Not row("Neutre").ToString = "" Then
                        Dim sectionfils As String = ""

                        sectionfils = Microsoft.VisualBasic.Left(row("Neutre").ToString, 2)
                        sectionfils.ToLower()
                        sectionfils = String.Join(Nothing, System.Text.RegularExpressions.Regex.Split(sectionfils, "[^\d]"))

                        Dim af As Integer = 1
                        For i = 1 To CInt(sectionfils)

                            rowcabledetail(5) = New Object

                            If CInt(sectionfils) > 1 Then
                                tempfil = Math.Ceiling(af) & "N"
                            Else
                                tempfil = "N"
                            End If

                            rowcabledetail(0) = ii
                            If Not row("id").ToString = "" Then rowcabledetail(1) = row("id").ToString Else rowcabledetail(1) = 0
                            rowcabledetail(2) = row("repere").ToString
                            Dim section_tempN As String
                            section_tempN = row("Neutre").ToString
                            section_tempN = section_tempN.Replace(Microsoft.VisualBasic.Left(row("Neutre").ToString, 2), "1x")
                            Me.Sections_cablesBindingSource.Position = Me.Sections_cablesBindingSource.Find("section", section_tempN)
                            rowcabledetail(3) = CType(CType(Me.Sections_cablesBindingSource.Current, DataRowView).Row, MydbDataSet.sections_cablesRow).idsections_cables
                            rowcabledetail(4) = tempfil

                            rowcabledetail(5) = False
                            dbdetailcables.Rows.Add(rowcabledetail)
                            ii += 1

                            af += 1
                        Next

                    End If
                    'generation PE

                    If Not row("PE").ToString = "" Then
                        Dim sectionfils As String = ""

                        sectionfils = Microsoft.VisualBasic.Left(row("PE").ToString, 2)
                        sectionfils.ToLower()
                        sectionfils = String.Join(Nothing, System.Text.RegularExpressions.Regex.Split(sectionfils, "[^\d]"))

                        Dim af As Integer = 1
                        For i = 1 To CInt(sectionfils)
                            rowcabledetail(5) = New Object

                            If CInt(sectionfils) > 1 Then
                                tempfil = Math.Ceiling(af) & "PE"
                            Else
                                tempfil = "PE"
                            End If

                            rowcabledetail(0) = ii
                            If Not row("id").ToString = "" Then rowcabledetail(1) = row("id").ToString Else rowcabledetail(1) = 0
                            rowcabledetail(2) = row("repere").ToString
                            Dim section_temp As String
                            section_temp = row("PE").ToString
                            section_temp = section_temp.Replace(Microsoft.VisualBasic.Left(row("PE").ToString, 2), "1x")
                            Me.Sections_cablesBindingSource.Position = Me.Sections_cablesBindingSource.Find("section", section_temp)
                            rowcabledetail(3) = CType(CType(Me.Sections_cablesBindingSource.Current, DataRowView).Row, MydbDataSet.sections_cablesRow).idsections_cables
                            rowcabledetail(4) = tempfil

                            rowcabledetail(5) = False
                            dbdetailcables.Rows.Add(rowcabledetail)
                            ii += 1

                            af += 1
                        Next

                    End If

            End Select

        Next
        dbdetailcables.AcceptChanges()

        dbcables.DefaultView.RowFilter = "present=True"
        TextBoxXAnnalyse.AppendText("Total Cables corespondant :" & dbcables.DefaultView.Count & " / " & Me.CablesBindingSource.Count & Environment.NewLine)
        TextBoxXAnnalyse.AppendText("#--------------------------------------------------------------------------------------#" & Environment.NewLine)
        dbcables.DefaultView.RowFilter = "present=False"
        TextBoxXAnnalyse.AppendText("Total Cables Nouveaux ou changement de repere :" & dbcables.DefaultView.Count & " / " & Me.CablesBindingSource.Count & Environment.NewLine)

        For Each erows In dbcables.DefaultView
            TextBoxXAnnalyse.AppendText("Cables : " & erows("repere").ToString & Environment.NewLine)
        Next

        'dbcables.DefaultView.RowFilter = "present=true"
        'For Each erows In dbcables.DefaultView
        '    TextBoxXAnnalyse.AppendText("Nombre de Changement de section : " & erows("repere").ToString & Environment.NewLine)
        'Next

        Dim rowtest As MydbDataSet.cablesRow

        For Each row In dbcables.Rows
            'If Me.CablesBindingSource.Find("repere cable", row("repere").ToString) > 0 Then
            '    Me.CablesBindingSource.Position = Me.CablesBindingSource.Find("repere cable", row("repere").ToString)
            '    row.BeginEdit()
            '    row("present") = True
            '    row("action") = "Mise à jour"
            '    row("id") = CType(CType(Me.CablesBindingSource.Current, DataRowView).Row, mydbDataSet.cablesRow).idcable
            '    'analyse section

            '    'If Not CType(CType(Me.CablesBindingSource.Current, DataRowView).Row, mydbDataSet.cablesRow).types_cable_idtypes_cable = CInt(row("Typecable").ToString) Then

            '    'End If

            '    row.EndEdit()
            'End If

            row.BeginEdit()
            If Me.EquipementsBindingSource.Find("repere equipement", row("tenant").ToString) > 0 Then

                Me.EquipementsBindingSource.Position = Me.EquipementsBindingSource.Find("repere equipement", row("tenant").ToString)
                row("idtenant") = CType(CType(Me.EquipementsBindingSource.Current, DataRowView).Row, MydbDataSet.equipementsRow).idequipement

            End If

            If Me.EquipementsBindingSource.Find("repere equipement", row("aboutissant").ToString) > 0 Then

                Me.EquipementsBindingSource.Position = Me.EquipementsBindingSource.Find("repere equipement", row("aboutissant").ToString)
                row("idaboutissant") = CType(CType(Me.EquipementsBindingSource.Current, DataRowView).Row, MydbDataSet.equipementsRow).idequipement

            End If

            If Not row("id").ToString = "" Then
                Me.CablesBindingSource.Position = Me.CablesBindingSource.Find("idcable", CInt(row("id").ToString))
                If Not row("idaboutissant").ToString = "" Then

                    If Not CInt(row("idaboutissant").ToString) = CType(CType(Me.CablesBindingSource.Current, DataRowView).Row, MydbDataSet.cablesRow).idequipement2 Then
                        row("changement") = True
                    End If
                End If
                If Not row("idtenant").ToString = "" Then

                    If Not CInt(row("idtenant").ToString) = CType(CType(Me.CablesBindingSource.Current, DataRowView).Row, MydbDataSet.cablesRow).idequipement Then
                        row("changement2") = True
                    End If
                End If

            End If

            row.EndEdit()

        Next
        dbcables.AcceptChanges()

        For Each row In dbdetailcables.Rows
            Me.Cables_detailsBindingSource.Filter = "cables_idcable ='" & CInt(row("id_detail").ToString) & "' and Fils ='" & row("fil").ToString & "'"
            ' Me.Cables_detailsBindingSource.Find("cables_idcable", CInt(row("id_detail").ToString))
            If Me.Cables_detailsBindingSource.Count > 0 Then
                row.BeginEdit()
                row("idreal") = CType(CType(Me.Cables_detailsBindingSource.Current, DataRowView).Row, MydbDataSet.cables_detailsRow).idcables_details
                row.EndEdit()
            End If
        Next

        dbdetailcables.AcceptChanges()

        dbequipemets.DefaultView.RowFilter = Nothing
        dbcables.DefaultView.RowFilter = Nothing
        Me.SuperGridControlEquipements.PrimaryGrid.DataSource = dbequipemets
        Me.SuperGridControlcables.PrimaryGrid.DataSource = dbcables
        Me.ButtonXLancerLimport.Enabled = True
        Me.ButtonX1.Enabled = True
    End Sub

    Public Sub New()

        ' Cet appel est requis par le concepteur.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().
        Dim panel As GridPanel = SuperGridControlEquipements.PrimaryGrid
        Dim panel2 As GridPanel = SuperGridControlcables.PrimaryGrid

        Dim column As GridColumn = panel.Columns("action")
        column.EditorType = GetType(GridLabelXEditControl)
        Dim column2 As GridColumn = panel.Columns("referent")
        column2.EditorType = GetType(GridreferentCombo)
        Dim column3 As GridColumn = panel.Columns("lot")
        column3.EditorType = GetType(GridlotCombo)
        Dim column4 As GridColumn = panel.Columns("salle")
        column4.EditorType = GetType(GridsalleCombo)
        Dim column5 As GridColumn = panel.Columns("categorie")
        column5.EditorType = GetType(GridcategorieCombo)
        Dim column6 As GridColumn = panel2.Columns("referent")
        column6.EditorType = GetType(GridcableCombo)

    End Sub

    Private Sub OfficeFormImportNoteDeCalcul_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.cables_details'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.Cables_detailsTableAdapter.Fill(Me.MydbDataSet.cables_details)
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.salles'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.SallesTableAdapter.Fill(Me.MydbDataSet.salles)
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.lots'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.LotsTableAdapter.Fill(Me.MydbDataSet.lots)
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.categories'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.CategoriesTableAdapter.Fill(Me.MydbDataSet.categories)
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.batiments'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.BatimentsTableAdapter.Fill(Me.MydbDataSet.batiments)
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.sections_cables'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.Sections_cablesTableAdapter.Fill(Me.MydbDataSet.sections_cables)
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.types_cable'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.Types_cableTableAdapter.Fill(Me.MydbDataSet.types_cable)
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.cables'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.CablesTableAdapter.Fill(Me.MydbDataSet.cables)
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.equipements'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.EquipementsTableAdapter.Fill(Me.MydbDataSet.equipements)

    End Sub

    Private Sub SuperGridControlcable_EditorValueChanged(sender As Object, e As GridEditEventArgs) Handles SuperGridControlEquipements.EndEdit
        Dim pb As SuperGridControl = TryCast(sender, SuperGridControl)
        If pb IsNot Nothing Then
            If pb.ActiveCell.ColumnIndex = 4 Then
                Dim row1 As GridRow = TryCast(pb.ActiveRow, GridRow)

                Dim Row() As Data.DataRow

                Row = dbequipemets.Select("repere ='" & row1.Cells(1).Value.ToString & "'")
                Row(0)("referent") = row1.Cells(4).Value.ToString
                dbequipemets.AcceptChanges()
            End If
        End If
    End Sub

    Private Sub X2Progress_BeforeCellPaint(ByVal sender As Object, ByVal e As GridPostRenderCellEventArgs) Handles SuperGridControlEquipements.PostRenderCell
        Dim pbc As GridLabelXEditControl
        If e.GridCell.GridColumn.ColumnIndex = 0 Then

            pbc = TryCast(e.GridCell.GridColumn.RenderControl, GridLabelXEditControl)

            If pbc IsNot Nothing Then
                Select Case pbc.Text
                    Case "Suppression ?"

                        pbc.Image = ImageList.Images("SUP")
                        Exit Select

                    Case ""

                        pbc.Image = ImageList.Images("OK")
                        Exit Select
                    Case "ajout"

                        pbc.Image = ImageList.Images("ADD")
                        Exit Select

                    Case Nothing

                        pbc.Image = ImageList.Images("OK")
                        Exit Select
                    Case Else

                        pbc.Image = ImageList.Images("OK")
                        Exit Select
                End Select
            End If

        End If

    End Sub

    Private Sub SuperGridControl1_CellDoubleClick(sender As System.Object, e As DevComponents.DotNetBar.SuperGrid.GridCellClickEventArgs) Handles SuperGridControlEquipements.CellClick
        'Dim pbc As GridLabelXEditControl
        'If e.GridCell.GridColumn.ColumnIndex = 0 Then

        '    pbc = TryCast(e.GridCell.GridColumn.RenderControl, GridLabelXEditControl)

        '    If pbc IsNot Nothing Then

        Dim pb As SuperGridControl = TryCast(sender, SuperGridControl)
        If pb IsNot Nothing Then
            If pb.ActiveCell.ColumnIndex = 1 Then
                Dim Row() As Data.DataRow
                Row = dbequipemets.Select("repere ='" & pb.ActiveCell.Value.ToString & "'")
                Select Case Row(0)("action").ToString

                    Case ""

                        Row(0)("action") = "ajout"

                        dbequipemets.AcceptChanges()
                        ' Me.SuperGridControlEquipements.PrimaryGrid.DataSource = dbequipemets
                        Exit Select
                    Case "ajout"

                        Row(0)("action") = "Suppression ?"
                        dbequipemets.AcceptChanges()
                        '  Me.SuperGridControlEquipements.PrimaryGrid.DataSource = dbequipemets
                        Exit Select
                    Case "Suppression ?"

                        Row(0)("action") = "Mise à jour"
                        dbequipemets.AcceptChanges()
                        '   Me.SuperGridControlEquipements.PrimaryGrid.DataSource = dbequipemets
                        Exit Select
                    Case "Mise à jour"
                        ' Dim referent As String

                        Row(0)("action") = ""
                        dbequipemets.AcceptChanges()
                        '   Me.SuperGridControlEquipements.PrimaryGrid.DataSource = dbequipemets
                        Exit Select

                End Select

            End If
            ' ElseIf pb.ActiveCell.ColumnIndex = 5 Then

            '    Dim Row() As Data.DataRow
            '    Row = dbequipemets.Select("repere ='" & pb.ActiveCell.Value.ToString & "'")
            '    Row(0)("action") = ""
            '    dbequipemets.AcceptChanges()
        End If

    End Sub

    Private Sub SuperGridControl1_Cellclick(sender As System.Object, e As DevComponents.DotNetBar.SuperGrid.GridCellClickEventArgs) Handles SuperGridControlcables.CellClick
        'Dim pbc As GridLabelXEditControl
        'If e.GridCell.GridColumn.ColumnIndex = 0 Then

        '    pbc = TryCast(e.GridCell.GridColumn.RenderControl, GridLabelXEditControl)

        '    If pbc IsNot Nothing Then

        Dim pb As SuperGridControl = TryCast(sender, SuperGridControl)
        If pb IsNot Nothing Then
            If pb.ActiveCell.ColumnIndex = 2 Then
                Dim Row() As Data.DataRow
                Row = dbcables.Select("repere ='" & pb.ActiveCell.Value.ToString & "'")
                Select Case Row(0)("action").ToString

                    Case ""

                        Row(0)("action") = "ajout"

                        dbcables.AcceptChanges()
                        ' Me.SuperGridControlEquipements.PrimaryGrid.DataSource = dbequipemets
                        Exit Select
                    Case "ajout"

                        Row(0)("action") = "Suppression ?"
                        dbcables.AcceptChanges()
                        '  Me.SuperGridControlEquipements.PrimaryGrid.DataSource = dbequipemets
                        Exit Select
                    Case "Suppression ?"

                        Row(0)("action") = "Mise à jour"
                        dbcables.AcceptChanges()
                        '   Me.SuperGridControlEquipements.PrimaryGrid.DataSource = dbequipemets
                        Exit Select
                    Case "Mise à jour"
                        ' Dim referent As String

                        Row(0)("action") = ""
                        dbcables.AcceptChanges()
                        '   Me.SuperGridControlEquipements.PrimaryGrid.DataSource = dbequipemets
                        Exit Select

                End Select

            End If
            ' ElseIf pb.ActiveCell.ColumnIndex = 5 Then

            '    Dim Row() As Data.DataRow
            '    Row = dbequipemets.Select("repere ='" & pb.ActiveCell.Value.ToString & "'")
            '    Row(0)("action") = ""
            '    dbequipemets.AcceptChanges()
        End If

    End Sub

    Private Sub SuperGridControlEquipements_EditorValueChanged(sender As Object, e As GridEditEventArgs) Handles SuperGridControlcables.EndEdit
        Dim pb As SuperGridControl = TryCast(sender, SuperGridControl)
        If pb IsNot Nothing Then
            If pb.ActiveCell.ColumnIndex = 0 Then
                Dim row1 As GridRow = TryCast(pb.ActiveRow, GridRow)

                'Dim Row() As Data.DataRow

                'Row = dbcables.Select("repere ='" & row1.Cells(1).Value.ToString & "'")
                'Row(0)("id_detail") = row1.Cells(4).Value.ToString
                'dbequipemets.AcceptChanges()
            End If
        End If
    End Sub

    Public Class GridreferentCombo
        Inherits GridComboBoxExEditControl
        Public Sub New()
            DisableInternalDrawing = False
            DropDownStyle = ComboBoxStyle.DropDownList

            Dim MydbDataSet As New progelec.MydbDataSet
            MydbDataSet.DataSetName = "MydbDataSet"
            Dim equipementsources As New BindingSource
            Dim equipementtable As New progelec.MydbDataSetTableAdapters.equipementsTableAdapter
            equipementtable.Fill(MydbDataSet.equipements)

            For i = 0 To MydbDataSet.equipements.Rows.Count - 1
                Items.Add(MydbDataSet.equipements.Rows(i)("repere equipement").ToString())
            Next
        End Sub

    End Class

    Public Class GridlotCombo
        Inherits GridComboBoxExEditControl
        Public Sub New()
            DisableInternalDrawing = False
            DropDownStyle = ComboBoxStyle.DropDownList

            Dim MydbDataSet As New progelec.MydbDataSet
            MydbDataSet.DataSetName = "MydbDataSet"
            Dim equipementsources As New BindingSource
            Dim equipementtable As New progelec.MydbDataSetTableAdapters.lotsTableAdapter
            equipementtable.Fill(MydbDataSet.lots)

            For i = 0 To MydbDataSet.lots.Rows.Count - 1
                Items.Add(MydbDataSet.lots.Rows(i)("lot").ToString())
            Next
        End Sub

    End Class

    Public Class GridsalleCombo
        Inherits GridComboBoxExEditControl
        Public Sub New()
            DisableInternalDrawing = False
            DropDownStyle = ComboBoxStyle.DropDownList

            Dim MydbDataSet As New progelec.MydbDataSet
            MydbDataSet.DataSetName = "MydbDataSet"
            Dim equipementsources As New BindingSource
            Dim equipementtable As New progelec.MydbDataSetTableAdapters.sallesTableAdapter
            equipementtable.Fill(MydbDataSet.salles)

            For i = 0 To MydbDataSet.salles.Rows.Count - 1
                Items.Add(MydbDataSet.salles.Rows(i)("repere salle").ToString())
            Next
        End Sub

    End Class

    Public Class GridcategorieCombo
        Inherits GridComboBoxExEditControl
        Public Sub New()
            DisableInternalDrawing = False
            DropDownStyle = ComboBoxStyle.DropDownList

            Dim MydbDataSet As New progelec.MydbDataSet
            MydbDataSet.DataSetName = "MydbDataSet"
            Dim equipementsources As New BindingSource
            Dim equipementtable As New progelec.MydbDataSetTableAdapters.categoriesTableAdapter
            equipementtable.Fill(MydbDataSet.categories)

            For i = 0 To MydbDataSet.categories.Rows.Count - 1
                Items.Add(MydbDataSet.categories.Rows(i)("Categorie").ToString())
            Next
        End Sub

    End Class
    Public Class GridcableCombo
        Inherits GridComboBoxExEditControl
        Public Sub New()
            DisableInternalDrawing = False
            DropDownStyle = ComboBoxStyle.DropDownList

            Dim MydbDataSet As New progelec.MydbDataSet
            MydbDataSet.DataSetName = "MydbDataSet"
            Dim equipementsources As New BindingSource
            Dim equipementtable As New progelec.MydbDataSetTableAdapters.cablesTableAdapter
            equipementtable.Fill(MydbDataSet.cables)

            For i = 0 To MydbDataSet.cables.Rows.Count - 1
                Items.Add(MydbDataSet.cables.Rows(i)("repere cable").ToString())
            Next
        End Sub

    End Class

    Private Sub ButtonXLancerLimport_Click(sender As Object, e As EventArgs) Handles ButtonXLancerLimport.Click

        Dim info As New TaskDialogInfo("AVERTISSEMENT", eTaskDialogIcon.Hand, "Imports Note de calcul", "L'import affecteras definitivement les bases de données etes vous sur de vos changements ? ", eTaskDialogButton.Ok Or eTaskDialogButton.Cancel, eTaskDialogBackgroundColor.Red)
        Dim result As eTaskDialogResult = TaskDialog.Show(info)
        Select Case result

            Case eTaskDialogResult.Ok

                Dim row As DataRow
                Dim equip As MydbDataSet.equipementsRow

                For Each row In dbequipemets.Rows
                    If Me.EquipementsBindingSource.Find("repere equipement", row("referent").ToString) > 0 Then
                        If row("action").ToString = "Mise à jour" Then

                            Me.EquipementsBindingSource.Position = Me.EquipementsBindingSource.Find("repere equipement", row("referent").ToString)
                            equip = CType(CType(Me.EquipementsBindingSource.Current, DataRowView).Row, MydbDataSet.equipementsRow)
                            equip.BeginEdit()

                            If Not equip.repere_equipement = row("repere").ToString Then
                                equip.repere_equipement = row("repere").ToString
                            End If

                            If Not row("lot").ToString = "" Then
                                Me.LotsBindingSource.Position = Me.LotsBindingSource.Find("lot", row("lot").ToString)
                                equip.lots_idlots = CType(CType(Me.LotsBindingSource.Current, DataRowView).Row, MydbDataSet.lotsRow).idlots
                            End If
                            If Not row("salle").ToString = "" Then
                                Me.SallesBindingSource.Position = Me.SallesBindingSource.Find("repere salle", row("salle").ToString)
                                equip.salles_idsalle = CType(CType(Me.SallesBindingSource.Current, DataRowView).Row, MydbDataSet.sallesRow).idsalle
                            End If
                            If Not row("categorie").ToString = "" Then
                                Me.CategoriesBindingSource.Position = Me.CategoriesBindingSource.Find("Categorie", row("categorie").ToString)
                                equip.Categories_idCategories = CType(CType(Me.CategoriesBindingSource.Current, DataRowView).Row, MydbDataSet.categoriesRow).idCategories
                            End If

                            equip.designation = row("designation").ToString

                            equip.modif = "Mise à jour suite import Note de calcul reference : " & Me.TextBoxXReference.Text & " d'indice : " & TextBoxXRevision.Text & " en date du " & Me.DateTimePicker.Value.ToString
                            equip.qui = FormMain.user.Nom_user
                            equip._date = Me.DateTimePicker.Value
                            equip.EndEdit()
                        End If
                    End If

                Next

                Me.EquipementsBindingSource.EndEdit()
                Me.EquipementsTableAdapter.Update(MydbDataSet.equipements)
                Me.EquipementsTableAdapter.Fill(MydbDataSet.equipements)

                For Each row In dbequipemets.Rows
                    If Me.EquipementsBindingSource.Find("repere equipement", row("repere").ToString) = -1 Then
                        If row("action").ToString = "ajout" Then

                            Me.EquipementsBindingSource.AddNew()
                            equip = CType(CType(Me.EquipementsBindingSource.Current, DataRowView).Row, MydbDataSet.equipementsRow)
                            equip.BeginEdit()
                            equip.repere_equipement = row("repere").ToString
                            equip.modif = "Import Note de calcul reference : " & Me.TextBoxXReference.Text & " d'indice : " & TextBoxXRevision.Text & " en date du " & Me.DateTimePicker.Value.ToString
                            equip.qui = FormMain.user.Nom_user

                            Me.LotsBindingSource.Position = Me.LotsBindingSource.Find("lot", row("lot").ToString)
                            equip.lots_idlots = CType(CType(Me.LotsBindingSource.Current, DataRowView).Row, MydbDataSet.lotsRow).idlots
                            Me.SallesBindingSource.Position = Me.SallesBindingSource.Find("repere salle", row("salle").ToString)
                            equip.salles_idsalle = CType(CType(Me.SallesBindingSource.Current, DataRowView).Row, MydbDataSet.sallesRow).idsalle
                            Me.CategoriesBindingSource.Position = Me.CategoriesBindingSource.Find("Categorie", row("categorie").ToString)
                            equip.Categories_idCategories = CType(CType(Me.CategoriesBindingSource.Current, DataRowView).Row, MydbDataSet.categoriesRow).idCategories
                            equip.designation = row("designation").ToString
                            equip._date = Me.DateTimePicker.Value

                            equip.EndEdit()
                            Me.EquipementsBindingSource.EndEdit()
                            Me.EquipementsTableAdapter.Update(MydbDataSet.equipements)
                            Me.EquipementsTableAdapter.Fill(MydbDataSet.equipements)
                        End If
                    End If

                Next

                Exit Sub
            Case eTaskDialogResult.Cancel
                Exit Sub
        End Select
        'creationequipement

    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        'mise à jour base cables
        Dim cable As MydbDataSet.cablesRow

        Dim row As DataRow
        For Each row In dbcables.Rows
            If row("action").ToString = "Mise à jour" Then

                ' If Not CBool(row("changement").ToString) Then

                If Me.CablesBindingSource.Find("idcable", row("id").ToString) > 0 Then
                    '   If row("action").ToString = "ajout" Then
                    Me.CablesBindingSource.Position = Me.CablesBindingSource.Find("idcable", row("id").ToString)
                    cable = CType(CType(Me.CablesBindingSource.Current, DataRowView).Row, MydbDataSet.cablesRow)
                    cable.BeginEdit()
                    If Not row("LMAX").ToString = "" Then
                        cable.LMAX = CInt(row("LMAX").ToString)
                    End If
                    If Not row("lnote").ToString = "" Then
                        cable.Longueur_Note_Calcule = CInt(row("lnote").ToString)
                    End If
                    'Try
                    '    If Not IsNothing(cable.divers) Then
                    '        cable.divers = "Maj suite import Note de calcul reference : " & Me.TextBoxXReference.Text & " d'indice : " & TextBoxXRevision.Text & " en date du " & Me.DateTimePicker.Value.ToString & "  " & cable.divers
                    '    Else
                    '        cable.divers = "Maj à jour suite import Note de calcul reference : " & Me.TextBoxXReference.Text & " d'indice : " & TextBoxXRevision.Text & " en date du " & Me.DateTimePicker.Value.ToString
                    '    End If
                    'Catch ex As Exception

                    'End Try
                    cable.divers = "Maj à jour suite import Note de calcul reference : " & Me.TextBoxXReference.Text & " d'indice : " & TextBoxXRevision.Text & " en date du " & Me.DateTimePicker.Value.ToString

                    cable.EndEdit()
                    Me.CablesBindingSource.EndEdit()
                    Me.CablesTableAdapter.Update(MydbDataSet.cables)
                    Me.CablesTableAdapter.Fill(MydbDataSet.cables)
                End If
                'End If
                'End If
            End If
        Next

        Me.Cables_detailsBindingSource.RemoveFilter()
        Me.Cables_detailsBindingSource.Filter = Nothing

        For Each row In dbdetailcables.Rows
            '  If Not CInt(row("id_detail").ToString) = 0 Then

            If Not IsDBNull(row("idreal")) Then
                Dim rowdetail As MydbDataSet.cables_detailsRow

                If Not Me.Cables_detailsBindingSource.Find("idcables_details", CInt(row(6).ToString)) = -1 Then
                    Me.Cables_detailsBindingSource.Position = Me.Cables_detailsBindingSource.Find("idcables_details", CInt(row(6).ToString))

                    rowdetail = CType(CType(Me.Cables_detailsBindingSource.Current, DataRowView).Row, MydbDataSet.cables_detailsRow)
                    rowdetail.BeginEdit()
                    rowdetail.cables_idcable = CInt(row(1).ToString)
                    rowdetail.trefle = CBool(row(5).ToString)
                    rowdetail.sections_cables_idsections_cables = CInt(row(3).ToString)
                    rowdetail.qui = CStr("imports-3")
                    rowdetail.EndEdit()

                    'Else
                    '    Dim rowdetail As mydbDataSet.cables_detailsRow
                    '    'Me.Cables_detailsBindingSource.Position = Me.Cables_detailsBindingSource.Find("idcables_details", row("idreal").ToString)
                    '    Me.Cables_detailsBindingSource.AddNew()
                    '    rowdetail = CType(CType(Me.Cables_detailsBindingSource.Current, DataRowView).Row, mydbDataSet.cables_detailsRow)
                    '    rowdetail.BeginEdit()
                    '    rowdetail.Fils = row("fil").ToString
                    '    rowdetail.cables_idcable = CInt(row("id_detail").ToString)
                    '    rowdetail.trefle = CBool(row("trefle)").ToString)
                    '    rowdetail.sections_cables_idsections_cables = CInt(row("section").ToString)
                    '    rowdetail.qui = FormMain.user.Nom_user

                    '    rowdetail.AcceptChanges()
                    '    rowdetail.EndEdit()
                    '    Me.Cables_detailsBindingSource.EndEdit()
                    '    Me.Cables_detailsTableAdapter.Update(MydbDataSet.cables_details)
                    '    Me.Cables_detailsTableAdapter.Fill(MydbDataSet.cables_details)

                End If

                Me.Cables_detailsBindingSource.EndEdit()
                Me.Cables_detailsTableAdapter.Update(MydbDataSet.cables_details)
                Me.Cables_detailsTableAdapter.Fill(MydbDataSet.cables_details)

            End If
        Next
    End Sub
End Class