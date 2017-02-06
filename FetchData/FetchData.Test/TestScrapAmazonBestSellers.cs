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
        public void DepartmentMenuShouldHaveTwoLevels()
        {
            using (var browser = new IE("https://www.amazon.com/Best-Sellers/zgbs/ref=zg_bsms_tab"))
            {
                var bestSellers = browser.Page<FetchData.Amazon.Pages.AmazonBestSellersPage>();
                /* Main menu UL has two children. 
                 * 1) <li> = "Any Department"
                 * 2) <ul> = list of departments
                 */
                var childs = bestSellers.Ul_Department.Children();
                Assert.AreEqual(childs.Count(), 2);

            }
        }

        [TestMethod]
        public void DepartmentMenuListShouldHave37Categories()
        {

            var subUl = bestSellers.Ul_Department.ChildWithTag("ul", null);


            Assert.AreEqual(bestSellers.Ul_Department.Items.Where(e => e.Text != "Any Department").ToList().Count, 37);
            Assert.AreEqual(bestSellers.Ul_Department.Items[0].Text.Trim(), "Amazon Launchpad");
            Assert.AreEqual(bestSellers.Ul_Department.Items[36].Text.Trim(), "Video Games");
        }
    }
