Imports DevComponents.DotNetBar
Imports DevComponents.AdvTree

Public Class FormMiseTourets
    Dim maxtouret As Integer
    Dim mintouret As Integer
    Dim col1 As New AutoCompleteStringCollection
    Private Sub FormMiseTourets_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.tourets'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.TouretsTableAdapter.Fill(Me.MydbDataSet.tourets)
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.fournitures'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.FournituresTableAdapter.Fill(Me.MydbDataSet.fournitures)
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.cables_details_has_tourets'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.Cables_details_has_touretsTableAdapter.Fill(Me.MydbDataSet.cables_details_has_tourets)
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.tourets_has_fournitures'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.Tourets_has_fournituresTableAdapter.Fill(Me.MydbDataSet.tourets_has_fournitures)
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.donnee_phy'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.Donnee_phyTableAdapter.Fill(Me.MydbDataSet.donnee_phy)
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.lst_tourets'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.Lst_touretsTableAdapter.Fill(Me.MydbDataSet.lst_tourets)
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.lst_cable_mise_touret'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.Lst_cable_mise_touretTableAdapter.Fill(Me.MydbDataSet.lst_cable_mise_touret)
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.sections_cables'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.Sections_cablesTableAdapter.Fill(Me.MydbDataSet.sections_cables)
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.types_cable'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.Types_cableTableAdapter.Fill(Me.MydbDataSet.types_cable)
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.salles'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.SallesTableAdapter.Fill(Me.MydbDataSet.salles)
        Maj_Data_Combo()
        Me.StepItem1.Value = 100
        step_select()
        mintouret = 999999
        reperetouret()
    End Sub
    Private Sub reperetouret()
        For i = 0 To Me.MydbDataSet.tourets.Rows.Count - 1
            col1.Add(Me.MydbDataSet.tourets.Rows(i)("Repere").ToString())
            If maxtouret < CInt(Me.MydbDataSet.tourets.Rows(i)("idtouret")) Then maxtouret = CInt(Me.MydbDataSet.tourets.Rows(i)("idtouret"))
            If mintouret > CInt(Me.MydbDataSet.tourets.Rows(i)("idtouret")) Then mintouret = CInt(Me.MydbDataSet.tourets.Rows(i)("idtouret"))

        Next
        TextBoxX1.AutoCompleteSource = AutoCompleteSource.CustomSource
        TextBoxX1.AutoCompleteCustomSource = col1
        TextBoxX1.AutoCompleteMode = AutoCompleteMode.SuggestAppend
    End Sub
    Private Sub step_select()

        If StepItem1.Value = 100 Then
            Me.ListViewEx3.Enabled = False
            Me.ListViewEx4.Enabled = False
        ElseIf StepItem2.Value = 100 Then
            Me.ListViewEx3.Enabled = True
            Me.ListViewEx4.Enabled = False
        ElseIf StepItem3.Value = 100 Then
            Me.ListViewEx3.Enabled = True
            Me.ListViewEx4.Enabled = True
        End If

    End Sub
#Region "Barre selection"

    Private Sub StepItem1_Click(sender As Object, e As EventArgs) Handles StepItem1.Click
        StepItem1.Value = 100
        StepItem2.Value = 0
        StepItem3.Value = 0
        step_select()
    End Sub

    Private Sub StepItem2_Click(sender As Object, e As EventArgs) Handles StepItem2.Click
        StepItem1.Value = 0
        StepItem2.Value = 100
        StepItem3.Value = 0
        step_select()
    End Sub

    Private Sub StepItem3_Click(sender As Object, e As EventArgs) Handles StepItem3.Click
        StepItem1.Value = 0
        StepItem2.Value = 0
        StepItem3.Value = 100
        step_select()
    End Sub
#End Region

