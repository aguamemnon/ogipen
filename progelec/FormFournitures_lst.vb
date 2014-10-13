Public Class FormFournitures_lst
    Dim Sep As Char
    Private Sub FournituresBindingNavigatorSaveItem_Click(sender As System.Object, e As System.EventArgs) Handles ButtonX6.Click
        Me.Validate()
        Me.FournituresBindingSource.EndEdit()
        Me.FournituresTableAdapter.Update(MydbDataSet.fournitures)
        Me.FournituresTableAdapter.Fill(MydbDataSet.fournitures)

    End Sub

    Private Sub FormFournitures_lst_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Sep = CChar(Application.CurrentCulture.NumberFormat.NumberDecimalSeparator)
        'TODO: This line of code loads data into the 'MydbDataSet.fournisseurs' table. You can move, or remove it, as needed.
        Me.FournisseursTableAdapter.Fill(Me.MydbDataSet.fournisseurs)
        'TODO: This line of code loads data into the 'MydbDataSet.fournitures' table. You can move, or remove it, as needed.
        Me.FournituresTableAdapter.Fill(Me.MydbDataSet.fournitures)

    End Sub

    Private Sub ButtonX3_Click(sender As System.Object, e As System.EventArgs) Handles ButtonX3.Click
        Me.FournituresBindingSource.EndEdit()
        Me.FournituresTableAdapter.Update(MydbDataSet.fournitures)
        Me.FournituresTableAdapter.Fill(MydbDataSet.fournitures)
        Me.Close()
    End Sub

    Private Sub ButtonX1_Click(sender As System.Object, e As System.EventArgs) Handles ButtonX1.Click
        Me.FournituresBindingSource.AddNew()

    End Sub

    Private Sub ButtonX2_Click(sender As System.Object, e As System.EventArgs) Handles ButtonX2.Click
        Me.FournituresBindingSource.RemoveCurrent()
        Me.FournituresTableAdapter.Update(MydbDataSet.fournitures)
        Me.FournituresTableAdapter.Fill(MydbDataSet.fournitures)

    End Sub

    Private Sub ButtonX5_Click(sender As System.Object, e As System.EventArgs) Handles ButtonX5.Click
        Me.FournituresBindingSource.EndEdit()
        Me.FournituresBindingSource.Position -= 1
    End Sub

    Private Sub ButtonX4_Click(sender As System.Object, e As System.EventArgs) Handles ButtonX4.Click
        Me.FournituresBindingSource.EndEdit()
        Me.FournituresBindingSource.Position += 1
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If Not (Char.IsNumber(e.KeyChar) Or e.KeyChar.Equals(Sep) Or Char.IsControl(e.KeyChar)) Then e.Handled = True
    End Sub
    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        If Not (Char.IsNumber(e.KeyChar) Or e.KeyChar.Equals(Sep) Or Char.IsControl(e.KeyChar)) Then e.Handled = True
    End Sub
End Class