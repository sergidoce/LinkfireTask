using LibraryMicroservice.Model;
using LibraryMicroservice.Model.DTOs;
using LibraryMicroservice.Repositories;
using LibraryMicroservice.Services.Interfaces;

namespace LibraryMicroservice.Services
{
    public class UserService : IUserService
    {
        private IUsersRepository _usersRepository;
        private IAlbumsRepository _albumsRepository;

        public UserService(IUsersRepository usersRepository, IAlbumsRepository albumsRepository)
        {
            _usersRepository = usersRepository;
            _albumsRepository = albumsRepository;
        }

        public AlbumDTO AddAlbumToLibrary(int userId, AlbumDTO albumDTO)
        {
            User user = _usersRepository.GetUserById(userId);

            if (user == null)
                return null;

            Album album = _albumsRepository.AddAlbum(albumDTO);

            user.AddAlbumToLibrary(album);
            _usersRepository.UpdateUser(user);
            return new AlbumDTO(album.Id, album.Name, album.Artist, album.Cover, album.Url);
        }

        public bool RemoveAlbumFromLibrary(int userId, string album_id)
        {
            User user = _usersRepository.GetUserById(userId);

            if (user == null)
                return false;

            var result = user.RemoveAlbumFromLibrary(album_id);

            if(result)
                _usersRepository.UpdateUser(user);

            return result;
        }
    }
}
