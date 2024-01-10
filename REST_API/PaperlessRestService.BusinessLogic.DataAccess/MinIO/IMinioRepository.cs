using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperlessRestService.BusinessLogic.DataAccess.MinIO
{
    public interface IMinioRepository
    {
        Task UploadFileAsync(Stream fileStream, string filePath);

        Task<Stream> GetFileAsync(string filePath);

        Task DeleteFileAsync(string filePath);

        Task<bool> FileExistsAsync(string filePath);
    }
}
