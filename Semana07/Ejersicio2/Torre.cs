using System;
using System.Collections.Generic;
using System.Linq;

namespace TorresDeHanoi
{
    // Representa una torre que usa una pila para almacenar discos.
    public class Torre
    {
        // Nombre de la torre (por ejemplo: A, B, C).
        public string Nombre { get; private set; }

        // Pila interna donde se almacenan los discos.
        private Stack<Disco> pila;

        // Constructor que asigna un nombre y crea la pila vacía.
        public Torre(string nombre)
        {
            Nombre = nombre;
            pila = new Stack<Disco>();
        }

        // Agrega un disco encima de la torre.
        public void Apilar(Disco d) => pila.Push(d);

        // Quita el disco que está en la cima de la torre.
        public Disco Desapilar() => pila.Pop();

        // Devuelve cuántos discos hay actualmente en la torre.
        public int Cantidad => pila.Count;

        // Muestra los discos desde la base hasta la cima para mayor claridad visual.
        public void Mostrar()
        {
            Console.Write($"Torre {Nombre}: ");

            // Se invierte la pila para mostrar los discos desde la base.
            foreach (var d in pila.Reverse())
                Console.Write($"[{d}] ");

            Console.WriteLine();
        }
    }
}
