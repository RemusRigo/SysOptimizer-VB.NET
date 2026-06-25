Public Class Form1

   '-----------------------------------------------------------------------------------------------
   ' Add ListView Group
   Private Sub LV_AddGroup(name As String)
      grp = New ListViewGroup(name)
      lvOptimizer.Groups.Add(grp)
   End Sub

   '-----------------------------------------------------------------------------------------------
   ' Add ListView item
   Private Sub LV_AddItem(name As String, isChecked As Boolean)
      Dim item As New ListViewItem(name)
      item.SubItems.Add("")
      item.SubItems.Add("")
      item.Checked = isChecked
      item.Tag = 0
      item.Group = grp
      lvSysPurge.Items.Add(item)
   End Sub

   '-----------------------------------------------------------------------------------------------
   ' Build Options
   Public Sub BuildOptions()
      lvSysPurge.BeginUpdate()
      lvSysPurge.Items.Clear()
      lvSysPurge.Groups.Clear()

      LV_AddGroup("Microsoft Windows » FileSystem")
      If IsAppElevated() Then LV_AddItem("EventViewer logs", True)
      LV_AddItem("Log files (inside Windows)", True)
      LV_AddItem("Log files (System drive)", False)
      LV_AddItem("Prefetch files", True)
      LV_AddItem("Temp folder(s)", True)
      If IsAppElevated() Then LV_AddItem("Windows Update cache", False)

      LV_AddGroup("Microsoft Windows » Registry")
      LV_AddItem("MRU list: Run", True)
      If IsAppElevated() Then LV_AddItem("Shared DLL's)", True)

      LV_AddGroup("Microsoft Teams")
      LV_AddItem("Cache", True)

      ResizeColumns()
      lvSysPurge.EndUpdate()
   End Sub

   '-----------------------------------------------------------------------------------------------
   ' Process Actions
   Private Async Sub ProcessActions(itemsToProcess As List(Of ListViewItem))
      For Each item As ListViewItem In itemsToProcess
         Dim grp = item.Group
         If grp Is Nothing Then Continue For

         Select Case grp.Header
            Case "Microsoft Windows » FileSystem" '------------------------------------------------
               Select Case item.Text

                  Case "EventViewer logs"
                     Dim pathsToClean As String() = {Path.Combine(Environment.GetEnvironmentVariable("SystemRoot"), "System32\winevt\Logs")}
                     StopService("eventlog")
                     Await Task.Delay(5000)
                     TaskCleanFolders(item, pathsToClean, "*.evtx", False, False)
                     'TaskCleanFolder(item, Path.Combine(Environment.GetEnvironmentVariable("SystemRoot"), "System32\winevt\Logs"), "*.evtx", False, False)
                     StartService("eventlog")

                  Case "Log files (inside Windows)"
                     Dim pathsToClean As String() = {Environment.GetEnvironmentVariable("SystemRoot")}
                     TaskCleanFolders(item, pathsToClean, "*.log", True, True)

                  Case "Log files (System drive)"
                     Dim pathsToClean As String() = {Environment.GetEnvironmentVariable("SystemDrive")}
                     TaskCleanFolders(item, pathsToClean, "*.log", True, True)

                  Case "Prefetch files"
                     Dim pathsToClean As String() = {Path.Combine(Environment.GetEnvironmentVariable("SystemRoot"), "Prefetch")}
                     TaskCleanFolders(item, pathsToClean, "*.pf", False, False)

                  Case "Temp folder(s)"
                     Dim pathsToClean As String() = {
                        Environment.GetEnvironmentVariable("TEMP"),
                        Path.Combine(Environment.GetEnvironmentVariable("SystemRoot"), "Temp")
                     }
                     TaskCleanFolders(item, pathsToClean, "*.*", True, True)

                  Case "Windows Update cache"
                     StopService("wuauserv")
                     StopService("bits")
                     StopService("cryptsvc")
                     StopService("msiserver")
                     Await Task.Delay(5000)
                     Dim pathsToClean As String() = {
                        Path.Combine(Environment.GetEnvironmentVariable("SystemRoot"), "SoftwareDistribution\Download"),
                        Path.Combine(Environment.GetEnvironmentVariable("SystemRoot"), "SoftwareDistribution\DataStore")
                     }
                     TaskCleanFolders(item, pathsToClean, "*.*", True, True)
                     StartService("msiserver")
                     StartService("cryptsvc")
                     StartService("bits")
                     StartService("wuauserv")

               End Select

            Case "Microsoft Windows » Registry" '--------------------------------------------------
               Select Case item.Text
                  Case "MRU list: Run"
                     TaskCleanRegValues(item, Registry.CurrentUser, "Software\Microsoft\Windows\CurrentVersion\Explorer\RunMRU", False)

                  Case "Shared DLL's)"
                     '
               End Select

            Case "Microsoft Teams" '---------------------------------------------------------------
               Select Case item.Text
                  Case "Cache"
                     Dim pathsToClean As String() = {
                        Path.Combine(Environment.GetEnvironmentVariable("appdata"), "Microsoft\Teams"),
                        Path.Combine(Environment.GetEnvironmentVariable("localappdata"), "Packages\MSTeams_8wekyb3d8bbwe\LocalCache\Microsoft\MSTeams")
                     }
                     TaskCleanFolders(item, pathsToClean, "*.*", True, True)

               End Select

         End Select
      Next
   End Sub

   Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      BuildOptions()
   End Sub
End Class
