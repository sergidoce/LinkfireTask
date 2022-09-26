using LibraryMicroservice.Model;
using LibraryMicroservice.Model.DTOs;
using SpotifyAPI.Web;


namespace LibraryMicroservice.Gateways
{
    public class SpotifyGateway : IAPIGateway
    {
        SpotifyClient _spotifyClient;

        public SpotifyGateway()
        {
            var config = SpotifyClientConfig
                .CreateDefault()
                .WithAuthenticator(new ClientCredentialsAuthenticator("6d76f84feae243e4aeaeb3bbec86752b", "d19cf0a800084f0583fb2ac5bff45d92"));

            _spotifyClient = new SpotifyClient(config);
        }


        private string ConstructQuery(string name, string artist)
        {
            string query = "";

            if (name != null)
                query += "album=" + name + ",";
            if (artist != null)
                query += "artist=" + artist;

            return query;
        }

        public async Task<List<AlbumDTO>> FindAlbums(string name, string artist)
        {
            string query = ConstructQuery(name, artist);
            var searchRequest = new SearchRequest(SearchRequest.Types.Album, query);
            SearchResponse response = await _spotifyClient.Search.Item(searchRequest);

            List<AlbumDTO> result = new List<AlbumDTO>();

            if (response.Albums != null && response.Albums.Items != null)
            {
                foreach(SimpleAlbum album in response.Albums.Items)
                {
                    result.Add(new AlbumDTO(album.Id, album.Name, album.Artists[0].Name, album.Images[0].Url, album.ExternalUrls["spotify"]));
                }
            }
            return result;
        }
    }
}
