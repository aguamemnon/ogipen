Imports System.ComponentModel
Imports DevComponents.DotNetBar.Metro.ColorTables
Imports DevComponents.DotNetBar
Imports System.Globalization
Imports MySql.Data.MySqlClient
Imports System.Threading
Imports System.Windows.Forms.DataVisualization.Charting
Imports Ludiosoft.ConfigurationFile
Imports MySql.Data
Imports FastReport.Data
Imports System.IO.File
Imports Microsoft.Win32

Public Class FormMain
    Inherits RibbonForm

    Public Shared user As Class_User = New Class_User
    Public Shared maintenance As Boolean = False
    Dim t As Integer
    Public Event EventFired()
    Public Event EventFired2()
    Public Event EventFired3()
    Public Event EventFired4()
    Public Event EventFired5()
    Public Event EventFired6()
    Public Event EventFired7()
    Public Event EventFired8()
    Public Event EventFired9()
    Public config_ini_ok As Boolean = False
    Dim MysqlConn As MySqlConnection
    Dim ConnectionString As String

    Dim m_AlertOnLoad As Balloon
    Dim m_AlertOnLoad2 As Balloon

    Private _fichier As String
    Public trc As cls_troncons = New cls_troncons
    Public param1 As Integer

    Public Shared out As Boolean

    ' Dim MysqlConn As MySqlConnection
    'Dim ConnectionString As String
    ' Dim maintenance As Boolean = False

#Region "Automatic Color Scheme creation based on the selected color table"

    Private m_ColorSelected As Boolean = False
    Private m_BaseStyle As eStyle = eStyle.Office2010Silver

    Private Sub buttonStyleCustom_ExpandChange(ByVal sender As Object, ByVal e As EventArgs)
        If buttonStyleCustom.Expanded Then
            ' Remember the starting color scheme to apply if no color is selected during live-preview
            m_ColorSelected = False
            m_BaseStyle = StyleManager.Style
        Else
            If Not m_ColorSelected Then
                If StyleManager.Style = eStyle.Metro Then
                    StyleManager.MetroColorGeneratorParameters = MetroColorGeneratorParameters.Default
                Else
                    StyleManager.ChangeStyle(m_BaseStyle, Color.Empty)
                End If
            End If
        End If
    End Sub

    Private Sub buttonStyleCustom_ColorPreview(ByVal sender As Object, ByVal e As ColorPreviewEventArgs)
        If StyleManager.Style = eStyle.Metro Then
            Dim baseColor As Color = e.Color
            StyleManager.MetroColorGeneratorParameters = New MetroColorGeneratorParameters(Color.White, baseColor)
        Else
            StyleManager.ColorTint = e.Color
        End If
    End Sub

    Private Sub buttonStyleCustom_SelectedColorChanged(ByVal sender As Object, ByVal e As EventArgs)
        m_ColorSelected = True ' Indicate that color was selected for buttonStyleCustom_ExpandChange method
        buttonStyleCustom.CommandParameter = buttonStyleCustom.SelectedColor
    End Sub

#End Region

    Private Sub AppCommandTheme_Executed(ByVal sender As Object, ByVal e As EventArgs) _
        Handles buttonChangeStyle.Click, AppCommandTheme.Executed
        Dim source As ICommandSource = TryCast(sender, ICommandSource)
        If TypeOf source.CommandParameter Is String Then
            Dim style As eStyle = CType([Enum].Parse(GetType(eStyle), source.CommandParameter.ToString()), eStyle)
            ' Using StyleManager change the style and color tinting
            If style = eStyle.Metro Then
                ' More customization is needed for Metro
                ' Capitalize App Button and tab
                ApplicationButton1.Text = ApplicationButton1.Text.ToUpper()
                For Each item As BaseItem In RibbonControl.Items
                    ' Ribbon Control may contain items other than tabs so that needs to be taken in account
                    Dim tab As RibbonTabItem = TryCast(item, RibbonTabItem)
                    If tab IsNot Nothing Then
                        tab.Text = tab.Text.ToUpper()
                    End If
                Next item

                ApplicationButton1.BackstageTabEnabled = True ' Use Backstage for Metro

                RibbonControl1.RibbonStripFont = New Font("Segoe UI", 9.25F, FontStyle.Regular, GraphicsUnit.Point,
                                                          (CByte(0)))

                StyleManager.MetroColorGeneratorParameters = MetroColorGeneratorParameters.DarkBlue

                ' Adjust size of switch button to match Metro styling
                switchButtonItem1.SwitchWidth = 12
                switchButtonItem1.ButtonWidth = 42
                switchButtonItem1.ButtonHeight = 19

                StyleManager.Style = eStyle.Metro ' BOOM
            Else
                ' If previous style was Metro we need to update other properties as well
                If StyleManager.Style = eStyle.Metro Then
                    RibbonControl1.RibbonStripFont = Nothing
                    ' Fix capitalization App Button and tab
                    ApplicationButton1.Text = ToTitleCase(ApplicationButton1.Text)
                    For Each item As BaseItem In RibbonControl.Items
                        ' Ribbon Control may contain items other than tabs so that needs to be taken in account
                        Dim tab As RibbonTabItem = TryCast(item, RibbonTabItem)
                        If tab IsNot Nothing Then
                            tab.Text = ToTitleCase(tab.Text)
                        End If
                    Next item
                    ' Adjust size of switch button to match Office styling
                    switchButtonItem1.SwitchWidth = 28
                    switchButtonItem1.ButtonWidth = 62
                    switchButtonItem1.ButtonHeight = 20
                End If

                StyleManager.ChangeStyle(style, Color.Empty)
                If _
                    style = eStyle.Office2007Black OrElse style = eStyle.Office2007Blue OrElse
                    style = eStyle.Office2007Silver OrElse style = eStyle.Office2007VistaGlass Then
                    ApplicationButton1.BackstageTabEnabled = False
                Else
                    ApplicationButton1.BackstageTabEnabled = True
                End If
            End If
        ElseIf TypeOf source.CommandParameter Is Color Then
            If StyleManager.Style = eStyle.Metro Then
                StyleManager.MetroColorGeneratorParameters = New MetroColorGeneratorParameters(Color.White,
                                                                                               CType(
                                                                                                   source.
                                                                                                  CommandParameter,
                                                                                                   Color))
            Else
                StyleManager.ColorTint = CType(source.CommandParameter, Color)
            End If
        End If
    End Sub

    Private Function ToTitleCase(ByVal text As String) As String
        If text.Contains("&") Then
            Dim ampPosition As Integer = text.IndexOf("&"c)
            text = text.Replace("&", "")
            text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.ToLower())
            If ampPosition > 0 Then
                text = text.Substring(0, ampPosition) & "&" & text.Substring(ampPosition)
            Else
                text = "&" & text
            End If
            Return text
        Else
            Return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.ToLower())
        End If
    End Function

    Private Sub AppCommandExit_Executed(ByVal sender As Object, ByVal e As EventArgs) Handles AppCommandExit.Executed
        Me.Close()
    End Sub

    Private Sub ButtonItem1_Click(sender As Object, e As EventArgs)
        'Dim FormLstCables As FormLstCables
        'FormLstCables = New FormLstCables
        'FormLstCables.MdiParent = Me
        'FormLstCables.WindowState = FormWindowState.Maximized
        'FormLstCables.Show()
        Dim ChildWindowFound As Boolean = False

        If Not (MdiChildren.Length.Equals(0)) Then
            For Each ChildWindow As Form In MdiChildren
                If ChildWindow.Name.Equals("FormLstCables") Then
                    ChildWindow.Activate()
                    ChildWindowFound = True
                End If
            Next
        End If

        If Not ChildWindowFound Then
            Dim FormLstCables As FormLstCables = New FormLstCables
            FormLstCables.MdiParent = Me
            FormLstCables.WindowState = FormWindowState.Maximized
            AddHandler Me.EventFired8, AddressOf FormLstCables.actualisation
            FormLstCables.Show()
        End If
    End Sub

    Private Sub ButtonItem8_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim frmequip As FormEquipement
        frmequip = New FormEquipement
        frmequip.MdiParent = Me
        frmequip.WindowState = FormWindowState.Maximized
        frmequip.mode = True
        frmequip.Show()
    End Sub

    Private Sub RibbonStateCommand_Executed(sender As Object, e As EventArgs)
        RibbonControl1.Expanded = RibbonStateCommand.Checked
        RibbonStateCommand.Checked = Not RibbonStateCommand.Checked
    End Sub

    Private Sub ButtonItem9_Click(sender As Object, e As EventArgs)
        Dim frmcable As FormCable
        frmcable = New FormCable
        frmcable.MdiParent = Me
        frmcable.WindowState = FormWindowState.Maximized
        ' frmcable.action = "new"
        frmcable.mode = True
        frmcable.Show()
    End Sub

    Private Sub ButtonItem10_Click(sender As Object, e As EventArgs)
        Dim FormTroncon As FormTroncon
        FormTroncon = New FormTroncon
        FormTroncon.MdiParent = Me
        FormTroncon.WindowState = FormWindowState.Maximized
        FormTroncon.mode = True
        FormTroncon.Show()
    End Sub

    Private Sub ButtonItem17_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim FormDonnees As FormDonnees
        FormDonnees = New FormDonnees
        FormDonnees.MdiParent = Me
        FormDonnees.WindowState = FormWindowState.Maximized
        FormDonnees.Show()
    End Sub

    Private Sub ButtonItem3_Click(sender As Object, e As EventArgs)
        Dim FormLots As FormLots
        FormLots = New FormLots

        FormLots.Show()
    End Sub

    Private Sub ButtonItem2_Click(sender As Object, e As EventArgs)
        Dim FormCategorie As FormCategorie
        FormCategorie = New FormCategorie

        FormCategorie.Show()
    End Sub

    Private Sub ButtonItem4_Click(sender As Object, e As EventArgs)
        Dim FormTypeCable As FormTypeCable
        FormTypeCable = New FormTypeCable

        FormTypeCable.Show()
    End Sub

    Private Sub ButtonItem11_Click(sender As Object, e As EventArgs)
        Dim FormLstTroncons As FormLstTroncons
        FormLstTroncons = New FormLstTroncons
        FormLstTroncons.MdiParent = Me
        FormLstTroncons.WindowState = FormWindowState.Maximized
        FormLstTroncons.Show()
    End Sub

    Private Sub ButtonItem18_Click(sender As Object, e As EventArgs)
        Dim FormAssocTroncons As FormAssocTroncons
        FormAssocTroncons = New FormAssocTroncons
        FormAssocTroncons.MdiParent = Me
        FormAssocTroncons.WindowState = FormWindowState.Maximized
        FormAssocTroncons.Show()
    End Sub

    Private Sub ButtonItem16_Click(sender As Object, e As EventArgs)
        Dim FormParcours As FormParcours
        FormParcours = New FormParcours
        FormParcours.MdiParent = Me
        FormParcours.WindowState = FormWindowState.Maximized
        FormParcours.Show()
    End Sub

    Private Sub ButtonItem7_Click(sender As Object, e As EventArgs)
        Dim FormLstEquipement As FormLstEquipement
        FormLstEquipement = New FormLstEquipement
        FormLstEquipement.MdiParent = Me
        FormLstEquipement.WindowState = FormWindowState.Maximized
        FormLstEquipement.Show()
    End Sub

    Private Sub ButtonItem19_Click(sender As Object, e As EventArgs) Handles ButtonItem19.Click
        Dim FormReportParcours As FormReportParcours
        FormReportParcours = New FormReportParcours
        FormReportParcours.MdiParent = Me
        FormReportParcours.WindowState = FormWindowState.Maximized
        FormReportParcours.Show()
    End Sub

    Private Sub ButtonItem20_Click(sender As Object, e As EventArgs)
        Dim Formsalle As FormSalle
        Formsalle = New FormSalle
        Formsalle.MdiParent = Me
        Formsalle.WindowState = FormWindowState.Maximized
        Formsalle.Show()
    End Sub

    'Private Sub ButtonItem21_Click(sender As Object, e As EventArgs)
    '    Dim FormLstSalles As FormLstSalles
    '    FormLstSalles = New FormLstSalles
    '    FormLstSalles.MdiParent = Me
    '    FormLstSalles.WindowState = FormWindowState.Maximized
    '    FormLstSalles.Show()
    'End Sub

    Private Sub ButtonItem5_Click(sender As Object, e As EventArgs) Handles ButtonItem5.Click
        Dim formoption As FormOptions
        formoption = New FormOptions
        formoption.ShowDialog()
    End Sub

