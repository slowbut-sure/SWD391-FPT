using ManagerApartment.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Services.Authentication.Implement
{
    public class Authentication : IAuthentication
    {
        private const int SaltSize = 128 / 8;
        private const int KeySize = 256 / 8;
        private const int Iterations = 10000;
        private const char Delimiter = ';';
        private static readonly HashAlgorithmName _hashAlgorithmName = HashAlgorithmName.SHA256;

        public bool Verify(string HashPassword, string InputPassword)
        {
            var elments = HashPassword.Split(Delimiter);
            var salt = Convert.FromBase64String(elments[0]);
            var hash = Convert.FromBase64String(elments[1]);

            var hashInput = Rfc2898DeriveBytes.Pbkdf2(InputPassword, salt, Iterations, _hashAlgorithmName, KeySize);

            return CryptographicOperations.FixedTimeEquals(hash, hashInput);
        }

        public string Hash(string password)
        {
            var salt = RandomNumberGenerator.GetBytes(SaltSize);
            var hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, _hashAlgorithmName, KeySize);

            return string.Join(Delimiter, Convert.ToBase64String(salt), Convert.ToBase64String(hash));
        }

        public string GenerateToken(Staff staff, string secretKey, string role)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var secretKryByte = Encoding.UTF8.GetBytes(secretKey);
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.NameIdentifier, staff.Name),
                new Claim(ClaimTypes.Email, staff.Email),
                new Claim("Id", staff.StaffId.ToString()),
                new Claim(ClaimTypes.Role, role)
            }),
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKryByte), SecurityAlgorithms.HmacSha256)
            };
            var token = jwtTokenHandler.CreateToken(tokenDescription);
            return jwtTokenHandler.WriteToken(token);
        }

        public string GenerateToken(Owner owner, string secretKey, string role)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var secretKryByte = Encoding.UTF8.GetBytes(secretKey);
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.NameIdentifier, owner.Name),
                new Claim(ClaimTypes.Email, owner.Email),
                new Claim("Id", owner.OwnerId.ToString()),
                new Claim(ClaimTypes.Role, role)
            }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKryByte), SecurityAlgorithms.HmacSha256)
            };
            var token = jwtTokenHandler.CreateToken(tokenDescription);
            return jwtTokenHandler.WriteToken(token);
        }

        public string GenerateToken(Tennant tennant, string secretKey, string role)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var secretKryByte = Encoding.UTF8.GetBytes(secretKey);
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.NameIdentifier, tennant.Name),
                new Claim(ClaimTypes.Email, tennant.Email),
                new Claim("Id", tennant.TennantId.ToString()),
                new Claim(ClaimTypes.Role, role)
            }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKryByte), SecurityAlgorithms.HmacSha256)
            };
            var token = jwtTokenHandler.CreateToken(tokenDescription);
            return jwtTokenHandler.WriteToken(token);
        }

        //    public string GenerateToken(Staff staff, Owner owner, Tennant tennant, string secretKey, string role)
        //    {
        //        Subject = new ClaimsIdentity(new[]
        //            {
        //            new Claim(ClaimTypes.NameIdentifier, staff.Name),
        //            new Claim("Id", staff.StaffId.ToString()),
        //            new Claim(ClaimTypes.Role, role)
        //        }),
        //            Expires = DateTime.UtcNow.AddHours(1),
        //            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKryByte), SecurityAlgorithms.HmacSha256)
        //        };
        //    var token = jwtTokenHandler.CreateToken(tokenDescription);
        //        return jwtTokenHandler.WriteToken(token);
        //    }
    }
}