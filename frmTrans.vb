Imports TbkLibSTW
Imports TbkLibSTW.Models

Public Class frmTrans
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        LibTbk.Configura(_PuertoTbk)
        Dim respuesta = LibTbk.CargaLlaves()
        If(respuesta.Conexion = True)
            TextBox1.Text = respuesta.DatosLlave.CodigoDescripcion
            TextBox2.Text = respuesta.DatosLlave.CodigoComercio
            TextBox3.Text = respuesta.DatosLlave.TerminalId
            If Not respuesta.DatosLlave.Codigo.Equals("00")
                   MessageBox.Show(respuesta.DatosLlave.CodigoDescripcion)
            End If
            Else 
            MessageBox.Show(respuesta.ConexionDescripcion)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
         LibTbk.Configura(_PuertoTbk)
        Dim respuesta = LibTbk.CierreCaja(Comprobante.Si)
        If(respuesta.Conexion = True)
            TextBox6.Text = respuesta.DatosCierre.CodigoDescripcion
            TextBox5.Text = respuesta.DatosCierre.CodigoComercio
            TextBox4.Text = respuesta.DatosCierre.TerminalId
             If Not respuesta.DatosCierre.Codigo.Equals("00")
                   MessageBox.Show(respuesta.DatosCierre.CodigoDescripcion)
            End If
            Else 
            MessageBox.Show(respuesta.ConexionDescripcion)
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
         If TextBox10.Text <> ""
              LibTbk.Configura(_PuertoTbk)
        Dim respuesta = LibTbk.AnulaVentaPos(TextBox10.Text.Trim())
        If(respuesta.Conexion = True)
            TextBox9.Text = respuesta.DatosAnulacion.CodigoDescripcion
            TextBox8.Text = respuesta.DatosAnulacion.CodigoComercio
            TextBox7.Text = respuesta.DatosAnulacion.TerminalId
            TextBox11.Text = respuesta.DatosAnulacion.CAutorizacion
            TextBox12.Text = respuesta.DatosAnulacion.NOperacion
            If Not respuesta.DatosAnulacion.Codigo.Equals("00")
                   MessageBox.Show(respuesta.DatosAnulacion.CodigoDescripcion)
            End If
            Else 
            MessageBox.Show(respuesta.ConexionDescripcion)
        End If
            Else 
            MessageBox.Show("Ingrese documento a anular")
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
         LibTbk.Configura(_PuertoTbk)
        Dim respuesta = LibTbk.UltimaVenta(Comprobante.No)
        If(respuesta.Conexion = True)
            TextBox14.Text = respuesta.DatosUltimaVenta.CodigoDescripcion
            TextBox13.Text = respuesta.DatosUltimaVenta.CodigoComercio
            TextBox16.Text = respuesta.DatosUltimaVenta.TerminalId
            TextBox17.Text = respuesta.DatosUltimaVenta.CAutorizacion
            TextBox18.Text = respuesta.DatosUltimaVenta.Monto
            TextBox19.Text = respuesta.DatosUltimaVenta.MontoCuota

            TextBox20.Text = respuesta.DatosUltimaVenta.MontoCuota
            TextBox21.Text = respuesta.DatosUltimaVenta.U4Digitos
            TextBox22.Text = respuesta.DatosUltimaVenta.NOperacion
            TextBox23.Text = respuesta.DatosUltimaVenta.TipoTarjeta
            TextBox24.Text = respuesta.DatosUltimaVenta.FechaContable
            TextBox25.Text = respuesta.DatosUltimaVenta.NCuenta
            TextBox26.Text = respuesta.DatosUltimaVenta.AbrevTarjeta
            TextBox27.Text = respuesta.DatosUltimaVenta.FechaTransaccion
            TextBox30.Text = respuesta.DatosUltimaVenta.HoraTransaccion

            If Not respuesta.DatosUltimaVenta.Codigo.Equals("00")
                   MessageBox.Show(respuesta.DatosUltimaVenta.CodigoDescripcion)
            End If
            Else 
            MessageBox.Show(respuesta.ConexionDescripcion)
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        LibTbk.Configura(_PuertoTbk)
        Dim respuesta = LibTbk.TotalesVenta(Comprobante.No)
        If(respuesta.Conexion = True)
            TextBox29.Text = respuesta.DatosTotal.NumeroTransacciones
            TextBox28.Text = respuesta.DatosTotal.Total
            
            If Not respuesta.DatosTotal.Codigo.Equals("00")
                   MessageBox.Show(respuesta.DatosTotal.CodigoDescripcion)
            End If
            Else 
            MessageBox.Show(respuesta.ConexionDescripcion)
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        LibTbk.Configura(_PuertoTbk)
        Dim respuesta = LibTbk.CambiaModalidad()
        If respuesta = True
               MessageBox.Show("Correcto cambio modalidad")
            Else 
               MessageBox.Show("Error de comunicacion cambio modalidad")
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
         LibTbk.Configura(_PuertoTbk)
        Dim respuesta = LibTbk.Pooling()
        If respuesta = True
               MessageBox.Show("Correcta comunicación Pooling")
            Else 
               MessageBox.Show("Error de comunicación Pooling")
        End If
    End Sub
End Class