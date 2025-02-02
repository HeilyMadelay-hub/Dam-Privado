Imports System.Data
Imports System.Data.OleDb
Public Class Form1

    Dim oconexion As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Application.StartupPath & "\dbempresas.mdb;")
    Dim odataadapter As New OleDbDataAdapter("SELECT * FROM tbempresas", oconexion)
    Dim odataset As New DataSet

    Private Sub ButtonConectar_Click(sender As Object, e As EventArgs) Handles ButtonConectar.Click
        Try
            ' Abrir la conexión
            oconexion.Open()
            odataadapter.Fill(odataset, "tb1")
            MsgBox("Conexión exitosa a la base de datos,  Ok!!", MsgBoxStyle.Information, "Estado de Conexión")
        Catch ex As OleDbException
            ' Manejo de errores específicos de OleDb
            MsgBox("Error al conectar a la base de datos: " & ex.Message, MsgBoxStyle.Critical, "Error de Conexión")
        Catch ex As Exception
            ' Manejo de otros errores generales
            MsgBox("Se produjo un error: " & ex.Message, MsgBoxStyle.Critical, "Error General")
        Finally
            ' Asegurarse de cerrar la conexión, incluso si ocurre un error
            If oconexion.State = ConnectionState.Open Then
                oconexion.Close()
            End If
        End Try
    End Sub


    Private Sub ButtonVer_Click(sender As Object, e As EventArgs) Handles ButtonVer.Click

        Dim ofila As DataRow

        For Each ofila In odataset.Tables("tb1").Rows

            ListBoxNombre.Items.Add(ofila.Item("Nombre"))

        Next

    End Sub

    'Hasta aqui el ejercicio primera parte

    '---------------------------------------------------

    'La nueva parte es que cuando hagas click en uno de los nombres de la lista aparezca los datos en su textbox correspondiente

    Private Sub ListBoxNombre_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBoxNombre.SelectedIndexChanged
        If ListBoxNombre.SelectedIndex <> -1 Then

            Dim nombreseleccionado As String = ListBoxNombre.SelectedItem.ToString()

            Dim filaencontrada As DataRow = odataset.Tables("tb1").Select($"Nombre = '{nombreseleccionado}'").FirstOrDefault()

            'odataset.Tables("tb1"): Accesses the "tb1" table in the dataset
            '.Select() : Filters rows based on a condition
            '$"Nombre = '{nombreseleccionado}'": String interpolation to create a filter condition
            'Looks for rows where the "Nombre" column matches the selected name
            '.FirstOrDefault() : Returns the first matching row, Or null if no match


            If filaencontrada IsNot Nothing Then 'Si lo encuentro muestra
                TextBoxNombre.Text = filaencontrada("Nombre").ToString()
                TextBoxDireccion.Text = filaencontrada("Direccion").ToString()
                TextBoxTelefono.Text = filaencontrada("Telefono").ToString()
            End If

        End If
    End Sub





End Class
