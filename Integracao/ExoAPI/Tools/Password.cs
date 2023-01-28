using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace ExoAPI.Tools
{
	public static class Password
	{
        public static string Hash(string password)
        {
            var bytes = Encoding.ASCII.GetBytes(password);
            var rfc = new Rfc2898DeriveBytes(bytes, new byte[0], 1000); // 10.000 para produção
            return Convert.ToBase64String(rfc.GetBytes(50));
        }
    }
}

