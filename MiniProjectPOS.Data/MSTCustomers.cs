using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjectPOS.Data
{
    [Table("MST_CUSTOMERS")]
    public class MSTCustomers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string CustomerName { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string Email { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(15)]
        public string Phone { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        public string Address { get; set; }

        public int? ProvinceID { get; set; }
        public int? RegionID { get; set; }
        public int? DistrictID { get; set; }

        public int? CreatedBy { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? ModifiedOn { get; set; }

        [ForeignKey("ProvinceID")]
        public virtual MSTProvince Province { get; set; }
        [ForeignKey("RegionID")]
        public virtual MSTRegion Region { get; set; }
        [ForeignKey("DistrictID")]
        public virtual MSTDistrict District { get; set; }
        public virtual ICollection<TRXPayment> Payment { get; set; }
    }
}
