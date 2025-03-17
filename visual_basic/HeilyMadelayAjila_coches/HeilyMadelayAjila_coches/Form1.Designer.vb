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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBoxFotoCoche = New System.Windows.Forms.PictureBox()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ComboBoxCoches = New System.Windows.Forms.ComboBox()
        Me.ListBoxClientes = New System.Windows.Forms.ListBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextBoxModelo = New System.Windows.Forms.TextBox()
        Me.TextBoxCilindrada = New System.Windows.Forms.TextBox()
        Me.TextBoxMotor = New System.Windows.Forms.TextBox()
        Me.TextBoxUnidades = New System.Windows.Forms.TextBox()
        Me.ButtonBorrar = New System.Windows.Forms.Button()
        Me.ButtonVender = New System.Windows.Forms.Button()
        Me.ButtonVendidos = New System.Windows.Forms.Button()
        Me.ButtonSalir = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        CType(Me.PictureBoxFotoCoche, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(97, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "FOTOGRAFIA"
        '
        'PictureBoxFotoCoche
        '
        Me.PictureBoxFotoCoche.Location = New System.Drawing.Point(80, 88)
        Me.PictureBoxFotoCoche.Name = "PictureBoxFotoCoche"
        Me.PictureBoxFotoCoche.Size = New System.Drawing.Size(138, 99)
        Me.PictureBoxFotoCoche.TabIndex = 1
        Me.PictureBoxFotoCoche.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(343, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "COCHES"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(629, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 17)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "CLIENTES"
        '
        'ComboBoxCoches
        '
        Me.ComboBoxCoches.FormattingEnabled = True
        Me.ComboBoxCoches.Location = New System.Drawing.Point(324, 88)
        Me.ComboBoxCoches.Name = "ComboBoxCoches"
        Me.ComboBoxCoches.Size = New System.Drawing.Size(121, 24)
        Me.ComboBoxCoches.TabIndex = 4
        '
        'ListBoxClientes
        '
        Me.ListBoxClientes.FormattingEnabled = True
        Me.ListBoxClientes.ItemHeight = 16
        Me.ListBoxClientes.Location = New System.Drawing.Point(613, 88)
        Me.ListBoxClientes.Name = "ListBoxClientes"
        Me.ListBoxClientes.Size = New System.Drawing.Size(120, 228)
        Me.ListBoxClientes.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(50, 251)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 17)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "MODELO"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(50, 305)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 17)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "CILINDRADA"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(50, 375)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 17)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "MOTOR"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(50, 439)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(78, 17)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "UNIDADES"
        '
        'TextBoxModelo
        '
        Me.TextBoxModelo.Location = New System.Drawing.Point(155, 251)
        Me.TextBoxModelo.Name = "TextBoxModelo"
        Me.TextBoxModelo.Size = New System.Drawing.Size(100, 22)
        Me.TextBoxModelo.TabIndex = 10
        '
        'TextBoxCilindrada
        '
        Me.TextBoxCilindrada.Location = New System.Drawing.Point(155, 305)
        Me.TextBoxCilindrada.Name = "TextBoxCilindrada"
        Me.TextBoxCilindrada.Size = New System.Drawing.Size(100, 22)
        Me.TextBoxCilindrada.TabIndex = 11
        '
        'TextBoxMotor
        '
        Me.TextBoxMotor.Location = New System.Drawing.Point(155, 370)
        Me.TextBoxMotor.Name = "TextBoxMotor"
        Me.TextBoxMotor.Size = New System.Drawing.Size(100, 22)
        Me.TextBoxMotor.TabIndex = 12
        '
        'TextBoxUnidades
        '
        Me.TextBoxUnidades.Location = New System.Drawing.Point(155, 439)
        Me.TextBoxUnidades.Name = "TextBoxUnidades"
        Me.TextBoxUnidades.Size = New System.Drawing.Size(100, 22)
        Me.TextBoxUnidades.TabIndex = 13
        '
        'ButtonBorrar
        '
        Me.ButtonBorrar.Location = New System.Drawing.Point(333, 386)
        Me.ButtonBorrar.Name = "ButtonBorrar"
        Me.ButtonBorrar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonBorrar.TabIndex = 14
        Me.ButtonBorrar.Text = "Borrar"
        Me.ButtonBorrar.UseVisualStyleBackColor = True
        '
        'ButtonVender
        '
        Me.ButtonVender.Location = New System.Drawing.Point(452, 386)
        Me.ButtonVender.Name = "ButtonVender"
        Me.ButtonVender.Size = New System.Drawing.Size(75, 23)
        Me.ButtonVender.TabIndex = 15
        Me.ButtonVender.Text = "Vender"
        Me.ButtonVender.UseVisualStyleBackColor = True
        '
        'ButtonVendidos
        '
        Me.ButtonVendidos.Location = New System.Drawing.Point(562, 386)
        Me.ButtonVendidos.Name = "ButtonVendidos"
        Me.ButtonVendidos.Size = New System.Drawing.Size(75, 23)
        Me.ButtonVendidos.TabIndex = 16
        Me.ButtonVendidos.Text = "Vendidos"
        Me.ButtonVendidos.UseVisualStyleBackColor = True
        '
        'ButtonSalir
        '
        Me.ButtonSalir.Location = New System.Drawing.Point(672, 386)
        Me.ButtonSalir.Name = "ButtonSalir"
        Me.ButtonSalir.Size = New System.Drawing.Size(75, 23)
        Me.ButtonSalir.TabIndex = 17
        Me.ButtonSalir.Text = "Salir"
        Me.ButtonSalir.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(382, 479)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(196, 17)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "AUTOMOVILES DE OCASION"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 542)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.ButtonSalir)
        Me.Controls.Add(Me.ButtonVendidos)
        Me.Controls.Add(Me.ButtonVender)
        Me.Controls.Add(Me.ButtonBorrar)
        Me.Controls.Add(Me.TextBoxUnidades)
        Me.Controls.Add(Me.TextBoxMotor)
        Me.Controls.Add(Me.TextBoxCilindrada)
        Me.Controls.Add(Me.TextBoxModelo)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ListBoxClientes)
        Me.Controls.Add(Me.ComboBoxCoches)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PictureBoxFotoCoche)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.PictureBoxFotoCoche, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBoxFotoCoche As PictureBox
    Friend WithEvents ColorDialog1 As ColorDialog
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents ComboBoxCoches As ComboBox
    Friend WithEvents ListBoxClientes As ListBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents TextBoxModelo As TextBox
    Friend WithEvents TextBoxCilindrada As TextBox
    Friend WithEvents TextBoxMotor As TextBox
    Friend WithEvents TextBoxUnidades As TextBox
    Friend WithEvents ButtonBorrar As Button
    Friend WithEvents ButtonVender As Button
    Friend WithEvents ButtonVendidos As Button
    Friend WithEvents ButtonSalir As Button
    Friend WithEvents Label8 As Label
End Class
