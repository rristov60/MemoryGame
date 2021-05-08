using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography; // Namespace used for accesing the hashing functions

namespace Users_and_Security
{
    class PasswordHashing
    {
        public static string hashPassword(string password)
        {
            SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider();

            byte[] passwordBytes = Encoding.ASCII.GetBytes(password);
            byte[] encryptedPasswordBytes = sha256.ComputeHash(passwordBytes);

            return Convert.ToBase64String(encryptedPasswordBytes);
        }
    }
}
