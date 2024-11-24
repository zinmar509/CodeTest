using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Common.Exceptions
{
    public sealed class DuplicateSeqNoException : Exception
    {
        public DuplicateSeqNoException(string fieldName) : base($"{fieldName} is duplicate.")
        {

        }
    }
}
