Imports DevComponents.DotNetBar

Public Class FormDonnees
    Inherits OfficeForm
    Dim Sep As Char
    Private Sub FormDonnees_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Sep = CChar(Application.CurrentCulture.NumberFormat.NumberDecimalSeparator)
        'TODO: This line of code loads data into the 'MydbDataSet.ctrl_phy' table. You can move, or remove it, as needed.
        Me.Ctrl_phyTableAdapter.Fill(Me.MydbDataSet.ctrl_phy)
        'TODO: This line of code loads data into the 'MydbDataSet.donnee_phy' table. You can move, or remove it, as needed.
        Me.Donnee_phyTableAdapter.Fill(Me.MydbDataSet.donnee_phy)
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.sections_cables'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.Sections_cablesTableAdapter.Fill(Me.MydbDataSet.sections_cables)
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.sections_cables'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.Sections_cablesTableAdapter.Fill(Me.MydbDataSet.sections_cables)
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.types_cable'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.Types_cableTableAdapter.Fill(Me.MydbDataSet.types_cable)
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.types_cable'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.Types_cableTableAdapter.Fill(Me.MydbDataSet.types_cable)
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.donnees_cables'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.Donnees_cablesTableAdapter.Fill(Me.MydbDataSet.donnees_cables)
        If Me._Ctrl_phyBindingSource.Count = 0 Then
            Me.LabelX1.Visible = False
            Me.Ctrl_phyDataGridViewX.Visible = False
        End If
    End Sub

    Private Sub Donnees_cablesBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.Donnees_cablesBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.MydbDataSet)
    End Sub

    Private Sub ButtonX2_Click(sender As Object, e As EventArgs) Handles ButtonX2.Click
        Me.Donnees_cablesBindingSource.Position -= 1
        Dim row As MydbDataSet.donnees_cablesRow
        row = CType(CType(Me.Donnees_cablesBindingSource.Current, DataRowView).Row, MydbDataSet.donnees_cablesRow)
        Me._Donnee_phyBindingSource.Position = Me.Donnee_phyBindingSource.Find("iddonnee", row.iddonnee)
    End Sub

    Private Sub ButtonX4_Click(sender As Object, e As EventArgs) Handles ButtonX4.Click
        Me.Donnees_cablesBindingSource.Position += 1
        Dim row As MydbDataSet.donnees_cablesRow
        row = CType(CType(Me.Donnees_cablesBindingSource.Current, DataRowView).Row, MydbDataSet.donnees_cablesRow)
        Me._Donnee_phyBindingSource.Position = Me.Donnee_phyBindingSource.Find("iddonnee", row.iddonnee)
    End Sub

    Private Sub Donnee_phyDataGridViewX_CellClick(sender As Object, e As DataGridViewCellEventArgs) _
        Handles Donnee_phyDataGridViewX.CellClick
        Dim row As MydbDataSet.donnee_phyRow
        row = CType(CType(Me.Donnee_phyBindingSource.Current, DataRowView).Row, MydbDataSet.donnee_phyRow)
        Me.Donnees_cablesBindingSource.Position = Me.Donnees_cablesBindingSource.Find("iddonnee", row.iddonnee)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.SuperValidator1.Validate()
        If Me.SuperValidator1.Validate() = False Then
            Exit Sub
        End If
        Me.Donnees_cablesBindingSource.EndEdit()
        Me.Donnees_cablesTableAdapter.Update(Me.MydbDataSet.donnees_cables)
        Me.Donnee_phyTableAdapter.Fill(Me.MydbDataSet.donnee_phy)
        Me.Donnees_cablesTableAdapter.Fill(Me.MydbDataSet.donnees_cables)
        Me.Ctrl_phyTableAdapter.Fill(Me.MydbDataSet.ctrl_phy)
        If Me._Ctrl_phyBindingSource.Count = 0 Then
            Me.LabelX1.Visible = False
            Me.Ctrl_phyDataGridViewX.Visible = False
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Donnees_cablesBindingSource.AddNew()
    End Sub
    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TempPoseTextBox.KeyPress
        If Not (Char.IsNumber(e.KeyChar) Or e.KeyChar.Equals(Sep) Or Char.IsControl(e.KeyChar)) Then e.Handled = True
    End Sub
    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TempRaccTeteTextBox.KeyPress
        If Not (Char.IsNumber(e.KeyChar) Or e.KeyChar.Equals(Sep) Or Char.IsControl(e.KeyChar)) Then e.Handled = True
    End Sub
    Private Sub TextBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles NombreBrinsTextBox.KeyPress
        If Not (Char.IsNumber(e.KeyChar) Or e.KeyChar.Equals(Sep) Or Char.IsControl(e.KeyChar)) Then e.Handled = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Donnees_cablesBindingSource.RemoveCurrent()
        Me.Donnees_cablesTableAdapter.Update(Me.MydbDataSet.donnees_cables)
        Me.Donnee_phyTableAdapter.Fill(Me.MydbDataSet.donnee_phy)
        Me.Donnees_cablesTableAdapter.Fill(Me.MydbDataSet.donnees_cables)
        Me.Ctrl_phyTableAdapter.Fill(Me.MydbDataSet.ctrl_phy)
        If Me._Ctrl_phyBindingSource.Count = 0 Then
            Me.LabelX1.Visible = False
            Me.Ctrl_phyDataGridViewX.Visible = False
        End If
    End Sub

    Private Sub ButtonX3_Click(sender As Object, e As EventArgs) Handles ButtonX3.Click
        Dim s As String = InputBox("Quelle est la section ?", "ajout d'une section")
        Dim ss As String

        If s <> "" Then

        Else
            Exit Sub
        End If
        'todo Boucle de verification

        Me.SectionscablesBindingSource.AddNew()
        CType(CType(Me.SectionscablesBindingSource.Current, DataRowView).Row, MydbDataSet.sections_cablesRow).section = s

        Me.SectionscablesBindingSource.EndEdit()
        Me.Sections_cablesTableAdapter.Update(Me.MydbDataSet.sections_cables)
        Me.Sections_cablesTableAdapter.Fill(Me.MydbDataSet.sections_cables)
    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        Dim s As String = InputBox("Quel est le type ?", "ajout d'un Type de câble")
        Dim ss As String

        If s <> "" Then

        Else
            Exit Sub
        End If
        'todo Boucle de verification

        Me.TypescableBindingSource.AddNew()
        CType(CType(Me.TypescableBindingSource.Current, DataRowView).Row, MydbDataSet.types_cableRow).types = s

        Me.TypescableBindingSource.EndEdit()
        Me.Types_cableTableAdapter.Update(Me.MydbDataSet.types_cable)
        Me.Types_cableTableAdapter.Fill(Me.MydbDataSet.types_cable)

    End Sub
End Class