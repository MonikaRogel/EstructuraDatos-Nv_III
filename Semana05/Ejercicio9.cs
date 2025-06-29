using System;
using System.Collections.Generic;

namespace Semana05
{
    /// <summary>
    /// Ejercicio 9: Solicita una palabra al usuario y muestra cuántas veces aparece cada vocal.
    /// </summary>
    public class Ejercicio9
    {
        /// <summary>
        /// Método principal que ejecuta el ejercicio: muestra el enunciado,
        /// solicita la palabra, cuenta las vocales y muestra el resultado.
        /// </summary>
        public void Ejecutar()
        {
            MostrarEnunciado();
            string palabra = LeerPalabra();
            Dictionary<char, int> conteo = ContarVocales(palabra);
            MostrarResultado(conteo);
        }

        /// <summary>
        /// Muestra el enunciado del ejercicio según lo indicado por el docente.
        /// </summary>
        private void MostrarEnunciado()
        {
            Console.WriteLine("══════════════════════════════════════════════════════════");
            Console.WriteLine("Ejercicio 9 - Contar vocales en una palabra");
            Console.WriteLine("Escribir un programa que pida al usuario una palabra");
            Console.WriteLine("y muestre por pantalla el número de veces que contiene cada vocal.");
            Console.WriteLine("══════════════════════════════════════════════════════════\n");
        }

        /// <summary>
        /// Solicita al usuario una palabra y la convierte a minúsculas.
        /// </summary>
        /// <returns>Palabra ingresada en minúsculas (o cadena vacía si null).</returns>
        private string LeerPalabra()
        {
            Console.Write(" Ingresa una palabra: ");
            return Console.ReadLine()?.ToLower() ?? "";
        }

        /// <summary>
        /// Cuenta las vocales en la palabra dada.
        /// </summary>
        /// <param name="palabra">Palabra a analizar.</param>
        /// <returns>Diccionario con la cantidad de ocurrencias por vocal.</returns>
        private Dictionary<char, int> ContarVocales(string palabra)
        {
            Dictionary<char, int> vocales = new Dictionary<char, int>
            {
                { 'a', 0 }, { 'e', 0 }, { 'i', 0 }, { 'o', 0 }, { 'u', 0 }
            };

            foreach (char letra in palabra)
            {
                if (vocales.ContainsKey(letra))
                {
                    vocales[letra]++;
                }
            }

            return vocales;
        }

        /// <summary>
        /// Muestra en consola el conteo de vocales.
        /// </summary>
        /// <param name="conteo">Diccionario con el resultado del análisis.</param>
        private void MostrarResultado(Dictionary<char, int> conteo)
        {
            Console.WriteLine("\n Recuento de vocales:");
            foreach (var kvp in conteo)
            {
                Console.WriteLine($"- {kvp.Key}: {kvp.Value}");
            }
        }
    }
}
