# Fase 00.3 - HTTP / REST / JSON (molde para entender APIs .NET)

## Idea en 1 frase
- `HTTP` — QUÉ ES: idioma con el que tu app pide datos / POR QUÉ: toda API .NET habla HTTP.
- `REST` — QUÉ ES: molde para no inventar URLs locas, recurso en plural + método dice la acción / POR QUÉ: todos usan lo mismo, te contratan por seguirlo.
- `JSON` — QUÉ ES: texto ordenado con llaves y comillas para mandar datos / POR QUÉ: C# y navegador se entienden con JSON.

## REST malo vs bueno (lo que preguntaste)
MALO - cada quien inventa, nadie te contrata así:
```
GET /traemeLosProductosPorfa.php  # QUÉ ES: verbo en URL / POR QUÉ MALO: solo tú entiendes
GET /crearProducto?accion=crear   # QUÉ ES: acción en URL / POR QUÉ MALO: rompe el molde
```
BUENO - recurso sustantivo plural, acción en método:
```
GET /api/productos     # QUÉ ES: leer todos / POR QUÉ BUENO: predecible
GET /api/productos/1   # QUÉ ES: leer uno / POR QUÉ BUENO: mismo recurso + id
POST /api/productos    # QUÉ ES: crear uno / POR QUÉ BUENO: URL igual, cambia método
PUT /api/productos/1   # QUÉ ES: actualizar uno / POR QUÉ BUENO: reemplazas todo
DELETE /api/productos/1 # QUÉ ES: borrar uno / POR QUÉ BUENO: misma URL, distinta acción
# Reglas: minúscula plural, sin verbo en URL, cada pedido lleva todo (sin estado) para escalar en Azure.
# Tu práctica fue REST: GET .../posts/1 con recurso posts en plural.

## Molde que repetirás en Fase 2 (copiar tal cual)
```
MÉTODO + URL + STATUS + JSON
GET https://api.tienda.com/api/productos/1 -> 200 + { "id":1, "nombre":"Laptop" }
# MÉTODO = qué quieres hacer / URL = a quién se lo pides / STATUS = qué respondió / JSON = datos que te dio
```

## Métodos (qué quieres hacer) — QUÉ ES cada uno / POR QUÉ se usa
- `GET` — QUÉ ES: leer / POR QUÉ: ver productos, sin cambiar nada. Ejemplo: ver ficha.
- `POST` — QUÉ ES: crear nuevo / POR QUÉ: guardar algo que no existía. Ejemplo: registrar usuario.
- `PUT` — QUÉ ES: actualizar completo, mandas todo el objeto / POR QUÉ: reemplazas entero. Ejemplo: editar producto con nombre+precio+stock.
- `PATCH` — QUÉ ES: actualizar 1 campo, mandas solo lo que cambia / POR QUÉ: en entrevistas te lo preguntan, PUT vs PATCH. Ejemplo: solo cambiar precio.
- `DELETE` — QUÉ ES: borrar / POR QUÉ: eliminas. Bueno devuelve 204 sin JSON, no 200. Ejemplo: borrar tarea.

## Status (qué respondió el servidor) — memoriza estos 7
- `200 OK` — QUÉ ES: todo bien al leer / POR QUÉ: tu GET salió bien.
- `201 Created` — QUÉ ES: todo bien al crear / POR QUÉ: tu POST guardó.
- `204 No Content` — QUÉ ES: borrado bien sin devolver nada / POR QUÉ: DELETE bueno no devuelve JSON.
- `400 Bad Request` — QUÉ ES: mandaste datos mal / POR QUÉ: te faltó un campo o JSON roto.
- `401 Unauthorized` — QUÉ ES: sin permiso / POR QUÉ: te falta login o token.
- `404 Not Found` — QUÉ ES: no existe esa URL o id / POR QUÉ: pediste producto 999 que no hay.
- `500 Error` — QUÉ ES: se rompió el servidor / POR QUÉ: bug en C#, no es tu culpa como cliente.

## JSON (cómo se ven los datos)
```json
{
  "id": 1,          // QUÉ ES: número / POR QUÉ: identifica único
  "nombre": "Laptop", // QUÉ ES: texto entre comillas / POR QUÉ: así viajan los textos
  "precio": 1200,     // QUÉ ES: número sin comillas / POR QUÉ: números van sin comillas
  "disponible": true  // QUÉ ES: verdadero/falso sin comillas / POR QUÉ: booleanos así
}
```

## Práctica real sin código (hazlo en tu navegador)
1. Abre: https://jsonplaceholder.typicode.com/posts/1
   - QUÉ ES: API pública de prueba / POR QUÉ: responde siempre igual, ideal nivel cero.
2. Verás algo como:
```json
{
  "userId": 1,
  "id": 1,
  "title": "sunt aut facere...",
  "body": "quia et suscipit..."
}
```
3. Respóndeme esto para verificar:
   - ¿Qué MÉTODO usó tu navegador? (pista: leer = ?)
   - ¿Qué STATUS crees que devolvió? (pista: si ves datos = ?)
   - Copia el `title` que te salió.

## Cómo se verá en .NET Fase 2 (adelanto, no codificar aún)
- Tu C# con `GET /api/productos/1` devolverá `200 + JSON` igual que arriba.
- Por eso este molde: hoy lees, en Fase 2 creas.

## Molde 0.3b: Lo que faltaba para junior (cerrar 0.3)

1. Path vs Query — QUÉ ES dónde va el dato / POR QUÉ te trabas sin esto en Fase 2
```
GET /api/productos/1              # PATH — QUÉ ES: /1 es parte de la URL / POR QUÉ: pides UNO específico
GET /api/productos?page=1&orden=precio # QUERY — QUÉ ES: ?page=1 son filtros después de ? / POR QUÉ: pides LISTA filtrada, página 1 ordenada
GET /api/posts?userId=1           # Ejemplo real que practicarás abajo / POR QUÉ: trae solo posts del usuario 1
# Regla: path = cuál, query = cómo los quiero. Body solo en POST/PUT/PATCH, nunca en GET.
```

2. Headers + Auth — QUÉ ES el sobre del pedido / POR QUÉ sin esto tu JWT dará 401
```
Content-Type: application/json  # QUÉ ES: dices mando JSON / POR QUÉ: el servidor sabe cómo leerte
Accept: application/json        # QUÉ ES: dices devuélveme JSON / POR QUÉ: pides formato
Authorization: Bearer TU_TOKEN  # QUÉ ES: tu pase de entrada / POR QUÉ: sin token el servidor responde 401 Unauthorized
# En navegador no ves headers al escribir URL, en Swagger/Postman sí. Por eso navegador solo sirve para GET público.
```

3. Error estándar enterprise — QUÉ ES forma fija / POR QUÉ te exigen esto en empleo
```json
// Éxito: 200 + datos
{ "id": 1, "nombre": "Laptop" }
// Error: 400 + forma fija, no texto libre
{ "error": "BadRequest", "message": "Falta el campo nombre" }
```

4. Cómo probar como junior (navegador no basta)
- `Navegador` — QUÉ ES: solo hace GET / POR QUÉ: escribir URL = leer, no puedes probar POST.
- `Swagger` — QUÉ ES: página que genera tu API .NET para probar / POR QUÉ: en Fase 2 lo usarás a diario, tiene botón Try it.
- `Postman o REST Client VS Code` — QUÉ ES: app para mandar POST/PUT/DELETE / POR QUÉ: cuando trabajes con token Bearer.

## Práctica 2 sin código - query (2 min)
1. Abre: https://jsonplaceholder.typicode.com/posts?userId=1
2. Verás lista solo con `"userId": 1` — QUÉ ES: filtraste por query / POR QUÉ: ?userId=1 pide solo de ese usuario.
3. Dime: ¿cuántos posts ves y qué método/status fue?

## Mi práctica 2026-09-24 (lo que hice, aquí queda, no en notas.md)
- Abrí `https://jsonplaceholder.typicode.com/posts/1` — QUÉ ES: API prueba / POR QUÉ: practicar lectura sin código.
- Método usado: `GET` — QUÉ ES: leer / POR QUÉ: escribir URL + Enter siempre es leer.
- Status: `200 OK` — QUÉ ES: todo bien / POR QUÉ: vi datos, si fuera 404 no vería nada.
- Title que me devolvió: `sunt aut facere repellat provident occaecati excepturi optio reprehenderit` — QUÉ ES: campo title del JSON / POR QUÉ: confirma que leí bien la API.
