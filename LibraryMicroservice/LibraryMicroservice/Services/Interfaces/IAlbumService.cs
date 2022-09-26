using LibraryMicroservice.Model.DTOs;

namespace LibraryMicroservice.Services.Interfaces
{
    public interface IAlbumService
    {
        Task<List<AlbumDTO>> FindAlbums(string name, string artist);
    }
}
