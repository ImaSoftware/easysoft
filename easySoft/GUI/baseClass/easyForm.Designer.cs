﻿namespace GUI.baseClass
{
    partial class easyForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(easyForm));
            this.barraTitulo = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.xTitulo = new System.Windows.Forms.Label();
            this.errP = new System.Windows.Forms.ErrorProvider(this.components);
            this.miTip = new System.Windows.Forms.ToolTip(this.components);
            this.misImagenes = new System.Windows.Forms.ImageList(this.components);
            this.barraTitulo.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errP)).BeginInit();
            this.SuspendLayout();
            // 
            // barraTitulo
            // 
            this.barraTitulo.ColumnCount = 4;
            this.barraTitulo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.barraTitulo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.barraTitulo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.barraTitulo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.barraTitulo.Controls.Add(this.button1, 1, 0);
            this.barraTitulo.Controls.Add(this.button2, 2, 0);
            this.barraTitulo.Controls.Add(this.button3, 3, 0);
            this.barraTitulo.Controls.Add(this.panel2, 0, 0);
            this.barraTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.barraTitulo.Location = new System.Drawing.Point(0, 0);
            this.barraTitulo.Name = "barraTitulo";
            this.barraTitulo.RowCount = 1;
            this.barraTitulo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.barraTitulo.Size = new System.Drawing.Size(1120, 37);
            this.barraTitulo.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(958, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(49, 31);
            this.button1.TabIndex = 0;
            this.button1.TabStop = false;
            this.button1.Text = "-";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(1013, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(49, 31);
            this.button2.TabIndex = 1;
            this.button2.TabStop = false;
            this.button2.Text = "W";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(1068, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(49, 31);
            this.button3.TabIndex = 2;
            this.button3.TabStop = false;
            this.button3.Text = "X";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.xTitulo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(949, 31);
            this.panel2.TabIndex = 4;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            this.panel2.DoubleClick += new System.EventHandler(this.panel2_DoubleClick);
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseMove);
            this.panel2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseUp);
            // 
            // xTitulo
            // 
            this.xTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.xTitulo.AutoSize = true;
            this.xTitulo.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xTitulo.Location = new System.Drawing.Point(9, 5);
            this.xTitulo.Name = "xTitulo";
            this.xTitulo.Size = new System.Drawing.Size(145, 23);
            this.xTitulo.TabIndex = 0;
            this.xTitulo.Text = "easySoftware";
            this.xTitulo.DoubleClick += new System.EventHandler(this.xTitulo_DoubleClick);
            this.xTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            this.xTitulo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseMove);
            this.xTitulo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseUp);
            // 
            // errP
            // 
            this.errP.ContainerControl = this;
            // 
            // misImagenes
            // 
            this.misImagenes.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("misImagenes.ImageStream")));
            this.misImagenes.TransparentColor = System.Drawing.Color.Transparent;
            this.misImagenes.Images.SetKeyName(0, "diskette.png");
            // 
            // easyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1120, 547);
            this.Controls.Add(this.barraTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "easyForm";
            this.Text = "easyForm";
            this.Load += new System.EventHandler(this.easyForm_Load);
            this.barraTitulo.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errP)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label xTitulo;
        public System.Windows.Forms.ErrorProvider errP;
        public System.Windows.Forms.ToolTip miTip;
        public System.Windows.Forms.TableLayoutPanel barraTitulo;
        public System.Windows.Forms.ImageList misImagenes;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.Button button2;
        public System.Windows.Forms.Button button3;
    }
}