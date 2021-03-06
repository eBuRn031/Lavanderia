﻿Imports BE_LAVANDERIA
Imports DA_LAVANDERIA
Public Class FRM_CLIENTE
    Dim CODIGO As Integer
    Dim dts As New DataTable
    Private Sub BTN_NUEVO_Click(sender As Object, e As EventArgs) Handles BTN_NUEVO.Click
        FRM_CLIENTE_CRUD.Show()
        Me.Close()
    End Sub

    Private Sub BTN_SALIR_Click(sender As Object, e As EventArgs) Handles BTN_SALIR.Click
        Me.Close()
    End Sub

    Private Sub DGV_CLIENTES_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_CLIENTES.CellEnter
        CODIGO = Me.DGV_CLIENTES.CurrentRow.Cells.Item("CODIGO").Value.ToString()
    End Sub

    Private Sub BTN_EDITAR_Click(sender As Object, e As EventArgs) Handles BTN_EDITAR.Click
        If CODIGO <> Nothing Then
            VARIABLES_GLOBALES.ID_CLIENTE = CODIGO
            FRM_CLIENTE_CRUD.Show()
            Me.Close()
        End If
    End Sub

    Private Sub BTN_ELIMINAR_Click(sender As Object, e As EventArgs) Handles BTN_ELIMINAR.Click
        If CODIGO <> Nothing Then
            If MsgBox("¿REALEMENTE QUIERES ELIMINAR ESE CLIENTE?", MsgBoxStyle.YesNo) = vbYes Then
                Dim BEClientes As New BEClientes
                Dim DAClientes As New DAClientes
                Try
                    BEClientes.gid_cli = CODIGO
                    BEClientes.gusu_eli = VARIABLES_GLOBALES.ID_USUARIO
                    DAClientes.eliminar_Clientes(BEClientes)
                    MsgBox("CLIENTE ELIMINADO CORRECTAMENTE...!!")
                    CARGARDATAGRIDVIEW()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

            End If
        End If

    End Sub

    Private Sub FRM_CLIENTE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CARGARDATAGRIDVIEW()
        DGV_CLIENTES.Columns.Item(0).Visible = False
    End Sub

    Sub CARGARDATAGRIDVIEW()
        Try
            Dim DACargarDataGridView As New DACargarDataGridView
            dts = DACargarDataGridView.Mostrar_Clientes()
            If dts.Rows.Count <> 0 Then
                DGV_CLIENTES.DataSource = dts
            Else
                DGV_CLIENTES.DataSource = Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BTN_VER_Click(sender As Object, e As EventArgs) Handles BTN_VER.Click
        If CODIGO <> Nothing Then
            Dim FRM_CLIENTE_CRUD As New FRM_CLIENTE_CRUD
            VARIABLES_GLOBALES.ID_CLIENTE = CODIGO
            FRM_CLIENTE_CRUD.Button1.Enabled = False
            FRM_CLIENTE_CRUD.Button1.Visible = False
            FRM_CLIENTE_CRUD.TXT_APELLIDOS_MAT.Enabled = False
            FRM_CLIENTE_CRUD.TXT_APELLIDOS_PAT.Enabled = False
            FRM_CLIENTE_CRUD.TXT_CELULAR.Enabled = False
            FRM_CLIENTE_CRUD.TXT_CORREO.Enabled = False
            FRM_CLIENTE_CRUD.TXT_DOCUMENTO.Enabled = False
            FRM_CLIENTE_CRUD.TXT_NOMBRES.Enabled = False
            FRM_CLIENTE_CRUD.TXT_TELEFONO.Enabled = False
            FRM_CLIENTE_CRUD.GroupBox1.Enabled = False
            FRM_CLIENTE_CRUD.DateTimePicker1.Enabled = False
            FRM_CLIENTE_CRUD.ComboBox1.Enabled = False

            FRM_CLIENTE_CRUD.Show()
            Me.Close()
        End If

    End Sub

    Private Sub BTN_BUSCAR_Click(sender As Object, e As EventArgs) Handles BTN_BUSCAR.Click
        If RB_NOMBRES.Checked = True Then
            CARGARBUSQUEDANOMBRE()
        End If

        If RB_DNI.Checked = True Then
            CARGARBUSQUEDADNI()
        End If

    End Sub

    Sub CARGARBUSQUEDANOMBRE()
        Try
            Dim DACargarDataGridView As New DACargarDataGridView
            dts = DACargarDataGridView.Mostrar_Clientes_Busqueda(TXT_BUSQUEDA.Text)
            If dts.Rows.Count <> 0 Then
                DGV_CLIENTES.DataSource = dts
            Else
                DGV_CLIENTES.DataSource = Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub CARGARBUSQUEDADNI()
        Try
            Dim DACargarDataGridView As New DACargarDataGridView
            dts = DACargarDataGridView.Mostrar_Clientes_DNI_Busqueda(TXT_BUSQUEDA.Text)
            If dts.Rows.Count <> 0 Then
                DGV_CLIENTES.DataSource = dts
            Else
                DGV_CLIENTES.DataSource = Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

End Class