Imports System.Data.OleDb
Imports System.IO
Imports System.Reflection
Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.SuperGrid
Imports DevComponents.DotNetBar.SuperGrid.Style
Public Class Form_Detail_equipement_alimentation

    Private Sub Form_Detail_equipement_alimentation_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'MydbDataSet.departs' table. You can move, or remove it, as needed.
        Me.DepartsTableAdapter.Fill(Me.MydbDataSet.departs)
        'TODO: This line of code loads data into the 'MydbDataSet.lst_alim_equip' table. You can move, or remove it, as needed.
        Me.Lst_alim_equipTableAdapter.Fill(Me.MydbDataSet.lst_alim_equip)
        'TODO: This line of code loads data into the 'MydbDataSet.segregations' table. You can move, or remove it, as needed.
        Me.SegregationsTableAdapter.Fill(Me.MydbDataSet.segregations)
        'TODO: This line of code loads data into the 'MydbDataSet.cables' table. You can move, or remove it, as needed.
        Me.CablesTableAdapter.Fill(Me.MydbDataSet.cables)
        'TODO: This line of code loads data into the 'MydbDataSet.borniers' table. You can move, or remove it, as needed.
        Me.BorniersTableAdapter.Fill(Me.MydbDataSet.borniers)
        'TODO: This line of code loads data into the 'MydbDataSet.equipements' table. You can move, or remove it, as needed.
        Me.EquipementsTableAdapter.Fill(Me.MydbDataSet.equipements)

        SuperGridControl1.PrimaryGrid.DataSource = Me.MydbDataSet
        SuperGridControl1.PrimaryGrid.DataMember = "equipements"

    End Sub

    Private Sub SuperGridControl1DataBindingComplete(ByVal sender As Object, ByVal e As GridDataBindingCompleteEventArgs)
        Dim panel As GridPanel = e.GridPanel

        panel.GroupByRow.Visible = True

        Select Case panel.DataMember
            Case "Customers"
                CustomizeCustomerPanel(panel)

            Case "Orders"
                CustomizeOrdersPanel(panel)

            Case "Order Details"
                CustomizeDetailsPanel(panel)
        End Select
    End Sub
    Private Sub CustomizeCustomerPanel(ByVal panel As GridPanel)
        panel.FrozenColumnCount = 1
        panel.ColumnHeader.RowHeight = 30

        panel.Columns(0).GroupBoxEffects = GroupBoxEffects.None
        panel.Columns("Region").NullString = "<no locale>"

        panel.Columns(0).CellStyles.Default.Background = New Background(Color.AliceBlue)

        For Each column As GridColumn In panel.Columns
            column.ColumnSortMode = ColumnSortMode.Multiple
        Next column
    End Sub

#Region "CustomizeOrdersPanel"

    ''' <summary>
    ''' Customizes the OrdersPanel
    ''' </summary>
    ''' <param name="panel"></param>
    Private Sub CustomizeOrdersPanel(ByVal panel As GridPanel)
        panel.ShowRowGridIndex = True
        panel.ShowRowDirtyMarker = True
        panel.ColumnHeader.RowHeight = 30

        panel.Columns(0).CellStyles.Default.Background = New Background(Color.Beige)

        panel.Caption = New GridCaption()

        panel.Caption.Text = String.Format("Orders ({0}) for customer <font color=""Maroon""><i>""{1}</i>""</font>", panel.Rows.Count, CType(panel.Parent, GridRow)("CompanyName").Value)

        panel.DefaultVisualStyles.CaptionStyles.Default.Alignment = Alignment.MiddleLeft

    End Sub

#End Region

    ''' <summary>
    ''' Customizes the DetailsPanel
    ''' </summary>
    ''' <param name="panel"></param>
    Private Sub CustomizeDetailsPanel(ByVal panel As GridPanel)
        panel.ColumnHeader.RowHeight = 30

        panel.Columns(0).CellStyles.Default.Background = New Background(Color.LavenderBlush)

        panel.Columns("OrderID").CellStyles.Default.Alignment = Alignment.MiddleLeft

        panel.DefaultVisualStyles.CaptionStyles.Default.Alignment = Alignment.MiddleLeft
        panel.DefaultVisualStyles.CellStyles.Default.Alignment = Alignment.MiddleRight

    End Sub

    Private Sub Lst_alim_equipDataGridViewX_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Lst_alim_equipDataGridViewX.CellDoubleClick
        Dim row As MydbDataSet.lst_alim_equipRow
        row = CType(CType(Lst_alim_equipBindingSource.Current, DataRowView).Row, MydbDataSet.lst_alim_equipRow)
        Dim FormEquipement As FormEquipement
        FormEquipement = New FormEquipement
        FormEquipement.MdiParent = Me.ParentForm
        FormEquipement.WindowState = FormWindowState.Maximized
        FormEquipement.mode = False

        FormEquipement.value2 = row.idequipement 'crow.Item(0).ToString

        FormEquipement.Show()
    End Sub
End Class