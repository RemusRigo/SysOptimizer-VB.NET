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
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Repair")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Optimize")
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOptimizer))
        Me.scOptimizer = New System.Windows.Forms.SplitContainer()
        Me.btnApps = New System.Windows.Forms.Button()
        Me.btnReg = New System.Windows.Forms.Button()
        Me.btnFS = New System.Windows.Forms.Button()
        Me.btnRepair = New System.Windows.Forms.Button()
        Me.tvOptions = New System.Windows.Forms.TreeView()
        CType(Me.scOptimizer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.scOptimizer.Panel1.SuspendLayout()
        Me.scOptimizer.SuspendLayout()
        Me.SuspendLayout()
        '
        'scOptimizer
        '
        Me.scOptimizer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.scOptimizer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.scOptimizer.Location = New System.Drawing.Point(0, 0)
        Me.scOptimizer.Name = "scOptimizer"
        '
        'scOptimizer.Panel1
        '
        Me.scOptimizer.Panel1.Controls.Add(Me.btnApps)
        Me.scOptimizer.Panel1.Controls.Add(Me.btnReg)
        Me.scOptimizer.Panel1.Controls.Add(Me.btnFS)
        Me.scOptimizer.Panel1.Controls.Add(Me.btnRepair)
        Me.scOptimizer.Panel1.Controls.Add(Me.tvOptions)
        Me.scOptimizer.Size = New System.Drawing.Size(686, 390)
        Me.scOptimizer.SplitterDistance = 128
        Me.scOptimizer.SplitterWidth = 3
        Me.scOptimizer.TabIndex = 0
        '
        'btnApps
        '
        Me.btnApps.Image = Global.SysOptimizer.My.Resources.Resources.Apps
        Me.btnApps.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnApps.Location = New System.Drawing.Point(3, 94)
        Me.btnApps.Name = "btnApps"
        Me.btnApps.Size = New System.Drawing.Size(103, 31)
        Me.btnApps.TabIndex = 3
        Me.btnApps.Text = "&Apps"
        Me.btnApps.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnApps.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnApps.UseVisualStyleBackColor = True
        '
        'btnReg
        '
        Me.btnReg.Image = Global.SysOptimizer.My.Resources.Resources.Registry
        Me.btnReg.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReg.Location = New System.Drawing.Point(3, 63)
        Me.btnReg.Name = "btnReg"
        Me.btnReg.Size = New System.Drawing.Size(103, 31)
        Me.btnReg.TabIndex = 2
        Me.btnReg.Text = "&Registry"
        Me.btnReg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReg.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnReg.UseVisualStyleBackColor = True
        '
        'btnFS
        '
        Me.btnFS.Image = Global.SysOptimizer.My.Resources.Resources.FS
        Me.btnFS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnFS.Location = New System.Drawing.Point(3, 33)
        Me.btnFS.Name = "btnFS"
        Me.btnFS.Size = New System.Drawing.Size(103, 31)
        Me.btnFS.TabIndex = 1
        Me.btnFS.Text = "&File System"
        Me.btnFS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnFS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnFS.UseVisualStyleBackColor = True
        '
        'btnRepair
        '
        Me.btnRepair.Image = Global.SysOptimizer.My.Resources.Resources.Repair
        Me.btnRepair.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRepair.Location = New System.Drawing.Point(3, 3)
        Me.btnRepair.Name = "btnRepair"
        Me.btnRepair.Size = New System.Drawing.Size(103, 31)
        Me.btnRepair.TabIndex = 0
        Me.btnRepair.Text = "&Repair"
        Me.btnRepair.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRepair.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnRepair.UseVisualStyleBackColor = True
        '
        'tvOptions
        '
        Me.tvOptions.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvOptions.Location = New System.Drawing.Point(0, 0)
        Me.tvOptions.Name = "tvOptions"
        TreeNode1.Name = "Node0"
        TreeNode1.Text = "Repair"
        TreeNode2.Name = "Node1"
        TreeNode2.Text = "Optimize"
        Me.tvOptions.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2})
        Me.tvOptions.Size = New System.Drawing.Size(128, 390)
        Me.tvOptions.TabIndex = 0
        '
        'frmOptimizer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(686, 390)
        Me.Controls.Add(Me.scOptimizer)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmOptimizer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmOptimizer"
        Me.scOptimizer.Panel1.ResumeLayout(False)
        CType(Me.scOptimizer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scOptimizer.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents scOptimizer As SplitContainer
   Friend WithEvents btnApps As Button
   Friend WithEvents btnReg As Button
   Friend WithEvents btnFS As Button
   Friend WithEvents btnRepair As Button
   Friend WithEvents tvOptions As TreeView
End Class
