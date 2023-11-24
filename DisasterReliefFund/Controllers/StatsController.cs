using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DisasterReliefFund.Models;

namespace DisasterReliefFund.Controllers
{
    public class StatsController : Controller
    {
        // GET: Stats
        public ActionResult Index()
        {
            Statistics statistics = new Statistics()
            {


                DonationMoney = 50000,
                GoodsNumber = 20,
                DisasterName = "Alex relief", 
              MoneyAllocated = 10000,
              GoodsAllocated = "Alex relief fund"


    };
            

            return View(statistics);
        }
    }
}