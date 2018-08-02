namespace GUI.Interfaz
{
    partial class FrmRep07001
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRep07001));
            this.btnGenera = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.fecIni = new System.Windows.Forms.DateTimePicker();
            this.fecFin = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rBres = new System.Windows.Forms.RadioButton();
            this.rbDet = new System.Windows.Forms.RadioButton();
            this.pnlPrin = new System.Windows.Forms.SplitContainer();
            this.panelFiltro = new System.Windows.Forms.Panel();
            this.txtLoteFin = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLoteIni = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.proveDesc = new System.Windows.Forms.TextBox();
            this.txtprov = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.btnImages = new System.Windows.Forms.ImageList(this.components);
            this.visor = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.errP)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlPrin)).BeginInit();
            this.pnlPrin.Panel1.SuspendLayout();
            this.pnlPrin.Panel2.SuspendLayout();
            this.pnlPrin.SuspendLayout();
            this.panelFiltro.SuspendLayout();
            this.SuspendLayout();
            // 
            // misImagenes
            // 
            this.misImagenes.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("misImagenes.ImageStream")));
            this.misImagenes.Images.SetKeyName(0, "diskette.png");
            this.misImagenes.Images.SetKeyName(1, "geninf.png");
            // 
            // btnGenera
            // 
            this.btnGenera.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenera.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenera.ImageKey = "geninf.png";
            this.btnGenera.ImageList = this.misImagenes;
            this.btnGenera.Location = new System.Drawing.Point(872, 10);
            this.btnGenera.Name = "btnGenera";
            this.btnGenera.Size = new System.Drawing.Size(150, 49);
            this.btnGenera.TabIndex = 27;
            this.btnGenera.Text = "         Emitir Reporte";
            this.btnGenera.UseVisualStyleBackColor = true;
            this.btnGenera.Click += new System.EventHandler(this.btnGenera_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(259, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Fechas";
            // 
            // fecIni
            // 
            this.fecIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fecIni.Location = new System.Drawing.Point(307, 44);
            this.fecIni.Name = "fecIni";
            this.fecIni.Size = new System.Drawing.Size(95, 20);
            this.fecIni.TabIndex = 23;
            // 
            // fecFin
            // 
            this.fecFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fecFin.Location = new System.Drawing.Point(413, 44);
            this.fecFin.Name = "fecFin";
            this.fecFin.Size = new System.Drawing.Size(95, 20);
            this.fecFin.TabIndex = 24;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rBres);
            this.groupBox1.Controls.Add(this.rbDet);
            this.groupBox1.Location = new System.Drawing.Point(524, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(97, 62);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo";
            // 
            // rBres
            // 
            this.rBres.AutoSize = true;
            this.rBres.Location = new System.Drawing.Point(18, 35);
            this.rBres.Name = "rBres";
            this.rBres.Size = new System.Drawing.Size(72, 17);
            this.rBres.TabIndex = 26;
            this.rBres.Text = "Resumido";
            this.rBres.UseVisualStyleBackColor = true;
            // 
            // rbDet
            // 
            this.rbDet.AutoSize = true;
            this.rbDet.Checked = true;
            this.rbDet.Location = new System.Drawing.Point(18, 15);
            this.rbDet.Name = "rbDet";
            this.rbDet.Size = new System.Drawing.Size(70, 17);
            this.rbDet.TabIndex = 25;
            this.rbDet.TabStop = true;
            this.rbDet.Text = "Detallado";
            this.rbDet.UseVisualStyleBackColor = true;
            // 
            // pnlPrin
            // 
            this.pnlPrin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPrin.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.pnlPrin.Location = new System.Drawing.Point(0, 37);
            this.pnlPrin.Name = "pnlPrin";
            this.pnlPrin.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // pnlPrin.Panel1
            // 
            this.pnlPrin.Panel1.Controls.Add(this.panelFiltro);
            this.pnlPrin.Panel1.Controls.Add(this.button4);
            this.pnlPrin.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlPrin_Panel1_Paint);
            // 
            // pnlPrin.Panel2
            // 
            this.pnlPrin.Panel2.Controls.Add(this.visor);
            this.pnlPrin.Size = new System.Drawing.Size(1031, 372);
            this.pnlPrin.SplitterDistance = 101;
            this.pnlPrin.TabIndex = 15;
            this.pnlPrin.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.pnlPrin_SplitterMoved);
            // 
            // panelFiltro
            // 
            this.panelFiltro.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelFiltro.Controls.Add(this.groupBox1);
            this.panelFiltro.Controls.Add(this.txtLoteFin);
            this.panelFiltro.Controls.Add(this.label1);
            this.panelFiltro.Controls.Add(this.btnGenera);
            this.panelFiltro.Controls.Add(this.label2);
            this.panelFiltro.Controls.Add(this.txtLoteIni);
            this.panelFiltro.Controls.Add(this.fecIni);
            this.panelFiltro.Controls.Add(this.label3);
            this.panelFiltro.Controls.Add(this.fecFin);
            this.panelFiltro.Controls.Add(this.proveDesc);
            this.panelFiltro.Controls.Add(this.txtprov);
            this.panelFiltro.Location = new System.Drawing.Point(3, 0);
            this.panelFiltro.Name = "panelFiltro";
            this.panelFiltro.Size = new System.Drawing.Size(1025, 74);
            this.panelFiltro.TabIndex = 29;
            // 
            // txtLoteFin
            // 
            this.txtLoteFin.Location = new System.Drawing.Point(163, 43);
            this.txtLoteFin.Name = "txtLoteFin";
            this.txtLoteFin.Size = new System.Drawing.Size(88, 20);
            this.txtLoteFin.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Proveedor";
            // 
            // txtLoteIni
            // 
            this.txtLoteIni.Location = new System.Drawing.Point(69, 43);
            this.txtLoteIni.Name = "txtLoteIni";
            this.txtLoteIni.Size = new System.Drawing.Size(88, 20);
            this.txtLoteIni.TabIndex = 21;
            this.txtLoteIni.Leave += new System.EventHandler(this.txtLoteIni_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Lote";
            // 
            // proveDesc
            // 
            this.proveDesc.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.proveDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.proveDesc.ForeColor = System.Drawing.Color.SlateBlue;
            this.proveDesc.Location = new System.Drawing.Point(131, 11);
            this.proveDesc.Name = "proveDesc";
            this.proveDesc.ReadOnly = true;
            this.proveDesc.Size = new System.Drawing.Size(377, 20);
            this.proveDesc.TabIndex = 19;
            this.proveDesc.TabStop = false;
            this.proveDesc.Text = "Todos los proveedores";
            // 
            // txtprov
            // 
            this.txtprov.Location = new System.Drawing.Point(70, 11);
            this.txtprov.Name = "txtprov";
            this.txtprov.Size = new System.Drawing.Size(60, 20);
            this.txtprov.TabIndex = 18;
            this.txtprov.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtprov_KeyUp);
            this.txtprov.Leave += new System.EventHandler(this.txtprov_Leave);
            // 
            // button4
            // 
            this.button4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button4.ImageIndex = 1;
            this.button4.ImageList = this.btnImages;
            this.button4.Location = new System.Drawing.Point(0, 75);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(1031, 26);
            this.button4.TabIndex = 28;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnImages
            // 
            this.btnImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("btnImages.ImageStream")));
            this.btnImages.TransparentColor = System.Drawing.Color.Transparent;
            this.btnImages.Images.SetKeyName(0, "down.png");
            this.btnImages.Images.SetKeyName(1, "up.png");
            // 
            // visor
            // 
            this.visor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.visor.Location = new System.Drawing.Point(0, 0);
            this.visor.Name = "visor";
            this.visor.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote;
            this.visor.ServerReport.BearerToken = null;
            this.visor.Size = new System.Drawing.Size(1031, 267);
            this.visor.TabIndex = 0;
            this.visor.TabStop = false;
            // 
            // FrmRep07001
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 409);
            this.Controls.Add(this.pnlPrin);
            this.Name = "FrmRep07001";
            this.Text = "v";
            this.Load += new System.EventHandler(this.FrmRep07001_Load);
            this.Controls.SetChildIndex(this.pnlPrin, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errP)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlPrin.Panel1.ResumeLayout(false);
            this.pnlPrin.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlPrin)).EndInit();
            this.pnlPrin.ResumeLayout(false);
            this.panelFiltro.ResumeLayout(false);
            this.panelFiltro.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGenera;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker fecIni;
        private System.Windows.Forms.DateTimePicker fecFin;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rBres;
        private System.Windows.Forms.RadioButton rbDet;
        private System.Windows.Forms.SplitContainer pnlPrin;
        private Microsoft.Reporting.WinForms.ReportViewer visor;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ImageList btnImages;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLoteFin;
        private System.Windows.Forms.TextBox txtLoteIni;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox proveDesc;
        private System.Windows.Forms.TextBox txtprov;
        private System.Windows.Forms.Panel panelFiltro;
    }
}