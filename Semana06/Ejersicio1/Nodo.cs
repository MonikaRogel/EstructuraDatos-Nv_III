// Clase que representa un nodo de la lista enlazada
public class Nodo
{
    public int Valor { get; set; }             // Valor almacenado en el nodo
    public Nodo? Siguiente { get; set; }       // Referencia al siguiente nodo

    public Nodo(int valor)
    {
        Valor = valor;
        Siguiente = null;
    }
}
