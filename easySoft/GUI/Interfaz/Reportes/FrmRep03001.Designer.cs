namespace GUI.Interfaz.Reportes
{
    partial class FrmRep03001
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRep03001));
            this.label1 = new System.Windows.Forms.Label();
            this.fecIni = new System.Windows.Forms.DateTimePicker();
            this.txtItmIni = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtItmFin = new System.Windows.Forms.TextBox();
            this.txtloteFin = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtloteIni = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errP)).BeginInit();
            this.SuspendLayout();
            // 
            // visor
            // 
            this.visor.ServerReport.BearerToken = null;
            this.visor.Size = new System.Drawing.Size(801, 333);
            // 
            // misImagenes
            // 
            this.misImagenes.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("misImagenes.ImageStream")));
            this.misImagenes.Images.SetKeyName(0, "arrow-down.png");
            this.misImagenes.Images.SetKeyName(1, "arrow-up.png");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(355, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Mes de Inicio para Kardex";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // fecIni
            // 
            this.fecIni.CustomFormat = "MM yyyy";
            this.fecIni.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fecIni.Location = new System.Drawing.Point(488, 45);
            this.fecIni.Name = "fecIni";
            this.fecIni.Size = new System.Drawing.Size(81, 20);
            this.fecIni.TabIndex = 5;
            this.miTip.SetToolTip(this.fecIni, "El análisis de kardex considera todas las transacciones del mes que se escoje des" +
        "de el primer dia ");
            this.fecIni.ValueChanged += new System.EventHandler(this.fecIni_ValueChanged);
            // 
            // txtItmIni
            // 
            this.txtItmIni.Location = new System.Drawing.Point(85, 45);
            this.txtItmIni.Name = "txtItmIni";
            this.txtItmIni.Size = new System.Drawing.Size(129, 20);
            this.txtItmIni.TabIndex = 1;
            this.txtItmIni.Leave += new System.EventHandler(this.txtItmIni_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "Rango Items";
            // 
            // txtItmFin
            // 
            this.txtItmFin.Location = new System.Drawing.Point(220, 45);
            this.txtItmFin.Name = "txtItmFin";
            this.txtItmFin.Size = new System.Drawing.Size(129, 20);
            this.txtItmFin.TabIndex = 2;
            this.txtItmFin.Leave += new System.EventHandler(this.txtItmIni_Leave);
            // 
            // txtloteFin
            // 
            this.txtloteFin.Location = new System.Drawing.Point(181, 70);
            this.txtloteFin.Name = "txtloteFin";
            this.txtloteFin.Size = new System.Drawing.Size(89, 20);
            this.txtloteFin.TabIndex = 4;
            this.miTip.SetToolTip(this.txtloteFin, "Tenga en cuenta que el resumen de existencias no considera numero de lote");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 37;
            this.label3.Text = "Rango Lotes";
            // 
            // txtloteIni
            // 
            this.txtloteIni.Location = new System.Drawing.Point(86, 70);
            this.txtloteIni.Name = "txtloteIni";
            this.txtloteIni.Size = new System.Drawing.Size(89, 20);
            this.txtloteIni.TabIndex = 3;
            this.miTip.SetToolTip(this.txtloteIni, "Tenga en cuenta que el resumen de existencias no considera numero de lote");
            this.txtloteIni.TextChanged += new System.EventHandler(this.txtloteIni_TextChanged);
            this.txtloteIni.Leave += new System.EventHandler(this.txtloteIni_Leave);
            // 
            // FrmRep03001
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 477);
            this.Controls.Add(this.txtloteFin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtloteIni);
            this.Controls.Add(this.txtItmFin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtItmIni);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fecIni);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmRep03001";
            this.Text = "Contraste Existencia y Costos";
            this.Load += new System.EventHandler(this.FrmRep03001_Load);
            this.Controls.SetChildIndex(this.visor, 0);
            this.Controls.SetChildIndex(this.fecIni, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtItmIni, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtItmFin, 0);
            this.Controls.SetChildIndex(this.txtloteIni, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtloteFin, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker fecIni;
        private System.Windows.Forms.TextBox txtItmIni;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtItmFin;
        private System.Windows.Forms.TextBox txtloteFin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtloteIni;
    }
}