using PuxApp.Models;

namespace PuxApp.Services
{
    /// <summary>
    /// Zajišťuje načtení seznamu souborů v adresáři.
    /// </summary>
    public class DirectoryScanner
    {
        private readonly DirectoryPathValidator _directoryPathValidator;
        public DirectoryScanner(DirectoryPathValidator directoryPathValidator)
        {
            _directoryPathValidator = directoryPathValidator;
        }

        /// <summary>
        /// Načte soubory z daného adresáře.
        /// </summary>
        /// <param name="path">Cesta k adresáři.</param>
        /// <returns>Seznam nalezených souborů</returns>
        /// <exception cref="ArgumentException">Zadaná cesta nesmí být prázdná.</exception>
        /// <exception cref="DirectoryNotFoundException">Zadaná cesta je neplatná.</exception>
        public List<FileItem> ReturnFilesFromDirectory(string path)
        {
            _directoryPathValidator.ValidatePath(path);

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