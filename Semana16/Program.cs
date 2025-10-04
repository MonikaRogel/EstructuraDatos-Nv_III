using System;

namespace Semana16
{
    // ------------------------------------------------------------
    // Clase Program
    // Encargada de la interacción con el usuario:
    // muestra vuelos, recibe consultas de rutas y presenta resultados.
    // ------------------------------------------------------------
    class Program
    {
        static void Main()
        {
            var grafo = new GrafoVuelos();
            grafo.CargarDesdeArchivo("vuelos.txt");

            Console.WriteLine("SISTEMA DE BÚSQUEDA DE VUELOS ECUATORIANOS");
            Console.WriteLine("(*-*)______________________________________________(*-*)\n");

            grafo.ListarVuelos();

            Console.WriteLine("\n BÚSQUEDA DE RUTAS MÁS ECONÓMICAS");
            Console.WriteLine("(*-*)______________________________________________(*-*)\n");

            while (true)
            {
                Console.Write("Ciudad origen (Enter para salir): ");
                string origen = Console.ReadLine();
                if (string.IsNullOrEmpty(origen)) break;

                Console.Write("Ciudad destino: ");
                string destino = Console.ReadLine();
                if (string.IsNullOrEmpty(destino)) break;

                var (principal, alternativa) = grafo.EncontrarRutaYAlternativa(origen, destino);

                if (principal.Item1 == -1)
                {
                    Console.WriteLine($"\n No hay rutas disponibles de {origen} a {destino}\n");
                    continue;
                }

                // Verificamos si existe un vuelo directo o solo rutas con escalas
                bool vueloDirecto = grafo.TieneVueloDirecto(origen, destino);
                if (!vueloDirecto)
                {
                    Console.WriteLine($"\n Nota: No existe vuelo directo entre {origen} y {destino}. Se muestran rutas con escalas.\n");
                }

                Console.WriteLine($"\n RUTA MÁS BARATA:");
                Console.WriteLine($" Costo total: ${principal.Item1}");
                Console.WriteLine($" Ruta: {string.Join(" → ", principal.Item2)}");

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

                Console.WriteLine("\n" + new string('=', 50) + "\n");
            }
        }
    }
}
