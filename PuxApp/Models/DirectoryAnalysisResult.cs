namespace PuxApp.Models
{
    /// <summary>
    /// Obsahuje výsledek porovnání aktuálního a předchozího stavu adresáře.
    /// </summary>
    public class DirectoryAnalysisResult
    {
        /// <summary>
        /// Seznam nových souborů.
        /// </summary>
        public List<FileSnapshotItem> NewFiles { get; set; } = new();

        /// <summary>
        /// Seznam změněných souborů.
        /// </summary>
        public List<FileSnapshotItem> ModifiedFiles { get; set; } = new();

        /// <summary>
        /// Seznam odstraněných souborů.
        /// </summary>
        public List<string> DeletedFiles { get; set; } = new();

        /// <summary>
        /// Seznam odstraněných podadresářů.
        /// </summary>
        public List<string> DeletedDirectories { get; set; } = new();

        /// <summary>
        /// Informace, zda jde o první analýzu adresáře.
        /// </summary>
        public bool IsInitialScan { get; set; }
    }
}