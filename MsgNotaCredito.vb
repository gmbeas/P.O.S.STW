Public Class MsgNotaCredito


    Public ds As DataSet

    Private Sub MsgNotaCredito_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.DataGridView1.DataSource = ds.Tables(0)

    End Sub

End Class