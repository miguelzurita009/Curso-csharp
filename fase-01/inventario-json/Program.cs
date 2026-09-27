// Fase 01.3 - POO + JSON + async con Main explícito
// POO — QUÉ ES: organizar en clases con datos y métodos / POR QUÉ: no todo suelto en Main, cada clase una tarea
// async — QUÉ ES: esperar archivos sin bloquear / POR QUÉ: leer/guardar disco tarda, await libera

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

class Program
{
    static async Task Main() // async Task — QUÉ ES: Main que puede esperar / POR QUÉ: usamos await para JSON
    {
        var inventario = new Inventario(); // QUÉ ES: crea objeto con lista dentro / POR QUÉ: Main pide, Inventario guarda
        inventario.Agregar(new Producto(1, "Laptop", 1200, 1));
        inventario.Agregar(new Producto(2, "Mouse", 25, 1));
        inventario.Agregar(new Producto(3, "Silla", 150, 2));

        Console.WriteLine($"Total: {inventario.Contar()}"); // Esperas 3
        var buscado = inventario.BuscarPorId(2); // QUÉ ES: pide por id / POR QUÉ: como WHERE id=2
        Console.WriteLine($"Buscado 2: {buscado?.Nombre} {buscado?.Precio}"); // ?. — QUÉ ES: si es null no revienta / POR QUÉ: si id no existe evita error

        Console.WriteLine("Caros:");
        foreach (var p in inventario.ListarCaros(100)) Console.WriteLine($"- {p.Nombre} {p.Precio}");

        await inventario.GuardarAsync("datos.json"); // await — QUÉ ES: espera que termine de escribir / POR QUÉ: sin await seguiría sin guardar
        Console.WriteLine("Guardado en datos.json");

        var otro = new Inventario();
        await otro.CargarAsync("datos.json"); // Lee lo guardado
        Console.WriteLine($"Cargado: {otro.Contar()} productos"); // Esperas 3, prueba que no se perdió al cerrar
    }
}

record Producto(int Id, string Nombre, int Precio, int CategoriaId);
// record = solo datos, como fila.

class Inventario // QUÉ ES: caja con lista + métodos / POR QUÉ: Main no toca lista directo, pide a Inventario
{
    private readonly List<Producto> _productos = new(); // private — QUÉ ES: solo esta clase lo ve / POR QUÉ: protege, nadie mete mano directa. readonly = no se reemplaza lista
    // new() — QUÉ ES: crea lista vacía sin repetir tipo / POR QUÉ: corto, deduce List<Producto>

    public void Agregar(Producto p) => _productos.Add(p); // public — QUÉ ES: otros pueden llamar / POR QUÉ: puerta de entrada. => forma corta de método
    public int Contar() => _productos.Count; // Count propiedad sin ()
    public Producto? BuscarPorId(int id) => _productos.FirstOrDefault(p => p.Id == id);
    // Producto? — QUÉ ES: puede devolver null / POR QUÉ: si id no existe no hay qué devolver. FirstOrDefault = primero o nada
    public IEnumerable<Producto> ListarCaros(int minimo) => _productos.Where(p => p.Precio > minimo).OrderByDescending(p => p.Precio);
    // IEnumerable — QUÉ ES: secuencia para recorrer / POR QUÉ: devuelves para foreach sin exponer lista real

    public async Task GuardarAsync(string ruta) // Task — QUÉ ES: promesa de trabajo / POR QUÉ: async siempre devuelve Task
    {
        var json = JsonSerializer.Serialize(_productos, new JsonSerializerOptions { WriteIndented = true });
        // Serialize — QUÉ ES: lista a texto JSON / POR QUÉ: así se guarda en archivo. Indented = bonito
        await File.WriteAllTextAsync(ruta, json); // WriteAllTextAsync — escribe archivo esperando
    }

    public async Task CargarAsync(string ruta)
    {
        if (!File.Exists(ruta)) return; // Si no hay archivo no hace nada, evita error primera vez
        var json = await File.ReadAllTextAsync(ruta); // Lee texto esperando
        var lista = JsonSerializer.Deserialize<List<Producto>>(json); // Deserialize — QUÉ ES: JSON a lista / POR QUÉ: recupera objetos
        if (lista is not null) { _productos.Clear(); _productos.AddRange(lista); } // Clear+AddRange reemplaza contenido
    }
}
