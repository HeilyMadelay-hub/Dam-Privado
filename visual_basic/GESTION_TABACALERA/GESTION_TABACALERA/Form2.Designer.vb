﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ButtonVolver = New System.Windows.Forms.Button()
        Me.ButtonTabacaleras = New System.Windows.Forms.Button()
        Me.ButtonMarcas = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ButtonVolver
        '
        Me.ButtonVolver.Location = New System.Drawing.Point(12, 12)
        Me.ButtonVolver.Name = "ButtonVolver"
        Me.ButtonVolver.Size = New System.Drawing.Size(75, 23)
        Me.ButtonVolver.TabIndex = 0
        Me.ButtonVolver.Text = "Volver"
        Me.ButtonVolver.UseVisualStyleBackColor = True
        '
        'ButtonTabacaleras
        '
        Me.ButtonTabacaleras.Location = New System.Drawing.Point(172, 164)
        Me.ButtonTabacaleras.Name = "ButtonTabacaleras"
        Me.ButtonTabacaleras.Size = New System.Drawing.Size(128, 39)
        Me.ButtonTabacaleras.TabIndex = 1
        Me.ButtonTabacaleras.Text = "Tabacaleras"
        Me.ButtonTabacaleras.UseVisualStyleBackColor = True
        '
        'ButtonMarcas
        '
        Me.ButtonMarcas.Location = New System.Drawing.Point(172, 107)
        Me.ButtonMarcas.Name = "ButtonMarcas"
        Me.ButtonMarcas.Size = New System.Drawing.Size(128, 39)
        Me.ButtonMarcas.TabIndex = 2
        Me.ButtonMarcas.Text = "Marcas"
        Me.ButtonMarcas.UseVisualStyleBackColor = True
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(470, 273)
        Me.Controls.Add(Me.ButtonMarcas)
        Me.Controls.Add(Me.ButtonTabacaleras)
        Me.Controls.Add(Me.ButtonVolver)
        Me.Name = "Form2"
        Me.Text = "Gestion"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ButtonVolver As Button
    Friend WithEvents ButtonTabacaleras As Button
    Friend WithEvents ButtonMarcas As Button
End Class
