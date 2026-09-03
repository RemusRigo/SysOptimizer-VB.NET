'--------------------------------------------------------------------------------------------------
' ctrlListViewCheckBox: ListView with CheckBox on items
'    © 2026 Remus Rigo
'       v1.0.20260825
'--------------------------------------------------------------------------------------------------
'
Imports Microsoft.VisualBasic.FileIO
Imports SysOptimizer.UIControls.libListView

''' <summary>
''' Attach to any OwnerDraw ListView to get a native checkbox in column 0 and a custom data-driven checkbox in column 1 (see LV_CheckBoxData).
''' Usage: Dim lvcbListView As New ctrlListViewCheckBox(lvListView)
''' </summary>

Namespace UIControls
   Public Class clsListViewCheckBox

      Private ReadOnly lv As ListView
      Private Const CB_SIZE As Integer = 14

      Public Sub New(listView As ListView)
         lv = listView
         lv.View = View.Details
         lv.OwnerDraw = True
         lv.FullRowSelect = False ' if True then the checkbox will not work ok (item checkbox can uncheck or check randomly)
         lv.CheckBoxes = False   ' draw both checkboxes on OwnerDraw

         Dim dbProp = GetType(Control).GetProperty("DoubleBuffered", Reflection.BindingFlags.Instance Or Reflection.BindingFlags.NonPublic)
         dbProp?.SetValue(lv, True, Nothing)

         AddHandler lv.DrawColumnHeader, AddressOf DrawColumnHeader
         AddHandler lv.DrawItem, AddressOf DrawItem
         AddHandler lv.DrawSubItem, AddressOf DrawSubItem
         AddHandler lv.MouseDown, AddressOf MouseDown
      End Sub

      Private Sub DrawColumnHeader(sender As Object, e As DrawListViewColumnHeaderEventArgs)
         e.DrawDefault = True
      End Sub

      Private Sub DrawItem(sender As Object, e As DrawListViewItemEventArgs)
         e.DrawBackground()
      End Sub

      Private Sub DrawSubItem(sender As Object, e As DrawListViewSubItemEventArgs)
         Dim data = TryCast(e.Item.Tag, LV_CheckBoxData)

         ' COLUMN 0 → item.Checked
         If e.ColumnIndex = 0 Then
            e.DrawBackground()

            Dim x As Integer = e.Bounds.X + 4
            Dim y As Integer = e.Bounds.Y + (e.Bounds.Height - CB_SIZE) \ 2
            Dim state As ButtonState = If(e.Item.Checked, ButtonState.Checked, ButtonState.Normal)

            ControlPaint.DrawCheckBox(e.Graphics, New Rectangle(x, y, CB_SIZE, CB_SIZE), state)

            Dim textX As Integer = x + CB_SIZE + 6
            TextRenderer.DrawText(e.Graphics, e.SubItem.Text, lv.Font, New Point(textX, e.Bounds.Y + 2), lv.ForeColor)
            Exit Sub
         End If

         ' COLUMN 1 → data.CheckState
         If e.ColumnIndex = 1 AndAlso data IsNot Nothing AndAlso data.HasCheckBox Then
            e.DrawBackground()

            Dim x As Integer = e.Bounds.X + 4
            Dim y As Integer = e.Bounds.Y + (e.Bounds.Height - CB_SIZE) \ 2
            Dim state As ButtonState = If(data.CheckState, ButtonState.Checked, ButtonState.Normal)

            ControlPaint.DrawCheckBox(e.Graphics, New Rectangle(x, y, CB_SIZE, CB_SIZE), state)

            ' if no text is specified, then set the caption to checkbox's CheckState
            Dim txt As String = If(data.Display <> "", data.Display, If(data.CheckState, "Enabled", "Disabled"))
            TextRenderer.DrawText(e.Graphics, txt, lv.Font, New Point(x + CB_SIZE + 6, e.Bounds.Y + 2), lv.ForeColor)
            Exit Sub
         End If

         ' DEFAULT
         e.DrawBackground()
         TextRenderer.DrawText(e.Graphics, e.SubItem.Text, lv.Font, e.Bounds, lv.ForeColor)
      End Sub

      Private Sub MouseDown(sender As Object, e As MouseEventArgs)
         Dim ht As ListViewHitTestInfo = lv.HitTest(e.Location)
         If ht.Item Is Nothing OrElse ht.SubItem Is Nothing Then Exit Sub

         Dim colIndex As Integer = ht.Item.SubItems.IndexOf(ht.SubItem)
         Dim x As Integer = ht.SubItem.Bounds.X + 4
         Dim y As Integer = ht.SubItem.Bounds.Y + (ht.SubItem.Bounds.Height - CB_SIZE) \ 2
         Dim checkBoxRect As New Rectangle(x, y, CB_SIZE, CB_SIZE)

         If Not checkBoxRect.Contains(e.Location) Then Exit Sub

         Select Case colIndex

            Case 0
               ht.Item.Checked = Not ht.Item.Checked
               lv.Invalidate(ht.SubItem.Bounds)

            Case 1
               Dim data = TryCast(ht.Item.Tag, LV_CheckBoxData)
               If data Is Nothing OrElse Not data.HasCheckBox Then Exit Sub

               data.CheckState = Not data.CheckState
               lv.Invalidate(ht.SubItem.Bounds)

         End Select
      End Sub

      Public Sub AttachContextMenu()
         Dim menu As New ContextMenuStrip()

         menu.Items.Add("Check all", Nothing, Sub() CheckAll(True))
         menu.Items.Add("Uncheck all", Nothing, Sub() CheckAll(False))
         menu.Items.Add(New ToolStripSeparator())
         menu.Items.Add("Check all options", Nothing, Sub() CheckAllItems(True))
         menu.Items.Add("Uncheck all options", Nothing, Sub() CheckAllItems(False))
         menu.Items.Add(New ToolStripSeparator())
         menu.Items.Add("Check all defaults", Nothing, Sub() CheckAllData(True))
         menu.Items.Add("Uncheck all defaults", Nothing, Sub() CheckAllData(False))

         lv.ContextMenuStrip = menu
      End Sub

      Public Sub CheckAllItems(checked As Boolean)
         For Each item As ListViewItem In lv.Items
            item.Checked = checked
         Next
         lv.Invalidate()
      End Sub

      Public Sub CheckAllData(checked As Boolean)
         For Each item As ListViewItem In lv.Items
            Dim data = TryCast(item.Tag, LV_CheckBoxData)
            If data IsNot Nothing AndAlso data.HasCheckBox Then
               data.CheckState = checked
            End If
         Next
         lv.Invalidate()
      End Sub

      Public Sub CheckAll(checked As Boolean)
         For Each item As ListViewItem In lv.Items
            item.Checked = checked
            Dim data = TryCast(item.Tag, LV_CheckBoxData)
            If data IsNot Nothing AndAlso data.HasCheckBox Then
               data.CheckState = checked
            End If
         Next
         lv.Invalidate()
      End Sub

      ''' <summary>Detach handlers — call from the form's FormClosed if you want to be tidy.</summary>
      Public Sub Detach()
         RemoveHandler lv.DrawColumnHeader, AddressOf DrawColumnHeader
         RemoveHandler lv.DrawItem, AddressOf DrawItem
         RemoveHandler lv.DrawSubItem, AddressOf DrawSubItem
         RemoveHandler lv.MouseDown, AddressOf MouseDown
      End Sub

   End Class

End Namespace