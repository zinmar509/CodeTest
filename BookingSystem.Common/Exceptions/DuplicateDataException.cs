using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Common.Exceptions
{
    public sealed class DuplicateDataException : Exception
    {
        public DuplicateDataException(string fieldName) : base($"{fieldName} is already exist.")
        {

        }
    }
}
