Public Class txtNroDoc

    Private Sub FrmReporte_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.RadActualizayConcilia.Checked = True
        CargarComboSede()
        CargarComboTipoDocumento()
        CargarComboMedioPago()
        CargaComboCaja()
        CargaComboCajero()
        drop_Sede.Text = ""
        dropCajero.Text = ""
        dropMedioPago.Text = ""
        dropTipoDocumento.Text = ""
        Me.radFechaDia.Checked = True
        Me.radFechaDia_CheckedChanged(sender, e)
    End Sub

    Protected Sub CargarComboSede()

        Dim objAyuda As New AyudaPosController
        Dim x As ArrayList = objAyuda.Sedes
        Me.drop_Sede.DataSource = x
        drop_Sede.DisplayMember = "Descripcion"
        drop_Sede.ValueMember = "Codigo"

    End Sub

    Protected Sub CargarComboTipoDocumento()

        Dim objAyuda As New AyudaPosController
        Me.dropTipoDocumento.DataSource = objAyuda.TiposDoc
        Me.dropTipoDocumento.DisplayMember = "Descripcion"
        Me.dropTipoDocumento.ValueMember = "Codigo"


    End Sub

    Protected Sub CargarComboMedioPago()

        Dim objAyuda As New AyudaPosController
        Me.dropMedioPago.DataSource = objAyuda.MediosPago
        Me.dropMedioPago.DisplayMember = "Descripcion"
        Me.dropMedioPago.ValueMember = "Codigo"

    End Sub

    Protected Sub CargaComboCaja()

        Dim objAyuda As New AyudaPosController
        Me.dropCaja.DataSource = objAyuda.Cajas
        Me.dropCaja.DisplayMember = "Descripcion"
        Me.dropCaja.ValueMember = "Codigo"


    End Sub


    Protected Sub CargaComboCajero()

        Dim objAyuda As New AyudaPosController

        Me.dropCajero.DataSource = objAyuda.Cajeros
        Me.dropCajero.DisplayMember = "Descripcion"
        Me.dropCajero.ValueMember = "Codigo"

    End Sub


    Private Sub btn_Ejecutar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Ejecutar.Click


        Dim ws_pos As New ws_pos.POS

        If IsNothing(dropCaja.SelectedText) Then
            MsgBox("Seleccione una Caja", MsgBoxStyle.Information, "Datos Requeridos")
        End If


        Dim Sede As String = ""
        Dim Cajero As String = ""
        Dim Caja As String = ""
        Dim TipoDoc As String = ""
        Dim MedioPago As String = ""
        Dim NroDoc As String = ""

        If Not IsNothing(drop_Sede.SelectedValue) Then
            Sede = drop_Sede.SelectedValue
        End If

        If Not IsNothing(dropCajero.SelectedValue) Then
            Cajero = dropCajero.SelectedValue
        End If

        If Not IsNothing(dropCaja.SelectedValue) Then
            Caja = dropCaja.SelectedValue
        End If

        If Not IsNothing(dropTipoDocumento.SelectedValue) Then
            TipoDoc = dropTipoDocumento.SelectedValue
        End If

        If Not IsNothing(dropMedioPago.SelectedValue) Then
            MedioPago = dropMedioPago.SelectedValue
        End If

        If Me.txt_Nro_Doc.Text <> "" Then
            NroDoc = txt_Nro_Doc.Text
        End If

        Dim tipo As String = ""


        If RadActualizayConcilia.Checked = True Then
            tipo = "ACP"
        End If

        If RadSoloConcilia.Checked = True Then
            tipo = "COP"
        End If

        If RadActualizaLisayPos.Checked = True Then
            tipo = "ATP"
        End If

        If RadSoloActualizaLisa.Checked = True Then
            tipo = "ALP"
        End If

        If RadSoloActualizaPos.Checked = True Then
            tipo = "APP"
        End If

        Dim ds As DataSet = ws_pos.POS_Concilia(tipo, FechaDesde.Value, FechaHasta.Value, Sede, Caja, Cajero, TipoDoc, MedioPago, NroDoc)
        Me.DataGridView1.DataSource = ds.Tables(0)

    End Sub

    Private Sub radFechaDia_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radFechaDia.CheckedChanged

        FechaHasta.Value = FechaDesde.Value


    End Sub

    Private Sub RadFechaMes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadFechaMes.CheckedChanged

        Dim fecha As DateTime = FechaDesde.Value
        Dim mes As String = fecha.Month


        Dim varfechadesde As Date
        varfechadesde = fecha.AddDays(-fecha.Day + 1)
        FechaDesde.Value = varfechadesde

        Dim varfechahasta As Date = fecha
        varfechahasta = varfechahasta.AddDays(-varfechahasta.Day + 1).AddMonths(1).AddDays(-1)

        FechaHasta.Value = varfechahasta



    End Sub




    Private Sub RadFechaAno_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadFechaAno.CheckedChanged
        Dim fecha As DateTime = FechaDesde.Value
        Dim mes As String = fecha.Month
        Dim ano As String = fecha.Year

        FechaDesde.Value = "01/01/" + ano

        Dim varfechahasta As Date = "01/12/" + ano
        varfechahasta = varfechahasta.AddDays(-varfechahasta.Day + 1).AddMonths(1).AddDays(-1)

        FechaHasta.Value = varfechahasta
    End Sub

 
End Class