using System;

namespace SimuladorAtraccionConsola.Models
{
    // Esta clase representa a una persona que quiere entrar a la atracción.
    // Se le asigna un ID único, se registra su nombre, y se guarda la hora exacta de ingreso.
    public class Persona
    {
        public int Id { get; }  // Identificador único para evitar duplicados
        public string Nombre { get; }  // Nombre de la persona
        public DateTime TimestampIngreso { get; }  // Hora en la que fue registrada

        public Persona(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
            TimestampIngreso = DateTime.Now;
        }

        // Permite mostrar los datos de la persona de forma legible en consola
        public override string ToString()
        {
            return $"{Nombre} (ID: {Id}, Ingreso: {TimestampIngreso:HH:mm:ss})";
        }
    }
}


