// See https://aka.ms/new-console-template for more information
using System;

namespace Semana16
{
    // ------------------------------------------------------------
    // Clase principal del programa
    // Aquí se maneja la interacción con el usuario y se utilizan
    // las funciones del grafo para mostrar vuelos y calcular rutas.
    // ------------------------------------------------------------
    class Program
    {
        static void Main()
        {
            // Creamos el grafo y cargamos los vuelos desde el archivo de texto
            var grafo = new GrafoVuelos();
            grafo.CargarDesdeArchivo("vuelos.txt");

            // Encabezado inicial del sistema
            Console.WriteLine("SISTEMA DE BÚSQUEDA DE VUELOS ECUATORIANOS");
            Console.WriteLine("(*-*)______________________________________________(*-*)\n");

            // Mostramos todos los vuelos cargados
            grafo.ListarVuelos();

            // Segunda sección: búsqueda de rutas
            Console.WriteLine("\n BÚSQUEDA DE RUTAS MÁS ECONÓMICAS");
            Console.WriteLine("(*-*)______________________________________________(*-*)\n");

            // Bucle para que el usuario pueda hacer varias consultas
            while (true)
            {
                // Pedimos ciudad de origen
                Console.Write("Ciudad origen (Enter para salir): ");
                string origen = Console.ReadLine();
                if (string.IsNullOrEmpty(origen)) break; // salir si no escribe nada

                // Pedimos ciudad de destino
                Console.Write("Ciudad destino: ");
                string destino = Console.ReadLine();
                if (string.IsNullOrEmpty(destino)) break;

                // Obtenemos la ruta más barata y una posible alternativa
                var (principal, alternativa) = grafo.EncontrarRutaYAlternativa(origen, destino);

                // Si no existe ruta entre esas dos ciudades
                if (principal.Item1 == -1)
                {
                    Console.WriteLine($"\n No hay rutas disponibles de {origen} a {destino}\n");
                    continue;
                }

                // Mostramos la ruta más barata encontrada
                Console.WriteLine($"\n RUTA MÁS BARATA:");
                Console.WriteLine($" Costo total: ${principal.Item1}");
                Console.WriteLine($" Ruta: {string.Join(" → ", principal.Item2)}");

                // Si existe, también mostramos la ruta alternativa
                if (alternativa.Item1 > 0)
                {
                    Console.WriteLine($"\n RUTA ALTERNATIVA:");
                    Console.WriteLine($" Costo total: ${alternativa.Item1}");
                    Console.WriteLine($" Ruta: {string.Join(" → ", alternativa.Item2)}");
                    Console.WriteLine($" Diferencia: +${alternativa.Item1 - principal.Item1}");
                }
                else
                {
                    Console.WriteLine("\n No se encontró una ruta alternativa.");
                }

                // Separador visual para mejorar la lectura de resultados
                Console.WriteLine("\n" + new string('=', 50) + "\n");
            }
        }
    }
}

