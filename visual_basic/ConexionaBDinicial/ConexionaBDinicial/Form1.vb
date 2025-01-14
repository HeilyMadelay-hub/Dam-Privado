Imports System.Data
Imports System.Data.OleDb

Public Class Form1

    Dim oconexion As New OleDbConnection



    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        oconexion.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Application.StartupPath & "\dbempresas.mdb;")


    End Sub

    Private Sub btbConectar_Click(sender As Object, e As EventArgs) Handles btbConectar.Click

        Try
            ' Intentar abrir la conexión
            oconexion.Open()
            ' Si se conecta correctamente, mostrar "Sí" en el TextBox
            TextBox1.Text = "Sí"
        Catch ex As Exception
            ' Si ocurre un error, mostrar "No" en el TextBox
            TextBox1.Text = "No"
            ' También puedes mostrar un mensaje con más detalles (opcional)
            MessageBox.Show("Error al conectar: " & ex.Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' Cerrar la conexión si está abierta
            If oconexion.State = ConnectionState.Open Then
                oconexion.Close()
            End If

        End Try

    End Sub

    Private Sub btnRecuperarInformacion_Click(sender As Object, e As EventArgs) Handles btnRecuperarInformacion.Click

        Try

            ' Intentar abrir la conexión
            oconexion.Open()
            ' Crear la consulta SQL para obtener los datos de la tabla
            Dim query As String = "SELECT * FROM tbempresas"
            Dim comando As New OleDbCommand(query, oconexion)

            ' Crear un adaptador para llenar los datos
            Dim adaptador As New OleDbDataAdapter(comando)
            Dim tabla As New DataTable()

            ' Llenar la tabla con los datos de la consulta
            adaptador.Fill(tabla)

            ' Mostrar los datos en el DataGridView
            DataGridView1.DataSource = tabla

        Catch ex As Exception
            ' Mostrar un mensaje de error si ocurre algo
            MessageBox.Show("Error al recuperar los datos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' Cerrar la conexión si está abierta
            If oconexion.State = ConnectionState.Open Then
                oconexion.Close()
            End If
        End Try



    End Sub


End Class
