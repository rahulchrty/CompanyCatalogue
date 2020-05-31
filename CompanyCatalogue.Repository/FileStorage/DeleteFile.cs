using CompanyCatalogue.Interfaces;
using System.IO;

namespace CompanyCatalogue.Repository
{
    public class DeleteFile : IDeleteFile
    {
        public void Delete(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}
