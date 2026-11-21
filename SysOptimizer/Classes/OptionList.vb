'--------------------------------------------------------------------------------------------------
' SysOptimizer: OptionList.vb - shared logic for the option ListViews (frmFileSystem, frmRegistry, frmApps)
'    © 2026 Remus Rigo
'       v1.0.20261121
'
'    One ListView row = one option. The row's LV_CheckBoxData.Apply holds what the option does,
'    so Run doesn't need a Select Case on group/item text.
'       column 0 checkbox (item.Checked)  : process this row
'       column 1 checkbox (CheckState)    : True = restore default, False = optimize
'--------------------------------------------------------------------------------------------------

Imports System.ServiceProcess ' ServiceStartMode
Imports Microsoft.Win32
Imports SysOptimizer.UIControls

Friend Class OptionList

   Private ReadOnly lv As ListView
   Private ReadOnly pb As ctrlProgressBarPercentage
   Private ReadOnly log As Logger
   Private grp As ListViewGroup

   Public Sub New(listView As ListView, progressBar As ctrlProgressBarPercentage, logger As Logger)
      lv = listView
      pb = progressBar
      log = logger
   End Sub

   '-----------------------------------------------------------------------------------------------
   ' Build: clears the list, lets the form add groups/options
   Public Sub Build(addItems As Action)
      grp = Nothing
      lv.BeginUpdate()
      Try
         lv.Items.Clear()
         lv.Groups.Clear()
         addItems()
      Finally
         lv.EndUpdate()
      End Try
   End Sub

   Public Sub AddGroup(name As String)
      LV_AddGroup(lv, grp, name)
   End Sub

   '-----------------------------------------------------------------------------------------------
   ' AddOption: any option; apply gets CheckState (True = restore default, False = optimize)
   Public Function AddOption(name As String, isChecked As Boolean, apply As Action(Of Boolean),
                             Optional checkBoxIsChecked As Boolean = False) As ListViewItem
      Dim item = LVCB_AddItem(lv, grp, name, isChecked, True, checkBoxIsChecked)
      DirectCast(item.Tag, LV_CheckBoxData).Apply = apply
      Return item
   End Function

   ' Service: restore = start + defaultMode, optimize = stop + optimizedMode
   Public Function AddService(name As String, isChecked As Boolean, serviceName As String,
                              Optional optimizedMode As ServiceStartMode = ServiceStartMode.Disabled,
                              Optional defaultMode As ServiceStartMode = ServiceStartMode.Automatic) As ListViewItem
      Return AddOption(name, isChecked,
         Sub(restore)
            If restore Then
               StartService(serviceName)
               SetServiceStartUpType(serviceName, defaultMode)
            Else
               StopService(serviceName)
               SetServiceStartUpType(serviceName, optimizedMode)
            End If
         End Sub)
   End Function

   ' One DWORD value: restore = defaultValue, optimize = optimizedValue
   Public Function AddRegDWord(name As String, isChecked As Boolean, root As RegistryKey, keyPath As String,
                               valueName As String, Optional defaultValue As Integer = 1,
                               Optional optimizedValue As Integer = 0) As ListViewItem
      Return AddOption(name, isChecked,
         Sub(restore) RegWriteDWord(root, keyPath, valueName, If(restore, defaultValue, optimizedValue)))
   End Function

   '-----------------------------------------------------------------------------------------------
   ' Run: applies the checked rows (in ListView order) and moves the progress bar
   Public Sub Run()
      Dim work As New List(Of ListViewItem)()
      For Each item As ListViewItem In lv.Items
         Dim data = TryCast(item.Tag, LV_CheckBoxData)
         If item.Checked AndAlso data?.Apply IsNot Nothing Then work.Add(item)
      Next

      pb.Value = 0
      pb.Maximum = Math.Max(work.Count, 1)
      For Each item In work
         Dim data = DirectCast(item.Tag, LV_CheckBoxData)
         Try
            data.Apply.Invoke(data.CheckState)
         Catch ex As Exception
            log.Msg.Error($"{ex.Message} : {item.Text}")
         End Try
         pb.Value += 1
      Next
   End Sub

End Class
