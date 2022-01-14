<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddPurok
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAddPurok))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnBac = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.txtPurok = New System.Windows.Forms.TextBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DodgerBlue
        Me.Panel1.Controls.Add(Me.btnBac)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.btnBack)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(316, 81)
        Me.Panel1.TabIndex = 28
        '
        'btnBac
        '
        Me.btnBac.BackColor = System.Drawing.Color.Transparent
        Me.btnBac.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBac.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBac.ForeColor = System.Drawing.Color.Transparent
        Me.btnBac.Image = CType(resources.GetObject("btnBac.Image"), System.Drawing.Image)
        Me.btnBac.Location = New System.Drawing.Point(8, 5)
        Me.btnBac.Name = "btnBac"
        Me.btnBac.Size = New System.Drawing.Size(42, 27)
        Me.btnBac.TabIndex = 43
        Me.btnBac.UseCompatibleTextRendering = True
        Me.btnBac.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("MS Reference Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(55, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(210, 26)
        Me.Label1.TabIndex = 42
        Me.Label1.Text = "ADD NEW PUROK"
        '
        'btnBack
        '
        Me.btnBack.BackColor = System.Drawing.Color.Transparent
        Me.btnBack.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBack.ForeColor = System.Drawing.Color.Cornsilk
        Me.btnBack.Image = CType(resources.GetObject("btnBack.Image"), System.Drawing.Image)
        Me.btnBack.Location = New System.Drawing.Point(9, 416)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(59, 32)
        Me.btnBack.TabIndex = 23
        Me.btnBack.UseCompatibleTextRendering = True
        Me.btnBack.UseVisualStyleBackColor = False
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate.Location = New System.Drawing.Point(24, 101)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(100, 20)
        Me.lblDate.TabIndex = 149
        Me.lblDate.Text = "Purok Name:"
        '
        'txtPurok
        '
        Me.txtPurok.Font = New System.Drawing.Font("MS Reference Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPurok.Location = New System.Drawing.Point(130, 101)
        Me.txtPurok.Name = "txtPurok"
        Me.txtPurok.Size = New System.Drawing.Size(158, 23)
        Me.txtPurok.TabIndex = 150
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.DarkRed
        Me.btnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSave.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnSave.Location = New System.Drawing.Point(130, 139)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(158, 48)
        Me.btnSave.TabIndex = 151
        Me.btnSave.Text = "&Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'frmAddPurok
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(316, 202)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.txtPurok)
        Me.Controls.Add(Me.lblDate)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmAddPurok"
        Me.Text = "Add Purok"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnBack As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents lblDate As Label
    Friend WithEvents txtPurok As TextBox
    Friend WithEvents btnSave As Button
    Friend WithEvents btnBac As Button
End Class
