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
            this.lblOpenFile = new System.Windows.Forms.Label();
            this.lblSave = new System.Windows.Forms.Label();
            this.lblTab = new System.Windows.Forms.Label();
            this.lblStart = new System.Windows.Forms.Label();
            this.lblVerify = new System.Windows.Forms.Label();
            this.lblTokens = new System.Windows.Forms.Label();
            this.lblErrores = new System.Windows.Forms.Label();
            this.btnMenuHide = new System.Windows.Forms.PictureBox();
            this.btnMinimize = new System.Windows.Forms.PictureBox();
            this.btnNormalSize = new System.Windows.Forms.PictureBox();
            this.btnMaximize = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.PictureBox();
            this.btnErrores = new System.Windows.Forms.PictureBox();
            this.btnTokens = new System.Windows.Forms.PictureBox();
            this.btnVerify = new System.Windows.Forms.PictureBox();
            this.btnStart = new System.Windows.Forms.PictureBox();
            this.btnTab = new System.Windows.Forms.PictureBox();
            this.btnSave = new System.Windows.Forms.PictureBox();
            this.btnOpenFile = new System.Windows.Forms.PictureBox();
            this.btnRestart = new System.Windows.Forms.PictureBox();
            this.lblRestart = new System.Windows.Forms.Label();
            this.Menu.SuspendLayout();
            this.BarraTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMenuHide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNormalSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnErrores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnTokens)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnVerify)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnTab)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOpenFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRestart)).BeginInit();
            this.SuspendLayout();
            // 
            // Menu
            // 
            this.Menu.BackColor = System.Drawing.Color.Blue;
            this.Menu.Controls.Add(this.lblRestart);
            this.Menu.Controls.Add(this.btnRestart);
            this.Menu.Controls.Add(this.lblErrores);
            this.Menu.Controls.Add(this.btnErrores);
            this.Menu.Controls.Add(this.lblTokens);
            this.Menu.Controls.Add(this.lblVerify);
            this.Menu.Controls.Add(this.lblStart);
            this.Menu.Controls.Add(this.lblTab);
            this.Menu.Controls.Add(this.lblSave);
            this.Menu.Controls.Add(this.lblOpenFile);
            this.Menu.Controls.Add(this.btnTokens);
            this.Menu.Controls.Add(this.btnVerify);
            this.Menu.Controls.Add(this.btnStart);
            this.Menu.Controls.Add(this.btnTab);
            this.Menu.Controls.Add(this.btnSave);
            this.Menu.Controls.Add(this.btnOpenFile);
            this.Menu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Menu.Dock = System.Windows.Forms.DockStyle.Left;
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(300, 800);
            this.Menu.TabIndex = 0;
            // 
            // BarraTop
            // 
            this.BarraTop.BackColor = System.Drawing.Color.RoyalBlue;
            this.BarraTop.Controls.Add(this.btnMenuHide);
            this.BarraTop.Controls.Add(this.btnMinimize);
            this.BarraTop.Controls.Add(this.btnNormalSize);
            this.BarraTop.Controls.Add(this.btnMaximize);
            this.BarraTop.Controls.Add(this.btnClose);
            this.BarraTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.BarraTop.Location = new System.Drawing.Point(300, 0);
            this.BarraTop.Name = "BarraTop";
            this.BarraTop.Size = new System.Drawing.Size(900, 60);
            this.BarraTop.TabIndex = 1;
            this.BarraTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BarraTop_MouseDown);
            // 
            // Container
            // 
            this.Container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Container.Location = new System.Drawing.Point(300, 60);
            this.Container.Name = "Container";
            this.Container.Size = new System.Drawing.Size(900, 740);
            this.Container.TabIndex = 2;
            // 
            // lblOpenFile
            // 
            this.lblOpenFile.AutoSize = true;
            this.lblOpenFile.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOpenFile.Location = new System.Drawing.Point(78, 36);
            this.lblOpenFile.Name = "lblOpenFile";
            this.lblOpenFile.Size = new System.Drawing.Size(166, 24);
            this.lblOpenFile.TabIndex = 6;
            this.lblOpenFile.Text = "Abrir Archivo";
            // 
            // lblSave
            // 
            this.lblSave.AutoSize = true;
            this.lblSave.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSave.Location = new System.Drawing.Point(78, 114);
            this.lblSave.Name = "lblSave";
            this.lblSave.Size = new System.Drawing.Size(190, 24);
            this.lblSave.TabIndex = 7;
            this.lblSave.Text = "Guardar Archivo";
            this.lblSave.Click += new System.EventHandler(this.label7_Click);
            // 
            // lblTab
            // 
            this.lblTab.AutoSize = true;
            this.lblTab.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTab.Location = new System.Drawing.Point(78, 187);
            this.lblTab.Name = "lblTab";
            this.lblTab.Size = new System.Drawing.Size(166, 24);
            this.lblTab.TabIndex = 8;
            this.lblTab.Text = "Nueva Pestaña";
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStart.Location = new System.Drawing.Point(78, 263);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(214, 24);
            this.lblStart.TabIndex = 9;
            this.lblStart.Text = "Generar Automatas";
            // 
            // lblVerify
            // 
            this.lblVerify.AutoSize = true;
            this.lblVerify.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVerify.Location = new System.Drawing.Point(78, 339);
            this.lblVerify.Name = "lblVerify";
            this.lblVerify.Size = new System.Drawing.Size(214, 24);
            this.lblVerify.TabIndex = 10;
            this.lblVerify.Text = "Verificar Lexemas";
            // 
            // lblTokens
            // 
            this.lblTokens.AutoSize = true;
            this.lblTokens.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTokens.Location = new System.Drawing.Point(78, 414);
            this.lblTokens.Name = "lblTokens";
            this.lblTokens.Size = new System.Drawing.Size(130, 24);
            this.lblTokens.TabIndex = 11;
            this.lblTokens.Text = "Ver Tokens";
            // 
            // lblErrores
            // 
            this.lblErrores.AutoSize = true;
            this.lblErrores.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrores.Location = new System.Drawing.Point(78, 490);
            this.lblErrores.Name = "lblErrores";
            this.lblErrores.Size = new System.Drawing.Size(142, 24);
            this.lblErrores.TabIndex = 13;
            this.lblErrores.Text = "Ver Errores";
            this.lblErrores.Click += new System.EventHandler(this.label12_Click);
            // 
            // btnMenuHide
            // 
            this.btnMenuHide.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenuHide.Image = global::Compi1_Proyecto1.Properties.Resources.menu;
            this.btnMenuHide.Location = new System.Drawing.Point(6, 4);
            this.btnMenuHide.Name = "btnMenuHide";
            this.btnMenuHide.Size = new System.Drawing.Size(50, 50);
            this.btnMenuHide.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMenuHide.TabIndex = 4;
            this.btnMenuHide.TabStop = false;
            this.btnMenuHide.Click += new System.EventHandler(this.btnMenuHide_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimize.Image = global::Compi1_Proyecto1.Properties.Resources.minimize;
            this.btnMinimize.Location = new System.Drawing.Point(816, 12);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(20, 20);
            this.btnMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMinimize.TabIndex = 3;
            this.btnMinimize.TabStop = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnNormalSize
            // 
            this.btnNormalSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNormalSize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNormalSize.Image = global::Compi1_Proyecto1.Properties.Resources.tamano_pequq;
            this.btnNormalSize.Location = new System.Drawing.Point(842, 12);
            this.btnNormalSize.Name = "btnNormalSize";
            this.btnNormalSize.Size = new System.Drawing.Size(20, 20);
            this.btnNormalSize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnNormalSize.TabIndex = 2;
            this.btnNormalSize.TabStop = false;
            this.btnNormalSize.Visible = false;
            this.btnNormalSize.Click += new System.EventHandler(this.btnNormalSize_Click);
            // 
            // btnMaximize
            // 
            this.btnMaximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMaximize.Image = global::Compi1_Proyecto1.Properties.Resources.expand;
            this.btnMaximize.Location = new System.Drawing.Point(842, 12);
            this.btnMaximize.Name = "btnMaximize";
            this.btnMaximize.Size = new System.Drawing.Size(20, 20);
            this.btnMaximize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMaximize.TabIndex = 1;
            this.btnMaximize.TabStop = false;
            this.btnMaximize.Click += new System.EventHandler(this.btnMaximize_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Image = global::Compi1_Proyecto1.Properties.Resources.close;
            this.btnClose.Location = new System.Drawing.Point(868, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(20, 20);
            this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnClose.TabIndex = 0;
            this.btnClose.TabStop = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnErrores
            // 
            this.btnErrores.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnErrores.Image = global::Compi1_Proyecto1.Properties.Resources.navegador;
            this.btnErrores.Location = new System.Drawing.Point(12, 475);
            this.btnErrores.Name = "btnErrores";
            this.btnErrores.Size = new System.Drawing.Size(60, 60);
            this.btnErrores.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnErrores.TabIndex = 12;
            this.btnErrores.TabStop = false;
            // 
            // btnTokens
            // 
            this.btnTokens.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTokens.Image = global::Compi1_Proyecto1.Properties.Resources.simbolico;
            this.btnTokens.Location = new System.Drawing.Point(12, 399);
            this.btnTokens.Name = "btnTokens";
            this.btnTokens.Size = new System.Drawing.Size(60, 60);
            this.btnTokens.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnTokens.TabIndex = 5;
            this.btnTokens.TabStop = false;
            // 
            // btnVerify
            // 
            this.btnVerify.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerify.Image = global::Compi1_Proyecto1.Properties.Resources.papel;
            this.btnVerify.Location = new System.Drawing.Point(12, 323);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(60, 60);
            this.btnVerify.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnVerify.TabIndex = 4;
            this.btnVerify.TabStop = false;
            // 
            // btnStart
            // 
            this.btnStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStart.Image = global::Compi1_Proyecto1.Properties.Resources.prueba;
            this.btnStart.Location = new System.Drawing.Point(12, 245);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(60, 60);
            this.btnStart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnStart.TabIndex = 3;
            this.btnStart.TabStop = false;
            this.btnStart.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // btnTab
            // 
            this.btnTab.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTab.Image = global::Compi1_Proyecto1.Properties.Resources.fichas;
            this.btnTab.Location = new System.Drawing.Point(12, 168);
            this.btnTab.Name = "btnTab";
            this.btnTab.Size = new System.Drawing.Size(60, 60);
            this.btnTab.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnTab.TabIndex = 2;
            this.btnTab.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Image = global::Compi1_Proyecto1.Properties.Resources.guardar;
            this.btnSave.Location = new System.Drawing.Point(12, 91);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(60, 60);
            this.btnSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnSave.TabIndex = 1;
            this.btnSave.TabStop = false;
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpenFile.Image = global::Compi1_Proyecto1.Properties.Resources.carpeta;
            this.btnOpenFile.Location = new System.Drawing.Point(12, 12);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(60, 60);
            this.btnOpenFile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnOpenFile.TabIndex = 0;
            this.btnOpenFile.TabStop = false;
            // 
            // btnRestart
            // 
            this.btnRestart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRestart.Image = global::Compi1_Proyecto1.Properties.Resources.telefono_movil;
            this.btnRestart.Location = new System.Drawing.Point(12, 551);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(60, 60);
            this.btnRestart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnRestart.TabIndex = 14;
            this.btnRestart.TabStop = false;
            // 
            // lblRestart
            // 
            this.lblRestart.AutoSize = true;
            this.lblRestart.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRestart.Location = new System.Drawing.Point(78, 569);
            this.lblRestart.Name = "lblRestart";
            this.lblRestart.Size = new System.Drawing.Size(154, 24);
            this.lblRestart.TabIndex = 15;
            this.lblRestart.Text = "Limpiar Todo";
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
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            this.BarraTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnMenuHide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNormalSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnErrores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnTokens)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnVerify)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnTab)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOpenFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRestart)).EndInit();
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
    private System.Windows.Forms.PictureBox btnOpenFile;
    private System.Windows.Forms.PictureBox btnMenuHide;
    private System.Windows.Forms.PictureBox btnTokens;
    private System.Windows.Forms.PictureBox btnVerify;
    private System.Windows.Forms.PictureBox btnStart;
    private System.Windows.Forms.PictureBox btnTab;
    private System.Windows.Forms.PictureBox btnSave;
    private System.Windows.Forms.Label lblSave;
    private System.Windows.Forms.Label lblOpenFile;
    private System.Windows.Forms.Label lblErrores;
    private System.Windows.Forms.PictureBox btnErrores;
    private System.Windows.Forms.Label lblTokens;
    private System.Windows.Forms.Label lblVerify;
    private System.Windows.Forms.Label lblStart;
    private System.Windows.Forms.Label lblTab;
    private System.Windows.Forms.Label lblRestart;
    private System.Windows.Forms.PictureBox btnRestart;
  }
}

