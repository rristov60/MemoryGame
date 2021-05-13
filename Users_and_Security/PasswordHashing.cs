using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography; // Namespace користено за да имаме пристап до интегрираните криптирачки функции во C#

namespace Users_and_Security
{
    public class PasswordHashing
    {
        // Функција за хеширање на Password со помош на SHA256
        public static string hashPassword(string password)
        {
            SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider(); // Создаваме нова инстанца од алгоритамот за хеширање

            byte[] passwordBytes = Encoding.ASCII.GetBytes(password); // Password-от го претвораме во бајти бидејќи алгоритамот го хешира како бајти
            byte[] encryptedPasswordBytes = sha256.ComputeHash(passwordBytes); // Самото хеширање и складирање на складираните бајти

            return Convert.ToBase64String(encryptedPasswordBytes); // Враќањљ на хешираните бајти како string
        }
    }
}
