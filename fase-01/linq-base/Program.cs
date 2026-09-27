// Fase 01.2 - Lista + LINQ = tu SQL en C#
// List<> — QUÉ ES: lista en memoria como tabla / POR QUÉ: aquí practicas sin base, en Fase 2 será db.Productos
// OJO ORDEN: primero código, tipos al final — POR QUÉ: C# top-level exige statements antes que record

var productos = new List<Producto> // var — QUÉ ES: deduce tipo / POR QUÉ: no escribes List<Producto> otra vez
{
    new(1, "Laptop", 1200, 1), // new(1,...) — QUÉ ES: crea uno sin repetir Producto / POR QUÉ: corto
    new(2, "Mouse", 25, 1),
    new(3, "Silla", 150, 2),
    new(4, "Teclado", 60, 1),
};

// WHERE precio > 100 — igual que SQL
var caros = productos.Where(p => p.Precio > 100); // Where — QUÉ ES: filtra / POR QUÉ: es tu WHERE. p => léelo cada p donde
Console.WriteLine("Caros >100:");
foreach (var p in caros) Console.WriteLine($"- {p.Nombre} {p.Precio}");
// foreach — QUÉ ES: recorre uno por uno / POR QUÉ: para mostrar

// SELECT nombre, precio + ORDER BY DESC — igual que SQL
var lista = productos
    .OrderByDescending(p => p.Precio) // ORDER BY DESC
    .Select(p => new { p.Nombre, p.Precio }); // Select — QUÉ ES: elige columnas / POR QUÉ: es tu SELECT
Console.WriteLine("Ordenados:");
foreach (var p in lista) Console.WriteLine($"- {p.Nombre} {p.Precio}");

// COUNT por categoria — igual que GROUP BY
var totalElectronica = productos.Count(p => p.CategoriaId == 1); // Count con condición
Console.WriteLine($"Electronica tiene: {totalElectronica}"); // Esperas 3

record Producto(int Id, string Nombre, int Precio, int CategoriaId);
// record — QUÉ ES: clase corta para datos, va al final / POR QUÉ: C# lo exige después del código
// int Id — único como PK SQL. CategoriaId — apunta como FK.
