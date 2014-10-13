Imports DevComponents.DotNetBar
Imports System.Algorithms.Dijkstra
Imports DevComponents.DotNetBar.SuperGrid
Imports System.Threading
Imports Microsoft.Office.Interop

Public Class FormLstCables
    Inherits OfficeForm
    Public graph As Graph
    Public dataSet As DataSet
    Dim lt As System.Data.DataTable = New System.Data.DataTable("troncons_seg2")
    Dim lt2 As System.Data.DataTable = New System.Data.DataTable("troncons_tri")
    Dim lt3 As System.Data.DataTable = New System.Data.DataTable("cables")
    Dim column As DataColumn
    Dim row As DataRow
    ' Dim i As Integer
    Dim a As Integer
    Dim PrimaryKeyColumns(0) As DataColumn
    Dim state_cont As Boolean = False
    Dim st As Integer
    Dim fn As Integer
    Private memochoix As Boolean

#Region "Load"

    Private Delegate Sub Bouleanstate2(ByVal state As Boolean)
    Private _calcul As Thread
    Private _dataload As Thread
    Private MotifModif As String

    Private Sub Progbarstart2(ByVal state As Boolean)
        If Me.InvokeRequired Then
            Me.Invoke(New Bouleanstate2(AddressOf Progbarstart2), New Object() {state})
        Else
            If state Then
                Me.CircularProgress1.Visible = True
                Me.CircularProgress1.IsRunning = True
                Me.CircularProgress1.Text = "Actualisation / Calcul des données"
            Else
                Me.CircularProgress1.Visible = False
                Me.CircularProgress1.IsRunning = False
            End If
        End If
    End Sub

    Private Sub ButtonX2_Click(sender As System.Object, e As System.EventArgs) Handles ButtonX2.Click
        Me.SuperGridControl.PrimaryGrid.DetachDataSource(False)
        _dataload = New Thread(AddressOf Dataload)
        _dataload.IsBackground = True
        _dataload.Start()
    End Sub

    Private Sub Dataload()
        Dim t As Bouleanstate2
        t = New Bouleanstate2(AddressOf Progbarstart2)
        t(True)

        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.parcours'. Vous pouvez la déplacer ou la supprimer selon vos besoins.

        Me.ParcoursTableAdapter.Fill(Me.MydbDataSet.parcours)
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.parcours_detail'. Vous pouvez la déplacer ou la supprimer selon vos besoins.

        Me.Parcours_detailTableAdapter.Fill(Me.MydbDataSet.parcours_detail)
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.borniers'. Vous pouvez la déplacer ou la supprimer selon vos besoins.

        Me.BorniersTableAdapter.Fill(Me.MydbDataSet.borniers)
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.departs'. Vous pouvez la déplacer ou la supprimer selon vos besoins.

        Me.DepartsTableAdapter.Fill(Me.MydbDataSet.departs)
        ' Declare variables

        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.lst_cables'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        '  Me.SuperGridControl.PrimaryGrid.VirtualRowCount = 0
        Me.Lst_cablesTableAdapter.Fill(Me.MydbDataSet.lst_cables)
        '   Me.SuperGridControl.PrimaryGrid.VirtualRowCount = Me.MydbDataSet.lst_cables.Rows.Count
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.cables_details'. Vous pouvez la déplacer ou la supprimer selon vos besoins.

        Me.Cables_detailsTableAdapter.Fill(Me.MydbDataSet.cables_details)
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.cables'. Vous pouvez la déplacer ou la supprimer selon vos besoins.

        Me.CablesTableAdapter.Fill(Me.MydbDataSet.cables)
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.cables_details'. Vous pouvez la déplacer ou la supprimer selon vos besoins.

        Me.DepartsTableAdapter.Fill(Me.MydbDataSet.departs)
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.cables'. Vous pouvez la déplacer ou la supprimer selon vos besoins.

        Me.BorniersTableAdapter.Fill(Me.MydbDataSet.borniers)
        Me.SuperGridControl.PrimaryGrid.DataSource = Me.Lst_cablesBindingSource
        'Me.CablesTableAdapter.Fill(Me.MydbDataSet.cables)
        'Me.DepartsTableAdapter.Fill(Me.MydbDataSet.departs)
        'Me.BorniersTableAdapter.Fill(Me.MydbDataSet.borniers)
        Me.TronconsTableAdapter.Fill(Me.MydbDataSet.troncons)

        t(False)
    End Sub

#End Region

#Region "Actualisation"
    Public Sub actualisation()
        _dataload = New Thread(AddressOf Dataload)
        _dataload.IsBackground = True
        _dataload.Start()
    End Sub
#End Region

#Region "Calculs Parcours"

#End Region

