using FetchData.Extensions;
using WatiN.Core;

namespace FetchData.Amazon.Pages
{
    public class AmazonBestSellersPage : WatiN.Core.Page
    {
        private const string ul_DepartmentId = "zg_browseRoot";

        public Ul Ul_Department
        {
            get { return Document.ElementOfType<Ul>(ul_DepartmentId); }
        }
    }
}
