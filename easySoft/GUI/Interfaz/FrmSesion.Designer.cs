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
            this.ctlSesion1.BackColor = System.Drawing.Color.Black;
            this.ctlSesion1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ctlSesion1.BackgroundImage")));
            this.ctlSesion1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ctlSesion1.Location = new System.Drawing.Point(0, 37);
            this.ctlSesion1.Name = "ctlSesion1";
            this.ctlSesion1.Size = new System.Drawing.Size(604, 541);
            this.ctlSesion1.TabIndex = 1;
            this.ctlSesion1.Resultado += new System.EventHandler(this.ctlSesion1_Acceso_Correcto);
            this.ctlSesion1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ctlSesion1_MouseDown);
            this.ctlSesion1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ctlSesion1_MouseUp);
            // 
            // FrmSesion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 578);
            this.Controls.Add(this.ctlSesion1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FrmSesion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmSesion";
            this.Load += new System.EventHandler(this.FrmSesion_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmSesion_KeyDown);
            this.Controls.SetChildIndex(this.ctlSesion1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errP)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Interfaz.CtlSesion ctlSesion1;
    }
}