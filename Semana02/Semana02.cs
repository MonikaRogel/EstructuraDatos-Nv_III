using System;

// Clase para el Círculo
public class Circulo
{
    private double radio; // Dato primitivo encapsulado: radio del círculo

    // Constructor que inicializa el radio
    public Circulo(double r)
    {
        radio = r;
    }

    // CalcularArea devuelve el área del círculo usando la fórmula π * radio²
    public double CalcularArea()
    {
        return Math.PI * radio * radio;
    }

    // CalcularPerimetro devuelve la circunferencia usando la fórmula 2 * π * radio
    public double CalcularPerimetro()
    {
        return 2 * Math.PI * radio;
    }
}

// Clase para el Rectángulo
public class Rectangulo
{
    private double baseRect;   // Dato primitivo encapsulado: base del rectángulo
    private double altura;     // Dato primitivo encapsulado: altura del rectángulo

    // Constructor que inicializa base y altura
    public Rectangulo(double b, double h)
    {
        baseRect = b;
        altura = h;
    }

    // CalcularArea devuelve el área del rectángulo usando base * altura
    public double CalcularArea()
    {
        return baseRect * altura;
    }

    // CalcularPerimetro devuelve el perímetro usando 2*(base + altura)
    public double CalcularPerimetro()
    {
        return 2 * (baseRect + altura);
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Crear un círculo con radio 5
        Circulo miCirculo = new Circulo(5);
        Console.WriteLine("CÍRCULO:");
        Console.WriteLine($"Área: {miCirculo.CalcularArea():F2}");        // 78.54
        Console.WriteLine($"Perímetro: {miCirculo.CalcularPerimetro():F2}"); // 31.42
        
        Console.WriteLine("\n-----------------------------\n");
        
        // Crear un rectángulo de 6x4
        Rectangulo miRectangulo = new Rectangulo(6, 4);
        Console.WriteLine("RECTÁNGULO:");
        Console.WriteLine($"Área: {miRectangulo.CalcularArea()}");          // 24
        Console.WriteLine($"Perímetro: {miRectangulo.CalcularPerimetro()}"); // 20
    }
}