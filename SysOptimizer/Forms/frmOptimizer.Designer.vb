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
      Dim TreeNode1 As TreeNode = New TreeNode("Repair")
      Dim TreeNode2 As TreeNode = New TreeNode("Optimize")
      scOptimizer = New SplitContainer()
      tvOptions = New TreeView()
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
      ' 
      ' frmOptimizer
      ' 
      AutoScaleDimensions = New SizeF(7F, 15F)
      AutoScaleMode = AutoScaleMode.Font
      ClientSize = New Size(800, 450)
      Controls.Add(scOptimizer)
      Name = "frmOptimizer"
      Text = "frmOptimizer"
      scOptimizer.Panel1.ResumeLayout(False)
      CType(scOptimizer, ComponentModel.ISupportInitialize).EndInit()
      scOptimizer.ResumeLayout(False)
      ResumeLayout(False)
   End Sub

   Friend WithEvents scOptimizer As SplitContainer
   Friend WithEvents tvOptions As TreeView
End Class
