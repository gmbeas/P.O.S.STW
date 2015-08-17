Public Class VendedoresDialog

    Event traeVendedor(ByVal codigo As String, ByVal nombre As String)


    Dim objVendedoresController As New VendedorController


    Private Sub VendedoresDialog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        

    End Sub


    Public Sub CargarDatos()
        Dim arr As ArrayList = objVendedoresController.Ayuda("STE")

        If arr.Count <> 0 Then
            Me.listaVendedores.DataSource = arr
            Me.listaVendedores.DisplayMember = "Descripcion"
            Me.listaVendedores.ValueMember = "Codigo"

            Me.lista_oculta.DataSource = arr
            Me.lista_oculta.DisplayMember = "Descripcion"
            Me.lista_oculta.ValueMember = "Codigo"
        Else
            MsgBox("NO EXISTEN REGISTROS", MsgBoxStyle.Exclamation, "INFORMACION")
        End If

    End Sub

    Function FILTRO() As ArrayList

        Dim ARR As New ArrayList

        For Each x As ListaObj In Me.lista_oculta.Items

            Dim posicion As Integer = 0

            posicion = x.Descripcion.IndexOf(UCase(Me.TextBox1.Text.Trim))

            If posicion <> -1 Then
                ARR.Add(x)
            End If

        Next

        Me.listaVendedores.DataSource = ARR
        Me.listaVendedores.DisplayMember = "Descripcion"
        Me.listaVendedores.ValueMember = "Codigo"

    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub listaVendedores_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles listaVendedores.Click

        Dim obj As ListaObj = Me.listaVendedores.SelectedItem
        RaiseEvent traeVendedor(obj.Codigo, obj.Descripcion)
        Me.Close()
    End Sub

    Private Sub listaVendedores_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles listaVendedores.KeyPress


        If Not IsNothing(Me.listaVendedores.SelectedValue) Then


            Dim codigo As String = Me.listaVendedores.SelectedValue.ToString.Trim
            Dim Nombre As String = Me.listaVendedores.DisplayMember.ToString.Trim

            RaiseEvent traeVendedor(codigo, Nombre)
            Me.Close()
            'Me.Owner.Controls("txtCodigoProducto").Text = "oye"

        Else
            MsgBox("SELECCIONE VALOR", MsgBoxStyle.Information, "BUSQUEDA")
        End If
    End Sub

    Private Sub listaVendedores_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles listaVendedores.SelectedIndexChanged


    End Sub

    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown




    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        FILTRO()
    End Sub
End Class