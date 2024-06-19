Public Class MainForm

    ' Other code for your form...

    ' Declare btnViewSubmissions (if not declared already)
    Private WithEvents btnViewSubmissions As Button

    ' Constructor or Form Load where you initialize btnViewSubmissions


    ' Event handler for btnViewSubmissions click
    Private Sub btnViewSubmissions_Click(sender As Object, e As EventArgs) Handles btnViewSubmissions.Click
        Dim viewForm As New ViewSubmissionsForm()
        viewForm.Show()
    End Sub

    ' Other event handlers and methods for your form...

End Class