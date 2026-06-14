# PuxApp

ASP.NET Core aplikace pro sledování změn v lokálním adresáři.

## Verze

Aktuální verze: `0.1.0`

Podrobnosti o změnách jsou v [CHANGELOG.md](./CHANGELOG.md).

## Cíl projektu

Aplikace bude umět:

- načíst cestu k lokálnímu adresáři,
- analyzovat jeho obsah,
- porovnávat změny oproti minulému spuštění,
- evidovat nové, změněné a smazané soubory,
- verzovat soubory bez použití databáze.

## Technologie

- C#
- ASP.NET Core
- Visual Studio 2026
- Git

## Spuštění

```bash
dotnet run
```

## Plán dalších kroků

1. Přidat jednoduchý endpoint pro ověření, že aplikace běží.
2. Přidat statický frontend (`wwwroot/index.html`).
3. Přidat zadání cesty k adresáři.
4. Přidat skenování souborů.
5. Přidat ukládání snapshotu do JSON.
6. Přidat porovnání změn a verzování souborů.
