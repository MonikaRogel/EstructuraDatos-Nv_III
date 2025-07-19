using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SimuladorAtraccionConsola.Models
{
    // Esta clase contiene toda la lógica de negocio de la atracción.
    // Aquí se gestiona la fila de espera principal, la lista de personas asignadas a la atracción
    // y una cola adicional de personas que quedaron fuera por falta de espacio (espera).
    public class Atraccion
    {
        private readonly Queue<Persona> _colaEspera = new();        // Cola principal de espera (FIFO)
        private readonly Queue<Persona> _colaEnEspera = new();      // Cola secundaria para los que llegaron tarde (sin lugar)
        private readonly List<Persona> _asignados = new();          // Lista de personas que consiguieron asiento
        private readonly Stack<Persona> _historialAsignacion = new(); // Historial de asignación para posibles reportes o auditoría

        public const int Capacidad = 30;  // Límite máximo de personas que pueden subirse a la atracción

        // Intenta agregar una persona a la fila principal.
        // Se verifica que no se repita el ID ni el nombre en ninguna lista del sistema.
        public void AgregarALaCola(Persona persona)
        {
            if (_colaEspera.Concat(_colaEnEspera).Concat(_asignados).Any(p =>
                p.Id == persona.Id || p.Nombre.Equals(persona.Nombre, StringComparison.OrdinalIgnoreCase)))
            {
                throw new InvalidOperationException("Ya existe una persona con el mismo nombre o ID.");
            }

            _colaEspera.Enqueue(persona);
        }

        // Agrega una persona a la cola en espera (no podrá subirse, pero queda registrada)
        public void AgregarAColaEnEspera(Persona persona)
        {
            _colaEnEspera.Enqueue(persona);
        }

        // Devuelve una copia de la cola principal (los que están en espera de ser asignados)
        public List<Persona> ObtenerColaPrincipal() => _colaEspera.ToList();

        // Devuelve la lista de personas que quedaron fuera por falta de espacio
        public List<Persona> ObtenerColaEnEspera() => _colaEnEspera.ToList();

        // Devuelve la lista de personas que fueron asignadas a la atracción
        public List<Persona> ObtenerAsignados() => _asignados;

        // Devuelve el historial de asignaciones en el orden que fueron procesadas
        public Stack<Persona> ObtenerHistorial() => _historialAsignacion;

        public int TotalCola => _colaEspera.Count;
        public int TotalAsignados => _asignados.Count;
        public int TotalEnEspera => _colaEnEspera.Count;

        // Realiza la asignación de asientos según el orden de llegada.
        // Si la atracción ya está llena, las personas se quedan en la cola.
        public void AsignarAsientos()
        {
            while (_colaEspera.Count > 0 && _asignados.Count < Capacidad)
            {
                var persona = _colaEspera.Dequeue();
                _asignados.Add(persona);
                _historialAsignacion.Push(persona);
            }

            // No se limpia la cola, solo se procesan hasta llenar la capacidad.
            // Los restantes quedan en espera para una próxima asignación o para seguimiento.
        }

        // Crea un archivo de texto con un resumen completo de los asignados y en espera
        public void GuardarResumenEnArchivo(string rutaArchivo)
        {
            using StreamWriter escritor = new(rutaArchivo, false);

            escritor.WriteLine("=== RESUMEN DE ASIGNACIÓN ===");
            escritor.WriteLine($"Asientos ocupados: {_asignados.Count} de {Capacidad}\n");

            int asiento = 1;
            escritor.WriteLine("Personas que subieron a la atracción:");
            foreach (var persona in _asignados)
            {
                escritor.WriteLine($"Asiento #{asiento}: {persona.Nombre} (ID: {persona.Id}) - Ingreso: {persona.TimestampIngreso:HH:mm:ss}");
                asiento++;
            }

            if (_colaEnEspera.Any())
            {
                escritor.WriteLine("\nPersonas que quedaron en lista de espera:");
                foreach (var persona in _colaEnEspera)
                {
                    escritor.WriteLine($"- {persona}");
                }
            }
        }

        // Resetea completamente el estado del sistema, útil para nuevas simulaciones
        public void Reiniciar()
        {
            _colaEspera.Clear();
            _colaEnEspera.Clear();
            _asignados.Clear();
            _historialAsignacion.Clear();
        }
    }
}
