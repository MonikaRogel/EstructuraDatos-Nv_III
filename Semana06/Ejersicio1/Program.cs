// See https://aka.ms/new-console-template for more information
using System;
/*
2.  Invertir una lista enlazada:
    Implementar un método dentro de la lista enlazada que permita invertir los datos 
    almacenados en una lista enlazada, es decir que el primer elemento pase a ser el último 
    y el último pase a ser el primero, que el segundo sea el penúltimo y el penúltimo 
    pase a ser el segundo y así sucesivamente.
*/
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("============================================================");
        Console.WriteLine("       2525 - ESTRUCTURA DE DATOS - UEA / SEMANA 06");
        Console.WriteLine("------------------------------------------------------------");
        Console.WriteLine("        Ejercicio 2: Invertir una lista enlazada simple");
        Console.WriteLine("============================================================\n");
        // Crear una lista enlazada y agregar valores
        ListaEnlazada lista = new ListaEnlazada();
        lista.Agregar(10);
        lista.Agregar(20);
        lista.Agregar(30);
        lista.Agregar(40);
        lista.Agregar(50);
        // Mostrar la lista original
        Console.WriteLine(">> Lista original:");
        lista.Mostrar();
        // Invertir la lista
        Console.WriteLine("\n>> Invirtiendo la lista...");
        lista.Invertir();
        // Mostrar la lista invertida
        Console.WriteLine(">> Lista invertida:");
        lista.Mostrar();
    }
}
