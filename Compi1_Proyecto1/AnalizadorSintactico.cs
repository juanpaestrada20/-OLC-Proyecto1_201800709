using System;
using System.Collections.Generic;
using System.Linq;

namespace Compi1_Proyecto1
{
  internal class AnalizadorSintactico
  {
    private LinkedList<Token> salidaSintactico;
    private LinkedList<Token> listaAnalizada;
    private Token actual;
    private int controlToken;
    private String conjunto;

    public void parser(LinkedList<Token> tokens)
    {
      numeroGrafica = 0;
      listaAnalizada = new LinkedList<Token>();
      conjunto = "";
      this.salidaSintactico = tokens;
      controlToken = 0;
      actual = salidaSintactico.ElementAt(controlToken);
      Inicio();
    }

    public static int numeroGrafica;

    private void Inicio()
    {
      match(Token.Tipo.LLAVE_ABRE);
      Cuerpo();
      match(Token.Tipo.LLAVE_CIERRA);
    }

    private void Cuerpo()
    {
      if (actual.getTipoToken() == Token.Tipo.INICIO_COMENTARIO)
      {
        match(Token.Tipo.INICIO_COMENTARIO);
        match(Token.Tipo.COMENTARIO);
        Cuerpo();
      }
      else if (actual.getTipoToken() == Token.Tipo.INICIO_MULTILINEA)
      {
        match(Token.Tipo.INICIO_MULTILINEA);
        match(Token.Tipo.COMENTARIO_MULTILINEA);
        match(Token.Tipo.FIN_MULTILINEA);
        Cuerpo();
      }
      else if (actual.getTipoToken() == Token.Tipo.PALABRA_RESERVADA)
      {
        match(Token.Tipo.PALABRA_RESERVADA);
        match(Token.Tipo.DOS_PUNTOS);
        match(Token.Tipo.ID);
        match(Token.Tipo.ASIGNACION);
        verificarConjunto();
        match(Token.Tipo.PUNTO_COMA);
        Cuerpo();
      }
      else if (actual.getTipoToken() == Token.Tipo.ID)
      {
        match(Token.Tipo.ID);
        match(Token.Tipo.ASIGNACION);
        ExpresionRegular();
        match(Token.Tipo.PUNTO_COMA);
        Cuerpo();
      }
      else if (actual.getTipoToken() == Token.Tipo.PORCENTAJE)
      {
        match(Token.Tipo.PORCENTAJE);
        match(Token.Tipo.PORCENTAJE);
        match(Token.Tipo.PORCENTAJE);
        match(Token.Tipo.PORCENTAJE);
        EvaluarExpresion(); //
      }
    }

    private void EvaluarExpresion()
    {
      if (actual.getTipoToken() == Token.Tipo.INICIO_COMENTARIO)
      {
        match(Token.Tipo.INICIO_COMENTARIO);
        match(Token.Tipo.COMENTARIO);
        EvaluarExpresion();
      }
      else if (actual.getTipoToken() == Token.Tipo.INICIO_MULTILINEA)
      {
        match(Token.Tipo.INICIO_MULTILINEA);
        match(Token.Tipo.COMENTARIO_MULTILINEA);
        match(Token.Tipo.FIN_MULTILINEA);
        EvaluarExpresion();
      }
      else if (actual.getTipoToken() == Token.Tipo.ID)
      {
        match(Token.Tipo.ID);
        match(Token.Tipo.DOS_PUNTOS);
        match(Token.Tipo.COMILLA_DOBLE);
        match(Token.Tipo.CADENA);
        match(Token.Tipo.COMILLA_DOBLE);
        match(Token.Tipo.PUNTO_COMA);
        EvaluarExpresion();
      }
    }

    private void ExpresionRegular()
    {
      LinkedList<Token> expresionRegular = new LinkedList<Token>();
      while (actual.getTipoToken() != Token.Tipo.PUNTO_COMA)
      {
        if (actual.getTipoToken() == Token.Tipo.LLAVE_ABRE)
        {
          match(Token.Tipo.LLAVE_ABRE);
        }
        else if (actual.getTipoToken() == Token.Tipo.LLAVE_CIERRA)
        {
          match(Token.Tipo.LLAVE_CIERRA);
        }
        else
        {
          expresionRegular.AddLast(actual);
          match(actual.getTipoToken());
        }
      }
      Console.WriteLine("--------------------");
      foreach (Token item in expresionRegular)
      {
        Console.WriteLine(item.getTipo());
      }
      generarArbol(expresionRegular);
      expresionRegular.Clear();
    }

