# SQL 20 Ejercicios Resueltos - copiar el pensamiento, no solo el SQL

Base de `sql.md`. Si modificaste datos, re-pega CREATE+INSERT antes de empezar. Orden: lee 1-18, escribe 19-20 modifican.

## Cómo leer cada uno
- `Pienso:` pasos en orden para armarlo tú mañana sin mirar.
- `SQL:` solución.
- `Da:` resultado con tus 4 productos.
- `Molde:` frase para copiar.

## 1. Explorar
Pienso: 1) ¿Qué tabla? Productos 2) ¿Qué columnas? todas para ver.
```sql
SELECT * FROM Productos;
```
Da: 4 filas completas. Molde: explorar = `SELECT *`.

## 2. Elegir columnas
Pienso: 1) Solo necesito nombre+precio para lista 2) No traigo ids de más.
```sql
SELECT nombre, precio FROM Productos;
```
Da: Laptop 1200, Mouse 25, Silla 150, Teclado 60. Molde: en API pide exactas.

## 3. Filtrar número
Pienso: 1) ¿Condición? precio>100 2) WHERE filtra filas.
```sql
SELECT * FROM Productos WHERE precio > 100;
```
Da: Laptop, Silla. Molde: `WHERE columna operador valor`.

## 4. Buscar texto
Pienso: 1) Busco letra a en nombre 2) LIKE + % = cualquier cosa.
```sql
SELECT * FROM Productos WHERE nombre LIKE '%a%';
```
Da: Laptop, Silla, Teclado. Mouse no tiene a. Molde: buscador = `LIKE '%x%'`.

## 5. Ordenar
Pienso: 1) Quiero de caro a barato 2) ORDER BY precio DESC.
```sql
SELECT nombre, precio FROM Productos ORDER BY precio DESC;
```
Da: Laptop 1200, Silla 150, Teclado 60, Mouse 25. Molde: orden = `ORDER BY ... DESC/ASC`.

## 6. AND junta filtros
Pienso: 1) ¿Filtros? precio>50 y categoria 1 2) Ambos deben cumplirse = AND.
```sql
SELECT * FROM Productos WHERE precio > 50 AND categoriaId = 1;
```
Da: Laptop, Teclado. Molde: varios filtros = `AND`.

## 7. IN lista
Pienso: 1) Quiero ids 1,3,4 sin escribir 3 OR 2) IN lista.
```sql
SELECT * FROM Productos WHERE id IN (1, 3, 4);
```
Da: Laptop, Silla, Teclado. Molde: lista fija = `IN (...)`.

## 8. BETWEEN rango
Pienso: 1) Entre 50 y 200 incluidos 2) BETWEEN bordes.
```sql
SELECT id, nombre, precio FROM Productos WHERE precio BETWEEN 50 AND 200;
```
Da: Silla 150, Teclado 60. Molde: rango = `BETWEEN a AND b`.

## 9. Contar por grupo
Pienso: 1) ¿Agrupo por qué se repite? categoriaId 2) SELECT grupo + COUNT 3) GROUP BY mismo.
```sql
SELECT categoriaId, COUNT(*) AS total FROM Productos GROUP BY categoriaId;
```
Da: 1|3, 2|1. Molde: reporte = `grupo + COUNT + GROUP BY mismo`.

## 10. Promediar por grupo
Pienso: igual que 9 pero cambio COUNT por AVG.
```sql
SELECT categoriaId, AVG(precio) AS promedio FROM Productos GROUP BY categoriaId;
```
Da: 1|428, 2|150. 428 = (1200+25+60)/3. Molde: cambia función, mismo molde.

## 11. Contar con nombre útil (6b)
Pienso: 1) id no sirve, quiero nombre -> necesito JOIN 2) FROM+JOIN ON FK=PK 3) SELECT nombre+COUNT 4) GROUP BY nombre.
```sql
SELECT Categorias.nombre AS categoria, COUNT(*) AS total
FROM Productos
JOIN Categorias ON Productos.categoriaId = Categorias.id
GROUP BY Categorias.nombre;
```
Da: Electronica|3, Hogar|1. Molde: si muestras nombre agrupa por nombre.

