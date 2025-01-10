<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.lblpalabrabuscar = New System.Windows.Forms.Label()
        Me.TextBoxPalabra = New System.Windows.Forms.TextBox()
        Me.BtbBuscarCoincidencias = New System.Windows.Forms.Button()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.SuspendLayout()
        '
        'lblpalabrabuscar
        '
        Me.lblpalabrabuscar.AutoSize = True
        Me.lblpalabrabuscar.Location = New System.Drawing.Point(78, 63)
        Me.lblpalabrabuscar.Name = "lblpalabrabuscar"
        Me.lblpalabrabuscar.Size = New System.Drawing.Size(164, 17)
        Me.lblpalabrabuscar.TabIndex = 0
        Me.lblpalabrabuscar.Text = "Palabra o frase a buscar"
        '
        'TextBoxPalabra
        '
        Me.TextBoxPalabra.Location = New System.Drawing.Point(273, 63)
        Me.TextBoxPalabra.Name = "TextBoxPalabra"
        Me.TextBoxPalabra.Size = New System.Drawing.Size(342, 22)
        Me.TextBoxPalabra.TabIndex = 2
        '
        'BtbBuscarCoincidencias
        '
        Me.BtbBuscarCoincidencias.Location = New System.Drawing.Point(264, 115)
        Me.BtbBuscarCoincidencias.Name = "BtbBuscarCoincidencias"
        Me.BtbBuscarCoincidencias.Size = New System.Drawing.Size(230, 23)
        Me.BtbBuscarCoincidencias.TabIndex = 3
        Me.BtbBuscarCoincidencias.Text = "Buscar Coincidencias"
        Me.BtbBuscarCoincidencias.UseVisualStyleBackColor = True
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(81, 167)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(534, 222)
        Me.RichTextBox1.TabIndex = 4
        Me.RichTextBox1.Text = "Copiar cualquier texto"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(691, 450)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.BtbBuscarCoincidencias)
        Me.Controls.Add(Me.TextBoxPalabra)
        Me.Controls.Add(Me.lblpalabrabuscar)
        Me.Name = "Form1"
        Me.Text = "Control RichTextBox"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblpalabrabuscar As Label
    Friend WithEvents TextBoxPalabra As TextBox
    Friend WithEvents BtbBuscarCoincidencias As Button
    Friend WithEvents RichTextBox1 As RichTextBox
End Class
