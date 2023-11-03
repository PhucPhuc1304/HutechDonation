using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Web_Donation.Models;

namespace Web_Donation.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMongoCollection<Product> _productCollection;

        public HomeController(MongoDBContext context)
        {
            _productCollection = context.GetProductCollection();
        }

        public IActionResult Index()
        {
            List<Product> products = _productCollection.Find(product => true).ToList();
            return View(products);
        }
    }

}
