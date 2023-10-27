using Services.Interfaces.IUnitOfWork;
using Services.Models.Response.StaffResponse;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Models.Request.StaffRequest;
using ManagerApartment.Models;
using Domain.Enums.Status;
using Services.Models.Request.ServiceRequest;
using Services.Models.Response.ServiceResponse;
using Services.Interfaces;
using Services.Models.Response;
using Services.Authentication;
using Domain.Enums.Role;

namespace Services.Servicesss.Implement
{
    public class StaffImplement : StaffService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IStaffRepository _staffRepository;
        private readonly IAuthentication _authentication;
        public StaffImplement(IUnitOfWork unitOfWork, IMapper mapper, IStaffRepository staffRepository, IAuthentication authentication)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _staffRepository = staffRepository;
            _authentication = authentication;
        }

        public async Task<DataResponse<ResponseAccountStaff>> CreateStaff(RequestCreateStaff staff)
        {
            var response = new DataResponse<ResponseAccountStaff>();

            try
            {
                var createStaff = _mapper.Map<Staff>(staff);
                createStaff.StaffStatus = StaffEnum.ACTIVE.ToString();
                createStaff.Password = _authentication.Hash(staff.StaffPassword);
                _unitOfWork.Staff.Add(createStaff);
                _unitOfWork.Save();
                response.Data = _mapper.Map<ResponseAccountStaff>(createStaff);
                response.Message = "Create Successfully.";
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = "Oops! Some thing went wrong.\n" + ex.Message;
                response.Success = false;
            }

            return response;
        }

        public async Task DeleteStaff(int staffId)
        {
            var staff = _unitOfWork.Staff.GetById(staffId);
            if (staff is null)
            {
                throw new Exception("Can not found by" + staffId);
            }
            staff.StaffStatus = StaffEnum.INACTIVE.ToString();
            _unitOfWork.Staff.Update(staff);
            _unitOfWork.Save();
        }

        public async Task<DataResponse<List<ResponseAccountStaff>>> GetAllStaffs()
        {
            var response = new DataResponse<List<ResponseAccountStaff>>();

            try
            {
                var staffs = _unitOfWork.Staff.GetAll().ToList();
                if (staffs is null)
                {
                    response.Message = "List staffs is null";
                    response.Success = true;
                    return response;
                }
                response.Data = _mapper.Map<List<ResponseAccountStaff>>(staffs);
                response.Message = "List staffs";
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = "Oops! Some thing went wrong.\n" + ex.Message;
                response.Success = false;
            }

            return response;
        }

        public async Task<DataResponse<List<StaffRequestListResponse>>> GetRequets()
        {
            var response = new DataResponse<List<StaffRequestListResponse>>();
            var requets = await _unitOfWork.Request.GetStaffRequests();
            if (requets == null)
            {
                response.Success = true;
                response.Message = "Empty request";
            }
            else
            {
                response.Data = _mapper.Map<List<StaffRequestListResponse>>(requets);
                response.Success = true;
                response.Message = "Staff request list";
            }

            return response;
        }

        public async Task<DataResponse<ResponseAccountStaff>> GetStaffById(int id)
        {
            var response = new DataResponse<ResponseAccountStaff>();

            try
            {
                var staff = await _unitOfWork.Staff.GetStaffById(id);
                if (staff is null)
                {
                    response.Message = "Staff not exist";
                    response.Success = false;
                    return response;
                }
                response.Data = _mapper.Map<ResponseAccountStaff>(staff);
                response.Success = true;
                response.Message = $"StaffId: {id}";
            }
            catch (Exception ex) 
            {
                response.Message = "Oops! Some thing went wrong.\n" + ex.Message;
                response.Success = false;
            }

            return response;
        }

        public async Task<DataResponse<List<ResponseAccountStaff>>> GetStaffByName(string name)
        {
            var response = new DataResponse<List<ResponseAccountStaff>>();

            try
            {
                var names = await _staffRepository.GetStaffByName(name);
                response.Data = _mapper.Map<List<ResponseAccountStaff>>(names);
                response.Success = true;
                response.Message = "Get Staffs by name";
            }
            catch (Exception ex)
            {
                response.Message = "Oops! Some thing went wrong.\n" + ex.Message;
                response.Success = false;
            }

            return response;
        }

        public async Task<DataResponse<List<StaffsOnlyResponse>>> GetStaffsOnly()
        {
            var response = new DataResponse<List<StaffsOnlyResponse>>();
            try
            {
                var list = await _unitOfWork.Staff.GetStaffsOnly();
                if (list is null)
                {
                    response.Message = "No staff found";
                    response.Success = false;
                    return response;
                }
                foreach (var staff in list)
                {
                    staff.Role = RolePositionStaff.STAFF.ToString();
                }
                response.Data = _mapper.Map<List<StaffsOnlyResponse>>(list);
                response.Success = true;
                response.Message = "List of Staff Roles";

            }
            catch (Exception ex)
            {
                response.Message = "Oops! Some thing went wrong.\n" + ex.Message;
                response.Success = false;
            }

            return response;
        }

        public async Task<DataResponse<ResponseAccountStaff>> UpdateStaff(int staffId, UpdateStaff updateStaff)
        {
            var response = new DataResponse<ResponseAccountStaff>();

            try
            {
                var staff = _unitOfWork.Staff.GetById(staffId);
                if (staff is null)
                {
                    response.Message = "Can not found";
                    response.Success = false;
                    return response;
                }
                staff.Name = updateStaff.StaffName;
                staff.Phone = updateStaff.StaffPhone;
                staff.Password = updateStaff.StaffPassword;
                staff.Address = updateStaff.StaffAddress;
                staff.AvatarLink = updateStaff.AvatarLink;
                staff.StaffStatus = updateStaff.StaffStatus;
                staff.Code = updateStaff.StaffCode;
                _unitOfWork.Staff.Update(staff);
                _unitOfWork.Save();
                response.Data = _mapper.Map<ResponseAccountStaff>(staff);
                response.Message = "Update Successfully.";
                response.Success = true;
            }
            catch (Exception ex) 
            {
                response.Message = "Oops! Some thing went wrong.\n" + ex.Message;
                response.Success = false;
            }

            return response;
        }
    }
}
