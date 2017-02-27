using FetchData.Extensions;
using WatiN.Core;

namespace FetchData.Amazon.Pages
{
    public class AmazonBestSellersPage : WatiN.Core.Page
    {
        private const string ul_DepartmentId = "zg_browseRoot";
        private const string li_selected = "zg_selected";

        public Li Li_DepartmentSelected
        {
            get
            {
                return Document.ElementOfType<Li>(li_selected);
            }
        }
        
        public bool IsLastMenuLevel()
        {
            if (Li_DepartmentSelected.Parent != null)
            {
                Ul parentUl = ((Ul)Li_DepartmentSelected.Parent);
                if (parentUl.ChildrenOfType<Ul>().Count == 0) return true;
            }
            return false;
        }

        public Ul Ul_DepartmentMenuRoot
        {
            get { return Document.ElementOfType<Ul>(ul_DepartmentId); }
        }

        public Ul Ul_DepartmentList
        {
            get
            {
                return Ul_DepartmentMenuRoot.ChildrenOfType<Ul>()[0];
                //return ((IElementContainer)Document.Element(Find.ById(ul_DepartmentId))).ElementOfType<Ul>("");
            }
        }
        
    }
}
