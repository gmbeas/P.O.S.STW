Public Class Productos
    Dim objProductoController As New ArticuloController
    Public caja As System.Windows.Forms.TextBox
    Public btn As System.Windows.Forms.Button
    Public tipo As String
    Public listaPrecio As String

    Event BuscarArt(ByVal codigo As String)

    Private Sub Productos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load





    End Sub


    Public Sub CargarDatos()
        If txtBusqueda.Text <> "" Then

            Dim ds As DataSet = objProductoController.Filtro(tipo, txtBusqueda.Text, listaPrecio)
            If ds.Tables(0).Rows.Count <> 0 Then
                Dim arreglo As New ArrayList

                For Each dr As DataRow In ds.Tables(0).Rows

                    Dim obj As New ListaObj
                    obj.Codigo = dr("Codigo").ToString

                    Dim descripcion As String = dr("codigo").ToString + " - " + dr("Descripcion").ToString + " " + dr(2).ToString()
                    descripcion = descripcion.Trim + Space(120 - (descripcion.Trim).Length)
                    obj.Descripcion = descripcion
                    arreglo.Add(obj)
                Next

                Me.ListBox1.DataSource = arreglo
                Me.ListBox1.DisplayMember = "Descripcion"
                Me.ListBox1.ValueMember = "Codigo"

            End If

        End If
    End Sub





    Public Sub llenarGrilla(ByVal grilla As DataGridView, ByVal objeto As Object)
        Dim bs As BindingSource = New BindingSource()
        bs.DataSource = objeto
        grilla.DataSource = bs
        bs.ResetBindings(False)
    End Sub

    Private Sub ListBox1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox1.Click

        If Not IsNothing(Me.ListBox1.SelectedValue) Then


            Dim codigo As String = Me.ListBox1.SelectedValue.ToString.Trim
            RaiseEvent BuscarArt(codigo)
            'Me.Owner.Controls("txtCodigoProducto").Text = "oye"
            Me.Close()


        Else
            MsgBox("SELECCIONE VALOR", MsgBoxStyle.Information, "BUSQUEDA")
        End If


    End Sub





    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged

    End Sub
End Class