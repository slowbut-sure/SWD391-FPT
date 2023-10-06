using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ManagerApartment.Models;
using Services.Models.Response.StaffResponse;

namespace Services.AutoMappers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Staff, ResponseAccountStaff>()
                .ForMember(re => re.StaffId, act => act.MapFrom(src => src.StaffId))
                .ForMember(re => re.Email, act => act.MapFrom(src => src.Email))
                .ForMember(re => re.Name, act => act.MapFrom(src => src.Phone))
                .ForMember(re => re.Address, act => act.MapFrom(src => src.Address))
                .ForMember(re => re.StaffStatus, act => act.MapFrom(src => src.StaffStatus))
                .ForMember(re => re.AvatarLink, act => act.MapFrom(src => src.AvatarLink))
                .ForMember(re => re.Code, act => act.MapFrom(src => src.Code))
                .ForMember(re => re.StaffLogId, act => act.Ignore())
                .ForMember(re => re.StaffDetailId, act => act.Ignore());
        }
    }
}
