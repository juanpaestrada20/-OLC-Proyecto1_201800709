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
    private int fila;
    private int columna;

    public LinkedList<Token> AnalizadorLexico(String entrada)
    {
      salidaTokens = new LinkedList<Token>();

      return salidaTokens;
    }
  }
}