#Region "Timer_serveur"""

    Private Sub TimerServeur_Tick(sender As Object, e As EventArgs) Handles TimerServeur.Tick

        If Not bw.IsBusy = True Then
            bw.RunWorkerAsync()
        End If
    End Sub

    Private Sub bw_DoWork(sender As Object, e As DoWorkEventArgs) Handles bw.DoWork
        MysqlConn = New MySqlConnection()

        MysqlConn.ConnectionString = "server=" & FormMain.user.server & ";" _
                                     & "user id=root;" _
                                     & "password=" & FormMain.user.pass_user & ";" _
                                     & "database=progelec"
        Const query As String = "SELECT * FROM maintenance"
        Dim reader As MySqlDataReader

        Dim cmd As New MySqlCommand(query, MysqlConn)

        Try
            MysqlConn.Open()

            reader = cmd.ExecuteReader()
            While reader.Read()

                For i As Integer = 0 To reader.FieldCount - 1

                    maintenance = reader.GetBoolean("statut")
                    '  Debug.WriteLine(reader.GetValue(i).ToString())
                Next
            End While
            '   MessageBox.Show("Connection to Database has been opened.")
            MysqlConn.Close()
        Catch myerror As MySqlException
            MessageBox.Show(
                "Une erreur est survenu sur la comunication Clent Serveur Contactez votre administrateur: " &
                myerror.Message)
        Finally
            MysqlConn.Dispose()
        End Try

        MysqlConn.Close()
        MysqlConn.Dispose()
    End Sub

    Private Sub bw_ProgressChanged(ByVal sender As Object, ByVal e As ProgressChangedEventArgs) _
        Handles bw.ProgressChanged
    End Sub

    Private Sub bw_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) _
        Handles bw.RunWorkerCompleted
        If maintenance = True Then
            ShowLoadAlert()
        End If
        If ctrl_check() Then
            ctrl_phy_action()
        End If

    End Sub

    Private Sub ShowLoadAlert()
        If IsNothing(m_AlertOnLoad) Then
            m_AlertOnLoad = New AlertCustom()
            Dim r As Rectangle = Screen.GetWorkingArea(Me)
            m_AlertOnLoad.Location = New Point(r.Right - m_AlertOnLoad.Width, r.Bottom - m_AlertOnLoad.Height)
            m_AlertOnLoad.AutoClose = False
            m_AlertOnLoad.AutoCloseTimeOut = 15
            m_AlertOnLoad.AlertAnimation = eAlertAnimation.BottomToTop
            m_AlertOnLoad.AlertAnimationDuration = 300
            m_AlertOnLoad.Show(False)
            m_AlertOnLoad.Focus()
        ElseIf m_AlertOnLoad.IsDisposed Then
            m_AlertOnLoad = New AlertCustom()
            Dim r As Rectangle = Screen.GetWorkingArea(Me)
            m_AlertOnLoad.Location = New Point(r.Right - m_AlertOnLoad.Width, r.Bottom - m_AlertOnLoad.Height)
            m_AlertOnLoad.AutoClose = False
            m_AlertOnLoad.AutoCloseTimeOut = 15
            m_AlertOnLoad.AlertAnimation = eAlertAnimation.BottomToTop
            m_AlertOnLoad.AlertAnimationDuration = 300
            m_AlertOnLoad.Show(False)
            m_AlertOnLoad.Focus()
        End If
    End Sub

