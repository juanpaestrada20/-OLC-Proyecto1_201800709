using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compi1_Proyecto1
{
  class AnalizadorSintactico
  {
    LinkedList<Token> salidaSintactico;
    private LinkedList<Token> listaAnalizada;
    LinkedList<Error> salidaErrores;
    private Token actual;
    private int controlToken;
    private String conjunto;


    public void parser (LinkedList<Token> tokens)
    {
      listaAnalizada = new LinkedList<Token>();
      conjunto = "";
      this.salidaSintactico = tokens;
      controlToken = 0;
      actual = salidaSintactico.ElementAt(controlToken);
      Inicio();
    }

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
        ExpresionRegular();//falta
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
      match(Token.Tipo.ID);
      match(Token.Tipo.DOS_PUNTOS);
      match(Token.Tipo.COMILLA_DOBLE);
      match(Token.Tipo.CADENA);
      match(Token.Tipo.COMILLA_DOBLE);
      match(Token.Tipo.PUNTO_COMA);
      EvaluarExpresion();
    }

    private void ExpresionRegular()
    {

    }

    private void verificarConjunto()
    {
      if (actual.getTipoToken() == Token.Tipo.CONJUNTO)
      {
        match(Token.Tipo.CONJUNTO);
      }
      else if (actual.getTipoToken() == Token.Tipo.CARACTER)
      {
        conjunto += actual.getValor();
        salidaSintactico.Remove(salidaSintactico.ElementAt(controlToken));
        actual = salidaSintactico.ElementAt(controlToken);
        otroCaracter();
      }
      else if(actual.getTipoToken() == Token.Tipo.ID)
      {
        actual.changeTipo(Token.Tipo.CONJUNTO);
        match(Token.Tipo.CONJUNTO);
      }
    }

    private void match(Token.Tipo tipo)
    {
      if(actual.getTipoToken() != tipo)
      {
        Console.WriteLine("No se esperaba este caracter");
      }
      else if(actual.getTipoToken() != Token.Tipo.ULTIMO)
      {
        listaAnalizada.AddLast(actual);
        controlToken++;
        actual = salidaSintactico.ElementAt(controlToken);
      }
    }

    private void otroCaracter()
    {
      if(actual.getTipoToken() == Token.Tipo.COMA)
      {
        match(Token.Tipo.COMA);
        match(Token.Tipo.CARACTER);
        controlToken -= 2;
        conjunto += salidaSintactico.ElementAt(controlToken);
        salidaSintactico.Remove(salidaSintactico.ElementAt(controlToken));
        conjunto += salidaSintactico.ElementAt(controlToken);
        salidaSintactico.Remove(salidaSintactico.ElementAt(controlToken));
        actual = salidaSintactico.ElementAt(controlToken);
        listaAnalizada.RemoveLast();
        listaAnalizada.RemoveLast(); 
        otroCaracter();
      }
      else if(actual.getTipoToken() == Token.Tipo.VIRGULILLA)
      {
        match(Token.Tipo.VIRGULILLA);
        match(Token.Tipo.CARACTER);
        controlToken -= 2;
        conjunto += salidaSintactico.ElementAt(controlToken);
        salidaSintactico.Remove(salidaSintactico.ElementAt(controlToken));
        conjunto += salidaSintactico.ElementAt(controlToken);
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

    //private String getError(Token.Tipo tipo)
    //{

    //}
  }
}
