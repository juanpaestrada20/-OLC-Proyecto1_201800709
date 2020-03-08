using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compi1_Proyecto1
{
  class AnalizadorLexico
  {
    private LinkedList<Token> salidaTokens;
    private LinkedList<Error> salidaErrores;
    private String auxlex;
    private int fila;
    private int columna;
    private int estado;

    public LinkedList<Token> Escanner(String entrada)
    {
      salidaTokens = new LinkedList<Token>();
      salidaErrores = new LinkedList<Error>();
      Char c;
      fila = 1;
      columna = 0;
      estado = 0;

      for (int i = 0; i < entrada.Length; i++)
      {
        c = entrada.ElementAt(i);
        switch (estado)
        {

          case 0:
            //comentario de una linea
            if (c.CompareTo('/') == 0)
            {
              auxlex += c;
              columna++;
              estado = 1;
            }
            //comnetario multilinea
            else if (c.CompareTo('<') == 0)
            {
              auxlex += c;
              columna++;
              estado = 2;
            }
            else if (c.CompareTo('.') == 0)
            {
              auxlex += c;
              columna++;
              agregarToken(Token.Tipo.CONCATENACION);
            }
            else if (c.CompareTo('|') == 0)
            {
              auxlex += c;
              columna++;
              agregarToken(Token.Tipo.DISYUNCION);
            }
            else if (c.CompareTo('?') == 0)
            {
              auxlex += c;
              columna++;
              agregarToken(Token.Tipo.SIGNO_INTERROGACION);
            }
            else if (c.CompareTo('*') == 0)
            {
              auxlex += c;
              columna++;
              agregarToken(Token.Tipo.CERRADURA_KLEENE);
            }
            else if (c.CompareTo('\n') == 0)
            {
              fila++;
              columna = 0;
              estado = 0;
            }
            // comilla simple
            else if (c.CompareTo('\'') == 0)
            {
              auxlex += c;
              columna++;
              agregarToken(Token.Tipo.COMILLA_SIMPLE);
              estado = 3;
            }
            //comilla doble
            else if (c.CompareTo('\"') == 0)
            {
              auxlex += c;
              columna++;
              agregarToken(Token.Tipo.COMILLA_DOBLE);
              estado = 4;
            }
            // id
            else if (Char.IsLetter(c))
            {
              auxlex += c;
              columna++;
              estado = 5;
            }
            //flecha
            else if (c.CompareTo('-') == 0)
            {
              auxlex += c;
              columna++;
              estado = 6;
            }
            //espacio
            else if (c.CompareTo(' ') == 0)
            {
              columna++;
            }
            //llave
            else if (c.CompareTo('{') == 0)
            {
              auxlex += c;
              columna++;
              agregarToken(Token.Tipo.LLAVE_ABRE);
            }
            //llave cierra
            else if(c.CompareTo('}') == 0)
            {
              auxlex += c;
              columna++;
              agregarToken(Token.Tipo.LLAVE_CIERRA);
            }
            //punto coma
            else if (c.CompareTo(';') == 0)
            {
              auxlex += c;
              columna++;
              agregarToken(Token.Tipo.PUNTO_COMA);
            }
            //dos puntos
            else if (c.CompareTo(':') == 0)
            {
              auxlex += c;
              columna++;
              agregarToken(Token.Tipo.DOS_PUNTOS);
            }
            //virgulilla
            else if (c.CompareTo('~') == 0)
            {
              auxlex += c;
              columna++;
              agregarToken(Token.Tipo.VIRGULILLA);
            }
            //coma
            else if (c.CompareTo(',') == 0)
            {
              auxlex += c;
              columna++;
              agregarToken(Token.Tipo.COMA);
            }
            //porcentaje
            else if (c.CompareTo('%') == 0)
            {
              auxlex += c;
              columna++;
              agregarToken(Token.Tipo.PORCENTAJE);
            }
            else if (Char.IsDigit(c))
            {
              auxlex += c;
              columna++;
              estado = 8;
            }
            //todo
            else if (c.CompareTo('[') == 0)
            {
              auxlex += c;
              columna++;
              estado = 7;
            }
            else if((((int)c >= 33) && ((int)c <= 64)) || (((int)c >= 91) && ((int)c <= 96)) )
            {
              auxlex += c;
              columna++;
              agregarToken(Token.Tipo.CARACTER);
            }
            break;
          // comentario de una linea
          case 1:
            bool comentario = false;
            if (c.CompareTo('/') == 0 && auxlex.CompareTo("/") == 0)
            {
              auxlex += c;
              columna++;
              agregarToken(Token.Tipo.INICIO_COMENTARIO);
              estado = 1;
              comentario = true;
            }
            else if (c.CompareTo('\n') == 0)
            {
              agregarToken(Token.Tipo.COMENTARIO);
              fila++;
              columna = 0;
            }
            else if (comentario)
            {
              auxlex += c;
              columna++;
              estado = 1;
            }
            else if (!comentario)
            {
              auxlex += c;
              columna++;
              estado = 1;
            }
            else if (!comentario && c.CompareTo('\n') == 0)
            {
              agregarError("Se esperaba el caracter '/'");
            }
            break;
          //Comentario multilinea
          case 2:
            if (c.CompareTo('!') == 0 && auxlex.CompareTo("<") == 0)
            {
              auxlex += c;
              columna++;
              agregarToken(Token.Tipo.INICIO_MULTILINEA);
              estado = 2;

            }
            else if (c.CompareTo('!') == 0)
            {
              agregarToken(Token.Tipo.COMENTARIO_MULTILINEA);
              columna++;
              auxlex += c;
              i++;
              c = entrada.ElementAt(i);
              if(c.CompareTo('>') == 0)
              {
                auxlex += c;
                columna++;
                agregarToken(Token.Tipo.FIN_MULTILINEA);
              }
            }
            else if (c.CompareTo('\n') == 0)
            {
              auxlex += c;
              columna = 0;
              estado = 2;
            }
            else if (c.CompareTo('>') == 0 && auxlex.Contains("~"))
            {
              auxlex += c;
              columna++;
              agregarToken(Token.Tipo.CONJUNTO);
            }
            else
            {
              auxlex += c;
              columna++;
              estado = 2;
            }
            break;
          //comilla simple
          case 3:
            if (c.CompareTo('\'') == 0)
            {
              if (auxlex.Length == 1)
              {
                agregarToken(Token.Tipo.CARACTER);
                auxlex += c;
                agregarToken(Token.Tipo.COMILLA_SIMPLE);
              }
              else
              {
                agregarError("No se debe ingresar mas de un caracter en comillas simples");
              }
            }
            else
            {
              auxlex += c;
              columna++;
            }
            break;
          //comilla doble
          case 4:
            if (c.CompareTo('\"') == 0)
            {
              agregarToken(Token.Tipo.CADENA);
              auxlex += c;
              columna++;
              agregarToken(Token.Tipo.COMILLA_DOBLE);
            }
            else
            {
              auxlex += c;
              columna++;
            }
            break;
          case 5:
            auxlex += c;
            columna++;
            if (auxlex.ToLower().CompareTo("conj") == 0)
            {
              char d = entrada.ElementAt(i + 1);
              if (!Char.IsLetterOrDigit(d))
              {
                agregarToken(Token.Tipo.PALABRA_RESERVADA);
              }
            }
            else if (c.CompareTo(' ') == 0)
            {
              agregarToken(Token.Tipo.ID);
              columna++;
            }
            else if (c.CompareTo(';') == 0)
            {
              agregarToken(Token.Tipo.ID);
              auxlex += c;
              columna++;
              agregarToken(Token.Tipo.PUNTO_COMA);
            }
            else if (c.CompareTo('\n') == 0)
            {
              agregarToken(Token.Tipo.ID);
              fila++;
              columna = 0;
            }
            else if(c.CompareTo('}') == 0)
            {
              agregarToken(Token.Tipo.ID);
              auxlex += c;
              columna++;
              agregarToken(Token.Tipo.LLAVE_CIERRA);
            }
            break;
          //->
          case 6:
            if (c.CompareTo('>') == 0)
            {
              auxlex += c;
              columna++;
              agregarToken(Token.Tipo.ASIGNACION);
            }
            else
            {
              auxlex += c;
              columna++;
              agregarError("Hizo falta \'>\'");
            }
            break;
          //dentro de llaves
          case 7:
            if (c.CompareTo('}') == 0)
            {
              agregarToken(Token.Tipo.CONJUNTO);
              auxlex += c;
              columna++;
              agregarToken(Token.Tipo.LLAVE_CIERRA);
            }
            else if (c.CompareTo(' ') == 0)
            {
              auxlex += c;
              columna++;
              agregarToken(Token.Tipo.LLAVE_CIERRA);
            }
            else if (c.CompareTo('\n') == 0)
            {
              auxlex += c;
              columna++;
              agregarToken(Token.Tipo.LLAVE_CIERRA);
            }
            else
            {
              auxlex += c;
              columna++;
            }
            break;
          case 8:
            if (!Char.IsDigit(c))
            {
              agregarToken(Token.Tipo.NUMERO);
              i--;
            }
            else
            {
              auxlex += c;
              columna++;
            }
            break;
            //todo
        }
      }
      return salidaTokens;
    }

    private void agregarToken(Token.Tipo tipo)
    {
      salidaTokens.AddLast(new Token(tipo, auxlex, fila, columna));
      auxlex = "";
      estado = 0;
    }

    private void agregarError(String descripcion)
    {
      salidaErrores.AddLast(new Error(auxlex, descripcion, fila, columna));
      auxlex = "";
      estado = 0;
    }

    public void generarListaTokes()
    {

    }

    public void imprimirTokens()
    {
      int contador = 1;
      foreach(Token item in salidaTokens)
      {
        Console.WriteLine(contador + ". " + item.getTipo() + " -> " + item.getValor());
        contador++;
      }
    }
  }
}
