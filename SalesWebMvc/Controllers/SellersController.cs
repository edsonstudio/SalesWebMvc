using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Services;

namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService; //dependencia para o SellerService

        public SellersController(SellerService sellerService) //construtor para injetar dependencia
        {
            _sellerService = sellerService;
        }
        public IActionResult Index()
        {
            var list = _sellerService.FindAll();
            return View(list); //esse list vai enviar a lista de vendedores para o objeto model na view Index correspondente ao controller Sellers
        }
    }
}