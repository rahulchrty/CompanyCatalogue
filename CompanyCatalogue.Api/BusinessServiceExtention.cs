﻿using CompanyCatalogue.Business;
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
            return services;
        }
    }
}
