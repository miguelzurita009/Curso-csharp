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

-- 6. Contar y agrupar — QUÉ ES: COUNT cuenta filas, GROUP BY las junta por valor igual / POR QUÉ: reportes ej cuántos por categoría
SELECT categoriaId, COUNT(*) AS total FROM Productos GROUP BY categoriaId;
-- PASOS PARA ARMARLO TÚ (repite este orden):
-- Paso 1: ¿Por qué columna agrupo? Ej categoriaId — QUÉ ES: la columna que se repite / POR QUÉ: quieres un total por cada valor
-- Paso 2: SELECT categoriaId, COUNT(*) AS total — QUÉ ES: pides grupo + conteo, AS total = apodo / POR QUÉ: sin COUNT solo verías ids repetidos
-- Paso 3: FROM Productos — QUÉ ES: de dónde / POR QUÉ: siempre tabla base
-- Paso 4: GROUP BY categoriaId — QUÉ ES: junta iguales / POR QUÉ: debe ser LA MISMA columna del SELECT, si no da error
-- Resultado con tus datos: 1|3 (Electronica tiene 3), 2|1 (Hogar tiene 1) — POR QUÉ: Laptop,Mouse,Teclado son 1, Silla es 2
-- Similar tú: cuenta por precio? No, precio no se repite. Agrupa solo por columnas que se repiten: categoriaId.
-- Otro similar: SELECT categoriaId, AVG(precio) AS promedio FROM Productos GROUP BY categoriaId; — QUÉ ES: AVG promedia / POR QUÉ: mismo molde, cambia COUNT por AVG

-- 6b. Contar pero mostrando nombre categoría (más útil) — QUÉ ES: JOIN + GROUP juntos / POR QUÉ: categoriaId 1 no dice nada, Electronica sí
SELECT Categorias.nombre AS categoria, COUNT(*) AS total
FROM Productos
JOIN Categorias ON Productos.categoriaId = Categorias.id
GROUP BY Categorias.nombre;
-- PASOS: 1) Quiero ver nombre no id -> necesito Categorias -> 2) FROM Productos + JOIN Categorias ON FK=PK -> 3) SELECT nombre + COUNT -> 4) GROUP BY MISMA columna del SELECT (Categorias.nombre)
-- Resultado: Electronica|3, Hogar|1 — QUÉ ES: útil para reporte / POR QUÉ: jefe entiende nombres no ids

-- 7. Unir 2 tablas JOIN — QUÉ ES: pega filas donde FK = PK / POR QUÉ: lo más pedido en empleo, traer producto + nombre categoría sin duplicar datos
SELECT Productos.nombre, Productos.precio, Categorias.nombre AS categoria
FROM Productos
JOIN Categorias ON Productos.categoriaId = Categorias.id;
-- PASOS PARA ARMARLO TÚ (repite este orden):
-- Paso 1: ¿Qué quiero ver? Ej nombre producto + nombre categoría — QUÉ ES: elige columnas / POR QUÉ: si no eliges traes todo y choca nombre con nombre
-- Paso 2: FROM Productos — QUÉ ES: tabla base, la que tiene el FK categoriaId / POR QUÉ: empiezas por la que apunta
-- Paso 3: Busca el FK: categoriaId en Productos apunta a id en Categorias — QUÉ ES: FK termina en Id / POR QUÉ: así sabes el ON sin adivinar
-- Paso 4: JOIN Categorias ON Productos.categoriaId = Categorias.id — QUÉ ES: pega donde coinciden / POR QUÉ: ON dice cómo pegar, izquierda FK = derecha PK
-- Paso 5: SELECT con prefijo Tabla.columna + AS para duplicados: Categorias.nombre AS categoria — QUÉ ES: prefijo evita ambigüedad, AS renombra / POR QUÉ: ambas se llaman nombre, sin AS no sabes cuál es cuál
-- Resultado: Laptop|1200|Electronica, Mouse|25|Electronica, Silla|150|Hogar, Teclado|60|Electronica
-- Similar tú: trae solo Hogar agregando al final: WHERE Categorias.id = 2; — mismo molde + filtro

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

## Molde 0.4b: Lo que faltaba para junior (cerrar SQL)

1. WHERE compuesto + NULL — QUÉ ES: combinar filtros / POR QUÉ: en API filtras por varias cosas, es lo más pedido en pruebas
```sql
-- AND = todo debe cumplirse / OR = basta uno / IN = lista / BETWEEN = rango / IS NULL = vacío
SELECT * FROM Productos WHERE precio > 50 AND categoriaId = 1; -- QUÉ ES: caros de Electronica / POR QUÉ: AND junta filtros. Resultado: Laptop, Teclado
SELECT * FROM Productos WHERE categoriaId = 1 OR categoriaId = 2; -- QUÉ ES: de ambas / POR QUÉ: OR alterna
SELECT * FROM Productos WHERE id IN (1, 3, 4); -- QUÉ ES: solo esos ids / POR QUÉ: IN evita muchos OR
SELECT * FROM Productos WHERE precio BETWEEN 50 AND 200; -- QUÉ ES: entre 50 y 200 / POR QUÉ: BETWEEN incluye bordes. Resultado: Silla, Teclado
-- NULL: si mañana agregas columna descripcion sin valor, WHERE descripcion IS NULL encuentra vacíos. = NULL nunca funciona, siempre IS NULL.
-- PASOS TÚ: 1) ¿Qué filtros? 2) Únelos con AND 3) Prueba uno por uno antes de juntar.
```

2. Paginación LIMIT/OFFSET — QUÉ ES: dar por páginas / POR QUÉ: tu API nunca devuelve 10.000, conecta con ?page de HTTP 0.3b
```sql
SELECT id, nombre FROM Productos ORDER BY id LIMIT 2 OFFSET 0; -- Página 1: 1,2
SELECT id, nombre FROM Productos ORDER BY id LIMIT 2 OFFSET 2; -- Página 2: 3,4
-- QUÉ ES: LIMIT cuántos, OFFSET cuántos salto / POR QUÉ: OFFSET = (page-1)*limit. Page2 limit2 = offset 2.
-- Regla: siempre ORDER BY + LIMIT juntos, sin ORDER la página sale desordenada.
```

3. Lista real junta todo — QUÉ ES: molde que usarás en Fase 2 / POR QUÉ: en API WHERE+ORDER+LIMIT van juntos
```sql
SELECT Productos.nombre, Productos.precio, Categorias.nombre AS categoria
FROM Productos
JOIN Categorias ON Productos.categoriaId = Categorias.id
WHERE Productos.precio > 20
ORDER BY Productos.precio DESC
LIMIT 10;
-- PASOS: 1) JOIN para tener nombres 2) WHERE filtra 3) ORDER ordena 4) LIMIT pagina. Ese orden es fijo.
```

4. PK/FK + integridad — QUÉ ES: reglas que protegen / POR QUÉ: si borras Electrónica con 3 productos rompes todo
```sql
-- PK = único ej Productos.id / FK = apunta ej Productos.categoriaId -> Categorias.id
-- Si intentas: DELETE FROM Categorias WHERE id = 1; — falla si hay productos, POR QUÉ: FK protege.
-- En .NET Fase 2 EF Core creará estos FK por ti con relaciones. Hoy entiende: FK evita huérfanos.
```

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
