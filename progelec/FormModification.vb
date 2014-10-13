Public Class FormModification

    Private Sub FormModification_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'MydbDataSet.modifrev' table. You can move, or remove it, as needed.
        Me.ModifrevTableAdapter.Fill(Me.MydbDataSet.modifrev)
        'TODO: This line of code loads data into the 'MydbDataSet.modiftype' table. You can move, or remove it, as needed.
        Me.ModiftypeTableAdapter.Fill(Me.MydbDataSet.modiftype)
        'TODO: This line of code loads data into the 'MydbDataSet.modifdetail' table. You can move, or remove it, as needed.
        Me.ModifdetailTableAdapter.Fill(Me.MydbDataSet.modifdetail)
        'TODO: This line of code loads data into the 'MydbDataSet.modif' table. You can move, or remove it, as needed.
        Me.ModifTableAdapter.Fill(Me.MydbDataSet.modif)
        'TODO: This line of code loads data into the 'MydbDataSet.modiforigine' table. You can move, or remove it, as needed.
        Me.ModiforigineTableAdapter.Fill(Me.MydbDataSet.modiforigine)

    End Sub
End Class