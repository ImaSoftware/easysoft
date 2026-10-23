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
            this.rbAutoriza = new System.Windows.Forms.RadioButton();
            this.rbRecibe = new System.Windows.Forms.RadioButton();
            this.rbMail = new System.Windows.Forms.RadioButton();
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
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(563, 248);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(508, 209);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(52, 36);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtIn
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtIn, 2);
            this.txtIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtIn.Location = new System.Drawing.Point(3, 209);
            this.txtIn.Multiline = true;
            this.txtIn.Name = "txtIn";
            this.txtIn.Size = new System.Drawing.Size(499, 36);
            this.txtIn.TabIndex = 1;
            this.txtIn.Text = "3110201701099004945900120010060025183723128989415";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 183);
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
            this.wB1.Size = new System.Drawing.Size(557, 96);
            this.wB1.TabIndex = 3;
            this.wB1.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.wB1_Navigated);
            // 
            // chkPrueba
            // 
            this.chkPrueba.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkPrueba.Location = new System.Drawing.Point(3, 125);
            this.chkPrueba.Name = "chkPrueba";
            this.chkPrueba.Size = new System.Drawing.Size(135, 55);
            this.chkPrueba.TabIndex = 4;
            this.chkPrueba.Text = "Ambiente Prueba";
            this.chkPrueba.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.groupBox1, 2);
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(144, 125);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(416, 55);
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
            this.tableLayoutPanel2.Controls.Add(this.rbAutoriza, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.rbRecibe, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.rbMail, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(410, 36);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // rbAutoriza
            // 
            this.rbAutoriza.Checked = true;
            this.rbAutoriza.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbAutoriza.Location = new System.Drawing.Point(3, 3);
            this.rbAutoriza.Name = "rbAutoriza";
            this.rbAutoriza.Size = new System.Drawing.Size(130, 30);
            this.rbAutoriza.TabIndex = 0;
            this.rbAutoriza.TabStop = true;
            this.rbAutoriza.Text = "Autoriza";
            this.rbAutoriza.UseVisualStyleBackColor = true;
            this.rbAutoriza.CheckedChanged += new System.EventHandler(this.rdAutoriza_CheckedChanged);
            // 
            // rbRecibe
            // 
            this.rbRecibe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbRecibe.Location = new System.Drawing.Point(139, 3);
            this.rbRecibe.Name = "rbRecibe";
            this.rbRecibe.Size = new System.Drawing.Size(130, 30);
            this.rbRecibe.TabIndex = 1;
            this.rbRecibe.Text = "Recepcion";
            this.rbRecibe.UseVisualStyleBackColor = true;
            this.rbRecibe.CheckedChanged += new System.EventHandler(this.rdRecibe_CheckedChanged);
            // 
            // rbMail
            // 
            this.rbMail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbMail.Location = new System.Drawing.Point(275, 3);
            this.rbMail.Name = "rbMail";
            this.rbMail.Size = new System.Drawing.Size(132, 30);
            this.rbMail.TabIndex = 1;
            this.rbMail.Text = "e-mail";
            this.rbMail.UseVisualStyleBackColor = true;
            this.rbMail.CheckedChanged += new System.EventHandler(this.rbMail_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 248);
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
    }
}