#Region "affichage donnee combo"
    Dim dataCombo3 As DataTable
    Private Sub Maj_Data_Combo()

        Dim dc As New Dictionary(Of String, String)
        For Each r As DataRowView In Me.SallesBindingSource
            If Not dc.ContainsKey(r.Item(2).ToString()) Then dc.Add(r.Item(2).ToString(), r.Item(2).ToString())
        Next
        Me.ComboBoxEx1.DataSource = Me.SallesBindingSource
        Me.ComboBoxEx1.DisplayMember = "repere salle"

        Me.ComboBoxEx3.DataSource = New BindingSource(dc, Nothing)
        Me.ComboBoxEx3.DisplayMember = "key"

        Me.ComboBoxEx2.DataSource = Me.Sections_cablesBindingSource
        Me.ComboBoxEx2.DisplayMember = "section"

        Me.ComboBoxEx1.DataSource = Me.Types_cableBindingSource
        Me.ComboBoxEx1.DisplayMember = "types"

        With ListViewEx1
            .Columns.Add("Type")
            .Columns.Add("id")
            .View = View.Tile
            .GridLines = True
            .FullRowSelect = True
            ' Dim dt As mydbDataSet.types_cableRow
            Dim dt As MydbDataSet.lst_cable_mise_touretRow
            Me.Lst_cable_mise_touretBindingSource.Filter = "Touret_def = '' or Touret_def is null"
            Dim dtr As DataRowView
            Dim dct As New Dictionary(Of String, String)
            For Each dtr In Me.Lst_cable_mise_touretBindingSource
                dt = CType(dtr.Row, MydbDataSet.lst_cable_mise_touretRow)
                If Not dct.ContainsKey(dt.types) Then dct.Add(dt.types, dt.types)
            Next
            For Each dcts As KeyValuePair(Of String, String) In dct

                Dim ListViewE As New ListViewItem(CStr(dcts.Key))

                Me.ListViewEx1.Items.Add(ListViewE)
            Next

            'For Each dtr In Me.Lst_cable_mise_touretBindingSource

            '    dt = CType(dtr.Row, mydbDataSet.lst_cable_mise_touretRow)
            '    Dim ListViewE As New ListViewItem(dt.types.ToString)
            '    ListViewE.SubItems.Add(dt.types.ToString)
            '    .Items.Add(ListViewE)
            'Next
        End With
        With ListViewEx2
            .Columns.Add("section")
            .Columns.Add("id")
            .View = View.Tile
            .GridLines = True
            .FullRowSelect = True
        End With
    End Sub

#End Region

#Region "affichage et Filtrage sur touret"
    Private Sub affiche_tourets(Optional ByVal section As Integer = Nothing, Optional ByVal type As Integer = Nothing, Optional ByVal donnee As Integer = Nothing)

        Dim subItemStyle As New ElementStyle()

        subItemStyle = New ElementStyle()
        subItemStyle.TextColor = Color.SlateGray
        subItemStyle.Name = "subiteNum"
        AdvTree1.Styles.Add(subItemStyle)

        subItemStyle = New ElementStyle()
        subItemStyle.TextColor = Color.Maroon
        subItemStyle.Name = "subitemLong"
        AdvTree1.Styles.Add(subItemStyle)

        subItemStyle = New ElementStyle()
        subItemStyle.TextColor = Color.Green
        subItemStyle.Name = "subitemOK"
        AdvTree1.Styles.Add(subItemStyle)

        AdvTree1.TileSize = New Size(200, 48)
        AdvTree1.DisplayMembers = "Repere,Long_estime,Longueur"
        AddHandler AdvTree1.DataNodeCreated, AddressOf AdvTree7DataNodeCreated
        Me.Lst_touretsBindingSource.Filter = "types='" & ListViewEx1.FocusedItem.Text & "' and section='" & ListViewEx2.FocusedItem.Text & "'"

        AdvTree1.DataSource = Me.Lst_touretsBindingSource

    End Sub
    Private Sub AdvTree7DataNodeCreated(ByVal sender As Object, ByVal e As DevComponents.DotNetBar.Controls.DataNodeEventArgs)

        If e.Node.Cells(1).Text = "" Then e.Node.Cells(1).Text = "0"
        If CDbl(e.Node.Cells(1).Text) > CDbl(e.Node.Cells(2).Text) * 0.8 Then
            e.Node.Cells(1).StyleNormal = AdvTree1.Styles("subiteNum")
            e.Node.Cells(2).StyleNormal = AdvTree1.Styles("subitemLong")
        Else
            e.Node.Cells(1).StyleNormal = AdvTree1.Styles("subiteNum")
            e.Node.Cells(2).StyleNormal = AdvTree1.Styles("subitemOK")

        End If

    End Sub
