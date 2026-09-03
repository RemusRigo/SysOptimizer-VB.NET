'--------------------------------------------------------------------------------------------------
' libServices.vb
'    © 2026 Remus Rigo
'       v1.0.2026-06-13
'--------------------------------------------------------------------------------------------------

Imports System.ComponentModel
Imports System.Runtime.InteropServices
Imports System.ServiceProcess

Module libServices

   ''' <summary>Retrieves the current status of the specified Windows service</summary>
   Public Function GetServiceStatus(serviceName As String) As ServiceControllerStatus
      Try
         Using sc As New ServiceController(serviceName)
            Return sc.Status
         End Using
      Catch ex As Exception
         Throw New InvalidOperationException($"Failed to get status for service '{serviceName}'.", ex)
      End Try
   End Function

   ''' <summary>Starts the service if it is not already running. (default timeout: 10 seconds)</summary>
   Public Function StartService(serviceName As String, Optional timeoutMilliseconds As Integer = 10000) As Boolean
      Try
         Using sc As New ServiceController(serviceName)
            ' Check if it's already running
            If sc.Status = ServiceControllerStatus.Running Then
               Return True
            End If

            ' Start if it's not already starting
            If sc.Status <> ServiceControllerStatus.StartPending Then
               sc.Start()
            End If

            ' Wait for it to start
            sc.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromMilliseconds(timeoutMilliseconds))
            Return True
         End Using
      Catch ex As Exception
         Return False
      End Try
   End Function

   ''' <summary>Stops the service if it is not already stopped. (default timeout: 10 seconds)</summary>
   Public Function StopService(serviceName As String, Optional timeoutMilliseconds As Integer = 10000) As Boolean
      Try
         Using sc As New ServiceController(serviceName)
            ' Check if it's already stopped
            If sc.Status = ServiceControllerStatus.Stopped Then
               Return True
            End If

            ' Stop if it's running
            If sc.Status <> ServiceControllerStatus.StopPending Then
               sc.Stop()
            End If

            ' Wait for it to stop
            sc.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromMilliseconds(timeoutMilliseconds))
            Return True
         End Using
      Catch ex As Exception
         Return False
      End Try
   End Function


   ''' <summary>Restarts the service by stopping it and then starting it. (default timeout: 10 seconds for each operation)</summary>
   Public Function RestartService(serviceName As String, Optional timeoutMilliseconds As Integer = 10000) As Boolean
      Try
         Using sc As New ServiceController(serviceName)

            ' Stop if running
            If sc.Status <> ServiceControllerStatus.Stopped AndAlso sc.Status <> ServiceControllerStatus.StopPending Then
               sc.Stop()
               sc.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromMilliseconds(timeoutMilliseconds))
            End If

            ' Start
            sc.Start()
            sc.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromMilliseconds(timeoutMilliseconds))
            Return True

         End Using
      Catch ex As Exception
         Return False
      End Try
   End Function

   Public Function GetServiceStartUpType(serviceName As String) As ServiceStartMode
      Dim hScm As IntPtr = IntPtr.Zero
      Dim hService As IntPtr = IntPtr.Zero
      Dim configPtr As IntPtr = IntPtr.Zero
      Try
         hScm = OpenSCManager(Nothing, Nothing, SC_MANAGER_CONNECT)
         If hScm = IntPtr.Zero Then Throw New Win32Exception(Marshal.GetLastWin32Error())

         hService = OpenService(hScm, serviceName, SERVICE_QUERY_CONFIG)
         If hService = IntPtr.Zero Then Throw New Win32Exception(Marshal.GetLastWin32Error())

         ' First call is expected to fail - it just reports the buffer size we actually need
         Dim bytesNeeded As Integer = 0
         QueryServiceConfig(hService, IntPtr.Zero, 0, bytesNeeded)

         configPtr = Marshal.AllocHGlobal(bytesNeeded)
         If Not QueryServiceConfig(hService, configPtr, bytesNeeded, bytesNeeded) Then
            Throw New Win32Exception(Marshal.GetLastWin32Error())
         End If

         Dim config = CType(Marshal.PtrToStructure(configPtr, GetType(QUERY_SERVICE_CONFIG)), QUERY_SERVICE_CONFIG)
         Return CType(config.dwStartType, ServiceStartMode)

      Catch ex As Exception
         Throw New InvalidOperationException($"Failed to get startup type for service '{serviceName}'.", ex)
      Finally
         ' free resources
         If configPtr <> IntPtr.Zero Then Marshal.FreeHGlobal(configPtr)
         If hService <> IntPtr.Zero Then CloseServiceHandle(hService)
         If hScm <> IntPtr.Zero Then CloseServiceHandle(hScm)
      End Try
   End Function

   ''' <summary>use ServiceStartMode or Boot=0, System=1, Automatic=2, Manual=3, Disabled=4</summary>
   Public Function SetServiceStartUpType(serviceName As String, mode As ServiceStartMode) As Boolean

      Dim hSCM As IntPtr = IntPtr.Zero
      Dim hService As IntPtr = IntPtr.Zero
      Try
         hSCM = OpenSCManager(Nothing, Nothing, SC_MANAGER_CONNECT)
         If hSCM = IntPtr.Zero Then Return False

         hService = OpenService(hSCM, serviceName, SERVICE_CHANGE_CONFIG)
         If hService = IntPtr.Zero Then Return False

         Return ChangeServiceConfig(hService, SERVICE_NO_CHANGE, CInt(mode), SERVICE_NO_CHANGE, Nothing, Nothing, IntPtr.Zero, Nothing, Nothing, Nothing, Nothing)
      Catch ex As Exception
         Return False
      Finally
         ' free resources
         If hService <> IntPtr.Zero Then CloseServiceHandle(hService)
         If hSCM <> IntPtr.Zero Then CloseServiceHandle(hSCM)
      End Try
   End Function


   'Public Function GetServiceStartMode(serviceName As String) As String
   '   Try
   '      Using sc As New ServiceController(serviceName)
   '         ' sc.StartType returns a ServiceStartMode enumeration (e.g., Automatic, Manual, Disabled)
   '         Return sc.StartType.ToString()
   '      End Using
   '   Catch ex As Exception
   '      Return "Error: " & ex.Message
   '   End Try
   'End Function


End Module
