Public Class AnulaDocumento

    Public correlativo As String
    Public CodigoVendedor As String
    Public CodigoCliente As String
    Public ListaPrecio As String


    Private Sub btn_Anular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Anular.Click


        Dim observaciones As String = ""



        If txtObservaciones.Text <> "" Then
            observaciones = txtObservaciones.Text
        Else
            MsgBox("Ingrese la Razon por la que esta anulando el documento!", MsgBoxStyle.Information, "Steward")
            Exit Sub
        End If


        Dim objanula As New DocumentosVentaController
        'objanula.AnulaDocumento(_Empresa, _Sede, _PuntoFacturacion, _tipoDocumentoVenta, correlativo)

        ' Dim wswop As New ws_pos.POS
        'Dim ds As DataSet = wswop.POS_ActualizaCabecera("M", _Empresa, _Bodega, _Pos, _tipoDocumentoVenta, correlativo, _FechaSistema, CodigoVendedor, CodigoCliente, ListaPrecio, 5, id_Cajero, 0, 0, 0, 0, 0, 0, txtObservaciones.Text, id_Cajero)




    End Sub
End Class