#End Region

#Region "Filtrage sur section"

#End Region

#Region "Filtrage sur type"

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        ' affiche_tourets()
        Me.Donnee_phyBindingSource.Filter = "types_cable_idtypes_cable=" & Me.ComboBox2.SelectedValue.ToString & " and sections_cables_idsections_cables=" & Me.ComboBox1.SelectedValue.ToString
        If Me.Donnee_phyBindingSource.Count = 0 Then

        Else

            Dim ntouret As MydbDataSet.touretsRow
            Me.TouretsBindingSource.AddNew()
            ntouret = CType(CType(Me.TouretsBindingSource.Current, DataRowView).Row, MydbDataSet.touretsRow)
            ntouret.Repere = Me.TextBoxX1.Text
            ntouret.Actif = True
            ntouret.Long_estime = CDec(Me.TextBoxX4.Text)
            ntouret.donnees_cables_iddonnee = CType(CType(Me.Donnee_phyBindingSource.Current, DataRowView).Row, MydbDataSet.donnee_phyRow).iddonnee
            Me.TouretsBindingSource.EndEdit()
            Me.TouretsTableAdapter.Update(MydbDataSet.tourets)
            Me.TouretsTableAdapter.Fill(MydbDataSet.tourets)

            reperetouret()
        End If

        Me.Lst_touretsTableAdapter.Fill(MydbDataSet.lst_tourets)
        Me.Donnee_phyBindingSource.Filter = Nothing
    End Sub

    Private Sub ListViewEx1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListViewEx1.MouseClick
        Dim test As String
        test = CStr(ListViewEx1.FocusedItem.Text)
        If Me.ListViewEx1.SelectedIndices.Count <= 0 Then
            Return
        End If
        Dim selNdx = Me.ListViewEx1.SelectedIndices(0)
        If selNdx >= 0 Then
            '   MsgBox(ListViewEx1.Items(selNdx).Text)
            '  MsgBox (ListViewEx1.Items(selNdx).SubItems(1).Text)

            'Me.Donnee_phyBindingSource.Filter = "types_cable_idtypes_cable=" & ListViewEx1.Items(selNdx).SubItems(1).Text
            Me.Lst_cable_mise_touretBindingSource.Filter = "types='" & ListViewEx1.Items(selNdx).Text & "' and Touret_def is null"
            Dim dcs As New Dictionary(Of String, String)
            For Each r As DataRowView In Me.Lst_cable_mise_touretBindingSource
                If Not dcs.ContainsKey(r.Item(8).ToString()) Then dcs.Add(r.Item(8).ToString(), r.Item(8).ToString())
            Next
            Me.ListViewEx2.Items.Clear()
            For Each dcst As KeyValuePair(Of String, String) In dcs

                Dim ListViewE2 As New ListViewItem(CStr(dcst.Key))

                Me.ListViewEx2.Items.Add(ListViewE2)
            Next

        End If
    End Sub
