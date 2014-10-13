Imports System.Drawing.Drawing2D
Imports DevComponents.DotNetBar.SuperGrid
Imports DevComponents.DotNetBar.SuperGrid.Style
Imports DevComponents.DotNetBar
Imports System.Threading
Imports DevComponents.DotNetBar.Controls
Imports System.ComponentModel
Imports Microsoft.VisualBasic
Imports DevComponents.DotNetBar.Rendering

Public Class FormLstTroncons
    Inherits OfficeForm
    Public dataSet As DataSet
    Dim column As DataColumn
    Dim _row As DataRow
    Dim PrimaryKeyColumns(0) As DataColumn
    Dim _state As Boolean

    Public DocumentChanged As Boolean = False
    Dim lt4 As DataTable = New DataTable("troncons")
    Dim lt5 As DataTable = New DataTable("discrim")
#Region "load"

    Private Sub FormLstTroncons_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ButtonX2_Click(sender As System.Object, e As System.EventArgs) Handles ButtonX2.Click
        Me.SuperGridControl1.PrimaryGrid.DetachDataSource(True)
        _dataload = New Thread(AddressOf Bindingdata)
        '  _dataload.IsBackground = True
        _dataload.Start()

    End Sub

    Private Sub Bindingdata()

        'Dim t As Bouleanstate2
        't = New Bouleanstate2(AddressOf Progbarstart2)
        't(True)
        ' progbarstart2(True)
        ' System.Threading.Thread.Sleep(1000)
        'Me.Lst_tronconsTableAdapter.Connection.Close()
        'Me.Lst_tronconsTableAdapter.Connection.ConnectionString = ClassConnectionBuilder.ConnectionStringBuilder( formmain.user.server,formmain.user.Project_user, "root",formmain.user.pass_user)
        'Me.Lst_tronconsTableAdapter.Connection.Open()
        'Me.SuperGridControl1.PrimaryGrid.VirtualRowCount = 0
        '
        Me.Lst_tronconsTableAdapter.Fill(Me.MydbDataSet.lst_troncons)
        Me.SuperGridControl1.PrimaryGrid.DataSource = Me.Lst_tronconsBindingSource
        '   Me.SuperGridControl1.PrimaryGrid.VirtualRowCount = Me.MydbDataSet.lst_troncons.Rows.Count

        '  Me.SuperGridControl1.ResetBindings()
        '   Me.SuperGridControl1.PrimaryGrid.BeginDataUpdate()
        ' Me.SuperGridControl1.PrimaryGrid.EndDataUpdate()
        '  Me.SuperGridControl1.PrimaryGrid.DataSource = Me.Lst_tronconsBindingSource
        ' progbarstart2(False)
        't(False)

    End Sub

    Private Sub Progbarstart2(ByVal state As Boolean)
        If Me.InvokeRequired Then
            Me.Invoke(New Bouleanstate2(AddressOf Progbarstart2), New Object() {state})
        Else
            If state Then
                '  Me.SuperGridControl1.PrimaryGrid.ColumnAutoSizeMode = ColumnAutoSizeMode.AllCellsExceptHeader
                Me.ProgressBarX1.Visible = True

            Else
                Me.ProgressBarX1.Visible = False

                ' Me.SuperGridControl1.PrimaryGrid.ColumnAutoSizeMode = ColumnAutoSizeMode.NotSet
                '  Me.SuperGridControl1.AutoSize = True
            End If
        End If

    End Sub
    Private Delegate Sub Bouleanstate2(ByVal state As Boolean)
    Private _dataload As Thread
#End Region
    Private Sub RenderSliderBackground(ByVal e As GridPostRenderCellEventArgs)
        If (e.RenderParts And RenderParts.Background) = RenderParts.Background Then
            If Not IsDBNull(e.GridCell.Value) Then

                If CInt(Fix(e.GridCell.Value)) > 70 Then
                    Using br As Brush = New LinearGradientBrush(e.Bounds, Color.Transparent, Color.Red, 0.0F)
                        e.Graphics.FillRectangle(br, e.Bounds)
                    End Using
                    Dim pbx As GridProgressBarXEditControl = TryCast(e.GridCell.GridColumn.EditControl, GridProgressBarXEditControl)

                    If pbx IsNot Nothing Then

                        If CInt(Fix(e.GridCell.Value)) > 70 Then

                            SuperGridControl1.PrimaryGrid.Columns(12).InvalidateRender()
                            SuperGridControl1.PrimaryGrid.Columns(15).InvalidateRender()
                        Else
                            pbx.ForeColor = Color.Green
                            pbx.TextVisible = True
                        End If
                    End If
                End If
            End If
        End If

    End Sub

