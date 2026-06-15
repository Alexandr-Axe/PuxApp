namespace PuxApp.Models
{
    /// <summary>
    /// Představuje uložený stav jednoho souboru.
    /// </summary>
    public class FileSnapshotItem
    {
        /// <summary>
        /// Relativní cesta souboru vůči analyzovanému adresáři.
        /// </summary>
        public string RelativePath { get; set; } = string.Empty;

        /// <summary>
        /// Hash souboru.
        /// </summary>
        public string Hash { get; set; } = string.Empty;

        /// <summary>
        /// Aktuální verze souboru.
        /// </summary>
        public int Version { get; set; } = 1;
    }
}