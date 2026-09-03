'--------------------------------------------------------------------------------------------------
' SysOptimizer: frmApps.vb: Apps optimization
'    © 2026 Remus Rigo
'       v1.1.20260825
'--------------------------------------------------------------------------------------------------

Imports SysOptimizer.UIControls

Public Class frmApps
   Private lvcbApps As clsListViewCheckBox
   Private pbActions As ctrlProgressBarPercentage
   Private log As New Logger(appName)

   Dim grp As ListViewGroup = Nothing

   '-----------------------------------------------------------------------------------------------
   ' Build Options
   Public Sub BuildOptions()
      lvApps.BeginUpdate()
      lvApps.Items.Clear()
      lvApps.Groups.Clear()

      ' If IsAppElevated() Then
      LV_AddGroup(lvApps, grp, "App 1")
      LVCB_AddItem(lvApps, grp, "Item 1", True, True)
      LVCB_AddItem(lvApps, grp, "Item 2", True, True)

      'ResizeLVColumns(lvApps)
      lvApps.EndUpdate()
   End Sub

   '-----------------------------------------------------------------------------------------------
   ' Process Actions
   Private Sub ProcessActions(itemsToProcess As List(Of ListViewItem))
      For Each item As ListViewItem In itemsToProcess
         Dim grp = item.Group
         If grp Is Nothing Then Continue For

         Select Case grp.Header

            Case "App 1"
               Select Case item.Text

                  '--------------------------------------------------------------------------------
                  Case "Item 1"
                     If DirectCast(item.Tag, LV_CheckBoxData).CheckState Then
                        MessageBox.Show("checked")
                     Else
                        MessageBox.Show("unchecked")
                     End If
                     pbActions.Value += 1

                  Case "Item 2"
                     If DirectCast(item.Tag, LV_CheckBoxData).CheckState Then
                        MessageBox.Show("checked")
                     Else
                        MessageBox.Show("unchecked")
                     End If
                     pbActions.Value += 1

               End Select
         End Select
      Next
   End Sub

   '-----------------------------------------------------------------------------------------------
   ' frmApps: OnLoad
   Private Sub frmApps_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      lvApps.HeaderStyle = ColumnHeaderStyle.None
      lvcbApps = New clsListViewCheckBox(lvApps)
      lvcbApps.AttachContextMenu()

      pbActions = New ctrlProgressBarPercentage
      pbActions.Dock = DockStyle.None
      pbActions.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
      pbActions.Location = New Point(3, 417)
      pbActions.Size = New Size(745, 20)
      Me.Controls.Add(pbActions)

      BuildOptions()
   End Sub

   '-----------------------------------------------------------------------------------------------
   ' btnProcess: OnClick
   Private Sub btnProcess_Click(sender As Object, e As EventArgs) Handles btnAppsRun.Click
      Dim itemsToProcess As New List(Of ListViewItem)()
      For Each item As ListViewItem In lvApps.Items
         If item.Checked AndAlso item.Group IsNot Nothing Then
            itemsToProcess.Add(item)
         End If
      Next
      pbActions.Maximum = itemsToProcess.Count
      ProcessActions(itemsToProcess)
   End Sub

   'Private Sub frmApps_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
   '   lvcbApps?.Detach()
   'End Sub
End Class