#Region "Calculs troncons"
    Private Shared event_1 As New AutoResetEvent(True)
    Private _calcTroncons As Thread
    Private Delegate Sub Bouleanstate(ByVal state As Boolean)
    Private Sub ButtonX1_Click_2(sender As System.Object, e As System.EventArgs) Handles ButtonX1.Click

        Dim info As TaskDialogInfo
        info = New TaskDialogInfo("Calcul Taux de remplissage", eTaskDialogIcon.Exclamation, "Generation des calculs ", formmain.user.nom & " Voullez-vous Regener les calculs ?", eTaskDialogButton.Ok Or eTaskDialogButton.Cancel, eTaskDialogBackgroundColor.Red)

        Dim result As eTaskDialogResult = TaskDialog.Show(info)
        Select Case result

            Case eTaskDialogResult.Ok
                _calcTroncons = New Thread(AddressOf btnCalculTauxDeRemplissage_Click)
                '   _calcTroncons.IsBackground = True
                _calcTroncons.Start()
            Case eTaskDialogResult.Cancel
                Exit Sub

        End Select

        'Dim resul = MessageBox.Show("Voullez-vous Regener les calculs", "Calcul Taux de remplissage", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        'Select Case resul

        '    Case DialogResult.Yes

        '        _calcTroncons = New Thread(AddressOf btnCalculTauxDeRemplissage_Click)
        '        _calcTroncons.IsBackground = True
        '        _calcTroncons.Start()

        '    Case DialogResult.No
        'End Select

    End Sub

    Private Sub btnCalculTauxDeRemplissage_Click()
        Dim t As Bouleanstate
        t = New Bouleanstate(AddressOf Progbarstart)
        t(True)
        ' progbarstart(True)
        Dim items As DataRow
        Dim grow As GridRow = New GridRow()

        Dim irow As Integer
        Dim crow As DataRowView
        Dim a As Integer
        Dim drow As DataRow
        Dim tremp As Double
        Dim tremp2 As Double
        Dim trempf As Double
        Dim tremp2f As Double
        lt4.Clear()
        Me.TronconsTableAdapter.Connection.Close()
        Me.TronconsTableAdapter.Connection.ConnectionString = ClassConnectionBuilder.ConnectionStringBuilder(FormMain.user.server, FormMain.user.Project_user, "root", FormMain.user.pass_user)
        Me.TronconsTableAdapter.Connection.Open()
        'selection liste de l'ensemble des tronçons
        For Each grow In Me.SuperGridControl1.GetSelectedRows
            irow = Me.Lst_tronconsBindingSource.Find("idtroncons", grow.Cells(0).Value.ToString)
            Me.Lst_tronconsBindingSource.Position = irow
            crow = CType(Me.Lst_tronconsBindingSource.Item(irow), DataRowView)

            drow = lt4.NewRow
            drow("id") = crow.Item(0).ToString
            drow("l1") = (CDbl(crow.Item(5).ToString) - CDbl(crow.Item(25).ToString))
            drow("S1") = CDbl(crow.Item(7).ToString)
            drow("forme") = crow.Item(11).ToString
            drow("diametre") = CDbl(crow.Item(14).ToString)
            drow("type") = crow.Item(17).ToString
            drow("reserve") = crow.Item(9).ToString
            drow("reserve2") = crow.Item(10).ToString
            drow("nbcouche") = crow.Item(24).ToString

            lt4.Rows.Add(drow)

        Next
        'pour chaque troncons <> discrimination =1
        a = lt4.Rows.Count - 1
        System.Threading.Thread.Sleep(1000)
        Me.TronconsTableAdapter.Fill(Me.MydbDataSet.troncons)

        Dim dictionary As New Dictionary(Of String, Integer)
        Dim dictionary2 As New Dictionary(Of String, Integer)

        Do While a > -1
            Dim masse As Integer = 0
            tremp = 0
            tremp2 = 0

            dictionary.Clear()
            dictionary2.Clear()
            lt5.Clear()
            If lt4.Rows(a).Item(3).ToString = "Cercle" Then
                Me.Cables_troncon_idTableAdapter.Fill(Me.MydbDataSet.cables_troncon_id, CType(lt4.Rows(a).Item(0), Integer?))

                For Each item In Me.MydbDataSet.cables_troncon_id
                    tremp2 = CDbl(tremp2 + (Math.PI * (Math.Pow(CDbl((CInt(item.diametre))), 2) / 4)))

                Next

                tremp2f = Math.Round((tremp2 * 1.5 * 100) / ((Math.PI * (Math.Pow((CDbl(lt4.Rows(a).Item(4).ToString())), 2) / 4))))

                trempf = 0

            ElseIf lt4.Rows(a).Item(5).ToString = "TREMIE" Then

                Me.Cables_troncon_idTableAdapter.Fill(Me.MydbDataSet.cables_troncon_id, CType(lt4.Rows(a).Item(0), Integer?))

                For Each item In Me.MydbDataSet.cables_troncon_id

                    ' test variable r et r2 si vide  r1 et  r 2 = 50

                    'select lst cables / troncon avec les datas

                    tremp2 = CDbl(tremp2 + Math.Pow((CInt(item.diametre)), 2))

                Next

                tremp2f = Math.Round((tremp2 * 100) / (CDbl(lt4.Rows(a).Item(2).ToString) * CDbl(lt4.Rows(a).Item(1).ToString)))

                trempf = 0

            Else

                Me.Cables_troncon_idTableAdapter.Fill(Me.MydbDataSet.cables_troncon_id, CType(lt4.Rows(a).Item(0), Integer?))
                Me.TronconsBindingSource.Position = Me.TronconsBindingSource.Find("idtroncons", CType(lt4.Rows(a).Item(0), Integer?))
                Dim row_troncon As mydbDataSet.tronconsRow
                row_troncon = CType(CType(Me.TronconsBindingSource.Current, DataRowView).Row, mydbDataSet.tronconsRow)
                'calcul masse troncon

                Dim row As mydbDataSet.cables_troncon_idRow
                For Each row In MydbDataSet.cables_troncon_id
                    Dim veris As String = row_troncon.repere_troncon
                    row = CType(CType(Me.Cables_troncon_idBindingSource.Current, DataRowView).Row, mydbDataSet.cables_troncon_idRow)
                    masse = CInt(masse + (CInt(row.masse) * (CInt(row_troncon.longueur) / 1000)))

                Next

                masse = CInt(masse / (CInt(row_troncon.longueur) / 1000))

                For Each item In Me.MydbDataSet.cables_troncon_id

                    ' test variable r et r2 si vide  r1 et  r 2 = 50

                    'select lst cables / troncon avec les datas
                    Select Case item.mode_de_pose
                        Case True

                            If item.trefle = True Then

                                If dictionary.ContainsKey(item.repere_cable) Then
                                    dictionary.Item(item.repere_cable) = dictionary.Item(item.repere_cable) + 1
                                Else
                                    dictionary.Add(item.repere_cable, +1)
                                    dictionary2.Add(item.repere_cable, +1)
                                End If
                                drow = lt5.NewRow
                                drow("id") = item.repere_cable
                                drow("diametre") = item.diametre

                                Dim test As DataRow
                                test = lt5.Rows.Find(item.repere_cable)
                                If test Is Nothing Then
                                    lt5.Rows.Add(drow)

                                End If

                            Else
                                tremp = tremp + CDbl(item.diametre)
                            End If

                        Case False

                            If item.mode_de_pose3 = True Then
                                '  tremp2 = CDbl(tremp2 + Math.Pow((CInt(item.diametre)), 2))
                                tremp2 = CDbl(tremp2 + CDbl(item.diametre))
                            End If

                    End Select
                    'select cas :

                Next

                Dim test2 As Double

                For Each item In dictionary2
                    test2 = dictionary.Item(item.Key)

                    dictionary.Item(item.Key) = CInt((dictionary.Item(item.Key) * 2) / 3)

                Next

                For Each items In lt5.Rows

                    ' items(0).ToString()
                    If dictionary.ContainsKey(items(0).ToString) Then

                        tremp = tremp + (dictionary.Item(items(0).ToString) * CInt(items(1).ToString))

                    End If
                Next

                If lt4.Rows(a).Item(7).ToString = "" Then lt4.Rows(a).Item(7) = "0"
                If CDbl(lt4.Rows(a).Item(6).ToString) = 0 Then
                    trempf = 0
                Else
                    trempf = Math.Round((tremp * 100) / (CDbl(lt4.Rows(a).Item(1).ToString) * (CDbl(lt4.Rows(a).Item(6).ToString) / 100)))
                End If
                If CDbl(lt4.Rows(a).Item(7).ToString) = 0 Then
                    tremp2f = 0
                Else
                    tremp2f = Math.Round((tremp2 * 100) / ((CDbl(lt4.Rows(a).Item(8).ToString) * CDbl(lt4.Rows(a).Item(1).ToString)) * (CDbl(lt4.Rows(a).Item(7).ToString) / 100)))
                End If

            End If

            Dim erows As DataRowView
            erows = CType(Me.TronconsBindingSource.Item(Me.TronconsBindingSource.Find("idtroncons", lt4.Rows(a).Item(0).ToString)), DataRowView)

            erows.BeginEdit()
            If Double.IsNaN(trempf) Then trempf = 0
            If Double.IsNaN(tremp2f) Then tremp2f = 0
            erows("reserve_cal") = trempf
            erows("reserve2_cal") = tremp2f
            'erows("") = ""
            ' erows("") = ""
            erows("Masse_calcule") = masse
            erows("qui") = formmain.user.Nom_user
            erows("date_calcul") = DateTime.Today.ToString("g")
            erows.EndEdit()
            ' erows.Row.AcceptChanges()
            Me.TronconsBindingSource.EndEdit()

            Me.TronconsTableAdapter.Update(Me.MydbDataSet.troncons)
            Me.TronconsTableAdapter.Fill(Me.MydbDataSet.troncons)
            a = a - 1
        Loop

       ' Me.SuperGridControl1.PrimaryGrid.DetachDataSource(True)
        ' Me.SuperGridControl1.PrimaryGrid.VirtualRowCount = 0
        Me.Lst_tronconsTableAdapter.Fill(Me.MydbDataSet.lst_troncons)
        '   Me.SuperGridControl1.PrimaryGrid.VirtualRowCount = Me.MydbDataSet.lst_troncons.Rows.Count

        t(False)

    End Sub

    Private Sub Progbarstart(ByVal state As Boolean)
        If Me.InvokeRequired Then
            Me.Invoke(New Bouleanstate(AddressOf Progbarstart), New Object() {state})
        Else
            If state Then
                Me.ProgressBarX1.Visible = True
                Me.ProgressBarX1.Text = "Calculs des tronçons en cours ... Veuillez Patienter"
            Else
                Me.ProgressBarX1.Visible = False
            End If
        End If

    End Sub

