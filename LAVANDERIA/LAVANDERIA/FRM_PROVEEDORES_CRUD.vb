﻿Imports BE_LAVANDERIA
Imports DA_LAVANDERIA
Public Class FRM_PROVEEDORES_CRUD
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles BTN_SALIR.Click
        VARIABLES_GLOBALES.ID_PROVEEDOR = Nothing
        FRM_PROVEEDORES.Show()
        Me.Close()
    End Sub

    Private Sub BTN_ACEPTAR_Click(sender As Object, e As EventArgs) Handles BTN_ACEPTAR.Click
        Dim BEProveedores As New BEProveedores
        Dim DAProveedores As New DAProveedores

        If VARIABLES_GLOBALES.ID_PROVEEDOR = Nothing Then
            BEProveedores.grazon_social = TXT_RAZON_SOCIAL.Text
            BEProveedores.gruc = TXT_RUC.Text
            BEProveedores.gcelular = TXT_CELULAR.Text
            BEProveedores.gtelefono = TXT_TELEFONO.Text
            BEProveedores.gcorreo = TXT_CORREO.Text
            BEProveedores.gusu_reg = VARIABLES_GLOBALES.ID_USUARIO

            If DAProveedores.insertar_Proveedores(BEProveedores) Then
                MsgBox("PROVEEDOR GUARDADO CORRECTAMENTE..!!")
            Else
                MsgBox("ERROR AL GUARDAR PROVEEDOR...")
            End If

        Else
            BEProveedores.gid_proveedor = VARIABLES_GLOBALES.ID_PROVEEDOR
            BEProveedores.grazon_social = TXT_RAZON_SOCIAL.Text
            BEProveedores.gruc = TXT_RUC.Text
            BEProveedores.gcelular = TXT_CELULAR.Text
            BEProveedores.gtelefono = TXT_TELEFONO.Text
            BEProveedores.gcorreo = TXT_CORREO.Text
            BEProveedores.gusu_mod = VARIABLES_GLOBALES.ID_USUARIO

            If DAProveedores.actualizar_Proveedores(BEProveedores) Then
                MsgBox("PROVEEDOR ACTUALIZADO CORRECTAMENTE..!!")
            Else
                MsgBox("ERROR AL ACTUALIZAR PROVEEDOR...!!")
            End If
        End If

        VARIABLES_GLOBALES.ID_PROVEEDOR = Nothing
        FRM_PROVEEDORES.Show()
        Me.Close()
    End Sub

    Sub LIMPIAR()
        TXT_CELULAR.Text = ""
        TXT_CORREO.Text = ""
        TXT_RAZON_SOCIAL.Text = ""
        TXT_RUC.Text = ""
        TXT_TELEFONO.Text = ""
    End Sub

    Private Sub FRM_PROVEEDORES_CRUD_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If VARIABLES_GLOBALES.ID_PROVEEDOR <> Nothing Then
            Dim DAConsultas_Completas_Base As New DAConsultas_Completas_Base
            DAConsultas_Completas_Base.cargarProveedores(VARIABLES_GLOBALES.ID_PROVEEDOR, TXT_RAZON_SOCIAL, TXT_RUC, TXT_CELULAR, TXT_TELEFONO, TXT_CORREO)
        End If
    End Sub
End Class