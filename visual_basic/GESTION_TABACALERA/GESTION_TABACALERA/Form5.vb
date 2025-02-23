Imports System.Data.OleDb
Imports System.Data

Public Class Form5

    'Cuando creas un CommandBuilder:

    'Analiza la consulta Select del adaptador
    'Identifica la tabla y columnas
    'Crea automáticamente las sentencias SQL necesarias

    'CUÁNDO ES NECESARIO :vbCopyadaptador.Update(dataset, "nombreTabla")  'Necesita CommandBuilder

    'CUÁNDO NO ES NECESARIO: vbCopyadaptador.Fill(dataset, "nombreTabla")    'No necesita CommandBuilder

    ' RESTRICCIONES IMPORTANTES:

    '  La consulta Select debe ser de una sola tabla
    '  La tabla debe tener una clave primaria
    '  No funciona con consultas JOIN o vistas complejas

    '  EJEMPLO DE USO COMPLETO

    '   Public Class Form5
    '        Dim marcasadaptador As New OleDbDataAdapter("SELECT * FROM tbtabaqueras", conexion)
    '        Dim odataset As New DataSet()
    '        Dim obuildermarcas As New OleDbCommandBuilder(marcasadaptador)

    '        ' Para insertar un nuevo registro
    '        Private Sub InsertarRegistro()
    '            Dim nuevaFila As DataRow = odataset.Tables("tbtabaqueras").NewRow()
    '            nuevaFila("nombre") = "Nueva Tabaquera"
    '            odataset.Tables("tbtabaqueras").Rows.Add(nuevaFila)

    '            ' Aquí el CommandBuilder genera automáticamente el INSERT
    '            marcasadaptador.Update(odataset, "tbtabaqueras")
    '        End Sub
    '    End Class

    'BUENAS PRÁCTICAS

    'Declararlo a nivel de clase
    'Crear uno por cada adaptador
    'Mantener la variable aunque no se use directamente
    'Usar Try/Catch al actualizar datos

    'Es como un "asistente invisible" que te ayuda a mantener sincronizados los datos entre tu aplicación y la base de datos,
    'generando automáticamente el SQL necesario para las operaciones de modificación de datos.

    Dim marcasadaptador As New OleDbDataAdapter("SELECT * FROM tbmarcas", Module1.oconexion)
    Dim odataset As New DataSet()
    Dim obuildermarcas As New OleDbCommandBuilder(marcasadaptador) ' Para modificar,insertar o borrar datos


    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Module1.oconexion.Open()
            marcasadaptador.Fill(odataset, "tbmarcas")

            'Ejecuta la consulta de marcasadaptador,crea una nueva tabla en el dataset,copia los datos de la base,nombra la tabla en el dataset tbtabaqueras
            'El primer parametro el dataset donde se guardan los datos y el segundo parametro el nombre que tendra la tabla en el dataset
            'Se ejecuta cuando el formulario se carga y asegura que esten disponibles desde el inicio pudiendo asi mostrar los datos en contrales
            'Con el fill creas una copia de trabajo en memoria permitiendo trabajar sin conexion reduciendo la carga al servidor

            Module1.oconexion.Close()
            MessageBox.Show("Datos cargados correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception

            MessageBox.Show("Error al cargar los datos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    'Verifica que no exista una marca con el mismo nombre
    'Si no existe, crea un nuevo registro con los datos del formulario
    'Intenta guardar los cambios en la base de datos y manejar posibles errores y muestra mensajes apropiados al usuario

    Private Sub ButtonAltaMarcas_Click(sender As Object, e As EventArgs) Handles ButtonAltaMarcas.Click

        Dim ofila As DataRow
        Dim duplicado As Boolean = False
        Dim numCigarrillos As Integer
        Dim precio As Decimal
        Dim nicotina As Decimal

        'Validar que los campos no estén vacíos
        If String.IsNullOrEmpty(TextBoxNombreMarca.Text) OrElse
           String.IsNullOrEmpty(TextBoxNombreTabaco.Text) OrElse
           String.IsNullOrEmpty(TextBoxNumeroCigarillos.Text) OrElse
           String.IsNullOrEmpty(TextBoxNicotina.Text) OrElse
           String.IsNullOrEmpty(TextBoxPrecio.Text) Then
            MessageBox.Show("Todos los campos son obligatorios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        'Validación nombre marca
        If Not TextBoxNombreMarca.Text.All(Function(c) Char.IsLetter(c) OrElse c = " ") Then
            MessageBox.Show("El nombre de la marca solo puede contener letras", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If TextBoxNombreMarca.Text.Length > 50 Then
            MessageBox.Show("El nombre de la marca es demasiado largo (máximo 50 caracteres)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        'Validación nombre tabaco
        If Not TextBoxNombreTabaco.Text.All(Function(c) Char.IsLetter(c) OrElse c = " ") Then
            MessageBox.Show("El nombre del tabaco solo puede contener letras", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If TextBoxNombreTabaco.Text.Length > 50 Then
            MessageBox.Show("El nombre del tabaco es demasiado largo (máximo 50 caracteres)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        'Validar que los valores numéricos sean correctos
        If Not Integer.TryParse(TextBoxNumeroCigarillos.Text, numCigarrillos) Then
            MessageBox.Show("El número de cigarrillos debe ser un número entero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If Not Decimal.TryParse(TextBoxNicotina.Text, nicotina) Then
            MessageBox.Show("La nicotina debe ser un número decimal", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If Not Decimal.TryParse(TextBoxPrecio.Text, precio) Then
            MessageBox.Show("El precio debe ser un número decimal", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        'Validar rangos de valores
        If numCigarrillos <= 0 OrElse numCigarrillos > 40 Then
            MessageBox.Show("El número de cigarrillos debe estar entre 1 y 40", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If nicotina < 0 OrElse nicotina > 3 Then
            MessageBox.Show("La nicotina debe estar entre 0 y 3 mg", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If precio <= 0 OrElse precio > 15 Then
            MessageBox.Show("El precio debe estar entre 0.01€ y 15€", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        'Verifica que no exista una marca con el mismo nombre
        For Each fila As DataRow In odataset.Tables("tbmarcas").Rows
            If fila("nombre_marca").ToString() = TextBoxNombreMarca.Text Then
                MessageBox.Show("El nombre ya existe, por favor pruebe con otro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                duplicado = True
                Exit For
            End If
        Next

        'Si no existe, crea un nuevo registro con los datos del formulario

        If Not duplicado Then

            'La nueva linea que vas a añadir con todas las caracteristicas

            ofila = odataset.Tables("tbmarcas").NewRow
            ofila("nombre_marca") = TextBoxNombreMarca.Text
            ofila("Nombretb") = TextBoxNombreTabaco.Text
            ofila("Nº_Cigarrillos") = numCigarrillos
            ofila("Nicotina") = nicotina
            ofila("Precio") = precio

            'Ya añadiendo
            odataset.Tables("tbmarcas").Rows.Add(ofila)

            'Intenta guardar los cambios en la base de datos y manejar posibles errores y muestra mensajes apropiados al usuario

            Try
                oconexion.Open()
                marcasadaptador.Update(odataset, "tbmarcas") 'Actualizando la nueva fila
                oconexion.Close()

                LimpiarCampos()

                MessageBox.Show("Se ha dado de alta correctamente la marca", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch ex As Exception
                MessageBox.Show("Error:No se ha podido dar de alta la marca: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If

    End Sub

    Private Sub LimpiarCampos()
        TextBoxNombreMarca.Clear()
        TextBoxNombreTabaco.Clear()
        TextBoxNumeroCigarillos.Clear()
        TextBoxNicotina.Clear()
        TextBoxPrecio.Clear()
    End Sub

    Private Sub ButtonVolver_Click(sender As Object, e As EventArgs) Handles ButtonVolver.Click
        Me.Hide()
        formulario2.Show()
    End Sub

End Class