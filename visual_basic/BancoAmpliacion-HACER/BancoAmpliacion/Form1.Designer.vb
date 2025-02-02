<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormBanco
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lbltitulo = New System.Windows.Forms.Label()
        Me.ButtonOperar = New System.Windows.Forms.Button()
        Me.ButtonGestion = New System.Windows.Forms.Button()
        Me.ButtonSalir = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lbltitulo
        '
        Me.lbltitulo.AutoSize = True
        Me.lbltitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltitulo.Location = New System.Drawing.Point(49, 47)
        Me.lbltitulo.Name = "lbltitulo"
        Me.lbltitulo.Size = New System.Drawing.Size(270, 32)
        Me.lbltitulo.TabIndex = 0
        Me.lbltitulo.Text = "IES VISTA ALEGRE"
        '
        'ButtonOperar
        '
        Me.ButtonOperar.Location = New System.Drawing.Point(69, 141)
        Me.ButtonOperar.Name = "ButtonOperar"
        Me.ButtonOperar.Size = New System.Drawing.Size(75, 34)
        Me.ButtonOperar.TabIndex = 1
        Me.ButtonOperar.Text = "Operar"
        Me.ButtonOperar.UseVisualStyleBackColor = True
        '
        'ButtonGestion
        '
        Me.ButtonGestion.Location = New System.Drawing.Point(244, 141)
        Me.ButtonGestion.Name = "ButtonGestion"
        Me.ButtonGestion.Size = New System.Drawing.Size(75, 34)
        Me.ButtonGestion.TabIndex = 2
        Me.ButtonGestion.Text = "Gestión"
        Me.ButtonGestion.UseVisualStyleBackColor = True
        '
        'ButtonSalir
        '
        Me.ButtonSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.1!)
        Me.ButtonSalir.Location = New System.Drawing.Point(158, 204)
        Me.ButtonSalir.Name = "ButtonSalir"
        Me.ButtonSalir.Size = New System.Drawing.Size(75, 34)
        Me.ButtonSalir.TabIndex = 3
        Me.ButtonSalir.Text = "Salir"
        Me.ButtonSalir.UseVisualStyleBackColor = True
        '
        'FormBanco
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(368, 260)
        Me.Controls.Add(Me.ButtonSalir)
        Me.Controls.Add(Me.ButtonGestion)
        Me.Controls.Add(Me.ButtonOperar)
        Me.Controls.Add(Me.lbltitulo)
        Me.Name = "FormBanco"
        Me.Text = "Banco"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbltitulo As Label
    Friend WithEvents ButtonOperar As Button
    Friend WithEvents ButtonGestion As Button
    Friend WithEvents ButtonSalir As Button
End Class
