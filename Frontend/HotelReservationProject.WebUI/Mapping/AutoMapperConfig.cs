using AutoMapper;
using HotelProject.EntityLayer.Concrete;
using HotelReservationProject.WebUI.Dtos.AboutDto;
using HotelReservationProject.WebUI.Dtos.LoginDto;
using HotelReservationProject.WebUI.Dtos.RegisterDto;
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
			CreateMap<CreateNewUserDto, AppUser>().ReverseMap();
			CreateMap<LoginUserDto, AppUser>().ReverseMap();

			CreateMap<ResultAboutDto,About>().ReverseMap();
			CreateMap<UpdateAboutDto,About>().ReverseMap();
		}


	}
}
