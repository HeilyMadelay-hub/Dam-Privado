Imports System.IO
Imports System.Diagnostics

Public Class Form1
    ' Save button (Button1)
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim saveFileDialog As New SaveFileDialog()
        saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
        saveFileDialog.Title = "Guardar archivo"

        If saveFileDialog.ShowDialog() = DialogResult.OK Then
            Try
                File.WriteAllText(saveFileDialog.FileName, TextBoxComentarios.Text)
                MessageBox.Show("Archivo guardado correctamente.", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("Error al guardar el archivo: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub


    ' View button (Button2)
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
        openFileDialog.Title = "Seleccionar archivo para ver"

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            Try
                Process.Start("notepad.exe", openFileDialog.FileName)
            Catch ex As Exception
                MessageBox.Show("Error al abrir el archivo con el visor predeterminado: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    ' Open button (Button3)
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
        openFileDialog.Title = "Abrir archivo"

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            Try
                TextBoxComentarios.Text = File.ReadAllText(openFileDialog.FileName)
                MessageBox.Show("Archivo cargado correctamente.", "Abrir archivo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("Error al abrir el archivo: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

End Class
