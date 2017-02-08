using FetchData.Extensions;
using WatiN.Core;

namespace FetchData.Amazon.Pages
{
    public class AmazonBestSellersPage : WatiN.Core.Page
    {
        private const string ul_DepartmentId = "zg_browseRoot";

        public Ul Ul_DepartmentMenuRoot
        {
            get { return Document.ElementOfType<Ul>(ul_DepartmentId); }
        }

        public Ul Ul_DepartmentList
        {
            get
            {
                return Document.ElementOfType<Ul>(ul_DepartmentId).ChildrenOfType<Ul>()[0];
                //return ((IElementContainer)Document.Element(Find.ById(ul_DepartmentId))).ElementOfType<Ul>("");
            }
        }
    }
}
