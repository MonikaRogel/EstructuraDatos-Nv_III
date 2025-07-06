using System;

// Clase que gestiona una lista enlazada simple
public class ListaEnlazada
{
    // Nodo inicial de la lista (cabeza)
    public Nodo? Cabeza { get; private set; }

    // Constructor: inicializa la lista como vacía
    public ListaEnlazada()
    {
        Cabeza = null;
    }

    // Método para agregar un nuevo nodo al final de la lista
    public void Agregar(int valor)
    {
        // Crear el nuevo nodo con el valor dado
        Nodo nuevo = new Nodo(valor);

        if (Cabeza == null)
        {
            // Si la lista está vacía, el nuevo nodo se vuelve la cabeza
            Cabeza = nuevo;
        }
        else
        {
            // Si ya hay nodos, recorrer hasta el final
            Nodo actual = Cabeza;
            while (actual.Siguiente != null)
            {
                actual = actual.Siguiente;
            }

            // Enlazar el último nodo con el nuevo nodo
            actual.Siguiente = nuevo;
        }
    }

    // Método para mostrar los elementos de la lista en consola
    public void Mostrar()
    {
        Nodo? actual = Cabeza;

        Console.Write("head --> ");
        while (actual != null)
        {
            // Imprimimos el valor actual y pasamos al siguiente
            Console.Write($"[ {actual.Valor} | * ] --> ");
            actual = actual.Siguiente;
        }

        Console.WriteLine("null"); // Indica el fin de la lista
    }

    // Método que busca un valor específico en la lista y cuenta cuántas veces aparece
    public int Buscar(int valorBuscado)
    {
        int contador = 0;
        Nodo? actual = Cabeza;

        while (actual != null)
        {
            // Si encontramos el valor, incrementamos el contador
            if (actual.Valor == valorBuscado)
            {
                contador++;
            }

            // Pasamos al siguiente nodo
            actual = actual.Siguiente;
        }

        // Si no se encontró ninguna coincidencia, se muestra un mensaje
        if (contador == 0)
        {
            Console.WriteLine($"\n>> El valor {valorBuscado} no fue encontrado en la lista.");
        }

        // Retorna la cantidad de veces que se encontró el valor
        return contador;
    }
}
