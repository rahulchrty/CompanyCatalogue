using System.Data;

namespace CompanyCatalogue.Interfaces
{
    public interface IFileParser
    {
        DataTable Parse(string filePath);
    }
}
