using FetchData.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using WatiN.Core;

namespace FetchData.Amazon.Scrap
{
    public class ScrapAmazonBestSellers
    {
        Pages.AmazonBestSellersPage _bestSellersPage;
        public void Scrap()
        {
            using (var browser = new IE("https://www.amazon.com/Best-Sellers/zgbs/ref=zg_bsms_tab"))
            {
                _bestSellersPage = browser.Page<Pages.AmazonBestSellersPage>();

                Console.WriteLine( _bestSellersPage.Ul_DepartmentMenuRoot.InnerHtml);
                Console.WriteLine( _bestSellersPage.Ul_DepartmentList.InnerHtml);
                var allDepts =  _bestSellersPage.Ul_DepartmentList.Items;
                _traverseDepartmentMenuTree(allDepts[0],  _bestSellersPage.Ul_DepartmentMenuRoot);
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
        
        private Stack<Ul> _departmentMenuStack = new Stack<Ul>();
        private void _traverseDepartmentMenuTree(Li deptSelected, Ul parentUl)
        {
            deptSelected.Links[0].Click();
            Console.WriteLine(_bestSellersPage.Ul_DepartmentMenuRoot.InnerHtml);
            Console.WriteLine(_bestSellersPage.Ul_DepartmentList.InnerHtml);
            
        }
        /*
        Pages.AmazonBestSellersPage _previousPage;
        private Pages.AmazonBestSellersPage _openDepartmentPage(Ul browserRoot, Li linkToClick)
        {
            //if there is no sub-dept found under department root menu then return. 
            if (linkToClick == null)
                return _previousPage;

            
        }
        */
    }
}
