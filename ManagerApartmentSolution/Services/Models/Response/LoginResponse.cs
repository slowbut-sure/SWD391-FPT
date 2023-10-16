using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models.Response
{
    public class LoginResponse
    {
        public LoginResponse()
        {
            // Khởi tạo các thuộc tính
            Data = string.Empty;
            Success = false;
            Messenger = string.Empty;
        }

        public string Data { get; set; }
        public bool Success { get; set; }
        public string Messenger { get; set; }
    }
}
