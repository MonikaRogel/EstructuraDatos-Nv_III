using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Semana11
{
    /// <summary>
    /// Clase que maneja la lógica de traducción Español ↔ Inglés.
    /// Utiliza dos diccionarios: uno para español → inglés y otro para inglés → español.
    /// </summary>
    public class Traductor
    {
        private readonly Dictionary<string, string> _espanolIngles;
        private readonly Dictionary<string, string> _inglesEspanol;

        public Traductor()
        {
            _espanolIngles = new Dictionary<string, string>();
            _inglesEspanol = new Dictionary<string, string>();
            InicializarDiccionario();
        }

        /// <summary>
        /// Inicializa el diccionario con palabras sugeridas.
        /// </summary>
        private void InicializarDiccionario()
        {
            AgregarPalabra("tiempo", "time");
            AgregarPalabra("persona", "person");
            AgregarPalabra("año", "year");
            AgregarPalabra("camino", "way");
            AgregarPalabra("día", "day");
            AgregarPalabra("cosa", "thing");
            AgregarPalabra("hombre", "man");
            AgregarPalabra("mundo", "world");
            AgregarPalabra("vida", "life");
            AgregarPalabra("mano", "hand");
            AgregarPalabra("parte", "part");
            AgregarPalabra("niño", "child");
            AgregarPalabra("ojo", "eye");
            AgregarPalabra("mujer", "woman");
            AgregarPalabra("lugar", "place");
            AgregarPalabra("trabajo", "work");
            AgregarPalabra("semana", "week");
            AgregarPalabra("caso", "case");
            AgregarPalabra("punto", "point");
            AgregarPalabra("gobierno", "government");
            AgregarPalabra("empresa", "company");
        }

        /// <summary>
        /// Agrega o actualiza una palabra en ambos diccionarios.
        /// </summary>
        public void AgregarPalabra(string palabraEspanol, string palabraIngles)
        {
            string esLower = palabraEspanol.Trim().ToLower();
            string enLower = palabraIngles.Trim().ToLower();

            _espanolIngles[esLower] = enLower;
            _inglesEspanol[enLower] = esLower;
        }

        /// <summary>
        /// Traduce una frase completa. Solo reemplaza las palabras registradas.
        /// </summary>
        public string TraducirFrase(string frase, string idioma)
        {
            string idiomaNormalizado = NormalizarIdioma(idioma);

            Dictionary<string, string>? diccionario = idiomaNormalizado switch
            {
                "espanol" => _espanolIngles,
                "ingles" => _inglesEspanol,
                _ => null
            };

            if (diccionario == null)
                return "Idioma no válido. Debe escribir 'español/espanol' o 'inglés/ingles'.";

            // Dividir por espacios y signos de puntuación, respetando letras con tildes
            string[] partes = Regex.Split(frase, @"(\W+)");
            List<string> resultado = new();

            foreach (string parte in partes)
            {
                string palabraLimpia = parte.ToLower();
                if (diccionario.ContainsKey(palabraLimpia))
                {
                    string traduccion = diccionario[palabraLimpia];

                    // Respetar mayúsculas iniciales
                    if (!string.IsNullOrEmpty(parte) && char.IsUpper(parte[0]))
                        traduccion = Capitalizar(traduccion);

                    resultado.Add(traduccion);
                }
                else
                {
                    resultado.Add(parte);
                }
            }

            return string.Join("", resultado);
        }

        /// <summary>
        /// Normaliza el idioma escrito por el usuario (quita tildes, pasa a minúsculas).
        /// </summary>
        private string NormalizarIdioma(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return "";

            string t = texto.Trim().ToLower();
            t = t.Replace("á", "a")
                 .Replace("é", "e")
                 .Replace("í", "i")
                 .Replace("ó", "o")
                 .Replace("ú", "u");

            if (t.Contains("espan")) return "espanol";
            if (t.Contains("ingl")) return "ingles";
            return t;
        }

        /// <summary>
        /// Convierte la primera letra de una palabra en mayúscula.
        /// </summary>
        private string Capitalizar(string palabra)
        {
            if (string.IsNullOrEmpty(palabra)) return palabra;
            return char.ToUpper(palabra[0]) + palabra.Substring(1);
        }
    }
}


