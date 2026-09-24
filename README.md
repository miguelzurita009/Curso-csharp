# Curso C# / .NET - Miguel

Ruta junior empleable: C# + ASP.NET Core + SQL + Azure + IA integrada.

## Estructura
- `fase-00/` -> bases: Git, HTTP, SQL, entorno — POR QUÉ: sin base no puedes guardar ni entender tu código.
- `fase-01/` -> C# (próximo) — QUÉ ES: el lenguaje que aprenderás.
- `fase-02/` -> API + EF Core (próximo) — QUÉ ES: cómo C# habla con bases de datos y crea servicios.

## Molde 0: Firma inicial (una sola vez por PC)
Cada versión guarda tu nombre y email. Sin esto, `git commit` falla con `Author identity unknown`.

1. Comprobar si ya tienes firma: — POR QUÉ: si no hay firma, el commit falla.
```
git config --global user.name  # QUÉ ES: muestra tu nombre guardado / POR QUÉ: confirma si ya tienes firma
git config --global user.email # QUÉ ES: muestra tu email guardado / POR QUÉ: Git lo usa para firmar cada versión
```
- Si devuelve nombre y email, ya está. No hagas nada.
- Si devuelve vacío, ve al paso 2.

2. Solo si salió vacío, crear firma: — POR QUÉ: sin firma no puedes guardar versiones.
```
git config --global user.name "Tu Nombre"   # QUÉ ES: guarda tu nombre / POR QUÉ: aparecerá en cada versión que hagas
git config --global user.email "tu@email.com" # QUÉ ES: guarda tu email / POR QUÉ: GitHub lo usa para vincular tus aportes a tu cuenta
```
- `config` = configurar — QUÉ ES: cambia ajustes de Git.
- `--global` = para todos tus proyectos en este PC — POR QUÉ: lo haces una vez y vale para todo.

3. Verificar repitiendo el paso 1. Ahora debe devolver tu nombre y email.

## Mi molde de trabajo (repetir siempre) - Molde 1
1. `git status` — QUÉ ES: muestra qué cambió / POR QUÉ: antes de guardar debes ver qué vas a guardar.
2. `git add .` — QUÉ ES: mete todo al carrito (staging) / POR QUÉ: Git solo guarda lo que metes al carrito.
3. `git commit -m "tipo: descripción corta"` — QUÉ ES: guarda la versión con mensaje / POR QUÉ: el mensaje explica qué hiciste para tu yo futuro.
4. `git log --oneline -5` — QUÉ ES: muestra tus últimas 5 versiones / POR QUÉ: confirmas que se guardó bien.

Tipos: `init`, `nota`, `ejercicio`, `proyecto`, `fix`

## Molde 2: Enlazar a GitHub y subir (una vez por proyecto + uso diario)
- `remoto` — QUÉ ES: copia de tus versiones en GitHub / POR QUÉ: copia de seguridad + portafolio para empleo.
- `origin` — QUÉ ES: nombre corto de la URL de GitHub / POR QUÉ: para no escribir la URL larga cada vez.
- `push` — QUÉ ES: subir versiones locales a GitHub / POR QUÉ: si no haces push, GitHub no se entera.

1. Enlazar (una sola vez por proyecto):
```
git remote add origin https://github.com/miguelzurita009/Curso-csharp.git # QUÉ ES: guarda la dirección de GitHub con nombre origin / POR QUÉ: solo se enlaza una vez
git remote -v # QUÉ ES: muestra a dónde está enlazado / POR QUÉ: confirmas que el enlace quedó bien
```

2. Subir (siempre después de commit):
```
git push -u origin main # QUÉ ES: sube tu rama main a GitHub y la deja vinculada / POR QUÉ: -u es solo la primera vez, después basta con git push
git push                # QUÉ ES: sube cambios siguientes / POR QUÉ: ya quedó vinculado con -u
git status              # QUÉ ES: debe decir clean y up to date / POR QUÉ: confirmas que local y GitHub están iguales
```

## Molde 3: Segundo commit en adelante - ciclo diario completo (copiar tal cual)
POR QUÉ este molde: el primero fue especial con `-u`, todos los demás son así. Requisito: debes haber cambiado al menos 1 archivo, si no sale `nothing to commit`.
```
git status                         # QUÉ ES: ve qué cambió / POR QUÉ: debes ver antes de guardar. Esperas: modified: algún archivo
git add .                          # QUÉ ES: mete al carrito / POR QUÉ: Git solo guarda lo del carrito
git status                         # QUÉ ES: verifica carrito / POR QUÉ: esperas: Changes to be committed
git commit -m "nota: descripción"  # QUÉ ES: guarda versión local / POR QUÉ: aún NO está en GitHub, solo PC. Esperas: [main xxxxxxx]
git log --oneline -5               # QUÉ ES: historial / POR QUÉ: tu nueva versión debe salir arriba
git push                           # QUÉ ES: sube a GitHub / POR QUÉ: sin -u porque ya vinculaste. Esperas: main -> main
git status                         # QUÉ ES: verificación final / POR QUÉ: esperas: up to date with origin/main + clean
```
