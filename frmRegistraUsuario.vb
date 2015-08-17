
Imports Microsoft.VisualBasic
Imports System.Text.RegularExpressions
Imports System

Public Class frmRegistraUsuario



    Private Sub frmRegistraUsuario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargarTipoCLiente()
        CargarComboGiro()
        cargarComboRegion()



    End Sub



    Protected Sub cargarComboRegion()
        Dim objregion As New RegionesController

        Me.ComboRegion.DataSource = objregion.Regiones("[SELECCIONAR]")
        Me.ComboRegion.DisplayMember = "DESCRIPCION"
        Me.ComboRegion.ValueMember = "CODIGO"

    End Sub


    Protected Sub cargarComboCiudad(ByVal codigoRegion As String)
        Dim objCiudad As New CiudadController

        Me.ComboCiudad.DataSource = objCiudad.GetCiudad(codigoRegion, "[SELECCIONAR]")
        Me.ComboCiudad.DisplayMember = "DESCRIPCION"
        Me.ComboCiudad.ValueMember = "CODIGO"

    End Sub

    Protected Sub cargarComboComuna(ByVal codigoRegion As String, ByVal codigociudad As String)
        Dim objComuna As New ComunasController

        Me.ComboComuna.DataSource = objComuna.GetComunas(codigoRegion, codigociudad, "[SELECCIONAR]")
        Me.ComboComuna.DisplayMember = "DESCRIPCION"
        Me.ComboComuna.ValueMember = "CODIGO"

    End Sub



    Protected Sub CargarComboGiro()
        Dim objCliente As New ClientesController
        Me.ComboGiroComercial.DataSource = objCliente.Giros
        Me.ComboGiroComercial.DisplayMember = "Descripcion"
        Me.ComboGiroComercial.ValueMember = "Codigo"

    End Sub

    Protected Sub CargarTipoCLiente()

        Dim ARR As New ArrayList
        Dim obj As New ListaObj
        obj.Codigo = "P"
        obj.Descripcion = "PERSONA"

        Dim obj2 As New ListaObj
        obj2.Codigo = "E"
        obj2.Descripcion = "EMPRESA"

        ARR.Add(obj)
        ARR.Add(obj2)

        Me.dropTipo.DataSource = ARR
        Me.dropTipo.DisplayMember = "Descripcion"
        Me.dropTipo.ValueMember = "Codigo"
    End Sub

    Private Sub btnRegistrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegistrar.Click
        ErrorProvider1.Clear()


        If txtRut.Text = "" Then
            Me.ErrorProvider1.SetError(Me.txtRut, "Obligatorio")
            Exit Sub
        End If


        If txtNombre.Text = "" Then
            Me.ErrorProvider1.SetError(Me.txtNombre, "Obligatorio")
            Exit Sub
        End If

        If txtDetalleDireccion.Text = "" Then
            Me.ErrorProvider1.SetError(Me.txtDetalleDireccion, "Obligatorio")
            Exit Sub
        End If

        If ComboRegion.SelectedValue = "" Then
            Me.ErrorProvider1.SetError(Me.ComboRegion, "Obligatorio")
            Exit Sub
        End If

        If ComboCiudad.SelectedValue = "" Then
            Me.ErrorProvider1.SetError(Me.ComboCiudad, "Obligatorio")
            Exit Sub
        End If


        If ComboComuna.SelectedValue = "" Then
            Me.ErrorProvider1.SetError(Me.ComboComuna, "Obligatorio")
            Exit Sub
        End If
        Dim objCliente As New ClientesController


        Dim RUT As String = txtRut.Text.ToString.Replace("-", "")
        Dim largo As Integer = RUT.Length
        Dim dv As String = RUT.Substring(largo - 1, 1)
        RUT = RUT.Remove(largo - 1, 1)
        Dim giro As String = Me.ComboGiroComercial.SelectedValue

        Try
            objCliente.RegistroCliente(RUT, dv, UCase(txtNombre.Text), giro, dropTipo.SelectedValue)
            objCliente.RegistraDireccionCliente(RUT, UCase(txtDetalleDireccion.Text), ComboRegion.SelectedValue, ComboCiudad.SelectedValue, ComboComuna.SelectedValue)
            MsgBox("Registro Ingresado", MsgBoxStyle.Information, "STEWARD")
            Me.Close()
        Catch ex As Exception
            Dim objLog As New PosLog
            objLog.GuardaMvto("E", ex.ToString)
            objLog.ReportaError("frmRegistraUsuario.vb", "btnregistrar(click)", ex.ToString)
        End Try
        'objCliente.RegistraDireccion888(RUT)

    End Sub



   
    Private Sub ComboRegion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboRegion.SelectedIndexChanged

        Dim valor As String = ComboRegion.SelectedValue.ToString


        If valor.ToString.Contains(".") = False Then

            cargarComboCiudad(ComboRegion.SelectedValue)

        End If


    End Sub

 
    Private Sub ComboCiudad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboCiudad.SelectedIndexChanged
        Dim valor As String = ComboCiudad.SelectedValue.ToString

        If valor.ToString.Contains(".") = False Then

            cargarComboComuna(Me.ComboRegion.SelectedValue, Me.ComboCiudad.SelectedValue)

        End If
    End Sub

    
End Class