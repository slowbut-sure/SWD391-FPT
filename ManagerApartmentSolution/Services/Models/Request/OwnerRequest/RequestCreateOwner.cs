using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models.Request.OwnerRequest
{
    public class RequestCreateOwner
    {
        [Required(ErrorMessage = "The code field is required.")]
        public string OwnerCode { get; set; }

        [Required(ErrorMessage = "The name field is required.")]
        public string OwnerName { get; set; }

        public string OwnerEmail { get; set; } = null!;

        [Required(ErrorMessage = "The Password field is required.")]
        public string OwnerPassword { get; set; }

        [RegularExpression(@"^[0-10]{9,10}$", ErrorMessage = "The phone number must be an 9 or 10 digit integer.")]
        [Required(ErrorMessage = "Phone field is required.")]
        public string OwnerPhone { get; set; }

        public string OwnerAddress { get; set; } = null!;
    }
}
