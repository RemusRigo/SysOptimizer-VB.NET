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
      ColumnHeader2 = New ColumnHeader()
      btnProcess = New Button()
      SuspendLayout()
      ' 
      ' lvOptimizer
      ' 
      lvOptimizer.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
      lvOptimizer.CheckBoxes = True
      lvOptimizer.Columns.AddRange(New ColumnHeader() {ColumnHeader1, ColumnHeader2})
      lvOptimizer.FullRowSelect = True
      lvOptimizer.Location = New Point(0, 0)
      lvOptimizer.Name = "lvOptimizer"
      lvOptimizer.OwnerDraw = True
      lvOptimizer.Size = New Size(804, 413)
      lvOptimizer.TabIndex = 0
      lvOptimizer.UseCompatibleStateImageBehavior = False
      lvOptimizer.View = View.Details
      ' 
      ' ColumnHeader1
      ' 
      ColumnHeader1.Text = "Action"
      ColumnHeader1.Width = 200
      ' 
      ' ColumnHeader2
      ' 
      ColumnHeader2.Text = "Option"
      ColumnHeader2.Width = 150
      ' 
      ' btnProcess
      ' 
      btnProcess.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
      btnProcess.Location = New Point(755, 416)
      btnProcess.Name = "btnProcess"
      btnProcess.Size = New Size(46, 23)
      btnProcess.TabIndex = 2
      btnProcess.Text = "Run"
      btnProcess.UseVisualStyleBackColor = True
      ' 
      ' frmOptimizer
      ' 
      AutoScaleDimensions = New SizeF(7F, 15F)
      AutoScaleMode = AutoScaleMode.Font
      ClientSize = New Size(804, 441)
      Controls.Add(btnProcess)
      Controls.Add(lvOptimizer)
      Name = "frmOptimizer"
      StartPosition = FormStartPosition.CenterScreen
      Text = "SysOptimizer"
      ResumeLayout(False)
   End Sub

   Friend WithEvents lvOptimizer As ListView
   Friend WithEvents ColumnHeader1 As ColumnHeader
   Friend WithEvents btnProcess As Button
   Friend WithEvents ColumnHeader2 As ColumnHeader

End Class
