namespace Compi1_Proyecto1
{
  internal class NodoLista
  {
    public Nodo nodo;
    public NodoLista siguiente;
    public NodoLista anterior;

    public NodoLista(Nodo nodo)
    {
      this.nodo = nodo;
      siguiente = null;
      anterior = null;
    }
  }
}
