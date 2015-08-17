<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VendedoresDialog
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
        Me.listaVendedores = New System.Windows.Forms.ListBox
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.lista_oculta = New System.Windows.Forms.ListBox
        Me.SuspendLayout()
        '
        'listaVendedores
        '
        Me.listaVendedores.FormattingEnabled = True
        Me.listaVendedores.Location = New System.Drawing.Point(12, 35)
        Me.listaVendedores.Name = "listaVendedores"
        Me.listaVendedores.Size = New System.Drawing.Size(539, 147)
        Me.listaVendedores.TabIndex = 0
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(162, 3)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(209, 26)
        Me.TextBox1.TabIndex = 1
        '
        'lista_oculta
        '
        Me.lista_oculta.FormattingEnabled = True
        Me.lista_oculta.Location = New System.Drawing.Point(12, 188)
        Me.lista_oculta.Name = "lista_oculta"
        Me.lista_oculta.Size = New System.Drawing.Size(539, 17)
        Me.lista_oculta.TabIndex = 2
        Me.lista_oculta.Visible = False
        '
        'VendedoresDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(558, 200)
        Me.Controls.Add(Me.lista_oculta)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.listaVendedores)
        Me.Name = "VendedoresDialog"
        Me.Text = "VendedoresDialog"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents listaVendedores As System.Windows.Forms.ListBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents lista_oculta As System.Windows.Forms.ListBox
End Class
