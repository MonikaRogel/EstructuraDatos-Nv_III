namespace Semana05
{
    /// <summary>
    /// Representa una asignatura con su nombre.
    /// Puede ampliarse en el futuro con más propiedades (créditos, docente, etc.).
    /// </summary>
    public class Asignatura
    {
        public string Nombre { get; }

        public Asignatura(string nombre)
        {
            Nombre = nombre;
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
