using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models.Response.StaffResponse
{
    public class ResponseOfStaffDetail
    {
        public int StaffDetailId { get; set; }

        public int StaffId { get; set; }
        public string StaffName {  get; set; }
        public string StaffEmail { get; set; }
        public string StaffPhone { get; set; }
        public string StaffAddress { get; set; }
        public string AvatarLink { get; set; }
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string ServiceStatus { get; set; }
    }
}
