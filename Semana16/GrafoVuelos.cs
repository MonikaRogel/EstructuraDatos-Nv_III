using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Semana16
{
    // ------------------------------------------------------------
    // Clase GrafoVuelos
    // Representa la red de vuelos nacionales en Ecuador.
    // Cada ciudad se modela como un nodo y cada vuelo como una arista dirigida
    // con un costo asociado (precio del boleto).
    // ------------------------------------------------------------
    public class GrafoVuelos
    {
        // Diccionario para almacenar la lista de adyacencia.
        // clave = ciudad de origen
        // valor = lista de pares (destino, costo del vuelo)
        private Dictionary<string, List<(string destino, int costo)>> adj;

        // Constructor: inicializa la estructura vacía
        public GrafoVuelos()
        {
            adj = new Dictionary<string, List<(string, int)>>();
        }

        // ------------------------------------------------------------
        // Método: AgregarVuelo
        // Añade un vuelo al grafo (origen → destino con un costo).
        // ------------------------------------------------------------
        public void AgregarVuelo(string origen, string destino, int costo)
        {
            if (!adj.ContainsKey(origen))
                adj[origen] = new List<(string, int)>();

            adj[origen].Add((destino, costo));
        }

        // ------------------------------------------------------------
        // Método: RutaMasBarata
        // Calcula la ruta más barata entre dos ciudades usando Dijkstra.
        // ------------------------------------------------------------
        public (int costo, List<string> ruta) RutaMasBarata(string origen, string destino)
        {
            return RutaMasBarataIgnorandoAristas(origen, destino, new HashSet<(string, string)>());
        }

        // ------------------------------------------------------------
        // Método privado: RutaMasBarataIgnorandoAristas
        // Implementación del algoritmo de Dijkstra.
        // Se puede pedir que ignore ciertas aristas para calcular rutas alternativas.
        // ------------------------------------------------------------
        private (int, List<string>) RutaMasBarataIgnorandoAristas(
            string origen, 
            string destino, 
            HashSet<(string, string)> aristasAIgnorar)
        {
            var dist = new Dictionary<string, int>();
            var prev = new Dictionary<string, string>();
            var cola = new SortedSet<(int costo, string ciudad)>();

            // Inicializamos todas las distancias como "infinito"
            foreach (var ciudad in adj.Keys)
                dist[ciudad] = int.MaxValue;

            dist[origen] = 0;
            cola.Add((0, origen));

            while (cola.Count > 0)
            {
                var (costoActual, ciudadActual) = cola.Min;
                cola.Remove(cola.Min);

                if (ciudadActual == destino) break;
                if (!adj.ContainsKey(ciudadActual)) continue;

                foreach (var (vecino, costoVuelo) in adj[ciudadActual])
                {
                    if (aristasAIgnorar.Contains((ciudadActual, vecino)))
                        continue;

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

            // Si no se llegó al destino
            if (dist[destino] == int.MaxValue)
                return (-1, null);

            // Reconstrucción de la ruta
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

        // ------------------------------------------------------------
        // Método: EncontrarRutaYAlternativa
        // Calcula la ruta más barata y busca una alternativa distinta.
        // ------------------------------------------------------------
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

        // Verifica si dos rutas son exactamente iguales
        private bool EsMismaRuta(List<string> ruta1, List<string> ruta2)
        {
            if (ruta1 == null || ruta2 == null) return false;
            if (ruta1.Count != ruta2.Count) return false;
            return ruta1.SequenceEqual(ruta2);
        }

        // ------------------------------------------------------------
        // Método: CargarDesdeArchivo
        // Lee todos los vuelos desde el archivo de texto (origen,destino,costo).
        // ------------------------------------------------------------
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

        // ------------------------------------------------------------
        // Método: ListarVuelos
        // Muestra en pantalla todos los vuelos cargados, ordenados por ciudad y costo.
        // ------------------------------------------------------------
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

        // ------------------------------------------------------------
        // Método: TieneVueloDirecto
        // Indica si existe un vuelo directo entre dos ciudades específicas.
        // ------------------------------------------------------------
        public bool TieneVueloDirecto(string origen, string destino)
        {
            if (!adj.ContainsKey(origen)) return false;
            return adj[origen].Any(v => v.destino.Equals(destino, StringComparison.OrdinalIgnoreCase));
        }
    }
}
