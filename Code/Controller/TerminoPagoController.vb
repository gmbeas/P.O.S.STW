Imports Microsoft.VisualBasic
Imports System.Xml

Public Class TerminoPagoController

    Dim obj30 As New apws0030.Pws0030




    Public Function GetTerminoTarjetaCredito_() As ArrayList
        Dim ds As New DataSet

        If standalone = True Then
            Dim objWsLisa As New _WS_LISA.WS_Lisa
            ds = objWsLisa.ConsultaTerminosDePago("MPT")

        Else
            Dim objWsLisa As New ws_lisa.WS_Lisa
            ds = objWsLisa.ConsultaTerminosDePago("MPT")

        End If

        Dim arreglo As New ArrayList



        For Each dr As DataRow In ds.Tables(0).Rows
            Dim obj As New ListaObj

            obj.Codigo = dr(0).ToString
            obj.Descripcion = dr(1).ToString
            arreglo.Add(obj)
        Next

        Return arreglo

    End Function

    Public Function GetTerminoCheque_old() As ArrayList
        Dim arreglo As New ArrayList
        Dim ds As New DataSet

        If standalone = True Then

            Dim objWsLisa As New _WS_LISA.WS_Lisa
            ds = objWsLisa.ConsultaTerminosDePago("MPC")
        Else
            Dim objWsLisa As New ws_lisa.WS_Lisa
            ds = objWsLisa.ConsultaTerminosDePago("MPC")

        End If


        Dim objSel As New ListaObj
        objSel.Codigo = "-"
        objSel.Descripcion = "[SELECCIONAR]"
        arreglo.Add(objSel)

        For Each dr As DataRow In ds.Tables(0).Rows
            Dim objLista As New ListaObj
            objLista.Codigo = dr(0).ToString
            objLista.Descripcion = dr(1).ToString
            arreglo.Add(objLista)
        Next

        Return arreglo
    End Function


    Public Function GetTerminoCheque() As ArrayList
        Dim arreglo As New ArrayList

        Dim terminos As String() = _TerminosCheque.Split(New Char() {","c})

        ' Use For Each loop over words and display them
        Dim obj1 As New ListaObj
        obj1.Codigo = "-"
        obj1.Descripcion = "[SELECCIONAR]"
        arreglo.Add(obj1)

        For Each fragmento As String In terminos
            Dim obj As New ListaObj

            Dim valores As String() = fragmento.Split(New Char() {"-"c})
            obj.Codigo = valores.GetValue(0).ToString
            obj.Descripcion = valores.GetValue(1).ToString

            arreglo.Add(obj)
        Next

  

        Return arreglo
    End Function


    Public Function GetTerminoTarjetaCredito() As ArrayList
        Dim arreglo As New ArrayList

        Dim terminos As String() = _TerminosTarjetaCredito.Split(New Char() {","c})

        ' Use For Each loop over words and display them
        Dim obj1 As New ListaObj
        obj1.Codigo = "-"
        obj1.Descripcion = "[SELECCIONAR]"
        arreglo.Add(obj1)

        For Each fragmento As String In terminos
            Dim obj As New ListaObj
            Dim valores As String() = fragmento.Split(New Char() {"-"c})
            obj.Codigo = valores.GetValue(0).ToString
            obj.Descripcion = valores.GetValue(1).ToString
            arreglo.Add(obj)
        Next

        Return arreglo
    End Function

    
End Class
