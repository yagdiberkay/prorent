using AutoMapper;
using Umbraco.Web.UI.Dto;
using Umbraco.Web.UI.LiveProrent24Service;
using Umbraco.Web.UI.Models;

namespace Umbraco.Web.UI.Mapping
{
    public class Mapping : Profile
    {
        public MapperConfiguration MappingConfig()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ReservationModel, ReservationDto>()
                .ForMember(dst => dst.addresses, act => act.MapFrom(src => src.addresses));

                cfg.CreateMap<reservation, ReservationModel>()
                .ForMember(dst => dst.addresses, act => act.MapFrom(src => src.addresses));
                cfg.CreateMap<InsertReservationResponse1, OperationResultModel>();
            });

            return config;
        }
    }
}
