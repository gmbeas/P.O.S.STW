Imports System.IO
Imports System.Web.UI.WebControls
Imports System.Xml

Public Class PendientesDialog

    Event RecuperaVenta(ByVal documento As String)



    Private Sub Dialog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim objws As New ws_pos.Pos
        Try
            Dim objController As New PendientesController
            Dim pp = objController.GetPendientes(_Sede, _PuntoFacturacion)
            Me.ListBox1.DataSource = objController.GetPendientes(_Sede, _PuntoFacturacion)
            Me.ListBox1.DisplayMember = "descripcion"
            Me.ListBox1.ValueMember = "Codigo"

            ListBox2.Items.Clear()

           For Each i As ListaObj In ListBox1.Items
           
                ListBox2.Items.Add(New ListItem(i.Descripcion, i.Codigo))
            Next

        Catch ex As Exception
            MsgBox("Error", MsgBoxStyle.Information, "Error")
        End Try


    End Sub

    Private Sub btnRojo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btnAzul_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ListBox1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox1.Click
       
    End Sub


    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged

    End Sub

    Private Sub ListBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox2.SelectedIndexChanged
         Dim respuesta = String.Empty
        Dim documento = Me.ListBox2.SelectedItem.Value
        Dim docux = Me.ListBox2.SelectedItem.Text

        Dim objController As New PendientesController
        Dim ruta As String = _RutaRespaldoXml + documento

        If Not File.Exists(ruta) Then

            Dim pp = objController.GetPendientes(_Sede, _PuntoFacturacion)
            For Each o As ListaObj In pp
                If o.Descripcion.Trim() = docux.Trim() Then
                    respuesta = o.Codigo_Padre
                End If
            Next
        Else
            Dim doc = New XmlDocument()
            doc.Load(ruta)
            respuesta = doc.OuterXml
            'this.textBox1.Text = doc.OuterXml;

        End If

        RaiseEvent RecuperaVenta(respuesta)
        Me.Close()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        ListBox2.Items.Clear()
        For Each i As ListaObj In ListBox1.Items
            If i.Descripcion.ToUpper().contains(TextBox1.Text.ToUpper()) Then
                ListBox2.Items.Insert(0, New ListItem(i.Descripcion, i.Codigo))
            End If
        Next
    End Sub
End Class