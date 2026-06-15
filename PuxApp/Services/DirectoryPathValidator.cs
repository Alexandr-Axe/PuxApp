namespace PuxApp.Services
{
    /// <summary>
    /// Zajišťuje validaci cesty k adresáři.
    /// </summary>
    public class DirectoryPathValidator
    {
        /// <summary>
        /// Ověří, zda je zadaná cesta platná a zda adresář existuje.
        /// </summary>
        /// <param name="path">Cesta k adresáři.</param>
        /// <exception cref="ArgumentException">Zadaná cesta nesmí být prázdná.</exception>
        /// <exception cref="DirectoryNotFoundException">Zadaná cesta je neplatná.</exception>
        public void ValidatePath(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentException("Cesta nesmí být prázdná.");

            if (!Directory.Exists(path))
                throw new DirectoryNotFoundException("Zadaný adresář neexistuje.");
        }
    }
}