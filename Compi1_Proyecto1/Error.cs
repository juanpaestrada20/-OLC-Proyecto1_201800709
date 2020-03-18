using System;

namespace Compi1_Proyecto1
{
  internal class Error
  {
    private String error;
    private String descripcion;
    private int fila;
    private int columna;

    public Error(string error, string descripcion, int fila, int columna)
    {
      this.error = error;
      this.descripcion = descripcion;
      this.fila = fila;
      this.columna = columna;
    }

    public String getError()
    {
      return this.error;
    }

    public String getDescripcion()
    {
      return this.descripcion;
    }

    public int getFila()
    {
      return this.fila;
    }

    public int getColumna()
    {
      return this.columna;
    }
  }
}
