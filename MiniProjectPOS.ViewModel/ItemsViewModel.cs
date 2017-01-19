using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjectPOS.ViewModel
{
    public class ItemsViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int? CategoryID { get; set; }
        public string CategoryName { get; set; }
    }

    public class ItemsVariantViewModel 
    {
        public int ID { get; set; }
        public string VariantName { get; set; }
        public string SKU { get; set; }
        public decimal? Price { get; set; }
    }
}
