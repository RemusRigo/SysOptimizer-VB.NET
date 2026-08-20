<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRegistry
   Inherits System.Windows.Forms.Form

   'Form overrides dispose to clean up the component list.
   <System.Diagnostics.DebuggerNonUserCode()> _
   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
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
   <System.Diagnostics.DebuggerStepThrough()> _
   Private Sub InitializeComponent()
      btnRegistry = New Button()
      lvRegistry = New ListView()
      ColumnHeader1 = New ColumnHeader()
      SuspendLayout()
      ' 
      ' btnRegistry
      ' 
      btnRegistry.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
      btnRegistry.Location = New Point(760, 414)
      btnRegistry.Name = "btnRegistry"
      btnRegistry.Size = New Size(40, 23)
      btnRegistry.TabIndex = 4
      btnRegistry.Text = "&Run"
      btnRegistry.UseVisualStyleBackColor = True
      ' 
      ' lvRegistry
      ' 
      lvRegistry.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
      lvRegistry.CheckBoxes = True
      lvRegistry.Columns.AddRange(New ColumnHeader() {ColumnHeader1})
      lvRegistry.FullRowSelect = True
      lvRegistry.Location = New Point(0, 0)
      lvRegistry.Name = "lvRegistry"
      lvRegistry.Size = New Size(800, 410)
      lvRegistry.TabIndex = 3
      lvRegistry.UseCompatibleStateImageBehavior = False
      lvRegistry.View = View.Details
      ' 
      ' ColumnHeader1
      ' 
      ColumnHeader1.Text = "Action"
      ColumnHeader1.Width = 200
      ' 
      ' frmRegistry
      ' 
      AutoScaleDimensions = New SizeF(7F, 15F)
      AutoScaleMode = AutoScaleMode.Font
      ClientSize = New Size(804, 441)
      Controls.Add(btnRegistry)
      Controls.Add(lvRegistry)
      Name = "frmRegistry"
      Text = "Registry"
      ResumeLayout(False)
   End Sub

   Friend WithEvents btnRegistry As Button
   Friend WithEvents lvRegistry As ListView
   Friend WithEvents ColumnHeader1 As ColumnHeader
End Class
