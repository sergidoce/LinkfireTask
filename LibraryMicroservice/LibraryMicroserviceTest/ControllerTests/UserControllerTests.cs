using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryMicroservice.Controllers;
using LibraryMicroservice.Model.DTOs;
using LibraryMicroservice.Repositories;
using LibraryMicroservice.Services;
using LibraryMicroservice.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Xunit.Abstractions;

namespace LibraryMicroserviceTest.ControllerTests
{
    public class UserControllerTests
    {

        private readonly ITestOutputHelper output;

        public UserControllerTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void AddAlbumToLibrary_Should_Success()
        {
            Factory factory = new Factory();

            IUsersRepository usersRepository = factory.CreateUsersRepository();
            IAlbumsRepository albumsRepository = factory.CreateAlbumsRepository();

            UserController userController = factory.CreateUserController(usersRepository, albumsRepository);

            //Arrange
            AlbumDTO albumDTO = new AlbumDTO("test_id", "Hjem fra fabrikken", "Andreas Odbjerg", "test_cover", "test_url");

            //Act
            var actionResult = userController.AddAlbumToLibrary(1, albumDTO);

            //Assert
            var result = actionResult as OkResult;
            Assert.NotNull(result);

        }

        [Fact]
        public void AddAlbumToLibrary_Should_NotFindUser()
        {
            Factory factory = new Factory();

            IUsersRepository usersRepository = new UsersRepository();
            IAlbumsRepository albumsRepository = new AlbumsRepository();

            UserController userController = factory.CreateUserController(usersRepository, albumsRepository);

            //Arrange
            AlbumDTO albumDTO = new AlbumDTO("test_id", "Hjem fra fabrikken", "Andreas Odbjerg", "test_cover", "test_url");

            //Act
            var actionResult = userController.AddAlbumToLibrary(5, albumDTO);

            //Assert
            var result = actionResult as NotFoundObjectResult;

            Assert.NotNull(result);

        }
    }
}
