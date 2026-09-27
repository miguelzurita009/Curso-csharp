# Fase 01.2 - Teoría LINQ base (todo lo hablado, ordenado para copiar pensamiento)

## 1. List<Producto> necesita tipo Producto
- `record Producto(int Id, string Nombre, int Precio, int CategoriaId)` — QUÉ ES: tu molde/fila / POR QUÉ: sin molde no hay lista. Está en `linq-base/Program.cs` abajo.
- `List<Producto>` — QUÉ ES: lista que solo acepta Producto / POR QUÉ: `<Producto>` dice qué guarda. Sin record da error `no existe Producto`.
- `var productos = new List<Producto> { ... }` — QUÉ ES: creas lista con 4 filas / POR QUÉ: `new` crea, `var` deduce tipo para no repetir.

## 2. p => p.Precio, cómo sabe que existe Precio
- `productos` es `List<Producto>`, entonces cada `p` ES un Producto.
- `Precio` existe porque lo definiste tercero en el record: `int Precio`.
- `p => p.Precio > 100` léelo: cada p donde su Precio > 100. `=>` = lambda, flecha de cada uno a su condición.
- VS Code autocompleta porque ya sabe el tipo. Si pones `p.Invento` da error porque no está en el record.

## 3. record qué es, cómo funciona, para qué
- QUÉ ES: clase corta solo para datos. `record Producto(...)` con campos entre paréntesis.
- CÓMO FUNCIONA: tú das campos y C# genera propiedades + constructor `new Producto(1,"Laptop",1200,1)` + `ToString` + igualdad.
- PARA QUÉ: llevar datos como filas SQL o JSON. En Fase 2 serán DTOs. Si necesitas lógica con métodos, usas `class`; si solo datos, `record`.
- `ToString` — QUÉ ES: convertir a texto para mostrar / POR QUÉ: `WriteLine(p)` lo llama solo. Record lo trae bonito `Producto { Id=1, Nombre=Laptop... }`, class normal muestra feo `Namespace.Producto`.

## 4. Where trae filas completas, Select elige columnas
- `Where(p => p.Precio > 100)` — QUÉ ES: filtra FILAS / POR QUÉ: es tu `SELECT * WHERE`. Da Laptop y Silla ENTEROS con 4 campos.
- `Select(p => new { p.Nombre, p.Precio })` — QUÉ ES: elige COLUMNAS / POR QUÉ: es tu `SELECT nombre, precio`. Sin Select muestras todo, con Select limpio.
- Regla: Where = qué filas (2 de 4), Select = qué columnas (2 de 4).

## 5. Por qué new en Select
- `new` — QUÉ ES: crear objeto / POR QUÉ: siempre que quieres dato nuevo.
- `new Producto(...)` = creas con molde con nombre.
- `new List<Producto>` = creas lista vacía para llenar.
- `new { p.Nombre, p.Precio }` = creas cajita anónima temporal sin nombre porque solo tiene 2 de 4 campos, no es Producto completo.
- Sin `new` no hay qué devolver. En Fase 2 ese anónimo será `new ProductoDto` con nombre.
