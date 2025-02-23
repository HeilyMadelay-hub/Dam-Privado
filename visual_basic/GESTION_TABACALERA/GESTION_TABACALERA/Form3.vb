Imports System.Data.OleDb
Imports System.Data
Public Class Form3

    'Form1
    Dim odataset As New DataSet()

    Dim tabaquerasadaptador As New OleDbDataAdapter("SELECT * FROM tbtabaqueras", Module1.oconexion)
    Dim marcasadaptador As New OleDbDataAdapter("SELECT * FROM tbmarcas", Module1.oconexion)
    Dim pedidosadaptador As New OleDbDataAdapter("SELECT * FROM tbpedidos", Module1.oconexion)

    Dim obuilderpedidos As New OleDbCommandBuilder(pedidosadaptador) ' Para modificar,insertar o borrar datos


    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Module1.oconexion.Open()

            tabaquerasadaptador.Fill(odataset, "tbtabaqueras")
            marcasadaptador.Fill(odataset, "tbmarcas")
            pedidosadaptador.Fill(odataset, "tbpedidos")

            Module1.oconexion.Close()

            MessageBox.Show("Datos cargados correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception

            MessageBox.Show("Error al cargar los datos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub ButtonVolver_Click(sender As Object, e As EventArgs) Handles ButtonVolver.Click
        Me.Hide()
        formulario1.Show()
    End Sub

    Private Sub ButtonVerTablas_Click(sender As Object, e As EventArgs) Handles ButtonVerTablas.Click
        Me.Hide()
        Form6.Show()
    End Sub


End Class