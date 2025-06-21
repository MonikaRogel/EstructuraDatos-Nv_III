// Contacto.cs
using System;

/// <summary>
/// Clase base abstracta que representa un contacto genérico.
/// Contiene los campos comunes a todos los tipos de contactos.
/// </summary>
public abstract class Contacto
{
    /// <summary>
    /// Nombre completo del contacto.
    /// </summary>
    public string Nombre { get; set; }

    /// <summary>
    /// Número de teléfono del contacto.
    /// </summary>
    public string Telefono { get; set; }

    /// <summary>
    /// Correo electrónico del contacto.
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Constructor de la clase Contacto.
    /// </summary>
    /// <param name="nombre">Nombre del contacto.</param>
    /// <param name="telefono">Teléfono del contacto.</param>
    /// <param name="email">Correo electrónico del contacto.</param>
    public Contacto(string nombre, string telefono, string email)
    {
        Nombre = nombre;
        Telefono = telefono;
        Email = email;
    }

    /// <summary>
    /// Método abstracto que se implementa en las subclases para mostrar la información específica del contacto.
    /// </summary>
    public abstract void Mostrar();
}
