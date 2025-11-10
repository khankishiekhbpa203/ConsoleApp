using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Exceptions
{
    public class NullPredicateException : Exception
    {
        public NullPredicateException(string message) : base(message) { }
    }
}
