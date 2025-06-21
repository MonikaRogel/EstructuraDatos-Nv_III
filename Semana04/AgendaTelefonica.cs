// AgendaTelefonica.cs
using System;

/// <summary>
/// Clase principal que administra una agenda de contactos. 
/// Permite agregar, mostrar, buscar, ordenar y filtrar contactos según su tipo.
/// </summary>
public class AgendaTelefonica
{
    private Contacto[] contactos;  // Arreglo que almacena los contactos
    private int contador;          // Número actual de contactos registrados

    /// <summary>
    /// Constructor de la clase AgendaTelefonica.
    /// </summary>
    /// <param name="capacidad">Cantidad máxima de contactos que puede almacenar.</param>
    public AgendaTelefonica(int capacidad)
    {
        contactos = new Contacto[capacidad];
        contador = 0;
    }

    /// <summary>
    /// Agrega un nuevo contacto a la agenda si hay espacio disponible.
    /// </summary>
    /// <param name="c">Contacto a agregar.</param>
    public void AgregarContacto(Contacto c)
    {
        if (contador < contactos.Length)
        {
            contactos[contador++] = c;
            Console.WriteLine("Contacto agregado con éxito.");
        }
        else
        {
            Console.WriteLine("Agenda llena. No se pueden agregar más contactos.");
        }
    }

    /// <summary>
    /// Muestra todos los contactos de la agenda en formato tabular.
    /// </summary>
    public void MostrarContactos()
    {
        if (contador == 0)
        {
            Console.WriteLine("\nLa agenda está vacía.");
            return;
        }

        Console.WriteLine("\nLISTADO DE TODOS LOS CONTACTOS\n");
        Console.WriteLine($"{"Nombre",-15} | {"Teléfono",-12} | {"Email",-20} | {"Tipo",-11} | Info Adicional");
        Console.WriteLine(new string('-', 85));

        for (int i = 0; i < contador; i++)
        {
            contactos[i].Mostrar();
        }
    }

    /// <summary>
    /// Ordena los contactos alfabéticamente por nombre.
    /// </summary>
    public void OrdenarPorNombre()
    {
        Array.Sort(contactos, 0, contador, Comparer<Contacto>.Create(
            (a, b) => string.Compare(a.Nombre, b.Nombre, StringComparison.OrdinalIgnoreCase)
        ));
        Console.WriteLine("\nContactos ordenados alfabéticamente por nombre.");
    }

    /// <summary>
    /// Busca y muestra contactos cuyo nombre contenga el texto especificado (no distingue mayúsculas).
    /// </summary>
    /// <param name="nombre">Texto a buscar dentro del nombre del contacto.</param>
    public void BuscarPorNombre(string nombre)
    {
        Console.WriteLine($"\nResultados de búsqueda para: \"{nombre}\"");
        bool encontrado = false;

        for (int i = 0; i < contador; i++)
        {
            if (contactos[i].Nombre.IndexOf(nombre, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                contactos[i].Mostrar();
                encontrado = true;
            }
        }

        if (!encontrado)
        {
            Console.WriteLine("No se encontró ningún contacto con ese nombre.");
        }
    }

    /// <summary>
    /// Filtra y muestra todos los contactos de un tipo específico: personal, profesional o emergencia.
    /// </summary>
    /// <param name="tipo">Tipo de contacto a mostrar.</param>
    public void ObtenerContactosPorTipo(string tipo)
    {
        Console.WriteLine($"\nContactos del tipo: {tipo}");
        bool encontrado = false;

        for (int i = 0; i < contador; i++)
        {
            if ((tipo.ToLower() == "personal" && contactos[i] is ContactoPersonal) ||
                (tipo.ToLower() == "profesional" && contactos[i] is ContactoProfesional) ||
                (tipo.ToLower() == "emergencia" && contactos[i] is ContactoEmergencia))
            {
                contactos[i].Mostrar();
                encontrado = true;
            }
        }

        if (!encontrado)
        {
            Console.WriteLine("No se encontraron contactos de ese tipo.");
        }
    }
}

