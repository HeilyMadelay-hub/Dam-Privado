
Imports System.Data
Imports System.Data.OleDb

Public Class Form1

    Dim oconexion As New OleDbConnection
    Dim isConnected As Boolean = False

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        oconexion.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Application.StartupPath & "\dbempresas.mdb;")

    End Sub

    Private Sub btbConectar_Click(sender As Object, e As EventArgs) Handles ButtonConectar.Click

        TextBoxDireccion.Enabled = True
        TextBoxTelefono.Enabled = True

        Try
            ' Intentar abrir la conexión
            oconexion.Open()

            ' Mostrar mensaje de éxito si se conecta correctamente
            MessageBox.Show("Conexión exitosa", "Conexión", MessageBoxButtons.OK, MessageBoxIcon.Information)

            isConnected = True



        Catch ex As Exception

            ' También puedes mostrar un mensaje con más detalles (opcional)
            MessageBox.Show("Error al conectar: " & ex.Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally

            ' Cerrar la conexión si está abierta
            If oconexion.State = ConnectionState.Open Then
                oconexion.Close()
            End If

        End Try

    End Sub

    Private Sub ButtonListar_Click(sender As Object, e As EventArgs) Handles ButtonListar.Click

        TextBoxDireccion.Enabled = True
        TextBoxTelefono.Enabled = True

        If Not isConnected Then

            MessageBox.Show("Primero debe conectar antes de listar los datos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            Exit Sub

        End If

        Try

            oconexion.Open()

            'COMANDO

            Dim query As String = "Select * from tbempresas"

            Dim comando As New OleDbCommand(query, oconexion)

            'ADAPTADOR

            Dim adaptador As New OleDbDataAdapter(comando)

            Dim tabla As New DataTable

            'Llenar la tabla

            adaptador.Fill(tabla)

            'Asignar la tabla al datagridview

            DataGridView1.DataSource = tabla

        Catch ex As Exception
            ' Mostrar mensaje de error en caso de fallo
            MessageBox.Show("Error al listar datos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' Cerrar la conexión si está abierta
            If oconexion.State = ConnectionState.Open Then
                oconexion.Close()
            End If
        End Try

    End Sub

    ' ExecuteNonQuery() se utiliza para ejecutar comandos SQL que modifican datos en la base de datos:
    ' - INSERT: Añade registros nuevos
    ' - DELETE: Elimina registros existentes
    ' - UPDATE: Actualiza registros existentes
    ' - Comandos DDL (CREATE TABLE, DROP TABLE, etc.): Modifican la estructura de la base de datos
    ' Devuelve el número de filas afectadas por la operación, pero no devuelve datos.
    ' Ideal para operaciones que no requieren recuperar información directamente.


    Private Sub ButtonAlta_Click(sender As Object, e As EventArgs) Handles ButtonAlta.Click

        TextBoxDireccion.Enabled = True
        TextBoxTelefono.Enabled = True

        ' Verificar si la conexión está establecida
        If Not isConnected Then
            MessageBox.Show("Primero debe conectar antes de realizar esta acción.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            ' Abrir la conexión
            oconexion.Open()

            ' Crear la consulta SQL para insertar un registro
            Dim query As String = "INSERT INTO tbempresas (nombre, direccion, telefono) VALUES (@Nombre, @Direccion, @Telefono)"
            Dim comando As New OleDbCommand(query, oconexion)

            ' Agregar los parámetros a la consulta
            comando.Parameters.Add("@Nombre", OleDbType.VarChar).Value = TextBoxNombre.Text
            comando.Parameters.Add("@Direccion", OleDbType.VarChar).Value = TextBoxDireccion.Text
            comando.Parameters.Add("@Telefono", OleDbType.VarChar).Value = TextBoxTelefono.Text

            ' Ejecutar el comando
            Dim filasafectadas As Integer = comando.ExecuteNonQuery()

            ' Confirmar la inserción
            If filasafectadas > 0 Then
                MessageBox.Show("Registro insertado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("No se pudo insertar el registro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            ' Mostrar mensaje de error
            MessageBox.Show("Error al insertar el registro: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' Cerrar la conexión si está abierta
            If oconexion.State = ConnectionState.Open Then
                oconexion.Close()
            End If
        End Try
    End Sub

    Private Sub ButtonBaja_Click(sender As Object, e As EventArgs) Handles ButtonBaja.Click
        ' Desactivar los TextBox de Dirección y Teléfono inmediatamente al hacer clic en el botón de Baja
        TextBoxDireccion.Enabled = False
        TextBoxTelefono.Enabled = False

        ' Verificar si la conexión está establecida
        If Not isConnected Then
            MessageBox.Show("Primero debe conectar antes de realizar esta acción.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            ' Abrir la conexión
            oconexion.Open()

            ' Verificar que el usuario ha ingresado un valor clave para eliminar
            If String.IsNullOrEmpty(TextBoxNombre.Text) Then
                MessageBox.Show("Debe ingresar el nombre del registro que desea eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            ' Crear la consulta SQL para eliminar un registro de la tabla tbempresas
            Dim query As String = "DELETE FROM tbempresas WHERE nombre = @Nombre"
            Dim comando As New OleDbCommand(query, oconexion)

            ' Agregar el parámetro necesario
            comando.Parameters.Add("@Nombre", OleDbType.VarChar).Value = TextBoxNombre.Text

            ' Ejecutar el comando
            Dim rowsAffected As Integer = comando.ExecuteNonQuery()

            ' Confirmar la eliminación
            If rowsAffected > 0 Then
                MessageBox.Show("Registro eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("No se encontró un registro con el nombre especificado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            ' Mostrar mensaje de error
            MessageBox.Show("Error al eliminar el registro: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' Cerrar la conexión si está abierta
            If oconexion.State = ConnectionState.Open Then
                oconexion.Close()
            End If
        End Try

    End Sub


    Private Sub ButtonBuscar_Click(sender As Object, e As EventArgs) Handles ButtonBuscar.Click

        TextBoxDireccion.Enabled = True
        TextBoxTelefono.Enabled = True

        Dim query As String = "SELECT * FROM tbempresas WHERE 1=1"

        ' Verificar si la conexión está establecida
        If Not isConnected Then
            MessageBox.Show("Primero debe conectar antes de buscar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            ' Abrir la conexión
            oconexion.Open()

            ' Crear el comando SQL
            Dim comando As New OleDbCommand(query, oconexion)

            ' Agregar condiciones directamente
            If Not String.IsNullOrEmpty(TextBoxNombre.Text) Then
                query &= " AND Nombre = @Nombre"
                comando.Parameters.Add("@Nombre", OleDbType.VarChar).Value = TextBoxNombre.Text
            End If

            If Not String.IsNullOrEmpty(TextBoxDireccion.Text) Then
                query &= " AND Direccion = @Direccion"
                comando.Parameters.Add("@Direccion", OleDbType.VarChar).Value = TextBoxDireccion.Text
            End If

            If Not String.IsNullOrEmpty(TextBoxTelefono.Text) Then
                query &= " AND Telefono = @Telefono"
                comando.Parameters.Add("@Telefono", OleDbType.VarChar).Value = TextBoxTelefono.Text
            End If

            ' Actualizar la consulta final en el comando
            comando.CommandText = query

            ' Crear un DataAdapter para ejecutar la consulta y llenar los datos en un DataTable
            Dim adaptador As New OleDbDataAdapter(comando)
            Dim tabla As New DataTable()
            adaptador.Fill(tabla)

            ' Asignar los resultados al DataGridView
            DataGridView1.DataSource = tabla

            ' Mostrar los datos en los TextBox si hay resultados
            If tabla.Rows.Count > 0 Then
                TextBoxNombre.Text = tabla.Rows(0)("Nombre").ToString()
                TextBoxDireccion.Text = tabla.Rows(0)("Direccion").ToString()
                TextBoxTelefono.Text = tabla.Rows(0)("Telefono").ToString()
            Else
                ' Mostrar mensaje si no hay resultados
                MessageBox.Show("No se encontraron resultados para los criterios especificados.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            ' Mostrar mensaje de error
            MessageBox.Show("Error al buscar datos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' Cerrar la conexión si está abierta
            If oconexion.State = ConnectionState.Open Then
                oconexion.Close()
            End If
        End Try

    End Sub

    Private Sub ButtonSalir_Click(sender As Object, e As EventArgs) Handles ButtonSalir.Click

        TextBoxDireccion.Enabled = True
        TextBoxTelefono.Enabled = True

        Close()

    End Sub
End Class
