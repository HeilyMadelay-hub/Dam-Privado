Imports System.Data
Imports System.Data.OleDb
Public Class Form1

    Dim oconexion As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\bdcoches.accdb;")
    Dim cochesmodelosadaptador As New OleDbDataAdapter("SELECT * FROM TBMODELOS", oconexion)
    Dim cochesvendidosadaptador As New OleDbDataAdapter("SELECT * FROM TBVENDIDOS", oconexion)
    Dim odataset As New DataSet()
    Dim obuildercochesmodelos As New OleDbCommandBuilder(cochesmodelosadaptador)
    Dim obuildercochesvendidos As New OleDbCommandBuilder(cochesvendidosadaptador)
    Dim ofila As DataRow

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ComboBoxCoches.DropDownStyle = ComboBoxStyle.DropDownList

        Try

            cochesmodelosadaptador.Fill(odataset, "TBMODELOS")
            cochesvendidosadaptador.Fill(odataset, "TBVENDIDOS")


            MessageBox.Show("Datos cargados correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

            RellenarComboBoxCoches()

        Catch ex As Exception

            MessageBox.Show("Error al cargar los datos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Private Sub RellenarComboBoxCoches()
        Try
            ComboBoxCoches.Items.Clear()

            For Each fila In odataset.Tables("TBMODELOS").Rows
                ComboBoxCoches.Items.Add(fila.Item("Modelo").ToString())
            Next
        Catch ex As Exception
            MsgBox("Error al llenar el ComboBox: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub ComboBoxCoches_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxCoches.SelectedIndexChanged

        Dim expression As String
        Dim filaencontrada() As DataRow
        Try
            TextBoxModelo.Text = ""
            TextBoxCilindrada.Text = ""
            TextBoxMotor.Text = ""
            TextBoxUnidades.Text = ""
            PictureBoxFotoCoche.Image = Nothing


            expression = "Modelo= '" & ComboBoxCoches.SelectedItem.ToString() & "'"
            filaencontrada = Me.odataset.Tables("tbmodelos").Select(expression)

            If filaencontrada.GetUpperBound(0) <> -1 Then

                PictureBoxFotoCoche.Image = Image.FromFile(Application.StartupPath & "\COCHES\" & filaencontrada(0).Item("Foto"))
                TextBoxModelo.Text = filaencontrada(0).Item("modelo").ToString()
                TextBoxCilindrada.Text = filaencontrada(0).Item("cilindrada").ToString()
                TextBoxMotor.Text = filaencontrada(0).Item("motor").ToString()
                TextBoxUnidades.Text = filaencontrada(0).Item("unidades").ToString()
            Else

                MsgBox("Error, no existe el modelo seleccionado", MsgBoxStyle.Information, "Información")
            End If
        Catch ex As Exception
            MsgBox("Error al cargar los datos del modelo: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub


    Private Sub ButtonVender_Click(sender As Object, e As EventArgs) Handles ButtonVender.Click
        Try
            If ComboBoxCoches.SelectedIndex = -1 Then
                MessageBox.Show("Debe seleccionar un modelo de coche para vender", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim unidadesDisponibles As Integer = Convert.ToInt32(TextBoxUnidades.Text)

            If unidadesDisponibles <= 0 Then
                MessageBox.Show("No hay unidades disponibles de este modelo", "Sin stock", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            Dim telefonoComprador As String = ""
            Dim telefonoValido As Boolean = False

            Do Until telefonoValido

                telefonoComprador = InputBox("Introduzca el número de teléfono del comprador:", "Datos de venta")

                If String.IsNullOrEmpty(telefonoComprador) Then
                    MessageBox.Show("Venta cancelada. No se introdujo número de teléfono.", "Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If

                If IsNumeric(telefonoComprador) Then
                    telefonoValido = True
                Else
                    MessageBox.Show("Por favor, introduzca solo números en el teléfono.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Loop

            Dim modeloSeleccionado As String = ComboBoxCoches.SelectedItem.ToString()
            Dim ventaExistente As String = "Modelo = '" & modeloSeleccionado & "' AND Telefono = '" & telefonoComprador & "'"
            Dim ventasExistentes() As DataRow = odataset.Tables("TBVENDIDOS").Select(ventaExistente)

            If ventasExistentes.Length > 0 Then
                MessageBox.Show("Este cliente ya ha comprado este modelo de coche", "Venta duplicada", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim expression As String = "Modelo = '" & modeloSeleccionado & "'"
            Dim filasEncontradas() As DataRow = odataset.Tables("TBMODELOS").Select(expression)
            filasEncontradas(0)("unidades") = unidadesDisponibles - 1

            Dim nuevaVenta As DataRow = odataset.Tables("TBVENDIDOS").NewRow()
            nuevaVenta("Modelo") = modeloSeleccionado
            nuevaVenta("Telefono") = telefonoComprador
            odataset.Tables("TBVENDIDOS").Rows.Add(nuevaVenta)

            cochesmodelosadaptador.Update(odataset, "TBMODELOS")
            cochesvendidosadaptador.Update(odataset, "TBVENDIDOS")

            TextBoxUnidades.Text = (unidadesDisponibles - 1).ToString()
            ListBoxClientes.Items.Add(modeloSeleccionado & " - Tel: " & telefonoComprador)

            MessageBox.Show("Venta realizada con éxito", "Venta completada", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error al realizar la venta: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ButtonVendidos_Click(sender As Object, e As EventArgs) Handles ButtonVendidos.Click
        Try
            ListBoxClientes.Items.Clear()

            Dim telefonosTemporales As New List(Of String)()
            'Creo la lista para primero obtener los telefonos unicos
            For Each fila As DataRow In odataset.Tables("TBVENDIDOS").Rows
                Dim telefono As String = fila("Telefono").ToString()
                If Not telefonosTemporales.Contains(telefono) Then
                    telefonosTemporales.Add(telefono)
                End If
            Next
            'los guardas aqui
            Dim telefonosUnicos(telefonosTemporales.Count - 1) As String

            'los copias al array y se añaden a la interfaz
            For i As Integer = 0 To telefonosTemporales.Count - 1
                telefonosUnicos(i) = telefonosTemporales(i)
                ListBoxClientes.Items.Add(telefonosUnicos(i))
            Next

            If ListBoxClientes.Items.Count = 0 Then
                MessageBox.Show("No hay clientes registrados", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Error al cargar los clientes: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ListBoxClientes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBoxClientes.SelectedIndexChanged
        Try
            If ListBoxClientes.SelectedIndex <> -1 Then
                Dim telefonoSeleccionado As String = ListBoxClientes.SelectedItem.ToString()

                Dim expression As String = "Telefono = '" & telefonoSeleccionado & "'"
                Dim filasEncontradas() As DataRow = odataset.Tables("TBVENDIDOS").Select(expression)

                If filasEncontradas.Length > 0 Then

                    Dim modelosComprados As New List(Of String)

                    For Each fila As DataRow In filasEncontradas
                        modelosComprados.Add(fila("Modelo").ToString())
                    Next

                    MessageBox.Show("El cliente con teléfono " & telefonoSeleccionado & " compró el/los siguiente(s) modelo(s): " & String.Join(", ", modelosComprados), "Información de compra", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error al mostrar la información del cliente: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ButtonBorrar_Click(sender As Object, e As EventArgs) Handles ButtonBorrar.Click
        Try
            If ListBoxClientes.SelectedIndex = -1 Then
                MessageBox.Show("Debe seleccionar un cliente para eliminarlo", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim telefonoSeleccionado As String = ListBoxClientes.SelectedItem.ToString()

            Dim confirmacion As DialogResult = MessageBox.Show("¿Está seguro de eliminar al cliente con teléfono " & telefonoSeleccionado & "?",
                                                          "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If confirmacion = DialogResult.Yes Then

                Dim expression As String = "Telefono = '" & telefonoSeleccionado & "'"
                Dim filasEncontradas() As DataRow = odataset.Tables("TBVENDIDOS").Select(expression)

                For Each fila As DataRow In filasEncontradas
                    fila.Delete()
                Next

                cochesvendidosadaptador.Update(odataset, "TBVENDIDOS")

                ListBoxClientes.Items.RemoveAt(ListBoxClientes.SelectedIndex)

                MessageBox.Show("Cliente eliminado correctamente", "Eliminación completada", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show("Error al eliminar el cliente: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ButtonSalir_Click(sender As Object, e As EventArgs) Handles ButtonSalir.Click
        Close()
    End Sub

End Class


