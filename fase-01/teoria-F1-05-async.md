# F1-05 Teoría async/await (para copiar pensamiento)

## Didáctica desde cero (léeme primero)
Imagina restaurante 1 mesero tú-hilo, cocina disco:
- Sync: pides plato y te quedas parado frente a cocina 10 min mirando, 5 mesas esperan enojadas. Eso es `Thread.Sleep` o leer sin await.
- Async: pides plato, dejas ticket, atiendes 5 mesas más, cuando suena vas por plato. Eso es `await`.

Sintaxis pieza por pieza con tu demo:
```csharp
static async Task Main()
```
- `static` ya lo sabes, `Main` puerta. `async` = permiso para esperar liberando dentro. Sin async no puedes usar await. `Task` = promesa, Main promete terminar. Si devolviera texto sería `Task<string>`.
```csharp
await Task.Delay(1000);
```
- Léelo: espera 1s liberando. `Task.Delay` = cocina falsa para practicar. `await` = dejo ticket y atiendo otros, vuelvo en 1s.
```csharp
await File.WriteAllTextAsync("saludo.txt", "Hola");
string t = await File.ReadAllTextAsync("saludo.txt");
```
- Escribe esperando, luego lee esperando. Sin primer await leerías vacío porque no terminó de escribir.
Flujo números de tu salida 1-2-3-4: 1 pides, 2 vuelve tras 1s, 3 escribe, 4 lee. Cada await es pausa que libera.

## Idea base
- `Sync` — QUÉ ES: hace y espera bloqueando / POR QUÉ: simple pero congela. `Thread.Sleep(1000)` congela 1s.
- `Async` — QUÉ ES: hace y espera liberando / POR QUÉ: `await Task.Delay(1000)` espera 1s sin congelar. En API con 100 usuarios a la vez es vital.
- `Task` — QUÉ ES: promesa de trabajo futuro / POR QUÉ: async siempre devuelve Task. `Task` solo = trabajo sin resultado, `Task<string>` = trabajo que dará texto.
- `await` — QUÉ ES: espera aquí hasta que termine / POR QUÉ: sin await sigues con archivo a medias. Solo se usa dentro de método async.

## Partes de tu demo
```csharp
static async Task Main() // Main async para usar await dentro
await Task.Delay(1000); // Simula disco/red 1s sin bloquear
await File.WriteAllTextAsync("saludo.txt", "Hola"); // Escribe esperando
string t = await File.ReadAllTextAsync("saludo.txt"); // Lee esperando
```
- Si quitas `await` de Write y lees enseguida, lees vacío o viejo. POR QUÉ: no esperaste.

## Errores junior que evitamos
- `async void` — QUÉ ES: async sin Task / POR QUÉ MALO: no se puede esperar ni atrapar error. Solo en eventos UI, nunca en tu código. Siempre `async Task`.
- Olvidar `await` — compilador avisa `no se espera`. Si lo ignoras, corre a medias.
- `.Result` para evitar await — QUÉ ES: bloquea para sacar resultado / POR QUÉ MALO: puede congelar API. Siempre await.

## Molde copiar
```
1) Método que espera lleva async Task
2) Cada espera lleva await: Delay, Read, Write, red
3) Main que usa await debe ser async Task Main
```
