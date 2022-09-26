using LibraryMicroservice.Model;
using LibraryMicroservice.Model.DTOs;

namespace LibraryMicroservice.Repositories
{
    public class AlbumsRepository : IAlbumsRepository
    {
        private List<Album> _albums;
        public AlbumsRepository()
        {
            _albums = new List<Album>();
        }
        public Album AddAlbum(AlbumDTO albumDTO)
        {
            
            foreach(Album a in _albums)
            {
                if (a.Id == albumDTO.Id)
                    return a;
            }

            Album album = new Album(albumDTO.Id, albumDTO.Name, albumDTO.Artist, albumDTO.Artist, albumDTO.Url);
            _albums.Add(album);

            return album;
        }
    }
}
