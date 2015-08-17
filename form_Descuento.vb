
Public Class form_Descuento
    Event IngresaDescuento(ByVal tipo As Integer, ByVal porcentaje As Double, ByVal codigo As String)

    Dim objUsuario As New UsuarioController


    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
       

        Me.ErrorProvider1.Clear()

        If txtUsuario.Text.Length = 0 Then
            Me.ErrorProvider1.SetError(txtUsuario, "Ingrese Usuario ")
            Exit Sub
        End If

        If txtPassword.Text.Length = 0 Then
            Me.ErrorProvider1.SetError(txtPassword, "Ingrese Password")
            Exit Sub
        End If

        If txtDescuento.Text.Length = 0 Then
            Me.ErrorProvider1.SetError(txtPassword, "Ingrese Porcentaje de descuento")
            Exit Sub
        End If


        If objUsuario.ValidaAutentificacion(txtUsuario.Text, txtPassword.Text) = False Then
            Me.ErrorProvider1.SetError(Me.txtUsuario, "error")
            MsgBox("Datosde autentificacion Incorrectos", MsgBoxStyle.Information, "STEWARD")
            Exit Sub
        End If

        If objUsuario.ValidaRolUsuario(txtUsuario.Text, 2) = False And objUsuario.ValidaRolUsuario(txtUsuario.Text, 261) = False Then
            MsgBox("usted no posee privilegios para realizar esta operación", MsgBoxStyle.Information, "STEWARD")
            Exit Sub

        End If

        Dim objpar As New ParametrosController

        If txtDescuento.Text >= _DESCUENTOMINIMO() And txtDescuento.Text <= _DESCUENTOMAXIMO() Then
            RaiseEvent IngresaDescuento(Int32.Parse(txtTipo.Text), Convert.ToDouble(txtDescuento.Text.Replace(".", ",")), txtCodigoArticulo.Text)
            Me.Close()
        Else
            MsgBox("el rango de descuento no se encuentra en el margen adecuado", MsgBoxStyle.Information, "STEWARD")
            Exit Sub
        End If



    End Sub

    Private Sub form_Descuento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txtUsuario.Clear()
        Me.txtPassword.Clear()
        Me.txtDescuento.Clear()
    End Sub

    Private Sub txtUsuario_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUsuario.KeyDown
        If e.KeyValue = Keys.Enter Then
            Me.txtPassword.Focus()
        End If

    End Sub

    Private Sub txtUsuario_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUsuario.TextChanged

    End Sub

    Private Sub txtPassword_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPassword.KeyDown

        If e.KeyValue = Keys.Enter Then
            Me.txtDescuento.Focus()

        End If

    End Sub

    Private Sub txtPassword_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPassword.TextChanged

    End Sub

    Private Sub txtDescuento_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDescuento.KeyDown

        If e.KeyValue = Keys.Enter Then

            Me.btnAceptar_Click(sender, e)

        End If


    End Sub

    Private Sub txtDescuento_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDescuento.TextChanged

    End Sub
End Class