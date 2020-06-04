using CompanyCatalogue.Business;
using CompanyCatalogue.Interfaces;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class BusinessServiceExtention
    {
        public static IServiceCollection AddBusinessService(this IServiceCollection services)
        {
            services.AddScoped<IProcessCatalogueFile, ProcessCatalogueFile>();
            services.AddScoped<IFileParser, FileParser>();
            services.AddScoped<ICompanyCatalogueCollection, CompanyCatalogueCollection>();
            services.AddScoped<ISpreadsheetCellValue, SpreadsheetCellValue>();
            services.AddScoped<ICatalogueDetails, CatalogueDetails>();
            services.AddScoped<IDeleteCompany, DeleteCompany>();
            services.AddScoped<IDeleteCatalogue, DeleteCatalogue>();
            services.AddScoped<IUpdateCompanyDetailsValidation, UpdateCompanyDetailsValidation>();
            services.AddScoped<ICompanyUpdateModelValidation, CompanyUpdateModelValidation>();
            services.AddScoped<IUpdateCompanyDetails, UpdateCompanyDetails>();
            services.AddScoped<IRetrieveCatalogue, RetrieveCatalogue>();
            services.AddScoped<IProcessExport, ProcessExport>();
            services.AddScoped<IConstructExcelFile, ConstructExcelFile>();
            return services;
        }
    }
}
