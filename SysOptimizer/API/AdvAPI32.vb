'--------------------------------------------------------------------------------------------------
' AdvAPI32.dll - Advanced Windows API functions related to security and policy management.
'    © 2026 Remus Rigo
'       v1.1 20260725
'--------------------------------------------------------------------------------------------------

Imports System.Runtime.InteropServices

Module AdvAPI32

   '-----------------------------------------------------------------------------------------------
   ' Constants

   Public Const OWNER_SECURITY_INFORMATION As UInteger = &H1UI

   Public Const POLICY_ALL_ACCESS As UInteger = &HF0FFF

   Public Const SC_MANAGER_CONNECT As Integer = &H1
   Public Const SERVICE_QUERY_CONFIG As Integer = &H1
   Public Const SERVICE_CHANGE_CONFIG As Integer = &H2
   Public Const SERVICE_NO_CHANGE As Integer = -1 ' bit pattern 0xFFFFFFFF

   Public Const SE_FILE_OBJECT As Integer = 1
   Public Const SE_PRIVILEGE_ENABLED As UInteger = &H2UI

   Public Const TOKEN_ADJUST_PRIVILEGES As UInteger = &H20UI
   Public Const TOKEN_QUERY As UInteger = &H8UI

   '-----------------------------------------------------------------------------------------------
   ' Structures

   <StructLayout(LayoutKind.Sequential)>
   Public Structure LSA_OBJECT_ATTRIBUTES
      Public Length As UInteger
      Public RootDirectory As IntPtr
      Public ObjectName As IntPtr
      Public Attributes As UInteger
      Public SecurityDescriptor As IntPtr
      Public SecurityQualityOfService As IntPtr
   End Structure

   <StructLayout(LayoutKind.Sequential)>
   Public Structure LSA_UNICODE_STRING
      Public Length As UShort
      Public MaximumLength As UShort
      Public Buffer As IntPtr
   End Structure

   <StructLayout(LayoutKind.Sequential)>
   Public Structure LUID
      Public LowPart As UInteger
      Public HighPart As Integer
   End Structure

   <StructLayout(LayoutKind.Sequential)>
   Public Structure LUID_AND_ATTRIBUTES
      Public Luid As LUID
      Public Attributes As UInteger
   End Structure


   Public Enum SE_OBJECT_TYPE
      SE_UNKNOWN_OBJECT_TYPE = 0
      SE_FILE_OBJECT = 1
      SE_SERVICE = 2
      SE_PRINTER = 3
      SE_REGISTRY_KEY = 4
      SE_LMSHARE = 5
      SE_KERNEL_OBJECT = 6
      SE_WINDOW_OBJECT = 7
      SE_DS_OBJECT = 8
      SE_DS_OBJECT_ALL = 9
      SE_PROVIDER_DEFINED_OBJECT = 10
      SE_WMIGUID_OBJECT = 11
      SE_REGISTRY_WOW64_32KEY = 12
   End Enum

   <StructLayout(LayoutKind.Sequential)>
   Public Structure QUERY_SERVICE_CONFIG
      Public dwServiceType As Integer
      Public dwStartType As Integer
      Public dwErrorControl As Integer
      <MarshalAs(UnmanagedType.LPWStr)> Public lpBinaryPathName As String
      <MarshalAs(UnmanagedType.LPWStr)> Public lpLoadOrderGroup As String
      Public dwTagId As Integer
      <MarshalAs(UnmanagedType.LPWStr)> Public lpDependencies As String
      <MarshalAs(UnmanagedType.LPWStr)> Public lpServiceStartName As String
      <MarshalAs(UnmanagedType.LPWStr)> Public lpDisplayName As String
   End Structure

   <StructLayout(LayoutKind.Sequential)>
   Public Structure TOKEN_PRIVILEGES
      Public PrivilegeCount As UInteger
      Public Privileges As LUID_AND_ATTRIBUTES
   End Structure

   '-----------------------------------------------------------------------------------------------
   ' Functions

   <DllImport("advapi32.dll", SetLastError:=True)>
   Public Function AdjustTokenPrivileges(tokenHandle As IntPtr,
      disableAllPrivileges As Boolean,
      ByRef newState As TOKEN_PRIVILEGES,
      bufferLength As Integer,
      ByRef previousState As TOKEN_PRIVILEGES,
      ByRef returnLength As Integer) As Boolean
   End Function

   <DllImport("advapi32.dll", SetLastError:=True, CharSet:=CharSet.Unicode)>
   Public Function ChangeServiceConfig(hService As IntPtr, dwServiceType As Integer, dwStartType As Integer, dwErrorControl As Integer,
                                         lpBinaryPathName As String, lpLoadOrderGroup As String, lpdwTagId As IntPtr,
                                         lpDependencies As String, lpServiceStartName As String, lpPassword As String,
                                         lpDisplayName As String) As Boolean
   End Function

   <DllImport("advapi32.dll", SetLastError:=True)>
   Public Function CloseServiceHandle(hSCObject As IntPtr) As Boolean
   End Function

   <DllImport("advapi32.dll", SetLastError:=True)>
   Public Function LookupPrivilegeValue(lpSystemName As String, lpName As String, ByRef lpLuid As LUID) As Boolean
   End Function

   <DllImport("advapi32.dll", SetLastError:=True)>
   Public Function LsaOpenPolicy(ByRef SystemName As LSA_UNICODE_STRING, ByRef ObjectAttributes As LSA_OBJECT_ATTRIBUTES, AccessMask As UInteger,
                                 ByRef PolicyHandle As IntPtr) As UInteger
   End Function

   <DllImport("advapi32.dll", SetLastError:=True)>
   Public Function LsaStorePrivateData(PolicyHandle As IntPtr, ByRef KeyName As LSA_UNICODE_STRING, ByRef PrivateData As LSA_UNICODE_STRING) As UInteger
   End Function

   <DllImport("advapi32.dll", SetLastError:=True)>
   Public Function LsaRetrievePrivateData(PolicyHandle As IntPtr, ByRef KeyName As LSA_UNICODE_STRING, ByRef PrivateData As IntPtr) As UInteger
   End Function

   <DllImport("advapi32.dll")>
   Public Function LsaClose(ObjectHandle As IntPtr) As UInteger
   End Function

   <DllImport("advapi32.dll")>
   Public Function LsaFreeMemory(Buffer As IntPtr) As UInteger
   End Function

   <DllImport("advapi32.dll", SetLastError:=True, CharSet:=CharSet.Unicode)>
   Public Function OpenSCManager(lpMachineName As String, lpDatabaseName As String, dwDesiredAccess As Integer) As IntPtr
   End Function

   <DllImport("advapi32.dll", SetLastError:=True, CharSet:=CharSet.Unicode)>
   Public Function OpenService(hSCManager As IntPtr, lpServiceName As String, dwDesiredAccess As Integer) As IntPtr
   End Function

   <DllImport("advapi32.dll", SetLastError:=True)>
   Public Function OpenProcessToken(hProcess As IntPtr, desiredAccess As UInteger, ByRef tokenHandle As IntPtr) As Boolean
   End Function

   <DllImport("advapi32.dll", SetLastError:=True, CharSet:=CharSet.Unicode)>
   Public Function QueryServiceConfig(hService As IntPtr, lpServiceConfig As IntPtr, cbBufSize As Integer, ByRef pcbBytesNeeded As Integer) As Boolean
   End Function

   <DllImport("advapi32.dll", SetLastError:=True)>
   Public Function SetNamedSecurityInfo(
      pObjectName As String,
      objectType As SE_OBJECT_TYPE,
      securityInfo As UInteger,
      owner As IntPtr,
      group As IntPtr,
      dacl As IntPtr,
      sacl As IntPtr) As UInteger
   End Function

End Module
