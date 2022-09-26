using LibraryMicroservice.Model;

namespace LibraryMicroservice.Repositories
{
    public interface IUsersRepository
    {
        User GetUserById(int userId);

        bool UpdateUser(User user);
    }
}
