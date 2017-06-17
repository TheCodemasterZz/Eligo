using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eligo.DataLayer.Exceptions
{
    public class PrimaryKeyViolationException : Exception
    {
        public PrimaryKeyViolationException()
            : base("There is a primary key violation exception.")
        {
        }

        public PrimaryKeyViolationException(string message)
            : base(message)
        {
        }

        public PrimaryKeyViolationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
