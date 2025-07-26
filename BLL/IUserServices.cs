using final_project.Moddels;

namespace final_project.BLL
{
    public interface IUserServices
    {
        public Task<List<User>> GetAllUser();
        public Task<User> UpdateUser(User user);
        public Task<User> AddUser(User user);
        public Task DeleteUser(int id);
        public Task<User?> GetUserById(int id);

    }
}
