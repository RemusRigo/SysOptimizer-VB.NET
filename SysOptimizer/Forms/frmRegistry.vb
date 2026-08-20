Imports System.IO
Imports Microsoft.VisualBasic.FileIO
Imports Microsoft.Win32

Public Class frmRegistry

   Dim log As New Logger(appName)

   Private pbActions As rrProgressBar

   Dim grp As ListViewGroup = Nothing

   Private Sub LV_AddGroup(name As String)
      grp = New ListViewGroup(name)
      lvRegistry.Groups.Add(grp)
   End Sub

   '-----------------------------------------------------------------------------------------------
   ' Add ListView item
   Private Sub LV_AddItem(name As String, isChecked As Boolean)
      Dim item As New ListViewItem(name)
      item.Checked = isChecked
      item.Group = grp
      lvRegistry.Items.Add(item)
   End Sub

   '-----------------------------------------------------------------------------------------------
   ' Build Options
   Public Sub BuildOptions()
      lvRegistry.BeginUpdate()
      lvRegistry.Items.Clear()

      LV_AddGroup("Start Menu")
      LV_AddItem("Disable Bing Search", True)

      lvRegistry.EndUpdate()
   End Sub

   '-----------------------------------------------------------------------------------------------
   ' Process Actions
   Private Async Sub ProcessActions(itemsToProcess As List(Of ListViewItem))
      For Each item As ListViewItem In itemsToProcess
         Dim grp = item.Group
         If grp Is Nothing Then Continue For

         Select Case grp.Header
            '======================================================================================
            Case "Start Menu"
               Select Case item.Text

                  '--------------------------------------------------------------------------------
                  Case "Disable Bing Search"
                     RegWriteDWord(Registry.CurrentUser, "Software\Microsoft\Windows\CurrentVersion\Search", "AllowSearchToUseLocation", 0)
                     RegWriteDWord(Registry.CurrentUser, "Software\Microsoft\Windows\CurrentVersion\Search", "BingSearchEnabled", 0)
                     RegWriteDWord(Registry.CurrentUser, "Software\Microsoft\Windows\CurrentVersion\Search", "CortanaConsent", 0)
                     pbActions.Value += 1

               End Select
         End Select
      Next
   End Sub

   Private Sub frmRegistry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      lvRegistry.View = View.Details
      lvRegistry.FullRowSelect = True

      pbActions = New rrProgressBar()
      pbActions.Dock = DockStyle.None
      pbActions.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
      pbActions.Location = New Point(3, 417)
      pbActions.Size = New Size(745, 20)
      Me.Controls.Add(pbActions)

      BuildOptions()
   End Sub

   Private Async Sub btnRegistry_Click(sender As Object, e As EventArgs) Handles btnRegistry.Click
      Dim itemsToProcess As New List(Of ListViewItem)()

      For Each item As ListViewItem In lvRegistry.Items
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