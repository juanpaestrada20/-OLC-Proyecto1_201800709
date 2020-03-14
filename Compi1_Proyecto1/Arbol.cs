using System;
using System.Collections.Generic;
using System.Linq;

namespace Compi1_Proyecto1
{
  class Arbol
  {
    private Nodo raiz;
    private int index;
    private int i;
    private LinkedList<Token> tokens;
    private Token actual;
    private LinkedList<Nodo> nodos;
    private Stack<Nodo> expresion;
    public Arbol()
    {
      raiz = null;
    }

    public void setRaiz(Nodo raiz)
    {
      this.raiz = raiz;
    }

    public Nodo getRaiz()
    {
      return raiz;
    }

    public void generarArbol(LinkedList<Token> tok)
    {
      nodos = new LinkedList<Nodo>();
      index = 0;
      i = 0;
      tokens = tok;
      tokens.AddLast(new Token(Token.Tipo.ULTIMO, "#", 0, 0));
      actual = tokens.ElementAt(index);
      while (actual.getTipoToken() != Token.Tipo.ULTIMO)
      {
        Nodo temp = crearNodo(actual);
        if (temp != null)
        {
          nodos.AddLast(temp);
        }
        index++;
        actual = tokens.ElementAt(index);
      }
      metodoThompson();
    }

    private void insertarNodo(Nodo actual)
    {
      //raiz = agregarNodo(raiz, actual);
    }

    private Nodo agregarNodo(Nodo n, Nodo actual)
    {
      if(n == null)
      {
        n = actual;
      }
      else
      {
        if(n.getIzquierda().getTipo().CompareTo("operador") == 0)
        {
          n.setIzquierda(agregarNodo(n.getIzquierda(), actual));
        }
        else
        {
          n.setDerecha(agregarNodo(n.getDerecha(), actual));
        }
      }
      return n;
    }
    private Nodo crearNodo(Token dato)
    {
      Nodo n;
      switch (dato.getTipoToken())
      {
        case Token.Tipo.CONCATENACION:
          Nodo l = new Nodo(dato.getValor(), "operador");
          return l;
        case Token.Tipo.DISYUNCION:
          n = new Nodo(dato.getValor(), "operador");
          return n;
        case Token.Tipo.CERRADURA_KLEENE:
          n = new Nodo(dato.getValor(), "unario");
          return n;
        case Token.Tipo.CERRADURA_POSITIVA:
          n = new Nodo(dato.getValor(), "unario");
          return n;
        case Token.Tipo.SIGNO_INTERROGACION:
          n = new Nodo(dato.getValor(), "unario");
          return n;
        case Token.Tipo.ID:
        case Token.Tipo.CONJUNTO:
        case Token.Tipo.CARACTER:
        case Token.Tipo.CADENA:
          n = new Nodo(dato.getValor(), "operando");
          return n;
        default:
          n = null;
          return n;

      }
    }

    public void recorrerNodo()
    {
      foreach(Nodo item in nodos)
      {
        Console.WriteLine(item.getDato());
      }
    }

    private void metodoThompson(Nodo actual)
    {

      raiz = thompson(raiz, actual);
      //Nodo actual;
      //Nodo n1;
      //Nodo n2;
      //while(i < nodos.Count)
      //{
      //  actual = nodos.ElementAt(i);
      //  if(actual.getTipo() == "operador")
      //  {
      //    if(actual.getDato() == ".")
      //    {
      //      i++;
      //      n1 = nodos.ElementAt(i);
      //      i++;
      //      n2 = nodos.ElementAt(i);
      //      concatenar(n1, n2);
      //    }
      //  }
      //  i++;
      //}
    }
    private Nodo thompson(Nodo n, Nodo actual)
    {
      if(n == null)
      {
        n = actual;
      }
      else
      {
        if((n.getTipo() == "operador") &&(n.getDerecha() == null) && n.getIzquierda() == null)
        {
          
        }
      }
      return n;
    }
    private Nodo cerraduraKleene(Nodo n)
    {
      Nodo n1 = new Nodo("epsilon", "transiciones");
      Nodo n2 = new Nodo("", "transiciones");
      Nodo n3 = new Nodo("epsilon", "transiciones");
      n1.setIzquierda(n);
      n1.setDerecha(n3);
      n.setIzquierda(n2);
      n2.setIzquierda(n);
      n2.setDerecha(n3);
      return n1;
    }

    private Nodo concatenar(Nodo n, Nodo n1)
    {
      n.setIzquierda(n1);
      Nodo n2 = new Nodo("", "transiciones");
      n1.setIzquierda(n2);
      n.setTipo("transicion");
      n1.setTipo("transicion");
      return n;
    }

    private Nodo disyuncion(Nodo n, Nodo n1)
    {
      Nodo inicio = new Nodo("epsilon", "transiciones");
      inicio.setIzquierda(n);
      inicio.setDerecha(n1);
      Nodo fin = new Nodo("", "transiciones");
      Nodo aux1 = new Nodo("epsilon", "transicion");
      Nodo aux2 = new Nodo("epsilon", "transicion");
      aux1.setIzquierda(fin);
      aux2.setIzquierda(fin);

      return inicio;
    }
  }
}
