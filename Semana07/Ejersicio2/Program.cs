// See https://aka.ms/new-console-template for more information
using System;

namespace TorresDeHanoi
{
    /// Clase principal del programa.
    /// Permite al usuario ingresar el número de discos
    /// y ejecuta la solución paso a paso mostrando el uso de pilas.
    internal class Program
    {
        static void Main(string[] args)
        {
            /// Solicita al usuario el número de discos a utilizar.
            Console.Write("Ingrese el número de discos (mínimo 1): ");

            /// Verifica si la entrada es un número entero positivo.
            if (int.TryParse(Console.ReadLine(), out int discos) && discos > 0)
            {
                /// Crea una instancia del juego y lo resuelve.
                Hanoi juego = new Hanoi(discos);
                juego.Resolver();
            }
            else
            {
                /// Mensaje de error si la entrada no es válida.
                Console.WriteLine("Entrada no válida. Debe ser un número entero positivo.");
            }

            /// Espera a que el usuario presione una tecla antes de cerrar.
            Console.WriteLine("Presione cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}


