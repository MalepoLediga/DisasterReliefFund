using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DisasterReliefFund.Models
{
    public class Statistics
    {
        public int DonationMoney { get; set; }
        public int GoodsNumber { get; set; }

        public string DisasterName { get; set; } = string.Empty;

        public int MoneyAllocated { get; set;}

        public string GoodsAllocated { get; set; } = string.Empty;

    }
}