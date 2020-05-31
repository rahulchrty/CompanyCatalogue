using CompanyCatalogue.Interfaces;
using CompanyCatalogue.Repository;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class RepositoryServiceExtention
    {
        public static IServiceCollection AddRepositoryService(this IServiceCollection services)
        {
            services.AddScoped<ISaveFile, LocalStorage>();
            services.AddScoped<ICatalogueUOW, CatalogueUOF>();
            services.AddScoped<IRetrieveCatalogueDetailsRepository, RetrieveCatalogueDetailsRepository>();
            return services;
        }
    }
}
