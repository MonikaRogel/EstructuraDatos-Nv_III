// See https://aka.ms/new-console-template for more information
using SimuladorAtraccionConsola.Models;
using System;
using System.Text.RegularExpressions;

class Program
{
    // Creamos una instancia de la clase que maneja toda la lógica de la atracción.
    static Atraccion atraccion = new();

    // Usamos este contador para asignar un ID único a cada visitante nuevo.
    static int contadorVisitantes = 0;

    static void Main()
    {
        bool salir = false;

        // Bucle principal del programa: se repite hasta que el usuario elija salir.
        while (!salir)
        {
            MostrarMenu();  // Mostramos el menú con las estadísticas actuales

            Console.Write("\nSeleccione una opción: ");
            string? opcion = Console.ReadLine();

            // Según lo que elija el usuario, se ejecuta una acción.
            switch (opcion)
            {
                case "1":
                    AgregarVisitanteManual();
                    break;
                case "2":
                    MostrarCola();
                    break;
                case "3":
                    AsignarAsientos();
                    break;
                case "4":
                    MostrarResultado();
                    break;
                case "5":
                    GuardarEnArchivo();
                    break;
                case "6":
                    ReiniciarSimulacion();
                    break;
                case "7":
                    IngresoAsistido();
                    break;
                case "0":
                    salir = true;
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }

            Console.WriteLine("\nPresione ENTER para continuar...");
            Console.ReadLine();
        }
    }

    // Esta función muestra el menú principal con el estado actual del sistema.
    static void MostrarMenu()
    {
        Console.Clear();

        Console.WriteLine("**********************************************");
        Console.WriteLine("    Simulador de Atracción - Consola");
        Console.WriteLine("**********************************************");

        // Se muestra cuántas personas hay en cada parte del sistema.
        Console.WriteLine($"En fila: {atraccion.TotalCola}   Asignados: {atraccion.TotalAsignados}   En espera: {atraccion.TotalEnEspera}");
        Console.WriteLine("----------------------------------------------");

        Console.WriteLine("1. Agregar visitante a la fila (manual)");
        Console.WriteLine("2. Ver fila actual");
        Console.WriteLine("3. Asignar asientos");
        Console.WriteLine("4. Ver resultado de asignación");
        Console.WriteLine("5. Guardar resumen en archivo");
        Console.WriteLine("6. Reiniciar simulación");
        Console.WriteLine("7. Ingreso asistido de personas");
        Console.WriteLine("0. Salir");
    }