#End Region
#Region "darg ands drop"

    Private Sub DataGridViewX1_DragEnter(sender As Object, e As DragEventArgs) Handles DataGridViewX2.DragEnter
        e.Effect = DragDropEffects.Copy
    End Sub

    Private Sub DataGridViewX2_DragDrop(sender As Object, e As DragEventArgs) Handles DataGridViewX2.DragDrop
        Try
            '    Dim r As DataGridViewSelectedRowCollection = CType(e.Data.GetData(GetType(DataGridViewSelectedRowCollection)), DataGridViewSelectedRowCollection)
            Dim r As DataGridViewSelectedRowCollection = CType(e.Data.GetData(GetType(DataGridViewSelectedRowCollection)), DataGridViewSelectedRowCollection)
            For Each selectedItem As DataGridViewRow In r
                Dim cables As MydbDataSet.lst_cable_mise_touretRow
                cables = CType(CType(selectedItem.DataBoundItem, DataRowView).Row, MydbDataSet.lst_cable_mise_touretRow)
                Dim touret As MydbDataSet.lst_touretsRow

                Me.Lst_touretsBindingSource.Position = Me.Lst_touretsBindingSource.Find("repere", Me.LabelX17.Text)
                touret = CType(CType(Me.Lst_touretsBindingSource.Current, DataRowView).Row, MydbDataSet.lst_touretsRow)
                Dim total1 As Double = Nothing
                Me.Tourets_has_fournituresBindingSource.Filter = Nothing

                Me.Tourets_has_fournituresBindingSource.Filter = "tourets_idtouret=" & touret.idtouret
                If Not Me.Tourets_has_fournituresBindingSource.Count = 0 Then
                    Dim idtf As Integer = CType(CType(Me.Tourets_has_fournituresBindingSource.Current, DataRowView).Row, MydbDataSet.tourets_has_fournituresRow).fournitures_idfourniture

                    Me.FournituresBindingSource.Position = Me.FournituresBindingSource.Find("idfourniture", idtf)
                    Dim longtouret As Decimal = CType(CType(Me.FournituresBindingSource.Current, DataRowView).Row, MydbDataSet.fournituresRow).Longueur
                    total1 = longtouret - (touret.Long_estime + (CDec(cables.longueur) / 1000))
                    If total1 < 1 Then
                        MsgBox("Trop grand ")
                        Me.Lst_cable_mise_touretTableAdapter.Fill(MydbDataSet.lst_cable_mise_touret)

                        Exit Sub
                    End If
                    Dim rooww As MydbDataSet.cables_details_has_touretsRow

                    Me.Cables_details_has_touretsBindingSource.AddNew()
                    rooww = CType(CType(Me.Cables_details_has_touretsBindingSource.Current, DataRowView).Row, MydbDataSet.cables_details_has_touretsRow)
                    rooww.cables_details_idcables_details = cables.idcables_details
                    rooww.tourets_idtouret = touret.idtouret
                    Me.Cables_details_has_touretsBindingSource.EndEdit()
                    Me.Cables_details_has_touretsTableAdapter.Update(MydbDataSet.cables_details_has_tourets)

                    Me.Cables_details_has_touretsTableAdapter.Fill(MydbDataSet.cables_details_has_tourets)

                    Dim row As MydbDataSet.touretsRow
                    Me.TouretsBindingSource.Position = Me.TouretsBindingSource.Find("idtouret", touret.idtouret)
                    row = CType(CType(Me.TouretsBindingSource.Current, DataRowView).Row, MydbDataSet.touretsRow)

                    row.BeginEdit()
                    If row.IsLong_estimeNull Then
                        row.Long_estime = CDec((touret.Long_estime + (CDec(cables.longueur) / 1000)))
                    Else
                        row.Long_estime = CDec((touret.Long_estime + (CDec(cables.longueur) / 1000)))
                    End If
                    row.EndEdit()
                    'Me.TouretsBindingSource.EndEdit()
                    Me.TouretsTableAdapter.Update(MydbDataSet.tourets)
                    Me.TouretsTableAdapter.Fill(MydbDataSet.tourets)
                    Me.Lst_touretsTableAdapter.Fill(MydbDataSet.lst_tourets)

                Else

                    Dim idtf As Integer = CType(CType(Me.Tourets_has_fournituresBindingSource.Current, DataRowView).Row, MydbDataSet.tourets_has_fournituresRow).fournitures_idfourniture

                    Me.FournituresBindingSource.Position = Me.FournituresBindingSource.Find("idfourniture", idtf)
                    Dim longtouret As Decimal = CType(CType(Me.FournituresBindingSource.Current, DataRowView).Row, MydbDataSet.fournituresRow).Longueur
                    total1 = longtouret - (touret.Long_estime + (CDec(cables.longueur) / 1000))
                    If total1 < 1 Then
                        MsgBox("Trop grand ")
                        Exit Sub
                    End If
                    Dim rooww As MydbDataSet.cables_details_has_touretsRow

                    Me.Cables_details_has_touretsBindingSource.AddNew()
                    rooww = CType(CType(Me.Cables_details_has_touretsBindingSource.Current, DataRowView).Row, MydbDataSet.cables_details_has_touretsRow)
                    rooww.cables_details_idcables_details = cables.idcables_details
                    rooww.tourets_idtouret = touret.idtouret
                    Me.Cables_details_has_touretsBindingSource.EndEdit()
                    Me.Cables_details_has_touretsTableAdapter.Update(MydbDataSet.cables_details_has_tourets)

                    Me.Cables_details_has_touretsTableAdapter.Fill(MydbDataSet.cables_details_has_tourets)

                    Dim row As MydbDataSet.touretsRow
                    Me.TouretsBindingSource.Position = Me.TouretsBindingSource.Find("idtouret", touret.idtouret)
                    row = CType(CType(Me.TouretsBindingSource.Current, DataRowView).Row, MydbDataSet.touretsRow)

                    row.BeginEdit()
                    If row.IsLong_estimeNull Then
                        row.Long_estime = CDec((touret.Long_estime + (CDec(cables.longueur) / 1000)))
                    Else
                        row.Long_estime = CDec((touret.Long_estime + (CDec(cables.longueur) / 1000)))
                    End If
                    row.EndEdit()
                    'Me.TouretsBindingSource.EndEdit()
                    Me.TouretsTableAdapter.Update(MydbDataSet.tourets)
                    Me.TouretsTableAdapter.Fill(MydbDataSet.tourets)
                    Me.Lst_touretsTableAdapter.Fill(MydbDataSet.lst_tourets)

                End If

            Next
            Me.Lst_cable_mise_touretTableAdapter.Fill(MydbDataSet.lst_cable_mise_touret)
            Maj_Data_Combo()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DataGridViewX_MouseDown(sender As Object, e As MouseEventArgs) Handles DataGridViewX1.MouseDown
        Dim Index As Integer
        Index = DataGridViewX1.HitTest(e.X, e.Y).RowIndex
        If Index > -1 Then
            'Pass the Index as "Data" argument of the DoDragDrop Function
            'Me.DataGridViewX1.Rows(Index).Selected = True
            '  DataGridViewX1.DoDragDrop(Index, DragDropEffects.Move)
            '          For  I = 0 to DataGridViewX1.SelectedRows.Count -1
            'DataGridViewX1.DoDragDrop(DataGridViewX1.SelectedRows(I), DragDropEffects.All)
            '        Next
            Dim selectedItems As DataGridViewSelectedRowCollection = DataGridViewX1.SelectedRows
            '   For Each selectedItem As DataGridViewRow In selectedItems
            'Add code to handle whatever you want for each row
            DataGridViewX1.DoDragDrop(selectedItems, DragDropEffects.All)

            '  Next

        End If

        'If DataGridViewX.SelectedRows.Count = 0 Then
        '    Exit Sub
        'End If

    End Sub

