Imports System.Collections.Generic
Imports DevComponents.DotNetBar.Controls
Imports DevComponents.DotNetBar.SuperGrid
Imports DevComponents.DotNetBar

Public Class FormTroncon
    Inherits OfficeForm
    Public mode As Boolean
    Public value As String
    Public slc As Double
    Public slc2 As Double
    Dim ctrl2 As Control

    Dim change As Boolean = False
    Public dataSet2 As DataSet
    Dim column As DataColumn
    Dim row As DataRow
    Public lt5 As DataTable = New DataTable("discrim")

    Private Sub changeOn()
        change = True
    End Sub

    Private Sub TronconsBindingNavigatorSaveItem_Click(sender As System.Object, e As System.EventArgs)
        Me.Validate()
        Me.TronconsBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.MydbDataSet)

    End Sub

    Private Sub FormTroncon_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'MydbDataSet.batiments' table. You can move, or remove it, as needed.
        RemoveHandler ComboBoxEx5.SelectedValueChanged, AddressOf ComboBoxEx5_SelectedValueChanged
        RemoveHandler ComboBoxEx6.SelectedValueChanged, AddressOf ComboBoxEx5_SelectedValueChanged
        Me.BatimentsTableAdapter.Fill(Me.MydbDataSet.batiments)
        Me.Batiments2TableAdapter.Fill(Me.MydbDataSet.batiments)
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
        column.Caption = "ref_cab"
        column.ReadOnly = False
        column.Unique = False

        ' Add the column to the table.
        lt5.Columns.Add(column)
        Dim PrimaryKeyColumns(0) As DataColumn
        PrimaryKeyColumns(0) = lt5.Columns("id")
        lt5.PrimaryKey = PrimaryKeyColumns

        ' Instantiate the DataSet variable.
        '= New DataTable("discrim")
        dataSet2 = New DataSet()
        ' Add the new DataTable to the DataSet.
        dataSet2.Tables.Add(lt5)

        RemoveHandler TypeComboBox.SelectedValueChanged, AddressOf TypeComboBox_SelectedValueChanged
        RemoveHandler ComboBoxEx3.SelectedIndexChanged, AddressOf TypeComboBox_SelectedValueChanged
        RemoveHandler ComboBoxEx2.SelectedValueChanged, AddressOf ComboBoxEx2_SelectedValueChanged
        RemoveHandler ComboBoxEx1.SelectedValueChanged, AddressOf ComboBoxEx2_SelectedValueChanged

        'TODO: This line of code loads data into the 'MydbDataSet.troncons_fournitures' table. You can move, or remove it, as needed.
        Me.Troncons_fournituresTableAdapter.Fill(Me.MydbDataSet.troncons_fournitures)
        'TODO: This line of code loads data into the 'MydbDataSet.fournitures' table. You can move, or remove it, as needed.
        Me.FournituresTableAdapter.Fill(Me.MydbDataSet.fournitures)
        'TODO: This line of code loads data into the 'MydbDataSet.cables' table. You can move, or remove it, as needed.
        Me.CablesTableAdapter.Fill(Me.MydbDataSet.cables)

        'TODO: This line of code loads data into the 'MydbDataSet.cables_details' table. You can move, or remove it, as needed.
        '   Me.Cables_detailsTableAdapter.Connection.Close()
        '  Me.Cables_detailsTableAdapter.Connection.ConnectionString = ClassConnectionBuilder.ConnectionStringBuilder( formmain.user.server,formmain.user.Project_user, "root",formmain.user.pass_user)
        ' Me.Cables_detailsTableAdapter.Connection.Open()
        '    Me.Cables_detailsTableAdapter.Fill(Me.MydbDataSet.cables_details)

        'TODO: This line of code loads data into the 'MydbDataSet.troncons' table. You can move, or remove it, as needed.
        ' Me.TronconsTableAdapter.Connection.Close()
        ' Me.TronconsTableAdapter.Connection.ConnectionString = ClassConnectionBuilder.ConnectionStringBuilder( formmain.user.server,formmain.user.Project_user, "root",formmain.user.pass_user)
        ' Me.TronconsTableAdapter.Connection.Open()
        Me.TronconsTableAdapter.Fill(Me.MydbDataSet.troncons)
        'TODO: This line of code loads data into the 'MydbDataSet.segregations' table. You can move, or remove it, as needed.
        ' Me.SegregationsTableAdapter.Connection.Close()
        ' Me.SegregationsTableAdapter.Connection.ConnectionString = ClassConnectionBuilder.ConnectionStringBuilder( formmain.user.server,formmain.user.Project_user, "root",formmain.user.pass_user)
        ' Me.SegregationsTableAdapter.Connection.Open()
        Me.SegregationsTableAdapter.Fill(Me.MydbDataSet.segregations)
        'TODO: This line of code loads data into the 'MydbDataSet.salles' table. You can move, or remove it, as needed.
        'Me.Salle_2TableAdapter1.Connection.Close()
        ' Me.Salle_2TableAdapter1.Connection.ConnectionString = ClassConnectionBuilder.ConnectionStringBuilder( formmain.user.server,formmain.user.Project_user, "root",formmain.user.pass_user)
        ' Me.Salle_2TableAdapter1.Connection.Open()
        Me.Salle_2TableAdapter1.Fill(Me.MydbDataSet.salles)
        'TODO: This line of code loads data into the 'MydbDataSet.types_troncons' table. You can move, or remove it, as needed.
        ' Me.Types_tronconsTableAdapter.Connection.Close()
        ' Me.Types_tronconsTableAdapter.Connection.ConnectionString = ClassConnectionBuilder.ConnectionStringBuilder( formmain.user.server,formmain.user.Project_user, "root",formmain.user.pass_user)
        ' Me.Types_tronconsTableAdapter.Connection.Open()
        Me.Types_tronconsTableAdapter.Fill(Me.MydbDataSet.types_troncons)

        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.salles'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        ' Me.SallesTableAdapter.Fill(Me.MydbDataSet.salles)
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.segregations'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        '   Me.SegregationsTableAdapter.Fill(Me.MydbDataSet.segregations)
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.troncons'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        '  Me.TronconsTableAdapter.Fill(Me.MydbDataSet.troncons)
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.types_troncons'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        '    Me.Types_tronconsTableAdapter.Fill(Me.MydbDataSet.types_troncons)
        Select Case Me.Remplissage3RadioButton.Checked
            Case True

                Me.Reserves2TextBox.Visible = True
            Case False

                Me.Reserves2TextBox.Visible = False
        End Select
        If mode = True Then
            Me.TronconsBindingSource.AddNew()
            Me.ButtonX1.Text = "Enregistrer et Fermer"
            Me.QuiTextBox.Text = FormMain.user.Nom_user
            Me.Date_calculDateTimePicker.Value = Today()
            Me.Remplissage3RadioButton.Checked = True
            Me.Remplissage2RadioButton.Checked = False
            Me.DiscriminationCheckBox.Checked = False
            Me.RemplissageRadioButton.Checked = False
            Me.ComboBoxEx6.Enabled = False
        Else
            Dim row As MydbDataSet.tronconsRow
            Try
                Me.TronconsBindingSource.Position = Me.TronconsBindingSource.Find("Idtroncons", value)
                row = CType(CType(Me.TronconsBindingSource.Current, DataRowView).Row, MydbDataSet.tronconsRow)
            Catch ex As System.Exception
                System.Windows.Forms.MessageBox.Show(ex.Message)
            End Try
            Try
                Me.Cables_troncon_idTableAdapter.Fill(Me.MydbDataSet.cables_troncon_id, New System.Nullable(Of Integer)(CType(value, Integer)))

                Me.Types_tronconsBindingSource.Position = Me.Types_tronconsBindingSource.Find("idTypes_troncons", row.Types_troncons_idTypes_troncons)
                Me.SallesBindingSource.Position = Me.SallesBindingSource.Find("idsalle", row.salles)
                Me.Salle_2bindingSource.Position = Me.Salle_2bindingSource.Find("idsalle", row.salles_idsalle)
                Me.SegregationsBindingSource.Position = Me.SegregationsBindingSource.Find("idsegregations", row.segregations_idsegregations)
                Me.Text = "TRC : " & row.repere_troncon
            Catch ex As System.Exception
                System.Windows.Forms.MessageBox.Show(ex.Message)
            End Try

            Try
                Me.Lst_fournitures_trcTableAdapter.Fill(Me.MydbDataSet.lst_fournitures_trc, New System.Nullable(Of Integer)(CType(value, Integer)))
            Catch ex As System.Exception
                System.Windows.Forms.MessageBox.Show(ex.Message)
            End Try
            Me.ButtonX1.Text = "Modifier"
            For Each Me.ctrl2 In Me.Controls
                Me.ctrl2.Enabled = False
            Next
            Me.ButtonX1.Enabled = True

        End If
        Me.Cables_troncon_idDataGridViewX.Enabled = True

        Try
            Me.FournituresTableAdapter.Fill(Me.MydbDataSet.fournitures)
            Me.FournituresBindingSource.Filter = "liste_troncon = true"

            Me.ComboBoxEx4.DataSource = Me.FournituresBindingSource
            Me.ComboBoxEx4.DisplayMember = "designation"
            Me.ComboBoxEx4.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxEx4.DropDownColumns = "Categorie,designation,fournisseur"
            Me.ComboBoxEx4.DropDownColumnsHeaders = "Categorie" & vbCrLf & "designation" & vbCrLf & "fournisseur"
            Me.ComboBoxEx4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.ComboBoxEx4.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxEx4.FormattingEnabled = True
            Me.ComboBoxEx4.ItemHeight = 14
            Me.ComboBoxEx4.DropDownWidth = 800
            Me.ComboBoxEx4.DropDownHeight = 500
            '   Me.ComboBoxEx4.Location = New System.Drawing.Point(19, 156)
            Me.ComboBoxEx4.Name = "ComboBoxEx4"

            '  Me.ComboBoxEx4.Size = New System.Drawing.Size(192, 20)
            Me.ComboBoxEx4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            '     Me.ComboBoxEx4.TabIndex = 2
            ComboBoxEx4.Visible = False

        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try

        ComboBoxEx4.Visible = False

    End Sub

    Private Sub TypeComboBox_SelectedValueChanged(sender As System.Object, e As System.EventArgs) Handles TypeComboBox.SelectedValueChanged, ComboBoxEx3.SelectedIndexChanged
        Select Case Me.TypeComboBox.Text
            Case "TREMIE"
                Me.ComboBoxEx3.Enabled = True
                If Me.ComboBoxEx3.Text = Me.ComboBoxEx2.Text Then
                    MsgBox("veuillez choisir la salle aboutissante")
                    Me.ComboBoxEx3.Focus()
                End If
                Me.DiametreTextBox.Enabled = True
                Me.LargeurTextBox.Enabled = True
                Me.HauteurTextBox.Enabled = True
                Me.FormesComboBox.Text = "Rectangle"
            Case "FOURREAU"
                Me.ComboBoxEx3.Enabled = True
                If Me.ComboBoxEx3.Text = Me.ComboBoxEx2.Text Then
                    MsgBox("veuillez choisir la salle aboutissante")
                    Me.ComboBoxEx3.Focus()
                End If
                Me.DiametreTextBox.Enabled = False
                Me.LargeurTextBox.Enabled = False
                Me.HauteurTextBox.Enabled = False
                Me.FormesComboBox.Text = "Cercle"

            Case "DALLE"
                Me.ComboBoxEx3.Enabled = False
                Me.ComboBoxEx3.Text = Me.ComboBoxEx2.Text
                Me.HauteurTextBox.Enabled = False
                ' Me.LongueurTextBox.Enabled = False
                Me.LargeurTextBox.Enabled = False
                Me.DiametreTextBox.Enabled = False
                'Me.CheckBoxX1.CheckState = CheckState.Checked
                Me.ComboBoxEx4.Text = "SECTION OBLIGATOIRE"
                Me.FormesComboBox.Text = "Rectangle"
                Me.DiametreTextBox.Enabled = False
                Me.LargeurTextBox.Enabled = False
                Me.HauteurTextBox.Enabled = False
            Case "TUBE"
                Me.ComboBoxEx3.Enabled = False
                Me.ComboBoxEx3.Text = Me.ComboBoxEx2.Text
                Me.HauteurTextBox.Enabled = False
                ' Me.LongueurTextBox.Enabled = False
                Me.LargeurTextBox.Enabled = False
                Me.DiametreTextBox.Enabled = False
                'Me.CheckBoxX1.CheckState = CheckState.Checked
                Me.ComboBoxEx4.Text = "SECTION OBLIGATOIRE"
                Me.FormesComboBox.Text = "Cercle"
                Me.DiametreTextBox.Enabled = False
                Me.LargeurTextBox.Enabled = False
                Me.HauteurTextBox.Enabled = False
            Case ""
                '   MsgBox("Veuillez choisir le type de tronçon !")
            Case Else
                Me.ComboBoxEx3.Enabled = False
                Me.ComboBoxEx3.Text = Me.ComboBoxEx2.Text
                Me.HauteurTextBox.Enabled = False
                ' Me.LongueurTextBox.Enabled = False
                Me.LargeurTextBox.Enabled = False
                Me.DiametreTextBox.Enabled = False
                'Me.CheckBoxX1.CheckState = CheckState.Checked
                Me.ComboBoxEx4.Text = "SECTION OBLIGATOIRE"
                Me.DiametreTextBox.Enabled = False
                Me.LargeurTextBox.Enabled = False
                Me.HauteurTextBox.Enabled = False
        End Select

    End Sub

    Private Sub ComboBoxEx2_SelectedValueChanged(sender As System.Object, e As System.EventArgs) Handles ComboBoxEx2.SelectedValueChanged, ComboBoxEx1.SelectedValueChanged
        Select Case Me.TypeComboBox.Text
            Case "TREMIE"
                Me.ComboBoxEx3.Enabled = True
                If Me.ComboBoxEx3.Text = Me.ComboBoxEx2.Text Then
                    MsgBox("veuillez choisir la salle aboutissante")
                    Me.ComboBoxEx3.Focus()

                End If
            Case ("FOURREAU")
                Me.ComboBoxEx3.Enabled = True
                If Me.ComboBoxEx3.Text = Me.ComboBoxEx2.Text Then
                    MsgBox("veuillez choisir la salle aboutissante")
                    Me.ComboBoxEx3.Focus()
                End If
            Case Else
                Me.ComboBoxEx3.Enabled = False
                Me.ComboBoxEx3.Text = Me.ComboBoxEx2.Text
        End Select
    End Sub

    Private Sub Remplissage3RadioButton_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Remplissage3RadioButton.CheckedChanged
        Select Case Me.Remplissage3RadioButton.Checked
            Case True

                Me.Reserves2TextBox.Visible = True
            Case False

                Me.Reserves2TextBox.Visible = False
        End Select
    End Sub

    Private Sub IdtronconsTextBox_TextChanged(sender As System.Object, e As System.EventArgs) Handles IdtronconsTextBox.TextChanged
        Try
            Me.Cables_troncon_idTableAdapter.Fill(Me.MydbDataSet.cables_troncon_id, New System.Nullable(Of Integer)(CType(Me.IdtronconsTextBox.Text, Integer)))
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Me.Validate()
        If Me.SuperValidator1.Validate() = False Then
            Exit Sub
        End If
        Dim drow As DataRow
        Dim items As DataRow
        slc = 0
        slc2 = 0
        Dim dictionary As New Dictionary(Of String, Integer)
        Dim dictionary2 As New Dictionary(Of String, Integer)
        dictionary.Clear()
        dictionary2.Clear()

        Select Case Me.FormesComboBox.Text

            Case "Rectangle"
                lt5.Clear()
                If Me.TypeComboBox.Text = "TREMIE" Then

                    For Each item In Me.MydbDataSet.cables_troncon_id

                        slc2 = CDbl(slc2 + Math.Pow((CInt(item.diametre)), 2))

                    Next

                    slc2 = Math.Round((slc2 * 100) / (CDbl(Me.HauteurTextBox.Text) * (CDbl(Me.LargeurTextBox.Text) - CDbl(Me.Reserve_lotTextBox.Text))))

                    slc = 0

                Else
                    For Each item In Me.MydbDataSet.cables_troncon_id

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
                                    slc = slc + CDbl(item.diametre)
                                End If

                            Case False

                                If item.mode_de_pose3 = True Then
                                    'slc2 = CInt(CDbl(slc2 + Math.Pow((CInt(item.diametre)), 2)))
                                    slc2 = slc2 + (CDbl(item.diametre))

                                End If
                        End Select

                    Next
                    Dim test2 As Double
                    For Each item In dictionary2
                        test2 = dictionary.Item(item.Key)
                        dictionary.Item(item.Key) = CInt((dictionary.Item(item.Key) * 2) / 3)

                    Next

                    For Each items In lt5.Rows

                        'items(0).ToString()
                        If dictionary.ContainsKey(items(0).ToString) Then

                            slc = slc + (dictionary.Item(items(0).ToString) * CInt(items(1).ToString))

                        End If
                    Next
                    If CDbl(Me.Reserves2TextBox.Text) > 0 Then
                        slc2 = Math.Round((slc2 * 100) / ((CDbl(Me.TextBox1.Text) * (CDbl(Me.LargeurTextBox.Text) - CDbl(Me.Reserve_lotTextBox.Text))) * (CDbl(Me.Reserves2TextBox.Text) / 100)))
                    Else
                        slc2 = 0

                    End If
                    If CDbl(Me.ReservesTextBox.Text) > 0 Then
                        slc = Math.Round((slc * 100) / ((CDbl(Me.LargeurTextBox.Text) - CDbl(Me.Reserve_lotTextBox.Text)) * (CDbl(Me.ReservesTextBox.Text) / 100)))
                    Else
                        slc = 0
                    End If

                End If

            Case "Cercle"

                For Each item In Me.MydbDataSet.cables_troncon_id
                    slc2 = CInt(CDbl(slc2 + (Math.PI * (Math.Pow(CDbl((CInt(item.diametre))), 2) / 4))))
                Next
                slc2 = CInt(Math.Round((slc2 * 1.5 * 100) / ((Math.PI * (Math.Pow((CDbl(Me.DiametreTextBox.Text.ToString())), 2) / 4)))))

                slc = 0
            Case Else
                MsgBox("Tronçon non definit sur la forme Veuillez finir de le paramétrer")
        End Select
        'calcul masse troncon
        Dim masse As Double = 0
        Dim row As MydbDataSet.cables_troncon_idRow
        For Each row In MydbDataSet.cables_troncon_id
            row = CType(CType(Me.Cables_troncon_idBindingSource.Current, DataRowView).Row, MydbDataSet.cables_troncon_idRow)
            masse = CDbl(masse + (CDbl(row.masse) * (CDbl(Me.LongueurTextBox.Text) / 1000)))

        Next
        masse = CInt(masse / (CInt(Me.LongueurTextBox.Text) / 1000))
        Masse_TextBoxX1.Text = CStr(masse)
        Me.Reserve_calTextBox.Text = CStr(slc)
        Me.Reserve2_calTextBox.Text = CStr(slc2)
    End Sub

    Private Sub FormesComboBox_SelectedValueChanged(sender As System.Object, e As System.EventArgs) Handles FormesComboBox.SelectedValueChanged
        Select Case Me.FormesComboBox.Text
            Case "rectangle"
                MsgBox("Pensez à Selectionner le mode de remplissage")
                If CInt(Me.DiametreTextBox.Text) > 0 Or Not CInt(Me.LargeurTextBox.Text) > 0 Then MsgBox("Attention Verifier le diametre et la largeur")
            Case "cercle"
                Me.RemplissageRadioButton.Checked = True
                If Not CInt(Me.DiametreTextBox.Text) > 0 Then MsgBox("Attention Verifier le diametre")
            Case Else

        End Select

    End Sub

    Private Sub ButtonX1_Click(sender As System.Object, e As System.EventArgs) Handles ButtonX1.Click

        If Me.ButtonX1.Text = "Nouveau" Then
            If FormMain.user.mode = "Consultation" Then Exit Sub
            Me.TronconsBindingSource.AddNew()
            Me.ButtonX1.Text = "Enregistrer et Fermer"
            Me.ModifTextBox.Enabled = False
            Me.Remplissage3RadioButton.Checked = True
            Me.Remplissage2RadioButton.Checked = False

            Me.RemplissageRadioButton.Checked = False
        ElseIf Me.ButtonX1.Text = "Modifier" Then
            If FormMain.user.mode = "Consultation" Then Exit Sub
            For Each Me.ctrl2 In Me.Controls
                Me.ctrl2.Enabled = True
            Next
            Me.QuiTextBox.Text = FormMain.user.Nom_user
            Me.QuiTextBox.Enabled = False
            Me.Date_calculDateTimePicker.Value = Today()
            Me.Date_calculDateTimePicker.Enabled = False
            Me.ButtonX1.Text = "Enregistrer et Fermer"
            Me.DetailmodifTextBox.Text = FormMain.user.mode
            Me.DetailmodifTextBox.Enabled = False

            Me.ModifTextBox.Enabled = False
            '
            '
            If Me.TypeComboBox.Text = "TREMIE" Then

                Me.DiametreTextBox.Enabled = True
                Me.LargeurTextBox.Enabled = True
                Me.HauteurTextBox.Enabled = True

            End If

            Select Case Me.FormesComboBox.Text
                Case "Rectangle"

                    If Not CInt(Me.LargeurTextBox.Text) > 0 Then
                        MsgBox("Attention Verifier la largeur")
                    Else
                        Me.Button1.PerformClick()
                    End If

                Case "Cercle"
                    If Not CInt(Me.DiametreTextBox.Text) > 0 Then
                        MsgBox("Attention Verifier le diametre ")
                    Else
                        Me.Button1.PerformClick()
                    End If

            End Select

        Else
            Me.Validate()
            If Me.SuperValidator1.Validate() = False Then
                Exit Sub
            End If
            Dim row As MydbDataSet.tronconsRow
            row = CType(CType(Me.TronconsBindingSource.Current, DataRowView).Row, MydbDataSet.tronconsRow)
            row.remplissage = Me.RemplissageRadioButton.Checked
            row.remplissage2 = Me.Remplissage2RadioButton.Checked
            row.remplissage3 = Me.Remplissage3RadioButton.Checked
            row.largeur = Me.LargeurTextBox.Text
            row.hauteur = Me.HauteurTextBox.Text
            row.Diametre = Me.DiametreTextBox.Text

            If Me.VirtuelCheckBox.Checked Then
                row.virtuel = True
            Else
                row.virtuel = False
            End If

            If Me.DiscriminationCheckBox.Checked Then
                row.discrimination = True
            Else
                row.discrimination = False
            End If

            If Me.TerminalCheckBox.Checked Then
                row.terminal = True
            Else
                row.terminal = False
            End If

            If Me.Radio_protectionCheckBox.Checked Then
                row.radio_protection = True
            Else
                row.radio_protection = False
            End If
            If Me.Coupe_feuCheckBox.Checked Then
                row.coupe_feu = True
            Else
                row.coupe_feu = False
            End If

            Me.TronconsBindingSource.EndEdit()
            Me.TronconsTableAdapter.Update(Me.MydbDataSet.troncons)

            Me.Close()
        End If

    End Sub

    Private Sub FormTroncon_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        AddHandler TypeComboBox.SelectedValueChanged, AddressOf TypeComboBox_SelectedValueChanged
        AddHandler ComboBoxEx3.SelectedIndexChanged, AddressOf TypeComboBox_SelectedValueChanged
        AddHandler ComboBoxEx2.SelectedValueChanged, AddressOf ComboBoxEx2_SelectedValueChanged
        AddHandler ComboBoxEx1.SelectedValueChanged, AddressOf ComboBoxEx2_SelectedValueChanged
        AddHandler ComboBoxEx6.SelectedValueChanged, AddressOf ComboBoxEx5_SelectedValueChanged
        AddHandler ComboBoxEx5.SelectedValueChanged, AddressOf ComboBoxEx5_SelectedValueChanged
    End Sub

    Private Sub Reserves2TextBox_TextChanged(sender As System.Object, e As System.EventArgs) Handles Reserves2TextBox.TextChanged
        If Me.Reserves2TextBox.Text = "" Then
            Me.Reserves2TextBox.Text = "0"
            Me.ReservesTextBox.Text = CStr(100 - CDbl(Me.Reserves2TextBox.Text))
        Else
            Me.ReservesTextBox.Text = CStr(100 - CDbl(Me.Reserves2TextBox.Text))
        End If

    End Sub

    Private Sub ReservesTextBox_TextChanged(sender As System.Object, e As System.EventArgs) Handles ReservesTextBox.TextChanged
        If Me.ReservesTextBox.Text = "" Then
            Me.ReservesTextBox.Text = "0"
            Me.Reserves2TextBox.Text = CStr(100 - CDbl(Me.ReservesTextBox.Text))
        Else
            Me.Reserves2TextBox.Text = CStr(100 - CDbl(Me.ReservesTextBox.Text))
        End If
    End Sub

    Private Sub Remplissage2RadioButton_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Remplissage2RadioButton.CheckedChanged
        Select Case Me.Remplissage2RadioButton.Checked
            Case True

                Me.Reserves2TextBox.Visible = False
                Me.ReservesTextBox.Text = "100"
            Case False

                Me.Reserves2TextBox.Visible = True

        End Select
    End Sub

    Private Sub RemplissageRadioButton_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RemplissageRadioButton.CheckedChanged
        Select Case Me.RemplissageRadioButton.Checked
            Case True

                Me.ReservesTextBox.Visible = False
                Me.Reserves2TextBox.Text = "100"
            Case False

                Me.ReservesTextBox.Visible = True

        End Select
    End Sub

    Private Sub FormTroncon_Leave(sender As System.Object, e As System.EventArgs) Handles MyBase.Leave
        Me.Cables_detailsTableAdapter.Connection.Close()
        Me.TronconsTableAdapter.Connection.Close()
        Me.SegregationsTableAdapter.Connection.Close()
        Me.Salle_2TableAdapter1.Connection.Close()
        Me.Types_tronconsTableAdapter.Connection.Close()
        Me.Cable_details_tronconTableAdapter.Connection.Close()
        Me.Cables_troncon_idTableAdapter.Connection.Close()
        'liberation memoire
        Me.Cables_detailsTableAdapter.Dispose()
        Me.TronconsTableAdapter.Dispose()
        Me.SegregationsTableAdapter.Dispose()
        Me.Salle_2TableAdapter1.Dispose()
        Me.Types_tronconsTableAdapter.Dispose()
        Me.Cable_details_tronconTableAdapter.Dispose()
        Me.Cables_troncon_idTableAdapter.Dispose()

    End Sub

    Private Sub SuperValidator1_CustomValidatorValidateValue(sender As System.Object, e As DevComponents.DotNetBar.Validator.ValidateValueEventArgs) Handles SuperValidator1.CustomValidatorValidateValue
        If Me.Remplissage2RadioButton.Checked Or Me.Remplissage3RadioButton.Checked Or Me.RemplissageRadioButton.Checked = True Then
            e.IsValid = True
        Else
            e.IsValid = False
        End If
    End Sub

    Private Sub Cables_troncon_idDataGridViewX_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Cables_troncon_idDataGridViewX.CellDoubleClick
        Dim grow As GridRow
        Dim test As String = ""
        Dim irow As Integer
        Dim crow As DataRowView
        Dim row As DataGridViewRow
        Dim formCable As FormCable
        formCable = New FormCable
        formCable.MdiParent = ParentForm
        formCable.WindowState = FormWindowState.Maximized
        formCable.mode = False
        If e.ColumnIndex > -1 AndAlso e.RowIndex > -1 Then ' AndAlso TypeOf sender.CurrentCell Is DataGridViewTextBoxCell Then 'AndAlso TypeOf sender.CurrentCell Is DataGridViewTextBoxCell
            test = CStr(Cables_troncon_idDataGridViewX.Rows(e.RowIndex).Cells(4).Value)

        End If
        'e.RowIndex

        'grow = CType(row.Item("repere cable"), GridRow)
        irow = CablesBindingSource.Find("repere cable", test)
        CablesBindingSource.Position = irow
        crow = CType(CablesBindingSource.Item(irow), DataRowView)

        formCable.value = crow.Item(0).ToString

        formCable.Show()
    End Sub

    Private Sub FillToolStripButton_Click_4(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub ButtonX2_Click(sender As System.Object, e As System.EventArgs) Handles ButtonX2.Click
        Dim lst_fourn As FormFournitures = New FormFournitures()
        lst_fourn.Idtrc = CInt(value)
        lst_fourn.ShowDialog()
        Me.Lst_fournitures_trcTableAdapter.Fill(MydbDataSet.lst_fournitures_trc, CType(value, Integer?))
    End Sub

    Private Sub ComboBoxEx4_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles ComboBoxEx4.SelectedValueChanged
        Dim row As MydbDataSet.fournituresRow

        If Not IsNothing(Me.FournituresBindingSource.Current) And CheckBoxX1.CheckState = CheckState.Checked Then
            Me.FournituresBindingSource.Position = Me.FournituresBindingSource.Find("idfourniture", CType(CType(Me.ComboBoxEx4.SelectedValue, System.Data.DataRowView).Row, progelec.MydbDataSet.fournituresRow).idfourniture)

            Select Case MessageBox.Show("Voulez vou appliquer ce model au tronçon ?", "Template Troncon", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                Case System.Windows.Forms.DialogResult.Yes
                    Select Case MessageBox.Show("Voulez vou appliquer ce model aux fournitures ?", "Template fournitures", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                        Case System.Windows.Forms.DialogResult.Yes
                            row = CType(CType(Me.FournituresBindingSource.Current, DataRowView).Row, MydbDataSet.fournituresRow)

                            Me.LargeurTextBox.Text = CStr(row.largeur)
                            Me.Validate()
                            Me.HauteurTextBox.Text = CStr(row.Hauteur)
                            Me.Validate()
                            Me.DiametreTextBox.Text = CStr(row.diametre)
                            Me.Validate()
                            Dim rows As MydbDataSet.troncons_fournituresRow
                            Dim row_four As MydbDataSet.fournituresRow

                            row_four = CType(CType(Me.FournituresBindingSource.Current, DataRowView).Row, MydbDataSet.fournituresRow)
                            Dim ctrl As Integer = Me.Lst_fournitures_trcBindingSource.Find("fourniture", row_four.idfourniture)
                            If ctrl > -1 Then
                                For Each rows In MydbDataSet.troncons_fournitures

                                    If rows.troncon = CInt(value) And rows.fourniture = row_four.idfourniture Then
                                        rows.Quant = 1

                                        rows.AcceptChanges()

                                    End If

                                Next
                                Me.Troncons_fournituresBindingSource.EndEdit()
                                Me.Troncons_fournituresTableAdapter.Update(MydbDataSet.troncons_fournitures)
                                Me.Lst_fournitures_trcTableAdapter.Fill(Me.MydbDataSet.lst_fournitures_trc, CInt(value))
                            Else
                                Me.Troncons_fournituresBindingSource.AddNew()
                                Dim row_four2 As MydbDataSet.troncons_fournituresRow
                                ' row_four2.BeginEdit()
                                row_four2 = CType(CType(Me.Troncons_fournituresBindingSource.Current, DataRowView).Row, MydbDataSet.troncons_fournituresRow)
                                row_four2.troncon = CInt(value)
                                row_four2.Quant = 1
                                row_four2.fourniture = row_four.idfourniture
                                'row_four2.AcceptChanges()
                                Me.Troncons_fournituresBindingSource.EndEdit()
                                Me.Troncons_fournituresTableAdapter.Update(MydbDataSet.troncons_fournitures)
                                Me.Lst_fournitures_trcTableAdapter.Fill(Me.MydbDataSet.lst_fournitures_trc, CInt(value))
                            End If

                        Case System.Windows.Forms.DialogResult.No
                            row = CType(CType(Me.FournituresBindingSource.Current, DataRowView).Row, MydbDataSet.fournituresRow)
                            Me.LargeurTextBox.Text = CStr(row.largeur)
                            Me.HauteurTextBox.Text = CStr(row.Hauteur)
                            Me.DiametreTextBox.Text = CStr(row.diametre)
                    End Select
                Case System.Windows.Forms.DialogResult.No

            End Select

        End If

    End Sub

    Private Sub CheckBoxX1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBoxX1.CheckedChanged
        Select Case CheckBoxX1.CheckState
            Case CheckState.Checked
                ComboBoxEx4.Visible = True
            Case CheckState.Unchecked
                ComboBoxEx4.Visible = False
        End Select
    End Sub

    Private Sub ComboBoxEx5_SelectedValueChanged(sender As System.Object, e As System.EventArgs) Handles ComboBoxEx5.SelectedValueChanged, ComboBoxEx6.SelectedValueChanged
        Try
            Me.SallesBindingSource.Filter = "batiments_idbatiment='" & ComboBoxEx5.SelectedValue.ToString & "'"
            If CheckBox1.Checked Then
                Me.Salle_2bindingSource.Filter = "batiments_idbatiment='" & ComboBoxEx6.SelectedValue.ToString & "'"
            Else
                Me.Salle_2bindingSource.Filter = "batiments_idbatiment='" & ComboBoxEx5.SelectedValue.ToString & "'"
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            Me.ComboBoxEx3.Enabled = True
            Me.ComboBoxEx6.Enabled = True
        Else
            Me.ComboBoxEx3.Enabled = False
            Me.ComboBoxEx6.Enabled = False
        End If

    End Sub
End Class