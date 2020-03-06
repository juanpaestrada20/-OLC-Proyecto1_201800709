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
  }
}

