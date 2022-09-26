using LibraryMicroservice.Model;

namespace LibraryMicroservice.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private List<User> _users;

        public UsersRepository()
        {
            _users = new List<User>()
            {
                new User(1, "Agnes"),
                new User(2, "Sergi")
            };
        }

        public User GetUserById(int userId)
        {
            foreach(User user in _users)
            {
                if (user.Id == userId)
                    return user;
            }
            return null;
        }

        public bool UpdateUser(User user)
        {
            for(int i = 0; i < _users.Count; i++)
            {
                if (_users[i].Id == user.Id)
                {
                    _users[i] = user;
                    return true;
                }
            }

            return false;
        }
    }
}
