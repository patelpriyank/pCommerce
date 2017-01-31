using FetchData.Amazon.Scrap;
using System;

namespace Main
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            ScrapAmazonBestSellers scrapAzBs = new ScrapAmazonBestSellers();
            scrapAzBs.Scrap();
        }
    }
}