#End Region

    Private Sub ButtonItem48_Click(sender As Object, e As EventArgs)
        Dim formsuptrc As FormSupTroncon = New FormSupTroncon
        formsuptrc.ShowDialog()
    End Sub

    Private Sub FormMain_Load1(sender As Object, e As EventArgs) Handles Me.Load
        'TODO: cette ligne de code charge les données dans la table 'ProgelecDataSet.log'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.LogTableAdapter.Fill(Me.ProgelecDataSet.log)
        Me.WindowState = FormWindowState.Minimized

        '  user = New Class_User
        init()
        'AddHandler Me.EventFired6, AddressOf FormDispoRaccordement.Actualisation
        ''TODO: This line of code loads data into the 'MydbDataSet.ctrl_phy' table. You can move, or remove it, as needed.
        'Me.Ctrl_phyTableAdapter.Fill(Me.MydbDataSet.ctrl_phy)
        ''TODO: This line of code loads data into the 'MydbDataSet.lst_besoin_cables' table. You can move, or remove it, as needed.
        'Me.Lst_besoin_cablesTableAdapter.Fill(Me.MydbDataSet.lst_besoin_cables)
        'Me.Type_docTableAdapter.Fill(MydbDataSet.type_doc)
        'bw = New BackgroundWorker
        'bw.WorkerSupportsCancellation = True
        'bw.WorkerReportsProgress = True
        'AddHandler bw.DoWork, AddressOf bw_DoWork
        'AddHandler bw.ProgressChanged, AddressOf bw_ProgressChanged
        'AddHandler bw.RunWorkerCompleted, AddressOf bw_RunWorkerCompleted
        ''TODO: This line of code loads data into the 'MydbDataSet.type_doc' table. You can move, or remove it, as needed.
        'Try
        '    Dim s As DataRowView       '
        '    s = CType(Me.type_doc.Item(Me.type_doc.Find("type_doc", "Carnet de deroulage")), DataRowView)
        '   formmain.user.option1 = s.Item("reference").ToString

        '    s = CType(Me.type_doc.Item(Me.type_doc.Find("type_doc", "Calcul DCC")), DataRowView)

        '   formmain.user.option2 = s.Item("reference").ToString
        '    s = CType(Me.type_doc.Item(Me.type_doc.Find("type_doc", "Carnet de cables")), DataRowView)

        '   formmain.user.option3 = s.Item("reference").ToString
        '    s = CType(Me.type_doc.Item(Me.type_doc.Find("type_doc", "Carnet de tremies")), DataRowView)

        '   formmain.user.option4 = s.Item("reference").ToString

        '    Me.Text = "Projet : " &formmain.user.Project_user
        '    config_ini_ok = True
        'Catch ex As Exception
        '    Me.type_doc.Filter = "type_doc='Carnet de deroulage'"
        '    If Me.type_doc.Count = 0 Then
        '        Me.type_doc.AddNew()
        '        CType(CType(Me.type_doc.Current, DataRowView).Row, mydbDataSet.type_docRow).type_doc = "Carnet de deroulage"
        '        Me.type_doc.EndEdit()
        '        Me.Type_docTableAdapter.Update(MydbDataSet.type_doc)
        '        Me.Type_docTableAdapter.Fill(MydbDataSet.type_doc)
        '    End If
        '    Me.type_doc.RemoveFilter()
        '    Me.type_doc.Filter = "type_doc='Calcul DCC'"
        '    If Me.type_doc.Count = 0 Then
        '        Me.type_doc.AddNew()
        '        CType(CType(Me.type_doc.Current, DataRowView).Row, mydbDataSet.type_docRow).type_doc = "Calcul DCC"
        '        Me.type_doc.EndEdit()
        '        Me.Type_docTableAdapter.Update(MydbDataSet.type_doc)
        '        Me.Type_docTableAdapter.Fill(MydbDataSet.type_doc)
        '    End If
        '    Me.type_doc.RemoveFilter()
        '    Me.type_doc.Filter = "type_doc='Carnet de cables'"
        '    If Me.type_doc.Count = 0 Then
        '        Me.type_doc.AddNew()
        '        CType(CType(Me.type_doc.Current, DataRowView).Row, mydbDataSet.type_docRow).type_doc = "Carnet de cables"
        '        Me.type_doc.EndEdit()
        '        Me.Type_docTableAdapter.Update(MydbDataSet.type_doc)
        '        Me.Type_docTableAdapter.Fill(MydbDataSet.type_doc)
        '    End If
        '    Me.type_doc.RemoveFilter()
        '    Me.type_doc.Filter = "type_doc='Carnet de tremies'"
        '    If Me.type_doc.Count = 0 Then
        '        Me.type_doc.AddNew()
        '        CType(CType(Me.type_doc.Current, DataRowView).Row, mydbDataSet.type_docRow).type_doc = "Carnet de tremies"
        '        Me.type_doc.EndEdit()
        '        Me.Type_docTableAdapter.Update(MydbDataSet.type_doc)
        '        Me.Type_docTableAdapter.Fill(MydbDataSet.type_doc)
        '    End If
        '    Me.type_doc.RemoveFilter()
        '    config_ini_ok = False
        'End Try
        'Me.Type_docTableAdapter.Fill(Me.MydbDataSet.type_doc)

        'With Me.NavigationPanePanel2
        '    .Controls.Item("labelx15").Text =formmain.user.email
        '    .Controls.Item("labelx13").Text =formmain.user.Nom_user
        '    .Controls.Item("labelx14").Text =formmain.user.Prenom
        '    .Controls.Item("labelx17").Text = CStr(t) & "secondes"
        '    .Controls.Item("labelx22").Text =formmain.user.server

        'End With
        'With Me.NavigationPanePanel1
        '    .Controls.Item("LabelX18").Text = "Consultation"
        '    .Controls.Item("labelX19").Text = ""
        '    .Controls.Item("labelX20").Text = ""
        'End With
        'Me.Bar3.Text = "INFORMATIONS"

        'Me.ReflectionImage4.Image = My.Resources.info
        ''Ifformmain.user.mode = "Consultation" Then
        ''    'troncons
        ''    Me.ButtonItem48.Enabled = False
        ''    Me.ButtonItem10.Enabled = False
        ''    Me.ButtonItem36.Enabled = False
        ''    'equipements
        ''    Me.ButtonItem3.Enabled = False
        ''    Me.ButtonItem7.Enabled = False
        ''End If

        ''ctrl_phy = New Thread(AddressOf ctrl_phy_action)

        ''Try
        ''    Me.Lst_action_borniersTableAdapter.Fill(Me.MydbDataSet.lst_action_borniers,formmain.user.Nom_user)
        ''Catch ex As System.Exception
        ''    System.Windows.Forms.MessageBox.Show(ex.Message)
        ''End Try
        ''Try
        ''    Me.Lst_action_cablesTableAdapter.Fill(Me.MydbDataSet.lst_action_cables,formmain.user.Nom_user)
        ''Catch ex As System.Exception
        ''    System.Windows.Forms.MessageBox.Show(ex.Message)
        ''End Try
        ''Try
        ''    Me.Lst_action_departsTableAdapter.Fill(Me.MydbDataSet.lst_action_departs,formmain.user.Nom_user)
        ''Catch ex As System.Exception
        ''    System.Windows.Forms.MessageBox.Show(ex.Message)
        ''End Try
        ''Try
        ''    Me.Lst_action_equipementsTableAdapter.Fill(Me.MydbDataSet.lst_action_equipements,formmain.user.Nom_user)
        ''Catch ex As System.Exception
        ''    System.Windows.Forms.MessageBox.Show(ex.Message)
        ''End Try

        ''Try
        ''    Me.Lst_action_tronconsTableAdapter.Fill(Me.MydbDataSet.lst_action_troncons,formmain.user.Nom_user)
        ''Catch ex As System.Exception
        ''    System.Windows.Forms.MessageBox.Show(ex.Message)
        ''End Try

        ''Try
        ''    Me.Lst_action_userTableAdapter.Fill(Me.MydbDataSet.lst_action_user,formmain.user.Nom_user)
        ''Catch ex As System.Exception
        ''    System.Windows.Forms.MessageBox.Show(ex.Message)
        ''End Try

    End Sub

    Private Sub FormMain_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.WindowState = FormWindowState.Maximized
        'init parametre

        'init login
        Me.LabelItem1.Text = "Identification en cours ...."
        Dim login As LoginForm
        login = New LoginForm

        login.ShowDialog()

        login.Dispose()

        If FormMain.user.state = True Then
            Me.LabelItem1.Text = "Selection de projet en cours ......"
            Dim formselectproject As FormSelectProject

            formselectproject = New FormSelectProject

            formselectproject.ShowDialog()
            If FormMain.user.state = False Then
                out = True
                Me.Close()

                Exit Sub
            End If

            Me.LabelItem1.Text = "connecté au projet : " & user.Project_user
            My.Settings.runtimeConnectionstring = ClassConnectionBuilder.ConnectionStringBuilder(FormMain.user.server, FormMain.user.Project_user, "root", FormMain.user.pass_user)

            My.Settings("MydbConnectionString") = ClassConnectionBuilder.ConnectionStringBuilder(FormMain.user.server, FormMain.user.Project_user, "root", FormMain.user.pass_user)
            My.Settings("mydb") = ClassConnectionBuilder.ConnectionStringBuilder(FormMain.user.server, FormMain.user.Project_user, "root", FormMain.user.pass_user)

            My.Settings.Save()

            formselectproject.Dispose()
            FormMain.user.mode = "Marché de base"
            FormMain.user.detail_modif = ""
            FormMain.user.refmodif = ""
            '   GC.Collect()
            'Dim FormMain As FormMain = New FormMain
            'FormMain.ShowDialog()
        Else
            out = True
            Me.Close()
        End If
        'init base

        Me.LabelItem2.Text = " Utilisateur en cours : " & user.Nom_user

        If Not My.Settings.About_check Then
            Dim about As AboutBox1 = New AboutBox1

            about.ShowDialog()
        End If
        init_form()
        If Not config_ini_ok Then
            Dim formoption As FormOptions
            formoption = New FormOptions
            formoption.ShowDialog()
            config_ini_ok = True
        End If

    End Sub

    Private Sub ButtonItem8_Click_1(sender As Object, e As EventArgs)
        Dim formTS As FormModification = New FormModification
        formTS.MdiParent = Me
        formTS.WindowState = FormWindowState.Maximized
        formTS.Show()
    End Sub

    Private Sub ButtonItem17_Click_1(sender As Object, e As EventArgs) Handles ButtonItem17.Click
        Dim support As FormSupport = New FormSupport
        support.ShowDialog()
    End Sub

    Private Sub Clock_Tick(sender As Object, e As EventArgs) Handles Clock.Tick
        t += 1
        With Me.NavigationPanePanel2
            .Controls.Item("labelx15").Text = FormMain.user.email
            .Controls.Item("labelx13").Text = FormMain.user.Nom_user
            .Controls.Item("labelx14").Text = FormMain.user.Prenom
            .Controls.Item("labelx17").Text = CStr(t) & "minutes"
        End With
        Me.LogTableAdapter.Fill(Me.ProgelecDataSet.log)
        Dim loguser As progelecDataSet.logRow
        Me.LogBindingSource.Filter = " user='" & FormMain.user.nom & "'"
        If Me.LogBindingSource.Count = 0 Then
            Me.LogBindingSource.AddNew()
            loguser = CType(CType(Me.LogBindingSource.Current, DataRowView).Row, progelecDataSet.logRow)
            loguser.user = FormMain.user.nom
            loguser.timestamp = Now.ToString("yyyy-MM-dd HH:mm:ss")
            Me.LogBindingSource.EndEdit()
            Me.LogTableAdapter.Update(Me.ProgelecDataSet.log)
            Me.LogTableAdapter.Fill(Me.ProgelecDataSet.log)
        Else
            Me.LogBindingSource.Position = Me.LogBindingSource.Find("user", FormMain.user.nom)
            loguser = CType(CType(Me.LogBindingSource.Current, DataRowView).Row, progelecDataSet.logRow)
            ' loguser.user = FormMain.user.nom
            loguser.timestamp = Now.ToString("yyyy-MM-dd HH:mm:ss")
            Me.LogBindingSource.EndEdit()
            Me.LogTableAdapter.Update(Me.ProgelecDataSet.log)
            Me.LogTableAdapter.Fill(Me.ProgelecDataSet.log)
        End If
        Me.LogBindingSource.Filter = Nothing
    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        Dim formseclectionmode As New FormSelectionMode
        FormSelectionMode.ShowDialog()
        Me.modetravail()
    End Sub

    Private Sub modetravail()
        Select Case FormMain.user.mode
            Case "marché de base"
                Me.ReflectionImage4.Image = My.Resources.folder_accept
                With Me.NavigationPanePanel1

                    .Controls.Item("labelx18").Text = FormMain.user.mode
                    .Controls.Item("labelx19").Text = FormMain.user.refmodif
                    .Controls.Item("labelx20").Text = FormMain.user.detail_modif

                End With

                ''troncons
                'Me.ButtonItem48.Enabled = True
                'Me.ButtonItem10.Enabled = True
                'Me.ButtonItem36.Enabled = True
                ''equipements
                'Me.ButtonItem3.Enabled = True
                'Me.ButtonItem7.Enabled = True

            Case "consultation"
                Me.ReflectionImage4.Image = My.Resources.info
                With Me.NavigationPanePanel1

                    .Controls.Item("labelx18").Text = FormMain.user.mode
                    .Controls.Item("labelx19").Text = FormMain.user.refmodif
                    .Controls.Item("labelx20").Text = FormMain.user.detail_modif
                End With

                ''troncons
                'Me.ButtonItem48.Enabled = False
                'Me.ButtonItem10.Enabled = False
                'Me.ButtonItem36.Enabled = False
                ''equipements
                'Me.ButtonItem3.Enabled = False
                'Me.ButtonItem7.Enabled = False

            Case Else
                Me.ReflectionImage4.Image = My.Resources.warning
                With Me.NavigationPanePanel1

                    .Controls.Item("labelx18").Text = FormMain.user.mode
                    .Controls.Item("labelx19").Text = FormMain.user.refmodif
                    .Controls.Item("labelx20").Text = FormMain.user.detail_modif
                End With

                ''troncons
                'Me.ButtonItem48.Enabled = True
                'Me.ButtonItem10.Enabled = True
                'Me.ButtonItem36.Enabled = True
                ''equipements
                'Me.ButtonItem3.Enabled = True
                'Me.ButtonItem7.Enabled = True
        End Select
    End Sub

    Private Sub ButtonItem36_Click(sender As Object, e As EventArgs)
        Dim formsupasstrc As FormSupAssocTroncon = New FormSupAssocTroncon
        formsupasstrc.ShowDialog()
    End Sub

    Private Sub ButtonItem35_Click(sender As Object, e As EventArgs) Handles ButtonItem35.Click
        Dim formsalles As FormSalle = New FormSalle
        formsalles.MdiParent = Me
        formsalles.WindowState = FormWindowState.Maximized
        formsalles.Show()
    End Sub

    Private Sub ButtonItem37_Click(sender As Object, e As EventArgs)
        Dim formserges As Formserge = New Formserge()
        formserges.MdiParent = Me
        formserges.WindowState = FormWindowState.Maximized
        formserges.Show()
    End Sub

    Private Sub ButtonItem66_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ButtonItem33_Click(sender As Object, e As EventArgs)
        Dim physique As FormDonnees = New FormDonnees()
        'physique.Parent = Me
        'physique.MdiParent = Me
        physique.ShowDialog()
    End Sub

