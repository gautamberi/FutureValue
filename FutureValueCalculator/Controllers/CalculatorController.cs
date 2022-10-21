using FutureValueCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FutureValueCalculator.Controllers
{
    public class CalculatorController : Controller
    {
        // GET: Calculator
        /// <summary>
        /// index 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {

            //FutureValueModel model = new FutureValueModel();
            //ViewBag.FutureValue = 0;
            return View();
        }

        [HttpPost]
        public ActionResult Index(FutureValueModel model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.FutureValue = model.CalculateFV().ToString("C");
            }
            else
            {
                ViewBag.FutureValue = "Something went wrong!";
            }
            
            return View(model);
        }
    }
}