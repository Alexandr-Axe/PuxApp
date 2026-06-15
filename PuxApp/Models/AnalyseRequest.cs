namespace PuxApp.Models
{
    /// <summary>
    /// Reprezentuje požadavek pro analýzu adresáře z webového rozhraní.
    /// </summary>
    public class AnalyseRequest
    {
        public string Path { get; set; } = string.Empty;
    }
}
