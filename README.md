# PuxApp

PuxApp je webová aplikace v ASP.NET Core pro analýzu změn v adresáři.
Uživatel zadá cestu k adresáři a aplikace zobrazí informace o nových, změněných a odstraněných souborech a složkách.

## Verze

Aktuální verze: `1.0.0`

Podrobnosti o změnách jsou v [CHANGELOG.md](./CHANGELOG.md).

## Funkce

- Analýza zadaného adresáře.
- Zobrazení nových souborů.
- Zobrazení změněných souborů.
- Zobrazení odstraněných souborů.
- Zobrazení odstraněných podadresářů.
- Zobrazení verzí souborů.

## Technologie

- C#
- ASP.NET Core
- HTML, JS, CSS

## Struktura projektu

- `Program.cs` – konfigurace aplikace
- `Extensions/` – registrace služeb a endpointů
- `Services/` – aplikační logika
- `Models/` – datové modely
- `wwwroot/index.html` – uživatelské rozhraní
- `wwwroot/js/app.js` – frontend logika
- `wwwroot/css/site.css` – styly
- `TESTING.md` – testovací scénáře
- `CHANGELOG.md` – přehled hlavních změn

## Spuštění

## Spuštění projektu

1. Otevřete projekt v terminálu.
2. Spusťte aplikaci:

```bash
dotnet run
```

3. Po spuštění otevřete adresu zobrazenou v konzoli, například:

```text
http://localhost:5041
```

## Použití

1. Otevřete webové rozhraní aplikace.
2. Zadejte cestu k adresáři.
3. Klikněte na tlačítko **Analyzovat**.
4. Zobrazí se výsledek analýzy adresáře.

## Výstup analýzy

Aplikace může zobrazit:

- nové soubory,
- změněné soubory,
- odstraněné soubory,
- odstraněné podadresáře,
- verze souborů.

## Testování

Testovací scénáře jsou sepsané v souboru [TESTING.md](./TESTING.md).

## Poznámky

- Zadaná cesta musí existovat a být dostupná aplikaci.
- Při neplatné cestě nebo chybě serveru se zobrazí chybová hláška.

## Checklist

- Projekt se spustí pomocí `dotnet run` bez chyb.
- Webové rozhraní se načte a zobrazí formulář pro cestu k adresáři.
- Frontend správně volá endpoint `/api/analyse`.
- Všechny hlavní scénáře prošly ručními testy sepsanými v [TESTING.md](./TESTING.md).
- Při chybě (neplatná cesta, nedostupný server) se zobrazí srozumitelná hláška.
- README a tento soubor odpovídají aktuálnímu stavu aplikace.