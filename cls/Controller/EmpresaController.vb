﻿Imports Microsoft.VisualBasic
Imports System.Xml
Public Class EmpresaController

    Dim objWs033 As New wsBrowse.Pws0033
    Dim wsbrowseayudacaja As New wsBrowse.Pws0046
    Dim wsbrowseAyudaTipoTransporte As New wsBrowse.Pws0044


    Public Function GetSedes(ByVal CodigoEmpresa As String) As ArrayList
        Dim arreglo As New ArrayList

        Dim cadena As String = "<?xml version='1.0' encoding='utf-8'?>" & _
       "<Documento>" & _
       "<Documento_empresa>" + CodigoEmpresa + "</Documento_empresa>" & _
       "</Documento>"

        Dim resultado As String = objWs033.Execute(cadena)
        Dim docXML As New XmlDocument
        docXML.LoadXml(resultado)
        Dim listanodoSedes As XmlNodeList
        Dim nodo As XmlNode
        docXML.SelectNodes("/Respuesta")
        If docXML.GetElementsByTagName("Respuesta").Count > 0 Then ' Existen Resultad
            listanodoSedes = docXML.SelectNodes("/Respuesta/Sede")
             For Each nodo In listanodoSedes

                Dim codigo As String = nodo.ChildNodes.Item(0).InnerText
                Dim descripcion As String = nodo.ChildNodes.Item(1).InnerText
                Dim objSede As New SedeObj

                objSede.Codigo = codigo
                objSede.Descripcion = descripcion

                arreglo.Add(objSede)

            Next


        End If


        Return arreglo
    End Function


    Public Function GetCajas(ByVal CodigoEmpresa As String) As ArrayList
        Dim arreglo As New ArrayList

        Dim cadena As String = "<?xml version='1.0' encoding='utf-8'?>" & _
       "<Documento>" & _
       "<Documento_empresa>" + CodigoEmpresa + "</Documento_empresa>" & _
       "</Documento>"

        Dim resultado As String = wsbrowseayudacaja.Execute(cadena)
        Dim docXML As New XmlDocument
        docXML.LoadXml(resultado)
        Dim listanodoSedes As XmlNodeList
        Dim nodo As XmlNode
        docXML.SelectNodes("/Respuesta")
        If docXML.GetElementsByTagName("Respuesta").Count > 0 Then ' Existen Resultad
            listanodoSedes = docXML.SelectNodes("/Respuesta/Caja")
            For Each nodo In listanodoSedes

                Dim codigo As String = nodo.ChildNodes.Item(0).InnerText
                Dim descripcion As String = nodo.ChildNodes.Item(1).InnerText
                Dim objLista As New ListaObj

                objLista.Descripcion = descripcion

                arreglo.Add(objLista)

            Next


        End If


        Return arreglo
    End Function


    Public Function GetTipoTransporte(ByVal CodigoEmpresa As String) As ArrayList
        Dim arreglo As New ArrayList

        Dim resultado As String = wsbrowseAyudaTipoTransporte.Execute()
        Dim docXML As New XmlDocument
        docXML.LoadXml(resultado)
        Dim listanodoSedes As XmlNodeList
        Dim nodo As XmlNode
        docXML.SelectNodes("/Respuesta")
        If docXML.GetElementsByTagName("Respuesta").Count > 0 Then ' Existen Resultad
            listanodoSedes = docXML.SelectNodes("/Respuesta/TipoTransporte")
            For Each nodo In listanodoSedes

                Dim codigo As String = nodo.ChildNodes.Item(0).InnerText
                Dim descripcion As String = nodo.ChildNodes.Item(1).InnerText
                Dim objLista As New ListaObj

                objLista.Codigo = codigo
                objLista.Descripcion = descripcion

                arreglo.Add(objLista)

            Next


        End If


        Return arreglo
    End Function

End Class
