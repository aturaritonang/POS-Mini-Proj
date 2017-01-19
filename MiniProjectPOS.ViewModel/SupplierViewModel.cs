using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjectPOS.ViewModel
{
    public class SupplierViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int? ProvinceID { get; set; }
        public string ProvinceName { get; set; }
        public int? RegionID { get; set; }
        public string RegionName { get; set; }
        public int? DistrictID { get; set; }
        public string DistrictName { get; set; }
        [Display(Name="Kode Pos")]
        [MaxLength(5)]
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
