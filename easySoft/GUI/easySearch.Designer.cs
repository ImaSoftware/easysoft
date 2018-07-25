namespace GUI
{
    partial class easySearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(easySearch));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnMode = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.ctlSearch = new System.Windows.Forms.TextBox();
            this.GV_Consulta = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.errP)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GV_Consulta)).BeginInit();
            this.SuspendLayout();
            // 
            // misImagenes
            // 
            this.misImagenes.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("misImagenes.ImageStream")));
            this.misImagenes.Images.SetKeyName(0, "search2.png");
            this.misImagenes.Images.SetKeyName(1, "s_fx.png");
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tableLayoutPanel1.Controls.Add(this.btnMode, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnSearch, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.ctlSearch, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.GV_Consulta, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 37);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 9F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(534, 382);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // btnMode
            // 
            this.btnMode.BackColor = System.Drawing.Color.Transparent;
            this.btnMode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMode.FlatAppearance.BorderSize = 0;
            this.btnMode.Location = new System.Drawing.Point(465, 350);
            this.btnMode.Name = "btnMode";
            this.btnMode.Size = new System.Drawing.Size(24, 21);
            this.btnMode.TabIndex = 3;
            this.btnMode.TabStop = false;
            this.btnMode.UseVisualStyleBackColor = false;
            this.btnMode.Click += new System.EventHandler(this.btnMode_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Transparent;
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.ImageIndex = 0;
            this.btnSearch.ImageList = this.misImagenes;
            this.btnSearch.Location = new System.Drawing.Point(495, 350);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(24, 21);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // ctlSearch
            // 
            this.ctlSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlSearch.Location = new System.Drawing.Point(13, 350);
            this.ctlSearch.Name = "ctlSearch";
            this.ctlSearch.Size = new System.Drawing.Size(446, 20);
            this.ctlSearch.TabIndex = 1;
            this.ctlSearch.TextChanged += new System.EventHandler(this.ctlSearch_TextChanged);
            this.ctlSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ctlSearch_KeyDown);
            this.ctlSearch.Leave += new System.EventHandler(this.ctlSearch_Leave);
            // 
            // GV_Consulta
            // 
            this.GV_Consulta.AllowUserToAddRows = false;
            this.GV_Consulta.AllowUserToDeleteRows = false;
            this.GV_Consulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.GV_Consulta, 3);
            this.GV_Consulta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GV_Consulta.Location = new System.Drawing.Point(13, 13);
            this.GV_Consulta.Name = "GV_Consulta";
            this.GV_Consulta.ReadOnly = true;
            this.GV_Consulta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GV_Consulta.Size = new System.Drawing.Size(506, 322);
            this.GV_Consulta.TabIndex = 2;
            this.GV_Consulta.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GV_Consulta_CellDoubleClick);
            this.GV_Consulta.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.GV_Consulta_ColumnHeaderMouseClick);
            // 
            // easySearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 419);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "easySearch";
            this.Text = "easySearch";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.easySearch_FormClosing);
            this.Load += new System.EventHandler(this.easySearch_Load);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errP)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GV_Consulta)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnMode;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox ctlSearch;
        private System.Windows.Forms.DataGridView GV_Consulta;
    }
}