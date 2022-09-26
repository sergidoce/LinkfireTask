using LibraryMicroservice.Model.DTOs;

namespace LibraryMicroservice.Gateways
{
    public interface IAPIGateway
    {
        Task<List<AlbumDTO>> FindAlbums(string name, string artist);
    }
}
