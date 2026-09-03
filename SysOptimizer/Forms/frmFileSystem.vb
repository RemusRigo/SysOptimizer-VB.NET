'--------------------------------------------------------------------------------------------------
' SysOptimizer: frmFileSystem.vb: FileSystem optimization
'    © 2026 Remus Rigo
'       v1.1.20260825
'--------------------------------------------------------------------------------------------------

Imports System.ServiceProcess ' ServiceStartMode
Imports SysOptimizer.UIControls

Public Class frmFileSystem

   Private lvcbFileSystem As clsListViewCheckBox
   Private pbActions As ctrlProgressBarPercentage
   Private log As New Logger(appName)

   Dim grp As ListViewGroup = Nothing

   '-----------------------------------------------------------------------------------------------
   ' Build Options
   Public Sub BuildOptions()
      lvFileSystem.BeginUpdate()
      lvFileSystem.Items.Clear()
      lvFileSystem.Groups.Clear()

      LV_AddGroup(lvFileSystem, grp, "Services")
      If IsAppElevated() Then LVCB_AddItem(lvFileSystem, grp, "Connected User Experiences And Telemetry", False, False)
      If IsAppElevated() Then LVCB_AddItem(lvFileSystem, grp, "Delivery Optimization", False, True)
      If IsAppElevated() Then LVCB_AddItem(lvFileSystem, grp, "Downloaded Maps Manager", False, True)
      If IsAppElevated() Then LVCB_AddItem(lvFileSystem, grp, "Program Compatibility Assistant Service", False, True)
      If IsAppElevated() Then LVCB_AddItem(lvFileSystem, grp, "SysMain (Superfetch)", False, True)
      If IsAppElevated() Then LVCB_AddItem(lvFileSystem, grp, "Windows Health And Optimized Experiences", False, True)
      If IsAppElevated() Then LVCB_AddItem(lvFileSystem, grp, "Windows Search/Indexing Service", False, True)
      If IsAppElevated() Then LVCB_AddItem(lvFileSystem, grp, "Windows Subsystem for Linux (WSL) service", False, True)
      If IsAppElevated() Then LVCB_AddItem(lvFileSystem, grp, "WSAIFabricSvc", False, True)

      'ResizeLVColumns(lvFileSystem)
      lvFileSystem.EndUpdate()
   End Sub

   '-----------------------------------------------------------------------------------------------
   ' Process Actions
   Private Sub ProcessActions(itemsToProcess As List(Of ListViewItem))
      For Each item As ListViewItem In itemsToProcess
         Dim grp = item.Group
         If grp Is Nothing Then Continue For

         Select Case grp.Header

            Case "Services" '----------------------------------------------------------------------
               Select Case item.Text

                  Case "Connected User Experiences And Telemetry"
                     If DirectCast(item.Tag, LV_CheckBoxData).CheckState Then ' Restore default                    
                        StartService("DiagTrack")
                        SetServiceStartUpType("DiagTrack", ServiceStartMode.Automatic)
                     Else ' Optimize
                        StopService("DiagTrack")
                        SetServiceStartUpType("DiagTrack", ServiceStartMode.Disabled)
                     End If
                     pbActions.Value += 1

                  Case "Delivery Optimization"
                     If DirectCast(item.Tag, LV_CheckBoxData).CheckState Then ' Restore default                    
                        StartService("DoSvc")
                        SetServiceStartUpType("DoSvc", ServiceStartMode.Automatic)
                     Else ' Optimize
                        StopService("DoSvc")
                        SetServiceStartUpType("DoSvc", ServiceStartMode.Disabled)
                     End If
                     pbActions.Value += 1

                  Case "Downloaded Maps Manager"
                     If DirectCast(item.Tag, LV_CheckBoxData).CheckState Then ' Restore default                    
                        StartService("MapsBroker")
                        SetServiceStartUpType("MapsBroker", ServiceStartMode.Automatic)
                     Else ' Optimize
                        StopService("MapsBroker")
                        SetServiceStartUpType("MapsBroker", ServiceStartMode.Disabled)
                     End If
                     pbActions.Value += 1

                  Case "Program Compatibility Assistant Service"
                     If DirectCast(item.Tag, LV_CheckBoxData).CheckState Then ' Restore default                    
                        StartService("PcaSvc")
                        SetServiceStartUpType("PcaSvc", ServiceStartMode.Automatic)
                     Else ' Optimize
                        StopService("PcaSvc")
                        SetServiceStartUpType("PcaSvc", ServiceStartMode.Manual)
                     End If
                     pbActions.Value += 1

                  Case "SysMain (Superfetch)"
                     If DirectCast(item.Tag, LV_CheckBoxData).CheckState Then ' Restore default                    
                        StartService("SysMain")
                        SetServiceStartUpType("SysMain", ServiceStartMode.Automatic)
                     Else ' Optimize
                        StopService("SysMain")
                        SetServiceStartUpType("SysMain", ServiceStartMode.Disabled)
                     End If
                     pbActions.Value += 1

                  Case "Windows Health And Optimized Experiences"
                     If DirectCast(item.Tag, LV_CheckBoxData).CheckState Then ' Restore default                    
                        StartService("whesvc")
                        SetServiceStartUpType("whesvc", ServiceStartMode.Automatic)
                     Else ' Optimize
                        StopService("whesvc")
                        SetServiceStartUpType("whesvc", ServiceStartMode.Disabled)
                     End If
                     pbActions.Value += 1

                  Case "Windows Search/Indexing Service"
                     If DirectCast(item.Tag, LV_CheckBoxData).CheckState Then ' Restore default                    
                        StartService("wsearch")
                        SetServiceStartUpType("wsearch", ServiceStartMode.Automatic)
                     Else ' Optimize
                        StopService("wsearch")
                        SetServiceStartUpType("wsearch", ServiceStartMode.Disabled)
                     End If
                     pbActions.Value += 1

                  Case "Windows Subsystem for Linux (WSL) service"
                     If DirectCast(item.Tag, LV_CheckBoxData).CheckState Then ' Restore default                    
                        StartService("WSLService")
                        SetServiceStartUpType("WSLService", ServiceStartMode.Automatic)
                     Else ' Optimize
                        StopService("WSLService")
                        SetServiceStartUpType("WSLService", ServiceStartMode.Disabled)
                     End If
                     pbActions.Value += 1

                  Case "WSAIFabricSvc"
                     If DirectCast(item.Tag, LV_CheckBoxData).CheckState Then ' Restore default                    
                        StartService("WSAIFabricSvc")
                        SetServiceStartUpType("WSAIFabricSvc", ServiceStartMode.Automatic)
                     Else ' Optimize
                        StopService("WSAIFabricSvc")
                        SetServiceStartUpType("WSAIFabricSvc", ServiceStartMode.Disabled)
                     End If
                     pbActions.Value += 1

               End Select
         End Select
      Next
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

      BuildOptions()
   End Sub

   '-----------------------------------------------------------------------------------------------
   ' btnFSRun: OnClick
   Private Sub btnFSRun_Click(sender As Object, e As EventArgs) Handles btnFSRun.Click
      Dim itemsToProcess As New List(Of ListViewItem)()
      For Each item As ListViewItem In lvFileSystem.Items
         If item.Checked AndAlso item.Group IsNot Nothing Then
            itemsToProcess.Add(item)
         End If
      Next
      pbActions.Maximum = itemsToProcess.Count
      ProcessActions(itemsToProcess)
   End Sub

End Class
