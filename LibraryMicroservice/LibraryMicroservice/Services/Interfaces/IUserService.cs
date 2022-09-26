using LibraryMicroservice.Model.DTOs;

namespace LibraryMicroservice.Services.Interfaces
{
    public interface IUserService
    {
        /* Finds a user and adds the album to its library, if the album is already there, it does nothing */
        AlbumDTO AddAlbumToLibrary(int userId, AlbumDTO albumDTO);
        bool RemoveAlbumFromLibrary(int userId, string album_id);
    }
}
