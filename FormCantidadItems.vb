Public Class FormCantidadItems
    Public cantidad As Integer
    Public fila As Integer
    Event ActualizaCantidad(ByVal filas As Integer, ByVal cantidad As Integer)

    Private Sub FormCantidadItems_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txtCantidad.Text = cantidad.ToString

    End Sub

    Private Sub txtCantidad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCantidad.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtCantidad.Text <> "" Then
                Dim cantidad As Integer = Int32.Parse(Me.txtCantidad.Text)
                RaiseEvent ActualizaCantidad(fila, cantidad)
                Me.Close()

            Else
                MsgBox("Ingrese Valor")
            End If


        End If
    End Sub

    Private Sub txtCantidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidad.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtCantidad_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCantidad.TextChanged

    End Sub
End Class