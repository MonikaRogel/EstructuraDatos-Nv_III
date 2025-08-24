// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;

namespace VacunacionCOVID
{
    class Program
    {
        // Instancia global de Random para seleccionar ciudadanos de forma aleatoria
        static Random random = new Random();

        static void Main(string[] args)
        {
            Console.WriteLine("2525 - ESTRUCTURA DE DATOS - UEA / SEMANA 10\n");

            // 1. Conjunto universal U (500 ciudadanos)
            // Aquí genero a todos los ciudadanos que forman parte del universo U.
            // Cada ciudadano tiene un identificador en forma de cadena "Ciudadano X".
            HashSet<string> U = new HashSet<string>();
            for (int i = 1; i <= 500; i++)
                U.Add("Ciudadano " + i);

            // 2. Subconjuntos de vacunados (A = Pfizer, B = AstraZeneca)
            // A representa el conjunto de vacunados con Pfizer.
            // B representa el conjunto de vacunados con AstraZeneca.
            // Cada conjunto contiene 75 ciudadanos seleccionados al azar dentro del universo U.
            HashSet<string> A = GenerarVacunados(U, 75); // Pfizer
            HashSet<string> B = GenerarVacunados(U, 75); // AstraZeneca

            // 3. Operaciones de teoría de conjuntos
            // En este punto aplico la teoría de conjuntos para obtener los listados solicitados.

            // vacunados = (A ∪ B)
            // La unión de A y B me da a todos los vacunados (con cualquiera de las dos vacunas).
            var vacunados = new HashSet<string>(A);
            vacunados.UnionWith(B);

            // no vacunados = U – (A ∪ B)
            // La diferencia entre el universo U y los vacunados me da los no vacunados.
            var noVacunados = new HashSet<string>(U);
            noVacunados.ExceptWith(vacunados);

            // ambas dosis = A ∩ B
            // La intersección entre A y B me da los ciudadanos que recibieron ambas dosis.
            var ambasDosis = new HashSet<string>(A);
            ambasDosis.IntersectWith(B);

            // solo Pfizer = A – B
            // Los que están en Pfizer pero no en AstraZeneca corresponden a los vacunados solo con Pfizer.
            var soloPfizer = new HashSet<string>(A);
            soloPfizer.ExceptWith(B);

            // solo AstraZeneca = B – A
            // Los que están en AstraZeneca pero no en Pfizer corresponden a los vacunados solo con AstraZeneca.
            var soloAstra = new HashSet<string>(B);
            soloAstra.ExceptWith(A);

            // 4. Resultados
            // Finalmente muestro los resultados por consola, indicando el total de ciudadanos
            // y cuántos pertenecen a cada categoría definida por las operaciones de conjuntos.
            Console.WriteLine("=== Campaña de Vacunación COVID-19 ===");
            Console.WriteLine($"Total ciudadanos (U): {U.Count}");
            Console.WriteLine($"Vacunados con Pfizer (A): {A.Count}");
            Console.WriteLine($"Vacunados con AstraZeneca (B): {B.Count}");
            Console.WriteLine($"No vacunados (U – (A ∪ B)): {noVacunados.Count}");
            Console.WriteLine($"Ambas dosis (A ∩ B): {ambasDosis.Count}");
            Console.WriteLine($"Solo Pfizer (A – B): {soloPfizer.Count}");
            Console.WriteLine($"Solo AstraZeneca (B – A): {soloAstra.Count}");
        }

        // Método para generar ciudadanos vacunados de manera aleatoria
        // Aquí recibo como parámetro el universo U y la cantidad que necesito seleccionar.
        // Utilizo un ciclo while hasta completar la cantidad solicitada, seleccionando
        // índices aleatorios de la lista de ciudadanos del universo.
        static HashSet<string> GenerarVacunados(HashSet<string> universo, int cantidad)
        {
            HashSet<string> conjunto = new HashSet<string>();
            var lista = new List<string>(universo);

            while (conjunto.Count < cantidad)
            {
                int index = random.Next(lista.Count);
                conjunto.Add(lista[index]);
            }
            return conjunto;
        }
    }
}

