Imports System.Data
Imports System.Data.OleDb
Public Class Formulario2

    'DATAREADER BASE DE DATOS  CON CONEXION DATASET MODELO NO CONECTADO  SE TRABAJA CON EL FILL.DATASET EXAMEN DATASET EXAMEN

    Dim saldoActual As Double

    'Busca el numero de cuentas en la base de datos
    Private Sub ButtonBuscar_Click(sender As Object, e As EventArgs) Handles ButtonBuscar.Click

        Try

            ' Abre la conexión si está cerrada
            If oconexion.State = ConnectionState.Closed Then
                oconexion.Open()
            End If

            ' Consulta SQL corregida
            Dim comandobuscar As New OleDbCommand("SELECT tbcuentas.Saldo, tbdatos.Nombre, tbdatos.Numero_Cuenta FROM tbdatos INNER JOIN tbcuentas ON tbdatos.Numero_Cuenta = tbcuentas.Numero_Cuenta WHERE tbdatos.Numero_Cuenta = ?", oconexion)

            Dim numCuenta As Integer
            If Integer.TryParse(TextBoxNumeroCuenta.Text, numCuenta) Then
                comandobuscar.Parameters.AddWithValue("?", numCuenta)
            Else
                MessageBox.Show("El número de cuenta debe ser un valor numérico", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            ' Deshabilitar los TextBox después de mostrar los datos
            TextBoxNumeroCuenta.Enabled = False
            TextBoxNombre.Enabled = False
            TextBoxSaldoInicial.Enabled = False

            Dim odatareader As OleDbDataReader = comandobuscar.ExecuteReader()


            If odatareader.Read() Then
                TextBoxNumeroCuenta.Text = odatareader("Numero_Cuenta").ToString()
                TextBoxNombre.Text = odatareader("Nombre").ToString()
                TextBoxSaldoInicial.Text = odatareader("Saldo").ToString()
            Else
                MessageBox.Show("El elemento buscado no existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Catch ex As Exception
            MessageBox.Show("Error al buscar los datos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'Vuelve el formulario 1
    Private Sub ButtonVolver_Click(sender As Object, e As EventArgs) Handles ButtonVolver.Click
        ' Cerrar el formulario actual
        Me.Hide()
    End Sub

    Private Sub Formulario2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        TextBoxSaldoActual.Enabled = False

    End Sub

    Private Sub ButtonPago_Click(sender As Object, e As EventArgs) Handles ButtonPago.Click

        Dim cantidad As Double
        cantidad = InputBox("Introduce cantidad", "DB Banco")
        saldoActual -= cantidad

        TextBoxSaldoActual.Text = saldoActual.ToString()


    End Sub

    Private Sub ButtonIngreso_Click(sender As Object, e As EventArgs) Handles ButtonIngreso.Click
        Dim cantidad As Double
        cantidad = InputBox("Introduce cantidad", "DB Banco")
        saldoActual += cantidad

        TextBoxSaldoActual.Text = saldoActual.ToString()


    End Sub

    Private Sub ButtonNuevo_Click(sender As Object, e As EventArgs) Handles ButtonNuevo.Click
        Try
            ' Eliminar espacios en blanco de los valores ingresados
            Dim numeroCuentaTexto As String = TextBoxNumeroCuenta.Text.Trim()
            Dim nombreTexto As String = TextBoxNombre.Text.Trim()
            Dim saldoInicialTexto As String = TextBoxSaldoInicial.Text.Trim()

            ' Verificar si los campos están vacíos
            If String.IsNullOrEmpty(numeroCuentaTexto) OrElse String.IsNullOrEmpty(nombreTexto) OrElse String.IsNullOrEmpty(saldoInicialTexto) Then
                MessageBox.Show("Debe ingresar un número de cuenta, un nombre y un saldo inicial.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            ' Verificar si el saldo inicial es un número válido
            Dim nuevoSaldo As Double
            If Not Double.TryParse(saldoInicialTexto, nuevoSaldo) Then
                MessageBox.Show("El saldo inicial debe ser un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            ' Verificar si el número de cuenta es numérico
            Dim numCuenta As Integer
            If Not Integer.TryParse(numeroCuentaTexto, numCuenta) Then
                MessageBox.Show("El número de cuenta debe ser un valor numérico.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            ' Asegurar que la conexión está abierta
            If oconexion.State = ConnectionState.Closed Then
                oconexion.Open()
            End If

            ' Comprobar si la cuenta ya existe en la base de datos
            Dim verificarCuenta As New OleDbCommand("SELECT COUNT(*) FROM tbcuentas WHERE Numero_Cuenta = ?", oconexion)
            verificarCuenta.Parameters.AddWithValue("?", numCuenta)

            Dim cuentaExiste As Integer = Convert.ToInt32(verificarCuenta.ExecuteScalar())

            If cuentaExiste = 0 Then
                ' Si la cuenta no existe, se crea
                Dim insertarCuenta As New OleDbCommand("INSERT INTO tbcuentas (Numero_Cuenta, Saldo) VALUES (?, ?)", oconexion)
                insertarCuenta.Parameters.AddWithValue("?", numCuenta)
                insertarCuenta.Parameters.AddWithValue("?", nuevoSaldo)

                Dim filasInsertadas As Integer = insertarCuenta.ExecuteNonQuery()
                If filasInsertadas > 0 Then
                    MessageBox.Show("Cuenta creada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("No se pudo crear la cuenta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

            End If

            ' Limpiar los campos después de la operación
            TextBoxNumeroCuenta.Clear()
            TextBoxNombre.Clear()
            TextBoxSaldoInicial.Clear()
            TextBoxSaldoActual.Clear()

        Catch ex As Exception
            MessageBox.Show("Error al procesar la cuenta: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub




End Class