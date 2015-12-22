Imports System
Imports System.Object


Public Class LoginForm

    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See http://go.microsoft.com/fwlink/?LinkId=35339).  
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.

    Event DatosLogin(ByVal nombre As String)


    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click


        If UsernameTextBox.Text = "" Then

            MsgBox("Ingrese Nombre de Usuario", MsgBoxStyle.Information)
            Exit Sub
        End If

        If PasswordTextBox.Text = "" Then

            MsgBox("Ingrese Password", MsgBoxStyle.Information)
            Exit Sub
        End If

        Try
            Dim ds As New DataSet
            If standalone = True Then
                'Dim objlisa As New _ws_pos.POS
                '  ds = objlisa.AutentificacionWOP(Me.UsernameTextBox.Text, PasswordTextBox.Text)
            Else
                'Dim objpos As New WS_POS.POS
                'ds = objpos.ValidaUsuario(Me.UsernameTextBox.Text, PasswordTextBox.Text)

                Dim objlisa As New ws_pos.POS
                ds = objlisa.ValidaUsuario(Me.UsernameTextBox.Text, PasswordTextBox.Text)

            End If



            Dim dr As DataRow = ds.Tables(0).Rows(0)

            If dr(0).ToString.Substring(0, 1) <> "-" Then

                _usuario = dr(0).ToString
                Dim valores As String() = _usuario.Split(New Char() {"|"c})
                id_Cajero = Int32.Parse(valores.GetValue(0).ToString)
                _usuario = valores.GetValue(1).ToString
                Dim OBJLOG As New PosLog

                If ValidaRol(UsernameTextBox.Text) = False Then

                    MsgBox("No tiene Privilegios para accerder a la Aplicación", MsgBoxStyle.Exclamation)
                    Exit Sub
                End If



                Dim dsCajas As New DataSet
                Dim objPos As New ws_pos.Pos
                If standalone = True Then
                    ' Dim objPos As New _ws_pos.POS
                    ' dsCajas = objPos.POS_CAJAS(id_Cajero)
                Else

                    dsCajas = objPos.POS_CAJAS(id_Cajero, "?")

                End If


                Dim arreglo As New ArrayList
                Dim totalcajas As Integer = 0

                Dim obj As New ClsSesion
                obj.Sede = "-"
                obj.Caja = "Seleccione Caja"
                arreglo.Add(obj)

                For Each dr_ As DataRow In dsCajas.Tables(0).Rows
                    Dim i = _GetDeudores(dr_("Caja"))
                    totalcajas = totalcajas + 1
                    Dim objSesion As New ClsSesion
                    objSesion.Sede = dr_("Sede").ToString
                    objSesion.Caja = dr_("Caja").ToString
                    objSesion.NumeroLineas = _GetNumeroLineas(dr_("Caja"))
                    objSesion.PuertoTbk = _GetPuertoTBK(dr_("Caja"))
                    objSesion.Deudores =i
                    objSesion.Bodega = dr_("Bodega").ToString
                    objSesion.Ubicacion = dr_("Ubicacion").ToString
                    objSesion.Vendedor = dr_("CodVendedor").ToString
                    objSesion.CentroGestion = dr_("CentroGestion").ToString
                    objSesion.Ubicacion = dr_("Ubicacion").ToString
                    objSesion.Conceptoventa = dr_("ConceptoVenta").ToString()


                    arreglo.Add(objSesion)
                Next

                Dim cajaUsuario As String = ""
                If totalcajas = 1 Then
                    
                    Dim drcaja As DataRow = dsCajas.Tables(0).Rows(0)
                     Dim i = _GetDeudores(drcaja("Caja"))
                    cajaUsuario = drcaja("USR_ID").ToString
                    Me.DropCaja.Enabled = False
                    CajaPos = drcaja("CAJA").ToString
                    _CodigoVendedorDefecto = drcaja("CodVendedor").ToString
                    _NumeroLineas = _GetNumeroLineas(drcaja("CAJA").ToString)
                    _PuertoTbk = _GetPuertoTBK(drcaja("CAJA").ToString)
                    _Deudores =i
                    _Sede = drcaja("Sede").ToString
                    _Bodega = drcaja("Bodega").ToString
                    _PuntoFacturacion = drcaja("CAJA").ToString
                    _Pos = drcaja("CAJA").ToString
                    _VendedorDefecto = drcaja("CodVendedor").ToString
                    _CentrodeGestion = drcaja("CentroGestion").ToString
                    _Ubicacion = drcaja("Ubicacion").ToString
                    ConceptoVenta = drcaja("ConceptoVenta").ToString




                End If

                If totalcajas = 0 Then
                    MsgBox("para operar caja, debe tener una asignada, comuniquese con el departamento de informatica", MsgBoxStyle.Exclamation)
                    Exit Sub
                End If


                If totalcajas > 1 Then
                    If Me.DropCaja.SelectedValue = Nothing Then

                        Me.DropCaja.DataSource = arreglo
                        Me.DropCaja.DisplayMember = "CAJA"
                        Me.DropCaja.ValueMember = "CAJA"
                        Me.DropCaja.Enabled = True
                        Exit Sub

                    Else

                        Dim CodigoCaja As String = Me.DropCaja.SelectedValue

                        If Not IsNumeric(CodigoCaja) Then

                            MsgBox("Seleccione La Caja", MsgBoxStyle.Exclamation, "Steward")
                            Me.ErrorProvider1.SetError(Me.DropCaja, "Seleccione Caja")
                            Exit Sub
                        Else
                            'Cargo las variables correspondientes

                            Dim objsesion As ClsSesion = Me.DropCaja.SelectedItem
                            _CodigoVendedorDefecto = objsesion.Vendedor
                            CajaPos = objsesion.Caja
                            _PuntoFacturacion = objsesion.Caja
                            _NumeroLineas = objsesion.NumeroLineas
                            _PuertoTbk = objsesion.PuertoTbk
                            _Deudores = objsesion.Deudores
                            _Pos = objsesion.Caja
                            _VendedorDefecto = objsesion.Vendedor
                            _Sede = objsesion.Sede
                            _Bodega = objsesion.Bodega
                            _CentrodeGestion = objsesion.CentroGestion
                            _Ubicacion = objsesion.Ubicacion
                            ConceptoVenta = objsesion.Conceptoventa
                            OBJLOG.GuardaMvto("M", "Inicio de Sesion")
                        End If
                    End If


                End If

                Me.Close()

            Else
                MsgBox("Datos Incorrectos:" + dr(0).ToString, MsgBoxStyle.Information)
                Exit Sub

            End If
        Catch ex As Exception
            Dim objLog As New PosLog
            objLog.GuardaMvto("E", ex.ToString)
            objLog.ReportaError("LoginForm", "Logueo", ex.ToString)
        End Try




    End Sub

    Protected Function ValidaRol(ByVal Usuario As String) As Boolean
        Dim obj As New UsuarioController


        If obj.ValidaRolUsuario(Usuario, 260) Then
            Return True
        End If

        If obj.ValidaRolUsuario(Usuario, 261) Then
            Return True
        End If



        If obj.ValidaRolUsuario(Usuario, 2) Then
            Return True
        End If


        Return False

    End Function


    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click

        End
    End Sub

    Private Sub LoginForm1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim version = Reflection.Assembly.GetExecutingAssembly().GetName().Version
        Label2.Text = String.Format("Versión {0} - Fecha compilación 23 Septiembre 2015", version)

        


    End Sub

    Private Sub UsernameLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UsernameLabel.Click

    End Sub

    Private Sub UsernameTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UsernameTextBox.TextChanged

    End Sub

    Private Sub PasswordTextBox_TextChanged(sender As Object, e As EventArgs) Handles PasswordTextBox.TextChanged

    End Sub
End Class
