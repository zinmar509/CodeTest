using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Common.Exceptions
{
    public sealed class InvalidDataFormatException : Exception
    {
        public InvalidDataFormatException(string message) : base(message)
        {

        }
    }
}
