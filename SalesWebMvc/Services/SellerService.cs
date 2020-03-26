using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Services
{
    public class SellerService
    {
        private readonly SalesWebMvcContext _context;

        public SellerService(SalesWebMvcContext context) //dependencia do context
        {
            _context = context;
        }

        public List<Seller> FindAll() //operação syncrona
        {
            return _context.Seller.ToList();
        }
    }
}
