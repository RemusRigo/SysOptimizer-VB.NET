'--------------------------------------------------------------------------------------------------
' SysOptimizer: frmRegistry.vb: Registry optimization
'    © 2026 Remus Rigo
'       v1.2.20261121
'--------------------------------------------------------------------------------------------------

Imports Microsoft.Win32
Imports SysOptimizer.UIControls

Public Class frmRegistry

   Private lvcbRegistry As clsListViewCheckBox
   Private pbActions As ctrlProgressBarPercentage
   Private ol As OptionList
   Private log As New Logger(appName)

   '-----------------------------------------------------------------------------------------------
   ' Build Options
   '    AddRegDWord : one DWORD, restore default = 1, optimize = 0
   '    AddOption   : anything else; the Sub gets restore (True = restore default, False = optimize)
   Public Sub BuildOptions()
      Const CDM As String = "Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"
      Const SEARCH As String = "Software\Microsoft\Windows\CurrentVersion\Search"
      Dim hkcu = Registry.CurrentUser

      ol.Build(
         Sub()
            ol.AddGroup("Content Delivery Manager")
            ol.AddRegDWord("Automatically Install Suggested Apps", True, hkcu, CDM, "SilentInstalledAppsEnabled")
            ol.AddRegDWord("SubscribedContent-310093Enabled: Windows Welcome Experience", True, hkcu, CDM, "SubscribedContent-310093Enabled")
            ol.AddRegDWord("SubscribedContent-338388Enabled: Get Even More Out of Windows", True, hkcu, CDM, "SubscribedContent-338388Enabled")
            ol.AddRegDWord("SubscribedContent-338389Enabled: Get tips, tricks, and suggestions as you use Windows", True, hkcu, CDM, "SubscribedContent-338389Enabled")
            ol.AddRegDWord("SubscribedContent-338393Enabled: Suggested Content in Settings app", True, hkcu, CDM, "SubscribedContent-338393Enabled")
            ol.AddRegDWord("SubscribedContent-353694Enabled: Suggested Content in Settings app", True, hkcu, CDM, "SubscribedContent-353694Enabled")
            ol.AddRegDWord("SubscribedContent-353696Enabled: Suggested Content in Settings app", True, hkcu, CDM, "SubscribedContent-353696Enabled")
            ol.AddRegDWord("SoftLandingEnabled: Get tips and suggestions when using Windows", True, hkcu, CDM, "SoftLandingEnabled")

            ol.AddGroup("Control Panel")
            ol.AddOption("Disable StickyKeys shortcut", True,
               Sub(restore) RegWriteSZ(hkcu, "Control Panel\Accessibility\StickyKeys", "Flags", If(restore, "510", "506")))

            ol.AddGroup("Notifications")
            ol.AddRegDWord("Suggest ways to get the most out of Windows and finish setting up this device", True,
                           hkcu, "Software\Microsoft\Windows\CurrentVersion\UserProfileEngagement", "ScoobeSystemSettingEnabled")

            ol.AddGroup("Start Menu")
            ol.AddOption("Disable Bing Search", True,
               Sub(restore)
                  Dim value = If(restore, 1, 0)
                  RegWriteDWord(hkcu, SEARCH, "BingSearchEnabled", value)
                  RegWriteDWord(hkcu, SEARCH, "CortanaConsent", value)
               End Sub)
         End Sub)
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

      ol = New OptionList(lvRegistry, pbActions, log)
      BuildOptions()
   End Sub

   '-----------------------------------------------------------------------------------------------
   ' btnRegRun: OnClick
   Private Sub btnRegRun_Click(sender As Object, e As EventArgs) Handles btnRegRun.Click
      ol.Run()
   End Sub

End Class
