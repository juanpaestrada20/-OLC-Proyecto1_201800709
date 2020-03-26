using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compi1_Proyecto1
{
  internal class Mover
  {
    private ArrayList estados;

    public Mover()
    {
      estados = new ArrayList();
    }

    public ArrayList getEstados()
    {
      return estados;
    }

    public void addEstado(int estado)
    {
      estados.Add(estado);
    }

    public void ordenar()
    {
      estados.Sort();
    }
  }
}