## 12. JOIN todos
Pienso: 1) Quiero producto+categoria 2) Base Productos tiene FK 3) JOIN ON categoriaId=id 4) SELECT con prefijo + AS por duplicado nombre.
```sql
SELECT Productos.nombre, Productos.precio, Categorias.nombre AS categoria
FROM Productos
JOIN Categorias ON Productos.categoriaId = Categorias.id;
```
Da: 4 filas con categoria al lado. Molde: `FROM base + JOIN ON FK=PK`.

## 13. JOIN filtrado por id (tu ejercicio 3)
Pienso: 1) Mismo JOIN 12 2) Solo Hogar = id 2 por id porque frontend manda id.
```sql
SELECT Productos.nombre, Productos.precio, Categorias.nombre AS categoria
FROM Productos
JOIN Categorias ON Productos.categoriaId = Categorias.id
WHERE Categorias.id = 2;
```
Da: Silla|150|Hogar. Molde: filtra por id, muestra nombre.

## 14. JOIN filtrado por nombre (contraste, no usar)
Pienso: mismo pero WHERE nombre='Hogar'. Funciona pero frágil por tildes/mayúsculas.
```sql
SELECT Productos.nombre, Productos.precio, Categorias.nombre AS categoria
FROM Productos
JOIN Categorias ON Productos.categoriaId = Categorias.id
WHERE Categorias.nombre = 'Hogar';
```
Da: mismo. Molde: filtra por id en real, nombre solo para explorar.

## 15. Página 1
Pienso: 1) Ordeno por id para páginas estables 2) LIMIT 2 primeros.
```sql
SELECT id, nombre FROM Productos ORDER BY id LIMIT 2 OFFSET 0;
```
Da: 1 Laptop, 2 Mouse. Molde: `ORDER BY + LIMIT + OFFSET`, offset=(page-1)*limit.

## 16. Página 2
Pienso: misma pero salto 2.
```sql
SELECT id, nombre FROM Productos ORDER BY id LIMIT 2 OFFSET 2;
```
Da: 3 Silla, 4 Teclado. Molde: página 2 = offset 2.

## 17. Lista real API (junta todo)
Pienso: orden fijo 1) JOIN 2) WHERE 3) ORDER 4) LIMIT.
```sql
SELECT Productos.nombre, Productos.precio, Categorias.nombre AS categoria
FROM Productos
JOIN Categorias ON Productos.categoriaId = Categorias.id
WHERE Productos.precio > 20
ORDER BY Productos.precio DESC
LIMIT 10;
```
Da: 4 filas ordenadas: Laptop 1200, Silla 150, Teclado 60, Mouse 25. Molde: `JOIN->WHERE->ORDER->LIMIT`.

## 18. DISTINCT valores únicos
Pienso: quiero qué categorias tienen productos sin repetir.
```sql
SELECT DISTINCT categoriaId FROM Productos;
```
Da: 1, 2. Molde: combo filtros = `DISTINCT`.

## 19. Crear y verificar
Pienso: 1) INSERT con todos campos 2) SELECT para verificar.
```sql
INSERT INTO Productos (id, nombre, precio, categoriaId) VALUES (5, 'Monitor', 300, 1);
SELECT * FROM Productos WHERE id = 5;
```
Da: Monitor creado. Molde: POST = INSERT + verifica con SELECT.

## 20. Actualizar y borrar seguro
Pienso: 1) Siempre con WHERE id 2) Verifico.
```sql
UPDATE Productos SET precio = 30 WHERE id = 2;
SELECT nombre, precio FROM Productos WHERE id = 2;
DELETE FROM Productos WHERE id = 5;
SELECT COUNT(*) AS quedan FROM Productos;
```
Da: Mouse 30, borrado Monitor, quedan 4. Molde: sin WHERE rompes todo, siempre `WHERE id = ?`.
