using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models.Response.StaffResponse
{
    public class StaffsOnlyResponse
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Role { get; set; }
        public string AvatarLink { get; set; }
        public DateTime LastLogin { get; set; }
        public DateTime LastUpdate { get; set; }
        public string Status { get; set; }
        public int NumberOfRequestLogPending { get; set; }
    }
}
