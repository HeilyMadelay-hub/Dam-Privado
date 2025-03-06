Imports System.Data.OleDb
Imports System.Data
Public Class Form6
    Dim odataset As New DataSet()
    Dim tabaquerasadaptador As New OleDbDataAdapter("SELECT * FROM tbtabaqueras", Module1.oconexion)
    Dim marcasadaptador As New OleDbDataAdapter("SELECT * FROM tbmarcas", Module1.oconexion)
    Dim pedidosadaptador As New OleDbDataAdapter("SELECT * FROM tbpedidos", Module1.oconexion)

    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Module1.oconexion.Open()

            ' Limpiar el dataset para evitar datos duplicados
            odataset.Clear()

            ' Llenar el dataset con los datos actualizados
            tabaquerasadaptador.Fill(odataset, "tbtabaqueras")
            marcasadaptador.Fill(odataset, "tbmarcas")
            pedidosadaptador.Fill(odataset, "tbpedidos")

            ' Asignar los datos a cada DataGridView
            DataGridView1.DataSource = odataset.Tables("tbtabaqueras")
            DataGridView2.DataSource = odataset.Tables("tbmarcas")
            DataGridView3.DataSource = odataset.Tables("tbpedidos")

            ' Ajustar automáticamente el tamaño de las columnas
            DataGridView1.AutoResizeColumns()
            DataGridView2.AutoResizeColumns()
            DataGridView3.AutoResizeColumns()

        Catch ex As Exception
            MessageBox.Show("Error al cargar los datos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Module1.oconexion.Close()
        End Try
    End Sub

    Private Sub ButtonVolver_Click(sender As Object, e As EventArgs) Handles ButtonVolver.Click
        Me.Hide()
        Form3.Show()
    End Sub
End Class