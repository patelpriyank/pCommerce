using FetchData.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using WatiN.Core;

namespace FetchData.Amazon.Scrap
{
    public class ScrapAmazonBestSellers
    {
        private Stack<Li> _allLeafNodes = new Stack<Li>();
        private int MAX_RECURSSION_LOOP = 10;
        private int _currentLoopCounter = 0;

        public void Scrap()
        {
            using (var browser = new IE("https://www.amazon.com/Best-Sellers/zgbs/ref=zg_bsms_tab"))
            {
                var bestSellersPage = browser.Page<Pages.AmazonBestSellersPage>();

                Console.WriteLine(bestSellersPage.Ul_DepartmentMenuRoot.InnerHtml);
                Console.WriteLine(bestSellersPage.Ul_DepartmentList.InnerHtml);
                var allDepts = bestSellersPage.Ul_DepartmentList.Items;
                _allLeafNodes.Clear();
                foreach (var dept in allDepts)
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

        private void _loadAllLeafNodes(Pages.AmazonBestSellersPage bestSellersPage, Li deptSelected)
        {
            if (_currentLoopCounter < MAX_RECURSSION_LOOP)
                _currentLoopCounter++;
            else
                return;

            string prevInnerHtml = bestSellersPage.Ul_DepartmentMenuRoot.InnerHtml;

            //click link inside <li> to load that sub-dept page
            //this will automatically update AmazonBestSellersPage with new page load
            deptSelected.Links[0].Click();

            //if a leaf node, then add all its siblings to stacks
            if (bestSellersPage.IsLeafNode(deptSelected))
            {
                foreach (var item in bestSellersPage.Ul_DepartmentList.Items)
                {
                    _allLeafNodes.Push(item);
                }
                return;
            }
            //else keep drilling down
            else 
            {
                foreach (var dept in bestSellersPage.Ul_DepartmentList.Items)
                {
                    _loadAllLeafNodes(bestSellersPage, dept);
                }
            }
        }
        
    }
}
