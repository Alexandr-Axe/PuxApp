using PuxApp.Services;

namespace PuxApp.Extensions
{
    /// <summary>
    /// Obsahuje metody pro registraci aplikačních služeb.
    /// </summary>
    public static class ServiceCollections
    {
        /// <summary>
        /// Zaregistruje služby používané aplikací.
        /// </summary>
        /// <param name="builder">Builder webové aplikace.</param>
        public static void AddApplicationServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddSingleton<DirectoryScanner>();
            builder.Services.AddSingleton<FileHashService>();
            builder.Services.AddSingleton<SnapshotStore>();
        }
    }
}
