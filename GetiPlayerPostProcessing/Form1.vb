﻿Imports System.IO
Imports System.Threading
Imports System.ComponentModel
Imports System.Net

Public Class Form1

    Private watchedFolder As String = My.Settings.WatchedFolder ' No trailing slashes
    Private outFolder As String = My.Settings.OutFolder
    Private plexRoot As String = My.Settings.PlexURL
    Private ffmpeg As String = My.Settings.ffmpegLocation

    Private currentlyProcessingFiles As New ArrayList

    Private Sub GetRules()
        ' Dim lines() As String = IO.File.ReadAllLines("c:\iPlayer\datebasedrules.txt")


        'For x As Integer = 0 To lines.GetUpperBound(0)
        'lineArray.Add(lines(x))
        'Next
    End Sub

    Private Function IsDateBased(ByVal title As String)

        'For Each line As String In lineArray
        'If title.ToLower.Contains(line) Then
        'Return True
        'End If
        'Next

        Dim regex As New System.Text.RegularExpressions.Regex("(([0-9])([0-9])([0-9])([0-9]))-([0-9])([0-9])-([0-9])([0-9])")
        If regex.IsMatch(title) Then
            Return True
        End If

        Return False
    End Function

    Private Sub FileSystemWatcher1_Changed(ByVal sender As System.Object, ByVal e As System.IO.FileSystemEventArgs) Handles FileSystemWatcher1.Changed

    End Sub

    Private Sub FileSystemWatcher1_Created(ByVal sender As Object, ByVal e As System.IO.FileSystemEventArgs) Handles FileSystemWatcher1.Created

    End Sub

    Private Function TempName(ByVal fileName As String) As Boolean
        If fileName.Contains("-temp-") OrElse fileName.Contains(".partial.") Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function AlreadyProcessing(ByVal filename As String) As Boolean
        For Each item As String In currentlyProcessingFiles
            If item = filename Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Sub fileCreated(ByVal e As System.IO.FileSystemEventArgs)
        Dim sFile As String = e.FullPath


        If TempName(sFile) = False AndAlso AlreadyProcessing(e.FullPath) = False Then
            Dim processingfiles As New List(Of String)
            currentlyProcessingFiles.Add(e.FullPath)
            processingfiles.Add(e.FullPath)
            WriteLine(Convert.ToString("processing file : ") & sFile)
            ' Wait if file is still open
            Dim fileInfo As New FileInfo(sFile)
            While IsFileExist(fileInfo)
                Try
                    If IsFileLocked(fileInfo) Then
                        WriteLine(Convert.ToString("file locked - waiting : ") & sFile)
                        Thread.Sleep(500)
                    Else
                        Exit While
                    End If
                Catch exc As Exception
                End Try
            End While

            If IsFileExist(fileInfo) Then
                WriteLine(Convert.ToString("file unlocked : ") & sFile)

                WriteLine("Sleeping for 30 secs until we start work")
                Thread.Sleep(New TimeSpan(0, 0, 30))
                If IsFileExist(fileInfo) Then
                    Dim fileName As String = e.FullPath
                    If IsDateBased(e.Name) Then
                        fileName = RenameToDateName(fileName, processingfiles)
                    End If

                    fileName = RemoveUnderscoresRename(fileName, processingfiles)
                    fileName = AddSpaces(fileName, processingfiles)


                    Dim explode = fileName.Split("\")
                    Dim year As String = GetYear(fileName) ' this will need to be changed soon.
                    Dim oldFolder As String = GeneratePath(explode, explode.Length - 1)
                    Dim newFolder As String
                    If IsDateBased(e.Name) Then
                        newFolder = RenameSeasonFolder(GeneratePath(explode, explode.Length - 1), year, processingfiles)
                        fileName = fileName.Replace(oldFolder, newFolder)
                    Else

                    End If

                    'Dim folderBase As String = fileName.Substring(0, fileName.IndexOf(explode(explode.Length - 1)))
                    If IsDateBased(fileName) Then
                        WipeMetaTags(fileName, processingfiles)
                    End If

                    MoveToMediaNAS(fileName)
                    RefreshPlex()
                    currentlyProcessingFiles.Remove(e.FullPath)
                    currentlyProcessingFiles.Remove(fileName)
                    For Each File In processingfiles
                        While currentlyProcessingFiles.Contains(File)
                            currentlyProcessingFiles.Remove(File)
                        End While
                    Next
                End If
            End If
        Else

            WriteLine(Convert.ToString("ignoring file : ") & sFile)
        End If
    End Sub

    Private Function AddSpaces(ByVal filename As String, ByRef processfiles As List(Of String)) As String
        Dim explode = filename.Split("\")
        Dim filen As String = explode(explode.Length - 1)
        Dim fileE = filen.Split(".")
        Dim newName As String
        Dim datePart As String = ""
        Dim dateBased As Boolean = False
        If IsDateBased(filen) Then
            dateBased = True
            Dim regex As New System.Text.RegularExpressions.Regex("(([0-9])([0-9])([0-9])([0-9]))-([0-9])([0-9])-([0-9])([0-9])")
            If regex.IsMatch(filename) Then
                Dim match As System.Text.RegularExpressions.Match = regex.Match(filename)

                datePart = match.Value
                fileE(0) = fileE(0).Replace(datePart, "")

            End If

        End If

        newName = fileE(0).Replace("-", " - ")

        newName = System.Text.RegularExpressions.Regex.Replace(newName, "[ ]{2,}", " ")

        If Not newName.Contains("-") Then
            newName = newName.Replace(" ", " - ")
        End If

        If dateBased = True Then
            newName = newName & datePart
        End If

        newName = newName & "." & fileE(1)
        newName = filename.Replace(filen, newName)

        currentlyProcessingFiles.Add(newName)
        processfiles.add(newName)
        File.Move(filename, newName)

        Return newName

    End Function

    Private Function GetYear(ByVal filename As String) As String
        Dim regex As New System.Text.RegularExpressions.Regex("(([0-9])([0-9])([0-9])([0-9]))-([0-9])([0-9])-([0-9])([0-9])")
        If regex.IsMatch(filename) Then
            Dim match As System.Text.RegularExpressions.Match = regex.Match(filename)

            Return match.Groups("1").Value

        End If
        Return 1
    End Function

    Private Function RenameSeasonFolder(ByVal folder As String, ByVal year As String, ByRef processFiles As List(Of String)) As String
        Try
            Dim newName As String = folder.Replace("Season 1", "Season " & year)
            currentlyProcessingFiles.Add(newName)

            If folder <> newName Then
                Directory.Move(folder, newName)
            End If

            processFiles.Add(newName)

            Return newName
        Catch generatedExceptionName As IOException
            Return Nothing
        End Try
    End Function

    Private Function RemoveUnderscoresRename(ByVal filename As String, ByRef processFiles As List(Of String), Optional ByVal newPathSoFar As String = "")
        Dim explode = filename.Split("\")
        Dim oldName As String = filename

        Dim newEnd As String = explode(explode.Length - 1).Replace("_", " ")
        Dim newName As String = GeneratePath(explode, explode.Length - 1) & "\" & explode(explode.Length - 1).Replace("_", " ")

        If watchedFolder.EndsWith(explode(explode.Length - 1)) Then
            Return watchedFolder & "\" & newPathSoFar
        Else



            Try
                currentlyProcessingFiles.Add(newName)

                Dim attr As FileAttributes = File.GetAttributes(oldName)

                'detect whether its a directory or file
                currentlyProcessingFiles.Add(newName)
                processFiles.Add(newName)

                If (attr And FileAttributes.Directory) = FileAttributes.Directory Then
                    If oldName <> newName Then
                        Directory.Move(oldName, newName)
                    End If
                Else
                    If oldName <> newName Then
                        File.Move(oldName, newName)
                    End If
                End If

                If newPathSoFar = Nothing Then
                    newPathSoFar = newEnd
                Else
                    newPathSoFar = newEnd & "\" & newPathSoFar
                End If

                Return RemoveUnderscoresRename(GeneratePath(explode, explode.Length - 1), processFiles, newPathSoFar)


            Catch generatedExceptionName As IOException
                Return Nothing
            End Try

        End If
    End Function

    Private Function GeneratePath(ByVal explode As String(), ByVal i As Integer) As String
        Dim returnPath As String = ""

        For x As Integer = 0 To (i - 1)
            returnPath = returnPath & "\" & explode(x)
        Next

        If returnPath.Length > 0 Then
            returnPath = returnPath.Substring(1)
        End If
        Return returnPath
    End Function

    Private Function RenameToDateName(ByVal filePath As String, ByRef processfiles As List(Of String)) As String
        Dim newName As String = filePath.Replace("s01e01-", "")
        newName = filePath.Replace("s01e01", "")

        Try
            currentlyProcessingFiles.Add(newName)
            processfiles.Add(newName)
            If filePath <> newName Then
                File.Move(filePath, newName)
            End If

            Return newName
        Catch generatedExceptionName As IOException
            'the file is unavailable because it is:
            'still being written to
            'or being processed by another thread
            'or does not exist (has already been processed)

            Return Nothing
        End Try
    End Function

    Private Sub RefreshPlex()
        If plexRoot IsNot Nothing AndAlso plexRoot.Length > 0 Then
            WriteLine("Refreshing Plex..")
            Dim url As String = plexRoot & "/library/sections/all/refresh"
            Dim request As HttpWebRequest = WebRequest.Create(url)
            Dim response As HttpWebResponse = request.GetResponse
            WriteLine("Done")
        End If
    End Sub

    Private Sub WipeMetaTags(ByVal filename As String, ByRef currentProcessing As List(Of String))
        Dim explode = filename.Split(".")
        Dim ext As String = "." & explode(explode.Length - 1)

        Dim newfilename As String = filename
        newfilename = newfilename.Replace(ext, "notag" & ext)
        
        Dim cmda As String = "-i """ & filename & """ -metadata disc="""" -metadata track="""" -metadata episode_id="""" -metadata season_number=""""  -metadata episode_sort="""" -c:v copy -c:a copy  """ & newfilename & """"

        Dim ProcessProperties As New ProcessStartInfo
        ProcessProperties.FileName = ffmpeg & "\ffmpeg.exe"
        ProcessProperties.Arguments = cmda 'command line arguments
        ProcessProperties.WindowStyle = ProcessWindowStyle.Normal

        currentlyProcessingFiles.Add(newfilename)

        Dim myProcess As Process = Process.Start(ProcessProperties)



        WriteLine("Stripping Tags... waiting for ffmpeg to finish....")
        While myProcess.HasExited = False
            Thread.Sleep(1000)
        End While
        WriteLine("Finished... renaming")
        File.Delete(filename)
        File.Move(newfilename, filename)

    End Sub

    Private Sub MoveToMediaNAS(ByVal fileN As String)
        Dim newName As String = fileN.Replace(watchedFolder & "\", "")

        If newName(0) = "\" Then
            newName = newName.Substring(1)
        End If

        Dim explode = newName.Split("\")
        Dim showRoot As String = watchedFolder & "\" & explode(0)
        Dim newRoot As String = outFolder & "\" & explode(0)
        newName = outFolder & "\" & newName
        Try
            'Directory.Move(file(0), newName)
            'Dim f As New System.IO.FileInfo(showRoot)
            'f.MoveTo(newRoot)
            WriteLine("Copying file")
            ' newRoot = GetMoveRoot(ive, explode)
            'JDStuart.DirectoryUtils.Directory.Move(showRoot, newRoot)
            'RMORTEGA77.Utils.FileUtilities.MoverDirectorio(showRoot, newRoot)
            CreateDirectoryOnNAS(newName)
            File.Move(fileN, newName)

            Dim finfo As New FileInfo(fileN)
            While finfo.Exists
                Thread.Sleep(1000)
            End While

        Catch generatedExceptionName As IOException
            'the file is unavailable because it is:
            'still being written to
            'or being processed by another thread
            'or does not exist (has already been processed)
        Finally

        End Try
        WriteLine("Done")
    End Sub

    Private Function CreateDirectoryOnNAS(ByVal fileName As String, Optional ByVal i As Integer = -1)

        Dim explode = fileName.Split("\")
        If i = -1 Then
            i = explode.Length - 1
        End If
        Dim path As String = GeneratePath(explode, i)
        If path = outFolder Then
            Return True
        End If
        Dim dir As New DirectoryInfo(path)
        If Not dir.Exists Then
            Directory.CreateDirectory(path)
        End If

        Return CreateDirectoryOnNAS(fileName, i - 1)
    End Function

    Private Function GetMoveRoot(ByVal root As String, ByVal path As String(), Optional ByVal i As Integer = 1) As String
        If Directory.Exists(root & "\" & path(0)) Then

            Dim explode = path
            Dim npath As String = root
            For x As Integer = 0 To i
                npath = npath & "\" & explode(x)
            Next
            Return GetMoveRoot(root, path, i)
        Else
            Return root & "\" & path(0)
        End If
    End Function

    Private Sub WriteLine(ByVal text As String)
        If TextBox1.InvokeRequired Then
            ''//For VB 10 you can use an anonymous sub
            TextBox1.Invoke(Sub() WriteLine(text))
        Else
            TextBox1.AppendText(text & vbNewLine)
            TextBox1.Select(TextBox1.TextLength, 0)
            TextBox1.ScrollToCaret()
        End If
    End Sub

    Private Shared Function IsFileExist(ByVal file As FileInfo) As Boolean
        If file.Exists Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Shared Function IsFileLocked(ByVal file As FileInfo) As Boolean
        Dim stream As FileStream = Nothing

        Try
            stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None)
        Catch generatedExceptionName As IOException
            'the file is unavailable because it is:
            'still being written to
            'or being processed by another thread
            'or does not exist (has already been processed)
            Return True
        Finally
            If stream IsNot Nothing Then
                stream.Close()
            End If
        End Try

        'file is not locked
        Return False
    End Function


    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load



        FileSystemWatcher1.Path = watchedFolder
        FileSystemWatcher1.EnableRaisingEvents = True
        'WriteLine("Getting rules...")
        'GetRules()
        'WriteLine("Rules:")
        'For Each line As String In lineArray
        'WriteLine(line)
        'Next
        WriteLine("Watching folder " & watchedFolder & "...")
    End Sub

    Private Sub FileSystemWatcher1_Renamed(ByVal sender As Object, ByVal e As System.IO.RenamedEventArgs) Handles FileSystemWatcher1.Renamed
        Dim nThread As New Thread(AddressOf fileCreated)

        nThread.Start(e)
    End Sub

    Private Sub SettingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SettingsToolStripMenuItem.Click
        Settings.Show()
    End Sub

    Private Sub ForceRefreshPlexToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ForceRefreshPlexToolStripMenuItem.Click
        RefreshPlex()
    End Sub

    Private Sub OpenWatchedFolderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenWatchedFolderToolStripMenuItem.Click
        Process.Start("explorer.exe", watchedFolder)
    End Sub

    Private Sub OpenOutputFolderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenOutputFolderToolStripMenuItem.Click
        Process.Start("explorer.exe", outFolder)
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        AboutBox1.Show()
    End Sub

    Private Sub MenuStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub
End Class