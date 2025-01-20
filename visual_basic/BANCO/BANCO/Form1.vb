Imports System.Data
Imports System.Data.OleDb

Public Class Form1
    Private oconexion As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\dbbanco.accdb;")
    Private saldoActual As Double

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            oconexion.Open()
            oconexion.Close()
        Catch ex As Exception
            MessageBox.Show("Error al conectar con la base de datos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Try
            Using bcomando As New OleDbCommand("SELECT tbcuentas.Saldo, tbdatos.Nombre FROM tbdatos INNER JOIN tbcuentas ON tbdatos.Numero_cuenta = tbcuentas.Numero_cuenta WHERE tbdatos.Numero_cuenta = @A", oconexion)
                bcomando.Parameters.AddWithValue("@A", txtNumeroCuenta.Text)
                oconexion.Open()
                Using odatareader As OleDbDataReader = bcomando.ExecuteReader()
                    If odatareader.Read() Then
                        saldoActual = Convert.ToDouble(odatareader("Saldo"))
                        txtSaldoInicial.Text = saldoActual.ToString()
                        txtNombre.Text = odatareader("Nombre").ToString()
                    Else
                        MessageBox.Show("El elemento buscado no existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al buscar los datos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            oconexion.Close()
        End Try
    End Sub

    Private Sub btnIngresos_Click(sender As Object, e As EventArgs) Handles btnIngresos.Click
        Dim cantidad As Double
        If Double.TryParse(InputBox("Introduce cantidad", "DB Banco"), cantidad) Then
            saldoActual += cantidad
            txtSaldoActual.Text = saldoActual.ToString()
        Else
            MessageBox.Show("Ingrese un valor numérico válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnPagos_Click(sender As Object, e As EventArgs) Handles btnPagos.Click
        Dim cantidad As Double
        If Double.TryParse(InputBox("Introduce cantidad", "DB Banco"), cantidad) Then
            If cantidad > saldoActual Then
                MessageBox.Show("Saldo insuficiente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                saldoActual -= cantidad
                txtSaldoActual.Text = saldoActual.ToString()
            End If
        Else
            MessageBox.Show("Ingrese un valor numérico válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Try
            Using ocomando As New OleDbCommand("UPDATE tbcuentas SET Saldo = @A WHERE Numero_cuenta = @B", oconexion)
                ocomando.Parameters.AddWithValue("@A", saldoActual)
                ocomando.Parameters.AddWithValue("@B", txtNumeroCuenta.Text)
                oconexion.Open()
                Dim filasAfectadas As Integer = ocomando.ExecuteNonQuery()
                If filasAfectadas > 0 Then
                    MessageBox.Show("Saldo actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("No se encontró la cuenta especificada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al actualizar el saldo: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            oconexion.Close()
        End Try

        ' Limpiar campos
        saldoActual = 0
        txtNombre.Clear()
        txtSaldoInicial.Clear()
        txtSaldoActual.Clear()
        txtNumeroCuenta.Clear()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Application.Exit()
    End Sub
End Class