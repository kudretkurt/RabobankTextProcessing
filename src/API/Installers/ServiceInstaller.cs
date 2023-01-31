using Test;

namespace API.Installers
{
    public static class ServiceInstaller
    {
        public static void InstallServices(this IServiceCollection serviceCollection)
        {
           serviceCollection.AddScoped<IWordFrequencyAnalyzer, WordFrequencyAnalyzer>();
        }
    }
}
