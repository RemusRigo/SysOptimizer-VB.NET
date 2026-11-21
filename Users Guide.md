# SysOptimizer: User's Guide



## Downloads & Runtimes

Download the latest release from the [Releases page](https://github.com/RemusRigo/SysOptimizer-VB.NET/releases).

Each release contains one folder per framework and architecture:

|Folder|Target Framework|Architecture|Required Runtime|
|-|-|-|-|
|`net4.8 x64`|.NET Framework 4.8|64-bit|[.NET Framework 4.8](https://dotnet.microsoft.com/download/dotnet-framework/net48) (included in Windows 10/11)|
|`net4.8 x86`|.NET Framework 4.8|32-bit|[.NET Framework 4.8](https://dotnet.microsoft.com/download/dotnet-framework/net48) (included in Windows 10/11)|
|`net8.0 x64`|.NET 8.0|64-bit|[.NET 8.0 Desktop Runtime (x64)](https://dotnet.microsoft.com/download/dotnet/8.0)|
|`net8.0 x86`|.NET 8.0|32-bit|[.NET 8.0 Desktop Runtime (x86)](https://dotnet.microsoft.com/download/dotnet/8.0)|
|`net10.0 x64`|.NET 10.0|64-bit|[.NET 10.0 Desktop Runtime (x64)](https://dotnet.microsoft.com/download/dotnet/10.0)|
|`net10.0 x86`|.NET 10.0|32-bit|[.NET 10.0 Desktop Runtime (x86)](https://dotnet.microsoft.com/download/dotnet/10.0)|

> **Which one do I need?** On Windows 10/11, the **net4.8 x64** build runs without installing anything.
> For the .NET 8.0/10.0 builds, the plain ".NET Runtime" is not enough; install the **Desktop** Runtime.



## Install

SysOptimizer is portable: there is no installer.

1. Download and extract the folder that matches your system, e.g. `net4.8 x64`.
2. Copy the **whole folder** to a location where you have write access, for example `D:\My Apps\SysOptimizer\`.
3. Right-click `SysOptimizer.exe` → **Run as administrator**. Without administrator rights, most options are hidden.

> If Windows blocks the file ("Windows protected your PC"), right-click `SysOptimizer.exe` →
> **Properties** → check **Unblock** → **OK**, then try again.



## Usage

Click a category button (**Repair**, **File System**, **Registry**, **Apps**), check the options you want, then click **Run**.
The progress bar shows how far the actions are. Options marked *admin* are shown only when SysOptimizer runs as administrator.

### Repair

|Option|What it does|
|-|-|
|**Microsoft Configuration Manager (SCCM)** *(admin)*|Restarts the SCCM client service (`ccmexec`)|
|**Windows Icon Cache**|Restarts File Explorer so the icon cache is rebuilt|
|**Windows Photo Viewer**|Restores the classic Windows Photo Viewer as an "Open with" option for images|
|**Windows Search (Indexing service)** *(admin)*|Stops Windows Search, deletes the search index, and starts it again (the index is rebuilt)|
|**Windows Update** *(admin)*|Stops and restarts the Windows Update services (`wuauserv`, `bits`, `cryptsvc`, `msiserver`)|

### File System: Services *(admin)*

Stop a service and set it to disabled, or restore it:
Connected User Experiences And Telemetry, Delivery Optimization, Downloaded Maps Manager, Program Compatibility Assistant Service,
SysMain (Superfetch), Windows Health And Optimized Experiences, Windows Search/Indexing Service, Windows Subsystem for Linux (WSL) service, WSAIFabricSvc.

### Registry

|Group|Options|
|-|-|
|**Content Delivery Manager**|Automatically Install Suggested Apps, Windows Welcome Experience, Get Even More Out of Windows, Get tips, tricks, and suggestions, Suggested Content in Settings app|
|**Control Panel**|Disable StickyKeys shortcut (pressing Shift 5 times)|
|**Notifications**|Suggest ways to get the most out of Windows and finish setting up this device|
|**Start Menu**|Disable Bing Search|

### Apps: Microsoft Edge *(admin)*

Default Browser Setting Enabled, Default Browser Settings Campaign Enabled, Edge Shopping Assistant Enabled,
Hide First Run Experience, New TabPage Content Enabled.

After a Registry or Apps change, sign out and in again (or restart Edge) for it to take effect.

Actions and errors are written to `Logs\<year>\<month>\<day>\SysOptimizer.log`.



## Uninstall

1. Optional: set the options back to their Windows default and click **Run**.
2. Delete the folder you copied in step 2 of *Install*.
