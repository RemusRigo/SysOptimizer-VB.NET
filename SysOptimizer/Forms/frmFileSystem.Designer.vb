<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmFileSystem
   Inherits System.Windows.Forms.Form

   'Form overrides dispose to clean up the component list.
   <System.Diagnostics.DebuggerNonUserCode()>
   Protected Overrides Sub Dispose(disposing As Boolean)
      Try
         If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
         End If
      Finally
         MyBase.Dispose(disposing)
      End Try
   End Sub

   'Required by the Windows Form Designer
   Private components As System.ComponentModel.IContainer

   'NOTE: The following procedure is required by the Windows Form Designer
   'It can be modified using the Windows Form Designer.
   'Do not modify it using the code editor.
   <System.Diagnostics.DebuggerStepThrough()>
   Private Sub InitializeComponent()
      btnFSProcess = New Button()
      lvFileSystem = New ListView()
      ColumnHeader3 = New ColumnHeader()
      SuspendLayout()
      ' 
      ' btnFSProcess
      ' 
      btnFSProcess.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
      btnFSProcess.Location = New Point(755, 416)
      btnFSProcess.Name = "btnFSProcess"
      btnFSProcess.Size = New Size(46, 23)
      btnFSProcess.TabIndex = 2
      btnFSProcess.Text = "Run"
      btnFSProcess.UseVisualStyleBackColor = True
      ' 
      ' lvFileSystem
      ' 
      lvFileSystem.Columns.AddRange(New ColumnHeader() {ColumnHeader3})
      lvFileSystem.Location = New Point(0, 0)
      lvFileSystem.Name = "lvFileSystem"
      lvFileSystem.Size = New Size(804, 413)
      lvFileSystem.TabIndex = 3
      lvFileSystem.UseCompatibleStateImageBehavior = False
      ' 
      ' frmFileSystem
      ' 
      AutoScaleDimensions = New SizeF(7F, 15F)
      AutoScaleMode = AutoScaleMode.Font
      ClientSize = New Size(804, 441)
      Controls.Add(lvFileSystem)
      Controls.Add(btnFSProcess)
      Name = "frmFileSystem"
      StartPosition = FormStartPosition.CenterScreen
      Text = "FileSystem"
      ResumeLayout(False)
   End Sub
   Friend WithEvents btnFSProcess As Button
   Friend WithEvents lvFileSystem As ListView
   Friend WithEvents ColumnHeader3 As ColumnHeader

End Class
