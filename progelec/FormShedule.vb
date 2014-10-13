Imports Braincase.GanttChart

Public Class FormShedule
    Dim manager As ProjectManager = New ProjectManager()
    Dim lot As Integer
    Private Sub FormShedule_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        '  ButtonX1.PerformClick()
        ' BackgroundWorker1.RunWorkerAsync()
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.troncons_status'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.Troncons_statusTableAdapter.Fill(Me.MydbDataSet.troncons_status)
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.equipements_status'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.Equipements_statusTableAdapter.Fill(Me.MydbDataSet.equipements_status)
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.lots'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.LotsTableAdapter.Fill(Me.MydbDataSet.lots)
        'TODO: cette ligne de code charge les données dans la table 'MydbDataSet.salles_status'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.Salles_statusTableAdapter.Fill(Me.MydbDataSet.salles_status)
        'Dim manager As ProjectManager = New ProjectManager()
        'manager.Start = CDate("24/07/2013")
        Me.LotsBindingSource.Filter = "principale=true"
        lot = CType(DirectCast(Me.LotsBindingSource.Current, DataRowView).Row, mydbDataSet.lotsRow).idlots
        'Dim task As Task = New Task()
        'task.Name = "essais"

        'manager.Add(task)
        Panel1.Visible = False
        Me.BackgroundWorker1.WorkerReportsProgress = True
        Me.CircularProgress1.Maximum = Salles_statusBindingSource.Count - 1
        Me.CircularProgress1.Visible = True

    End Sub

   
    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub FormShedule_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        BackgroundWorker1.RunWorkerAsync()
        'Chart1.Init(manager)
        'DataGridViewX1.DataSource = New BindingSource(manager.Tasks, Nothing)
    End Sub
    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged

        CircularProgress1.Value = e.ProgressPercentage


    End Sub

  

    Private Sub Chart1_TaskSelected(sender As Object, e As TaskMouseEventArgs) Handles Chart1.TaskSelected
        AdvPropertyGrid2.SelectedObjects = Chart1.SelectedTasks.Select(Function(x) If(manager.IsPart(x), manager.SplitTaskOf(x), x)).ToArray()
    End Sub

   

    Private Sub DataGridViewX1_MouseClick(sender As Object, e As MouseEventArgs) Handles DataGridViewX1.MouseClick
        If DataGridViewX1.SelectedRows.Count > 0 Then
            Dim task = TryCast(DataGridViewX1.SelectedRows(0).DataBoundItem, Task)
            Chart1.ScrollTo(task)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim row As mydbDataSet.salles_statusRow
        Dim row2 As mydbDataSet.equipements_statusRow
        Dim row3 As mydbDataSet.troncons_statusRow
        manager.Start = CDate("24/07/2014")
        Dim span As TimeSpan

        span = DateTime.Today - manager.Start
        manager.Now = CInt(Math.Round(span.TotalDays))
        Dim count As Integer = 0
        Dim count2 As Integer = 0
        Dim somme As Double
        Dim somme2 As Double
        Dim somme3 As Double
        Dim somme4 As Double
        For count = 0 To Salles_statusBindingSource.Count - 1
            'equipements
            somme3 = 0
            somme4 = 0

            ' For Each row In Salles_statusBindingSource
            Dim rows As DataRowView = DirectCast(Salles_statusBindingSource.Item(count), DataRowView)
            row = CType(rows.Row, mydbDataSet.salles_statusRow)
            Me.Equipements_statusBindingSource.Filter = "idlots='" & lot & "' and idsalle='" & row.idsalle & "'"

            For count2 = 0 To Me.Equipements_statusBindingSource.Count - 1
                Dim rows2 As DataRowView = DirectCast(Equipements_statusBindingSource.Item(count2), DataRowView)
                row2 = CType(rows2.Row, mydbDataSet.equipements_statusRow)
                somme = somme + row2.temp_de_pose
                If row2.avancement > 0 And Not row2.pose Then
                    somme3 = somme3 + (row2.temp_de_pose * row2.avancement / 100)
                ElseIf row2.pose Then
                    somme3 = somme3 + row2.temp_de_pose
                End If

            Next
            Me.Troncons_statusBindingSource.Filter = "id_sall_tenant='" & row.idsalle & "'"
            For count2 = 0 To Troncons_statusBindingSource.Count - 1
                Dim rows3 As DataRowView = DirectCast(Troncons_statusBindingSource.Item(count2), DataRowView)
                row3 = CType(rows3.Row, mydbDataSet.troncons_statusRow)
                somme2 = somme2 + row3.temp_de_pose
                Try



                    If row3.pose Then
                        somme4 = somme4 + row3.temp_de_pose
                    End If

                Catch ex As Exception

                End Try
            Next

            'If IsDBNull(row.date_Prev) Then
            '    row.date_Prev = DateTime.Today
            'End If
            Try
                somme3 = Math.Round(somme - somme3, 2)
                somme4 = Math.Round(somme2 - somme4, 2)
                If (row.date_Prev) > CDate("24/07/2014") Then
                    Dim task As Task = New Task()
                    task.Name = "MAD - " & row.repere_salle
                    manager.Add(task)
                    span = row.date_Prev - manager.Start
                    manager.SetStart(task, CInt(Math.Round(span.TotalDays)))
                    '  Chart1.SetToolTip(task, "Tronçons :" & somme2 & " Hrs")

                    Chart1.SetToolTip(task, DaysOfWork(row.date_Prev, row.date_Fin) & " jours de travail " & vbNewLine & "Charge : " & NbOfWork(DaysOfWork(row.date_Prev, row.date_Fin), CDbl(TextBoxX1.Text), somme, somme2, , , ) & "" & vbNewLine & "Equipements :" & somme & " Hrs RAF :" & somme3 & " " & vbNewLine & "Tronçons :" & Math.Round(somme2, 2) & " Hrs RAF :" & somme4 & " ")
                    span = row.date_Fin - manager.Start
                    manager.SetEnd(task, CInt(Math.Round(span.TotalDays)))

                Else


                End If
                somme = 0
                somme2 = 0

                BackgroundWorker1.ReportProgress(CInt(count * 100 / Salles_statusBindingSource.Count))
            Catch ex As Exception
                Dim task As Task = New Task()
                task.Name = "?? - " & row.repere_salle
                manager.Add(task)
                span = manager.Start - manager.Start
                manager.SetStart(task, CInt(Math.Round(span.TotalDays)))
                '   Chart1.SetToolTip(task, "Tronçons :" & somme2 & " Hrs")
                Chart1.SetToolTip(task, "Equipements :" & somme & " Hrs" & vbNewLine & "Tronçons :" & somme2 & " Hrs")
                span = manager.Start - manager.Start
                manager.SetEnd(task, CInt(Math.Round(span.TotalDays)))
                somme = 0
                somme2 = 0
                BackgroundWorker1.ReportProgress(CInt(count * 100 / Salles_statusBindingSource.Count))
            End Try
        Next




        'For Each view As DataRowView In Me.Salles_statusBindingSource
        '    Dim row = CType(view.Row, mydbDataSet.salles_statusRow)

        'Next

    End Sub
    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        CircularProgress1.Visible = False
        DataGridViewX1.DataSource = New BindingSource(manager.Tasks, Nothing)
        Panel1.Visible = True
        Chart1.Init(manager)
    End Sub

    'Private Sub Chart1_MouseClick(sender As Object, e As MouseEventArgs) Handles Chart1.
    '    Chart1.SetToolTip(Chart1.SelectedTask, "test")
    'End Sub
    Public Function NbOfWork(ByVal nbDayWork As Double, ByVal WorkByDay As Double, Optional ByVal TotalEquipements As Double = 0, Optional ByVal Totaltroncons As Double = 0, Optional ByVal TotalTrirage As Double = 0, Optional ByVal TotalRacT As Double = 0, Optional ByVal TotalRacA As Double = 0) As Double
        NbOfWork = 0
        Dim totaux As Double = 0
        totaux = TotalEquipements + TotalRacA + TotalRacT + Totaltroncons
        NbOfWork = totaux / (nbDayWork * WorkByDay)
        NbOfWork = Math.Round(NbOfWork, 2)
        Return NbOfWork
    End Function
    Public Function DaysOfWork(ByVal Day_start As Date, ByVal Day_end As Date) As Double
        DaysOfWork = 0
        Dim i As Integer
        Dim span As TimeSpan
        span = Day_end - Day_start
        DaysOfWork = span.TotalDays + 1
        'eviction des weekend
        Dim dayd As Date
        dayd = Day_start
        Dim Daydd As Date
        For i = 0 To CInt(span.TotalDays)
            Daydd = dayd.AddDays(i)
            If Daydd.DayOfWeek = DayOfWeek.Saturday Or Daydd.DayOfWeek = DayOfWeek.Sunday Then
                DaysOfWork -= 1
            End If
        Next
        Return DaysOfWork
    End Function


End Class