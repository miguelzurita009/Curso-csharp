# Fase 00.4 - SQL Ejercicios (5 para practicar, tú los resuelves)

Usa tus tablas de `sql.md` en https://sqliteonline.com/. Pega CREATE+INSERT primero si empezaste de cero.

## Cómo responder
- Escribe tu consulta en sqliteonline, corre, pégame tu SQL + qué te salió.
- No mires `sql.md` a la primera, intenta con pasos. Si te trabas, mira pista.

## Ejercicio 1 - Filtrar y ordenar (fácil)
Trae nombre y precio de productos de Electronica (categoriaId=1) ordenados de mayor a menor precio.
- Pista molde: `SELECT ... WHERE ... ORDER BY ... DESC` — QUÉ ES: filtra luego ordena / POR QUÉ: lista de tienda.
- Resultado esperado: 3 filas: Laptop 1200, Teclado 60, Mouse 25 en ese orden.
- [ ] Lo hice

## Ejercicio 2 - Rango (medio)
Trae id, nombre, precio de productos con precio entre 50 y 200.
- Pista: `BETWEEN` — QUÉ ES: entre bordes incluidos / POR QUÉ: rangos de precio.
- Resultado esperado: 2 filas: Silla 150, Teclado 60. Laptop no, Mouse no.
- [ ] Lo hice

## Ejercicio 3 - JOIN con filtro (medio, el más pedido en empleo)
Trae nombre producto, precio y nombre categoria como `categoria`, solo de Hogar.
- Pista pasos: 1) FROM Productos 2) JOIN Categorias ON FK=PK 3) SELECT con prefijo + AS 4) WHERE Categorias.id = 2
- Resultado esperado: 1 fila: Silla|150|Hogar.
- [ ] Lo hice

## Ejercicio 4 - Reporte con nombre (mezcla 6b)
Muestra nombre categoria como `categoria` y total de productos como `total`, ordenado por total de mayor a menor.
- Pista: `SELECT ... COUNT(*) ... JOIN ... GROUP BY ... ORDER BY total DESC` — mismo molde 6b + orden.
- Resultado esperado: 2 filas: Electronica|3, Hogar|1 en ese orden.
- [ ] Lo hice

## Ejercicio 5 - Lista real paginada (cierre junior)
Trae nombre producto, precio y categoria, de productos con precio > 20, ordenados por precio DESC, solo los primeros 2 (página 1).
- Pista orden fijo: `JOIN -> WHERE -> ORDER BY -> LIMIT` — QUÉ ES: lista API / POR QUÉ: así pedirá tu .NET con ?page&limit.
- Resultado esperado: 2 filas: Laptop|1200|Electronica, Silla|150|Hogar. Teclado queda fuera por ser página 1.
- [ ] Lo hice

## Cuando termines
Pégame tus 5 SQL y cerramos Fase 0. Si fallas 2+, repetimos esos moldes.
