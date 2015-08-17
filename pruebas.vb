Public Class pruebas

    Private Sub pruebas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
       Dim objws28 As New apws0028.Pws0028
        Dim pp = objws28.Execute()

    End Sub
End Class