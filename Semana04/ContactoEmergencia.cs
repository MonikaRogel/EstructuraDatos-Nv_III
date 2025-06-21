// ContactoEmergencia.cs
using System;

/// <summary>
/// Representa un contacto de emergencia, que hereda de la clase Contacto.
/// Incluye información adicional como tipo de emergencia y parentesco.
/// </summary>
public class ContactoEmergencia : Contacto
{
    /// <summary>
    /// Tipo de emergencia para la que este contacto debe ser llamado (por ejemplo: médica, personal).
    /// </summary>
    public string TipoEmergencia { get; set; }

    /// <summary>
    /// Parentesco del contacto con la persona registrada (por ejemplo: madre, amigo, vecino).
    /// </summary>
    public string Parentesco { get; set; }

    /// <summary>
    /// Constructor del contacto de emergencia.
    /// </summary>
    /// <param name="nombre">Nombre del contacto.</param>
    /// <param name="telefono">Teléfono del contacto.</param>
    /// <param name="email">Correo electrónico del contacto.</param>
    /// <param name="tipoEmergencia">Tipo de emergencia que representa este contacto.</param>
    /// <param name="parentesco">Parentesco con el usuario.</param>
    public ContactoEmergencia(string nombre, string telefono, string email, string tipoEmergencia, string parentesco)
        : base(nombre, telefono, email)
    {
        TipoEmergencia = tipoEmergencia;
        Parentesco = parentesco;
    }

    /// <summary>
    /// Muestra la información formateada del contacto de emergencia.
    /// </summary>
    public override void Mostrar()
    {
        Console.WriteLine($"{Nombre,-15} | {Telefono,-12} | {Email,-20} | Emergencia | {TipoEmergencia,-10} | {Parentesco}");
    }
}
