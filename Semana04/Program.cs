// Program.cs
using System;

/// <summary>
/// Clase principal del programa. Contiene el método Main, que ejecuta la lógica de interacción
/// del usuario con la agenda telefónica mediante un menú de consola.
/// </summary>
class Program
{
    static void Main(string[] args)
    {
        // Se crea una instancia de AgendaTelefonica con una capacidad máxima de 100 contactos
        AgendaTelefonica agenda = new AgendaTelefonica(100);
        bool salir = false;

        // Bucle principal para mantener activo el menú hasta que el usuario decida salir
        while (!salir)
        {
            // Muestra el menú principal
            Console.Clear();
            Console.WriteLine("==== AGENDA TELEFÓNICA ====");
            Console.WriteLine("1. Agregar contacto personal");
            Console.WriteLine("2. Agregar contacto profesional");
            Console.WriteLine("3. Agregar contacto de emergencia");
            Console.WriteLine("4. Mostrar todos los contactos");
            Console.WriteLine("5. Buscar por nombre");
            Console.WriteLine("6. Ordenar por nombre");
            Console.WriteLine("7. Ver contactos por tipo");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");
            string? opcion = Console.ReadLine();

            // Limpia la consola antes de ejecutar la acción seleccionada
            Console.Clear();

            // Ejecuta la acción correspondiente según la opción elegida
            switch (opcion)
            {
                case "1":
                    // Agrega un contacto personal
                    Console.Write("Nombre: ");
                    string? nombreP = Console.ReadLine() ?? "";
                    Console.Write("Teléfono: ");
                    string? telP = Console.ReadLine() ?? "";
                    Console.Write("Email: ");
                    string? emailP = Console.ReadLine() ?? "";
                    Console.Write("Relación: ");
                    string? relacion = Console.ReadLine() ?? "";
                    Console.Write("Cumpleaños (yyyy-mm-dd): ");
                    string? fechaCumple = Console.ReadLine();
                    if (!DateTime.TryParse(fechaCumple, out DateTime cumple))
                    {
                        Console.WriteLine("Fecha inválida.");
                        break;
                    }
                    agenda.AgregarContacto(new ContactoPersonal(nombreP, telP, emailP, relacion, cumple));
                    break;

                case "2":
                    // Agrega un contacto profesional
                    Console.Write("Nombre: ");
                    string? nombrePr = Console.ReadLine() ?? "";
                    Console.Write("Teléfono: ");
                    string? telPr = Console.ReadLine() ?? "";
                    Console.Write("Email: ");
                    string? emailPr = Console.ReadLine() ?? "";
                    Console.Write("Empresa: ");
                    string? empresa = Console.ReadLine() ?? "";
                    Console.Write("Cargo: ");
                    string? cargo = Console.ReadLine() ?? "";
                    agenda.AgregarContacto(new ContactoProfesional(nombrePr, telPr, emailPr, empresa, cargo));
                    break;

                case "3":
                    // Agrega un contacto de emergencia
                    Console.Write("Nombre: ");
                    string? nombreE = Console.ReadLine() ?? "";
                    Console.Write("Teléfono: ");
                    string? telE = Console.ReadLine() ?? "";
                    Console.Write("Email: ");
                    string? emailE = Console.ReadLine() ?? "";
                    Console.Write("Tipo de emergencia: ");
                    string? tipo = Console.ReadLine() ?? "";
                    Console.Write("Parentesco: ");
                    string? parentesco = Console.ReadLine() ?? "";
                    agenda.AgregarContacto(new ContactoEmergencia(nombreE, telE, emailE, tipo, parentesco));
                    break;

                case "4":
                    // Muestra todos los contactos almacenados en la agenda
                    agenda.MostrarContactos();
                    break;

                case "5":
                    // Permite buscar contactos por nombre
                    Console.Write("Ingrese el nombre a buscar: ");
                    string? buscar = Console.ReadLine() ?? "";
                    agenda.BuscarPorNombre(buscar);
                    break;

                case "6":
                    // Ordena los contactos alfabéticamente por nombre
                    agenda.OrdenarPorNombre();
                    break;

                case "7":
                    // Filtra y muestra los contactos según su tipo
                    Console.Write("Tipo (personal/profesional/emergencia): ");
                    string? tipoBuscar = Console.ReadLine() ?? "";
                    agenda.ObtenerContactosPorTipo(tipoBuscar);
                    break;

                case "0":
                    // Finaliza la ejecución del programa
                    salir = true;
                    break;

                default:
                    // Maneja cualquier opción no válida
                    Console.WriteLine("Opción no válida.");
                    break;
            }

            // Espera una tecla para continuar con el menú si no se ha salido
            if (!salir)
            {
                Console.WriteLine("\nPresione una tecla para continuar...");
                Console.ReadKey();
            }
        }
    }
}
