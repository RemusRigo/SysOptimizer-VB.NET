Imports System.IO
Imports System.Windows.Forms.Design.AxImporter
Imports Microsoft.VisualBasic.Logging
Imports Microsoft.Win32
Imports SysOptimizer.UIControls

Public Class frmApps
   Private pbActions As rrProgressBar

   Dim log As New Logger(appName)
   Dim grp As ListViewGroup = Nothing

   Private Class LV_CheckBoxData
      Public Property HasCheckBox As Boolean
      Public Property CheckState As Boolean
      Public Property Display As String
   End Class
   '-----------------------------------------------------------------------------------------------
   ' Add ListView Group
   Private Sub LV_AddGroup(name As String)
      grp = New ListViewGroup(name)
      lvApps.Groups.Add(grp)
   End Sub

   '-----------------------------------------------------------------------------------------------
   ' Add ListView item
   Private Sub LV_AddItem(name As String, isChecked As Boolean, Optional hasCheckBox As Boolean = False, Optional CheckBoxIsChecked As Boolean = False, Optional CheckBoxText As String = "On/Off")
      Dim item As New ListViewItem(name)
      item.SubItems.Add("")
      item.Checked = isChecked
      item.Tag = New LV_CheckBoxData With {
         .HasCheckBox = hasCheckBox,
         .CheckState = CheckBoxIsChecked,
         .Display = CheckBoxText
      }
      item.Group = grp
      lvApps.Items.Add(item)
   End Sub

   '-----------------------------------------------------------------------------------------------
   ' Build Options
   Public Sub BuildOptions()
      lvApps.BeginUpdate()
      lvApps.Items.Clear()
      lvApps.Groups.Clear()

      ' If IsAppElevated() Then
      LV_AddGroup("App 1")
      LV_AddItem("Item 1", True, True, True)

      'ResizeLVColumns(lvOptimizer)
      lvApps.EndUpdate()
   End Sub

   '-----------------------------------------------------------------------------------------------
   ' Process Actions
   Private Async Sub ProcessActions(itemsToProcess As List(Of ListViewItem))
      For Each item As ListViewItem In itemsToProcess
         Dim grp = item.Group
         If grp Is Nothing Then Continue For

         Select Case grp.Header

            Case "App 1"
               Select Case item.Text

                  '--------------------------------------------------------------------------------
                  Case "Item 1"
                     Dim data = DirectCast(item.Tag, LV_CheckBoxData)
                     If data.CheckState Then
                        MessageBox.Show("checked")
                     Else
                        MessageBox.Show("unchecked")
                     End If
                     pbActions.Value += 1

               End Select
         End Select
      Next
   End Sub

   Private Sub frmApps_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      lvApps.View = View.Details
      lvApps.OwnerDraw = True
      lvApps.FullRowSelect = False ' if True then the checkbox will not work ok (item checkbox can uncheck or check randomly)

      pbActions = New rrProgressBar()
      pbActions.Dock = DockStyle.None
      pbActions.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
      pbActions.Location = New Point(3, 417)
      pbActions.Size = New Size(745, 20)
      Me.Controls.Add(pbActions)

      BuildOptions()

   End Sub

   Private Async Sub btnProcess_Click(sender As Object, e As EventArgs) Handles btnProcess.Click
      Dim itemsToProcess As New List(Of ListViewItem)()
      For Each item As ListViewItem In lvApps.Items
         If item.Checked AndAlso item.Group IsNot Nothing Then
            itemsToProcess.Add(item)
         End If
      Next

      pbActions.Maximum = itemsToProcess.Count

      Try
         Await Task.Run(Sub() ProcessActions(itemsToProcess))
      Finally

      End Try
   End Sub

   Private Sub lvApps_DrawColumnHeader(sender As Object, e As DrawListViewColumnHeaderEventArgs) Handles lvApps.DrawColumnHeader
      e.DrawDefault = True
   End Sub

   Private Sub lvApps_DrawItem(sender As Object, e As DrawListViewItemEventArgs) Handles lvApps.DrawItem
      'e.DrawDefault = True
      e.DrawBackground()
   End Sub

   Private Sub lvApps_DrawSubItem(sender As Object, e As DrawListViewSubItemEventArgs) Handles lvApps.DrawSubItem
      Dim data = TryCast(e.Item.Tag, LV_CheckBoxData)

      ' COLUMN 0 → built-in checkbox
      If e.ColumnIndex = 0 Then
         e.DrawBackground()

         Dim cbSize As Integer = 14
         Dim x As Integer = e.Bounds.X + 4
         Dim y As Integer = e.Bounds.Y + (e.Bounds.Height - cbSize) \ 2

         Dim state As ButtonState = If(e.Item.Checked, ButtonState.Checked, ButtonState.Normal)

         ControlPaint.DrawCheckBox(e.Graphics, New Rectangle(x, y, cbSize, cbSize), state)

         ' Draw the item text
         Dim textX As Integer = x + cbSize + 6
         TextRenderer.DrawText(e.Graphics, e.SubItem.Text, lvApps.Font, New Point(textX, e.Bounds.Y + 2), lvApps.ForeColor)

         Exit Sub
      End If

      ' COLUMN 1 → your custom checkbox
      If e.ColumnIndex = 1 AndAlso data IsNot Nothing AndAlso data.HasCheckBox Then
         e.DrawBackground()

         Dim cbSize As Integer = 14
         Dim x As Integer = e.Bounds.X + 4
         Dim y As Integer = e.Bounds.Y + (e.Bounds.Height - cbSize) \ 2

         Dim state As ButtonState = If(data.CheckState, ButtonState.Checked, ButtonState.Normal)

         ControlPaint.DrawCheckBox(e.Graphics, New Rectangle(x, y, cbSize, cbSize), state)

         Dim txt As String = If(data.CheckState, "Enabled", "Disabled")
         TextRenderer.DrawText(e.Graphics, txt, lvApps.Font, New Point(x + cbSize + 6, e.Bounds.Y + 2), lvApps.ForeColor)

         Exit Sub
      End If

      ' DEFAULT TEXT FOR OTHER COLUMNS
      e.DrawBackground()
      TextRenderer.DrawText(e.Graphics, e.SubItem.Text, lvApps.Font, e.Bounds, lvApps.ForeColor)
   End Sub


   Private Sub lvApps_MouseDown(sender As Object, e As MouseEventArgs) Handles lvApps.MouseDown
      Dim ht As ListViewHitTestInfo = lvApps.HitTest(e.Location)
      'MessageBox.Show(ht.Location)

      ' Ensure we hit an item and a subitem
      If ht.Item Is Nothing OrElse ht.SubItem Is Nothing Then Exit Sub

      ' Check if it is the second column (Index 1)
      If ht.Item.SubItems.IndexOf(ht.SubItem) <> 1 Then Exit Sub

      Dim data = TryCast(ht.Item.Tag, LV_CheckBoxData)
      If data Is Nothing OrElse Not data.HasCheckBox Then Exit Sub

      ' Define the hit area (must match the drawing logic in DrawSubItem)
      Dim cbSize As Integer = 14
      Dim x As Integer = ht.SubItem.Bounds.X + 4
      Dim y As Integer = ht.SubItem.Bounds.Y + (ht.SubItem.Bounds.Height - cbSize) \ 2
      Dim checkBoxRect As New Rectangle(x, y, cbSize, cbSize)

      ' Only toggle if the click is specifically inside the checkbox area
      If checkBoxRect.Contains(e.Location) Then
         data.CheckState = Not data.CheckState

         ' Force the ListView to repaint the specific subitem
         lvApps.Invalidate(ht.SubItem.Bounds)
      End If
   End Sub

End Class
