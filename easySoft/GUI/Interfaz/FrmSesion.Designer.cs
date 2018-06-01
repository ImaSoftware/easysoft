namespace GUI
{
    partial class FrmSesion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSesion));
            this.ctlSesion1 = new GUI.Interfaz.CtlSesion();
            ((System.ComponentModel.ISupportInitialize)(this.errP)).BeginInit();
            this.SuspendLayout();
            // 
            // misImagenes
            // 
            this.misImagenes.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("misImagenes.ImageStream")));
            this.misImagenes.Images.SetKeyName(0, "diskette.png");
            // 
            // ctlSesion1
            // 
            this.ctlSesion1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlSesion1.Location = new System.Drawing.Point(0, 31);
            this.ctlSesion1.Name = "ctlSesion1";
            this.ctlSesion1.Size = new System.Drawing.Size(514, 209);
            this.ctlSesion1.TabIndex = 1;
            this.ctlSesion1.Resultado += new System.EventHandler(this.ctlSesion1_Acceso_Correcto);
            // 
            // FrmSesion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 240);
            this.Controls.Add(this.ctlSesion1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmSesion";
            this.Text = "FrmSesion";
            this.Load += new System.EventHandler(this.FrmSesion_Load);
            this.Controls.SetChildIndex(this.ctlSesion1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errP)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Interfaz.CtlSesion ctlSesion1;
    }
}