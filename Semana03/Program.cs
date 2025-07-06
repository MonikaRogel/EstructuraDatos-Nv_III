using System;

class Estudiante
{
    // Atributos del estudiante
    public string Id { get; set; }
    public string Nombres { get; set; }
    public string Apellidos { get; set; }
    public string Direccion { get; set; }
    // Array de teléfonos
    public string[] Telefonos { get; set; }
    // Constructor
    public Estudiante(string id, string nombres, string apellidos, string direccion, string[] telefonos)
    {
        Id = id;
        Nombres = nombres;
        Apellidos = apellidos;
        Direccion = direccion;
        Telefonos = telefonos;
    }
    // Método para mostrar los datos
    public void MostrarInformacion()
    {
        Console.WriteLine("============================================");
        Console.WriteLine("         REGISTRO DE DATOS DEL ESTUDIANTE");
        Console.WriteLine("============================================");
        Console.WriteLine($"- ID: {Id}");
        Console.WriteLine($"- Nombres: {Nombres}");
        Console.WriteLine($"- Apellidos: {Apellidos}");
        Console.WriteLine($"- Dirección: {Direccion}");
        Console.WriteLine("- Teléfonos:");
        for (int i = 0; i < Telefonos.Length; i++)
        {
            Console.WriteLine($"    • Teléfono {i + 1}: {Telefonos[i]}");
        }
        Console.WriteLine("============================================");
        Console.WriteLine("   Fin del registro.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Crear un estudiante con sus datos
        string[] telefonos = { "0933903268", "0273456213", "0935674530"  };
        Estudiante estudiante = new Estudiante("202501", "Monik Betzy", "Royel Quirog", "Cuenca - Fermín Caballero", telefonos);

        // Mostrar la información
        estudiante.MostrarInformacion();
    }
}

