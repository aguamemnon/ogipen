Imports System.Text
Imports System.ComponentModel
Imports Microsoft.VisualBasic
Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Controls
Imports DevComponents.DotNetBar.Rendering
Imports DevComponents.DotNetBar.SuperGrid
Imports DevComponents.DotNetBar.SuperGrid.Style

Public Class FormDispoRaccordement
    Public Filtre1, Filtre2 As Integer

    Public Sub Actualisation()
        'TODO: This line of code loads data into the 'MydbDataSet.lst_rac_tenant' table. You can move, or remove it, as needed.
        Me.Lst_rac_tenantTableAdapter.Fill(Me.MydbDataSet.lst_rac_tenant)
        'TODO: This line of code loads data into the 'MydbDataSet.lst_salles' table. You can move, or remove it, as needed.
        Me.Lst_sallesTableAdapter.Fill(Me.MydbDataSet.lst_salles)
        'TODO: This line of code loads data into the 'MydbDataSet.lst_rac_about' table. You can move, or remove it, as needed.
        Me.Lst_rac_aboutTableAdapter.Fill(Me.MydbDataSet.lst_rac_about)
        'TODO: This line of code loads data into the 'MydbDataSet.lst_dispo_tirage' table. You can move, or remove it, as needed.
        Me.Lst_rac_tenantBindingSource.RemoveFilter()
        If Filtre1 > 0 Then
            Me.Lst_rac_tenantBindingSource.Filter = "salles_idsalle='" & Filtre1 & "'"
            Me.Lst_rac_aboutBindingSource.Filter = "salles_idsalle='" & Filtre1 & "'"
            Me.Lst_sallesBindingSource.Position = Me.Lst_sallesBindingSource.Find("idsalle", Filtre1)
            Me.LabelX3.Text = "Filtre sur :" & CType(CType(Me.Lst_sallesBindingSource.Current, DataRowView).Row, MydbDataSet.lst_sallesRow).repere_salle
            Me.Text = "Raccordement Possible Salle  : " & CType(CType(Me.Lst_sallesBindingSource.Current, DataRowView).Row, MydbDataSet.lst_sallesRow).repere_salle
            Me.LabelX3.Visible = True

        Else
            Me.Text = "Liste Racordement Possible "
            Me.LabelX3.Visible = False
        End If
        maj_data()
    End Sub

    Private Sub FormDispoRaccordement_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Actualisation()
        If Filtre1 > 0 Then
            Me.Lst_rac_tenantBindingSource.Filter = "salles_idsalle='" & Filtre1 & "'"
            Me.Lst_rac_aboutBindingSource.Filter = "salles_idsalle='" & Filtre1 & "'"
            Me.Lst_sallesBindingSource.Position = Me.Lst_sallesBindingSource.Find("idsalle", Filtre1)
            Me.LabelX3.Text = "Filtre sur :" & CType(CType(Me.Lst_sallesBindingSource.Current, DataRowView).Row, MydbDataSet.lst_sallesRow).repere_salle
            Me.LabelX3.Visible = True
            Me.Text = "Raccordement Possible Salle  : " & CType(CType(Me.Lst_sallesBindingSource.Current, DataRowView).Row, MydbDataSet.lst_sallesRow).repere_salle

        Else
            Me.Text = "Liste Racordement Possible "
            Me.LabelX3.Visible = False
        End If
    End Sub

    Private Sub Command1_Executed(sender As System.Object, e As System.EventArgs) Handles Command1.Executed, LabelItem4.Click
        PageSlider1.SelectedPageIndex = 0
    End Sub

    Private Sub Command2_Executed(sender As System.Object, e As System.EventArgs) Handles Command2.Executed, LabelItem5.Click
        PageSlider1.SelectedPageIndex = 1
    End Sub
    Public Sub maj_data()
        Dim thg, thr As Double
        Dim tht, thtr, thtra As Double
        Dim tha, thar, thara As Double
        For Each c In Me.Lst_rac_tenantBindingSource
            Dim cc As MydbDataSet.lst_rac_tenantRow
            cc = CType(CType(c, DataRowView).Row, progelec.MydbDataSet.lst_rac_tenantRow)
            tht += cc.TempRaccTete
            If cc.pose And Not cc.rac Then
                thtr += cc.TempRaccTete
            ElseIf cc.pose And cc.rac Then
                thtra += cc.TempRaccTete
            End If
        Next
        For Each c In Me.Lst_rac_aboutBindingSource
            Dim cc As MydbDataSet.lst_rac_aboutRow
            cc = CType(CType(c, DataRowView).Row, progelec.MydbDataSet.lst_rac_aboutRow)
            tha += cc.TempRaccTete
            If cc.pose And Not cc.rac Then
                thar += cc.TempRaccTete
            ElseIf cc.pose And cc.rac Then
                thara += cc.TempRaccTete
            End If

        Next
        Me.TextBoxItem1.Text = String.Format("{0} Heures", tht)
        Me.TextBoxItem10.Text = String.Format("{0} Heures", tha)
        Me.TextBoxItem14.Text = String.Format("{0} Heures", thtr)
        Me.TextBoxItem11.Text = String.Format("{0} Heures", thar)

        Me.TextBoxItem7.Text = String.Format("{0} Heures", thtra)
        Me.TextBoxItem12.Text = String.Format("{0} Heures", thara)
        Me.TextBoxItem2.Text = String.Format("{0} Heures", tht + tha)
        Me.TextBoxItem16.Text = String.Format("{0} Heures", thtr + thar)
        Me.TextBoxItem3.Text = String.Format("{0} Heures", thtra + thara)
    End Sub

    Public Sub New()

        ' Cet appel est requis par le concepteur.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().
        InitializeGrid()
    End Sub

    Private Sub InitializeGrid()
        Dim panel As GridPanel = SuperGridControl1.PrimaryGrid

        ' Set both the Slider and SitchButton columns to
        ' our own defined EditControls

        Dim column As GridColumn = panel.Columns("status")

        column.EditorType = GetType(MyGridLabelXEditControl)

        column = panel.Columns("statut")
        column.EditorType = GetType(MyGridLabelXEditControl)

        Dim panel2 As GridPanel = SuperGridControl2.PrimaryGrid

        ' Set both the Slider and SitchButton columns to
        ' our own defined EditControls

        Dim column2 As GridColumn = panel2.Columns("status")

        column2.EditorType = GetType(MyGridLabelXEditControl)

        column2 = panel.Columns("statut")
        column2.EditorType = GetType(MyGridLabelXEditControl)

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
End Class