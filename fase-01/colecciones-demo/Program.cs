// F1-03 Colecciones dedicado con Main, sin LINQ para no mezclar
// List<> — QUÉ ES: lista que crece / POR QUÉ: la usas 90%, en Fase 2 será db.Productos

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var nombres = new List<string>(); // Empieza vacía
        Console.WriteLine($"Vacía: {nombres.Count}"); // Count propiedad = 0

        nombres.Add("Laptop"); // Add — QUÉ ES: agrega al final / POR QUÉ: tu INSERT en memoria
        nombres.Add("Mouse");
        nombres.Add("Silla");
        Console.WriteLine($"Con 3: {nombres.Count}"); // 3

        Console.WriteLine($"Primero [0]: {nombres[0]}"); // [0] primero, listas empiezan en 0
        Console.WriteLine($"Último: {nombres[nombres.Count - 1]}"); // Count-1 = último. POR QUÉ: si pides [3] con 3 items revienta

        foreach (var n in nombres) Console.WriteLine($"- {n}"); // foreach recorre para mostrar

        nombres.Remove("Mouse"); // Remove por valor, quita 1
        Console.WriteLine($"Tras Remove Mouse: {nombres.Count}"); // 2
        nombres.RemoveAt(0); // RemoveAt por índice, quita Laptop
        Console.WriteLine($"Tras RemoveAt 0: {string.Join(",", nombres)}"); // Queda Silla. Join une para mostrar

        nombres.Clear(); // Vacía todo
        Console.WriteLine($"Tras Clear: {nombres.Count}"); // 0

        // Dictionary — QUÉ ES: caja clave->valor para buscar por id rápido / POR QUÉ: en inventario buscarás por id sin recorrer
        var precios = new Dictionary<int, string>(); // int clave id, string valor nombre
        precios.Add(1, "Laptop");
        precios.Add(2, "Mouse");
        Console.WriteLine($"Id 2: {precios[2]}"); // Acceso directo por clave, no recorre
        Console.WriteLine($"Tiene 3? {precios.ContainsKey(3)}"); // ContainsKey pregunta sin reventar. Esperas False
    }
}
