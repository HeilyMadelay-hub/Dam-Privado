Imports System.Data
Imports System.Data.OleDb
Public Class Form1

    Dim oconexion As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Application.StartupPath & "\dbempresas.mdb;")
    Dim odataadapter As New OleDbDataAdapter("SELECT * FROM tbempresas", oconexion)
    Dim odataset As New DataSet
    Dim obuilder As New OleDbCommandBuilder(odataadapter)

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Deshabilitar los botones hasta que se establezca la conexión
        Button2.Enabled = False
        Button3.Enabled = False
        Button4.Enabled = False
        Button5.Enabled = False

        oconexion.Open()

        odataadapter.Fill(odataset, "tb1")

        oconexion.Close()
    End Sub


    'un command builder por cada adaptador

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try

            MsgBox("Conexión exitosa a la base de datos,  Ok!!", MsgBoxStyle.Information, "Estado de Conexión")

            ' Habilitar los otros botones después de la conexión exitosa
            Button2.Enabled = True
            Button3.Enabled = True
            Button4.Enabled = True
            Button5.Enabled = True

        Catch ex As OleDbException
            ' Manejo de errores específicos de OleDb
            MsgBox("Error al conectar a la base de datos: " & ex.Message, MsgBoxStyle.Critical, "Error de Conexión")
        Catch ex As Exception
            ' Manejo de otros errores generales
            MsgBox("Se produjo un error: " & ex.Message, MsgBoxStyle.Critical, "Error General")

        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Try



            ' Limpiar el ListBox antes de agregar los nuevos datos
            ListBox1.Items.Clear()

            ' Iterar sobre las filas de la tabla y agregar cada registro al ListBox
            For Each row As DataRow In odataset.Tables("tb1").Rows
                Dim nombre As String = row("Nombre").ToString()
                ListBox1.Items.Add(nombre)
            Next


        Catch ex As OleDbException
            MsgBox("Error al acceder a la base de datos: " & ex.Message, MsgBoxStyle.Critical, "Error de Base de Datos")

        End Try

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Try



            'Asegurarse que el dataset tiene la estructura de la tabla
            If odataset.Tables("tb1") Is Nothing OrElse odataset.Tables("tb1").Rows.Count = 0 Then
                odataadapter.Fill(odataset, "tb1")
            End If

            If String.IsNullOrWhiteSpace(TextBoxNombre.Text) OrElse
               String.IsNullOrWhiteSpace(TextBoxDireccion.Text) OrElse
               String.IsNullOrWhiteSpace(TextBoxTelefono.Text) Then

                MsgBox("Por favor, complete todos los campos requeridos: Nombre, Dirección y Teléfono.", MsgBoxStyle.Exclamation, "Campos Incompletos")
                Return
            End If

            'Crear un nuevo DataRow

            Dim nuevaFila As DataRow = odataset.Tables("tb1").NewRow()

            'Asignar los valores de los TextBox a la nueva fila

            nuevaFila("Nombre") = TextBoxNombre.Text

            nuevaFila("Direccion") = TextBoxDireccion.Text

            nuevaFila("Telefono") = TextBoxTelefono.Text

            ' Agregar la nueva fila al DataSet
            odataset.Tables("tb1").Rows.Add(nuevaFila)

            ' Actualizar la base de datos
            odataadapter.Update(odataset, "tb1")

            MsgBox("Registro insertado correctamente.", MsgBoxStyle.Information, "Éxito")

        Catch ex As OleDbException

            MsgBox("Error al insertar en la base de datos: " & ex.Message, MsgBoxStyle.Critical, "Error de Base de Datos")


        End Try

        'Limpiar los TextBox después de insertar
        TextBoxNombre.Clear()
        TextBoxDireccion.Clear()
        TextBoxTelefono.Clear()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            ' Verificar que hay un registro seleccionado
            If odataset.Tables("tb1").Rows.Count > 0 Then
                ' Buscar el registro en la tabla
                Dim filaEliminar As DataRow = odataset.Tables("tb1").Rows(0) ' Asegúrate de usar el índice correcto
                filaEliminar.Delete()

                ' Actualizar la base de datos
                odataadapter.Update(odataset, "tb1")

                MsgBox("Registro eliminado correctamente.", MsgBoxStyle.Information, "Éxito")
            Else
                MsgBox("No se encontraron registros para eliminar.", MsgBoxStyle.Information, "Información")
            End If
        Catch ex As OleDbException
            MsgBox("Error al eliminar el registro: " & ex.Message, MsgBoxStyle.Critical, "Error de Base de Datos")

        End Try
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Try
            ' Verificar que hay un registro seleccionado en el ListBox
            If ListBox1.SelectedItem IsNot Nothing Then
                ' Obtener el nombre seleccionado en el ListBox
                Dim nombreSeleccionado As String = ListBox1.SelectedItem.ToString()

                ' Buscar la fila correspondiente en el DataSet
                Dim filaActualizar As DataRow = Nothing
                For Each row As DataRow In odataset.Tables("tb1").Rows
                    If row("Nombre").ToString() = nombreSeleccionado Then
                        filaActualizar = row
                        Exit For
                    End If
                Next

                ' Si se encuentra la fila, actualizar los valores
                If filaActualizar IsNot Nothing Then
                    filaActualizar("Nombre") = TextBoxNombre.Text
                    filaActualizar("Direccion") = TextBoxDireccion.Text
                    filaActualizar("Telefono") = TextBoxTelefono.Text

                    ' Guardar cambios en la base de datos
                    odataadapter.Update(odataset, "tb1")

                    ' Actualizar el ListBox para reflejar los cambios
                    ListBox1.Items.Clear()
                    For Each row As DataRow In odataset.Tables("tb1").Rows
                        ListBox1.Items.Add(row("Nombre").ToString())
                    Next

                    MsgBox("Registro actualizado correctamente.", MsgBoxStyle.Information, "Éxito")
                Else
                    MsgBox("No se encontró el registro seleccionado.", MsgBoxStyle.Information, "Información")
                End If
            Else
                MsgBox("Por favor, selecciona un nombre de la lista para actualizar.", MsgBoxStyle.Information, "Información")
            End If

        Catch ex As OleDbException
            MsgBox("Error al actualizar el registro: " & ex.Message, MsgBoxStyle.Critical, "Error de Base de Datos")

        End Try
    End Sub



End Class
