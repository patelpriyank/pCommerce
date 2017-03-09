using FetchData.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using WatiN.Core;
using FetchData.Models;

namespace FetchData.Amazon.Scrap
{
    public class ScrapAmazonBestSellers
    {
        private List<MenuItemModel> _visitedNodes = new List<MenuItemModel>();
        private Stack<Li> _allLeafNodes = new Stack<Li>();
        private int MAX_RECURSSION_LOOP = 10;
        private int _currentLoopCounter = 0;

        public void Scrap()
        {
            using (var browser = new IE("https://www.amazon.com/Best-Sellers/zgbs/ref=zg_bsms_tab"))
            {
                var bestSellersPage = browser.Page<Pages.AmazonBestSellersPage>();
                var allDepts = bestSellersPage.Ul_DepartmentList.Items;
                _allLeafNodes.Clear();

                var rootMenu = new MenuItemModel();
                rootMenu.Name = "All Departments";
                rootMenu.Path = rootMenu.Name;
                _visitedNodes.Add(rootMenu);

                foreach (Li dept in allDepts)
                {
                    /*
                     * Clicking hyperlik on page automatically refreshes 
                     * AmazonBestSellersPage instance with latest DOM and HTML.
                    */
                    dept.Links[0].Click();
                    _traverseToLeafMenus(bestSellersPage, rootMenu);
                }
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
        
        private void _traverseToLeafMenus(Pages.AmazonBestSellersPage bestSellersPage, MenuItemModel parentNode)
        {
            var selectedMenu = new MenuItemModel();
            selectedMenu.Name = bestSellersPage.Li_DepartmentSelected.InnerHtml;
            selectedMenu.Path = parentNode.Path + "->" + selectedMenu.Name;
            _visitedNodes.Add(selectedMenu);

            if (_currentLoopCounter < MAX_RECURSSION_LOOP)
                _currentLoopCounter++;
            else
                return;
            
            //if a leaf node, then add all its siblings to stacks
            if (bestSellersPage.IsLeafMenu())
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
                    _traverseToLeafMenus(bestSellersPage, selectedMenu);
                }
            }
        }
        
    }
}
