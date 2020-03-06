namespace Compi1_Proyecto1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Menu = new System.Windows.Forms.Panel();
            this.BarraTop = new System.Windows.Forms.Panel();
            this.Container = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.PictureBox();
            this.btnMaximize = new System.Windows.Forms.PictureBox();
            this.btnNormalSize = new System.Windows.Forms.PictureBox();
            this.btnMinimize = new System.Windows.Forms.PictureBox();
            this.BarraTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNormalSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).BeginInit();
            this.SuspendLayout();
            // 
            // Menu
            // 
            this.Menu.BackColor = System.Drawing.Color.Blue;
            this.Menu.Dock = System.Windows.Forms.DockStyle.Left;
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(300, 800);
            this.Menu.TabIndex = 0;
            // 
            // BarraTop
            // 
            this.BarraTop.BackColor = System.Drawing.Color.RoyalBlue;
            this.BarraTop.Controls.Add(this.btnMinimize);
            this.BarraTop.Controls.Add(this.btnNormalSize);
            this.BarraTop.Controls.Add(this.btnMaximize);
            this.BarraTop.Controls.Add(this.btnClose);
            this.BarraTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.BarraTop.Location = new System.Drawing.Point(300, 0);
            this.BarraTop.Name = "BarraTop";
            this.BarraTop.Size = new System.Drawing.Size(900, 60);
            this.BarraTop.TabIndex = 1;
            // 
            // Container
            // 
            this.Container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Container.Location = new System.Drawing.Point(300, 60);
            this.Container.Name = "Container";
            this.Container.Size = new System.Drawing.Size(900, 740);
            this.Container.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(868, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(20, 20);
            this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnClose.TabIndex = 0;
            this.btnClose.TabStop = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnMaximize
            // 
            this.btnMaximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMaximize.Image = ((System.Drawing.Image)(resources.GetObject("btnMaximize.Image")));
            this.btnMaximize.Location = new System.Drawing.Point(842, 12);
            this.btnMaximize.Name = "btnMaximize";
            this.btnMaximize.Size = new System.Drawing.Size(20, 20);
            this.btnMaximize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMaximize.TabIndex = 1;
            this.btnMaximize.TabStop = false;
            this.btnMaximize.Click += new System.EventHandler(this.btnMaximize_Click);
            // 
            // btnNormalSize
            // 
            this.btnNormalSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNormalSize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNormalSize.Image = ((System.Drawing.Image)(resources.GetObject("btnNormalSize.Image")));
            this.btnNormalSize.Location = new System.Drawing.Point(842, 12);
            this.btnNormalSize.Name = "btnNormalSize";
            this.btnNormalSize.Size = new System.Drawing.Size(20, 20);
            this.btnNormalSize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnNormalSize.TabIndex = 2;
            this.btnNormalSize.TabStop = false;
            this.btnNormalSize.Visible = false;
            this.btnNormalSize.Click += new System.EventHandler(this.btnNormalSize_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimize.Image = ((System.Drawing.Image)(resources.GetObject("btnMinimize.Image")));
            this.btnMinimize.Location = new System.Drawing.Point(816, 12);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(20, 20);
            this.btnMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMinimize.TabIndex = 3;
            this.btnMinimize.TabStop = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.Controls.Add(this.Container);
            this.Controls.Add(this.BarraTop);
            this.Controls.Add(this.Menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.BarraTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNormalSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).EndInit();
            this.ResumeLayout(false);

        }

    #endregion

    private System.Windows.Forms.Panel MenuVertical;
    private System.Windows.Forms.Panel Barra;
    private System.Windows.Forms.PictureBox btnMenu;
    private System.Windows.Forms.Panel Contenedor;
    private System.Windows.Forms.PictureBox btnMin;
    private System.Windows.Forms.PictureBox btnRestore;
    private System.Windows.Forms.PictureBox btnMax;
    private System.Windows.Forms.PictureBox btnCerrar;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.PictureBox btnNewTab;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.PictureBox btnPDF;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.PictureBox btnSaveFile;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.PictureBox btnNewFile;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.PictureBox btnClean;
    private System.Windows.Forms.Label btnAnalizar2;
    private System.Windows.Forms.PictureBox btnCorrer;
    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.Panel Menu;
    private System.Windows.Forms.Panel BarraTop;
    private System.Windows.Forms.Panel Container;
    private System.Windows.Forms.PictureBox btnMinimize;
    private System.Windows.Forms.PictureBox btnNormalSize;
    private System.Windows.Forms.PictureBox btnMaximize;
    private System.Windows.Forms.PictureBox btnClose;
  }
}

