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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRep07001));
            this.btnGenera = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.fecIni = new System.Windows.Forms.DateTimePicker();
            this.fecFin = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbDet = new System.Windows.Forms.RadioButton();
            this.rBres = new System.Windows.Forms.RadioButton();
            this.rsLote = new GUI.Controles.rsCuadro();
            this.rsProv = new GUI.Controles.rsCuadro();
            this.pnlPrin = new System.Windows.Forms.SplitContainer();
            this.visor = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.errP)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlPrin)).BeginInit();
            this.pnlPrin.Panel1.SuspendLayout();
            this.pnlPrin.Panel2.SuspendLayout();
            this.pnlPrin.SuspendLayout();
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
            this.btnGenera.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenera.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenera.ImageKey = "geninf.png";
            this.btnGenera.ImageList = this.misImagenes;
            this.btnGenera.Location = new System.Drawing.Point(869, 10);
            this.btnGenera.Name = "btnGenera";
            this.btnGenera.Size = new System.Drawing.Size(150, 71);
            this.btnGenera.TabIndex = 8;
            this.btnGenera.Text = "         Emitir Reporte";
            this.btnGenera.UseVisualStyleBackColor = true;
            this.btnGenera.Click += new System.EventHandler(this.btnGenera_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(340, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Fecha";
            // 
            // fecIni
            // 
            this.fecIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fecIni.Location = new System.Drawing.Point(390, 18);
            this.fecIni.Name = "fecIni";
            this.fecIni.Size = new System.Drawing.Size(95, 20);
            this.fecIni.TabIndex = 12;
            // 
            // fecFin
            // 
            this.fecFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fecFin.Location = new System.Drawing.Point(496, 18);
            this.fecFin.Name = "fecFin";
            this.fecFin.Size = new System.Drawing.Size(95, 20);
            this.fecFin.TabIndex = 13;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rBres);
            this.groupBox1.Controls.Add(this.rbDet);
            this.groupBox1.Location = new System.Drawing.Point(337, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(302, 39);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo";
            // 
            // rbDet
            // 
            this.rbDet.AutoSize = true;
            this.rbDet.Checked = true;
            this.rbDet.Location = new System.Drawing.Point(6, 12);
            this.rbDet.Name = "rbDet";
            this.rbDet.Size = new System.Drawing.Size(70, 17);
            this.rbDet.TabIndex = 0;
            this.rbDet.TabStop = true;
            this.rbDet.Text = "Detallado";
            this.rbDet.UseVisualStyleBackColor = true;
            // 
            // rBres
            // 
            this.rBres.AutoSize = true;
            this.rBres.Location = new System.Drawing.Point(97, 12);
            this.rBres.Name = "rBres";
            this.rBres.Size = new System.Drawing.Size(72, 17);
            this.rBres.TabIndex = 1;
            this.rBres.Text = "Resumido";
            this.rBres.UseVisualStyleBackColor = true;
            // 
            // rsLote
            // 
            this.rsLote.BackColor = System.Drawing.Color.Transparent;
            this.rsLote.Location = new System.Drawing.Point(14, 54);
            this.rsLote.Name = "rsLote";
            this.rsLote.Size = new System.Drawing.Size(317, 29);
            this.rsLote.TabIndex = 11;
            // 
            // rsProv
            // 
            this.rsProv.BackColor = System.Drawing.Color.Transparent;
            this.rsProv.Location = new System.Drawing.Point(14, 12);
            this.rsProv.Name = "rsProv";
            this.rsProv.Size = new System.Drawing.Size(352, 29);
            this.rsProv.TabIndex = 9;
            // 
            // pnlPrin
            // 
            this.pnlPrin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPrin.Location = new System.Drawing.Point(0, 37);
            this.pnlPrin.Name = "pnlPrin";
            this.pnlPrin.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // pnlPrin.Panel1
            // 
            this.pnlPrin.Panel1.Controls.Add(this.rsProv);
            this.pnlPrin.Panel1.Controls.Add(this.groupBox1);
            this.pnlPrin.Panel1.Controls.Add(this.btnGenera);
            this.pnlPrin.Panel1.Controls.Add(this.fecFin);
            this.pnlPrin.Panel1.Controls.Add(this.label1);
            this.pnlPrin.Panel1.Controls.Add(this.fecIni);
            this.pnlPrin.Panel1.Controls.Add(this.rsLote);
            // 
            // pnlPrin.Panel2
            // 
            this.pnlPrin.Panel2.Controls.Add(this.visor);
            this.pnlPrin.Size = new System.Drawing.Size(1031, 372);
            this.pnlPrin.SplitterDistance = 91;
            this.pnlPrin.TabIndex = 15;
            // 
            // reportViewer1
            // 
            this.visor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.visor.Location = new System.Drawing.Point(0, 0);
            this.visor.Name = "reportViewer1";
            this.visor.ServerReport.BearerToken = null;
            this.visor.Size = new System.Drawing.Size(1031, 277);
            this.visor.TabIndex = 0;
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
            this.pnlPrin.Panel1.PerformLayout();
            this.pnlPrin.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlPrin)).EndInit();
            this.pnlPrin.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGenera;
        private Controles.rsCuadro rsProv;
        private System.Windows.Forms.Label label1;
        private Controles.rsCuadro rsLote;
        private System.Windows.Forms.DateTimePicker fecIni;
        private System.Windows.Forms.DateTimePicker fecFin;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rBres;
        private System.Windows.Forms.RadioButton rbDet;
        private System.Windows.Forms.SplitContainer pnlPrin;
        private Microsoft.Reporting.WinForms.ReportViewer visor;
    }
}