using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ManagerApartment.Models;
using Services.Models.Response.ApartmentResponse;
using Services.Models.Response.Asset;
using Services.Models.Response.Bill;
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

            CreateMap<Apartment, ResponseOfApartment>()
                .ForMember(re => re.ApartmentId, act => act.MapFrom(src => src.ApartmentId))
                .ForMember(re => re.ApartmentTypeId, act => act.MapFrom(src => src.ApartmentTypeId))
                .ForMember(re => re.BuildingId, act => act.MapFrom(src => src.BuildingId))
                .ForMember(re => re.BuildingName, act => act.MapFrom(src => src.Building.Name))
                .ForMember(re => re.BuildingAddress, act => act.MapFrom(src => src.Building.Address))
                .ForMember(re => re.OwnerId, act => act.MapFrom(src => src.OwnerId))
                .ForMember(re => re.OwnerName, act => act.MapFrom(src => src.Owner.Name))
                .ForMember(re => re.FromDate, act => act.MapFrom(src => src.FromDate))
                .ForMember(re => re.ToDate, act => act.MapFrom(src => src.ToDate))
                .ForMember(re => re.Sequence, act => act.MapFrom(src => src.Sequence))
                .ForMember(re => re.ApartmentStatus, act => act.MapFrom(src => src.ApartmentStatus));

            CreateMap<ApartmentType, ResponseOfApartmentType>()
                .ForMember(re => re.ApartmentTypeId, act => act.MapFrom(src => src.ApartmentTypeId))
                .ForMember(re => re.BuildingId, act => act.MapFrom(src => src.Building.BuildingId))
                .ForMember(re => re.BuildingName, act => act.MapFrom(src => src.Building.Name))
                .ForMember(re => re.BuildingAddress, act => act.MapFrom(src => src.Building.Address))
                .ForMember(re => re.ApartmentTypeName, act => act.MapFrom(src => src.Name))
                .ForMember(re => re.Description, act => act.MapFrom(src => src.Description))
                .ForMember(re => re.Status, act => act.MapFrom(src => src.Status));

            CreateMap<Asset, ResponseOfAsset>()
                .ForMember(re => re.AssetId, act => act.MapFrom(src => src.AssetId))
                .ForMember(re => re.AssetHistoryId, act => act.MapFrom(src => src.AssetHistoryId))
                .ForMember(re => re.ApartmentId, act => act.MapFrom(src => src.ApartmentId))
                .ForMember(re => re.Name, act => act.MapFrom(src => src.Name))
                .ForMember(re => re.Quantity, act => act.MapFrom(src => src.Quantity))
                .ForMember(re => re.Description, act => act.MapFrom(src => src.Description))
                .ForMember(re => re.ItemImage, act => act.MapFrom(src => src.ItemImage))
                .ForMember(re => re.Status, act => act.MapFrom(src => src.Status));

            CreateMap<AssetHistory, ResponseOfAssetHistory>()
                .ForMember(re => re.AssetHistoryId, act => act.MapFrom(src => src.AssetHistoryId))
                .ForMember(re => re.Code, act => act.MapFrom(src => src.Code))
                .ForMember(re => re.Date, act => act.MapFrom(src => src.Date))
                .ForMember(re => re.Quantity, act => act.MapFrom(src => src.Quantity))
                .ForMember(re => re.Description, act => act.MapFrom(src => src.Description))
                .ForMember(re => re.ItemImage, act => act.MapFrom(src => src.ItemImage))
                .ForMember(re => re.Status, act => act.MapFrom(src => src.Status));

            CreateMap<Bill, ResponseOfBill>()
                .ForMember(re => re.BillId, act => act.MapFrom(src => src.BillId))
                .ForMember(re => re.RequestId, act => act.MapFrom(src => src.RequestId))
                .ForMember(re => re.ApartmentId, act => act.MapFrom(src => src.Request.ApartmentId))
                .ForMember(re => re.Description, act => act.MapFrom(src => src.Request.Description))
                .ForMember(re => re.BookDateTime, act => act.MapFrom(src => src.Request.BookDateTime))
                .ForMember(re => re.EndDate, act => act.MapFrom(src => src.Request.EndDate))
                .ForMember(re => re.EndDate, act => act.MapFrom(src => src.TotalPrice))
                .ForMember(re => re.EndDate, act => act.MapFrom(src => src.Status));

        }
    }
}
