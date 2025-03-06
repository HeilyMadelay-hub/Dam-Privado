Imports System.Data.OleDb
Imports System.Data
Public Class Form3
    Dim odataset As New DataSet()

    Dim tabaquerasadaptador As New OleDbDataAdapter("SELECT * FROM tbtabaqueras", Module1.oconexion)
    Dim marcasadaptador As New OleDbDataAdapter("SELECT * FROM tbmarcas", Module1.oconexion)
    Dim pedidosadaptador As New OleDbDataAdapter("SELECT * FROM tbpedidos", Module1.oconexion)

    Dim obuilderpedidos As New OleDbCommandBuilder(pedidosadaptador) ' Para modificar,insertar o borrar datos


    Dim precioCajetilla As Double
    Dim marcaCajetilla As String

    'FORMULARIO
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Agregar esta línea antes de cargar los datos para que el usuario no pueda escribir cuando despliega la lista
        ComboBoxTabacaleras.DropDownStyle = ComboBoxStyle.DropDownList
        Try
            Module1.oconexion.Open()

            tabaquerasadaptador.Fill(odataset, "tbtabaqueras")
            marcasadaptador.Fill(odataset, "tbmarcas")
            pedidosadaptador.Fill(odataset, "tbpedidos")

            Module1.oconexion.Close()

            MessageBox.Show("Datos cargados correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

            RellenarComboBoxTabaqueras()

        Catch ex As Exception

            MessageBox.Show("Error al cargar los datos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    'ELEMENTOS DONDE INTRODUCES LOS DATOS

    Private Sub ComboBoxTabacaleras_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxTabacaleras.SelectedIndexChanged
        ' Este es el evento que se dispara cuando el usuario selecciona un item diferente en el ComboBox

        Dim i As Integer        ' Declara una variable para usar como contador en el bucle
        Dim expression As String    ' Declara una variable para almacenar la condición de búsqueda
        Dim filaencontrada() As DataRow    ' Declara un array para almacenar las filas que coincidan con la búsqueda

        Try    ' Inicio del bloque de manejo de errores
            ListBoxMarcas.Items.Clear()    ' Limpia todos los items existentes en el ListBox

            ' Construye la expresión de búsqueda usando el nombre de la tabacalera seleccionada
            expression = "Nombretb = '" & ComboBoxTabacaleras.SelectedItem.ToString() & "'"
            'El nombre de la columna de la tabla - = lo que compara - ComboBoxTabacaleras.SelectedItem.ToString() lo que estas seleccionando


            ' Busca en la tabla "tbmarcas" todas las filas que coincidan con la expresión
            filaencontrada = Me.odataset.Tables("tbmarcas").Select(expression)

            ' Verifica si se encontraron resultados (-1 significa que no hay resultados)
            If filaencontrada.GetUpperBound(0) <> -1 Then
                ' Recorre todas las filas encontradas
                For i = 0 To filaencontrada.GetUpperBound(0)
                    ' Añade el nombre de la marca al ListBox
                    Me.ListBoxMarcas.Items.Add(filaencontrada(i).Item("nombre_marca"))
                Next i
            Else
                ' Si no se encontraron resultados, muestra un mensaje de error
                MsgBox("Error, no existe")
            End If

        Catch ex As Exception    ' Captura cualquier error que ocurra durante la ejecución
            ' Muestra un mensaje con el error específico que ocurrió
            MsgBox("Error al cargar las marcas: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try    ' Fin del bloque de manejo de errores
    End Sub
    Private Sub ListBoxPedidos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBoxPedidos.SelectedIndexChanged
        If ListBoxPedidos.SelectedItem Is Nothing Then
            Exit Sub
        End If

        Try
            ' Buscar el pedido seleccionado
            Dim expression As String = "Id_pedido = " & ListBoxPedidos.SelectedItem.ToString()
            Dim filasPedido() As DataRow = odataset.Tables("tbpedidos").Select(expression)

            If filasPedido.Length > 0 Then
                ' Obtener la marca del pedido
                Dim nombreMarca As String = filasPedido(0)("Nombre_marca").ToString()

                ' Buscar la información de la marca en tbmarcas
                Dim expressionMarca As String = "nombre_marca = '" & nombreMarca & "'"
                Dim filasMarca() As DataRow = odataset.Tables("tbmarcas").Select(expressionMarca)

                If filasMarca.Length > 0 Then
                    ' Mostrar datos de la marca
                    PictureBox1.Image = Image.FromFile(Application.StartupPath & "\MARCAS_CIGARROS\" & filasMarca(0).Item("Foto"))
                    TextBoxNumeroCigarrillos.Text = filasMarca(0).Item("Nº_Cigarrillos").ToString()
                    TextBoxNicotina.Text = filasMarca(0).Item("Nicotina").ToString()
                    TextBoxPrecio.Text = filasMarca(0).Item("Precio").ToString()

                    ' Mostrar datos del pedido
                    NumericUpDownUnidades.Value = CDec(filasPedido(0)("cantidad"))

                    ' Si la cantidad es múltiplo de 10, probablemente fue un pedido por cartones
                    If CDec(filasPedido(0)("cantidad")) Mod 10 = 0 Then
                        CheckBoxCartones.Checked = True
                        NumericUpDownUnidades.Value = CDec(filasPedido(0)("cantidad")) / 10
                    Else
                        CheckBoxCartones.Checked = False
                    End If

                    ' Seleccionar la tabacalera y marca correspondiente
                    For Each fila As DataRow In odataset.Tables("tbmarcas").Rows
                        If fila("nombre_marca").ToString() = nombreMarca Then
                            Dim tabaquera As String = fila("Nombretb").ToString()
                            ComboBoxTabacaleras.SelectedItem = tabaquera
                            ListBoxMarcas.SelectedItem = nombreMarca
                            Exit For
                        End If
                    Next
                End If
            End If

        Catch ex As Exception
            MessageBox.Show("Error al cargar los detalles del pedido: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    'Al dar clic en la marca en los textbox muestras la caracteristicas de la marca
    Private Sub ListBoxMarcas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBoxMarcas.SelectedIndexChanged
        ' Declara una variable para usar como contador en el bucle
        Dim i As Integer

        ' Declara una variable para almacenar la condición de búsqueda
        Dim expression As String

        ' Declara un array para almacenar las filas que coincidan con la búsqueda
        Dim filaencontrada() As DataRow

        ' Inicio del bloque de manejo de errores
        Try
            ' Construye la expresión de búsqueda usando el nombre de la marca seleccionada en el ListBox
            expression = "nombre_marca = '" & ListBoxMarcas.SelectedItem.ToString() & "'"

            ' Busca en la tabla "tbmarcas" todas las filas que coincidan con la expresión
            filaencontrada = Me.odataset.Tables("tbmarcas").Select(expression)

            ' Verifica si se encontraron resultados (-1 significa que no hay resultados)
            If filaencontrada.GetUpperBound(0) <> -1 Then
                ' Recorre todas las filas encontradas
                For i = 0 To filaencontrada.GetUpperBound(0)
                    ' Carga la imagen de la marca desde el directorio MARCAS_CIGARROS
                    Me.PictureBox1.Image = Image.FromFile(Application.StartupPath & "\MARCAS_CIGARROS\" & filaencontrada(i).Item("Foto"))

                    ' Muestra el número de cigarrillos en el TextBox correspondiente
                    Me.TextBoxNumeroCigarrillos.Text = filaencontrada(i).Item("Nº_Cigarrillos")

                    ' Muestra la cantidad de nicotina en el TextBox correspondiente
                    Me.TextBoxNicotina.Text = filaencontrada(i).Item("Nicotina")

                    ' Muestra el precio en el TextBox correspondiente
                    Me.TextBoxPrecio.Text = filaencontrada(i).Item("Precio")

                    ' Convierte el precio a Double y lo guarda en una variable
                    precioCajetilla = CDbl(filaencontrada(i).Item("Precio"))

                    ' Guarda el nombre de la marca en una variable
                    marcaCajetilla = filaencontrada(i).Item("nombre_marca")
                Next i
            Else
                ' Si no se encontraron resultados, muestra un mensaje de error
                MsgBox("Error, no existe")
            End If

            ' Captura cualquier error que ocurra durante la ejecución
        Catch ex As Exception
            ' Muestra un mensaje con el error específico que ocurrió
            MsgBox("Error al cargar las marcas: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try    ' Fin del bloque de manejo de errores
    End Sub

    Private Sub ButtonRealizarPedido_Click(sender As Object, e As EventArgs) Handles ButtonRealizarPedido.Click

        ' Validacion de haber seleccionado marca 
        If ListBoxMarcas.SelectedItem Is Nothing Then
            MessageBox.Show("Debe seleccionar una marca del listado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        'Haber seleccionado el numero de cartones

        If NumericUpDownUnidades.Value <= 0 Then
            MessageBox.Show("La cantidad debe ser mayor que 0", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Validación del checkbox de cartones
        If CheckBoxCartones.Checked = False Then
            MessageBox.Show("Debe seleccionar la opción de cartones", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim ofila As DataRow
        Dim cantidad As Double = Convert.ToDouble(NumericUpDownUnidades.Value)
        Dim precio_venta As Double


        If CheckBoxCartones.Checked Then
            precio_venta = cantidad * Convert.ToDouble(precioCajetilla) * 10
        Else
            cantidad = NumericUpDownUnidades.Value
            precio_venta = cantidad * Convert.ToDouble(precioCajetilla)
        End If

        ofila = odataset.Tables("tbpedidos").NewRow
        ofila("Nombre_marca") = marcaCajetilla
        ofila("cantidad") = cantidad
        ofila("total") = precio_venta


        odataset.Tables("tbpedidos").Rows.Add(ofila)

        Try
            Module1.oconexion.Open()
            pedidosadaptador.Update(odataset, "tbpedidos")
            oconexion.Close()

            MessageBox.Show("Pedido realizado", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

            'Recargamos el Dataset para obtener el cambio en la tabla
            odataset.Tables("tbpedidos").Clear()

            pedidosadaptador.Fill(odataset, "tbpedidos")

            ' Obtener el número actual de pedidos en la tabla
            Dim numeroPedidos As Integer = odataset.Tables("tbpedidos").Rows.Count

            ' Preguntar si quiere ver el total cada 5 pedidos
            If numeroPedidos Mod 5 = 0 Then
                Dim respuesta As DialogResult = MessageBox.Show("Has llegado a " & numeroPedidos.ToString & " pedidos. ¿Deseas ver el total acumulado?",
                                                          "Ver Total", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If respuesta = DialogResult.Yes Then
                    MostrarTotal()
                End If
            End If

        Catch ex As Exception
            MessageBox.Show("Error al insertar los datos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        RellenarLosPedidos()

    End Sub

    Private Sub ButtonBorrarPedido_Click(sender As Object, e As EventArgs) Handles ButtonBorrarPedido.Click


        If ListBoxPedidos.SelectedItem Is Nothing Then
            MsgBox("Seleccione un pedido para borrar.", MsgBoxStyle.Exclamation, "Aviso")
            Exit Sub
        End If

        Dim fila As DataRow
        ' Buscar y eliminar el pedido seleccionado
        For Each fila In odataset.Tables("tbpedidos").Rows
            If fila("Id_pedido").ToString = ListBoxPedidos.SelectedItem.ToString Then
                fila.Delete()
                Module1.oconexion.Open()
                pedidosadaptador.Update(odataset, "tbpedidos")
                Module1.oconexion.Close()
                Exit For
            End If
        Next

        Try
            Module1.oconexion.Open()
            pedidosadaptador.Update(odataset, "tbpedidos")
            Module1.oconexion.Close()

            MessageBox.Show("Se ha eliminado el pedido", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

            'Recargamos el Dataset para obtener el cambio en la tabla
            odataset.Tables("tbpedidos").Clear()
            pedidosadaptador.Fill(odataset, "tbpedidos")


            'Actualizamos el ListBoxPedidos
            ListBoxPedidos.Items.Clear()
            For Each fila In odataset.Tables("tbpedidos").Rows
                ListBoxPedidos.Items.Add(fila("Id_pedido").ToString())
            Next


        Catch ex As Exception
            MessageBox.Show("Error al eliminar el pedido: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'BOTONES
    Private Sub ButtonVolver_Click(sender As Object, e As EventArgs) Handles ButtonVolver.Click
        Me.Hide()
        formulario1.Show()
    End Sub

    Private Sub ButtonVerTablas_Click(sender As Object, e As EventArgs) Handles ButtonVerTablas.Click
        Me.Hide()
        Form6.Show()
    End Sub

    'Subs - Void de Java
    Private Sub RellenarComboBoxTabaqueras()
        Try
            ComboBoxTabacaleras.Items.Clear()

            For Each fila In odataset.Tables("tbtabaqueras").Rows
                ComboBoxTabacaleras.Items.Add(fila.Item("Nombre").ToString())
            Next
        Catch ex As Exception
            MsgBox("Error al llenar el ComboBox: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub RellenarListBoxMarcas()
        Try
            ListBoxMarcas.Items.Clear()

            For Each fila In odataset.Tables("tbmarcas").Rows
                ListBoxMarcas.Items.Add(fila.Item("nombre_marca").ToString)
            Next

        Catch ex As Exception
            MsgBox("Error al llenar el ComboBox: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub RellenarLosPedidos()

        Try
            Module1.oconexion.Open()
            pedidosadaptador.Update(odataset, "tbpedidos")
            ListBoxPedidos.Items.Clear()
            For Each fila In odataset.Tables("tbpedidos").Rows
                ListBoxPedidos.Items.Add(fila("Id_pedido").ToString())
            Next

        Catch ex As Exception
            MsgBox("Error al llenar la lista de pedidos: " & ex.Message, MsgBoxStyle.Critical, "Error")

        Finally
            Module1.oconexion.Close()
        End Try


    End Sub

    Private Sub BorrarElPedidoYResetearID()

        Try
            Module1.oconexion.Open()

            'Borra todos los registros y reinicia el contador en una sola consulta
            Dim comandoReset As New OleDbCommand("DELETE FROM tbpedidos; ALTER TABLE tbpedidos ALTER COLUMN Id_pedido COUNTER (1,1);", oconexion)
            comandoReset.ExecuteNonQuery()

            'Limpiamos el dataset y la lista visual
            odataset.Tables("tbpedidos").Clear()
            ListBoxPedidos.Items.Clear()

            MsgBox("Pedidos eliminados y contador reiniciado.", MsgBoxStyle.Information, "Éxito")

        Catch ex As Exception
            MsgBox("Error al limpiar pedidos: " & ex.Message, MsgBoxStyle.Critical, "Error")
        Finally
            Module1.oconexion.Close()
        End Try

    End Sub

    Private Sub MostrarTotal()
        Dim totalPedidos As Double = CalcularTotalPedidos()
        If totalPedidos > 0 Then
            MessageBox.Show("Total de pedidos: " & totalPedidos.ToString("C"), "Total")
        End If
    End Sub

    'Funciones

    Private Function CalcularTotalPedidos() As Double
        Dim total As Double = 0

        Try
            Module1.oconexion.Open()
            Dim comando As New OleDbCommand("SELECT SUM(total) FROM tbpedidos", Module1.oconexion) 'CREA UN COMANDO USANDO LA CONEXION EN EL MODULE QUE SUMA LA COLUMNA TOTAL DE LA TABLA PEDIDOS
            Dim resultado = comando.ExecuteScalar()

            ' En una tabla de pedidos:
            ' Nothing -> La consulta falló completamente
            ' DBNull.Value -> Hay pedidos pero el total es NULL en la BD
            ' 0 -> Hay pedidos pero suman 0
            ' > 0 -> Hay pedidos con valor positivo

            If resultado IsNot Nothing AndAlso resultado IsNot DBNull.Value Then
                total = CDbl(resultado)
            End If

        Catch ex As Exception
            MsgBox("Error al calcular total: " & ex.Message)
        Finally
            Module1.oconexion.Close()
        End Try

        Return total

        'ExecuteScalar() : Ejecuta el comando y
        'Devuelve un único valor (la primera columna de la primera fila)
        'Perfecto para funciones agregadas como SUM, COUNT, AVG
        'En este caso, devuelve la suma total de todos los pedidos,PERO EN SI SIEMPRE DEVUELVE UN OBJECT
        'ExecuteReader() que devolvería múltiples filas
        'ExecuteNonQuery() que se usa para INSERT, UPDATE o DELETE devuelve el numero de filas afectadas
    End Function


End Class