#End Region

    'Private Sub ButtonX1_Click(sender As System.Object, e As System.EventArgs)
    '    'Dim irow As Integer = Me.SuperGridControl2.ActiveRow.RowIndex
    '    Me.Lst_tronconsTableAdapter.ClearBeforeFill = True
    '    '   Me.Lst_tronconsTableAdapter.Fill(Me.MydbDataSet.lst_troncons)
    '    '
    '    'Me.MydbDataSet.Clear()
    '    Me.Lst_tronconsTableAdapter.Fill(Me.MydbDataSet.lst_troncons)
    '    Me.Lst_tronconsBindingSource.DataSource = Me.MydbDataSet.lst_troncons
    '    '   Me.Lst_tronconsBindingSource.Position = irow
    '    '   Me.Lst_tronconsBindingSource.ResetBindings(False)
    '    '   Me.SuperGridControl2.Refresh()
    'End Sub

    'Private Sub ButtonX1_Click_1(sender As System.Object, e As System.EventArgs)
    '    '  If Me.ButtonX1.Text = "Annuler Calcul" Then
    '    '  Me.Timer1.Start()
    '    ''   Me.btnCalculTauxDeRemplissage.Enabled = False
    '    'Me.ButtonX1.Text = "Activer Mode Calcul"
    '    '    Else
    '    '  Me.Timer1.Stop()
    '    '   Me.btnCalculTauxDeRemplissage.Enabled = True
    '    '   Me.ButtonX1.Text = "Annuler Calcul"
    '    '   End If
    'End Sub

    Private Sub FormClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed

        Dim mdi As FormMain = TryCast(Me.ParentForm, FormMain)
        ' mdi.labelPosition.Text = ""
        '  Me.Lst_tronconsTableAdapter.Connection.Close()
        GC.Collect()
        Me.Dispose()
    End Sub

    Private Sub FormClosing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If Me.DocumentChanged Then
            Dim dlg As System.Windows.Forms.DialogResult = MessageBoxEx.Show(Me, "Document has changed. Save changes?", "Notepad", MessageBoxButtons.YesNoCancel)
            If dlg = System.Windows.Forms.DialogResult.Cancel Then
                e.Cancel = True
            ElseIf dlg = System.Windows.Forms.DialogResult.Yes Then

            End If
        End If

    End Sub

    ''' <summary>
    ''' Waiting_bars
    ''' </summary>

    ''' <summary>
    ''' Handles the Shown event of the FormLstTroncons control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    '   Private Sub FormLstTroncons_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
    '      Me.ProgressBarX1.Visible = True
    '     Me.CircularProgress1.Visible = True
    '    If Not Actualisation_Data.IsBusy Then
    '        Me.Actualisation_Data.RunWorkerAsync()
    '    End If
    ' End Sub

    Private Sub Actualisation_Data_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles Actualisation_Data.DoWork
        If Actualisation_Data.CancellationPending Then
            ' Set Cancel to True
            e.Cancel = True
            Exit Sub
        End If
        'Me.MydbDataSet.lst_troncons.Clear()
        ' Me.TronconsTableAdapter.Connection.Close()

        Me.Lst_tronconsTableAdapter.Fill(Me.MydbDataSet.lst_troncons)
        ' Me.Lst_tronconsBindingSource.DataSource = Me.MydbDataSet.lst_troncons
        'Me.Lst_tronconsBindingSource.ResetBindings(False)
        '  Me.SuperGridControl1.PrimaryGrid.BeginDataUpdate()
        '  Me.SuperGridControl1.PrimaryGrid.EndDataUpdate()

        '    Me.SuperGridControl1.PrimaryGrid.DataSource = Me.Lst_tronconsBindingSource

        ' Me.Lst_tronconsBindingSource.DataSource = MydbDataSet.lst_troncons
        For i = 1 To 100
            'System.Threading.Thread.Sleep(10)
            Actualisation_Data.ReportProgress(i)
        Next
    End Sub

    Private Sub Actualisation_Data_ProgressChanged(sender As System.Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles Actualisation_Data.ProgressChanged
        Me.ProgressBarX1.Value = e.ProgressPercentage

    End Sub

    Private Sub Actualisation_Data_RunWorkerCompleted(sender As System.Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles Actualisation_Data.RunWorkerCompleted
        ' Me.Lst_tronconsBindingSource.DataSource = Me.MydbDataSet.lst_troncons
        'Me.SuperGridControl1.Refresh()
        '.SuperGridControl2.PrimaryGrid.BeginDataUpdate()
        ' .SuperGridControl2.PrimaryGrid.EndDataUpdate()

        Me.ProgressBarX1.Visible = False
        SuperGridControl1.PrimaryGrid.Columns(12).InvalidateRender()
        SuperGridControl1.PrimaryGrid.Columns(15).InvalidateRender()
    End Sub

    Private Sub MajData(sender As System.Object, e As System.EventArgs)
        If Not Me.Actualisation_Data.IsBusy Then
            Me.SuperGridControl1.DataBindings.Clear()
            Me.Actualisation_Data.RunWorkerAsync()

        End If
    End Sub

#Region " IDisposable Object .."
    Public Class ObjectDisposeClass
        Implements IDisposable
        Private disposedValue As Boolean = False

        Public Sub Dispose() Implements IDisposable.Dispose
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub

        Protected Overridable Sub Dispose(ByVal disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    ' TODO: free unmanaged resources when explicitly called
                End If
                ' TODO: free shared unmanaged resources
            End If
            Me.disposedValue = True
        End Sub
    End Class
#End Region

    'Private Sub Button1_Click(sender As System.Object, e As System.EventArgs)
    '    Dim grow As GridRow

    '    Dim irow As Integer
    '    '
    '    grow = CType(Me.SuperGridControl1.PrimaryGrid.ActiveRow, GridRow)
    '    irow = Me.Lst_tronconsBindingSource.Find("idtroncons", grow.Cells(0).Value.ToString)
    '    Me.Lst_tronconsTableAdapter.Fill(Me.MydbDataSet.lst_troncons)
    '    Me.Lst_tronconsBindingSource.Position = irow
    '    Me.Lst_tronconsBindingSource.ResetBindings(False)
    'End Sub

    Private Sub SuperGridControl1_DoubleClick(sender As System.Object, e As DevComponents.DotNetBar.SuperGrid.GridRowDoubleClickEventArgs) Handles SuperGridControl1.RowDoubleClick
        Dim grow As GridRow

        Dim irow As Integer
        Dim crow As DataRowView

        Dim formTroncon As FormTroncon
        formTroncon = New FormTroncon
        formTroncon.MdiParent = Me.ParentForm
        formTroncon.WindowState = FormWindowState.Maximized
        formTroncon.mode = False

        grow = CType(e.GridRow, GridRow)
        irow = Me.Lst_tronconsBindingSource.Find("idtroncons", grow.Cells(0).Value.ToString)
        Me.Lst_tronconsBindingSource.Position = irow
        crow = CType(Me.Lst_tronconsBindingSource.Item(irow), DataRowView)

        formTroncon.value = crow.Item(0).ToString

        formTroncon.Show()
    End Sub

    'Private Sub SuperGridControl1PostRenderCell(ByVal sender As Object, ByVal e As GridPostRenderCellEventArgs) Handles SuperGridControl1.PostRenderCell
    '    If e.GridCell.ColumnIndex = 12 Or e.GridCell.ColumnIndex = 15 Then

    '        RenderSliderBackground(e)

    '    End If
    'End Sub

    'Private Sub RenderProgressBugs(ByVal e As GridPostRenderCellEventArgs)
    '    'If (e.RenderParts And RenderParts.Content) = RenderParts.Content Then
    '    Dim pbx As GridProgressBarXEditControl = TryCast(e.GridCell.GridColumn.EditControl, GridProgressBarXEditControl)

    '    If pbx IsNot Nothing Then
    '        Select Case pbx.Value
    '            Case 0
    '                '  pbx.ChunkGradientAngle = 50

    '                pbx.ChunkColor = Color.Green
    '                pbx.ChunkColor2 = Color.Red
    '                pbx.TextVisible = True
    '                '  pbx.Text = "Not Started"
    '                pbx.ColorTable = eProgressBarItemColor.Normal
    '                ' pbx.ProgressType = eProgressItemType.Marquee
    '                Exit Select

    '            Case 100
    '                '   pbx.Text = "Completed"
    '                '  pbx.ChunkGradientAngle = 50
    '                pbx.TextVisible = True
    '                pbx.ColorTable = eProgressBarItemColor.Error
    '                pbx.ChunkColor = Color.Green
    '                pbx.ChunkColor2 = Color.Red
    '                pbx.Text = pbx.Value.ToString
    '                Exit Select
    '            Case Else
    '                '  pbx.ChunkGradientAngle = 50
    '                ' pbx.ProgressType = eProgressItemType.Marquee
    '                pbx.ChunkColor = Color.Green
    '                pbx.ChunkColor2 = Color.Red
    '                pbx.TextVisible = True
    '                pbx.Text = pbx.Value.ToString
    '                'pbx.Text = ""
    '                pbx.ColorTable = eProgressBarItemColor.Normal
    '                Exit Select
    '        End Select

    '        If pbx.Value > 70 Then

    '            pbx.ChunkColor = Color.Green
    '            pbx.ChunkColor2 = Color.Red
    '            pbx.TextVisible = True
    '            pbx.Text = pbx.Value.ToString
    '            pbx.ColorTable = eProgressBarItemColor.[Error]

    '        End If
    '    End If
    '    'End If

    'End Sub

    'Private Sub SuperGridControl1GetRenderer(ByVal sender As Object, ByVal e As GridGetRendererEventArgs) Handles SuperGridControl1.GetRenderer
    '    Dim columnIndex As Integer = e.GridCell.ColumnIndex

    '    ' Just as an example, lets have all CheckBox cells, whose
    '    ' adjacent SwitchButton cell is 'true', to render as a textual
    '    ' value, instead of the normal checkbox display.

    '    'If columnIndex = 22 Then
    '    '    Dim scell As GridCell = e.GridCell.GridRow.Cells(22)

    '    '    e.RenderType = CType(IIf(CBool(scell.Value) = True, GetType(GridTextBoxXEditControl), Nothing), Type)
    '    'End If
    'End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

            Me.Lst_tronconsTableAdapter.Connection.Close()
        Me.Lst_tronconsTableAdapter.Connection.ConnectionString = ClassConnectionBuilder.ConnectionStringBuilder(FormMain.user.server, FormMain.user.Project_user, "root", FormMain.user.pass_user)
        Me.Lst_tronconsTableAdapter.Connection.Open()
 Me.Lst_tronconsTableAdapter.Fill(Me.MydbDataSet.lst_troncons)
            Dim panel As GridPanel = superGridControl1.PrimaryGrid

          '  panel.VirtualMode = True

        'Me.Lst_tronconsTableAdapter.Fill(Me.MydbDataSet.lst_troncons)

        '' Me.SuperGridControl1.PrimaryGrid.DetachDataSource(True)
        Me.SuperGridControl1.PrimaryGrid.DataSource = Me.Lst_tronconsBindingSource
        InitializeGrid()
        ' Add any initialization after the InitializeComponent() call.
       '  RemoveHandler SuperGridControl1.PostRenderCell, AddressOf X2Progress_BeforeCellPaint
    End Sub
       Private Sub InitializeGrid()
            Dim panel As GridPanel = superGridControl1.PrimaryGrid

            ' Set both the Slider and SitchButton columns to
            ' our own defined EditControls

            Dim column As GridColumn = panel.Columns("Reserve_cal")

   column.EditorType = GetType(MyGridProgressBarXEditControl)

            column = panel.Columns("reserve2_cal")
            column.EditorType = GetType(MyGridProgressBarXEditControl)

        End Sub
#Region "X2Progress_Initialize"

    ''' <summary>
    ''' Initializes our X2 "Progress" environment
    ''' </summary>
    'Private Sub X2Progress_Initialize()
    '    Dim pb As GridProgressBarXEditControl = TryCast(e.GridCell.GridColumn.EditControl, GridProgressBarXEditControl)

    '  '   Hook onto the BeforeCellPaint event so we can
    '  '   demonstrate cell customization

    '    If pb IsNot Nothing Then
    '        AddHandler pb, AddressOf X2Progress_BeforeCellPaint
    '    End If
    'End Sub

