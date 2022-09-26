using LibraryMicroservice.Model;
using LibraryMicroservice.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace LibraryMicroserviceTest.RepositoryTests
{
    public class UserRepositoryTests
    {
        private readonly ITestOutputHelper output;

        public UserRepositoryTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void GetUserById_Should_Success()
        {
            Factory factory = new Factory();

            IUsersRepository usersRepository = factory.CreateUsersRepository();

            //Arrange
            int userId = 1; 

            //Act
            User result = usersRepository.GetUserById(userId);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(userId, result.Id);
        }


        [Fact]
        public void GetUserById_Should_Not_Find_User()
        {
            Factory factory = new Factory();

            IUsersRepository usersRepository = factory.CreateUsersRepository();

            //Arrange
            int userId = -1;

            //Act
            User result = usersRepository.GetUserById(userId);

            //Assert
            Assert.Null(result);
        }

        [Fact]
        public void UpdateUser_ShouldSuccess()
        {
            Factory factory = new Factory();

            IUsersRepository usersRepository = factory.CreateUsersRepository();

            //Arrange
            int userId = 1;
            string newName = "Test";

            User user = usersRepository.GetUserById(userId);
            string oldName = user.Name;
            user.Name = newName;

            //Act
            bool result = usersRepository.UpdateUser(user);

            //Assert
            User updated_user = usersRepository.GetUserById(userId);
            Assert.True(result);
            Assert.NotEqual(newName, oldName);
            Assert.Equal(newName, updated_user.Name);
        }

        [Fact]
        public void UpdateUser_Should_Not_Find_User()
        {
            Factory factory = new Factory();

            IUsersRepository usersRepository = factory.CreateUsersRepository();

            //Arrange
            User user = new User(-1, "does_not_exist");

            //Act
            bool result = usersRepository.UpdateUser(user);

            //Assert
            Assert.False(result);
            
        }
    }
}
