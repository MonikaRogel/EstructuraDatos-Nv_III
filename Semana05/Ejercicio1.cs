using System;
using System.Collections.Generic;

namespace Semana05
{
    /// <summary>
    /// Clase que representa el ejercicio 1: mostrar las asignaturas del curso.
    /// Refactorizada para utilizar una clase `Asignatura`.
    /// </summary>
    public class Ejercicio1
    {
        // Lista de objetos Asignatura
        private readonly List<Asignatura> asignaturas;

        /// <summary>
        /// Inicializa la lista con asignaturas específicas del nivel III.
        /// </summary>
        public Ejercicio1()
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
        /// Ejecuta el flujo principal del ejercicio.
        /// </summary>
        public void Ejecutar()
        {
            MostrarEnunciado();
            MostrarAsignaturas();
            MostrarDespedida();
        }

        /// <summary>
        /// Muestra el enunciado del ejercicio.
        /// </summary>
        private void MostrarEnunciado()
        {
            Console.WriteLine("══════════════════════════════════════════════════════════");
            Console.WriteLine("Ejercicio 1 - Mostrar asignaturas");
            Console.WriteLine("Escribir un programa que almacene las asignaturas de un curso (por ejemplo: ");
            Console.WriteLine("Matemáticas, Física, Química, Historia y Lengua) en una lista y la muestre por pantalla.");
            Console.WriteLine("Se personalizó según mis asignaturas");
            Console.WriteLine("══════════════════════════════════════════════════════════\n");
        }

        /// <summary>
        /// Muestra las asignaturas enumeradas por consola.
        /// </summary>
        private void MostrarAsignaturas()
        {
            for (int i = 0; i < asignaturas.Count; i++)
            {
                Console.WriteLine($"  {i + 1}. {asignaturas[i]}");
            }
        }

        /// <summary>
        /// Muestra un mensaje de cierre.
        /// </summary>
        private void MostrarDespedida()
        {
            Console.WriteLine("\n ¡Asignaturas del nivel III según la malla curricular!");
        }
    }
}
