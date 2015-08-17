Public Class direccionFacturacion

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub direccionFacturacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim objdir As DireccionObj = _direccionFacturacion
        Me.TextBox1.Text = objdir.Direccion.TrimEnd

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Me.TextBox1.Text <> "" Then
            If Me.TextBox1.Text.Length <= 51 Then
                Dim objdir As DireccionObj = _direccionFacturacion
                objdir.Direccion = Me.TextBox1.Text
                _direccionFacturacion = objdir

                Me.Close()
            Else
                Dim dif As Integer = Int32.Parse(TextBox1.Text.Length)
                dif = dif - 50

                MsgBox("ha superado el limite, quite " + dif.ToString + " caracteres menos")
            End If

        Else
            MsgBox("Ingrese Valor")
        End If
    End Sub
End Class