Imports System.DirectoryServices.ActiveDirectory

Public Class frmOptimizer

   Public Sub ProcessOptions(path As String)
      Dim frmChild As Form = Nothing
      scOptimizer.Panel2.Controls.Clear()
      Select Case path
<<<<<<< HEAD
         Case "Repair" : frmChild = New frmRepair
         Case "FileSystem" : frmChild = New frmFileSystem
         Case "Registry" : frmChild = New frmRegistry
         Case "Apps" : frmChild = New frmApps
=======
         Case "Repair"
            frmChild = New frmRepair

         Case "Optimize"
            frmChild = New frmActions

         Case Else
>>>>>>> 6f872c4580e8171f07be41ad0bb3d514848b76d8
      End Select

      If frmChild IsNot Nothing Then
         frmChild.TopLevel = False
         frmChild.FormBorderStyle = FormBorderStyle.None
         frmChild.Dock = DockStyle.Fill
         scOptimizer.Panel2.Controls.Add(frmChild)
         frmChild.Show()
      End If
<<<<<<< HEAD
=======

   End Sub

   Private Sub tvOptions_DoubleClick(sender As Object, e As EventArgs) Handles tvOptions.DoubleClick
      ProcessOptions(tvOptions.SelectedNode.FullPath)
   End Sub

   Private Sub tvOptions_NodeMouseDoubleClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles tvOptions.NodeMouseDoubleClick
      e.Node.Toggle()
>>>>>>> 6f872c4580e8171f07be41ad0bb3d514848b76d8
   End Sub

   Private Sub frmOptimizer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      Me.Text = appTitle
   End Sub
<<<<<<< HEAD

   Private Sub btnRepair_Click(sender As Object, e As EventArgs) Handles btnRepair.Click
      ProcessOptions("Repair")
   End Sub

   Private Sub btnFS_Click(sender As Object, e As EventArgs) Handles btnFS.Click
      ProcessOptions("FileSystem")
   End Sub

   Private Sub btnReg_Click(sender As Object, e As EventArgs) Handles btnReg.Click
      ProcessOptions("Registry")
   End Sub

   Private Sub btnApps_Click(sender As Object, e As EventArgs) Handles btnApps.Click
      ProcessOptions("Apps")
   End Sub
=======
>>>>>>> 6f872c4580e8171f07be41ad0bb3d514848b76d8
End Class