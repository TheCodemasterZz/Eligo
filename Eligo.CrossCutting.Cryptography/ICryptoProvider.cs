using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eligo.CrossCutting.Cryptography
{
    public interface ICryptoProvider
    {
        CryptoConfig Settings { get; }

        string Encrypt(string plainText);

        string Decrypt(string encryptedText);

        bool IsMatch(string encryptedText, string plainText);
    }
}
