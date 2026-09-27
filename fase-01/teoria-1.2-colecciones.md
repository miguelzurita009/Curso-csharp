# Fase 01.2 - Teoría Colecciones (lo pasamos rápido, aquí lento)

## Idea base
- `Colección` — QUÉ ES: caja con varios datos del mismo tipo / POR QUÉ: no haces variable1 variable2, guardas lista.
- `List<Producto>` — QUÉ ES: lista que crece, solo acepta Producto / POR QUÉ: es la que usas 90% en .NET, en Fase 2 será `db.Productos`.
- `Array Producto[]` — QUÉ ES: caja fija que no crece / POR QUÉ: hoy no la usamos, List es flexible. Array es viejo rígido.

## Partes de tu código
```csharp
var productos = new List<Producto> { new Producto(1,"Laptop",1200,1), ... };
```
- `new List<Producto>` — QUÉ ES: crea lista vacía / POR QUÉ: `new` siempre crea, sin new es null y revienta.
- `var` — QUÉ ES: deduce tipo solo / POR QUÉ: no repites `List<Producto>` dos veces. No es sin tipo, es Producto igual.
- `{ ... }` — QUÉ ES: llenas al crear / POR QUÉ: inicializas con tus 4 filas SQL.
- `<Producto>` — QUÉ ES: candado de tipo / POR QUÉ: si metes string da error, protege.

## Operaciones que usarás (molde copiar)
```csharp
productos.Add(new Producto(5,"Monitor",300,1)); // QUÉ ES: agrega uno / POR QUÉ: es tu INSERT en memoria
productos.Count // QUÉ ES: cuántos hay, es propiedad sin () / POR QUÉ: 4. Count() con () es método con filtro ej Count(p=>...)
var primero = productos[0]; // QUÉ ES: índice 0 = primero / POR QUÉ: listas empiezan en 0, [0] Laptop, [3] Teclado
productos.RemoveAll(p => p.Id == 5); // QUÉ ES: borra los que cumplan / POR QUÉ: es tu DELETE. Raro en base, normal en memoria para practicar
foreach (var p in productos) Console.WriteLine(p.Nombre); // QUÉ ES: recorre uno por uno / POR QUÉ: para mostrar o sumar
```
- `Add` sin `new` no funciona, siempre `Add(new Producto(...))`.
- `[0]` si pides `[10]` que no existe revienta `ArgumentOutOfRange`, como pedir id que no hay -> 404.
- `foreach` no modifica, solo lee. Para transformar usas LINQ `Where/Select`.

## List vs SQL tabla
- `List` en memoria se pierde al cerrar programa / `Tabla SQL` queda guardada. POR QUÉ practicas aquí gratis y en Fase 2 pasas a base real.
- `productos.Where(...)` = WHERE, `productos.Add` = INSERT, `RemoveAll` = DELETE. Mismo pensamiento.
