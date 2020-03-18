namespace Compi1_Proyecto1
{
  internal class ListaNodos
  {
    private NodoLista cabeza;
    private NodoLista cola;
    private int size;

    public ListaNodos()
    {
      cabeza = null;
      cola = null;
      size = 0;
    }

    public int getSize()
    {
      return size;
    }

    public void insertarDato(Nodo n)
    {
      NodoLista nuevo = new NodoLista(n);

      if (cabeza == null)
      {
        cabeza = nuevo;
        cola = nuevo;
      }
      else
      {
        cola.siguiente = nuevo;
        nuevo.anterior = cola;
        cola = nuevo;
      }
      size++;
    }
  }
}
