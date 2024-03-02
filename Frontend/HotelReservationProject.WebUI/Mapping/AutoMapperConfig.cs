using AutoMapper;
using HotelProject.EntityLayer.Concrete;
using HotelReservationProject.WebUI.Dtos.ServiceDto;

namespace HotelReservationProject.WebUI.Mapping
{
	public class AutoMapperConfig : Profile
	{
		public AutoMapperConfig()
		{
			CreateMap<ResultServiceDto, Service>().ReverseMap();
			CreateMap<UpdateServiceDto, Service>().ReverseMap();
			CreateMap<CreateServiceDto, Service>().ReverseMap();
		}


	}
}
