Imports System.Data
Imports System.Data.OleDb
Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            oconexion.Open()
            MessageBox.Show("Conexión exitosa con la base de datos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            oconexion.Close()
        Catch ex As Exception
            MessageBox.Show("Error al conectar con la base de datos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub ButtonGestion_Click(sender As Object, e As EventArgs) Handles ButtonGestion.Click

        ' Ocultar Form1 y mostrar Form2
        Me.Hide()
        formulario2.Show()

    End Sub

    Private Sub ButtonVenta_Click(sender As Object, e As EventArgs) Handles ButtonVenta.Click

        ' Ocultar Form1 y mostrar Form3
        Me.Hide()
        formulario3.Show()

    End Sub


End Class
