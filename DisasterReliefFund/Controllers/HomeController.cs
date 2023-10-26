using DisasterReliefFund.Models;
using System;
using System.Configuration;
using System.Web.Mvc;




namespace DisasterReliefFund.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [HttpGet]
        public ActionResult Contact()
        {
            var model = new ContactViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Contact(ContactViewModel contact)
        {
            if (ModelState.IsValid)
            {
                // Handle the submitted contact data, e.g., send an email or save it to a database
                // Redirect to a thank you page or display a success message
            }

            return View(contact);
        }
    }
}


