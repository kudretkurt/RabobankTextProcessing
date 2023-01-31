using API.Installers;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

Console.WriteLine("API starting...");

var builder = WebApplication.CreateBuilder(args);
ConfigureHostSettings(builder.Host);
Console.WriteLine("Configured Host Settings...");
ConfigurationSettings(builder.Configuration);
RegisterServices(builder.Services, builder.Configuration);
Console.WriteLine("Services Registered...");
var app = builder.Build();

ConfigureWebApplication(app);

await app.RunAsync();

void ConfigurationSettings(IConfigurationBuilder configurationBuilder)
{
    configurationBuilder.SetBasePath(Directory.GetCurrentDirectory());
    configurationBuilder.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true);
    configurationBuilder.AddEnvironmentVariables();
}

void RegisterServices(IServiceCollection serviceCollection, IConfiguration configurationRoot)
{
    serviceCollection.InstallControllers();
    serviceCollection.InstallSwagger();
    serviceCollection.InstallServices();
}

void ConfigureHostSettings(IHostBuilder hostBuilder)
{
    //https://docs.microsoft.com/en-us/aspnet/core/migration/50-to-60-samples?view=aspnetcore-6.0
    // Wait 30 seconds for graceful shutdown.
    hostBuilder.ConfigureHostOptions(o => o.ShutdownTimeout = TimeSpan.FromSeconds(45));
}

void ConfigureWebApplication(IApplicationBuilder applicationBuilder)
{
    var provider = applicationBuilder.ApplicationServices.GetRequiredService<IApiVersionDescriptionProvider>();
    applicationBuilder.UseHttpsRedirection();
    applicationBuilder.UseRouting();
    applicationBuilder.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    applicationBuilder.UseSwagger();
    applicationBuilder.UseSwaggerUI(
        options =>
        {
            // build a swagger endpoint for each discovered API version
            foreach (var description in provider.ApiVersionDescriptions)
                options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                    description.GroupName.ToUpperInvariant());

            // response list for export : https://github.com/swagger-api/swagger-ui/issues/3832#issuecomment-942470952
            options.ConfigObject.AdditionalItems["syntaxHighlight"] = new Dictionary<string, object>
            {
                ["activated"] = false
            };
        });
}