<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmApps
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
      lvApps = New ListView()
      ColumnHeader1 = New ColumnHeader()
      ColumnHeader2 = New ColumnHeader()
      btnProcess = New Button()
      SuspendLayout()
      ' 
      ' lvApps
      ' 
      lvApps.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
      lvApps.CheckBoxes = True
      lvApps.Columns.AddRange(New ColumnHeader() {ColumnHeader1, ColumnHeader2})
      lvApps.FullRowSelect = True
      lvApps.Location = New Point(0, 0)
      lvApps.Name = "lvApps"
      lvApps.OwnerDraw = True
      lvApps.Size = New Size(804, 413)
      lvApps.TabIndex = 0
      lvApps.UseCompatibleStateImageBehavior = False
      lvApps.View = View.Details
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
      ' frmApps
      ' 
      AutoScaleDimensions = New SizeF(7F, 15F)
      AutoScaleMode = AutoScaleMode.Font
      ClientSize = New Size(804, 441)
      Controls.Add(btnProcess)
      Controls.Add(lvApps)
      Name = "frmApps"
      StartPosition = FormStartPosition.CenterScreen
      Text = "Apps"
      ResumeLayout(False)
   End Sub

   Friend WithEvents lvApps As ListView
   Friend WithEvents ColumnHeader1 As ColumnHeader
   Friend WithEvents btnProcess As Button
   Friend WithEvents ColumnHeader2 As ColumnHeader

End Class
