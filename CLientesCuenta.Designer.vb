<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CLientesCuenta
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnBuscar = New System.Windows.Forms.Button
        Me.txtRut = New System.Windows.Forms.TextBox
        Me.GridDocumentos = New System.Windows.Forms.DataGridView
        Me.Chk = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtTotalAbonos = New System.Windows.Forms.TextBox
        Me.txtTotalCargo = New System.Windows.Forms.TextBox
        Me.txtSaldoPorPagar = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtNombre = New System.Windows.Forms.TextBox
        Me.txtRut_ = New System.Windows.Forms.TextBox
        Me.btn_Aplicar_Pago = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        CType(Me.GridDocumentos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnBuscar)
        Me.GroupBox1.Controls.Add(Me.txtRut)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(196, 51)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Cliente"
        '
        'btnBuscar
        '
        Me.btnBuscar.Location = New System.Drawing.Point(125, 16)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(52, 23)
        Me.btnBuscar.TabIndex = 1
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'txtRut
        '
        Me.txtRut.Location = New System.Drawing.Point(19, 19)
        Me.txtRut.Name = "txtRut"
        Me.txtRut.Size = New System.Drawing.Size(100, 20)
        Me.txtRut.TabIndex = 0
        '
        'GridDocumentos
        '
        Me.GridDocumentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridDocumentos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Chk})
        Me.GridDocumentos.Location = New System.Drawing.Point(12, 125)
        Me.GridDocumentos.Name = "GridDocumentos"
        Me.GridDocumentos.Size = New System.Drawing.Size(1024, 307)
        Me.GridDocumentos.TabIndex = 1
        '
        'Chk
        '
        Me.Chk.HeaderText = "Seleccionar"
        Me.Chk.Name = "Chk"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.TxtTotalAbonos)
        Me.GroupBox2.Controls.Add(Me.txtTotalCargo)
        Me.GroupBox2.Controls.Add(Me.txtSaldoPorPagar)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.txtNombre)
        Me.GroupBox2.Controls.Add(Me.txtRut_)
        Me.GroupBox2.Location = New System.Drawing.Point(255, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(781, 68)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Resumen"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(684, 42)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Total Abonos"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(569, 42)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Total Cargos"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(442, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Saldo por Pagar"
        '
        'TxtTotalAbonos
        '
        Me.TxtTotalAbonos.Location = New System.Drawing.Point(667, 19)
        Me.TxtTotalAbonos.Name = "TxtTotalAbonos"
        Me.TxtTotalAbonos.ReadOnly = True
        Me.TxtTotalAbonos.Size = New System.Drawing.Size(100, 20)
        Me.TxtTotalAbonos.TabIndex = 8
        '
        'txtTotalCargo
        '
        Me.txtTotalCargo.Location = New System.Drawing.Point(551, 19)
        Me.txtTotalCargo.Name = "txtTotalCargo"
        Me.txtTotalCargo.ReadOnly = True
        Me.txtTotalCargo.Size = New System.Drawing.Size(100, 20)
        Me.txtTotalCargo.TabIndex = 7
        '
        'txtSaldoPorPagar
        '
        Me.txtSaldoPorPagar.Location = New System.Drawing.Point(434, 19)
        Me.txtSaldoPorPagar.Name = "txtSaldoPorPagar"
        Me.txtSaldoPorPagar.ReadOnly = True
        Me.txtSaldoPorPagar.Size = New System.Drawing.Size(100, 20)
        Me.txtSaldoPorPagar.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(267, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Nombre"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(60, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(24, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Rut"
        '
        'txtNombre
        '
        Me.txtNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombre.Location = New System.Drawing.Point(131, 18)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.ReadOnly = True
        Me.txtNombre.Size = New System.Drawing.Size(287, 26)
        Me.txtNombre.TabIndex = 3
        '
        'txtRut_
        '
        Me.txtRut_.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRut_.Location = New System.Drawing.Point(25, 19)
        Me.txtRut_.Name = "txtRut_"
        Me.txtRut_.ReadOnly = True
        Me.txtRut_.Size = New System.Drawing.Size(100, 26)
        Me.txtRut_.TabIndex = 2
        '
        'btn_Aplicar_Pago
        '
        Me.btn_Aplicar_Pago.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Aplicar_Pago.Location = New System.Drawing.Point(12, 438)
        Me.btn_Aplicar_Pago.Name = "btn_Aplicar_Pago"
        Me.btn_Aplicar_Pago.Size = New System.Drawing.Size(119, 48)
        Me.btn_Aplicar_Pago.TabIndex = 3
        Me.btn_Aplicar_Pago.Text = "Aplicar Pago"
        Me.btn_Aplicar_Pago.UseVisualStyleBackColor = True
        '
        'CLientesCuenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1047, 498)
        Me.Controls.Add(Me.btn_Aplicar_Pago)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GridDocumentos)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "CLientesCuenta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CLientesCuenta"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.GridDocumentos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents txtRut As System.Windows.Forms.TextBox
    Friend WithEvents GridDocumentos As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents txtRut_ As System.Windows.Forms.TextBox
    Friend WithEvents TxtTotalAbonos As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalCargo As System.Windows.Forms.TextBox
    Friend WithEvents txtSaldoPorPagar As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btn_Aplicar_Pago As System.Windows.Forms.Button
    Friend WithEvents Chk As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
