namespace GUI.Interfaz.Reportes
{
    partial class FrmRep08001
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRep08001));
            this.label1 = new System.Windows.Forms.Label();
            this.anio = new System.Windows.Forms.NumericUpDown();
            this.semNo = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.anio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.semNo)).BeginInit();
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
            this.misImagenes.Images.SetKeyName(0, "arrow-down.png");
            this.misImagenes.Images.SetKeyName(1, "arrow-up.png");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Año";
            // 
            // anio
            // 
            this.anio.Location = new System.Drawing.Point(65, 72);
            this.anio.Maximum = new decimal(new int[] {
            2100,
            0,
            0,
            0});
            this.anio.Minimum = new decimal(new int[] {
            2018,
            0,
            0,
            0});
            this.anio.Name = "anio";
            this.anio.Size = new System.Drawing.Size(62, 20);
            this.anio.TabIndex = 32;
            this.anio.Value = new decimal(new int[] {
            2018,
            0,
            0,
            0});
            // 
            // semNo
            // 
            this.semNo.Location = new System.Drawing.Point(65, 51);
            this.semNo.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.semNo.Name = "semNo";
            this.semNo.Size = new System.Drawing.Size(62, 20);
            this.semNo.TabIndex = 34;
            this.semNo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "Semana";
            // 
            // FrmRep08001
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.semNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.anio);
            this.Controls.Add(this.label1);
            this.Name = "FrmRep08001";
            this.Text = "FrmRep08001";
            this.Load += new System.EventHandler(this.FrmRep08001_Load);
            this.Controls.SetChildIndex(this.visor, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.anio, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.semNo, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.anio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.semNo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown anio;
        private System.Windows.Forms.NumericUpDown semNo;
        private System.Windows.Forms.Label label2;
    }
}