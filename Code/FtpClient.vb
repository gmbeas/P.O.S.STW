Public Class FtpClient
    Public Shared Function UploadFileFtp(carpeta As String, origen As String, archivo As String) As Boolean

        Dim ftp As New Chilkat.Ftp2()

        Dim success As Boolean

        '  Any string unlocks the component for the 1st 30-days.
        success = ftp.UnlockComponent("FTP287654321_5DB0FA8FoH0V")
        If (success <> True) Then
            Return False
        End If


        ftp.Hostname = _GetDatoFtp("POS_FTP_IP")
        ftp.Username = _GetDatoFtp("POS_FTP_USER")
        ftp.Password = _GetDatoFtp("POS_FTP_PASS")

        '  The default data transfer mode is "Active" as opposed to "Passive".

        '  Connect and login to the FTP server.
        success = ftp.Connect()
        If (success <> True) Then
            Return False
        End If


        '  Change to the remote directory where the file will be uploaded.
        success = ftp.ChangeRemoteDir(carpeta)
        If (success <> True) Then
            Return False
        End If


        '  Upload a file.
        Dim localFilename As String
        localFilename = origen
        Dim remoteFilename As String
        remoteFilename = archivo

        success = ftp.PutFile(localFilename, remoteFilename)
        If (success <> True) Then
            Return False
        End If


        ftp.Disconnect()
        Return True
    End Function



    ''' <summary>
    ''' Methods to upload file to FTP Server
    ''' </summary>
    ''' <param name="fileName">local source file name</param>
    ''' <param name="uploadPath">Upload FTP path including Host name</param>
    ''' <param name="ftpUser">FTP login username</param>
    ''' <param name="ftpPass">FTP login password</param>

    Public Shared Function UploadFile(ByVal fileName As String, ByVal uploadPath As String, ByVal ftpUser As String, ByVal ftpPass As String) As Boolean
        Dim fileInfo As New IO.FileInfo(fileName)

        ' Create FtpWebRequest object from the Uri provided
        Dim ftpWebRequest As Net.FtpWebRequest = CType(Net.FtpWebRequest.Create(New Uri(uploadPath)), Net.FtpWebRequest)

        ' Provide the WebPermission Credintials
        ftpWebRequest.Credentials = New Net.NetworkCredential(ftpUser, ftpPass)

        ' By default KeepAlive is true, where the control connection is not closed
        ' after a command is executed.
        ftpWebRequest.KeepAlive = False

        ' set timeout for 20 seconds
        ftpWebRequest.Timeout = 20000

        ' Specify the command to be executed.
        ftpWebRequest.Method = System.Net.WebRequestMethods.Ftp.UploadFile

        ' Specify the data transfer type.
        ftpWebRequest.UseBinary = True

        ' Notify the server about the size of the uploaded file
        ftpWebRequest.ContentLength = fileInfo.Length

        ' The buffer size is set to 2kb
        Const buffLength As Integer = 2048
        Dim buff(buffLength - 1) As Byte

        ' Opens a file stream (System.IO.FileStream) to read the file to be uploaded
        Dim fileStream As IO.FileStream = fileInfo.OpenRead()

        Try
            ' Stream to which the file to be upload is written
            Dim stream As IO.Stream = ftpWebRequest.GetRequestStream()

            ' Read from the file stream 2kb at a time
            Dim contentLen As Integer = fileStream.Read(buff, 0, buffLength)

            ' Till Stream content ends
            Do While contentLen <> 0
                ' Write Content from the file stream to the FTP Upload Stream
                stream.Write(buff, 0, contentLen)
                contentLen = fileStream.Read(buff, 0, buffLength)
            Loop

            ' Close the file stream and the Request Stream
            stream.Close()
            stream.Dispose()
            fileStream.Close()
            fileStream.Dispose()
            Return True
        Catch ex As Exception

            MessageBox.Show(ex.Message, "Upload Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
End Class
