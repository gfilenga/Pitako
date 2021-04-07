using System.Threading.Tasks;

namespace Pitako.Domain.Interfaces
{
    public interface IAWSS3Service
    {
        string BucketName { get; }
        Task<string> PutImgAsync(string base64, string path, string id);
        Task<string> DeleteImgAsync(string path, string id);
    }
}