using LibraryMicroservice.Model;
using LibraryMicroservice.Model.DTOs;

namespace LibraryMicroservice.Repositories
{
    public interface IAlbumsRepository
    {
        Album AddAlbum(AlbumDTO albumDTO);
    }
}
