'--------------------------------------------------------------------------------------------------
' NTDLL.dll
'    © 2026 Remus Rigo
'       v1.0 2026-06-26
'--------------------------------------------------------------------------------------------------

Imports System.Runtime.InteropServices

Namespace API
   Module ntdll

      <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Unicode)>
      Friend Structure RTL_OSVERSIONINFOEX
         Public dwOSVersionInfoSize As UInteger
         Public dwMajorVersion As UInteger
         Public dwMinorVersion As UInteger
         Public dwBuildNumber As UInteger
         Public dwPlatformId As UInteger
         <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=128)>
         Public szCSDVersion As String
         Public wServicePackMajor As UShort
         Public wServicePackMinor As UShort
         Public wSuiteMask As UShort
         Public wProductType As Byte
         Public wReserved As Byte
      End Structure

      <DllImport("ntdll.dll", CharSet:=CharSet.Unicode)>
      Friend Function RtlGetVersion(ByRef versionInfo As RTL_OSVERSIONINFOEX) As Integer
      End Function

   End Module
End Namespace
