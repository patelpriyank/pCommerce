using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FetchData.Models
{
    public class MenuItemModel
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _path;
        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }

        private bool _isLeafMenu;
        public bool IsLeafMenu
        {
            get { return _isLeafMenu; }
            set { _isLeafMenu = value; }
        }
    }
}
