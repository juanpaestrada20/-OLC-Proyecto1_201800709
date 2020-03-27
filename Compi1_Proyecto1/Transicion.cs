using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compi1_Proyecto1
{
  internal class Transicion
  {
    private int estado;
    private LinkedList<Destino> transiciones;
    private bool estadoFinal;

    public Transicion(int estado)
    {
      this.estado = estado;
      transiciones = new LinkedList<Destino>();
      estadoFinal = false;
    }

    public int getEstado()
    {
      return estado;
    }

    public LinkedList<Destino> getTransiciones()
    {
      return transiciones;
    }

    public void addTransicion(Destino estado)
    {
      bool repeat = false;
      for (int i = 0; i < transiciones.Count; i++)
      {
        if (transiciones.ElementAt(i).getDestino() == estado.getDestino() && transiciones.ElementAt(i).getLetra() == estado.getLetra())
        {
          repeat = true;
          break;
        }
      }
      if (!repeat)
        transiciones.AddLast(estado);
    }

    public void isEstadoFinal()
    {
      estadoFinal = true;
    }

    public bool esFinal()
    {
      return estadoFinal;
    }
  }
}
