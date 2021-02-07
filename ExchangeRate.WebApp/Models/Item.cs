using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRate.WebApp.Models
{
    public class Item
    {
        public string Date { get; set; }
        public string Currency { get; set; }
        public string Quantity { get; set; }
        public string Rate { get; set; }
        public string Unit { get; set; }
    }
}
