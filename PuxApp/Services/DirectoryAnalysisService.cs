using PuxApp.Models;

namespace PuxApp.Services
{
    /// <summary>
    /// Analyzuje adresáře a detekci změn oproti předchozímu stavu (snapshotu).
    /// </summary>
    public class DirectoryAnalysisService
    {
        private readonly FileHashService _fileHashService;
        private readonly SnapshotStore _snapshotStore;
        private readonly DirectoryPathValidator _directoryPathValidator;

        public DirectoryAnalysisService(FileHashService fileHashService, SnapshotStore snapshotStore, DirectoryPathValidator directoryPathValidator)
        {
            _fileHashService = fileHashService;
            _snapshotStore = snapshotStore;
            _directoryPathValidator = directoryPathValidator;
        }

        /// <summary>
        /// Analyzuje adresáře a vrátí změny od posledního spuštění.
        /// </summary>
        /// <param name="directoryPath">Cesta k analyzovanému adresáři.</param>
        /// <returns>Výsledek analýzy změn.</returns>
        public DirectoryAnalysisResult Analyse(string directoryPath)
        {
            _directoryPathValidator.ValidatePath(directoryPath);

            DirectorySnapshot currentSnapshot = CreateCurrentSnapshot(directoryPath);
            DirectorySnapshot? previousSnapshot = _snapshotStore.Load(directoryPath);

            DirectoryAnalysisResult result = CompareSnapshots(previousSnapshot, currentSnapshot);

            _snapshotStore.Save(currentSnapshot);

            return result;
        }

        /// <summary>
        /// Porovná aktuální snapshot s předchozím.
        /// </summary>
        /// <param name="previousSnapshot">Předchozí snapshot.</param>
        /// <param name="currentSnapshot">Aktuální snapshot.</param>
        /// <returns>Výsledek analýzy změn.</returns>
        private DirectoryAnalysisResult CompareSnapshots(DirectorySnapshot? previousSnapshot, DirectorySnapshot currentSnapshot)
        {
            DirectoryAnalysisResult result = new();

            if (previousSnapshot is null)
            {
                result.IsInitialScan = true;
                result.NewFiles.AddRange(currentSnapshot.Files);
                return result;
            }

            Dictionary<string, FileSnapshotItem> previousFiles = previousSnapshot.Files
                .ToDictionary(file => file.RelativePath, file => file);

            Dictionary<string, FileSnapshotItem> currentFiles = currentSnapshot.Files
                .ToDictionary(file => file.RelativePath, file => file);

            foreach (FileSnapshotItem currentFile in currentSnapshot.Files)
            {
                // Nový soubory
                if (!previousFiles.TryGetValue(currentFile.RelativePath, out FileSnapshotItem? previousFile))
                {
                    currentFile.Version = 1;
                    result.NewFiles.Add(currentFile);
                    continue;
                }

                // Upravený soubory
                if (previousFile.Hash != currentFile.Hash)
                {
                    currentFile.Version = previousFile.Version + 1;
                    result.ModifiedFiles.Add(currentFile);
                }

                // Žádný změna
                else
                {
                    currentFile.Version = previousFile.Version;
                }
            }
            
            // Smazaný soubory
            foreach (FileSnapshotItem previousFile in previousSnapshot.Files)
            {
                if (!currentFiles.ContainsKey(previousFile.RelativePath))
                {
                    result.DeletedFiles.Add(previousFile.RelativePath);
                }
            }

            HashSet<string> currentDirectories = currentSnapshot.Directories.ToHashSet();

            // Smazaný složky
            foreach (string previousDirectory in previousSnapshot.Directories)
            {
                if (!currentDirectories.Contains(previousDirectory))
                {
                    result.DeletedDirectories.Add(previousDirectory);
                }
            }

            return result;
        }

        /// <summary>
        /// Vytvoří aktuální snapshot adresáře.
        /// </summary>
        /// <param name="directoryPath">Cesta k adresáři.</param>
        /// <returns>Aktuální snapshot adresáře.</returns>
        private DirectorySnapshot CreateCurrentSnapshot(string directoryPath)
        {
            List<FileSnapshotItem> files = Directory
                .GetFiles(directoryPath, "*", SearchOption.AllDirectories)
                .Select(filePath => new FileSnapshotItem
                {
                    RelativePath = Path.GetRelativePath(directoryPath, filePath),
                    Hash = _fileHashService.ComputeHash(filePath),
                    Version = 1
                })
                .OrderBy(file => file.RelativePath)
                .ToList();

            List<string> directories = Directory
                .GetDirectories(directoryPath, "*", SearchOption.AllDirectories)
                .Select(directory => Path.GetRelativePath(directoryPath, directory))
                .OrderBy(directory => directory)
                .ToList();

            return new DirectorySnapshot
            {
                DirectoryPath = directoryPath,
                Files = files,
                Directories = directories
            };
        }
    }
}
