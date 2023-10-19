using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models.Request.StaffRequest
{
    public class RequestCreateStaff
    {
        [Required(ErrorMessage = "The role field is required.")]
        public string StaffRole { get; set; }

        [Required(ErrorMessage = "The email field is required.")]
        public string StaffEmail { get; set; }

        [Required(ErrorMessage = "The name field is required.")]
        public string StaffName { get; set; }

        [RegularExpression(@"^[0-10]{9,10}$", ErrorMessage = "The phone number must be an 9 or 10 digit integer.")]
        [Required(ErrorMessage = "Phone field is required.")]
        public string StaffPhone { get; set; }

        [Required(ErrorMessage = "The Password field is required.")]
        public string StaffPassword { get; set; }

        public string StaffAddress { get; set; } = null!;

        public string AvatarLink { get; set; } = null!;

        [Required(ErrorMessage = "The email field is required.")]
        public string StaffCode { get; set; }
    }
}
