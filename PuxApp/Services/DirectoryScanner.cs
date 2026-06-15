using PuxApp.Models;

namespace PuxApp.Services
{
    /// <summary>
    /// Zajišťuje načtení seznamu souborů v adresáři.
    /// </summary>
    public class DirectoryScanner
    {
        /// <summary>
        /// Načte soubory z daného adresáře.
        /// </summary>
        /// <param name="path">Cesta k adresáři.</param>
        /// <returns>Seznam nalezených souborů</returns>
        /// <exception cref="ArgumentException">Zadaná cesta nesmí být prázdná.</exception>
        /// <exception cref="DirectoryNotFoundException">Zadaná cesta je neplatná.</exception>
        public List<FileItem> ReturnFilesFromDirectory(string path) 
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentException("Cesta nesmí být prázdná.");

            if (!Directory.Exists(path))
                throw new DirectoryNotFoundException("Zadaný adresář neexistuje.");

            return Directory
                .GetFiles(path)
                .Select(file => new FileItem
                {
                    Name = Path.GetFileName(file),
                    FullPath = file
                })
                .ToList();
        }
    }
}
