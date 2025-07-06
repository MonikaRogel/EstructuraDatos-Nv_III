using System;

// Clase que representa la lista enlazada simple
public class ListaEnlazada
{
    public Nodo? Cabeza { get; private set; }

    public ListaEnlazada()
    {
        Cabeza = null; // Lista vacía al inicio
    }

    // Agrega un nodo al final de la lista
    public void Agregar(int valor)
    {
        Nodo nuevo = new Nodo(valor);

        if (Cabeza == null)
        {
            Cabeza = nuevo;
        }
        else
        {
            Nodo actual = Cabeza;
            while (actual.Siguiente != null)
            {
                actual = actual.Siguiente;
            }
            actual.Siguiente = nuevo;
        }
    }

    // Muestra todos los elementos de la lista
    public void Mostrar()
    {
        Nodo? actual = Cabeza;

        Console.Write("head --> ");
        while (actual != null)
        {
            Console.Write($"[ {actual.Valor} | * ] --> ");
            actual = actual.Siguiente;
        }
        Console.WriteLine("null");
    }

    // Invierte el orden de los nodos en la lista
    public void Invertir()
    {
        Nodo? anterior = null;
        Nodo? actual = Cabeza;
        Nodo? siguiente = null;

        while (actual != null)
        {
            siguiente = actual.Siguiente;   // Guardamos el siguiente nodo
            actual.Siguiente = anterior;    // Invertimos la dirección del enlace
            anterior = actual;              // Avanzamos anterior
            actual = siguiente;             // Avanzamos actual
        }

        Cabeza = anterior; // Nuevo inicio de la lista
    }
}