    // Esta opción permite ingresar una persona a la fila manualmente.
    static void AgregarVisitanteManual()
    {
        // Verificamos si ya se alcanzó la capacidad total (asignados + en cola).
        if (atraccion.TotalCola + atraccion.TotalAsignados >= Atraccion.Capacidad)
        {
            Console.WriteLine("La atracción ya está llena. No se pueden agregar más personas.");
            return;
        }

        Console.Write("\nIngrese el nombre del visitante: ");
        string? nombre = Console.ReadLine();

        // Validamos que el nombre no esté vacío y solo tenga letras y espacios.
        if (string.IsNullOrWhiteSpace(nombre) || !Regex.IsMatch(nombre, @"^[a-zA-Z\sáéíóúÁÉÍÓÚñÑ]+$"))
        {
            Console.WriteLine("El nombre debe contener solo letras y espacios.");
            return;
        }

        nombre = nombre.Trim();
        contadorVisitantes++;

        try
        {
            var persona = new Persona(contadorVisitantes, nombre);
            atraccion.AgregarALaCola(persona);
            Console.WriteLine($"{persona.Nombre} se ha unido a la fila.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            contadorVisitantes--;  // Si falla, retrocedemos el contador
        }
    }

    // Muestra en consola a todas las personas que están en la fila principal.
    static void MostrarCola()
    {
        var cola = atraccion.ObtenerColaPrincipal();

        if (cola.Count == 0)
        {
            Console.WriteLine("La fila está vacía.");
            return;
        }

        Console.WriteLine("\nFila actual:");
        foreach (var persona in cola)
        {
            Console.WriteLine($"- {persona}");
        }
    }

    // Asigna personas desde la cola principal hasta llenar los asientos disponibles.
    static void AsignarAsientos()
    {
        atraccion.AsignarAsientos();  // Se encarga de mover desde la cola a asignados

        var asignados = atraccion.ObtenerAsignados();

        if (asignados.Count == 0)
        {
            Console.WriteLine("No hay personas en la fila para asignar.");
            return;
        }

        Console.WriteLine("\nAsignación de asientos:");
        int asiento = 1;
        foreach (var persona in asignados)
        {
            Console.WriteLine($"Asiento #{asiento}: {persona.Nombre} (ID: {persona.Id})");
            asiento++;
        }
    }

    // Muestra tanto los que subieron como los que quedaron esperando.
    static void MostrarResultado()
    {
        var asignados = atraccion.ObtenerAsignados();
        var enEspera = atraccion.ObtenerColaEnEspera();

        Console.WriteLine($"\nPersonas que subieron ({asignados.Count}):");
        int asiento = 1;
        foreach (var persona in asignados)
        {
            Console.WriteLine($"Asiento #{asiento}: {persona.Nombre} (ID: {persona.Id})");
            asiento++;
        }

        Console.WriteLine($"\nPersonas en espera ({enEspera.Count}):");
        foreach (var persona in enEspera)
        {
            Console.WriteLine($"- {persona}");
        }
    }

    // Guarda en un archivo de texto el resumen de asignaciones y lista de espera.
    static void GuardarEnArchivo()
    {
        string ruta = "ResumenAsignacion.txt";
        atraccion.GuardarResumenEnArchivo(ruta);
        Console.WriteLine($"Resumen guardado en: {System.IO.Path.GetFullPath(ruta)}");
    }

    // Reinicia toda la simulación, como si fuera desde cero.
    static void ReiniciarSimulacion()
    {
        atraccion.Reiniciar();
        contadorVisitantes = 0;
        Console.WriteLine("Simulación reiniciada.");
    }

    // Permite ingresar varias personas de golpe, y maneja automáticamente si quedan en espera.
    static void IngresoAsistido()
    {
        int totalActual = atraccion.TotalCola + atraccion.TotalAsignados;
        int espacioDisponible = Atraccion.Capacidad - totalActual;

        // Si no hay espacio, no se puede ingresar a nadie.
        if (espacioDisponible <= 0)
        {
            Console.WriteLine("Todos los asientos ya han sido ocupados.");
            return;
        }

        Console.WriteLine($"\nActualmente hay {totalActual} personas en la fila.");
        Console.WriteLine($"Asientos disponibles: {espacioDisponible} de {Atraccion.Capacidad}\n");

        Console.Write("¿Cuántas personas deseas ingresar ahora?: ");
        if (!int.TryParse(Console.ReadLine(), out int cantidadDeseada) || cantidadDeseada <= 0)
        {
            Console.WriteLine("Cantidad no válida.");
            return;
        }

        int personasQueEntraran = Math.Min(cantidadDeseada, espacioDisponible);
        int personasEnEspera = Math.Max(cantidadDeseada - espacioDisponible, 0);
        int personasIngresadas = 0;

        // Si no hay suficientes lugares, lo informamos al usuario.
        if (personasEnEspera > 0)
        {
            Console.WriteLine($"Solo se agregarán {personasQueEntraran} personas a la fila.");
            Console.WriteLine($"Las otras {personasEnEspera} personas quedarán en espera.");
        }

        // Se ingresan las personas hasta llenar la capacidad disponible
        while ((atraccion.TotalCola + atraccion.TotalAsignados) < Atraccion.Capacidad && personasIngresadas < personasQueEntraran)
        {
            Console.Write($"Nombre de la persona #{personasIngresadas + 1}: ");
            string? nombre = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(nombre) || !Regex.IsMatch(nombre, @"^[a-zA-Z\sáéíóúÁÉÍÓÚñÑ]+$"))
            {
                Console.WriteLine("El nombre debe contener solo letras y espacios.");
                continue;
            }

            nombre = nombre.Trim();
            contadorVisitantes++;

            try
            {
                var persona = new Persona(contadorVisitantes, nombre);
                atraccion.AgregarALaCola(persona);
                Console.WriteLine($"{nombre} fue agregado correctamente.");
                personasIngresadas++;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                contadorVisitantes--;
            }
        }

        // Las personas que no alcanzaron lugar se agregan a la cola de espera.
        if (personasEnEspera > 0)
        {
            Console.WriteLine($"\nSe registrarán {personasEnEspera} personas en lista de espera:");

            for (int i = 0; i < personasEnEspera; i++)
            {
                Console.Write($"Nombre de la persona en espera #{i + 1}: ");
                string? nombre = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(nombre) || !Regex.IsMatch(nombre, @"^[a-zA-Z\sáéíóúÁÉÍÓÚñÑ]+$"))
                {
                    Console.WriteLine("El nombre debe contener solo letras y espacios.");
                    i--;
                    continue;
                }

                nombre = nombre.Trim();
                contadorVisitantes++;

                try
                {
                    var persona = new Persona(contadorVisitantes, nombre);
                    atraccion.AgregarAColaEnEspera(persona);
                    Console.WriteLine($"{nombre} fue registrado en lista de espera.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    contadorVisitantes--;
                    i--;
                }
            }
        }

        Console.WriteLine($"\nIngreso completado. Hay {Atraccion.Capacidad} personas en la fila o asignadas.");
    }
}
