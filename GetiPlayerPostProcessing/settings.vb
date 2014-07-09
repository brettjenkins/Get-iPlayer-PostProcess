Imports System.Collections.Specialized

Public Class Settings

    Private TextBoxFrom As New List(Of TextBox)
    Private TextBoxTo As New List(Of TextBox)
    Private LabelReplace As New List(Of Label)

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        My.Settings.PlexURL = txtPlex.Text
        My.Settings.OutFolder = txtOutput.Text
        My.Settings.WatchedFolder = txtWatched.Text
        My.Settings.ffmpegLocation = txtFFMpeg.Text

        If My.Settings.ReplaceTextFrom Is Nothing Then
            My.Settings.ReplaceTextFrom = New StringCollection
        End If
        If My.Settings.ReplaceTextTo Is Nothing Then
            My.Settings.ReplaceTextTo = New StringCollection
        End If

        My.Settings.ReplaceTextFrom.Clear()
        My.Settings.ReplaceTextTo.Clear()

        For Each TextBox In TextBoxFrom
            My.Settings.ReplaceTextFrom.Add(TextBox.Text)
        Next

        For Each TextBox In TextBoxTo
            My.Settings.ReplaceTextTo.Add(TextBox.Text)
        Next



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

        Dim i As Integer = 0
        For Each replaceText In My.Settings.ReplaceTextFrom
            Dim replaceTo = My.Settings.ReplaceTextTo(i)

            AddTextBoxRow(replaceText, replaceTo)

            i += 1
        Next

        AddTextBoxRows()



    End Sub



    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Panel1.Controls.Clear()

        TextBoxReplaceFromTemplate.Visible = False
        TextBoxReplaceToTemplate.Visible = False
        LabelReplaceTemplate.Visible = False



        AddTextBoxRows()

    End Sub

    Private Sub AddTextBoxRow(Optional ByVal textFrom As String = "", Optional ByVal textTo As String = "")

        Dim offset As Integer = 0
        If TextBoxFrom.Count > 0 Then
            offset = TextBoxFrom.Item(TextBoxFrom.Count - 1).Location.Y + 20
        End If

        Dim fromLoc As System.Drawing.Point = TextBoxReplaceFromTemplate.Location
        fromLoc.Y = offset

        Dim newtextBoxFrom As New TextBox
        newtextBoxFrom.Size = TextBoxReplaceFromTemplate.Size
        newtextBoxFrom.Location = fromLoc
        newtextBoxFrom.Text = textFrom

        TextBoxFrom.Add(newtextBoxFrom)

        Dim toLoc As System.Drawing.Point = TextBoxReplaceToTemplate.Location
        toLoc.Y = offset

        Dim newtextBoxTo As New TextBox
        newtextBoxTo.Size = TextBoxReplaceToTemplate.Size
        newtextBoxTo.Location = toLoc
        newtextBoxTo.Text = textTo

        TextBoxTo.Add(newtextBoxTo)

        Dim labelLoc As System.Drawing.Point = LabelReplaceTemplate.Location
        labelLoc.Y = offset

        Dim label As New Label
        label.Size = LabelReplaceTemplate.Size
        label.Location = labelLoc
        label.Text = "Replace:"

        LabelReplace.Add(label)
    End Sub

    Private Sub AddTextBoxRows()

        For Each textBox In TextBoxFrom

            Panel1.Controls.Add(textBox)

        Next

        For Each textBox In TextBoxTo
            Panel1.Controls.Add(textBox)
        Next

        For Each textBox In LabelReplace
            Panel1.Controls.Add(textBox)
        Next

    End Sub

    Private Sub btnAddRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddRow.Click
        AddTextBoxRow()
        AddTextBoxRows()
    End Sub

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click
#If DEBUG Then
        My.Settings.Reset()
#End If
    End Sub
End Class