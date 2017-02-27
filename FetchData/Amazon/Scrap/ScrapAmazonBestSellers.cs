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

        /*
         1. click on the link inside the node
         2. get 'zg_selected' <li>
         3. if parent <ul> has structure of <ul> <li zg_selected><ul>...</ul> </ul> then it is not a leaf node
            if parent <ul> has structure of <ul> all <li> </ul> then it is a leaf node
         4. Add all <li> under that parents into leaf nodes stack
         5. otherwise keep drillingdown 
             */
        
        private void _loadAllLeafNodes(Pages.AmazonBestSellersPage bestSellersPage)
        {
            if (_currentLoopCounter < MAX_RECURSSION_LOOP)
                _currentLoopCounter++;
            else
                return;

            //click link inside <li> to load that sub-dept page
            //this will automatically update AmazonBestSellersPage with new page load
            bestSellersPage.Li_DepartmentSelected.Links[0].Click();

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
