Imports System.IO
Imports System.Windows.Forms.Design.AxImporter
Imports Microsoft.VisualBasic.Logging
Imports Microsoft.Win32
Imports SysOptimizer.UIControls

Public Class frmOptimizer
   Private pbActions As rrProgressBar

   Dim log As New Logger(appName)
   Dim grp As ListViewGroup = Nothing

   Private Class LV_CheckBoxData
      Public Property HasCheckBox As Boolean
      Public Property CheckState As Boolean
      Public Property Display As String
   End Class
   '-----------------------------------------------------------------------------------------------
   ' Add ListView Group
   Private Sub LV_AddGroup(name As String)
      grp = New ListViewGroup(name)
      lvOptimizer.Groups.Add(grp)
   End Sub

   '-----------------------------------------------------------------------------------------------
   ' Add ListView item
   Private Sub LV_AddItem(name As String, isChecked As Boolean, Optional hasCheckBox As Boolean = False, Optional CheckBoxIsChecked As Boolean = False, Optional CheckBoxText As String = "On/Off")
      Dim item As New ListViewItem(name)
      item.SubItems.Add("")
      item.Checked = isChecked
      item.Tag = New LV_CheckBoxData With {
         .HasCheckBox = hasCheckBox,
         .CheckState = CheckBoxIsChecked,
         .Display = CheckBoxText
      }
      item.Group = grp
      lvOptimizer.Items.Add(item)
   End Sub

   '-----------------------------------------------------------------------------------------------
   ' Build Options
   Public Sub BuildOptions()
      lvOptimizer.BeginUpdate()
      lvOptimizer.Items.Clear()
      lvOptimizer.Groups.Clear()

      ' If IsAppElevated() Then
      LV_AddGroup("Clean /Repair / Rebuild")
      LV_AddItem("Windows Search: Indexing DB", False)
      ' End If

      'If IsAppElevated() Then
      LV_AddGroup("Services")
      LV_AddItem("Windows Search", True, True, True, "On/Off")
      'End If

      'ResizeLVColumns(lvOptimizer)
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
                     pbActions.Value += 1

               End Select

            '======================================================================================
            Case "Services"
               Select Case item.Text

                  '--------------------------------------------------------------------------------
                  Case "Windows Search"
                     StopService("wsearch")
                     pbActions.Value += 1

               End Select

         End Select
      Next
   End Sub

   Private Sub frmOptimizer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      lvOptimizer.View = View.Details
      lvOptimizer.OwnerDraw = True
      lvOptimizer.FullRowSelect = True

      AddHandler lvOptimizer.DrawColumnHeader, AddressOf lvOptimizer_DrawColumnHeader
      AddHandler lvOptimizer.DrawItem, AddressOf lvOptimizer_DrawItem
      AddHandler lvOptimizer.DrawSubItem, AddressOf lvOptimizer_DrawSubItem

      pbActions = New rrProgressBar()
      pbActions.Dock = DockStyle.None
      pbActions.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
      pbActions.Location = New Point(3, 417)
      pbActions.Size = New Size(745, 20)
      Me.Controls.Add(pbActions)

      BuildOptions()

   End Sub

   Private Async Sub btnProcess_Click(sender As Object, e As EventArgs) Handles btnProcess.Click
      Dim itemsToProcess As New List(Of ListViewItem)()
      For Each item As ListViewItem In lvOptimizer.Items
         If item.Checked AndAlso item.Group IsNot Nothing Then
            itemsToProcess.Add(item)
         End If
      Next

      pbActions.Maximum = itemsToProcess.Count

      Try
         Await Task.Run(Sub() ProcessActions(itemsToProcess))
      Finally

      End Try
   End Sub

   Private Sub lvOptimizer_DrawColumnHeader(sender As Object, e As DrawListViewColumnHeaderEventArgs) Handles lvOptimizer.DrawColumnHeader
      e.DrawDefault = True
   End Sub

   Private Sub lvOptimizer_DrawItem(sender As Object, e As DrawListViewItemEventArgs) Handles lvOptimizer.DrawItem
      'e.DrawDefault = True
   End Sub

   Private Sub lvOptimizer_DrawSubItem(sender As Object, e As DrawListViewSubItemEventArgs) Handles lvOptimizer.DrawSubItem
      Dim data = TryCast(e.Item.Tag, LV_CheckBoxData)
      If data Is Nothing Then
         e.DrawDefault = True
         Return
      End If

      ' Only column 2
      If e.ColumnIndex = 1 AndAlso data.HasCheckBox Then
         Dim g = e.Graphics
         Dim bounds = e.Bounds

         Dim cbSize As Integer = 14
         Dim x As Integer = bounds.X + 4
         Dim y As Integer = bounds.Y + (bounds.Height - cbSize) \ 2

         ControlPaint.DrawCheckBox(g,
             New Rectangle(x, y, cbSize, cbSize),
             If(data.CheckState, ButtonState.Checked, ButtonState.Normal)
         )

         ' Optional text next to checkbox
         Dim txt As String = If(data.CheckState, "Enabled", "Disabled")
         Using f As New Font("Segoe UI", 9)
            g.DrawString(txt, f, Brushes.Black, x + cbSize + 6, y - 1)
         End Using

      Else
         e.DrawDefault = True
      End If
   End Sub

End Class
