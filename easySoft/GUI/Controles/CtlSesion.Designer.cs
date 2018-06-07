namespace GUI.Interfaz
{
    partial class CtlSesion
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtusernom = new System.Windows.Forms.TextBox();
            this.txtuserpwd = new System.Windows.Forms.TextBox();
            this.cmbEmpresas = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtusernom
            // 
            this.txtusernom.BackColor = System.Drawing.SystemColors.ControlText;
            this.txtusernom.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtusernom.Font = new System.Drawing.Font("Corbel", 16.25F);
            this.txtusernom.ForeColor = System.Drawing.Color.White;
            this.txtusernom.Location = new System.Drawing.Point(282, 216);
            this.txtusernom.Name = "txtusernom";
            this.txtusernom.Size = new System.Drawing.Size(170, 27);
            this.txtusernom.TabIndex = 1;
            this.txtusernom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtuserpwd
            // 
            this.txtuserpwd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtuserpwd.BackColor = System.Drawing.SystemColors.MenuText;
            this.txtuserpwd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtuserpwd.Font = new System.Drawing.Font("Showcard Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtuserpwd.ForeColor = System.Drawing.Color.White;
            this.txtuserpwd.Location = new System.Drawing.Point(282, 248);
            this.txtuserpwd.Name = "txtuserpwd";
            this.txtuserpwd.Size = new System.Drawing.Size(170, 26);
            this.txtuserpwd.TabIndex = 2;
            this.txtuserpwd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtuserpwd.UseSystemPasswordChar = true;
            // 
            // cmbEmpresas
            // 
            this.cmbEmpresas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbEmpresas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmpresas.FormattingEnabled = true;
            this.cmbEmpresas.Location = new System.Drawing.Point(284, 280);
            this.cmbEmpresas.Name = "cmbEmpresas";
            this.cmbEmpresas.Size = new System.Drawing.Size(168, 21);
            this.cmbEmpresas.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(362, 308);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 37);
            this.button1.TabIndex = 3;
            this.button1.Text = "LOGIN";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkRed;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(562, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(38, 25);
            this.button2.TabIndex = 7;
            this.button2.Text = "X";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // CtlSesion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GUI.Properties.Resources.INGRESO;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.cmbEmpresas);
            this.Controls.Add(this.txtuserpwd);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtusernom);
            this.Controls.Add(this.button2);
            this.Name = "CtlSesion";
            this.Size = new System.Drawing.Size(603, 536);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbEmpresas;
        private System.Windows.Forms.TextBox txtusernom;
        private System.Windows.Forms.TextBox txtuserpwd;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}
