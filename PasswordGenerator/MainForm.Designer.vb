<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.genPass_BT = New System.Windows.Forms.Button()
        Me.password_TB = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pLen_MTB = New System.Windows.Forms.TextBox()
        Me.simbolFiles_CB = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'genPass_BT
        '
        Me.genPass_BT.Location = New System.Drawing.Point(5, 58)
        Me.genPass_BT.Name = "genPass_BT"
        Me.genPass_BT.Size = New System.Drawing.Size(216, 23)
        Me.genPass_BT.TabIndex = 0
        Me.genPass_BT.Text = "Генерировать пароль"
        Me.genPass_BT.UseVisualStyleBackColor = True
        '
        'password_TB
        '
        Me.password_TB.Font = New System.Drawing.Font("Consolas", 10.0!)
        Me.password_TB.Location = New System.Drawing.Point(5, 87)
        Me.password_TB.Name = "password_TB"
        Me.password_TB.ReadOnly = True
        Me.password_TB.Size = New System.Drawing.Size(216, 23)
        Me.password_TB.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Длина пароля:"
        '
        'pLen_MTB
        '
        Me.pLen_MTB.Location = New System.Drawing.Point(95, 5)
        Me.pLen_MTB.Name = "pLen_MTB"
        Me.pLen_MTB.Size = New System.Drawing.Size(31, 20)
        Me.pLen_MTB.TabIndex = 4
        '
        'simbolFiles_CB
        '
        Me.simbolFiles_CB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.simbolFiles_CB.FormattingEnabled = True
        Me.simbolFiles_CB.Location = New System.Drawing.Point(5, 31)
        Me.simbolFiles_CB.Name = "simbolFiles_CB"
        Me.simbolFiles_CB.Size = New System.Drawing.Size(216, 21)
        Me.simbolFiles_CB.TabIndex = 5
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(227, 116)
        Me.Controls.Add(Me.simbolFiles_CB)
        Me.Controls.Add(Me.pLen_MTB)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.password_TB)
        Me.Controls.Add(Me.genPass_BT)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MainForm"
        Me.Text = "Password Generator v 1.2"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents genPass_BT As System.Windows.Forms.Button
    Friend WithEvents password_TB As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pLen_MTB As System.Windows.Forms.TextBox
    Friend WithEvents simbolFiles_CB As ComboBox
End Class
