# Fase 00 - Notas (molde)

## Qué hice hoy
- 2026-09-24 - verifiqué entorno: Git 2.49 ok, .NET 6 y 9 ok, VS Code ok, Docker falta (se instala en Fase 3)
- 2026-09-24 - comprobé firma Git: Miguel / miguelzurita009@gmail.com ya configurada
- 2026-09-24 - creé molde base: README.md + .gitignore + notas.md
- 2026-09-24 - renombré rama master -> main
- 2026-09-24 - enlacé a GitHub: https://github.com/miguelzurita009/Curso-csharp.git
- 2026-09-24 - practiqué segundo commit + push
- 2026-09-24 - practiqué HTTP 0.3: leí https://jsonplaceholder.typicode.com/posts/1, método GET, status 200, title sunt aut facere...

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

### Molde 2 - Enlazar y primer push (una vez por proyecto) — FALTABA, ya agregado
```
git remote -v # QUÉ ES: muestra enlace / POR QUÉ: vacío = sin enlace, con origin = enlazado
git remote add origin https://github.com/miguelzurita009/Curso-csharp.git # QUÉ ES: guarda URL con nombre origin / POR QUÉ: solo una vez
git push -u origin main # QUÉ ES: sube main y vincula / POR QUÉ: -u solo primera vez
# remoto = copia en GitHub / origin = nombre corto / push = subir
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

### Molde 4 - Revertir cuando algo salió mal
```
# Caso 1 - cambié archivo pero NO hice commit:
# git status # ves modified: archivo
# git restore fase-00/prueba-revert.txt # QUÉ ES: descarta cambio / POR QUÉ: vuelve a última versión

# Caso 2 - commit local sin push:
# git log --oneline -5 # QUÉ ES: ver hashes / POR QUÉ: necesitas el código de la versión buena
# git reset --soft HEAD~1 # QUÉ ES: deshace commit guardando cambios / POR QUÉ: HEAD~1 = una atrás, no pierdes nada

# Caso 3 - ya hice push (lo seguro, igual que chat y README):
# git log --oneline -5 # QUÉ ES: busca hash malo, ej 68ae698 / POR QUÉ: debes decirle cuál deshacer
# git revert 68ae698 --no-edit # QUÉ ES: crea nueva versión que deshace la mala / POR QUÉ: --no-edit = no abrir editor, no borra historia
# git push # QUÉ ES: sube el deshacer / POR QUÉ: GitHub queda bueno otra vez
# NUNCA push --force — POR QUÉ: rompe historia y portafolio
```

### Molde 5 - Ver, traer y clonar (cerrar Git base)
```
# diff = ver líneas antes de guardar / POR QUÉ: status dice nombre, diff evita subir error
# git status # Esperas: modified:
# git diff # QUÉ ES: rojo borrado verde agregado / POR QUÉ: revisas antes del carrito
# git diff --staged # QUÉ ES: qué hay en carrito / POR QUÉ: verificas después de add
# pull = traer de GitHub, gemelo de push / POR QUÉ: sin bajar trabajas con código viejo
# git pull # QUÉ ES: baja origin/main / POR QUÉ: ya vinculado, esperas Already up to date
# clone = copiar repo a carpeta nueva / POR QUÉ: recupera en otra PC
# git clone https://github.com/miguelzurita009/Curso-csharp.git # crea carpeta con .git incluido
```

Tipos de commit: `init, nota, ejercicio, proyecto, fix` — QUÉ ES: prefijo del mensaje / POR QUÉ: ordena tu historial

## Qué aprendí (1 frase)
- Git guarda versiones local con commit y las sube a GitHub con push, y el navegador lee APIs con GET que devuelve 200 + JSON.

## Duda para mañana
- ¿Cómo pido datos con SQL SELECT WHERE JOIN?
