# Fase 00 - Notas (molde)

## Qué hice hoy
- 2026-09-24 - verifiqué entorno: Git 2.49 ok, .NET 6 y 9 ok, VS Code ok, Docker falta (se instala en Fase 3)
- 2026-09-24 - comprobé firma Git: Miguel / miguelzurita009@gmail.com ya configurada
- 2026-09-24 - creé molde base: README.md + .gitignore + notas.md
- 2026-09-24 - renombré rama master -> main
- 2026-09-24 - enlacé a GitHub: https://github.com/miguelzurita009/Curso-csharp.git
- 2026-09-24 - practiqué segundo commit + push

## Mi entorno actual
- `git 2.49` — QUÉ ES: guarda versiones / POR QUÉ: sin esto no hay historial
- `dotnet 9.0.318 + 6.0.428` — QUÉ ES: SDK para compilar C# / POR QUÉ: usaremos .NET 9
- `VS Code 1.139` — QUÉ ES: editor / POR QUÉ: ahí editas y repites moldes
- `Docker: falta` — QUÉ ES: contenedores / POR QUÉ: se instala en Fase 3, no bloquea ahora
- Rama: `main` — QUÉ ES: línea principal de versiones / POR QUÉ: nombre moderno, antes era master
- Estado: local + GitHub iguales — QUÉ ES: `up to date + clean` / POR QUÉ: nada pendiente

## Comandos que repetí

### Molde 0 - Firma (una vez por PC) — POR QUÉ: sin firma el commit falla con Author identity unknown
```
git config --global user.name  # QUÉ ES: muestra tu nombre / POR QUÉ: confirma si ya tienes firma
git config --global user.email # QUÉ ES: muestra tu email / POR QUÉ: Git firma cada versión con esto
# Solo si sale vacío, crear firma:
# git config --global user.name "Tu Nombre"   # QUÉ ES: guarda nombre / POR QUÉ: saldrá en cada versión
# git config --global user.email "tu@email.com" # QUÉ ES: guarda email / POR QUÉ: GitHub vincula tus aportes
# config = cambiar ajustes / --global = vale para todos tus proyectos en este PC
```

### Molde 1 - Guardar versión (siempre)
```
git status # QUÉ ES: ver qué cambió / POR QUÉ: ver antes de guardar
git add . # QUÉ ES: meter al carrito / POR QUÉ: Git solo guarda lo del carrito
git commit -m "tipo: descripción" # QUÉ ES: guardar local / POR QUÉ: aún no está en GitHub
git log --oneline -5 # QUÉ ES: historial / POR QUÉ: confirmar que se guardó
```

### Molde 3 - Segundo commit en adelante (ciclo diario)
```
git status # Esperas: modified: algún archivo
git add .
git commit -m "nota: descripción"
git log --oneline -5 # Tu nueva versión arriba
git push # QUÉ ES: subir a GitHub / POR QUÉ: sin -u, ya está vinculado
git status # Esperas: up to date + clean
```

### Molde 2 - Enlazar y primer push (una vez por proyecto) — FALTABA, ya agregado
```
git remote -v # QUÉ ES: muestra enlace / POR QUÉ: vacío = sin enlace, con origin = enlazado
git remote add origin https://github.com/miguelzurita009/Curso-csharp.git # QUÉ ES: guarda URL con nombre origin / POR QUÉ: solo una vez
git push -u origin main # QUÉ ES: sube main y vincula / POR QUÉ: -u solo primera vez
# remoto = copia en GitHub / origin = nombre corto / push = subir
```

Tipos de commit: `init, nota, ejercicio, proyecto, fix` — QUÉ ES: prefijo del mensaje / POR QUÉ: ordena tu historial

## Qué aprendí (1 frase)
- Git guarda versiones local con commit y las sube a GitHub con push, el enlace se hace una vez con remote add origin.

## Duda para mañana
- ¿Qué es HTTP/REST y cómo lo usa una API .NET?
