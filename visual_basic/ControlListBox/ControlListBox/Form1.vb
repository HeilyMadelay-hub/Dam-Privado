Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim archivo As String

        Me.OpenFileDialog1.Title = "Seleccionar archivo texto"

        Me.OpenFileDialog1.Filter = "archivos de texto * .txt | *.txt"
        Me.OpenFileDialog1.ShowDialog()
        archivo = OpenFileDialog1.FileName

        Process.Start("notepad.exe", archivo)

    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim myOpenFile As New OpenFileDialog

        ' Dando las características al archivo que abriremos
        With myOpenFile
            .InitialDirectory = "C:\"
            .Filter = "All Files (.)|."
            .FilterIndex = 1
            ' Restaurar el directorio de la aplicación al cerrar el cuadro de diálogo
            .RestoreDirectory = True
        End With

        If myOpenFile.ShowDialog() = DialogResult.OK Then
            ' El propio RichTextBox cuenta con el método LoadFile() para poder cargar el archivo que seleccionemos.
            RichTextBox1.LoadFile(myOpenFile.FileName, RichTextBoxStreamType.PlainText)
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim archivo As String
        Dim mySaveFile As New SaveFileDialog
        mySaveFile.ShowDialog()
        archivo = mySaveFile.FileName
        If mySaveFile.FileName <> "" Then
            RichTextBox1.SaveFile(mySaveFile.FileName, RichTextBoxStreamType.PlainText)
        End If
    End Sub

End Class
