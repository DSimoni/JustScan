using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JustScan.Models
{
    public class Menu
    {
        public Int32 BusinessID{ get; set; }

        public string BusinessType { get; set; }

        public string BusinessName { get; set; }

        public string BusinessLanguage { get; set; }

        public Int32 ImageID { get; set; }

        public string CategoryName { get; set; }

        public string SubCategoryName { get; set; }

        public string Description { get; set; }

        public string MetaDescription { get; set; }


        public double Price { get; set; }


    }
}
