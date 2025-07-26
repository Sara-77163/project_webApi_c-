using AutoMapper;
using final_project.Moddels;
using final_project.Moddels.DTO;


namespace final_project
{
    public class DonorProfile : Profile
    {
        public DonorProfile()
        {
            CreateMap<Donor, DonorDTO>();
            CreateMap<DonorDTO, Donor>();
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
            CreateMap<Gift, GiftDTO>();
            CreateMap<GiftDTO, Gift>();
            CreateMap<GiftCategory, GiftCategoryDTO>();
            CreateMap<GiftCategoryDTO, GiftCategory>();
        }
    }
}
