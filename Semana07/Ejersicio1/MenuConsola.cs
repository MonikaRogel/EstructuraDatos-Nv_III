using System;

namespace VerificadorPOO
{
    /// <summary>
    /// Esta clase representa un menú de consola para interactuar con el usuario.
    /// Permite verificar si una fórmula matemática tiene sus paréntesis balanceados.
    /// </summary>
    public class MenuConsola
    {
        /// <summary>
        /// Muestra el menú principal y gestiona la interacción con el usuario.
        /// El usuario puede elegir entre verificar una fórmula o salir del programa.
        /// </summary>
        public void Mostrar()
        {
            bool salir = false;

            // Bucle principal del menú. Se repite hasta que el usuario elija salir.
            while (!salir)
            {
                // Dibujamos el menú en pantalla
                Console.WriteLine("╔════════════════════════════════════════╗");
                Console.WriteLine("║     Menú de Validación de Expresiones  ║");
                Console.WriteLine("╠════════════════════════════════════════╣");
                Console.WriteLine("║ 1. Verificar fórmula matemática        ║");
                Console.WriteLine("║ 2. Salir                               ║");
                Console.WriteLine("╚════════════════════════════════════════╝");
                Console.Write("Ingrese una opción: ");

                // Leemos la opción del usuario. Si es null, usamos cadena vacía.
                string opcion = Console.ReadLine() ?? string.Empty;
                Console.Clear();

                // Procesamos la opción seleccionada
                switch (opcion)
                {
                    case "1":
                        Validar(); // Llama al método que valida la fórmula
                        break;
                    case "2":
                        Console.WriteLine("Gracias por usar el sistema.");
                        salir = true; // Se termina el bucle
                        break;
                    default:
                        Console.WriteLine("Opción inválida."); // Caso de error
                        break;
                }

                // Si no se eligió salir, esperamos que el usuario presione una tecla
                if (!salir)
                {
                    Console.WriteLine("\nPresione una tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        /// <summary>
        /// Solicita al usuario una expresión matemática, la valida usando el sistema
        /// de pilas, y muestra en pantalla si está o no balanceada.
        /// </summary>
        private void Validar()
        {
            Console.WriteLine("VALIDACIÓN DE EXPRESIÓN MATEMÁTICA");
            Console.WriteLine("--------------------------------------");
            Console.Write("Ingrese la expresión matemática: ");

            // Leemos la entrada del usuario. Si es null, usamos cadena vacía.
            string input = Console.ReadLine() ?? string.Empty;

            // Creamos una instancia de ExpresionMatematica con el texto ingresado
            var expresion = new ExpresionMatematica(input);

            // Mostramos el resultado al usuario según esté o no balanceada
            if (expresion.EsBalanceada())
                Console.WriteLine("\n Fórmula balanceada.");
            else
                Console.WriteLine("\n Fórmula NO balanceada.");
        }
    }
}

