// See https://aka.ms/new-console-template for more information
using System;

namespace Semana11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Creamos el traductor con las palabras iniciales
            Traductor traductor = new Traductor();
            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("\n___________________ MENÚ ____________________ <*_*>");
                Console.WriteLine("1. Traducir una frase");
                Console.WriteLine("2. Agregar palabras al diccionario");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");
                string? opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Write("Ingrese la frase a traducir: ");
                        string? frase = Console.ReadLine();

                        Console.Write("¿La frase está en español o inglés? (español/espanol - inglés/ingles): ");
                        string? idioma = Console.ReadLine();

                        if (!string.IsNullOrEmpty(frase) && !string.IsNullOrEmpty(idioma))
                        {
                            string traduccion = traductor.TraducirFrase(frase, idioma);
                            Console.WriteLine("Traducción: " + traduccion);
                        }
                        else
                        {
                            Console.WriteLine("Entrada no válida.");
                        }
                        break;

                    case "2":
                        Console.Write("Ingrese la palabra en español: ");
                        string? palabraEs = Console.ReadLine();

                        Console.Write("Ingrese la palabra en inglés: ");
                        string? palabraEn = Console.ReadLine();

                        if (!string.IsNullOrEmpty(palabraEs) && !string.IsNullOrEmpty(palabraEn))
                        {
                            traductor.AgregarPalabra(palabraEs, palabraEn);
                            Console.WriteLine("Palabra agregada correctamente.");
                        }
                        else
                        {
                            Console.WriteLine("Datos inválidos, intente de nuevo.");
                        }
                        break;

                    case "0":
                        Console.WriteLine("Saliendo del programa...");
                        salir = true;
                        break;

                    default:
                        Console.WriteLine("Opción no válida, intente nuevamente.");
                        break;
                }
            }
        }
    }
}

