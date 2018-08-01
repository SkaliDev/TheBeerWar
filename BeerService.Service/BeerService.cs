using BeerService.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerService.Service
{
    public class BeerService
    {
        private readonly BeerContex _context;

        public BeerService(BeerContex contex)
        {
            _context = contex;
        }
    }
}
