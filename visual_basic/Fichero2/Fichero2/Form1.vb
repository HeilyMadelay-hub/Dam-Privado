Imports System.Text.RegularExpressions

Public Class Form1

    Private Sub botonBuscar_Click(sender As Object, e As EventArgs) Handles BtbBuscarCoincidencias.Click
        ' Validación del texto a buscar
        If String.IsNullOrWhiteSpace(TextBoxPalabra.Text) Then
            MsgBox("Por favor, ingresa una palabra o frase para buscar.", MsgBoxStyle.Exclamation)
            Return
        End If

        ' Llama al procedimiento buscar_patron
        buscar_patron(TextBoxPalabra.Text, RichTextBox1, Color.Red, Color.Yellow)
    End Sub

    Private Sub buscar_patron(ByVal textoabuscar As String,
                          ByVal objetotexto As Windows.Forms.RichTextBox,
                          ByVal colortexto As Color, ByVal colorfondo As Color)

        Dim coincidencias As MatchCollection
        Dim palabra As Match

        Try
            ' Crea la expresión regular para buscar el texto
            Dim cadenaabuscar As New Regex(textoabuscar, RegexOptions.IgnoreCase)
            coincidencias = cadenaabuscar.Matches(objetotexto.Text)

            ' Restaurar el color original del texto
            With objetotexto
                .SelectAll()
                .SelectionColor = Color.Black
                .SelectionBackColor = Color.White
            End With

            ' Resaltar coincidencias
            For Each palabra In coincidencias
                With objetotexto
                    .SelectionStart = palabra.Index
                    .SelectionLength = palabra.Length
                    .SelectionColor = colortexto
                    .SelectionBackColor = colorfondo
                End With
            Next

            ' Mover el cursor al final del texto
            objetotexto.SelectionStart = objetotexto.Text.Length
            objetotexto.SelectionLength = 0

        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        End Try

    End Sub


End Class
