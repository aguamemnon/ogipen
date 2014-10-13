Imports System.Text
Imports System.ComponentModel
Imports Microsoft.VisualBasic
Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Controls
Imports DevComponents.DotNetBar.Rendering
Imports System.Windows.Forms.DataVisualization.Charting

Public Class FormDispoSalle
    Dim lot_principal As Integer
    Private _switchval As String = ""
    Private Const INT_thisProgressBarX6Value As Integer = 0
    Dim row_clk As Integer
    Public Event EventFired6()
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Public Sub actualisation()
        Me.Salles_dispo_histoTableAdapter.Fill(Me.MydbDataSet.salles_dispo_histo)
        'TODO: This line of code loads data into the 'MydbDataSet.salles_dispo' table. You can move, or remove it, as needed.
        Me.Salles_dispoTableAdapter.Fill(Me.MydbDataSet.salles_dispo)
        'TODO: This line of code loads data into the 'MydbDataSet.salles_status' table. You can move, or remove it, as needed.
        Me.Salles_statusTableAdapter.Fill(Me.MydbDataSet.salles_status)
    End Sub

    Private Sub DataGridViewX1_CellContentClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridViewX1.CellClick, DataGridViewX2.CellClick

        Dim cell As DataGridViewButtonXCell = TryCast(DataGridViewX1.CurrentCell, DataGridViewButtonXCell)

        If cell IsNot Nothing Then
            Dim bc As DataGridViewButtonXColumn = TryCast(DataGridViewX1.Columns(e.ColumnIndex), DataGridViewButtonXColumn)
            '  DataGridViewX1.Columns(e.ColumnIndex)
            If bc IsNot Nothing Then
                If IsDBNull(cell.Value) Then cell.Value = "BLOCAGE"
                Dim s As String = Convert.ToString(cell.Value)

                Select Case bc.Name
                    Case "Statut"

                        If s = "Dispo" Then
                            Dim motive As String = InputBox("Veuillez preciser le motif du blocage", "Motif du blocage ? ")
                            MessageBox.Show("Blocage de la salle ", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            cell.Value = "BLOCAGE"
                            bc.ColorTable = eButtonColor.Magenta
                            Salles_dispoTableAdapter.Fill(MydbDataSet.salles_dispo)
                            Dim rows As MydbDataSet.salles_dispoRow
                            Dim rows2 As MydbDataSet.salles_statusRow
                            rows2 = CType(CType(Salles_statusBindingSource.Current, DataRowView).Row, progelec.MydbDataSet.salles_statusRow)
                            Salles_dispoBindingSource.Filter = "salles_idsalle=" & "'" & rows2.idsalle & "'"
                            If Salles_dispoBindingSource.Count() > INT_thisProgressBarX6Value Then
                                Salles_dispoBindingSource.Position = Salles_dispoBindingSource.Find("salles_idsalle", rows2.idsalle)
                                rows = CType(CType(Salles_dispoBindingSource.Current, DataRowView).Row, MydbDataSet.salles_dispoRow)
                                rows.BeginEdit()
                                rows._date = CStr(Today.Date)
                                rows.statut = "BLOCAGE"
                                rows.motif = motive
                                rows.qui = FormMain.user.Nom_user
                                rows.salles_idsalle = rows2.idsalle
                                rows.EndEdit()
                                Salles_dispoBindingSource.EndEdit()
                                Salles_dispoTableAdapter.Update(MydbDataSet.salles_dispo)
                                Salles_dispoTableAdapter.Fill(MydbDataSet.salles_dispo)

                            Else
                                Salles_dispoBindingSource.AddNew()
                                rows = CType(CType(Salles_dispoBindingSource.Current, DataRowView).Row, MydbDataSet.salles_dispoRow)
                                rows._date = CStr(Today.Date)
                                rows.statut = "BLOCAGE"
                                rows.motif = motive
                                rows.qui = FormMain.user.Nom_user
                                rows.salles_idsalle = rows2.idsalle
                                Salles_dispoBindingSource.EndEdit()
                                Salles_dispoTableAdapter.Update(MydbDataSet.salles_dispo)
                                Salles_dispoTableAdapter.Fill(MydbDataSet.salles_dispo)
                            End If
                            motive = Nothing
                            Salles_statusTableAdapter.Fill(MydbDataSet.salles_status)
                            Salles_dispo_histoTableAdapter.Fill(MydbDataSet.salles_dispo_histo)
                            'Salles_dispo_histoBindingSource.Filter = "salles_idsalle=" & "'" & rows2.idsalle & "'"
                        Else
                            MessageBox.Show("Mise à dispo de la salle ", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            'MessageBox.Show("Blocage de la salle ", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            cell.Value = "Dispo"
                            bc.ColorTable = eButtonColor.BlueWithBackground
                            Salles_dispoTableAdapter.Fill(MydbDataSet.salles_dispo)
                            Dim rows As MydbDataSet.salles_dispoRow
                            Dim rows2 As MydbDataSet.salles_statusRow
                            rows2 = CType(CType(Salles_statusBindingSource.Current, DataRowView).Row, progelec.MydbDataSet.salles_statusRow)
                            Dim motive As String = InputBox("Veuillez preciser le motif de la dispo", "Motif de Dispo ? ")
                            Salles_dispoBindingSource.Filter = "salles_idsalle=" & "'" & rows2.idsalle & "'"
                            If Salles_dispoBindingSource.Count() > INT_thisProgressBarX6Value Then
                                Salles_dispoBindingSource.Position = Salles_dispoBindingSource.Find("salles_idsalle", rows2.idsalle)

                                rows = CType(CType(Salles_dispoBindingSource.Current, DataRowView).Row, MydbDataSet.salles_dispoRow)
                                rows.BeginEdit()
                                rows._date = CStr(Today.Date)
                                rows.statut = "Dispo"
                                rows.qui = FormMain.user.Nom_user
                                rows.motif = motive
                                rows.EndEdit()
                                Salles_dispoBindingSource.EndEdit()
                                Salles_dispoTableAdapter.Update(MydbDataSet.salles_dispo)
                                Salles_dispoTableAdapter.Fill(MydbDataSet.salles_dispo)
                            Else
                                Salles_dispoBindingSource.AddNew()
                                rows = CType(CType(Salles_dispoBindingSource.Current, DataRowView).Row, MydbDataSet.salles_dispoRow)
                                rows._date = CStr(Today.Date)
                                rows.statut = "Dispo"
                                rows.qui = FormMain.user.Nom_user
                                rows.motif = motive
                                rows.salles_idsalle = rows2.idsalle
                                Salles_dispoBindingSource.EndEdit()
                                Salles_dispoTableAdapter.Update(MydbDataSet.salles_dispo)
                                Salles_dispoTableAdapter.Fill(MydbDataSet.salles_dispo)
                            End If
                            motive = Nothing
                            Salles_statusTableAdapter.Fill(MydbDataSet.salles_status)
                            Salles_dispo_histoTableAdapter.Fill(MydbDataSet.salles_dispo_histo)
                            'Salles_dispo_histoBindingSource.Filter = "salles_idsalle=" & "'" & rows2.idsalle & "'"
                        End If

                        Exit Select

                        'Case "Column1"
                        '    If (String.IsNullOrEmpty(s)) Then
                        '        cell.Value = "Global"
                        '    Else
                        '        cell.Value = ""
                        '    End If
                        '    Exit Select
                End Select
            End If
        End If

    End Sub
    Private Sub X2Progress_Initialize()
        Dim pb As DataGridViewButtonXColumn = TryCast(DataGridViewX1.Columns("Statut"), DataGridViewButtonXColumn)

        '   Hook onto the BeforeCellPaint event so we can
        '   demonstrate cell customization

        If pb IsNot Nothing Then
            AddHandler pb.BeforeCellPaint, AddressOf X2Progress_BeforeCellPaint
        End If
    End Sub
    Private Sub X2Progress_BeforeCellPaint(ByVal sender As Object, ByVal e As BeforeCellPaintEventArgs)
        ' Dim pbc As DataGridViewButtonXCell = TryCast(sender, DataGridViewButtonXCell)

        'If pbc IsNot Nothing Then

        Dim bc As DataGridViewButtonXColumn = TryCast(sender, DataGridViewButtonXColumn)
        Dim s As String = Convert.ToString(bc.Text) 'pbc.Value

        Select Case s
            Case "BLOCAGE"
                'pbc.Value = "BLOCAGE"
                bc.Text = "BLOCAGE"
                bc.ColorTable = eButtonColor.BlueWithBackground

                Exit Select

            Case Else

                'pbc.Value = "DISPO"
                bc.Text = "DISPO"
                bc.ColorTable = eButtonColor.OrangeWithBackground
                Exit Select

        End Select

        ' End If
    End Sub

    Private Sub FormDispoSalle_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'MydbDataSet.lst_rac_tenant' table. You can move, or remove it, as needed.
        Me.Lst_rac_tenantTableAdapter.Fill(Me.MydbDataSet.lst_rac_tenant)
        'TODO: This line of code loads data into the 'MydbDataSet.lst_rac_about' table. You can move, or remove it, as needed.
        Me.Lst_rac_aboutTableAdapter.Fill(Me.MydbDataSet.lst_rac_about)
        'TODO: This line of code loads data into the 'MydbDataSet.lst_dispo_tirage' table. You can move, or remove it, as needed.
        Me.Lst_dispo_tirageTableAdapter.Fill(Me.MydbDataSet.lst_dispo_tirage)
        'TODO: This line of code loads data into the 'MydbDataSet.equipements_status' table. You can move, or remove it, as needed.
        Me.Equipements_statusTableAdapter.Fill(Me.MydbDataSet.equipements_status)
        'TODO: This line of code loads data into the 'MydbDataSet.troncons_status' table. You can move, or remove it, as needed.
        Me.Troncons_statusTableAdapter.Fill(Me.MydbDataSet.troncons_status)
        'TODO: This line of code loads data into the 'MydbDataSet.salles_dispo_histo' table. You can move, or remove it, as needed.
        Me.Salles_dispo_histoTableAdapter.Fill(Me.MydbDataSet.salles_dispo_histo)
        'TODO: This line of code loads data into the 'MydbDataSet.salles_dispo' table. You can move, or remove it, as needed.
        Me.Salles_dispoTableAdapter.Fill(Me.MydbDataSet.salles_dispo)
        'TODO: This line of code loads data into the 'MydbDataSet.salles_status' table. You can move, or remove it, as needed.
        Me.Salles_statusTableAdapter.Fill(Me.MydbDataSet.salles_status)
        Me.LotsTableAdapter.Fill(Me.MydbDataSet.lots)
        Me.LotsBindingSource.Position = Me.LotsBindingSource.Find("principale", True)
        update_global()
        lot_principal = CType(CType(Me.LotsBindingSource.Current, DataRowView).Row, MydbDataSet.lotsRow).idlots

        DataGridViewX1_CellMouseClickExtracted()
        X2Progress_Initialize()
    End Sub

    Private Sub DataGridViewX1_CellMouseClickExtracted()
        Dim rows_click As MydbDataSet.salles_statusRow
        rows_click = CType(CType(Salles_statusBindingSource.Current, DataRowView).Row, MydbDataSet.salles_statusRow)
        row_clk = rows_click.idsalle
        Salles_dispo_histoBindingSource.RemoveFilter()

        Salles_dispo_histoBindingSource.Filter = "salles_idsalle=" & "'" & row_clk & "'"
        Me.Troncons_statusBindingSource.RemoveFilter()
        Me.Troncons_statusBindingSource.Filter = "id_sall_tenant ='" & rows_click.idsalle & "'"
        Me.LabelX8.Text = CStr(Me.Troncons_statusBindingSource.Count)
        Dim cc As MydbDataSet.troncons_statusRow
        Dim total As Integer
        Dim total2, total3 As Double
        For Each c In Me.Troncons_statusBindingSource
            Try
                cc = CType(CType(c, DataRowView).Row, MydbDataSet.troncons_statusRow)
                If cc.pose Then
                    If Not IsDBNull(cc.temp_de_pose) Then

                        total += 1
                        total2 += cc.temp_de_pose
                    End If

                End If
                If Not IsDBNull(cc.temp_de_pose) Then
                    total3 += cc.temp_de_pose
                End If
            Catch ex As Exception

            End Try

        Next
        Me.ProgressBarX4.Maximum = Me.Troncons_statusBindingSource.Count
        Me.ProgressBarX4.Value = total
        Me.ProgressBarX4.TextVisible = True
        Me.ProgressBarX4.Text = total & " / " & Me.Troncons_statusBindingSource.Count

        Me.ProgressBarX10.Maximum = 100
        If total3 = INT_thisProgressBarX6Value Then
            Me.ProgressBarX10.Value = INT_thisProgressBarX6Value
            Me.LabelX19.Text = " 0 %"
            Me.LabelX14.Text = " 0 %"
        Else
            Me.ProgressBarX10.Value = CInt(total2 * 100 / total3)
            Me.LabelX19.Text = Math.Round(CInt(total2 * 100 / total3), 2) & " % "
            Me.LabelX14.Text = String.Format("{0} %", Math.Round(total / Me.Troncons_statusBindingSource.Count * 100))
        End If
        Me.ProgressBarX10.TextVisible = True
        Me.ProgressBarX10.Text = total2 & " / " & total3

        Me.Equipements_statusBindingSource.Filter = String.Format("idsalle ='{0}'{1}", rows_click.idsalle, _switchval)
        Dim etotal As Integer
        Dim etotal2, etotal3 As Double
        For Each c In Me.Equipements_statusBindingSource
            Dim cd As MydbDataSet.equipements_statusRow
            cd = CType(CType(c, DataRowView).Row, MydbDataSet.equipements_statusRow)

            If cd.pose Then etotal += 1
            Try
                etotal3 += CDbl(cd.temp_de_pose)
                If cd.pose Then
                    etotal2 += CDbl(cd.temp_de_pose)
                End If

            Catch ex As Exception

            End Try

        Next
        Me.ProgressBarX1.Maximum = Me.Equipements_statusBindingSource.Count
        Me.ProgressBarX1.Value = etotal
        Me.ProgressBarX1.Text = etotal & " / " & Me.Equipements_statusBindingSource.Count
        Me.ProgressBarX1.TextVisible = True
        Me.ProgressBarX6.Maximum = 100
        If etotal3 = INT_thisProgressBarX6Value Then
            Me.ProgressBarX6.Value = INT_thisProgressBarX6Value
            Me.LabelX21.Text = "0 %"
            Me.LabelX16.Text = "0 %"

        Else
            Me.ProgressBarX6.Value = CInt(Math.Round(CInt(etotal2 * 100 / etotal3), 2))
            Me.LabelX21.Text = String.Format("{0} %", Math.Round(CInt(etotal2 * 100 / etotal3)), 2)
            Me.LabelX16.Text = String.Format("{0} %", Math.Round(etotal / Me.Equipements_statusBindingSource.Count * 100))
        End If

        Me.ProgressBarX6.Text = String.Format("{0} / {1}", Math.Round(etotal2, 2), Math.Round(etotal3, 2))
        Me.ProgressBarX6.TextVisible = True

        Dim ctotal As Integer
        Me.Lst_dispo_tirageBindingSource.RemoveFilter()
        Me.Lst_dispo_tirageBindingSource.Filter = String.Format("Salle_about LIKE'%{0}%'", rows_click.repere_salle)

        Dim ttotal1, ttotal2 As Double
        Me.ProgressBarX2.TextVisible = True
        Me.ProgressBarX2.Maximum = Me.Lst_dispo_tirageBindingSource.Count
        For Each ce In Me.Lst_dispo_tirageBindingSource
            Dim ct As MydbDataSet.lst_dispo_tirageRow
            ct = CType(CType(ce, DataRowView).Row, MydbDataSet.lst_dispo_tirageRow)
            If Not IsDBNull(ct.TempPose) Then
                ttotal1 += ct.TempPose
                If ct.pose Then
                    ctotal += 1
                    ttotal2 += ct.TempPose
                End If
            End If
        Next

        Me.ProgressBarX2.Text = ctotal & " / " & Me.Lst_dispo_tirageBindingSource.Count

        Me.ProgressBarX8.TextVisible = True
        Me.ProgressBarX8.Maximum = 100
        If ttotal1 = INT_thisProgressBarX6Value Then
            Me.ProgressBarX8.Value = INT_thisProgressBarX6Value
            Me.LabelX22.Text = "0 %"
            Me.LabelX17.Text = "0 %"
        Else
            Me.ProgressBarX8.Value = CInt((ttotal2 * 100 / ttotal1))
            Me.LabelX22.Text = Math.Round(CInt((ttotal2 * 100 / ttotal1)), 2) & " %"
            Me.LabelX17.Text = String.Format("{0} %", Math.Round(ctotal / Me.Lst_dispo_tirageBindingSource.Count * 100))
        End If
        Me.ProgressBarX8.Text = ttotal2 & " / " & ttotal1

        Dim global1, global2 As Integer
        Dim tglobal, tglobal2 As Double

        global1 = Me.Troncons_statusBindingSource.Count + Me.Equipements_statusBindingSource.Count + Me.Lst_dispo_tirageBindingSource.Count
        global2 = etotal + total + ctotal
        Me.ProgressBarX5.Maximum = global1
        Me.ProgressBarX5.Value = global2
        Me.ProgressBarX5.TextVisible = True
        Me.ProgressBarX5.Text = global2 & " / " & global1

        tglobal = etotal3 + total3 + ttotal1
        tglobal2 = etotal2 + total2 + ttotal2
        Me.ProgressBarX7.Maximum = CInt(tglobal)
        Me.ProgressBarX7.Value = CInt(tglobal2)
        Me.ProgressBarX7.TextVisible = True
        Me.ProgressBarX7.Text = tglobal2 & " / " & tglobal
        If tglobal = 0 Then
            Me.LabelX20.Text = " 0 % "

        Else
            Me.LabelX20.Text = String.Format("{0} %", Math.Round(tglobal2 / tglobal * 100))

        End If
        If global1 = 0 Then
            Me.LabelX15.Text = " 0 %"
        Else
            Me.LabelX15.Text = String.Format("{0} %", Math.Round(global2 / global1 * 100))
        End If
        Me.GroupPanel1.Text = " Avancement salle :" & CType(CType(Me.Salles_statusBindingSource.Current, DataRowView).Row, MydbDataSet.salles_statusRow).repere_salle
        Dim ctrac, crac As Integer
        Dim strac, srtrac As Double
        Dim thg, thr As Double
        Dim tht, thtr, thtra As Double
        Dim tha, thar, thara As Double
        Me.Lst_rac_tenantBindingSource.RemoveFilter()
        Me.Lst_rac_tenantBindingSource.Filter = String.Format("Salles_idsalle ='{0}'", rows_click.idsalle)
        For Each c In Me.Lst_rac_tenantBindingSource
            Dim ccc As MydbDataSet.lst_rac_tenantRow
            ccc = CType(CType(c, DataRowView).Row, progelec.MydbDataSet.lst_rac_tenantRow)
            tht += ccc.TempRaccTete
            ctrac += 1
            If ccc.pose And Not ccc.rac Then
                thtr += ccc.TempRaccTete
            ElseIf ccc.pose And ccc.rac Then
                thtra += ccc.TempRaccTete
                crac += crac
            End If
        Next
        Me.Lst_rac_aboutBindingSource.RemoveFilter()
        Me.Lst_rac_aboutBindingSource.Filter = String.Format("Salles_idsalle ='{0}'", rows_click.idsalle)
        For Each c In Me.Lst_rac_aboutBindingSource
            Dim cccc As MydbDataSet.lst_rac_aboutRow
            cccc = CType(CType(c, DataRowView).Row, progelec.MydbDataSet.lst_rac_aboutRow)
            tha += cccc.TempRaccTete
            ctrac += 1
            If cccc.pose And Not cccc.rac Then
                thar += cccc.TempRaccTete
            ElseIf cccc.pose And cccc.rac Then
                thara += cccc.TempRaccTete
                crac += crac
            End If

        Next
        strac = tht + tha
        srtrac = thara + thtra
        If srtrac = 0 Then
            Me.LabelX18.Text = " 0 % "
            Me.LabelX23.Text = " 0 % "
            Me.ProgressBarX9.Value = 0
            Me.ProgressBarX9.Text = String.Format("{0} / {1}", Math.Round(srtrac, 2), Math.Round(strac, 2))
            Me.ProgressBarX9.TextVisible = True
            ProgressBarX3.TextVisible = True
            ProgressBarX3.Text = String.Format("{0} / {1}", Math.Round(crac, 2), Math.Round(ctrac, 2))
            ProgressBarX3.Value = 0
        Else
            Me.ProgressBarX9.Value = CInt(Math.Round(CInt((ttotal2 * 100 / ttotal1)), 2))
            Me.ProgressBarX9.Text = String.Format("{0} / {1}", Math.Round(srtrac, 2), Math.Round(strac, 2))
            Me.ProgressBarX9.TextVisible = True
            Me.LabelX23.Text = String.Format("{0} %", Math.Round(strac / srtrac * 100))
            ProgressBarX3.Value = crac
            ProgressBarX3.Maximum = ctrac
            ProgressBarX3.TextVisible = True
            ProgressBarX3.Text = String.Format("{0} / {1}", Math.Round(crac, 2), Math.Round(ctrac, 2))
            '  ProgressBarX3.Value = 0
            LabelX18.Text = String.Format("{0} %", Math.Round(crac / ctrac * 100))

        End If

    End Sub
    Private Sub update_global()

        ' x11 equipements
        Dim getotal As Integer
        Dim getotal2, getotal3 As Double
        Me.Equipements_statusBindingSource.RemoveFilter()
        For Each c In Me.Equipements_statusBindingSource
            Dim gcd As mydbDataSet.equipements_statusRow
            gcd = CType(CType(c, DataRowView).Row, mydbDataSet.equipements_statusRow)

            If gcd.pose Then getotal += 1
            Try
                getotal3 += CDbl(gcd.temp_de_pose)
                If gcd.avancement > 0 And gcd.pose = False Then
                    getotal2 += CDbl(gcd.temp_de_pose * (gcd.avancement / 100))
                End If
                If gcd.pose Then
                    getotal2 += CDbl(gcd.temp_de_pose)
                End If

            Catch ex As Exception

            End Try

        Next
        Me.ProgressBarX11.Maximum = 10000
        Me.ProgressBarX11.Value = CInt(Math.Round(((getotal2 * 100) / getotal3), 2) * 100)

        Me.ProgressBarX11.Text = Math.Round(getotal2, 2) & " / " & Math.Round(getotal3, 2) & " ( " & Math.Round(((getotal2 * 100) / getotal3), 2) & " %)"
        Me.ProgressBarX11.TextVisible = True




        'x13 tirrage
        Dim ctotal As Integer
        Me.Lst_dispo_tirageBindingSource.RemoveFilter()
        ' Me.Lst_dispo_tirageBindingSource.Filter = String.Format("Salle_about LIKE'%{0}%'", rows_click.repere_salle)

        Dim ttotal1, ttotal2 As Double
        Me.ProgressBarX2.TextVisible = True
        Me.ProgressBarX2.Maximum = Me.Lst_dispo_tirageBindingSource.Count
        For Each ce In Me.Lst_dispo_tirageBindingSource
            Dim ct As mydbDataSet.lst_dispo_tirageRow
            ct = CType(CType(ce, DataRowView).Row, mydbDataSet.lst_dispo_tirageRow)
            If Not IsDBNull(ct.TempPose) Then
                ttotal1 += ct.temps
                If ct.pose Then
                    ctotal += 1
                    ttotal2 += ct.temps
                End If
            End If
        Next
        Me.ProgressBarX13.Maximum = 10000
        Me.ProgressBarX13.Value = CInt(Math.Round(((ttotal2 * 100) / ttotal1), 2) * 100)

        Me.ProgressBarX13.Text = Math.Round(ttotal2, 2) & " / " & Math.Round(ttotal1, 2) & " ( " & Math.Round(((ttotal2 * 100) / ttotal1), 2) & " %)"
        Me.ProgressBarX13.TextVisible = True
        'x14 raccordements
        Dim ctrac, crac As Integer
        Dim strac, srtrac As Double
        Dim thg, thr As Double
        Dim tht, thtr, thtra As Double
        Dim tha, thar, thara As Double
        Me.Lst_rac_tenantBindingSource.RemoveFilter()
        ' Me.Lst_rac_tenantBindingSource.Filter = String.Format("Salles_idsalle ='{0}'", rows_click.idsalle)
        For Each c In Me.Lst_rac_tenantBindingSource
            Dim ccc As mydbDataSet.lst_rac_tenantRow
            ccc = CType(CType(c, DataRowView).Row, progelec.mydbDataSet.lst_rac_tenantRow)
            tht += ccc.TempRaccTete
            ctrac += 1
            If ccc.pose And Not ccc.rac Then
                thtr += ccc.TempRaccTete
            ElseIf ccc.pose And ccc.rac Then
                thtra += ccc.TempRaccTete
                crac += crac
            End If
        Next
        Me.Lst_rac_aboutBindingSource.RemoveFilter()
        ' Me.Lst_rac_aboutBindingSource.Filter = String.Format("Salles_idsalle ='{0}'", rows_click.idsalle)
        For Each c In Me.Lst_rac_aboutBindingSource
            Dim cccc As mydbDataSet.lst_rac_aboutRow
            cccc = CType(CType(c, DataRowView).Row, progelec.mydbDataSet.lst_rac_aboutRow)
            tha += cccc.TempRaccTete
            ctrac += 1
            If cccc.pose And Not cccc.rac Then
                thar += cccc.TempRaccTete
            ElseIf cccc.pose And cccc.rac Then
                thara += cccc.TempRaccTete
                crac += crac
            End If

        Next
        strac = tht + tha
        srtrac = thara + thtra
        Me.ProgressBarX14.Text = String.Format("{0} / {1}  ( {2} % )", (Math.Round(srtrac, 2)), (Math.Round(strac, 2)), (Math.Round(((srtrac * 100) / strac), 2)))
        Me.ProgressBarX14.TextVisible = True
        Me.ProgressBarX14.Maximum = 10000
        Me.ProgressBarX14.Value = CInt(Math.Round(((srtrac * 100) / strac), 2) * 100)

        'x15 cheminement
        Dim gcc As mydbDataSet.troncons_statusRow
        Dim gtotal As Integer
        Dim gtotal2, gtotal3 As Double
        Me.Troncons_statusBindingSource.RemoveFilter()
        For Each c In Me.Troncons_statusBindingSource
            Try
                gcc = CType(CType(c, DataRowView).Row, mydbDataSet.troncons_statusRow)
                If gcc.pose Then
                    If Not IsDBNull(gcc.temp_de_pose) Then

                        gtotal += 1
                        gtotal2 += gcc.temp_de_pose
                    End If

                End If
                If Not IsDBNull(gcc.temp_de_pose) Then
                    gtotal3 += gcc.temp_de_pose
                End If
            Catch ex As Exception

            End Try

        Next
        Me.ProgressBarX15.Text = String.Format("{0} / {1}  ( {2} % )", (Math.Round(gtotal2, 2)), (Math.Round(gtotal3, 2)), (Math.Round(((gtotal2 * 100) / gtotal3), 2)))
        Me.ProgressBarX15.TextVisible = True
        Me.ProgressBarX15.Maximum = 10000
        Me.ProgressBarX15.Value = CInt(Math.Round(((gtotal2 * 100) / gtotal3), 2) * 100)
        'x12 global
        Dim tg As Double
        Dim tr As Double
        tg = gtotal3 + strac + ttotal1 + getotal3
        tr = gtotal2 + srtrac + ttotal2 + getotal2
        Me.ProgressBarX12.Text = String.Format("{0} / {1}  ( {2} % )", (Math.Round(tr, 2)), (Math.Round(tg, 2)), (Math.Round(((tr * 100) / tg), 2)))
        Me.ProgressBarX12.TextVisible = True
        Me.ProgressBarX12.Maximum = 10000
        Me.ProgressBarX12.Value = CInt(Math.Round(((tr * 100) / tg), 2) * 100)
    End Sub
    Private Sub DataGridViewX1_CellMouseClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewX1.CellClick
        DataGridViewX1_CellMouseClickExtracted()
    End Sub

    Private Sub ProgressBarX4_Click(sender As System.Object, e As System.EventArgs) Handles ProgressBarX4.DoubleClick, ProgressBarX15.DoubleClick

        Dim ChildWindowFound As Boolean = False
        If Not (ParentForm.MdiChildren.Length.Equals(INT_thisProgressBarX6Value)) Then
            For Each ChildWindow As Form In ParentForm.MdiChildren
                If ChildWindow.Name.Equals("FormDsipoCheminements") Then
                    ChildWindow.Activate()
                    ChildWindowFound = True
                End If
            Next
        End If

        If Not ChildWindowFound Then
            Dim FormDsipoCheminements As FormDsipoCheminements
            FormDsipoCheminements = New FormDsipoCheminements
            FormDsipoCheminements.MdiParent = Me.ParentForm
            FormDsipoCheminements.WindowState = FormWindowState.Maximized
            ' AddHandler Parent.EventFired2, AddressOf FormDsipoCheminements.actualisation
            FormDsipoCheminements.Show()
        End If
    End Sub

    Private Sub ProgressBarX1_DoubleClick(sender As System.Object, e As System.EventArgs) Handles ProgressBarX1.DoubleClick, ProgressBarX11.DoubleClick
        Dim ChildWindowFound As Boolean = False
        If Not (ParentForm.MdiChildren.Length.Equals(INT_thisProgressBarX6Value)) Then
            For Each ChildWindow As Form In ParentForm.MdiChildren
                If ChildWindow.Name.Equals("FormDispoEquip") Then
                    ChildWindow.Activate()
                    ChildWindowFound = True
                End If
            Next
        End If

        If Not ChildWindowFound Then
            Dim FormDispoEquip As FormDispoEquip
            FormDispoEquip = New FormDispoEquip
            FormDispoEquip.MdiParent = Me.ParentForm
            FormDispoEquip.WindowState = FormWindowState.Maximized
            ' AddHandler Parent.EventFired2, AddressOf FormDsipoCheminements.actualisation
            FormDispoEquip.Show()
        End If
    End Sub

    Private Sub SwitchButton1_ValueChanged(sender As System.Object, e As System.EventArgs) Handles SwitchButton1.ValueChanged
        If SwitchButton1.Value Then
            _switchval = String.Format(" and idlots='{0}'", lot_principal)
        Else
            _switchval = ""
        End If
        DataGridViewX1_CellMouseClickExtracted()
    End Sub

    Private Sub SwitchButton2_ValueChanged(sender As System.Object, e As System.EventArgs) Handles SwitchButton2.ValueChanged
        If SwitchButton2.Value Then
            Me.DataGridViewX1.Visible = False
            Me.DataGridViewX2.Visible = False
            Me.GroupPanel1.Visible = False

            Chart1.Series("Series1").ChartType = SeriesChartType.StackedBar100
            Chart1.Series("Series2").ChartType = SeriesChartType.StackedBar100
            Chart1.Series("Series3").ChartType = SeriesChartType.StackedBar100

            'On met les 3 series dans le même StackedGroup
            '(Peut importe le nom du group)
            Chart1.Series("Series1")("StackedGroupName") = "Group1"
            Chart1.Series("Series2")("StackedGroupName") = "Group1"
            Chart1.Series("Series3")("StackedGroupName") = "Group1"
            'on ajoute l'affichage des valeurs Y comme label
            Chart1.Series("Series1").IsValueShownAsLabel = True
            Chart1.Series("Series2").IsValueShownAsLabel = True
            Chart1.Series("Series3").IsValueShownAsLabel = True
            Me.GroupPanel2.Visible = True
            update_global()
        Else
            Me.DataGridViewX1.Visible = True
            Me.DataGridViewX2.Visible = True
            Me.GroupPanel1.Visible = True

            Me.GroupPanel2.Visible = False
        End If

    End Sub

    Private Sub ProgressBarX3_DoubleClick(sender As System.Object, e As System.EventArgs) Handles ProgressBarX3.DoubleClick
        Dim ChildWindowFound As Boolean = False
        If Not (ParentForm.MdiChildren.Length.Equals(INT_thisProgressBarX6Value)) Then
            For Each ChildWindow As Form In ParentForm.MdiChildren
                If ChildWindow.Name.Equals("FormDispoRaccordement") Then
                    Dim formChild2 As FormDispoRaccordement = DirectCast(ChildWindow, FormDispoRaccordement)
                    formChild2.Filtre1 = CType(CType(Me.Salles_statusBindingSource.Current, DataRowView).Row, MydbDataSet.salles_statusRow).idsalle
                    ChildWindow.Activate()

                    ChildWindowFound = True
                End If
            Next
        End If

        If Not ChildWindowFound Then
            Dim FormDispoRaccordement As FormDispoRaccordement
            FormDispoRaccordement = New FormDispoRaccordement
            FormDispoRaccordement.MdiParent = Me.ParentForm
            FormDispoRaccordement.WindowState = FormWindowState.Maximized
            FormDispoRaccordement.Filtre1 = CType(CType(Me.Salles_statusBindingSource.Current, DataRowView).Row, MydbDataSet.salles_statusRow).idsalle
            AddHandler EventFired6, AddressOf FormDsipoCheminements.actualisation
            FormDispoRaccordement.Show()
        End If
    End Sub

    Private Sub DataGridViewX1_KeyUp(sender As Object, e As KeyEventArgs) Handles DataGridViewX1.KeyUp
        Select Case e.KeyCode
            Case Keys.Down
                DataGridViewX1_CellMouseClickExtracted()
            Case Keys.Up
                DataGridViewX1_CellMouseClickExtracted()

        End Select
    End Sub
End Class