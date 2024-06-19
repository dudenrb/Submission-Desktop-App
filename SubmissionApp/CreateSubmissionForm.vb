Imports System.Net.Http
Imports System.Text
Imports Newtonsoft.Json

Public Class CreateSubmissionForm
    Private stopwatchRunning As Boolean = False
    Private stopwatch As New Stopwatch()

    ' Handles the Start/Pause Stopwatch button click event
    Private Sub btnStartStopwatch_Click(sender As Object, e As EventArgs) Handles btnStartStopwatch.Click
        If stopwatchRunning Then
            stopwatch.Stop()
            btnStartStopwatch.Text = "Start Stopwatch"
        Else
            stopwatch.Start()
            btnStartStopwatch.Text = "Pause Stopwatch"
        End If
        stopwatchRunning = Not stopwatchRunning
    End Sub

    ' Handles the Submit button click event
    Private Async Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        ' Gather data from input fields
        Dim submission = New With {
            .name = txtName.Text,
            .email = txtEmail.Text,
            .phone = txtPhoneNumber.Text,
            .github_link = txtGithubLink.Text,
            .stopwatch_time = stopwatch.Elapsed.ToString()
        }

        ' Serialize the submission data to JSON
        Dim jsonData As String = JsonConvert.SerializeObject(submission)

        ' Send submission to the backend
        Dim client As New HttpClient()
        Dim content As New StringContent(jsonData, Encoding.UTF8, "application/json")
        Dim response = Await client.PostAsync("http://localhost:5000/submit", content)

        If response.IsSuccessStatusCode Then
            MessageBox.Show("Submission Successful!")
            ' Optionally, close the form after submission
            Me.Close()
        Else
            MessageBox.Show("Submission Failed.")
        End If
    End Sub

    ' Handles the form Load event
    Private Sub CreateSubmissionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Add the KeyDown event handler to capture key presses
        AddHandler Me.KeyDown, AddressOf CreateSubmissionForm_KeyDown
    End Sub

    ' Handles the KeyDown event to check for Ctrl + S shortcut
    Private Sub CreateSubmissionForm_KeyDown(sender As Object, e As KeyEventArgs)
        If e.Control AndAlso e.KeyCode = Keys.S Then
            ' Trigger the submit button click event
            btnSubmit.PerformClick()
            e.SuppressKeyPress = True ' Prevents the "ding" sound when pressing keys
        End If
    End Sub

    Private Sub txtPhoneNumber_TextChanged(sender As Object, e As EventArgs) Handles txtPhoneNumber.TextChanged

    End Sub
End Class
