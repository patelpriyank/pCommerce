using FetchData.Extensions;
using System;
using System.Collections.Generic;
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
                var bestSellersPage = browser.Page<Pages.AmazonBestSellersPage>();

                Console.WriteLine(bestSellersPage.Ul_DepartmentMenuRoot.InnerHtml);
                Console.WriteLine(bestSellersPage.Ul_DepartmentList.InnerHtml);
                var allDepts = bestSellersPage.Ul_DepartmentList.Items;
                foreach(var dept in allDepts)
                {
                    _loadAllLeafNodes(bestSellersPage, dept);
                }
                /*
                foreach (Li item in allDepts)
                {
                    item.Links[0].Click();
                    Console.WriteLine( _bestSellersPage.Ul_DepartmentMenuRoot.InnerHtml);
                    Console.WriteLine( _bestSellersPage.Ul_DepartmentList.InnerHtml);
                    Console.WriteLine(item.InnerHtml);
                }
                */
            }
        }
        
        private Stack<Li> _allLeafNodes = new Stack<Li>();
        private void _loadAllLeafNodes(Pages.AmazonBestSellersPage bestSellersPage, Li deptSelected)
        {
            string prevInnerHtml = bestSellersPage.Ul_DepartmentMenuRoot.InnerHtml;

            //click link inside <li> to load that sub-dept page
            //this will automatically update AmazonBestSellersPage with new page load
            deptSelected.Links[0].Click();

            //determine if this dept is NOT a leaf node in dept menu hierarchy
            //then keep drilling down
            if (prevInnerHtml != bestSellersPage.Ul_DepartmentMenuRoot.InnerHtml)
            {
                foreach (var dept in bestSellersPage.Ul_DepartmentList.Items)
                {
                    _loadAllLeafNodes(bestSellersPage, dept);
                }
            }

            //if a leaf node, then add all its siblings to stacks
            foreach(var item in bestSellersPage.Ul_DepartmentList.Items)
            {
                _allLeafNodes.Push(item);
            }
        }
        
    }
}
