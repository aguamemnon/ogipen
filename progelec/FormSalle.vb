Imports DevComponents.DotNetBar
Public Class FormSalle
    Dim ctrl2 As Control
    Dim col As Collection
    Dim col1 As New AutoCompleteStringCollection
    Public ID As Integer
    'Private Sub SallesBindingNavigatorSaveItem_Click(sender As System.Object, e As System.EventArgs)
    '    Me.Validate()
    '    If Me.SuperValidator1.Validate() = False Then
    '        Exit Sub
    '    End If

    '    Me.SallesBindingSource.EndEdit()
    '    Me.SallesTableAdapter.Update(Me.MydbDataSet1.salles)
    '    Me.SallesTableAdapter.Fill(Me.MydbDataSet1.salles)
    'End Sub
    Private Sub customValidator1_ValidateValue(ByVal sender As System.Object, ByVal e As DevComponents.DotNetBar.Validator.ValidateValueEventArgs) Handles CustomValidator1.ValidateValue
        If Me.SallesBindingSource.Find("repere salle", e.ControlToValidate.Text) > -1 Then
            e.IsValid = False
        Else
            e.IsValid = True
        End If

    End Sub
    Private Sub FormSalle_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet1.troncons'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.TronconsTableAdapter.Fill(Me.MydbDataSet1.troncons)
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet1.cables'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.CablesTableAdapter.Fill(Me.MydbDataSet1.cables)
        'TODO: This line of code loads data into the 'MydbDataSet1.batiments' table. You can move, or remove it, as needed.
        Me.BatimentsTableAdapter.Fill(Me.MydbDataSet1.batiments)
        'TODO: This line of code loads data into the 'MydbDataSet1.troncons' table. You can move, or remove it, as needed.

        'TODO: This line of code loads data into the 'MydbDataSet1.equipements' table. You can move, or remove it, as needed.
        Me.EquipementsTableAdapter.Fill(Me.MydbDataSet1.equipements)
        'TODO: This line of code loads data into the 'MydbDataSet1.salles' table. You can move, or remove it, as needed.
        Me.SallesTableAdapter.Fill(Me.MydbDataSet1.salles)
        If FormMain.user.mode = "Consultation" Then
            Me.ButtonX1.Enabled = False
            Me.ButtonX2.Enabled = False
            Me.ButtonX3.Enabled = False
            Me.SuperTabControl1.Enabled = True
        End If

        For i = 0 To Me.MydbDataSet1.salles.Rows.Count - 1
            col1.Add(Me.MydbDataSet1.salles.Rows(i)("repere salle").ToString())
        Next
        Repere_salleTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource
        Repere_salleTextBox.AutoCompleteCustomSource = col1
        Repere_salleTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend

        If ID = 0 Then
            Me.SallesBindingSource.AddNew()
            For Each Me.ctrl2 In Me.Controls
                Me.ctrl2.Enabled = True
            Next
            Me.QuiTextBox.Text = FormMain.user.Nom_user
            Me.QuiTextBox.Enabled = False
            Me.DateDateTimePicker.Value = Today()
            Me.DateDateTimePicker.Enabled = False
            Me.ButtonX1.Text = "Enregistrement"
            Me.ButtonX1.Visible = True
            Me.ButtonX2.Visible = False
            Me.ButtonX3.Visible = False

        Else
            Me.SallesBindingSource.Position = Me.SallesBindingSource.Find("idsalle", ID)
            Me.ButtonX1.Visible = False
            Me.ButtonX2.Visible = True
            Me.ButtonX3.Visible = True

        End If

    End Sub

    Private Sub BindingNavigatorMoveNextItem_Click(sender As System.Object, e As System.EventArgs) Handles IdsalleTextBox.TextChanged
        Try
            Me.Lst_trc_salleTableAdapter.Fill(Me.MydbDataSet1.lst_trc_salle, New System.Nullable(Of Integer)(CType(Me.IdsalleTextBox.Text, Integer)))
            Me.TronconsDataGridViewX.DataBindings.Clear()
            Me.TronconsDataGridViewX.DataSource = Me.Lst_trc_salleBindingSource
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try
        If CDbl(Me.IdsalleTextBox.Text) < 0 Or Me.IdsalleTextBox.Text = "" Or FormMain.user.mode = "Consultation" Then
            Me.ButtonX3.Enabled = False

        End If
        If FormMain.user.mode = "Consultation" Then
            Me.ButtonX1.Enabled = False
            Me.ButtonX2.Enabled = False
            Me.ButtonX3.Enabled = False
        End If
    End Sub

    Private Sub ButtonX1_Click(sender As System.Object, e As System.EventArgs) Handles ButtonX1.Click
        If Me.ButtonX1.Text = "Ajout :" Then
            Me.SallesBindingSource.AddNew()
            For Each Me.ctrl2 In Me.Controls
                Me.ctrl2.Enabled = True
            Next
            Me.QuiTextBox.Text = FormMain.user.Nom_user
            Me.QuiTextBox.Enabled = False
            Me.DateDateTimePicker.Value = Today()
            Me.DateDateTimePicker.Enabled = False
            Me.ButtonX1.Text = "Enregistrement"
        ElseIf Me.ButtonX1.Text = "Enregistrement" Then

            Me.Validate()
            If Me.modif Then
                Me.SallesBindingSource.EndEdit()
                Me.SallesTableAdapter.Update(Me.MydbDataSet1.salles)
                ' Me.SallesTableAdapter.Fill(Me.MydbDataSet1.salles)
                Me.ButtonX1.Text = "Ajout :"
                Me.modif = False
                Me.Close()
            Else
                If Me.SuperValidator1.Validate() = False Then
                    Exit Sub
                End If
                Me.SallesBindingSource.EndEdit()
                Me.SallesTableAdapter.Update(Me.MydbDataSet1.salles)
                ' Me.SallesTableAdapter.Fill(Me.MydbDataSet1.salles)
                Me.ButtonX1.Text = "Ajout :"
                Me.Close()
            End If


            'Dim row As mydbDataSet.sallesRow

            'row = CType(CType(Me.SallesBindingSource.Current, DataRowView).Row, mydbDataSet.sallesRow)


            ' Me.SallesTableAdapter.Fill(Me.MydbDataSet1.salles)



        End If

    End Sub
    Dim modif As Boolean = False
    Private Sub ButtonX2_Click(sender As System.Object, e As System.EventArgs) Handles ButtonX2.Click
        For Each Me.ctrl2 In Me.Controls
            Me.ctrl2.Enabled = True
        Next
        Me.QuiTextBox.Text = FormMain.user.Nom_user
        Me.QuiTextBox.Enabled = False
        Me.DateDateTimePicker.Value = Today()
        Me.DateDateTimePicker.Enabled = False
        Me.modif = True
        Me.ButtonX1.Text = "Enregistrement"
        Me.ButtonX1.Visible = True
        Me.ButtonX2.Visible = False
        Me.ButtonX3.Visible = False
    End Sub

    Private Sub ButtonX4_Click(sender As System.Object, e As System.EventArgs) Handles ButtonX4.Click
        Dim s As String = InputBox("Quel est le nom du batiment ?", "ajout d'un batiment")
        Dim ss As String

        If s <> "" Then
            ss = InputBox("Donner une information sur le batiment ?", "ajout d'un batiment")
        Else
            Exit Sub
        End If
        Me.BatimentsBindingSource.AddNew()
        CType(CType(Me.BatimentsBindingSource.Current, DataRowView).Row, MydbDataSet.batimentsRow).Nom = s
        CType(CType(Me.BatimentsBindingSource.Current, DataRowView).Row, MydbDataSet.batimentsRow).Designation = ss
        Me.BatimentsBindingSource.EndEdit()
        Me.BatimentsTableAdapter.Update(Me.MydbDataSet1.batiments)
        Me.BatimentsTableAdapter.Fill(Me.MydbDataSet1.batiments)
    End Sub

    Private Sub ButtonX3_Click(sender As Object, e As EventArgs) Handles ButtonX3.Click
        Dim info As New TaskDialogInfo("AVERTISSEMENT", eTaskDialogIcon.Hand, "Suppression d'une salle", "Voulez vous supprimmer la salle " & Me.Repere_salleTextBox.Text & " ", eTaskDialogButton.Ok Or eTaskDialogButton.Cancel, eTaskDialogBackgroundColor.Red)
        Dim result As eTaskDialogResult = TaskDialog.Show(info)
        Select Case result

            Case eTaskDialogResult.Ok
                'supression equipememnts
                'troncons
                'association
                Me.EquipementsBindingSource.Filter = "salles_idsalle=" & CInt(Me.IdsalleTextBox.Text)

                If Me.EquipementsBindingSource.Count > 0 Then
                    MsgBox("suppression impossible des équipements sont encore rattaché à la salle , merci de corriger avant suppression .. ")
                    Exit Sub
                End If
                Me.TronconsBindingSource.Filter = "salles=" & CInt(Me.IdsalleTextBox.Text)

                If Me.TronconsBindingSource.Count > 0 Then
                    MsgBox("suppression impossible des tronçons sont encore rattaché à la salle , merci de corriger avant suppression .. ")
                    Exit Sub
                End If
                Me.TronconsBindingSource.Filter = Nothing
                Me.TronconsBindingSource.Filter = "salles_idsalle=" & CInt(Me.IdsalleTextBox.Text)

                If Me.TronconsBindingSource.Count > 0 Then
                    MsgBox("suppression impossible des tronçons sont encore rattaché à la salle , merci de corriger avant suppression .. ")
                    Exit Sub
                End If
              
                Me.SallesBindingSource.RemoveCurrent()
                Me.SallesBindingSource.EndEdit()
                Me.SallesTableAdapter.Update(Me.MydbDataSet1.salles)
                Me.Close()

            Case eTaskDialogResult.Cancel


                        Exit Sub
        End Select
    End Sub
End Class