using final_project.Moddels;
using final_project.Moddels.DTO;
using Microsoft.EntityFrameworkCore;

namespace final_project.DAL
{
    public class DonorDal : IDonorDal
    {
        private readonly ChinaSaleContext _chainaSaleContext;
        public DonorDal(ChinaSaleContext _chainaSaleContext)
        {
            this._chainaSaleContext = _chainaSaleContext;
        }
        public async  Task<List<Donor>> GetAllDonor()
        {
            return await _chainaSaleContext.Donors.Include(d => d.Gifts).ToListAsync();
        }
        public async Task<Donor?> GetDonorById(int id)
        {
            return await _chainaSaleContext.Donors
                                            .Include(d => d.Gifts) 
                                            .FirstOrDefaultAsync(d => d.Id == id);
        }
        public async Task<Donor> AddDonor(Donor donor)
        {
            await  _chainaSaleContext.Donors.AddAsync(donor);
            await _chainaSaleContext.SaveChangesAsync();
            return donor;
        }

        public async  Task Delete(int id)
        {
            //await _chainaSaleContext.Donors.Where(d=>d.Id==id).ExecuteDeleteAsync();
            Donor donor = await _chainaSaleContext.Donors.Where(d => d.Id == id).FirstOrDefaultAsync();
            if (donor != null)
            {
                _chainaSaleContext.Donors.Remove(donor);
                await _chainaSaleContext.SaveChangesAsync();
            }
        }

        public async Task<Donor> Updatedonor(Donor donor)
        {
             _chainaSaleContext.Donors.Update(donor);
            await _chainaSaleContext.SaveChangesAsync();
            return donor;
        }
        public async Task<List<Donor>> GetDonorsFiltered(string? name, string? email, string? giftName)
        {
            IQueryable<Donor> query = _chainaSaleContext.Donors.AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(d => d.Name.Contains(name));
            }

            if (!string.IsNullOrWhiteSpace(email))
            {
                query = query.Where(d => d.Email.Contains(email));
            }

            if (!string.IsNullOrWhiteSpace(giftName))
            {
                query = query.Include(d => d.Gifts) 
                             .Where(d => d.Gifts.Any(g => g.Name.Contains(giftName))); 
            }

            return await query.ToListAsync();
        }

    }
}
