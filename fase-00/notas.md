# Fase 00 - Notas (molde)

## Qué hice hoy
- 2026-09-24 - aprendí segundo commit y push a GitHub

## Comandos que repetí

### Molde 0 - Firma (una vez por PC)
```
git config --global user.name
git config --global user.email
# Solo si sale vacío:
# git config --global user.name "Tu Nombre"
# git config --global user.email "tu@email.com"
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

## Qué aprendí (1 frase)
-

## Duda para mañana
-
