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
        Me.ButtonGestion = New System.Windows.Forms.Button()
        Me.ButtonVenta = New System.Windows.Forms.Button()
        Me.LabelTabacalera = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'ButtonGestion
        '
        Me.ButtonGestion.Location = New System.Drawing.Point(276, 151)
        Me.ButtonGestion.Name = "ButtonGestion"
        Me.ButtonGestion.Size = New System.Drawing.Size(125, 23)
        Me.ButtonGestion.TabIndex = 0
        Me.ButtonGestion.Text = "Gestion"
        Me.ButtonGestion.UseVisualStyleBackColor = True
        '
        'ButtonVenta
        '
        Me.ButtonVenta.Location = New System.Drawing.Point(276, 232)
        Me.ButtonVenta.Name = "ButtonVenta"
        Me.ButtonVenta.Size = New System.Drawing.Size(125, 23)
        Me.ButtonVenta.TabIndex = 1
        Me.ButtonVenta.Text = "Venta"
        Me.ButtonVenta.UseVisualStyleBackColor = True
        '
        'LabelTabacalera
        '
        Me.LabelTabacalera.AutoSize = True
        Me.LabelTabacalera.Location = New System.Drawing.Point(289, 96)
        Me.LabelTabacalera.Name = "LabelTabacalera"
        Me.LabelTabacalera.Size = New System.Drawing.Size(98, 17)
        Me.LabelTabacalera.TabIndex = 2
        Me.LabelTabacalera.Text = "TABACALERA"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.LabelTabacalera)
        Me.Controls.Add(Me.ButtonVenta)
        Me.Controls.Add(Me.ButtonGestion)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ButtonGestion As Button
    Friend WithEvents ButtonVenta As Button
    Friend WithEvents LabelTabacalera As Label
End Class
