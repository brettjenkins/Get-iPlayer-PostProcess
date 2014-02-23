Public Class Settings

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        My.Settings.PlexURL = txtPlex.Text
        My.Settings.OutFolder = txtOutput.Text
        My.Settings.WatchedFolder = txtWatched.Text
        My.Settings.ffmpegLocation = txtFFMpeg.Text
        My.Settings.Save()

        Application.Restart()

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Hide()
    End Sub

    Private Sub Settings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtOutput.Text = My.Settings.OutFolder
        txtWatched.Text = My.Settings.WatchedFolder
        txtPlex.Text = My.Settings.PlexURL
        txtFFMpeg.Text = My.Settings.ffmpegLocation
    End Sub
End Class