using System.Collections.Generic;

namespace VerificadorPOO
{
    // Clase estática que valida si los paréntesis están balanceados
    public static class ValidadorParentesis
    {
        // Método principal que usa una pila para verificar la expresión
        public static bool EstaBalanceada(string expresion)
        {
            var pila = new Stack<char>();

            foreach (char c in expresion)
            {
                if (EsApertura(c))
                {
                    pila.Push(c); // Agrega símbolo de apertura a la pila
                }
                else if (EsCierre(c))
                {
                    // Si no hay apertura previa o no coincide con el último abierto
                    if (pila.Count == 0 || !EsPareja(pila.Pop(), c))
                        return false;
                }
            }

            // Si la pila queda vacía, la expresión está correctamente balanceada
            return pila.Count == 0;
        }

        // Verifica si es un símbolo de apertura: (, {, [
        private static bool EsApertura(char c) =>
            c == '(' || c == '{' || c == '[';

        // Verifica si es un símbolo de cierre: ), }, ]
        private static bool EsCierre(char c) =>
            c == ')' || c == '}' || c == ']';

        // Verifica si un símbolo de cierre hace pareja con el de apertura
        private static bool EsPareja(char apertura, char cierre)
        {
            return (apertura == '(' && cierre == ')') ||
                   (apertura == '{' && cierre == '}') ||
                   (apertura == '[' && cierre == ']');
        }
    }
}
