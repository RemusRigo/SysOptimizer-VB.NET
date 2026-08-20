Imports System.IO
Imports System.Windows.Forms.Design.AxImporter
Imports Microsoft.VisualBasic.Logging
Imports Microsoft.Win32
Imports SysOptimizer.UIControls
Imports Windows.Win32.System

Public Class frmFileSystem

   Private pbActions As rrProgressBar

   Dim log As New Logger(appName)
   Dim grp As ListViewGroup = Nothing


   '-----------------------------------------------------------------------------------------------
   ' Add ListView Group
   Private Sub LV_AddGroup(name As String)
      grp = New ListViewGroup(name)
      lvFileSystem.Groups.Add(grp)
   End Sub

   '-----------------------------------------------------------------------------------------------
   ' Add ListView item
   Private Sub LV_AddItem(name As String, isChecked As Boolean)
      Dim item As New ListViewItem(name)
      item.Checked = isChecked
      item.Group = grp
      lvFileSystem.Items.Add(item)
   End Sub

   '-----------------------------------------------------------------------------------------------
   ' Build Options
   Public Sub BuildOptions()
      lvFileSystem.BeginUpdate()
      lvFileSystem.Items.Clear()
      lvFileSystem.Groups.Clear()

      LV_AddGroup("Services")
      If IsAppElevated() Then LV_AddItem("Windows Search/Indexing Service", True)
      LV_AddItem("test", True)

      ResizeLVColumns(lvFileSystem)
      lvFileSystem.EndUpdate()
   End Sub

   '-----------------------------------------------------------------------------------------------
   ' Process Actions
   Private Async Sub ProcessActions(itemsToProcess As List(Of ListViewItem))
      For Each item As ListViewItem In itemsToProcess
         Dim grp = item.Group
         If grp Is Nothing Then Continue For

         Select Case grp.Header
            '======================================================================================
            Case "Services"
               Select Case item.Text

                  '--------------------------------------------------------------------------------
                  Case "Windows Search/Indexing Service"
                     StopService("wsearch")
                     pbActions.Value += 1



               End Select
         End Select
      Next
   End Sub

   Private Sub frmFileSystem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      lvFileSystem.View = View.Details
      lvFileSystem.FullRowSelect = True

      pbActions = New rrProgressBar()
      pbActions.Dock = DockStyle.None
      pbActions.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
      pbActions.Location = New Point(3, 417)
      pbActions.Size = New Size(745, 20)
      Me.Controls.Add(pbActions)

      BuildOptions()

   End Sub

   Private Async Sub btnProcess_Click(sender As Object, e As EventArgs) Handles btnFSProcess.Click
      Dim itemsToProcess As New List(Of ListViewItem)()
      For Each item As ListViewItem In lvFileSystem.Items
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

End Class
