<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRepair
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
      btnRepairRun = New Button()
      lvRepair = New ListView()
      ColumnHeader1 = New ColumnHeader()
      SuspendLayout()
      ' 
      ' btnRepairRun
      ' 
      btnRepairRun.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
      btnRepairRun.Location = New Point(760, 414)
      btnRepairRun.Name = "btnRepairRun"
      btnRepairRun.Size = New Size(40, 23)
      btnRepairRun.TabIndex = 4
      btnRepairRun.Text = "&Run"
      btnRepairRun.UseVisualStyleBackColor = True
      ' 
      ' lvRepair
      ' 
      lvRepair.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
      lvRepair.CheckBoxes = True
      lvRepair.Columns.AddRange(New ColumnHeader() {ColumnHeader1})
      lvRepair.FullRowSelect = True
      lvRepair.Location = New Point(0, 0)
      lvRepair.Name = "lvRepair"
      lvRepair.Size = New Size(800, 410)
      lvRepair.TabIndex = 3
      lvRepair.UseCompatibleStateImageBehavior = False
      lvRepair.View = View.Details
      ' 
      ' ColumnHeader1
      ' 
      ColumnHeader1.Text = "Action"
      ColumnHeader1.Width = 200
      ' 
      ' frmRepair
      ' 
      AutoScaleDimensions = New SizeF(7F, 15F)
      AutoScaleMode = AutoScaleMode.Font
      ClientSize = New Size(804, 441)
      Controls.Add(btnRepairRun)
      Controls.Add(lvRepair)
      Name = "frmRepair"
      Text = "Repair"
      ResumeLayout(False)
   End Sub

   Friend WithEvents btnRepairRun As Button
   Friend WithEvents lvRepair As ListView
   Friend WithEvents ColumnHeader1 As ColumnHeader
End Class
