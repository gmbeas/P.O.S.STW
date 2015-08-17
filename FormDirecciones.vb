Public Class FormDirecciones

    Event CargaDireccion(ByVal Codigo As String, ByVal descripcion As String, idtipo As String)

    Public rut As String
    Public tipo As String

    Private Sub FormDirecciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim objdir As New DireccionesController
        Dim dir As ArrayList = objdir.GetDirecciones(rut)
        Me.DataGridView1.DataSource = dir

    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick

        If e.RowIndex <> -1 Then

            Dim codigo As String = Me.DataGridView1.Rows(e.RowIndex).Cells("Codigo").Value
            Dim descripcion As String = Me.DataGridView1.Rows(e.RowIndex).Cells("Direccion").Value.ToString.Trim
            Dim region As String = Me.DataGridView1.Rows(e.RowIndex).Cells("DESCRIPCIONREGION").Value.ToString.Trim
            Dim ciudad As String = Me.DataGridView1.Rows(e.RowIndex).Cells("DESCRIPCIONCIUDAD").Value.ToString.Trim
            Dim comuna As String = Me.DataGridView1.Rows(e.RowIndex).Cells("DESCRIPCIONCOMUNA").Value.ToString.Trim
            Dim direccion As String = descripcion + " " + comuna + " " + ciudad
            Dim codigoregion As String = Me.DataGridView1.Rows(e.RowIndex).Cells("REGION").Value.ToString.Trim
            Dim codigocomuna As String = Me.DataGridView1.Rows(e.RowIndex).Cells("COMUNA").Value.ToString.Trim
            Dim codigociudad As String = Me.DataGridView1.Rows(e.RowIndex).Cells("CIUDAD").Value.ToString.Trim


            Dim objdireccion As New DireccionObj
            objdireccion.Codigo = codigo
            objdireccion.Direccion = descripcion
            objdireccion.Comuna = codigocomuna
            objdireccion.Ciudad = codigociudad
            objdireccion.Region = codigoregion
            objdireccion.DescripcionCiudad = ciudad
            objdireccion.DescripcionComuna = comuna
            objdireccion.DescripcionRegion = region

            If (tipo = "1") Then
                _direccionFacturacion = objdireccion
            Else
                _direccionDespacho = objdireccion
            End If
            ' _direccionFacturacion = objdireccion


            RaiseEvent CargaDireccion(codigo, direccion, tipo)
            Me.Close()
        End If

    End Sub


  
    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class