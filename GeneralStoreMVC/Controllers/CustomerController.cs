using GeneralStoreMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GeneralStoreMVC.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        // GET: Customer
        public ActionResult Index()
        {
            return View(_db.Customers.ToList());
        }
    }
}