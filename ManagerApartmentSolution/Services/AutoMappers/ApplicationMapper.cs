using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entity;
using Domain.Enums.Role;
using Domain.Enums.Status;
using ManagerApartment.Models;
using Microsoft.AspNetCore.Routing.Constraints;
using Services.Models.Request.AssetRequest;
using Services.Models.Request.BuildingRequest;
using Services.Models.Request.OwnerRequest;
using Services.Models.Request.RequestDetailRequest;
using Services.Models.Request.RequestRequest;
using Services.Models.Request.ServiceRequest;
using Services.Models.Request.StaffRequest;
using Services.Models.Request.TennantRequest;
using Services.Models.Response;
using Services.Models.Response.Response.AddOnResponse;
using Services.Models.Response.Response.ApartmentResponse;
using Services.Models.Response.Response.Asset;
using Services.Models.Response.Response.Bill;
using Services.Models.Response.Response.BuildingResponse;
using Services.Models.Response.Response.ContractResponse;
using Services.Models.Response.Response.OwnerResponse;
using Services.Models.Response.Response.PackageResponse;
using Services.Models.Response.Response.RequestRespponse;
using Services.Models.Response.Response.ResponseAssetHistoryByAssetId;
using Services.Models.Response.Response.ServiceResponse;
using Services.Models.Response.Response.StaffResponse;
using Services.Models.Response.Response.TennantResponse;

