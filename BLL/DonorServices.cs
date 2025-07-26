using final_project.DAL;
using final_project.Moddels;

namespace final_project.BLL
{
    public class DonorServices : IDonorServices
    {
        private readonly IDonorDal _donorDal;
        public DonorServices(IDonorDal donorDal)
        {
           _donorDal = donorDal;
        }
        public async Task<Donor> AddDonor(Donor donor)
        {
            return await _donorDal.AddDonor(donor);
        }

        public async Task DeleteDonor(int id)
        {
            await _donorDal.Delete(id);
        }

        public async Task<List<Donor>> GetAllDonor()
        {
            return await _donorDal.GetAllDonor();
        }
        public async Task<Donor?> GetDonorByID(int id )
        {
            return await _donorDal.GetDonorById(id);

        }

        public async Task<Donor> Updatedonor(Donor donor)
        {
            return await _donorDal.Updatedonor(donor);
        }
        public  async Task<List<Donor>> GetDonorsFiltered(string? name, string? email, string? giftName)
        {
            return await _donorDal.GetDonorsFiltered(name, email, giftName);
        }

    }
}
