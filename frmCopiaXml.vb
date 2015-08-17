Imports System.IO

Public Class frmCopiaXml

    Private Sub frmCopiaXml_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fechaArchivos.Value = DateTime.Now
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        lblEstado.Text = "Enviando XML al servidor"
        lblEstado.Visible = True

        Dim fechaRecopilacion = fechaArchivos.Value.ToShortDateString()

        Dim di As New DirectoryInfo(_RutaRespaldoXml)
        ' Get a reference to each file in that directory.
        Dim fiArr As FileInfo() = di.GetFiles()
        Dim contador = 0
        ' Display the names of the files.
        Dim fri As FileInfo
        For Each fri In fiArr
            Dim archivo = fri.FullName
            Dim fileCreateDate As DateTime = Convert.ToDateTime(File.GetCreationTime(archivo))

            If (fileCreateDate.ToShortDateString() = fechaRecopilacion) Then
                Try
                    'Dim valorRetorno = FtpClient.UploadFile(archivo, "ftp://" + _GetDatoFtp("POS_FTP_IP") + "/POS" + Pos.txtNroCaja.Text + "/" + fri.Name, _GetDatoFtp("POS_FTP_USER"), _GetDatoFtp("POS_FTP_PASS"))

                    Dim valorRetorno = FtpClient.UploadFileFtp("POS" + Pos.txtNroCaja.Text, archivo, fri.Name)

                    contador = contador + 1
                Catch ex As Exception
                    MessageBox.Show(ex.ToString())
                End Try

            End If

        Next fri

        lblEstado.Text = "FINALIZADO XML al servidor, se movieron " + contador.ToString() + " xml"
    End Sub
End Class