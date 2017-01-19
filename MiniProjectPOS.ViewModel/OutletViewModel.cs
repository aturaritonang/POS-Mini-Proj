using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjectPOS.ViewModel
{
    public class OutletViewModel
    {
        public int ID { get; set; }
        public string OutletName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int? ProvinceID { get; set; }
        public string ProvinceName { get; set; }
        public int? RegionID { get; set; }
        public string RegionName { get; set; }
        public int? DistrictID { get; set; }
        public string DistrictName { get; set; }
        public string PostalCode { get; set; }
    }
}
