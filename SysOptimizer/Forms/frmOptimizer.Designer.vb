<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOptimizer
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
<<<<<<< HEAD
      scOptimizer = New SplitContainer()
      btnApps = New Button()
      btnReg = New Button()
      btnFS = New Button()
      btnRepair = New Button()
=======
      Dim TreeNode1 As TreeNode = New TreeNode("Repair")
      Dim TreeNode2 As TreeNode = New TreeNode("Optimize")
      scOptimizer = New SplitContainer()
      tvOptions = New TreeView()
>>>>>>> 6f872c4580e8171f07be41ad0bb3d514848b76d8
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
      scOptimizer.Name = "scOptimizer"
      ' 
      ' scOptimizer.Panel1
      ' 
<<<<<<< HEAD
      scOptimizer.Panel1.Controls.Add(btnApps)
      scOptimizer.Panel1.Controls.Add(btnReg)
      scOptimizer.Panel1.Controls.Add(btnFS)
      scOptimizer.Panel1.Controls.Add(btnRepair)
      scOptimizer.Size = New Size(800, 450)
      scOptimizer.SplitterDistance = 126
      scOptimizer.TabIndex = 0
      ' 
      ' btnApps
      ' 
      btnApps.Image = My.Resources.Resources.Apps
      btnApps.ImageAlign = ContentAlignment.MiddleLeft
      btnApps.Location = New Point(3, 108)
      btnApps.Name = "btnApps"
      btnApps.Size = New Size(120, 36)
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
      btnReg.Location = New Point(3, 73)
      btnReg.Name = "btnReg"
      btnReg.Size = New Size(120, 36)
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
      btnFS.Location = New Point(3, 38)
      btnFS.Name = "btnFS"
      btnFS.Size = New Size(120, 36)
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
      btnRepair.Location = New Point(3, 3)
      btnRepair.Name = "btnRepair"
      btnRepair.Size = New Size(120, 36)
      btnRepair.TabIndex = 0
      btnRepair.Text = "&Repair"
      btnRepair.TextAlign = ContentAlignment.MiddleLeft
      btnRepair.TextImageRelation = TextImageRelation.ImageBeforeText
      btnRepair.UseVisualStyleBackColor = True
=======
      scOptimizer.Panel1.Controls.Add(tvOptions)
      scOptimizer.Size = New Size(800, 450)
      scOptimizer.SplitterDistance = 189
      scOptimizer.TabIndex = 0
      ' 
      ' tvOptions
      ' 
      tvOptions.Dock = DockStyle.Fill
      tvOptions.Location = New Point(0, 0)
      tvOptions.Name = "tvOptions"
      TreeNode1.Name = "Node0"
      TreeNode1.Text = "Repair"
      TreeNode2.Name = "Node1"
      TreeNode2.Text = "Optimize"
      tvOptions.Nodes.AddRange(New TreeNode() {TreeNode1, TreeNode2})
      tvOptions.Size = New Size(189, 450)
      tvOptions.TabIndex = 0
>>>>>>> 6f872c4580e8171f07be41ad0bb3d514848b76d8
      ' 
      ' frmOptimizer
      ' 
      AutoScaleDimensions = New SizeF(7F, 15F)
      AutoScaleMode = AutoScaleMode.Font
      ClientSize = New Size(800, 450)
      Controls.Add(scOptimizer)
      Name = "frmOptimizer"
<<<<<<< HEAD
      Text = "Optimizer"
=======
      Text = "frmOptimizer"
>>>>>>> 6f872c4580e8171f07be41ad0bb3d514848b76d8
      scOptimizer.Panel1.ResumeLayout(False)
      CType(scOptimizer, ComponentModel.ISupportInitialize).EndInit()
      scOptimizer.ResumeLayout(False)
      ResumeLayout(False)
   End Sub

   Friend WithEvents scOptimizer As SplitContainer
<<<<<<< HEAD
   Friend WithEvents btnApps As Button
   Friend WithEvents btnReg As Button
   Friend WithEvents btnFS As Button
   Friend WithEvents btnRepair As Button
=======
   Friend WithEvents tvOptions As TreeView
>>>>>>> 6f872c4580e8171f07be41ad0bb3d514848b76d8
End Class
