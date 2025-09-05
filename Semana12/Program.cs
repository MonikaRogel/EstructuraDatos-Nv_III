// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;

namespace TorneoFutbol
{
    // Clase Jugador
    // Representa a un jugador de fútbol con sus datos básicos.
    public class Jugador
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Posicion { get; set; }

        public override bool Equals(object obj) =>
            obj is Jugador otro && Id == otro.Id;

        public override int GetHashCode() => Id.GetHashCode();

        public override string ToString() =>
            $"{Id} - {Nombre} ({Posicion}, {Edad} años)";
    }

    // Clase Equipo
    // Representa a un equipo con su lista de jugadores.
    public class Equipo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Ciudad { get; set; }
        public HashSet<Jugador> Jugadores { get; set; } = new HashSet<Jugador>();

        public override bool Equals(object obj) =>
            obj is Equipo otro && Id == otro.Id;

        public override int GetHashCode() => Id.GetHashCode();

        public override string ToString() =>
            $"{Id} - {Nombre} ({Ciudad})";
    }

    class Program
    {
        // Diccionario: clave = ID del equipo, valor = Equipo con su lista de jugadores
        static Dictionary<int, Equipo> equipos = new Dictionary<int, Equipo>();

        static void Main()
        {
            int opcion;
            do
            {
                Console.WriteLine("\n(<---------Torneo de Fútbol---------<(*_*)>");
                Console.WriteLine("1. Registrar equipo");
                Console.WriteLine("2. Registrar jugador en equipo");
                Console.WriteLine("3. Listar equipos");
                Console.WriteLine("4. Listar jugadores de un equipo");
                Console.WriteLine("5. Buscar jugador por nombre");
                Console.WriteLine("6. Eliminar equipo");
                Console.WriteLine("7. Eliminar jugador");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");
                
                if (!int.TryParse(Console.ReadLine(), out opcion))
                    opcion = -1;

                switch (opcion)
                {
                    case 1: RegistrarEquipo(); break;
                    case 2: RegistrarJugador(); break;
                    case 3: ListarEquipos(); break;
                    case 4: ListarJugadoresDeEquipo(); break;
                    case 5: BuscarJugador(); break;
                    case 6: EliminarEquipo(); break;
                    case 7: EliminarJugador(); break;
                    case 0: Console.WriteLine("¡Gracias por usar el sistema!"); break;
                    default: Console.WriteLine("Opción no válida."); break;
                }

            } while (opcion != 0);
        }

        // Registrar equipo
        static void RegistrarEquipo()
        {
            Console.Write("Ingrese ID del equipo: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("El ID del equipo debe ser un número entero.");
                return;
            }

            if (equipos.ContainsKey(id))
            {
                Console.WriteLine("Ya existe un equipo con este ID.");
                return;
            }

            Console.Write("Ingrese nombre del equipo: ");
            string nombre = Console.ReadLine();

            Console.Write("Ingrese ciudad: ");
            string ciudad = Console.ReadLine();

            Equipo nuevo = new Equipo { Id = id, Nombre = nombre, Ciudad = ciudad };
            equipos[id] = nuevo;

            Console.WriteLine("Equipo registrado correctamente.");
        }

        // Registrar jugador en un equipo
        static void RegistrarJugador()
        {
            Console.Write("Ingrese ID del equipo: ");
            if (!int.TryParse(Console.ReadLine(), out int equipoId))
            {
                Console.WriteLine("El ID del equipo debe ser un número entero.");
                return;
            }

            if (!equipos.ContainsKey(equipoId))
            {
                Console.WriteLine("El equipo no existe.");
                return;
            }

            Console.Write("Ingrese ID del jugador: ");
            if (!int.TryParse(Console.ReadLine(), out int idJugador))
            {
                Console.WriteLine("El ID del jugador debe ser un número entero.");
                return;
            }

            Console.Write("Ingrese nombre del jugador: ");
            string nombre = Console.ReadLine();

            Console.Write("Ingrese edad: ");
            if (!int.TryParse(Console.ReadLine(), out int edad))
            {
                Console.WriteLine("La edad debe ser un número entero.");
                return;
            }

            Console.Write("Ingrese posición: ");
            string posicion = Console.ReadLine();

            Jugador nuevo = new Jugador { Id = idJugador, Nombre = nombre, Edad = edad, Posicion = posicion };

            if (equipos[equipoId].Jugadores.Add(nuevo))
                Console.WriteLine("Jugador agregado correctamente.");
            else
                Console.WriteLine("El jugador ya existe en este equipo.");
        }

        // Listar equipos
        static void ListarEquipos()
        {
            if (equipos.Count == 0)
            {
                Console.WriteLine("No hay equipos registrados.");
                return;
            }

            Console.WriteLine("\n------ Equipos Registrados ------<<(*_*)>>");
            foreach (var eq in equipos.Values)
                Console.WriteLine(eq);
        }

        // Listar jugadores de un equipo
        static void ListarJugadoresDeEquipo()
        {
            Console.Write("Ingrese ID del equipo: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("El ID del equipo debe ser un número entero.");
                return;
            }

            if (!equipos.ContainsKey(id))
            {
                Console.WriteLine("El equipo no existe.");
                return;
            }

            var equipo = equipos[id];
            Console.WriteLine($"\nJugadores del equipo {equipo.Nombre}:");

            if (equipo.Jugadores.Count == 0)
                Console.WriteLine("No hay jugadores en este equipo.");
            else
                foreach (var jugador in equipo.Jugadores)
                    Console.WriteLine(jugador);
        }

        // Buscar jugador en todos los equipos
        static void BuscarJugador()
        {
            Console.Write("Ingrese nombre del jugador: ");
            string nombre = Console.ReadLine();

            foreach (var equipo in equipos.Values)
            {
                foreach (var jugador in equipo.Jugadores)
                {
                    if (jugador.Nombre.Contains(nombre, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine($"{jugador} | Equipo: {equipo.Nombre}");
                        return;
                    }
                }
            }

            Console.WriteLine("Jugador no encontrado.");
        }

        // Eliminar equipo
        static void EliminarEquipo()
        {
            Console.Write("Ingrese ID del equipo a eliminar: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("El ID del equipo debe ser un número entero.");
                return;
            }

            if (equipos.Remove(id))
                Console.WriteLine("Equipo eliminado correctamente.");
            else
                Console.WriteLine("El equipo no existe.");
        }

        // Eliminar jugador
        static void EliminarJugador()
        {
            Console.Write("Ingrese ID del equipo: ");
            if (!int.TryParse(Console.ReadLine(), out int equipoId))
            {
                Console.WriteLine("El ID del equipo debe ser un número entero.");
                return;
            }

            if (!equipos.ContainsKey(equipoId))
            {
                Console.WriteLine("El equipo no existe.");
                return;
            }

            Console.Write("Ingrese ID del jugador a eliminar: ");
            if (!int.TryParse(Console.ReadLine(), out int idJugador))
            {
                Console.WriteLine("El ID del jugador debe ser un número entero.");
                return;
            }

            Jugador jugadorAEliminar = null;
            foreach (var j in equipos[equipoId].Jugadores)
            {
                if (j.Id == idJugador)
                {
                    jugadorAEliminar = j;
                    break;
                }
            }

            if (jugadorAEliminar != null && equipos[equipoId].Jugadores.Remove(jugadorAEliminar))
                Console.WriteLine("Jugador eliminado correctamente.");
            else
                Console.WriteLine("El jugador no existe en este equipo.");
        }
    }
}
