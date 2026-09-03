'--------------------------------------------------------------------------------------------------
' SysOptimizer: frmRegistry.vb: Registry optimization
'    © 2026 Remus Rigo
'       v1.1.20260825
'--------------------------------------------------------------------------------------------------

Imports Microsoft.VisualBasic.FileIO
Imports Microsoft.Win32
Imports SysOptimizer.UIControls

Public Class frmRegistry

   Private lvcbRegistry As clsListViewCheckBox
   Private pbActions As ctrlProgressBarPercentage
   Private log As New Logger(appName)

   Dim grp As ListViewGroup = Nothing

   '-----------------------------------------------------------------------------------------------
   ' Build Options
   Public Sub BuildOptions()
      lvRegistry.BeginUpdate()
      lvRegistry.Items.Clear()

      LV_AddGroup(lvRegistry, grp, "Content Delivery Manager")
      LVCB_AddItem(lvRegistry, grp, "Automatically Install Suggested Apps", True, True)
      LVCB_AddItem(lvRegistry, grp, "SubscribedContent-310093Enabled: Windows Welcome Experience", True, True)
      LVCB_AddItem(lvRegistry, grp, "SubscribedContent-338388Enabled: Get Even More Out of Windows", True, True)
      LVCB_AddItem(lvRegistry, grp, "SubscribedContent-338389Enabled: Get tips, tricks, and suggestions as you use Windows", True, True)
      LVCB_AddItem(lvRegistry, grp, "SubscribedContent-338393Enabled: Suggested Content in Settings app", True, True)
      LVCB_AddItem(lvRegistry, grp, "SubscribedContent-353694Enabled: Suggested Content in Settings app", True, True)
      LVCB_AddItem(lvRegistry, grp, "SubscribedContent-353696Enabled: Suggested Content in Settings app", True, True)
      LVCB_AddItem(lvRegistry, grp, "SoftLandingEnabled: Get tips and suggestions when using Windows", True, True)

      LV_AddGroup(lvRegistry, grp, "Control Panel")
      LVCB_AddItem(lvRegistry, grp, "Disable StickyKeys shortcut", True, True)

      LV_AddGroup(lvRegistry, grp, "Notifications")
      LVCB_AddItem(lvRegistry, grp, "Suggest ways to get the most out of Windows and finish setting up this device", True, True)

      LV_AddGroup(lvRegistry, grp, "Start Menu")
      LVCB_AddItem(lvRegistry, grp, "Disable Bing Search", True, True)

      lvRegistry.EndUpdate()
   End Sub

   '-----------------------------------------------------------------------------------------------
   ' Process Actions
   Private Sub ProcessActions(itemsToProcess As List(Of ListViewItem))
      For Each item As ListViewItem In itemsToProcess
         Dim grp = item.Group
         If grp Is Nothing Then Continue For

         Select Case grp.Header
            '======================================================================================
            Case "Content Delivery Manager"
               Select Case item.Text

                  '--------------------------------------------------------------------------------
                  Case "Automatically Install Suggested Apps"
                     If DirectCast(item.Tag, LV_CheckBoxData).CheckState Then ' Restore default                    
                        RegWriteDWord(Registry.CurrentUser, "Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager", "SilentInstalledAppsEnabled", 1)
                     Else ' Optimize
                        RegWriteDWord(Registry.CurrentUser, "Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager", "SilentInstalledAppsEnabled", 0)
                     End If
                     pbActions.Value += 1

                  Case "SubscribedContent-310093Enabled: Windows Welcome Experience"
                     If DirectCast(item.Tag, LV_CheckBoxData).CheckState Then ' Restore default                    
                        RegWriteDWord(Registry.CurrentUser, "Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager", "SubscribedContent-310093Enabled", 1)
                     Else ' Optimize
                        RegWriteDWord(Registry.CurrentUser, "Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager", "SubscribedContent-310093Enabled", 0)
                     End If
                     pbActions.Value += 1

                  Case "SubscribedContent-338388Enabled: Get Even More Out of Windows"
                     If DirectCast(item.Tag, LV_CheckBoxData).CheckState Then ' Restore default                    
                        RegWriteDWord(Registry.CurrentUser, "Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager", "SubscribedContent-338388Enabled", 1)
                     Else ' Optimize
                        RegWriteDWord(Registry.CurrentUser, "Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager", "SubscribedContent-338388Enabled", 0)
                     End If
                     pbActions.Value += 1

                  Case "SubscribedContent-338389Enabled: Get tips, tricks, and suggestions as you use Windows"
                     If DirectCast(item.Tag, LV_CheckBoxData).CheckState Then ' Restore default                    
                        RegWriteDWord(Registry.CurrentUser, "Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager", "SubscribedContent-338389Enabled", 1)
                     Else ' Optimize
                        RegWriteDWord(Registry.CurrentUser, "Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager", "SubscribedContent-338389Enabled", 0)
                     End If
                     pbActions.Value += 1

                  Case "SubscribedContent-338393Enabled: Suggested Content in Settings app"
                     If DirectCast(item.Tag, LV_CheckBoxData).CheckState Then ' Restore default                    
                        RegWriteDWord(Registry.CurrentUser, "Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager", "SubscribedContent-338393Enabled", 1)
                     Else ' Optimize
                        RegWriteDWord(Registry.CurrentUser, "Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager", "SubscribedContent-338393Enabled", 0)
                     End If
                     pbActions.Value += 1

                  Case "SubscribedContent-353694Enabled: Suggested Content in Settings app"
                     If DirectCast(item.Tag, LV_CheckBoxData).CheckState Then ' Restore default                    
                        RegWriteDWord(Registry.CurrentUser, "Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager", "SubscribedContent-353694Enabled", 1)
                     Else ' Optimize
                        RegWriteDWord(Registry.CurrentUser, "Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager", "SubscribedContent-353694Enabled", 0)
                     End If
                     pbActions.Value += 1

                  Case "SubscribedContent-353696Enabled: Suggested Content in Settings app"
                     If DirectCast(item.Tag, LV_CheckBoxData).CheckState Then ' Restore default                    
                        RegWriteDWord(Registry.CurrentUser, "Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager", "SubscribedContent-353696Enabled", 1)
                     Else ' Optimize
                        RegWriteDWord(Registry.CurrentUser, "Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager", "SubscribedContent-353696Enabled", 0)
                     End If
                     pbActions.Value += 1

                  Case "SoftLandingEnabled: Get tips and suggestions when using Windows"
                     If DirectCast(item.Tag, LV_CheckBoxData).CheckState Then ' Restore default                    
                        RegWriteDWord(Registry.CurrentUser, "Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager", "SoftLandingEnabled", 1)
                     Else ' Optimize
                        RegWriteDWord(Registry.CurrentUser, "Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager", "SoftLandingEnabled", 0)
                     End If
                     pbActions.Value += 1

               End Select

            Case "Control Panel" '----------------------------------------------------------------------
               Select Case item.Text

                  Case "Disable StickyKeys shortcut"
                     If DirectCast(item.Tag, LV_CheckBoxData).CheckState Then ' Restore default                    
                        RegWriteSZ(Registry.CurrentUser, "Control Panel\Accessibility\StickyKeys", "Flags", 510)
                     Else ' Optimize
                        RegWriteSZ(Registry.CurrentUser, "Control Panel\Accessibility\StickyKeys", "Flags", 506)
                     End If
                     pbActions.Value += 1

               End Select

            Case "Notifications"
               Select Case item.Text

                  '--------------------------------------------------------------------------------
                  Case "Suggest ways to get the most out of Windows and finish setting up this device"
                     If DirectCast(item.Tag, LV_CheckBoxData).CheckState Then ' Restore default                    
                        RegWriteDWord(Registry.CurrentUser, "Software\Microsoft\Windows\CurrentVersion\UserProfileEngagemen", "ScoobeSystemSettingEnabled", 1)
                     Else ' Optimize
                        RegWriteDWord(Registry.CurrentUser, "Software\Microsoft\Windows\CurrentVersion\UserProfileEngagemen", "ScoobeSystemSettingEnabled", 0)
                     End If
                     pbActions.Value += 1

               End Select

            Case "Start Menu"
               Select Case item.Text

                  '--------------------------------------------------------------------------------
                  Case "Disable Bing Search"
                     If DirectCast(item.Tag, LV_CheckBoxData).CheckState Then ' Restore default                    
                        RegWriteDWord(Registry.CurrentUser, "Software\Microsoft\Windows\CurrentVersion\Search", "BingSearchEnabled", 1)
                        RegWriteDWord(Registry.CurrentUser, "Software\Microsoft\Windows\CurrentVersion\Search", "CortanaConsent", 1)
                     Else ' Optimize
                        RegWriteDWord(Registry.CurrentUser, "Software\Microsoft\Windows\CurrentVersion\Search", "BingSearchEnabled", 0)
                        RegWriteDWord(Registry.CurrentUser, "Software\Microsoft\Windows\CurrentVersion\Search", "CortanaConsent", 0)
                     End If
                     pbActions.Value += 1

               End Select

         End Select
      Next
   End Sub

   '-----------------------------------------------------------------------------------------------
   ' frmRegistry: OnLoad
   Private Sub frmRegistry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      lvRegistry.HeaderStyle = ColumnHeaderStyle.None
      lvcbRegistry = New clsListViewCheckBox(lvRegistry)
      lvcbRegistry.AttachContextMenu()

      pbActions = New ctrlProgressBarPercentage()
      pbActions.Dock = DockStyle.None
      pbActions.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
      pbActions.Location = New Point(3, 417)
      pbActions.Size = New Size(745, 20)
      Me.Controls.Add(pbActions)

      BuildOptions()
   End Sub

   '-----------------------------------------------------------------------------------------------
   ' btnRegRun: OnClick
   Private Sub btnRegRun_Click(sender As Object, e As EventArgs) Handles btnRegRun.Click
      Dim itemsToProcess As New List(Of ListViewItem)()
      For Each item As ListViewItem In lvRegistry.Items
         If item.Checked AndAlso item.Group IsNot Nothing Then
            itemsToProcess.Add(item)
         End If
      Next
      pbActions.Maximum = itemsToProcess.Count
      ProcessActions(itemsToProcess)
   End Sub

End Class