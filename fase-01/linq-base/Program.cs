// Fase 01.2 - Lista + LINQ con Main explícito (tu preferencia)
// class Program + static Main — QUÉ ES: puerta de entrada clásica / POR QUÉ: ves dónde empieza todo, sin magia top-level. Ideal base.
// List<> — QUÉ ES: lista en memoria como tabla / POR QUÉ: aquí practicas sin base, en Fase 2 será db.Productos

using System;
using System.Collections.Generic;
using System.Linq;
// using — QUÉ ES: trae herramientas / POR QUÉ: List necesita Collections, Where necesita Linq

class Program // QUÉ ES: caja del programa / POR QUÉ: C# organiza código en clases
{
    static void Main() // QUÉ ES: método inicial, void = no devuelve / POR QUÉ: .NET busca Main para empezar
    {
        var productos = new List<Producto> // var — deduce tipo para no repetir List<Producto>
        {
            new Producto(1, "Laptop", 1200, 1), // new Producto(...) — QUÉ ES: crea uno completo / POR QUÉ: con Main usamos forma larga clara
            new Producto(2, "Mouse", 25, 1),
            new Producto(3, "Silla", 150, 2),
            new Producto(4, "Teclado", 60, 1),
        };

        // WHERE precio > 100 — igual que SQL
        var caros = productos.Where(p => p.Precio > 100); // Where = WHERE. p => cada p donde
        Console.WriteLine("Caros >100:");
        foreach (var p in caros) Console.WriteLine($"- {p.Nombre} {p.Precio}");

        // SELECT + ORDER BY DESC
        var lista = productos
            .OrderByDescending(p => p.Precio)
            .Select(p => new { p.Nombre, p.Precio });
        Console.WriteLine("Ordenados:");
        foreach (var p in lista) Console.WriteLine($"- {p.Nombre} {p.Precio}");

        // COUNT
        var totalElectronica = productos.Count(p => p.CategoriaId == 1);
        Console.WriteLine($"Electronica tiene: {totalElectronica}"); // Esperas 3
    }
}

record Producto(int Id, string Nombre, int Precio, int CategoriaId);
// record fuera de Program — QUÉ ES: tipo dato / POR QUÉ: con Main ya no importa orden top-level, va fuera limpio
