'--------------------------------------------------------------------------------------------------
' SysOptimizer: frmApps.vb: Apps optimization
'    © 2026 Remus Rigo
'       v1.2.20261121
'--------------------------------------------------------------------------------------------------

Imports Microsoft.Win32
Imports SysOptimizer.UIControls

Public Class frmApps
   Private lvcbApps As clsListViewCheckBox
   Private pbActions As ctrlProgressBarPercentage
   Private ol As OptionList
   Private log As New Logger(appName)

   '-----------------------------------------------------------------------------------------------
   ' Build Options: restore default = 1, optimize = 0 (AddRegDWord defaults)
   Public Sub BuildOptions()
      Const EDGE As String = "Software\Policies\Microsoft\Edge"
      Dim HKLM = Registry.LocalMachine

      ol.Build(
         Sub()
            ol.AddGroup("Microsoft Edge")
            If IsAppElevated() Then
               ' Name | checked | root | key | value
               ol.AddRegDWord("Default Browser Setting Enabled", True, HKLM, EDGE, "DefaultBrowserSettingEnabled")
               ol.AddRegDWord("Default Browser Settings Campaign Enabled", True, HKLM, EDGE, "DefaultBrowserSettingsCampaignEnabled")
               ol.AddRegDWord("Edge Shopping Assistant Enabled", True, HKLM, EDGE, "EdgeShoppingAssistantEnabled")
               ol.AddRegDWord("Hide First Run Experience", True, HKLM, EDGE, "HideFirstRunExperience")
               ol.AddRegDWord("New TabPage Content Enabled", True, HKLM, EDGE, "NewTabPageContentEnabled")
            End If
         End Sub)

      lvApps.Columns(0).Width = -1
      lvApps.Columns(0).Width = lvApps.Columns(0).Width + 30
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

      ol = New OptionList(lvApps, pbActions, log)
      BuildOptions()
   End Sub

   '-----------------------------------------------------------------------------------------------
   ' btnProcess: OnClick
   Private Sub btnProcess_Click(sender As Object, e As EventArgs) Handles btnAppsRun.Click
      ol.Run()
   End Sub

   'Private Sub frmApps_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
   '   lvcbApps?.Detach()
   'End Sub
End Class
