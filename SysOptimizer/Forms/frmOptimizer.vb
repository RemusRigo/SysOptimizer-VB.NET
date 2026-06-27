Imports System.IO
Imports System.Windows.Forms.Design.AxImporter
Imports Microsoft.VisualBasic.Logging
Imports Microsoft.Win32
Imports SysOptimizer.UIControls

Public Class frmOptimizer
   Private pbActions As rrProgressBar

   Dim log As New Logger(appName)
   Dim grp As ListViewGroup = Nothing

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
      'item.SubItems.Add("")
      ' item.SubItems.Add("")
      item.Checked = isChecked
      item.Tag = 0
      item.Group = grp
      lvOptimizer.Items.Add(item)
   End Sub

   '-----------------------------------------------------------------------------------------------
   ' Build Options
   Public Sub BuildOptions()
      lvOptimizer.BeginUpdate()
      lvOptimizer.Items.Clear()
      lvOptimizer.Groups.Clear()

      If IsAppElevated() Then
         LV_AddGroup("Clean /Repair / Rebuild")
         LV_AddItem("Windows Search: Indexing DB", True)
      End If

      If IsAppElevated() Then
         LV_AddGroup("Services")
         LV_AddItem("Windows Search", True)
      End If

      ResizeLVColumns(lvOptimizer)
      lvOptimizer.EndUpdate()
   End Sub

   '-----------------------------------------------------------------------------------------------
   ' Process Actions
   Private Async Sub ProcessActions(itemsToProcess As List(Of ListViewItem))
      For Each item As ListViewItem In itemsToProcess
         Dim grp = item.Group
         If grp Is Nothing Then Continue For

         Select Case grp.Header
            '======================================================================================
            Case "Clean /Repair / Rebuild"
               Select Case item.Text

                  '--------------------------------------------------------------------------------
                  Case "Windows Search: Indexing DB"
                     StopService("wsearch")
                     Await Task.Delay(5000)
                     Dim delPath As String = Environment.ExpandEnvironmentVariables("%ProgramData%\Microsoft\Search\Data\Applications\Windows")
                     Try
                        If Directory.Exists(delPath) Then
                           For Each delFile As String In Directory.GetFiles(delPath)
                              Try
                                 File.Delete(delFile)
                                 log.Msg.Info("File deleted: " & delFile)
                              Catch ex As Exception
                                 log.Msg.Error("Error deleting file: " & delFile & " - " & ex.Message)
                              End Try
                           Next
                        Else
                           log.Msg.Warning("Folder not found: " & delPath)
                        End If
                     Catch ex As Exception
                        log.Msg.Error("Folder cleanup error: " & ex.Message)
                     End Try
                     If RegWriteDWord(Registry.LocalMachine, "SOFTWARE\Microsoft\Windows Search", "SetupCompletedSuccessfully", 1) Then
                        log.Msg.Info("Reg: Windows Search: Indexing DB reset: ok")
                     Else
                        log.Msg.Error("Reg: Windows Search: Indexing DB reset: not ok")
                     End If
                     StartService("wsearch")
               End Select

            '======================================================================================
            Case "Services"
               Select Case item.Text

                  '--------------------------------------------------------------------------------
                  Case "Windows Search"

               End Select

         End Select
      Next
   End Sub

   Private Sub frmOptimizer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      BuildOptions()
      pbActions = New rrProgressBar()
      pbActions.Dock = DockStyle.None
      pbActions.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
      pbActions.Location = New Point(3, 417)
      pbActions.Size = New Size(745, 20)
      'pbActioms.BarColor = DarkenColor(tvOptions.BackColor, 15)
      'pbActioms.BarColorDone = DarkenColor(tvOptions.BackColor, 30)
      Me.Controls.Add(pbActions)
   End Sub

   Private Async Sub btnProcess_Click(sender As Object, e As EventArgs) Handles btnProcess.Click
      Dim itemsToProcess As New List(Of ListViewItem)()
      For Each item As ListViewItem In lvOptimizer.Items
         If item.Checked AndAlso item.Group IsNot Nothing Then
            itemsToProcess.Add(item)
         End If
      Next

      MessageBox.Show(itemsToProcess.Count)

      Try
         ' 2. Pass the gathered items to the background worker
         Await Task.Run(Sub() ProcessActions(itemsToProcess))
      Finally
         'toolBtnPurge.Enabled = True
      End Try
   End Sub
End Class
