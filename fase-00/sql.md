# Fase 00.4 - SQL básico (molde para .NET + EF Core)

## Idea en 1 frase
- `SQL` — QUÉ ES: idioma para pedir y guardar datos en base de datos / POR QUÉ: toda API .NET lee base, sin SQL no hay empleo.
- `Tabla` — QUÉ ES: Excel con filas y columnas / POR QUÉ: ahí viven los datos.
- `Fila` — QUÉ ES: un registro ej un producto / POR QUÉ: es lo que pides.
- `Columna` — QUÉ ES: campo ej nombre, precio / POR QUÉ: eliges cuáles traer.
- `id` — QUÉ ES: número único por fila / POR QUÉ: con eso haces JOIN y buscas uno.

## Tablas de práctica (copiar tal cual en la web)
Usaremos estas 2, como en tienda real:
```sql
-- QUÉ ES: crear tablas / POR QUÉ: primero estructura, luego datos
CREATE TABLE Categorias (
  id INTEGER PRIMARY KEY,   -- QUÉ ES: único / POR QUÉ: identifica categoría
  nombre TEXT               -- QUÉ ES: texto / POR QUÉ: ej Electrónica
);
CREATE TABLE Productos (
  id INTEGER PRIMARY KEY,   -- QUÉ ES: único / POR QUÉ: identifica producto
  nombre TEXT,              -- QUÉ ES: texto / POR QUÉ: ej Laptop
  precio INTEGER,           -- QUÉ ES: número / POR QUÉ: sin comillas
  categoriaId INTEGER       -- QUÉ ES: número que apunta a Categorias.id / POR QUÉ: así se unen con JOIN
);
-- Datos
INSERT INTO Categorias (id, nombre) VALUES (1, 'Electronica'), (2, 'Hogar');
INSERT INTO Productos (id, nombre, precio, categoriaId) VALUES
(1, 'Laptop', 1200, 1),
(2, 'Mouse', 25, 1),
(3, 'Silla', 150, 2),
(4, 'Teclado', 60, 1);
```

## Dónde practicar sin instalar nada
1. Entra a: https://sqliteonline.com/ — QUÉ ES: SQLite en navegador / POR QUÉ: no instalas Postgres aún, sintaxis 95% igual.
2. Pega el bloque de arriba y dale Run. — POR QUÉ: creas tu mini tienda.
3. Luego pega una por una las 10 de abajo.

## Las 10 consultas molde (repetir en orden)
```sql
-- 1. Traer todo — QUÉ ES: * = todas columnas / POR QUÉ: explorar primero
SELECT * FROM Productos;

-- 2. Traer solo 2 columnas — QUÉ ES: eliges campos / POR QUÉ: en API no traes todo, solo lo necesario
SELECT nombre, precio FROM Productos;

-- 3. Filtrar — QUÉ ES: WHERE filtra filas / POR QUÉ: pedir solo lo que quieres
SELECT * FROM Productos WHERE precio > 100;

-- 4. Buscar texto — QUÉ ES: LIKE busca parecido / POR QUÉ: buscador. % = cualquier cosa
SELECT * FROM Productos WHERE nombre LIKE '%a%';

-- 5. Ordenar — QUÉ ES: ORDER BY ordena / POR QUÉ: listas ordenadas. DESC = mayor a menor
SELECT nombre, precio FROM Productos ORDER BY precio DESC;

-- 6. Contar y agrupar — QUÉ ES: COUNT cuenta, GROUP BY agrupa / POR QUÉ: reportes ej cuántos por categoría
SELECT categoriaId, COUNT(*) AS total FROM Productos GROUP BY categoriaId;

-- 7. Unir 2 tablas JOIN — QUÉ ES: une por id igual / POR QUÉ: lo más pedido en empleo, traer producto + nombre categoría
SELECT Productos.nombre, Productos.precio, Categorias.nombre AS categoria
FROM Productos
JOIN Categorias ON Productos.categoriaId = Categorias.id;

-- 8. Crear — QUÉ ES: INSERT agrega fila / POR QUÉ: tu POST hará esto
INSERT INTO Productos (id, nombre, precio, categoriaId) VALUES (5, 'Monitor', 300, 1);

-- 9. Actualizar — QUÉ ES: UPDATE cambia / POR QUÉ: tu PUT/PATCH hará esto. SIN WHERE cambias todo, peligro
UPDATE Productos SET precio = 30 WHERE id = 2;

-- 10. Borrar — QUÉ ES: DELETE borra / POR QUÉ: tu DELETE hará esto. SIN WHERE borras todo, peligro
DELETE FROM Productos WHERE id = 5;
```

## Reglas junior que evitan desastres
- `SIN WHERE en UPDATE/DELETE borras todo` — POR QUÉ: error clásico que rompe producción, siempre lleva WHERE id = ?
- `SELECT * solo para explorar` — POR QUÉ: en API pides columnas exactas, * trae de más y es lento.
- `JOIN ON` — QUÉ ES: une donde ids coinciden / POR QUÉ: así conectas tablas sin duplicar datos.

## Cómo se verá en .NET Fase 2 (adelanto)
```csharp
// SQL que aprendiste:
-- SELECT nombre, precio FROM Productos WHERE precio > 100;
// En C# con EF Core será LINQ, mismo molde:
var lista = db.Productos.Where(p => p.precio > 100).Select(p => new { p.nombre, p.precio }).ToList();
// QUÉ ES: LINQ = SQL pero en C# / POR QUÉ: hoy SQL puro, en Fase 2 C# lo genera por ti.
```

## Mi práctica (llénala tú, aquí queda)
- [ ] Corrí 1-5 y vi datos
- [ ] Corrí 7 JOIN y vi categoria
- [ ] Corrí 8-10 sin borrar todo (siempre con WHERE)
- Qué me costó: _
