Imports System.Data
Imports System.Data.OleDb
Public Class Form1
    Dim oconexion As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Application.StartupPath & "\dbempresas.mdb;")
    Dim odataadapter As New OleDbDataAdapter("SELECT * FROM tbempresas", oconexion)
    Dim odataset As New DataSet

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
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
End Class
