
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Core.Helpers
{
    public static class SHA512Hash
    {
        public static void CreateHash(string password, out byte[] passwordHash,out byte[] passwordSalt)
        {
            using (var hmacsha512 = new HMACSHA512())
            {
                passwordSalt = hmacsha512.Key;
                passwordHash = hmacsha512.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
        public static bool VerifyHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            
            using (var hmac512sha = new HMACSHA512(passwordSalt))
            {
                var currentHash = hmac512sha.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < currentHash.Length; i++)
                {
                    if (currentHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