#Region "Verification"

    Dim ctrl_phy As Thread

    Public Sub ctrl_phy_action()
        If IsNothing(m_AlertOnLoad2) Then
            m_AlertOnLoad2 = New AlertBases()
            Dim r As Rectangle = Screen.GetWorkingArea(Me)
            m_AlertOnLoad2.Location = New Point(r.Left, r.Bottom - m_AlertOnLoad2.Height)
            m_AlertOnLoad2.AutoClose = True
            m_AlertOnLoad2.AutoCloseTimeOut = 15
            m_AlertOnLoad2.AlertAnimation = eAlertAnimation.BottomToTop
            m_AlertOnLoad2.AlertAnimationDuration = 300
            m_AlertOnLoad2.Show(False)
            m_AlertOnLoad2.Focus()
        ElseIf m_AlertOnLoad2.IsDisposed Then
            m_AlertOnLoad2 = New AlertBases()
            Dim r As Rectangle = Screen.GetWorkingArea(Me)
            m_AlertOnLoad2.Location = New Point(r.Left, r.Bottom - m_AlertOnLoad2.Height)
            m_AlertOnLoad2.AutoClose = True
            m_AlertOnLoad2.AutoCloseTimeOut = 15
            m_AlertOnLoad2.AlertAnimation = eAlertAnimation.BottomToTop
            m_AlertOnLoad2.AlertAnimationDuration = 300
            m_AlertOnLoad2.Show(False)
            m_AlertOnLoad2.Focus()
        Else

        End If
    End Sub

    Public Function ctrl_check() As Boolean
        ctrl_check = False
        If Me.Ctrl_phybindingsource.Count > 0 Then
            ctrl_check = True
        End If

        Return ctrl_check
    End Function

    'Public Sub ctrl_1() Handles TimerServeur.Tick
    '    'If Not ctrl_phy.IsAlive Then
    '    '    ' ctrl_phy.IsBackground = True
    '    '    ctrl_phy = New Thread(AddressOf ctrl_phy_action)
    '    '    ctrl_phy.Start()
    '    'End If
    '    ctrl_phy_action()

    'End Sub

#End Region

    Private Sub ButtonX2_Click(sender As System.Object, e As System.EventArgs)
        Dim actions_globals As Form_actions_globale = New Form_actions_globale
        actions_globals.MdiParent = Me
        actions_globals.WindowState = FormWindowState.Maximized
        actions_globals.Show()
    End Sub

    Private Sub ButtonItem70_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItem70.Click
        Dim FormFournitures_lst As FormFournitures_lst = New FormFournitures_lst
        FormFournitures_lst.MdiParent = Me
        FormFournitures_lst.WindowState = FormWindowState.Maximized
        FormFournitures_lst.Show()
    End Sub

    Private Sub ButtonItem71_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItem71.Click

    End Sub

    Private Sub ButtonItem73_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItem73.Click
        Dim formdefbesoin As FormDefBesoins = New FormDefBesoins
        formdefbesoin.MdiParent = Me
        formdefbesoin.WindowState = FormWindowState.Maximized
        formdefbesoin.Show()

    End Sub

    Private Sub ButtonItem69_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItem69.Click
        Dim Form_Plg_Jalons As Form_Plg_Jalons = New Form_Plg_Jalons
        Form_Plg_Jalons.MdiParent = Me

        Form_Plg_Jalons.WindowState = FormWindowState.Maximized
        Form_Plg_Jalons.Show()
    End Sub

    Private Sub ButtonItem74_Click(sender As System.Object, e As System.EventArgs)
        Dim FormSynoptique As FormSynoptique = New FormSynoptique
        FormSynoptique.MdiParent = Me
        FormSynoptique.WindowState = FormWindowState.Maximized
        FormSynoptique.Show()
    End Sub

    Private Sub ButtonItem75_Click(sender As System.Object, e As System.EventArgs)
        Dim FormMap As FormMap = New FormMap
        FormMap.MdiParent = Me
        FormMap.WindowState = FormWindowState.Maximized
        FormMap.Show()
    End Sub

    Private Sub ButtonItem76_Click(sender As System.Object, e As System.EventArgs)
        Dim FormLst_Mat_Trc As FormLst_Mat_Trc = New FormLst_Mat_Trc
        FormLst_Mat_Trc.MdiParent = Me
        FormLst_Mat_Trc.WindowState = FormWindowState.Maximized
        FormLst_Mat_Trc.Show()
    End Sub

    Private Sub ButtonItem77_Click(sender As System.Object, e As System.EventArgs)
        Dim Form_Detail_equipement_alimentation As Form_Detail_equipement_alimentation = New Form_Detail_equipement_alimentation
        Form_Detail_equipement_alimentation.MdiParent = Me
        Form_Detail_equipement_alimentation.WindowState = FormWindowState.Maximized
        Form_Detail_equipement_alimentation.Show()
    End Sub

#Region "Chart"

    Public Sub graph() Handles ButtonX2.Click
        ' Set Back Color
        Chart2.ChartAreas("Default").BackColor = Color.White

        ' Set Back Gradient End Color
        Chart2.ChartAreas("Default").BackSecondaryColor = Color.White

        ' Set Gradient Type
        Chart2.ChartAreas("Default").BackGradientStyle = GradientStyle.DiagonalRight

        ' Set Border Color
        Chart2.ChartAreas("Default").BorderColor = Color.Blue

        ' Set Border Style
        Chart2.ChartAreas("Default").BorderDashStyle = ChartDashStyle.NotSet

        ' Set Border Width
        Chart2.ChartAreas("Default").BorderWidth = 1

        ' Set Shadow Offset
        Chart2.ChartAreas("Default").ShadowOffset = 2
        For pointIndex = 0 To 9
            Chart2.Series("Previsionel").Points.AddY(5)
            Chart2.Series("Reel").Points.AddY(8)
        Next pointIndex

        ' Set series chart type
        Chart2.Series("Previsionel").ChartType = SeriesChartType.Spline
        Chart2.Series("Reel").ChartType = SeriesChartType.Spline
    End Sub
