# Curso C# / .NET - Miguel

Ruta junior empleable: C# + ASP.NET Core + SQL + Azure + IA integrada.

## Estructura
- `fase-00/` -> bases: Git, HTTP, SQL, entorno
- `fase-01/` -> C# (próximo)
- `fase-02/` -> API + EF Core (próximo)

## Molde 0: Firma inicial (una sola vez por PC)
Cada versión guarda tu nombre y email. Sin esto, `git commit` falla con `Author identity unknown`.

1. Comprobar si ya tienes firma:
```
git config --global user.name
git config --global user.email
```
- Si devuelve nombre y email, ya está. No hagas nada.
- Si devuelve vacío, ve al paso 2.

2. Solo si salió vacío, crear firma:
```
git config --global user.name "Tu Nombre"
git config --global user.email "tu@email.com"
```
- `config` = configurar, `--global` = para todos tus proyectos en este PC.

3. Verificar repitiendo el paso 1. Ahora debe devolver tu nombre y email.

## Mi molde de trabajo (repetir siempre) - Molde 1
1. `git status`
2. `git add .`
3. `git commit -m "tipo: descripción corta"`
4. `git log --oneline -5`

Tipos: `init`, `nota`, `ejercicio`, `proyecto`, `fix`
