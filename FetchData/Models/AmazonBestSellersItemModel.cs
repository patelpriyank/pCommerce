using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FetchData.Models
{
    public class AmazonBestSellersItemModel
    {
        private string _department;
        public string Department
        {
            get { return _department; }
            set { _department = value; }
        }

        private string _rank;
        public string Rank
        {
            get { return _rank; }
            set { _rank = value; }
        }

        private string _starRatings;
        public string StarRatings
        {
            get { return _starRatings; }
            set { _starRatings = value; }
        }

        private string _totalReviews;
        public string TotalReviews
        {
            get { return _totalReviews; }
            set { _totalReviews = value; }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _price;
        public string Price
        {
            get { return _price; }
            set { _price = value; }
        }

        private bool _iaPeimw;
        public bool IsPrime
        {
            get { return _iaPeimw;  }
            set { _iaPeimw = value; }
        }

        private string _departmentHierarchy;
        public string DepartmentHierarchy
        {
           get { return _departmentHierarchy; }
            set { _departmentHierarchy = value; }
        }

    }
}
