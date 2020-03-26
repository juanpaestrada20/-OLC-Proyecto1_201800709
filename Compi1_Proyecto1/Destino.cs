using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compi1_Proyecto1
{
  internal class Destino
  {
    private string letra;
    private int destino;

    public Destino(string letra, int destino)
    {
      this.letra = letra;
      this.destino = destino;
    }

    public string getLetra()
    {
      return letra;
    }

    public int getDestino()
    {
      return destino;
    }
  }
}
