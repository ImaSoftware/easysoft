namespace GUI.Interfaz.Reportes
{
    partial class FrmRep07002
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRep07002));
            this.label1 = new System.Windows.Forms.Label();
            this.fecIni = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.errP)).BeginInit();
            this.SuspendLayout();
            // 
            // visor
            // 
            this.visor.ServerReport.BearerToken = null;
            this.visor.Size = new System.Drawing.Size(800, 307);
            // 
            // misImagenes
            // 
            this.misImagenes.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("misImagenes.ImageStream")));
            this.misImagenes.Images.SetKeyName(0, "diskette.png");
            this.misImagenes.Images.SetKeyName(1, "arrow-up.png");
            this.misImagenes.Images.SetKeyName(2, "arrow-down.png");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Mes";
            // 
            // fecIni
            // 
            this.fecIni.CustomFormat = "MM yyyy";
            this.fecIni.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fecIni.Location = new System.Drawing.Point(46, 50);
            this.fecIni.Name = "fecIni";
            this.fecIni.Size = new System.Drawing.Size(81, 20);
            this.fecIni.TabIndex = 32;
            this.miTip.SetToolTip(this.fecIni, "El análisis de kardex considera todas las transacciones del mes que se escoje des" +
        "de el primer dia ");
            // 
            // FrmRep07002
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.fecIni);
            this.Controls.Add(this.label1);
            this.Name = "FrmRep07002";
            this.Text = "FrmRep07002";
            this.Controls.SetChildIndex(this.visor, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.fecIni, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker fecIni;
    }
}