#Region "X2Progress_BeforeCellPaint"

    ''' <summary>
    ''' Handles X2 "Progress" BeforeCellPaint events
    ''' </summary>
    ''' <param name="sender">DataGridViewProgressBarXColumn</param>
    ''' <param name="e">BeforeCellPaintEventArgs</param>
    'Private Sub X2Progress_BeforeCellPaint(ByVal sender As Object, ByVal e As GridPostRenderCellEventArgs)' Handles SuperGridControl1.PostRenderCell
    '    Dim pbc As GridProgressBarXEditControl = TryCast(e.GridCell.GridColumn.RenderControl, GridProgressBarXEditControl)

    '    If pbc IsNot Nothing Then
    '        Select Case pbc.Value
    '            Case 0
    '                pbc.Text = pbc.Value.ToString
    '                pbc.TextVisible = True
    '                  pbc.ColorTable = eProgressBarItemColor.Normal
    '                Exit Select

    '            Case > 69
    '                pbc.Text = pbc.Value.ToString '"Warning"
    '                pbc.TextVisible = True
    '                pbc.ColorTable = eProgressBarItemColor.Error
    '                Exit Select
    '            Case Nothing
    '                pbc.Text = "Non Calculé"
    '                pbc.TextVisible = True
    '            Case Else

    '                pbc.Text = pbc.Value.ToString
    '                pbc.TextVisible = True
    '                pbc.ColorTable = eProgressBarItemColor.Normal
    '                Exit Select
    '        End Select

    '        'If pbc.Value > 70 Then
    '        '    pbc.Text = "Warning"
    '        '    pbc.TextVisible = True
    '        '    pbc.ColorTable = eProgressBarItemColor.[Error]
    '        'End If

    '    End If
    'End Sub

#End Region

#End Region

    Private Sub SwitchButton1_ValueChanged(sender As Object, e As EventArgs) Handles SwitchButton1.ValueChanged
        If SwitchButton1.Value Then
            SuperGridControl1.PrimaryGrid.GridPanel.Columns("longueur").Visible = True
            SuperGridControl1.PrimaryGrid.GridPanel.Columns("largeur").Visible = True
            SuperGridControl1.PrimaryGrid.GridPanel.Columns("hauteur").Visible = True
            SuperGridControl1.PrimaryGrid.GridPanel.Columns("elevation").Visible = True
            SuperGridControl1.PrimaryGrid.GridPanel.Columns("diametre").Visible = True
            SuperGridControl1.PrimaryGrid.GridPanel.Columns("version").Visible = True
            SuperGridControl1.PrimaryGrid.GridPanel.Columns("qui").Visible = True
            SuperGridControl1.PrimaryGrid.GridPanel.Columns("margesH").Visible = True
            SuperGridControl1.PrimaryGrid.GridPanel.Columns("margesL").Visible = True
            SuperGridControl1.PrimaryGrid.GridPanel.Columns("2-reserve2_cal").Visible = True
            SuperGridControl1.PrimaryGrid.GridPanel.Columns("2-reserve_cal").Visible = True

        Else

            SuperGridControl1.PrimaryGrid.GridPanel.Columns("longueur").Visible = False
            SuperGridControl1.PrimaryGrid.GridPanel.Columns("largeur").Visible = False
            SuperGridControl1.PrimaryGrid.GridPanel.Columns("hauteur").Visible = False
            SuperGridControl1.PrimaryGrid.GridPanel.Columns("elevation").Visible = False
            SuperGridControl1.PrimaryGrid.GridPanel.Columns("diametre").Visible = False
            SuperGridControl1.PrimaryGrid.GridPanel.Columns("version").Visible = False
            SuperGridControl1.PrimaryGrid.GridPanel.Columns("qui").Visible = False
            SuperGridControl1.PrimaryGrid.GridPanel.Columns("margesH").Visible = False
            SuperGridControl1.PrimaryGrid.GridPanel.Columns("margesL").Visible = False
            SuperGridControl1.PrimaryGrid.GridPanel.Columns("2-reserve2_cal").Visible = False
            SuperGridControl1.PrimaryGrid.GridPanel.Columns("2-reserve_cal").Visible = False
        End If
    End Sub

    Private Sub FormLstTroncons_Shown(sender As Object, e As EventArgs) Handles Me.Shown

         '_dataload = New Thread(AddressOf Bindingdata)
         ''  _dataload.IsBackground = True
         '_dataload.Start()
        column = New DataColumn()
        column.DataType = System.Type.GetType("System.Int32")
        column.ColumnName = "id"
        column.AutoIncrement = False
        column.Caption = "ref_trc"
        column.ReadOnly = False
        column.Unique = False

         ' Add the column to the table.
        lt4.Columns.Add(column)

        column = New DataColumn()
        column.DataType = System.Type.GetType("System.Double")
        column.ColumnName = "l1"
        column.AutoIncrement = False
        column.Caption = "l50"
        column.ReadOnly = False
        column.Unique = False

         ' Add the column to the table.
        lt4.Columns.Add(column)

        column = New DataColumn()
        column.DataType = System.Type.GetType("System.Double")
        column.ColumnName = "s1"
        column.AutoIncrement = False
        column.Caption = "s50"
        column.ReadOnly = False
        column.Unique = False

         ' Add the column to the table.
        lt4.Columns.Add(column)

        column = New DataColumn()
        column.DataType = System.Type.GetType("System.String")
        column.ColumnName = "forme"
        column.AutoIncrement = False
        column.Caption = "forme"
        column.ReadOnly = False
        column.Unique = False

         ' Add the column to the table.
        lt4.Columns.Add(column)

        column = New DataColumn()
        column.DataType = System.Type.GetType("System.Double")
        column.ColumnName = "diametre"
        column.AutoIncrement = False
        column.Caption = "diametre"
        column.ReadOnly = False
        column.Unique = False

         ' Add the column to the table.
        lt4.Columns.Add(column)

        column = New DataColumn()
        column.DataType = System.Type.GetType("System.String")
        column.ColumnName = "type"
        column.AutoIncrement = False
        column.Caption = "type"
        column.ReadOnly = False
        column.Unique = False

         ' Add the column to the table.
        lt4.Columns.Add(column)

        column = New DataColumn()
        column.DataType = System.Type.GetType("System.String")
        column.ColumnName = "reserve"
        column.AutoIncrement = False
        column.Caption = "reserve"
        column.ReadOnly = False
        column.Unique = False

         ' Add the column to the table.
        lt4.Columns.Add(column)

        column = New DataColumn()
        column.DataType = System.Type.GetType("System.String")
        column.ColumnName = "reserve2"
        column.AutoIncrement = False
        column.Caption = "reserve2"
        column.ReadOnly = False
        column.Unique = False

         ' Add the column to the table.
        lt4.Columns.Add(column)

        column = New DataColumn()
        column.DataType = System.Type.GetType("System.String")
        column.ColumnName = "nbcouche"
        column.AutoIncrement = False
        column.Caption = "nbcouche"
        column.ReadOnly = False
        column.Unique = False

         ' Add the column to the table.
        lt4.Columns.Add(column)

        PrimaryKeyColumns(0) = lt4.Columns("id")
        lt4.PrimaryKey = PrimaryKeyColumns

         ' Instantiate the DataSet variable.
        dataSet = New DataSet()

         ' Add the new DataTable to the DataSet.
        dataSet.Tables.Add(lt4)

        column = New DataColumn()
        column.DataType = System.Type.GetType("System.String")
        column.ColumnName = "id"
        column.AutoIncrement = False
        column.Caption = "ref_cab_sec"
        column.ReadOnly = False
        column.Unique = True

         ' Add the column to the table.
        lt5.Columns.Add(column)

        column = New DataColumn()
        column.DataType = System.Type.GetType("System.Double")
        column.ColumnName = "diametre"
        column.AutoIncrement = False
        column.Caption = "ref_cab_sec"
        column.ReadOnly = False
        column.Unique = False

         ' Add the column to the table.
        lt5.Columns.Add(column)

        PrimaryKeyColumns(0) = lt5.Columns("id")
        lt5.PrimaryKey = PrimaryKeyColumns

         ' Instantiate the DataSet variable.

         ' Add the new DataTable to the DataSet.
        dataSet.Tables.Add(lt5)

        SuperGridControl1.PrimaryGrid.GridPanel.Columns("longueur").Visible = False
        SuperGridControl1.PrimaryGrid.GridPanel.Columns("largeur").Visible = False
        SuperGridControl1.PrimaryGrid.GridPanel.Columns("hauteur").Visible = False
        SuperGridControl1.PrimaryGrid.GridPanel.Columns("elevation").Visible = False
        SuperGridControl1.PrimaryGrid.GridPanel.Columns("diametre").Visible = False
        SuperGridControl1.PrimaryGrid.GridPanel.Columns("version").Visible = False
        SuperGridControl1.PrimaryGrid.GridPanel.Columns("qui").Visible = False
        SuperGridControl1.PrimaryGrid.GridPanel.Columns("margesH").Visible = False
        SuperGridControl1.PrimaryGrid.GridPanel.Columns("margesL").Visible = False
        SuperGridControl1.PrimaryGrid.GridPanel.Columns("2-reserve2_cal").Visible = False
        SuperGridControl1.PrimaryGrid.GridPanel.Columns("2-reserve_cal").Visible = False
        ' AddHandler SuperGridControl1.PostRenderCell, AddressOf X2Progress_BeforeCellPaint
    End Sub
Private Class MyGridProgressBarXEditControl
            Inherits GridProgressBarXEditControl
            Public Sub New()
                TextVisible = True
            End Sub

            Public Overrides Sub InitializeContext(ByVal cell As GridCell, ByVal style As CellVisualStyle)
                MyBase.InitializeContext(cell, style)

                Text = Value.ToString()

                'Select Case Value
                '    Case 100
                '        ColorTable = eProgressBarItemColor.Normal
                '    Case Else
                '        ColorTable = eProgressBarItemColor.Paused
                'End Select

                'If Value < 30 Then
                '    ColorTable = eProgressBarItemColor.Error
                'End If

             Select Case Value
                Case 0
                  Text = Value.ToString
                      ColorTable = eProgressBarItemColor.Normal
                    Exit Select

                Case > 69

                   Text = Value.ToString
                    ColorTable = eProgressBarItemColor.Error
                    Exit Select
                Case Nothing
                    Text = "Non Calculé"
                    ColorTable = eProgressBarItemColor.Normal

                Case Else

                   Text = Value.ToString

                    ColorTable = eProgressBarItemColor.Normal
                    Exit Select
            End Select
            End Sub
        End Class
End Class