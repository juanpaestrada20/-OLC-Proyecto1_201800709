using System;

namespace Compi1_Proyecto1
{
  class Nodo
  {
    private String dato;
    private Nodo izquierda;
    private Nodo derecha;
    private String tipo;
    private bool visitado;

    public Nodo(String dato, String tipo)
    {
      this.dato = dato;
      izquierda = null;
      derecha = null;
      this.tipo = tipo;
      visitado = false;
    }

    public String getDato()
    {
     return dato;
    }

    public Nodo getIzquierda()
    {
      return izquierda;
    }

    public Nodo getDerecha()
    {
      return derecha;
    }

    public String getTipo()
    {
      return tipo;
    }

    public void setIzquierda(Nodo izquierda)
    {
      this.izquierda = izquierda;
    }

    public void setDerecha(Nodo derecha)
    {
      this.derecha = derecha;
    }

    public void setDato(String dato)
    {
      this.dato = dato;
    }

    public void setTipo(String tipo)
    {
      this.tipo = tipo;
    }

    public void visitar()
    {
      this.visitado = true;
    }
  }
}
