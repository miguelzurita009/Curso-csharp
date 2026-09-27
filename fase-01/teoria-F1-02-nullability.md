# F1-02 Teoría Nullability (análisis + lo que faltaba)

## Veredicto: tu demo está bien pero al 70%, faltan 3 de empleo
Tienes: `? ?? ?. is null Value ??=` + evitas NullReference. Bien base.
Falta para junior: `!`, `ThrowIfNull`, `IsNullOrWhiteSpace`. Sin eso lees código ajeno y te pierdes.

## 1. ? avisa, no solo permite
- `string? nombre` — QUÉ ES: puede ser null y el compilador lo sabe / POR QUÉ: en `.csproj` tienes `<Nullable>enable</Nullable>`, C# te advierte si lo usas sin revisar. Sin `?` promete que nunca es null.
- `int? descuento` — igual para números. En SQL es columna nullable.

## 2. Operadores que ya tienes (bien)
- `??` si null usa otro. `?.` si null no sigue. `is null` pregunta moderna. `.Value` saca número solo tras revisar. `??=` asigna si vacío.

## 3. Lo que faltaba para junior (añadido para dejar claro)
- `!` null-forgiving — QUÉ ES: `nombre!` dices confía, sé que no es null / POR QUÉ: callas advertencia. Úsalo casi nunca, si te equivocas revienta. Lo verás en código ajeno.
```csharp
string? n = "Mouse";
Console.WriteLine(n!.Length); // Sabes que no es null, quitas aviso
```
- `ThrowIfNull` — QUÉ ES: si es null lanza error claro / POR QUÉ: en APIs validas entradas al inicio, molde junior.
```csharp
void Agregar(Producto? p)
{
    ArgumentNullException.ThrowIfNull(p); // Si p null revienta aquí con mensaje, no más abajo raro
}
```
- `string.IsNullOrWhiteSpace` — QUÉ ES: true si null, vacío "" o espacios "   " / POR QUÉ: usuario manda "" no null, con `is null` no lo atrapas. En validación siempre este.
```csharp
if (string.IsNullOrWhiteSpace(nombre)) Console.WriteLine("Nombre inválido");
```
- `null vs "" vs 0` — QUÉ ES: null = sin dato, "" = texto vacío, 0 = número cero / POR QUÉ: en SQL NULL no es 0 ni "". No los mezcles.

## Molde copiar para no reventar
```
1) Declara con ? si puede faltar
2) Revisa con is null o IsNullOrWhiteSpace antes de usar
3) Usa ?? para defecto o ?. para acceso seguro
4) Solo .Value tras revisar, casi nunca !
```
