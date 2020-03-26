using System;

namespace Compi1_Proyecto1
{
  internal class Nodo
  {
    private String dato;
    private Nodo izquierda;
    private Nodo derecha;
    private String tipo;
    private bool visitado;
    public int Index;
    public bool clonado;
    public bool visitaThompson;

    public Nodo(int Index, String dato, String tipo)
    {
      this.dato = dato;
      izquierda = null;
      derecha = null;
      this.tipo = tipo;
      visitado = false;
      this.Index = Index;
      clonado = false;
      visitaThompson = false;
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
      visitado = true;
    }

    public bool isVisitado()
    {
      return visitado;
    }

    public void desVisitar()
    {
      visitado = false;
    }

    public void clonar()
    {
      clonado = true;
    }

    public void changeNodo(Nodo n)
    {
      this.dato = n.getDato();
      izquierda = n.getIzquierda();
      derecha = n.getDerecha();
      this.tipo = n.getTipo();
      visitado = n.isVisitado();
      this.Index = n.Index;
    }
  }
}
