'--------------------------------------------------------------------------------------------------
' SysOptimizer: frmApps.vb: Apps optimization
'    © 2026 Remus Rigo
'       v1.1.20260825
'--------------------------------------------------------------------------------------------------

Imports Microsoft.Win32
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


      LV_AddGroup(lvApps, grp, "Microsoft Edge")
      If IsAppElevated() Then LVCB_AddItem(lvApps, grp, "Default Browser Setting Enabled", True, True)
      If IsAppElevated() Then LVCB_AddItem(lvApps, grp, "Default Browser Settings Campaign Enabled", True, True)
      If IsAppElevated() Then LVCB_AddItem(lvApps, grp, "Edge Shopping Assistant Enabled", True, True)
      If IsAppElevated() Then LVCB_AddItem(lvApps, grp, "Hide First Run Experience", True, True)
      If IsAppElevated() Then LVCB_AddItem(lvApps, grp, "New TabPage Content Enabled", True, True)

      lvApps.Columns(0).Width = -1
      lvApps.Columns(0).Width = lvApps.Columns(0).Width + 30
      lvApps.EndUpdate()
   End Sub

   '-----------------------------------------------------------------------------------------------
   ' Process Actions
   Private Sub ProcessActions(itemsToProcess As List(Of ListViewItem))
      For Each item As ListViewItem In itemsToProcess
         Dim grp = item.Group
         If grp Is Nothing Then Continue For

         Select Case grp.Header

            Case "Microsoft Edge"
               Select Case item.Text

                  Case "Default Browser Setting Enabled"
                     If DirectCast(item.Tag, LV_CheckBoxData).CheckState Then ' Restore default                    
                        RegWriteDWord(Registry.LocalMachine, "Software\Policies\Microsoft\Edge", "DefaultBrowserSettingEnabled", 1)
                     Else ' Cloak
                        RegWriteDWord(Registry.LocalMachine, "Software\Policies\Microsoft\Edge", "DefaultBrowserSettingEnabled", 0)
                     End If
                     pbActions.Value += 1

                  Case "Default Browser Settings Campaign Enabled"
                     If DirectCast(item.Tag, LV_CheckBoxData).CheckState Then ' Restore default                    
                        RegWriteDWord(Registry.LocalMachine, "Software\Policies\Microsoft\Edge", "DefaultBrowserSettingsCampaignEnabled", 1)
                     Else ' Cloak
                        RegWriteDWord(Registry.LocalMachine, "Software\Policies\Microsoft\Edge", "DefaultBrowserSettingsCampaignEnabled", 0)
                     End If
                     pbActions.Value += 1

                  Case "Edge Shopping Assistant Enabled"
                     If DirectCast(item.Tag, LV_CheckBoxData).CheckState Then ' Restore default                    
                        RegWriteDWord(Registry.LocalMachine, "Software\Policies\Microsoft\Edge", "EdgeShoppingAssistantEnabled", 1)
                     Else ' Cloak
                        RegWriteDWord(Registry.LocalMachine, "Software\Policies\Microsoft\Edge", "EdgeShoppingAssistantEnabled", 0)
                     End If
                     pbActions.Value += 1

                  Case "Hide First Run Experience"
                     If DirectCast(item.Tag, LV_CheckBoxData).CheckState Then ' Restore default                    
                        RegWriteDWord(Registry.LocalMachine, "Software\Policies\Microsoft\Edge", "HideFirstRunExperience", 1)
                     Else ' Cloak
                        RegWriteDWord(Registry.LocalMachine, "Software\Policies\Microsoft\Edge", "HideFirstRunExperience", 0)
                     End If
                     pbActions.Value += 1

                  Case "New TabPage Content Enabled"
                     If DirectCast(item.Tag, LV_CheckBoxData).CheckState Then ' Restore default                    
                        RegWriteDWord(Registry.LocalMachine, "Software\Policies\Microsoft\Edge", "NewTabPageContentEnabled", 1)
                     Else ' Cloak
                        RegWriteDWord(Registry.LocalMachine, "Software\Policies\Microsoft\Edge", "NewTabPageContentEnabled", 0)
                     End If
                     pbActions.Value += 1

               End Select
         End Select
      Next
   End Sub

   '-----------------------------------------------------------------------------------------------
   ' frmApps: OnLoad
   Private Sub frmApps_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      lvApps.Columns.Add("Option", 350, HorizontalAlignment.Left)
      lvApps.Columns.Add("Default", 75, HorizontalAlignment.Left)
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
