using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace TBC.Application.Infrastructure.Services
{
    public interface IFileService
    {
        Task<string> Upload(IFormFile file);
        Task<byte[]> Download(string path);
    }
}
