using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeerService.Exceptions
{
    public class BeerException : Exception
    {
        public BeerException()
        { }

        public BeerException(string message)
            : base(message)
        { }

        public BeerException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}