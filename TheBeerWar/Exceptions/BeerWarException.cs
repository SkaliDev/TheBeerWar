using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheBeerWar.Exceptions
{
    public class BeerWarException : Exception
    {
        public BeerWarException()
        { }

        public BeerWarException(string message)
            : base(message)
        { }

        public BeerWarException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}