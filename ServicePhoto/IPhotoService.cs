using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;

namespace Picture.Service
{
    public interface IPictureService
    {
        Task<IEnumerable<Album>> GetAllPhotosByUrlAsync(string url);

        Task<IEnumerable<Photo>> GetDetailsPhotoByUrlAsync(string url);
    }
}