#End Region

    Private Sub ButtonItem67_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItem67.Click
        Dim ChildWindowFound As Boolean = False
        If Not (MdiChildren.Length.Equals(0)) Then
            For Each ChildWindow As Form In MdiChildren
                If ChildWindow.Name.Equals("FormDispoSalle") Then
                    ChildWindow.Activate()
                    ChildWindowFound = True
                End If
            Next
        End If

        If Not ChildWindowFound Then
            Dim formdisposalle As FormDispoSalle = New FormDispoSalle
            formdisposalle.MdiParent = Me
            formdisposalle.WindowState = FormWindowState.Maximized
            AddHandler Me.EventFired2, AddressOf formdisposalle.actualisation
            formdisposalle.Show()
        End If

    End Sub

    Private Sub ButtonItem52_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItem52.Click
        Dim ChildWindowFound As Boolean = False
        If Not (MdiChildren.Length.Equals(0)) Then
            For Each ChildWindow As Form In MdiChildren
                If ChildWindow.Name.Equals("FormDispoEquip") Then
                    ChildWindow.Activate()
                    ChildWindowFound = True
                End If
            Next
        End If

        If Not ChildWindowFound Then
            Dim FormDispoEquip As FormDispoEquip = New FormDispoEquip
            FormDispoEquip.MdiParent = Me
            FormDispoEquip.WindowState = FormWindowState.Maximized
            AddHandler Me.EventFired3, AddressOf FormDispoEquip.actualisation
            FormDispoEquip.Show()
        End If

    End Sub

    Private Sub ButtonItem50_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItem50.Click
        Dim ChildWindowFound As Boolean = False

        If Not (MdiChildren.Length.Equals(0)) Then
            For Each ChildWindow As Form In MdiChildren
                If ChildWindow.Name.Equals("FormDsipoCheminements") Then
                    ChildWindow.Activate()
                    ChildWindowFound = True
                End If
            Next
        End If

        If Not ChildWindowFound Then
            Dim FormDsipoCheminements As FormDsipoCheminements = New FormDsipoCheminements
            FormDsipoCheminements.MdiParent = Me
            FormDsipoCheminements.WindowState = FormWindowState.Maximized
            AddHandler Me.EventFired4, AddressOf FormDsipoCheminements.actualisation
            FormDsipoCheminements.Show()
        End If

    End Sub

    Private Sub tabStrip1_SelectedTabChanged(sender As System.Object, e As DevComponents.DotNetBar.TabStripTabChangedEventArgs) Handles tabStrip1.SelectedTabChanged
        Dim activeChild As Form = Me.ActiveMdiChild
        'For Each f In MdiChildren
        '    If f.Name Is ActiveMdiChild.Name Then
        '        RaiseEvent OnDoSomething()
        '    End If

        'Next
        If (Not activeChild Is Nothing) Then
            If ActiveMdiChild.Name = "FormDispoTirage" Then
                RaiseEvent EventFired()
            ElseIf ActiveMdiChild.Name = "formdisposalle" Then
                RaiseEvent EventFired2()
            ElseIf ActiveMdiChild.Name = "FormDispoEquip" Then
                RaiseEvent EventFired3()
            ElseIf ActiveMdiChild.Name = "FormDsipoCheminements" Then
                RaiseEvent EventFired4()

            ElseIf ActiveMdiChild.Name = "FormLstCables" Then
                RaiseEvent EventFired8()
            ElseIf ActiveMdiChild.Name = "FormDispoRaccordement" Then
                Dim form2 As FormDispoRaccordement = DirectCast(ActiveMdiChild, FormDispoRaccordement)
                form2.Actualisation()
                '   RaiseEvent EventFired6()
            ElseIf ActiveMdiChild.Name = "FormTouretsliste" Then
                RaiseEvent EventFired7()
            ElseIf ActiveMdiChild.Name = "FormLstSalles" Then
                RaiseEvent EventFired9()
            End If
        End If
    End Sub

    Private Sub ButtonItem55_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItem55.Click

        Dim ChildWindowFound As Boolean = False

        If Not (MdiChildren.Length.Equals(0)) Then
            For Each ChildWindow As Form In MdiChildren
                If ChildWindow.Name.Equals("FormDispoTirage") Then
                    ChildWindow.Activate()
                    ChildWindowFound = True
                End If
            Next
        End If

        If Not ChildWindowFound Then
            Dim FormDispoTirage As FormDispoTirage = New FormDispoTirage
            FormDispoTirage.MdiParent = Me
            FormDispoTirage.WindowState = FormWindowState.Maximized
            AddHandler Me.EventFired, AddressOf FormDispoTirage.actualisation
            FormDispoTirage.Show()
        End If

        'Dim FormDispoTirage As FormDispoTirage = New FormDispoTirage
        'FormDispoTirage.MdiParent = Me
        'FormDispoTirage.WindowState = FormWindowState.Maximized
        'AddHandler Me.EventFired, AddressOf FormDispoTirage.actualisation
        'FormDispoTirage.Show()
    End Sub

    Private Sub ButtonItem57_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItem57.Click
        Dim ChildWindowFound As Boolean = False

        If Not (MdiChildren.Length.Equals(0)) Then
            For Each ChildWindow As Form In MdiChildren
                If ChildWindow.Name.Equals("FormDispoRaccordement") Then
                    ChildWindow.Activate()
                    ChildWindowFound = True
                End If
            Next
        End If

        If Not ChildWindowFound Then
            Dim FormDispoRaccordement As FormDispoRaccordement = New FormDispoRaccordement
            FormDispoRaccordement.MdiParent = Me
            FormDispoRaccordement.WindowState = FormWindowState.Maximized
            AddHandler Me.EventFired6, AddressOf FormDispoRaccordement.Actualisation
            FormDispoRaccordement.Show()
        End If

    End Sub

    Private Sub ButtonItem38_Click(sender As System.Object, e As System.EventArgs)
        Dim ChildWindowFound As Boolean = False

        If Not (MdiChildren.Length.Equals(0)) Then
            For Each ChildWindow As Form In MdiChildren
                If ChildWindow.Name.Equals("FormTouretsliste") Then
                    ChildWindow.Activate()
                    ChildWindowFound = True
                End If
            Next
        End If

        If Not ChildWindowFound Then
            Dim FormTouretsliste As FormTouretsliste = New FormTouretsliste
            FormTouretsliste.MdiParent = Me
            FormTouretsliste.WindowState = FormWindowState.Maximized
            AddHandler Me.EventFired7, AddressOf FormTouretsliste.actualisation
            FormTouretsliste.Show()
        End If
    End Sub

    Private Sub ButtonItem79_Click(sender As System.Object, e As System.EventArgs)
        Dim FormSalle As FormSalle
        FormSalle = New FormSalle
        FormSalle.MdiParent = Me
        FormSalle.WindowState = FormWindowState.Maximized
        ' AddHandler Parent.EventFired2, AddressOf FormDsipoCheminements.actualisation

        FormSalle.Show()
    End Sub

    Private Sub ButtonItem102_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItem102.Click
        Dim about As AboutBox1 = New AboutBox1

        about.ShowDialog()
    End Sub

    Private Sub ButtonItem58_Click(sender As Object, e As EventArgs)
        Dim formRapportProjet As FormRapportProjet
        formRapportProjet = New FormRapportProjet
        formRapportProjet.MdiParent = Me
        formRapportProjet.WindowState = FormWindowState.Maximized
        formRapportProjet.Show()
    End Sub

    Private Sub ButtonItem103_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ButtonItem104_Click(sender As Object, e As EventArgs) Handles ButtonItem104.Click
        Dim ChildWindowFound As Boolean = False

        If Not (MdiChildren.Length.Equals(0)) Then
            For Each ChildWindow As Form In MdiChildren
                If ChildWindow.Name.Equals("FormCtrlEtudes") Then
                    ChildWindow.Activate()
                    ChildWindowFound = True
                End If
            Next
        End If

        If Not ChildWindowFound Then
            Dim FormCtrlEtudes As FormCtrlEtudes = New FormCtrlEtudes
            FormCtrlEtudes.MdiParent = Me
            FormCtrlEtudes.WindowState = FormWindowState.Maximized
            AddHandler Me.EventFired7, AddressOf FormCtrlEtudes.Actualisation
            FormCtrlEtudes.Show()
        End If
    End Sub

    Private Sub ButtonItem82_Click(sender As Object, e As EventArgs) Handles ButtonItem82.Click
  
        Dim ChildWindowFound As Boolean = False

        If Not (MdiChildren.Length.Equals(0)) Then
            For Each ChildWindow As Form In MdiChildren
                If ChildWindow.Name.Equals("FormLstSalles") Then
                    ChildWindow.Activate()
                    ChildWindowFound = True
                End If
            Next
        End If

        If Not ChildWindowFound Then
            Dim FormLstSalles As FormLstSalles = New FormLstSalles
            FormLstSalles.MdiParent = Me
            FormLstSalles.WindowState = FormWindowState.Maximized
            AddHandler Me.EventFired9, AddressOf FormLstSalles.actualisation
            FormLstSalles.Show()
        End If
    End Sub

    Private Sub ButtonItem83_Click(sender As Object, e As EventArgs) Handles ButtonItem83.Click
        Dim ChildWindowFound As Boolean = False

        If Not (MdiChildren.Length.Equals(0)) Then
            For Each ChildWindow As Form In MdiChildren
                If ChildWindow.Name.Equals("FormSalle") Then
                    ChildWindow.Activate()
                    ChildWindowFound = True
                End If
            Next
        End If

        If Not ChildWindowFound Then
            Dim FormSalle As FormSalle
            FormSalle = New FormSalle
            FormSalle.MdiParent = Me
            FormSalle.WindowState = FormWindowState.Maximized

            FormSalle.Show()
        End If

    End Sub

    Private Sub ButtonItem85_Click(sender As Object, e As EventArgs) Handles ButtonItem85.Click
        Dim ChildWindowFound As Boolean = False

        If Not (MdiChildren.Length.Equals(0)) Then
            For Each ChildWindow As Form In MdiChildren
                If ChildWindow.Name.Equals("FormTroncon") Then
                    ChildWindow.Activate()
                    ChildWindowFound = True
                End If
            Next
        End If

        If Not ChildWindowFound Then
            Dim FormTroncon As FormTroncon
            FormTroncon = New FormTroncon
            FormTroncon.MdiParent = Me
            FormTroncon.WindowState = FormWindowState.Maximized
            FormTroncon.mode = True
            FormTroncon.Show()
        End If

    End Sub

    Private Sub ButtonItem86_Click(sender As Object, e As EventArgs) Handles ButtonItem86.Click
        Dim FormLstTroncons As FormLstTroncons
        FormLstTroncons = New FormLstTroncons
        FormLstTroncons.MdiParent = Me
        FormLstTroncons.WindowState = FormWindowState.Maximized
        FormLstTroncons.Show()
    End Sub

    Private Sub ButtonItem87_Click(sender As Object, e As EventArgs) Handles ButtonItem87.Click
        Dim ChildWindowFound As Boolean = False

        If Not (MdiChildren.Length.Equals(0)) Then
            For Each ChildWindow As Form In MdiChildren
                If ChildWindow.Name.Equals("FormAssocTroncons") Then
                    ChildWindow.Activate()
                    ChildWindowFound = True
                End If
            Next
        End If

        If Not ChildWindowFound Then
            Dim FormAssocTroncons As FormAssocTroncons
            FormAssocTroncons = New FormAssocTroncons
            FormAssocTroncons.MdiParent = Me
            FormAssocTroncons.WindowState = FormWindowState.Maximized
            FormAssocTroncons.Show()
        End If

    End Sub

    Private Sub ButtonItem89_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ButtonItem90_Click(sender As Object, e As EventArgs) Handles ButtonItem90.Click
        Dim FormLst_Mat_Trc As FormLst_Mat_Trc = New FormLst_Mat_Trc
        FormLst_Mat_Trc.MdiParent = Me
        FormLst_Mat_Trc.WindowState = FormWindowState.Maximized
        FormLst_Mat_Trc.Show()
    End Sub

    Private Sub ButtonItem91_Click(sender As Object, e As EventArgs) Handles ButtonItem91.Click
        Dim FormLstEquipement As FormLstEquipement
        FormLstEquipement = New FormLstEquipement
        FormLstEquipement.MdiParent = Me
        FormLstEquipement.WindowState = FormWindowState.Maximized
        FormLstEquipement.Show()
    End Sub

    Private Sub ButtonItem92_Click(sender As Object, e As EventArgs) Handles ButtonItem92.Click
        Dim ChildWindowFound As Boolean = False

        If Not (MdiChildren.Length.Equals(0)) Then
            For Each ChildWindow As Form In MdiChildren
                If ChildWindow.Name.Equals("frmequip") Then
                    ChildWindow.Activate()
                    ChildWindowFound = True
                End If
            Next
        End If

        If Not ChildWindowFound Then
            Dim frmequip As FormEquipement
            frmequip = New FormEquipement
            frmequip.MdiParent = Me
            frmequip.WindowState = FormWindowState.Maximized
            frmequip.mode = True
            frmequip.Show()
        End If

    End Sub

    Private Sub ButtonItem95_Click(sender As Object, e As EventArgs) Handles ButtonItem95.Click
        Dim Form_Detail_equipement_alimentation As Form_Detail_equipement_alimentation = New Form_Detail_equipement_alimentation
        Form_Detail_equipement_alimentation.MdiParent = Me
        Form_Detail_equipement_alimentation.WindowState = FormWindowState.Maximized
        Form_Detail_equipement_alimentation.Show()
    End Sub

    Private Sub ButtonItem96_Click(sender As Object, e As EventArgs) Handles ButtonItem96.Click
        Dim FormLstCables As FormLstCables
        FormLstCables = New FormLstCables
        FormLstCables.MdiParent = Me
        FormLstCables.WindowState = FormWindowState.Maximized
        FormLstCables.Show()
    End Sub

    Private Sub ButtonItem97_Click(sender As Object, e As EventArgs) Handles ButtonItem97.Click
        Dim ChildWindowFound As Boolean = False

        If Not (MdiChildren.Length.Equals(0)) Then
            For Each ChildWindow As Form In MdiChildren
                If ChildWindow.Name.Equals("frmcable") Then
                    ChildWindow.Activate()
                    ChildWindowFound = True
                End If
            Next
        End If

        If Not ChildWindowFound Then
            Dim frmcable As FormCable
            frmcable = New FormCable
            frmcable.MdiParent = Me
            frmcable.WindowState = FormWindowState.Maximized
            ' frmcable.action = "new"
            frmcable.mode = True
            frmcable.Show()
        End If

    End Sub

    Private Sub ButtonItem3_Click_1(sender As Object, e As EventArgs) Handles ButtonItem3.Click
        Dim formsuptrc As FormSupTroncon = New FormSupTroncon
        formsuptrc.ShowDialog(Me)
    End Sub

    Private Sub ButtonItem4_Click_1(sender As Object, e As EventArgs) Handles ButtonItem4.Click
        Dim formsupasstrc As FormSupAssocTroncon = New FormSupAssocTroncon
        formsupasstrc.ShowDialog(Me)
    End Sub

    Private Sub ButtonItem11_Click_1(sender As Object, e As EventArgs) Handles ButtonItem11.Click
        Dim FormCategorie As FormCategorie
        FormCategorie = New FormCategorie

        FormCategorie.ShowDialog(Me)
    End Sub

    Private Sub ButtonItem12_Click(sender As Object, e As EventArgs) Handles ButtonItem12.Click
        Dim formserges As Formserge = New Formserge()
        formserges.MdiParent = Me
        formserges.WindowState = FormWindowState.Maximized
        formserges.Show()
    End Sub

    Private Sub ButtonItem16_Click_1(sender As Object, e As EventArgs) Handles ButtonItem16.Click
        Dim FormSynoptique As FormSynoptique = New FormSynoptique
        FormSynoptique.MdiParent = Me
        FormSynoptique.WindowState = FormWindowState.Maximized
        FormSynoptique.Show()
    End Sub

    Private Sub ButtonItem2_Click_1(sender As Object, e As EventArgs) Handles ButtonItem2.Click
        Dim physique As FormDonnees = New FormDonnees()
        'physique.Parent = Me
        'physique.MdiParent = Me
        physique.ShowDialog(Me)
    End Sub

    Private Sub ButtonItem18_Click_1(sender As Object, e As EventArgs) Handles ButtonItem18.Click
        Dim FormLots As FormLots
        FormLots = New FormLots

        FormLots.Show(Me)
    End Sub

    Private Sub ButtonItem39_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ButtonItem9_Click_1(sender As Object, e As EventArgs) Handles ButtonItem9.Click
        Dim Form_reseaux As Form_reseaux = New Form_reseaux()
        'physique.Parent = Me
        'physique.MdiParent = Me
        Form_reseaux.ShowDialog(Me)
    End Sub

    Private Sub ButtonItem23_Click(sender As Object, e As EventArgs) Handles ButtonItem23.Click
        Dim ChildWindowFound As Boolean = False
        If Not (MdiChildren.Length.Equals(0)) Then
            For Each ChildWindow As Form In MdiChildren
                If ChildWindow.Name.Equals("ad_FormTouretsDetail") Then
                    ChildWindow.Activate()
                    ChildWindowFound = True
                End If
            Next
        End If

        If Not ChildWindowFound Then
            Dim ad_FormTouretsDetail As FormTouretsDetail
            ad_FormTouretsDetail = New FormTouretsDetail
            ad_FormTouretsDetail.MdiParent = Me
            ad_FormTouretsDetail.WindowState = FormWindowState.Maximized
            ' frmcable.action = "new"
            ad_FormTouretsDetail.mode = True
            ad_FormTouretsDetail.Show()
        End If
    End Sub

    Private Sub ButtonItem22_Click(sender As Object, e As EventArgs) Handles ButtonItem22.Click
        Dim ChildWindowFound As Boolean = False

        If Not (MdiChildren.Length.Equals(0)) Then
            For Each ChildWindow As Form In MdiChildren
                If ChildWindow.Name.Equals("FormTouretsliste") Then
                    ChildWindow.Activate()
                    ChildWindowFound = True
                End If
            Next
        End If

        If Not ChildWindowFound Then
            Dim FormTouretsliste As FormTouretsliste = New FormTouretsliste
            FormTouretsliste.MdiParent = Me
            FormTouretsliste.WindowState = FormWindowState.Maximized
            AddHandler Me.EventFired7, AddressOf FormTouretsliste.actualisation
            FormTouretsliste.Show()
        End If
    End Sub

    Private Sub PlanningBtn_Click(sender As Object, e As EventArgs) Handles PlanningBtn.Click
        Dim formshedule As New FormShedule
        formshedule.MdiParent = Me
        formshedule.WindowState = FormWindowState.Maximized
        formshedule.Show()
    End Sub

    Private Sub FormMain_FormClosed(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If out Then

            Exit Sub

        Else
            Dim info As New TaskDialogInfo("AVERTISSEMENT", eTaskDialogIcon.Hand, "Fermeture de progelec", "La fermeture entrainera la perte de toutes modifications non sauvegardés  ", eTaskDialogButton.Ok Or eTaskDialogButton.Cancel, eTaskDialogBackgroundColor.Red)
            Dim result As eTaskDialogResult = TaskDialog.Show(info)
            Select Case result

                Case eTaskDialogResult.Ok
                    Exit Sub
                Case eTaskDialogResult.Cancel
                    e.Cancel = True
            End Select
        End If

    End Sub

    Private Sub Fermeture()
        If out Then

        Else
            Dim info As New TaskDialogInfo("AVERTISSEMENT", eTaskDialogIcon.Hand, "Fermeture de progelec", "La fermeture entrainera la perte de toutes modifications non sauvegardés  ", eTaskDialogButton.Ok Or eTaskDialogButton.Cancel, eTaskDialogBackgroundColor.Red)
            Dim result As eTaskDialogResult = TaskDialog.Show(info)
            Select Case result

                Case eTaskDialogResult.Ok
                    Exit Sub

            End Select

        End If

    End Sub

    Private Sub ButtonItem1_Click_1(sender As Object, e As EventArgs) Handles ButtonItem1.Click
        Dim formarchi As FormArchi
        formarchi = New FormArchi
        formarchi.MdiParent = Me
        formarchi.WindowState = FormWindowState.Maximized
        ' AddHandler Parent.EventFired2, AddressOf FormDsipoCheminements.actualisation

        formarchi.Show()
    End Sub

    Private Sub ButtonItem68_Click(sender As Object, e As EventArgs) Handles ButtonItem68.Click
        Dim info As New TaskDialogInfo("AVERTISSEMENT", eTaskDialogIcon.Hand, "Fermeture du projet", "La fermeture entrainera la perte de toutes modifications non sauvegardés  ", eTaskDialogButton.Ok Or eTaskDialogButton.Cancel, eTaskDialogBackgroundColor.Red)
        Dim result As eTaskDialogResult = TaskDialog.Show(info)
        Select Case result

            Case eTaskDialogResult.Ok
                Dim formselectproject As FormSelectProject

                formselectproject = New FormSelectProject

                formselectproject.ShowDialog()

                My.Settings.runtimeConnectionstring = ClassConnectionBuilder.ConnectionStringBuilder(FormMain.user.server, FormMain.user.Project_user, "root", FormMain.user.pass_user)

                My.Settings("MydbConnectionString") = ClassConnectionBuilder.ConnectionStringBuilder(FormMain.user.server, FormMain.user.Project_user, "root", FormMain.user.pass_user)
                My.Settings("mydb") = ClassConnectionBuilder.ConnectionStringBuilder(FormMain.user.server, FormMain.user.Project_user, "root", FormMain.user.pass_user)

                My.Settings.Save()

                formselectproject.Dispose()
                Me.Text = "Projet : " & FormMain.user.Project_user
                FormMain.user.mode = "Marché de base"
                FormMain.user.detail_modif = ""
                FormMain.user.refmodif = ""
                Me.LabelItem1.Text = "connecté au projet : " & FormMain.user.Project_user
            Case eTaskDialogResult.Cancel
                Exit Sub
        End Select
    End Sub
    Public Sub init_form()
        AddHandler Me.EventFired6, AddressOf FormDispoRaccordement.Actualisation
        'TODO: This line of code loads data into the 'MydbDataSet.ctrl_phy' table. You can move, or remove it, as needed.
        Me.Ctrl_phyTableAdapter.Fill(Me.MydbDataSet.ctrl_phy)
        'TODO: This line of code loads data into the 'MydbDataSet.lst_besoin_cables' table. You can move, or remove it, as needed.
        Me.Lst_besoin_cablesTableAdapter.Fill(Me.MydbDataSet.lst_besoin_cables)
        Me.Type_docTableAdapter.Fill(MydbDataSet.type_doc)
        bw = New BackgroundWorker
        bw.WorkerSupportsCancellation = True
        bw.WorkerReportsProgress = True
        AddHandler bw.DoWork, AddressOf bw_DoWork
        AddHandler bw.ProgressChanged, AddressOf bw_ProgressChanged
        AddHandler bw.RunWorkerCompleted, AddressOf bw_RunWorkerCompleted
        'TODO: This line of code loads data into the 'MydbDataSet.type_doc' table. You can move, or remove it, as needed.
        Try
            Dim s As DataRowView       '
            s = CType(Me.type_doc.Item(Me.type_doc.Find("type_doc", "Carnet de deroulage")), DataRowView)
            FormMain.user.option1 = s.Item("reference").ToString

            s = CType(Me.type_doc.Item(Me.type_doc.Find("type_doc", "Calcul DCC")), DataRowView)

            FormMain.user.option2 = s.Item("reference").ToString
            s = CType(Me.type_doc.Item(Me.type_doc.Find("type_doc", "Carnet de cables")), DataRowView)

            FormMain.user.option3 = s.Item("reference").ToString
            s = CType(Me.type_doc.Item(Me.type_doc.Find("type_doc", "Carnet de tremies")), DataRowView)

            FormMain.user.option4 = s.Item("reference").ToString

            Me.Text = "Projet : " & FormMain.user.Project_user
            config_ini_ok = True
        Catch ex As Exception
            Me.type_doc.Filter = "type_doc='Carnet de deroulage'"
            If Me.type_doc.Count = 0 Then
                Me.type_doc.AddNew()
                CType(CType(Me.type_doc.Current, DataRowView).Row, MydbDataSet.type_docRow).type_doc = "Carnet de deroulage"
                Me.type_doc.EndEdit()
                Me.Type_docTableAdapter.Update(MydbDataSet.type_doc)
                Me.Type_docTableAdapter.Fill(MydbDataSet.type_doc)
            End If
            Me.type_doc.RemoveFilter()
            Me.type_doc.Filter = "type_doc='Calcul DCC'"
            If Me.type_doc.Count = 0 Then
                Me.type_doc.AddNew()
                CType(CType(Me.type_doc.Current, DataRowView).Row, MydbDataSet.type_docRow).type_doc = "Calcul DCC"
                Me.type_doc.EndEdit()
                Me.Type_docTableAdapter.Update(MydbDataSet.type_doc)
                Me.Type_docTableAdapter.Fill(MydbDataSet.type_doc)
            End If
            Me.type_doc.RemoveFilter()
            Me.type_doc.Filter = "type_doc='Carnet de cables'"
            If Me.type_doc.Count = 0 Then
                Me.type_doc.AddNew()
                CType(CType(Me.type_doc.Current, DataRowView).Row, MydbDataSet.type_docRow).type_doc = "Carnet de cables"
                Me.type_doc.EndEdit()
                Me.Type_docTableAdapter.Update(MydbDataSet.type_doc)
                Me.Type_docTableAdapter.Fill(MydbDataSet.type_doc)
            End If
            Me.type_doc.RemoveFilter()
            Me.type_doc.Filter = "type_doc='Carnet de tremies'"
            If Me.type_doc.Count = 0 Then
                Me.type_doc.AddNew()
                CType(CType(Me.type_doc.Current, DataRowView).Row, MydbDataSet.type_docRow).type_doc = "Carnet de tremies"
                Me.type_doc.EndEdit()
                Me.Type_docTableAdapter.Update(MydbDataSet.type_doc)
                Me.Type_docTableAdapter.Fill(MydbDataSet.type_doc)
            End If
            Me.type_doc.RemoveFilter()
            config_ini_ok = False
        End Try
        Me.Type_docTableAdapter.Fill(Me.MydbDataSet.type_doc)

        With Me.NavigationPanePanel2
            .Controls.Item("labelx15").Text = FormMain.user.email
            .Controls.Item("labelx13").Text = FormMain.user.Nom_user
            .Controls.Item("labelx14").Text = FormMain.user.Prenom
            .Controls.Item("labelx17").Text = CStr(t) & "secondes"
            .Controls.Item("labelx22").Text = FormMain.user.server

        End With
        With Me.NavigationPanePanel1
            .Controls.Item("LabelX18").Text = "Consultation"
            .Controls.Item("labelX19").Text = ""
            .Controls.Item("labelX20").Text = ""
        End With
        Me.Bar3.Text = "INFORMATIONS"

        Me.ReflectionImage4.Image = My.Resources.info
        'Ifformmain.user.mode = "Consultation" Then
        '    'troncons
        '    Me.ButtonItem48.Enabled = False
        '    Me.ButtonItem10.Enabled = False
        '    Me.ButtonItem36.Enabled = False
        '    'equipements
        '    Me.ButtonItem3.Enabled = False
        '    Me.ButtonItem7.Enabled = False
        'End If

        'ctrl_phy = New Thread(AddressOf ctrl_phy_action)

        'Try
        '    Me.Lst_action_borniersTableAdapter.Fill(Me.MydbDataSet.lst_action_borniers,formmain.user.Nom_user)
        'Catch ex As System.Exception
        '    System.Windows.Forms.MessageBox.Show(ex.Message)
        'End Try
        'Try
        '    Me.Lst_action_cablesTableAdapter.Fill(Me.MydbDataSet.lst_action_cables,formmain.user.Nom_user)
        'Catch ex As System.Exception
        '    System.Windows.Forms.MessageBox.Show(ex.Message)
        'End Try
        'Try
        '    Me.Lst_action_departsTableAdapter.Fill(Me.MydbDataSet.lst_action_departs,formmain.user.Nom_user)
        'Catch ex As System.Exception
        '    System.Windows.Forms.MessageBox.Show(ex.Message)
        'End Try
        'Try
        '    Me.Lst_action_equipementsTableAdapter.Fill(Me.MydbDataSet.lst_action_equipements,formmain.user.Nom_user)
        'Catch ex As System.Exception
        '    System.Windows.Forms.MessageBox.Show(ex.Message)
        'End Try

        'Try
        '    Me.Lst_action_tronconsTableAdapter.Fill(Me.MydbDataSet.lst_action_troncons,formmain.user.Nom_user)
        'Catch ex As System.Exception
        '    System.Windows.Forms.MessageBox.Show(ex.Message)
        'End Try

        'Try
        '    Me.Lst_action_userTableAdapter.Fill(Me.MydbDataSet.lst_action_user,formmain.user.Nom_user)
        'Catch ex As System.Exception
        '    System.Windows.Forms.MessageBox.Show(ex.Message)
        'End Try
    End Sub
    Public Sub init()

        ini_serveur()
        Dim splash As SplashScreen = CType(My.Application.SplashScreen, SplashScreen)
        Try
            'Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException)
            'Application.EnableVisualStyles()
            'Application.SetCompatibleTextRenderingDefault(False)
            FastReport.Utils.RegisteredObjects.AddConnection(GetType(MySqlDataConnection))
        Catch ex As Exception

        End Try
        Try
            splash.UpdateProgress("Initialisation Configuration ..", 5)
            _fichier = "debug.zip"
            Dim Chemin As String
            Chemin = Application.StartupPath & "\"
            If Exists(Chemin & _fichier) Then
                Dim launchProc As String
                launchProc = Application.StartupPath & "\patcher.exe "
                Shell(launchProc, AppWinStyle.NormalFocus)
                'Process.Start(Chemin & fichier)
                'Exit Sub
                out = True
                Me.Close()
                Exit Sub

            End If
            System.Threading.Thread.Sleep(1500)
        Catch ex As Exception
            MsgBox("Probleme d'initialisation configuration")
            Application.Exit()
        End Try

        Try
            If My.Settings.MustUpgrade Then
                My.Settings.Upgrade()
                My.Settings.MustUpgrade = False
                My.Settings.Save()
            End If
            splash.UpdateProgress("Recuperation des anciens paramétres ....", 25)
        Catch ex As Exception
            Dim el As New progelec.ErrorLogger
            el.WriteToErrorLog(ex.Message, ex.StackTrace, "init_setting")

        End Try

        Dim ini As New INIFile

        ini.LoadINI("config.ini")

        ' ini_serveur = ini.GetSection("SECTION=serveur").GetKey("address").value()
        FormMain.user.server = ini.GetSection("SECTION=serveur").GetKey("address").value()
        FormMain.user.update = ini.GetSection("SECTION=update").GetKey("serveur").value()
        FormMain.user.pass_user = ini.GetSection("SECTION=serveur").GetKey("password").value()

        out = False

        Try
            splash.UpdateProgress("Test connecxion au serveur ..", 45)
            MysqlConn = New MySqlConnection()

            MysqlConn.ConnectionString = "server=" & FormMain.user.server & ";" _
     & "user id=root;" _
     & "password=" & FormMain.user.pass_user & ";" _
     & "database=progelec"
            Const query As String = "SELECT * FROM maintenance"
            Dim reader As MySqlDataReader

            Dim cmd As New MySqlCommand(query, MysqlConn)

            Try
                MysqlConn.Open()

                reader = cmd.ExecuteReader()
                While reader.Read()

                    For i As Integer = 0 To reader.FieldCount - 1

                        maintenance = reader.GetBoolean("statut")
                        Debug.WriteLine(reader.GetValue(i).ToString())
                    Next
                End While

                MysqlConn.Close()
                System.Threading.Thread.Sleep(1500)
            Catch myerror As MySqlException
                MessageBox.Show("Une erreur est survenu sur la comunication Clent Serveur Contactez votre administrateur: " & myerror.Message)

                Application.Exit()
            Finally
                MysqlConn.Dispose()
            End Try

            MysqlConn.Close()
            MysqlConn.Dispose()
        Catch myerror As MySqlException

        End Try

        If maintenance = True Then
            Me.WindowState = FormWindowState.Maximized

            MsgBox("La base est en maintenance veuillez revenir plus tard")
            out = True
        End If
        If out = True Then
            Me.Close()
            Exit Sub
        End If

        Dim AssemblyName As String = "progelec"

        AutoUpdate.RemotePath = FormMain.user.update

        AutoUpdate.UpdateFileName = "MyUpdate.dat"
        splash.UpdateProgress("Controle de mise à jours sur le serveur ..", 75)
        If AutoUpdate.UpdateFiles(AssemblyName & "/") Then

            If Environment.Is64BitOperatingSystem Then
                ' MessageBox.Show("2")
                Dim launchProc As String
                launchProc = Application.StartupPath & "\updater.exe " & AutoUpdate.RemotePath & AssemblyName & "/" & AutoUpdate.UpdateFileName & " " & AutoUpdate.RemotePath & AssemblyName & "/"
                Shell(launchProc, AppWinStyle.NormalFocus)
                out = True
            Else

                'Instance de la classe Process
                Dim proc As New System.Diagnostics.Process()
                proc.StartInfo.Arguments = String.Format(" ""{0}"" ""{1}""", AutoUpdate.RemotePath & AssemblyName & "/" & AutoUpdate.UpdateFileName, AutoUpdate.RemotePath & AssemblyName & "/")
                proc.StartInfo.FileName = Application.StartupPath & "\updater.exe"

                proc.Start()
                out = True
            End If

        End If

        If out = True Then
            Me.WindowState = FormWindowState.Maximized
            Me.Close()
            Exit Sub

        End If

        ' AutoUpdate.ErrorMessage = "Une erreur vien de ce produire lors de la mise à jour veuillez recommencer."

        'Dim splash As New SplashScreen
        'splash.Show()
        'splash.Refresh()

        My.Settings("ProgelecConnectionString") = ClassConnectionBuilder.ConnectionStringBuilder(FormMain.user.server, "progelec", "root", FormMain.user.pass_user)
        My.Settings.Save()
        ' My.Settings.Reload()

        System.Threading.Thread.Sleep(3000)
        '  splash.Close()
        ' Application.Run(New Form1)

        FormMain.user.state = False

    End Sub

    Private Sub ButtonItem25_Click(sender As Object, e As EventArgs) Handles ButtonItem25.Click
        If user.Nom_user = "admin" Or check_profils(user.Nom_user, user.Project_user, "Admin") Then

            Dim FormAdministration As New FormAdministration() With {.MdiParent = Me}
            FormAdministration.Show()
        End If
    End Sub

    Private Sub ButtonItem14_Click(sender As Object, e As EventArgs) Handles ButtonItem14.Click
        If user.Nom_user = "admin" Or check_profils(user.Nom_user, user.Project_user, "Admin") Then
            Const stXL_SUBKEY As String = "\Excel.Application\CurVer"
            Dim rkVersionKey As RegistryKey = Nothing
            rkVersionKey = Registry.ClassesRoot.OpenSubKey(name:=stXL_SUBKEY, writable:=False)

            If rkVersionKey Is Nothing Then
                'not installed
                MessageBox.Show("Ms Excel n'est pas installé." _
                    & Microsoft.VisualBasic.ControlChars.CrLf & "" _
                    & Microsoft.VisualBasic.ControlChars.CrLf & "Pour utiliser cette fonction merci d'installer Ms Excel 2010", "Verification presence office", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Else
                Dim formimport As New OfficeFormImportNoteDeCalcul() With {.MdiParent = Me}
                formimport.WindowState = FormWindowState.Maximized
                formimport.Show()
            End If

        End If
    End Sub

    Private Sub ButtonItem8_Click_2(sender As Object, e As EventArgs) Handles ButtonItem8.Click
        Dim ChildWindowFound As Boolean = False

        If Not (MdiChildren.Length.Equals(0)) Then
            For Each ChildWindow As Form In MdiChildren
                If ChildWindow.Name.Equals("FormPieceMarchandise") Then
                    ChildWindow.Activate()
                    ChildWindowFound = True
                End If
            Next
        End If

        If Not ChildWindowFound Then
            Dim FormPieceMarchandise As FormPieceMarchandise = New FormPieceMarchandise
            FormPieceMarchandise.MdiParent = Me
            FormPieceMarchandise.WindowState = FormWindowState.Maximized
            ' AddHandler Me.EventFired7, AddressOf FormTouretsliste.actualisation
            FormPieceMarchandise.Show()
        End If
    End Sub

    Private Sub ButtonItem15_Click(sender As Object, e As EventArgs) Handles ButtonItem15.Click
        Dim FormSap As FormSap = New FormSap
        FormSap.MdiParent = Me
        FormSap.WindowState = FormWindowState.Maximized
        ' AddHandler Me.EventFired7, AddressOf FormTouretsliste.actualisation
        FormSap.Show()
    End Sub

#Region " Controle Base"
    Private Sub ctrl_tourets()

    End Sub
#End Region
End Class