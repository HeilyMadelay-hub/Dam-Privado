<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form4
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
        Me.Nombre = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBoxNombre = New System.Windows.Forms.TextBox()
        Me.TextBoxDireccion = New System.Windows.Forms.TextBox()
        Me.ButtonAltaTabaqueras = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ButtonVolver
        '
        Me.ButtonVolver.Location = New System.Drawing.Point(25, 22)
        Me.ButtonVolver.Name = "ButtonVolver"
        Me.ButtonVolver.Size = New System.Drawing.Size(85, 36)
        Me.ButtonVolver.TabIndex = 0
        Me.ButtonVolver.Text = "Volver"
        Me.ButtonVolver.UseVisualStyleBackColor = True
        '
        'Nombre
        '
        Me.Nombre.AutoSize = True
        Me.Nombre.Location = New System.Drawing.Point(75, 121)
        Me.Nombre.Name = "Nombre"
        Me.Nombre.Size = New System.Drawing.Size(58, 17)
        Me.Nombre.TabIndex = 1
        Me.Nombre.Text = "Nombre"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(75, 187)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Direccion"
        '
        'TextBoxNombre
        '
        Me.TextBoxNombre.Location = New System.Drawing.Point(211, 121)
        Me.TextBoxNombre.Name = "TextBoxNombre"
        Me.TextBoxNombre.Size = New System.Drawing.Size(100, 22)
        Me.TextBoxNombre.TabIndex = 3
        '
        'TextBoxDireccion
        '
        Me.TextBoxDireccion.Location = New System.Drawing.Point(211, 182)
        Me.TextBoxDireccion.Name = "TextBoxDireccion"
        Me.TextBoxDireccion.Size = New System.Drawing.Size(100, 22)
        Me.TextBoxDireccion.TabIndex = 4
        '
        'ButtonAltaTabaqueras
        '
        Me.ButtonAltaTabaqueras.Location = New System.Drawing.Point(151, 253)
        Me.ButtonAltaTabaqueras.Name = "ButtonAltaTabaqueras"
        Me.ButtonAltaTabaqueras.Size = New System.Drawing.Size(133, 36)
        Me.ButtonAltaTabaqueras.TabIndex = 5
        Me.ButtonAltaTabaqueras.Text = "Alta tabaqueras"
        Me.ButtonAltaTabaqueras.UseVisualStyleBackColor = True
        '
        'Form4
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(433, 341)
        Me.Controls.Add(Me.ButtonAltaTabaqueras)
        Me.Controls.Add(Me.TextBoxDireccion)
        Me.Controls.Add(Me.TextBoxNombre)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Nombre)
        Me.Controls.Add(Me.ButtonVolver)
        Me.Name = "Form4"
        Me.Text = "Tabacaleras"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ButtonVolver As Button
    Friend WithEvents Nombre As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBoxNombre As TextBox
    Friend WithEvents TextBoxDireccion As TextBox
    Friend WithEvents ButtonAltaTabaqueras As Button
End Class