    private void generarArbol(LinkedList<Token> expresion)
    {
      Arbol arbol = new Arbol();
      numeroGrafica++;
      arbol.generarArbol(expresion, numeroGrafica);
    }

    private void verificarConjunto()
    {
      if (actual.getTipoToken() == Token.Tipo.CONJUNTO)
      {
        match(Token.Tipo.CONJUNTO);
      }
      else if (actual.getTipoToken() == Token.Tipo.ID)
      {
        actual.changeTipo(Token.Tipo.CONJUNTO);
        match(Token.Tipo.CONJUNTO);
      }
      else if (actual.getTipoToken() == Token.Tipo.NUMERO)
      {
        actual.changeTipo(Token.Tipo.CARACTER);
        conjunto += actual.getValor();
        salidaSintactico.Remove(salidaSintactico.ElementAt(controlToken));
        actual = salidaSintactico.ElementAt(controlToken);
        otroCaracter();
      }
      else
      {
        conjunto += actual.getValor();
        salidaSintactico.Remove(salidaSintactico.ElementAt(controlToken));
        actual = salidaSintactico.ElementAt(controlToken);
        otroCaracter();
      }
    }

    private void match(Token.Tipo tipo)
    {
      if (actual.getTipoToken() != tipo)
      {
        Console.WriteLine("No se esperaba este caracter\"" + actual.getTipo() + "\", se esperaba" + tipo.ToString());
      }
      else if (actual.getTipoToken() != Token.Tipo.ULTIMO)
      {
        listaAnalizada.AddLast(actual);
        controlToken++;
        actual = salidaSintactico.ElementAt(controlToken);
      }
    }

    private void otroCaracter()
    {
      if (actual.getTipoToken() == Token.Tipo.COMA)
      {
        match(Token.Tipo.COMA);
        if (actual.getTipoToken() != Token.Tipo.CARACTER)
        {
          actual.changeTipo(Token.Tipo.CARACTER);
        }
        match(Token.Tipo.CARACTER);
        controlToken -= 2;
        conjunto += salidaSintactico.ElementAt(controlToken).getValor();
        salidaSintactico.Remove(salidaSintactico.ElementAt(controlToken));
        conjunto += salidaSintactico.ElementAt(controlToken).getValor();
        salidaSintactico.Remove(salidaSintactico.ElementAt(controlToken));
        actual = salidaSintactico.ElementAt(controlToken);
        listaAnalizada.RemoveLast();
        listaAnalizada.RemoveLast();
        otroCaracter();
      }
      else if (actual.getTipoToken() == Token.Tipo.VIRGULILLA)
      {
        match(Token.Tipo.VIRGULILLA);
        if (actual.getTipoToken() != Token.Tipo.CARACTER)
        {
          actual.changeTipo(Token.Tipo.CARACTER);
        }
        match(Token.Tipo.CARACTER);
        controlToken -= 2;
        conjunto += salidaSintactico.ElementAt(controlToken).getValor();
        salidaSintactico.Remove(salidaSintactico.ElementAt(controlToken));
        conjunto += salidaSintactico.ElementAt(controlToken).getValor();
        salidaSintactico.Remove(salidaSintactico.ElementAt(controlToken));
        actual = salidaSintactico.ElementAt(controlToken);
        listaAnalizada.RemoveLast();
        listaAnalizada.RemoveLast();
        otroCaracter();
      }
      else
      {
        aceptarConjunto();
      }
    }

    private void aceptarConjunto()
    {
      listaAnalizada.AddLast(new Token(Token.Tipo.CONJUNTO, conjunto, actual.getFila(), actual.getColumna()));
      conjunto = "";
    }

    public LinkedList<Token> changeTokens()
    {
      return salidaSintactico;
    }
  }
}
