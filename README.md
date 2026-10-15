# SysOptimizer
SysOptimizer: a Windows utility that repairs and optimizes the system



## Author

* [@remusrigo](https://github.com/RemusRigo)
* [@remusrigo](https://sourceforge.net/u/remusrigo/profile)



## Features

* Clean/Repair:
  * Microsoft Configuration Manager (SCCM)
  * Windows Icon cache
  * Windows Photo Viewer
  * Windows Search (Indexing service)
  * Windows Update

* Stop/Restore services:
  * Connected User Experiences And Telemetry
  * Delivery Optimization
  * Downloaded Maps Manager
  * Program Compatibility Assistant Service
  * SysMain (Superfetch)
  * Windows Health And Optimized Experiences
  * Windows Search/Indexing Service
  * Windows Subsystem for Linux (WSL) service
  * WSAIFabricSvc

* Registry:
  * Content Delivery Manager: suggested apps, tips, welcome experience, suggested content in Settings
  * Control Panel: disable StickyKeys shortcut
  * Notifications: "Suggest ways to get the most out of Windows"
  * Start Menu: disable Bing Search

* Apps:
  * Microsoft Edge policies: default browser prompts, shopping assistant, first run experience, new tab page content

* Each option shows its Windows default; options that need administrator rights are shown only when running as administrator
* Logs actions to a file



## User's Guide

See the [User's Guide](UsersGuide.md) for downloads, runtimes, installation and usage.



## Statistics

![VB.NET](https://img.shields.io/badge/Language-VB.NET-blue)
![API](https://img.shields.io/badge/API-AdvAPI32-lightblue)
![API](https://img.shields.io/badge/API-NTDLL-lightblue)
![Runtime](https://img.shields.io/badge/Runtime-.NET%204.8-lightblue)
![Runtime](https://img.shields.io/badge/Runtime-.NET%208.0-lightblue)
![Runtime](https://img.shields.io/badge/Runtime-.NET%2010.0-lightblue)
![VS](https://img.shields.io/badge/IDE-Visual%20Studio-purple)
<br>
![status](https://img.shields.io/badge/status-in%20progress-orange) 
![GitHub Downloads (all assets, all releases)](https://img.shields.io/github/downloads/RemusRigo/SysOptimizer-VB.NET/total)



## Roadmap

* 2026-10-07: Add: Clean/Repair: Microsoft Configuration Manager (SCCM)
* 2026-08-24: Add: Clean/Repair: Windows Icon cache
* 2026-08-21: Fix: implement CheckBox into ListView
* 2026-08-20: Add: Registry: Disable Bing Search in Start Menu
* 2026-08-20: Add: Split project in 4 categories
* 2026-07-17: Add: Stop Windows Search service
* 2026-07-17: Add: Windows Search
* 2026-07-17: Add: Windows Update
* 2026-07-17: Add: Repair: Windows Update
* 2026-06-25: NOK: implement CheckBox into ListView
* 2026-06-25: Add: implement CheckBox into ListView
* 2026-06-25: Add: implement Logger class
* 2026-06-25: Add: implement OSVersion class
* 2026-06-25: Project started
