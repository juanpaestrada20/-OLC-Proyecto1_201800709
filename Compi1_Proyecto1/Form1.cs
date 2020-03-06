using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compi1_Proyecto1
{
    public partial class Form1 : Form
    {
    private int numPestana = 0;

        public Form1()
        {
            InitializeComponent();
        }
    //Funcion al panel de la barra
    [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
    private extern static void ReleaseCapture();
    [DllImport("user32.DLL", EntryPoint = "SendMessage")]
    private extern static void SendMessage(IntPtr hwnd, int wsmg, int wparam, int lmaparam);

    private void pictureBox1_Click(object sender, EventArgs e)
    {
      if(MenuVertical.Width == 280)
      {
        MenuVertical.Width = 0;
      }
      else
      {
        MenuVertical.Width = 280;
      }
    }

    private void btnCerrar_Click(object sender, EventArgs e)
    {
      Application.Exit();
    }

    private void btnMax_Click(object sender, EventArgs e)
    {
      this.WindowState = FormWindowState.Maximized;
      btnRestore.Visible = true;
      btnMax.Visible = false;
    }

    private void btnRestore_Click(object sender, EventArgs e)
    {
      this.WindowState = FormWindowState.Normal;
      btnRestore.Visible = false;
      btnMax.Visible = true;
    }

    private void btnMin_Click(object sender, EventArgs e)
    {
      this.WindowState = FormWindowState.Minimized;
    }

    private void Barra_MouseDown(object sender, MouseEventArgs e)
    {
      ReleaseCapture();
      SendMessage(this.Handle, 0x112, 0xf012, 0);
      if (this.WindowState == FormWindowState.Normal)
      {
        btnMax.Visible = true;
        btnRestore.Visible = false;
      }
    }

    private void label2_Click(object sender, EventArgs e)
    {

    }

    private void label6_Click(object sender, EventArgs e)
    {

    }

    private RichTextBox GetRichTextBox()
    {
      RichTextBox rtb = null;
      TabPage tp = tabControl1.SelectedTab;

      if (tp != null)
      {
        rtb = tp.Controls[0] as RichTextBox;
      }

      return rtb;
    }

    private void btnNewTab_Click(object sender, EventArgs e)
    {
      numPestana++;

      TabPage pestana = new TabPage("Pestaña " + numPestana);
      RichTextBox richtxt = new RichTextBox();
      richtxt.Dock = DockStyle.Fill;

      pestana.Controls.Add(richtxt);
      tabControl1.TabPages.Add(pestana);
    }

    private void Form1_Load(object sender, EventArgs e)
    {

    }
  }
}
