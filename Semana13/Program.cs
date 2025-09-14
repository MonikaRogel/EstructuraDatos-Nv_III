// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;

namespace Semana13
{
    class Program
    {
        // Lista que representa el catálogo de revistas
        private static List<string> catalogoRevistas = new List<string>();

        static void Main(string[] args)
        {
            InicializarCatalogo();
            MostrarMenu();
        }

        // Carga inicial de revistas y ordenamiento alfabético
        private static void InicializarCatalogo()
        {
            catalogoRevistas.AddRange(new[]
            {
                "National Geographic",
                "Time",
                "The Economist",
                "Forbes",
                "People",
                "Vogue",
                "Sports Illustrated",
                "Wired",
                "Cosmopolitan",
                "New Yorker",
                "Scientific American",
                "PC Magazine"
            });

            catalogoRevistas.Sort();
        }

        // Muestra el menú principal y controla el flujo del programa
        private static void MostrarMenu()
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("=== CATÁLOGO DE REVISTAS ===");
                Console.WriteLine("1. Buscar revista (Búsqueda Binaria Recursiva)");
                Console.WriteLine("2. Buscar revista (Búsqueda Binaria Iterativa)");
                Console.WriteLine("3. Mostrar todas las revistas");
                Console.WriteLine("4. Salir");
                Console.Write("Seleccione una opción: ");

                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    EjecutarOpcion(opcion);
                }
                else
                {
                    Console.WriteLine("Por favor, ingrese un número válido.");
                }

                if (opcion != 4)
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                }
            } while (opcion != 4);
        }

        // Ejecuta la acción correspondiente según la opción del menú
        private static void EjecutarOpcion(int opcion)
        {
            switch (opcion)
            {
                case 1:
                    EjecutarBusqueda((lista, objetivo) =>
                        BusquedaBinariaRecursiva(lista, objetivo, 0, lista.Count - 1),
                        "Recursiva");
                    break;

                case 2:
                    EjecutarBusqueda(BusquedaBinariaIterativa, "Iterativa");
                    break;

                case 3:
                    MostrarTodasLasRevistas();
                    break;

                case 4:
                    Console.WriteLine("Gracias por usar el catálogo de revistas.");
                    break;

                default:
                    Console.WriteLine("Opción no válida. Intente nuevamente.");
                    break;
            }
        }

        // Método común para realizar la búsqueda usando el algoritmo que se indique
        private static void EjecutarBusqueda(Func<List<string>, string, int> metodoBusqueda, string tipo)
        {
            Console.Write($"Ingrese el título de la revista a buscar ({tipo}): ");
            string titulo = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(titulo))
            {
                Console.WriteLine("El título no puede estar vacío.");
                return;
            }

            int resultado = metodoBusqueda(catalogoRevistas, titulo);

            if (resultado == -1)
            {
                Console.WriteLine($"La revista '{titulo}' no se encuentra en el catálogo.");
            }
            else
            {
                Console.WriteLine($"La revista '{catalogoRevistas[resultado]}' fue encontrada en la posición {resultado + 1} (orden alfabético).");
            }
        }

        // Algoritmo de búsqueda binaria recursiva
        private static int BusquedaBinariaRecursiva(List<string> lista, string objetivo, int inicio, int fin)
        {
            if (inicio > fin)
            {
                return -1; // No encontrado
            }

            int medio = (inicio + fin) / 2;
            int comparacion = string.Compare(lista[medio], objetivo, StringComparison.OrdinalIgnoreCase);

            if (comparacion == 0)
            {
                return medio;
            }
            else if (comparacion > 0)
            {
                return BusquedaBinariaRecursiva(lista, objetivo, inicio, medio - 1);
            }
            else
            {
                return BusquedaBinariaRecursiva(lista, objetivo, medio + 1, fin);
            }
        }

        // Algoritmo de búsqueda binaria iterativa
        private static int BusquedaBinariaIterativa(List<string> lista, string objetivo)
        {
            int inicio = 0;
            int fin = lista.Count - 1;

            while (inicio <= fin)
            {
                int medio = (inicio + fin) / 2;
                int comparacion = string.Compare(lista[medio], objetivo, StringComparison.OrdinalIgnoreCase);

                if (comparacion == 0)
                {
                    return medio;
                }
                else if (comparacion > 0)
                {
                    fin = medio - 1;
                }
                else
                {
                    inicio = medio + 1;
                }
            }

            return -1;
        }

        // Muestra todas las revistas en el catálogo con su posición
        private static void MostrarTodasLasRevistas()
        {
            Console.WriteLine("=== CATÁLOGO COMPLETO DE REVISTAS ===");

            for (int i = 0; i < catalogoRevistas.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {catalogoRevistas[i]}");
            }
        }
    }
}
