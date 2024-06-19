Imports System.Net.Http
Imports System.Threading.Tasks
Imports Newtonsoft.Json

Public Class ViewSubmissionsForm
    Private submissions As New List(Of Submission)()
    Private currentIndex As Integer = 0

    Private Async Sub ViewSubmissionsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Fetch all submissions from backend
        Await LoadAllSubmissions()

        ' Display the first submission
        UpdateSubmissionDisplay()
    End Sub

    Private Sub UpdateSubmissionDisplay()
        If submissions.Count > 0 Then
            Dim submission = submissions(currentIndex)
            lblSubmissionData.Text = $"Name: {submission.name}, Email: {submission.email}, Phone: {submission.phone}, GitHub: {submission.github_link}, Stopwatch: {submission.stopwatch_time}"
        Else
            lblSubmissionData.Text = "No submissions available."
        End If
    End Sub

    Private Async Function LoadAllSubmissions() As Task
        ' Load all submissions from the backend
        Dim client As New HttpClient()
        Dim response = Await client.GetStringAsync("http://localhost:5000/readAll")

        If Not String.IsNullOrEmpty(response) Then
            submissions = JsonConvert.DeserializeObject(Of List(Of Submission))(response)
        End If
    End Function

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        If currentIndex < submissions.Count - 1 Then
            currentIndex += 1
            UpdateSubmissionDisplay()
        End If
    End Sub

    Private Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles btnPrevious.Click
        If currentIndex > 0 Then
            currentIndex -= 1
            UpdateSubmissionDisplay()
        End If
    End Sub

    Public Class Submission
        Public Property name As String
        Public Property email As String
        Public Property phone As String
        Public Property github_link As String
        Public Property stopwatch_time As String
    End Class
End Class
