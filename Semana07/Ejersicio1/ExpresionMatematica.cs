namespace VerificadorPOO
{
    // Clase que representa una expresión matemática
    public class ExpresionMatematica
    {
        // Propiedad que contiene el texto de la expresión
        public string Contenido { get; }

        // Constructor que recibe la expresión
        public ExpresionMatematica(string contenido)
        {
            Contenido = contenido;
        }

        // Método que valida si la expresión está balanceada
        public bool EsBalanceada()
        {
            return ValidadorParentesis.EstaBalanceada(Contenido);
        }
    }
}
