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
# Error CS8803 — QUÉ ES: pusiste record antes del código / POR QUÉ: en consola top-level el código va primero, tipos al final
```
