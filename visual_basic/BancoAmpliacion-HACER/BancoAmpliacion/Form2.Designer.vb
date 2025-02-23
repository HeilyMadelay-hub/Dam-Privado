<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Formulario2
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
        Me.LabelNombre = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBoxNumeroCuenta = New System.Windows.Forms.TextBox()
        Me.TextBoxNombre = New System.Windows.Forms.TextBox()
        Me.TextBoxSaldoInicial = New System.Windows.Forms.TextBox()
        Me.TextBoxSaldoActual = New System.Windows.Forms.TextBox()
        Me.ButtonNuevo = New System.Windows.Forms.Button()
        Me.ButtonPago = New System.Windows.Forms.Button()
        Me.ButtonIngreso = New System.Windows.Forms.Button()
        Me.ButtonBuscar = New System.Windows.Forms.Button()
        Me.ButtonVolver = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'LabelNombre
        '
        Me.LabelNombre.AutoSize = True
        Me.LabelNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelNombre.Location = New System.Drawing.Point(146, 103)
        Me.LabelNombre.Name = "LabelNombre"
        Me.LabelNombre.Size = New System.Drawing.Size(68, 20)
        Me.LabelNombre.TabIndex = 0
        Me.LabelNombre.Text = "Nombre"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(146, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(123, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Numero cuenta"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(146, 159)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 20)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Saldo Inicial"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(146, 219)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(103, 20)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Saldo Actual"
        '
        'TextBoxNumeroCuenta
        '
        Me.TextBoxNumeroCuenta.Location = New System.Drawing.Point(325, 42)
        Me.TextBoxNumeroCuenta.Name = "TextBoxNumeroCuenta"
        Me.TextBoxNumeroCuenta.Size = New System.Drawing.Size(100, 22)
        Me.TextBoxNumeroCuenta.TabIndex = 4
        '
        'TextBoxNombre
        '
        Me.TextBoxNombre.Location = New System.Drawing.Point(325, 101)
        Me.TextBoxNombre.Name = "TextBoxNombre"
        Me.TextBoxNombre.Size = New System.Drawing.Size(100, 22)
        Me.TextBoxNombre.TabIndex = 5
        '
        'TextBoxSaldoInicial
        '
        Me.TextBoxSaldoInicial.Location = New System.Drawing.Point(325, 159)
        Me.TextBoxSaldoInicial.Name = "TextBoxSaldoInicial"
        Me.TextBoxSaldoInicial.Size = New System.Drawing.Size(100, 22)
        Me.TextBoxSaldoInicial.TabIndex = 6
        '
        'TextBoxSaldoActual
        '
        Me.TextBoxSaldoActual.Location = New System.Drawing.Point(325, 217)
        Me.TextBoxSaldoActual.Multiline = True
        Me.TextBoxSaldoActual.Name = "TextBoxSaldoActual"
        Me.TextBoxSaldoActual.Size = New System.Drawing.Size(100, 22)
        Me.TextBoxSaldoActual.TabIndex = 7
        '
        'ButtonNuevo
        '
        Me.ButtonNuevo.Location = New System.Drawing.Point(536, 42)
        Me.ButtonNuevo.Name = "ButtonNuevo"
        Me.ButtonNuevo.Size = New System.Drawing.Size(165, 34)
        Me.ButtonNuevo.TabIndex = 8
        Me.ButtonNuevo.Text = "Nuevo"
        Me.ButtonNuevo.UseVisualStyleBackColor = True
        '
        'ButtonPago
        '
        Me.ButtonPago.Location = New System.Drawing.Point(536, 159)
        Me.ButtonPago.Name = "ButtonPago"
        Me.ButtonPago.Size = New System.Drawing.Size(165, 36)
        Me.ButtonPago.TabIndex = 9
        Me.ButtonPago.Text = "Pagos"
        Me.ButtonPago.UseVisualStyleBackColor = True
        '
        'ButtonIngreso
        '
        Me.ButtonIngreso.Location = New System.Drawing.Point(536, 100)
        Me.ButtonIngreso.Name = "ButtonIngreso"
        Me.ButtonIngreso.Size = New System.Drawing.Size(165, 39)
        Me.ButtonIngreso.TabIndex = 10
        Me.ButtonIngreso.Text = "Ingreso"
        Me.ButtonIngreso.UseVisualStyleBackColor = True
        '
        'ButtonBuscar
        '
        Me.ButtonBuscar.Location = New System.Drawing.Point(536, 216)
        Me.ButtonBuscar.Name = "ButtonBuscar"
        Me.ButtonBuscar.Size = New System.Drawing.Size(165, 34)
        Me.ButtonBuscar.TabIndex = 11
        Me.ButtonBuscar.Text = "Buscar"
        Me.ButtonBuscar.UseVisualStyleBackColor = True
        '
        'ButtonVolver
        '
        Me.ButtonVolver.Location = New System.Drawing.Point(536, 270)
        Me.ButtonVolver.Name = "ButtonVolver"
        Me.ButtonVolver.Size = New System.Drawing.Size(165, 34)
        Me.ButtonVolver.TabIndex = 12
        Me.ButtonVolver.Text = "Volver"
        Me.ButtonVolver.UseVisualStyleBackColor = True
        '
        'Formulario2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(789, 333)
        Me.Controls.Add(Me.ButtonVolver)
        Me.Controls.Add(Me.ButtonBuscar)
        Me.Controls.Add(Me.ButtonIngreso)
        Me.Controls.Add(Me.ButtonPago)
        Me.Controls.Add(Me.ButtonNuevo)
        Me.Controls.Add(Me.TextBoxSaldoActual)
        Me.Controls.Add(Me.TextBoxSaldoInicial)
        Me.Controls.Add(Me.TextBoxNombre)
        Me.Controls.Add(Me.TextBoxNumeroCuenta)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LabelNombre)
        Me.Name = "Formulario2"
        Me.Text = "Operar"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabelNombre As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBoxNumeroCuenta As TextBox
    Friend WithEvents TextBoxNombre As TextBox
    Friend WithEvents TextBoxSaldoInicial As TextBox
    Friend WithEvents TextBoxSaldoActual As TextBox
    Friend WithEvents ButtonNuevo As Button
    Friend WithEvents ButtonPago As Button
    Friend WithEvents ButtonIngreso As Button
    Friend WithEvents ButtonBuscar As Button
    Friend WithEvents ButtonVolver As Button
End Class
