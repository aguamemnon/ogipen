Imports System.Algorithms.Dijkstra
Imports DevComponents.DotNetBar
Imports System.Threading.Tasks

Public Class FormCable
    Inherits OfficeForm
    Public dataSet As DataSet
    Public dataSet2 As DataSet
    Public dataset3 As DataSet
    Public dataset4 As DataSet
    Public troncon_associations As DataView
    Public troncons_seg As DataView
    Dim lst_action As DataTable = New DataTable("actions")
    Public value As String
    Public mode As Boolean

    Public graph As Graph
    Dim lt As DataTable = New DataTable("troncons_seg2")
    Dim lt2 As DataTable = New DataTable("troncons_tri")

    Dim column As DataColumn
    Dim row As DataRow
    Dim i As Integer
    Dim a As Integer
    '

    Dim st As Integer
    Dim fn As Integer
    Dim item As Object
    Public action As String

    Private Sub FormCable_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

    End Sub

    Private Sub FormCable_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        RemoveHandler ComboBox.SelectedIndexChanged, AddressOf ComboBox_SelectedIndexChanged
        RemoveHandler ComboBox9.SelectedIndexChanged, AddressOf ComboBox9_SelectedIndexChanged
        Me.Dispose()
    End Sub
    Private Sub FormCable_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.cables_details_has_tourets'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.Cables_details_has_touretsTableAdapter.Fill(Me.MydbDataSet.cables_details_has_tourets)
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.lst_cable_mise_touret'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.Lst_cable_mise_touretTableAdapter.Fill(Me.MydbDataSet.lst_cable_mise_touret)
        'TODO: This line of code loads data into the 'MydbDataSet.Actions_borniers' table. You can move, or remove it, as needed.
        Me.Actions_borniersTableAdapter.Fill(Me.MydbDataSet.actions_borniers)
        RemoveHandler ComboBox9.SelectedIndexChanged, AddressOf ComboBox9_SelectedIndexChanged
        RemoveHandler ComboBox.SelectedIndexChanged, AddressOf ComboBox_SelectedIndexChanged
        RemoveHandler Repere_equipementComboBox.SelectedValueChanged, AddressOf Repere_equipementComboBox_SelectedValueChanged
        RemoveHandler ComboBox7.SelectedValueChanged, AddressOf ComboBox7_SelectedValueChanged
        'TODO: This line of code loads data into the 'MydbDataSet.troncons' table. You can move, or remove it, as needed.
        Me.TronconsTableAdapter.Fill(Me.MydbDataSet.troncons)
        Me.Parcour_detail_idTableAdapter.Connection.Close()
        Me.EquipementsTableAdapter.Fill(MydbDataSet.equipements)

        Me.Parcour_detail_idTableAdapter.Connection.Open()
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.parcours_detail'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.Parcours_detailTableAdapter.Fill(Me.MydbDataSet.parcours_detail)
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.parcours'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.ParcoursTableAdapter.Fill(Me.MydbDataSet.parcours)
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.sections_cables'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.Sections_cablesTableAdapter.Fill(Me.MydbDataSet.sections_cables)
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.donnees_cables'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.Donnees_cablesTableAdapter.Fill(Me.MydbDataSet.donnees_cables)

        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.categories'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.CategoriesTableAdapter.Fill(Me.MydbDataSet.categories)
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.segregations'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.SegregationsTableAdapter.Fill(Me.MydbDataSet.segregations)
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.lots'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.LotsTableAdapter.Fill(Me.MydbDataSet.lots)
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.types_cable'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.Types_cableTableAdapter.Fill(Me.MydbDataSet.types_cable)
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.cables'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.CablesTableAdapter.Fill(Me.MydbDataSet.cables)
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.types_cable'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.cables_details'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.Cables_detailsTableAdapter.Fill(Me.MydbDataSet.cables_details)
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.departs'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.DepartsTableAdapter.Fill(Me.MydbDataSet.departs)
        Dim cables_row As mydbDataSet.cablesRow

        Dim col As New AutoCompleteStringCollection
        Dim i As Integer
        For i = 0 To Me.MydbDataSet.cables.Rows.Count - 1
            col.Add(Me.MydbDataSet.cables.Rows(i)("repere cable").ToString())
        Next
        Repere_cableTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource
        Repere_cableTextBox.AutoCompleteCustomSource = col
        Repere_cableTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend

        Dim salle_cont1 As New BindingSource
        Dim salle_cont2 As New BindingSource
        Dim salle_cont1_adap As New mydbDataSetTableAdapters.sallesTableAdapter
        Dim salle_cont2_adap As New mydbDataSetTableAdapters.sallesTableAdapter

        Dim equip1 As New BindingSource
        Dim equip2 As New BindingSource

        Dim equip1_adap As New mydbDataSetTableAdapters.equipementsTableAdapter

        Dim equip2_adap As New mydbDataSetTableAdapters.equipementsTableAdapter

        Dim troncons_cont3 As New BindingSource
        Dim troncons_cont4 As New BindingSource
        Dim troncons_cont3_adap As New mydbDataSetTableAdapters.tronconsTableAdapter
        Dim troncons_cont4_adap As New mydbDataSetTableAdapters.tronconsTableAdapter

        'equip1_adap.Fill(Me.MydbDataSet.equipements)
        'equip2_adap.Fill(Me.MydbDataSet.equipements)
        'equip1.DataSource = MydbDataSet
        'equip2.DataSource = MydbDataSet
        'equip1.DataMember = "equipements"
        'equip2.DataMember = "equipements"
        salle_cont1_adap.Fill(Me.MydbDataSet.salles)
        salle_cont2_adap.Fill(Me.MydbDataSet.salles)
        troncons_cont3_adap.Fill(Me.MydbDataSet.troncons)
        troncons_cont4_adap.Fill(Me.MydbDataSet.troncons)

        salle_cont1.DataSource = MydbDataSet
        salle_cont1.DataMember = "salles"

        salle_cont2.DataSource = MydbDataSet
        salle_cont2.DataMember = "salles"

        troncons_cont3.DataSource = MydbDataSet
        troncons_cont3.DataMember = "troncons"
        troncons_cont4.DataSource = MydbDataSet
        troncons_cont4.DataMember = "troncons"

        ComboBoxEx1.DataSource = salle_cont1
        ComboBoxEx2.DataSource = salle_cont2
        ComboBoxEx1.DisplayMember = "repere salle"
        ComboBoxEx2.DisplayMember = "repere salle"
        ComboBoxEx1.ValueMember = "idsalle"
        ComboBoxEx2.ValueMember = "idsalle"

        ComboBoxEx3.DataSource = troncons_cont3
        ComboBoxEx4.DataSource = troncons_cont4
        ComboBoxEx3.DisplayMember = "repere troncon"
        ComboBoxEx4.DisplayMember = "repere troncon"
        ComboBoxEx3.ValueMember = "idtroncons"
        ComboBoxEx4.ValueMember = "idtroncons"

        'Repere_equipementComboBox.DataSource = equip1
        'ComboBox7.DataSource = equip2
        'Repere_equipementComboBox.DisplayMember = "repere equipement"
        'ComboBox7.DisplayMember = "idequipement"
        'Repere_equipementComboBox.ValueMember = "repere equipement"
        'ComboBox7.ValueMember = "idequipement"

        Me.ButtonXEnregistrer.Enabled = False

        Select Case action
            Case "new"
                Me.CablesBindingSource.AddNew()
                Me.ButtonXEnregistrer.Enabled = True
                Me.ButtonXNouveau.Enabled = False
                Me.Button1.Enabled = False
        End Select
        If mode = True Then
            Me.CablesBindingSource.AddNew()
            Me.ButtonXEnregistrer.Enabled = True
            Me.ButtonXNouveau.Enabled = False
            Me.Button1.Enabled = False
            Me.CheckBox2.Enabled = False
            Me.ComboBox9.Enabled = False
            Me.TextBox17.Enabled = False
        Else

            Try
                Me.CablesBindingSource.Position = Me.CablesBindingSource.Find("idcable", value)

                Dim rows As DataRowView
                Dim rows22 As mydbDataSet.cablesRow
                rows = CType(Me.CablesBindingSource.Item(Me.CablesBindingSource.Position), DataRowView)
                rows22 = CType(CType(Me.CablesBindingSource.Item(Me.CablesBindingSource.Position), DataRowView).Row, mydbDataSet.cablesRow)
                Me.Text = "Cable : " & rows22.repere_cable
                Dim detail As mydbDataSet.cablesRow
                detail = CType(CType(Me.CablesBindingSource.Current, DataRowView).Row, mydbDataSet.cablesRow)
                'maj combo depart
                Me.Lst_departs_onTableAdapter.Fill(Me.MydbDataSet.lst_departs_on, CType(rows22.idequipement, Integer?))
                Me.Departs_iddepartsComboBox.DataSource = Me.Lst_departs_onBindingSource
                Me.Departs_iddepartsComboBox.SelectedValue = rows22.departs_iddeparts
                'maj combo bornier
                Me.Lst_Borniers_onTableAdapter.Fill(Me.MydbDataSet.lst_borniers_on, CType(rows22.idequipement2, Integer?))
                Me.Borniers_idbornierComboBox.DataSource = Me.Lst_Borniers_onBindingSource
                Me.Borniers_idbornierComboBox.SelectedValue = rows22.borniers_idbornier

                Me.Cable_details_sectionTableAdapter.Fill(Me.MydbDataSet.cable_details_section, CType(value, Integer?))
                Me.Cables_detailsTableAdapter.Fill(Me.MydbDataSet.cables_details)
                Me.Cables_detailsBindingSource.ResetBindings(False)
                Try
                    Me.Cables_detailsBindingSource.Position = Me.Cables_detailsBindingSource.Find("idcables_details", CType(CType(Me.Cable_details_sectionBindingSource.Current, DataRowView).Row, mydbDataSet.cable_details_sectionRow).idcables_details)
                Catch ex As Exception

                End Try

                'Dim rowsCables As mydbDataSet.cablesRow
                'rowsCables = CType(CType(Me.CablesBindingSource.Current, DataRowView).Row, mydbDataSet.cablesRow)
                'Me.EquipementsBindingSource.Position = Me.EquipementsBindingSource.Find("idequipement", rowsCables.idequipement)
                'Me.Repere_equipementComboBox.SelectedValue = DirectCast(DirectCast(Me.EquipementAboutissantBindingSource.Current, System.Data.DataRowView).Row, progelec.mydbDataSet.equipementsRow).idequipement
                'Me.EquipementAboutissantBindingSource.Position = Me.EquipementAboutissantBindingSource.Find("idequipement", rowsCables.idequipement2)
                'Dim place As mydbDataSet.cablesRow
                'place = CType(CType(Me.CablesBindingSource.Current, DataRowView).Row, mydbDataSet.cablesRow)
                'If IsDBNull(place.Cont3Val) Then
                '    Me.ComboBoxEx1.Text = ""
                'Else
                '    Me.ComboBoxEx1.SelectedValue = place.Cont3Val
                'End If
                'If IsDBNull(place.Cont4Val) Then
                '    Me.ComboBoxEx2.Text = ""
                'Else
                '    Me.ComboBoxEx2.SelectedValue = place.Cont4Val
                'End If
                'If IsDBNull(place.Cont5Val) Then
                '    Me.ComboBoxEx3.Text = ""
                'Else
                '    Me.ComboBoxEx3.SelectedValue = place.Cont5Val
                'End If
                'If IsDBNull(place.Cont6Val) Then
                '    Me.ComboBoxEx4.Text = ""
                'Else
                '    Me.ComboBoxEx4.SelectedValue = place.Cont6Val
                'End If

                If Not IsNothing(detail.parcours_idparcours) Then
                    Me.TextBox11.Text = CStr(detail.parcours_idparcours)
                    Me.Parcour_detail_idTableAdapter.Fill(Me.MydbDataSet.parcour_detail_id, CType(detail.parcours_idparcours, Integer?))
                    Me.Parcour_detail_idBindingSource.ResetBindings(False)
                End If
                'Me.Departs_iddepartsComboBox.SelectedValue = rows22.departs_iddeparts
                Me.ButtonXEnregistrer.Enabled = True
            Catch ex As System.Exception
                System.Windows.Forms.MessageBox.Show(ex.Message)
            End Try

        End If
        ' and add to DataTable.
        column = New DataColumn()
        column.DataType = System.Type.GetType("System.Int32")
        column.ColumnName = "id"
        column.ReadOnly = True
        column.Unique = True

        ' Add the Column to the DataColumnCollection.
        lt.Columns.Add(column)

        ' Create second column.
        column = New DataColumn()
        column.DataType = System.Type.GetType("System.String")
        column.ColumnName = "troncon"
        column.AutoIncrement = False
        column.Caption = "troncon"
        column.ReadOnly = False
        column.Unique = False

        ' Add the column to the table.
        lt.Columns.Add(column)

        ' Make the ID column the primary key column.
        Dim PrimaryKeyColumns(0) As DataColumn
        PrimaryKeyColumns(0) = lt.Columns("id")
        lt.PrimaryKey = PrimaryKeyColumns

        ' Instantiate the DataSet variable.
        dataSet = New DataSet()

        ' Add the new DataTable to the DataSet.
        dataSet.Tables.Add(lt)

        ' Create new DataColumn, set DataType, ColumnName
        ' and add to DataTable.
        column = New DataColumn()
        column.DataType = System.Type.GetType("System.Int32")
        column.ColumnName = "id"
        column.ReadOnly = True
        column.Unique = True

        ' Add the Column to the DataColumnCollection.
        lt2.Columns.Add(column)

        ' Create second column.
        column = New DataColumn()
        column.DataType = System.Type.GetType("System.Int32")
        column.ColumnName = "id_troncon"
        column.AutoIncrement = False
        column.Caption = "troncon"
        column.ReadOnly = False
        column.Unique = False

        ' Add the column to the table.
        lt2.Columns.Add(column)

        ' Create second column.
        column = New DataColumn()
        column.DataType = System.Type.GetType("System.Int32")
        column.ColumnName = "id_troncon2"
        column.AutoIncrement = False
        column.Caption = "troncon tenant"
        column.ReadOnly = False
        column.Unique = False

        ' Add the column to the table.
        lt2.Columns.Add(column)

        ' Create second column.
        column = New DataColumn()
        column.DataType = System.Type.GetType("System.Int32")
        column.ColumnName = "longueur"
        column.AutoIncrement = False
        column.Caption = "longueur"
        column.ReadOnly = False
        column.Unique = False

        ' Add the column to the table.
        lt2.Columns.Add(column)

        column = New DataColumn()
        column.DataType = System.Type.GetType("System.Int32")
        column.ColumnName = "pose"
        column.AutoIncrement = False
        column.Caption = "pose"
        column.ReadOnly = False
        column.Unique = False

        ' Add the column to the table.
        lt2.Columns.Add(column)
        ' Make the ID column the primary key column.

        PrimaryKeyColumns(0) = lt2.Columns("id")
        lt2.PrimaryKey = PrimaryKeyColumns
        dataSet.Tables.Add(lt2)

        '  Me.ComboBox.Enabled = False
        '  Me.ComboBox2.Enabled = False
        '  Me.ComboBox3.Enabled = False
        ' Me.ComboBox5.Enabled = False
        '   Me.ComboBox3.Text = ""
        param1 = CInt("0")

        column = New DataColumn()
        column.DataType = System.Type.GetType("System.Int32")
        column.ColumnName = "id"
        column.AutoIncrement = True
        column.Caption = "id"
        column.ReadOnly = False
        column.Unique = True

        lst_action.Columns.Add(column)
        column = New DataColumn()
        column.DataType = System.Type.GetType("System.String")
        column.ColumnName = "qui"
        column.Caption = "qui"
        lst_action.Columns.Add(column)
        column = New DataColumn()
        column.DataType = System.Type.GetType("System.String")
        column.ColumnName = "quoi"
        column.Caption = "quoi"
        lst_action.Columns.Add(column)
        column = New DataColumn()
        column.DataType = System.Type.GetType("System.String")
        column.ColumnName = "type"
        column.Caption = "type"
        lst_action.Columns.Add(column)
        column = New DataColumn()
        column.DataType = System.Type.GetType("System.String")
        column.ColumnName = "table"
        column.Caption = "table"
        lst_action.Columns.Add(column)
        column = New DataColumn()
        column.DataType = System.Type.GetType("System.String")
        column.ColumnName = "identifiant"
        column.Caption = "identifiant"
        lst_action.Columns.Add(column)
        column = New DataColumn()
        column.DataType = System.Type.GetType("System.String")
        column.ColumnName = "champ"
        column.Caption = "champ"
        lst_action.Columns.Add(column)
        PrimaryKeyColumns(0) = lst_action.Columns("id")
        lst_action.PrimaryKey = PrimaryKeyColumns
        dataSet.Tables.Add(lst_action)
        cables_row = CType(CType(Me.CablesBindingSource.Current, DataRowView).Row, mydbDataSet.cablesRow)
        'Me.Lst_departs_onBindingSource.Position = Me.Lst_departs_onBindingSource.Find("iddepart", cables_row.departs_iddeparts)

        AddHandler ComboBox.SelectedIndexChanged, AddressOf ComboBox_SelectedIndexChanged
        AddHandler Repere_equipementComboBox.SelectedValueChanged, AddressOf Repere_equipementComboBox_SelectedValueChanged
        AddHandler ComboBox7.SelectedValueChanged, AddressOf ComboBox7_SelectedValueChanged
        AddHandler ComboBox9.SelectedIndexChanged, AddressOf ComboBox9_SelectedIndexChanged
        If Not mode Then
            Me.Departs_iddepartsComboBox.SelectedValue = cables_row.departs_iddeparts
        End If
        Try
            Me.Lst_cable_mise_touretBindingSource.Filter = "idcable='" & value & "' and Touret_def<>''"
        Catch ex As Exception

        End Try

    End Sub

    Private Sub CablesBindingNavigatorSaveItem_Click_1(sender As System.Object, e As System.EventArgs)
        Me.Validate()
        If Me.SuperValidator1.Validate() = False Then
            Exit Sub
        End If

        Me.CablesBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.MydbDataSet)
        Me.Cables_detailsBindingSource.EndEdit()
        Me.Cables_detailsTableAdapter.Update(Me.MydbDataSet)
        Me.CablesTableAdapter.Update(Me.MydbDataSet)

    End Sub

    Private Sub btnNouveauCable_Click(sender As System.Object, e As System.EventArgs)
        Me.Validate()
        If Me.SuperValidator1.Validate() = False Then
            Exit Sub
        End If
        Dim temp As String = Repere_cableTextBox.Text
        Me.CablesBindingSource.EndEdit()
        Me.CablesTableAdapter.Update(Me.MydbDataSet)
        If Me.IdcableTextBox.Text <> "-1" Then
            Me.Cables_detailsBindingSource.EndEdit()
            Me.Cables_detailsTableAdapter.Update(Me.MydbDataSet)
            Me.Cables_detailsTableAdapter.Fill(Me.MydbDataSet.cables_details)
            Me.Cables_detailsBindingSource.ResetBindings(False)
        End If
        Me.CablesTableAdapter.Fill(Me.MydbDataSet.cables)
        Me.CablesBindingSource.ResetBindings(False)
        Dim itemcable As Integer = Me.CablesBindingSource.Find("repere cable", temp)

        Me.CablesBindingSource.Position = itemcable
        Me.Cables_detailsBindingSource.AddNew()
        Me.TextBox18.Text = Me.IdcableTextBox.Text
        Me.ButtonXEnregistrer.Enabled = True
        Me.Button1.Enabled = False
        Me.Cable_details_sectionTableAdapter.Fill(Me.MydbDataSet.cable_details_section, CType(Me.IdcableTextBox.Text, Integer?))

        Me.Cables_detailsBindingSource.ResetBindings(False)

    End Sub

    Private Sub Repere_equipementComboBox_SelectedValueChanged(sender As System.Object, e As System.EventArgs) Handles Repere_equipementComboBox.SelectedValueChanged

        If Repere_equipementComboBox.SelectedValue Is Nothing Then
            Exit Sub
        Else
            Me.Lst_departs_onTableAdapter.Fill(Me.MydbDataSet.lst_departs_on, CInt(Me.Repere_equipementComboBox.SelectedValue.ToString))
            Me.Departs_iddepartsComboBox.DataSource = Me.Lst_departs_onBindingSource

            'Me.Departs_iddepartsComboBox.SelectedValue = CType(CType(Me.CablesBindingSource.Current, DataRowView).Row, mydbDataSet.cablesRow).departs_iddeparts

        End If
    End Sub

    Private Sub ComboBox7_SelectedValueChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox7.SelectedValueChanged
        If ComboBox7.SelectedValue Is Nothing Then
            Exit Sub
        Else
            Me.Lst_Borniers_onTableAdapter.Fill(Me.MydbDataSet.lst_borniers_on, CInt(Me.ComboBox7.SelectedValue.ToString))
            Me.Borniers_idbornierComboBox.DataSource = Me.Lst_Borniers_onBindingSource
        End If
    End Sub

    Private Sub ButtonXEnregistrer_Click(sender As System.Object, e As System.EventArgs) Handles ButtonXEnregistrer.Click
        Me.Validate()
        If Me.SuperValidator1.Validate() = False Then
            Exit Sub
        End If
        RemoveHandler ComboBox.SelectedIndexChanged, AddressOf ComboBox_SelectedIndexChanged
        RemoveHandler Repere_equipementComboBox.SelectedValueChanged, AddressOf Repere_equipementComboBox_SelectedValueChanged
        RemoveHandler ComboBox7.SelectedValueChanged, AddressOf ComboBox7_SelectedValueChanged
        Dim row3 As mydbDataSet.cablesRow

        row3 = CType(CType(Me.CablesBindingSource.Current, DataRowView).Row, mydbDataSet.cablesRow)
        Dim t As String = row3.repere_cable
        row3.departs_iddeparts = CInt(Me.Departs_iddepartsComboBox.SelectedValue)
        If row3.idcable = -1 Then
            row3.parcours_idparcours = 0
        End If

        If RadioButton4.Checked = True Then
            row3.mode_de_pose = False
            row3.mode_de_pose2 = False
            row3.mode_de_pose3 = True

        ElseIf RadioButton5.Checked = True Then
            row3.mode_de_pose = False
            row3.mode_de_pose2 = False
            row3.mode_de_pose3 = True

        ElseIf RadioButton6.Checked = True Then
            row3.mode_de_pose = True
            row3.mode_de_pose2 = False
            row3.mode_de_pose3 = False

        End If

        'row3.AcceptChanges()
        'row3.EndEdit()
        Me.CablesBindingSource.EndEdit()

        Me.CablesTableAdapter.Update(Me.MydbDataSet.cables)
        Me.Cables_detailsBindingSource.EndEdit()
        Me.Cables_detailsTableAdapter.Update(Me.MydbDataSet.cables_details)

        Me.Button1.Enabled = True
        Me.ButtonXEnregistrer.Enabled = False

        'Dim r As DataRow
        'For Each r In lst_action.Rows

        '    action_creation(CStr(r("qui")), CStr(r("quoi")), "cables", CInt(r("type")), CInt(r("identifiant")))

        'Next
        Me.CablesTableAdapter.Fill(Me.MydbDataSet.cables)
        Me.CablesBindingSource.Position = Me.CablesBindingSource.Find("repere cable", t)
        AddHandler ComboBox.SelectedIndexChanged, AddressOf ComboBox_SelectedIndexChanged
        AddHandler Repere_equipementComboBox.SelectedValueChanged, AddressOf Repere_equipementComboBox_SelectedValueChanged
        AddHandler ComboBox7.SelectedValueChanged, AddressOf ComboBox7_SelectedValueChanged

    End Sub

    Private Sub ButtonXNouveau_Click(sender As System.Object, e As System.EventArgs) Handles ButtonXNouveau.Click
        Me.CablesBindingSource.AddNew()
        Me.ButtonXEnregistrer.Enabled = True
        Me.ButtonXNouveau.Enabled = False
    End Sub

    Private Sub IdcableTextBox_TextChanged(sender As System.Object, e As System.EventArgs) Handles IdcableTextBox.TextChanged

        Me.Cable_details_sectionTableAdapter.Fill(Me.MydbDataSet.cable_details_section, CType(Me.IdcableTextBox.Text, Integer?))

        Me.Cables_detailsBindingSource.ResetBindings(False)

    End Sub

    Private Sub ButtonX1_Click(sender As System.Object, e As System.EventArgs)
        Select Case MessageBox.Show("Vous allez creer un parcour entre et .Etes vous sur ?", "Creation d'un parcour", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            Case System.Windows.Forms.DialogResult.Yes
                'verification de la selection
                st = CInt(Me.TextBox9.Text)
                fn = CInt(Me.TextBox10.Text)

                If st = 0 Then

                    MessageBox.Show("Aucun parcours possible" _
            & Microsoft.VisualBasic.ControlChars.CrLf & "" _
            & Microsoft.VisualBasic.ControlChars.CrLf & "Veuillez selectionner Le tronçon tenant .", "Impossible", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    Exit Sub
                End If

                If fn = 0 Then

                    MessageBox.Show("Aucun parcours possible" _
            & Microsoft.VisualBasic.ControlChars.CrLf & "" _
            & Microsoft.VisualBasic.ControlChars.CrLf & "Veuillez selectionner le tronçon aboutissant .", "Impossible", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    Exit Sub
                End If

                'creation de la liste des troncons et de l'arbre unique

                'selection des associations unique pour l'arbre

                lt.Clear()
                lt2.Clear()
                Dim item As DataRow

                i = 0
                a = 1
                row = lt.NewRow()
                row("id") = st
                row("troncon") = Me.ComboBox2.Text
                lt.Rows.Add(row)

                Do While a > 0
                    'pour chaque trc dans troncons_assoc = st
                    Me.Lst_assoc_par_trcTableAdapter.Fill(Me.MydbDataSet.lst_assoc_par_trc, CType(lt.Rows(i).Item(0), Integer?), st, fn)

                    For Each item In Me.MydbDataSet.lst_assoc_par_trc
                        If item(6).ToString = Me.ComboBox.SelectedValue.ToString Or item(6).ToString = "0" Then

                            If 0 = dataSet.Tables("troncons_tri").Select("ID = '" & item(0).ToString & "'").Count() Then
                                row = lt2.NewRow()
                                row("id") = item(0).ToString
                                row("id_troncon") = item(1).ToString
                                row("id_troncon2") = item(2).ToString
                                row("longueur") = CType(item(8).ToString, Double?)
                                lt2.Rows.Add(row)
                                If 0 = dataSet.Tables("troncons_seg2").Select("ID = '" & item(2).ToString & "'").Count() Then
                                    row = lt.NewRow()
                                    row("id") = item(2).ToString
                                    row("troncon") = item(4).ToString
                                    lt.Rows.Add(row)
                                    a = a + 1
                                End If

                            End If

                        End If

                    Next

                    Me.Lst_assoc_par_trc2TableAdapter.Fill(Me.MydbDataSet.lst_assoc_par_trc2, CType(lt.Rows(i).Item(0), Integer?), st, fn)

                    For Each item In Me.MydbDataSet.lst_assoc_par_trc2
                        If item(6).ToString = Me.ComboBox.SelectedValue.ToString Or item(6).ToString = "0" Then

                            If dataSet.Tables("troncons_tri").Select("ID = '" & item(0).ToString & "'").Count() = 0 Then
                                row = lt2.NewRow()
                                row("id") = item(0).ToString
                                row("id_troncon") = item(1).ToString
                                row("id_troncon2") = item(2).ToString
                                row("longueur") = item(8).ToString
                                lt2.Rows.Add(row)
                                If 0 = dataSet.Tables("troncons_seg2").Select("ID = '" & item(1).ToString & "'").Count() Then
                                    row = lt.NewRow()
                                    row("id") = item(1).ToString
                                    row("troncon") = item(4).ToString
                                    lt.Rows.Add(row)
                                    a = a + 1
                                End If

                            End If
                        End If
                    Next

                    i = i + 1
                    a = a - 1
                Loop

                If 0 = dataSet.Tables("troncons_seg2").Select("ID = '" & fn & "'").Count() Then

                    MessageBox.Show("Aucun parcours ne mene au tronçon demandé" _
                        & Microsoft.VisualBasic.ControlChars.CrLf & "" _
                        & Microsoft.VisualBasic.ControlChars.CrLf & "Veuillez choisir un autre tronçon ou creer un pont .", "Impossible", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    Exit Sub
                End If

                Me.graph = New Graph

                '//reset graph
                Me.graph.Reset()

                For Each item In lt.Rows

                    Dim te As Integer = CInt(item(0).ToString)
                    Me.graph.AddVertex(te.ToString)
                Next

                For Each item In lt2.Rows

                    Me.graph.AddEdge(item(2).ToString, item(1).ToString, CDbl(item(3).ToString))

                Next

                'Me.graph.Save("graph2")

                Dim starting = Me.graph.Verticies(st.ToString)
                Dim ending = Me.graph.Verticies(fn.ToString)

                Me.ShowResults(starting, ending)

            Case System.Windows.Forms.DialogResult.No

        End Select
    End Sub

    Private Sub ShowResults(ByVal start As Vertex, _
                ByVal [end] As Vertex)

        Dim distance = graph.GetDistance(start, [end])
        Dim path = graph.GetPath(start, [end], False)

        '//show basic results
        MessageBox.Show(String.Format("De {0} à {1}{3}{3}Parcour : {2}{3}{3}Distance: {4}", _
                                      start.Key, [end].Key, path, Environment.NewLine, distance), _
                        "Dijkstra's", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Select Case MessageBox.Show("Voullez vous enregistrer le parcour.Etes vous sur ?", "enregistrement d'un parcour", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            Case System.Windows.Forms.DialogResult.Yes
                ' Me.ParcoursBindingSource.AddNew()
                Dim ref_parcours As String
                Dim prow As DataRow
                Dim drow As DataRow
                Dim dow As Date

                prow = Me.MydbDataSet.parcours.NewRow
                dow = Today
                'ref_parcours = CStr(Year(Today))
                ref_parcours = CStr(Month(Today))
                ref_parcours = ref_parcours & dow.Day()
                ref_parcours = ref_parcours & Hour(Now)
                ref_parcours = ref_parcours & Minute(Now)

                prow.Item(1) = st
                prow.Item(2) = fn
                prow.Item(3) = Today
                prow.Item(4) = "test"
                prow.Item(6) = ref_parcours
                prow.Item(7) = distance
                Me.MydbDataSet.parcours.Rows.Add(prow)
                Me.ParcoursBindingSource.EndEdit()
                Me.ParcoursTableAdapter.Update(MydbDataSet)
                Me.ParcoursTableAdapter.Fill(Me.MydbDataSet.parcours)
                Me.ParcoursBindingSource.ResetBindings(False)
                Me.ParcoursBindingSource.Sort = "ref_parcour"
                Dim place As Integer = Me.ParcoursBindingSource.Find("ref_parcour", ref_parcours)
                Me.ParcoursBindingSource.Position = place

                ' Me.Parcours_detailBindingSource.AddNew()
                Dim strArr() As String
                Dim count As Integer
                path = path.Replace(">", "")
                path = path.Replace(" ", "")
                strArr = path.Split(CChar("-"))

                Dim rows As DataRowView
                rows = CType(Me.ParcoursBindingSource.Item(place), DataRowView)
                For count = 0 To strArr.Length - 1
                    '  MsgBox(strArr(count))
                    drow = MydbDataSet.parcours_detail.NewRow
                    drow.Item("parcours_idparcours") = rows(0).ToString
                    drow.Item("ordre") = count + 1
                    drow.Item("troncon") = strArr(count)
                    MydbDataSet.parcours_detail.Rows.Add(drow)
                Next

                Me.Parcours_detailBindingSource.EndEdit()
                Me.Parcours_detailTableAdapter.Update(MydbDataSet)
                Me.Parcours_detailTableAdapter.Fill(Me.MydbDataSet.parcours_detail)
                Me.TextBox11.Text = rows(0).ToString
            Case (System.Windows.Forms.DialogResult.No)

        End Select

    End Sub
    Dim modepose As Boolean = False
    Dim segregation As Boolean = False
    Dim arbre_unique As Boolean = False
    Dim tenant As Boolean = False
    Dim about As Boolean = False
    Dim tenant_seg As Boolean = False
    Dim about_seg As Boolean = False
    Dim tenant_assoc As Boolean = False
    Dim idsegregation As Integer
    Dim trc_dep As String
    Public Sub annalyse_parcours()
        modepose = False
        segregation = False
        arbre_unique = False
        tenant = False
        about = False
        tenant_seg = False
        about_seg = False
        tenant_assoc = False
        Dim rd As mydbDataSet.lst_departs_onRow

        rd = CType(CType(Me.Lst_departs_onBindingSource.Current, DataRowView).Row, mydbDataSet.lst_departs_onRow)
        Dim rb As mydbDataSet.lst_borniers_onRow

        rb = CType(CType(Me.Lst_Borniers_onBindingSource.Current, DataRowView).Row, mydbDataSet.lst_borniers_onRow)
        'verification de la selection
        st = CInt(rd.troncons_idtroncons)
        fn = CInt(rb.troncons_idtroncons)

        If st = 0 Then

            '        MessageBox.Show("Aucun parcours possible" _
            '& Microsoft.VisualBasic.ControlChars.CrLf & "" _
            '& Microsoft.VisualBasic.ControlChars.CrLf & "Veuillez selectionner Le tronçon tenant .", "Impossible", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Exit Sub
        End If

        If fn = 0 Then

            '        MessageBox.Show("Aucun parcours possible" _
            '& Microsoft.VisualBasic.ControlChars.CrLf & "" _
            '& Microsoft.VisualBasic.ControlChars.CrLf & "Veuillez selectionner le tronçon aboutissant .", "Impossible", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Exit Sub
        End If

        'creation de la liste des troncons et de l'arbre unique

        'selection des associations unique pour l'arbre

        lt.Clear()
        lt2.Clear()
        Dim item As DataRow

        i = 0
        a = 1
        row = lt.NewRow()
        row("id") = st
        row("troncon") = trc_dep
        lt.Rows.Add(row)

        Do While a > 0
            'pour chaque trc dans troncons_assoc = st
            Me.Lst_assoc_par_trcTableAdapter.Fill(Me.MydbDataSet.lst_assoc_par_trc, CType(lt.Rows(i).Item(0), Integer?), st, fn)

            For Each item In Me.MydbDataSet.lst_assoc_par_trc
                'test segregation et TV
                '  If item(6).ToString = Me.ComboBox.SelectedValue.ToString Or item(6).ToString = "0" Then

                If 0 = dataSet.Tables("troncons_tri").Select("ID = '" & item(0).ToString & "'").Count() Then
                    row = lt2.NewRow()
                    row("id") = item(0).ToString
                    row("id_troncon") = item(1).ToString
                    row("id_troncon2") = item(2).ToString
                    row("longueur") = CType(item(8).ToString, Double?)
                    If item(27).ToString = "True" Then
                        row("pose") = 1
                    End If
                    If item(28).ToString = "True" Then
                        row("pose") = 2
                    End If
                    If item(29).ToString = "True" Then
                        row("pose") = 3
                    End If
                    ' row("pose") = item(27).ToString()
                    lt2.Rows.Add(row)
                    If 0 = dataSet.Tables("troncons_seg2").Select("ID = '" & item(2).ToString & "'").Count() Then
                        row = lt.NewRow()
                        row("id") = item(2).ToString
                        row("troncon") = item(4).ToString
                        lt.Rows.Add(row)
                        a = a + 1
                    End If

                End If

                '  End If

            Next

            Me.Lst_assoc_par_trc2TableAdapter.Fill(Me.MydbDataSet.lst_assoc_par_trc2, CType(lt.Rows(i).Item(0), Integer?), st, fn)

            For Each item In Me.MydbDataSet.lst_assoc_par_trc2
                '  If item(6).ToString = Me.ComboBox.SelectedValue.ToString Or item(6).ToString = "0" Then

                If dataSet.Tables("troncons_tri").Select("ID = '" & item(0).ToString & "'").Count() = 0 Then
                    row = lt2.NewRow()
                    row("id") = item(0).ToString
                    row("id_troncon") = item(1).ToString
                    row("id_troncon2") = item(2).ToString
                    row("longueur") = item(8).ToString
                    If item(27).ToString = "True" Then
                        row("pose") = 1
                    End If
                    If item(28).ToString = "True" Then
                        row("pose") = 2
                    End If
                    If item(29).ToString = "True" Then
                        row("pose") = 3
                    End If
                    ' row("pose") = item(27).ToString()
                    lt2.Rows.Add(row)
                    If 0 = dataSet.Tables("troncons_seg2").Select("ID = '" & item(1).ToString & "'").Count() Then
                        row = lt.NewRow()
                        row("id") = item(1).ToString
                        row("troncon") = item(4).ToString
                        lt.Rows.Add(row)
                        a = a + 1
                    End If

                End If
                ' End If
            Next

            i = i + 1
            a = a - 1


        Loop

        If 0 = dataSet.Tables("troncons_seg2").Select("ID = '" & fn & "'").Count() Then

            'MessageBox.Show("Aucun parcours ne mene au tronçon demandé" _
            '    & Microsoft.VisualBasic.ControlChars.CrLf & "" _
            '    & Microsoft.VisualBasic.ControlChars.CrLf & "Veuillez verifier les segregations ou creer un pont .", "Impossible", MessageBoxButtons.OK, MessageBoxIcon.Error)
            about = True
            'Exit Sub
        End If
        If 0 = dataSet.Tables("troncons_seg2").Select("ID = '" & st & "'").Count() Then

            'MessageBox.Show("Aucun parcours ne mene au tronçon demandé" _
            '    & Microsoft.VisualBasic.ControlChars.CrLf & "" _
            '    & Microsoft.VisualBasic.ControlChars.CrLf & "Veuillez verifier les segregations ou creer un pont .", "Impossible", MessageBoxButtons.OK, MessageBoxIcon.Error)
            tenant = True
            ' Exit Sub
        End If
        'For Each item In lt.Rows
        If lt2.Rows.Count = 0 Then
            tenant_assoc = False
        Else
            tenant_assoc = True
        End If

        If tenant Or about Then Exit Sub
        'Next
        Me.graph = New Graph

        '//reset graph
        'Me.graph.Reset()

        'For Each item In lt.Rows

        '    Dim te As Integer = CInt(item(0).ToString)
        '    Me.graph.AddVertex(te.ToString)
        'Next

        'For Each item In lt2.Rows

        '    Me.graph.AddEdge(item(2).ToString, item(1).ToString, CDbl(item(3).ToString))

        'Next

        ''Me.graph.Save("graph2")

        'Dim starting = Me.graph.Verticies(st.ToString)
        'Dim ending = Me.graph.Verticies(fn.ToString)

        'Me.ShowResults2(starting, ending)
        'Dim dr() As DataRow
        'Dim n As Integer = 0
        'Dim ltindex(lt.Rows.Count) As Integer

        '' filtre segregation
        'Dim ctrltrc As mydbDataSet.tronconsRow
        'For Each item In lt.Rows
        '    Me.TronconsBindingSource.Position = Me.TronconsBindingSource.Find("idtroncons", CInt(item(0).ToString))
        '    ctrltrc = CType(CType(Me.TronconsBindingSource.Current, DataRowView).Row, mydbDataSet.tronconsRow)
        '    If ctrltrc.segregations_idsegregations = 0 Or ctrltrc.segregations_idsegregations = idsegregation Then
        '    Else
        '        dr = lt2.Select("id_troncon = '" & CInt(item(0).ToString) & "'")
        '        For i As Integer = 0 To dr.Length - 1
        '            ' lt2.Rows.Remove(CType(dr(i), DataRow))
        '            ' lt2.AcceptChanges()
        '            dr(i).Delete()
        '        Next
        '        lt2.AcceptChanges()
        '        dr = lt2.Select("id_troncon2 = '" & CInt(item(0).ToString) & "'")
        '        For i As Integer = 0 To dr.Length - 1
        '            ' lt2.Rows.Remove(CType(dr(i), DataRow))
        '            ' lt2.AcceptChanges()
        '            dr(i).Delete()
        '        Next
        '        lt2.AcceptChanges()

        '        ltindex(n) = CInt(item(0).ToString)
        '        n = n + 1
        '    End If

        'Next
        'Dim iiii As Integer
        'For iiii = 0 To n - 1

        '    dr = lt.Select("id ='" & CInt(ltindex(iiii).ToString) & "'")
        '    dr(0).Delete()
        '    lt.AcceptChanges()
        'Next
        ''v2
        Do While a > 0
            'pour chaque trc dans troncons_assoc = st
            Me.Lst_assoc_par_trcTableAdapter.Fill(Me.MydbDataSet.lst_assoc_par_trc, CType(lt.Rows(i).Item(0), Integer?), st, fn)

            For Each item In Me.MydbDataSet.lst_assoc_par_trc
                'test segregation et TV
                '  If item(6).ToString = Me.ComboBox.SelectedValue.ToString Or item(6).ToString = "0" Then

                If 0 = dataSet.Tables("troncons_tri").Select("ID = '" & item(0).ToString & "'").Count() Then
                    row = lt2.NewRow()
                    row("id") = item(0).ToString
                    row("id_troncon") = item(1).ToString
                    row("id_troncon2") = item(2).ToString
                    row("longueur") = CType(item(8).ToString, Double?)
                    If item(27).ToString = "True" Then
                        row("pose") = 1
                    End If
                    If item(28).ToString = "True" Then
                        row("pose") = 2
                    End If
                    If item(29).ToString = "True" Then
                        row("pose") = 3
                    End If
                    ' row("pose") = item(27).ToString()
                    lt2.Rows.Add(row)
                    If 0 = dataSet.Tables("troncons_seg2").Select("ID = '" & item(2).ToString & "'").Count() Then
                        row = lt.NewRow()
                        row("id") = item(2).ToString
                        row("troncon") = item(4).ToString
                        lt.Rows.Add(row)
                        a = a + 1
                    End If

                End If

                '  End If

            Next

            Me.Lst_assoc_par_trc2TableAdapter.Fill(Me.MydbDataSet.lst_assoc_par_trc2, CType(lt.Rows(i).Item(0), Integer?), st, fn)

            For Each item In Me.MydbDataSet.lst_assoc_par_trc2
                If item(6).ToString = Me.ComboBox.SelectedValue.ToString Or item(6).ToString = "0" Then

                    If dataSet.Tables("troncons_tri").Select("ID = '" & item(0).ToString & "'").Count() = 0 Then
                        row = lt2.NewRow()
                        row("id") = item(0).ToString
                        row("id_troncon") = item(1).ToString
                        row("id_troncon2") = item(2).ToString
                        row("longueur") = item(8).ToString
                        If item(27).ToString = "True" Then
                            row("pose") = 1
                        End If
                        If item(28).ToString = "True" Then
                            row("pose") = 2
                        End If
                        If item(29).ToString = "True" Then
                            row("pose") = 3
                        End If
                        ' row("pose") = item(27).ToString()
                        lt2.Rows.Add(row)
                        If 0 = dataSet.Tables("troncons_seg2").Select("ID = '" & item(1).ToString & "'").Count() Then
                            row = lt.NewRow()
                            row("id") = item(1).ToString
                            row("troncon") = item(4).ToString
                            lt.Rows.Add(row)
                            a = a + 1
                        End If

                    End If
                End If
            Next

            i = i + 1
            a = a - 1


        Loop

        If lt2.Select("id_troncon = '" & fn & "'").Count > 0 Then
            segregation = True
        Else

        End If
        If lt2.Select("id_troncon2 = '" & fn & "'").Count > 0 Then
            segregation = True
        Else

        End If

        'Me.graph.Reset()

        'For Each item In lt.Rows

        '    Dim te As Integer = CInt(item(0).ToString)
        '    Me.graph.AddVertex(te.ToString)
        'Next

        'For Each item In lt2.Rows

        '    Me.graph.AddEdge(item(2).ToString, item(1).ToString, CDbl(item(3).ToString))

        'Next

        ''Me.graph.Save("graph2")

        'starting = Me.graph.Verticies(st.ToString)
        'ending = Me.graph.Verticies(fn.ToString)

        'Me.ShowResults2(starting, ending)

        'filtre pode de pose
        'Dim ok As Boolean = False
        'n = 0
        'For Each item In lt.Rows
        '    Me.TronconsBindingSource.Position = Me.TronconsBindingSource.Find("idtroncons", CInt(item(0).ToString))
        '    ctrltrc = CType(CType(Me.TronconsBindingSource.Current, DataRowView).Row, mydbDataSet.tronconsRow)

        '    If Me.RadioButton6.Checked And ctrltrc.remplissage2 Then
        '        ok = True

        '    ElseIf Me.RadioButton6.Checked And ctrltrc.remplissage3 Then
        '        ok = True
        '    ElseIf Me.RadioButton4.Checked And ctrltrc.remplissage3 Then
        '        ok = True
        '    ElseIf Me.RadioButton4.Checked And ctrltrc.remplissage Then
        '        ok = True

        '    Else

        '    End If
        '    If Not ok Then
        '        dr = lt2.Select("id_troncon = '" & CInt(item(0).ToString) & "'")
        '        For i As Integer = 0 To dr.Length - 1
        '            lt2.Rows.Remove(CType(dr(i), DataRow))

        '        Next
        '        lt2.AcceptChanges()
        '        dr = lt2.Select("id_troncon2 = '" & CInt(item(0).ToString) & "'")
        '        For i As Integer = 0 To dr.Length - 1
        '            lt2.Rows.Remove(CType(dr(i), DataRow))

        '        Next
        '        lt2.AcceptChanges()

        '        '  item.Delete()
        '        ltindex(n) = CInt(item(0).ToString)
        '        n = n + 1

        '    End If
        '    ok = False


        '    'If ctrltrc.remplissage Or ctrltrc.segregations_idsegregations = CInt(ComboBox.SelectedValue) Then
        '    'Else
        '    '    dr = lt2.Select("id_troncons = '" & CInt(item(0).ToString) & "'")
        '    '    For i As Integer = 0 To dr.Length - 1
        '    '        lt2.Rows.Remove(CType(dr(0), DataRow))
        '    '    Next
        '    '    lt2.AcceptChanges()
        '    '    dr = lt2.Select("id_troncons2 = '" & CInt(item(0).ToString) & "'")
        '    '    For i As Integer = 0 To dr.Length - 1
        '    '        lt2.Rows.Remove(CType(dr(0), DataRow))
        '    '    Next

        '    '    lt2.AcceptChanges()
        '    '    item.Delete()

        '    'End If

        'Next
        'For iiii = 0 To n - 1

        '    dr = lt.Select("id ='" & CInt(ltindex(iiii).ToString) & "'")
        '    dr(0).Delete()
        '    lt.AcceptChanges()
        'Next

        'lt.AcceptChanges()

        'v2
        Do While a > 0
            'pour chaque trc dans troncons_assoc = st
            Me.Lst_assoc_par_trcTableAdapter.Fill(Me.MydbDataSet.lst_assoc_par_trc, CType(lt.Rows(i).Item(0), Integer?), st, fn)

            For Each item In Me.MydbDataSet.lst_assoc_par_trc
                'test segregation et TV
                If item(6).ToString = Me.ComboBox.SelectedValue.ToString Or item(6).ToString = "0" Then

                    If 0 = dataSet.Tables("troncons_tri").Select("ID = '" & item(0).ToString & "'").Count() Then
                        row = lt2.NewRow()
                        row("id") = item(0).ToString
                        row("id_troncon") = item(1).ToString
                        row("id_troncon2") = item(2).ToString
                        row("longueur") = CType(item(8).ToString, Double?)
                        If item(27).ToString = "True" Then
                            row("pose") = 1
                        End If
                        If item(28).ToString = "True" Then
                            row("pose") = 2
                        End If
                        If item(29).ToString = "True" Then
                            row("pose") = 3
                        End If
                        ' row("pose") = item(27).ToString()
                        lt2.Rows.Add(row)
                        If 0 = dataSet.Tables("troncons_seg2").Select("ID = '" & item(2).ToString & "'").Count() Then
                            row = lt.NewRow()
                            row("id") = item(2).ToString
                            row("troncon") = item(4).ToString
                            lt.Rows.Add(row)
                            a = a + 1
                        End If

                    End If

                End If

            Next

            Me.Lst_assoc_par_trc2TableAdapter.Fill(Me.MydbDataSet.lst_assoc_par_trc2, CType(lt.Rows(i).Item(0), Integer?), st, fn)

            For Each item In Me.MydbDataSet.lst_assoc_par_trc2
                If item(6).ToString = Me.ComboBox.SelectedValue.ToString Or item(6).ToString = "0" Then

                    If dataSet.Tables("troncons_tri").Select("ID = '" & item(0).ToString & "'").Count() = 0 Then
                        row = lt2.NewRow()
                        row("id") = item(0).ToString
                        row("id_troncon") = item(1).ToString
                        row("id_troncon2") = item(2).ToString
                        row("longueur") = item(8).ToString
                        If item(27).ToString = "True" Then
                            row("pose") = 1
                        End If
                        If item(28).ToString = "True" Then
                            row("pose") = 2
                        End If
                        If item(29).ToString = "True" Then
                            row("pose") = 3
                        End If
                        ' row("pose") = item(27).ToString()
                        lt2.Rows.Add(row)
                        If 0 = dataSet.Tables("troncons_seg2").Select("ID = '" & item(1).ToString & "'").Count() Then
                            row = lt.NewRow()
                            row("id") = item(1).ToString
                            row("troncon") = item(4).ToString
                            lt.Rows.Add(row)
                            a = a + 1
                        End If

                    End If
                End If
            Next

            i = i + 1
            a = a - 1


        Loop

        If lt2.Select("id_troncon = '" & fn & "'").Count > 0 Then
            modepose = True
        Else

        End If
        If lt2.Select("id_troncon2 = '" & fn & "'").Count > 0 Then
            modepose = True
        Else

        End If

        Me.graph.Reset()

        For Each item In lt.Rows

            Dim te As Integer = CInt(item(0).ToString)
            Me.graph.AddVertex(te.ToString)
        Next

        For Each item In lt2.Rows

            Me.graph.AddEdge(item(2).ToString, item(1).ToString, CDbl(item(3).ToString))

        Next

        'Me.graph.Save("graph2")

        Dim starting = Me.graph.Verticies(st.ToString)
        Dim ending = Me.graph.Verticies(fn.ToString)

        Me.ShowResults2(starting, ending)
    End Sub

    Private Sub ShowResults2(ByVal start As Vertex, _
              ByVal [end] As Vertex)

        Dim distance = graph.GetDistance(start, [end])
        Dim path = graph.GetPath(start, [end], False)

        arbre_unique = True
        '//show basic results
        'MessageBox.Show(String.Format("De {0} à {1}{3}{3}Parcour : {2}{3}{3}Distance: {4}", _
        '                              start.Key, [end].Key, path, Environment.NewLine, distance), _
        '                "Dijkstra's", MessageBoxButtons.OK, MessageBoxIcon.Information)

        'Select Case MessageBox.Show("Voullez vous enregistrer le parcour.Etes vous sur ?", "enregistrement d'un parcour", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        '    Case System.Windows.Forms.DialogResult.Yes
        '        ' Me.ParcoursBindingSource.AddNew()
        '        Dim ref_parcours As String
        '        Dim prow As DataRow
        '        Dim drow As DataRow
        '        Dim dow As Date

        '        prow = Me.MydbDataSet.parcours.NewRow
        '        dow = Today
        '        'ref_parcours = CStr(Year(Today))
        '        ref_parcours = CStr(Month(Today))
        '        ref_parcours = ref_parcours & dow.Day()
        '        ref_parcours = ref_parcours & Hour(Now)
        '        ref_parcours = ref_parcours & Minute(Now)

        '        prow.Item(1) = st
        '        prow.Item(2) = fn
        '        prow.Item(3) = Today
        '        prow.Item(4) = "test"
        '        prow.Item(6) = ref_parcours
        '        prow.Item(7) = distance
        '        Me.MydbDataSet.parcours.Rows.Add(prow)
        '        Me.ParcoursBindingSource.EndEdit()
        '        Me.ParcoursTableAdapter.Update(MydbDataSet)
        '        Me.ParcoursTableAdapter.Fill(Me.MydbDataSet.parcours)
        '        Me.ParcoursBindingSource.ResetBindings(False)
        '        Me.ParcoursBindingSource.Sort = "ref_parcour"
        '        Dim place As Integer = Me.ParcoursBindingSource.Find("ref_parcour", ref_parcours)
        '        Me.ParcoursBindingSource.Position = place

        '        ' Me.Parcours_detailBindingSource.AddNew()
        '        Dim strArr() As String
        '        Dim count As Integer
        '        path = path.Replace(">", "")
        '        path = path.Replace(" ", "")
        '        strArr = path.Split(CChar("-"))

        '        Dim rows As DataRowView
        '        rows = CType(Me.ParcoursBindingSource.Item(place), DataRowView)
        '        For count = 0 To strArr.Length - 1
        '            '  MsgBox(strArr(count))
        '            drow = MydbDataSet.parcours_detail.NewRow
        '            drow.Item("parcours_idparcours") = rows(0).ToString
        '            drow.Item("ordre") = count + 1
        '            drow.Item("troncon") = strArr(count)
        '            MydbDataSet.parcours_detail.Rows.Add(drow)
        '        Next

        '        Me.Parcours_detailBindingSource.EndEdit()
        '        Me.Parcours_detailTableAdapter.Update(MydbDataSet)
        '        Me.Parcours_detailTableAdapter.Fill(Me.MydbDataSet.parcours_detail)
        '        Me.TextBox11.Text = rows(0).ToString
        '    Case (System.Windows.Forms.DialogResult.No)

        'End Select
    End Sub


    Private Sub TextBox11_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox11.TextChanged
        If Me.TextBox11.Text <> "" Then
            Me.Parcour_detail_idTableAdapter.ClearBeforeFill = True
            Me.Parcour_detail_idTableAdapter.Fill(Me.MydbDataSet.parcour_detail_id, CType(Me.TextBox11.Text, Integer?))
            Me.Parcour_detail_idBindingSource.ResetBindings(False)
            Me.ParcoursBindingSource.Sort = "idparcours"
            Dim place As Integer = Me.ParcoursBindingSource.Find("idparcours", Me.TextBox11.Text)
            Me.ParcoursBindingSource.Position = place
        Else
            If Me.Parcour_detail_idBindingSource.Count > 0 Then
                Me.Parcour_detail_idTableAdapter.Fill(Me.MydbDataSet.parcour_detail_id, CType(0, Integer?))
                Me.Parcours_detailBindingSource.ResetBindings(True)

            End If

        End If

    End Sub

    Private Sub SuperTabItem2_Click_1(sender As System.Object, e As System.EventArgs) Handles SuperTabItem2.Click

        Dim detail As mydbDataSet.cablesRow
        detail = CType(CType(Me.CablesBindingSource.Current, DataRowView).Row, mydbDataSet.cablesRow)

        If Not IsDBNull(detail.parcours_idparcours) Then
            Me.TextBox11.Text = CStr(detail.parcours_idparcours)
            Me.Parcour_detail_idTableAdapter.Fill(Me.MydbDataSet.parcour_detail_id, CType(detail.parcours_idparcours, Integer?))
            Me.Parcour_detail_idBindingSource.ResetBindings(False)
        End If

        'If Me.TextBox11.Text <> "" Then
        '    Me.Parcour_detail_idTableAdapter.ClearBeforeFill = True
        '    Me.Parcour_detail_idTableAdapter.Fill(Me.MydbDataSet.parcour_detail_id, CType(Me.TextBox11.Text, Integer?))
        '    Me.Parcour_detail_idBindingSource.ResetBindings(False)
        'Else
        '    If Me.Parcour_detail_idBindingSource.Count > 0 Then
        '        Me.Parcour_detail_idTableAdapter.Fill(Me.MydbDataSet.parcour_detail_id, CType(0, Integer?))
        '        Me.Parcours_detailBindingSource.ResetBindings(True)
        '    End If

        'End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox2.CheckedChanged
        If Me.CheckBox2.Checked = True Then
            Me.RadioButton5.Checked = True
        Else
            Me.RadioButton6.Checked = True
        End If
    End Sub

    Private Sub ButtonX3_Click(sender As System.Object, e As System.EventArgs) Handles ButtonX3.Click

    End Sub



    Private Sub ButtonX1_Click_1(sender As System.Object, e As System.EventArgs) Handles ButtonX1.Click

        Select Case MessageBox.Show("Vous allez supprimer le parcour de ce câble etes vous sur ?", "Suppression de parcour", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            Case System.Windows.Forms.DialogResult.Yes
                Dim row As mydbDataSet.cablesRow
                row = CType(CType(Me.CablesBindingSource.Current, DataRowView).Row, mydbDataSet.cablesRow)
                row.parcours_idparcours = 0
                'Dim row2 As mydbDataSet.departsRow
                'row2 = CType(CType(Me.DepartsBindingSource.Current, DataRowView).Row, mydbDataSet.departsRow)
                ''Dim row3 As mydbDataSet.borniersRow
                ''row2 = CType(CType(Me.Current, DataRowView).Row, mydbDataSet.borniersRow)
                ''row.departs_iddeparts = row2.iddepart
                ''row.borniers_idbornier = CInt(Me.Borniers_idbornierComboBox.SelectedValue)
                'row.departs_iddeparts = row2.iddepart
                Me.CablesBindingSource.EndEdit()
                Me.DepartsBindingSource.EndEdit()
                Me.DepartsTableAdapter.Update(Me.MydbDataSet.departs)
                Me.CablesTableAdapter.Update(Me.MydbDataSet.cables)
            Case System.Windows.Forms.DialogResult.No

        End Select

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        'nouveau

        Me.Cables_detailsBindingSource.AddNew()

        Me.Button4.Enabled = False
        Me.Button3.Enabled = True
        Me.Button1.Enabled = False
        Me.CheckBox2.Enabled = True
        Me.ComboBox9.Enabled = True
        Me.TextBox17.Enabled = True
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        'enregistrement

        Dim rdetail As mydbDataSet.cables_detailsRow

        rdetail = CType(CType(Me.Cables_detailsBindingSource.Current, DataRowView).Row, mydbDataSet.cables_detailsRow)
        rdetail.cables_idcable = CType(CType(Me.CablesBindingSource.Current, DataRowView).Row, mydbDataSet.cablesRow).idcable
        rdetail.Fils = Me.TextBox17.Text
        rdetail.sections_cables_idsections_cables = CInt(Me.ComboBox9.SelectedValue)
        'rdetail.EndEdit()
        If Not CheckBox2.Checked Then
            rdetail.trefle = False
        End If
        Me.Cables_detailsBindingSource.EndEdit()
        Me.Cables_detailsTableAdapter.Update(Me.MydbDataSet.cables_details)

        Me.Cable_details_sectionTableAdapter.Fill(Me.MydbDataSet.cable_details_section, CType(CType(CType(Me.CablesBindingSource.Current, DataRowView).Row, mydbDataSet.cablesRow).idcable, Integer?))

        Me.Button3.Enabled = False
        Me.Button1.Enabled = True
        Me.Button4.Enabled = True
        Me.CheckBox2.Enabled = False
        Me.ComboBox9.Enabled = False
        Me.TextBox17.Enabled = False
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        'suppression
        Select Case MessageBox.Show("Vous allez supprimer un fil etes vous sur ?", "Suppression de fil", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            Case System.Windows.Forms.DialogResult.Yes
                Dim rows As mydbDataSet.cablesRow
                rows = CType(CType(Me.CablesBindingSource.Current, DataRowView).Row, mydbDataSet.cablesRow)
                Dim rows2 As mydbDataSet.cable_details_sectionRow
                rows2 = CType(CType(Me.Cable_details_sectionBindingSource.Current, DataRowView).Row, mydbDataSet.cable_details_sectionRow)
                Me.Cables_detailsTableAdapter.Fill(Me.MydbDataSet.cables_details)
                Me.Cables_detailsBindingSource.Position = Me.Cables_detailsBindingSource.Find("idcables_details", rows2.idcables_details)
                Me.Cables_detailsBindingSource.RemoveAt(Me.Cables_detailsBindingSource.Position)
                Me.Cables_detailsBindingSource.EndEdit()
                Me.Cables_detailsTableAdapter.Update(Me.MydbDataSet.cables_details)
                Me.Cable_details_sectionTableAdapter.Fill(Me.MydbDataSet.cable_details_section, CType(rows.idcable, Integer?))

                Me.Cable_details_sectionBindingSource.ResetBindings(False)

            Case System.Windows.Forms.DialogResult.No

        End Select
    End Sub

    Private Sub ButtonX2_Click(sender As System.Object, e As System.EventArgs) Handles ButtonX2.Click
        'UP
        'Me.Cables_detailsBindingSource.Position -= 1
        ' Me.DataGridView4.SelectedRows.
        ' Me.DataGridView4.SelectedRows.Item(-1)
        Me.Cable_details_sectionBindingSource.Position -= 1

        Me.Cables_detailsBindingSource.Position = Me.Cables_detailsBindingSource.Find("idcables_details", CType(CType(Me.Cable_details_sectionBindingSource.Current, DataRowView).Row, mydbDataSet.cable_details_sectionRow).idcables_details)

    End Sub

    Private Sub ButtonX4_Click(sender As System.Object, e As System.EventArgs) Handles ButtonX4.Click
        'DOWN
        'Me.Cables_detailsBindingSource.Position += 1
        ' Me.DataGridView4.SelectedRows.Item(e.RowIndex + 1)
        Me.Cable_details_sectionBindingSource.Position += 1
        Me.Cables_detailsBindingSource.Position = Me.Cables_detailsBindingSource.Find("idcables_details", CType(CType(Me.Cable_details_sectionBindingSource.Current, DataRowView).Row, mydbDataSet.cable_details_sectionRow).idcables_details)
    End Sub

    Private Sub DataGridView4_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView4.CellClick

        '   Dim row As mydbDataSet.cable_details_sectionRow
        '  row = CType(CType(Me.Cable_details_sectionBindingSource.Current, DataRowView).Row, mydbDataSet.cable_details_sectionRow)
        '   Me.Cables_detailsBindingSource.Position = Me.Cables_detailsBindingSource.Find(row.Fils, "fil")
        Me.Cables_detailsBindingSource.Position = Me.Cables_detailsBindingSource.Find("idcables_details", CType(CType(Me.Cable_details_sectionBindingSource.Current, DataRowView).Row, mydbDataSet.cable_details_sectionRow).idcables_details)

    End Sub

    Private Sub ButtonX5_Click(sender As System.Object, e As System.EventArgs) Handles ButtonX5.Click

        Dim formEquipement As FormEquipement
        formEquipement = New FormEquipement
        formEquipement.MdiParent = Me.ParentForm
        formEquipement.WindowState = FormWindowState.Maximized
        formEquipement.mode = False
        Dim row As mydbDataSet.equipementsRow
        row = CType(CType(Me.EquipementsBindingSource.Current, DataRowView).Row, mydbDataSet.equipementsRow)
        formEquipement.value2 = row.idequipement 'CStr(Repere_equipementComboBox.Text)
        formEquipement.Show()
    End Sub

    Private Sub ButtonX6_Click(sender As System.Object, e As System.EventArgs) Handles ButtonX6.Click
        Dim formEquipement As FormEquipement
        formEquipement = New FormEquipement
        formEquipement.MdiParent = Me.ParentForm
        formEquipement.WindowState = FormWindowState.Maximized
        formEquipement.mode = False
        Dim row As mydbDataSet.equipementsRow
        row = CType(CType(Me.EquipementAboutissantBindingSource.Current, DataRowView).Row, mydbDataSet.equipementsRow)
        formEquipement.value2 = row.idequipement 'CStr(ComboBox7.Text)
        formEquipement.Show()
    End Sub

    Private Sub DataGridView2_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellDoubleClick
        Dim row As String = CStr(DataGridView2.Rows(e.RowIndex).Cells(2).Value)
        Dim formTroncon As FormTroncon
        formTroncon = New FormTroncon
        formTroncon.MdiParent = Me.ParentForm
        formTroncon.WindowState = FormWindowState.Maximized
        formTroncon.mode = False
        Dim rows As mydbDataSet.tronconsRow
        Me.TronconsBindingSource.Position = Me.TronconsBindingSource.Find("repere troncon", row)
        rows = CType(CType(Me.TronconsBindingSource.Current, DataRowView).Row, mydbDataSet.tronconsRow)

        formTroncon.value = CStr(rows.idtroncons)

        formTroncon.Show()

    End Sub

    Dim info As TaskDialogInfo

    Dim result As eTaskDialogResult
    Private Sub ComboBox_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox.SelectedIndexChanged
        If Me.Lst_cable_mise_touretBindingSource.Count > 0 Then
            info = New TaskDialogInfo("Verouillage ", eTaskDialogIcon.Exclamation, "Câble mis en touret ", "Attention ce câble est affécté à un touret. si vous continuez le câble seras désaffecté ,etes vous sur ?", eTaskDialogButton.Ok Or eTaskDialogButton.No, eTaskDialogBackgroundColor.Red)
            result = TaskDialog.Show(info)

            Select Case result

                Case eTaskDialogResult.Ok
                    Dim r() As Data.DataRow

                    r = dataSet.Tables("actions").Select("champ = 'segregation'")
                    'For Each r In lst_action.Rows
                    '    If r("champ") = "segregation" And row("type") = "1" Then

                    '    End If
                    'Next
                    Dim cc As mydbDataSet.cablesRow

                    cc = CType(CType(Me.CablesBindingSource.Current, DataRowView).Row, mydbDataSet.cablesRow)

                    If r.Length = 0 Then
                        Dim row As DataRow = lst_action.NewRow

                        row("qui") = FormMain.user.Nom_user
                        row("quoi") = "Chamgement de segragation en " & Me.ComboBox.Text
                        row("identifiant") = cc.idcable
                        row("type") = "1"
                        row("champ") = "segregation"
                        lst_action.Rows.Add(row)
                        row = lst_action.NewRow

                        row("qui") = FormMain.user.Nom_user
                        row("quoi") = "Chamgement de segragation en " & Me.ComboBox.Text
                        row("identifiant") = cc.idcable
                        row("type") = "5"
                        row("champ") = "segregation"
                        lst_action.Rows.Add(row)
                        row = lst_action.NewRow

                        row("qui") = FormMain.user.Nom_user
                        row("quoi") = "Chamgement de segragation en " & Me.ComboBox.Text
                        row("identifiant") = cc.idcable
                        row("type") = "4"
                        row("champ") = "segregation"
                        lst_action.Rows.Add(row)
                    Else
                        For Each rr In r
                            Select Case rr("type").ToString
                                Case "1"
                                    rr("quoi") = "Chamgement de segragation en " & Me.ComboBox.Text
                                Case "4"
                                    rr("quoi") = "Chamgement de segragation en " & Me.ComboBox.Text
                                Case "5"
                                    rr("quoi") = "Chamgement de segragation en " & Me.ComboBox.Text

                            End Select
                        Next

                    End If
                    Dim count As Integer = 0
                    Cables_detailsBindingSource.Filter = "cables_idcable='" & value & "'"
                    If Cables_detailsBindingSource.Count > 0 Then



                        For count = 0 To Cables_detailsBindingSource.Count - 1

                            Me.Cables_details_has_touretsBindingSource.Filter = "cables_details_idcables_details='" & CType(DirectCast(Cables_detailsBindingSource.Item(count), DataRowView).Row, mydbDataSet.cables_detailsRow).idcables_details & "'"
                            Me.Cables_details_has_touretsBindingSource.RemoveCurrent()
                            Me.Cables_details_has_touretsTableAdapter.Update(MydbDataSet.cables_details_has_tourets)
                            Me.Lst_cable_mise_touretTableAdapter.Fill(MydbDataSet.lst_cable_mise_touret)
                            Me.Cables_details_has_touretsTableAdapter.Fill(MydbDataSet.cables_details_has_tourets)
                        Next
                    End If


                Case eTaskDialogResult.No
                    RemoveHandler ComboBox.SelectedIndexChanged, AddressOf ComboBox_SelectedIndexChanged

                    Me.CablesBindingSource.ResetBindings(True)

                    AddHandler ComboBox.SelectedIndexChanged, AddressOf ComboBox_SelectedIndexChanged
                    Exit Sub

            End Select
        Else
            Dim r() As Data.DataRow

            r = dataSet.Tables("actions").Select("champ = 'segregation'")
            'For Each r In lst_action.Rows
            '    If r("champ") = "segregation" And row("type") = "1" Then

            '    End If
            'Next
            Dim cc As mydbDataSet.cablesRow

            cc = CType(CType(Me.CablesBindingSource.Current, DataRowView).Row, mydbDataSet.cablesRow)

            If r.Length = 0 Then
                Dim row As DataRow = lst_action.NewRow

                row("qui") = FormMain.user.Nom_user
                row("quoi") = "Chamgement de segragation en " & Me.ComboBox.Text
                row("identifiant") = cc.idcable
                row("type") = "1"
                row("champ") = "segregation"
                lst_action.Rows.Add(row)
                row = lst_action.NewRow

                row("qui") = FormMain.user.Nom_user
                row("quoi") = "Chamgement de segragation en " & Me.ComboBox.Text
                row("identifiant") = cc.idcable
                row("type") = "5"
                row("champ") = "segregation"
                lst_action.Rows.Add(row)
                row = lst_action.NewRow

                row("qui") = FormMain.user.Nom_user
                row("quoi") = "Chamgement de segragation en " & Me.ComboBox.Text
                row("identifiant") = cc.idcable
                row("type") = "4"
                row("champ") = "segregation"
                lst_action.Rows.Add(row)
            Else
                For Each rr In r
                    Select Case rr("type").ToString
                        Case "1"
                            rr("quoi") = "Chamgement de segragation en " & Me.ComboBox.Text
                        Case "4"
                            rr("quoi") = "Chamgement de segragation en " & Me.ComboBox.Text
                        Case "5"
                            rr("quoi") = "Chamgement de segragation en " & Me.ComboBox.Text

                    End Select
                Next

            End If
        End If




    End Sub

    Private Sub ButtonX7_Click(sender As System.Object, e As System.EventArgs) Handles ButtonX7.Click
        Select Case MessageBox.Show("Vous allez supprimer un cable et tous les fils le composant etes vous sur ?", "Suppression de CABLES", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            Case System.Windows.Forms.DialogResult.Yes
                Dim rows As mydbDataSet.cablesRow
                rows = CType(CType(Me.CablesBindingSource.Current, DataRowView).Row, mydbDataSet.cablesRow)

                Me.Cables_detailsBindingSource.Filter = "cables_idcable = " & rows.idcable
                If Me.Cables_detailsBindingSource.Count > 0 Then

                    Do While Me.Cables_detailsBindingSource.Count > 0
                        Me.Cables_detailsBindingSource.RemoveAt(Me.Cables_detailsBindingSource.Find("cables_idcable", rows.idcable))
                        Me.Cables_detailsBindingSource.EndEdit()
                        Me.Cables_detailsTableAdapter.Update(Me.MydbDataSet.cables_details)
                        Me.Cables_detailsBindingSource.Filter = "cables_idcable = " & rows.idcable
                    Loop
                End If

                Me.CablesBindingSource.RemoveCurrent()
                Me.CablesBindingSource.EndEdit()
                Me.CablesTableAdapter.Update(Me.MydbDataSet.cables)
                Me.Close()

            Case System.Windows.Forms.DialogResult.No

        End Select
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        Me.CheckBox2.Enabled = True
        Me.ComboBox9.Enabled = True
        Me.TextBox17.Enabled = True
        Me.Button1.Enabled = False
        Me.Button3.Enabled = True
    End Sub

    Private Sub ComboBox9_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox9.SelectedIndexChanged
        If Me.Lst_cable_mise_touretBindingSource.Count > 0 Then
            info = New TaskDialogInfo("Verouillage ", eTaskDialogIcon.Exclamation, "Fils mis en touret ", "Attention ce Fils est affécté à un touret. si vous continuez le fils seras désaffecté ,etes vous sur ?", eTaskDialogButton.Ok Or eTaskDialogButton.No, eTaskDialogBackgroundColor.Red)
            result = TaskDialog.Show(info)

            Select Case result

                Case eTaskDialogResult.Ok
                    Me.Cables_detailsBindingSource.Position = Me.Cables_detailsBindingSource.Find("idcables_details", CType(CType(Me.Cable_details_sectionBindingSource.Current, DataRowView).Row, mydbDataSet.cable_details_sectionRow).idcables_details)
                    Me.Cables_details_has_touretsBindingSource.Filter = "cables_details_idcables_details='" & CType(CType(Me.Cables_detailsBindingSource.Current, DataRowView).Row, mydbDataSet.cables_detailsRow).idcables_details & "'"
                    Me.Cables_details_has_touretsBindingSource.RemoveCurrent()
                    Me.Cables_details_has_touretsTableAdapter.Update(MydbDataSet.cables_details_has_tourets)
                    Me.Lst_cable_mise_touretTableAdapter.Fill(MydbDataSet.lst_cable_mise_touret)
                    Me.Cables_details_has_touretsTableAdapter.Fill(MydbDataSet.cables_details_has_tourets)
                Case eTaskDialogResult.No
                    RemoveHandler ComboBox9.SelectedIndexChanged, AddressOf ComboBox9_SelectedIndexChanged
                    Me.Cable_details_sectionBindingSource.ResetBindings(True)
                    AddHandler ComboBox9.SelectedIndexChanged, AddressOf ComboBox9_SelectedIndexChanged
            End Select
        End If

    End Sub

    Private Sub ButtonX8_Click(sender As Object, e As EventArgs) Handles ButtonX8.Click
        ProgressBarX1.Visible = True
        ProgressSteps1.Visible = False
        idsegregation = CInt(Me.ComboBox.SelectedValue.ToString)
        trc_dep = Me.ComboBox2.Text
        BackgroundWorker1.RunWorkerAsync()

    End Sub



    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        If tenant Then
            StepItem1.Value = 0

        Else
            StepItem1.Value = 100
        End If
        If about Then
            StepItem4.Value = 0

        Else
            StepItem4.Value = 100
        End If

        If arbre_unique Then
            StepItem5.Value = 100

        Else
            StepItem5.Value = 0
        End If

        If segregation Then
            StepItem3.Value = 100
        Else
            StepItem3.Value = 0
        End If
        If tenant_assoc Then
            StepItem6.Value = 100
        Else
            StepItem6.Value = 0
        End If
        If modepose Then
            StepItem2.Value = 100
        Else
            StepItem2.Value = 0
        End If
        ProgressBarX1.Visible = False
        ProgressSteps1.Visible = True
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        annalyse_parcours()
    End Sub


    Private Sub ButtonX9_Click(sender As Object, e As EventArgs)
        Dim t1 = Task.Factory.StartNew(Sub()
                                           modepose = False
                                           segregation = False
                                           arbre_unique = False
                                           tenant = False
                                           about = False
                                           tenant_seg = False
                                           about_seg = False
                                           tenant_assoc = False
                                           Dim rd As mydbDataSet.lst_departs_onRow

                                           rd = CType(CType(Me.Lst_departs_onBindingSource.Current, DataRowView).Row, mydbDataSet.lst_departs_onRow)
                                           Dim rb As mydbDataSet.lst_borniers_onRow

                                           rb = CType(CType(Me.Lst_Borniers_onBindingSource.Current, DataRowView).Row, mydbDataSet.lst_borniers_onRow)
                                           'verification de la selection
                                           st = CInt(rd.troncons_idtroncons)
                                           fn = CInt(rb.troncons_idtroncons)

                                           If st = 0 Then

                                               '        MessageBox.Show("Aucun parcours possible" _
                                               '& Microsoft.VisualBasic.ControlChars.CrLf & "" _
                                               '& Microsoft.VisualBasic.ControlChars.CrLf & "Veuillez selectionner Le tronçon tenant .", "Impossible", MessageBoxButtons.OK, MessageBoxIcon.Error)

                                               Exit Sub
                                           End If

                                           If fn = 0 Then

                                               '        MessageBox.Show("Aucun parcours possible" _
                                               '& Microsoft.VisualBasic.ControlChars.CrLf & "" _
                                               '& Microsoft.VisualBasic.ControlChars.CrLf & "Veuillez selectionner le tronçon aboutissant .", "Impossible", MessageBoxButtons.OK, MessageBoxIcon.Error)

                                               Exit Sub
                                           End If

                                           'creation de la liste des troncons et de l'arbre unique

                                           'selection des associations unique pour l'arbre

                                           lt.Clear()
                                           lt2.Clear()
                                           Dim item As DataRow

                                           i = 0
                                           a = 1
                                           row = lt.NewRow()
                                           row("id") = st
                                           row("troncon") = trc_dep
                                           lt.Rows.Add(row)

                                           Do While a > 0
                                               'pour chaque trc dans troncons_assoc = st
                                               Me.Lst_assoc_par_trcTableAdapter.Fill(Me.MydbDataSet.lst_assoc_par_trc, CType(lt.Rows(i).Item(0), Integer?), st, fn)

                                               For Each item In Me.MydbDataSet.lst_assoc_par_trc
                                                   'test segregation et TV
                                                   '  If item(6).ToString = Me.ComboBox.SelectedValue.ToString Or item(6).ToString = "0" Then

                                                   If 0 = dataSet.Tables("troncons_tri").Select("ID = '" & item(0).ToString & "'").Count() Then
                                                       row = lt2.NewRow()
                                                       row("id") = item(0).ToString
                                                       row("id_troncon") = item(1).ToString
                                                       row("id_troncon2") = item(2).ToString
                                                       row("longueur") = CType(item(8).ToString, Double?)
                                                       If item(27).ToString = "True" Then
                                                           row("pose") = 1
                                                       End If
                                                       If item(28).ToString = "True" Then
                                                           row("pose") = 2
                                                       End If
                                                       If item(29).ToString = "True" Then
                                                           row("pose") = 3
                                                       End If
                                                       ' row("pose") = item(27).ToString()
                                                       lt2.Rows.Add(row)
                                                       If 0 = dataSet.Tables("troncons_seg2").Select("ID = '" & item(2).ToString & "'").Count() Then
                                                           row = lt.NewRow()
                                                           row("id") = item(2).ToString
                                                           row("troncon") = item(4).ToString
                                                           lt.Rows.Add(row)
                                                           a = a + 1
                                                       End If

                                                   End If

                                                   '  End If

                                               Next

                                               Me.Lst_assoc_par_trc2TableAdapter.Fill(Me.MydbDataSet.lst_assoc_par_trc2, CType(lt.Rows(i).Item(0), Integer?), st, fn)

                                               For Each item In Me.MydbDataSet.lst_assoc_par_trc2
                                                   '  If item(6).ToString = Me.ComboBox.SelectedValue.ToString Or item(6).ToString = "0" Then

                                                   If dataSet.Tables("troncons_tri").Select("ID = '" & item(0).ToString & "'").Count() = 0 Then
                                                       row = lt2.NewRow()
                                                       row("id") = item(0).ToString
                                                       row("id_troncon") = item(1).ToString
                                                       row("id_troncon2") = item(2).ToString
                                                       row("longueur") = item(8).ToString
                                                       If item(27).ToString = "True" Then
                                                           row("pose") = 1
                                                       End If
                                                       If item(28).ToString = "True" Then
                                                           row("pose") = 2
                                                       End If
                                                       If item(29).ToString = "True" Then
                                                           row("pose") = 3
                                                       End If
                                                       ' row("pose") = item(27).ToString()
                                                       lt2.Rows.Add(row)
                                                       If 0 = dataSet.Tables("troncons_seg2").Select("ID = '" & item(1).ToString & "'").Count() Then
                                                           row = lt.NewRow()
                                                           row("id") = item(1).ToString
                                                           row("troncon") = item(4).ToString
                                                           lt.Rows.Add(row)
                                                           a = a + 1
                                                       End If

                                                   End If
                                                   ' End If
                                               Next

                                               i = i + 1
                                               a = a - 1


                                           Loop

                                           If 0 = dataSet.Tables("troncons_seg2").Select("ID = '" & fn & "'").Count() Then

                                               'MessageBox.Show("Aucun parcours ne mene au tronçon demandé" _
                                               '    & Microsoft.VisualBasic.ControlChars.CrLf & "" _
                                               '    & Microsoft.VisualBasic.ControlChars.CrLf & "Veuillez verifier les segregations ou creer un pont .", "Impossible", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                               about = True
                                               'Exit Sub
                                           End If
                                           If 0 = dataSet.Tables("troncons_seg2").Select("ID = '" & st & "'").Count() Then

                                               'MessageBox.Show("Aucun parcours ne mene au tronçon demandé" _
                                               '    & Microsoft.VisualBasic.ControlChars.CrLf & "" _
                                               '    & Microsoft.VisualBasic.ControlChars.CrLf & "Veuillez verifier les segregations ou creer un pont .", "Impossible", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                               tenant = True
                                               ' Exit Sub
                                           End If
                                           'For Each item In lt.Rows
                                           If lt2.Rows.Count = 0 Then
                                               tenant_assoc = False
                                           Else
                                               tenant_assoc = True
                                           End If

                                           If tenant Or about Then Exit Sub
                                           'Next
                                           Me.graph = New Graph

                                           '//reset graph
                                           'Me.graph.Reset()

                                           'For Each item In lt.Rows

                                           '    Dim te As Integer = CInt(item(0).ToString)
                                           '    Me.graph.AddVertex(te.ToString)
                                           'Next

                                           'For Each item In lt2.Rows

                                           '    Me.graph.AddEdge(item(2).ToString, item(1).ToString, CDbl(item(3).ToString))

                                           'Next

                                           ''Me.graph.Save("graph2")

                                           'Dim starting = Me.graph.Verticies(st.ToString)
                                           'Dim ending = Me.graph.Verticies(fn.ToString)

                                           'Me.ShowResults2(starting, ending)
                                           'Dim dr() As DataRow
                                           'Dim n As Integer = 0
                                           'Dim ltindex(lt.Rows.Count) As Integer

                                           '' filtre segregation
                                           'Dim ctrltrc As mydbDataSet.tronconsRow
                                           'For Each item In lt.Rows
                                           '    Me.TronconsBindingSource.Position = Me.TronconsBindingSource.Find("idtroncons", CInt(item(0).ToString))
                                           '    ctrltrc = CType(CType(Me.TronconsBindingSource.Current, DataRowView).Row, mydbDataSet.tronconsRow)
                                           '    If ctrltrc.segregations_idsegregations = 0 Or ctrltrc.segregations_idsegregations = idsegregation Then
                                           '    Else
                                           '        dr = lt2.Select("id_troncon = '" & CInt(item(0).ToString) & "'")
                                           '        For i As Integer = 0 To dr.Length - 1
                                           '            ' lt2.Rows.Remove(CType(dr(i), DataRow))
                                           '            ' lt2.AcceptChanges()
                                           '            dr(i).Delete()
                                           '        Next
                                           '        lt2.AcceptChanges()
                                           '        dr = lt2.Select("id_troncon2 = '" & CInt(item(0).ToString) & "'")
                                           '        For i As Integer = 0 To dr.Length - 1
                                           '            ' lt2.Rows.Remove(CType(dr(i), DataRow))
                                           '            ' lt2.AcceptChanges()
                                           '            dr(i).Delete()
                                           '        Next
                                           '        lt2.AcceptChanges()

                                           '        ltindex(n) = CInt(item(0).ToString)
                                           '        n = n + 1
                                           '    End If

                                           'Next
                                           'Dim iiii As Integer
                                           'For iiii = 0 To n - 1

                                           '    dr = lt.Select("id ='" & CInt(ltindex(iiii).ToString) & "'")
                                           '    dr(0).Delete()
                                           '    lt.AcceptChanges()
                                           'Next
                                           ''v2
                                           Do While a > 0
                                               'pour chaque trc dans troncons_assoc = st
                                               Me.Lst_assoc_par_trcTableAdapter.Fill(Me.MydbDataSet.lst_assoc_par_trc, CType(lt.Rows(i).Item(0), Integer?), st, fn)

                                               For Each item In Me.MydbDataSet.lst_assoc_par_trc
                                                   'test segregation et TV
                                                   '  If item(6).ToString = Me.ComboBox.SelectedValue.ToString Or item(6).ToString = "0" Then

                                                   If 0 = dataSet.Tables("troncons_tri").Select("ID = '" & item(0).ToString & "'").Count() Then
                                                       row = lt2.NewRow()
                                                       row("id") = item(0).ToString
                                                       row("id_troncon") = item(1).ToString
                                                       row("id_troncon2") = item(2).ToString
                                                       row("longueur") = CType(item(8).ToString, Double?)
                                                       If item(27).ToString = "True" Then
                                                           row("pose") = 1
                                                       End If
                                                       If item(28).ToString = "True" Then
                                                           row("pose") = 2
                                                       End If
                                                       If item(29).ToString = "True" Then
                                                           row("pose") = 3
                                                       End If
                                                       ' row("pose") = item(27).ToString()
                                                       lt2.Rows.Add(row)
                                                       If 0 = dataSet.Tables("troncons_seg2").Select("ID = '" & item(2).ToString & "'").Count() Then
                                                           row = lt.NewRow()
                                                           row("id") = item(2).ToString
                                                           row("troncon") = item(4).ToString
                                                           lt.Rows.Add(row)
                                                           a = a + 1
                                                       End If

                                                   End If

                                                   '  End If

                                               Next

                                               Me.Lst_assoc_par_trc2TableAdapter.Fill(Me.MydbDataSet.lst_assoc_par_trc2, CType(lt.Rows(i).Item(0), Integer?), st, fn)

                                               For Each item In Me.MydbDataSet.lst_assoc_par_trc2
                                                   If item(6).ToString = Me.ComboBox.SelectedValue.ToString Or item(6).ToString = "0" Then

                                                       If dataSet.Tables("troncons_tri").Select("ID = '" & item(0).ToString & "'").Count() = 0 Then
                                                           row = lt2.NewRow()
                                                           row("id") = item(0).ToString
                                                           row("id_troncon") = item(1).ToString
                                                           row("id_troncon2") = item(2).ToString
                                                           row("longueur") = item(8).ToString
                                                           If item(27).ToString = "True" Then
                                                               row("pose") = 1
                                                           End If
                                                           If item(28).ToString = "True" Then
                                                               row("pose") = 2
                                                           End If
                                                           If item(29).ToString = "True" Then
                                                               row("pose") = 3
                                                           End If
                                                           ' row("pose") = item(27).ToString()
                                                           lt2.Rows.Add(row)
                                                           If 0 = dataSet.Tables("troncons_seg2").Select("ID = '" & item(1).ToString & "'").Count() Then
                                                               row = lt.NewRow()
                                                               row("id") = item(1).ToString
                                                               row("troncon") = item(4).ToString
                                                               lt.Rows.Add(row)
                                                               a = a + 1
                                                           End If

                                                       End If
                                                   End If
                                               Next

                                               i = i + 1
                                               a = a - 1


                                           Loop

                                           If lt2.Select("id_troncon = '" & fn & "'").Count > 0 Then
                                               segregation = True
                                           Else

                                           End If
                                           If lt2.Select("id_troncon2 = '" & fn & "'").Count > 0 Then
                                               segregation = True
                                           Else

                                           End If

                                           'Me.graph.Reset()

                                           'For Each item In lt.Rows

                                           '    Dim te As Integer = CInt(item(0).ToString)
                                           '    Me.graph.AddVertex(te.ToString)
                                           'Next

                                           'For Each item In lt2.Rows

                                           '    Me.graph.AddEdge(item(2).ToString, item(1).ToString, CDbl(item(3).ToString))

                                           'Next

                                           ''Me.graph.Save("graph2")

                                           'starting = Me.graph.Verticies(st.ToString)
                                           'ending = Me.graph.Verticies(fn.ToString)

                                           'Me.ShowResults2(starting, ending)

                                           'filtre pode de pose
                                           'Dim ok As Boolean = False
                                           'n = 0
                                           'For Each item In lt.Rows
                                           '    Me.TronconsBindingSource.Position = Me.TronconsBindingSource.Find("idtroncons", CInt(item(0).ToString))
                                           '    ctrltrc = CType(CType(Me.TronconsBindingSource.Current, DataRowView).Row, mydbDataSet.tronconsRow)

                                           '    If Me.RadioButton6.Checked And ctrltrc.remplissage2 Then
                                           '        ok = True

                                           '    ElseIf Me.RadioButton6.Checked And ctrltrc.remplissage3 Then
                                           '        ok = True
                                           '    ElseIf Me.RadioButton4.Checked And ctrltrc.remplissage3 Then
                                           '        ok = True
                                           '    ElseIf Me.RadioButton4.Checked And ctrltrc.remplissage Then
                                           '        ok = True

                                           '    Else

                                           '    End If
                                           '    If Not ok Then
                                           '        dr = lt2.Select("id_troncon = '" & CInt(item(0).ToString) & "'")
                                           '        For i As Integer = 0 To dr.Length - 1
                                           '            lt2.Rows.Remove(CType(dr(i), DataRow))

                                           '        Next
                                           '        lt2.AcceptChanges()
                                           '        dr = lt2.Select("id_troncon2 = '" & CInt(item(0).ToString) & "'")
                                           '        For i As Integer = 0 To dr.Length - 1
                                           '            lt2.Rows.Remove(CType(dr(i), DataRow))

                                           '        Next
                                           '        lt2.AcceptChanges()

                                           '        '  item.Delete()
                                           '        ltindex(n) = CInt(item(0).ToString)
                                           '        n = n + 1

                                           '    End If
                                           '    ok = False


                                           '    'If ctrltrc.remplissage Or ctrltrc.segregations_idsegregations = CInt(ComboBox.SelectedValue) Then
                                           '    'Else
                                           '    '    dr = lt2.Select("id_troncons = '" & CInt(item(0).ToString) & "'")
                                           '    '    For i As Integer = 0 To dr.Length - 1
                                           '    '        lt2.Rows.Remove(CType(dr(0), DataRow))
                                           '    '    Next
                                           '    '    lt2.AcceptChanges()
                                           '    '    dr = lt2.Select("id_troncons2 = '" & CInt(item(0).ToString) & "'")
                                           '    '    For i As Integer = 0 To dr.Length - 1
                                           '    '        lt2.Rows.Remove(CType(dr(0), DataRow))
                                           '    '    Next

                                           '    '    lt2.AcceptChanges()
                                           '    '    item.Delete()

                                           '    'End If

                                           'Next
                                           'For iiii = 0 To n - 1

                                           '    dr = lt.Select("id ='" & CInt(ltindex(iiii).ToString) & "'")
                                           '    dr(0).Delete()
                                           '    lt.AcceptChanges()
                                           'Next

                                           'lt.AcceptChanges()

                                           'v2
                                           Do While a > 0
                                               'pour chaque trc dans troncons_assoc = st
                                               Me.Lst_assoc_par_trcTableAdapter.Fill(Me.MydbDataSet.lst_assoc_par_trc, CType(lt.Rows(i).Item(0), Integer?), st, fn)

                                               For Each item In Me.MydbDataSet.lst_assoc_par_trc
                                                   'test segregation et TV
                                                   If item(6).ToString = Me.ComboBox.SelectedValue.ToString Or item(6).ToString = "0" Then

                                                       If 0 = dataSet.Tables("troncons_tri").Select("ID = '" & item(0).ToString & "'").Count() Then
                                                           row = lt2.NewRow()
                                                           row("id") = item(0).ToString
                                                           row("id_troncon") = item(1).ToString
                                                           row("id_troncon2") = item(2).ToString
                                                           row("longueur") = CType(item(8).ToString, Double?)
                                                           If item(27).ToString = "True" Then
                                                               row("pose") = 1
                                                           End If
                                                           If item(28).ToString = "True" Then
                                                               row("pose") = 2
                                                           End If
                                                           If item(29).ToString = "True" Then
                                                               row("pose") = 3
                                                           End If
                                                           ' row("pose") = item(27).ToString()
                                                           lt2.Rows.Add(row)
                                                           If 0 = dataSet.Tables("troncons_seg2").Select("ID = '" & item(2).ToString & "'").Count() Then
                                                               row = lt.NewRow()
                                                               row("id") = item(2).ToString
                                                               row("troncon") = item(4).ToString
                                                               lt.Rows.Add(row)
                                                               a = a + 1
                                                           End If

                                                       End If

                                                   End If

                                               Next

                                               Me.Lst_assoc_par_trc2TableAdapter.Fill(Me.MydbDataSet.lst_assoc_par_trc2, CType(lt.Rows(i).Item(0), Integer?), st, fn)

                                               For Each item In Me.MydbDataSet.lst_assoc_par_trc2
                                                   If item(6).ToString = Me.ComboBox.SelectedValue.ToString Or item(6).ToString = "0" Then

                                                       If dataSet.Tables("troncons_tri").Select("ID = '" & item(0).ToString & "'").Count() = 0 Then
                                                           row = lt2.NewRow()
                                                           row("id") = item(0).ToString
                                                           row("id_troncon") = item(1).ToString
                                                           row("id_troncon2") = item(2).ToString
                                                           row("longueur") = item(8).ToString
                                                           If item(27).ToString = "True" Then
                                                               row("pose") = 1
                                                           End If
                                                           If item(28).ToString = "True" Then
                                                               row("pose") = 2
                                                           End If
                                                           If item(29).ToString = "True" Then
                                                               row("pose") = 3
                                                           End If
                                                           ' row("pose") = item(27).ToString()
                                                           lt2.Rows.Add(row)
                                                           If 0 = dataSet.Tables("troncons_seg2").Select("ID = '" & item(1).ToString & "'").Count() Then
                                                               row = lt.NewRow()
                                                               row("id") = item(1).ToString
                                                               row("troncon") = item(4).ToString
                                                               lt.Rows.Add(row)
                                                               a = a + 1
                                                           End If

                                                       End If
                                                   End If
                                               Next

                                               i = i + 1
                                               a = a - 1


                                           Loop

                                           If lt2.Select("id_troncon = '" & fn & "'").Count > 0 Then
                                               modepose = True
                                           Else

                                           End If
                                           If lt2.Select("id_troncon2 = '" & fn & "'").Count > 0 Then
                                               modepose = True
                                           Else

                                           End If

                                           Me.graph.Reset()

                                           For Each item In lt.Rows

                                               Dim te As Integer = CInt(item(0).ToString)
                                               Me.graph.AddVertex(te.ToString)
                                           Next

                                           For Each item In lt2.Rows

                                               Me.graph.AddEdge(item(2).ToString, item(1).ToString, CDbl(item(3).ToString))

                                           Next

                                           'Me.graph.Save("graph2")

                                           Dim starting = Me.graph.Verticies(st.ToString)
                                           Dim ending = Me.graph.Verticies(fn.ToString)

                                           Me.ShowResults2(starting, ending)
                                       End Sub)


    End Sub
End Class