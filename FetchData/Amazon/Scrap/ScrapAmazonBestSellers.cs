using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatiN;
using WatiN.Core;

namespace FetchData.Amazon.Scrap
{
    public class ScrapAmazonBestSellers
    {
        public void Scrap()
        {
            using (var browser = new IE("https://www.amazon.com/Best-Sellers/zgbs/ref=zg_bsms_tab"))
            {
                var bestSellers = browser.Page<Pages.AmazonBestSellersPage>();
                Console.WriteLine(bestSellers.Ul_Department.ToString());
            }
        }
    }
}
