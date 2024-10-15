using AutoMapper;
using VietKoiShow.ModelMapper;
using VietKoiShow.Models;

namespace VietKoiShow.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<TblkoiFish, KoiFishModel>().ReverseMap();
            //////dcmm
        }
    }
}
