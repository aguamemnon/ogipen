Public Class FormPieceMarchandise

    Private Sub ComboBoxEx1_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxEx1.SelectedValueChanged

        Me.LabelX11.Text = ComboBoxEx1.SelectedItem.ToString

        Select Case ComboBoxEx1.SelectedItem.ToString
            Case "Entree Marchandise"
                TextBoxX1.Enabled = False
                TextBoxX2.Enabled = False
                TextBoxX3.Enabled = False
            Case "Bon de Livraison"
                TextBoxX1.Enabled = False
                TextBoxX2.Enabled = True
                TextBoxX3.Enabled = True
            Case "Bon de Sortie"
                TextBoxX1.Enabled = False
                TextBoxX2.Enabled = False
                TextBoxX3.Enabled = False
        End Select
    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click, ButtonX5.Click, ButtonX4.Click, ButtonX3.Click
        'recherche de la commande pour rappel des ligne et des poste en entree ou sortie marchandise
    End Sub

    Private Sub ButtonX2_Click(sender As Object, e As EventArgs) Handles ButtonX2.Click
        Select Case ComboBoxEx1.SelectedItem.ToString
            Case "Entree Marchandise"
                'ajout de marchandise sans bl ni commande SAP (exemple retour materiels autres projet)

            Case "Bon de Livraison"
                'entree de marchandise avec BL ( et / sans commande SAP)

            Case "Bon de Sortie"
                'sortie de marchandise pour affectation autre projet .... our retour fournisseur

        End Select
    End Sub

    Private Sub FormPieceMarchandise_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        'mise en place des données dans les champs

    End Sub

    Private Sub StockBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.StockBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.MydbDataSet)

    End Sub

    Private Sub FormPieceMarchandise_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.fournitures'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.FournituresTableAdapter.Fill(Me.MydbDataSet.fournitures)
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.emplacement'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.EmplacementTableAdapter.Fill(Me.MydbDataSet.emplacement)
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.fournisseurs'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.FournisseursTableAdapter.Fill(Me.MydbDataSet.fournisseurs)
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.stock'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.StockTableAdapter.Fill(Me.MydbDataSet.stock)

    End Sub

    Private Sub ComboBoxEx4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxEx4.Validated
        Dim row As MydbDataSet.fournituresRow
        If Me.FournituresBindingSource.Count > 0 Then
            row = CType(CType(Me.FournituresBindingSource.Current, DataRowView).Row, MydbDataSet.fournituresRow)

            Me.TextBoxX5.Text = row.designation
            Me.TextBoxX6.Text = row.idfourniture.ToString
        End If
    End Sub
End Class