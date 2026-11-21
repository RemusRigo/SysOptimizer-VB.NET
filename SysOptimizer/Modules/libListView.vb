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

         ' What the row does when Run is pressed. Gets CheckState: True = restore default, False = optimize
         Public Property Apply As Action(Of Boolean)

         ' The values the row was added with (used by the "Defaults" context menu item)
         Public Property DefaultChecked As Boolean
         Public Property DefaultCheckState As Boolean
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
      Public Function LVCB_AddItem(lv As ListView, ByRef grp As ListViewGroup, name As String, isChecked As Boolean, Optional hasCheckBox As Boolean = False, Optional CheckBoxIsChecked As Boolean = False, Optional CheckBoxText As String = "On/Off") As ListViewItem
         Dim item As New ListViewItem(name)
         item.SubItems.Add("")
         item.Checked = isChecked
         item.Tag = New LV_CheckBoxData With {
            .HasCheckBox = hasCheckBox,
            .CheckState = CheckBoxIsChecked,
            .Display = CheckBoxText,
            .DefaultChecked = isChecked,
            .DefaultCheckState = CheckBoxIsChecked
         }
         item.Group = grp
         lv.Items.Add(item)
         Return item
      End Function

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
