using System;
using System.Collections.Generic;
using System.Linq;

namespace Semana05
{
    /// <summary>
    /// Ejercicio 10: Almacena una lista de precios y muestra el menor y el mayor.
    /// </summary>
    public class Ejercicio10
    {
        /// <summary>
        /// Lista de precios enteros.
        /// </summary>
        private readonly List<int> precios;

        /// <summary>
        /// Constructor que inicializa la lista con los precios dados.
        /// </summary>
        public Ejercicio10()
        {
            precios = new List<int> { 50, 75, 46, 22, 80, 65, 8 };
        }

        /// <summary>
        /// Método principal que ejecuta el ejercicio completo:
        /// muestra el enunciado, los precios y sus extremos.
        /// </summary>
        public void Ejecutar()
        {
            MostrarEnunciado();
            MostrarPrecios();
            MostrarExtremos();
        }

        /// <summary>
        /// Muestra en consola el enunciado del ejercicio para el usuario.
        /// </summary>
        private void MostrarEnunciado()
        {
            Console.WriteLine("══════════════════════════════════════════════════════════");
            Console.WriteLine("Ejercicio 10 - Análisis de precios");
            Console.WriteLine("Escribir un programa que almacene en una lista los siguientes precios:");
            Console.WriteLine("50, 75, 46, 22, 80, 65, 8");
            Console.WriteLine("y muestre por pantalla el menor y el mayor de los precios.");
            Console.WriteLine("══════════════════════════════════════════════════════════\n");
        }

        /// <summary>
        /// Muestra la lista completa de precios registrados.
        /// </summary>
        private void MostrarPrecios()
        {
            Console.WriteLine($"$ Precios registrados: {string.Join(", ", precios)}");
        }

        /// <summary>
        /// Calcula y muestra el precio más bajo y el más alto.
        /// </summary>
        private void MostrarExtremos()
        {
            int menor = precios.Min();
            int mayor = precios.Max();

            Console.WriteLine($"Precio más bajo: {menor}");
            Console.WriteLine($"Precio más alto: {mayor}");
        }
    }
}
