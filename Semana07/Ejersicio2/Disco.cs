using System;

namespace TorresDeHanoi
{
    /// <summary>
    /// Representa un disco que se usa en las Torres de Hanoi.
    /// Cada disco tiene un tamaño que determina su prioridad.
    /// </summary>
    public class Disco
    {
        public int Tamaño { get; private set; }

        public Disco(int tamaño)
        {
            Tamaño = tamaño;
        }

        public override string ToString()
        {
            return Tamaño.ToString();
        }
    }
}
