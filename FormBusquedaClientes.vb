Public Class FormBusquedaClientes

    Event IngresaRut(ByVal rut As String)

    Private Sub txtBusqueda_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBusqueda.KeyDown

        If e.KeyValue = Keys.Enter Then
            Dim objcliente As New ClientesController
            If objcliente.filtrar(txtBusqueda.Text).Count <> 0 Then
                Me.ListaClientes.DataSource = objcliente.filtrar(txtBusqueda.Text)
                Me.ListaClientes.DisplayMember = "Descripcion"
                Me.ListaClientes.ValueMember = "Codigo"
            End If
        End If


    End Sub

    Private Sub txtBusqueda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBusqueda.TextChanged


    End Sub

    Private Sub FormBusquedaClientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ListaClientes_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListaClientes.Click
        RaiseEvent IngresaRut(ListaClientes.SelectedValue)
        Me.Close()

    End Sub

    Private Sub ListaClientes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListaClientes.SelectedIndexChanged



    End Sub
End Class