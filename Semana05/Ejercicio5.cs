using System;
using System.Collections.Generic;

namespace Semana05
{
    /// <summary>
    /// Ejercicio 5: Mostrar los números del 1 al 10 en orden inverso, separados por comas.
    /// Aplicación de principios de programación orientada a objetos.
    /// </summary>
    public class Ejercicio5
    {
        /// <summary>
        /// Lista que almacena los números del 1 al 10.
        /// </summary>
        private readonly List<int> numeros;

        /// <summary>
        /// Constructor que inicializa la lista con los números del 1 al 10.
        /// </summary>
        public Ejercicio5()
        {
            numeros = new List<int>();
            InicializarNumeros();
        }

        /// <summary>
        /// Método principal que ejecuta el ejercicio completo.
        /// Muestra el enunciado, invierte los números y los presenta al usuario.
        /// </summary>
        public void Ejecutar()
        {
            MostrarEnunciado();
            Console.WriteLine(" Lista invertida del 1 al 10:");
            Console.WriteLine(string.Join(", ", ObtenerNumerosInvertidos()));
        }

        /// <summary>
        /// Muestra en consola el enunciado del ejercicio tal como lo planteó el docente.
        /// </summary>
        private void MostrarEnunciado()
        {
            Console.WriteLine("══════════════════════════════════════════════════════════");
            Console.WriteLine("Ejercicio 5 - Mostrar números en orden inverso");
            Console.WriteLine("Escribir un programa que almacene en una lista los números del 1 al 10");
            Console.WriteLine("y los muestre por pantalla en orden inverso separados por comas.");
            Console.WriteLine("══════════════════════════════════════════════════════════\n");
        }

        /// <summary>
        /// Llena la lista con los números del 1 al 10.
        /// </summary>
        private void InicializarNumeros()
        {
            for (int i = 1; i <= 10; i++)
            {
                numeros.Add(i);
            }
        }

        /// <summary>
        /// Devuelve una copia de la lista con los números invertidos.
        /// </summary>
        /// <returns>Lista invertida de enteros.</returns>
        private List<int> ObtenerNumerosInvertidos()
        {
            List<int> copiaInvertida = new List<int>(numeros);
            copiaInvertida.Reverse();
            return copiaInvertida;
        }
    }
}

