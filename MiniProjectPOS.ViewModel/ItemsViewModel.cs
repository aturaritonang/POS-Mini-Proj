using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjectPOS.ViewModel
{
    public class ItemsViewModel
    {
        public int ID { get; set; }
        public string VariantName { get; set; }
        public int? CategoryID { get; set; }
        public string CategoryName { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:n2}")]
        public decimal? Price { get; set; }
        public int? InStock { get; set; }
        public int? AlertStock { get; set; }
        public List<ItemsVariantViewModel> ItemVarians { get; set; }
    }

    public class ItemsVariantViewModel 
    {
        public int ID { get; set; }
        public string VariantName { get; set; }
        public string SKU { get; set; }
        public decimal? Price { get; set; }
    }


}
