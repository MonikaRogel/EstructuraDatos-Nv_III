// Clase que representa un nodo dentro de la lista enlazada simple
public class Nodo
{
    // Valor numérico que contiene el nodo
    public int Valor { get; set; }

    // Referencia al siguiente nodo en la lista (puede ser null si es el último)
    public Nodo? Siguiente { get; set; }

    // Constructor que inicializa el nodo con un valor y sin siguiente (null)
    public Nodo(int valor)
    {
        Valor = valor;
        Siguiente = null;
    }
}
