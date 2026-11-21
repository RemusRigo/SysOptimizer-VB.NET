<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmOptimizer
   Inherits System.Windows.Forms.Form

   'Form overrides dispose to clean up the component list.
   <System.Diagnostics.DebuggerNonUserCode()>
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
   <System.Diagnostics.DebuggerStepThrough()>
   Private Sub InitializeComponent()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOptimizer))
      scOptimizer = New SplitContainer()
      btnApps = New Button()
      btnReg = New Button()
      btnFS = New Button()
      btnRepair = New Button()
      CType(scOptimizer, ComponentModel.ISupportInitialize).BeginInit()
      scOptimizer.Panel1.SuspendLayout()
      scOptimizer.SuspendLayout()
      SuspendLayout()
      ' 
      ' scOptimizer
      ' 
      scOptimizer.Dock = DockStyle.Fill
      scOptimizer.FixedPanel = FixedPanel.Panel1
      scOptimizer.Location = New Point(0, 0)
      scOptimizer.Margin = New Padding(4, 3, 4, 3)
      scOptimizer.Name = "scOptimizer"
      ' 
      ' scOptimizer.Panel1
      ' 
      scOptimizer.Panel1.Controls.Add(btnApps)
      scOptimizer.Panel1.Controls.Add(btnReg)
      scOptimizer.Panel1.Controls.Add(btnFS)
      scOptimizer.Panel1.Controls.Add(btnRepair)
      scOptimizer.Size = New Size(800, 450)
      scOptimizer.SplitterDistance = 120
      scOptimizer.TabIndex = 0
      ' 
      ' btnApps
      ' 
      btnApps.Image = My.Resources.Resources.Apps
      btnApps.ImageAlign = ContentAlignment.MiddleLeft
      btnApps.Location = New Point(3, 43)
      btnApps.Margin = New Padding(4, 3, 4, 3)
      btnApps.Name = "btnApps"
      btnApps.Size = New Size(110, 40)
      btnApps.TabIndex = 3
      btnApps.Text = "&Apps"
      btnApps.TextAlign = ContentAlignment.MiddleLeft
      btnApps.TextImageRelation = TextImageRelation.ImageBeforeText
      btnApps.UseVisualStyleBackColor = True
      ' 
      ' btnReg
      ' 
      btnReg.Image = My.Resources.Resources.Registry
      btnReg.ImageAlign = ContentAlignment.MiddleLeft
      btnReg.Location = New Point(3, 83)
      btnReg.Margin = New Padding(4, 3, 4, 3)
      btnReg.Name = "btnReg"
      btnReg.Size = New Size(110, 40)
      btnReg.TabIndex = 2
      btnReg.Text = "&Registry"
      btnReg.TextAlign = ContentAlignment.MiddleLeft
      btnReg.TextImageRelation = TextImageRelation.ImageBeforeText
      btnReg.UseVisualStyleBackColor = True
      ' 
      ' btnFS
      ' 
      btnFS.Image = My.Resources.Resources.FS
      btnFS.ImageAlign = ContentAlignment.MiddleLeft
      btnFS.Location = New Point(3, 3)
      btnFS.Margin = New Padding(4, 3, 4, 3)
      btnFS.Name = "btnFS"
      btnFS.Size = New Size(110, 40)
      btnFS.TabIndex = 1
      btnFS.Text = "&File System"
      btnFS.TextAlign = ContentAlignment.MiddleLeft
      btnFS.TextImageRelation = TextImageRelation.ImageBeforeText
      btnFS.UseVisualStyleBackColor = True
      ' 
      ' btnRepair
      ' 
      btnRepair.Image = My.Resources.Resources.Repair
      btnRepair.ImageAlign = ContentAlignment.MiddleLeft
      btnRepair.Location = New Point(3, 123)
      btnRepair.Margin = New Padding(4, 3, 4, 3)
      btnRepair.Name = "btnRepair"
      btnRepair.Size = New Size(110, 40)
      btnRepair.TabIndex = 0
      btnRepair.Text = "&Repair"
      btnRepair.TextAlign = ContentAlignment.MiddleLeft
      btnRepair.TextImageRelation = TextImageRelation.ImageBeforeText
      btnRepair.UseVisualStyleBackColor = True
      ' 
      ' frmOptimizer
      ' 
      AutoScaleDimensions = New SizeF(7F, 15F)
      AutoScaleMode = AutoScaleMode.Font
      ClientSize = New Size(800, 450)
      Controls.Add(scOptimizer)
      Icon = CType(resources.GetObject("$this.Icon"), Icon)
      Margin = New Padding(4, 3, 4, 3)
      Name = "frmOptimizer"
      StartPosition = FormStartPosition.CenterScreen
      Text = "frmOptimizer"
      scOptimizer.Panel1.ResumeLayout(False)
      CType(scOptimizer, ComponentModel.ISupportInitialize).EndInit()
      scOptimizer.ResumeLayout(False)
      ResumeLayout(False)

   End Sub

   Friend WithEvents scOptimizer As SplitContainer
   Friend WithEvents btnApps As Button
   Friend WithEvents btnReg As Button
   Friend WithEvents btnFS As Button
   Friend WithEvents btnRepair As Button
End Class
