using LibraryMicroservice.Model;

namespace LibraryMicroservice.Repositories
{

    /* The repositories classes are classes that interact with the data. In this case they also store the data because
     * I haven't used a database system for the task. Each repository has a list of model instances representing a table
     * in the database */
    public class UsersRepository : IUsersRepository
    {
        private List<User> _users;

        public UsersRepository()
        {
            // I initialize the list with some values because functionality to create users is not implemented.
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
