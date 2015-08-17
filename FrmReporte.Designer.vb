<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class txtNroDoc
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txt_Nro_Doc = New System.Windows.Forms.TextBox
        Me.btn_Ejecutar = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.dropMedioPago = New System.Windows.Forms.ComboBox
        Me.dropTipoDocumento = New System.Windows.Forms.ComboBox
        Me.dropCaja = New System.Windows.Forms.ComboBox
        Me.dropCajero = New System.Windows.Forms.ComboBox
        Me.drop_Sede = New System.Windows.Forms.ComboBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.RadSoloActualizaPos = New System.Windows.Forms.RadioButton
        Me.RadSoloActualizaLisa = New System.Windows.Forms.RadioButton
        Me.RadActualizaLisayPos = New System.Windows.Forms.RadioButton
        Me.RadSoloConcilia = New System.Windows.Forms.RadioButton
        Me.RadActualizayConcilia = New System.Windows.Forms.RadioButton
        Me.RadFechaAno = New System.Windows.Forms.RadioButton
        Me.RadFechaMes = New System.Windows.Forms.RadioButton
        Me.radFechaDia = New System.Windows.Forms.RadioButton
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.FechaHasta = New System.Windows.Forms.DateTimePicker
        Me.FechaDesde = New System.Windows.Forms.DateTimePicker
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txt_Nro_Doc)
        Me.GroupBox1.Controls.Add(Me.btn_Ejecutar)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.dropMedioPago)
        Me.GroupBox1.Controls.Add(Me.dropTipoDocumento)
        Me.GroupBox1.Controls.Add(Me.dropCaja)
        Me.GroupBox1.Controls.Add(Me.dropCajero)
        Me.GroupBox1.Controls.Add(Me.drop_Sede)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.RadFechaAno)
        Me.GroupBox1.Controls.Add(Me.RadFechaMes)
        Me.GroupBox1.Controls.Add(Me.radFechaDia)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.FechaHasta)
        Me.GroupBox1.Controls.Add(Me.FechaDesde)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1123, 101)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'txt_Nro_Doc
        '
        Me.txt_Nro_Doc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Nro_Doc.Location = New System.Drawing.Point(907, 43)
        Me.txt_Nro_Doc.Name = "txt_Nro_Doc"
        Me.txt_Nro_Doc.Size = New System.Drawing.Size(203, 22)
        Me.txt_Nro_Doc.TabIndex = 20
        '
        'btn_Ejecutar
        '
        Me.btn_Ejecutar.Location = New System.Drawing.Point(571, 25)
        Me.btn_Ejecutar.Name = "btn_Ejecutar"
        Me.btn_Ejecutar.Size = New System.Drawing.Size(43, 34)
        Me.btn_Ejecutar.TabIndex = 19
        Me.btn_Ejecutar.Text = "Ejecu"
        Me.btn_Ejecutar.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(834, 74)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(67, 13)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "Medio Pago:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(851, 46)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(50, 13)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "Nro Doc:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(847, 21)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(54, 13)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Tipo Doc:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(629, 71)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(31, 13)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Caja:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(620, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Cajero:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(625, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Sede:"
        '
        'dropMedioPago
        '
        Me.dropMedioPago.FormattingEnabled = True
        Me.dropMedioPago.Location = New System.Drawing.Point(907, 71)
        Me.dropMedioPago.Name = "dropMedioPago"
        Me.dropMedioPago.Size = New System.Drawing.Size(203, 21)
        Me.dropMedioPago.TabIndex = 14
        '
        'dropTipoDocumento
        '
        Me.dropTipoDocumento.FormattingEnabled = True
        Me.dropTipoDocumento.Location = New System.Drawing.Point(907, 12)
        Me.dropTipoDocumento.Name = "dropTipoDocumento"
        Me.dropTipoDocumento.Size = New System.Drawing.Size(203, 21)
        Me.dropTipoDocumento.TabIndex = 12
        '
        'dropCaja
        '
        Me.dropCaja.FormattingEnabled = True
        Me.dropCaja.Location = New System.Drawing.Point(666, 71)
        Me.dropCaja.Name = "dropCaja"
        Me.dropCaja.Size = New System.Drawing.Size(153, 21)
        Me.dropCaja.TabIndex = 11
        '
        'dropCajero
        '
        Me.dropCajero.FormattingEnabled = True
        Me.dropCajero.Location = New System.Drawing.Point(666, 40)
        Me.dropCajero.Name = "dropCajero"
        Me.dropCajero.Size = New System.Drawing.Size(153, 21)
        Me.dropCajero.TabIndex = 10
        '
        'drop_Sede
        '
        Me.drop_Sede.FormattingEnabled = True
        Me.drop_Sede.Location = New System.Drawing.Point(666, 13)
        Me.drop_Sede.Name = "drop_Sede"
        Me.drop_Sede.Size = New System.Drawing.Size(153, 21)
        Me.drop_Sede.TabIndex = 9
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.RadSoloActualizaPos)
        Me.GroupBox2.Controls.Add(Me.RadSoloActualizaLisa)
        Me.GroupBox2.Controls.Add(Me.RadActualizaLisayPos)
        Me.GroupBox2.Controls.Add(Me.RadSoloConcilia)
        Me.GroupBox2.Controls.Add(Me.RadActualizayConcilia)
        Me.GroupBox2.Location = New System.Drawing.Point(314, 7)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(251, 79)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        '
        'RadSoloActualizaPos
        '
        Me.RadSoloActualizaPos.AutoSize = True
        Me.RadSoloActualizaPos.Location = New System.Drawing.Point(128, 56)
        Me.RadSoloActualizaPos.Name = "RadSoloActualizaPos"
        Me.RadSoloActualizaPos.Size = New System.Drawing.Size(113, 17)
        Me.RadSoloActualizaPos.TabIndex = 4
        Me.RadSoloActualizaPos.TabStop = True
        Me.RadSoloActualizaPos.Text = "Solo Actualiza Pos"
        Me.RadSoloActualizaPos.UseVisualStyleBackColor = True
        '
        'RadSoloActualizaLisa
        '
        Me.RadSoloActualizaLisa.AutoSize = True
        Me.RadSoloActualizaLisa.Location = New System.Drawing.Point(128, 33)
        Me.RadSoloActualizaLisa.Name = "RadSoloActualizaLisa"
        Me.RadSoloActualizaLisa.Size = New System.Drawing.Size(114, 17)
        Me.RadSoloActualizaLisa.TabIndex = 3
        Me.RadSoloActualizaLisa.TabStop = True
        Me.RadSoloActualizaLisa.Text = "Solo Actualiza Lisa"
        Me.RadSoloActualizaLisa.UseVisualStyleBackColor = True
        '
        'RadActualizaLisayPos
        '
        Me.RadActualizaLisayPos.AutoSize = True
        Me.RadActualizaLisayPos.Location = New System.Drawing.Point(128, 10)
        Me.RadActualizaLisayPos.Name = "RadActualizaLisayPos"
        Me.RadActualizaLisayPos.Size = New System.Drawing.Size(119, 17)
        Me.RadActualizaLisayPos.TabIndex = 2
        Me.RadActualizaLisayPos.TabStop = True
        Me.RadActualizaLisayPos.Text = "Actualiza Lisa y Pos"
        Me.RadActualizaLisayPos.UseVisualStyleBackColor = True
        '
        'RadSoloConcilia
        '
        Me.RadSoloConcilia.AutoSize = True
        Me.RadSoloConcilia.Location = New System.Drawing.Point(6, 33)
        Me.RadSoloConcilia.Name = "RadSoloConcilia"
        Me.RadSoloConcilia.Size = New System.Drawing.Size(86, 17)
        Me.RadSoloConcilia.TabIndex = 1
        Me.RadSoloConcilia.TabStop = True
        Me.RadSoloConcilia.Text = "Solo Concilia"
        Me.RadSoloConcilia.UseVisualStyleBackColor = True
        '
        'RadActualizayConcilia
        '
        Me.RadActualizayConcilia.AutoSize = True
        Me.RadActualizayConcilia.Location = New System.Drawing.Point(6, 10)
        Me.RadActualizayConcilia.Name = "RadActualizayConcilia"
        Me.RadActualizayConcilia.Size = New System.Drawing.Size(116, 17)
        Me.RadActualizayConcilia.TabIndex = 0
        Me.RadActualizayConcilia.TabStop = True
        Me.RadActualizayConcilia.Text = "Actualiza y Concilia"
        Me.RadActualizayConcilia.UseVisualStyleBackColor = True
        '
        'RadFechaAno
        '
        Me.RadFechaAno.AutoSize = True
        Me.RadFechaAno.Location = New System.Drawing.Point(263, 61)
        Me.RadFechaAno.Name = "RadFechaAno"
        Me.RadFechaAno.Size = New System.Drawing.Size(44, 17)
        Me.RadFechaAno.TabIndex = 7
        Me.RadFechaAno.TabStop = True
        Me.RadFechaAno.Text = "Año"
        Me.RadFechaAno.UseVisualStyleBackColor = True
        '
        'RadFechaMes
        '
        Me.RadFechaMes.AutoSize = True
        Me.RadFechaMes.Location = New System.Drawing.Point(263, 38)
        Me.RadFechaMes.Name = "RadFechaMes"
        Me.RadFechaMes.Size = New System.Drawing.Size(45, 17)
        Me.RadFechaMes.TabIndex = 6
        Me.RadFechaMes.TabStop = True
        Me.RadFechaMes.Text = "Mes"
        Me.RadFechaMes.UseVisualStyleBackColor = True
        '
        'radFechaDia
        '
        Me.radFechaDia.AutoSize = True
        Me.radFechaDia.Location = New System.Drawing.Point(263, 15)
        Me.radFechaDia.Name = "radFechaDia"
        Me.radFechaDia.Size = New System.Drawing.Size(41, 17)
        Me.radFechaDia.TabIndex = 5
        Me.radFechaDia.TabStop = True
        Me.radFechaDia.Text = "Dia"
        Me.radFechaDia.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Hasta"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Desde"
        '
        'FechaHasta
        '
        Me.FechaHasta.Location = New System.Drawing.Point(50, 47)
        Me.FechaHasta.Name = "FechaHasta"
        Me.FechaHasta.Size = New System.Drawing.Size(200, 20)
        Me.FechaHasta.TabIndex = 2
        '
        'FechaDesde
        '
        Me.FechaDesde.Location = New System.Drawing.Point(50, 21)
        Me.FechaDesde.Name = "FechaDesde"
        Me.FechaDesde.Size = New System.Drawing.Size(200, 20)
        Me.FechaDesde.TabIndex = 1
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(13, 129)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(1123, 324)
        Me.DataGridView1.TabIndex = 1
        '
        'txtNroDoc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1147, 480)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "txtNroDoc"
        Me.Text = "Reporte"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents RadActualizayConcilia As System.Windows.Forms.RadioButton
    Friend WithEvents RadFechaAno As System.Windows.Forms.RadioButton
    Friend WithEvents RadFechaMes As System.Windows.Forms.RadioButton
    Friend WithEvents radFechaDia As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents FechaHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents FechaDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents RadActualizaLisayPos As System.Windows.Forms.RadioButton
    Friend WithEvents RadSoloConcilia As System.Windows.Forms.RadioButton
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dropMedioPago As System.Windows.Forms.ComboBox
    Friend WithEvents dropTipoDocumento As System.Windows.Forms.ComboBox
    Friend WithEvents dropCaja As System.Windows.Forms.ComboBox
    Friend WithEvents dropCajero As System.Windows.Forms.ComboBox
    Friend WithEvents drop_Sede As System.Windows.Forms.ComboBox
    Friend WithEvents RadSoloActualizaPos As System.Windows.Forms.RadioButton
    Friend WithEvents RadSoloActualizaLisa As System.Windows.Forms.RadioButton
    Friend WithEvents btn_Ejecutar As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_Nro_Doc As System.Windows.Forms.TextBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
End Class
