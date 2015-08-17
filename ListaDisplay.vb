Public Class ListaDisplay

    Public tipo As String
    Public arreglo As ArrayList
    Event ListaDisplay(ByVal tipo As String, ByVal codigo As String, ByVal descripcion As String)

    Private Sub ListaDisplay_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.ListBox1.DataSource = arreglo
        Me.ListBox1.DisplayMember = "Descripcion"
        Me.ListBox1.ValueMember = "Codigo"



    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged



        Dim objeto As ListaObj = Me.ListBox1.SelectedItem
        If objeto.Codigo <> "-" Then

            RaiseEvent ListaDisplay(tipo, objeto.Codigo, objeto.Descripcion)
            Me.Close()

        End If


    End Sub
End Class