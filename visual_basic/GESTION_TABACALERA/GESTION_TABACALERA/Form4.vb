Imports System.Data.OleDb
Imports System.Data

Public Class Form4

    Dim tabaquerasadaptador As New OleDbDataAdapter("SELECT * FROM tbtabaqueras", Module1.oconexion)
    Dim odataset As New DataSet()
    Dim obuildertabaqueras As New OleDbCommandBuilder(tabaquerasadaptador) ' Para modificar,insertar o borrar datos

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            Module1.oconexion.Open()
            tabaquerasadaptador.Fill(odataset, "tbtabaqueras")
            Module1.oconexion.Close()
            MessageBox.Show("Datos cargados correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception

            MessageBox.Show("Error al cargar los datos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Private Sub ButtonAltaTabaqueras_Click(sender As Object, e As EventArgs) Handles ButtonAltaTabaqueras.Click

        Dim ofila As DataRow
        Dim repetido As Boolean = False

        'Validar que los campos no estén vacíos
        If String.IsNullOrEmpty(TextBoxNombre.Text) OrElse String.IsNullOrEmpty(TextBoxDireccion.Text) Then
            MessageBox.Show("Todos los campos son obligatorios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        'Validación del nombre
        If Not TextBoxNombre.Text.All(Function(c) Char.IsLetter(c) OrElse c = " ") Then
            MessageBox.Show("El nombre solo puede contener letras", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If TextBoxNombre.Text.Length > 50 Then
            MessageBox.Show("El nombre es demasiado largo (máximo 50 caracteres)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        'Validación de la dirección
        If Not TextBoxDireccion.Text.All(Function(c) Char.IsLetterOrDigit(c) OrElse c = " ") Then
            MessageBox.Show("La dirección solo puede contener letras, números y espacios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If TextBoxDireccion.Text.Length > 100 Then
            MessageBox.Show("La dirección es demasiado larga (máximo 100 caracteres)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If


        'Verifica que no exista una tabaquera con el mismo nombre
        For Each fila As DataRow In odataset.Tables("tbtabaqueras").Rows
            If fila("Nombre").ToString() = TextBoxNombre.Text Then
                MessageBox.Show("El nombre ya existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                repetido = True
                Exit For
            End If
        Next

        If Not repetido Then

            'La nueva linea que vas a añadir con todas las caracteristicas

            ofila = odataset.Tables("tbtabaqueras").NewRow
            ofila("Nombre") = TextBoxNombre.Text.Trim()
            ofila("Direccion") = TextBoxDireccion.Text.Trim()


            odataset.Tables("tbtabaqueras").Rows.Add(ofila)

            Try
                oconexion.Open()
                tabaquerasadaptador.Update(odataset, "tbtabaqueras") 'Actualizando la nueva fila
                oconexion.Close()

                LimpiarCampos()

                MessageBox.Show("Se ha dado de alta correctamente la tabaquera", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch ex As Exception
                MessageBox.Show("Error:No se ha podido dar de alta la tabaquera: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try


        End If

    End Sub

    Private Sub LimpiarCampos()
        TextBoxDireccion.Clear()
        TextBoxNombre.Clear()
    End Sub

    Private Sub ButtonVolver_Click(sender As Object, e As EventArgs) Handles ButtonVolver.Click
        Me.Hide()
        formulario2.Show()
    End Sub


End Class