#End Region

    Private Sub ListViewEx2_MouseClick(sender As Object, e As MouseEventArgs) Handles ListViewEx2.MouseClick
        affiche_tourets()
        lst_cable_touret()
    End Sub

    Private Sub AdvTree1_DoubleClick(sender As Object, e As EventArgs) Handles AdvTree1.Click
        Me.DataGridViewX2.DataSource = Me.Lst_mise_touret2
        '   Me.SuperGridControl2.PrimaryGrid.DataSource = Me.Lst_mise_touret2
        Me.Lst_mise_touret2.Filter = "Touret_def='" & Me.AdvTree1.SelectedNode.Cells(0).Text & "'"
        Me.LabelX17.Text = Me.AdvTree1.SelectedNode.Cells(0).Text
    End Sub
    Private Sub lst_cable_touret()
        '  Me.SuperGridControl1.PrimaryGrid.DataSource = Nothing
        Me.Lst_cable_mise_touretBindingSource.Filter = "types='" & ListViewEx1.FocusedItem.Text & "' and section='" & ListViewEx2.FocusedItem.Text & "' and Touret_def is null"
        '  Me.SuperGridControl1.PrimaryGrid.DataSource = Me.Lst_cable_mise_touretBindingSource
        '   me.SuperGridControl2.PrimaryGrid.DataSource = Nothing

        Me.DataGridViewX1.DataSource = Me.Lst_cable_mise_touretBindingSource
        Me.DataGridViewX2.DataSource = Nothing
    End Sub

    Private Sub CustomValidator1_ValidateValue(sender As Object, e As Validator.ValidateValueEventArgs) Handles CustomValidator1.ValidateValue
        Me.TouretsBindingSource.Filter = "repere='" & Me.TextBoxX1.Text & "'"

        If Me.TouretsBindingSource.Count = 0 Then
            e.IsValid = True
        Else
            e.IsValid = False
        End If
        Me.TouretsBindingSource.Filter = Nothing

    End Sub

    Private Sub ButtonX2_Click(sender As Object, e As EventArgs) Handles ButtonX2.Click
        Dim rom As MydbDataSet.lst_cable_mise_touretRow
        Dim total As Decimal
        If Me.Lst_mise_touret2.Count > 0 Then
            Dim row As MydbDataSet.touretsRow
            Dim touret As MydbDataSet.lst_touretsRow

            Me.Lst_touretsBindingSource.Position = Me.Lst_touretsBindingSource.Find("repere", Me.LabelX17.Text)
            touret = CType(CType(Me.Lst_touretsBindingSource.Current, DataRowView).Row, MydbDataSet.lst_touretsRow)
            Me.TouretsBindingSource.Position = Me.TouretsBindingSource.Find("idtouret", touret.idtouret)
            row = CType(CType(Me.TouretsBindingSource.Current, DataRowView).Row, MydbDataSet.touretsRow)

            rom = CType(CType(Me.Lst_mise_touret2.Current, DataRowView).Row, MydbDataSet.lst_cable_mise_touretRow)
            Me.Cables_details_has_touretsBindingSource.Position = Me.Cables_details_has_touretsBindingSource.Find("cables_details_idcables_details", rom.idcables_details)

            ' If Not row.IsLong_estimeNull Then
            total = CDec(CDec(row.Long_estime) - (CDec(rom.longueur) / 1000))

            ' End If
            row.BeginEdit()
            '   If Not Me.Tourets_has_fournituresBindingSource.Count = 0 Then

            'si fourniture

            row.Long_estime = CDec(total)
            '   Else

            '  End If
            Dim rooww As MydbDataSet.cables_details_has_touretsRow
            rooww = CType(CType(Me.Cables_details_has_touretsBindingSource.Current, DataRowView).Row, MydbDataSet.cables_details_has_touretsRow)
            Me.Cables_details_has_touretsBindingSource.RemoveCurrent()
            'rooww.cables_details_idcables_details = rom.idcables_details
            'rooww.tourets_idtouret = row.idtouret
            Me.Cables_details_has_touretsBindingSource.EndEdit()
            Me.Cables_details_has_touretsTableAdapter.Update(MydbDataSet.cables_details_has_tourets)

            Me.Cables_details_has_touretsTableAdapter.Fill(MydbDataSet.cables_details_has_tourets)

            row.Long_estime = CDec(total)
            row.EndEdit()

            Try
                Me.TouretsTableAdapter.Update(MydbDataSet.tourets)

                Me.TouretsTableAdapter.Fill(MydbDataSet.tourets)
                Me.Lst_touretsTableAdapter.Fill(MydbDataSet.lst_tourets)
                Me.Lst_cable_mise_touretTableAdapter.Fill(MydbDataSet.lst_cable_mise_touret)
            Catch ex As DBConcurrencyException

                Dim customErrorMessage As String
                customErrorMessage = "Concurrency violation" & vbCrLf
                customErrorMessage += CType(ex.Row.Item(0), String)
                MessageBox.Show(customErrorMessage)

                ' Add business logic code to resolve the concurrency violation...

            End Try
            ' Me.Cables_details_has_touretsBindingSource.RemoveCurrent()
            Me.Cables_details_has_touretsTableAdapter.Update(MydbDataSet.cables_details_has_tourets)
            '  Me.Cables_details_has_touretsTableAdapter.Fill(MydbDataSet.cables_details_has_tourets)
            Me.Lst_cable_mise_touretTableAdapter.Fill(MydbDataSet.lst_cable_mise_touret)
        End If
        Maj_Data_Combo()
    End Sub
End Class