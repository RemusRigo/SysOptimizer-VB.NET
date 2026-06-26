<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmOptimizer
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
      lvOptimizer = New ListView()
      ColumnHeader1 = New ColumnHeader()
      SuspendLayout()
      ' 
      ' lvOptimizer
      ' 
      lvOptimizer.Columns.AddRange(New ColumnHeader() {ColumnHeader1})
      lvOptimizer.Dock = DockStyle.Fill
      lvOptimizer.Location = New Point(0, 0)
      lvOptimizer.Name = "lvOptimizer"
      lvOptimizer.Size = New Size(800, 450)
      lvOptimizer.TabIndex = 0
      lvOptimizer.UseCompatibleStateImageBehavior = False
      lvOptimizer.View = View.Details
      ' 
      ' frmOptimizer
      ' 
      AutoScaleDimensions = New SizeF(7F, 15F)
      AutoScaleMode = AutoScaleMode.Font
      ClientSize = New Size(800, 450)
      Controls.Add(lvOptimizer)
      Name = "frmOptimizer"
      Text = "Form1"
      ResumeLayout(False)
   End Sub

   Friend WithEvents lvOptimizer As ListView
   Friend WithEvents ColumnHeader1 As ColumnHeader

End Class
