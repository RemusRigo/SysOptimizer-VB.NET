Imports System.DirectoryServices.ActiveDirectory

Public Class frmOptimizer

   Public Sub ProcessOptions(path As String)
      Dim frmChild As Form = Nothing
      scOptimizer.Panel2.Controls.Clear()
      Select Case path
         Case "Repair" : frmChild = New frmRepair
         Case "FileSystem" : frmChild = New frmFileSystem
         Case "Registry" : frmChild = New frmRegistry
         Case "Apps" : frmChild = New frmApps
      End Select

      If frmChild IsNot Nothing Then
         frmChild.TopLevel = False
         frmChild.FormBorderStyle = FormBorderStyle.None
         frmChild.Dock = DockStyle.Fill
         scOptimizer.Panel2.Controls.Add(frmChild)
         frmChild.Show()
      End If
   End Sub

   Private Sub frmOptimizer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      Me.Text = appTitle
   End Sub

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
End Class