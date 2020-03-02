using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compi1_Proyecto1
{
  class Token
  {
    public enum Tipo
    {
      INICIO_COMENTARIO,
      COMENTARIO,
      INICIO_MULTILINEA,
      COMENTARIO_MULTILINEA,
      FIN_MULTILINEA,
      CONCATENACION,
      DISYUNCION,
      SIGNO_INTERROGACION,
      CERRADURA_KLEENE,
      CERRADURA_POSITIVA,
      PALABRA_RESERVADA,
      CONJUNTO,
      SALTO_DE_LINEA,
      COMILLA_SIMPLE,
      COMILLA_DOBLE,
      TABULACION,
      TODO,
      ID,
      ASIGNACION,
      LLAVE_ABRE,
      LLAVE_CIERRA,
      PUNTO_COMA,
      DOS_PUNTOS,
      VIRGULILLA,
      PORCENTAJE,
      COMA,
      EXPRESION_REGULAR,
      CADENA,
      SIMBOLO
    }

    private Tipo tipo;
    private String valor;
    private int fila;
    private int columna;

    public Token(Tipo tipo, string valor, int fila, int columna)
    {
      this.tipo = tipo;
      this.valor = valor;
      this.fila = fila;
      this.columna = columna;
    }

    public void changeTipo(Tipo tipo)
    {
      this.tipo = tipo;
    }

    public int getFila()
    {
      return fila;
    }

    public int getColumna()
    {
      return columna;
    }

    public String getValor()
    {
      return valor;
    }

    public String getTipo()
    {
      switch (tipo)
      {
        case Tipo.INICIO_COMENTARIO:
          return "Inicio Comentario";
        case Tipo.COMENTARIO:
          return "Comentario";
        case Tipo.INICIO_MULTILINEA:
          return "Inicio Comentario Multilinea";
        case Tipo.COMENTARIO_MULTILINEA:
          return "Comentario Multilinea";
        case Tipo.FIN_MULTILINEA:
          return "Fin Comentario Multilinea";
        case Tipo.CONCATENACION:
          return "Operador de Concatenacón";
        case Tipo.DISYUNCION:
          return "Operador de Disyuncion";
        case Tipo.SIGNO_INTERROGACION:
          return "Operador 0 o 1";
        case Tipo.CERRADURA_KLEENE:
          return "Cerradura de Kleene";
        case Tipo.CERRADURA_POSITIVA:
          return "Cerradura Positiva";
        case Tipo.PALABRA_RESERVADA:
          return "Palabra Reservada";
        case Tipo.CONJUNTO:
          return "Conjunto";
        case Tipo.SALTO_DE_LINEA:
          return "Salto de Linea";
        case Tipo.COMILLA_SIMPLE:
          return "Comilla Simple";
        case Tipo.COMILLA_DOBLE:
          return "Comilla Doble";
        case Tipo.TABULACION:
          return "Tabulacion";
        case Tipo.TODO:
          return "Todos los Caracters (Sin Salto de Línea)";
        case Tipo.ID:
          return "Identificador";
        case Tipo.ASIGNACION:
          return "Asignacion de Conjuntos";
        case Tipo.LLAVE_ABRE:
          return "Llave Abre";
        case Tipo.LLAVE_CIERRA:
          return "Llave Cierra";
        case Tipo.PUNTO_COMA:
          return "Punto y Coma";
        case Tipo.DOS_PUNTOS:
          return "Dos Puntos";
        case Tipo.VIRGULILLA:
          return "Rango";
        case Tipo.PORCENTAJE:
          return "Inicio de Validaciones";
        case Tipo.EXPRESION_REGULAR:
          return "Expresion Regular";
        case Tipo.CADENA:
          return "Cadena";
        case Tipo.SIMBOLO:
          return "Simbolo";
        default:
          return "Token Desconocido";
      }
    }
  }
}
