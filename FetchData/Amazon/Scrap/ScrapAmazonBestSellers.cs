using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatiN;

namespace FetchData.Amazon.Scrap
{
    public class ScrapAmazonBestSellers
    {
        public void Scrap()
        {
            using (var browser = new IE("http://localhost:51562"))
            {
                var bestSellers = browser.Page<Pages.AmazonBestSellersPage>();
            }
        }
    }
}
