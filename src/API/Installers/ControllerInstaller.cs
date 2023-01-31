using API.Filters;
using Test.Models.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Text.Json;

namespace API.Installers
{
    public static class ControllerInstaller
    {
        public static void InstallControllers(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddControllers(setup =>
            {
                setup.OutputFormatters.Add(new SystemTextJsonOutputFormatter(new JsonSerializerOptions()));
                setup.ReturnHttpNotAcceptable = true;

                setup.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status200OK));
                setup.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status400BadRequest));
                setup.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status500InternalServerError));
                setup.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status406NotAcceptable));

                setup.Filters.Add<ValidationFilterAttribute>();
            });

            serviceCollection.AddFluentValidationAutoValidation();
            serviceCollection.AddValidatorsFromAssemblyContaining<HighestFrequencyWordRequestValidator>();

            serviceCollection.Configure<ApiBehaviorOptions>(options => { options.SuppressModelStateInvalidFilter = true; });
        }
    }
}
