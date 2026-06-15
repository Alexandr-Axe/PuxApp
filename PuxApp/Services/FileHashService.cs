using System.Security.Cryptography;

namespace PuxApp.Services
{
    /// <summary>
    /// Vypočítává hashů souborů.
    /// </summary>
    public class FileHashService
    {
        /// <summary>
        /// Vypočítá SHA-256 hash souboru.
        /// </summary>
        /// <param name="filePath">Cesta k souboru.</param>
        /// <returns>Hash souboru.</returns>
        public string ComputeHash(string filePath)
        {
            using FileStream stream = File.OpenRead(filePath);
            using SHA256 sha256 = SHA256.Create();

            byte[] hashBytes = sha256.ComputeHash(stream);
            return Convert.ToHexString(hashBytes);
        }
    }
}