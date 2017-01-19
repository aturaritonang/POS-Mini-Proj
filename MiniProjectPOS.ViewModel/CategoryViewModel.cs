using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjectPOS.ViewModel
{
    public class CategoryViewModel
    {
        public int ID { get; set; }

        [Display(Name="Name")]
        public string Name { get; set; }
        [Display(Name = "Item Stock")]
        public int? ItemStock { get; set; }
    }
}
