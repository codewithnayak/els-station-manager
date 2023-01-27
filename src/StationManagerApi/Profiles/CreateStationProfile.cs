using StationManagerApi.Db;
using StationManagerApi.Models;

namespace StationManagerApi.Profiles
{
    public class CreateStationProfile : AutoMapper.Profile
    {
        public CreateStationProfile()
        {
            CreateMap<Models.Address , Db.Address>();
            CreateMap<CreateStationRequest, Station>()
                .ForMember(d => d.StationIdentifier , opt => opt.MapFrom(s => System.Guid.NewGuid()))
                .ForMember(d => d.StationCode, opt => opt.MapFrom(s => $"{s.StateCode}/PS/01"))
                .ForMember(d => d.Address, opt => opt.MapFrom(s => s.Address));
        }
    }
}
