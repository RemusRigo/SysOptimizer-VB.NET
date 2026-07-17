Imports System.IO

Public Class frmRepair

   Dim log As New Logger(appName)

   '-----------------------------------------------------------------------------------------------
   ' Add ListView item
   Private Sub LV_AddItem(name As String, isChecked As Boolean)
      Dim item As New ListViewItem(name)
      item.Checked = isChecked
      lvRepair.Items.Add(item)
   End Sub

   '-----------------------------------------------------------------------------------------------
   ' Build Options
   Public Sub BuildOptions()
      lvRepair.BeginUpdate()
      lvRepair.Items.Clear()

      LV_AddItem("Windows Update", True)
      LV_AddItem("Icon Cache", True)
      If IsAppElevated() Then LV_AddItem("Windows Update cache", False)

      lvRepair.EndUpdate()
   End Sub

   '-----------------------------------------------------------------------------------------------
   ' Process Actions
   Public Async Sub ProcessActions()
      For Each item As ListViewItem In lvRepair.Items
         If item.Checked Then
            Select Case item.Text
               Case "Windows Update"

               Case "Icon Cache"

               Case "Windows Update cache"
                  log.Msg.Info("Clean: Microsoft Windows » FileSystem: Windows Update cache")
                  StopService("wuauserv")
                  StopService("bits")
                  StopService("cryptsvc")
                  StopService("msiserver")
                  Await Task.Delay(5000)
                  Dim pathsToClean As String() = {
                        Path.Combine(Environment.GetEnvironmentVariable("SystemRoot"), "SoftwareDistribution\Download"),
                        Path.Combine(Environment.GetEnvironmentVariable("SystemRoot"), "SoftwareDistribution\DataStore")
                     }
                  CleanFolders(pathsToClean, "*.*", True, True)
                  StartService("msiserver")
                  StartService("cryptsvc")
                  StartService("bits")
                  StartService("wuauserv")
            End Select
         End If
      Next
   End Sub

   Private Sub frmRepair_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      BuildOptions()
   End Sub

   Private Sub btnRepair_Click(sender As Object, e As EventArgs) Handles btnRepair.Click
      ProcessActions()
   End Sub

   Private Sub CleanFolders(folderPaths As IEnumerable(Of String), mask As String, recursive As Boolean, deleteFolders As Boolean)
      ' Convert to list to avoid multiple enumerations
      Dim pathsList = folderPaths.ToList()

      For Each folderPath As String In pathsList
         If Not Directory.Exists(folderPath) Then Continue For

         Dim search = If(recursive, SearchOption.AllDirectories, SearchOption.TopDirectoryOnly)
         Dim files() As String
         Try
            files = Directory.GetFiles(folderPath, mask, search)
         Catch
            Continue For
         End Try

         ' delete files in reverse order to avoid issues with file system changes during deletion
         For i = 0 To files.Length - 1
            Try
               File.Delete(files(i))
            Catch ex As Exception
               log.Msg.Error($"{ex.Message} : {files(i)}")
            End Try
         Next

         ' delete folders in reverse order to avoid issues with file system changes during deletion
         If deleteFolders AndAlso recursive Then
            Try
               Dim folders() As String = Directory.GetDirectories(folderPath, "*", SearchOption.AllDirectories)
               For i = 0 To folders.Length - 1
                  Try
                     Directory.Delete(folders(i), False)
                  Catch ex As Exception
                     log.Msg.Error($"{ex.Message} : {folders(i)}")
                  End Try
               Next
            Catch ex As Exception
               log.Msg.Error($"{ex.Message} : {folderPath}")
            End Try
         End If
      Next
   End Sub

End Class