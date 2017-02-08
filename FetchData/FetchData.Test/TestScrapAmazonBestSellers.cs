using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WatiN.Core;
using System.Linq;

namespace FetchData.Test
{
    [TestClass]
    public class TestScrapAmazonBestSellers
    {
        [TestMethod]
        public void DepartmentMenuRootHasTwoChildrens()
        {
            using (var browser = new IE("https://www.amazon.com/Best-Sellers/zgbs/ref=zg_bsms_tab"))
            {
                var bestSellers = browser.Page<FetchData.Amazon.Pages.AmazonBestSellersPage>();
                /* Main menu UL has two children. 
                 * 1) <li> = "Any Department"
                 * 2) <ul> = list of departments
                 */
                var childs = bestSellers.Ul_DepartmentMenuRoot.Children();
                Assert.AreEqual(childs.Count(), 2);

            }
        }

        [TestMethod]
        public void DepartmentMenuListShouldHave37Categories()
        {
            using (var browser = new IE("https://www.amazon.com/Best-Sellers/zgbs/ref=zg_bsms_tab"))
            {
                var bestSellers = browser.Page<FetchData.Amazon.Pages.AmazonBestSellersPage>();
                /* Main menu UL has two children. 
                 * 1) <li> = "Any Department"
                 * 2) <ul> = list of departments
                 */
                var ulDepts = bestSellers.Ul_DepartmentList.Items.Count();
                Assert.AreEqual(ulDepts, 37);
            }
        }
    }
}
