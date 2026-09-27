// F1-05 async/await dedicado con Main, sin JSON ni LINQ
// async — QUÉ ES: método que puede esperar sin bloquear / POR QUÉ: disco y red tardan, no quieres congelar app
// await — QUÉ ES: espera aquí hasta que termine / POR QUÉ: sin await seguirías con archivo a medias
// Task — QUÉ ES: promesa de trabajo futuro / POR QUÉ: async siempre devuelve Task

using System;
using System.IO;
using System.Threading.Tasks;

class Program
{
    static async Task Main() // Main async para poder usar await dentro
    {
        Console.WriteLine("1 Inicio");

        await Esperar(1000); // Espera 1s sin bloquear. Si fuera Thread.Sleep bloquearía.
        Console.WriteLine("2 Tras esperar 1s");

        await File.WriteAllTextAsync("saludo.txt", "Hola async"); // Escribe esperando
        Console.WriteLine("3 Archivo escrito");

        string texto = await File.ReadAllTextAsync("saludo.txt"); // Lee esperando
        Console.WriteLine($"4 Leído: {texto}");
    }

    static async Task Esperar(int ms)
    {
        await Task.Delay(ms); // Delay — QUÉ ES: espera falsa / POR QUÉ: simula disco/red sin archivo real
    }
}
