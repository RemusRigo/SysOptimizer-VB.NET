'--------------------------------------------------------------------------------------------------
' OSVersion class
'    © 2026 Remus Rigo
'       v1.0 2026-06-25
'--------------------------------------------------------------------------------------------------

Imports System.Runtime.InteropServices
Imports SysOptimizer.API.ntdll

Public NotInheritable Class OSVersion

   Private Shared Function QueryVersion() As RTL_OSVERSIONINFOEX
      Dim v As New RTL_OSVERSIONINFOEX()
      v.dwOSVersionInfoSize = CUInt(Marshal.SizeOf(v))
      RtlGetVersion(v)
      Return v
   End Function

   Private Shared ReadOnly ver As RTL_OSVERSIONINFOEX = QueryVersion()

   Public Shared ReadOnly Property Major As Integer
      Get
         Return CInt(ver.dwMajorVersion)
      End Get
   End Property

   Public Shared ReadOnly Property Minor As Integer
      Get
         Return CInt(ver.dwMinorVersion)
      End Get
   End Property

   Public Shared ReadOnly Property Build As Integer
      Get
         Return CInt(ver.dwBuildNumber)
      End Get
   End Property

   Public Shared ReadOnly Property ServicePack As String
      Get
         Return ver.szCSDVersion
      End Get
   End Property

   '===============================================================================================

   '-----------------------------------------------------------------------------------------------
   ' Windows XP: 5.1
   Public Shared ReadOnly Property IsWindowsXP As Boolean
      Get
         Return Major = 5 AndAlso Minor = 1
      End Get
   End Property

   Public Shared ReadOnly Property IsLowerThanWindowsXP As Boolean
      Get
         Return Major < 5 OrElse (Major = 5 AndAlso Minor < 1)
      End Get
   End Property

   Public Shared ReadOnly Property IsHigherThanWindowsXP As Boolean
      Get
         Return Major > 5 OrElse (Major = 5 AndAlso Minor > 1)
      End Get
   End Property

   '-----------------------------------------------------------------------------------------------
   ' Windows Vista: 6.0
   Public Shared ReadOnly Property IsWindowsVista As Boolean
      Get
         Return Major = 6 AndAlso Minor = 0
      End Get
   End Property

   Public Shared ReadOnly Property IsLowerThanWindowsVista As Boolean
      Get
         Return Major < 6 OrElse (Major = 6 AndAlso Minor < 0)
      End Get
   End Property

   Public Shared ReadOnly Property IsHigherThanWindowsVista As Boolean
      Get
         Return Major > 6 OrElse (Major = 6 AndAlso Minor > 0)
      End Get
   End Property

   '-----------------------------------------------------------------------------------------------
   ' Windows 7: 6.1
   Public Shared ReadOnly Property IsWindows7 As Boolean
      Get
         Return Major = 6 AndAlso Minor = 1
      End Get
   End Property

   Public Shared ReadOnly Property IsLowerThanWindows7 As Boolean
      Get
         Return Major < 6 OrElse (Major = 6 AndAlso Minor < 1)
      End Get
   End Property

   Public Shared ReadOnly Property IsHigherThanWindows7 As Boolean
      Get
         Return Major > 6 OrElse (Major = 6 AndAlso Minor > 1)
      End Get
   End Property

   '-----------------------------------------------------------------------------------------------
   ' Windows 8: 6.2
   Public Shared ReadOnly Property IsWindows8 As Boolean
      Get
         Return Major = 6 AndAlso Minor = 2
      End Get
   End Property

   Public Shared ReadOnly Property IsLowerThanWindows8 As Boolean
      Get
         Return Major < 6 OrElse (Major = 6 AndAlso Minor < 2)
      End Get
   End Property

   Public Shared ReadOnly Property IsHigherThanWindows8 As Boolean
      Get
         Return Major > 6 OrElse (Major = 6 AndAlso Minor > 2)
      End Get
   End Property

   '-----------------------------------------------------------------------------------------------
   ' Windows 8.1: 6.3
   Public Shared ReadOnly Property IsWindows81 As Boolean
      Get
         Return Major = 6 AndAlso Minor = 3
      End Get
   End Property

   Public Shared ReadOnly Property IsLowerThanWindows81 As Boolean
      Get
         Return Major < 6 OrElse (Major = 6 AndAlso Minor < 3)
      End Get
   End Property

   Public Shared ReadOnly Property IsHigherThanWindows81 As Boolean
      Get
         Return Major > 6 OrElse (Major = 6 AndAlso Minor > 3)
      End Get
   End Property

   '-----------------------------------------------------------------------------------------------
   ' Windows 10: 10.0.10240 - 22000
   Public Shared ReadOnly Property IsWindows10 As Boolean
      Get
         Return Major = 10 AndAlso Build >= 10240 AndAlso Build < 22000
      End Get
   End Property
   Public Shared ReadOnly Property IsLowerThanWindows10 As Boolean
      Get
         Return Major < 10 OrElse (Major = 10 AndAlso Build < 10240)
      End Get
   End Property
   Public Shared ReadOnly Property IsHigherThanWindows10 As Boolean
      Get
         Return Major > 10 OrElse (Major = 10 AndAlso Build > 21999)
      End Get
   End Property

   ' Release --------------------------------------------------------------------------------------
   Public Shared ReadOnly Property IsWindows10_1507 As Boolean
      Get
         Return Major = 10 AndAlso Build = 10240
      End Get
   End Property
   Public Shared ReadOnly Property IsWindows10_1511 As Boolean
      Get
         Return Major = 10 AndAlso Build = 10586
      End Get
   End Property

   Public Shared ReadOnly Property IsWindows10_1607 As Boolean
      Get
         Return Major = 10 AndAlso Build = 14393
      End Get
   End Property
   Public Shared ReadOnly Property IsWindows10_1703 As Boolean
      Get
         Return Major = 10 AndAlso Build = 15063
      End Get
   End Property
   Public Shared ReadOnly Property IsWindows10_1709 As Boolean
      Get
         Return Major = 10 AndAlso Build = 16299
      End Get
   End Property
   Public Shared ReadOnly Property IsWindows10_1803 As Boolean
      Get
         Return Major = 10 AndAlso Build = 17134
      End Get
   End Property
   Public Shared ReadOnly Property IsWindows10_1809 As Boolean
      Get
         Return Major = 10 AndAlso Build = 17763
      End Get
   End Property
   Public Shared ReadOnly Property IsWindows10_1903 As Boolean
      Get
         Return Major = 10 AndAlso Build = 18362
      End Get
   End Property
   Public Shared ReadOnly Property IsWindows10_1909 As Boolean
      Get
         Return Major = 10 AndAlso Build = 18363
      End Get
   End Property
   Public Shared ReadOnly Property IsWindows10_2004 As Boolean
      Get
         Return Major = 10 AndAlso Build = 19041
      End Get
   End Property
   Public Shared ReadOnly Property IsWindows10_20H2 As Boolean
      Get
         Return Major = 10 AndAlso Build = 19042
      End Get
   End Property
   Public Shared ReadOnly Property IsWindows10_21H1 As Boolean
      Get
         Return Major = 10 AndAlso Build = 19043
      End Get
   End Property
   Public Shared ReadOnly Property IsWindows10_21H2 As Boolean
      Get
         Return Major = 10 AndAlso Build = 19044
      End Get
   End Property
   Public Shared ReadOnly Property IsWindows10_22H2 As Boolean
      Get
         Return Major = 10 AndAlso Build >= 19045
      End Get
   End Property

   '-----------------------------------------------------------------------------------------------
   ' Windows 11 >= 10.0.22000
   Public Shared ReadOnly Property IsWindows11 As Boolean
      Get
         Return Major = 10 AndAlso Build >= 22000
      End Get
   End Property
   Public Shared ReadOnly Property IsLowerThanWindows11 As Boolean
      Get
         Return Major < 10 OrElse (Major = 10 AndAlso Build < 22000)
      End Get
   End Property
   Public Shared ReadOnly Property IsHigherThanWindows11 As Boolean
      Get
         Return Major > 10 OrElse (Major = 10 AndAlso Build > 22000)
      End Get
   End Property

   ' Release --------------------------------------------------------------------------------------
   Public Shared ReadOnly Property IsWindows11_21H2 As Boolean
      Get
         Return Major = 10 AndAlso Build >= 22000 AndAlso Build < 22621
      End Get
   End Property
   Public Shared ReadOnly Property IsWindows11_22H2 As Boolean
      Get
         Return Major = 10 AndAlso Build >= 22621 AndAlso Build < 22631
      End Get
   End Property
   Public Shared ReadOnly Property IsWindows11_23H2 As Boolean
      Get
         Return Major = 10 AndAlso Build >= 22631 AndAlso Build < 26100
      End Get
   End Property
   Public Shared ReadOnly Property IsWindows11_24H2 As Boolean
      Get
         Return Major = 10 AndAlso Build >= 26100 AndAlso Build < 26200
      End Get
   End Property
   Public Shared ReadOnly Property IsWindows11_25H2 As Boolean
      Get
         Return Major = 10 AndAlso Build >= 26200
      End Get
   End Property

   '===============================================================================================

End Class
