using CompanyCatalogue.Models;
using System.Threading.Tasks;

namespace CompanyCatalogue.Interfaces
{
    public interface IProcessExport
    {
        Task<ExportModel> Export(string catalogueId);
    }
}
