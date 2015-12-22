Public Class Promocion

    
    Event GeneraOferta(ByVal codigo As Boolean, ByVal nombre As String, ByVal rut As String, ByVal promo As String)

    Private Sub Promocion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ComboBox1.DisplayMember = "Key"
        Me.ComboBox1.ValueMember = "Value"
        Me.ComboBox1.Items.Add(New DictionaryEntry("Club Lectores la Tercera", "LaTercera"))
        Me.ComboBox1.Items.Add(New DictionaryEntry("Otros", "Otros"))
        me.ComboBox1.SelectedIndex = 0
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
       
         RaiseEvent GeneraOferta(True, TextBox1.Text.ToUpper(), TextBox2.Text.ToUpper(),Me.ComboBox1.SelectedItem.Value)
         Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
         RaiseEvent GeneraOferta(False, "","","")
         Me.Close()
    End Sub

    Private Sub Promocion_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
            
    End Sub
End Class