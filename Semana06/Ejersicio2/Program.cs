// See https://aka.ms/new-console-template for more information
/*
3.  Implementar el método de búsqueda en la clase lista:
    El método debe retornar el número de veces que se encuentra el dato dentro de la lista.
    En caso de no encontrarse, debe mostrar un mensaje indicando que el dato no fue encontrado.
    El parámetro de entrada del método es el valor que se desea buscar.
*/

using System;

class Program
{
    static void Main(string[] args)
    {
        // Mensaje inicial de presentación
        Console.WriteLine("============================================================");
        Console.WriteLine("       2525 - ESTRUCTURA DE DATOS - UEA / SEMANA 06");
        Console.WriteLine("------------------------------------------------------------");
        Console.WriteLine("       Ejercicio 3: Buscar un valor en la lista enlazada");
        Console.WriteLine("============================================================\n");

        // Creamos la lista y agregamos algunos valores repetidos y distintos
        ListaEnlazada lista = new ListaEnlazada();
        lista.Agregar(5);
        lista.Agregar(10);
        lista.Agregar(20);
        lista.Agregar(10);
        lista.Agregar(30);
        lista.Agregar(10);

        // Mostramos el contenido actual de la lista
        Console.WriteLine(">> Lista actual:");
        lista.Mostrar();

        // Solicitamos al usuario el valor que desea buscar
        Console.Write("\nIngrese el valor que desea buscar en la lista: ");
        int valorBuscado = int.Parse(Console.ReadLine()!);

        // Ejecutamos el método de búsqueda
        int repeticiones = lista.Buscar(valorBuscado);

        // Si se encontró, mostramos cuántas veces apareció
        if (repeticiones > 0)
        {
            Console.WriteLine($">> El valor {valorBuscado} se encontró {repeticiones} vez/veces en la lista.");
        }
    }
}
