<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form5
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextBoxNombreMarca = New System.Windows.Forms.TextBox()
        Me.TextBoxNombreTabaco = New System.Windows.Forms.TextBox()
        Me.TextBoxNumeroCigarillos = New System.Windows.Forms.TextBox()
        Me.TextBoxNicotina = New System.Windows.Forms.TextBox()
        Me.TextBoxPrecio = New System.Windows.Forms.TextBox()
        Me.ButtonAltaMarcas = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ButtonVolver
        '
        Me.ButtonVolver.Location = New System.Drawing.Point(12, 22)
        Me.ButtonVolver.Name = "ButtonVolver"
        Me.ButtonVolver.Size = New System.Drawing.Size(86, 32)
        Me.ButtonVolver.TabIndex = 0
        Me.ButtonVolver.Text = "Volver"
        Me.ButtonVolver.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(47, 95)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Nombre Marca"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(47, 155)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(110, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Nombre Tabaco"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(47, 209)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 17)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Nª Cigarrillos"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(47, 270)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 17)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Nicotina"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(47, 334)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 17)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Precio"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(47, 394)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(0, 17)
        Me.Label6.TabIndex = 6
        '
        'TextBoxNombreMarca
        '
        Me.TextBoxNombreMarca.Location = New System.Drawing.Point(193, 90)
        Me.TextBoxNombreMarca.Name = "TextBoxNombreMarca"
        Me.TextBoxNombreMarca.Size = New System.Drawing.Size(345, 22)
        Me.TextBoxNombreMarca.TabIndex = 7
        '
        'TextBoxNombreTabaco
        '
        Me.TextBoxNombreTabaco.Location = New System.Drawing.Point(193, 150)
        Me.TextBoxNombreTabaco.Name = "TextBoxNombreTabaco"
        Me.TextBoxNombreTabaco.Size = New System.Drawing.Size(345, 22)
        Me.TextBoxNombreTabaco.TabIndex = 8
        '
        'TextBoxNumeroCigarillos
        '
        Me.TextBoxNumeroCigarillos.Location = New System.Drawing.Point(193, 209)
        Me.TextBoxNumeroCigarillos.Name = "TextBoxNumeroCigarillos"
        Me.TextBoxNumeroCigarillos.Size = New System.Drawing.Size(345, 22)
        Me.TextBoxNumeroCigarillos.TabIndex = 9
        '
        'TextBoxNicotina
        '
        Me.TextBoxNicotina.Location = New System.Drawing.Point(193, 265)
        Me.TextBoxNicotina.Name = "TextBoxNicotina"
        Me.TextBoxNicotina.Size = New System.Drawing.Size(345, 22)
        Me.TextBoxNicotina.TabIndex = 10
        '
        'TextBoxPrecio
        '
        Me.TextBoxPrecio.Location = New System.Drawing.Point(193, 329)
        Me.TextBoxPrecio.Name = "TextBoxPrecio"
        Me.TextBoxPrecio.Size = New System.Drawing.Size(345, 22)
        Me.TextBoxPrecio.TabIndex = 11
        '
        'ButtonAltaMarcas
        '
        Me.ButtonAltaMarcas.Location = New System.Drawing.Point(633, 203)
        Me.ButtonAltaMarcas.Name = "ButtonAltaMarcas"
        Me.ButtonAltaMarcas.Size = New System.Drawing.Size(102, 38)
        Me.ButtonAltaMarcas.TabIndex = 12
        Me.ButtonAltaMarcas.Text = "Alta Marcas"
        Me.ButtonAltaMarcas.UseVisualStyleBackColor = True
        '
        'Form5
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(778, 391)
        Me.Controls.Add(Me.ButtonAltaMarcas)
        Me.Controls.Add(Me.TextBoxPrecio)
        Me.Controls.Add(Me.TextBoxNicotina)
        Me.Controls.Add(Me.TextBoxNumeroCigarillos)
        Me.Controls.Add(Me.TextBoxNombreTabaco)
        Me.Controls.Add(Me.TextBoxNombreMarca)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ButtonVolver)
        Me.Name = "Form5"
        Me.Text = "Marcas"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ButtonVolver As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents TextBoxNombreMarca As TextBox
    Friend WithEvents TextBoxNombreTabaco As TextBox
    Friend WithEvents TextBoxNumeroCigarillos As TextBox
    Friend WithEvents TextBoxNicotina As TextBox
    Friend WithEvents TextBoxPrecio As TextBox
    Friend WithEvents ButtonAltaMarcas As Button
End Class
