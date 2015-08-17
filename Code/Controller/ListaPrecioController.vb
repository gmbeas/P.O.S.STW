Imports System.Xml

Public Class ListaPrecioController




    Public Function Getall() As ArrayList

        Dim cadena As String = "<Documento>" & _
        "<Documento_Empresa>" + _Empresa + "</Documento_Empresa>" & _
        "</Documento>"

        Dim arreglo As New ArrayList
        Dim resultado As String = ""

        If standalone = True Then
            Dim obj As New _apws0041.Pws0041
            resultado = obj.Execute(cadena)
        Else
            Dim obj As New apws0041.Pws0041
            resultado = obj.Execute(cadena)
        End If

        Dim docXML As New XmlDocument
        docXML.LoadXml(resultado)
        Dim listanodoSedes As XmlNodeList
        Dim nodo As XmlNode
        docXML.SelectNodes("/DefinicionRespuesta/Respuesta")
        If docXML.GetElementsByTagName("Respuesta").Count > 0 Then ' Existen Resultad
            listanodoSedes = docXML.SelectNodes("/DefinicionRespuesta/Respuesta/ListaPrecios")
            Dim x As Integer = listanodoSedes.Count
            For Each nodo In listanodoSedes

                Dim codigo As String = nodo.ChildNodes.Item(0).InnerText
                Dim descripcion As String = nodo.ChildNodes.Item(1).InnerText
                Dim objlista As New ListaObj
                objlista.Codigo = codigo
                objlista.Descripcion = descripcion
                arreglo.Add(objlista)

            Next


        End If
        Return arreglo

    End Function


    Public Function Valida(ByVal codigo As String) As Boolean

        Dim existe As Boolean = False

        For Each obj As ListaObj In Getall()

            If obj.Codigo = codigo Then
                existe = True
            End If

        Next

        Return existe

    End Function

End Class
