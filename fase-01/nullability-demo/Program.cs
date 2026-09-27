// F1-02 Nullability dedicado con Main explícito
// null — QUÉ ES: sin valor, como NULL SQL / POR QUÉ: no todo tiene dato ej descuento. Si lo tocas sin revisar revienta NullReference, error 1 de juniors.

using System;

class Program
{
    static void Main()
    {
        string? nombre = null; // string? — QUÉ ES: texto que permite null / POR QUÉ: ? avisa que puede venir vacío. Sin ? el compilador te advierte si metes null
        int? descuento = null; // int? — QUÉ ES: número que permite null / POR QUÉ: no todos los productos tienen descuento, igual que columna nullable SQL

        // 1. ?? da valor por defecto — QUÉ ES: si es null usa otro / POR QUÉ: evitas mostrar vacío
        Console.WriteLine($"Nombre: {nombre ?? "Sin nombre"}"); // Esperas Sin nombre
        Console.WriteLine($"Descuento: {descuento ?? 0}"); // Esperas 0

        // 2. ?. acceso seguro — QUÉ ES: si es null no sigue, devuelve null / POR QUÉ: sin ?. revienta al pedir .Length de null
        Console.WriteLine($"Largo nombre: {nombre?.Length ?? -1}"); // ?.Length da null, ?? -1 muestra -1. Esperas -1
        nombre = "Mouse";
        Console.WriteLine($"Largo nombre: {nombre?.Length ?? -1}"); // Ahora 5

        // 3. Revisar antes de usar — molde clásico
        descuento = null;
        if (descuento is null) // is null — QUÉ ES: pregunta si es null / POR QUÉ: forma moderna clara, mejor que == null
            Console.WriteLine("Sin descuento, precio full");
        else
            Console.WriteLine($"Con descuento {descuento}");

        descuento = 10;
        if (descuento is not null) // is not null — QUÉ ES: tiene valor / POR QUÉ: aquí ya puedes usar descuento.Value seguro
            Console.WriteLine($"Precio con descuento: {100 - descuento.Value}"); // .Value — QUÉ ES: saca el número de int? / POR QUÉ: solo úsalo tras revisar que no es null

        // 4. ??= asigna solo si es null — QUÉ ES: si está vacío ponle esto / POR QUÉ: inicializar barato
        string? categoria = null;
        categoria ??= "General"; // Como categoria era null ahora es General
        Console.WriteLine($"Categoria: {categoria}");
    }
}
