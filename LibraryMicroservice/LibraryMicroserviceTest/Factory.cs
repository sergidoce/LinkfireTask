using LibraryMicroservice.Controllers;
using LibraryMicroservice.Repositories;
using LibraryMicroservice.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Microsoft.Extensions.Logging;
using LibraryMicroservice.Services;

namespace LibraryMicroserviceTest
{
    public class Factory
    {
        public UserController CreateUserController(IUsersRepository usersRepository, IAlbumsRepository albumsRepository)
        {
            IUserService userService = CreateUserService(usersRepository, albumsRepository);
            var logger = new Mock<ILogger<UserController>>().Object;

            return new UserController(logger, userService);
        }

        public IUserService CreateUserService(IUsersRepository usersRepository, IAlbumsRepository albumsRepository)
        {
            return new UserService(usersRepository, albumsRepository);
        } 

        public IUsersRepository CreateUsersRepository()
        {
            return new UsersRepository();
        }

        public IAlbumsRepository CreateAlbumsRepository()
        {
            return new AlbumsRepository();
        }



    }
}
