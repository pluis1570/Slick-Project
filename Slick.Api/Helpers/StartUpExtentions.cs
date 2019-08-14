using Microsoft.Extensions.DependencyInjection;
using Slick.Models.Contracts;
using Slick.Models.Costumers;
using Slick.Models.People;
using Slick.Models.Skills;
using Slick.Repositories.Enities;
using Slick.Repositories.Skills;
using Slick.Services.Contracts;
using Slick.Services.Costumers;
using Slick.Services.People;
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
            services.AddTransient<IEntityRepository<SpecialisationLevel>, EntityRepository<SpecialisationLevel>>();
            services.AddTransient<IEntityRepository<Contract>, EntityRepository<Contract>>();
            services.AddTransient<IEntityRepository<Consultant>, EntityRepository<Consultant>>();
            services.AddTransient<IEntityRepository<Employee>, EntityRepository<Employee>>();
            services.AddTransient<IEntityRepository<Account>, EntityRepository<Account>>();
            services.AddTransient<IEntityRepository<AccountManager>, EntityRepository<AccountManager>>();
            services.AddTransient<IEntityRepository<AccountConsultant>, EntityRepository<AccountConsultant>>();

        }
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<ISpecialisationLevelsService, SpecialisationLevelsService>();
            services.AddTransient<IConsultantsService, ConsultantsService>();
            services.AddTransient<IContractsService, ContractsService>();
            services.AddTransient<IEmployeesService, EmployeesService>();
            services.AddTransient<IAccountsService, AccountsService>();
            services.AddTransient<IAccountManagersService, AccountManagersSerivce>();
            services.AddTransient<IAccountsConsultantsService, AccountConsultantsService>();

        }


    }
}
