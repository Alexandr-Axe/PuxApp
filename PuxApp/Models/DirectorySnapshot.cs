namespace PuxApp.Models
{
    /// <summary>
    /// Představuje uložený snapshot adresáře.
    /// </summary>
    public class DirectorySnapshot
    {
        /// <summary>
        /// Cesta k analyzovanému adresáři.
        /// </summary>
        public string DirectoryPath { get; set; } = string.Empty;

        /// <summary>
        /// Seznam souborů v snapshotu.
        /// </summary>
        public List<FileSnapshotItem> Files { get; set; } = new();

        /// <summary>
        /// Seznam podadresářů ve snapshotu.
        /// </summary>
        public List<string> Directories { get; set; } = new();
    }
}