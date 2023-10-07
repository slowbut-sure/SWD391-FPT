using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models.Response.StaffResponse
{
    public class ResponseAccountStaff
    {
        public ResponseAccountStaff(int staffId, string email, string name, string phone, string address, string staffStatus,
            string avatarLink, string code, int staffLogId, int staffDetailId, string role)
        {
            StaffId = staffId;
            Email = email;
            Name = name;
            Phone = phone;
            Address = address;
            StaffStatus = staffStatus;
            AvatarLink = avatarLink;
            Code = code;
            StaffLogId = staffLogId;
            StaffDetailId = staffDetailId;
            Role = role;
        }
        public int StaffId { get; set; }    
        public string Email { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string StaffStatus { get; set; }
        public string AvatarLink { get; set; }
        public string Code { get; set; }
        public int StaffLogId { get; set; }
        public int StaffDetailId { get; set; }
        public string Role { get; set; }
    }
}
