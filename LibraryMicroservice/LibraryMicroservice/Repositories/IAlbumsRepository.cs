using LibraryMicroservice.Model;
using LibraryMicroservice.Model.DTOs;

namespace LibraryMicroservice.Repositories
{
    public interface IAlbumsRepository
    {
        /* Adds an album to the repository to register it in the system */
        Album AddAlbum(AlbumDTO albumDTO);
    }
}
