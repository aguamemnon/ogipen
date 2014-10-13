Imports Braincase.GanttChart
Public Class Form_actions_globale

    Private Sub Form_actions_globale_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        'TODO: This line of code loads data into the 'MydbDataSet.actions_types' table. You can move, or remove it, as needed.
        Me.Actions_typesTableAdapter.Fill(Me.MydbDataSet.actions_types)
        Dim manager As ProjectManager = New ProjectManager()

        Dim task As Task = New Task()
        task.Name = "essais"

        manager.Add(task)
        manager.SetStart(task, 2000)
        manager.TimeScale = TimeScale.Day
        Dim span As TimeSpan = DateTime.Today - manager.Start
        manager.Now = CInt(Math.Round(span.TotalDays))
        Chart1.TimeScaleDisplay = TimeScaleDisplay.DayOfWeek
        Chart1.Init(manager)
    End Sub

    Private Sub Actions_typesBindingNavigatorSaveItem_Click(sender As System.Object, e As System.EventArgs)
        Me.Validate()
        Me.Actions_typesBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.MydbDataSet)

    End Sub
End Class