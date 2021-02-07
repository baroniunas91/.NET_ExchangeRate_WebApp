using ExchangeRate.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ExchangeRate.WebApp.Services
{
    public class ItemService
    {
        public void SortByRate(List<Item> list)
        {
            list.Sort(delegate (Item x, Item y)
            {
                if (x.Rate == null && y.Rate == null) return 0;
                else if (x.Rate == null) return -1;
                else if (y.Rate == null) return 1;
                else return y.Rate.CompareTo(x.Rate);
            });
        }

        public List<Item> ParseXmlNode(string response)
        {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(response);
            XmlNodeList xnList = xml.SelectNodes("/ExchangeRates/item");

            var itemsList = new List<Item>();
            foreach (XmlNode xn in xnList)
            {
                var item = new Item();
                item.Date = xn["date"].InnerText;
                item.Currency = xn["currency"].InnerText;
                item.Quantity = xn["quantity"].InnerText;
                item.Rate = xn["rate"].InnerText;
                item.Unit = xn["unit"].InnerText;
                itemsList.Add(item);
            }
            return itemsList;
        }
    }
}
