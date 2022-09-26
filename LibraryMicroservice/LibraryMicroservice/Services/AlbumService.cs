using LibraryMicroservice.Gateways;
using LibraryMicroservice.Model.DTOs;
using LibraryMicroservice.Services.Interfaces;
using Microsoft.Net.Http.Headers;
using SpotifyAPI.Web;
namespace LibraryMicroservice.Services
{
    public class AlbumService : IAlbumService
    {
        IAPIGateway _apiGateway;
        public AlbumService(IAPIGateway apiGateway)
        {
            _apiGateway = apiGateway;
        }

        public async Task<List<AlbumDTO>> FindAlbums(string name, string artist)
        {
            return await _apiGateway.FindAlbums(name, artist);
        }
    }
}
