<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class About
    Inherits DolphinForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(About))
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.Version = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Ventana.SuspendLayout()
        Me.PanelTitulo.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdSalir
        '
        Me.cmdSalir.FlatAppearance.BorderSize = 0
        Me.cmdSalir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.cmdSalir.Location = New System.Drawing.Point(724, 0)
        '
        'Ventana
        '
        Me.Ventana.Controls.Add(Me.Label6)
        Me.Ventana.Controls.Add(Me.Panel1)
        Me.Ventana.Controls.Add(Me.Version)
        Me.Ventana.Controls.Add(Me.Label5)
        Me.Ventana.Controls.Add(Me.Label10)
        Me.Ventana.Controls.Add(Me.Label11)
        Me.Ventana.Controls.Add(Me.PictureBox3)
        Me.Ventana.Controls.Add(Me.Label13)
        Me.Ventana.Controls.Add(Me.PictureBox4)
        Me.Ventana.Size = New System.Drawing.Size(754, 282)
        Me.Ventana.Controls.SetChildIndex(Me.PictureBox4, 0)
        Me.Ventana.Controls.SetChildIndex(Me.Label13, 0)
        Me.Ventana.Controls.SetChildIndex(Me.PictureBox3, 0)
        Me.Ventana.Controls.SetChildIndex(Me.Label11, 0)
        Me.Ventana.Controls.SetChildIndex(Me.Label10, 0)
        Me.Ventana.Controls.SetChildIndex(Me.Label5, 0)
        Me.Ventana.Controls.SetChildIndex(Me.Version, 0)
        Me.Ventana.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Ventana.Controls.SetChildIndex(Me.Label6, 0)
        '
        'PanelTitulo
        '
        Me.PanelTitulo.Size = New System.Drawing.Size(754, 28)
        '
        'ListaPngs
        '
        Me.ListaPngs.ImageStream = CType(resources.GetObject("ListaPngs.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ListaPngs.Images.SetKeyName(0, "save.png")
        Me.ListaPngs.Images.SetKeyName(1, "NoSign.png")
        Me.ListaPngs.Images.SetKeyName(2, "Bill.png")
        Me.ListaPngs.Images.SetKeyName(3, "Agrega.png")
        Me.ListaPngs.Images.SetKeyName(4, "ComandaICon.png")
        Me.ListaPngs.Images.SetKeyName(5, "go-previous.png")
        Me.ListaPngs.Images.SetKeyName(6, "go-next.png")
        Me.ListaPngs.Images.SetKeyName(7, "WINLOGO.jpg")
        '
        'MINIMIZE
        '
        Me.MINIMIZE.FlatAppearance.BorderSize = 0
        Me.MINIMIZE.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.MINIMIZE.Location = New System.Drawing.Point(626, 0)
        '
        'WINBTN
        '
        Me.WINBTN.FlatAppearance.BorderSize = 0
        Me.WINBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.WINBTN.Location = New System.Drawing.Point(668, 0)
        '
        'Label10
        '
        Me.Label10.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(404, 72)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(260, 31)
        Me.Label10.TabIndex = 25
        Me.Label10.Text = "Software de Gestion"
        '
        'Label11
        '
        Me.Label11.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Snow
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.Font = New System.Drawing.Font("Imprint MT Shadow", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(252, 5)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(280, 59)
        Me.Label11.TabIndex = 24
        Me.Label11.Text = "ALP-SAAB"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(125, 250)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(318, 16)
        Me.Label13.TabIndex = 28
        Me.Label13.Text = "® SyscomPsa S.A. Reservados todos los derechos."
        '
        'PictureBox3
        '
        Me.PictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox3.Image = Global.SAAB.My.Resources.Resources.saab
        Me.PictureBox3.Location = New System.Drawing.Point(11, 5)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(227, 223)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox3.TabIndex = 23
        Me.PictureBox3.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PictureBox4.Image = Global.SAAB.My.Resources.Resources.syscompsa
        Me.PictureBox4.Location = New System.Drawing.Point(11, 226)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(108, 51)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox4.TabIndex = 27
        Me.PictureBox4.TabStop = False
        '
        'Version
        '
        Me.Version.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Version.AutoSize = True
        Me.Version.Location = New System.Drawing.Point(611, 37)
        Me.Version.Name = "Version"
        Me.Version.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Version.Size = New System.Drawing.Size(130, 16)
        Me.Version.TabIndex = 31
        Me.Version.Text = "version Compilacion"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(548, 124)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(193, 107)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = "Software ideado para la gestion de restaurantes. Diseñado y estructurado para fun" &
    "cionar en integracion con el sistema AlpWin"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel1.AutoScroll = True
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(247, 125)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(295, 106)
        Me.Panel1.TabIndex = 32
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(241, 16)
        Me.Label4.TabIndex = 30
        Me.Label4.Text = "Gerente General: Ing. Leonardo Carrion"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(237, 16)
        Me.Label3.TabIndex = 31
        Me.Label3.Text = "Asesor Comercial: Ing. Oscar Gutierrez"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(202, 16)
        Me.Label2.TabIndex = 32
        Me.Label2.Text = "Jefe de Sistemas: Ing. Alex Pozo"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 77)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(267, 16)
        Me.Label1.TabIndex = 33
        Me.Label1.Text = "Desarrollado por: Ing. Holger Veloz Aguirre "
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(249, 102)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(61, 16)
        Me.Label6.TabIndex = 30
        Me.Label6.Text = "Creditos:"
        '
        'About
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(754, 310)
        Me.Font = New System.Drawing.Font("Arial Narrow", 12.0!)
        Me.Name = "About"
        Me.Text = "About"
        Me.Ventana.ResumeLayout(False)
        Me.Ventana.PerformLayout()
        Me.PanelTitulo.ResumeLayout(False)
        Me.PanelTitulo.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents Version As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
