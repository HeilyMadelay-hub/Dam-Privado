Imports System.Data
Imports System.Data.OleDb
Public Class FormBanco

    Private oconexion As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Application.StartupPath & "\dbempresas.mdb")
    Private formulario2 As Form2
    Private formulario3 As Form3

    Private Sub FormBanco_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            oconexion.Open()
            oconexion.Close()
        Catch ex As Exception
            MessageBox.Show("Error al conectar con la base de datos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'By initializing forms In the constructor, you

    'Prepare forms In memory beforehand
    'Avoid repeated Object creation
    'Improve performance
    'Ensure forms are ready When needed

    Public Sub New()
        InitializeComponent()
        formulario2 = New Form2()
        formulario3 = New Form3()
    End Sub

    Private Sub ButtonOperar_Click(sender As Object, e As EventArgs) Handles ButtonOperar.Click
        formulario2.Show()
        formulario3.Hide()
    End Sub

    Private Sub ButtonGestion_Click(sender As Object, e As EventArgs) Handles ButtonGestion.Click
        formulario3.Show()
        formulario2.Hide()
    End Sub

    Private Sub ButtonSalir_Click(sender As Object, e As EventArgs) Handles ButtonSalir.Click
        Close()
    End Sub
End Class
