using System;
using System.Collections.Generic;

namespace Semana05
{
    /// <summary>
    /// Ejercicio 2: Mostrar asignaturas con el mensaje personalizado "Yo estudio &lt;asignatura&gt;".
    /// Esta clase ilustra cómo recorrer una lista de objetos y mostrar información personalizada.
    /// </summary>
    public class Ejercicio2
    {
        /// <summary>
        /// Lista de asignaturas del curso. Cada asignatura es un objeto de tipo <see cref="Asignatura"/>.
        /// </summary>
        private readonly List<Asignatura> asignaturas;

        /// <summary>
        /// Constructor que inicializa la lista con asignaturas predeterminadas.
        /// </summary>
        public Ejercicio2()
        {
            asignaturas = new List<Asignatura>
            {
                new Asignatura("Instalaciones Eléctricas/Cableado Estructurado"),
                new Asignatura("Estructura de Datos"),
                new Asignatura("Sistemas Digitales"),
                new Asignatura("Metodologías de la Investigación"),
                new Asignatura("Sistemas Operativos")
            };
        }

        /// <summary>
        /// Método principal que ejecuta el ejercicio:
        /// muestra el enunciado, recorre la lista de asignaturas y presenta los mensajes.
        /// </summary>
        public void Ejecutar()
        {
            MostrarEnunciado();

            Console.WriteLine("Conoce tus materias:\n");

            foreach (var asignatura in asignaturas)
            {
                Console.WriteLine($"Yo estudio {asignatura.Nombre}.");
            }

            Console.WriteLine("\n¡Felicitaciones, sigue así! 🎓");
        }

        /// <summary>
        /// Muestra en consola el enunciado del ejercicio según lo indicado por el docente.
        /// </summary>
        private void MostrarEnunciado()
        {
            Console.WriteLine("══════════════════════════════════════════════════════════");
            Console.WriteLine("Ejercicio 2 - Mostrar asignaturas personalizadas");
            Console.WriteLine("Escribir un programa que almacene las asignaturas de un curso");
            Console.WriteLine("(por ejemplo Matemáticas, Física, Química, Historia y Lengua)");
            Console.WriteLine("en una lista y muestre el mensaje: Yo estudio <asignatura>");
            Console.WriteLine("══════════════════════════════════════════════════════════\n");
        }
    }
}
