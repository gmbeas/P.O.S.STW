<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDirecciones
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Label1 = New System.Windows.Forms.Label
        Me.Direccion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DescripcionComuna = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DescripcionCiudad = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DescripcionRegion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Codigo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Region = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Ciudad = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Comuna = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Direccion, Me.DescripcionComuna, Me.DescripcionCiudad, Me.DescripcionRegion, Me.Codigo, Me.Region, Me.Ciudad, Me.Comuna})
        Me.DataGridView1.Location = New System.Drawing.Point(9, 36)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(795, 156)
        Me.DataGridView1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 18)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Direcciones"
        '
        'Direccion
        '
        Me.Direccion.DataPropertyName = "Direccion"
        Me.Direccion.HeaderText = "Dirección"
        Me.Direccion.Name = "Direccion"
        Me.Direccion.ReadOnly = True
        Me.Direccion.Width = 300
        '
        'DescripcionComuna
        '
        Me.DescripcionComuna.DataPropertyName = "DescripcionComuna"
        Me.DescripcionComuna.HeaderText = "Comuna"
        Me.DescripcionComuna.Name = "DescripcionComuna"
        Me.DescripcionComuna.ReadOnly = True
        Me.DescripcionComuna.Width = 150
        '
        'DescripcionCiudad
        '
        Me.DescripcionCiudad.DataPropertyName = "DescripcionCiudad"
        Me.DescripcionCiudad.HeaderText = "Ciudad"
        Me.DescripcionCiudad.Name = "DescripcionCiudad"
        Me.DescripcionCiudad.ReadOnly = True
        Me.DescripcionCiudad.Width = 150
        '
        'DescripcionRegion
        '
        Me.DescripcionRegion.DataPropertyName = "DescripcionRegion"
        Me.DescripcionRegion.HeaderText = "Región"
        Me.DescripcionRegion.Name = "DescripcionRegion"
        Me.DescripcionRegion.ReadOnly = True
        Me.DescripcionRegion.Width = 150
        '
        'Codigo
        '
        Me.Codigo.DataPropertyName = "Codigo"
        Me.Codigo.HeaderText = "Codigo"
        Me.Codigo.Name = "Codigo"
        Me.Codigo.ReadOnly = True
        Me.Codigo.Visible = False
        '
        'Region
        '
        Me.Region.DataPropertyName = "Region"
        Me.Region.HeaderText = "Region"
        Me.Region.Name = "Region"
        Me.Region.ReadOnly = True
        Me.Region.Visible = False
        '
        'Ciudad
        '
        Me.Ciudad.DataPropertyName = "Ciudad"
        Me.Ciudad.HeaderText = "Ciudad"
        Me.Ciudad.Name = "Ciudad"
        Me.Ciudad.ReadOnly = True
        Me.Ciudad.Visible = False
        '
        'Comuna
        '
        Me.Comuna.DataPropertyName = "Comuna"
        Me.Comuna.HeaderText = "Comuna"
        Me.Comuna.Name = "Comuna"
        Me.Comuna.ReadOnly = True
        Me.Comuna.Visible = False
        '
        'FormDirecciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(816, 204)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DataGridView1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormDirecciones"
        Me.Text = "FormDirecciones"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Direccion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescripcionComuna As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescripcionCiudad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescripcionRegion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Region As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Ciudad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Comuna As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
