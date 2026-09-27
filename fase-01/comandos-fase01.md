# Fase 01 - Comandos .NET (acumulado, cada comando con qué es/por qué)

## Verificar (una vez)
```
dotnet --version  # QUÉ ES: muestra SDK activo / POR QUÉ: confirmas que usas .NET 9
dotnet --list-sdks # QUÉ ES: lista SDKs instalados / POR QUÉ: tú tienes 6 y 9, usaremos 9
```

## Crear consola (una vez por proyecto)
```
dotnet new console -n hola-csharp # QUÉ ES: crea carpeta hola-csharp con Program.cs + hola-csharp.csproj / POR QUÉ: molde base consola, -n = nombre
# .csproj — QUÉ ES: lista del proyecto, dice net9.0 / POR QUÉ: ahí .NET sabe qué compilar
# Program.cs — QUÉ ES: tu código / POR QUÉ: ahí escribes C#
```

## Correr y compilar (todos los días)
```
dotnet run --project fase-01/hola-csharp # QUÉ ES: compila y ejecuta / POR QUÉ: ves tu programa. --project dice cuál carpeta
dotnet build fase-01/hola-csharp # QUÉ ES: solo compila sin ejecutar / POR QUÉ: verifica errores antes de correr
dotnet new console -n linq-base # QUÉ ES: segunda consola para LINQ / POR QUÉ: separas 1.1 tipos de 1.2 listas, no mezclas
dotnet run --project fase-01/linq-base # QUÉ ES: corre LINQ / POR QUÉ: ves Where Select OrderBy
# Tu preferencia Main explícito — QUÉ ES: class Program + static void Main / POR QUÉ: ves puerta de entrada sin magia top-level, base más clara. Top-level era corto pero oculta inicio.
# Error CS8803 — QUÉ ES: pasaba en top-level con record arriba / POR QUÉ: con Main ya no pasa, record va fuera limpio
dotnet new console -n inventario-json # QUÉ ES: tercera consola POO+JSON / POR QUÉ: proyecto cierre 1.3, no mezclas con linq
dotnet run --project fase-01/inventario-json # QUÉ ES: corre inventario / POR QUÉ: crea datos.json. OJO ruta: datos.json se crea donde corres el comando (fase-01), muévelo a inventario-json para orden
dotnet new console -n nullability-demo # QUÉ ES: proyecto F1-02 solo null / POR QUÉ: un tema un proyecto, no mezclas. ? ?? ?. is null
dotnet run --project fase-01/nullability-demo # QUÉ ES: corre nullability / POR QUÉ: ves ?? ?. is null Value sin reventar
dotnet new console -n colecciones-demo # QUÉ ES: proyecto F1-03 solo colecciones sin LINQ / POR QUÉ: Add Remove Clear Dictionary separados
dotnet run --project fase-01/colecciones-demo # QUÉ ES: corre colecciones / POR QUÉ: ves Count [0] Remove Dictionary
dotnet new console -n async-demo # QUÉ ES: proyecto F1-05 solo async / POR QUÉ: Task await Delay File sin mezclar JSON
dotnet run --project fase-01/async-demo # QUÉ ES: corre async / POR QUÉ: ves espera sin bloquear + archivo. OJO saludo.txt se crea donde corres, muévelo a async-demo
```
