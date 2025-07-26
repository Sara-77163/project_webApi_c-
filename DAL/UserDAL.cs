using final_project.Moddels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace final_project.DAL
{
    public class UserDal : IUserDal
    {

        private readonly ChinaSaleContext _chainaSaleContext;
        public UserDal(ChinaSaleContext _chainaSaleContext)
        {
            this._chainaSaleContext = _chainaSaleContext;
        }
        public async Task<User> AddUser(User user)
        {
            await _chainaSaleContext.Users.AddAsync(user);
            await _chainaSaleContext.SaveChangesAsync();
            return user;
        }

        public async Task DeleteUser(int id)
        {
            User user = await _chainaSaleContext.Users.Where(user => user.Id == id).FirstOrDefaultAsync();
            if(user!=null)
            {
                _chainaSaleContext.Users.Remove(user);
                await  _chainaSaleContext.SaveChangesAsync();
            }
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _chainaSaleContext.Users.ToListAsync();
        }
        public async Task<User?> GetUserById(int id)
        {
   
            return await _chainaSaleContext.Users.FindAsync(id);
        }


        public async Task<User> UpdateUser(User user)
        {
            //await _chainaSaleContext.Users.ExecuteUpdateAsync(user,);
            _chainaSaleContext.Users.Update(user);
            await _chainaSaleContext.SaveChangesAsync();
            return user;
        }
    }
}
