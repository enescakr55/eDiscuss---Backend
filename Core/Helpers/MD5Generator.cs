using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Core.Helpers
{
    public class MD5Generator
    {
        public static string MD5Crypt(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputbytes = Encoding.UTF8.GetBytes(input);
                byte[] hash = md5.ComputeHash(inputbytes);
                string str = BitConverter.ToString(hash).Replace("-", "");
                return str;
            }
        }
    }
}
