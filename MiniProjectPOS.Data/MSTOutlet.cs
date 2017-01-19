using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjectPOS.Data
{
    [Table("MST_OUTLET")]
    public class MSTOutlet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Column(TypeName="VARCHAR")]
        [StringLength(50)]
        public string OutletName { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        public string Address { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(16)]
        public string Phone { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string Email { get; set; }

        public int? ProvinceID { get; set; }
        public int? RegionID { get; set; }
        public int? DistrictID { get; set; }
        [Column(TypeName="VARCHAR")]
        [StringLength(6)]
        public string PostalCode { get; set; }

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

        public virtual ICollection<MSTCategory> MSTCategorys { get; set; }

        public virtual ICollection<TRXAdjustmentStock> AdjustmentStocks { get; set; }

        public virtual ICollection<TRXPurchaseOrder> PurchaseOrders { get; set; }

        public virtual ICollection<MSTItemsVariantOutlet> ItemsVariantOutlets { get; set; }
    }
}
