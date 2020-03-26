using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Compi1_Proyecto1
{
  public partial class form1 : Form
  {
    private int numPestana;
    private static string ruta;
    private static LinkedList<Imagen> rutaImagenes = new LinkedList<Imagen>();

    public form1()
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
      Start();
    }

    private void label7_Click(object sender, EventArgs e)
    {
      saveFile();
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
      openMistakes();
    }

    private void openFile()
    {
      if (tabControl2.TabCount == 0)
      {
        numPestana++;
        TabPage pestana = new TabPage("Pestaña " + numPestana);
        RichTextBox richtxt = new RichTextBox();
        richtxt.Dock = DockStyle.Fill;

        pestana.Controls.Add(richtxt);
        tabControl2.TabPages.Add(pestana);
      }
      try
      {
        Stream stream;
        OpenFileDialog dialogo = new OpenFileDialog();
        dialogo.Title = "Seleccione archivo";
        dialogo.Filter = "(*.er)|*.er";
        if (dialogo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        {
          if ((stream = dialogo.OpenFile()) != null)
          {
            string texto = File.ReadAllText(dialogo.FileName);
            GetRichTextBox().Text = texto;
            tabControl2.TabPages[tabControl2.TabCount - 1].Text = dialogo.FileName.Substring(dialogo.FileName.LastIndexOf("\\") + 1);
            stream.Close();
          }
          else
          {
            MessageBox.Show("El archivo no es compatible", "Error de archivo");
          }
        }
      }
      catch (FileNotFoundException)
      {
        throw;
      }
      catch (IOException ex)
      {
        if (ex.Source != null)
          Console.WriteLine("IOException source: {0}", ex.Source);
        throw;
      }
    }

    private void saveFile()
    {
      try
      {
        if (tabControl2.TabCount == 0)
        {
          MessageBox.Show("No hay ningun archivo para guardar", "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        else
        {
          SaveFileDialog guardar = new SaveFileDialog();
          guardar.Title = "Guardar archivo como";
          guardar.Filter = "(*.er)|*.er";
          if (guardar.ShowDialog() == DialogResult.OK)
          {
            using (Stream s = File.Open(guardar.FileName, FileMode.CreateNew))
            using (StreamWriter sw = new StreamWriter(s))
            {
              sw.Write(GetRichTextBox().Text);
              tabControl2.TabPages[tabControl2.SelectedIndex].Text = guardar.FileName.Substring(guardar.FileName.LastIndexOf("\\") + 1);
              sw.Flush();
              sw.Close();
            }
          }
        }
      }
      catch (IOException)
      {
        throw;
      }
    }

    private void newTab()
    {
      numPestana++;

      TabPage pestana = new TabPage("Pestaña " + numPestana);
      RichTextBox richtxt = new RichTextBox();
      richtxt.Dock = DockStyle.Fill;

      pestana.Controls.Add(richtxt);
      tabControl2.TabPages.Add(pestana);
    }

    private RichTextBox GetRichTextBox()
    {
      RichTextBox rtb = null;
      TabPage tp = tabControl2.SelectedTab;

      if (tp != null)
      {
        rtb = tp.Controls[0] as RichTextBox;
      }

      return rtb;
    }

    private LinkedList<Token> listaTokens;
    private AnalizadorLexico analizador;
    private AnalizadorSintactico sintactico;

    internal static LinkedList<Imagen> RutaImagenes { get => rutaImagenes; set => rutaImagenes = value; }

    private void Start()
    {
      cbxAFN.Items.Clear();
      if (tabControl2.TabPages.Count == 0)
      {
        MessageBox.Show("No hay ninguna pestaña para analizar", "Analisis no realizado");
      }
      else
      {
        foreach (Control item in this.tabControl2.SelectedTab.Controls)
        {
          Boolean pestanaAnalizar = typeof(RichTextBox).IsInstanceOfType(item);
          if (pestanaAnalizar == true)
          {
            String entrada = GetRichTextBox().Text;
            analizador = new AnalizadorLexico();
            sintactico = new AnalizadorSintactico();
            listaTokens = analizador.Escanner(entrada);
            analizador.agregarUltimo();
            if (analizador.getErrores().Count == 0)
            {
              MessageBox.Show("Analisis Finalizado\nNo se han encontrado errores", "Analisis Completado");
              sintactico.parser(listaTokens);
              rellenarComboBox();

              //listaTokens = sintactico.changeTokens();
            }
            else
            {
              MessageBox.Show("\tAnalisis Finalizado\nSe han encontrado errores léxicos", "Analisis Completado");
            }
          }
        }
      }
    }

    private void rellenarComboBox()
    {
      cbxAFN.Items.Clear();
      foreach (Imagen item in RutaImagenes)
      {
        cbxAFN.Items.Add(item.name);
      }
    }

    private void verifyLexemas()
    {
    }

    private void openTokens()
    {
      analizador.generarListaTokens();
      String comandoDot = ruta + "\\tokens.xml";
      var comando = string.Format(comandoDot);
      var procStart = new System.Diagnostics.ProcessStartInfo("cmd", "/C" + comando);
      var proc = new System.Diagnostics.Process();
      proc.StartInfo = procStart;
      proc.Start();
      proc.WaitForExit();
    }

    private void openMistakes()
    {
      analizador.generarListaTokens();
      String comandoDot = ruta + "\\errores.xml";
      var comando = string.Format(comandoDot);
      var procStart = new System.Diagnostics.ProcessStartInfo("cmd", "/C" + comando);
      var proc = new System.Diagnostics.Process();
      proc.StartInfo = procStart;
      proc.Start();
      proc.WaitForExit();
    }

    private void Restart()
    {
      numPestana = 0;
      listaTokens.Clear();
      tabControl2.TabPages.Clear();
      imagen.Image = null;
      cbxAFN.Items.Clear();
      rutaImagenes.Clear();
    }

    private void lblOpenFile_Click(object sender, EventArgs e)
    {
      openFile();
    }

    private void lblTab_Click(object sender, EventArgs e)
    {
      newTab();
    }

    private void lblStart_Click(object sender, EventArgs e)
    {
      Start();
    }

    private void lblVerify_Click(object sender, EventArgs e)
    {
      verifyLexemas();
    }

    private void lblTokens_Click(object sender, EventArgs e)
    {
      openTokens();
    }

    private void lblRestart_Click(object sender, EventArgs e)
    {
      Restart();
    }

    private void btnTab_Click(object sender, EventArgs e)
    {
      newTab();
    }

    private void btnOpenFile_Click(object sender, EventArgs e)
    {
      openFile();
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      saveFile();
    }

    private void btnRestart_Click(object sender, EventArgs e)
    {
      Restart();
    }

    private void btnTokens_Click(object sender, EventArgs e)
    {
      openTokens();
    }

    private void btnErrores_Click(object sender, EventArgs e)
    {
      openMistakes();
    }

    private void btnVerify_Click(object sender, EventArgs e)
    {
      verifyLexemas();
    }

    private void cbxAFN_SelectedValueChanged(object sender, EventArgs e)
    {
      int num = 0;
      num = cbxAFN.SelectedIndex + 1;

      if (radioButton1.Checked)
      {
        string nombre = ruta + "\\imagen" + num + ".png";
        imagen.Image = Image.FromFile(nombre);
      }
      else if (radioButton2.Checked)
      {
        string nombre = ruta + "\\estados" + num + ".png";
        imagen.Image = Image.FromFile(nombre);
      }
      else if (radioButton3.Checked)
      {
        string nombre = ruta + "\\transiciones" + num + ".png";
        imagen.Image = Image.FromFile(nombre);
      }
      else if (radioButton4.Checked)
      {
        string nombre = ruta + "\\afd" + num + ".png";
        imagen.Image = Image.FromFile(nombre);
      }
    }

    private void radioButton2_CheckedChanged(object sender, EventArgs e)
    {
      if (cbxAFN.Items.Count > 0)
      {
        if (radioButton2.Checked)
        {
          int num = cbxAFN.SelectedIndex + 1;
          string nombre = ruta + "\\estados" + num + ".png";
          imagen.Image = Image.FromFile(nombre);
        }
      }
    }

    private void cbxAFN_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    private void radioButton1_CheckedChanged(object sender, EventArgs e)
    {
      if (cbxAFN.Items.Count > 0)
      {
        if (radioButton1.Checked)
        {
          int num = cbxAFN.SelectedIndex + 1;
          string nombre = ruta + "\\imagen" + num + ".png";
          imagen.Image = Image.FromFile(nombre);
        }
      }
    }

    private void radioButton4_CheckedChanged(object sender, EventArgs e)
    {
      if (cbxAFN.Items.Count > 0)
      {
        if (radioButton4.Checked)
        {
          int num = cbxAFN.SelectedIndex + 1;
          string nombre = ruta + "\\afd" + num + ".png";
          imagen.Image = Image.FromFile(nombre);
        }
      }
    }

    private void radioButton3_CheckedChanged(object sender, EventArgs e)
    {
      if (cbxAFN.Items.Count > 0)
      {
        if (radioButton3.Checked)
        {
          int num = cbxAFN.SelectedIndex + 1;
          string nombre = ruta + "\\transiciones" + num + ".png";
          imagen.Image = Image.FromFile(nombre);
        }
      }
    }
  }
}
