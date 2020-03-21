using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Compi1_Proyecto1
{
  public partial class Form1 : Form
  {
    private int numPestana;
    private static string ruta;

    public Form1()
    {
      InitializeComponent();
      numPestana = 0;
      ruta = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
    }

    //Funcion al panel de la barra
    [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
    private extern static void ReleaseCapture();

    [DllImport("user32.DLL", EntryPoint = "SendMessage")]
    private extern static void SendMessage(IntPtr hwnd, int wsmg, int wparam, int lmaparam);

    private void Form1_Load(object sender, EventArgs e)
    {
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
      Application.Exit();
    }

    private void btnMaximize_Click(object sender, EventArgs e)
    {
      this.WindowState = FormWindowState.Maximized;
      btnMaximize.Visible = false;
      btnNormalSize.Visible = true;
    }

    private void btnNormalSize_Click(object sender, EventArgs e)
    {
      this.WindowState = FormWindowState.Normal;
      btnMaximize.Visible = true;
      btnNormalSize.Visible = false;
    }

    private void btnMinimize_Click(object sender, EventArgs e)
    {
      this.WindowState = FormWindowState.Minimized;
    }

    private void btnMenuHide_Click(object sender, EventArgs e)
    {
      if (Menu.Width == 300)
      {
        Menu.Width = 82;
      }
      else
      {
        Menu.Width = 300;
      }
    }

    private void pictureBox4_Click(object sender, EventArgs e)
    {
      AnalizadorLexico analizador = new AnalizadorLexico();
      AnalizadorSintactico sintactico = new AnalizadorSintactico();
      LinkedList<Token> listaTokens = analizador.Escanner("hola");
      analizador.agregarUltimo();
      //analizador.imprimirTokens();

      sintactico.parser(listaTokens);
    }

    private void label7_Click(object sender, EventArgs e)
    {
    }

    private void BarraTop_MouseDown(object sender, MouseEventArgs e)
    {
      ReleaseCapture();
      SendMessage(this.Handle, 0x112, 0xf012, 0);
      if (this.WindowState == FormWindowState.Normal)
      {
        btnMaximize.Visible = true;
        btnNormalSize.Visible = false;
      }
    }

    private void label12_Click(object sender, EventArgs e)
    {
    }

    private void openFile()
    {
    }

    private void saveFile()
    {
    }

    private void newTab()
    {
    }

    private void Start()
    {
    }

    private void openTokens()
    {
    }

    private void openMistkes()
    {
    }

    private void Restart()
    {
    }
  }
}
