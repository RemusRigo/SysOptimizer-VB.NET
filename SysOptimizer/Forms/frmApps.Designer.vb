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
        Me.lvApps = New System.Windows.Forms.ListView()
        Me.btnAppsRun = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lvApps
        '
        Me.lvApps.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvApps.CheckBoxes = True
        Me.lvApps.FullRowSelect = True
        Me.lvApps.HideSelection = False
        Me.lvApps.Location = New System.Drawing.Point(0, 0)
        Me.lvApps.Name = "lvApps"
        Me.lvApps.OwnerDraw = True
        Me.lvApps.Size = New System.Drawing.Size(690, 358)
        Me.lvApps.TabIndex = 0
        Me.lvApps.UseCompatibleStateImageBehavior = False
        Me.lvApps.View = System.Windows.Forms.View.Details
        '
        'btnAppsRun
        '
        Me.btnAppsRun.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAppsRun.Location = New System.Drawing.Point(647, 361)
        Me.btnAppsRun.Name = "btnAppsRun"
        Me.btnAppsRun.Size = New System.Drawing.Size(39, 20)
        Me.btnAppsRun.TabIndex = 2
        Me.btnAppsRun.Text = "Run"
        Me.btnAppsRun.UseVisualStyleBackColor = True
        '
        'frmApps
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(689, 382)
        Me.Controls.Add(Me.btnAppsRun)
        Me.Controls.Add(Me.lvApps)
        Me.Name = "frmApps"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Apps"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lvApps As ListView
    Friend WithEvents btnAppsRun As Button

End Class
