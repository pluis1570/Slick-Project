using Microsoft.Extensions.DependencyInjection;
using Slick.Repositories.Skills;
using Slick.Services.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Slick.Api.Helpers
{
    public static class StartUpExtentions
    {
        public static void RegisterRepositories( this IServiceCollection services)
        {
            services.AddTransient<ISpecialisationLevelRepository, SpecialisationLevelRepository>();
        }
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<ISpecialisationLevelsService, SpecialisationLevelsService>();
        }
    }
}
