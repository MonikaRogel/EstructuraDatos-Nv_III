// See https://aka.ms/new-console-template for more information
using System;

namespace VerificadorPOO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Cambia el título de la ventana de consola
            Console.Title = "Verificación de Paréntesis Balanceados - POO";

            // Muestra el enunciado del problema
            MostrarEnunciado();

            // Muestra el menú principal
            var menu = new MenuConsola();
            menu.Mostrar();
        }

        // Método que muestra al usuario de qué trata el ejercicio
        private static void MostrarEnunciado()
        {
            Console.WriteLine("══════════════════════════════════════════════════════════════════");
            Console.WriteLine("Ejercicio: Verificación de paréntesis balanceados en C#");
            Console.WriteLine("──────────────────────────────────────────────────────────────────");
            Console.WriteLine("Desarrollar un programa que determine si los paréntesis (),");
            Console.WriteLine("llaves {} y corchetes [] en una expresión matemática están");
            Console.WriteLine("correctamente balanceados.");
            Console.WriteLine("Ejemplo:");
            Console.WriteLine("Entrada: {7 + (8 * 5) - [(9 - 7) + (4 + 1)]}");
            Console.WriteLine("Salida esperada: Fórmula balanceada.");
            Console.WriteLine("══════════════════════════════════════════════════════════════════\n");
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
