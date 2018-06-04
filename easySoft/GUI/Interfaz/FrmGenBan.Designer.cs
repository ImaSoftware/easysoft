namespace GUI.Interfaz
{
    partial class FrmGenBan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGenBan));
            this.label1 = new System.Windows.Forms.Label();
            this.cmbBanco = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvRoles = new System.Windows.Forms.DataGridView();
            this.cTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cFecDesde = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cFecHasta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnGenera = new System.Windows.Forms.Button();
            this.fechaini = new System.Windows.Forms.DateTimePicker();
            this.fechahasta = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.errP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoles)).BeginInit();
            this.SuspendLayout();
            // 
            // misImagenes
            // 
            this.misImagenes.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("misImagenes.ImageStream")));
            this.misImagenes.Images.SetKeyName(0, "diskette.png");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Seleccione el Banco";
            // 
            // cmbBanco
            // 
            this.cmbBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBanco.FormattingEnabled = true;
            this.cmbBanco.Location = new System.Drawing.Point(142, 51);
            this.cmbBanco.Name = "cmbBanco";
            this.cmbBanco.Size = new System.Drawing.Size(179, 21);
            this.cmbBanco.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Seleccione el Rol";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Desde";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(180, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Hasta";
            // 
            // dgvRoles
            // 
            this.dgvRoles.AllowUserToAddRows = false;
            this.dgvRoles.AllowUserToDeleteRows = false;
            this.dgvRoles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRoles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRoles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cTipo,
            this.cFecDesde,
            this.cFecHasta});
            this.dgvRoles.Location = new System.Drawing.Point(19, 141);
            this.dgvRoles.Name = "dgvRoles";
            this.dgvRoles.ReadOnly = true;
            this.dgvRoles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRoles.Size = new System.Drawing.Size(383, 225);
            this.dgvRoles.TabIndex = 6;
            this.dgvRoles.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRoles_CellDoubleClick);
            // 
            // cTipo
            // 
            this.cTipo.DataPropertyName = "NOMBRE_REP";
            this.cTipo.HeaderText = "Tipo";
            this.cTipo.Name = "cTipo";
            this.cTipo.ReadOnly = true;
            this.cTipo.Width = 53;
            // 
            // cFecDesde
            // 
            this.cFecDesde.DataPropertyName = "FECHA_DES";
            this.cFecDesde.HeaderText = "Desde";
            this.cFecDesde.Name = "cFecDesde";
            this.cFecDesde.ReadOnly = true;
            this.cFecDesde.Width = 63;
            // 
            // cFecHasta
            // 
            this.cFecHasta.DataPropertyName = "FECHA_HAS";
            this.cFecHasta.HeaderText = "Hasta";
            this.cFecHasta.Name = "cFecHasta";
            this.cFecHasta.ReadOnly = true;
            this.cFecHasta.Width = 60;
            // 
            // btnGenera
            // 
            this.btnGenera.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenera.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenera.ImageKey = "diskette.png";
            this.btnGenera.ImageList = this.misImagenes;
            this.btnGenera.Location = new System.Drawing.Point(252, 372);
            this.btnGenera.Name = "btnGenera";
            this.btnGenera.Size = new System.Drawing.Size(150, 33);
            this.btnGenera.TabIndex = 7;
            this.btnGenera.Text = "Guardar Archivo";
            this.btnGenera.UseVisualStyleBackColor = true;
            this.btnGenera.Click += new System.EventHandler(this.btnGenera_Click);
            // 
            // fechaini
            // 
            this.fechaini.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fechaini.Location = new System.Drawing.Point(65, 106);
            this.fechaini.Name = "fechaini";
            this.fechaini.Size = new System.Drawing.Size(100, 20);
            this.fechaini.TabIndex = 8;
            this.fechaini.Value = new System.DateTime(2018, 6, 4, 15, 46, 25, 0);
            this.fechaini.ValueChanged += new System.EventHandler(this.fechahasta_ValueChanged);
            // 
            // fechahasta
            // 
            this.fechahasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fechahasta.Location = new System.Drawing.Point(221, 106);
            this.fechahasta.Name = "fechahasta";
            this.fechahasta.Size = new System.Drawing.Size(100, 20);
            this.fechahasta.TabIndex = 9;
            this.fechahasta.Value = new System.DateTime(2018, 6, 4, 15, 46, 14, 0);
            this.fechahasta.ValueChanged += new System.EventHandler(this.fechahasta_ValueChanged);
            // 
            // FrmGenBan
            // 
            this.AcceptButton = this.btnGenera;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button3;
            this.ClientSize = new System.Drawing.Size(414, 417);
            this.Controls.Add(this.fechahasta);
            this.Controls.Add(this.fechaini);
            this.Controls.Add(this.btnGenera);
            this.Controls.Add(this.dgvRoles);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbBanco);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(335, 0);
            this.Name = "FrmGenBan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CtlGenBan";
            this.Load += new System.EventHandler(this.FrmGenBan_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cmbBanco, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.dgvRoles, 0);
            this.Controls.SetChildIndex(this.btnGenera, 0);
            this.Controls.SetChildIndex(this.fechaini, 0);
            this.Controls.SetChildIndex(this.fechahasta, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbBanco;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvRoles;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cFecDesde;
        private System.Windows.Forms.DataGridViewTextBoxColumn cFecHasta;
        private System.Windows.Forms.Button btnGenera;
        private System.Windows.Forms.DateTimePicker fechaini;
        private System.Windows.Forms.DateTimePicker fechahasta;
    }
}