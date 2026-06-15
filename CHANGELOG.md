# Changelog

Všechny změny v projektu budou evidovány v tomto souboru.

Projekt používá [Semantic Versioning](https://semver.org/).

## [0.5.0] - 15.06.2026

### Přidáno
- Služba pro analýzu adresáře, která porovnává aktuální snapshot s předchozím
  a detekuje nové, změněné a smazané soubory a podadresáře.
- API endpoint `POST /api/analyse`, který vrací strukturovaný JSON s detekovanými změnami
  a verzemi souborů.

## [0.4.1] - 15.06.2026

## Přidáno
- Refaktorace kódu pro lepší strukturu a čitelnost.

## [0.4.0] - 15.06.2026

## Přidáno
- Přidána služba `DirectoryScanner` pro načítání souborů z vybraného adresáře.
- Přidán model `FileItem` pro přenos informací o nalezených souborech.
- Přidáno zobrazení seznamu nalezených souborů ve webovém rozhraní.

## [0.3.0] - 15.06.2026

### Přidáno
- Přidán formulář pro zadání cesty k adresáři.
- Přidán JS pro odeslání požadavku.
- Přidán endpoint `POST /api/analyse`.
- Přidáno základní propojení mezi frontendem a backendem.

## [0.2.0] - 14.06.2026

### Přidáno
- Přidána statická HTML stránka ve složce `wwwroot`.
- Přidán základní formulář s textboxem, tlačítkem a místem pro výsledek.

## [0.1.0] - 14.06.2026

### Přidáno
- Vytvořen ASP.NET Core Empty projekt.
- Přidán základní README soubor.
