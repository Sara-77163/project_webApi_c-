using final_project.Moddels;
using final_project.Moddels.DTO;

namespace final_project.DAL
{
    public interface IDonorDal
    {
        public Task<List<Donor>> GetAllDonor();
        public Task<Donor> Updatedonor(Donor donor);
        public Task<Donor> AddDonor(Donor donor);
        public Task Delete(int id);
        public Task<List<Donor>> GetDonorsFiltered(string? name, string? email, string? giftName);
        public Task<Donor?> GetDonorById(int id); 
    }
}
