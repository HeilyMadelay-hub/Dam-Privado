Imports System.Data.OleDb
Imports System.Data
Module Module1

    Public oconexion As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Application.StartupPath & "\dbtabaqueras.mdb;")

    Public formulario1 As New Form1()
    Public formulario2 As New Form2()
    Public formulario3 As New Form3()
    Public formulario4 As New Form4()
    Public formulario5 As New Form5()
    Public formulario6 As New Form6()

End Module
