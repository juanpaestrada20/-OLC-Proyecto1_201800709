using System;
using System.Collections;
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
    private Stack<Nodo> nodos;
    private String ruta;
    public static int contador = 0;
    private LinkedList<Cerradura> cerraduras;
    private LinkedList<Mover> mueves;
    private int contadorEstados;
    private Nodo lastNode;
    private List<Nodo> NonTerminals;
    private LinkedList<Transicion> transicionesEstados;

    public Arbol()
    {
      raiz = null;
      contador = 0;
      contadorEstados = 0;
      ruta = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
      cerraduras = new LinkedList<Cerradura>();
      mueves = new LinkedList<Mover>();
      NonTerminals = new List<Nodo>();
      transicionesEstados = new LinkedList<Transicion>();
    }

    private int numeroGrafica;

    public void generarArbol(LinkedList<Token> tok, int numeroGrafica)
    {
      this.numeroGrafica = numeroGrafica;
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
      metodoThompson();
      graficar();
      metodoSubConjuntos();
      graficarAFD();
      graphEstados();
      graphTransiciones();
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
          NonTerminals.Add(n);
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
            contador++;
            Nodo nuevo = new Nodo(contador, aux1.getDato(), aux1.getTipo());
            nuevo.setIzquierda(aux1.getIzquierda());
            nuevo.setDerecha(aux1.getDerecha());
            nuevo = changeIndex(nuevo);
            aux2 = concatenar(aux1, cerraduraKleene(nuevo));
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
              Nodo nuevo = new Nodo(contador, aux2.getDato(), aux2.getTipo());
              nuevo.setIzquierda(aux2.getIzquierda());
              nuevo.setDerecha(aux2.getDerecha());
              nuevo = changeIndex(nuevo);
              aux3 = concatenar(aux2, cerraduraKleene(nuevo));
              nodos.Push(aux3);
            }
          }
          else if (aux3.getTipo() == "transicion" || aux3.getTipo() == "transiciones" || aux3.getTipo() == "operando")
          {
            pilaAuxilar.Push(aux1);
            aux1 = aux2;
            aux2 = aux3;
            aux3 = nodos.Pop();
            while (aux3.getTipo() != "operador" && aux3.getTipo() != "unario")
            {
              pilaAuxilar.Push(aux1);
              aux1 = aux2;
              aux2 = aux3;
              aux3 = nodos.Pop();
            }
            if (aux3.getTipo() == "unario")
            {
              pilaAuxilar.Push(aux1);
            }
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
              Nodo nuevo = new Nodo(contador, aux2.getDato(), aux2.getTipo());
              nuevo.setIzquierda(aux2.getIzquierda());
              nuevo.setDerecha(aux2.getDerecha());
              nuevo = changeIndex(nuevo);
              aux3 = concatenar(aux2, cerraduraKleene(nuevo));
              nodos.Push(aux3);
            }
            else if (aux3.getDato().CompareTo(".") == 0)
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
          while (pilaAuxilar.Count > 0)
          {
            nodos.Push(pilaAuxilar.Pop());
          }
        }
        metodoThompson();
      }
      else
      {
        try
        {
          raiz = nodos.Pop();
        }
        catch (InvalidOperationException e)
        {
          Console.WriteLine("error");
        }
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

    private Nodo changeIndex(Nodo n)
    {
      if (n != null)
      {
        if (n.getTipo() == "transicion")
        {
          contador++;
          n = clonar(contador, n);
          n.setIzquierda(changeIndex(n.getIzquierda()));
        }
        else if (n.getTipo() == "transiciones")
        {
          contador++;
          n = clonar(contador, n);
          n.setIzquierda(changeIndex(n.getIzquierda()));
          n.setDerecha(changeIndex(n.getDerecha()));
        }
        else if (n.getTipo() == "asignable")
        {
          //if (!n.clonado)
          //{
          contador++;
          n = clonar(contador + 5, n);
          //}
        }
      }
      return n;
    }

    public Nodo clonar(int index, Nodo n)
    {
      Nodo nuevo = new Nodo(index, n.getDato(), n.getTipo());
      nuevo.setIzquierda(n.getIzquierda());
      nuevo.setDerecha(n.getDerecha());
      nuevo.clonar();
      return nuevo;
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

    private StringBuilder grafo;
    public Nodo auxiliaryNode;

    private void graficar()
    {
      grafo = new StringBuilder();
      String rdot = ruta + "\\imagen" + numeroGrafica + ".dot";
      String rpng = ruta + "\\imagen" + numeroGrafica + ".png";
      form1.RutaImagenes.AddLast(new Imagen("Expresion " + numeroGrafica, rpng));
      grafo.Append("digraph G {\nrankdir=LR;splines=true;\noverlap =false\n\nnode [margin=0 shape=circle color=crimson fontcolor=white style=filled ];\n");
      auxiliaryNode = raiz;
      enviarNodo(auxiliaryNode);
      grafo.Append("}");
      generarDot(rdot, rpng, grafo);
    }

    private void graficarAFD()
    {
      StringBuilder afd = new StringBuilder();
      String rdot = ruta + "\\afd" + numeroGrafica + ".dot";
      String rpng = ruta + "\\afd" + numeroGrafica + ".png";
      afd.Append("digraph G {\nrankdir=LR;\nsplines=true;\noverlap =false\nnode [margin=0 shape=circle fontcolor=white color=darkslategray style=filled ];\n");
      foreach (Transicion item in transicionesEstados)
      {
        afd.Append(item.getEstado());
        if (item.esFinal())
        {
          afd.Append("[shape=doublecircle]");
        }
        else
        {
          afd.Append("[shape=circle]");
        }
        afd.Append(";\n");
      }

      foreach (Transicion item in transicionesEstados)
      {
        foreach (Destino estado in item.getTransiciones())
        {
          afd.Append(item.getEstado() + " -> " + estado.getDestino() + "[label=\"" + estado.getLetra() + "\"];\n");
        }
      }
      afd.Append("}");
      generarDot(rdot, rpng, afd);
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
            lastNode = aux;
          }
        }
      }
    }

    private void generarDot(String rdot, String rpng, StringBuilder grafo)
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

    private void metodoSubConjuntos()
    {
      if (raiz != null)
      {
        Mover primero = new Mover();
        primero.addEstado(raiz.Index);
        cerraduras.AddLast(makeCerradura(primero));
        for (int k = 0; k < cerraduras.Count; k++)
        {
          Transicion transition = new Transicion(cerraduras.ElementAt(k).getNumEstado());
          foreach (Nodo item in NonTerminals)
          {
            Mover temp = makeMove(cerraduras.ElementAt(k).getEstados(), item);
            if (temp != null)
            {
              if (temp.getEstados().Count > 0)
              {
                if (!mueves.Contains(temp))
                {
                  mueves.AddLast(temp);
                }

                Cerradura temporal = makeCerradura(temp);
                if (temporal != null)
                {
                  if (temporal.getEstados().Count > 0)
                  {
                    if (!cerraduras.Contains(temporal))
                    {
                      cerraduras.AddLast(temporal);
                    }
                    if (temporal.isEstadoFinal())
                    {
                      transition.isEstadoFinal();
                    }
                    transition.addTransicion(new Destino(item.getDato(), temporal.getNumEstado()));
                  }
                }
              }
            }
          }
          transicionesEstados.AddLast(transition);
        }
      }
    }

    private ArrayList encontrados;

    private Cerradura makeCerradura(Mover m)
    {
      contadorEstados++;
      encontrados = new ArrayList();
      Nodo aux = raiz;
      Nodo aux2;
      Cerradura nueva = new Cerradura(contadorEstados);
      foreach (int i in m.getEstados())
      {
        aux2 = findNode(aux, i);
        nueva.setEstados(transicionesEpsilon(encontrados, aux2));
        nueva.ordenarEstados();
        if (nueva.getEstados().Contains(lastNode))
        {
          nueva.setEstadoFinal();
        }
        desVisitarTodo(raiz);
      }

      for (int j = 0; j < cerraduras.Count; j++)
      {
        if (cerraduras.ElementAt(j).getEstados().Count == nueva.getEstados().Count)
        {
          bool iguales = true;
          foreach (Nodo n in cerraduras.ElementAt(j).getEstados())
          {
            if (!nueva.getEstados().Contains(n))
            {
              iguales = false;
              break;
            }
          }
          if (iguales)
          {
            contadorEstados--;
            return cerraduras.ElementAt(j);
          }
        }
      }

      return nueva;
    }

    private Nodo findNode(Nodo aux, int index)
    {
      if (aux == null)
      {
        return null;
      }
      else if (aux.Index == index)
      {
        return aux;
      }
      else if (aux.getTipo().CompareTo("transicion") == 0 && !aux.visitaThompson)
      {
        aux.visitaThompson = true;
        return findNode(aux.getIzquierda(), index);
      }
      else if (aux.getTipo().CompareTo("transiciones") == 0 && !aux.visitaThompson)
      {
        Nodo aux2;
        Nodo aux3;
        aux.visitaThompson = true;
        aux2 = findNode(aux.getIzquierda(), index);
        aux3 = findNode(aux.getDerecha(), index);
        if (aux2 != null && aux2.Index == index)
        {
          return aux2;
        }
        else if (aux3 != null && aux3.Index == index)
        {
          return aux3;
        }
        else
        {
          return null;
        }
      }
      else if (aux.getTipo().CompareTo("asignable") == 0)
      {
        aux.visitaThompson = true;
        return null;
      }
      else
      {
        return null;
      }
    }

    private void desVisitarTodo(Nodo aux)
    {
      if (aux != null)
      {
        if (aux.visitaThompson)
        {
          if (aux.getTipo().CompareTo("transicion") == 0)
          {
            aux.visitaThompson = false;
            desVisitarTodo(aux.getIzquierda());
          }
          else if (aux.getTipo().CompareTo("transiciones") == 0)
          {
            aux.visitaThompson = false;
            desVisitarTodo(aux.getIzquierda());
            desVisitarTodo(aux.getDerecha());
          }
          else if (aux.getTipo().CompareTo("asignable") == 0)
          {
            aux.visitaThompson = false;
          }
        }
      }
    }

    private ArrayList transicionesEpsilon(ArrayList actual, Nodo n)
    {
      Nodo aux = n;

      if (aux.getDato() == "epsilon")
      {
        if (!actual.Contains(aux))
        {
          actual.Add(aux);
        }
        if (aux.getIzquierda() != null)
        {
          actual.Add(aux.getIzquierda());
          actual = transicionesEpsilon(actual, aux.getIzquierda());
        }
        if (aux.getDerecha() != null)
        {
          actual.Add(aux.getDerecha());
          actual = transicionesEpsilon(actual, aux.getDerecha());
        }
      }

      return actual;
    }

    private Mover makeMove(ArrayList estado, Nodo n)
    {
      Mover nuevo = new Mover();

      foreach (Nodo item in estado)
      {
        if (item.getDato() == n.getDato())
        {
          nuevo.addEstado(item.getIzquierda().Index);
        }
      }
      for (int i = 0; i < mueves.Count; i++)
      {
        if (mueves.ElementAt(i).getEstados().Count == nuevo.getEstados().Count)
        {
          bool iguales = true;
          foreach (int el in mueves.ElementAt(i).getEstados())
          {
            if (!nuevo.getEstados().Contains(el))
            {
              iguales = false;
              break;
            }
          }
          if (iguales)
          {
            return mueves.ElementAt(i);
          }
        }
      }
      return nuevo;
    }

    private void graphEstados()
    {
      StringBuilder estados = new StringBuilder();
      String rdot = ruta + "\\estados" + numeroGrafica + ".dot";
      String rpng = ruta + "\\estados" + numeroGrafica + ".png";
      estados.Append("digraph html {\nrankdir = UD;\nnode1 [shape=none label=<\n" +
        "<table border='0' cellspacing='0'>" +
        "<tr>\n<td port=\"port1\" border =\"1\" bgcolor =\"lawngreen\"> Estados </td>" +
        "<td port=\"port1\" border =\"1\" bgcolor =\"lawngreen\"> Estado </td>" +
        "<td port=\"port1\" border =\"1\" bgcolor =\"lawngreen\" > Final </td>\n</tr> ");
      foreach (Cerradura item in cerraduras)
      {
        estados.Append("<tr>\n<td port=\"port1\" border =\"1\">");
        foreach (Nodo estado in item.getEstados())
        {
          estados.Append(" " + estado.Index + ",");
        }
        estados.Append("</td>\n");
        estados.Append("<td port=\"port1\" border =\"1\">" + item.getNumEstado() + "</td>\n");
        if (item.isEstadoFinal())
        {
          estados.Append("<td port=\"port1\" border =\"1\"> Si </td>\n");
        }
        else
        {
          estados.Append("<td port=\"port1\" border =\"1\"> No </td>\n");
        }
        estados.Append("</tr>\n");
      }

      estados.Append(" </table>>];\n");

      estados.Append("}");
      generarDot(rdot, rpng, estados);
    }

    private void graphTransiciones()
    {
      StringBuilder estados = new StringBuilder();
      String rdot = ruta + "\\transiciones" + numeroGrafica + ".dot";
      String rpng = ruta + "\\transiciones" + numeroGrafica + ".png";
      estados.Append("digraph html {\nrankdir = UD;\nnode1 [shape=none label=<\n" +
        "<table border='0' cellspacing='0'>" +
        "<tr>\n<td port=\"port1\" border =\"1\" bgcolor =\"lawngreen\"> Estado </td>");
      foreach (Nodo terminal in NonTerminals)
      {
        estados.Append("<td port=\"port1\" border =\"1\" bgcolor =\"lawngreen\" > " + terminal.getDato() + " </td>\n");
      }
      estados.Append("</tr>\n");
      foreach (Transicion tran in transicionesEstados)
      {
        estados.Append("<tr>\n");
        if (tran.esFinal())
        {
          estados.Append("<td port=\"port1\" border =\"1\" bgcolor =\"mediumspringgreen\" > " + tran.getEstado() + " </td>\n ");
        }
        else
        {
          estados.Append("<td port=\"port1\" border =\"1\"> " + tran.getEstado() + " </td>\n");
        }
        bool flag = false;
        string destino = "";
        foreach (Nodo ter in NonTerminals)
        {
          foreach (Destino des in tran.getTransiciones())
          {
            if (des.getLetra() == ter.getDato())
            {
              flag = true;
              destino = des.getDestino().ToString();
              break;
            }
          }
          if (flag)
          {
            estados.Append("<td port=\"port1\" border =\"1\"> " + destino + " </td>\n");
          }
          else
          {
            estados.Append("<td port=\"port1\" border =\"1\"></td>\n");
          }
        }
        estados.Append("</tr>\n");
      }

      estados.Append(" </table>>];\n");

      estados.Append("}");
      generarDot(rdot, rpng, estados);
    }
  }
}
