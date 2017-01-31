using FetchData.Amazon.Scrap;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            ScrapAmazonBestSellers scrapAzBs = new ScrapAmazonBestSellers();
            scrapAzBs.Scrap();
        }
    }
}
