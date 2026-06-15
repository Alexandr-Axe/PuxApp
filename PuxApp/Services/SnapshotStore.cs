using PuxApp.Models;
using System.Text;
using System.Text.Json;

namespace PuxApp.Services
{
    /// <summary>
    /// Ukládá a načítá snapshoty adresáře do JSON souborů.
    /// </summary>
    public class SnapshotStore
    {
        private const string SnapshotFolderName = "Snapshots";

        /// <summary>
        /// Načte snapshot pro zadaný adresář, pokud existuje.
        /// </summary>
        /// <param name="directoryPath">Cesta k analyzovanému adresáři.</param>
        /// <returns>Načtený snapshot.</returns>
        public DirectorySnapshot? Load(string directoryPath)
        {
            string snapshotPath = GetSnapshotFilePath(directoryPath);

            if (!File.Exists(snapshotPath))
                return null;

            string json = File.ReadAllText(snapshotPath);
            return JsonSerializer.Deserialize<DirectorySnapshot>(json);
        }

        /// <summary>
        /// Uloží snapshot zadaného adresáře.
        /// </summary>
        /// <param name="snapshot">Snapshot k uložení.</param>
        public void Save(DirectorySnapshot snapshot)
        {
            Directory.CreateDirectory(SnapshotFolderName);

            string snapshotPath = GetSnapshotFilePath(snapshot.DirectoryPath);

            string json = JsonSerializer.Serialize(snapshot, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(snapshotPath, json);
        }

        private static string GetSnapshotFilePath(string directoryPath)
        {
            string safeName = Convert.ToHexString(
                Encoding.UTF8.GetBytes(directoryPath));

            return Path.Combine(SnapshotFolderName, $"{safeName}.json");
        }
    }
}