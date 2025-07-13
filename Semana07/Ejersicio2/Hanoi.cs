using System;

namespace TorresDeHanoi
{
    /// Contiene la lógica para resolver el problema de las Torres de Hanoi
    /// utilizando tres torres (pilas) y una estrategia recursiva.
    public class Hanoi
    {
        private Torre origen, destino, auxiliar;
        private int numDiscos;
        private int contadorMovimientos = 0;

        /// Constructor que inicializa las torres y coloca los discos en la torre de origen.
        public Hanoi(int discos)
        {
            numDiscos = discos;
            origen = new Torre("A");
            destino = new Torre("C");
            auxiliar = new Torre("B");

            /// Se agregan los discos a la torre A, del más grande (abajo) al más pequeño (arriba).
            for (int i = discos; i >= 1; i--)
                origen.Apilar(new Disco(i));
        }

        /// Inicia la resolución del problema y muestra los pasos en consola.
        public void Resolver()
        {
            MostrarTorres();
            MoverDiscos(numDiscos, origen, destino, auxiliar);
            Console.WriteLine($"\nTotal de movimientos: {contadorMovimientos}");
        }

        /// Método recursivo para mover n discos desde una torre hacia otra,
        /// utilizando una torre auxiliar.
        private void MoverDiscos(int n, Torre desde, Torre hacia, Torre usando)
        {
            if (n == 1)
            {
                MoverUno(desde, hacia);
            }
            else
            {
                /// Mueve n-1 discos a la torre auxiliar.
                MoverDiscos(n - 1, desde, usando, hacia);

                /// Mueve el disco más grande al destino.
                MoverUno(desde, hacia);

                /// Mueve los n-1 discos desde la auxiliar al destino.
                MoverDiscos(n - 1, usando, hacia, desde);
            }
        }

        /// Realiza un solo movimiento de disco entre dos torres y lo muestra.
        private void MoverUno(Torre desde, Torre hacia)
        {
            Disco d = desde.Desapilar();
            hacia.Apilar(d);
            contadorMovimientos++;

            Console.WriteLine($"Mover disco {d} desde {desde.Nombre} hacia {hacia.Nombre}");
            MostrarTorres();
        }

        /// Muestra el estado actual de las tres torres.
        private void MostrarTorres()
        {
            origen.Mostrar();
            auxiliar.Mostrar();
            destino.Mostrar();
            Console.WriteLine("----------------------------");
        }
    }
}
