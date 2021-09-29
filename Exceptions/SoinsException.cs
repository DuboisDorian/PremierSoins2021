using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soins2021Exception
{
    class SoinsException : Exception
    {
        public SoinsException(string message) : base(message)
        {
        }
    }
}
