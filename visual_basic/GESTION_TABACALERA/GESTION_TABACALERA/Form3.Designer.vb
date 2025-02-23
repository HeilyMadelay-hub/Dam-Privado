<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form3
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ListBoxMarcas = New System.Windows.Forms.ListBox()
        Me.ComboBoxTabacaleras = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ButtonBorrarPedido = New System.Windows.Forms.Button()
        Me.ButtonRealizarPedido = New System.Windows.Forms.Button()
        Me.ListBoxPedidos = New System.Windows.Forms.ListBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ButtonVerTablas = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Promocion = New System.Windows.Forms.Label()
        Me.TextBoxPromocion = New System.Windows.Forms.TextBox()
        Me.TextBoxPrecio = New System.Windows.Forms.TextBox()
        Me.TextBoxNicotina = New System.Windows.Forms.TextBox()
        Me.TextBoxNumeroCigarrillos = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.NumericUpDownUnidades = New System.Windows.Forms.NumericUpDown()
        Me.CheckBoxCartones = New System.Windows.Forms.CheckBox()
        Me.Unidades = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.NumericUpDownUnidades, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ButtonVolver
        '
        Me.ButtonVolver.Location = New System.Drawing.Point(22, 34)
        Me.ButtonVolver.Name = "ButtonVolver"
        Me.ButtonVolver.Size = New System.Drawing.Size(75, 23)
        Me.ButtonVolver.TabIndex = 0
        Me.ButtonVolver.Text = "Volver"
        Me.ButtonVolver.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.ListBoxMarcas)
        Me.Panel1.Controls.Add(Me.ComboBoxTabacaleras)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(32, 81)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(476, 235)
        Me.Panel1.TabIndex = 1
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(312, 82)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(130, 118)
        Me.PictureBox1.TabIndex = 5
        Me.PictureBox1.TabStop = False
        '
        'ListBoxMarcas
        '
        Me.ListBoxMarcas.FormattingEnabled = True
        Me.ListBoxMarcas.ItemHeight = 16
        Me.ListBoxMarcas.Location = New System.Drawing.Point(167, 84)
        Me.ListBoxMarcas.Name = "ListBoxMarcas"
        Me.ListBoxMarcas.Size = New System.Drawing.Size(113, 116)
        Me.ListBoxMarcas.TabIndex = 4
        '
        'ComboBoxTabacaleras
        '
        Me.ComboBoxTabacaleras.FormattingEnabled = True
        Me.ComboBoxTabacaleras.Location = New System.Drawing.Point(21, 82)
        Me.ComboBoxTabacaleras.Name = "ComboBoxTabacaleras"
        Me.ComboBoxTabacaleras.Size = New System.Drawing.Size(121, 24)
        Me.ComboBoxTabacaleras.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(164, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 17)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Marcas"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(27, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 17)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Tabacaleras"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(27, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Producto"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.ButtonBorrarPedido)
        Me.Panel2.Controls.Add(Me.ButtonRealizarPedido)
        Me.Panel2.Controls.Add(Me.ListBoxPedidos)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Location = New System.Drawing.Point(32, 344)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(476, 235)
        Me.Panel2.TabIndex = 5
        '
        'ButtonBorrarPedido
        '
        Me.ButtonBorrarPedido.Location = New System.Drawing.Point(280, 129)
        Me.ButtonBorrarPedido.Name = "ButtonBorrarPedido"
        Me.ButtonBorrarPedido.Size = New System.Drawing.Size(145, 34)
        Me.ButtonBorrarPedido.TabIndex = 6
        Me.ButtonBorrarPedido.Text = "Borrar Pedido"
        Me.ButtonBorrarPedido.UseVisualStyleBackColor = True
        '
        'ButtonRealizarPedido
        '
        Me.ButtonRealizarPedido.Location = New System.Drawing.Point(280, 74)
        Me.ButtonRealizarPedido.Name = "ButtonRealizarPedido"
        Me.ButtonRealizarPedido.Size = New System.Drawing.Size(145, 34)
        Me.ButtonRealizarPedido.TabIndex = 5
        Me.ButtonRealizarPedido.Text = "Realizar Pedido"
        Me.ButtonRealizarPedido.UseVisualStyleBackColor = True
        '
        'ListBoxPedidos
        '
        Me.ListBoxPedidos.FormattingEnabled = True
        Me.ListBoxPedidos.ItemHeight = 16
        Me.ListBoxPedidos.Location = New System.Drawing.Point(21, 74)
        Me.ListBoxPedidos.Name = "ListBoxPedidos"
        Me.ListBoxPedidos.Size = New System.Drawing.Size(141, 116)
        Me.ListBoxPedidos.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(33, 38)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 17)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Pedidos"
        '
        'ButtonVerTablas
        '
        Me.ButtonVerTablas.Location = New System.Drawing.Point(1089, 306)
        Me.ButtonVerTablas.Name = "ButtonVerTablas"
        Me.ButtonVerTablas.Size = New System.Drawing.Size(145, 34)
        Me.ButtonVerTablas.TabIndex = 7
        Me.ButtonVerTablas.Text = "Ver Tablas"
        Me.ButtonVerTablas.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.Promocion)
        Me.Panel3.Controls.Add(Me.TextBoxPromocion)
        Me.Panel3.Controls.Add(Me.TextBoxPrecio)
        Me.Panel3.Controls.Add(Me.TextBoxNicotina)
        Me.Panel3.Controls.Add(Me.TextBoxNumeroCigarrillos)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Location = New System.Drawing.Point(576, 81)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(476, 235)
        Me.Panel3.TabIndex = 5
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(50, 133)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 17)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Precio"
        '
        'Promocion
        '
        Me.Promocion.AutoSize = True
        Me.Promocion.Location = New System.Drawing.Point(277, 133)
        Me.Promocion.Name = "Promocion"
        Me.Promocion.Size = New System.Drawing.Size(75, 17)
        Me.Promocion.TabIndex = 7
        Me.Promocion.Text = "Promocion"
        '
        'TextBoxPromocion
        '
        Me.TextBoxPromocion.Location = New System.Drawing.Point(265, 163)
        Me.TextBoxPromocion.Name = "TextBoxPromocion"
        Me.TextBoxPromocion.Size = New System.Drawing.Size(100, 22)
        Me.TextBoxPromocion.TabIndex = 6
        '
        'TextBoxPrecio
        '
        Me.TextBoxPrecio.Location = New System.Drawing.Point(30, 163)
        Me.TextBoxPrecio.Name = "TextBoxPrecio"
        Me.TextBoxPrecio.Size = New System.Drawing.Size(100, 22)
        Me.TextBoxPrecio.TabIndex = 5
        '
        'TextBoxNicotina
        '
        Me.TextBoxNicotina.Location = New System.Drawing.Point(265, 82)
        Me.TextBoxNicotina.Name = "TextBoxNicotina"
        Me.TextBoxNicotina.Size = New System.Drawing.Size(100, 22)
        Me.TextBoxNicotina.TabIndex = 4
        '
        'TextBoxNumeroCigarrillos
        '
        Me.TextBoxNumeroCigarrillos.Location = New System.Drawing.Point(28, 84)
        Me.TextBoxNumeroCigarrillos.Name = "TextBoxNumeroCigarrillos"
        Me.TextBoxNumeroCigarrillos.Size = New System.Drawing.Size(100, 22)
        Me.TextBoxNumeroCigarrillos.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(277, 52)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 17)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Nicotina"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(27, 52)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 17)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Nª Cigarillos"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(27, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(101, 17)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Caracteristicas"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.NumericUpDownUnidades)
        Me.Panel4.Controls.Add(Me.CheckBoxCartones)
        Me.Panel4.Controls.Add(Me.Unidades)
        Me.Panel4.Controls.Add(Me.Label10)
        Me.Panel4.Location = New System.Drawing.Point(576, 344)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(476, 235)
        Me.Panel4.TabIndex = 6
        '
        'NumericUpDownUnidades
        '
        Me.NumericUpDownUnidades.Location = New System.Drawing.Point(157, 97)
        Me.NumericUpDownUnidades.Name = "NumericUpDownUnidades"
        Me.NumericUpDownUnidades.Size = New System.Drawing.Size(120, 22)
        Me.NumericUpDownUnidades.TabIndex = 4
        '
        'CheckBoxCartones
        '
        Me.CheckBoxCartones.AutoSize = True
        Me.CheckBoxCartones.Location = New System.Drawing.Point(176, 60)
        Me.CheckBoxCartones.Name = "CheckBoxCartones"
        Me.CheckBoxCartones.Size = New System.Drawing.Size(87, 21)
        Me.CheckBoxCartones.TabIndex = 3
        Me.CheckBoxCartones.Text = "Cartones"
        Me.CheckBoxCartones.UseVisualStyleBackColor = True
        '
        'Unidades
        '
        Me.Unidades.AutoSize = True
        Me.Unidades.Location = New System.Drawing.Point(182, 138)
        Me.Unidades.Name = "Unidades"
        Me.Unidades.Size = New System.Drawing.Size(68, 17)
        Me.Unidades.TabIndex = 2
        Me.Unidades.Text = "Unidades"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(27, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(57, 17)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Compra"
        '
        'Form3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1248, 603)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.ButtonVerTablas)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ButtonVolver)
        Me.Name = "Form3"
        Me.Text = "Venta"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.NumericUpDownUnidades, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ButtonVolver As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents ListBoxMarcas As ListBox
    Friend WithEvents ComboBoxTabacaleras As ComboBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents ButtonBorrarPedido As Button
    Friend WithEvents ButtonRealizarPedido As Button
    Friend WithEvents ListBoxPedidos As ListBox
    Friend WithEvents Label6 As Label
    Friend WithEvents ButtonVerTablas As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents TextBoxNicotina As TextBox
    Friend WithEvents TextBoxNumeroCigarrillos As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents CheckBoxCartones As CheckBox
    Friend WithEvents Unidades As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Promocion As Label
    Friend WithEvents TextBoxPromocion As TextBox
    Friend WithEvents TextBoxPrecio As TextBox
    Friend WithEvents NumericUpDownUnidades As NumericUpDown
    Friend WithEvents PictureBox1 As PictureBox
End Class
