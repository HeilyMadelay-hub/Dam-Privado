Public Class Form1

    Private ColorDialog1 As New ColorDialog()

    Private FontDialog1 As New FontDialog()

    ' Evento para cambiar el fondo de la etiqueta lblDAM
    Private Sub Fondo_Click(sender As Object, e As EventArgs) Handles lblDAM.Click
        Try
            ' Mostrar el cuadro de diálogo para seleccionar color
            If ColorDialog1.ShowDialog() = DialogResult.OK Then
                lblDAM.BackColor = ColorDialog1.Color
            End If
        Catch ex As Exception
            MessageBox.Show("Ocurrió un error al cambiar el color: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Botón para cargar una imagen en PictureBox1
    Private Sub CargarImagen_Click(sender As Object, e As EventArgs) Handles lblImagen.Click
        Try
            Dim OpenFileDialog1 As New OpenFileDialog()
            OpenFileDialog1.Filter = "Archivos de Imagen|*.jpg;*.jpeg;*.png;*.bmp"

            If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
                PictureBox1.Image = Image.FromFile(OpenFileDialog1.FileName)
            End If
        Catch ex As Exception
            MessageBox.Show("Ocurrió un error al cargar la imagen: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Botón para restablecer la imagen de PictureBox1
    Private Sub RestablecerImagen_Click(sender As Object, e As EventArgs) Handles lblBorrarImagen.Click
        Try
            PictureBox1.Image = Nothing
        Catch ex As Exception
            MessageBox.Show("Ocurrió un error al restablecer la imagen: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub lblAbrirAplicacion_Click(sender As Object, e As EventArgs) Handles lblAbrirAplicacion.Click
        Try
            ' Crear el cuadro de diálogo para seleccionar un archivo
            Dim OpenFileDialog1 As New OpenFileDialog()
            OpenFileDialog1.Filter = "Archivos Ejecutables|*.exe|Todos los Archivos|*.*"

            ' Verificar si el usuario seleccionó un archivo
            If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
                ' Iniciar el proceso de la aplicación seleccionada
                Process.Start(OpenFileDialog1.FileName)
            End If
        Catch ex As Exception
            ' Manejo de excepciones en caso de error
            MessageBox.Show("Ocurrió un error al intentar abrir la aplicación: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Letra_Click(sender As Object, e As EventArgs) Handles lblColorLetra.Click
        Try
            ' Mostrar el cuadro de diálogo para seleccionar color de letra
            If ColorDialog1.ShowDialog() = DialogResult.OK Then
                lblDAM.ForeColor = ColorDialog1.Color
            End If
        Catch ex As Exception
            MessageBox.Show("Ocurrió un error al cambiar el color de la letra: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Cambiar el tipo de letra de lblDAM
    Private Sub TipoLetra_Click(sender As Object, e As EventArgs) Handles lblTipoLetra.Click
        Try
            ' Mostrar el cuadro de diálogo para seleccionar la fuente (tipo de letra)
            If FontDialog1.ShowDialog() = DialogResult.OK Then
                lblDAM.Font = FontDialog1.Font
            End If
        Catch ex As Exception
            MessageBox.Show("Ocurrió un error al cambiar el tipo de letra: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub lblColorFondo_Click(sender As Object, e As EventArgs) Handles lblColorFondo.Click
        Try
            ' Mostrar el cuadro de diálogo para seleccionar color
            If ColorDialog1.ShowDialog() = DialogResult.OK Then
                lblDAM.BackColor = ColorDialog1.Color
            End If
        Catch ex As Exception
            MessageBox.Show("Ocurrió un error al cambiar el color: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class


