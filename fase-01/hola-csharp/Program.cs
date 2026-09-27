// Fase 01.1 - Tipos base (molde para copiar)
// Console — QUÉ ES: pantalla / POR QUÉ: ves resultados
// string int decimal bool — QUÉ ES: tipos / POR QUÉ: cada dato tiene tipo, como columnas SQL

string nombre = "Laptop"; // QUÉ ES: texto entre comillas / POR QUÉ: nombres van en string
int precio = 1200; // QUÉ ES: número entero / POR QUÉ: precios enteros en int
decimal precioExacto = 1200.50m; // QUÉ ES: decimal con m al final / POR QUÉ: dinero exacto usa decimal, m = money
bool disponible = true; // QUÉ ES: verdadero/falso / POR QUÉ: flags como disponible
int? descuento = null; // QUÉ ES: int que permite nulo ? / POR QUÉ: como NULL en SQL, no todos tienen descuento

Console.WriteLine($"Producto: {nombre}, Precio: {precio}, Exacto: {precioExacto}, Disponible: {disponible}, Descuento: {descuento ?? 0}");
// $"" — QUÉ ES: interpolación / POR QUÉ: mete variables dentro del texto
// ?? 0 — QUÉ ES: si es null usa 0 / POR QUÉ: evitas mostrar vacío
