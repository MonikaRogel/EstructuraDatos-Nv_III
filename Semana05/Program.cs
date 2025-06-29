using System;
using Semana05; 

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== MENÚ DE EJERCICIOS ===");
            Console.WriteLine("1. Mostrar asignaturas");
            Console.WriteLine("2. Yo estudio <asignatura>");
            Console.WriteLine("3. Mostrar números del 10 al 1");
            Console.WriteLine("4. Mostrar el menor y mayor precio");
            Console.WriteLine("5. Contar vocales en una palabra");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine() ?? "";
            Console.Clear();

            switch (opcion)
            {
                case "1":
                    new Ejercicio1().Ejecutar();
                    break;
                case "2":
                    new Ejercicio2().Ejecutar();
                    break;
                case "3":
                    new Ejercicio5().Ejecutar();
                    break;
                case "4":
                    new Ejercicio9().Ejecutar();
                    break;
                case "5":
                    new Ejercicio10().Ejecutar();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }

            Console.WriteLine("\nPresione una tecla para volver al menú...");
            Console.ReadKey();
        }
    }
}
