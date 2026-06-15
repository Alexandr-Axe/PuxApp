## Testovací scénáře

1. Prázdný vstup
   - Krok: Nechat pole prázdné a kliknout na "Analyzovat".
   - Očekávání: Zobrazí se hláška "Zadej cestu k adresáři.".

2. Neexistující cesta
   - Krok: Zadám neplatnou cestu (např. `C:\neexistuje`) a kliknu na "Analyzovat".
   - Očekávání: Zobrazí se chybová hláška z backendu nebo obecná chyba.

3. První analýza existujícího adresáře
   - Krok: Zadám cestu k adresáři s několika soubory, poprvé spustím analýzu.
   - Očekávání: `První spuštění: Ano`, přehled souborů podle logiky backendu.

4. Druhá analýza po změně souboru
   - Krok: Změním obsah existujícího souboru, znovu spustím analýzu.
   - Očekávání: Soubor je v sekci "Změněné soubory" s odpovídající verzí.

5. Smazaný soubor nebo složka
   - Krok: Smažu soubor nebo podadresář, znovu spustím analýzu.
   - Očekávání: Položky se objeví v sekcích "Odstraněné soubory" nebo "Odstraněné podadresáře".