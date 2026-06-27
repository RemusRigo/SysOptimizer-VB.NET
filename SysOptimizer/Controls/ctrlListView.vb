'--------------------------------------------------------------------------------------------------
' ctrlListView
'    © 2026 Remus Rigo
'       v1.0 2026-06-27
'--------------------------------------------------------------------------------------------------

Imports System.Runtime.InteropServices

Namespace UIControls

   Public Module ctrlListView

      '-----------------------------------------------------------------------------------------------
      ' Resize ListView Columns
      Public Sub ResizeLVColumns(lv As ListView)
         For i = 0 To lv.Columns.Count - 1
            ' Setting column width to -1 in WinForms ListView auto-sizes the column
            lv.Columns(i).Width = -1
         Next
      End Sub


   End Module

End Namespace
