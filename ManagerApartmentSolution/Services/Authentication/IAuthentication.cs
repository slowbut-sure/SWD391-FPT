using ManagerApartment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Authentication
{
    public interface IAuthentication
    {
        public bool Verify(string HashPassword, string InputPassword);
        public string Hash(string password);
        public string GenerateToken(string id, string name, string secretKey, string role);
    }
}
