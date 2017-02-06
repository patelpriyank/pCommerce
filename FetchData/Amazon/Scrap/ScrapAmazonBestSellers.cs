using FetchData.Extensions;
using System;
using System.Linq;
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
                foreach(Li item in bestSellers.Ul_Department.Items)
                {
                    Console.WriteLine(item);
                }

                var subUL = bestSellers.Ul_Department.ChildrenWithTag("ul", null);
                Console.WriteLine(subUL[0].InnerHtml);
                //Console.WriteLine(bestSellers.Ul_Department.Items.Count);
                //Console.WriteLine(bestSellers.Ul_Department.Items.Where(e => e.Text != "Any Department").ToList().Count);
            }
        }
    }
}
