using final_project.DAL;
using final_project.Moddels;
using final_project.Moddels.DTO;

namespace final_project.BLL
{
    public class UserServices : IUserServices
    {
        private readonly IUserDal _userDal;
        public UserServices(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public async Task<User> AddUser(User user)
        {
            return await _userDal.AddUser(user);
        }

        public async Task DeleteUser(int id)
        {
            await _userDal.DeleteUser(id);
        }

        public async Task<List<User>> GetAllUser()
        {
            return await _userDal.GetAllUsers() ;
        }
        public async Task<User?> GetUserById(int id)
        {
            return await _userDal.GetUserById(id);
        }
        public async Task<User> UpdateUser(User user)
        {
            return await _userDal.UpdateUser(user);
        }
    }
}
