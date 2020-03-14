using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compi1_Proyecto1
{
  class NodoLista
  {
    Nodo nodo;
    NodoLista siguiente;

    NodoLista(Nodo nodo)
    {
      this.nodo = nodo;
      siguiente = null;
    }

  }
}
