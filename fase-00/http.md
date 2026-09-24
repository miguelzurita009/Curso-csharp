# Fase 00.3 - HTTP / REST / JSON (molde para entender APIs .NET)

## Idea en 1 frase
- `HTTP` — QUÉ ES: idioma con el que tu app pide datos / POR QUÉ: toda API .NET habla HTTP.
- `REST` — QUÉ ES: regla ordenada para usar HTTP con URLs claras / POR QUÉ: así no inventas URLs locas, todos usan el mismo molde.
- `JSON` — QUÉ ES: texto ordenado con llaves y comillas para mandar datos / POR QUÉ: C# y navegador se entienden con JSON.

## Molde que repetirás en Fase 2 (copiar tal cual)
```
MÉTODO + URL + STATUS + JSON
GET https://api.tienda.com/api/productos/1 -> 200 + { "id":1, "nombre":"Laptop" }
# MÉTODO = qué quieres hacer / URL = a quién se lo pides / STATUS = qué respondió / JSON = datos que te dio
```

## Métodos (qué quieres hacer) — QUÉ ES cada uno / POR QUÉ se usa
- `GET` — QUÉ ES: leer / POR QUÉ: ver productos, sin cambiar nada. Ejemplo: ver ficha.
- `POST` — QUÉ ES: crear nuevo / POR QUÉ: guardar algo que no existía. Ejemplo: registrar usuario.
- `PUT` — QUÉ ES: actualizar completo / POR QUÉ: reemplazas todo. Ejemplo: editar producto entero.
- `DELETE` — QUÉ ES: borrar / POR QUÉ: eliminas. Ejemplo: borrar tarea.

## Status (qué respondió el servidor) — memoriza estos 6
- `200 OK` — QUÉ ES: todo bien al leer / POR QUÉ: tu GET salió bien.
- `201 Created` — QUÉ ES: todo bien al crear / POR QUÉ: tu POST guardó.
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

## Mi práctica 2026-09-24 (lo que hice, aquí queda, no en notas.md)
- Abrí `https://jsonplaceholder.typicode.com/posts/1` — QUÉ ES: API prueba / POR QUÉ: practicar lectura sin código.
- Método usado: `GET` — QUÉ ES: leer / POR QUÉ: escribir URL + Enter siempre es leer.
- Status: `200 OK` — QUÉ ES: todo bien / POR QUÉ: vi datos, si fuera 404 no vería nada.
- Title que me devolvió: `sunt aut facere repellat provident occaecati excepturi optio reprehenderit` — QUÉ ES: campo title del JSON / POR QUÉ: confirma que leí bien la API.
