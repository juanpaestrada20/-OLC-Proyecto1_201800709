using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compi1_Proyecto1
{
  internal class Arbol
  {
    private Nodo raiz;
    private int index;
    private LinkedList<Token> tokens;
    private Token actual;
    private LinkedList<Nodo> expresion;
    private Stack<Nodo> nodos;
    private String ruta;
    private int numeroGrafica = 0;
    public static int contador = 0;

    public Arbol()
    {
      raiz = null;
      contador = 0;
      ruta = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
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
      nodos = new Stack<Nodo>();
      index = 0;
      tokens = tok;
      tokens.AddLast(new Token(Token.Tipo.ULTIMO, "#", 0, 0));
      actual = tokens.ElementAt(index);
      while (actual.getTipoToken() != Token.Tipo.ULTIMO)
      {
        Nodo temp = crearNodo(actual);
        if (temp != null)
        {
          nodos.Push(temp);
        }
        index++;
        actual = tokens.ElementAt(index);
      }
      //recorrerNodo();
      metodoThompson();
      graficar();
    }

    private Nodo crearNodo(Token dato)
    {
      contador++;
      Nodo n;
      switch (dato.getTipoToken())
      {
        case Token.Tipo.CONCATENACION:
          Nodo l = new Nodo(contador, dato.getValor(), "operador");
          return l;

        case Token.Tipo.DISYUNCION:
          n = new Nodo(contador, dato.getValor(), "operador");
          return n;

        case Token.Tipo.CERRADURA_KLEENE:
          n = new Nodo(contador, dato.getValor(), "unario");
          return n;

        case Token.Tipo.CERRADURA_POSITIVA:
          n = new Nodo(contador, dato.getValor(), "unario");
          return n;

        case Token.Tipo.SIGNO_INTERROGACION:
          n = new Nodo(contador, dato.getValor(), "unario");
          return n;

        case Token.Tipo.ID:
        case Token.Tipo.CONJUNTO:
        case Token.Tipo.CARACTER:
        case Token.Tipo.CADENA:
          n = new Nodo(contador, dato.getValor(), "operando");
          return n;

        default:
          n = null;
          return n;
      }
    }

    public void recorrerNodo()
    {
      while (nodos.Count > 0)
      {
        Console.WriteLine(nodos.Pop().getDato());
      }
    }

    private static Stack<Nodo> pilaAuxilar = new Stack<Nodo>();

    private void metodoThompson()
    {
      if (nodos.Count > 1)
      {
        Nodo aux1 = nodos.Pop();
        Nodo aux2 = nodos.Pop();

        if (aux2.getTipo().CompareTo("unario") == 0)
        {
          if (aux2.getDato().CompareTo("?") == 0)
          {
            contador++;
            aux2 = disyuncion(aux1, new Nodo(contador, "epsilon", "operando"));
            nodos.Push(aux2);
          }
          else if (aux2.getDato().CompareTo("*") == 0)
          {
            aux2 = cerraduraKleene(aux1);
            nodos.Push(aux2);
          }
          else if (aux2.getDato().CompareTo("+") == 0)
          {
            Nodo aux = cerraduraKleene(aux1);
            aux2 = concatenar(aux1, aux);
            nodos.Push(aux2);
          }
        }
        else if ((aux2.getTipo() != "operador") && (aux1.getTipo() != "operador"))
        {
          Nodo aux3 = nodos.Pop();
          if (aux3.getTipo() == "operador")
          {
            if (aux3.getDato().CompareTo(".") == 0)
            {
              aux3 = concatenar(aux2, aux1);
              nodos.Push(aux3);
            }
            else if (aux3.getDato().CompareTo("|") == 0)
            {
              aux3 = disyuncion(aux2, aux1);
              nodos.Push(aux3);
            }
          }
          else if (aux3.getTipo().CompareTo("unario") == 0)
          {
            pilaAuxilar.Push(aux1);
            if (aux3.getDato().CompareTo("?") == 0)
            {
              contador++;
              aux3 = disyuncion(aux2, new Nodo(contador, "epsilon", "operando"));
              nodos.Push(aux3);
            }
            else if (aux3.getDato().CompareTo("*") == 0)
            {
              aux3 = cerraduraKleene(aux2);
              nodos.Push(aux3);
            }
            else if (aux3.getDato().CompareTo("+") == 0)
            {
              aux3 = concatenar(aux2, cerraduraKleene(aux2));
              nodos.Push(aux3);
            }
          }
          else if (aux3.getTipo() == "transicion" || aux3.getTipo() == "transiciones" || aux3.getTipo() == "operando")
          {
            pilaAuxilar.Push(aux3);
            while (nodos.Peek().getTipo() != "operador" && nodos.Peek().getTipo() != "unario")
            {
              pilaAuxilar.Push(nodos.Pop());
            }
            aux3 = nodos.Pop();
            if (aux3.getDato().CompareTo("?") == 0)
            {
              contador++;
              aux3 = disyuncion(aux1, new Nodo(contador, "epsilon", "transicion"));
              nodos.Push(aux3);
            }
            else if (aux3.getDato().CompareTo("*") == 0)
            {
              aux3 = cerraduraKleene(aux1);
              nodos.Push(aux3);
            }
            else if (aux3.getDato().CompareTo("+") == 0)
            {
              aux3 = concatenar(aux1, cerraduraKleene(aux1));
              nodos.Push(aux3);
            }
          }
          while (pilaAuxilar.Count > 0)
          {
            nodos.Push(pilaAuxilar.Pop());
          }
        }
        metodoThompson();
      }
      else
      {
        raiz = nodos.Pop();
      }
    }

    private Nodo cerraduraKleene(Nodo n)
    {
      Nodo nuevoN = n;
      contador++;
      Nodo n1 = new Nodo(contador, "epsilon", "transiciones");
      n1.setIzquierda(nuevoN);
      if (nuevoN.getTipo() == "transiciones" || nuevoN.getTipo() == "transicion")
      {
        while (nuevoN.getTipo() != "asignable")
        {
          if (nuevoN.getTipo() == "transiciones")
          {
            nuevoN = nuevoN.getDerecha();
          }
          else
          {
            nuevoN = nuevoN.getIzquierda();
          }
        }
      }
      else if (nuevoN.getTipo() == "operando")
      {
        contador++;
        nuevoN.Index = contador;
      }

      contador++;
      Nodo n2 = new Nodo(contador, "epsilon", "transiciones");
      contador++;
      Nodo n3 = new Nodo(contador, "", "asignable");

      if (nuevoN.getTipo() == "operando")
      {
        nuevoN.setTipo("transicion");
        nuevoN.setIzquierda(n2);
        n2.setIzquierda(nuevoN);
        n2.setDerecha(n3);
      }
      else if (nuevoN.getTipo() == "asignable")
      {
        nuevoN.changeNodo(n2);
        nuevoN.setIzquierda(n);
        nuevoN.setDerecha(n3);
      }

      n1.setDerecha(n3);

      return n1;
    }

    private Nodo concatenar(Nodo n, Nodo n1)
    {
      Nodo aux1 = n;
      Nodo aux2 = n1;
      while (aux1.getTipo() != "asignable" && aux1.getTipo() != "operando")
      {
        if (aux1.getTipo() == "transiciones")
        {
          aux1 = aux1.getDerecha();
        }
        else
        {
          aux1 = aux1.getIzquierda();
        }
      }
      if (aux1.getTipo() == "operando")
      {
        aux1.setTipo("transicion");
        aux1.setIzquierda(aux2);
      }
      else if (aux1.getTipo() == "asignable")
      {
        aux1.changeNodo(aux2);
      }
      contador++;
      Nodo n2 = new Nodo(contador, "", "asignable");
      while (aux1.getTipo() != "asignable" && aux1.getTipo() != "operando")
      {
        if (aux1.getTipo() == "transiciones")
        {
          aux1 = aux1.getDerecha();
        }
        else
        {
          aux1 = aux1.getIzquierda();
        }
      }
      if (aux1.getTipo() == "operando")
      {
        aux1.setTipo("transicion");
        aux1.setIzquierda(n2);
      }
      return n;
    }

    private Nodo disyuncion(Nodo n, Nodo n1)
    {
      contador++;
      Nodo inicio = new Nodo(contador, "epsilon", "transiciones");
      Nodo aux1 = n;
      Nodo aux2 = n1;

      inicio.setIzquierda(aux1);
      inicio.setDerecha(aux2);

      contador++;
      Nodo fin = new Nodo(contador, "", "asignable");
      contador++;
      Nodo aux3 = new Nodo(contador, "epsilon", "transicion");
      contador++;
      Nodo aux4 = new Nodo(contador, "epsilon", "transicion");

      while (aux1.getTipo() != "asignable" && aux1.getTipo() != "operando")
      {
        if (aux1.getTipo() == "transiciones")
        {
          aux1 = aux1.getDerecha();
        }
        else
        {
          aux1 = aux1.getIzquierda();
        }
      }
      if (aux1.getTipo() == "operando")
      {
        aux1.setTipo("transicion");
        aux1.setIzquierda(aux3);
        aux3.setIzquierda(fin);
      }
      else if (aux1.getTipo() == "asignable")
      {
        aux1.changeNodo(aux3);
        aux1.setIzquierda(fin);
      }
      //
      while (aux2.getTipo() != "asignable" && aux2.getTipo() != "operando")
      {
        if (aux2.getTipo() == "transiciones")
        {
          aux2 = aux2.getDerecha();
        }
        else
        {
          aux2 = aux2.getIzquierda();
        }
      }
      if (aux2.getTipo() == "operando")
      {
        aux2.setTipo("transicion");
        aux2.setIzquierda(aux4);
        aux4.setIzquierda(fin);
      }
      else if (aux2.getTipo() == "asignable")
      {
        aux2.changeNodo(aux4);
        aux2.setIzquierda(fin);
      }

      return inicio;
    }

    private Nodo[] verificados = new Nodo[2];

    private Nodo[] verifyNodes(Nodo n1, Nodo n2)
    {
      Nodo aux1 = n1;
      Nodo aux2 = n2;

      while (aux1.getTipo() != "asignable")
      {
        aux2 = n2;
        while (aux2.getTipo() != "asignable")
        {
          if (aux1.Index == aux2.Index)
          {
            contador++;
            aux2.Index = contador;
          }
          if (aux2.getTipo() == "transiciones")
          {
            aux2 = aux2.getDerecha();
          }
          else if (aux2.getTipo() == "transicion")
          {
            aux2 = aux2.getIzquierda();
          }
        }
        if (aux1.getTipo() == "transiciones")
        {
          aux1 = aux1.getDerecha();
        }
        else if (aux1.getTipo() == "transicion")
        {
          aux1 = aux1.getIzquierda();
        }
      }
      verificados[0] = aux1;
      verificados[1] = aux2;
      return verificados;
    }

    private StringBuilder grafo;
    public Nodo auxiliaryNode;

    private void graficar()
    {
      numeroGrafica++;
      grafo = new StringBuilder();
      String rdot = ruta + "\\imagen" + numeroGrafica + ".dot";
      String rpng = ruta + "\\imagen" + numeroGrafica + ".png";
      grafo.Append("digraph G {\nrankdir=LR;\nnode [margin=0 shape=oval style=filled ];\n");
      auxiliaryNode = raiz;
      enviarNodo(auxiliaryNode);
      grafo.Append("}");
      generarDot(rdot, rpng);
    }

    private String value;

    private void enviarNodo(Nodo aux)
    {
      value = "";
      if (aux != null)
      {
        if (!aux.isVisitado())
        {
          if (aux.getTipo().CompareTo("transicion") == 0)
          {
            value = aux.Index + " -> " + aux.getIzquierda().Index + "[label=\"" + aux.getDato() + "\"];\n";
            grafo.Append(value);
            aux.visitar();
            enviarNodo(aux.getIzquierda());
          }
          else if (aux.getTipo().CompareTo("transiciones") == 0)
          {
            value = aux.Index + " -> " + aux.getIzquierda().Index + "[label=\"" + aux.getDato() + "\"];\n";
            grafo.Append(value);
            value = aux.Index + " -> " + aux.getDerecha().Index + "[label=\"" + aux.getDato() + "\"];\n";
            grafo.Append(value);
            aux.visitar();
            enviarNodo(aux.getIzquierda());
            enviarNodo(aux.getDerecha());
          }
          else if (aux.getTipo().CompareTo("asignable") == 0)
          {
            aux.visitar();
          }
        }
      }
    }

    private void generarDot(String rdot, String rpng)
    {
      System.IO.File.WriteAllText(rdot, grafo.ToString());
      String comandoDot = "dot.exe -Tpng " + rdot + " -o " + rpng;
      var comando = string.Format(comandoDot);
      var procStart = new System.Diagnostics.ProcessStartInfo("cmd", "/C" + comando);
      var proc = new System.Diagnostics.Process
      {
        StartInfo = procStart
      };
      proc.Start();
      proc.WaitForExit();
    }
  }
}
