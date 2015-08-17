Imports System.Runtime.InteropServices


Public Class CIniClass

    Private m_Ini As String

    Private Declare Function GetPrivateProfileStringKey Lib "kernel32" Alias _
    "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal _
    lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString _
    As String, ByVal nSize As Integer, ByVal lpFileName As String) As Integer

    Private Declare Function WritePrivateProfileString Lib "kernel32" Alias _
    "WritePrivateProfileStringA" (ByVal lpApplicationName As String, ByVal _
    lpKeyName As String, ByVal lpString As String, ByVal lpFileName As String) As Integer

    Property Archivo() As String
        Get
            Archivo = m_Ini
        End Get
        Set(ByVal value As String)
            m_Ini = value
        End Set
    End Property

    'Leer una llave de un archivo .ini
    Public Function LeeIni(ByVal Seccion As String, ByVal Llave As String) As String

        Dim lret As Long
        Dim ret As String

        ret = New String(CChar(" "), 255)

        lret = GetPrivateProfileStringKey(Seccion, Llave, "", ret, Len(ret), m_Ini)

        If InStr(ret, Chr(0)) Then
            ret = Left$(ret, Len(ret) - 1)
        End If

        Return ret

    End Function

    Private Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnSring As String, ByVal nSize As Integer, ByVal lpFileName As String) As Integer


    Public Function Readini(ByRef FileName As String, ByRef lpSectName As String, ByRef lpKeyName As String) As String
      
        Dim lpDefault As String
        Dim temp As New String(Chr(0), 400)
        Dim X As Integer
        lpDefault = "Unknown"
        X = GetPrivateProfileString(lpSectName, lpKeyName, lpDefault, temp, Len(temp), FileName)
        Readini = Left(temp, X)
    End Function


    'grabar una llave a un archivo ini
    Public Sub GrabaIni(ByVal Seccion As String, ByVal Llave As String, ByVal Valor As String)

        Dim lret As Long

        lret = WritePrivateProfileString(Seccion, Llave, Valor, m_Ini)

    End Sub
End Class


