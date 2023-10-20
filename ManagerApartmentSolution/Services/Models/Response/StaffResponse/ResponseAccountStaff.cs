using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models.Response.StaffResponse
{
    public class ResponseAccountStaff : AccountResponse
    {
        public ResponseAccountStaff(int staffId, string email, string name, string phone, string address, string staffStatus,
            string avatarLink, string code, string role)
        {
            StaffId = staffId;
            Email = email;
            StaffName = name;
            StaffPhone = phone;
            Address = address;
            StaffStatus = staffStatus;
            AvatarLink = avatarLink;
            Code = code;

            Role = role;
        }
        public int StaffId { get; set; }    
        public string Email { get; set; }
        public string StaffName { get; set; }
        public string StaffPhone { get; set; }
        public string Address { get; set; }
        public string StaffStatus { get; set; }
        public string AvatarLink { get; set; }
        public string Code { get; set; }

        public string Role { get; set; }
    }
}
