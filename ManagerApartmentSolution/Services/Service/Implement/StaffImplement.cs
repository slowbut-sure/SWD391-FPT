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

namespace Services.Servicesss.Implement
{
    public class StaffImplement : StaffService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IStaffRepository _staffRepository;
        public StaffImplement(IUnitOfWork unitOfWork, IMapper mapper, IStaffRepository staffRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _staffRepository = staffRepository;
        }

        public async Task<ResponseAccountStaff> CreateStaff(RequestCreateStaff staff)
        {
            var createStaff = _mapper.Map<Staff>(staff);
            createStaff.StaffStatus = StaffEnum.ACTIVE.ToString();
            _unitOfWork.Staff.Add(createStaff);
            _unitOfWork.Save();
            return _mapper.Map<ResponseAccountStaff>(createStaff);
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

        public async Task<List<ResponseAccountStaff>> GetAllStaffs()
        {
            var staffs =  _unitOfWork.Staff.GetAll().ToList();
            if(staffs is null)
            {
                throw new Exception("The staff list is empty");
            }
            return _mapper.Map<List<ResponseAccountStaff>>(staffs);
        }

        public async Task<DataResponse<List<StaffRequestListResponse>>> GetRequets()
        {
            var response = new DataResponse<List<StaffRequestListResponse>>();
            var requets = await _unitOfWork.Request.GetStaffRequests();
            if (requets is null)
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

        public async Task<ResponseAccountStaff> GetStaffById(int id)
        {
            var staff = await _unitOfWork.Staff.GetStaffById(id);
            if (staff is null)
            {
                throw new Exception("The staff does not exist");
            }
            return _mapper.Map<ResponseAccountStaff>(staff);
        }

        public async Task<List<ResponseAccountStaff>> GetStaffByName(string name)
        {
            var names = await _staffRepository.GetStaffByName(name);
            return _mapper.Map<List<ResponseAccountStaff>>(names);
        }

        public async Task<ResponseAccountStaff> UpdateStaff(int staffId, UpdateStaff updateStaff)
        {
            var staff = _unitOfWork.Staff.GetById(staffId);
            if (staff is null)
            {
                throw new Exception("Can not found ");
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
            return _mapper.Map<ResponseAccountStaff>(staff);

        }
    }
}
