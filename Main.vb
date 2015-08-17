Public Class Main

    Private Sub Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim formLogin As New LoginForm
        formLogin.Parent = Me.MdiParent
        formLogin.ShowDialog()

    End Sub
End Class