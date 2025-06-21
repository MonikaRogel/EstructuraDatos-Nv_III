// ContactoProfesional.cs
using System;

/// <summary>
/// Representa un contacto profesional, que hereda de la clase Contacto.
/// Incluye información laboral como empresa y cargo que ocupa.
/// </summary>
public class ContactoProfesional : Contacto
{
    /// <summary>
    /// Nombre de la empresa donde trabaja el contacto.
    /// </summary>
    public string Empresa { get; set; }

    /// <summary>
    /// Cargo o posición que ocupa el contacto en la empresa.
    /// </summary>
    public string Cargo { get; set; }

    /// <summary>
    /// Constructor del contacto profesional.
    /// </summary>
    /// <param name="nombre">Nombre del contacto.</param>
    /// <param name="telefono">Número de teléfono.</param>
    /// <param name="email">Correo electrónico.</param>
    /// <param name="empresa">Nombre de la empresa.</param>
    /// <param name="cargo">Cargo que ocupa en la empresa.</param>
    public ContactoProfesional(string nombre, string telefono, string email, string empresa, string cargo)
        : base(nombre, telefono, email)
    {
        Empresa = empresa;
        Cargo = cargo;
    }

    /// <summary>
    /// Muestra la información del contacto profesional en formato tabular.
    /// </summary>
    public override void Mostrar()
    {
        Console.WriteLine($"{Nombre,-15} | {Telefono,-12} | {Email,-20} | Profesional | {Empresa,-12} | {Cargo}");
    }
}
