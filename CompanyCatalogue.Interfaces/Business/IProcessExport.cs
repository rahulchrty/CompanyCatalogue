using System.Threading.Tasks;

namespace CompanyCatalogue.Interfaces
{
    public interface IProcessExport
    {
        Task<byte[]> Export(string catalogueId);
    }
}
