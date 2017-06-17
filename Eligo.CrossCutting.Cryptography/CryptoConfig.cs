using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eligo.CrossCutting.Cryptography
{
    public class CryptoConfig
    {
        private bool _encrypt = true;
        private string _internalKey = "keyphrase";

        public CryptoConfig()
        {
        }

        public CryptoConfig(bool encrypt, string key)
        {
            this._encrypt = encrypt;
            this._internalKey = key;
        }

        public bool Encrypt
        {
            get { return this._encrypt; }
        }

        public string InternalKey
        {
            get { return this._internalKey; }
        }
    }
}
