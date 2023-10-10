using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models.Request.StaffRequest
{
    public class UpdateStaff
    {
        public string StaffName { get; set; }

        public string StaffPhone { get; set; }

        public string StaffPassword { get; set; }

        public string StaffAddress { get; set; }

        public string StaffStatus { get; set; }

        public string AvatarLink { get; set; }

        public string StaffCode { get; set; }
    }
}
