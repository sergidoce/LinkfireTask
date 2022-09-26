using LibraryMicroservice.Model;
using LibraryMicroservice.Model.DTOs;
using LibraryMicroservice.Repositories;
using LibraryMicroservice.Services;
using LibraryMicroservice.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace LibraryMicroserviceTest.ServiceTests
{
    public class UserServiceTests
    {
        private readonly ITestOutputHelper output;

        public UserServiceTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void AddAlbumToLibrary_Should_Success()
        {
            Factory factory = new Factory();

            IUsersRepository usersRepository = factory.CreateUsersRepository();
            IAlbumsRepository albumsRepository = factory.CreateAlbumsRepository();

            IUserService userService = factory.CreateUserService(usersRepository, albumsRepository);

            //Arrange
            AlbumDTO albumDTO = new AlbumDTO("test_id", "Hjem fra fabrikken", "Andreas Odbjerg", "test_cover", "test_url");

            //Act
            var result = userService.AddAlbumToLibrary(1, albumDTO);

            //Assert
            List<string> userLibrary = usersRepository.GetUserById(1).AlbumLibrary;

            string album_id = userLibrary.Find(x => x == "test_id");

            Assert.NotNull(result);
            Assert.Equal(albumDTO.Id, result.Id);
            Assert.NotNull(album_id);

        }

        [Fact]
        public void AddAlbumToLibrary_Should_NotFindUser()
        {
            Factory factory = new Factory();

            IUsersRepository usersRepository = factory.CreateUsersRepository();
            IAlbumsRepository albumsRepository = factory.CreateAlbumsRepository();

            IUserService userService = factory.CreateUserService(usersRepository, albumsRepository);

            //Arrange
            AlbumDTO albumDTO = new AlbumDTO("test_id", "Hjem fra fabrikken", "Andreas Odbjerg", "test_cover", "test_url");

            //Act
            var result = userService.AddAlbumToLibrary(4, albumDTO);

            //Assert
            Assert.Null(result);

        }
    }
}
