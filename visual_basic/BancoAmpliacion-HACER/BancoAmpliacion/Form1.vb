Imports System.Data
Imports System.Data.OleDb
Public Class FormBanco

    Private formulario2 As New Formulario2()
    Private formulario3 As New Formulario3()


    Private Sub FormBanco_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            oconexion.Open()
            MessageBox.Show("Conexión exitosa con la base de datos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            oconexion.Close()
        Catch ex As Exception
            MessageBox.Show("Error al conectar con la base de datos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub ButtonOperar_Click(sender As Object, e As EventArgs) Handles ButtonOperar.Click
        If formulario2 Is Nothing OrElse formulario2.IsDisposed Then
            formulario2 = New Formulario2()
        End If
        formulario2.Show()

        If formulario3 IsNot Nothing AndAlso Not formulario3.IsDisposed Then
            formulario3.Hide()
        End If
    End Sub

    Private Sub ButtonGestion_Click(sender As Object, e As EventArgs) Handles ButtonGestion.Click
        If formulario3 Is Nothing OrElse formulario3.IsDisposed Then
            formulario3 = New Formulario3()
        End If
        formulario3.Show()

        If formulario2 IsNot Nothing AndAlso Not formulario2.IsDisposed Then
            formulario2.Hide()
        End If
    End Sub

    Private Sub ButtonSalir_Click(sender As Object, e As EventArgs) Handles ButtonSalir.Click
        ' Asegurarse de cerrar correctamente los formularios secundarios
        If formulario2 IsNot Nothing AndAlso Not formulario2.IsDisposed Then
            formulario2.Close()
        End If

        If formulario3 IsNot Nothing AndAlso Not formulario3.IsDisposed Then
            formulario3.Close()
        End If

        Close()
    End Sub
End Class
