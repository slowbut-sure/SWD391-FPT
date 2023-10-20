using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models.Request
{
    public class RequestLogin
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
