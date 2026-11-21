'--------------------------------------------------------------------------------------------------
' SysOptimizer: frmFileSystem.vb: FileSystem optimization
'    © 2026 Remus Rigo
'       v1.2.20261121
'--------------------------------------------------------------------------------------------------

Imports System.ServiceProcess ' ServiceStartMode
Imports SysOptimizer.UIControls

Public Class frmFileSystem

   Private lvcbFileSystem As clsListViewCheckBox
   Private pbActions As ctrlProgressBarPercentage
   Private ol As OptionList
   Private log As New Logger(appName)

   '-----------------------------------------------------------------------------------------------
   ' Build Options: each row knows what it does (OptionList.AddService), so there is no ProcessActions
   Public Sub BuildOptions()
      ol.Build(
         Sub()
            ol.AddGroup("Services")
            If IsAppElevated() Then
               ' Service Name | checked | service | optimize to
               ol.AddService("Connected User Experiences And Telemetry", False, "DiagTrack")
               ol.AddService("Delivery Optimization", False, "DoSvc")
               ol.AddService("Downloaded Maps Manager", False, "MapsBroker")
               ol.AddService("Program Compatibility Assistant Service", False, "PcaSvc", ServiceStartMode.Manual)
               ol.AddService("SysMain (Superfetch)", False, "SysMain")
               ol.AddService("Windows Health And Optimized Experiences", False, "whesvc")
               ol.AddService("Windows Search/Indexing Service", False, "wsearch")
               ol.AddService("Windows Subsystem for Linux (WSL) service", False, "WSLService")
               ol.AddService("WSAIFabricSvc", False, "WSAIFabricSvc")
            End If
         End Sub)
   End Sub

   '-----------------------------------------------------------------------------------------------
   ' frmFileSystem: OnLoad
   Private Sub frmFileSystem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      lvFileSystem.HeaderStyle = ColumnHeaderStyle.None
      lvcbFileSystem = New clsListViewCheckBox(lvFileSystem)
      lvcbFileSystem.AttachContextMenu()

      pbActions = New ctrlProgressBarPercentage()
      pbActions.Dock = DockStyle.None
      pbActions.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
      pbActions.Location = New Point(3, 417)
      pbActions.Size = New Size(745, 20)
      Me.Controls.Add(pbActions)

      ol = New OptionList(lvFileSystem, pbActions, log)
      BuildOptions()
   End Sub

   '-----------------------------------------------------------------------------------------------
   ' btnFSRun: OnClick
   Private Sub btnFSRun_Click(sender As Object, e As EventArgs) Handles btnFSRun.Click
      ol.Run()
   End Sub

End Class
