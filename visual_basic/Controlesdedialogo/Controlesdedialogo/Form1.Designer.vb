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
        Me.lblDAM = New System.Windows.Forms.Button()
        Me.lblImagen = New System.Windows.Forms.Button()
        Me.lblColorFondo = New System.Windows.Forms.Button()
        Me.lblColorLetra = New System.Windows.Forms.Button()
        Me.lblTipoLetra = New System.Windows.Forms.Button()
        Me.lblAbrirAplicacion = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblBorrarImagen = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblDAM
        '
        Me.lblDAM.Location = New System.Drawing.Point(141, 254)
        Me.lblDAM.Name = "lblDAM"
        Me.lblDAM.Size = New System.Drawing.Size(75, 23)
        Me.lblDAM.TabIndex = 0
        Me.lblDAM.Text = "DAM"
        Me.lblDAM.UseVisualStyleBackColor = True
        '
        'lblImagen
        '
        Me.lblImagen.Location = New System.Drawing.Point(479, 45)
        Me.lblImagen.Name = "lblImagen"
        Me.lblImagen.Size = New System.Drawing.Size(75, 34)
        Me.lblImagen.TabIndex = 1
        Me.lblImagen.Text = "Imagen"
        Me.lblImagen.UseVisualStyleBackColor = True
        '
        'lblColorFondo
        '
        Me.lblColorFondo.Location = New System.Drawing.Point(479, 151)
        Me.lblColorFondo.Name = "lblColorFondo"
        Me.lblColorFondo.Size = New System.Drawing.Size(100, 34)
        Me.lblColorFondo.TabIndex = 2
        Me.lblColorFondo.Text = "Color Fondo"
        Me.lblColorFondo.UseVisualStyleBackColor = True
        '
        'lblColorLetra
        '
        Me.lblColorLetra.Location = New System.Drawing.Point(479, 205)
        Me.lblColorLetra.Name = "lblColorLetra"
        Me.lblColorLetra.Size = New System.Drawing.Size(100, 32)
        Me.lblColorLetra.TabIndex = 3
        Me.lblColorLetra.Text = "Color Letra"
        Me.lblColorLetra.UseVisualStyleBackColor = True
        '
        'lblTipoLetra
        '
        Me.lblTipoLetra.Location = New System.Drawing.Point(479, 249)
        Me.lblTipoLetra.Name = "lblTipoLetra"
        Me.lblTipoLetra.Size = New System.Drawing.Size(100, 32)
        Me.lblTipoLetra.TabIndex = 4
        Me.lblTipoLetra.Text = "Tipo Letra"
        Me.lblTipoLetra.UseVisualStyleBackColor = True
        '
        'lblAbrirAplicacion
        '
        Me.lblAbrirAplicacion.Location = New System.Drawing.Point(479, 297)
        Me.lblAbrirAplicacion.Name = "lblAbrirAplicacion"
        Me.lblAbrirAplicacion.Size = New System.Drawing.Size(119, 32)
        Me.lblAbrirAplicacion.TabIndex = 5
        Me.lblAbrirAplicacion.Text = "Abrir Aplicación"
        Me.lblAbrirAplicacion.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(98, 99)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(165, 117)
        Me.PictureBox1.TabIndex = 6
        Me.PictureBox1.TabStop = False
        '
        'lblBorrarImagen
        '
        Me.lblBorrarImagen.Location = New System.Drawing.Point(479, 99)
        Me.lblBorrarImagen.Name = "lblBorrarImagen"
        Me.lblBorrarImagen.Size = New System.Drawing.Size(119, 34)
        Me.lblBorrarImagen.TabIndex = 7
        Me.lblBorrarImagen.Text = "Borrar Imagen"
        Me.lblBorrarImagen.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.lblBorrarImagen)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lblAbrirAplicacion)
        Me.Controls.Add(Me.lblTipoLetra)
        Me.Controls.Add(Me.lblColorLetra)
        Me.Controls.Add(Me.lblColorFondo)
        Me.Controls.Add(Me.lblImagen)
        Me.Controls.Add(Me.lblDAM)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblDAM As Button
    Friend WithEvents lblImagen As Button
    Friend WithEvents lblColorFondo As Button
    Friend WithEvents lblColorLetra As Button
    Friend WithEvents lblTipoLetra As Button
    Friend WithEvents lblAbrirAplicacion As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lblBorrarImagen As Button
End Class
