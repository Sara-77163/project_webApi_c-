using final_project.Moddels;

namespace final_project.BLL
{
    public interface IDonorServices
    {
        public Task<List<Donor>> GetAllDonor();
        public Task<Donor> Updatedonor(Donor donor);
        public Task<Donor> AddDonor(Donor donor);
        public Task DeleteDonor(int id);
        public  Task<List<Donor>> GetDonorsFiltered(string? name, string? email, string? giftName);
        public Task<Donor?> GetDonorByID(int id);

        


    }
}
