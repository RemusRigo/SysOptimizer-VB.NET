Public Class Form1

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
      item.SubItems.Add("")
      item.SubItems.Add("")
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
         LV_AddGroup("Services")
         LV_AddItem("Print Spooler", True)
         LV_AddItem("Windows Search", True)
      End If

      'ResizeColumns()
      lvOptimizer.EndUpdate()
   End Sub

   '-----------------------------------------------------------------------------------------------
   ' Process Actions
   Private Async Sub ProcessActions(itemsToProcess As List(Of ListViewItem))
      For Each item As ListViewItem In itemsToProcess
         Dim grp = item.Group
         If grp Is Nothing Then Continue For

         Select Case grp.Header
            Case "Services" '------------------------------------------------
               Select Case item.Text

                  Case "Windows Search"

               End Select

         End Select
      Next
   End Sub

   Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      BuildOptions()

      Dim log As New Logger(appName)
      log.Msg.Info("test/starting app")
   End Sub
End Class
