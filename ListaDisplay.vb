Imports System.Web.UI.WebControls
Imports System.Windows.Forms.VisualStyles

Public Class ListaDisplay

    Public tipo As String
    Public arreglo As ArrayList
    Event ListaDisplay(ByVal tipo As String, ByVal codigo As String, ByVal descripcion As String)

    Private Sub ListaDisplay_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

       
        Me.ListBox1.DataSource = arreglo
        Me.ListBox1.DisplayMember = "Descripcion"
        Me.ListBox1.ValueMember = "Codigo"
        Me.ListBox1.Visible = False
        ListBox2.Items.Clear()

       For Each i As ListaObj In ListBox1.Items
           
            ListBox2.Items.Add(New ListItem(i.Descripcion, i.Codigo))
        Next



    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged   

        'Dim objeto As ListaObj = Me.ListBox1.SelectedItem
        'If objeto.Codigo <> "-" Then

        '    RaiseEvent ListaDisplay(tipo, objeto.Codigo, objeto.Descripcion)
        '    Me.Close()

        'End If


    End Sub
   


    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        ListBox2.Items.Clear()
        For Each i As ListaObj In ListBox1.Items
            If i.Descripcion.ToUpper().contains(TextBox1.Text.ToUpper()) Then
                ListBox2.Items.Insert(0, New ListItem(i.Descripcion, i.Codigo))
            End If
        Next
        
    End Sub

    Private Sub ListBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox2.SelectedIndexChanged

        Dim objeto  = Me.ListBox2.SelectedItem.Value
        Dim objeto2  = Me.ListBox2.SelectedItem.Text
        'If objeto.Codigo <> "-" Then

        TextBox1.Text = String.Empty
        RaiseEvent ListaDisplay(tipo, objeto, objeto2)
        Me.Close()

        'End If
    End Sub
End Class