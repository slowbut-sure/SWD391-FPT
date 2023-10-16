using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models.Request.TennantRequest
{
    public class RequestCreateTennant
    {
        public RequestCreateTennant(string tennantName, string tennantCode,  string tennantEmail, string password, string tennantPhone, string tennantAddress)
        {
            TennantName = tennantName;
            TennantCode = tennantCode;
            TennantEmail = tennantEmail;
            Password = password;
            TennantPhone = tennantPhone;
            TennantAddress = tennantAddress;

        }

        [Required(ErrorMessage = "The name field is required.")]
        public string TennantName { get; set; } = null!;

        [Required(ErrorMessage = "The Password field is required.")]
        public string Password { get; set; } = null!;

        [Required(ErrorMessage = "The code field is required.")]
        public string TennantCode { get; set; } = null!;

        [EmailAddress] public string TennantEmail { get; set; } = null!;

        [RegularExpression(@"^[0-10]{9,10}$", ErrorMessage = "The phone number must be an 9 or 10 digit integer.")]
        [Required(ErrorMessage = "Phone field is required.")]
        public string TennantPhone { get; set; }
        public string TennantAddress { get; set; } = null!;

    }
}
