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
            services.AddScoped<IDeleteCompanyRepository, DeleteCompanyRepository>();
            services.AddScoped<IDeleteCataloguesRepository, DeleteCataloguesRepository>();
            services.AddScoped<IRetrieveCatalogueRepository, RetrieveCatalogueRepository>();
            services.AddScoped<IUpdateCompanyDetailsRepository, UpdateCompanyDetailsRepository>();
            services.AddScoped<IDeleteFile, DeleteFile>();
            return services;
        }
    }
}
