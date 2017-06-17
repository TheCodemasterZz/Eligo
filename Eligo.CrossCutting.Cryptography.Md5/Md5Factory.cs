using Eligo.CrossCutting.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eligo.CrossCutting.Caching.MemoryCaching
{
    public class Md5Factory : ICryptoFactory
    {
        public ICryptoProvider Create()
        {
            return new Md5Provider();
        }
    }
}
