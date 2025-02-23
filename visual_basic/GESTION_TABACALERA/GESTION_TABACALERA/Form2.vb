Public Class Form2


    'Las imagenes se llaman con picture.imagefromfile
    Private Sub ButtonVolver_Click(sender As Object, e As EventArgs) Handles ButtonVolver.Click
        Me.Hide()
        formulario1.Show()
    End Sub

    Private Sub ButtonMarcas_Click(sender As Object, e As EventArgs) Handles ButtonMarcas.Click
        Me.Hide()

        Form5.Show()

    End Sub

    Private Sub ButtonTabacaleras_Click(sender As Object, e As EventArgs) Handles ButtonTabacaleras.Click

        Me.Hide()
        Form4.Show()

    End Sub

End Class