using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Eligo.CrossCutting.Cryptography
{
    public static class CryptoFactory
    {
        static ICryptoFactory _currentCryptoFactory = null;

        public static void SetCurrent(ICryptoFactory cryptoFactory)
        {
            _currentCryptoFactory = cryptoFactory;
        }

        public static ICryptoProvider Create()
        {
            return (_currentCryptoFactory != null) ? _currentCryptoFactory.Create() : null;
        }
    }
}
