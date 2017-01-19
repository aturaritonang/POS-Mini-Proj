using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjectPOS.Data
{
    [Table("MST_DISTRICT")]
    public class MSTDistrict
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; } 
        public int RegionID { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string DistrictName { get; set; }
        public int? CreatedBy { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? ModifiedOn { get; set; }

        [ForeignKey("RegionID")]
        public virtual MSTRegion Region { get; set; }
        public virtual ICollection<MSTCustomers> Customers { get; set; }
    }
}
