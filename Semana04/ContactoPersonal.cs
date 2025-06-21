// ContactoPersonal.cs
using System;

/// <summary>
/// Representa un contacto personal, que hereda de la clase Contacto.
/// Incluye datos adicionales como la relación con la persona y su fecha de cumpleaños.
/// </summary>
public class ContactoPersonal : Contacto
{
    /// <summary>
    /// Tipo de relación personal con el usuario (por ejemplo: amigo, hermana, pareja).
    /// </summary>
    public string Relacion { get; set; }

    /// <summary>
    /// Fecha de cumpleaños del contacto.
    /// </summary>
    public DateTime Cumpleanios { get; set; }

    /// <summary>
    /// Constructor de un contacto personal.
    /// </summary>
    /// <param name="nombre">Nombre del contacto.</param>
    /// <param name="telefono">Número de teléfono.</param>
    /// <param name="email">Correo electrónico.</param>
    /// <param name="relacion">Relación con el usuario.</param>
    /// <param name="cumpleanios">Fecha de cumpleaños.</param>
    public ContactoPersonal(string nombre, string telefono, string email, string relacion, DateTime cumpleanios)
        : base(nombre, telefono, email)
    {
        Relacion = relacion;
        Cumpleanios = cumpleanios;
    }

    /// <summary>
    /// Muestra la información del contacto personal en formato tabular.
    /// </summary>
    public override void Mostrar()
    {
        Console.WriteLine($"{Nombre,-15} | {Telefono,-12} | {Email,-20} | Personal   | {Relacion,-10} | {Cumpleanios.ToShortDateString()}");
    }
}
