namespace GUI.baseClass
{
    partial class Repform
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Repform));
            this.visor = new Microsoft.Reporting.WinForms.ReportViewer();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.button4 = new System.Windows.Forms.Button();
            this.btnGenera = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errP)).BeginInit();
            this.SuspendLayout();
            // 
            // misImagenes
            // 
            this.misImagenes.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("misImagenes.ImageStream")));
            this.misImagenes.Images.SetKeyName(0, "arrow-down.png");
            this.misImagenes.Images.SetKeyName(1, "arrow-up.png");
            // 
            // visor
            // 
            this.visor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.visor.Location = new System.Drawing.Point(0, 138);
            this.visor.Name = "visor";
            this.visor.ServerReport.BearerToken = null;
            this.visor.Size = new System.Drawing.Size(800, 267);
            this.visor.TabIndex = 1;
            this.visor.ReportRefresh += new System.ComponentModel.CancelEventHandler(this.visor_ReportRefresh);
            this.visor.Drillthrough += new Microsoft.Reporting.WinForms.DrillthroughEventHandler(this.visor_Drillthrough);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "geninf.png");
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.ImageIndex = 1;
            this.button4.ImageList = this.misImagenes;
            this.button4.Location = new System.Drawing.Point(0, 109);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(800, 28);
            this.button4.TabIndex = 29;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnGenera
            // 
            this.btnGenera.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenera.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenera.ImageKey = "geninf.png";
            this.btnGenera.ImageList = this.imageList1;
            this.btnGenera.Location = new System.Drawing.Point(652, 41);
            this.btnGenera.Name = "btnGenera";
            this.btnGenera.Size = new System.Drawing.Size(142, 65);
            this.btnGenera.TabIndex = 30;
            this.btnGenera.Text = "         Emitir Reporte";
            this.btnGenera.UseVisualStyleBackColor = true;
            this.btnGenera.Click += new System.EventHandler(this.btnGenera_Click);
            // 
            // Repform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 410);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btnGenera);
            this.Controls.Add(this.visor);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Repform";
            this.Text = "Repform";
            this.Load += new System.EventHandler(this.Repform_Load);
            this.Controls.SetChildIndex(this.visor, 0);
            this.Controls.SetChildIndex(this.btnGenera, 0);
            this.Controls.SetChildIndex(this.button4, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errP)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnGenera;
        public Microsoft.Reporting.WinForms.ReportViewer visor;
    }
}