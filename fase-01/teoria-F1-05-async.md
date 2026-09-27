# F1-05 Teoría async/await (para copiar pensamiento)

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
