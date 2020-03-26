using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compi1_Proyecto1
{
  internal class Cerradura
  {
    private ArrayList estados;
    private int numEstado;
    private bool final;
    private bool marcado;

    public Cerradura(int numEstado)
    {
      this.numEstado = numEstado;
      estados = new ArrayList();
      final = false;
      marcado = false;
    }

    public int getNumEstado()
    {
      return numEstado;
    }

    public ArrayList getEstados()
    {
      return estados;
    }

    public void setEstados(ArrayList nueva)
    {
      estados = nueva;
    }

    public void agregarEstados(Nodo estado)
    {
      estados.Add(estado);
    }

    public void ordenarEstados()
    {
      Nodo[] nodos = new Nodo[estados.Count];
      int i = 0;
      int j;
      Nodo temp;
      foreach (Nodo item in estados)
      {
        nodos[i] = item;
        i++;
      }
      estados.Clear();
      for (i = 0; i < nodos.Length - 1; i++)
      {
        for (j = 0; j < nodos.Length - i - 1; j++)
        {
          if (nodos[j].Index > nodos[j + 1].Index)
          {
            temp = nodos[j];
            nodos[j] = nodos[j + 1];
            nodos[j + 1] = temp;
          }
          else if (nodos[j].Index == nodos[j + 1].Index)
          {
            Console.WriteLine("hay repetidos");
          }
        }
      }

      foreach (Nodo item in nodos)
      {
        estados.Add(item);
      }
    }

    public void setEstadoFinal()
    {
      final = true;
    }

    public bool isEstadoFinal()
    {
      return final;
    }

    public void marcar()
    {
      marcado = true;
    }

    public bool isMarcado()
    {
      return marcado;
    }
  }
}