#Region "OLD"

    Private Sub FormLstCables_GotFocus(sender As Object, e As System.EventArgs) Handles Me.GotFocus
        'Me.SuperGridControl.PrimaryGrid.DetachDataSource(True)
        '_dataload = New Thread(AddressOf Dataload)
        '_dataload.IsBackground = True
        '_dataload.Start()
    End Sub

    Private Sub FormLstCables_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.TronconsTableAdapter.Connection.Close()
        Me.TronconsTableAdapter.Connection.ConnectionString = ClassConnectionBuilder.ConnectionStringBuilder(FormMain.user.server,
                                                                                                            FormMain.user.
        Project_user,
     "root",
    FormMain.user.
                                                                                                                pass_user)
        Me.TronconsTableAdapter.Connection.Open()

        Me.BorniersTableAdapter.Connection.Close()
        Me.BorniersTableAdapter.Connection.ConnectionString = ClassConnectionBuilder.ConnectionStringBuilder(FormMain.user.server,
                                                                                                            FormMain.user.
        Project_user,
     "root",
    FormMain.user.
                                                                                                                pass_user)
        Me.BorniersTableAdapter.Connection.Open()
        Me.DepartsTableAdapter.Connection.Close()
        Me.DepartsTableAdapter.Connection.ConnectionString = ClassConnectionBuilder.ConnectionStringBuilder(FormMain.user.server,
                                                                                                           FormMain.user.
        Project_user,
     "root",
    FormMain.user.
                                                                                                               pass_user)
        Me.DepartsTableAdapter.Connection.Open()

        Me.CablesTableAdapter.Connection.Close()
        Me.CablesTableAdapter.Connection.ConnectionString = ClassConnectionBuilder.ConnectionStringBuilder(FormMain.user.server,
                                                                                                          FormMain.user.
        Project_user,
     "root",
    FormMain.user.
                                                                                                              pass_user)
        Me.CablesTableAdapter.Connection.Open()
        Me.Cables_detailsTableAdapter.Connection.Close()

        Me.Cables_detailsTableAdapter.Connection.ConnectionString =
            ClassConnectionBuilder.ConnectionStringBuilder(FormMain.user.server, FormMain.user.Project_user, "root", FormMain.user.pass_user)
        Me.Cables_detailsTableAdapter.Connection.Open()
        Me.Lst_cablesTableAdapter.Connection.Close()
        Me.Lst_cablesTableAdapter.Connection.ConnectionString =
            ClassConnectionBuilder.ConnectionStringBuilder(FormMain.user.server, FormMain.user.Project_user, "root", FormMain.user.pass_user)
        Me.Lst_cablesTableAdapter.ClearBeforeFill = True
        Me.Lst_cablesTableAdapter.Connection.Open()
        Me.BorniersTableAdapter.Connection.Close()

        Me.BorniersTableAdapter.Connection.Open()
        Me.BorniersTableAdapter.Connection.Close()
        Me.BorniersTableAdapter.Connection.ConnectionString = ClassConnectionBuilder.ConnectionStringBuilder(FormMain.user.server,
                                                                                                            FormMain.user.
        Project_user,
     "root",
    FormMain.user.
                                                                                                                pass_user)
        Me.BorniersTableAdapter.Connection.Open()
        Me.Parcours_detailTableAdapter.Connection.Close()
        Me.Parcours_detailTableAdapter.Connection.ConnectionString =
            ClassConnectionBuilder.ConnectionStringBuilder(FormMain.user.server, FormMain.user.Project_user, "root", FormMain.user.pass_user)
        Me.Parcours_detailTableAdapter.Connection.Open()
        Me.ParcoursTableAdapter.Connection.Close()
        Me.ParcoursTableAdapter.Connection.ConnectionString = ClassConnectionBuilder.ConnectionStringBuilder(FormMain.user.server,
                                                                                                            FormMain.user.
        Project_user,
     "root",
    FormMain.user.
                                                                                                                pass_user)
        Me.ParcoursTableAdapter.Connection.Open()

        'TODO: This line of code loads data into the 'MydbDataSet.salles' table. You can move, or remove it, as needed.
        Me.SallesTableAdapter.Fill(Me.MydbDataSet.salles)

        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.troncons'. Vous pouvez la déplacer ou la supprimer selon vos besoins.

        Me.TronconsTableAdapter.Fill(Me.MydbDataSet.troncons)

        ' Create new DataColumn, set DataType, ColumnName
        ' and add to DataTable.
        column = New DataColumn()
        column.DataType = Type.GetType("System.Int32")
        column.ColumnName = "id"
        column.ReadOnly = True
        column.Unique = True

        ' Add the Column to the DataColumnCollection.
        lt.Columns.Add(column)

        ' Create second column.
        column = New DataColumn()
        column.DataType = Type.GetType("System.String")
        column.ColumnName = "troncon"
        column.AutoIncrement = False
        column.Caption = "troncon"
        column.ReadOnly = False
        column.Unique = False

        ' Add the column to the table.
        lt.Columns.Add(column)

        ' Make the ID column the primary key column.

        PrimaryKeyColumns(0) = lt.Columns("id")
        lt.PrimaryKey = PrimaryKeyColumns

        ' Instantiate the DataSet variable.
        dataSet = New DataSet()

        ' Add the new DataTable to the DataSet.
        dataSet.Tables.Add(lt)

        ' Create new DataColumn, set DataType, ColumnName
        ' and add to DataTable.
        column = New DataColumn()
        column.DataType = Type.GetType("System.Int32")
        column.ColumnName = "id"
        column.ReadOnly = True
        column.Unique = True

        ' Add the Column to the DataColumnCollection.
        lt2.Columns.Add(column)

        ' Create second column.
        column = New DataColumn()
        column.DataType = Type.GetType("System.Int32")
        column.ColumnName = "id_troncon"
        column.AutoIncrement = False
        column.Caption = "troncon"
        column.ReadOnly = False
        column.Unique = False

        ' Add the column to the table.
        lt2.Columns.Add(column)

        ' Create second column.
        column = New DataColumn()
        column.DataType = Type.GetType("System.Int32")
        column.ColumnName = "id_troncon2"
        column.AutoIncrement = False
        column.Caption = "troncon tenant"
        column.ReadOnly = False
        column.Unique = False

        ' Add the column to the table.
        lt2.Columns.Add(column)

        ' Create second column.
        column = New DataColumn()
        column.DataType = Type.GetType("System.Int32")
        column.ColumnName = "longueur"
        column.AutoIncrement = False
        column.Caption = "longueur"
        column.ReadOnly = False
        column.Unique = False

        ' Add the column to the table.
        lt2.Columns.Add(column)

        ' Make the ID column the primary key column.

        PrimaryKeyColumns(0) = lt2.Columns("id")
        lt2.PrimaryKey = PrimaryKeyColumns
        dataSet.Tables.Add(lt2)

        ' Create new DataColumn, set DataType, ColumnName
        ' and add to DataTable.
        column = New DataColumn()
        column.DataType = Type.GetType("System.Int32")
        column.ColumnName = "id"
        column.ReadOnly = True
        column.Unique = True

        ' Add the Column to the DataColumnCollection.
        lt3.Columns.Add(column)

        ' Create second column.
        column = New DataColumn()
        column.DataType = Type.GetType("System.Int32")
        column.ColumnName = "id_troncon"
        column.AutoIncrement = False
        column.Caption = "troncon"
        column.ReadOnly = False
        column.Unique = False

        ' Add the column to the table.
        lt3.Columns.Add(column)

        ' Create second column.
        column = New DataColumn()
        column.DataType = Type.GetType("System.Int32")
        column.ColumnName = "seg"
        column.AutoIncrement = False
        column.Caption = "seg"
        column.ReadOnly = False
        column.Unique = False

        ' Add the column to the table.
        lt3.Columns.Add(column)
        ' Create second column.
        column = New DataColumn()
        column.DataType = Type.GetType("System.Int32")
        column.ColumnName = "id_troncon2"
        column.AutoIncrement = False
        column.Caption = "troncon aboutissant"
        column.ReadOnly = False
        column.Unique = False

        ' Add the column to the table.
        lt3.Columns.Add(column)

        ' Create second column.
        column = New DataColumn()
        column.DataType = Type.GetType("System.Int32")
        column.ColumnName = "id_parcour"
        column.AutoIncrement = False
        column.Caption = "Parcour"
        column.ReadOnly = False
        column.Unique = False

        ' Add the column to the table.
        lt3.Columns.Add(column)

        column = New DataColumn()
        column.DataType = Type.GetType("System.Int32")
        column.ColumnName = "pose"
        column.AutoIncrement = False
        column.Caption = "Mode_pose"
        column.ReadOnly = False
        column.Unique = False

        ' Add the column to the table.
        lt3.Columns.Add(column)

        column = New DataColumn()
        column.DataType = Type.GetType("System.Boolean")
        column.ColumnName = "contrainte"
        column.AutoIncrement = False
        column.Caption = "contrainte"
        column.ReadOnly = False
        column.Unique = False

        ' Add the column to the table.
        lt3.Columns.Add(column)

        column = New DataColumn()
        column.DataType = Type.GetType("System.Boolean")
        column.ColumnName = "verouillage_parcour"
        column.AutoIncrement = False
        column.Caption = "verouillage_parcour"
        column.ReadOnly = False
        column.Unique = False

        ' Add the column to the table.
        lt3.Columns.Add(column)

        PrimaryKeyColumns(0) = lt3.Columns("id")
        lt3.PrimaryKey = PrimaryKeyColumns
        dataSet.Tables.Add(lt3)
        Me.CheckBoxX10.Checked = False
        Me.Panel1.Visible = False
        Me.ButtonX1.Visible = False
        Me.CheckBoxX1.Visible = False
        _dataload = New Thread(AddressOf Dataload)
        _dataload.IsBackground = True
        _dataload.Start()
    End Sub
    Private Function GetRadioButtons() As Command()

        Return New Command() {Command1, Command2}

    End Function

    Private Sub Command1_Executed(sender As System.Object, e As System.EventArgs) Handles Command1.Executed
        MotifModif = "Conserver"
    End Sub

    Private Sub Command2_Executed(sender As System.Object, e As System.EventArgs) Handles Command2.Executed
        MotifModif = "Supprimer"
    End Sub
    Dim cont_choix As Boolean = False
    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        Dim grow As GridRow
        Dim irow As Integer
        Dim crow As DataRowView
        Dim crow2 As DataRowView
        Dim crow3 As DataRowView
        Dim crow4 As DataRowView
        Dim drow As DataRow
        Dim seg As Integer
        Dim pose As Integer
        Dim i As Integer

        Dim cont1 As Integer
        Dim cont2 As Integer
        Dim cont3 As Integer
        Dim cont4 As Integer
        Dim cont5 As Integer
        Dim cont6 As Integer
        Dim cont7 As Integer
        Dim cont8 As Integer

        Dim old_cont1 As Integer
        Dim old_cont2 As Integer
        Dim old_cont3 As Integer
        Dim old_cont4 As Integer
        Dim old_cont5 As Integer
        Dim old_cont6 As Integer
        Dim old_cont7 As Integer
        Dim old_cont8 As Integer

        Dim b As Integer
        Dim cause As String
        Dim copie_lt As System.Data.DataTable

        Dim copie_lt2 As System.Data.DataTable
        Dim copie2_lt As System.Data.DataTable

        Dim copie2_lt2 As System.Data.DataTable
        lt3.Clear()
        cause = ""
        'Me.CablesTableAdapter.Fill(Me.MydbDataSet.cables)
        'Me.DepartsTableAdapter.Fill(Me.MydbDataSet.departs)
        'Me.BorniersTableAdapter.Fill(Me.MydbDataSet.borniers)
        'Me.TronconsTableAdapter.Fill(Me.MydbDataSet.troncons)
        memochoix = False

        Dim info As TaskDialogInfo

        Dim result As eTaskDialogResult

        Select Case _
            MessageBox.Show("Vous allez creer un ensembe de parcours .Etes vous sur ?", "Creation d'un parcour",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            Case DialogResult.Yes
                Me.CircularProgress1.Visible = True
                Me.CircularProgress1.IsRunning = True

                'Liste des cables selectionnés
                For Each grow In Me.SuperGridControl.GetSelectedRows

                    Me.CablesBindingSource.Sort = "repere cable"
                    irow = Me.CablesBindingSource.Find("repere cable", grow.Cells(4).Value.ToString)
                    Me.CablesBindingSource.Position = irow
                    crow = CType(Me.CablesBindingSource.Item(irow), DataRowView)

                    drow = lt3.NewRow
                    drow("id") = crow.Item(0).ToString

                    If CBool(crow.Item(18)) Then
                        'monocouche
                        drow("pose") = 1
                    ElseIf CBool(crow.Item(19)) Then
                        'trefle
                        drow("pose") = 1
                    ElseIf CBool(crow.Item(20)) Then
                        'multicouche
                        drow("pose") = 2
                    End If

                    drow("contrainte") = crow.Item(25)
                    drow("verouillage_parcour") = crow.Item(42)
                    On Error Resume Next

                    irow = Me.DepartsBindingSource.Find("iddepart", crow.Item(2).ToString)
                    Me.DepartsBindingSource.Position = irow
                    crow2 = CType(Me.DepartsBindingSource.Item(irow), DataRowView)
                    drow("id_troncon") = crow2.Item(3).ToString

                    irow = Me.BorniersBindingSource.Find("idbornier", crow.Item(3).ToString)
                    Me.BorniersBindingSource.Position = irow
                    crow3 = CType(Me.BorniersBindingSource.Item(irow), DataRowView)
                    drow("id_troncon2") = crow3.Item(3).ToString

                    irow = Me.TronconsBindingSource.Find("idtroncons", crow2.Item(3).ToString)
                    Me.TronconsBindingSource.Position = irow
                    crow4 = CType(Me.TronconsBindingSource.Item(irow), DataRowView)
                    drow("seg") = crow4.Item(3).ToString

                    lt3.Rows.Add(drow)
                Next

                'Region "controle contrainte"

                'End Region
                Dim rowsc As mydbDataSet.cablesRow
                Dim lt3binding As BindingSource
                lt3binding = New BindingSource
                lt3binding.DataSource = lt3

                lt3binding.Filter = "verouillage_parcour = true"
                Dim dResult As DialogResult
                If lt3binding.Count > 0 Then

                    dResult = CType(MsgBox(lt3binding.Count & " Cable(s) ne seras (ont) parcouru suite au verouillage du (de leur) parcour(s).", CType(4144, MsgBoxStyle), "Controle Verouillage"), System.Windows.Forms.DialogResult)

                Else
                    dResult = DialogResult.OK
                End If
                If dResult = DialogResult.OK Then

                    'OK Code here

                    Dim state1 As Boolean = Me.CheckBoxX4.Checked
                    Dim state2 As Boolean = Me.CheckBoxX5.Checked
                    Dim state3 As Boolean = Me.CheckBoxX6.Checked
                    Dim state4 As Boolean = Me.CheckBoxX7.Checked
                    Dim state5 As Boolean = Me.CheckBoxX8.Checked
                    Dim state6 As Boolean = Me.CheckBoxX9.Checked

                    For ii = 0 To lt3.Rows.Count - 1
                        b = 1
                        If Not CBool(lt3.Rows(ii).Item(7)) Then

                            If Me.CheckBoxX1.Checked And CType(lt3.Rows(ii).Item(6), Boolean) = False Then
                                cont_choix = True
                                ' MsgBox("pas de contrainte existante / utilisation de la contrainte donee")
                                If Me.CheckBoxX2.Checked Then
                                    cont1 = CInt(Me.ComboBox1.SelectedValue)
                                    b = 2
                                End If

                                If Me.CheckBoxX3.Checked Then
                                    cont2 = CInt(Me.ComboBox2.SelectedValue)
                                    b = 3
                                End If

                                If state1 Then cont3 = CInt(Me.ComboBox3.SelectedValue)
                                If state2 Then cont4 = CInt(Me.ComboBox4.SelectedValue)
                                If state3 Then cont5 = CInt(Me.ComboBox5.SelectedValue)
                                If state4 Then cont6 = CInt(Me.ComboBox6.SelectedValue)
                                If state5 Then cont7 = CInt(Me.ComboBox7.SelectedValue)
                                If state6 Then cont8 = CInt(Me.ComboBox8.SelectedValue)

                            ElseIf Not Me.CheckBoxX1.Checked And CType(lt3.Rows(ii).Item(6), Boolean) = True Then
                                Me.ComboBox3.SelectedValue = 0
                                Me.ComboBox4.SelectedValue = 0
                                Me.ComboBox5.SelectedValue = 0
                                Me.ComboBox6.SelectedValue = 0
                                Me.ComboBox7.SelectedValue = 0
                                Me.ComboBox8.SelectedValue = 0

                                Me.CheckBoxX4.Checked = False
                                Me.CheckBoxX5.Checked = False
                                Me.CheckBoxX6.Checked = False
                                Me.CheckBoxX7.Checked = False
                                Me.CheckBoxX8.Checked = False
                                Me.CheckBoxX9.Checked = False

                                rowsc = Nothing
                                Me.CablesBindingSource.Position = Me.CablesBindingSource.Find("idcable", CInt(lt3.Rows(ii).Item(0).ToString))
                                rowsc = CType(CType(Me.CablesBindingSource.Current, DataRowView).Row, mydbDataSet.cablesRow)

                                info = New TaskDialogInfo("Gestion des Contraintes de Parcours", eTaskDialogIcon.ShieldStop, "Une contrainte est existante sur le Cable : " & rowsc.repere_cable, "Voullez vous conserver la contrainte de ce cable ?", eTaskDialogButton.Ok, eTaskDialogBackgroundColor.Red, GetRadioButtons, Nothing, Command3, Nothing, Nothing)
                                result = TaskDialog.Show(info)

                                Select Case result
                                    Case eTaskDialogResult.Ok

                                        Select Case MotifModif

                                            Case "Conserver"
                                                cont_choix = True

                                                If Not String.IsNullOrEmpty(rowsc.Cont3Mode.ToString) Then
                                                    If Not rowsc.IsCont3ModeNull Then
                                                        state1 = True
                                                        Me.CheckBoxX4.Checked = True

                                                        cont3 = rowsc.Cont3Val
                                                        Me.ComboBox3.SelectedValue = cont3
                                                    End If
                                                End If
                                                If Not String.IsNullOrEmpty(rowsc.Cont4Mode.ToString) Then
                                                    If Not rowsc.IsCont4ModeNull Then
                                                        state2 = True
                                                        Me.CheckBoxX5.Checked = True

                                                        cont4 = rowsc.Cont4Val
                                                        Me.ComboBox4.SelectedValue = cont4
                                                    End If
                                                End If
                                                If Not String.IsNullOrEmpty(rowsc.Cont5Mode.ToString) Then
                                                    If Not rowsc.IsCont5ModeNull Then
                                                        Me.CheckBoxX6.Checked = True

                                                        state3 = True
                                                        cont5 = rowsc.Cont5Val
                                                        Me.ComboBox5.SelectedValue = cont5
                                                    End If
                                                End If
                                                If Not String.IsNullOrEmpty(rowsc.Cont6Mode.ToString) Then
                                                    If Not rowsc.IsCont6ModeNull Then
                                                        Me.CheckBoxX7.Checked = True

                                                        state4 = True
                                                        cont6 = rowsc.Cont6Val
                                                        Me.ComboBox6.SelectedValue = cont6
                                                    End If
                                                End If
                                                If Not String.IsNullOrEmpty(rowsc.Cont7Mode.ToString) Then
                                                    If Not rowsc.IsCont7ModeNull Then
                                                        Me.CheckBoxX8.Checked = True
                                                        state5 = True
                                                        cont7 = rowsc.Cont7Val
                                                        Me.ComboBox7.SelectedValue = cont7
                                                    End If
                                                End If
                                                If Not String.IsNullOrEmpty(rowsc.Cont8Mode.ToString) Then
                                                    If Not rowsc.IsCont8ModeNull Then
                                                        Me.CheckBoxX9.Checked = True
                                                        state6 = True

                                                        cont8 = rowsc.Cont8Val
                                                        Me.ComboBox8.SelectedValue = cont8
                                                    End If
                                                End If

                                            Case "Supprimer"
                                                cont_choix = False
                                                Me.CheckBoxX4.Checked = False
                                                Me.CheckBoxX5.Checked = False
                                                Me.CheckBoxX6.Checked = False
                                                Me.CheckBoxX7.Checked = False
                                                Me.CheckBoxX8.Checked = False
                                                Me.CheckBoxX9.Checked = False
                                                state1 = False
                                                cont3 = CInt("")
                                                state2 = False
                                                cont4 = CInt("")
                                                state3 = False
                                                cont5 = CInt("")
                                                state4 = False
                                                cont6 = CInt("")
                                                state5 = False
                                                cont7 = CInt("")
                                                state6 = False
                                                cont8 = CInt("")

                                        End Select

                                    Case eTaskDialogResult.Cancel

                                        Exit Sub
                                End Select

                            ElseIf Not Me.CheckBoxX1.Checked And CType(lt3.Rows(ii).Item(6), Boolean) = False Then

                                ' MsgBox("pas de contrainte existante / pas  de  contrainte donee")

                            ElseIf Me.CheckBoxX1.Checked And CType(lt3.Rows(ii).Item(6), Boolean) = True Then
                                ' MsgBox("Quoi faire ?")
                                old_cont1 = CInt(Me.ComboBox1.SelectedValue)
                                old_cont2 = CInt(Me.ComboBox2.SelectedValue)
                                old_cont3 = CInt(Me.ComboBox3.SelectedValue)
                                old_cont4 = CInt(Me.ComboBox4.SelectedValue)
                                old_cont5 = CInt(Me.ComboBox5.SelectedValue)
                                old_cont6 = CInt(Me.ComboBox6.SelectedValue)
                                old_cont7 = CInt(Me.ComboBox7.SelectedValue)
                                old_cont8 = CInt(Me.ComboBox8.SelectedValue)
                                Me.CablesBindingSource.Position = Me.CablesBindingSource.Find("idcable", lt3.Rows(ii).Item(0))
                                rowsc = CType(CType(Me.CablesBindingSource.Current, DataRowView).Row, mydbDataSet.cablesRow)

                                info = New TaskDialogInfo("Gestion des Contraintes de Parcours", eTaskDialogIcon.ShieldStop, "Une contrainte est existante sur le Cable : " & rowsc.repere_cable, "Voullez vous conserver la contrainte de ce cable ou appliquer la nouvelle contrainte ?", eTaskDialogButton.Ok, eTaskDialogBackgroundColor.Red, GetRadioButtons, Nothing, Command3, Nothing, Nothing)
                                result = TaskDialog.Show(info)

                                Select Case result
                                    Case eTaskDialogResult.Ok

                                        Select Case MotifModif

                                            Case "Conserver"

                                                cont_choix = True

                                                If Not String.IsNullOrEmpty(rowsc.Cont3Mode.ToString) Then
                                                    If rowsc.Cont3Mode <> "" Then
                                                        Me.CheckBoxX4.Checked = True
                                                        state1 = True
                                                        cont3 = rowsc.Cont3Val
                                                        Me.ComboBox3.SelectedValue = cont3
                                                    End If
                                                End If
                                                If Not String.IsNullOrEmpty(rowsc.Cont4Mode.ToString) Then
                                                    If rowsc.Cont4Mode <> "" Then
                                                        Me.CheckBoxX5.Checked = True
                                                        state2 = True
                                                        cont4 = rowsc.Cont4Val
                                                        Me.ComboBox4.SelectedValue = cont4
                                                    End If
                                                End If
                                                If Not String.IsNullOrEmpty(rowsc.Cont5Mode.ToString) Then
                                                    If rowsc.Cont5Mode <> "" Then
                                                        Me.CheckBoxX6.Checked = True
                                                        state3 = True
                                                        cont5 = rowsc.Cont5Val
                                                        Me.ComboBox5.SelectedValue = cont5
                                                    End If
                                                End If
                                                If Not String.IsNullOrEmpty(rowsc.Cont6Mode.ToString) Then
                                                    If rowsc.Cont6Mode <> "" Then
                                                        Me.CheckBoxX7.Checked = True
                                                        state4 = True
                                                        cont6 = rowsc.Cont6Val
                                                        Me.ComboBox6.SelectedValue = cont6
                                                    End If
                                                End If
                                                If Not String.IsNullOrEmpty(rowsc.Cont7Mode.ToString) Then
                                                    If rowsc.Cont7Mode <> "" Then
                                                        Me.CheckBoxX8.Checked = True
                                                        state5 = True
                                                        cont7 = rowsc.Cont7Val
                                                        Me.ComboBox7.SelectedValue = cont7
                                                    End If
                                                End If
                                                If Not String.IsNullOrEmpty(rowsc.Cont8Mode.ToString) Then
                                                    If rowsc.Cont8Mode <> "" Then
                                                        Me.CheckBoxX9.Checked = True
                                                        state6 = True
                                                        cont8 = rowsc.Cont8Val
                                                        Me.ComboBox8.SelectedValue = cont8
                                                    End If
                                                End If

                                            Case "Supprimer"

                                                Me.CheckBoxX2.Checked = False
                                                Me.CheckBoxX3.Checked = False
                                                Me.CheckBoxX4.Checked = False
                                                Me.CheckBoxX5.Checked = False
                                                Me.CheckBoxX6.Checked = False
                                                Me.CheckBoxX7.Checked = False
                                                Me.CheckBoxX8.Checked = False
                                                Me.CheckBoxX9.Checked = False

                                                If Not old_cont1 = Nothing Then
                                                    Me.ComboBox1.SelectedValue = old_cont1
                                                    Me.CheckBoxX2.Checked = True

                                                Else
                                                    Me.ComboBox1.SelectedValue = 0
                                                    Me.CheckBoxX2.Checked = False

                                                End If

                                                If Not old_cont2 = Nothing Then
                                                    Me.ComboBox2.SelectedValue = old_cont2
                                                    Me.CheckBoxX3.Checked = True

                                                Else
                                                    Me.ComboBox2.SelectedValue = 0
                                                    Me.CheckBoxX3.Checked = False

                                                End If
                                                If Not old_cont3 = Nothing Then
                                                    Me.ComboBox3.SelectedValue = old_cont3
                                                    Me.CheckBoxX4.Checked = True
                                                    state1 = True
                                                Else
                                                    Me.ComboBox3.SelectedValue = 0
                                                    Me.CheckBoxX4.Checked = False
                                                    state1 = False
                                                End If
                                                If Not old_cont4 = Nothing Then
                                                    Me.ComboBox4.SelectedValue = old_cont4
                                                    Me.CheckBoxX5.Checked = True
                                                    state2 = True
                                                Else
                                                    Me.ComboBox4.SelectedValue = 0
                                                    Me.CheckBoxX5.Checked = False
                                                    state2 = False
                                                End If
                                                If Not old_cont5 = Nothing Then
                                                    Me.ComboBox5.SelectedValue = old_cont5
                                                    Me.CheckBoxX6.Checked = True
                                                    state3 = True
                                                Else
                                                    Me.ComboBox5.SelectedValue = 0
                                                    Me.CheckBoxX6.Checked = False
                                                    state3 = False
                                                End If
                                                If Not old_cont6 = Nothing Then
                                                    Me.ComboBox6.SelectedValue = old_cont6
                                                    Me.CheckBoxX7.Checked = True
                                                    state4 = True
                                                Else
                                                    Me.ComboBox6.SelectedValue = 0
                                                    Me.CheckBoxX7.Checked = False
                                                    state4 = False
                                                End If
                                                If Not old_cont7 = Nothing Then
                                                    Me.ComboBox7.SelectedValue = old_cont7
                                                    Me.CheckBoxX8.Checked = True
                                                    state5 = True
                                                Else
                                                    Me.ComboBox7.SelectedValue = 0
                                                    Me.CheckBoxX8.Checked = False
                                                    state5 = False
                                                End If
                                                If Not old_cont8 = Nothing Then
                                                    Me.ComboBox8.SelectedValue = old_cont8
                                                    Me.CheckBoxX9.Checked = True
                                                    state6 = True
                                                Else
                                                    Me.ComboBox8.SelectedValue = 0
                                                    Me.CheckBoxX9.Checked = False
                                                    state6 = False
                                                End If

                                                cont_choix = True

                                                If Me.CheckBoxX2.Checked Then
                                                    cont1 = CInt(Me.ComboBox1.SelectedValue)
                                                    b = 2
                                                End If

                                                If Me.CheckBoxX3.Checked Then
                                                    cont2 = CInt(Me.ComboBox2.SelectedValue)
                                                    b = 3
                                                End If

                                                If state1 Then cont3 = CInt(Me.ComboBox3.SelectedValue)
                                                If state2 Then cont4 = CInt(Me.ComboBox4.SelectedValue)
                                                If state3 Then cont5 = CInt(Me.ComboBox5.SelectedValue)
                                                If state4 Then cont6 = CInt(Me.ComboBox6.SelectedValue)
                                                If state5 Then cont7 = CInt(Me.ComboBox7.SelectedValue)
                                                If state6 Then cont8 = CInt(Me.ComboBox8.SelectedValue)

                                        End Select

                                    Case eTaskDialogResult.Cancel

                                        Exit Sub
                                End Select
                            End If

                            'If Me.CheckBoxX1.Checked Then
                            '    If Me.CheckBoxX2.Checked Then
                            '        cont1 = CInt(Me.ComboBox1.SelectedValue)
                            '        b = 2
                            '    End If

                            '    If Me.CheckBoxX3.Checked Then
                            '        cont2 = CInt(Me.ComboBox2.SelectedValue)
                            '        b = 3
                            '    End If

                            '    If Me.CheckBoxX4.Checked Then cont3 = CInt(Me.ComboBox3.SelectedValue)
                            '    If Me.CheckBoxX5.Checked Then cont4 = CInt(Me.ComboBox4.SelectedValue)
                            '    If Me.CheckBoxX6.Checked Then cont5 = CInt(Me.ComboBox5.SelectedValue)
                            '    If Me.CheckBoxX7.Checked Then cont6 = CInt(Me.ComboBox6.SelectedValue)
                            '    If Me.CheckBoxX8.Checked Then cont7 = CInt(Me.ComboBox7.SelectedValue)
                            '    If Me.CheckBoxX9.Checked Then cont8 = CInt(Me.ComboBox8.SelectedValue)
                            'End If

                            'verification de la selection
                            st = CInt(lt3.Rows(ii).Item(1).ToString)
                            fn = CInt(lt3.Rows(ii).Item(3).ToString)
                            seg = CInt(lt3.Rows(ii).Item(2).ToString)
                            pose = CInt(lt3.Rows(ii).Item(5).ToString)
                            If st = 0 Then
                                cause = "Veuillez selectionner Le tronçon tenant"
                                'MessageBox.Show("Aucun parcours possible" _
                                '                & ControlChars.CrLf & "" _
                                '                & ControlChars.CrLf & "Veuillez selectionner Le tronçon tenant .", "Impossible",
                                '                MessageBoxButtons.OK, MessageBoxIcon.Error)
                                '' GoTo Lastline
                                'Exit Sub
                                'Continue For
                            End If

                            If fn = 0 Then
                                cause = "Veuillez selectionner Le tronçon aboutissant"
                                'MessageBox.Show("Aucun parcours possible" _
                                '                & ControlChars.CrLf & "" _
                                '                & ControlChars.CrLf & "Veuillez selectionner le tronçon aboutissant .",
                                '                "Impossible", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                '' GoTo Lastline
                                'Exit Sub
                                ' Continue For
                            End If

                            'creation de la liste des troncons et de l'arbre unique

                            'selection des associations unique pour l'arbre

                            lt.Clear()
                            lt2.Clear()
                            copie_lt = lt.Copy
                            copie_lt2 = lt2.Copy
                            copie_lt.Clear()
                            copie_lt2.Clear()
                            copie2_lt = lt.Copy
                            copie2_lt2 = lt2.Copy
                            copie2_lt.Clear()
                            copie2_lt2.Clear()
                            Dim tempcont1 As Integer
                            Dim tempcont2 As Integer

                            Dim item As DataRow
                            'Do While b > 0

                            '    If b = 1 And Me.CheckBoxX2.Checked And Me.CheckBoxX3.Checked = False Then
                            '        st = fn
                            '        fn = tempcont1
                            '    End If
                            '    If b = 1 And Me.CheckBoxX3.Checked Then
                            '        st = fn
                            '        fn = tempcont2
                            '    End If
                            '    If b = 2 And Me.CheckBoxX2.Checked And Me.CheckBoxX3.Checked = False Then
                            '        tempcont1 = fn
                            '        fn = cont1
                            '    End If
                            '    If b = 2 And Me.CheckBoxX3.Checked Then
                            '        st = fn
                            '        fn = cont2
                            '    End If
                            '    If b = 3 Then
                            '        tempcont2 = fn
                            '        fn = cont1
                            '    End If

                            i = 0
                            a = 1

                            row = lt.NewRow()
                            row("id") = st

                            ' row("troncon") = Me.ComboBox2.Text
                            lt.Rows.Add(row)
                            copie_lt.Rows.Add(row)
                            copie2_lt.Rows.Add(row)

                            Do While a > 0
                                'pour chaque trc dans troncons_assoc = st

                                Me.Lst_assoc_par_trcTableAdapter.Connection.Close()
                                Me.Lst_assoc_par_trcTableAdapter.Connection.ConnectionString =
                                    ClassConnectionBuilder.ConnectionStringBuilder(FormMain.user.server, FormMain.user.Project_user, "root",
                                                                                  FormMain.user.pass_user)
                                Me.Lst_assoc_par_trcTableAdapter.Connection.Open()
                                Me.Lst_assoc_par_trcTableAdapter.Fill(Me.MydbDataSet.lst_assoc_par_trc,
                                                                      CType(lt.Rows(i).Item(0), Integer?), st, fn)
                                'verification segregation
                                For Each item In Me.MydbDataSet.lst_assoc_par_trc
                                    If _
                                       Me.CheckBoxX4.Checked = False Or Me.CheckBoxX4.Checked And cont3 <> CInt(item(5)) And
                                       Me.CheckBoxX4.Checked And cont3 <> CInt(item(26)) Then
                                        If _
                                            Me.CheckBoxX5.Checked = False Or
                                            Me.CheckBoxX5.Checked And cont4 <> CInt(item(5)) And
                                            Me.CheckBoxX5.Checked And cont4 <> CInt(item(26)) Then
                                            If _
                                                Me.CheckBoxX6.Checked = False Or
                                                Me.CheckBoxX6.Checked And cont5 <> CInt(item(1)) And
                                                Me.CheckBoxX6.Checked And cont5 <> CInt(item(2)) Then

                                                If _
                                                    Me.CheckBoxX7.Checked = False Or
                                                    Me.CheckBoxX7.Checked And cont6 <> CInt(item(1)) And
                                                    Me.CheckBoxX7.Checked And cont6 <> CInt(item(2)) Then

                                                    If _
                                Me.CheckBoxX8.Checked = False Or
                                Me.CheckBoxX8.Checked And cont7 <> CInt(item(1)) And
                                Me.CheckBoxX8.Checked And cont7 <> CInt(item(2)) Then
                                                        If _
                                                            Me.CheckBoxX9.Checked = False Or
                                                            Me.CheckBoxX9.Checked And cont8 <> CInt(item(1)) And
                                                            Me.CheckBoxX9.Checked And cont8 <> CInt(item(2)) Then

                                                            If item(6).ToString = seg.ToString Or item(6).ToString = "0" Then
                                                                If _
                                                          0 =
                                                          copie_lt2.Select(
                                                              "ID = '" & item(0).ToString & "'").Count() Then
                                                                    row = copie_lt2.NewRow()
                                                                    row("id") = item(0).ToString
                                                                    row("id_troncon") = item(1).ToString
                                                                    row("id_troncon2") = item(2).ToString
                                                                    row("longueur") = CType(item(8).ToString, Double?)
                                                                    copie_lt2.Rows.Add(row)
                                                                    If _
                                                                        0 =
                                                                        copie_lt.Select(
                                                                            "ID = '" & item(2).ToString & "'").Count() Then
                                                                        row = copie_lt.NewRow()
                                                                        row("id") = item(2).ToString
                                                                        row("troncon") = item(4).ToString
                                                                        copie_lt.Rows.Add(row)
                                                                    End If
                                                                End If
                                                            End If
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                Next

                                'verification mode de pose
                                For Each item In Me.MydbDataSet.lst_assoc_par_trc
                                    If _
                                       Me.CheckBoxX4.Checked = False Or Me.CheckBoxX4.Checked And cont3 <> CInt(item(5)) And
                                       Me.CheckBoxX4.Checked And cont3 <> CInt(item(26)) Then
                                        If _
                                            Me.CheckBoxX5.Checked = False Or
                                            Me.CheckBoxX5.Checked And cont4 <> CInt(item(5)) And
                                            Me.CheckBoxX5.Checked And cont4 <> CInt(item(26)) Then
                                            If _
                                                Me.CheckBoxX6.Checked = False Or
                                                Me.CheckBoxX6.Checked And cont5 <> CInt(item(1)) And
                                                Me.CheckBoxX6.Checked And cont5 <> CInt(item(2)) Then

                                                If _
                                                    Me.CheckBoxX7.Checked = False Or
                                                    Me.CheckBoxX7.Checked And cont6 <> CInt(item(1)) And
                                                    Me.CheckBoxX7.Checked And cont6 <> CInt(item(2)) Then

                                                    If _
                                                 Me.CheckBoxX8.Checked = False Or
                                                 Me.CheckBoxX8.Checked And cont7 <> CInt(item(1)) And
                                                 Me.CheckBoxX8.Checked And cont7 <> CInt(item(2)) Then

                                                        If _
                                                 Me.CheckBoxX9.Checked = False Or
                                                 Me.CheckBoxX9.Checked And cont8 <> CInt(item(1)) And
                                                 Me.CheckBoxX9.Checked And cont8 <> CInt(item(2)) Then

                                                            If _
                                                        (CBool(item(27)) And pose = 2) Or (CBool(item(28)) And pose = 1) Or
                                                        (CBool(item(29)) Or CInt(item(19)) = 1) Then
                                                                If _
                                                          0 =
                                                          copie2_lt2.Select(
                                                              "ID = '" & item(0).ToString & "'").Count() Then
                                                                    row = copie2_lt2.NewRow()
                                                                    row("id") = item(0).ToString
                                                                    row("id_troncon") = item(1).ToString
                                                                    row("id_troncon2") = item(2).ToString
                                                                    row("longueur") = CType(item(8).ToString, Double?)
                                                                    copie2_lt2.Rows.Add(row)
                                                                    If _
                                                                        0 =
                                                                        copie2_lt.Select(
                                                                            "ID = '" & item(2).ToString & "'").Count() Then
                                                                        row = copie2_lt.NewRow()
                                                                        row("id") = item(2).ToString
                                                                        row("troncon") = item(4).ToString
                                                                        copie2_lt.Rows.Add(row)
                                                                    End If
                                                                End If
                                                            End If
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                Next

                                ' generation arbre
                                For Each item In Me.MydbDataSet.lst_assoc_par_trc
                                    If _
                                        Me.CheckBoxX4.Checked = False Or Me.CheckBoxX4.Checked And cont3 <> CInt(item(5)) And
                                        Me.CheckBoxX4.Checked And cont3 <> CInt(item(26)) Then
                                        If _
                                            Me.CheckBoxX5.Checked = False Or
                                            Me.CheckBoxX5.Checked And cont4 <> CInt(item(5)) And
                                            Me.CheckBoxX5.Checked And cont4 <> CInt(item(26)) Then
                                            If _
                                                Me.CheckBoxX6.Checked = False Or
                                                Me.CheckBoxX6.Checked And cont5 <> CInt(item(1)) And
                                                Me.CheckBoxX6.Checked And cont5 <> CInt(item(2)) Then

                                                If _
                                                    Me.CheckBoxX7.Checked = False Or
                                                    Me.CheckBoxX7.Checked And cont6 <> CInt(item(1)) And
                                                    Me.CheckBoxX7.Checked And cont6 <> CInt(item(2)) Then

                                                    If _
                                                Me.CheckBoxX8.Checked = False Or
                                                Me.CheckBoxX8.Checked And cont7 <> CInt(item(1)) And
                                                Me.CheckBoxX8.Checked And cont7 <> CInt(item(2)) Then

                                                        If _
                                                Me.CheckBoxX9.Checked = False Or
                                                Me.CheckBoxX9.Checked And cont8 <> CInt(item(1)) And
                                                Me.CheckBoxX9.Checked And cont8 <> CInt(item(2)) Then

                                                            If item(6).ToString = seg.ToString Or item(6).ToString = "0" Then
                                                                If _
                                                                   (CBool(item(27)) And pose = 2) Or (CBool(item(28)) And pose = 1) Or
                                                                   (CBool(item(29)) Or CInt(item(19)) = 1) Then

                                                                    If _
                                                                        0 =
                                                                        dataSet.Tables("troncons_tri").Select(
                                                                            "ID = '" & item(0).ToString & "'").Count() Then
                                                                        row = lt2.NewRow()
                                                                        row("id") = item(0).ToString
                                                                        row("id_troncon") = item(1).ToString
                                                                        row("id_troncon2") = item(2).ToString
                                                                        row("longueur") = CType(item(8).ToString, Double?)
                                                                        lt2.Rows.Add(row)
                                                                        If _
                                                                            0 =
                                                                            dataSet.Tables("troncons_seg2").Select(
                                                                                "ID = '" & item(2).ToString & "'").Count() Then
                                                                            row = lt.NewRow()
                                                                            row("id") = item(2).ToString
                                                                            row("troncon") = item(4).ToString
                                                                            lt.Rows.Add(row)
                                                                            a = a + 1
                                                                        End If
                                                                    End If
                                                                End If
                                                            End If
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If

                                Next
                                Me.Lst_assoc_par_trc2TableAdapter.Connection.Close()
                                Me.Lst_assoc_par_trc2TableAdapter.Connection.ConnectionString =
                                    ClassConnectionBuilder.ConnectionStringBuilder(FormMain.user.server, FormMain.user.Project_user, "root",
                                                                                  FormMain.user.pass_user)
                                Me.Lst_assoc_par_trc2TableAdapter.Connection.Open()
                                Me.Lst_assoc_par_trc2TableAdapter.Fill(Me.MydbDataSet.lst_assoc_par_trc2,
                                                                       CType(lt.Rows(i).Item(0), Integer?), st, fn)

                                '' verification segregation
                                'For Each item In Me.MydbDataSet.lst_assoc_par_trc2
                                '    If _
                                '        Me.CheckBoxX4.Checked = False Or Me.CheckBoxX4.Checked And cont3 <> CInt(item(5)) And
                                '        Me.CheckBoxX4.Checked And cont3 <> CInt(item(26)) Then
                                '        If _
                                '            Me.CheckBoxX5.Checked = False Or
                                '            Me.CheckBoxX5.Checked And cont4 <> CInt(item(5)) And
                                '            Me.CheckBoxX5.Checked And cont4 <> CInt(item(26)) Then

                                '            If _
                                '                Me.CheckBoxX6.Checked = False Or
                                '                Me.CheckBoxX6.Checked And cont5 <> CInt(item(1)) And
                                '                Me.CheckBoxX6.Checked And cont5 <> CInt(item(2)) Then

                                '                If _
                                '                    Me.CheckBoxX7.Checked = False Or
                                '                    Me.CheckBoxX7.Checked And cont6 <> CInt(item(1)) And
                                '                    Me.CheckBoxX7.Checked And cont6 <> CInt(item(2)) Then
                                '                    If item(6).ToString = seg.ToString Or item(6).ToString = "0" Then

                                '                        If _
                                '                            copie_lt2.Select(
                                '                                "ID = '" & item(0).ToString & "'").Count() = 0 Then
                                '                            row = copie_lt2.NewRow()
                                '                            row("id") = item(0).ToString
                                '                            row("id_troncon") = item(1).ToString
                                '                            row("id_troncon2") = item(2).ToString
                                '                            row("longueur") = item(8).ToString
                                '                            copie_lt2.Rows.Add(row)
                                '                            If _
                                '                                0 =
                                '                                copie_lt.Select(
                                '                                    "ID = '" & item(1).ToString & "'").Count() Then
                                '                                row = copie_lt.NewRow()
                                '                                row("id") = item(1).ToString
                                '                                row("troncon") = item(4).ToString
                                '                                copie_lt.Rows.Add(row)

                                '                            End If

                                '                        End If
                                '                    End If

                                '                End If
                                '            End If
                                '        End If
                                '    End If
                                'Next
                                ''verification mode de pose
                                'For Each item In Me.MydbDataSet.lst_assoc_par_trc2
                                '    If _
                                '        Me.CheckBoxX4.Checked = False Or Me.CheckBoxX4.Checked And cont3 <> CInt(item(5)) And
                                '        Me.CheckBoxX4.Checked And cont3 <> CInt(item(26)) Then
                                '        If _
                                '            Me.CheckBoxX5.Checked = False Or
                                '            Me.CheckBoxX5.Checked And cont4 <> CInt(item(5)) And
                                '            Me.CheckBoxX5.Checked And cont4 <> CInt(item(26)) Then

                                '            If _
                                '                Me.CheckBoxX6.Checked = False Or
                                '                Me.CheckBoxX6.Checked And cont5 <> CInt(item(1)) And
                                '                Me.CheckBoxX6.Checked And cont5 <> CInt(item(2)) Then

                                '                If _
                                '                    Me.CheckBoxX7.Checked = False Or
                                '                    Me.CheckBoxX7.Checked And cont6 <> CInt(item(1)) And
                                '                    Me.CheckBoxX7.Checked And cont6 <> CInt(item(2)) Then
                                '                    If _
                                '        (CBool(item(27)) And pose = 2) Or (CBool(item(28)) And pose = 1) Or
                                '        (CBool(item(29)) Or CInt(item(19)) = 1) Then

                                '                        If _
                                '                            copie2_lt2.Select(
                                '                                "ID = '" & item(0).ToString & "'").Count() = 0 Then
                                '                            row = copie2_lt2.NewRow()
                                '                            row("id") = item(0).ToString
                                '                            row("id_troncon") = item(1).ToString
                                '                            row("id_troncon2") = item(2).ToString
                                '                            row("longueur") = item(8).ToString
                                '                            copie2_lt2.Rows.Add(row)
                                '                            If _
                                '                                0 =
                                '                                copie2_lt.Select(
                                '                                    "ID = '" & item(1).ToString & "'").Count() Then
                                '                                row = copie2_lt.NewRow()
                                '                                row("id") = item(1).ToString
                                '                                row("troncon") = item(4).ToString
                                '                                copie2_lt.Rows.Add(row)

                                '                            End If

                                '                        End If
                                '                    End If

                                '                End If
                                '            End If
                                '        End If
                                '    End If
                                'Next

                                For Each item In Me.MydbDataSet.lst_assoc_par_trc2
                                    If _
                                        Me.CheckBoxX4.Checked = False Or Me.CheckBoxX4.Checked And cont3 <> CInt(item(5)) And
                                        Me.CheckBoxX4.Checked And cont3 <> CInt(item(26)) Then
                                        If _
                                            Me.CheckBoxX5.Checked = False Or
                                            Me.CheckBoxX5.Checked And cont4 <> CInt(item(5)) And
                                            Me.CheckBoxX5.Checked And cont4 <> CInt(item(26)) Then

                                            If _
                                                Me.CheckBoxX6.Checked = False Or
                                                Me.CheckBoxX6.Checked And cont5 <> CInt(item(1)) And
                                                Me.CheckBoxX6.Checked And cont5 <> CInt(item(2)) Then

                                                If _
                                                    Me.CheckBoxX7.Checked = False Or
                                                    Me.CheckBoxX7.Checked And cont6 <> CInt(item(1)) And
                                                    Me.CheckBoxX7.Checked And cont6 <> CInt(item(2)) Then

                                                    If _
                                                 Me.CheckBoxX8.Checked = False Or
                                                 Me.CheckBoxX8.Checked And cont7 <> CInt(item(1)) And
                                                 Me.CheckBoxX8.Checked And cont7 <> CInt(item(2)) Then

                                                        If _
                                                                                                     Me.CheckBoxX9.Checked = False Or
                                                                                                     Me.CheckBoxX9.Checked And cont8 <> CInt(item(1)) And
                                                                                                     Me.CheckBoxX9.Checked And cont8 <> CInt(item(2)) Then

                                                            If item(6).ToString = seg.ToString Or item(6).ToString = "0" Then
                                                                If _
                                                                   (CBool(item(27)) And pose = 2) Or (CBool(item(28)) And pose = 1) Or
                                                                   (CBool(item(29)) Or CInt(item(19)) = 1) Then
                                                                    If _
                                                                        dataSet.Tables("troncons_tri").Select(
                                                                            "ID = '" & item(0).ToString & "'").Count() = 0 Then
                                                                        row = lt2.NewRow()
                                                                        row("id") = item(0).ToString
                                                                        row("id_troncon") = item(1).ToString
                                                                        row("id_troncon2") = item(2).ToString
                                                                        row("longueur") = item(8).ToString
                                                                        lt2.Rows.Add(row)
                                                                        If _
                                                                            0 =
                                                                            dataSet.Tables("troncons_seg2").Select(
                                                                                "ID = '" & item(1).ToString & "'").Count() Then
                                                                            row = lt.NewRow()
                                                                            row("id") = item(1).ToString
                                                                            row("troncon") = item(4).ToString
                                                                            lt.Rows.Add(row)
                                                                            a = a + 1
                                                                        End If
                                                                    End If
                                                                End If
                                                            End If
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                Next

                                i = i + 1
                                a = a - 1
                            Loop
                            'b -= 1
                            'Loop

                            st = CInt(lt3.Rows(ii).Item(1).ToString)
                            fn = CInt(lt3.Rows(ii).Item(3).ToString)

                            'If Not copie2_lt.Select("ID = '" & fn & "'").Count() > 0 Then
                            '    cause = " // Probleme sur la segregation // " & cause
                            'End If
                            'If Not copie_lt.Select("ID = '" & fn & "'").Count() > 0 Then
                            '    cause = " // Probleme sur le mode de pose // " & cause
                            'End If

                            'If Not copie2_lt.Select("ID = '" & fn & "'").Count() > 0 And Not copie_lt.Select("ID = '" & fn & "'").Count() > 0 Then
                            '    cause = " // Probleme d'association // " & cause
                            'End If
                            '      If 0 = dataSet.Tables("troncons_seg2").Select("ID = '" & fn & "'").Count() Then

                            '  MessageBox.Show("Aucun parcours ne mene au tronçon demandé" _
                            '     & Microsoft.VisualBasic.ControlChars.CrLf & "" _
                            '    & Microsoft.VisualBasic.ControlChars.CrLf & "Veuillez choisir un autre tronçon , Verifier Le mode de remplissage ou creer un pont .", "Impossible", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            'GoTo Lastline
                            ' Exit Sub
                            'Continue For
                            ' End If

                            Me.graph = New Graph

                            '//reset graph
                            Me.graph.Reset()

                            'Mise à jour des champ vide
                            For Each item In lt.Rows
                                Me.TronconsBindingSource.Position = Me.TronconsBindingSource.Find("idtroncons", item(0).ToString)
                                Dim rows As mydbDataSet.tronconsRow
                                rows = CType(CType(Me.TronconsBindingSource.Current, DataRowView).Row, mydbDataSet.tronconsRow)

                                item(1) = rows.repere_troncon
                            Next
                            'Mise à jour des longueurs associations
                            For Each item In lt2.Rows
                                Dim rows As mydbDataSet.tronconsRow
                                'Me.TronconsBindingSource.Position = Me.TronconsBindingSource.Find("idtroncons", item(1).ToString)

                                'rows = CType(CType(Me.TronconsBindingSource.Current, DataRowView).Row, mydbDataSet.tronconsRow)
                                'item(3) = rows.longueur
                                Me.TronconsBindingSource.Position = Me.TronconsBindingSource.Find("idtroncons", item(2).ToString)

                                rows = CType(CType(Me.TronconsBindingSource.Current, DataRowView).Row, mydbDataSet.tronconsRow)
                                item(3) = CInt(item(3).ToString()) + CInt(rows.longueur)
                            Next

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

                            Me.ShowResults(starting, ending, CInt(lt3(ii).Item(0).ToString), cause)
                            'Me.CheckBoxX2.Checked = False
                            'Me.CheckBoxX3.Checked = False
                            'Me.CheckBoxX4.Checked = False
                            'Me.CheckBoxX5.Checked = False
                            'Me.CheckBoxX6.Checked = False
                            'Me.CheckBoxX7.Checked = False
                            'Me.CheckBoxX8.Checked = False
                            'Me.CheckBoxX9.Checked = False

                            'If Not old_cont1 = 0 Then
                            '    Me.ComboBox1.SelectedValue = old_cont1
                            '    Me.CheckBoxX2.Checked = True
                            'End If

                            'If Not old_cont2 = 0 Then
                            '    Me.ComboBox2.SelectedValue = old_cont2
                            '    Me.CheckBoxX3.Checked = False
                            'End If
                            'If Not old_cont3 = 0 Then
                            '    Me.ComboBox3.SelectedValue = old_cont3
                            '    Me.CheckBoxX4.Checked = False
                            'End If
                            'If Not old_cont4 = 0 Then
                            '    Me.ComboBox4.SelectedValue = old_cont4
                            '    Me.CheckBoxX5.Checked = False
                            'End If
                            'If Not old_cont5 = 0 Then
                            '    Me.ComboBox5.SelectedValue = old_cont5
                            '    Me.CheckBoxX6.Checked = False
                            'End If
                            'If Not old_cont6 = 0 Then
                            '    Me.ComboBox6.SelectedValue = old_cont6
                            '    Me.CheckBoxX7.Checked = False
                            'End If
                            'If Not old_cont7 = 0 Then
                            '    Me.ComboBox7.SelectedValue = old_cont7
                            '    Me.CheckBoxX8.Checked = False
                            'End If
                            'If Not old_cont8 = 0 Then
                            '    Me.ComboBox8.SelectedValue = old_cont8
                            '    Me.CheckBoxX9.Checked = False
                            'End If
                        End If
                        cause = ""

                    Next ii
                End If
                Me.CircularProgress1.IsRunning = False
                Me.CircularProgress1.Visible = False
            Case DialogResult.No

        End Select
    End Sub

    Private Sub ShowResults(ByVal start As Vertex,
                            ByVal [end] As Vertex, ByVal id As Integer, ByVal _cause As String)

        Try
            Dim distance = graph.GetDistance(start, [end])

            Dim path = graph.GetPath(start, [end], False)

            ' //show basic results
            'MessageBox.Show(String.Format("De {0} à {1}{3}{3}Parcour : {2}{3}{3}Distance: {4}", _
            '                                  start.Key, [end].Key, path, Environment.NewLine, distance), _
            '            "Dijkstra's", MessageBoxButtons.OK, MessageBoxIcon.Information)

            'Select MessageBox.Show("Voullez vous enregistrer le parcour.Etes vous sur ?", "enregistrement d'un parcour", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            'Case System.Windows.Forms.DialogResult.Yes
            ' Me.ParcoursBindingSource.AddNew()
            Dim ref_parcours As String
            Dim prow As DataRow
            Dim drow As DataRow
            Dim dow As Date
            Dim cnt As Integer
            Dim strArr() As String
            Dim count As Integer
            Dim long_finale As Integer = 0
            state_cont = False
            path = path.Replace(">", "")
            path = path.Replace(" ", "")
            strArr = path.Split(CChar("-"))
            Me.Parcours_detailTableAdapter.Connection.Close()
            Me.Parcours_detailTableAdapter.Connection.ConnectionString =
                ClassConnectionBuilder.ConnectionStringBuilder(FormMain.user.server, FormMain.user.Project_user, "root", FormMain.user.pass_user)
            Me.Parcours_detailTableAdapter.Connection.Open()

            cnt = Me.Parcours_detailBindingSource.Count + 1
            prow = Me.MydbDataSet.parcours.NewRow
            dow = Today
            'ref_parcours = CStr(Year(Today))
            ref_parcours = CStr(Month(Today))
            ref_parcours = ref_parcours & dow.Day()
            ref_parcours = ref_parcours & Hour(Now)
            ref_parcours = ref_parcours & Minute(Now)
            ref_parcours = ref_parcours & cnt

            prow.Item(1) = st
            prow.Item(2) = fn
            prow.Item(3) = Today
            prow.Item(4) = FormMain.user.Nom_user
            prow.Item(6) = ref_parcours
            'Mise à jour longueur parcourts

            For count = 0 To strArr.Length - 1
                Dim rows2 As mydbDataSet.tronconsRow
                Me.TronconsBindingSource.Position = Me.TronconsBindingSource.Find("idtroncons", strArr(count))
                rows2 = CType(CType(Me.TronconsBindingSource.Current, DataRowView).Row, mydbDataSet.tronconsRow)
                long_finale += CInt(rows2.longueur)
            Next
            prow.Item(7) = long_finale 'distance
            Me.MydbDataSet.parcours.Rows.Add(prow)
            Me.ParcoursBindingSource.EndEdit()
            Me.ParcoursTableAdapter.Connection.Close()
            Me.ParcoursTableAdapter.Connection.ConnectionString = ClassConnectionBuilder.ConnectionStringBuilder(FormMain.user.server,
                                                                                                                FormMain.user.
            Project_user,
         "root",
        FormMain.user.
                                                                                                                    pass_user)
            Me.ParcoursTableAdapter.Connection.Open()
            Me.ParcoursTableAdapter.Update(MydbDataSet)
            Me.ParcoursTableAdapter.Fill(Me.MydbDataSet.parcours)
            Me.ParcoursBindingSource.ResetBindings(False)
            Me.ParcoursBindingSource.Sort = "ref_parcour"
            Dim place As Integer = Me.ParcoursBindingSource.Find("ref_parcour", ref_parcours)
            Me.ParcoursBindingSource.Position = place

            ' Me.Parcours_detailBindingSource.AddNew()

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

            Dim erows As DataRowView
            erows = CType(Me.CablesBindingSource.Item(Me.CablesBindingSource.Find("idcable", id)), DataRowView)
            erows.BeginEdit()
            '
            If cont_choix Then
                state_cont = True
            Else
                state_cont = False
            End If
            If Me.CheckBoxX2.Checked Then

                erows("Cont1Val") = Me.ComboBox1.SelectedValue
                erows("Cont1Mode") = Me.CheckBoxX2.Text
            End If
            If Me.CheckBoxX3.Checked Then

                erows("Cont2Val") = Me.ComboBox2.SelectedValue
                erows("Cont2Mode") = Me.CheckBoxX3.Text
            End If
            If Me.CheckBoxX4.Checked Then

                erows("Cont3Val") = Me.ComboBox3.SelectedValue
                erows("Cont3Mode") = Me.CheckBoxX4.Text
            End If
            If Me.CheckBoxX5.Checked Then

                erows("Cont4Val") = Me.ComboBox4.SelectedValue
                erows("Cont4Mode") = Me.CheckBoxX5.Text
            End If
            If Me.CheckBoxX6.Checked Then

                erows("Cont5Val") = Me.ComboBox5.SelectedValue
                erows("Cont5Mode") = Me.CheckBoxX6.Text
            End If
            If Me.CheckBoxX7.Checked Then

                erows("Cont6Val") = Me.ComboBox6.SelectedValue
                erows("Cont6Mode") = Me.CheckBoxX7.Text
            End If
            If Me.CheckBoxX8.Checked Then

                erows("Cont7Val") = Me.ComboBox7.SelectedValue
                erows("Cont7Mode") = Me.CheckBoxX8.Text
            End If
            If Me.CheckBoxX9.Checked Then

                erows("Cont8Val") = Me.ComboBox8.SelectedValue
                erows("Cont8Mode") = Me.CheckBoxX9.Text
            End If

            erows("Contrainte") = state_cont
            erows("parcours_idparcours") = rows(0).ToString
            erows("qui") = FormMain.user.Nom_user
            erows("date") = DateTime.Today.ToString("g")
            erows.EndEdit()
            CablesBindingSource.EndEdit()
            CablesTableAdapter.Update(MydbDataSet.cables)
            Parcours_detailBindingSource.EndEdit()
            Parcours_detailTableAdapter.Update(MydbDataSet)
            Parcours_detailTableAdapter.Fill(MydbDataSet.parcours_detail)
            'lt3.Rows(i).Item(4) = ref_parcours

            '  Case (System.Windows.Forms.DialogResult.No)
            'End Select
        Catch ex As Exception
            Dim erows As DataRowView
            erows = CType(Me.CablesBindingSource.Item(Me.CablesBindingSource.Find("idcable", id)), DataRowView)
            erows.BeginEdit()
            erows("parcours_idparcours") = "0"
            erows("qui") = FormMain.user.Nom_user
            erows("date") = DateTime.Today.ToString("g")
            erows("divers") = "#-GENERATION : Parcours impossible- " & _cause & " -# " & erows("divers").ToString
            erows.EndEdit()
            CablesBindingSource.EndEdit()
            CablesTableAdapter.Update(MydbDataSet.cables)
        End Try

    End Sub

    Private Sub SuperGridControl_DoubleClick(sender As Object, e As GridRowDoubleClickEventArgs) _
        Handles SuperGridControl.RowDoubleClick
        Dim grow As GridRow

        Dim irow As Integer
        Dim crow As DataRowView

        Dim formCable As FormCable
        formCable = New FormCable
        formCable.MdiParent = ParentForm
        formCable.WindowState = FormWindowState.Maximized
        formCable.mode = False

        grow = CType(e.GridRow, GridRow)
        irow = CablesBindingSource.Find("repere cable", grow.Cells(4).Value.ToString)
        CablesBindingSource.Position = irow
        crow = CType(CablesBindingSource.Item(irow), DataRowView)

        formCable.value = crow.Item(0).ToString

        formCable.Show()
    End Sub

    Private Sub CheckBoxX1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxX1.CheckedChanged
        If CheckBoxX1.Checked Then
            Panel1.Visible = True
        Else
            Panel1.Visible = False
        End If
    End Sub

    Private Sub CheckBoxX10_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxX10.CheckedChanged
        If Me.CheckBoxX10.Checked Then
            Me.CheckBoxX1.Visible = True
            Me.ButtonX1.Visible = True
        Else
            Me.CheckBoxX1.Visible = False
            Me.ButtonX1.Visible = False
        End If
    End Sub

    Private Sub CheckBoxX4_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxX4.CheckedChanged
        If Me.CheckBoxX4.Checked Then
            Me.CheckBoxX5.Checked = False
            Me.CheckBoxX5.Visible = True

        Else
            Me.CheckBoxX5.Checked = False
            Me.CheckBoxX5.Visible = False
        End If
    End Sub

    Private Sub CheckBoxX2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxX2.CheckedChanged
        If Me.CheckBoxX2.Checked Then
            Me.CheckBoxX3.Checked = False
            Me.CheckBoxX3.Visible = True

        Else
            Me.CheckBoxX3.Checked = False
            Me.CheckBoxX3.Visible = False
        End If
    End Sub

#End Region

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub ButtonX3_Click(sender As Object, e As EventArgs) Handles ButtonX3.Click
        Me.SuperGridControl.PrimaryGrid.SelectAll()
        Me.SuperGridControl.PrimaryGrid.CopySelectedCellsToClipboard(True, False)



        Dim xlapp As New Excel.Application
        xlapp.Visible = True
        Dim xlbk As Excel.Workbook = xlapp.Workbooks.Add
        Dim xlsheet As Excel.Worksheet = CType(xlbk.Sheets(1), Microsoft.Office.Interop.Excel.Worksheet)

        xlsheet.Range("a1").Select()
        xlsheet.Range("a1").PasteSpecial()
    End Sub
End Class