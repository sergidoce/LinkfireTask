using LibraryMicroservice.Model.DTOs;

namespace LibraryMicroservice.Services.Interfaces
{
    public interface IUserService
    {
        AlbumDTO AddAlbumToLibrary(int userId, AlbumDTO albumDTO);
        bool RemoveAlbumFromLibrary(int userId, string album_id);
    }
}