namespace Services.AutoMappers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<AddOn, ResponseOfAddOn>()
                .ForMember(re => re.AddOnId, act => act.MapFrom(src => src.AddOnId))
                //.ForMember(re => re.RequestId, act => act.MapFrom(src => src.RequestId))
                //.ForMember(re => re.RequestDescription, act => act.MapFrom(src => src.Request.Description))
                //.ForMember(re => re.RequestBookDate, act => act.MapFrom(src => src.Request.BookDateTime))
                .ForMember(re => re.ServiceId, act => act.MapFrom(src => src.ServiceId))
                .ForMember(re => re.ServiceName, act => act.MapFrom(src => src.Service.Name))
                .ForMember(re => re.ServicePrice, act => act.MapFrom(src => src.Service.Price))
                .ForMember(re => re.AddonAmount, act => act.MapFrom(src => src.Amount))
                .ForMember(re => re.AddOnPrice, act => act.MapFrom(src => src.Price))
                .ForMember(re => re.AddOnStatus, act => act.MapFrom(src => src.Status));

            CreateMap<Apartment, ResponseOfApartment>()
                .ForMember(re => re.ApartmentId, act => act.MapFrom(src => src.ApartmentId))
                .ForMember(re => re.ApartmentTypeId, act => act.MapFrom(src => src.ApartmentTypeId))
                .ForMember(re => re.apTypeName, act => act.MapFrom(src => src.ApartmentType.Name))
                .ForMember(re => re.BuildingId, act => act.MapFrom(src => src.BuildingId))
                .ForMember(re => re.BuildingName, act => act.MapFrom(src => src.Building.Name))
                .ForMember(re => re.BuildingAddress, act => act.MapFrom(src => src.Building.Address))
                .ForMember(re => re.OwnerId, act => act.MapFrom(src => src.OwnerId))
                .ForMember(re => re.OwnerCode, act => act.MapFrom(src => src.Owner.Code))
                .ForMember(re => re.OwnerName, act => act.MapFrom(src => src.Owner.Name))
                .ForMember(re => re.FromDate, act => act.MapFrom(src => src.FromDate))
                .ForMember(re => re.ToDate, act => act.MapFrom(src => src.ToDate))
                .ForMember(re => re.Sequence, act => act.MapFrom(src => src.Sequence))
                .ForMember(re => re.ApartmentStatus, act => act.MapFrom(src => src.ApartmentStatus));

            CreateMap<ApartmentType, ResponseOfApartmentType>()
                .ForMember(re => re.ApartmentTypeId, act => act.MapFrom(src => src.ApartmentTypeId))
                //.ForMember(re => re.BuildingId, act => act.MapFrom(src => src.Building.BuildingId))
                //.ForMember(re => re.BuildingName, act => act.MapFrom(src => src.Building.Name))
                //.ForMember(re => re.BuildingAddress, act => act.MapFrom(src => src.Building.Address))
                .ForMember(re => re.ApartmentTypeName, act => act.MapFrom(src => src.Name))
                .ForMember(re => re.ApaermentTypeDescription, act => act.MapFrom(src => src.Description))
                .ForMember(re => re.Status, act => act.MapFrom(src => src.Status));

            //==============================================================================================

            CreateMap<Asset, ResponseOfAsset>()
                .ForMember(re => re.AssetId, act => act.MapFrom(src => src.AssetId))
                .ForMember(re => re.AssetHistoryId, act => act.MapFrom(src => src.AssetHistoryId))
                .ForMember(re => re.ApartmentId, act => act.MapFrom(src => src.ApartmentId))
                .ForMember(re => re.AssetName, act => act.MapFrom(src => src.Name))
                .ForMember(re => re.Quantity, act => act.MapFrom(src => src.Quantity))
                .ForMember(re => re.AssetDescription, act => act.MapFrom(src => src.Description))
                .ForMember(re => re.ItemImage, act => act.MapFrom(src => src.ItemImage))
                .ForMember(re => re.AssetStatus, act => act.MapFrom(src => src.Status));

            CreateMap<Asset, ResponseAssetHistory>()
                .ForMember(re => re.AssetId, act => act.MapFrom(src => src.AssetId))
                .ForMember(re => re.AssetHistoryId, act => act.MapFrom(src => src.AssetHistoryId))
                .ForMember(re => re.Code, act => act.MapFrom(src => src.AssetHistory.Code))
                .ForMember(re => re.Date, act => act.MapFrom(src => src.AssetHistory.Date))
                .ForMember(re => re.assHistoryDescription, act => act.MapFrom(src => src.AssetHistory.Description))
                .ForMember(re => re.assHistoryQuantity, act => act.MapFrom(src => src.AssetHistory.Quantity))
                .ForMember(re => re.assHistoryItemImage, act => act.MapFrom(src => src.AssetHistory.ItemImage))
                .ForMember(re => re.assHistoryStatus, act => act.MapFrom(src => src.AssetHistory.Status));


            CreateMap<UpdateAsset, Asset>()
                .ForMember(re => re.AssetHistoryId, act => act.MapFrom(src => src.AssetHistoryId))
                .ForMember(re => re.ApartmentId, act => act.MapFrom(src => src.ApartmentId))
                .ForMember(re => re.Name, act => act.MapFrom(src => src.AssetName))
                .ForMember(re => re.Quantity, act => act.MapFrom(src => src.Quantity))
                .ForMember(re => re.Description, act => act.MapFrom(src => src.AssetDescription))
                .ForMember(re => re.ItemImage, act => act.MapFrom(src => src.ItemImage))
                .ForMember(re => re.Status, act => act.MapFrom(src => src.AssetStatus));

            ////////////////////////////////////////////////////////////////////////////////////////////////////

            CreateMap<AssetHistory, ResponseOfAssetHistory>()
                .ForMember(re => re.AssetHistoryId, act => act.MapFrom(src => src.AssetHistoryId))
                .ForMember(re => re.Code, act => act.MapFrom(src => src.Code))
                .ForMember(re => re.Date, act => act.MapFrom(src => src.Date))
                .ForMember(re => re.Quantity, act => act.MapFrom(src => src.Quantity))
                .ForMember(re => re.Description, act => act.MapFrom(src => src.Description))
                .ForMember(re => re.ItemImage, act => act.MapFrom(src => src.ItemImage))
                .ForMember(re => re.Status, act => act.MapFrom(src => src.Status));

            //=================================================================================================

            CreateMap<Bill, ResponseOfBill>()
                .ForMember(re => re.BillId, act => act.MapFrom(src => src.BillId))
                .ForMember(re => re.RequestId, act => act.MapFrom(src => src.RequestId))

                .ForMember(re => re.BillDescription, act => act.MapFrom(src => src.Request.Description))
                .ForMember(re => re.BookDateTime, act => act.MapFrom(src => src.Request.BookDateTime))
                .ForMember(re => re.EndDate, act => act.MapFrom(src => src.Request.EndDate))
                .ForMember(re => re.TotalPrice, act => act.MapFrom(src => src.TotalPrice))
                .ForMember(re => re.Status, act => act.MapFrom(src => src.Status));

            //===================================================================================================================

            CreateMap<Building, ResponseOfBuilding>()
                .ForMember(re => re.BuildingId, act => act.MapFrom(src => src.BuildingId))
                .ForMember(re => re.Code, act => act.MapFrom(src => src.Code))
                .ForMember(re => re.BuildingName, act => act.MapFrom(src => src.Name))
                .ForMember(re => re.BuildingAddress, act => act.MapFrom(src => src.Address))
                .ForMember(re => re.BuildingStatus, act => act.MapFrom(src => src.Status));

            CreateMap<RequestCreateBuilding, Building>()
                .ForMember(re => re.Code, act => act.MapFrom(src => src.BuildingCode))
                .ForMember(re => re.Name, act => act.MapFrom(src => src.BuildingName))
                .ForMember(re => re.Address, act => act.MapFrom(src => src.BuildingAddress));

            CreateMap<UpdateBuilding, Building>()
                .ForMember(re => re.Code, act => act.MapFrom(src => src.BuildingCode))
                .ForMember(re => re.Name, act => act.MapFrom(src => src.BuildingName))
                .ForMember(re => re.Address, act => act.MapFrom(src => src.BuildingAddress));

            //===================================================================================================================

            CreateMap<Contract, ResponseOfContract>()
                .ForMember(re => re.ContractId, act => act.MapFrom(src => src.ContractId))
                .ForMember(re => re.ApartmentId, act => act.MapFrom(src => src.ApartmentId))
                .ForMember(re => re.ContractDetailId, act => act.MapFrom(src => src.ContractDetailId))
                .ForMember(re => re.FromDate, act => act.MapFrom(src => src.FromDate))
                .ForMember(re => re.ToDate, act => act.MapFrom(src => src.ToDate))
                .ForMember(re => re.ContractImage, act => act.MapFrom(src => src.ContractImage))
                .ForMember(re => re.ContractStatus, act => act.MapFrom(src => src.ContractStatus));

            //=================================================================================================================

            CreateMap<ContractDetail, ResponseOfContractDetail>()
                .ForMember(re => re.ContractDetailId, act => act.MapFrom(src => src.ContractDetailId))
                .ForMember(re => re.Code, act => act.MapFrom(src => src.Code))
                .ForMember(re => re.StartDate, act => act.MapFrom(src => src.StartDate))
                .ForMember(re => re.EndDate, act => act.MapFrom(src => src.EndDate));

            //======================================================================================================================

            CreateMap<Owner, ResponseOfOwner>()
                .ForMember(re => re.OwnerId, act => act.MapFrom(src => src.OwnerId))
                .ForMember(re => re.Code, act => act.MapFrom(src => src.OwnerId))
                .ForMember(re => re.OwnerName, act => act.MapFrom(src => src.Name))
                .ForMember(re => re.OwnerEmail, act => act.MapFrom(src => src.Email))
                .ForMember(re => re.Password, act => act.MapFrom(src => src.Password))
                .ForMember(re => re.OwnerPhone, act => act.MapFrom(src => src.Phone))
                .ForMember(re => re.OwnerAddress, act => act.MapFrom(src => src.Address))
                .ForMember(re => re.OwnerStatus, act => act.MapFrom(src => src.Status));

            CreateMap<Owner, ResponseAccountOwner>()
                .ForMember(re => re.Id, act => act.MapFrom(src => src.OwnerId))
                .ForMember(re => re.Code, act => act.MapFrom(src => src.Code))
                .ForMember(re => re.Name, act => act.MapFrom(src => src.Name))
                .ForMember(re => re.Email, act => act.MapFrom(src => src.Email))
                .ForMember(re => re.Phone, act => act.MapFrom(src => src.Phone))
                .ForMember(re => re.Address, act => act.MapFrom(src => src.Address))
                .ForMember(re => re.AvatarLink, act => act.MapFrom(src => src.AvatarLink))
                .ForMember(re => re.LastLogin, act => act.MapFrom(src => src.LastLogin))
                .ForMember(re => re.LastUpdate, act => act.MapFrom(src => src.LastUpdate))
                .ForMember(re => re.Status, act => act.MapFrom(src => src.Status));

            CreateMap<RequestCreateOwner, Owner>()
                .ForMember(re => re.Code, act => act.MapFrom(src => src.OwnerCode))
                .ForMember(re => re.Name, act => act.MapFrom(src => src.OwnerName))
                .ForMember(re => re.Email, act => act.MapFrom(src => src.OwnerEmail))
                .ForMember(re => re.Password, act => act.MapFrom(src => src.OwnerPassword))
                .ForMember(re => re.Phone, act => act.MapFrom(src => src.OwnerPhone))
                .ForMember(re => re.Address, act => act.MapFrom(src => src.OwnerAddress));

            CreateMap<UpdateOwner, Owner>()
                .ForMember(re => re.Code, act => act.MapFrom(src => src.OwnerCode))
                .ForMember(re => re.Name, act => act.MapFrom(src => src.OwnerName))
                .ForMember(re => re.Email, act => act.MapFrom(src => src.OwnerEmail))
                .ForMember(re => re.Password, act => act.MapFrom(src => src.OwnerPassword))
                .ForMember(re => re.Phone, act => act.MapFrom(src => src.OwnerPhone))
                .ForMember(re => re.Address, act => act.MapFrom(src => src.OwnerAddress));

            //======================================================================================================================

            CreateMap<Package, ResponseOfPackage>()
                .ForMember(re => re.PackageId, act => act.MapFrom(src => src.PackageId))
                .ForMember(re => re.ApartmentTypeName, act => act.MapFrom(src => src.ApartmentType.Name))
                .ForMember(re => re.Code, act => act.MapFrom(src => src.Code))
                .ForMember(re => re.PackageName, act => act.MapFrom(src => src.Name))
                .ForMember(re => re.PackageDescription, act => act.MapFrom(src => src.Description))
                .ForMember(re => re.PackagePrice, act => act.MapFrom(src => src.Price))
                .ForMember(re => re.PackageImageLink, act => act.MapFrom(src => src.PackageImageLink));

            CreateMap<PackageServiceDetail, ResponseOfPackageServiceDetail>()
                .ForMember(re => re.PackServiceDetailId, act => act.MapFrom(src => src.PackSerDetailId))
                .ForMember(re => re.PackageId, act => act.MapFrom(src => src.PackageId))
                .ForMember(re => re.PackageName, act => act.MapFrom(src => src.Package.Name))
                .ForMember(re => re.PackagePrice, act => act.MapFrom(src => src.Package.Price))
                .ForMember(re => re.ServiceId, act => act.MapFrom(src => src.ServiceId))
                .ForMember(re => re.ServiceName, act => act.MapFrom(src => src.Service.Name))
                .ForMember(re => re.ServicePrice, act => act.MapFrom(src => src.Service.Price));

            CreateMap<Package, ResponseOfPackageIdName>()
                .ForMember(re => re.PackageId, act => act.MapFrom(src => src.PackageId))
                .ForMember(re => re.PackageName, act => act.MapFrom(src => src.Name));

            //=============================================================================================================

            CreateMap<RequestView, ResponseOfRequest>()
                .ForMember(re => re.RequestId, act => act.MapFrom(src => src.RequestId))
                .ForMember(re => re.ApartmentId, act => act.MapFrom(src => src.ApartmentId))
                .ForMember(re => re.OwnerId, act => act.MapFrom(src => src.OwnerId))
                .ForMember(re => re.Description, act => act.MapFrom(src => src.RequestDescription))
                .ForMember(re => re.BookDateTime, act => act.MapFrom(src => src.BookDateTime))
                .ForMember(re => re.EndDateTime, act => act.MapFrom(src => src.EndDateTime))
                .ForMember(re => re.IsSequence, act => act.MapFrom(src => src.IsSequence))
                .ForMember(re => re.sequence, act => act.MapFrom(src => src.RequestSequence))
                .ForMember(re => re.ReqStatus, act => act.MapFrom(src => src.ReqStatus))
                .ForMember(re => re.NumberOfAddOns, act => act.MapFrom(src => src.NumberOfAddOns))
                .ForMember(re => re.PackageRequestedId, act => act.MapFrom(src => src.PackageRequestedId))
                .ForMember(re => re.PackageName, act => act.MapFrom(src => src.PackageName))
                .ForMember(re => re.Owner, act => act.MapFrom(src => src.Owner))
                .ForMember(re => re.ApartmentName, act => act.MapFrom(src => src.ApartmentName))
                .ForMember(re => re.PackagePrice, act => act.MapFrom(src => src.PackagePrice))
                .ForMember(re => re.ApartmentAddress, act => act.MapFrom(src => src.ApartmentAddress));

            CreateMap<Request, ResponseOfRequest>()
                .ForMember(re => re.RequestId, act => act.MapFrom(src => src.RequestId))
                .ForMember(re => re.ApartmentId, act => act.MapFrom(src => src.ApartmentId))
                .ForMember(re => re.OwnerId, act => act.MapFrom(src => src.Apartment.OwnerId))
                .ForMember(re => re.Description, act => act.MapFrom(src => src.Description))
                .ForMember(re => re.BookDateTime, act => act.MapFrom(src => src.BookDateTime))
                .ForMember(re => re.EndDateTime, act => act.MapFrom(src => src.EndDate))
                .ForMember(re => re.IsSequence, act => act.MapFrom(src => src.IsSequence))
                .ForMember(re => re.sequence, act => act.MapFrom(src => src.Sequence))
                .ForMember(re => re.ReqStatus, act => act.MapFrom(src => src.ReqStatus))
                .ForMember(re => re.NumberOfAddOns, act => act.MapFrom(src => src.AddOns.Count))
                .ForMember(re => re.PackageRequestedId, act => act.MapFrom(src => src.PackageId))
                .ForMember(re => re.PackageName, act => act.MapFrom(src => src.Package.Name))
                .ForMember(re => re.Owner, act => act.MapFrom(src => src.Apartment.Owner.Name))
                .ForMember(re => re.ApartmentName, act => act.MapFrom(src => src.Apartment.ApartmentName));

            CreateMap<RequestCreateRequest, Request>()
                .ForMember(s => s.ApartmentId, act => act.MapFrom(src => src.ApartmentId))
                .ForMember(s => s.PackageId, act => act.MapFrom(src => src.PackageId))
                .ForMember(s => s.Description, act => act.MapFrom(src => src.RequestDescription))
                .ForMember(s => s.BookDateTime, act => act.MapFrom(src => src.rqBookDateTime));
