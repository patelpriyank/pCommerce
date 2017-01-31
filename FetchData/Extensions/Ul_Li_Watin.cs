using WatiN.Core;
using WatiN.Core.Native;

namespace FetchData.Extensions
{
    [ElementTag("ul")]
    public class Ul : ElementContainer<Ul>
    {
        public Ul(DomContainer domContainer, INativeElement nativeElement) : base(domContainer, nativeElement)
        {
        }

        public Ul(DomContainer domContainer, ElementFinder elementFinder) : base(domContainer, elementFinder)
        {
        }

        public LiCollection Items
        {
            get
            {
                return new LiCollection(DomContainer, CreateElementFinder<Li>(
                 delegate (INativeElement nativeElement)
                 {
                     return nativeElement.Children;
                 }, null));
            }
        }
    }

    [ElementTag("li")]
    public class Li : ElementContainer<Li>
    {
        public Li(DomContainer domContainer, INativeElement nativeElement) : base(domContainer, nativeElement)
        {
        }

        public Li(DomContainer domContainer, ElementFinder finder) : base(domContainer, finder)
        {
        }
    }

    public class LiCollection : BaseElementCollection<Li, LiCollection>
    {
        public LiCollection(DomContainer domContainer, ElementFinder elementFinder) :
            base(domContainer, elementFinder)
        {
        }

        protected override LiCollection CreateFilteredCollection(ElementFinder elementFinder)
        {
            return new LiCollection(DomContainer, elementFinder);
        }
    }
}
