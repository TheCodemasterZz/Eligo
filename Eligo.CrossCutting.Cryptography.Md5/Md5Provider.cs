using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using Eligo.CrossCutting.Cryptography;
using System.Text;
using System.Security.Cryptography;

namespace Eligo.CrossCutting.Caching.MemoryCaching
{
    public class Md5Provider : ICryptoProvider
    {
        public Cryptography.CryptoConfig Settings { get; }

        public string Decrypt(string encryptedText)
        {
            return encryptedText;
        }

        public string Encrypt(string plainText)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

            byte[] btr = Encoding.UTF8.GetBytes(plainText);
            btr = md5.ComputeHash(btr);
            StringBuilder sb = new StringBuilder();
            foreach (byte ba in btr)
            {
                sb.Append(ba.ToString("x2").ToLower());
            }
            return sb.ToString();
        }

        public bool IsMatch(string encryptedText, string plainText)
        {
            if ( Encrypt(plainText) == encryptedText )
            {
                return true;
            }
            return false;
        }
    }
}
