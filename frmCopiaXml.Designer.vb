<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCopiaXml
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
        Me.fechaArchivos = New System.Windows.Forms.DateTimePicker()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'fechaArchivos
        '
        Me.fechaArchivos.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.fechaArchivos.Location = New System.Drawing.Point(12, 22)
        Me.fechaArchivos.Name = "fechaArchivos"
        Me.fechaArchivos.Size = New System.Drawing.Size(99, 20)
        Me.fechaArchivos.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(144, 18)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Cargar XML"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'lblEstado
        '
        Me.lblEstado.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.lblEstado.Location = New System.Drawing.Point(12, 76)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(306, 23)
        Me.lblEstado.TabIndex = 2
        Me.lblEstado.Text = "Label1"
        Me.lblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblEstado.Visible = False
        '
        'frmCopiaXml
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(330, 127)
        Me.Controls.Add(Me.lblEstado)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.fechaArchivos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmCopiaXml"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmCopiaXml"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents fechaArchivos As System.Windows.Forms.DateTimePicker
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents lblEstado As System.Windows.Forms.Label
End Class
