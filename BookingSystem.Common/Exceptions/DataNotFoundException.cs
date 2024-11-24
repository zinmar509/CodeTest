using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Common.Exceptions
{
    public sealed class DataNotFoundException : Exception
    {
        public DataNotFoundException(string fieldName) : base($"{fieldName} does not found.")
        {
            
        }
    }
}
