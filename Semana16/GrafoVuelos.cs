using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Semana16
{
    // ------------------------------------------------------------
    // Clase GrafoVuelos
    // Representa una red de vuelos entre ciudades de Ecuador.
    // Cada ciudad es un nodo y cada vuelo (con su precio) es una arista dirigida.
    // ------------------------------------------------------------
    public class GrafoVuelos
    {
        // Diccionario que guarda los vuelos disponibles:
        // clave = ciudad de origen
        // valor = lista de destinos y sus costos
        private Dictionary<string, List<(string destino, int costo)>> adj;

        public GrafoVuelos()
        {
            adj = new Dictionary<string, List<(string, int)>>();
        }

        // Método para agregar un vuelo desde una ciudad origen a un destino con un costo.
        public void AgregarVuelo(string origen, string destino, int costo)
        {
            if (!adj.ContainsKey(origen))
                adj[origen] = new List<(string, int)>();

            adj[origen].Add((destino, costo));
        }

        // Calcula la ruta más barata entre dos ciudades usando el algoritmo de Dijkstra.
        public (int costo, List<string> ruta) RutaMasBarata(string origen, string destino)
        {
            return RutaMasBarataIgnorandoAristas(origen, destino, new HashSet<(string, string)>());
        }

        // Implementación interna de Dijkstra con la opción de ignorar aristas específicas.
        // Esto se usa para poder calcular rutas alternativas.
        private (int, List<string>) RutaMasBarataIgnorandoAristas(
            string origen, 
            string destino, 
            HashSet<(string, string)> aristasAIgnorar)
        {
            var dist = new Dictionary<string, int>();   // guarda el costo mínimo acumulado a cada ciudad
            var prev = new Dictionary<string, string>(); // guarda el "camino" para reconstruir la ruta
            var cola = new SortedSet<(int costo, string ciudad)>(); // simula una cola de prioridad

            // Inicializar todas las distancias como "infinito"
            foreach (var ciudad in adj.Keys)
                dist[ciudad] = int.MaxValue;

            // Al origen se llega con costo 0
            dist[origen] = 0;
            cola.Add((0, origen));

            while (cola.Count > 0)
            {
                var (costoActual, ciudadActual) = cola.Min;
                cola.Remove(cola.Min);

                if (ciudadActual == destino) break; // Si llegamos al destino, detenemos la búsqueda
                if (!adj.ContainsKey(ciudadActual)) continue;

                foreach (var (vecino, costoVuelo) in adj[ciudadActual])
                {
                    if (aristasAIgnorar.Contains((ciudadActual, vecino)))
                        continue; // si está en la lista de ignorados, lo saltamos

                    int nuevoCosto = costoActual + costoVuelo;
                    if (nuevoCosto < dist[vecino])
                    {
                        cola.Remove((dist[vecino], vecino));
                        dist[vecino] = nuevoCosto;
                        prev[vecino] = ciudadActual;
                        cola.Add((nuevoCosto, vecino));
                    }
                }
            }

            // Si el destino no fue alcanzado, devolvemos -1
            if (dist[destino] == int.MaxValue)
                return (-1, null);

            // Reconstruimos la ruta desde el destino hacia atrás usando el diccionario "prev"
            var ruta = new List<string>();
            string actual = destino;
            while (actual != null)
            {
                ruta.Add(actual);
                actual = prev.ContainsKey(actual) ? prev[actual] : null;
            }
            ruta.Reverse();

            return (dist[destino], ruta);
        }

        // Busca la ruta principal más barata y además intenta hallar una ruta alternativa.
        public ((int, List<string>) principal, (int, List<string>) alternativa) EncontrarRutaYAlternativa(string origen, string destino)
        {
            var rutaPrincipal = RutaMasBarata(origen, destino);
            if (rutaPrincipal.Item1 == -1)
                return ((-1, null), (-1, null));

            var rutasAlternativas = new List<(int, List<string>)>();

            if (rutaPrincipal.Item2 != null && rutaPrincipal.Item2.Count > 1)
            {
                for (int i = 0; i < rutaPrincipal.Item2.Count - 1; i++)
                {
                    var aristaAIgnorar = (rutaPrincipal.Item2[i], rutaPrincipal.Item2[i + 1]);
                    var rutaAlternativa = RutaMasBarataIgnorandoAristas(origen, destino, new HashSet<(string, string)>{ aristaAIgnorar });

                    if (rutaAlternativa.Item1 != -1 && !EsMismaRuta(rutaAlternativa.Item2, rutaPrincipal.Item2))
                        rutasAlternativas.Add(rutaAlternativa);
                }
            }

            var mejorAlternativa = rutasAlternativas.OrderBy(r => r.Item1).FirstOrDefault();
            return (rutaPrincipal, mejorAlternativa);
        }

        // Compara dos rutas para verificar si son exactamente iguales.
        private bool EsMismaRuta(List<string> ruta1, List<string> ruta2)
        {
            if (ruta1 == null || ruta2 == null) return false;
            if (ruta1.Count != ruta2.Count) return false;
            return ruta1.SequenceEqual(ruta2);
        }

        // Carga los vuelos desde un archivo de texto (cada línea = origen,destino,costo).
        public void CargarDesdeArchivo(string rutaArchivo)
        {
            foreach (var linea in File.ReadAllLines(rutaArchivo))
            {
                var partes = linea.Split(',');
                if (partes.Length == 3)
                {
                    AgregarVuelo(partes[0].Trim(), partes[1].Trim(), int.Parse(partes[2].Trim()));
                }
            }
        }

        // Muestra en pantalla todos los vuelos disponibles ordenados alfabéticamente por ciudad y costo.
        public void ListarVuelos()
        {
            Console.WriteLine("<*-*> LISTA COMPLETA DE VUELOS DISPONIBLES <*-*>");
            foreach (var ciudad in adj.Keys.OrderBy(c => c))
            {
                foreach (var (destino, costo) in adj[ciudad].OrderBy(v => v.costo))
                {
                    Console.WriteLine($" {ciudad} → {destino}: ${costo}");
                }
            }
        }
    }
}
