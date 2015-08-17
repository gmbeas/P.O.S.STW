<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormBusquedaClientes
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
        Me.txtBusqueda = New System.Windows.Forms.TextBox
        Me.ListaClientes = New System.Windows.Forms.ListBox
        Me.SuspendLayout()
        '
        'txtBusqueda
        '
        Me.txtBusqueda.Location = New System.Drawing.Point(86, 12)
        Me.txtBusqueda.Name = "txtBusqueda"
        Me.txtBusqueda.Size = New System.Drawing.Size(245, 20)
        Me.txtBusqueda.TabIndex = 0
        '
        'ListaClientes
        '
        Me.ListaClientes.FormattingEnabled = True
        Me.ListaClientes.Location = New System.Drawing.Point(24, 52)
        Me.ListaClientes.Name = "ListaClientes"
        Me.ListaClientes.Size = New System.Drawing.Size(396, 134)
        Me.ListaClientes.TabIndex = 1
        '
        'FormBusquedaClientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(448, 207)
        Me.Controls.Add(Me.ListaClientes)
        Me.Controls.Add(Me.txtBusqueda)
        Me.Name = "FormBusquedaClientes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Buscar Clientes"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtBusqueda As System.Windows.Forms.TextBox
    Friend WithEvents ListaClientes As System.Windows.Forms.ListBox
End Class
