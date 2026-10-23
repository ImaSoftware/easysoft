namespace proofC
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.txtIn = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.wB1 = new System.Windows.Forms.WebBrowser();
            this.chkPrueba = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.rbXSD = new System.Windows.Forms.RadioButton();
            this.rbAutoriza = new System.Windows.Forms.RadioButton();
            this.rbRecibe = new System.Windows.Forms.RadioButton();
            this.rbMail = new System.Windows.Forms.RadioButton();
            this.rbFirmado = new System.Windows.Forms.RadioButton();
            this.rbRide = new System.Windows.Forms.RadioButton();
            this.button2 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 141F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tableLayoutPanel1.Controls.Add(this.button1, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtIn, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.wB1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.chkPrueba, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.button2, 3, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(515, 320);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(460, 286);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(52, 31);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtIn
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtIn, 2);
            this.txtIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtIn.Location = new System.Drawing.Point(3, 286);
            this.txtIn.Multiline = true;
            this.txtIn.Name = "txtIn";
            this.txtIn.Size = new System.Drawing.Size(451, 31);
            this.txtIn.TabIndex = 1;
            this.txtIn.Text = "3110201701099004945900120010060025183723128989415";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 255);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Clave de Acceso:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Resultado:";
            // 
            // wB1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.wB1, 3);
            this.wB1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wB1.Location = new System.Drawing.Point(3, 23);
            this.wB1.MinimumSize = new System.Drawing.Size(20, 20);
            this.wB1.Name = "wB1";
            this.wB1.Size = new System.Drawing.Size(509, 143);
            this.wB1.TabIndex = 3;
            this.wB1.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.wB1_Navigated);
            // 
            // chkPrueba
            // 
            this.chkPrueba.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkPrueba.Location = new System.Drawing.Point(3, 172);
            this.chkPrueba.Name = "chkPrueba";
            this.chkPrueba.Size = new System.Drawing.Size(135, 80);
            this.chkPrueba.TabIndex = 4;
            this.chkPrueba.Text = "Ambiente Prueba";
            this.chkPrueba.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.groupBox1, 2);
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(144, 172);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(368, 80);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Metodo";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Controls.Add(this.rbXSD, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.rbAutoriza, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.rbRecibe, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.rbMail, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.rbFirmado, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.rbRide, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(362, 61);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // rbXSD
            // 
            this.rbXSD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbXSD.Location = new System.Drawing.Point(123, 33);
            this.rbXSD.Name = "rbXSD";
            this.rbXSD.Size = new System.Drawing.Size(114, 25);
            this.rbXSD.TabIndex = 2;
            this.rbXSD.Text = "XSD";
            this.rbXSD.UseVisualStyleBackColor = true;
            this.rbXSD.CheckedChanged += new System.EventHandler(this.rbXSD_CheckedChanged);
            // 
            // rbAutoriza
            // 
            this.rbAutoriza.Checked = true;
            this.rbAutoriza.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbAutoriza.Location = new System.Drawing.Point(3, 3);
            this.rbAutoriza.Name = "rbAutoriza";
            this.rbAutoriza.Size = new System.Drawing.Size(114, 24);
            this.rbAutoriza.TabIndex = 0;
            this.rbAutoriza.TabStop = true;
            this.rbAutoriza.Text = "Autoriza";
            this.rbAutoriza.UseVisualStyleBackColor = true;
            this.rbAutoriza.CheckedChanged += new System.EventHandler(this.rdAutoriza_CheckedChanged);
            // 
            // rbRecibe
            // 
            this.rbRecibe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbRecibe.Location = new System.Drawing.Point(123, 3);
            this.rbRecibe.Name = "rbRecibe";
            this.rbRecibe.Size = new System.Drawing.Size(114, 24);
            this.rbRecibe.TabIndex = 1;
            this.rbRecibe.Text = "Recepcion";
            this.rbRecibe.UseVisualStyleBackColor = true;
            this.rbRecibe.CheckedChanged += new System.EventHandler(this.rdRecibe_CheckedChanged);
            // 
            // rbMail
            // 
            this.rbMail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbMail.Location = new System.Drawing.Point(243, 3);
            this.rbMail.Name = "rbMail";
            this.rbMail.Size = new System.Drawing.Size(116, 24);
            this.rbMail.TabIndex = 1;
            this.rbMail.Text = "e-mail";
            this.rbMail.UseVisualStyleBackColor = true;
            this.rbMail.CheckedChanged += new System.EventHandler(this.rbMail_CheckedChanged);
            // 
            // rbFirmado
            // 
            this.rbFirmado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbFirmado.Location = new System.Drawing.Point(3, 33);
            this.rbFirmado.Name = "rbFirmado";
            this.rbFirmado.Size = new System.Drawing.Size(114, 25);
            this.rbFirmado.TabIndex = 0;
            this.rbFirmado.Text = "Firmado";
            this.rbFirmado.UseVisualStyleBackColor = true;
            this.rbFirmado.CheckedChanged += new System.EventHandler(this.rdFirmado_CheckedChanged);
            // 
            // rbRide
            // 
            this.rbRide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbRide.Location = new System.Drawing.Point(243, 33);
            this.rbRide.Name = "rbRide";
            this.rbRide.Size = new System.Drawing.Size(116, 25);
            this.rbRide.TabIndex = 0;
            this.rbRide.Text = "RIDE";
            this.rbRide.UseVisualStyleBackColor = true;
            this.rbRide.CheckedChanged += new System.EventHandler(this.rdRIDE_CheckedChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(460, 258);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(52, 22);
            this.button2.TabIndex = 6;
            this.button2.Text = "CMP";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 320);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "ELPROBADOR";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtIn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.WebBrowser wB1;
        private System.Windows.Forms.CheckBox chkPrueba;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.RadioButton rbAutoriza;
        private System.Windows.Forms.RadioButton rbRecibe;
        private System.Windows.Forms.RadioButton rbMail;
        private System.Windows.Forms.RadioButton rbFirmado;
        private System.Windows.Forms.RadioButton rbRide;
        private System.Windows.Forms.RadioButton rbXSD;
        private System.Windows.Forms.Button button2;
    }
}

