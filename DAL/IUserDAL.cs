using final_project.Moddels;

namespace final_project.DAL
{
    public interface IUserDal
    {
        public Task<List<User>> GetAllUsers();
        public Task<User> UpdateUser(User user);
        public Task<User> AddUser(User user);
        public Task DeleteUser(int id);
        public Task<User?> GetUserById(int id);

    }
}
