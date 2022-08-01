using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docely.Persistence
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", false)
            .Build();

            string ConnectionStrings = configuration.GetConnectionString("ConnectionStrings");

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer());
            return services;
        }
    }
}


////MIGRACJA BAZY DANYCH
/// https://docs.microsoft.com/pl-pl/ef/core/managing-schemas/migrations/projects?tabs=dotnet-core-cli
/// INSTRUKCJA
/// Otwieramy CMD lub PowerShell
/// Wpisujemy cd i ścieżka do projektu
/// Następnie 
///dotnet ef migrations add NewMigration --project Docely.Persistence
/// i na koniec