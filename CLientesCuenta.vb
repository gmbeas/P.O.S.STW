Imports StewardLib


Public Class CLientesCuenta
    Dim objVal As New STWVal
    Event TraeVenta(ByVal documento As String)
    Event SaldoPorPagar(ByVal documentos As ArrayList, ByVal saldo As Double, ByVal rut As String, ByVal nombre As String)

    Private Sub GroupBox2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub


    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click


        If objVal.ValidaRut(txtRut.Text) = True Then
            Dim rut As Integer = txtRut.Text.Remove(txtRut.Text.Length - 2, 2)
            Dim objcliente As New ClientesController
            Dim obj As FichaCobranzaObj = objcliente.EstadoFinanciero(rut.ToString)
            If obj.rut <> 0 Then
                Me.txtRut_.Text = txtRut.Text
                Me.txtNombre.Text = obj.Nombre
                Me.txtSaldoPorPagar.Text = obj.SaldoxPagar
                Me.TxtTotalAbonos.Text = obj.Abonos
                Me.txtTotalCargo.Text = obj.Cargos
                Me.GridDocumentos.DataSource = TraeDocumentos("PENDIENTES", obj.Documentos)
                ' AplicaSeparadoresMil()
            Else
                MsgBox("no se ha encontrado información")
            End If

        End If







    End Sub


    Public Function TraeDocumentos(ByVal Tipo As String, ByVal documentos As ArrayList) As ArrayList
        Dim arreglo As New ArrayList


        If Tipo = "PENDIENTES" Then

            For Each objDoc As DocumentoCobranzaObj In documentos

                If objDoc.SaldoXPagar <> 0 Then
                    arreglo.Add(objDoc)
                End If

            Next
        End If


        Return arreglo

    End Function

    Protected Sub AplicaSeparadoresMil()

        ' Me.GridDocumentos.Columns("SaldoXPagar").Visible = False

        For Each gr As DataGridViewRow In Me.GridDocumentos.Rows
            gr.Cells("SaldoXPagar").Value = Int32.Parse(gr.Cells("SaldoXPagar").Value).ToString("N0")

        Next


    End Sub

    Private Sub GroupBox2_Enter_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub CLientesCuenta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub GridDocumentos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridDocumentos.CellContentClick
        If e.RowIndex <> -1 Then
            'Dim fila As DataGridViewRow = Me.GridDocumentos.Rows(e.RowIndex)
            'RaiseEvent TraeVenta(fila.Cells("NumeroDocumento").Value)
        End If

    End Sub

    Private Sub btn_Aplicar_Pago_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Aplicar_Pago.Click

        Dim saldoPorPagar As Double = 0
        Dim documentos As New ArrayList

        Dim contador As Integer = 0
        For Each grow As DataGridViewRow In Me.GridDocumentos.Rows

            If grow.Cells(0).Value = True Then
                contador = contador + 1

                saldoPorPagar = grow.Cells("SaldoXPagar").Value + saldoPorPagar
                If saldoPorPagar <> 0 Then
                    Dim doc As New DocumentoObj
                    doc.Folio = grow.Cells("numerodocumento").Value
                    doc.TipoDocumento = grow.Cells("TipoDocumento").Value
                    doc.SaldoXPagar = grow.Cells("SaldoXPagar").Value
                    documentos.Add(doc)
                Else
                    MsgBox("El Documento:" + grow.Cells("numerodocumento").Value.ToString + " ya Esta Saldado")
                End If
            End If


        Next
        If documentos.Count <> 0 Then
            RaiseEvent SaldoPorPagar(documentos, saldoPorPagar, Me.txtRut_.Text, Me.txtNombre.Text)
            Me.Close()
        End If

    End Sub

    Private Sub txtRut_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRut.KeyDown

        If e.KeyValue = Keys.Enter Then

            If txtRut.Text = "" Then
                Dim xBusquedaCliente As New FormBusquedaClientes
                xBusquedaCliente.txtBusqueda.Text = ""
                xBusquedaCliente.txtBusqueda.Focus()
                xBusquedaCliente.ShowDialog()
            End If

            If txtRut.Text.Length = 7 Or txtRut.Text.Length = 8 Then

                Dim dv As String = _digitoverificador(Int32.Parse(txtRut.Text))
                Dim rut As String = txtRut.Text + "-" + dv
                If objVal.ValidaRut(rut) = True Then
                    Me.txtRut.Text = rut
                End If

            End If

            btnBuscar_Click(sender, e)


        End If

    End Sub

    Private Sub txtRut_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRut.KeyPress

    End Sub

    Private Sub txtRut_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRut.TextChanged

    End Sub
End Class