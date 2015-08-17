Public Class FormAutorizacion
    Event Autorizacion(ByVal Codigo As String)

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        Autoriza()

    End Sub



    Public Sub Autoriza()
        Dim objusuario As New UsuarioController

        Me.ErrorProvider1.Clear()

        If txtUsuario.Text.Length = 0 Then
            Me.ErrorProvider1.SetError(txtUsuario, "Ingrese Usuario ")
            Exit Sub
        End If

        If txtPassword.Text.Length = 0 Then
            Me.ErrorProvider1.SetError(txtPassword, "Ingrese Password")
            Exit Sub
        End If



        If objusuario.ValidaAutentificacion(txtUsuario.Text, txtPassword.Text) = False Then
            Me.ErrorProvider1.SetError(Me.txtUsuario, "error")
            MsgBox("Datosde autentificacion Incorrectos", MsgBoxStyle.Information, "STEWARD")
            Exit Sub
        End If

        If objusuario.ValidaRolUsuario(txtUsuario.Text, _ROLSUPERVISOR) = False Then
            MsgBox("usted no posee privilegios para realizar esta operación", MsgBoxStyle.Information, "STEWARD")
            Exit Sub

        End If


        RaiseEvent Autorizacion(Me.Tipo.Text)
        Me.Close()

    End Sub

    Private Sub FormAutorizacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txtUsuario.Text = ""
        Me.txtPassword.Text = ""
    End Sub

    Private Sub FormAutorizacion_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed



    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Dim cierre As String = ""
        If Tipo.Text = "Credido" Then
            cierre = "Close"
        End If

        If Tipo.Text = "Deposito" Then
            cierre = "CloseDeposito"
        End If

        If Tipo.Text = "ListaPrecio" Then
            cierre = "CloseLista"
        End If

        RaiseEvent Autorizacion(cierre)
        Me.Close()
    End Sub

    Private Sub txtPassword_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPassword.KeyDown

        If e.KeyValue = Keys.Enter Then
            Autoriza()
        End If


    End Sub

    Private Sub txtPassword_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPassword.TextChanged

    End Sub
End Class