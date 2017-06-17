using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eligo.DataLayer.Exceptions
{
    public class ForeignKeyViolationException : Exception
    {
        public ForeignKeyViolationException()
            : base("You cannot remove this object beacuse another object is related to it.")
        {
        }

        public ForeignKeyViolationException(string message)
            : base(message)
        {
        }

        public ForeignKeyViolationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
