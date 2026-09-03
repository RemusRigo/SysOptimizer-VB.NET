'--------------------------------------------------------------------------------------------------
' ctrlListView: ListView Utilities
'    © 2026 Remus Rigo
'       v1.1.20260824
'--------------------------------------------------------------------------------------------------

Namespace UIControls

   Public Module libListView

      Public Class LV_CheckBoxData
         Public Property HasCheckBox As Boolean
         Public Property CheckState As Boolean
         Public Property Display As String
      End Class

      '-----------------------------------------------------------------------------------------------
      ' Add ListView Group
      Public Sub LV_AddGroup(lv As ListView, ByRef grp As ListViewGroup, name As String)
         grp = New ListViewGroup(name)
         lv.Groups.Add(grp)
      End Sub

      '-----------------------------------------------------------------------------------------------
      ' Add ListView item
      Public Sub LV_AddItem(lv As ListView, name As String, isChecked As Boolean)
         Dim item As New ListViewItem(name)
         item.Checked = isChecked
         lv.Items.Add(item)
      End Sub

      '-----------------------------------------------------------------------------------------------
      ' Add ListView item
      Public Sub LVCB_AddItem(lv As ListView, ByRef grp As ListViewGroup, name As String, isChecked As Boolean, Optional hasCheckBox As Boolean = False, Optional CheckBoxIsChecked As Boolean = False, Optional CheckBoxText As String = "On/Off")
         Dim item As New ListViewItem(name)
         item.SubItems.Add("")
         item.Checked = isChecked
         item.Tag = New LV_CheckBoxData With {
            .HasCheckBox = hasCheckBox,
            .CheckState = CheckBoxIsChecked,
            .Display = CheckBoxText
         }
         item.Group = grp
         lv.Items.Add(item)
      End Sub

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
