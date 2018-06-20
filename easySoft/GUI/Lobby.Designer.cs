namespace GUI
{
    partial class Lobby
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Lobby));
            this.barraEstado = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.mainsplit = new System.Windows.Forms.SplitContainer();
            this.easyMenu1 = new GUI.Controles.easyMenu();
            this.VentanaMain = new System.Windows.Forms.TabControl();
            ((System.ComponentModel.ISupportInitialize)(this.errP)).BeginInit();
            this.barraEstado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainsplit)).BeginInit();
            this.mainsplit.Panel1.SuspendLayout();
            this.mainsplit.Panel2.SuspendLayout();
            this.mainsplit.SuspendLayout();
            this.SuspendLayout();
            // 
            // misImagenes
            // 
            this.misImagenes.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("misImagenes.ImageStream")));
            this.misImagenes.Images.SetKeyName(0, "diskette.png");
            // 
            // barraEstado
            // 
            this.barraEstado.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barraEstado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.barraEstado.Location = new System.Drawing.Point(0, 667);
            this.barraEstado.Name = "barraEstado";
            this.barraEstado.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.barraEstado.Size = new System.Drawing.Size(1142, 25);
            this.barraEstado.TabIndex = 1;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::GUI.Properties.Resources.nosave;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "Cerrar";
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.toolStripButton1.ToolTipText = "Cerrar Ficha";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // mainsplit
            // 
            this.mainsplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainsplit.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.mainsplit.Location = new System.Drawing.Point(0, 37);
            this.mainsplit.Name = "mainsplit";
            // 
            // mainsplit.Panel1
            // 
            this.mainsplit.Panel1.Controls.Add(this.easyMenu1);
            // 
            // mainsplit.Panel2
            // 
            this.mainsplit.Panel2.Controls.Add(this.VentanaMain);
            this.mainsplit.Size = new System.Drawing.Size(1142, 630);
            this.mainsplit.SplitterDistance = 71;
            this.mainsplit.TabIndex = 2;
            // 
            // easyMenu1
            // 
            this.easyMenu1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.easyMenu1.Location = new System.Drawing.Point(0, 0);
            this.easyMenu1.Name = "easyMenu1";
            this.easyMenu1.Size = new System.Drawing.Size(71, 630);
            this.easyMenu1.TabIndex = 1;
            this.easyMenu1.AbrirPrograma += new System.EventHandler(this.easyMenu1_AbrirPrograma);
            this.easyMenu1.AbrirNoPrograma += new System.EventHandler(this.easyMenu1_AbrirNoPrograma);
            this.easyMenu1.MouseLeave += new System.EventHandler(this.easyMenu1_MouseLeave);
            // 
            // VentanaMain
            // 
            this.VentanaMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VentanaMain.Location = new System.Drawing.Point(0, 0);
            this.VentanaMain.Name = "VentanaMain";
            this.VentanaMain.SelectedIndex = 0;
            this.VentanaMain.Size = new System.Drawing.Size(1067, 630);
            this.VentanaMain.TabIndex = 0;
            // 
            // Lobby
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1142, 692);
            this.Controls.Add(this.mainsplit);
            this.Controls.Add(this.barraEstado);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Lobby";
            this.Text = "Lobby";
            this.Load += new System.EventHandler(this.Lobby_Load);
            this.Controls.SetChildIndex(this.barraEstado, 0);
            this.Controls.SetChildIndex(this.mainsplit, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errP)).EndInit();
            this.barraEstado.ResumeLayout(false);
            this.barraEstado.PerformLayout();
            this.mainsplit.Panel1.ResumeLayout(false);
            this.mainsplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainsplit)).EndInit();
            this.mainsplit.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip barraEstado;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.SplitContainer mainsplit;
        private Controles.easyMenu easyMenu1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.TabControl VentanaMain;
    }
}