;

            CreateMap<UpdateRequest, Request>()
                .ForMember(s => s.ApartmentId, act => act.MapFrom(src => src.ApartmentId))
                .ForMember(s => s.Description, act => act.MapFrom(src => src.RequestDescription))
                .ForMember(s => s.BookDateTime, act => act.MapFrom(src => src.rqBookDateTime))
                .ForMember(s => s.EndDate, act => act.MapFrom(src => src.rqEndDate))
                .ForMember(s => s.IsSequence, act => act.MapFrom(src => src.rqIsSequence))
                .ForMember(s => s.Sequence, act => act.MapFrom(src => src.RequestSequence));

            CreateMap<Request, StaffRequestListResponse>()
                .ForPath(re => re.ApartmentId, act => act.MapFrom(src => src.ApartmentId))
                .ForPath(re => re.ApartmentOwnerId, act => act.MapFrom(src => src.Apartment.OwnerId))
                .ForPath(re => re.ApartmentTypeName, act => act.MapFrom(src => src.Apartment.ApartmentType.Name))
                .ForPath(re => re.ApartmentOwner, act => act.MapFrom(src => src.Apartment.Owner.Name))
                .ForPath(re => re.BookDateTime, act => act.MapFrom(src => src.BookDateTime))
                .ForPath(re => re.EndDate, act => act.MapFrom(src => src.EndDate))
                .ForPath(re => re.Packages, act => act.MapFrom(src => src.PackageId))
                .ForPath(re => re.NumberOfAddOnService, act => act.MapFrom(src => src.AddOns.Count));

            CreateMap<RequestDetailView, ResponseOfRequestDetail>()
                .ForMember(re => re.RequestId, act => act.MapFrom(src => src.RequestId))
                .ForMember(re => re.ApartmentId, act => act.MapFrom(src => src.ApartmentId))
                .ForMember(re => re.OwnerId, act => act.MapFrom(src => src.OwnerId))
                .ForMember(re => re.Description, act => act.MapFrom(src => src.RequestDescription))
                .ForMember(re => re.BookDateTime, act => act.MapFrom(src => src.BookDateTime))
                .ForMember(re => re.EndDateTime, act => act.MapFrom(src => src.EndDateTime))
                .ForMember(re => re.ReqStatus, act => act.MapFrom(src => src.ReqStatus))
                .ForMember(re => re.NumberOfAddOns, act => act.MapFrom(src => src.NumberOfAddOns))
                .ForMember(re => re.PackageRequestedId, act => act.MapFrom(src => src.PackageRequestedId))
                .ForMember(re => re.PackageName, act => act.MapFrom(src => src.PackageName))
                .ForMember(re => re.Owner, act => act.MapFrom(src => src.Owner))
                .ForMember(re => re.ApartmentName, act => act.MapFrom(src => src.ApartmentName))
                .ForMember(re => re.AddOnsList, act => act.MapFrom(src => src.AddOnList))
                .ForMember(re => re.PackagePrice, act => act.MapFrom(src => src.PackagePrice));

            CreateMap<Request, ResponseOfRequestDetail>()
                .ForMember(re => re.RequestId, act => act.MapFrom(src => src.RequestId))
                .ForMember(re => re.ApartmentId, act => act.MapFrom(src => src.ApartmentId))
                .ForMember(re => re.OwnerId, act => act.MapFrom(src => src.Apartment.OwnerId))
                .ForMember(re => re.Description, act => act.MapFrom(src => src.Description))
                .ForMember(re => re.BookDateTime, act => act.MapFrom(src => src.BookDateTime))
                .ForMember(re => re.EndDateTime, act => act.MapFrom(src => src.EndDate))
                .ForMember(re => re.IsSequence, act => act.MapFrom(src => src.IsSequence))
                .ForMember(re => re.sequence, act => act.MapFrom(src => src.Sequence))
                //.ForMember(re => re.ReqStatus, act => act.MapFrom(src => src.ReqStatus))
                .ForMember(re => re.NumberOfAddOns, act => act.MapFrom(src => src.AddOns.Count))
                .ForMember(re => re.PackageRequestedId, act => act.MapFrom(src => src.PackageId))
                .ForMember(re => re.PackageName, act => act.MapFrom(src => src.Package.Name))
                .ForMember(re => re.Owner, act => act.MapFrom(src => src.Apartment.Owner.Name))
                .ForMember(re => re.ApartmentName, act => act.MapFrom(src => src.Apartment.ApartmentName))
                .ForMember(re => re.AddOnsList, act => act.MapFrom(src => src.AddOns));
            //================================================================================================================

            /*			CreateMap<RequestDetail, ResponseOfRequestDetail>()
                            .ForMember(re => re.RequestDetailId, act => act.MapFrom(src => src.RequestDetailId))
                            .ForMember(re => re.RequestId, act => act.MapFrom(src => src.RequestId))
                            .ForMember(re => re.RequestDescription, act => act.MapFrom(src => src.Request.Description))
                            .ForMember(re => re.BookDateTime, act => act.MapFrom(src => src.Request.BookDateTime))
                            .ForMember(re => re.EndDate, act => act.MapFrom(src => src.Request.EndDate))
                            .ForMember(re => re.PackageId, act => act.MapFrom(src => src.PackageId))
                            .ForMember(re => re.PackageName, act => act.MapFrom(src => src.Package.Name))
                            .ForMember(re => re.RequestDetailAmount, act => act.MapFrom(src => src.Amount))
                            .ForMember(re => re.RequestPrice, act => act.MapFrom(src => src.Price));

                        CreateMap<RqDetailCreateRequest, RequestDetail>()
                            .ForMember(re => re.RequestId, act => act.MapFrom(src => src.RequestId))
                            .ForMember(re => re.PackageId, act => act.MapFrom(src => src.PackageId))
                            .ForMember(re => re.Amount, act => act.MapFrom(src => src.RequestDetailAmount))
                            .ForMember(re => re.Price, act => act.MapFrom(src => src.RequestPrice));

                        CreateMap<UpdateRequestDetail, RequestDetail>()
                            .ForMember(re => re.RequestId, act => act.MapFrom(src => src.RequestId))
                            .ForMember(re => re.PackageId, act => act.MapFrom(src => src.PackageId))
                            .ForMember(re => re.Amount, act => act.MapFrom(src => src.RequestDetailAmount))
                            .ForMember(re => re.Price, act => act.MapFrom(src => src.RequestPrice));*/

            /*			CreateMap<RequestDetail, StaffRequestListResponse>()
                            .ForPath(re => re.ApartmentId, act => act.MapFrom(src => src.Request.ApartmentId))
                            .ForPath(re => re.ApartmentOwnerId, act => act.MapFrom(src => src.Request.Apartment.OwnerId))
                            .ForPath(re => re.ApartmentTypeName, act => act.MapFrom(src => src.Request.Apartment.ApartmentType.Name))
                            .ForPath(re => re.ApartmentOwner, act => act.MapFrom(src => src.Request.Apartment.Owner.Name))
                            .ForPath(re => re.BookDateTime, act => act.MapFrom(src => src.Request.BookDateTime))
                            .ForPath(re => re.EndDate, act => act.MapFrom(src => src.Request.EndDate))
                            .ForMember(re => re.PackageId, act => act.MapFrom(src => src.PackageId))
                            .ForPath(re => re.PackageName, act => act.MapFrom(src => src.Package.Name))
                            .ForPath(re => re.NumberOfAddOnService, act => act.MapFrom(src => src.Request.AddOns.Count));*/

            //================================================================================================================

            CreateMap<RequestLog, ResponseOfRequestLog>()
                .ForMember(re => re.RequestLogId, act => act.MapFrom(src => src.RequestLogId))
                .ForMember(re => re.RequestId, act => act.MapFrom(src => src.RequestId))
                .ForMember(re => re.MaintainItem, act => act.MapFrom(src => src.MaintainItem))
                .ForMember(re => re.ReqLogDescription, act => act.MapFrom(src => src.Description))
                .ForMember(re => re.RqLogStatus, act => act.MapFrom(src => src.Status))
                .ForMember(re => re.UpdateTime, act => act.MapFrom(src => src.UpdateDate));


            CreateMap<RqLogCreateRequest, RequestLog>()
                .ForMember(re => re.RequestId, act => act.MapFrom(src => src.RequestId))
                .ForMember(re => re.MaintainItem, act => act.MapFrom(src => src.rqLogMaintainItem))
                .ForMember(re => re.Description, act => act.MapFrom(src => src.ReqLogDescription))
                .ForMember(re => re.StaffId, act => act.MapFrom(src => src.StaffId));

            CreateMap<UpdateRequestLog, RequestLog>()
                .ForMember(re => re.RequestId, act => act.MapFrom(src => src.RequestId))
                .ForMember(re => re.MaintainItem, act => act.MapFrom(src => src.rqLogMaintainItem))
                .ForMember(re => re.Description, act => act.MapFrom(src => src.ReqLogDescription))
                .ForMember(re => re.UpdateDate, act => act.MapFrom(src => src.UpdateTime));

            //==============================================================================================================

            CreateMap<Service, ResponseOfService>()
                .ForMember(re => re.ServiceId, act => act.MapFrom(src => src.ServiceId))
                .ForMember(re => re.ServiceCode, act => act.MapFrom(src => src.Code))
                .ForMember(re => re.ServiceName, act => act.MapFrom(src => src.Name))
                .ForMember(re => re.ServicePrice, act => act.MapFrom(src => src.Price))
                .ForMember(re => re.ServiceUnit, act => act.MapFrom(src => src.Unit))
                .ForMember(re => re.ServiceStatus, act => act.MapFrom(src => src.ServiceStatus));

            CreateMap<RequestCreateService, Service>()
                .ForMember(s => s.Code, act => act.MapFrom(src => src.ServiceCode))
                .ForMember(s => s.Name, act => act.MapFrom(src => src.ServiceName))
                .ForMember(s => s.Price, act => act.MapFrom(src => src.ServicePrice))
                .ForMember(s => s.Unit, act => act.MapFrom(src => src.ServiceUnit));

            CreateMap<UpdateService, Service>()
                .ForMember(s => s.Code, act => act.MapFrom(src => src.ServiceCode))
                .ForMember(s => s.Name, act => act.MapFrom(src => src.ServiceName))
                .ForMember(s => s.Price, act => act.MapFrom(src => src.ServicePrice))
                .ForMember(s => s.Unit, act => act.MapFrom(src => src.ServiceUnit));


            //==============================================================================================================

            CreateMap<Staff, ResponseAccountStaff>()
                .ForMember(re => re.Id, act => act.MapFrom(src => src.StaffId))
                .ForMember(re => re.Email, act => act.MapFrom(src => src.Email))
                .ForMember(re => re.Name, act => act.MapFrom(src => src.Name))
                .ForMember(re => re.Phone, act => act.MapFrom(src => src.Phone))
                .ForMember(re => re.Address, act => act.MapFrom(src => src.Address))
                .ForMember(re => re.Status, act => act.MapFrom(src => src.StaffStatus))
                .ForMember(re => re.AvatarLink, act => act.MapFrom(src => src.AvatarLink))
                .ForMember(re => re.LastLogin, act => act.MapFrom(src => src.LastLogin))
                .ForMember(re => re.LastUpdate, act => act.MapFrom(src => src.LastUpdate))
                .ForMember(re => re.Code, act => act.MapFrom(src => src.Code))
                .ForMember(re => re.Role, act => act.MapFrom(src => src.Role));

            CreateMap<Staff, StaffsOnlyResponse>()
                .ForMember(re => re.Id, act => act.MapFrom(src => src.StaffId))
                .ForMember(re => re.Email, act => act.MapFrom(src => src.Email))
                .ForMember(re => re.Name, act => act.MapFrom(src => src.Name))
                .ForMember(re => re.Phone, act => act.MapFrom(src => src.Phone))
                .ForMember(re => re.Address, act => act.MapFrom(src => src.Address))
                .ForMember(re => re.Status, act => act.MapFrom(src => src.StaffStatus))
                .ForMember(re => re.AvatarLink, act => act.MapFrom(src => src.AvatarLink))
                .ForMember(re => re.LastLogin, act => act.MapFrom(src => src.LastLogin))
                .ForMember(re => re.LastUpdate, act => act.MapFrom(src => src.LastUpdate))
                .ForMember(re => re.Code, act => act.MapFrom(src => src.Code))
                .ForMember(re => re.Role, act => act.MapFrom(src => src.Role))
                .ForPath(re => re.NumberOfRequestLogPending, act => act.MapFrom(src => src.RequestLogs.Count));

            CreateMap<RequestCreateStaff, Staff>()
                .ForMember(re => re.Role, act => act.MapFrom(src => src.StaffRole))
                .ForMember(re => re.Email, act => act.MapFrom(src => src.StaffEmail))
                .ForMember(re => re.Name, act => act.MapFrom(src => src.StaffName))
                .ForMember(re => re.Phone, act => act.MapFrom(src => src.StaffPhone))
                .ForMember(re => re.Password, act => act.MapFrom(src => src.StaffPassword))
                .ForMember(re => re.Address, act => act.MapFrom(src => src.StaffAddress))
                .ForMember(re => re.AvatarLink, act => act.MapFrom(src => src.AvatarLink))
                .ForMember(re => re.Code, act => act.MapFrom(src => src.StaffCode));

            CreateMap<UpdateStaff, Staff>()
                .ForMember(re => re.Name, act => act.MapFrom(src => src.StaffName))
                .ForMember(re => re.Phone, act => act.MapFrom(src => src.StaffPhone))
                .ForMember(re => re.Password, act => act.MapFrom(src => src.StaffPassword))
                .ForMember(re => re.Address, act => act.MapFrom(src => src.StaffAddress))
                .ForMember(re => re.AvatarLink, act => act.MapFrom(src => src.AvatarLink))
                .ForMember(re => re.Code, act => act.MapFrom(src => src.StaffCode));

            //==============================================================================================================

            CreateMap<StaffDetail, ResponseOfStaffDetail>()
                .ForMember(re => re.StaffDetailId, act => act.MapFrom(src => src.StaffDetailId))
                .ForMember(re => re.StaffId, act => act.MapFrom(src => src.StaffId))
                .ForMember(re => re.StaffName, act => act.MapFrom(src => src.Staff.Name))
                .ForMember(re => re.StaffEmail, act => act.MapFrom(src => src.Staff.Email))
                .ForMember(re => re.StaffPhone, act => act.MapFrom(src => src.Staff.Phone))
                .ForMember(re => re.StaffAddress, act => act.MapFrom(src => src.Staff.Address))
                .ForMember(re => re.AvatarLink, act => act.MapFrom(src => src.Staff.AvatarLink))
                .ForMember(re => re.ServiceId, act => act.MapFrom(src => src.ServiceId))
                .ForMember(re => re.ServiceName, act => act.MapFrom(src => src.Service.Name))
                .ForMember(re => re.ServiceStatus, act => act.MapFrom(src => src.Service.ServiceStatus));

            CreateMap<StaffLog, ResponseOfStaffLog>()
                .ForMember(re => re.StaffLogId, act => act.MapFrom(src => src.StaffLogId))
                .ForMember(re => re.StaffId, act => act.MapFrom(src => src.StaffId))
                .ForMember(re => re.StaffName, act => act.MapFrom(src => src.Staff.Name))
                .ForMember(re => re.StaffStatus, act => act.MapFrom(src => src.Staff.StaffStatus))
                .ForMember(re => re.StaffRole, act => act.MapFrom(src => src.Staff.Role))
                .ForMember(re => re.RequestLogId, act => act.MapFrom(src => src.RequestLogId))
                .ForMember(re => re.RequestId, act => act.MapFrom(src => src.RequestLog.RequestId))
                .ForMember(re => re.rqLogMaintainItem, act => act.MapFrom(src => src.RequestLog.MaintainItem))
                .ForMember(re => re.ReqLogDescription, act => act.MapFrom(src => src.RequestLog.Description))
                .ForMember(re => re.ReqLogStatus, act => act.MapFrom(src => src.RequestLog.Status));

            //===========================================================================================================

            CreateMap<Tennant, ResponseOfTennant>()
                .ForMember(re => re.TennantId, act => act.MapFrom(src => src.TennantId))
                .ForMember(re => re.TennantCode, act => act.MapFrom(src => src.Code))
                .ForMember(re => re.TennantName, act => act.MapFrom(src => src.Name))
                .ForMember(re => re.TennantEmail, act => act.MapFrom(src => src.Email))
                .ForMember(re => re.Password, act => act.MapFrom(src => src.Password))
                .ForMember(re => re.TennantPhone, act => act.MapFrom(src => src.Phone))
                .ForMember(re => re.TennantAddress, act => act.MapFrom(src => src.Address))
                .ForMember(re => re.TennantStatus, act => act.MapFrom(src => src.Status))
                .ForMember(re => re.ContractDetailId, act => act.MapFrom(src => src.ContractDetailId))
                .ForMember(re => re.StartDate, act => act.MapFrom(src => src.ContractDetail.StartDate))
                .ForMember(re => re.EndDate, act => act.MapFrom(src => src.ContractDetail.EndDate));

            CreateMap<Tennant, ResponseAccountTennant>()
                .ForMember(re => re.Id, act => act.MapFrom(src => src.TennantId))
                .ForMember(re => re.Code, act => act.MapFrom(src => src.Code))
                .ForMember(re => re.Name, act => act.MapFrom(src => src.Name))
                .ForMember(re => re.Email, act => act.MapFrom(src => src.Email))
                .ForMember(re => re.Phone, act => act.MapFrom(src => src.Phone))
                .ForMember(re => re.Address, act => act.MapFrom(src => src.Address))
                .ForMember(re => re.AvatarLink, act => act.MapFrom(src => src.AvatarLink))
                .ForMember(re => re.LastLogin, act => act.MapFrom(src => src.LastLogin))
                .ForMember(re => re.LastUpdate, act => act.MapFrom(src => src.LastUpdate))
                .ForMember(re => re.Status, act => act.MapFrom(src => src.Status));

            CreateMap<RequestCreateTennant, Tennant>()
               .ForMember(re => re.Name, act => act.MapFrom(src => src.TennantName))
               .ForMember(re => re.Email, act => act.MapFrom(src => src.TennantEmail))
               .ForMember(re => re.Code, act => act.MapFrom(src => src.TennantCode))
               .ForMember(re => re.Password, act => act.MapFrom(src => src.Password))
               .ForMember(re => re.Phone, act => act.MapFrom(src => src.TennantPhone))
               .ForMember(re => re.Address, act => act.MapFrom(src => src.TennantAddress));

            CreateMap<UpdateTennant, Tennant>()
               .ForMember(re => re.Name, act => act.MapFrom(src => src.TennantName))
               .ForMember(re => re.Email, act => act.MapFrom(src => src.TennantEmail))
               .ForMember(re => re.Password, act => act.MapFrom(src => src.Password))
               .ForMember(re => re.Phone, act => act.MapFrom(src => src.TennantPhone))
               .ForMember(re => re.Address, act => act.MapFrom(src => src.TennantAddress));

        }
    }
}
