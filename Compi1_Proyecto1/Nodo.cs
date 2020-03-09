using System;

namespace Compi1_Proyecto1
{
  class Nodo
  {
    private Object dato;
    private Nodo izquierda;
    private Nodo derecha;

    public Nodo(Object dato)
    {
      this.dato = dato;
      this.izquierda = null;
      this.derecha = null;
    }

    public Object getDato()
    {
      return this.dato;
    }

    public Nodo getIzquierda()
    {
      return this.izquierda;
    }

    public Nodo getDerecha()
    {
      return this.derecha;
    }

    public void setIzquierda(Nodo izquierda)
    {
      this.izquierda = izquierda;
    }

    public void setDerecha(Nodo derecha)
    {
      this.derecha = derecha;
    }

    public void setDato(Object dato)
    {
      this.dato = dato;
    }
  }
}
