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
                foreach (Li item in bestSellers.Ul_DepartmentList.Items)
                {
                    item.Links[0].Click();
                    Console.WriteLine(item.InnerHtml);
                }
            }
        }

        Pages.AmazonBestSellersPage _previousPage;
        private Pages.AmazonBestSellersPage _openDepartmentPage(Ul browserRoot, Li linkToClick)
        {
            //if there is no sub-dept found under department root menu then return. 
            if (linkToClick == null)
                return _previousPage;

            return 
        }
    }
}
